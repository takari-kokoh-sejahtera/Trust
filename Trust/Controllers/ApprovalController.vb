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

Namespace Controllers
    Public Class ApprovalController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
#Region "Java"
        Public Function NotApprove(ByVal Approval_ID As Integer?, ByVal val As String) As ActionResult
            If val <> "" Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level = Session("Level_ID_Quotation")
                Dim Query = db.Tr_Approvals.Where(Function(x) x.Approval_ID = Approval_ID).FirstOrDefault()
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
                Dim quotation = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = Query.Quotation_ID).FirstOrDefault
                quotation.IsNotApproved = True
                quotation.IsApplication = False
                quotation.RemarkNotApproved = val
                quotation.ModifiedDate = DateTime.Now
                quotation.ModifiedBy = user
                'Dim prospec = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = quotation.ProspectCustomer_ID).FirstOrDefault()
                'prospec.IsQuotation = False
                'prospec.ModifiedBy = user
                'prospec.ModifiedDate = DateTime.Now

                db.SaveChanges()
                Return Json(New With {Key .success = "true"})
            End If
            Return Json(New With {Key .success = "false", .error = "Please fill remark"})
        End Function

#End Region

        ' GET: Approval
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
            Dim V_app = db.V_Approval.Where(Function(x) x.User_ID = user And x.Module_ID = 19).FirstOrDefault

            Dim Level_ID = If(V_app Is Nothing, 0, V_app.Level_ID)
            Dim Level_IDNotApp() = {1, 2}
            Dim Limited_Approval = If(V_app Is Nothing, 0, V_app.Limited_Approval)

            'Dim tr_Approval = db.Tr_Approvals.Where(Function(x) x.IsDeleted = False).
            'Select(Function(x) New Tr_Approval With {.Approve = If(Level_IDNotApp.Contains(Level_ID) And Limited_Approval >= x.Cost_Price)})


            Dim tr_Approval = From A In db.Tr_Approvals
                              Group Join B In db.V_ProspectCusts On A.Tr_Quotations.ProspectCustomer_ID Equals B.ProspectCustomer_ID Into BA = Group
                              From B In BA.DefaultIfEmpty()
                              Where A.IsDeleted = False And A.Tr_Quotations.IsDeleted = False
                              Select New Tr_Approval With {.Approve = If(((Level_IDNotApp.Contains(Level_ID) And Limited_Approval >= B.Cost_Price) Or (Not Level_IDNotApp.Contains(Level_ID))) And Level_ID - 1 >= A.StatusRecord And A.Status = "Open", True, False),
                                  .No_Ref = B.No_Ref, .Company_Name = B.PT + " " + B.Company_Name, .Approval_ID = A.Approval_ID, .Quotation_ID = A.Quotation_ID, .MakerDate = A.MakerDate, .MakerBy = A.Cn_Users7.User_Name, .MakerRemark = A.MakerRemark,
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

        ' GET: Approval/Create
        Public Sub CreateApplication(dbnya As TrustEntities, Approval_ID As Integer, user As String, Quotation_ID As Integer)

            'Create Detail
            Dim Query = (From A In dbnya.Tr_Approvals
                         Group Join B In dbnya.Tr_QuotationDetails On A.Quotation_ID Equals B.Quotation_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Where A.IsDeleted = False And B.IsDeleted = False And A.Approval_ID = Approval_ID).ToList

            For Each item In Query
                Dim application As New Tr_Applications
                application.Approval_ID = Approval_ID
                application.QuotationDetail_ID = item.B.QuotationDetail_ID
                'Ambil nilai Calculation
                Dim calculate = dbnya.Tr_Calculates.Where(Function(x) x.Calculate_ID = item.B.Calculate_ID).FirstOrDefault()
                application.Rent_Location_ID = calculate.Rent_Location_ID
                application.Plat_Location = calculate.Plat_Location
                application.Term_Of_Payment = calculate.Term_Of_Payment
                application.PayMonth = calculate.PayMonth
                application.Payment_Condition = calculate.Payment_Condition
                application.Modification = calculate.Modification
                application.GPS_Cost = calculate.GPS_Cost
                application.GPS_CostPerMonth = calculate.GPS_CostPerMonth
                application.Agent_Fee = calculate.Agent_Fee
                application.Agent_FeePerMonth = calculate.Agent_FeePerMonth
                application.Update_OTR = calculate.Update_OTR
                application.Residual_Value = calculate.Residual_Value
                application.Residual_ValuePercent = calculate.Residual_ValuePercent
                application.Expedition_Status = calculate.Expedition_Status
                application.Expedition_Cost = calculate.Expedition_Cost
                application.Keur = calculate.Keur
                application.Update_Diskon = calculate.Update_Diskon
                application.Update_DiskonSystem = calculate.Update_DiskonSystem
                application.Update_DiskonTick = calculate.Update_DiskonTick
                application.Cost_Price = calculate.Cost_Price
                application.Up_Front_Fee = calculate.Up_Front_Fee
                application.Up_Front_Fee_Percent = calculate.Up_Front_Fee_Percent
                application.Other = calculate.Other
                application.Efektif_Date = calculate.Efektif_Date
                application.Replacement_Percent = calculate.Replacement_Percent
                application.Replacement = calculate.Replacement
                application.Replacement_Percent_Before = calculate.Replacement_Percent_Before
                application.Replacement_Tick = calculate.Replacement_Tick
                application.Maintenance_Percent = calculate.Maintenance_Percent
                application.Maintenance = calculate.Maintenance
                application.Maintenance_Percent_Before = calculate.Maintenance_Percent_Before
                application.Maintenance_Tick = calculate.Maintenance_Tick
                application.STNK_Percent = calculate.STNK_Percent
                application.STNK = calculate.STNK
                application.STNK_Percent_Before = calculate.STNK_Percent_Before
                application.STNK_Tick = calculate.STNK_Tick
                application.Overhead_Percent = calculate.Overhead_Percent
                application.Overhead = calculate.Overhead
                application.Overhead_Percent_Before = calculate.Overhead_Percent_Before
                application.Assurance_Percent = calculate.Assurance_Percent
                application.Assurance = calculate.Assurance
                application.Assurance_Percent_Before = calculate.Assurance_Percent_Before
                application.Assurance_Tick = calculate.Assurance_Tick
                application.AssuranceExtra = calculate.AssuranceExtra
                application.Lease_Profit = calculate.Lease_Profit
                application.Lease_Profit_Percent = calculate.Lease_Profit_Percent
                application.Depresiasi = calculate.Depresiasi
                application.Depresiasi_Percent = calculate.Depresiasi_Percent
                application.Funding_Interest = calculate.Funding_Interest
                application.Funding_Interest_Percent = calculate.Funding_Interest_Percent
                application.Bid_PricePerMonth = calculate.Bid_PricePerMonth
                application.Premium = calculate.Premium
                application.OJK = calculate.OJK
                application.SwapRate = calculate.SwapRate
                application.Project_Rating = calculate.Project_Rating
                application.IRR = calculate.IRR
                application.Funding_Rate = calculate.Funding_Rate
                application.Spread = calculate.Spread
                application.Profit = calculate.Profit
                'application.Remark = calculate.Remark
                application.New_Vehicle_Price = calculate.New_Vehicle_Price
                application.Location_Vehicle_ID = calculate.Location_Vehicle_ID
                application.CreatedDate = DateTime.Now
                application.CreatedBy = user
                application.IsDeleted = False
                application.IsFillOTR = db.V_ProspectCustDetails.Where(Function(x) x.Calculate_ID = item.B.Calculate_ID).Select(Function(x) x.IsVehicleExists).FirstOrDefault

                dbnya.Tr_Applications.Add(application)
                dbnya.SaveChanges()
            Next
            Dim quotation = dbnya.Tr_Quotations.Where(Function(x) x.Quotation_ID = Quotation_ID).FirstOrDefault
            quotation.IsApplication = True
            quotation.ModifiedDate = DateTime.Now
            quotation.ModifiedBy = user
            dbnya.SaveChanges()

        End Sub

        Function Detail(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Approval = (From A In db.Tr_Approvals
                               Group Join B In db.Tr_Quotations On A.Quotation_ID Equals B.Quotation_ID Into AB = Group
                               From B In AB.DefaultIfEmpty()
                               Group Join C In db.V_ProspectCusts On B.ProspectCustomer_ID Equals C.ProspectCustomer_ID Into CB = Group
                               From C In CB.DefaultIfEmpty()
                               Where A.IsDeleted = False And B.IsDeleted = False And A.Approval_ID = id
                               Select C.IsExists, B.No_Ref, Company_Name = C.PT + " " + C.Company_Name, A.Approval_ID, A.Quotation_ID, C.CompanyGroup_Name, C.Address,
                                   C.Phone, C.Email, C.PIC_Name, C.PIC_Phone, C.PIC_Email, B.Quotation_Validity, B.ProspectCustomer_ID, B.Remark, B.RemarkInternal).Select(
            Function(x) New Tr_Approval With {.No_Ref = x.No_Ref, .Company_Name = x.Company_Name, .Approval_ID = x.Approval_ID, .Quotation_ID = x.Quotation_ID,
                .CompanyGroup_Name = x.CompanyGroup_Name, .Address = x.Address, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone,
                .PIC_Email = x.PIC_Email, .Quotation_Validity = x.Quotation_Validity, .ProspectCustomer_ID = x.ProspectCustomer_ID, .RemarkQuotation = x.Remark,
                .RemarkInternal = x.RemarkInternal, .IsExists = x.IsExists}).FirstOrDefault()

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
                              OTR_Price = A.Gross, A.Qty, A.Year, B.STNK, B.Replacement,
                              A.Lease_long, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?),
                              Rent_Location = B.Ms_Citys2.City, Plat_Location = B.Ms_Citys1.City, B.Update_Diskon, Net = B.Cost_Price, B.Depresiasi_Percent, B.Residual_ValuePercent, B.Residual_Value, B.Maintenance_Percent,
                              B.Assurance_Percent, B.Expedition_Cost, B.Modification, B.GPS_Cost, B.Agent_Fee, B.Keur, B.IRR, B.Profit, B.Spread, A.Transaction_Type, B.Funding_Rate).ToList()
            ViewBag.detail = details
            Return View(tr_Approval)
        End Function

        Function Create(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Approval = (From A In db.Tr_Approvals
                               Group Join B In db.Tr_Quotations On A.Quotation_ID Equals B.Quotation_ID Into AB = Group
                               From B In AB.DefaultIfEmpty()
                               Group Join C In db.V_ProspectCusts On B.ProspectCustomer_ID Equals C.ProspectCustomer_ID Into CB = Group
                               From C In CB.DefaultIfEmpty()
                               Where A.IsDeleted = False And B.IsDeleted = False And A.Approval_ID = id
                               Select B.No_Ref, Company_Name = C.PT + " " + C.Company_Name, A.Approval_ID, A.Quotation_ID, C.CompanyGroup_Name, C.Address,
                                   C.Phone, C.Email, C.PIC_Name, C.PIC_Phone, C.PIC_Email, B.Quotation_Validity, B.ProspectCustomer_ID, B.Remark, B.RemarkInternal,
                                   CreatedBy = A.Cn_Users6.User_Name, C.IsExists).Select(
            Function(x) New Tr_Approval With {.IsExists = x.IsExists, .No_Ref = x.No_Ref, .Company_Name = x.Company_Name, .Approval_ID = x.Approval_ID, .Quotation_ID = x.Quotation_ID,
                .CompanyGroup_Name = x.CompanyGroup_Name, .Address = x.Address, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone,
                .PIC_Email = x.PIC_Email, .Quotation_Validity = x.Quotation_Validity, .ProspectCustomer_ID = x.ProspectCustomer_ID, .RemarkQuotation = x.Remark,
                .RemarkInternal = x.RemarkInternal, .CreatedBy = x.CreatedBy}).FirstOrDefault()

            If IsNothing(tr_Approval) Then
                Return HttpNotFound()
            End If

            Dim detail = (From A In db.V_ProspectCustDetails
                          Group Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                          From B In Group.DefaultIfEmpty()
                          Group Join C In db.V_QuotationHD On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
                          From C In CB.DefaultIfEmpty()
                          Where A.ProspectCustomer_ID = tr_Approval.ProspectCustomer_ID And A.IsCalculate = True And B.IsDeleted = False
                          Select Calculate_ID = CType(B.Calculate_ID, Integer?), QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?),
                              IsDeleted = CType(Not C.Quotation_ID, Boolean?), IsVehicleExists = If(A.IsVehicleExists, "Used Car", "New Car"), A.Brand_Name,
                              Vehicle = If(A.IsVehicleExists, A.Vehicle + " " + A.Type, A.Vehicle),
                              OTR_Price = A.Gross, A.Qty, A.Year, B.STNK, B.Replacement,
                              A.Lease_long, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?),
                              Rent_Location = B.Ms_Citys2.City, Plat_Location = B.Ms_Citys1.City, B.Update_Diskon, Net = B.Cost_Price, B.Depresiasi_Percent, B.Residual_ValuePercent, B.Residual_Value, B.Maintenance_Percent,
                              B.Assurance_Percent, B.Expedition_Cost, B.Modification, B.GPS_Cost, B.Agent_Fee, B.Keur, B.IRR, B.Profit, B.Spread, A.Transaction_Type, B.Funding_Rate).ToList()

            ViewBag.detail = detail
            Return View(tr_Approval)
        End Function



        ' POST: Approval/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Approval_ID,Remark")> ByVal tr_Approvals As Tr_Approval) As ActionResult
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim user As String
                        If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                        Dim level = Session("Level_ID_Quotation")
                        Dim User_ID = Session("ID")
                        'calculasi nga bisa di edit

                        Dim CalEdit = db.sp_ApproveGetCal(tr_Approvals.Approval_ID)
                        For Each i In CalEdit
                            Dim cal = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = i).FirstOrDefault
                            cal.IsEdit = False
                        Next
                        Dim Cost_Price = db.V_ProspectCusts.Where(Function(x) x.Approval_ID = tr_Approvals.Approval_ID).Select(Function(x) x.Cost_Price).FirstOrDefault
                        Dim Query = db.Tr_Approvals.Where(Function(x) x.Approval_ID = tr_Approvals.Approval_ID).FirstOrDefault()
                        If level = 1 Then
                            Query.MakerDate = DateTime.Now
                            Query.MakerBy = user
                            Query.MakerRemark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 2 Then
                            Query.CheckerDate = DateTime.Now
                            Query.CheckerBy = user
                            Query.CheckerRemark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 3 Then
                            If Cost_Price <= Session("Limited_Approval_Quotation") Then
                                Query.Status = "Finish"
                                CreateApplication(db, Query.Approval_ID, user, Query.Quotation_ID)
                            End If
                            Query.Approval1Date = DateTime.Now
                            Query.Approval1By = user
                            Query.Approval1Remark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 4 Then
                            If Cost_Price <= Session("Limited_Approval_Quotation") Then
                                Query.Status = "Finish"
                                CreateApplication(db, Query.Approval_ID, user, Query.Quotation_ID)
                            End If
                            Query.Approval2Date = DateTime.Now
                            Query.Approval2By = user
                            Query.Approval2Remark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 5 Then
                            If Cost_Price <= Session("Limited_Approval_Quotation") Then
                                Query.Status = "Finish"
                                CreateApplication(db, Query.Approval_ID, user, Query.Quotation_ID)
                            End If
                            Query.Approval3Date = DateTime.Now
                            Query.Approval3By = user
                            Query.Approval3Remark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 6 Then
                            If Cost_Price <= Session("Limited_Approval_Quotation") Then
                                Query.Status = "Finish"
                                CreateApplication(db, Query.Approval_ID, user, Query.Quotation_ID)
                            End If
                            Query.Approval4Date = DateTime.Now
                            Query.Approval4By = user
                            Query.Approval4Remark = tr_Approvals.Remark
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 7 Then
                            If Cost_Price <= Session("Limited_Approval_Quotation") Then
                                Query.Status = "Finish"
                                CreateApplication(db, Query.Approval_ID, user, Query.Quotation_ID)
                            End If
                            Query.Approval5Date = DateTime.Now
                            Query.Approval5By = user
                            Query.Approval5Remark = tr_Approvals.Remark
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
                    End Try
                End Using
            End If


            Dim tr_Approval = (From A In db.Tr_Approvals
                               Group Join B In db.Tr_Quotations On A.Quotation_ID Equals B.Quotation_ID Into AB = Group
                               From B In AB.DefaultIfEmpty()
                               Group Join C In db.V_ProspectCusts On B.ProspectCustomer_ID Equals C.ProspectCustomer_ID Into CB = Group
                               From C In CB.DefaultIfEmpty()
                               Where A.IsDeleted = False And B.IsDeleted = False And A.Approval_ID = tr_Approvals.Approval_ID
                               Select B.No_Ref, Company_Name = C.PT + " " + C.Company_Name, A.Approval_ID, A.Quotation_ID, C.CompanyGroup_Name, C.Address,
                                   C.Phone, C.Email, C.PIC_Name, C.PIC_Phone, C.PIC_Email, B.Quotation_Validity, B.ProspectCustomer_ID, B.Remark, B.RemarkInternal).Select(
Function(x) New Tr_Approval With {.No_Ref = x.No_Ref, .Company_Name = x.Company_Name, .Approval_ID = x.Approval_ID, .Quotation_ID = x.Quotation_ID,
    .CompanyGroup_Name = x.CompanyGroup_Name, .Address = x.Address, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone,
    .PIC_Email = x.PIC_Email, .Quotation_Validity = x.Quotation_Validity, .ProspectCustomer_ID = x.ProspectCustomer_ID, .RemarkQuotation = x.Remark, .RemarkInternal = x.RemarkInternal}).FirstOrDefault()

            If IsNothing(tr_Approval) Then
                Return HttpNotFound()
            End If

            Dim detail = (From A In db.V_ProspectCustDetails
                          Group Join B In db.Tr_Calculates On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                          From B In Group.DefaultIfEmpty()
                          Group Join C In db.V_QuotationHD On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
                          From C In CB.DefaultIfEmpty()
                          Where A.ProspectCustomer_ID = tr_Approval.ProspectCustomer_ID And A.IsCalculate = True And B.IsDeleted = False
                          Select Calculate_ID = CType(B.Calculate_ID, Integer?), QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?),
                              IsDeleted = CType(Not C.Quotation_ID, Boolean?), IsVehicleExists = If(A.IsVehicleExists, "Used Car", "New Car"), A.Brand_Name,
                              Vehicle = If(A.IsVehicleExists, A.Vehicle + " " + A.Type, A.Vehicle),
                              A.Lease_price, A.Qty, A.Year, B.STNK, B.Replacement,
                              A.Lease_long, A.Amount, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?),
                              Rent_Location = B.Ms_Citys2.City, Plat_Location = B.Ms_Citys1.City, B.Update_Diskon, B.Cost_Price, B.Depresiasi_Percent, B.Residual_ValuePercent, B.Residual_Value, B.Maintenance_Percent,
                              B.Assurance_Percent, B.Expedition_Cost, B.Modification, B.GPS_Cost, B.Agent_Fee, B.Keur, B.IRR, B.Profit, B.Spread, A.Transaction_Type, B.Funding_Rate).ToList()

            ViewBag.detail = detail
            Return View(tr_Approval)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
