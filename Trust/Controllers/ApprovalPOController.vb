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
    Public Class ApprovalPOController
        Inherits System.Web.Mvc.Controller

        Dim general As GeneralControl
        Private db As New TrustEntities
#Region "Java"
        Public Function NotApprove(ByVal ApprovalPO_ID As Integer?, ByVal val As String) As ActionResult
            If val <> "" Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level = Session("Level_ID_ApplicationPO")
                Dim Query = db.Tr_ApprovalPOs.Where(Function(x) x.ApprovalPO_ID = ApprovalPO_ID).FirstOrDefault()
                If level = 1 Or level = 2 Or level = 3 Or level = 4 Or level = 5 Or level = 6 Then
                    Query.StatusRecord = level
                    Query.RemarkNotApprove = val
                    Query.ModifiedDate = DateTime.Now
                    Query.ModifiedBy = user
                ElseIf level = 7 Then
                    Query.StatusRecord = level
                    Query.RemarkNotApprove = val
                    Query.ModifiedDate = DateTime.Now
                    Query.ModifiedBy = user
                End If
                Query.Status = "Close"
                Dim quotation = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = Query.ProspectCustomer_ID).FirstOrDefault
                quotation.IsApplicationPO = False
                quotation.ModifiedDate = DateTime.Now
                quotation.ModifiedBy = user
                db.SaveChanges()

                'Ubah jadi Not approve di ApplicationPO
                Dim appPO = db.Tr_ApplicationPOs.Where(Function(x) x.ProspectCustomer_ID = Query.ProspectCustomer_ID).ToList
                For Each i In appPO
                    i.IsNotApproved = True
                    i.RemarkNotApproved = val
                Next
                db.SaveChanges()
                Return Json(New With {Key .success = "true"})
            End If
            Return Json(New With {Key .success = "false", .error = "Please fill remark"})
        End Function

#End Region

        Function Zip(id As String) As ActionResult
            Dim outputStream = New MemoryStream
            Using zip1 As ZipFile = New ZipFile()
                Dim detailCal = db.Tr_ApplicationPODetails.Where(Function(x) x.Tr_ApplicationPOs.ProspectCustomer_ID = id And x.IsChecked And x.IsDeleted = False).
                GroupBy(Function(x) x.Dealer_ID).Select(Function(x) x.Key).ToList
                Dim no = 1
                For Each i In detailCal
                    Report(id, i.Value, no, zip1)
                    ReportDealer(id, i.Value, no, zip1)
                    'ReportCalCashFlow(i.Calculate_ID, zip1)
                    no = no + 1
                Next
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "ApplicationPO.zip")
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
        ' GET: ApprovalPO
        Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
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
            Dim id = Session("ID")
            Dim V_app = db.V_Approval.Where(Function(x) x.User_ID = user And x.Module_ID = 1050).FirstOrDefault

            Dim Level_ID = If(V_app Is Nothing, 0, V_app.Level_ID)
            Dim Level_IDNotApp() = {1, 2}
            Dim Limited_Approval = If(V_app Is Nothing, 0, V_app.Limited_Approval)

            'Dim tr_Approval = db.Tr_Approvals.Where(Function(x) x.IsDeleted = False).
            'Select(Function(x) New Tr_Approval With {.Approve = If(Level_IDNotApp.Contains(Level_ID) And Limited_Approval >= x.Cost_Price)})


            Dim tr_Approval = From A In db.Tr_ApprovalPOs
                              Group Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID Into BA = Group
                              From B In BA.DefaultIfEmpty()
                              Where A.IsDeleted = False
                              Select New Tr_ApprovalPO With {.Approve = If(((Level_IDNotApp.Contains(Level_ID) And Limited_Approval >= B.Cost_Price) Or (Not Level_IDNotApp.Contains(Level_ID))) And Level_ID - 1 >= A.StatusRecord And A.Status = "Open", True, False),
                                  .No_Ref = B.No_Ref, .Company_Name = B.PT + " " + B.Company_Name, .ApprovalPO_ID = A.ApprovalPO_ID, .ProspectCustomer_ID = A.ProspectCustomer_ID, .MakerDate = A.MakerDate, .MakerBy = A.Cn_Users7.User_Name, .MakerRemark = A.MakerRemark,
                                  .CheckerDate = A.CheckerDate, .CheckerBy = A.Cn_Users5.User_Name, .CheckerRemark = A.CheckerRemark,
                                  .Approval1Date = A.Approval1Date, .Approval1By = A.Cn_Users.User_Name, .Approval1Remark = A.Approval1Remark,
                                  .Approval2Date = A.Approval2Date, .Approval2By = A.Cn_Users1.User_Name, .Approval2Remark = A.Approval2Remark,
                                  .Approval3Date = A.Approval3Date, .Approval3By = A.Cn_Users2.User_Name, .Approval3Remark = A.Approval3Remark,
                                  .Approval4Date = A.Approval4Date, .Approval4By = A.Cn_Users3.User_Name, .Approval4Remark = A.Approval4Remark,
                                  .Approval5Date = A.Approval5Date, .Approval5By = A.Cn_Users4.User_Name, .Approval5Remark = A.Approval5Remark, .StatusRecord = A.StatusRecord, .Status = A.Status, .RemarkNotApprove = A.RemarkNotApprove,
                                  .CreatedDate = A.CreatedDate, .CreatedBy = A.Cn_Users6.User_Name, .CreatedBy_ID = A.CreatedBy, .ModifiedDate = A.ModifiedDate, .ModifiedBy = A.Cn_Users8.User_Name, .Cost_Price = B.Cost_Price}

            Dim Prospec = New ProspectController
            Dim list = Prospec.GetUserMarketing(Session("ID"), Session("Role_ID"), Session("Department_ID"))
            If list.FirstOrDefault <> 0 Then
                tr_Approval = tr_Approval.Where(Function(x) list.Contains(x.CreatedBy_ID))
            End If

            'Dim tr_Approval = db.sp_QuotationList(id)
            If Not String.IsNullOrEmpty(searchString) Then
                tr_Approval = tr_Approval.Where(Function(s) s.No_Ref.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "No_Ref"
                    tr_Approval = tr_Approval.OrderBy(Function(s) s.No_Ref)
                Case "Company_Name"
                    tr_Approval = tr_Approval.OrderBy(Function(s) s.Company_Name)
                Case Else
                    tr_Approval = From A In tr_Approval Order By A.Approve Descending, A.CreatedDate Descending
            End Select
            Dim pageNumber As Integer = If(page, 1)
            ViewBag.Level_ID = Session("Level_ID_Quotation")
            ViewBag.LevelGroup_ID = Session("LevelGroup_ID")
            ViewBag.Limited_Approval = Session("Limited_Approval_Quotation")
            Return View(tr_Approval.ToList.ToPagedList(pageNumber, pageSize))
        End Function

        Function Detail(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Approval = (From A In db.Tr_ApprovalPOs
                               Group Join C In db.V_ProspectCusts On A.ProspectCustomer_ID Equals C.ProspectCustomer_ID Into CA = Group
                               From C In CA.DefaultIfEmpty()
                               Where A.IsDeleted = False And A.ApprovalPO_ID = id
                               Select C.No_Ref, Company_Name = C.PT + " " + C.Company_Name, A.ApprovalPO_ID, A.ProspectCustomer_ID, C.CompanyGroup_Name, C.Address,
                                   C.Phone, C.Email, C.PIC_Name, C.PIC_Phone, C.PIC_Email).Select(
            Function(x) New Tr_ApprovalPO With {.No_Ref = x.No_Ref, .Company_Name = x.Company_Name, .ApprovalPO_ID = x.ApprovalPO_ID,
                .CompanyGroup_Name = x.CompanyGroup_Name, .Address = x.Address, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone,
                .PIC_Email = x.PIC_Email, .ProspectCustomer_ID = x.ProspectCustomer_ID}).FirstOrDefault()

            If IsNothing(tr_Approval) Then
                Return HttpNotFound()
            End If

            Dim details = (From A In db.V_ProspectCustDetails
                           Group Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                           From B In Group.DefaultIfEmpty()
                           Group Join C In db.V_QuotationHD On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
                           From C In CB.DefaultIfEmpty()
                           Where A.ProspectCustomer_ID = tr_Approval.ProspectCustomer_ID And A.IsCalculate = True And B.IsDeleted = False
                           Select Calculate_ID = CType(B.Calculate_ID, Integer?), QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?),
                              IsDeleted = CType(Not C.Quotation_ID, Boolean?), IsVehicleExists = If(A.IsVehicleExists, "Used Car", "New Car"), A.Brand_Name,
                              Vehicle = If(A.IsVehicleExists, A.Vehicle + " " + A.Type, A.Vehicle),
                              A.Lease_price, A.Qty, A.Year,
                              A.Lease_long, A.Amount, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?),
                              Rent_Location = B.Ms_Citys2.City, Plat_Location = B.Ms_Citys1.City, B.Update_Diskon, B.Cost_Price, B.Depresiasi_Percent, B.Residual_ValuePercent, B.Residual_Value, B.Maintenance_Percent,
                              B.Assurance_Percent, B.Expedition_Cost, B.Modification, B.GPS_Cost, B.Agent_Fee, B.Keur, B.IRR, B.Profit, B.Spread, A.Transaction_Type, B.Funding_Rate).ToList()

            ViewBag.detail = details
            Return View(tr_Approval)
        End Function




        Function Create(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ApprovalPO = (From A In db.Tr_ApprovalPOs
                              Join B In db.V_ProspectCusts On B.ProspectCustomer_ID Equals A.ProspectCustomer_ID
                              Where A.IsDeleted = False And A.ApprovalPO_ID = id
                              Select B.No_Ref, Company_Name = B.PT + " " + B.Company_Name, A.ApprovalPO_ID, B.CompanyGroup_Name, B.Address,
                                   B.Phone, B.Email, B.PIC_Name, B.PIC_Phone, B.PIC_Email, A.ProspectCustomer_ID, CreatedBy = A.Cn_Users6.User_Name).Select(
            Function(x) New Tr_ApprovalPO With {.No_Ref = x.No_Ref, .Company_Name = x.Company_Name, .ApprovalPO_ID = x.ApprovalPO_ID,
                .CompanyGroup_Name = x.CompanyGroup_Name, .Address = x.Address, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone,
                .PIC_Email = x.PIC_Email, .ProspectCustomer_ID = x.ProspectCustomer_ID, .CreatedBy = x.CreatedBy}).FirstOrDefault()

            'ApprovalPO.Detail = (From A In db.Tr_ApplicationPOs
            '                     Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
            '                     Where A.ProspectCustomer_ID = ApprovalPO.ProspectCustomer_ID
            '                     Select New Tr_ApplicationPO With {.ApplicationPO_ID = A.ApplicationPO_ID, .ProspectCustomerDetail_ID = A.ProspectCustomerDetail_ID,
            '                         .Vehicle = B.Vehicle, .Color = A.Color, .Delivery_Date = A.Delivery_Date, .Usage = A.Usage, .Qty = A.Qty, .Refund = A.Refund,
            '                         .PaymentByUser = A.PaymentByUser,
            '                         .Detail = (From AA In db.Tr_ApplicationPODetails
            '                                    Where AA.ApplicationPO_ID = A.ApplicationPO_ID
            '                                    Select New Tr_ApplicationPODetail With {.Dealer = AA.Ms_Dealers.Dealer_Name, .OTR_Price = AA.OTR_Price, .Discount = AA.Discount, .Status = AA.Status,
            '                                        .IsChecked = AA.IsChecked}).ToList}).ToList
            ApprovalPO.Detail = (From A In db.Tr_ApplicationPOs
                                 Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID
                                 Where A.ProspectCustomer_ID = ApprovalPO.ProspectCustomer_ID And A.IsDeleted = False
                                 Select New Tr_ApplicationPO With {.ApplicationPO_ID = A.ApplicationPO_ID, .ProspectCustomerDetail_ID = A.ProspectCustomerDetail_ID,
                                     .Vehicle = B.Vehicle, .Color = A.Color, .Delivery_Date = A.Delivery_Date, .Usage = A.Usage, .Qty = A.Qty, .Refund = A.Refund,
                                     .PaymentByUser = A.PaymentByUser}).ToList
            For Each i In ApprovalPO.Detail
                i.Detail = (From AA In db.Tr_ApplicationPODetails
                            Where AA.ApplicationPO_ID = i.ApplicationPO_ID
                            Select New Tr_ApplicationPODetail With {.Dealer = AA.Ms_Dealers.Dealer_Name, .OTR_Price = AA.OTR_Price, .Discount = AA.Discount, .Status = AA.Status,
                               .IsChecked = AA.IsChecked}).ToList
            Next

            If IsNothing(ApprovalPO) Then
                Return HttpNotFound()
            End If



            Return View(ApprovalPO)
        End Function


        Public Function GenerateNo(db As TrustEntities, Transaction As String, User As Integer) As Integer
            Dim no = db.Cn_NoSerieSetup.Where(Function(x) x.Transaction = Transaction And x.YearNo = DateTime.Now.Year And x.MonthNo = DateTime.Now.Month).FirstOrDefault()
            Dim number As Integer
            If no Is Nothing Then
                Dim NoSeries As New Cn_NoSerieSetup
                NoSeries.Transaction = Transaction
                NoSeries.YearNo = DateTime.Now.Year
                NoSeries.MonthNo = DateTime.Now.Month
                NoSeries.NextNo = 1
                NoSeries.CreatedDate = DateTime.Now
                NoSeries.CreatedBy = User
                NoSeries.IsDeleted = False
                db.Cn_NoSerieSetup.Add(NoSeries)
                number = 1
            Else
                no.NextNo = no.NextNo + 1
                no.ModifiedBy = User
                no.ModifiedDate = DateTime.Now
                number = no.NextNo
            End If
            Return number
        End Function
        ' POST: Approval/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        Public Sub ApproveFinish(db As TrustEntities, ProspectCustomer_ID As Integer, user As Integer, WithPO As Boolean)
            Try
                Dim transaction = "PO DEALER"
                Dim Vpro = db.V_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = ProspectCustomer_ID).FirstOrDefault

                Dim proc = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = ProspectCustomer_ID).FirstOrDefault
                proc.IsApplicationPO = True
                If WithPO Then
                    Dim no As Integer = GenerateNo(db, transaction, user)
                    proc.PO_No = Right("000" + no.ToString, 4) + "-PO/TKS/" + If(Vpro.Transaction_Type, "") + "/" + GeneralControl.RomawiMonth(DateTime.Now.Month) + "/" + DateTime.Now.Year.ToString
                End If
                db.SaveChanges()


                'Upadte Approval
                Dim approval = db.Tr_Approvals.Where(Function(x) x.IsDeleted = False And x.Quotation_ID = Vpro.Quotation_ID).FirstOrDefault
                approval.IsApplicationHeader = CType(True, Boolean)
                db.SaveChanges()

                If WithPO Then
                    'Ubah ISFillOTR nya di applikasi
                    Dim procCustDetailIDList = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = ProspectCustomer_ID).Select(Function(x) x.ProspectCustomerDetail_ID).ToArray
                    Dim appIDLst = db.V_ProspectCustDetails.Where(Function(x) procCustDetailIDList.Contains(x.ProspectCustomerDetail_ID) And x.Application_ID IsNot Nothing).Select(Function(x) x.Application_ID).ToArray
                    Dim app = db.Tr_Applications.Where(Function(x) x.IsDeleted = False And appIDLst.Contains(x.Application_ID)).ToList
                    db.SaveChanges()
                    Dim cal As New CalculateController
                    For Each i In app
                        Dim vProcDet = db.V_ProspectCustDetails.Where(Function(x) x.Application_ID = i.Application_ID).FirstOrDefault
                        Dim OTR_Price As Decimal? = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And
                                                               x.ProspectCustomerDetail_ID = vProcDet.ProspectCustomerDetail_ID).
                                                               Max(Function(x) x.Tr_ApplicationPODetails.Where(Function(z) z.IsDeleted = False And z.IsChecked = True).
                                                               Max(Function(y) y.OTR_Price))
                        Dim Discount As Decimal? = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And
                                                               x.ProspectCustomerDetail_ID = vProcDet.ProspectCustomerDetail_ID).
                                                               Max(Function(x) x.Tr_ApplicationPODetails.Where(Function(z) z.IsDeleted = False And z.IsChecked = True).
                                                               Max(Function(y) y.Discount))
                        Dim CostPrice = OTR_Price - Discount
                        i.Update_OTR = OTR_Price
                        i.Update_Diskon = Discount
                        i.Cost_Price = CostPrice
                        i.Replacement = i.Replacement_Percent * CostPrice / 100
                        If Not vProcDet.IsVehicleExists Then

                            i.STNK = OTR_Price * i.STNK_Percent / 100
                            i.Assurance = (OTR_Price + i.Modification) * vProcDet.Lease_long / 12 * ((i.Assurance_Percent * Math.Pow(0.955, vProcDet.Lease_long / 12)) / 100)
                            i.Maintenance = i.Maintenance_Percent * CostPrice / 100
                        End If
                        i.Overhead = CostPrice * i.Overhead_Percent / 100
                        i.Lease_Profit = (i.Lease_Profit_Percent * CostPrice * vProcDet.Lease_long) / 12 / 100
                        i.Up_Front_Fee = (i.Up_Front_Fee_Percent * CostPrice * vProcDet.Lease_long) / 100
                        i.Funding_Interest = (i.Funding_Interest_Percent * CostPrice) / 100 * (vProcDet.Lease_long / 12)


                        Dim Replacement = i.Replacement, Maintenance = i.Maintenance, STNK = i.STNK, Overhead = i.Overhead, GPS_Cost = i.GPS_Cost, GPS_CostPerMonth = i.GPS_CostPerMonth,
                        Lease_long = vProcDet.Lease_long, Assurance = i.Assurance + i.AssuranceExtra, Depresiasi = i.Depresiasi, Expedition_Cost = i.Expedition_Cost, Modification = i.Modification,
                        Funding_Interest = i.Funding_Interest, Other = i.Other, Lease_Profit = i.Lease_Profit
                        i.Bid_PricePerMonth = cal.CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, Lease_long, Assurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)

                        Dim Expedition_Status = i.Expedition_Status, PayMonth = i.PayMonth, Up_Front_Fee = i.Up_Front_Fee, Bid_PricePerMonth = i.Bid_PricePerMonth,
                            Residual_Value = i.Residual_Value, Payment_Condition = i.Payment_Condition, Term_Of_Payment = i.Term_Of_Payment, Agent_Fee = i.Agent_Fee, Keur = i.Keur,
                            Agent_FeePerMonth = i.Agent_FeePerMonth, Funding_Rate = i.Funding_Rate, IRR = i.IRR, Profit = i.Profit

                        cal.CalIRR(Expedition_Status, PayMonth, CostPrice, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, Assurance, Bid_PricePerMonth,
                               Residual_Value, vProcDet.Lease_long, Expedition_Cost, vProcDet.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                               GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRR, Profit)
                        i.IRR = IRR
                        i.Profit = Profit
                        i.IsFillOTR = True
                        i.FillOTRBy = user
                        db.SaveChanges()


                        'samain di FillOTR
                        Dim AssuranceCashFlow = (i.Assurance + i.AssuranceExtra) / (vProcDet.Lease_long / 12)
                        Dim Application_ID = i.Application_ID
                        'Dim appCaseFlow = db.Tr_ApplicationCashFlows.Where(Function(x) x.Application_ID = i.Application_ID And x.IsDeleted = False).ToList
                        'For Each p In appCaseFlow
                        '    p.IsDeleted = True
                        '    p.ModifiedBy = user
                        '    p.ModifiedDate = DateTime.Now
                        'Next
                        'db.SaveChanges()

                        Dim message = db.sp_SaveCashFlow(False, Application_ID, user, Expedition_Status, PayMonth, CostPrice, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                                         Bid_PricePerMonth, Residual_Value, vProcDet.Lease_long, Expedition_Cost, vProcDet.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                                         GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                        If message.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                            Throw New System.Exception(message.Select(Function(x) x.Message).FirstOrDefault)
                        End If
                        'cal.SaveCashFlow(False, Application_ID, user, Expedition_Status, PayMonth, CostPrice, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                        '                 Bid_PricePerMonth, Residual_Value, vProcDet.Lease_long, Expedition_Cost, vProcDet.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                        '                 GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate)
                        ''samain Qty, kalo Qty sama maka dia bisa buat Application Header
                        'Dim CountApp = db.Tr_Applications.Where(Function(x) x.Approval_ID = i.Approval_ID And x.IsFillOTR = True And x.IsDeleted = False).Count
                        'Dim CountQuotDetail = db.Tr_QuotationDetails.Where(Function(x) x.Quotation_ID = approval.Quotation_ID And x.IsDeleted = False).Count

                        'If CountApp + 1 = CountQuotDetail Then
                        '    approval.IsApplicationHeader = CType(True, Boolean)
                        'End If

                        db.SaveChanges()
                    Next
                End If


                'update Application
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            End Try
        End Sub
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(appPO As Tr_ApprovalPO) As ActionResult
            If ModelState.IsValid Then
                Me.db.Database.CommandTimeout = 0
                Using dbs = db.Database.BeginTransaction()
                    Try
                        Dim user As String
                        If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                        Dim level = Session("Level_ID_ApplicationPO")
                        'calculasi nga bisa di edit

                        Dim Cost_Price = db.Tr_ApplicationPODetails.Where(Function(x) x.IsDeleted = False And x.Tr_ApplicationPOs.ProspectCustomer_ID = appPO.ProspectCustomer_ID And x.IsChecked = True).Max(Function(x) x.OTR_Price)
                        Dim Query = db.Tr_ApprovalPOs.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = appPO.ProspectCustomer_ID).FirstOrDefault()
                        If level = 1 Then
                            Query.MakerDate = DateTime.Now
                            Query.MakerBy = user
                            Query.MakerRemark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 2 Then
                            Query.CheckerDate = DateTime.Now
                            Query.CheckerBy = user
                            Query.CheckerRemark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 3 Then
                            If Cost_Price <= Session("Limited_Approval_ApplicationPO") Then
                                Query.Status = "Finish"
                                ApproveFinish(db, appPO.ProspectCustomer_ID, user, True)
                            End If
                            Query.Approval1Date = DateTime.Now
                            Query.Approval1By = user
                            Query.Approval1Remark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 4 Then
                            If Cost_Price <= Session("Limited_Approval_ApplicationPO") Then
                                Query.Status = "Finish"
                                ApproveFinish(db, appPO.ProspectCustomer_ID, user, True)
                            End If
                            Query.Approval2Date = DateTime.Now
                            Query.Approval2By = user
                            Query.Approval2Remark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 5 Then
                            If Cost_Price <= Session("Limited_Approval_ApplicationPO") Then
                                Query.Status = "Finish"
                                ApproveFinish(db, appPO.ProspectCustomer_ID, user, True)
                            End If
                            Query.Approval3Date = DateTime.Now
                            Query.Approval3By = user
                            Query.Approval3Remark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 6 Then
                            If Cost_Price <= Session("Limited_Approval_ApplicationPO") Then
                                Query.Status = "Finish"
                                ApproveFinish(db, appPO.ProspectCustomer_ID, user, True)
                            End If
                            Query.Approval4Date = DateTime.Now
                            Query.Approval4By = user
                            Query.Approval4Remark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 7 Then
                            If Cost_Price <= Session("Limited_Approval_ApplicationPO") Then
                                Query.Status = "Finish"
                                ApproveFinish(db, appPO.ProspectCustomer_ID, user, True)
                            End If
                            Query.Approval5Date = DateTime.Now
                            Query.Approval5By = user
                            Query.Approval5Remark = appPO.RemarkNotApprove
                            Query.StatusRecord = level
                            Query.Status = "Finish"
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        End If
                        db.SaveChanges()
                        dbs.Commit()
                        Return RedirectToAction("Index")
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError(String.Empty, ex.Message)
                    End Try
                End Using
            End If

            For Each i In appPO.Detail
                i.Detail = (From AA In db.Tr_ApplicationPODetails
                            Where AA.ApplicationPO_ID = i.ApplicationPO_ID
                            Select New Tr_ApplicationPODetail With {.Dealer = AA.Ms_Dealers.Dealer_Name, .OTR_Price = AA.OTR_Price, .Discount = AA.Discount, .Status = AA.Status,
                               .IsChecked = AA.IsChecked}).ToList
            Next

            Return View(appPO)
        End Function

        ' GET: ApprovalPO/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApprovalPOs As Tr_ApprovalPOs = Await db.Tr_ApprovalPOs.FindAsync(id)
            If IsNothing(tr_ApprovalPOs) Then
                Return HttpNotFound()
            End If
            Return View(tr_ApprovalPOs)
        End Function

        ' POST: ApprovalPO/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_ApprovalPOs As Tr_ApprovalPOs = Await db.Tr_ApprovalPOs.FindAsync(id)
            db.Tr_ApprovalPOs.Remove(tr_ApprovalPOs)
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
