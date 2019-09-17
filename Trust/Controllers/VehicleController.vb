Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Trust.Trust
Imports PagedList
Imports ClosedXML.Excel
Imports System.IO

Namespace Controllers
    Public Class VehicleController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Private dbtks As New TKSEntities
        Private dbtsm As New EntityTSM1
        Function ErrorUpload() As ActionResult
            Return View()
        End Function

        Function UploadData() As ActionResult
            Dim form As New Ms_Vehicle_Import_Form
            form.TKS = True
            form.Trust = True
            Return View(form)
        End Function
        Function ConvInt(value As String, column As String, ByRef Setcolumn As String) As Integer?
            Setcolumn = column
            Return If(value = "", Nothing, Convert.ToInt32(value))
        End Function
        Function ConvDate(value As String, column As String, ByRef Setcolumn As String) As Date?
            If value = "" Then Return Nothing
            Setcolumn = column
            Try
                'jika dia pake yg integer
                If value > 59 Then value -= 1 ''// Excel/Lotus 2/29/1900 bug
                Return New DateTime(1899, 12, 31).AddDays(value)
            Catch
                'ika dia string
                Return If(value = "", Nothing, Convert.ToDateTime(value))
            End Try


        End Function
        Public Shared Function FromExcelSerialDate(ByVal SerialDate As Integer) As DateTime
            If SerialDate > 59 Then SerialDate -= 1 ''// Excel/Lotus 2/29/1900 bug
            Return New DateTime(1899, 12, 31).AddDays(SerialDate)
        End Function
        Function ConvDec(value As String, column As String, ByRef Setcolumn As String) As Decimal?
            Setcolumn = column
            Return If(value = "", Nothing, Convert.ToDecimal(value))
        End Function
        Function ConvBool(value As String, column As String, ByRef Setcolumn As String) As Boolean?
            Setcolumn = column
            Return If(value = "", Nothing, Convert.ToBoolean(value))
        End Function
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function UploadData(model As Ms_Vehicle_Import_Form) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim message = ""
            Dim line = 1
            Dim Column = ""
            Dim allrow = 0
            Dim dt As New DataTable()
            Dim stream = model.uploaded.InputStream
            Using workBook As New XLWorkbook(stream)
                Dim workSheet = workBook.Worksheet(1)
                Dim firstRow As Boolean = True
                Dim secondRow As Boolean = True
                If workSheet.Rows.Count = 1 Then
                    message = "Must fill Data."
                    GoTo eror
                End If

                For Each row In workSheet.Rows()
                    'Use the first row to add columns to DataTable.
                    If firstRow Then
                        firstRow = False
                    ElseIf firstRow = False And secondRow Then
                        For Each cell As IXLCell In row.Cells()
                            dt.Columns.Add(cell.Value.ToString())
                            allrow += 1
                        Next
                        secondRow = False
                    Else

                        'Add rows to DataTable.
                        dt.Rows.Add()
                        'For Each cell As IXLCell In row.Cells()
                        '    dt.Rows(dt.Rows.Count - 1)(i) = cell.Value.ToString()
                        'Next
                        For i As Integer = 1 To 41
                            dt.Rows(dt.Rows.Count - 1)(i - 1) = row.Cell(i).Value.ToString()
                        Next


                        'If i <> 0 And i <> allrow Then
                        '    message = "Must fill all Field for line " + line.ToString + "."
                        '    GoTo eror
                        'End If
                        'line += 1
                    End If
                Next
            End Using
            Dim list = New List(Of Ms_Vehicle_Import)
            line = 1
            Try
                For Each row As DataRow In dt.Rows
                    If row.Item("chassis_no").ToString <> "" Then
                        Dim model_ID = ConvInt(row.Item("Model_ID").ToString, "Model_ID", Column)
                        Dim type = db.Ms_Vehicle_Models.Where(Function(x) x.Model_ID = model_ID).Select(Function(x) x.Type).FirstOrDefault
                        Dim add As New Ms_Vehicle_Import With {.owner_id = ConvInt(row.Item("owner_id").ToString, "owner_id", Column),
                        .license_no = row.Item("license_no").ToString,
                        .manufacturer_id = ConvInt(row.Item("manufacturer_id").ToString, "manufacturer_id", Column),
                        .Model_ID = model_ID,
                        .color = row.Item("color").ToString,
                        .year = ConvInt(row.Item("year").ToString, "year", Column),
                        .chassis_no = row.Item("chassis_no").ToString,
                        .machine_no = row.Item("machine_no").ToString,
                        .title_no = row.Item("title_no").ToString,
                        .serial_no = row.Item("serial_no").ToString,
                        .registration_no = row.Item("registration_no").ToString,
                        .registration_expdate = ConvDate(row.Item("registration_expdate").ToString, "registration_expdate", Column),
                        .discount = ConvDec(row.Item("discount").ToString, "discount", Column),
                        .price = ConvDec(row.Item("price").ToString, "price", Column),
                        .comment = row.Item("comment").ToString,
                        .date_book = ConvDate(row.Item("date_book").ToString, "date_book", Column),
                        .Tmp_Plat = row.Item("Tmp_Plat").ToString,
                        .CarType = row.Item("CarType").ToString,
                        .STNK_Name = row.Item("STNK_Name").ToString,
                        .STNK_Address = row.Item("STNK_Address").ToString,
                        .CC = ConvInt(row.Item("CC").ToString, "CC", Column),
                        .PO_No = row.Item("PO_No").ToString,
                        .Harga_Beli = ConvDec(row.Item("Harga_Beli").ToString, "Harga_Beli", Column),
                        .Kwitansi_Date = ConvDate(row.Item("Kwitansi_Date").ToString, "Kwitansi_Date", Column),
                        .Kwitansi_No = row.Item("Kwitansi_No").ToString,
                        .FakturPajak_Date = ConvDate(row.Item("FakturPajak_Date").ToString, "FakturPajak_Date", Column),
                        .FakturPajak_No = row.Item("FakturPajak_No").ToString,
                        .VAT = row.Item("VAT").ToString,
                        .Dealer = row.Item("Dealer").ToString,
                        .Type = type}
                        list.Add(add)
                        line += 1
                    End If
                Next row
            Catch ex As Exception
                message = "In Line " + line.ToString + " Column " + Column + " " + ex.Message
                GoTo eror
            End Try

            Dim listTrustVehicle = db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False).ToList
            Dim listTKSVehicle = dbtks.vehicles.ToList
            Dim listTrustModel = db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).ToList
            Dim listTKSOwner = dbtks.owners.ToList
            Dim listTKSManufacturer = dbtks.manufacturers.ToList

            'Jika Plat ada yg sama
            If list.Where(Function(x) x.license_no <> "").GroupBy(Function(x) x.license_no).Where(Function(g) g.Count() > 1).Any Then
                message = "Can't Double Plat No"
                GoTo eror
            ElseIf list.GroupBy(Function(x) x.chassis_no).Where(Function(g) g.Count() > 1).Any Then
                message = "Can't Double Chassis No"
                GoTo eror
            ElseIf list.Where(Function(x) x.date_book Is Nothing).Any Then
                message = "date_book Must be fill"
                GoTo eror
            ElseIf list.Where(Function(x) x.registration_expdate Is Nothing).Any Then
                message = "Perpanjang STNK Must be fill"
                GoTo eror
            ElseIf model.Trust And list.Where(Function(g) listTrustVehicle.Where(Function(x) x.license_no <> "").Select(Function(x) x.license_no).Contains(g.license_no)).Any Then
                message = "Plat No is already exists in Trust"
                GoTo eror
            ElseIf model.Trust And list.Where(Function(g) listTrustVehicle.Select(Function(x) x.chassis_no).Contains(g.chassis_no)).Any Then
                message = "Chassis No is already exists in Trust"
                GoTo eror
            ElseIf model.TKS And list.Where(Function(g) listTKSVehicle.Select(Function(x) x.license_no).Contains(g.license_no)).Any Then
                message = "Plat No is already exists in TKS"
                GoTo eror
            ElseIf model.TKS And list.Where(Function(g) listTKSVehicle.Select(Function(x) x.chassis_no).Contains(g.chassis_no)).Any Then
                message = "Chassis No is already exists in TKS"
                GoTo eror
            ElseIf model.Trust Then
                line = 1
                For Each i In list
                    If Not listTrustModel.Where(Function(g) g.Model_ID = i.Model_ID).Any Then
                        message = "In Line " + line.ToString + " Column Model_ID, Model_ID is not exists in Trust."
                        GoTo eror
                    End If
                    line += 1
                Next
            ElseIf model.TKS Then
                line = 1
                For Each i In list
                    If Not listTKSOwner.Where(Function(g) g.owner_id = i.owner_id).Any Then
                        message = "In Line " + line.ToString + " Column owner_id, owner_id is not exists in TKS."
                        GoTo eror
                    End If
                    line += 1
                Next
                line = 1
                For Each i In list
                    If Not listTKSManufacturer.Where(Function(g) g.manufacturer_id = i.manufacturer_id).Any Then
                        message = "In Line " + line.ToString + " Column manufacturer_id, manufacturer_id is not exists in TKS."
                        GoTo eror
                    End If
                    line += 1
                Next
            End If

            If model.Trust Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        For Each i In list
                            Dim newVehicle As New Ms_Vehicles With {.Tmp_Plat = i.Tmp_Plat, .license_no = i.license_no, .Model_ID = i.Model_ID, .color = i.color, .year = i.year,
                                .chassis_no = i.chassis_no, .machine_no = i.machine_no, .serial_no = i.serial_no, .title_no = i.title_no,
                                .type = i.CarType, .CC = i.CC, .STNK_Name = i.STNK_Name, .STNK_Address = i.STNK_Address,
                                .PO_No = i.PO_No, .Harga_Beli = i.Harga_Beli, .Kwitansi_Date = i.Kwitansi_Date, .Kwitansi_No = i.Kwitansi_No, .FakturPajak_Date = i.FakturPajak_Date,
                                .FakturPajak_No = i.FakturPajak_No, .VAT = i.VAT, .Dealer = i.Dealer, .CreatedBy = user, .CreatedDate = DateTime.Now, .IsDeleted = False}
                            db.Ms_Vehicles.Add(newVehicle)
                        Next
                        db.SaveChanges()
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        message = ex.Message
                        GoTo eror
                    End Try
                End Using
            End If
            If model.TKS Then
                Using dbs = dbtks.Database.BeginTransaction
                    Try
                        For Each i In list
                            Dim newVehicle As New vehicle With {.owner_id = i.owner_id, .license_no = If(i.license_no = "", i.Tmp_Plat, i.license_no),
                                .type = i.Type, .color = i.color, .year = i.year,
                                .chassis_no = i.chassis_no, .machine_no = i.machine_no, .serial_no = i.serial_no, .title_no = i.title_no,
                                .registration_no = i.registration_no, .registration_expdate = i.registration_expdate, .manufacturer_id = i.manufacturer_id,
                                .discount = i.discount, .price = i.price, .comment = i.comment, .date_book = i.date_book, .date_entered = DateTime.Now,
                                .coverage = 0, .category = False, .status = 0, .remove = False, .date_insurance_end = "1900-01-01"}
                            dbtks.vehicles.Add(newVehicle)
                        Next
                        dbtks.SaveChanges()
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        If model.Trust Then
                            message = "Trust is done and TKS Error:" + ex.Message
                        Else
                            message = ex.Message
                        End If
                        GoTo eror
                    End Try
                End Using
                Using dbs = dbtsm.Database.BeginTransaction
                    Try
                        For Each i In list
                            Dim newVehicle As New vehicle With {.owner_id = i.owner_id, .license_no = If(i.license_no = "", i.Tmp_Plat, i.license_no), .type = i.Type, .color = i.color, .year = i.year,
                                .chassis_no = i.chassis_no, .machine_no = i.machine_no, .serial_no = i.serial_no, .title_no = i.title_no,
                                .registration_no = i.registration_no, .registration_expdate = i.registration_expdate, .manufacturer_id = i.manufacturer_id,
                                .discount = i.discount, .price = i.price, .comment = i.comment, .date_book = i.date_book, .date_entered = DateTime.Now,
                                .coverage = 0, .category = False, .status = 0, .remove = False, .date_insurance_end = "1900-01-01"}
                            dbtsm.vehicles.Add(newVehicle)
                        Next
                        dbtsm.SaveChanges()
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        If model.Trust Then
                            message = "Trust is done and TKS, TSM Error:" + ex.Message
                        Else
                            message = ex.Message
                        End If
                        GoTo eror
                    End Try
                End Using
            End If


            Return RedirectToAction("Index")

eror:
            ViewBag.Message = message
            Return View()
        End Function
        <HttpPost>
        Function ExportExcel() As FileResult
            Dim dtVehicle = New DataTable("Vehicle")
            'Dim dataVehicle = {New DataColumn("Tmp_Plat"),
            '            New DataColumn("license_no"),
            '            New DataColumn("x"),
            '            New DataColumn("owner_id"),
            '            New DataColumn("manufacturer_id"),
            '            New DataColumn("Model_ID"),
            '            New DataColumn("CarType"),
            '            New DataColumn("year"),
            '            New DataColumn("color"),
            '            New DataColumn("serial_no"),
            '            New DataColumn("registration_no"),
            '            New DataColumn("title_no"),
            '            New DataColumn("chassis_no"),
            '            New DataColumn("machine_no"),
            '            New DataColumn("CC"),
            '            New DataColumn("xx"),
            '            New DataColumn("STNK_Name"),
            '            New DataColumn("STNK_Address"),
            '            New DataColumn("PO_No"),
            '            New DataColumn("price"),
            '            New DataColumn("discount"),
            '            New DataColumn("Harga_Beli"),
            '            New DataColumn("xxx"),
            '            New DataColumn("Kwitansi_Date"),
            '            New DataColumn("Kwitansi_No"),
            '            New DataColumn("FakturPajak_Date"),
            '            New DataColumn("FakturPajak_No"),
            '            New DataColumn("VAT"),
            '            New DataColumn("Dealer"),
            '            New DataColumn("xxxx"),
            '            New DataColumn("registration_expdate"),
            '            New DataColumn("date_book"),
            '            New DataColumn("comment")}
            'dtVehicle.Columns.AddRange(dataVehicle)

            Dim dtModel = New DataTable("Model")
            Dim dataModel = {New DataColumn("Model_ID"),
                            New DataColumn("Type")}
            dtModel.Columns.AddRange(dataModel)
            For Each model In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Type).ToList
                dtModel.Rows.Add(model.Model_ID, model.Type)
            Next

            Dim dtOwner = New DataTable("Owner")
            Dim dataOwner = {New DataColumn("owner_id"),
                            New DataColumn("owner"),
                            New DataColumn("code"),
                            New DataColumn("address_1"),
                            New DataColumn("address_2")}
            dtOwner.Columns.AddRange(dataOwner)
            For Each x In dbtks.owners.ToList
                dtOwner.Rows.Add(x.owner_id, x.owner1, x.code, x.address_1, x.address_2)
            Next

            Dim dtManufacturer = New DataTable("Manufacturer")
            Dim dataManufacturer = {New DataColumn("manufacturer_id"),
                            New DataColumn("manufacturer")}
            dtManufacturer.Columns.AddRange(dataManufacturer)
            For Each x In dbtks.manufacturers.ToList
                dtManufacturer.Rows.Add(x.manufacturer_id, x.manufacturer1)
            Next



            Using wb As New XLWorkbook
                Dim vehicle = wb.Worksheets.Add(dtVehicle)
                wb.Worksheets.Add(dtModel)
                wb.Worksheets.Add(dtOwner)
                wb.Worksheets.Add(dtManufacturer)

                vehicle.Range("A1:AG1").InsertRowsAbove(1)
                vehicle.Row(1).Height = 70
                vehicle.Column(1).Width = 14
                vehicle.Column(2).Width = 13
                vehicle.Column(3).Width = 10
                vehicle.Column(4).Width = 14
                vehicle.Column(13).Width = 15
                vehicle.Column(14).Width = 14
                vehicle.Column(17).Width = 22
                vehicle.Column(21).Width = 24
                vehicle.Column(22).Width = 50
                vehicle.Column(24).Width = 11
                vehicle.Column(25).Width = 11
                vehicle.Column(26).Width = 12
                vehicle.Column(36).Width = 20
                vehicle.Column(38).Width = 145
                vehicle.Range("A1:AM1").Style.Fill.BackgroundColor = XLColor.Ivory
                vehicle.Range("A2:AM2").Style.Fill.BackgroundColor = XLColor.Turquoise
                vehicle.Range("A1:AM1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                vehicle.Range("A1:AM1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                vehicle.Range("A1:AM1").Style.Alignment.WrapText = True
                vehicle.Row(3).Delete()
                vehicle.Cell(1, 1).Value = "Plat Sementara (Temporary Plate No.)"
                vehicle.Cell(1, 2).Value = "No. Polisi Asli (Original Plate No.)"
                vehicle.Cell(1, 3).Value = "Asset ID (from BS)"
                vehicle.Cell(1, 4).Value = "Ownership (Kepemilikan)"
                vehicle.Cell(1, 5).Value = "Merk (Brand)"
                vehicle.Cell(1, 6).Value = "Jenis (Car Model)"
                vehicle.Cell(1, 7).Value = "Tipe (Car Type)"
                vehicle.Cell(1, 8).Value = "Tahun (Year)"
                vehicle.Cell(1, 9).Value = "Warna (Color)"
                vehicle.Cell(1, 10).Value = "Serial No."
                vehicle.Cell(1, 11).Value = "No. STNK"
                vehicle.Cell(1, 12).Value = "STNK Samsat Terbit"
                vehicle.Cell(1, 13).Value = "Perpanjangan STNK tiap tahun"
                vehicle.Cell(1, 14).Value = "Perpanjangan STNK 5 tahunan"
                vehicle.Cell(1, 15).Value = "Bulan STNK"
                vehicle.Cell(1, 16).Value = "No. BPKB"
                vehicle.Cell(1, 17).Value = "No. Chasis"
                vehicle.Cell(1, 18).Value = "No. Mesin"
                vehicle.Cell(1, 19).Value = "Cylinder (cc)"
                vehicle.Cell(1, 20).Value = "Bahan Bakar"
                vehicle.Cell(1, 21).Value = "Nama STNK (STNK Name)"
                vehicle.Cell(1, 22).Value = "Alamat STNK"
                vehicle.Cell(1, 23).Value = "Keterangan"
                vehicle.Cell(1, 24).Value = "Tgl Terima DO dr pool"
                vehicle.Cell(1, 25).Value = "Tgl Kendaraan Dtg"
                vehicle.Cell(1, 26).Value = "Terima STNK dr dealer"
                vehicle.Cell(1, 27).Value = "No. PO/Thn"
                vehicle.Cell(1, 28).Value = "Harga OTR "
                vehicle.Cell(1, 29).Value = "Discount"
                vehicle.Cell(1, 30).Value = "Harga Beli"
                vehicle.Cell(1, 31).Value = "Plafon COP"
                vehicle.Cell(1, 32).Value = "Advance Receipt"
                vehicle.Cell(1, 33).Value = "Tgl Kwitansi"
                vehicle.Cell(1, 34).Value = "Nomor Kwitansi"
                vehicle.Cell(1, 35).Value = "Tgl Faktur Pajak (Faktur Pajak Date)"
                vehicle.Cell(1, 36).Value = "No. Faktur Pajak"
                vehicle.Cell(1, 37).Value = "(VAT)"
                vehicle.Cell(1, 38).Value = "(Dealer)"
                vehicle.Cell(1, 39).Value = "Nama Dealer (Sesuai Master Vendor)"


                vehicle.Cell(2, 1).Value = "Tmp_Plat"
                vehicle.Cell(2, 2).Value = "license_no"
                vehicle.Cell(2, 3).Value = "x"
                vehicle.Cell(2, 4).Value = "owner_id"
                vehicle.Cell(2, 5).Value = "manufacturer_id"
                vehicle.Cell(2, 6).Value = "Model_ID"
                vehicle.Cell(2, 7).Value = "CarType"
                vehicle.Cell(2, 8).Value = "year"
                vehicle.Cell(2, 9).Value = "color"
                vehicle.Cell(2, 10).Value = "serial_no"
                vehicle.Cell(2, 11).Value = "registration_no"
                vehicle.Cell(2, 12).Value = "xx"
                vehicle.Cell(2, 13).Value = "registration_expdate"
                vehicle.Cell(2, 14).Value = "xxxx"
                vehicle.Cell(2, 15).Value = "xxxxx"
                vehicle.Cell(2, 16).Value = "title_no"
                vehicle.Cell(2, 17).Value = "chassis_no"
                vehicle.Cell(2, 18).Value = "machine_no"
                vehicle.Cell(2, 19).Value = "CC"
                vehicle.Cell(2, 20).Value = "xxxxxx"
                vehicle.Cell(2, 21).Value = "STNK_Name"
                vehicle.Cell(2, 22).Value = "STNK_Address"
                vehicle.Cell(2, 23).Value = "xxxxxxx"
                vehicle.Cell(2, 24).Value = "xxxxxxxx"
                vehicle.Cell(2, 25).Value = "xxxxxxxxx"
                vehicle.Cell(2, 26).Value = "xxxxxxxxxx"
                vehicle.Cell(2, 27).Value = "PO_No"
                vehicle.Cell(2, 28).Value = "price"
                vehicle.Cell(2, 29).Value = "discount"
                vehicle.Cell(2, 30).Value = "Harga_Beli"
                vehicle.Cell(2, 31).Value = "xxxxxxxxxxx"
                vehicle.Cell(2, 32).Value = "xxxxxxxxxxxx"
                vehicle.Cell(2, 33).Value = "Kwitansi_Date"
                vehicle.Cell(2, 34).Value = "Kwitansi_No"
                vehicle.Cell(2, 35).Value = "FakturPajak_Date"
                vehicle.Cell(2, 36).Value = "FakturPajak_No"
                vehicle.Cell(2, 37).Value = "VAT"
                vehicle.Cell(2, 38).Value = "Dealer"
                vehicle.Cell(2, 39).Value = "xxxxxxxxxxxxx"
                vehicle.Cell(2, 40).Value = "date_book"
                vehicle.Cell(2, 41).Value = "comment"

                Using stream As New MemoryStream()
                    wb.SaveAs(stream)
                    Return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx")
                End Using
            End Using

        End Function

        Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.CurrentSort = sortOrder
            If Not searchString Is Nothing Then
                page = 1
            Else
                searchString = currentFilter
            End If
            ViewBag.CurrentFilter = searchString
            ViewBag.pageSize = pageSize
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If
            Dim query = (From A In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).Include(Function(m) m.Ms_Vehicle_Models)
                         Select A.Vehicle_id, A.license_no, A.Tmp_Plat, A.Model_ID, A.type, A.color, A.year, A.chassis_no, A.machine_no, A.title_no, A.serial_no, A.registration_no, A.registration_expdate, A.insurance_no,
                        A.discount, A.price, A.acquisition, A.coverage, A.comment, A.status, A.date_insurance_start, A.date_insurance_end, A.date_insurance_mod, A.date_book, A.STNK_No,
                            A.STNK_Publish, A.STNK_Yearly_Renewal, A.STNK_5Year_Renewal, A.STNK_Month, A.STNK_Name, A.STNK_Address, A.CC, A.Fuel, A.NoUrutBuku, A.DO_date, A.Vehicle_Come,
                            A.STNK_Receipt, A.PO_No, A.Harga_Beli, A.Kwitansi_Date, A.Kwitansi_No, A.FakturPajak_Date, A.FakturPajak_No, A.VAT, A.Dealer, A.CreatedDate, A.ModifiedDate,
                            A.IsDeleted, Model = A.Ms_Vehicle_Models.Type, CreatedBy = A.Cn_Users.User_Name, ModifiedBy = A.Cn_Users1.User_Name).
                            Select(Function(x) New Ms_Vehicle With {.Vehicle_id = x.Vehicle_id, .license_no = x.license_no, .Tmp_Plat = x.Tmp_Plat, .Model_ID = x.Model_ID, .Model = x.Model, .type = x.type, .color = x.color, .year = x.year,
                        .chassis_no = x.chassis_no, .machine_no = x.machine_no, .title_no = x.title_no, .serial_no = x.serial_no, .registration_no = x.registration_no, .registration_expdate = x.registration_expdate,
                        .insurance_no = x.insurance_no, .discount = x.discount, .price = x.price, .acquisition = x.acquisition, .coverage = x.coverage, .comment = x.comment,
                        .date_insurance_start = x.date_insurance_start, .date_insurance_end = x.date_insurance_end, .date_insurance_mod = x.date_insurance_mod, .date_book = x.date_book, .STNK_No = x.STNK_No, .STNK_Publish = x.STNK_Publish,
                        .STNK_Yearly_Renewal = x.STNK_Yearly_Renewal, .STNK_5Year_Renewal = x.STNK_5Year_Renewal, .STNK_Month = x.STNK_Month, .STNK_Name = x.STNK_Name, .STNK_Address = x.STNK_Address, .CC = x.CC, .Fuel = x.Fuel,
                        .NoUrutBuku = x.NoUrutBuku, .DO_date = x.DO_date, .Vehicle_Come = x.Vehicle_Come, .STNK_Receipt = x.STNK_Receipt, .PO_No = x.PO_No, .Harga_Beli = x.Harga_Beli, .Kwitansi_Date = x.Kwitansi_Date,
                        .Kwitansi_No = x.Kwitansi_No, .FakturPajak = x.FakturPajak_Date, .FakturPajak_No = x.FakturPajak_No, .VAT = x.VAT, .Dealer = x.Dealer, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate,
                        .ModifiedBy = x.ModifiedBy, .IsDeleted = x.IsDeleted})

            If Not String.IsNullOrEmpty(searchString) Then
                query = query.Where(Function(s) s.license_no.Contains(searchString) OrElse s.Model.Contains(searchString) OrElse s.color.Contains(searchString))
            End If
            Select Case sortOrder
                Case "license_no"
                    query = query.OrderBy(Function(s) s.license_no)
                Case "Model"
                    query = query.OrderBy(Function(s) s.Model)
                Case "color"
                    query = query.OrderBy(Function(s) s.color)
                Case Else
                    query = query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(query.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Vehicle/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False And x.Vehicle_id = id).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).Include(Function(m) m.Ms_Vehicle_Models)
                         Group Join B In db.Ms_Vehicle_Models On A.Model_ID Equals B.Model_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Vehicle_Brands On B.Brand_ID Equals C.Brand_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Select A.Vehicle_id, A.license_no, A.Tmp_Plat, C.Brand_ID, C.Brand_Name, A.Model_ID, A.type, A.color, A.year, A.chassis_no, A.machine_no, A.title_no, A.serial_no, A.registration_no, A.registration_expdate, A.insurance_no,
                         A.discount, A.price, A.acquisition, A.coverage, A.comment, A.status, A.date_insurance_start, A.date_insurance_end, A.date_insurance_mod, A.date_book, A.STNK_No,
                            A.STNK_Publish, A.STNK_Yearly_Renewal, A.STNK_5Year_Renewal, A.STNK_Month, A.STNK_Name, A.STNK_Address, A.CC, A.Fuel, A.NoUrutBuku, A.DO_date, A.Vehicle_Come,
                            A.STNK_Receipt, A.PO_No, A.Harga_Beli, A.Kwitansi_Date, A.Kwitansi_No, A.FakturPajak_Date, A.FakturPajak_No, A.VAT, A.Dealer, A.CreatedDate, A.ModifiedDate,
                            A.IsDeleted, Model = A.Ms_Vehicle_Models.Type, CreatedBy = A.Cn_Users.User_Name, ModifiedBy = A.Cn_Users1.User_Name).
                            Select(Function(x) New Ms_Vehicle With {.Vehicle_id = x.Vehicle_id, .license_no = x.license_no, .Tmp_Plat = x.Tmp_Plat, .Brand_ID = x.Brand_ID, .Brand_Name = x.Brand_Name, .Model_ID = x.Model_ID, .Model = x.Model, .type = x.type, .color = x.color, .year = x.year,
                        .chassis_no = x.chassis_no, .machine_no = x.machine_no, .title_no = x.title_no, .serial_no = x.serial_no, .registration_no = x.registration_no, .registration_expdate = x.registration_expdate,
                        .insurance_no = x.insurance_no, .discount = x.discount, .price = x.price, .acquisition = x.acquisition, .coverage = x.coverage, .comment = x.comment,
                        .date_insurance_start = x.date_insurance_start, .date_insurance_end = x.date_insurance_end, .date_insurance_mod = x.date_insurance_mod, .date_book = x.date_book, .STNK_No = x.STNK_No, .STNK_Publish = x.STNK_Publish,
                        .STNK_Yearly_Renewal = x.STNK_Yearly_Renewal, .STNK_5Year_Renewal = x.STNK_5Year_Renewal, .STNK_Month = x.STNK_Month, .STNK_Name = x.STNK_Name, .STNK_Address = x.STNK_Address, .CC = x.CC, .Fuel = x.Fuel,
                        .NoUrutBuku = x.NoUrutBuku, .DO_date = x.DO_date, .Vehicle_Come = x.Vehicle_Come, .STNK_Receipt = x.STNK_Receipt, .PO_No = x.PO_No, .Harga_Beli = x.Harga_Beli, .Kwitansi_Date = x.Kwitansi_Date,
                        .Kwitansi_No = x.Kwitansi_No, .FakturPajak = x.FakturPajak_Date, .FakturPajak_No = x.FakturPajak_No, .VAT = x.VAT, .Dealer = x.Dealer, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate,
                        .ModifiedBy = x.ModifiedBy, .IsDeleted = x.IsDeleted}).FirstOrDefault
            If IsNothing(query) Then
                Return HttpNotFound()
            End If
            Return View(query)
        End Function
        Function IndexInputAsset(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
                        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.CurrentSort = sortOrder
            If Not searchString Is Nothing Then
                page = 1
            Else
                searchString = currentFilter
            End If
            ViewBag.CurrentFilter = searchString
            ViewBag.pageSize = pageSize
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If

            Dim Query = (From A In db.Tr_ApplicationPOs
                         Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
                         Join C In db.Tr_ApplicationPODetails On A.ApplicationPO_ID Equals C.ApplicationPO_ID
                         Group Join D In (db.Tr_ContractDetails.Where(Function(t) t.IsDeleted = False And t.ApplicationPO_ID IsNot Nothing).GroupBy(Function(w) w.ApplicationPO_ID)) On A.ApplicationPO_ID Equals D.Key Into AD = Group
                         From D In AD.DefaultIfEmpty()
                         Where C.IsChecked = True And B.Contract_ID IsNot Nothing And A.Qty <> D.Count
                         Order By A.CreatedDate Descending
                         Select D.Count, A.ApplicationPO_ID, B.CompanyGroup_Name, B.Company_Name, B.Brand_Name, B.Vehicle, A.CreatedDate, A.Qty, C.Dealer_ID).
                Select(Function(x) New Tr_ApplicationPO_InputAsset With {.ApplicationPO_ID = x.ApplicationPO_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Qty = x.Qty, .Dealer = db.Ms_Dealers.Where(Function(w) w.Dealer_ID = x.Dealer_ID).Select(Function(t) t.Dealer_Name).FirstOrDefault(), .CreatedDate = x.CreatedDate, .QtyInput = x.Count})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Brand_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString) OrElse s.Dealer.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Brand_Name"
                    Query = Query.OrderBy(Function(s) s.Brand_Name)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Vehicle)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Dealer)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            Return View(Query)
        End Function
        ' GET: Vehicle/Edit/5
        Function VehicleFromContract(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Query = (From A In db.Tr_ApplicationPOs
                         Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
                         Join C In db.Tr_ApplicationPODetails On A.ApplicationPO_ID Equals C.ApplicationPO_ID
                         Order By A.CreatedDate Descending
                         Select B.CompanyGroup_Name, B.Company_Name, B.ApplicationPO_No, B.Brand_Name, B.Vehicle, A.CreatedDate, B.Model_ID, B.Brand_ID, A.Color, C.Dealer_ID).
                         Select(Function(x) New Ms_Vehicle With {.CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .PO_No = x.ApplicationPO_No,
                         .Brand_Name = x.Brand_Name, .Model = x.Vehicle, .Model_ID = x.Model_ID, .Brand_ID = x.Brand_ID, .color = x.Color, .Dealer = db.Ms_Dealers.Where(Function(w) w.Dealer_ID = x.Dealer_ID).Select(Function(t) t.Dealer_Name).FirstOrDefault()}).FirstOrDefault
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Return View(Query)
        End Function

        ' POST: Vehicle/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function VehicleFromContract(<Bind(Include:="CompanyGroup_Name,Company_Name,Vehicle_id,ContractDetail_ID,license_no,Tmp_Plat,Brand_ID,Brand_Name,Model_ID,Model,type,color,year,chassis_no,machine_no,title_no,serial_no,registration_no,registration_expdate,insurance_no,discount,discountStr,price,priceStr,acquisition,acquisitionStr,coverage,coverageStr,comment,status,remove,date_insurance_start,date_insurance_end,date_insurance_mod,date_book,STNK_No,STNK_Publish,STNK_Yearly_Renewal,STNK_5Year_Renewal,STNK_Month,STNK_Name,STNK_Address,CC,Fuel,NoUrutBuku,DO_date,Vehicle_Come,STNK_Receipt,PO_No,Harga_Beli,Harga_BeliStr,Kwitansi_Date,Kwitansi_No,FakturPajak,FakturPajak_No,VAT,Dealer,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle As Ms_Vehicle) As ActionResult
            Dim user As Integer
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
#Else
            user = 1
#End If
            If ms_Vehicle.license_no = Nothing And ms_Vehicle.Tmp_Plat = Nothing Then
                ModelState.AddModelError("Tmp_Plat", "Must Input Tmp Plat")
            End If
            If ModelState.IsValid Then
                Using d = db.Database.BeginTransaction
                    Try
                        Dim vehicle As New Ms_Vehicles
                        vehicle.license_no = ms_Vehicle.license_no
                        vehicle.Tmp_Plat = ms_Vehicle.Tmp_Plat
                        vehicle.Model_ID = ms_Vehicle.Model_ID
                        vehicle.type = ms_Vehicle.type
                        vehicle.color = ms_Vehicle.color
                        vehicle.year = ms_Vehicle.year
                        vehicle.chassis_no = ms_Vehicle.chassis_no
                        vehicle.machine_no = ms_Vehicle.machine_no
                        vehicle.title_no = ms_Vehicle.title_no
                        vehicle.serial_no = ms_Vehicle.serial_no
                        vehicle.registration_no = ms_Vehicle.registration_no
                        vehicle.registration_expdate = ms_Vehicle.registration_expdate
                        vehicle.insurance_no = ms_Vehicle.insurance_no
                        vehicle.discount = ms_Vehicle.discount
                        vehicle.price = ms_Vehicle.price
                        vehicle.acquisition = ms_Vehicle.acquisition
                        vehicle.coverage = ms_Vehicle.coverage
                        vehicle.comment = ms_Vehicle.comment
                        vehicle.status = True
                        vehicle.date_insurance_start = ms_Vehicle.date_insurance_start
                        vehicle.date_insurance_end = ms_Vehicle.date_insurance_end
                        vehicle.date_insurance_mod = ms_Vehicle.date_insurance_mod
                        vehicle.date_book = ms_Vehicle.date_book
                        vehicle.STNK_No = ms_Vehicle.STNK_No
                        vehicle.STNK_Publish = ms_Vehicle.STNK_Publish
                        vehicle.STNK_Yearly_Renewal = ms_Vehicle.STNK_Yearly_Renewal
                        vehicle.STNK_5Year_Renewal = ms_Vehicle.STNK_5Year_Renewal
                        vehicle.STNK_Month = ms_Vehicle.STNK_Month
                        vehicle.STNK_Name = ms_Vehicle.STNK_Name
                        vehicle.STNK_Address = ms_Vehicle.STNK_Address
                        vehicle.CC = ms_Vehicle.CC
                        vehicle.Fuel = ms_Vehicle.Fuel
                        vehicle.NoUrutBuku = ms_Vehicle.NoUrutBuku
                        vehicle.DO_date = ms_Vehicle.DO_date
                        vehicle.Vehicle_Come = ms_Vehicle.Vehicle_Come
                        vehicle.STNK_Receipt = ms_Vehicle.STNK_Receipt
                        vehicle.PO_No = ms_Vehicle.PO_No
                        vehicle.Harga_Beli = ms_Vehicle.Harga_Beli
                        vehicle.Kwitansi_Date = ms_Vehicle.Kwitansi_Date
                        vehicle.Kwitansi_No = ms_Vehicle.Kwitansi_No
                        vehicle.FakturPajak_Date = ms_Vehicle.FakturPajak
                        vehicle.FakturPajak_No = ms_Vehicle.FakturPajak_No
                        vehicle.VAT = ms_Vehicle.VAT
                        vehicle.Dealer = ms_Vehicle.Dealer
                        vehicle.CreatedBy = user
                        vehicle.CreatedDate = DateTime.Now
                        vehicle.IsDeleted = False
                        'dimasukin biar ada link nya
                        vehicle.ContractDetail_ID = ms_Vehicle.ContractDetail_ID
                        db.Ms_Vehicles.Add(vehicle)
                        db.SaveChanges()

                        'update di Tr_ContractDetails
                        Dim ConDet = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = ms_Vehicle.ContractDetail_ID).FirstOrDefault
                        ConDet.Vehicle_ID = vehicle.Vehicle_id
                        ConDet.ModifiedBy = user
                        ConDet.ModifiedDate = DateTime.Now

                        db.SaveChanges()
                        d.Commit()
                        Return RedirectToAction("IndexInputAsset")
                    Catch ex As Exception
                        d.Rollback()
                    End Try
                End Using
            End If
        End Function


        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name")
            Dim myType As List(Of SelectListItem) = New List(Of SelectListItem)() From {}
            ViewBag.Model_ID = New SelectList(myType, "Value", "Text")
            Return View()
        End Function

        ' POST: Vehicle/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Vehicle_id,license_no,Brand_ID,Model_ID,type,Tmp_Plat,color,year,chassis_no,machine_no,title_no,serial_no,registration_no,registration_expdate,insurance_no,discount,discountStr,price,priceStr,acquisition,acquisitionStr,coverage,coverageStr,comment,remove,date_insurance_start,date_insurance_end,date_insurance_mod,date_book,STNK_No,STNK_Publish,STNK_Yearly_Renewal,STNK_5Year_Renewal,STNK_Month,STNK_Name,STNK_Address,CC,Fuel,NoUrutBuku,DO_date,Vehicle_Come,STNK_Receipt,PO_No,Harga_Beli,Harga_BeliStr,Kwitansi_Date,Kwitansi_No,FakturPajak,FakturPajak_No,VAT,Dealer,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle As Ms_Vehicle) As ActionResult
            Dim user As Integer
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
#Else
            user = 1
#End If
            If ModelState.IsValid Then
                Dim vehicle As New Ms_Vehicles
                vehicle.license_no = ms_Vehicle.license_no
                vehicle.Tmp_Plat = ms_Vehicle.Tmp_Plat
                vehicle.Model_ID = ms_Vehicle.Model_ID
                vehicle.type = ms_Vehicle.type
                vehicle.color = ms_Vehicle.color
                vehicle.year = ms_Vehicle.year
                vehicle.chassis_no = ms_Vehicle.chassis_no
                vehicle.machine_no = ms_Vehicle.machine_no
                vehicle.title_no = ms_Vehicle.title_no
                vehicle.serial_no = ms_Vehicle.serial_no
                vehicle.registration_no = ms_Vehicle.registration_no
                vehicle.registration_expdate = ms_Vehicle.registration_expdate
                vehicle.insurance_no = ms_Vehicle.insurance_no
                vehicle.discount = ms_Vehicle.discount
                vehicle.price = ms_Vehicle.price
                vehicle.acquisition = ms_Vehicle.acquisition
                vehicle.coverage = ms_Vehicle.coverage
                vehicle.comment = ms_Vehicle.comment
                vehicle.status = True
                vehicle.date_insurance_start = ms_Vehicle.date_insurance_start
                vehicle.date_insurance_end = ms_Vehicle.date_insurance_end
                vehicle.date_insurance_mod = ms_Vehicle.date_insurance_mod
                vehicle.date_book = ms_Vehicle.date_book
                vehicle.STNK_No = ms_Vehicle.STNK_No
                vehicle.STNK_Publish = ms_Vehicle.STNK_Publish
                vehicle.STNK_Yearly_Renewal = ms_Vehicle.STNK_Yearly_Renewal
                vehicle.STNK_5Year_Renewal = ms_Vehicle.STNK_5Year_Renewal
                vehicle.STNK_Month = ms_Vehicle.STNK_Month
                vehicle.STNK_Name = ms_Vehicle.STNK_Name
                vehicle.STNK_Address = ms_Vehicle.STNK_Address
                vehicle.CC = ms_Vehicle.CC
                vehicle.Fuel = ms_Vehicle.Fuel
                vehicle.NoUrutBuku = ms_Vehicle.NoUrutBuku
                vehicle.DO_date = ms_Vehicle.DO_date
                vehicle.Vehicle_Come = ms_Vehicle.Vehicle_Come
                vehicle.STNK_Receipt = ms_Vehicle.STNK_Receipt
                vehicle.PO_No = ms_Vehicle.PO_No
                vehicle.Harga_Beli = ms_Vehicle.Harga_Beli
                vehicle.Kwitansi_Date = ms_Vehicle.Kwitansi_Date
                vehicle.Kwitansi_No = ms_Vehicle.Kwitansi_No
                vehicle.FakturPajak_Date = ms_Vehicle.FakturPajak
                vehicle.FakturPajak_No = ms_Vehicle.FakturPajak_No
                vehicle.VAT = ms_Vehicle.VAT
                vehicle.Dealer = ms_Vehicle.Dealer
                vehicle.CreatedBy = user
                vehicle.CreatedDate = DateTime.Now
                vehicle.IsDeleted = False
                db.Ms_Vehicles.Add(vehicle)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name", ms_Vehicle.Brand_ID)
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False), "Model_ID", "Type", ms_Vehicle.Model_ID)
            Return View(ms_Vehicle)
        End Function

        ' GET: Vehicle/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False And x.Vehicle_id = id).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).Include(Function(m) m.Ms_Vehicle_Models)
                         Group Join B In db.Ms_Vehicle_Models On A.Model_ID Equals B.Model_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Vehicle_Brands On B.Brand_ID Equals C.Brand_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Select A.Vehicle_id, A.license_no, A.Tmp_Plat, C.Brand_ID, C.Brand_Name, A.Model_ID, A.type, A.color, A.year, A.chassis_no, A.machine_no, A.title_no, A.serial_no, A.registration_no, A.registration_expdate, A.insurance_no,
                         A.discount, A.price, A.acquisition, A.coverage, A.comment, A.status, A.date_insurance_start, A.date_insurance_end, A.date_insurance_mod, A.date_book, A.STNK_No,
                            A.STNK_Publish, A.STNK_Yearly_Renewal, A.STNK_5Year_Renewal, A.STNK_Month, A.STNK_Name, A.STNK_Address, A.CC, A.Fuel, A.NoUrutBuku, A.DO_date, A.Vehicle_Come,
                            A.STNK_Receipt, A.PO_No, A.Harga_Beli, A.Kwitansi_Date, A.Kwitansi_No, A.FakturPajak_Date, A.FakturPajak_No, A.VAT, A.Dealer, A.CreatedDate, A.ModifiedDate,
                            A.IsDeleted, Model = A.Ms_Vehicle_Models.Type, CreatedBy = A.Cn_Users.User_Name, ModifiedBy = A.Cn_Users1.User_Name).
                            Select(Function(x) New Ms_Vehicle With {.Vehicle_id = x.Vehicle_id, .license_no = x.license_no, .Tmp_Plat = x.Tmp_Plat, .Brand_ID = x.Brand_ID, .Brand_Name = x.Brand_Name, .Model_ID = x.Model_ID, .Model = x.Model, .type = x.type, .color = x.color, .year = x.year,
                        .chassis_no = x.chassis_no, .machine_no = x.machine_no, .title_no = x.title_no, .serial_no = x.serial_no, .registration_no = x.registration_no, .registration_expdate = x.registration_expdate,
                        .insurance_no = x.insurance_no, .discount = x.discount, .price = x.price, .acquisition = x.acquisition, .coverage = x.coverage, .comment = x.comment,
                        .date_insurance_start = x.date_insurance_start, .date_insurance_end = x.date_insurance_end, .date_insurance_mod = x.date_insurance_mod, .date_book = x.date_book, .STNK_No = x.STNK_No, .STNK_Publish = x.STNK_Publish,
                        .STNK_Yearly_Renewal = x.STNK_Yearly_Renewal, .STNK_5Year_Renewal = x.STNK_5Year_Renewal, .STNK_Month = x.STNK_Month, .STNK_Name = x.STNK_Name, .STNK_Address = x.STNK_Address, .CC = x.CC, .Fuel = x.Fuel,
                        .NoUrutBuku = x.NoUrutBuku, .DO_date = x.DO_date, .Vehicle_Come = x.Vehicle_Come, .STNK_Receipt = x.STNK_Receipt, .PO_No = x.PO_No, .Harga_Beli = x.Harga_Beli, .Kwitansi_Date = x.Kwitansi_Date,
                        .Kwitansi_No = x.Kwitansi_No, .FakturPajak = x.FakturPajak_Date, .FakturPajak_No = x.FakturPajak_No, .VAT = x.VAT, .Dealer = x.Dealer, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate,
                        .ModifiedBy = x.ModifiedBy, .IsDeleted = x.IsDeleted}).FirstOrDefault
            If IsNothing(query) Then
                Return HttpNotFound()
            End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name", query.Brand_ID)
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False), "Model_ID", "Type", query.Model_ID)
            Return View(query)
        End Function

        ' POST: Vehicle/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Vehicle_id,license_no,Tmp_Plat,Brand_ID,Model_ID,type,color,year,chassis_no,machine_no,title_no,serial_no,registration_no,registration_expdate,insurance_no,discount,discountStr,price,priceStr,acquisition,acquisitionStr,coverage,coverageStr,comment,remove,date_insurance_start,date_insurance_end,date_insurance_mod,date_book,STNK_No,STNK_Publish,STNK_Yearly_Renewal,STNK_5Year_Renewal,STNK_Month,STNK_Name,STNK_Address,CC,Fuel,NoUrutBuku,DO_date,Vehicle_Come,STNK_Receipt,PO_No,Harga_Beli,Harga_BeliStr,Kwitansi_Date,Kwitansi_No,FakturPajak,FakturPajak_No,VAT,Dealer,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle As Ms_Vehicle) As ActionResult
            Dim user As Integer
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
#Else
            user = 1
#End If
            If ms_Vehicle.license_no = Nothing And ms_Vehicle.Tmp_Plat = Nothing Then
                ModelState.AddModelError("Tmp_Plat", "Must Input Tmp Plat")
            End If
            If ModelState.IsValid Then
                Dim vehicle = db.Ms_Vehicles.Where(Function(x) x.Vehicle_id = ms_Vehicle.Vehicle_id).FirstOrDefault
                vehicle.license_no = ms_Vehicle.license_no
                vehicle.Tmp_Plat = ms_Vehicle.Tmp_Plat
                vehicle.Model_ID = ms_Vehicle.Model_ID
                vehicle.type = ms_Vehicle.type
                vehicle.color = ms_Vehicle.color
                vehicle.year = ms_Vehicle.year
                vehicle.chassis_no = ms_Vehicle.chassis_no
                vehicle.machine_no = ms_Vehicle.machine_no
                vehicle.title_no = ms_Vehicle.title_no
                vehicle.serial_no = ms_Vehicle.serial_no
                vehicle.registration_no = ms_Vehicle.registration_no
                vehicle.registration_expdate = ms_Vehicle.registration_expdate
                vehicle.insurance_no = ms_Vehicle.insurance_no
                vehicle.discount = ms_Vehicle.discount
                vehicle.price = ms_Vehicle.price
                vehicle.acquisition = ms_Vehicle.acquisition
                vehicle.coverage = ms_Vehicle.coverage
                vehicle.comment = ms_Vehicle.comment
                vehicle.date_insurance_start = ms_Vehicle.date_insurance_start
                vehicle.date_insurance_end = ms_Vehicle.date_insurance_end
                vehicle.date_insurance_mod = ms_Vehicle.date_insurance_mod
                vehicle.date_book = ms_Vehicle.date_book
                vehicle.STNK_No = ms_Vehicle.STNK_No
                vehicle.STNK_Publish = ms_Vehicle.STNK_Publish
                vehicle.STNK_Yearly_Renewal = ms_Vehicle.STNK_Yearly_Renewal
                vehicle.STNK_5Year_Renewal = ms_Vehicle.STNK_5Year_Renewal
                vehicle.STNK_Month = ms_Vehicle.STNK_Month
                vehicle.STNK_Name = ms_Vehicle.STNK_Name
                vehicle.STNK_Address = ms_Vehicle.STNK_Address
                vehicle.CC = ms_Vehicle.CC
                vehicle.Fuel = ms_Vehicle.Fuel
                vehicle.NoUrutBuku = ms_Vehicle.NoUrutBuku
                vehicle.DO_date = ms_Vehicle.DO_date
                vehicle.Vehicle_Come = ms_Vehicle.Vehicle_Come
                vehicle.STNK_Receipt = ms_Vehicle.STNK_Receipt
                vehicle.PO_No = ms_Vehicle.PO_No
                vehicle.Harga_Beli = ms_Vehicle.Harga_Beli
                vehicle.Kwitansi_Date = ms_Vehicle.Kwitansi_Date
                vehicle.Kwitansi_No = ms_Vehicle.Kwitansi_No
                vehicle.FakturPajak_Date = ms_Vehicle.FakturPajak
                vehicle.FakturPajak_No = ms_Vehicle.FakturPajak_No
                vehicle.VAT = ms_Vehicle.VAT
                vehicle.Dealer = ms_Vehicle.Dealer
                vehicle.ModifiedDate = DateTime.Now
                vehicle.ModifiedBy = user
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name", ms_Vehicle.Brand_ID)
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False), "Model_ID", "Type", ms_Vehicle.Model_ID)
            Return View(ms_Vehicle)
        End Function

        ' GET: Vehicle/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False And x.Vehicle_id = id).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).Include(Function(m) m.Ms_Vehicle_Models)
                         Group Join B In db.Ms_Vehicle_Models On A.Model_ID Equals B.Model_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Vehicle_Brands On B.Brand_ID Equals C.Brand_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Select A.Vehicle_id, A.license_no, A.Tmp_Plat, C.Brand_ID, C.Brand_Name, A.Model_ID, A.type, A.color, A.year, A.chassis_no, A.machine_no, A.title_no, A.serial_no, A.registration_no, A.registration_expdate, A.insurance_no,
                         A.discount, A.price, A.acquisition, A.coverage, A.comment, A.status, A.date_insurance_start, A.date_insurance_end, A.date_insurance_mod, A.date_book, A.STNK_No,
                            A.STNK_Publish, A.STNK_Yearly_Renewal, A.STNK_5Year_Renewal, A.STNK_Month, A.STNK_Name, A.STNK_Address, A.CC, A.Fuel, A.NoUrutBuku, A.DO_date, A.Vehicle_Come,
                            A.STNK_Receipt, A.PO_No, A.Harga_Beli, A.Kwitansi_Date, A.Kwitansi_No, A.FakturPajak_Date, A.FakturPajak_No, A.VAT, A.Dealer, A.CreatedDate, A.ModifiedDate,
                            A.IsDeleted, Model = A.Ms_Vehicle_Models.Type, CreatedBy = A.Cn_Users.User_Name, ModifiedBy = A.Cn_Users1.User_Name).
                            Select(Function(x) New Ms_Vehicle With {.Vehicle_id = x.Vehicle_id, .license_no = x.license_no, .Tmp_Plat = x.Tmp_Plat, .Brand_ID = x.Brand_ID, .Brand_Name = x.Brand_Name, .Model_ID = x.Model_ID, .Model = x.Model, .type = x.type, .color = x.color, .year = x.year,
                        .chassis_no = x.chassis_no, .machine_no = x.machine_no, .title_no = x.title_no, .serial_no = x.serial_no, .registration_no = x.registration_no, .registration_expdate = x.registration_expdate,
                        .insurance_no = x.insurance_no, .discount = x.discount, .price = x.price, .acquisition = x.acquisition, .coverage = x.coverage, .comment = x.comment,
                        .date_insurance_start = x.date_insurance_start, .date_insurance_end = x.date_insurance_end, .date_insurance_mod = x.date_insurance_mod, .date_book = x.date_book, .STNK_No = x.STNK_No, .STNK_Publish = x.STNK_Publish,
                        .STNK_Yearly_Renewal = x.STNK_Yearly_Renewal, .STNK_5Year_Renewal = x.STNK_5Year_Renewal, .STNK_Month = x.STNK_Month, .STNK_Name = x.STNK_Name, .STNK_Address = x.STNK_Address, .CC = x.CC, .Fuel = x.Fuel,
                        .NoUrutBuku = x.NoUrutBuku, .DO_date = x.DO_date, .Vehicle_Come = x.Vehicle_Come, .STNK_Receipt = x.STNK_Receipt, .PO_No = x.PO_No, .Harga_Beli = x.Harga_Beli, .Kwitansi_Date = x.Kwitansi_Date,
                        .Kwitansi_No = x.Kwitansi_No, .FakturPajak = x.FakturPajak_Date, .FakturPajak_No = x.FakturPajak_No, .VAT = x.VAT, .Dealer = x.Dealer, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate,
                        .ModifiedBy = x.ModifiedBy, .IsDeleted = x.IsDeleted}).FirstOrDefault
            If IsNothing(query) Then
                Return HttpNotFound()
            End If
            Return View(query)
        End Function

        ' POST: Vehicle/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim ms_Vehicles As Ms_Vehicles = db.Ms_Vehicles.Where(Function(x) x.Vehicle_id = id)
            ms_Vehicles.IsDeleted = True
            ms_Vehicles.ModifiedBy = user
            ms_Vehicles.ModifiedDate = DateTime.Now
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
