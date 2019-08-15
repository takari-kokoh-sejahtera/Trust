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
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO.File
Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Reporting.WebForms
Imports Ionic.Zip

Namespace Controllers
    Public Class QuotationController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
#Region "Java"
        Public Function FillCustomer(ByVal val As Integer?) As ActionResult
            If val IsNot Nothing Then
                If val = 0 Then
                    Return Json(New With {Key .success = "false"})
                End If
                Dim Query = (From A In db.V_ProspectCusts
                             Where A.ProspectCustomer_ID = val
                             Select A.CompanyGroup_Name, A.PT, A.Tbk, A.Company_Name, A.Address, A.City, A.Phone, A.Email, A.PIC_Name, A.PIC_Phone, A.PIC_Email).FirstOrDefault()
                Dim Detail = From A In db.V_ProspectCustDetails
                             Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
                             Where A.ProspectCustomer_ID = val And A.IsCalculate = True And B.IsDeleted = False
                             Select fill = False, B.Calculate_ID, A.IsVehicleExists, A.Brand_Name, A.Vehicle, A.Lease_price, A.Qty, A.Year, A.Lease_long, A.Amount, B.Bid_PricePerMonth

                'Dim amount = Query.Amount.ToString("#,##0.00")
                Return Json(New With {Key .success = "true", Key .CompanyGroup_Name = Query.CompanyGroup_Name, .Company_Name = Query.PT + " " + Query.Company_Name + " " + IIf(Query.Tbk, "Tbk", "Non TBK"),
                            .Address = Query.Address, .City = Query.City, .Phone = Query.Phone, .Email = Query.Email, .PIC_Name = Query.PIC_Name, .PIC_Phone = Query.PIC_Phone, .PIC_Email = Query.PIC_Email, .Detail = Detail})
            End If
            Return Json(New With {Key .success = "false"})
        End Function
#End Region
        Function Zip(id As String) As ActionResult
            Dim outputStream = New MemoryStream
            Dim noref As String
            Using zip1 As ZipFile = New ZipFile()
                Report(id, zip1)
                Dim detailCal = db.V_QuotationHD.Where(Function(x) x.Quotation_ID = id).ToList
                For Each i In detailCal
                    ReportCal(i.Calculate_ID, zip1)
                    ReportCalCashFlow(i.Calculate_ID, zip1)
                Next
                noref = detailCal.Select(Function(x) x.No_Ref).FirstOrDefault
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "" + noref + ".zip")
        End Function
        Sub ReportCalCashFlow(Calculate_ID As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/CalculateCashFlow.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim List = db.sp_PrintCalculateCashFlow(Calculate_ID).ToList
            Dim rd = New ReportDataSource("DSPrintCalculateCashFlow", List)
            lr.DataSources.Add(rd)
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

            zip.AddEntry(List.FirstOrDefault.Type.Replace("/", "") + " CashFlow " + Calculate_ID.ToString + ".pdf", renderedBytes)

        End Sub
        Sub ReportCal(Calculate_ID As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/CalculateNew.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim List = db.sp_PrintCalculation(Calculate_ID).ToList
            Dim rd = New ReportDataSource("DSCal", List)
            lr.DataSources.Add(rd)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>8.3in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.3in</MarginTop>" +
            " <MarginLeft>0.3in</MarginLeft>" +
            " <MarginRight>0.3in</MarginRight>" +
            " <MarginBottom>0.3in</MarginBottom>" +
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

            zip.AddEntry(List.FirstOrDefault.Vehicle.Replace("/", "") + " " + Calculate_ID.ToString + ".pdf", renderedBytes)

        End Sub

        Sub Report(id As String, zip As ZipFile)
            Dim List = db.sp_PrintQuotation(id).ToList
            Dim lr = New LocalReport()
            Dim path As String
            If List.Where(Function(x) x.Transaction_Type = "COP").Any Then
                path = Server.MapPath("~/Report/QuotationCOP.rdlc")
            Else
                path = Server.MapPath("~/Report/Quotation.rdlc")
            End If
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim NoRef = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = id).FirstOrDefault.No_Ref
            Dim rd = New ReportDataSource("DSQuotation", List)
            lr.DataSources.Add(rd)


            Dim listrow = db.V_ProspectCusts.Where(Function(x) x.Quotation_ID = id).FirstOrDefault

            Dim Par(1) As String
            Dim fillstr As String
            Dim i = 0
            fillstr = If(Not listrow.Maintenance_Tick, "    -   24 Hours/7 Days Support" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Assurance_Tick, "    -   All Risk Insurance" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Maintenance_Tick, "    -   All-Time Roadside Assistance" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Maintenance_Tick, "    -   Nationwide Workshop Support" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Maintenance_Tick, "    -   Full Service & Maintenance" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = "    -   Prompt Delivery" + vbNewLine
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Replacement_Tick, "    -   Quick Replacement Vehicle" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If
            fillstr = If(Not listrow.Maintenance_Tick, "    -   Support/Guidance Book" + vbNewLine, "")
            Par(i) = Par(i) + fillstr
            If fillstr <> "" Then
                i = If(i = 0, 1, 0)
            End If

            Dim param1 = New ReportParameter("Param1", Par(0), False)
            Dim param2 = New ReportParameter("Param2", If(Par(1) = "", " ", Par(1)), False)
            lr.SetParameters(New ReportParameter() {param1, param2})
            lr.Refresh()
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            'akalin kalo signernya kepotong
            Dim MarginBottom = "1cm"
            If List.Count = 10 Or List.Count = 9 Or List.Count = 8 Then
                MarginBottom = "3cm"
            End If
            'Dim deviceInfo =
            '"<DeviceInfo>" +
            '" <OutputFormat>" + "PDF" + "</OutputFormat>" +
            '" <PageWidth>8.3in</PageWidth>" +
            '" <PageHeight>11in</PageHeight>" +
            '" <MarginTop>" + MarginTop + "</MarginTop>" +
            '" <MarginLeft>2cm</MarginLeft>" +
            '" <MarginRight>0in</MarginRight>" +
            '" <MarginBottom>1cm</MarginBottom>" +
            '"</DeviceInfo>"
            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>8.3in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0cm</MarginTop>" +
            " <MarginLeft>0cm</MarginLeft>" +
            " <MarginRight>0cm</MarginRight>" +
            " <MarginBottom>" + MarginBottom + "</MarginBottom>" +
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
            zip.AddEntry(NoRef.Replace("/", "") + ".pdf", renderedBytes)

        End Sub
        <HttpPost()>
        Function TEST() As ActionResult
            Dim Query = (From A In db.Tr_Quotations.Where(Function(x) x.IsDeleted = False)
                         Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                         Group Join C In db.Tr_Approvals.Where(Function(x) x.IsDeleted = False) On A.Quotation_ID Equals C.Quotation_ID Into CA = Group
                         From C In CA.DefaultIfEmpty()
                         Where A.IsDeleted = False
                         Select A.Quotation_ID, B.Company_Name, A.No_Ref, A.Quotation_Validity, A.CreatedDate, CreatedBy = A.Cn_Users.User_Name, A.ModifiedDate, ModifiedBy = A.Cn_Users1.User_Name, A.IsApplication, C.Status, CreatedBy_ID = A.CreatedBy, A.IsNotApproved).
                         Select(Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .Company_Name = x.Company_Name, .No_Ref = x.No_Ref, .Quotation_Validity = x.Quotation_Validity, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
                             .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy, .IsApplication = x.IsApplication, .Status = x.Status, .CreatedBy_ID = x.CreatedBy_ID, .IsNotApproved = x.IsNotApproved})
            Return Json(Query, JsonRequestBehavior.AllowGet)
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
            Dim Query = (From A In db.Tr_Quotations.Where(Function(x) x.IsDeleted = False)
                         Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                         Group Join C In db.Tr_Approvals.Where(Function(x) x.IsDeleted = False) On A.Quotation_ID Equals C.Quotation_ID Into CA = Group
                         From C In CA.DefaultIfEmpty()
                         Where A.IsDeleted = False
                         Select A.Quotation_ID, B.Company_Name, A.No_Ref, A.Quotation_Validity, A.CreatedDate, CreatedBy = A.Cn_Users.User_Name, A.ModifiedDate, ModifiedBy = A.Cn_Users1.User_Name, A.IsApplication, C.Status, CreatedBy_ID = A.CreatedBy, A.IsNotApproved).
                         Select(Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .Company_Name = x.Company_Name, .No_Ref = x.No_Ref, .Quotation_Validity = x.Quotation_Validity, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
                             .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy, .IsApplication = x.IsApplication, .Status = x.Status, .CreatedBy_ID = x.CreatedBy_ID, .IsNotApproved = x.IsNotApproved})

            Dim Prospec = New ProspectController
            Dim list = Prospec.GetUserMarketing(Session("ID"), Session("Role_ID"), Session("Department_ID"))
            If list.FirstOrDefault = 0 Then
                Return New HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, "You are not part of marketing")
            End If

            Query.Where(Function(x) list.Contains(x.CreatedBy_ID))

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Company_Name.Contains(searchString) OrElse s.No_Ref.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "No_Ref"
                    Query = Query.OrderBy(Function(s) s.No_Ref)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            'Return View(Await tr_Quotations.ToListAsync())
        End Function

        ' GET: Quotation/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim detail = From A In db.V_ProspectCustDetails
                         Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
                         Where A.Quotation_ID = id And A.IsCalculate = True And B.IsDeleted = False
                         Select New Tr_QuotationDetail With {.QuotationDetail_ID = A.QuotationDetail_ID, .IsVehicleExists = A.IsVehicleExists, .Brand_Name = A.Brand_Name, .Vehicle = A.Vehicle, .Lease_price = A.Lease_price, .Qty = A.Qty, .Year = A.Year, .Lease_long = A.Lease_long, .Amount = A.Amount, .Bid_Price = B.Bid_PricePerMonth}
            Dim Query = (From z In db.V_ProspectCusts
                         Join B In db.Tr_Quotations.Where(Function(x) x.IsDeleted = False) On z.Quotation_ID Equals B.Quotation_ID
                         Where z.Quotation_ID = id
                         Select New Tr_Quotation With {.CompanyGroup_Name = z.CompanyGroup_Name, .Company_Name = z.Company_Name, .Address = z.Address, .City = z.City, .Phone = z.Phone, .Email = z.Email, .PIC_Name = z.PIC_Name,
                              .PIC_Phone = z.PIC_Phone, .PIC_Email = z.PIC_Email, .RemarkNotApproved = B.RemarkNotApproved,
                             .Detail = detail}).FirstOrDefault()
            'Select Case New Tr_QuotationDetail With {.QuotationDetail_ID = A.QuotationDetail_ID, .IsVehicleExists = A.IsVehicleExists, .Brand_Name = A.Brand_Name, .Vehicle = A.Vehicle, .Lease_price = A.Lease_price, .Qty = A.Qty, .Year = A.Year, .Lease_long = A.Lease_long, .Amount = A.Amount, .Bid_Price = B.Bid_PricePerMonth}}).FirstOrDefault()

            'Dim Query = (From A In db.Tr_Quotations
            '             Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
            '             Where A.IsDeleted = False And A.Quotation_ID = id
            '             Select A.Quotation_ID, B.Company_Name, A.No_Ref, A.Quotation_Validity, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy).
            '             Select(Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .Company_Name = x.Company_Name, .No_Ref = x.No_Ref, .Quotation_Validity = x.Quotation_Validity, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
            '                 .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy}).FirstOrDefault()
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Return View(Query)
        End Function

        ' GET: Quotation/Create
        Function Create() As ActionResult
            Dim Detail = From A In db.V_ProspectCusts
                         Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                         Where B.IsCalculate = True And A.IsQuotation = False
                         Group New With {A.ProspectCustomer_ID, A.Company_Name} By A Into AA = Group
                         Order By A.CreatedDate Descending
                         Select A.ProspectCustomer_ID, A.Company_Name

            ViewBag.ProspectCustomer_ID = New SelectList(Detail, "ProspectCustomer_ID", "Company_Name")
            ViewBag.Signer_ID = New SelectList(db.Ms_Contract_Signers, "Signer_ID", "Name")
            Dim quot As New Tr_Quotation
            quot.Quotation_Validity = 14
            Return View(quot)
        End Function
        'Save Detail
        Public Function SaveOrder(ProspectCustomer_ID As Integer, Remark As String, RemarkInternal As String, Quotation_Validity As Integer, IsDriver As Boolean, DriverQty As Integer?, DriverAmount As Decimal?, Signer_ID As Integer, order() As Tr_QuotationDetail) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim result As String = "Error", Message As String = ""

            'Validasi
            Dim Valid As Boolean = True
            If (ProspectCustomer_ID = 0 And Quotation_Validity = 0) And order Is Nothing Then
                Valid = False
                Message = "Please Choose Customer"
            ElseIf RemarkInternal.Trim = "" Then
                Valid = False
                Message = "Must fill Remark Internal"
            End If
            If Valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim no = db.Cn_NoSerieSetup.Where(Function(x) x.Transaction = "Quotation" And x.YearNo = DateTime.Now.Year And x.MonthNo = DateTime.Now.Month).FirstOrDefault()
                        Dim number As Integer
                        If no Is Nothing Then
                            Dim NoSeries As New Cn_NoSerieSetup
                            NoSeries.Transaction = "Quotation"
                            NoSeries.YearNo = DateTime.Now.Year
                            NoSeries.MonthNo = DateTime.Now.Month
                            NoSeries.NextNo = 1
                            NoSeries.CreatedDate = DateTime.Now
                            NoSeries.CreatedBy = user
                            NoSeries.IsDeleted = False
                            db.Cn_NoSerieSetup.Add(NoSeries)
                            number = 1
                        Else
                            no.NextNo = no.NextNo + 1
                            no.ModifiedBy = user
                            no.ModifiedDate = DateTime.Now
                            number = no.NextNo
                        End If
                        Dim ref As String = number.ToString("D5") + "-QT/TKS/MKT/" + GeneralControl.RomawiMonth(DateTime.Now.Month) + "/" + DateTime.Now.Year.ToString()

                        Dim Quotations As New Tr_Quotations
                        Quotations.ProspectCustomer_ID = ProspectCustomer_ID
                        Quotations.No_Ref = ref
                        Quotations.Remark = Remark
                        Quotations.RemarkInternal = RemarkInternal
                        Quotations.Quotation_Validity = Quotation_Validity
                        Quotations.IsDriver = IsDriver
                        Quotations.DriverQty = DriverQty
                        Quotations.DriverAmount = DriverAmount
                        Quotations.IsPO = 0
                        Quotations.Signer_ID = Signer_ID
                        Quotations.CreatedBy = user
                        Quotations.CreatedDate = DateTime.Now
                        Quotations.IsDeleted = False
                        Quotations.IsApplication = False
                        Quotations.IsNotApproved = False
                        db.Tr_Quotations.Add(Quotations)
                        For Each item In order
                            Dim D As New Tr_QuotationDetails
                            D.Quotation_ID = Quotations.Quotation_ID
                            D.Calculate_ID = item.Calculate_ID
                            D.CreatedBy = user
                            D.CreatedDate = DateTime.Now
                            D.IsDeleted = False
                            db.Tr_QuotationDetails.Add(D)
                        Next
                        Dim prospec = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = ProspectCustomer_ID).FirstOrDefault()
                        prospec.IsQuotation = True
                        prospec.ModifiedBy = user
                        prospec.ModifiedDate = DateTime.Now
#Region "Jika Pake Approval"
                        'Approval Di ilangin dulu
                        'add Approval
                        Dim A As New Tr_Approvals With {
                            .Quotation_ID = Quotations.Quotation_ID,
                            .StatusRecord = 1, 'karna dia longkap maker, maka jadi 1, kalo makernya ada jadi 0
                            .Status = "Open",
                            .IsApplicationHeader = False,
                            .IsApplicationHeaderDone = False,
                            .CreatedBy = user,
                            .CreatedDate = DateTime.Now,
                            .IsDeleted = False
                        }
                        db.Tr_Approvals.Add(A)
                        db.SaveChanges()
#End Region
#Region "Jika Tidak Pake Approval"
                        ''add Approval
                        'Dim A As New Tr_Approvals With {
                        '.Quotation_ID = Quotations.Quotation_ID,
                        '.StatusRecord = 0,
                        '.Status = "Finish",
                        '.IsApplicationHeader = False,
                        '.IsApplicationHeaderDone = False,
                        '.CreatedBy = user,
                        '.CreatedDate = DateTime.Now,
                        '.IsDeleted = False
                        '}
                        'db.Tr_Approvals.Add(A)
                        'db.SaveChanges()
                        'dim app = New ApprovalController
                        'app.CreateApplication(db, A.Approval_ID, user, Quotations.Quotation_ID)
#End Region
                        result = ref
                        dbs.Commit()
                        result = "Success"
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using


            End If
            Return Json(New With {.result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function

        '' GET: Quotation/Edit/5
        'Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim tr_Quotations As Tr_Quotations = Await db.Tr_Quotations.FindAsync(id)
        '    If IsNothing(tr_Quotations) Then
        '        Return HttpNotFound()
        '    End If
        '    Dim tr_Quotation = (From A In db.Tr_Quotations
        '                        Group Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID Into Group
        '                        From B In Group.DefaultIfEmpty()
        '                        Where A.Quotation_ID = id And A.IsDeleted = False
        '                        Select A.Quotation_ID, A.ProspectCustomer_ID, B.Company_Name, B.CompanyGroup_Name, Company = B.PT + " " + B.Company_Name, B.Address, B.City, B.Phone, B.Email, B.PIC_Name, B.PIC_Phone, B.PIC_Email, A.Quotation_Validity, A.Remark, A.Signer_ID).Select(
        '    Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .ProspectCustomer_ID = x.ProspectCustomer_ID, .Company_Name = x.Company_Name, .CompanyGroup_Name = x.CompanyGroup_Name,
        '    .Company = x.Company, .Address = x.Address, .City = x.City, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email,
        '    .Quotation_Validity = x.Quotation_Validity, .Remark = x.Remark, .Signer_ID = x.Signer_ID}).FirstOrDefault()

        '    Dim detail = (From A In db.V_ProspectCustDetails
        '                  Group Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID    Group
        '                  From B In Group.DefaultIfEmpty()
        '                  Group Join C In db.Tr_QuotationDetails On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
        '                  From C In CB.DefaultIfEmpty()
        '                  Where A.ProspectCustomer_ID = tr_Quotation.ProspectCustomer_ID And A.IsCalculate = True And B.IsDeleted = False
        '                  Select Calculate_ID = CType(B.Calculate_ID, Integer?), QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?), IsDeleted = CType(Not C.IsDeleted, Boolean?), A.IsVehicleExists, A.Brand_Name, A.Vehicle, A.Lease_price, A.Qty, A.Year, A.Lease_long, A.Amount, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?)).ToList()

        '    ViewBag.detail = detail
        '    Return View(tr_Quotation)
        'End Function
        'Public Function EditOrder(Quotation_ID As Integer, Remark As String, Quotation_Validity As Integer, IsDriver As Boolean, DriverQty As Integer, DriverAmount As Decimal, order() As Tr_QuotationDetail) As ActionResult
        '    Dim user As String
        '    If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
        '    Dim result As String = "Error"
        '    'Validasi
        '    Dim Valid As Boolean = False
        '    If (Quotation_ID <> 0 And Quotation_Validity <> 0) And order IsNot Nothing Then
        '        Valid = True
        '    End If

        '    If Valid Then
        '        Dim Quotations = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = Quotation_ID).FirstOrDefault()
        '        Quotations.Remark = Remark
        '        Quotations.Quotation_Validity = Quotation_Validity
        '        Quotations.IsDriver = IsDriver
        '        Quotations.DriverQty = DriverQty
        '        Quotations.DriverAmount = DriverAmount
        '        Quotations.ModifiedBy = user
        '        Quotations.ModifiedDate = DateTime.Now
        '        For Each item In order
        '            If item.Check Then
        '                If item.QuotationDetail_ID = 0 Then
        '                    Dim D As New Tr_QuotationDetails
        '                    D.Quotation_ID = Quotation_ID
        '                    D.Calculate_ID = item.Calculate_ID
        '                    D.CreatedBy = user
        '                    D.CreatedDate = DateTime.Now
        '                    D.IsDeleted = False
        '                    db.Tr_QuotationDetails.Add(D)
        '                Else
        '                    Dim D = db.Tr_QuotationDetails.Where(Function(x) x.QuotationDetail_ID = item.QuotationDetail_ID).FirstOrDefault()
        '                    D.ModifiedBy = user
        '                    D.ModifiedDate = DateTime.Now
        '                    D.IsDeleted = False
        '                End If
        '            Else
        '                If item.QuotationDetail_ID <> 0 Then
        '                    Dim D = db.Tr_QuotationDetails.Where(Function(x) x.QuotationDetail_ID = item.QuotationDetail_ID).FirstOrDefault()
        '                    D.ModifiedBy = user
        '                    D.ModifiedDate = DateTime.Now
        '                    D.IsDeleted = True
        '                End If
        '            End If
        '        Next
        '        db.SaveChanges()
        '        result = "Success"
        '    End If
        '    Return Json(result, JsonRequestBehavior.AllowGet)
        'End Function
        ' GET: Quotation/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Query = (From A In db.Tr_Quotations
                         Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                         Where A.IsDeleted = False And A.Quotation_ID = id
                         Select A.Quotation_ID, B.Company_Name, A.No_Ref, A.Quotation_Validity, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy).
                         Select(Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .Company_Name = x.Company_Name, .No_Ref = x.No_Ref, .Quotation_Validity = x.Quotation_Validity, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
                             .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy}).FirstOrDefault()
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Return View(Query)
        End Function

        ' POST: Quotation/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim tr_Quotations As Tr_Quotations = Await db.Tr_Quotations.FindAsync(id)
            tr_Quotations.IsDeleted = True
            tr_Quotations.ModifiedBy = user
            tr_Quotations.ModifiedDate = DateTime.Now
            Dim prospec = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = tr_Quotations.ProspectCustomer_ID).FirstOrDefault()
            prospec.IsQuotation = False
            prospec.ModifiedBy = user
            prospec.ModifiedDate = DateTime.Now
            Dim A = db.Tr_Approvals.Where(Function(x) x.Quotation_ID = id).FirstOrDefault()
            If A IsNot Nothing Then
                A.IsDeleted = True
                A.ModifiedBy = user
                A.ModifiedDate = DateTime.Now
            End If
            db.SaveChanges()

            Await db.SaveChangesAsync()
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
