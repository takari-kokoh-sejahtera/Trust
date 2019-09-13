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

Namespace Controllers
    Public Class ApprovalAppController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
#Region "Java"
        Public Function NotApprove(ByVal ApprovalApp_ID As Integer?, ByVal val As String, ByVal BackTo As String) As ActionResult
            If val <> "" Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level = Session("Level_ID_Application")
                Dim Query = db.Tr_ApprovalApps.Where(Function(x) x.ApprovalApp_ID = ApprovalApp_ID).FirstOrDefault()
                'If level = 1 Or level = 2 Or level = 3 Or level = 4 Or level = 5 Or level = 6 Then
                Query.StatusRecord = level
                Query.BackTo = BackTo
                Query.Remark = val
                Query.ModifiedDate = DateTime.Now
                Query.ModifiedBy = user
                'ElseIf level = 7 Then
                '    Query.StatusRecord = level
                '    Query.Remark = val
                '    Query.ModifiedDate = DateTime.Now
                '    Query.ModifiedBy = user
                'End If
                Query.Status = "Close"
                'Query.IsDeleted = True
                Dim tr_ApplicationHeader = db.Tr_ApplicationHeaders.Where(Function(x) x.ApplicationHeader_ID = Query.ApplicationHeader_ID).FirstOrDefault()
                tr_ApplicationHeader.IsNotApproved = True
                tr_ApplicationHeader.RemarkNotApproved = val
                tr_ApplicationHeader.ModifiedBy = user
                tr_ApplicationHeader.ModifiedDate = DateTime.Now
                Dim approval = db.Tr_Approvals.Where(Function(x) x.Approval_ID = tr_ApplicationHeader.Approval_ID).FirstOrDefault
                approval.IsApplicationHeader = True
                approval.IsApplicationHeaderDone = False
                approval.ModifiedBy = user

                approval.ModifiedDate = DateTime.Now

                'jika BackTo applikasi maka sampai disini
                If BackTo = "Application" Then GoTo Finish

                tr_ApplicationHeader.IsDeleted = True
                approval.IsApplicationHeader = False


                Dim pros = db.V_ProspectCusts.Where(Function(x) x.ApplicationHeader_ID = Query.ApplicationHeader_ID).FirstOrDefault
                Dim prosDet = db.V_ProspectCustDetails.Where(Function(x) x.Quotation_ID = pros.Quotation_ID).ToList
                Dim app = db.Tr_Applications.Where(Function(x) x.ApplicationHeader_ID = Query.ApplicationHeader_ID)
                For Each ap In app
                    'jika dia di bawah Applikasi maka di false biar keapus di applikasi
                    ap.ApplicationHeader_ID = Nothing

                    If prosDet.Where(Function(x) x.Application_ID = ap.Application_ID And x.IsVehicleExists = False).Any Then
                        ap.IsFillOTR = False
                    End If
                    ap.ModifiedBy = user
                    ap.ModifiedDate = DateTime.Now
                    Dim appCashFow = db.Tr_ApplicationCashFlows.Where(Function(x) x.Application_ID = ap.Application_ID).ToList
                    For Each i In appCashFow
                        i.IsDeleted = True
                        i.ModifiedBy = user
                        i.ModifiedDate = DateTime.Now
                    Next
                Next


                Dim appPO = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = pros.ProspectCustomer_ID)
                If BackTo = "Application PO" Then
                    For Each i In appPO
                        i.IsNotApproved = True
                        i.RemarkNotApproved = val
                    Next
                End If
                If BackTo = "Application PO" Then GoTo Finish

                'Hapus Applikasi PO dan APprovalnya
                For Each i In appPO
                    i.IsDeleted = True
                    i.ModifiedBy = user
                    i.ModifiedDate = DateTime.Now
                    For Each o In i.Tr_ApplicationPODetails
                        o.IsDeleted = True
                        o.ModifiedBy = user
                        o.ModifiedDate = DateTime.Now
                    Next
                Next
                Dim approvePO = db.Tr_ApprovalPOs.Where(Function(x) x.ProspectCustomer_ID = pros.ProspectCustomer_ID And x.IsDeleted = False).FirstOrDefault
                If approvePO IsNot Nothing Then
                    approvePO.IsDeleted = True
                End If
                'Update Prospect IsApplicationPO
                Dim pross = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = pros.ProspectCustomer_ID And x.IsDeleted = False).FirstOrDefault
                pross.IsApplicationPO = False

                Dim Quot = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = pros.Quotation_ID).FirstOrDefault
                Quot.IsPO = False
                'jika BackTo Upload SPH and PO maka sampe finish

Finish:
                db.SaveChanges()
                Return Json(New With {Key .success = "true"})
            End If
            Return Json(New With {Key .success = "false", .error = "Please fill remark"})
        End Function

#End Region
        ' GET: ApprovalApp
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
            ViewBag.Level_ID = Session("Level_ID_Application")
            Dim App = (From A In db.Tr_ApprovalApps
                       Group Join A1 In db.Cn_Users On A.MakerBy Equals A1.User_ID Into A1A = Group
                       From A1 In A1A.DefaultIfEmpty()
                       Group Join A2 In db.Cn_Users On A.CheckerBy Equals A2.User_ID Into A2A = Group
                       From A2 In A2A.DefaultIfEmpty()
                       Group Join A3 In db.Cn_Users On A.Approval1By Equals A3.User_ID Into A3A = Group
                       From A3 In A3A.DefaultIfEmpty()
                       Group Join A4 In db.Cn_Users On A.Approval2By Equals A4.User_ID Into A4A = Group
                       From A4 In A4A.DefaultIfEmpty()
                       Group Join A5 In db.Cn_Users On A.Approval3By Equals A5.User_ID Into A5A = Group
                       From A5 In A5A.DefaultIfEmpty()
                       Group Join A6 In db.Cn_Users On A.Approval4By Equals A6.User_ID Into A6A = Group
                       From A6 In A6A.DefaultIfEmpty()
                       Group Join A7 In db.Cn_Users On A.Approval5By Equals A7.User_ID Into A7A = Group
                       From A7 In A7A.DefaultIfEmpty()
                       Group Join A8 In db.Cn_Users On A.CreatedBy Equals A8.User_ID Into A8A = Group
                       From A8 In A8A.DefaultIfEmpty()
                       Group Join A9 In db.Cn_Users On A.ModifiedBy Equals A9.User_ID Into A9A = Group
                       From A9 In A9A.DefaultIfEmpty()
                       Group Join A10 In db.Cn_Users On A.Approval6By Equals A10.User_ID Into A10A = Group
                       From A10 In A10A.DefaultIfEmpty()
                       Group Join A11 In db.Cn_Users On A.Approval7By Equals A11.User_ID Into A11A = Group
                       From A11 In A11A.DefaultIfEmpty()
                       Group Join A12 In db.Cn_Users On A.Approval8By Equals A12.User_ID Into A12A = Group
                       From A12 In A12A.DefaultIfEmpty()
                       Join B In db.V_ProspectCusts On A.ApplicationHeader_ID Equals B.ApplicationHeader_ID
                       Where A.IsDeleted = 0
                       Group Join C In db.Tr_ApplicationHeaders On A.ApplicationHeader_ID Equals C.ApplicationHeader_ID Into CA = Group
                       From C In CA.DefaultIfEmpty()
                       Select A.ApprovalApp_ID, A.ApplicationHeader_ID, C.Application_No, B.CompanyGroup_Name, B.Company_Name,
                        A.MakerDate, MakerBy = A1.User_Name, A.CheckerDate, CheckerBy = A2.User_Name, A.Approval1Date, Approval1By = A3.User_Name, A.Approval2Date,
                        Approval2By = A4.User_Name, A.Approval3Date, Approval3By = A5.User_Name, A.Approval4Date, Approval4By = A6.User_Name, A.Approval5Date, Approval5By = A7.User_Name, A.Approval6Date, Approval6By = A10.User_Name, A.Approval7Date, Approval7By = A11.User_Name, A.Approval8Date, Approval8By = A12.User_Name,
                             A.StatusRecord, A.Status, A.Remark, A.CreatedDate, CreatedBy = A8.User_Name, A.ModifiedDate, ModifiedBy = A9.User_Name).Select(
                        Function(x) New Tr_ApprovalApp With {.ApprovalApp_ID = x.ApprovalApp_ID, .ApplicationHeader_ID = x.ApplicationHeader_ID, .Application_No = x.Application_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                        .MakerDate = x.MakerDate, .MakerByStr = x.MakerBy, .CheckerDate = x.CheckerDate, .CheckerByStr = x.CheckerBy, .Approval1Date = x.Approval1Date, .Approval1ByStr = x.Approval1By, .Approval2Date = x.Approval2Date,
                        .Approval2ByStr = x.Approval2By, .Approval3Date = x.Approval3Date, .Approval3ByStr = x.Approval3By, .Approval4Date = x.Approval4Date, .Approval4ByStr = x.Approval4By, .Approval5Date = x.Approval5Date, .Approval5ByStr = x.Approval5By, .Approval6Date = x.Approval6Date, .Approval6ByStr = x.Approval6By,
                         .Approval7Date = x.Approval7Date, .Approval7ByStr = x.Approval7By, .Approval8Date = x.Approval8Date, .Approval8ByStr = x.Approval8By, .Status = x.Status, .StatusRecord = x.StatusRecord,
                        .CreatedDate = x.CreatedDate, .CreatedByStr = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedByStr = x.ModifiedBy})

            If Not String.IsNullOrEmpty(searchString) Then
                App = App.Where(Function(s) s.Application_No.Contains(searchString) OrElse s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Application_No"
                    App = App.OrderBy(Function(s) s.Application_No)
                Case "CompanyGroup_Name"
                    App = App.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    App = App.OrderBy(Function(s) s.Company_Name)
                Case Else
                    App = App.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(App.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ApprovalApp/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApprovalApps As Tr_ApprovalApps = Await db.Tr_ApprovalApps.FindAsync(id)
            If IsNothing(tr_ApprovalApps) Then
                Return HttpNotFound()
            End If
            Return View(tr_ApprovalApps)
        End Function

        ' GET: ApprovalApp/Create
        Function Create(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Tr_ApplicationHeaders
                         Join C In db.Tr_ApprovalApps On A.ApplicationHeader_ID Equals C.ApplicationHeader_ID
                         Join B In db.V_ProspectCusts On A.Approval_ID Equals B.Approval_ID
                         Where A.IsDeleted = False And C.ApprovalApp_ID = id
                         Select A.ApplicationHeader_ID, B.Address, B.CompanyGroup_Name, B.Company_Name, B.City, B.PIC_Name, B.PIC_Phone, B.PIC_Email, B.Phone, B.Email,
                             B.IsExists, A.Credit_Rating, A.Authorized_Capital, A.Authorized_Signer_Name1, CC = A.Customer_Class, A.Authorized_Signer_Position1, A.Authorized_Signer_Name2, A.Contract_No,
                             C.ApprovalApp_ID, A.Authorized_Signer_Position2, A.IntroducedBy, CB = A.Contracted_by, A.Outstanding_Balance_Group, A.Outstanding_Balance_MUL_Group, A.RunContractCompany, A.RunContractGroup).
            Select(Function(x) New Tr_ApplicationHeader With {.ApplicationHeader_ID = x.ApplicationHeader_ID, .Address = x.Address, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                             .City = x.City, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Phone = x.Phone, .Email = x.Email, .IsExists = x.IsExists, .Credit_Rating = x.Credit_Rating,
                             .Authorized_Capital = x.Authorized_Capital, .Authorized_Signer_Name1 = x.Authorized_Signer_Name1, .Customer_Class = x.CC, .Authorized_Signer_Position1 = x.Authorized_Signer_Position1,
                             .Authorized_Signer_Name2 = x.Authorized_Signer_Name2, .Authorized_Signer_Position2 = x.Authorized_Signer_Position2, .IntroducedBy = x.IntroducedBy, .Contracted_by = x.CB,
                             .Outstanding_Balance_Group = x.Outstanding_Balance_Group, .Outstanding_Balance_MUL_Group = x.Outstanding_Balance_MUL_Group, .RunContractCompany = x.RunContractCompany,
                             .RunContractGroup = x.RunContractGroup, .ApprovalApp_ID = x.ApprovalApp_ID, .BackTo = "Upload SPH and PO", .Contract_No = x.Contract_No}).FirstOrDefault()
            query.Detail = (From H In db.Tr_ApplicationHeaders.Where(Function(z) z.IsDeleted = False)
                            Join A In db.V_ProspectCustDetails On H.ApplicationHeader_ID Equals A.ApplicationHeader_ID
                            Join App In db.Tr_Applications.Where(Function(z) z.IsDeleted = False) On A.Application_ID Equals App.Application_ID
                            Group Join B In db.Tr_Calculates.Where(Function(z) z.IsDeleted = False) On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                            From B In Group.DefaultIfEmpty()
                            Group Join C In db.V_QuotationHD On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
                            From C In CB.DefaultIfEmpty()
                            Where H.ApplicationHeader_ID = query.ApplicationHeader_ID And A.IsCalculate = True And B.IsDeleted = False
                            Select New Tr_ApplicationHeaderDetail With {.Application_ID = A.Application_ID, .QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?),
                              .IsVehicleExists = If(A.IsVehicleExists, "Used Car", "New Car"), .Brand_Name = A.Brand_Name,
                              .Vehicle = If(A.IsVehicleExists, A.Vehicle + " " + A.Type, A.Vehicle),
                              .OTR_Price = A.Gross, .OTR_PriceApp = A.GrossApp, .Qty = A.Qty, .Year = A.Year, .STNK = B.STNK, .Replacement = B.Replacement,
                              .Lease_long = A.Lease_long, .Bid_PricePerMonth = B.Bid_PricePerMonth, .Bid_PricePerMonthApp = App.Bid_PricePerMonth,
                              .Rent_Location = B.Ms_Citys2.City, .Plat_Location = B.Ms_Citys1.City, .Update_Diskon = B.Update_Diskon, .Update_DiskonApp = App.Update_Diskon, .Net = B.Cost_Price, .NetApp = App.Cost_Price, .Depresiasi_Percent = B.Depresiasi_Percent,
                                .Residual_ValuePercent = B.Residual_ValuePercent, .Residual_Value = B.Residual_Value,
                              .Maintenance_Percent = B.Maintenance_Percent,
                              .Assurance_Percent = B.Assurance_Percent, .Expedition_Cost = B.Expedition_Cost, .Modification = B.Modification, .GPS_Cost = B.GPS_Cost, .Agent_Fee = B.Agent_Fee,
                                       .Keur = B.Keur, .IRR = B.IRR, .IRRApp = App.IRR, .Profit = B.Profit, .ProfitApp = App.Profit, .Spread = B.Spread, .SpreadApp = App.Spread, .Transaction_Type = A.Transaction_Type, .Funding_Rate = B.Funding_Rate, .Funding_RateApp = App.Funding_Rate
                                }).ToList

            If IsNothing(query) Then
                Return HttpNotFound()
            End If


            'Dim query.detail = (From H In db.Tr_ApplicationHeaders.Where(Function(x) x.IsDeleted = False)
            '              Join A In db.V_ProspectCustDetails On H.ApplicationHeader_ID Equals A.ApplicationHeader_ID
            '              Join App In db.Tr_Applications.Where(Function(x) x.IsDeleted = False) On A.Application_ID Equals App.Application_ID
            '              Group Join B In db.Tr_Calculates.Where(Function(x) x.IsDeleted = False) On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
            '              From B In Group.DefaultIfEmpty()
            '              Group Join C In db.V_QuotationHD On B.Calculate_ID Equals C.Calculate_ID Into CB = Group
            '              From C In CB.DefaultIfEmpty()
            '              Where H.ApplicationHeader_ID = query.ApplicationHeader_ID And A.IsCalculate = True And B.IsDeleted = False
            '              Select Application_ID = CType(A.Application_ID, Integer?), QuotationDetail_ID = CType(C.QuotationDetail_ID, Integer?),
            '                  IsVehicleExists = If(A.IsVehicleExists, "Used Car", "New Car"), A.Brand_Name,
            '                  Vehicle = If(A.IsVehicleExists, A.Vehicle + " " + A.Type, A.Vehicle),
            '                  OTR_Price = A.Gross, A.Qty, A.Year, B.STNK, B.Replacement,
            '                  A.Lease_long, Bid_PricePerMonth = CType(B.Bid_PricePerMonth, Integer?),
            '                  Rent_Location = B.Ms_Citys2.City, Plat_Location = B.Ms_Citys1.City, B.Update_Diskon, Net = B.Cost_Price, B.Depresiasi_Percent, B.Residual_ValuePercent, B.Residual_Value,
            '                  B.Maintenance_Percent,
            '                  B.Assurance_Percent, B.Expedition_Cost, B.Modification, B.GPS_Cost, B.Agent_Fee, B.Keur, B.IRR, B.Profit, B.Spread, A.Transaction_Type, B.Funding_Rate).ToList()


            Dim MaxCostPrice = query.Detail.Max(Function(x) x.Net)
            query.Cost_Price = MaxCostPrice
            Dim Customer_Class As List(Of SelectListItem) = New List(Of SelectListItem)() From {
            New SelectListItem With {
                    .Text = "Japanese",
                    .Value = "Japanese"
                },
                New SelectListItem With {
                    .Text = "Non-Japanese",
                    .Value = "Non-Japanese"
                }
            }
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", query.Customer_Class)
            Dim Contracted_by As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PT Takari Kokoh Sejahtera",
                    .Value = "PT Takari Kokoh Sejahtera"
                },
                New SelectListItem With {
                    .Text = "PT Takari Sumber Mulia",
                    .Value = "PT Takari Sumber Mulia"
                }
            }
            ViewBag.Contracted_by = New SelectList(Contracted_by, "Value", "Text", query.Contracted_by)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", query.Credit_Rating)
            Return View(query)
        End Function

        ' POST: ApprovalApp/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(Appheader As Tr_ApplicationHeader) As ActionResult
            ModelState.Remove("Expec_Contract_Date")
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level = Session("Level_ID_Application")
                Dim User_ID = Session("ID")
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim Query = db.Tr_ApprovalApps.Where(Function(x) x.ApprovalApp_ID = Appheader.ApprovalApp_ID).FirstOrDefault()
                        If level = 1 Then
                            Query.MakerDate = DateTime.Now
                            Query.MakerBy = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 2 Then
                            Query.CheckerDate = DateTime.Now
                            Query.CheckerBy = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 3 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval1Date = DateTime.Now
                            Query.Approval1By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 4 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval2Date = DateTime.Now
                            Query.Approval2By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 5 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval3Date = DateTime.Now
                            Query.Approval3By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 6 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval4Date = DateTime.Now
                            Query.Approval4By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 7 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval5Date = DateTime.Now
                            Query.Approval5By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 8 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval6Date = DateTime.Now
                            Query.Approval6By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 9 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval7Date = DateTime.Now
                            Query.Approval7By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        ElseIf level = 10 Then
                            If Appheader.Cost_Price <= Session("Limited_Approval_Application") Then
                                Query.Status = "Finish"
                                CreateContract(Query.ApprovalApp_ID, user)
                            End If
                            Query.Approval8Date = DateTime.Now
                            Query.Approval8By = user
                            Query.StatusRecord = level
                            Query.ModifiedDate = DateTime.Now
                            Query.ModifiedBy = user
                        End If
                        db.SaveChanges()
                        dbs.Commit()
                        Return RedirectToAction("Index")
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("Company_Name", ex.Message)
                    End Try
                End Using
            End If
            Dim detail = (From A In db.Tr_Applications
                          Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
                          From B In Group.DefaultIfEmpty()
                          Where A.IsDeleted = False And A.IsFillOTR = True And A.ApplicationHeader_ID = Appheader.ApplicationHeader_ID
                          Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
                                  A.Application_ID, B.Brand_Name,
                                  B.Vehicle, A.Payee, A.PayeeRemark,
                                  B.Transaction_Type,
                                  A.Purchaser, A.Purchase_Type, B.Asset_Rating, A.Cost_Price).ToList()
            Dim Customer_Class As List(Of SelectListItem) = New List(Of SelectListItem)() From {
            New SelectListItem With {
                    .Text = "Japanese",
                    .Value = "Japanese"
                },
                New SelectListItem With {
                    .Text = "Non-Japanese",
                    .Value = "Non-Japanese"
                }
            }
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", Appheader.Customer_Class)
            Dim Contracted_by As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PT Takari Kokoh Sejahtera",
                    .Value = "PT Takari Kokoh Sejahtera"
                },
                New SelectListItem With {
                    .Text = "PT Takari Sumber Mulia",
                    .Value = "PT Takari Sumber Mulia"
                }
            }
            ViewBag.Contracted_by = New SelectList(Contracted_by, "Value", "Text", Appheader.Contracted_by)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", Appheader.Credit_Rating)
            ViewBag.Detail = detail
            Return View(Appheader)
        End Function

        Sub CreateContract(ApprovalApp_ID As Integer, user As String)
            'No Receipt
            Dim transRcp As String = "Receipt"
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
            Dim Contract_noRcp As String = "RCP/" + Right(Now.Year.ToString(), 2) + "." + numberRcp.ToString + "/TKS/" + Now.Month.ToString


            'Create Header
            Dim contract As New Tr_Contracts
            contract.ApprovalApp_ID = ApprovalApp_ID
            contract.Receipt_No = Contract_noRcp
            contract.CreatedDate = DateTime.Now
            contract.CreatedBy = user
            contract.IsDeleted = False
            contract.IsDraftedContract = False
            contract.IsSendedContract = False
            contract.IsReceiptContract = False
            contract.IsInvoicedAll = False
            contract.IsInvoiceReceiptAll = False
            contract.IsSetDelivery = False
            db.Tr_Contracts.Add(contract)
            db.SaveChanges()
            'Create Detail
            Dim Query = (From A In db.Tr_ApprovalApps.Where(Function(x) x.IsDeleted = False)
                         Group Join B In db.Tr_Applications.Where(Function(x) x.IsDeleted = False) On A.ApplicationHeader_ID Equals B.ApplicationHeader_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.V_ProspectCustDetails On B.Application_ID Equals C.Application_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Where A.IsDeleted = False And B.IsDeleted = False And A.ApprovalApp_ID = ApprovalApp_ID).ToList

            For Each item In Query
                If item.C.IsVehicleExists Then
                    Dim contractDetail As New Tr_ContractDetails
                    contractDetail.Vehicle_ID = item.C.VehicleExists_ID
                    contractDetail.Contract_ID = contract.Contract_ID
                    contractDetail.Application_ID = item.B.Application_ID
                    contractDetail.Bid_PricePerMonth = item.B.Bid_PricePerMonth
                    contractDetail.CreatedDate = DateTime.Now
                    contractDetail.CreatedBy = user
                    contractDetail.IsDeleted = False
                    contractDetail.IsTemporaryCar = False
                    contractDetail.IsDelivery = False
                    contractDetail.IsInvoiced = False
                    contractDetail.IsTotalLossOnly = False
                    db.Tr_ContractDetails.Add(contractDetail)
                Else
                    Dim PerMonth = item.B.Bid_PricePerMonth / item.C.Qty
                    For d As Integer = 1 To item.C.Qty
                        'jika dia mobil baru maka vehicle id nya kosong
                        Dim contractDetail As New Tr_ContractDetails
                        contractDetail.Contract_ID = contract.Contract_ID
                        contractDetail.Application_ID = item.B.Application_ID
                        contractDetail.Bid_PricePerMonth = PerMonth
                        contractDetail.CreatedDate = DateTime.Now
                        contractDetail.CreatedBy = user
                        contractDetail.IsDeleted = False
                        contractDetail.IsTemporaryCar = False
                        contractDetail.IsDelivery = False
                        contractDetail.IsInvoiced = False
                        contractDetail.IsTotalLossOnly = False
                        db.Tr_ContractDetails.Add(contractDetail)
                    Next
                End If
                db.SaveChanges()
            Next

            Dim appheader_ID = db.Tr_ApprovalApps.Where(Function(x) x.ApprovalApp_ID = ApprovalApp_ID).FirstOrDefault.ApplicationHeader_ID
            'nga update header ApppHeader
            'Dim quotation = db.Tr_Quotations.Where(Function(x) x.Quotation_ID = Quotation_ID).FirstOrDefault
            'quotation.IsApplication = True
            'quotation.ModifiedDate = DateTime.Now
            'quotation.ModifiedBy = user
            'Jika dia User baru di buatin otomatis di Customer
            Dim Pros = db.V_ProspectCusts.Where(Function(x) x.ApplicationHeader_ID = appheader_ID).FirstOrDefault
            Dim ProsH = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = Pros.ProspectCustomer_ID).FirstOrDefault
            If Not Pros.IsExists Then
                Dim AppHeader = db.Tr_ApplicationHeaders.Where(Function(x) x.ApplicationHeader_ID = appheader_ID).FirstOrDefault
                Dim customer = db.Ms_Customers.Where(Function(x) x.Customer_ID = Pros.Customer_ID).FirstOrDefault
                'customer.CompanyGroup_ID = Pros.CompanyGroup_ID
                'customer.Company_Name = Pros.Company_Name
                'customer.PT = Pros.PT
                'customer.Tbk = Pros.Tbk
                'customer.Address = Pros.Address
                'customer.City_ID = Pros.City_ID
                'customer.Phone = Pros.Phone
                'customer.Email = Pros.Email
                'customer.PIC_Name = Pros.PIC_Name
                'customer.PIC_Phone = Pros.PIC_Phone
                'customer.PIC_Email = Pros.PIC_Email
                'customer.Notes = Pros.Notes
                'dari app header
                customer.Customer_Class = AppHeader.Customer_Class
                customer.Credit_Rating = AppHeader.Credit_Rating
                customer.Line_of_Business = AppHeader.Line_of_Business
                customer.Authorized_Capital = AppHeader.Authorized_Capital
                customer.Authorized_Signer_Name1 = AppHeader.Authorized_Signer_Name1
                customer.Authorized_Signer_Position1 = AppHeader.Authorized_Signer_Position1
                customer.Authorized_Signer_Name2 = AppHeader.Authorized_Signer_Name2
                customer.Authorized_Signer_Position2 = AppHeader.Authorized_Signer_Position2
                customer.IntroducedBy = AppHeader.IntroducedBy

                'customer.CreatedDate = Pros.CreatedDate
                'customer.CreatedBy = Pros.CreatedBy
                'customer.IsDeleted = False
                'customer.IsKYC = False
                'db.Ms_Customers.Add(customer)
                ProsH.CustomerExists_ID = customer.Customer_ID
            End If
            ProsH.IsApplication = True
            db.SaveChanges()
        End Sub


        ' GET: ApprovalApp/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApprovalApps As Tr_ApprovalApps = Await db.Tr_ApprovalApps.FindAsync(id)
            If IsNothing(tr_ApprovalApps) Then
                Return HttpNotFound()
            End If
            ViewBag.Approval1By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval1By)
            ViewBag.Approval2By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval2By)
            ViewBag.Approval3By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval3By)
            ViewBag.Approval4By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval4By)
            ViewBag.Approval5By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval5By)
            ViewBag.CheckerBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.CheckerBy)
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.CreatedBy)
            ViewBag.MakerBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.MakerBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.ModifiedBy)
            ViewBag.ApplicationHeader_ID = New SelectList(db.Tr_ApplicationHeaders, "ApplicationHeader_ID", "Application_No", tr_ApprovalApps.ApplicationHeader_ID)
            Return View(tr_ApprovalApps)
        End Function

        ' POST: ApprovalApp/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ApprovalApp_ID,ApplicationHeader_ID,MakerDate,MakerBy,CheckerDate,CheckerBy,Approval1Date,Approval1By,Approval2Date,Approval2By,Approval3Date,Approval3By,Approval4Date,Approval4By,Approval5Date,Approval5By,StatusRecord,Status,Remark,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_ApprovalApps As Tr_ApprovalApps) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(tr_ApprovalApps).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.Approval1By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval1By)
            ViewBag.Approval2By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval2By)
            ViewBag.Approval3By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval3By)
            ViewBag.Approval4By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval4By)
            ViewBag.Approval5By = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.Approval5By)
            ViewBag.CheckerBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.CheckerBy)
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.CreatedBy)
            ViewBag.MakerBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.MakerBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_ApprovalApps.ModifiedBy)
            ViewBag.ApplicationHeader_ID = New SelectList(db.Tr_ApplicationHeaders, "ApplicationHeader_ID", "Application_No", tr_ApprovalApps.ApplicationHeader_ID)
            Return View(tr_ApprovalApps)
        End Function

        ' GET: ApprovalApp/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ApprovalApps As Tr_ApprovalApps = Await db.Tr_ApprovalApps.FindAsync(id)
            If IsNothing(tr_ApprovalApps) Then
                Return HttpNotFound()
            End If
            Return View(tr_ApprovalApps)
        End Function

        ' POST: ApprovalApp/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_ApprovalApps As Tr_ApprovalApps = Await db.Tr_ApprovalApps.FindAsync(id)
            db.Tr_ApprovalApps.Remove(tr_ApprovalApps)
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
