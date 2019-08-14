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
Imports System.IO
Imports Ionic.Zip
Imports Microsoft.Reporting.WebForms

Namespace Controllers
    Public Class ApplicationPOController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Function Zip(id As String) As ActionResult
            Dim outputStream = New MemoryStream
            Using zip1 As ZipFile = New ZipFile()
                Dim detailCal = db.Tr_ApplicationPODetails.Where(Function(x) x.Tr_ApplicationPOs.ProspectCustomer_ID = id And x.IsChecked And x.IsDeleted = False).
                GroupBy(Function(x) x.Dealer_ID).Select(Function(x) x.Key).ToList
                Dim no = 1
                For Each i In detailCal
                    Report(id, i.Value, no, zip1)
                    'ReportCalCashFlow(i.Calculate_ID, zip1)
                    no = no + 1
                Next
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "ApplicationPO.zip")
        End Function
        Function Zip2(id As String) As ActionResult
            Dim outputStream = New MemoryStream
            Using zip1 As ZipFile = New ZipFile()
                Dim detailCal = db.Tr_ApplicationPODetails.Where(Function(x) x.Tr_ApplicationPOs.ProspectCustomer_ID = id And x.IsChecked And x.IsDeleted = False).
                GroupBy(Function(x) x.Dealer_ID).Select(Function(x) x.Key).ToList
                Dim no = 1
                For Each i In detailCal
                    ReportDealer(id, i.Value, no, zip1)
                    'ReportCalCashFlow(i.Calculate_ID, zip1)
                    no = no + 1
                Next
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "ApplicationPOForDealer.zip")
        End Function
        Sub Report(id As Integer, dealer_ID As Integer, no As Integer, zip As ZipFile)
            Dim List = db.sp_PrintApplicationPO(id, dealer_ID).ToList
            Dim lr = New LocalReport()
            Dim path As String
            path = Server.MapPath("~/Report/ApplicationPO.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim rd = New ReportDataSource("DS", List)
            lr.DataSources.Add(rd)

            Dim header = List.FirstOrDefault
            Dim param1 = New ReportParameter("AppPONo", header.ApplicationPO_No, False)
            Dim param2 = New ReportParameter("CreatedDate", header.CreatedDate, False)
            Dim param3 = New ReportParameter("CreatedBy", header.CreatedBy, False)
            Dim param4 = New ReportParameter("DealerChecked", header.Dealer_NameChecked, False)
            lr.SetParameters(New ReportParameter() {param1, param2, param3, param4})
            lr.Refresh()
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"
            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>20cm</PageWidth>" +
            " <PageHeight>28.7cm</PageHeight>" +
            " <MarginTop>0.5cm</MarginTop>" +
            " <MarginLeft>0.5cm</MarginLeft>" +
            " <MarginRight>0.5cm</MarginRight>" +
            " <MarginBottom>0.5cm</MarginBottom>" +
            "</DeviceInfo>"
            Dim warnings() As Warning
            Dim streams() As String
            Dim renderedBytes() As Byte
            renderedBytes = lr.Render(
            reportType,
            deviceInfo,
            MimeType,
            endcoding,
            fileNameExtension,
            streams,
            warnings
            )
            zip.AddEntry("Application PO Vehicle" + no.ToString + ".pdf", renderedBytes)

        End Sub
        Sub ReportDealer(id As Integer, dealer_ID As Integer, no As Integer, zip As ZipFile)
            Dim List = db.sp_PrintApplicationPODealer(id, dealer_ID).ToList
            Dim lr = New LocalReport()
            Dim path As String
            path = Server.MapPath("~/Report/ApplicationPODealer.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim rd = New ReportDataSource("DS", List)
            lr.DataSources.Add(rd)

            Dim header = List.FirstOrDefault
            'Dim param1 = New ReportParameter("AppPONo", header.ApplicationPO_No, False)
            'Dim param2 = New ReportParameter("CreatedDate", header.CreatedDate, False)
            'Dim param3 = New ReportParameter("CreatedBy", header.CreatedBy, False)
            'Dim param4 = New ReportParameter("DealerChecked", header.Dealer_NameChecked, False)
            'lr.SetParameters(New ReportParameter() {param1, param2, param3, param4})
            lr.Refresh()
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"
            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>21cm</PageWidth>" +
            " <PageHeight>29.7cm</PageHeight>" +
            " <MarginTop>0cm</MarginTop>" +
            " <MarginLeft>0cm</MarginLeft>" +
            " <MarginRight>0cm</MarginRight>" +
            " <MarginBottom>0cm</MarginBottom>" +
            "</DeviceInfo>"
            Dim warnings() As Warning
            Dim streams() As String
            Dim renderedBytes() As Byte
            renderedBytes = lr.Render(
            reportType,
            deviceInfo,
            MimeType,
            endcoding,
            fileNameExtension,
            streams,
            warnings
            )
            zip.AddEntry("Application PO For Dealer" + no.ToString + ".pdf", renderedBytes)

        End Sub

        ' GET: ApplicationPO
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
            Dim appPO = From x In db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False)
                        Join b In db.V_ProspectCustDetails On x.ProspectCustomerDetail_ID Equals b.ProspectCustomerDetail_ID
                        Join h In db.Tr_ProspectCusts On x.ProspectCustomer_ID Equals h.ProspectCustomer_ID
                        Select New Tr_ApplicationPO With {.ApplicationPO_ID = x.ApplicationPO_ID, .ApplicationPO_No = x.ApplicationPO_No, .CompanyName = b.Company_Name,
                            .Color = x.Color, .Delivery_Date = x.Delivery_Date, .Usage = x.Usage, .Qty = x.Qty, .Refund = x.Refund, .PaymentByUser = x.PaymentByUser, .Vehicle = b.Vehicle, .IsApplicationPO = h.IsApplicationPO, .IsApplication = h.IsApplication,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate, .IsNotApproved = If(x.IsNotApproved, False), .ProspectCustomer_ID = h.ProspectCustomer_ID}
            If Not String.IsNullOrEmpty(searchString) Then
                appPO = appPO.Where(Function(s) s.ApplicationPO_No.Contains(searchString) OrElse s.CompanyName.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "ApplicationPO_No"
                    appPO = appPO.OrderBy(Function(s) s.ApplicationPO_No)
                Case "CompanyName"
                    appPO = appPO.OrderBy(Function(s) s.CompanyName)
                Case "Vehicle"
                    appPO = appPO.OrderBy(Function(s) s.Vehicle)
                Case Else
                    appPO = appPO.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(appPO.ToPagedList(pageNumber, pageSize))

        End Function
        Function IndexProcess(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            'Cache untuk di group, BitArray bisa di bandingin
            Dim appPO = From A In db.V_ProspectCusts
                        Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                        Group Join C In db.V_ApplicationPO On B.ProspectCustomerDetail_ID Equals C.ProspectCustomerDetail_ID Into BC = Group
                        From C In BC.DefaultIfEmpty
                        Where A.IsPO And B.IsFillOTR = False And B.Qty <> If(C.Qty, 0)
                        Select New Tr_ApplicationPO With {.CompanyName = B.Company_Name, .Vehicle = B.Vehicle, .Qty = B.Qty, .QtyAppPO = B.QtyAppPO, .No_Ref = A.No_Ref, .ProspectCustomerDetail_ID = B.ProspectCustomerDetail_ID, .CreatedDate = A.CreatedDate, .Quotation_ID = A.Quotation_ID}
            If Not String.IsNullOrEmpty(searchString) Then
                appPO = appPO.Where(Function(s) s.No_Ref.Contains(searchString) OrElse s.CompanyName.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "No_Ref"
                    appPO = appPO.OrderBy(Function(s) s.No_Ref)
                Case "CompanyName"
                    appPO = appPO.OrderBy(Function(s) s.CompanyName)
                Case "Vehicle"
                    appPO = appPO.OrderBy(Function(s) s.Vehicle)
                Case Else
                    appPO = appPO.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(appPO.ToPagedList(pageNumber, pageSize))
        End Function
        ' GET: ApplicationPO/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApplicationPOs = (From x In db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False)
                                     Join b In db.V_ProspectCustDetails On x.ProspectCustomerDetail_ID Equals b.ProspectCustomerDetail_ID
                                     Join h In db.V_ProspectCusts On x.ProspectCustomer_ID Equals h.ProspectCustomer_ID
                                     Where x.ApplicationPO_ID = id
                                     Select New Tr_ApplicationPO With {.ApplicationPO_ID = x.ApplicationPO_ID, .ProspectCustomerDetail_ID = x.ProspectCustomerDetail_ID, .No_Ref = h.No_Ref, .CompanyName = b.Company_Name,
                            .Color = x.Color, .Delivery_Date = x.Delivery_Date, .Usage = x.Usage, .Qty = x.Qty, .Refund = x.Refund, .PaymentByUser = x.PaymentByUser, .Vehicle = b.Vehicle,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate, .RemarkNotApproved = x.RemarkNotApproved}).FirstOrDefault

            tr_ApplicationPOs.Detail = (From d In db.Tr_ApplicationPODetails.Where(Function(x) x.IsDeleted = False)
                                        Where d.ApplicationPO_ID = tr_ApplicationPOs.ApplicationPO_ID
                                        Select New Tr_ApplicationPODetail With {.Dealer = d.Ms_Dealers.Dealer_Name, .OTR_Price = d.OTR_Price, .Discount = d.Discount,
                                           .Status = d.Status, .IsChecked = d.IsChecked}).ToList

            If IsNothing(tr_ApplicationPOs) Then
                Return HttpNotFound()
            End If
            Return View(tr_ApplicationPOs)
        End Function
        Dim myPlatStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Normal",
                    .Value = "Normal"
                },
                New SelectListItem With {
                    .Text = "Ganjil",
                    .Value = "Ganjil"
                },
                New SelectListItem With {
                    .Text = "Genap",
                    .Value = "Genap"
                }
            }

        ' GET: ApplicationPO/Create
        Function Create(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApplicationPOs = (From A In db.V_ProspectCusts
                                     Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                                     Join C In db.Tr_Calculates On B.Calculate_ID Equals C.Calculate_ID
                                     Where A.IsPO And B.IsFillOTR = False And B.Qty <> B.QtyAppPO And B.ProspectCustomerDetail_ID = id
                                     Select New Tr_ApplicationPO With {.CompanyName = B.Company_Name, .Vehicle = B.Vehicle, .Qty = B.Qty - If(B.QtyAppPO, 0), .No_Ref = A.No_Ref,
                                        .ProspectCustomerDetail_ID = B.ProspectCustomerDetail_ID, .Status = "Verbal",
                                         .OTR_Price_Cal = If(If(C.Update_OTR, 0) = 0, B.Lease_price, C.Update_OTR),
                                         .Discount_Cal = C.Update_Diskon}).FirstOrDefault
            If IsNothing(tr_ApplicationPOs) Then
                Return HttpNotFound()
            End If
            ViewBag.Plat_Location_ID = New SelectList(db.Ms_Citys.OrderBy(Function(a) a.City).Where(Function(x) x.isDeleted = False), "City_ID", "City")
            ViewBag.Plat_Status = New SelectList(myPlatStatus, "Value", "Text")
            ViewBag.Dealer_ID = New SelectList(db.Ms_Dealers.Where(Function(x) x.IsDeleted = False), "Dealer_ID", "Dealer_Name")
            Return View(tr_ApplicationPOs)
        End Function

        Function Validate(Header As Tr_ApplicationPO, ByRef Message As String) As Boolean
            Dim valid = True
            Dim prodetail = db.V_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = Header.ProspectCustomerDetail_ID).FirstOrDefault
            If Header.ProspectCustomerDetail_ID = 0 Then
                Message = "Please choose Vehicle"
                valid = False
            ElseIf (prodetail.Qty - If(prodetail.QtyAppPO, 0)) < Header.QtyAppPO Then
                Message = "Input Qty more then should be. " + (prodetail.Qty - If(prodetail.QtyAppPO, 0)).ToString
                valid = False
            ElseIf If(Header.QtyAppPO, 0) = 0 Then
                Message = "Must fill Qty PO!"
                valid = False
            ElseIf Header.Color = "" Then
                Message = "Must fill Color"
                valid = False
            ElseIf Header.Delivery_Date Is Nothing Then
                Message = "Must fill Delivery Date"
                valid = False
            ElseIf Header.Detail Is Nothing Then
                Message = "Must fill Dealer"
                valid = False
            ElseIf Not Header.Detail.Where(Function(X) X.IsChecked).Any Then
                Message = "Choose the list Dealer"
                valid = False
            End If
            Return valid
        End Function
        Function AppPONO(db As TrustEntities, user As Integer, ByRef ProspectCustomer_ID As Integer?, ProspectCustomerDetail_ID As Integer) As String
            Dim proCustID = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = ProspectCustomerDetail_ID).Select(Function(x) x.ProspectCustomer_ID).FirstOrDefault
            ProspectCustomer_ID = proCustID
            Dim appPO = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = proCustID).FirstOrDefault
            If appPO Is Nothing Then
                Dim transRcp As String = "APPPO"
                'No Otomatis
                Dim noRcp = db.Cn_NoSerieSetup.Where(Function(x) x.Transaction = transRcp And x.YearNo = DateTime.Now.Year And x.MonthNo = DateTime.Now.Month).FirstOrDefault()
                Dim numberRcp As Integer
                If noRcp Is Nothing Then
                    Dim NoSeries As New Cn_NoSerieSetup
                    NoSeries.Transaction = transRcp
                    NoSeries.YearNo = DateTime.Now.Year
                    NoSeries.MonthNo = DateTime.Now.Month
                    NoSeries.NextNo = 1
                    NoSeries.CreatedDate = DateTime.Now
                    NoSeries.CreatedBy = user
                    NoSeries.IsDeleted = False
                    db.Cn_NoSerieSetup.Add(NoSeries)
                    numberRcp = 1
                Else
                    noRcp.NextNo = noRcp.NextNo + 1
                    noRcp.ModifiedBy = user
                    noRcp.ModifiedDate = DateTime.Now
                    numberRcp = noRcp.NextNo
                End If
                db.SaveChanges()
                Return "AP" + numberRcp.ToString + "/" + Right(Now.Month.ToString(), 2) + "/TKS/" + Now.Year.ToString
            Else
                Return appPO.ApplicationPO_No
            End If

            'No Receipt
        End Function

        <HttpPost()>
        Function Create(orderHD() As Tr_ApplicationPO) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim Header = orderHD.FirstOrDefault
            Dim Message = ""
            Dim result = False
            If Validate(Header, Message) Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim NHeader As New Tr_ApplicationPOs
                        NHeader.ApplicationPO_No = AppPONO(db, user, NHeader.ProspectCustomer_ID, Header.ProspectCustomerDetail_ID)
                        NHeader.ProspectCustomerDetail_ID = Header.ProspectCustomerDetail_ID
                        NHeader.Color = Header.Color
                        NHeader.Delivery_Date = Header.Delivery_Date
                        NHeader.Usage = Header.Usage
                        NHeader.Qty = Header.QtyAppPO
                        NHeader.Refund = Header.Refund
                        NHeader.PaymentByUser = Header.PaymentByUser
                        NHeader.Plat_Status = Header.Plat_Status
                        NHeader.Plat_Location_ID = Header.Plat_Location_ID
                        NHeader.Note1 = Header.Note1
                        NHeader.Note2 = Header.Note2
                        NHeader.Aksesoris = Header.Aksesoris
                        NHeader.Comment = Header.Comment
                        NHeader.CreatedDate = DateTime.Now
                        NHeader.CreatedBy = user
                        NHeader.IsDeleted = False
                        NHeader.IsNotApproved = False
                        db.Tr_ApplicationPOs.Add(NHeader)
                        db.SaveChanges()
                        For Each i In Header.Detail
                            Dim detailNew As New Tr_ApplicationPODetails With {
                                .ApplicationPO_ID = NHeader.ApplicationPO_ID,
                                .Dealer_ID = i.Dealer_ID,
                                .OTR_Price = i.OTR_Price,
                                .Discount = i.Discount,
                                .Status = i.Status,
                                .IsChecked = i.IsChecked,
                                .CreatedDate = DateTime.Now,
                                .CreatedBy = user,
                                .IsDeleted = False
                            }
                            db.Tr_ApplicationPODetails.Add(detailNew)
                            db.SaveChanges()
                        Next

                        'jika 0 maka di update detailnya
                        Dim zeroQty = (From B In db.V_ProspectCustDetails
                                       Where B.IsFillOTR = False And B.Qty = B.QtyAppPO And B.ProspectCustomerDetail_ID = NHeader.ProspectCustomerDetail_ID).Any
                        If zeroQty Then
                            Dim application_ID = db.V_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = NHeader.ProspectCustomerDetail_ID).Select(Function(x) x.Application_ID).FirstOrDefault
                            Dim application = db.Tr_Applications.Where(Function(x) x.Application_ID = application_ID).FirstOrDefault
                            application.IsFillOTR = True
                            application.FillOTRBy = user
                            db.SaveChanges()
                        End If

                        'jika abis maka di insert Approvalnya
                        Dim zeroAll = Not (From B In db.V_ProspectCustDetails
                                           Where B.IsFillOTR = False And B.ProspectCustomer_ID = NHeader.ProspectCustomer_ID).Any
                        If zeroAll Then
                            Dim A As New Tr_ApprovalPOs With {
                                    .ProspectCustomer_ID = NHeader.ProspectCustomer_ID,
                                    .StatusRecord = 1, 'karna dia longkap maker, maka jadi 1, kalo makernya ada jadi 0
                                    .Status = "Open",
                                    .CreatedBy = user,
                                    .CreatedDate = DateTime.Now,
                                    .IsDeleted = False
                                }
                            db.Tr_ApprovalPOs.Add(A)
                            db.SaveChanges()
                        End If
                        dbs.Commit()
                        result = True
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using
            End If
            Return Json(New With {Key .result = result, Key .messages = Message}, JsonRequestBehavior.AllowGet)
        End Function

        '' GET: ApplicationPO/Edit/5
        'Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim tr_ApplicationPOs = Await (From A In db.V_ProspectCusts
        '                                   Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
        '                                   Where A.IsPO And B.IsFillOTR = False And B.Qty <> B.QtyAppPO And B.ProspectCustomerDetail_ID = id
        '                                   Select New Tr_ApplicationPO With {.CompanyName = B.Company_Name, .Vehicle = B.Vehicle, .Qty = B.Qty - B.QtyAppPO, .No_Ref = A.No_Ref,
        '                                .ProspectCustomerDetail_ID = B.ProspectCustomerDetail_ID}).FirstOrDefaultAsync
        '    If IsNothing(tr_ApplicationPOs) Then
        '        Return HttpNotFound()
        '    End If
        '    ViewBag.Dealer_ID = New SelectList(db.Ms_Dealers.Where(Function(x) x.IsDeleted = False), "Dealer_ID", "Dealer_Name")
        '    Return View(tr_ApplicationPOs)
        'End Function

        '' POST: ApplicationPO/Edit/5
        ''To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ''more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Async Function Edit(<Bind(Include:="ApplicationPO_ID,ApplicationPO_No,ProspectCustomerDetail_ID,Color,Delivery_Date,Usage,Qty,Refund,PaymentByUser,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_ApplicationPOs As Tr_ApplicationPOs) As Task(Of ActionResult)
        '    If ModelState.IsValid Then
        '        db.Entry(tr_ApplicationPOs).State = EntityState.Modified
        '        Await db.SaveChangesAsync()
        '        Return RedirectToAction("Index")
        '    End If
        '    ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApplicationPOs.CreatedBy)
        '    ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApplicationPOs.ModifiedBy)
        '    ViewBag.ProspectCustomerDetail_ID = New SelectList(db.Tr_ProspectCustDetails, "ProspectCustomerDetail_ID", "Transaction_Type", tr_ApplicationPOs.ProspectCustomerDetail_ID)
        '    Return View(tr_ApplicationPOs)
        'End Function

        ' GET: ApplicationPO/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApplicationPOs = (From A In db.Tr_ApplicationPOs
                                     Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                                     Where A.ApplicationPO_ID = id
                                     Select New Tr_ApplicationPO With {.CompanyName = B.Company_Name, .Vehicle = B.Vehicle, .Qty = B.Qty - If(B.QtyAppPO, 0),
                                        .ProspectCustomerDetail_ID = B.ProspectCustomerDetail_ID, .ApplicationPO_No = A.ApplicationPO_No, .Color = A.Color, .Delivery_Date = A.Delivery_Date,
                                         .Usage = A.Usage, .QtyAppPO = A.Qty, .Refund = A.Refund, .PaymentByUser = A.PaymentByUser}).FirstOrDefault
            If IsNothing(tr_ApplicationPOs) Then
                Return HttpNotFound()
            End If
            Return View(tr_ApplicationPOs)
        End Function

        ' POST: ApplicationPO/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Using dbs = db.Database.BeginTransaction
                Try
                    Dim tr_ApplicationPOs As Tr_ApplicationPOs = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And x.ApplicationPO_ID = id).FirstOrDefault
                    tr_ApplicationPOs.IsDeleted = True
                    tr_ApplicationPOs.ModifiedBy = user
                    tr_ApplicationPOs.ModifiedDate = DateTime.Now
                    db.SaveChanges()
                    Dim detail = db.Tr_ApplicationPODetails.Where(Function(x) x.ApplicationPO_ID = id).ToList
                    For Each i In detail
                        i.IsDeleted = True
                        i.ModifiedBy = user
                        i.ModifiedDate = DateTime.Now
                        db.SaveChanges()
                    Next
                    Dim application_ID = db.V_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = tr_ApplicationPOs.ProspectCustomerDetail_ID).Select(Function(x) x.Application_ID).FirstOrDefault
                    Dim application = db.Tr_Applications.Where(Function(x) x.Application_ID = application_ID).FirstOrDefault
                    application.IsFillOTR = False
                    application.FillOTRBy = Nothing
                    db.SaveChanges()
                    Dim approval = db.Tr_ApprovalPOs.Where(Function(x) x.ProspectCustomer_ID = tr_ApplicationPOs.ProspectCustomer_ID And x.IsDeleted = False).FirstOrDefault
                    If approval IsNot Nothing Then
                        approval.IsDeleted = True
                        approval.ModifiedBy = user
                        approval.ModifiedDate = DateTime.Now
                        db.SaveChanges()
                    End If
                    dbs.Commit()
                Catch ex As Exception
                    dbs.Rollback()
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message)
                End Try
            End Using
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
