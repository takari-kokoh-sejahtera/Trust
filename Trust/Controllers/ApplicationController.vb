Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Trust
Imports PagedList
Imports Newtonsoft.Json.Linq
Imports System.IO

Namespace Controllers
    Public Class ApplicationController
        Inherits System.Web.Mvc.Controller


        Private db As New TrustEntities

        ReadOnly myRecord_For_Payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Good",
                    .Value = "Good"
                },
                New SelectListItem With {
                    .Text = "Fair",
                    .Value = "Fair"
                },
                New SelectListItem With {
                    .Text = "Poor",
                    .Value = "Poor"
                }
            }
        ' GET: Application
        Async Function Index() As Task(Of ActionResult)
            Dim tr_Applications = db.Tr_Applications.Include(Function(t) t.Ms_Citys).Include(Function(t) t.Ms_Citys1).Include(Function(t) t.Tr_QuotationDetails)
            Return View(Await tr_Applications.ToListAsync())
        End Function

        Function IndexPOFromCustomer(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            Dim LevelGroup_ID As Integer? = Session("LevelGroup_ID")
            'Dim application = db.sp_POFromCustomerList(Session("ID"))
            Dim Quotation = (From A In db.Tr_Quotations
                             Join B In db.V_ProspectCusts On A.Quotation_ID Equals B.Quotation_ID
                             Where A.IsPO = False And A.IsDeleted = False And A.IsApplication = True
                             Select A.Quotation_ID, A.No_Ref, B.CompanyGroup_Name, B.Company_Name, CreatedBy = A.Cn_Users.User_Name, CreatedDate = A.CreatedDate, ModifiedBy = A.Cn_Users1.User_Name, ModifiedDate = A.ModifiedDate).
            Select(Function(x) New Tr_QuotationPO With {.Quotation_ID = x.Quotation_ID, .No_Ref = x.No_Ref, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate,
            .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate})

            If Not String.IsNullOrEmpty(searchString) Then
                Quotation = Quotation.Where(Function(s) s.No_Ref.Contains(searchString) OrElse s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "No_Ref"
                    Quotation = Quotation.OrderBy(Function(s) s.No_Ref)
                Case "CompanyGroup_Name"
                    Quotation = Quotation.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Quotation = Quotation.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Quotation = Quotation.OrderByDescending(Function(s) s.CreatedDate)
            End Select

            Dim pageNumber As Integer = If(page, 1)
            Return View(Quotation.ToPagedList(pageNumber, pageSize))
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function FileUpload(file As HttpPostedFileBase, file1 As HttpPostedFileBase, model As Tr_QuotationPO, detail As IEnumerable(Of Tr_QuotationDetailnya)) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim message As String = ""
            If file Is Nothing Then
                message = "Must fill PDF"
            End If
            If file1 Is Nothing Then
                message = "Must fill PDF"
            End If
            If ModelState.IsValid And file IsNot Nothing Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        'Dim pic As String = System.IO.Path.GetFileName(file.FileName)
                        Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/POFromCustomer"), model.Quotation_ID.ToString() + ".pdf")
                        Dim path1 As String = System.IO.Path.Combine(Server.MapPath("~/Image/POFromCustomer/IM-OtherFile"), model.Quotation_ID.ToString() + ".pdf")
                        Dim quot = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = model.Quotation_ID).FirstOrDefault
                        If Not quot Is Nothing Then
                            quot.THU = model.THU
                            quot.Record_For_Payment = model.Record_For_Payment
                            quot.IsPO = True
                            quot.POBy = user
                            For Each i In detail
                                Dim app = db.Tr_Applications.Where(Function(x) x.IsDeleted = False And x.Application_ID = i.Application_ID).FirstOrDefault
                                app.Color = i.Color
                                app.ModifiedDate = DateTime.Now
                                app.ModifiedBy = user
                            Next
                            Dim Pros = db.V_ProspectCusts.Where(Function(x) x.Quotation_ID = model.Quotation_ID).FirstOrDefault
                            If Not Pros.IsExists Then
                                Dim customer As New Ms_Customers
                                customer.CompanyGroup_ID = Pros.CompanyGroup_ID
                                customer.Company_Name = Pros.Company_Name
                                customer.PT = Pros.PT
                                customer.Tbk = Pros.Tbk
                                customer.Address = Pros.Address
                                customer.City_ID = Pros.City_ID
                                customer.Phone = Pros.Phone
                                customer.Email = Pros.Email
                                customer.PIC_Name = Pros.PIC_Name
                                customer.PIC_Phone = Pros.PIC_Phone
                                customer.PIC_Email = Pros.PIC_Email
                                customer.Notes = Pros.Notes
                                customer.IsKYC = False
                                customer.IsDeleted = False
                                customer.CreatedBy = user
                                customer.CreatedDate = DateTime.Now
                                db.Ms_Customers.Add(customer)
                                Dim prospect = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = Pros.ProspectCustomer_ID).FirstOrDefault
                                prospect.CustomerExists_ID = customer.Customer_ID
                                Dim ProsH = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = Pros.ProspectCustomer_ID).FirstOrDefault
                                ProsH.CustomerExists_ID = customer.Customer_ID
                            End If
                            db.SaveChanges()
                            file.SaveAs(path)
                            file1.SaveAs(path1)
                            Using ms As MemoryStream = New MemoryStream()
                                file.InputStream.CopyTo(ms)
                                file1.InputStream.CopyTo(ms)
                                Dim array As Byte() = ms.GetBuffer()
                            End Using
                            'Session("Pic") = pic
                            dbs.Commit()
                            Return RedirectToAction("IndexPOFromCustomer", "Application")
                        Else
                            message = "Quotation is not found"
                        End If
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("File", ex.Message)
                    End Try
                End Using
            End If
            ModelState.AddModelError("File", message)
            model.Detail = detail
            ViewBag.Record_For_Payment = New SelectList(myRecord_For_Payment, "Value", "Text")
            Return View("POFromCustomer", model)

        End Function


        Function POFromCustomer(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim LevelGroup_ID As Integer? = Session("LevelGroup_ID")
            Dim Quotation = (From A In db.Tr_Quotations
                             Join B In db.V_ProspectCusts On A.Quotation_ID Equals B.Quotation_ID
                             Where A.IsPO = False And A.IsDeleted = False And A.Quotation_ID = id
                             Select A.Quotation_ID, A.No_Ref, B.CompanyGroup_Name, B.Company_Name, B.ProspectCustomer_ID).
            Select(Function(x) New Tr_QuotationPO With {.Quotation_ID = x.Quotation_ID, .No_Ref = x.No_Ref, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .ProspectCustomer_ID = x.ProspectCustomer_ID}).FirstOrDefault

            If IsNothing(Quotation) Then
                Return HttpNotFound()
            End If
            Dim detail = (From A In db.Tr_Applications.Where(Function(x) x.IsDeleted = False)
                          Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                          Where B.ProspectCustomer_ID = Quotation.ProspectCustomer_ID
                          Select A.Application_ID, B.Vehicle, B.IsVehicleExists, Color = If(B.IsVehicleExists, B.Color, ""), B.Lease_price, B.Qty, B.Amount, B.Bid_PricePerMonth).
                          Select(Function(x) New Tr_QuotationDetailnya With {.Application_ID = x.Application_ID, .Vehicle = x.Vehicle, .IsVehicleExists = x.IsVehicleExists, .Color = x.Color, .Lease_price = x.Lease_price, .Qty = x.Qty, .Amount = x.Amount, .Bid_Price = x.Bid_PricePerMonth}).ToList
            Quotation.Detail = detail
            ViewBag.Record_For_Payment = New SelectList(myRecord_For_Payment, "Value", "Text")

            Return View(Quotation)
        End Function
        ' GET: Application/Details/5

        Function IndexOTR(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            'Dim application = db.sp_FillOTRList(Session("ID"))
            Dim LevelGroup_ID As Integer? = Session("LevelGroup_ID")
            'Dim application = db.sp_POFromCustomerList(Session("ID"))
            Dim application = (From A In db.Tr_Applications
                               Join B In db.V_ProspectCustDetails On A.QuotationDetail_ID Equals B.QuotationDetail_ID
                               Join C In db.Tr_Quotations.Where(Function(x) x.IsDeleted = False) On B.Quotation_ID Equals C.Quotation_ID
                               Where C.IsPO And A.IsDeleted = False And A.IsFillOTR = False
                               Select Approve = False, A.Application_ID, pdf = C.Quotation_ID.ToString + ".pdf", B.CompanyGroup_Name, B.Company_Name,
B.Vehicle, B.Lease_price, B.Qty, B.Amount, B.Bid_PricePerMonth, B.CreatedDateApp).
            Select(Function(x) New Tr_Application With {.Approve = x.Approve, .Application_ID = x.Application_ID, .pdf = x.pdf, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
.Vehicle = x.Vehicle, .Lease_price = x.Lease_price, .Qty = x.Qty, .Amount = x.Lease_price, .Bid_PricePerMonth = x.Bid_PricePerMonth, .CreatedDateApp = x.CreatedDateApp})
            If Not String.IsNullOrEmpty(searchString) Then
                application = application.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    application = application.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    application = application.OrderBy(Function(s) s.Company_Name)
                Case "Vehicle"
                    application = application.OrderBy(Function(s) s.Vehicle)
                Case Else
                    application = application.OrderByDescending(Function(s) s.CreatedDateApp)
            End Select

            For i As Integer = 0 To 4

            Next

            Dim pageNumber As Integer = If(page, 1)
            Return View(application.ToPagedList(pageNumber, pageSize))
        End Function

        Function OTR(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim test = (From A In db.Tr_Applications
                        Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
                        From B In AB.DefaultIfEmpty
                        Where A.Application_ID = id
                        Select B.CompanyGroup_Name, B.Company_Name, B.Vehicle, B.Lease_price, B.Qty, B.Amount, B.Bid_PricePerMonth).FirstOrDefault()

            'Dim tr_Applications = (From A In db.Tr_Applications
            '                       Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
            '                       From B In AB.DefaultIfEmpty
            '                       Where A.Application_ID = id
            '                       Select B.CompanyGroup_Name, B.Company_Name, B.Vehicle, B.Lease_price, B.Qty, B.Amount, B.Bid_PricePerMonth).Select(
            '                       Function(x) New Tr_Application With {.Application_ID = id, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Vehicle = x.Vehicle, .Lease_price = CType(x.Lease_price, Decimal?),
            '                       .Qty = x.Qty, .Amount = CType(x.Amount, Decimal?), .Bid_PricePerMonth = CType(x.Bid_PricePerMonth, Decimal?)}).FirstOrDefault()
            Dim tr_Applications As New Tr_Application
            tr_Applications.Application_ID = id
            tr_Applications.CompanyGroup_Name = test.CompanyGroup_Name
            tr_Applications.Company_Name = test.Company_Name
            tr_Applications.Vehicle = test.Vehicle
            tr_Applications.Lease_price = test.Lease_price
            tr_Applications.Qty = test.Qty
            tr_Applications.Amount = test.Amount
            tr_Applications.Bid_PricePerMonth = test.Bid_PricePerMonth

            If IsNothing(tr_Applications) Then
                Return HttpNotFound()
            End If

            Return View(tr_Applications)
        End Function

        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function OTR(<Bind(Include:="Application_ID,CompanyGroup_Name,Company_Name,Vehicle,Lease_price,Qty,Amount,Bid_PricePerMonth,Application_ID,Harga_OTR,Update_Diskon")> ByVal tr_Applications As Tr_Application) As ActionResult
        '    If ModelState.IsValid Then
        '        Dim application = db.Tr_Applications.Where(Function(x) x.Application_ID = tr_Applications.Application_ID)

        '        Return RedirectToAction("Index")
        '    End If
        '    Return View(tr_Applications)
        'End Function

        Public Function EditData(Application_ID As Integer, Rent_Location_ID As Integer, Plat_Location As Integer, PayMonth As Integer, Payment_Condition As String, Term_Of_Payment As Integer, Modification As Double, GPS_Cost As Double, GPS_CostPerMonth As Integer?, Agent_Fee As Double, Agent_FeePerMonth As Integer?, Update_OTR As Double, Residual_Value As Double?, Residual_ValuePercent As Decimal, Expedition_Status As String, Expedition_Cost As Double, Keur As Double, Update_Diskon As Double, Cost_Price As Double, Up_Front_Fee As Double, Up_Front_Fee_Percent As Decimal, Other As Double, Efektif_Date As Date?, Expec_Delivery_Date As Date?, Replacement_Percent As Decimal, Replacement As Double, Maintenance_Percent As Decimal, Maintenance As Double, STNK_Percent As Decimal, STNK As Double, Overhead_Percent As Decimal, Overhead As Double, Assurance_Percent As Decimal, Assurance As Double, Depresiasi_Percent As Decimal, Depresiasi As Double, Funding_Interest_Percent As Decimal, Funding_Interest As Double, Lease_Profit_Percent As Decimal, Lease_Profit As Double, Bid_PricePerMonth As Double, Premium As Decimal?, OJK As Decimal, SwapRate As Decimal, Project_Rating As String, IRR As Decimal, Funding_Rate As Decimal, Spread As Decimal, Profit As Decimal) As ActionResult
            Dim result As String = "Error"
            Dim Validate As Boolean = True
            If Payment_Condition = "" Or Application_ID = 0 Or Rent_Location_ID = 0 Or Plat_Location = 0 Or Efektif_Date Is Nothing Or Expec_Delivery_Date Is Nothing Or Bid_PricePerMonth = 0 Then
                Validate = False
            End If
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If Validate Then
                Using dbs = db.Database.BeginTransaction()
                    Try
                        Dim application = db.Tr_Applications.Where(Function(x) x.Application_ID = Application_ID).FirstOrDefault()
                        application.Rent_Location_ID = Rent_Location_ID
                        application.Plat_Location = Plat_Location
                        application.Modification = Modification
                        application.PayMonth = PayMonth
                        application.Payment_Condition = Payment_Condition
                        application.Term_Of_Payment = Term_Of_Payment
                        application.GPS_Cost = GPS_Cost
                        application.GPS_CostPerMonth = GPS_CostPerMonth
                        application.Agent_Fee = Agent_Fee
                        application.Agent_FeePerMonth = Agent_FeePerMonth
                        application.Update_OTR = Update_OTR
                        application.Residual_Value = Residual_Value
                        application.Residual_ValuePercent = Residual_ValuePercent
                        application.Expedition_Status = Expedition_Status
                        application.Expedition_Cost = Expedition_Cost
                        application.Keur = Keur
                        application.Update_Diskon = Update_Diskon
                        application.Cost_Price = Cost_Price
                        application.Up_Front_Fee = Up_Front_Fee
                        application.Up_Front_Fee_Percent = Up_Front_Fee_Percent
                        application.Other = Other
                        application.Efektif_Date = Efektif_Date
                        application.Expec_Delivery_Date = Expec_Delivery_Date
                        application.Replacement_Percent = Replacement_Percent
                        application.Replacement = Replacement
                        application.Maintenance_Percent = Maintenance_Percent
                        application.Maintenance = Maintenance
                        application.STNK_Percent = STNK_Percent
                        application.STNK = STNK
                        application.Overhead_Percent = Overhead_Percent
                        application.Overhead = Overhead
                        application.Assurance_Percent = Assurance_Percent
                        application.Assurance = Assurance
                        application.Lease_Profit_Percent = Lease_Profit_Percent
                        application.Lease_Profit = Lease_Profit
                        application.Depresiasi_Percent = Depresiasi_Percent
                        application.Depresiasi = Depresiasi
                        application.Funding_Interest_Percent = Funding_Interest_Percent
                        application.Funding_Interest = Funding_Interest
                        application.Bid_PricePerMonth = Bid_PricePerMonth
                        application.Premium = Premium
                        application.OJK = OJK
                        application.SwapRate = SwapRate
                        application.Project_Rating = Project_Rating
                        application.IRR = IRR
                        application.Spread = Spread
                        application.Profit = Profit
                        application.Funding_Rate = Funding_Rate
                        application.ModifiedBy = user
                        application.ModifiedDate = DateTime.Now
                        application.IsFillOTR = True
                        application.FillOTRBy = user

                        'cashFlow
                        Dim calculateControl = New CalculateController
                        Dim prospDetail = db.V_ProspectCustDetails.Where(Function(x) x.Application_ID = Application_ID).FirstOrDefault
                        Dim AssuranceCashFlow = Assurance / (prospDetail.Lease_long / 12)
                        'calculateControl.SaveCashFlow(False, Application_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Bid_PricePerMonth, Residual_Value, prospDetail.Lease_long, Expedition_Cost, prospDetail.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate)
                        Dim message = db.sp_SaveCashFlow(False, Application_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Bid_PricePerMonth, Residual_Value, prospDetail.Lease_long, Expedition_Cost, prospDetail.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                        If message.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                            Throw New System.Exception(message.Select(Function(x) x.Message).FirstOrDefault)
                        End If
                        'samain Qty, kalo Qty sama maka dia bisa buat Application Header
                        Dim CountApp = db.Tr_Applications.Where(Function(x) x.Approval_ID = application.Approval_ID And x.IsFillOTR = True And x.IsDeleted = False).Count
                        Dim approval = db.Tr_Approvals.Where(Function(x) x.Approval_ID = application.Approval_ID And x.IsDeleted = False).FirstOrDefault
                        Dim CountQuotDetail = db.Tr_QuotationDetails.Where(Function(x) x.Quotation_ID = approval.Quotation_ID And x.IsDeleted = False).Count

                        If CountApp + 1 = CountQuotDetail Then
                            approval.IsApplicationHeader = CType(True, Boolean)
                        End If

                        db.SaveChanges()
                        result = "Success"
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                    End Try
                End Using
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Calculate/Edit/5
        Function EditOTR(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Application As Tr_Applications = db.Tr_Applications.Find(id)
            If IsNothing(tr_Application) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_Applications
                         Where A.IsDeleted = False And A.Application_ID = id
                         Group Join B In db.V_ProspectCustDetails On A.QuotationDetail_ID Equals B.QuotationDetail_ID Into Group
                         From B In Group.DefaultIfEmpty()
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                         From D In DA.DefaultIfEmpty()
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                         From E In EA.DefaultIfEmpty()
                         Select B.Transaction_Type, A.Residual_ValuePercent, A.Expedition_Cost, A.Keur, A.Residual_Value, A.Agent_FeePerMonth, A.GPS_CostPerMonth, A.Payment_Condition, A.Application_ID, B.Year, B.Lease_price, B.Lease_long, B.Qty, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Cost_Price, A.Up_Front_Fee, A.Up_Front_Fee_Percent, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Replacement, A.Maintenance_Percent, A.Maintenance,
                            A.STNK_Percent, A.STNK, A.Overhead_Percent, A.Overhead, A.Assurance_Percent, A.Assurance, A.Lease_Profit_Percent, A.Lease_Profit, A.Depresiasi_Percent, A.Depresiasi, A.Funding_Interest_Percent, A.Funding_Interest, A.Bid_PricePerMonth,
                            A.IRR, A.Funding_Rate, A.Spread, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.Term_Of_Payment, B.Type, A.PayMonth, A.Expedition_Status, A.Profit, A.Premium, A.OJK, A.SwapRate, A.Project_Rating).
                            Select(Function(x) New Tr_ApplicationOTR With {.Transaction_Type = x.Transaction_Type, .Calculate_ID = x.Application_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .Year = x.Year, .Lease_price = x.Lease_price, .Lease_long = x.Lease_long, .Qty = x.Qty,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Payment_Condition = x.Payment_Condition, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost, .GPS_CostPerMonth = x.GPS_CostPerMonth,
            .Agent_Fee = x.Agent_Fee, .Agent_FeePerMonth = x.Agent_FeePerMonth, .Update_OTR = x.Update_OTR, .Residual_Value = x.Residual_Value, .Residual_ValuePercent = x.Residual_ValuePercent, .Expedition_Cost = x.Expedition_Cost, .Keur = x.Keur, .Update_Diskon = x.Update_Diskon, .Cost_Price = x.Cost_Price, .Up_Front_Fee = x.Up_Front_Fee, .Up_Front_Fee_Percent = x.Up_Front_Fee_Percent, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent, .Replacement = x.Replacement,
            .Maintenance_Percent = x.Maintenance_Percent, .Maintenance = x.Maintenance, .STNK_Percent = x.STNK_Percent, .STNK = x.STNK, .Overhead_Percent = x.Overhead_Percent, .Overhead = x.Overhead,
            .Assurance_Percent = x.Assurance_Percent, .Assurance = x.Assurance, .Lease_Profit_Percent = x.Lease_Profit_Percent, .Lease_Profit = x.Lease_Profit, .Depresiasi_Percent = x.Depresiasi_Percent, .Depresiasi = x.Depresiasi, .Funding_Interest_Percent = x.Funding_Interest_Percent, .Funding_Interest = x.Funding_Interest,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .IRR = x.IRR, .Funding_Rate = x.Funding_Rate, .Spread = x.Spread, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
            .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy, .Term_Of_Payment = x.Term_Of_Payment, .Type = x.Type, .PayMonth = x.PayMonth, .Expedition_Status = x.Expedition_Status,
            .Profit = x.Profit, .Premium = x.Premium, .OJK = x.OJK, .SwapRate = x.SwapRate, .Project_Rating = x.Project_Rating
            }).FirstOrDefault()
            'ViewBag.FixCost_ID = New SelectList(db.Ms_FixCosts, "FixCost_ID", "FixCost_Name", Query.FixCost_ID)
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City", Query.Rent_Location_ID)
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City", Query.Plat_Location)
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            ViewBag.Term_Of_Payment = New SelectList(month, "Value", "Text", Query.Term_Of_Payment)
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text", Query.GPS_CostPerMonth)
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text", Query.Agent_FeePerMonth)
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                },
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                }
            }
            Dim MyPayMonth As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Nothing",
                    .Value = 0
                },
                New SelectListItem With {
                    .Text = "First Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "Second Month",
                    .Value = 2
                },
                New SelectListItem With {
                    .Text = "Third Month",
                    .Value = 3
                }
            }
            Dim expedisiStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "One Way",
                    .Value = "One Way"
                },
                New SelectListItem With {
                    .Text = "Return",
                    .Value = "Return"
                }
            }
            ViewBag.Expedition_Status = New SelectList(expedisiStatus, "Value", "Text", Query.Expedition_Status)
            ViewBag.PayMonth = New SelectList(MyPayMonth, "Value", "Text", Query.PayMonth)

            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text", Query.Payment_Condition)
            Return View(Query)
        End Function




        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Applications As Tr_Applications = Await db.Tr_Applications.FindAsync(id)
            If IsNothing(tr_Applications) Then
                Return HttpNotFound()
            End If
            Return View(tr_Applications)
        End Function
        ' GET: Application/Create
        Function Create() As ActionResult
            ViewBag.Plat_Location = New SelectList(db.Ms_Citys, "CIty_ID", "City")
            ViewBag.Rent_Location_ID = New SelectList(db.Ms_Citys, "CIty_ID", "City")
            ViewBag.ProspectCustomerDetail_ID = New SelectList(db.Tr_ProspectCustDetails, "ProspectCustomerDetail_ID", "Transaction_Type")
            Return View()
        End Function

        ' POST: Application/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Application_ID,POFromCustomer,ProspectCustomerDetail_ID,Rent_Location_ID,Plat_Location,Payment_Condition,Modification,GPS_Cost,GPS_CostPerMonth,Agent_Fee,Agent_FeePerMonth,Update_OTR,Residual_Value,Residual_ValuePercent,Expedition_Cost,Keur,Update_Diskon,Cost_Price,Up_Front_Fee,Up_Front_Fee_Percent,Other,Efektif_Date,Replacement_Percent,Replacement,Maintenance_Percent,Maintenance,STNK_Percent,STNK,Overhead_Percent,Overhead,Assurance_Percent,Assurance,Lease_Profit,Lease_Profit_Percent,Depresiasi,Depresiasi_Percent,Funding_Interest,Funding_Interest_Percent,Bid_PricePerMonth,IRR,Funding_Rate,Spread,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Applications As Tr_Applications) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Tr_Applications.Add(tr_Applications)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.Plat_Location = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Plat_Location)
            ViewBag.Rent_Location_ID = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Rent_Location_ID)
            ViewBag.QuotationDetail_ID = New SelectList(db.Tr_QuotationDetails, "QuotationDetail_ID", "QuotationDetail_ID", tr_Applications.QuotationDetail_ID)
            Return View(tr_Applications)
        End Function

        '' GET: Application/Edit/5
        'Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim tr_Applications As Tr_Applications = Await db.Tr_Applications.FindAsync(id)
        '    If IsNothing(tr_Applications) Then
        '        Return HttpNotFound()
        '    End If
        '    ViewBag.Plat_Location = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Plat_Location)
        '    ViewBag.Rent_Location_ID = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Rent_Location_ID)
        '    ViewBag.QuotationDetail_ID = New SelectList(db.Tr_QuotationDetails, "QuotationDetail_ID", "QuotationDetail_ID", tr_Applications.QuotationDetail_ID)
        '    Return View(tr_Applications)
        'End Function

        '' POST: Application/Edit/5
        ''To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ''more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Async Function Edit(<Bind(Include:="Application_ID,POFromCustomer,ProspectCustomerDetail_ID,Rent_Location_ID,Plat_Location,Payment_Condition,Modification,GPS_Cost,GPS_CostPerMonth,Agent_Fee,Agent_FeePerMonth,Update_OTR,Residual_Value,Residual_ValuePercent,Expedition_Cost,Keur,Update_Diskon,Cost_Price,Up_Front_Fee,Up_Front_Fee_Percent,Other,Efektif_Date,Replacement_Percent,Replacement,Maintenance_Percent,Maintenance,STNK_Percent,STNK,Overhead_Percent,Overhead,Assurance_Percent,Assurance,Lease_Profit,Lease_Profit_Percent,Depresiasi,Depresiasi_Percent,Funding_Interest,Funding_Interest_Percent,Bid_PricePerMonth,IRR,Funding_Rate,Spread,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Applications As Tr_Applications) As Task(Of ActionResult)
        '    If ModelState.IsValid Then
        '        db.Entry(tr_Applications).State = EntityState.Modified
        '        Await db.SaveChangesAsync()
        '        Return RedirectToAction("Index")
        '    End If
        '    ViewBag.Plat_Location = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Plat_Location)
        '    ViewBag.Rent_Location_ID = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Applications.Rent_Location_ID)
        '    ViewBag.QuotationDetail_ID = New SelectList(db.Tr_QuotationDetails, "QuotationDetail_ID", "QuotationDetail_ID", tr_Applications.QuotationDetail_ID)
        '    Return View(tr_Applications)
        'End Function

        ' GET: Application/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Applications As Tr_Applications = Await db.Tr_Applications.FindAsync(id)
            If IsNothing(tr_Applications) Then
                Return HttpNotFound()
            End If
            Return View(tr_Applications)
        End Function

        ' POST: Application/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_Applications As Tr_Applications = Await db.Tr_Applications.FindAsync(id)
            db.Tr_Applications.Remove(tr_Applications)
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
