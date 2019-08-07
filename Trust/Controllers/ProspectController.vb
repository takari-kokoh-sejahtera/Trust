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
    Public Class ProspectController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Dim customer As New CustomerController
#Region "JS"
        Function GetModel(ByVal ID As Integer?) As ActionResult
            Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
            For Each row In db.Ms_Vehicle_Models.Where(Function(p) p.Brand_ID = ID And p.IsDeleted = False).OrderBy(Function(x) x.Type)
                list.Add(New SelectListItem With {.Text = Convert.ToString(row.Type), .Value = Convert.ToString(row.Model_ID)})
            Next
            Return Json(New SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet))
        End Function
        Function GetModelPrice(ByVal ID As Integer?) As ActionResult
            Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
            Dim harga = db.Ms_Vehicle_Models.Where(Function(p) p.Model_ID = ID And p.IsDeleted = False).Select(Function(x) x.OTR_Price).FirstOrDefault

            Return Json(New With {Key .Price = harga}, JsonRequestBehavior.AllowGet)
        End Function
#End Region

        Public Function GetUserMarketing(user_ID As Integer, role_ID As Integer, department_ID As Integer) As Integer()
            If role_ID = 6 Then
                Return {user_ID}
            ElseIf role_ID = 8 Then
                Return db.Cn_Users.Where(Function(x) x.Department_ID = department_ID).Select(Function(x) x.User_ID).ToArray
            ElseIf role_ID = 24 Then
                Return db.Cn_Users.Select(Function(x) x.User_ID).ToArray
            Else
                Return {0}
            End If
        End Function
        ' GET: Prospect
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
            Dim prospec = (From A In db.V_ProspectCusts
                           Select A.ProspectCustomer_ID, A.IsExists, A.CompanyGroup_ID, A.CompanyGroup_Name, A.Company_Name, A.PT, A.Tbk, A.Address, A.City_ID, A.City, A.Phone,
                              A.Email, A.PIC_Name, A.PIC_Phone, A.PIC_Email, A.Notes, A.IsQuotation, A.Status, A.Cost_Price, A.CreatedDate, A.CreatedByName, A.CreatedBy, A.ModifiedDate,
                              A.ModifiedByName, A.Quotation_ID, A.Approval_ID).
                              Select(Function(x) New Tr_ProspectCust With {.ProspectCustomer_ID = x.ProspectCustomer_ID, .IsExists = x.IsExists, .CompanyGroup_ID = x.CompanyGroup_ID,
                                         .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .PT = x.PT, .Tbk = x.Tbk, .Address = x.Address, .City_id = x.City_ID, .City = x.City, .Phone = x.Phone,
                              .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Notes = x.Notes, .IsQuotation = x.IsQuotation, .Status = x.Status, .Cost_Price = x.Cost_Price, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .CreatedByName = x.CreatedByName,
                              .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedByName, .Quotation_ID = x.Quotation_ID, .Approval_ID = x.Approval_ID})

            'pake Function
            Dim list = GetUserMarketing(Session("ID"), Session("Role_ID"), Session("Department_ID"))
            If list.FirstOrDefault = 0 Then
                Return New HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, "You are not part of marketing")
            End If
            prospec = prospec.Where(Function(x) list.Contains(x.CreatedBy))

            If Not String.IsNullOrEmpty(searchString) Then
                prospec = prospec.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    prospec = prospec.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    prospec = prospec.OrderBy(Function(s) s.Company_Name)
                Case Else
                    prospec = prospec.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(prospec.ToPagedList(pageNumber, pageSize))
        End Function


        ' GET: Prospect/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ProspectCusts = db.V_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = id).FirstOrDefault()
            If IsNothing(tr_ProspectCusts) Then
                Return HttpNotFound()
            End If
            Dim tr_ProspectCust As New Tr_ProspectCust
            tr_ProspectCust.ProspectCustomer_ID = id
            tr_ProspectCust.IsExists = tr_ProspectCusts.IsExists
            tr_ProspectCust.CompanyGroup_ID = tr_ProspectCusts.CompanyGroup_ID
            tr_ProspectCust.CompanyGroup_Name = tr_ProspectCusts.CompanyGroup_Name
            tr_ProspectCust.Company_Name = tr_ProspectCusts.Company_Name
            tr_ProspectCust.PT = tr_ProspectCusts.PT
            tr_ProspectCust.Tbk = tr_ProspectCusts.Tbk
            tr_ProspectCust.Address = tr_ProspectCusts.Address
            tr_ProspectCust.City = tr_ProspectCusts.City
            tr_ProspectCust.Phone = tr_ProspectCusts.Phone
            tr_ProspectCust.Email = tr_ProspectCusts.Email
            tr_ProspectCust.PIC_Name = tr_ProspectCusts.PIC_Name
            tr_ProspectCust.PIC_Phone = tr_ProspectCusts.PIC_Phone
            tr_ProspectCust.PIC_Email = tr_ProspectCusts.PIC_Email
            tr_ProspectCust.Notes = tr_ProspectCusts.Notes
            tr_ProspectCust.CreatedDate = tr_ProspectCusts.CreatedDate
            tr_ProspectCust.CreatedBy = tr_ProspectCusts.CreatedBy
            tr_ProspectCust.ModifiedDate = tr_ProspectCusts.ModifiedDate
            tr_ProspectCust.ModifiedBy = tr_ProspectCusts.ModifiedByName
            Dim history = From A In db.Tr_ProspectCustHistorys.Where(Function(x) x.ProspectCustomer_ID = id And x.IsDeleted = False)
                          Group Join B In db.Ms_ProspectCategorys On A.ProspectCategory_ID Equals B.ProspectCategory_ID Into AB = Group
                          From B In AB.DefaultIfEmpty
                          Select A.Status, B.ProspectCategory, A.DateTrans, A.Notes, A.CheckNote, A.CheckedDate, CheckedBy = A.Cn_Users.User_Name
            ViewBag.historys = history

            Return View(tr_ProspectCust)
        End Function

        ' GET: Prospect/Create
        Function Create() As ActionResult
#If DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Session("User_ID") = "System"
#Else
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If

            ViewBag.PT = New SelectList(customer.myPT, "Value", "Text")
            Dim myTbk As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Tbk",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Tbk",
                    .Value = False
                }
            }
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text")
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                }
            }
            ViewBag.Status = New SelectList(myStatus, "Value", "Text")
            Dim myType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "OPL",
                    .Value = "OPL"
                },
                New SelectListItem With {
                    .Text = "COP",
                    .Value = "COP"
                }
            }
            ViewBag.Transaction_Type = New SelectList(myType, "Value", "Text")
            ViewBag.City_id = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "City_ID", "City")
            ViewBag.VehicleExists_ID = New SelectList(db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False), "Vehicle_id", "license_no")
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Brand_Name), "Brand_ID", "Brand_Name")
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Type), "Model_ID", "Type")
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name")
            ViewBag.CustomerExists_ID = New SelectList(db.sp_GetCustomerFromUser(Session("ID")).OrderBy(Function(x) x.Company_Name), "Customer_ID", "Company_Name")
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.Where(Function(x) x.IsDeleted = False).GroupBy(Function(x) x.Credit_Rating), "Key", "Key")
            Dim myJakarta As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jakarta",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Jakarta",
                    .Value = False
                }
            }
            ViewBag.IsJakarta = New SelectList(myJakarta, "Value", "Text")
            ViewBag.ProspectCategory_ID = New SelectList(db.Ms_ProspectCategorys.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.ProspectCategory), "ProspectCategory_ID", "ProspectCategory")
            Dim ProspectCust = New Tr_ProspectCust
            ProspectCust.DateTrans = Now
            ProspectCust.DateTransTime = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
            Return View(ProspectCust)
        End Function
        Public Function SaveOrder(orderHD() As Tr_ProspectCust, order() As Tr_ProspectCustDetails) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim prospectCustomer As New Tr_ProspectCusts
            Dim result As String = "Error"
            Dim Message = ""
            Dim header = orderHD.FirstOrDefault

            'Validasi
#Region "Validasi"
            Dim Valid As Boolean = True
            'validate customer
            If header.IsExists Then
                If (header.CustomerExists_ID = 0) Then
                    Message = "Must fill Customer Exists"
                    Valid = False
                End If
            Else
                If ((header.CompanyGroup_ID = 0)) Then
                    Message = "Must fill Company Group"
                    Valid = False
                ElseIf (header.PT = Nothing) Then
                    Message = "Must fill PT"
                    Valid = False
                ElseIf header.Tbk Is Nothing Then
                    Message = "Must fill TBK"
                    Valid = False
                ElseIf header.Company_Name = "" Then
                    Message = "Must fill Company Name"
                    Valid = False
                ElseIf header.Company_Name.Length > 50 Then
                    Message = "Company Name cant not be more than 50 characters"
                    Valid = False
                ElseIf header.Status = "Finish" Then
                    If (header.Address Is Nothing) Then
                        Message = "Must fill Address"
                        Valid = False
                    ElseIf (header.City_id Is Nothing) Then
                        Message = "Must fill City"
                        Valid = False
                    ElseIf (header.Phone Is Nothing) Then
                        Message = "Must fill Phone"
                        Valid = False
                    ElseIf (header.Email Is Nothing) Then
                        Message = "Must fill Email"
                        Valid = False
                    ElseIf (header.PIC_Name Is Nothing) Then
                        Message = "Must fill PIC Name"
                        Valid = False
                    ElseIf (header.PIC_Phone Is Nothing) Then
                        Message = "Must fill PIC Phone"
                        Valid = False
                    ElseIf (header.PIC_Email Is Nothing) Then
                        Message = "Must fill PIC Email"
                        Valid = False
                    ElseIf (header.Credit_Rating Is Nothing) Then
                        Message = "Must fill Credit Rating "
                        Valid = False
                    End If
                End If
            End If
            If Valid Then
                If (If(header.ProspectCategory_ID, 0) = 0) Then
                    Message = "Must fill Category"
                    Valid = False
                ElseIf (header.DateTrans Is Nothing) Then
                    Message = "Must fill Date"
                    Valid = False
                ElseIf (header.DateTransTime Is Nothing) Then
                    Message = "Must fill Time"
                    Valid = False
                ElseIf header.Status = "Finish" And order Is Nothing Then
                    Message = "Must fill Vehicle"
                    Valid = False
                End If
            End If


#End Region

            If Valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        prospectCustomer.IsExists = header.IsExists
                        If header.IsExists Then
                            prospectCustomer.CustomerExists_ID = IIf(header.CustomerExists_ID = 0, Nothing, header.CustomerExists_ID)
                        Else
                            prospectCustomer.CompanyGroup_ID = IIf(header.CompanyGroup_ID = 0, Nothing, header.CompanyGroup_ID)
                            prospectCustomer.Company_Name = header.Company_Name
                            prospectCustomer.PT = IIf(header.PT = "", Nothing, header.PT)
                            prospectCustomer.Tbk = header.Tbk
                            prospectCustomer.Address = header.Address
                            prospectCustomer.City_id = IIf(header.City_id = 0, Nothing, header.City_id)
                            prospectCustomer.Phone = header.Phone
                            prospectCustomer.Email = header.Email
                            prospectCustomer.PIC_Name = header.PIC_Name
                            prospectCustomer.PIC_Phone = header.PIC_Phone
                            prospectCustomer.PIC_Email = header.PIC_Email
                            prospectCustomer.Credit_Rating = header.Credit_Rating
                        End If
                        prospectCustomer.Status = header.Status
                        prospectCustomer.Notes = header.Notes
                        prospectCustomer.IsQuotation = False
                        prospectCustomer.IsApplicationPO = False
                        prospectCustomer.CreatedBy = user
                        prospectCustomer.CreatedDate = DateTime.Now
                        prospectCustomer.IsDeleted = False
                        db.Tr_ProspectCusts.Add(prospectCustomer)
                        If Not order Is Nothing Then
                            Dim noForGroup = 1
                            For Each item In order
                                If item.IsMultiCalculated Then
                                    Dim luup = {12, 24, 36, 48, 60}
                                    For Each i In luup
                                        Dim D As New Tr_ProspectCustDetails With {
                                    .ProspectCustomer_ID = prospectCustomer.ProspectCustomer_ID,
                                    .Transaction_Type = item.Transaction_Type,
                                    .IsVehicleExists = item.IsVehicleExists,
                                    .VehicleExists_ID = IIf(item.VehicleExists_ID Is Nothing, Nothing, item.VehicleExists_ID),
                                    .Brand_ID = IIf(item.Brand_ID Is Nothing, Nothing, item.Brand_ID),
                                    .Model_ID = IIf(item.Model_ID Is Nothing, Nothing, item.Model_ID),
                                    .IsJakarta = IIf(item.IsJakarta Is Nothing, Nothing, item.IsJakarta),
                                    .Lease_price = item.Lease_price,
                                    .Qty = item.Qty,
                                    .IsMultiCalculated = item.IsMultiCalculated,
                                    .MultiCalculateGroup = noForGroup,
                                    .Year = item.Year,
                                    .Lease_long = i,
                                    .IsCalculate = False,
                                    .CreatedBy = user,
                                    .CreatedDate = DateTime.Now,
                                    .IsDeleted = False
                                    }
                                        db.Tr_ProspectCustDetails.Add(D)
                                    Next
                                Else
                                    Dim D As New Tr_ProspectCustDetails With {
                                .ProspectCustomer_ID = prospectCustomer.ProspectCustomer_ID,
                                .Transaction_Type = item.Transaction_Type,
                                .IsVehicleExists = item.IsVehicleExists,
                                .VehicleExists_ID = IIf(item.VehicleExists_ID Is Nothing, Nothing, item.VehicleExists_ID),
                                .Brand_ID = IIf(item.Brand_ID Is Nothing, Nothing, item.Brand_ID),
                                .Model_ID = IIf(item.Model_ID Is Nothing, Nothing, item.Model_ID),
                                .IsJakarta = IIf(item.IsJakarta Is Nothing, Nothing, item.IsJakarta),
                                .Lease_price = item.Lease_price,
                                .Qty = item.Qty,
                                .IsMultiCalculated = False,
                                .Year = item.Year,
                                .Lease_long = item.Lease_long,
                                .IsCalculate = False,
                                .CreatedBy = user,
                                .CreatedDate = DateTime.Now,
                                .IsDeleted = False
                                }
                                    db.Tr_ProspectCustDetails.Add(D)
                                End If
                                noForGroup += 1
                            Next
                        End If
                        Dim prospectCustHistory As New Tr_ProspectCustHistorys
                        prospectCustHistory.ProspectCustomer_ID = prospectCustomer.ProspectCustomer_ID
                        prospectCustHistory.Status = header.Status
                        prospectCustHistory.ProspectCategory_ID = header.ProspectCategory_ID
                        Dim DateTransJoin = header.DateTrans + header.DateTransTime
                        prospectCustHistory.DateTrans = DateTransJoin
                        prospectCustHistory.Notes = header.Notes
                        prospectCustHistory.CreatedBy = user
                        prospectCustHistory.CreatedDate = DateTime.Now
                        prospectCustHistory.IsDeleted = False
                        prospectCustHistory.IsChecked = False
                        db.Tr_ProspectCustHistorys.Add(prospectCustHistory)
                        db.SaveChanges()
                        result = "Success"
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using


            End If
            Return Json(New With {Key .result = result, Key .messages = Message}, JsonRequestBehavior.AllowGet)
        End Function

        Public Function GetVehicle(searchTerm As String) As JsonResult
            Dim vehicle = db.Ms_Vehicles.Where(Function(x) x.license_no.Contains(searchTerm) And x.Model_ID IsNot Nothing).ToList()
            Dim data = (vehicle.OrderBy(Function(x) x.license_no).Select(Function(x) New With {.id = x.Vehicle_id, .text = x.license_no})).Take(5)
            Return Json(data, JsonRequestBehavior.AllowGet)
        End Function

        ' GET: Prospect/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ProspectCusts As Tr_ProspectCusts = Await db.Tr_ProspectCusts.FindAsync(id)
            If IsNothing(tr_ProspectCusts) Then
                Return HttpNotFound()
            End If
            Dim tr_ProspectCust As New Tr_ProspectCust
            tr_ProspectCust.ProspectCustomer_ID = id
            tr_ProspectCust.IsExists = tr_ProspectCusts.IsExists
            tr_ProspectCust.CustomerExists_ID = tr_ProspectCusts.CustomerExists_ID
            tr_ProspectCust.CompanyGroup_ID = tr_ProspectCusts.CompanyGroup_ID
            tr_ProspectCust.Company_Name = tr_ProspectCusts.Company_Name
            tr_ProspectCust.PT = tr_ProspectCusts.PT
            tr_ProspectCust.Tbk = tr_ProspectCusts.Tbk
            tr_ProspectCust.Address = tr_ProspectCusts.Address
            tr_ProspectCust.City_id = tr_ProspectCusts.City_id
            tr_ProspectCust.Phone = tr_ProspectCusts.Phone
            tr_ProspectCust.Email = tr_ProspectCusts.Email
            tr_ProspectCust.PIC_Name = tr_ProspectCusts.PIC_Name
            tr_ProspectCust.PIC_Phone = tr_ProspectCusts.PIC_Phone
            tr_ProspectCust.PIC_Email = tr_ProspectCusts.PIC_Email
            tr_ProspectCust.Credit_Rating = tr_ProspectCusts.Credit_Rating
            tr_ProspectCust.DateTrans = Now
            tr_ProspectCust.DateTransTime = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
            Dim detail = From A In db.Tr_ProspectCustDetails
                         Group Join B In db.Ms_Vehicles On A.VehicleExists_ID Equals B.Vehicle_id Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Vehicle_Brands On A.Brand_ID Equals C.Brand_ID Into AC = Group
                         From C In AC.DefaultIfEmpty
                         Group Join D In db.Ms_Vehicle_Models On A.Model_ID Equals D.Model_ID Into AD = Group
                         From D In AD.DefaultIfEmpty
                         Where A.ProspectCustomer_ID = id And A.IsDeleted = False
                         Select A.ProspectCustomerDetail_ID, A.Transaction_Type, A.ProspectCustomer_ID, A.IsVehicleExists, A.VehicleExists_ID, B.license_no, A.Brand_ID, C.Brand_Name, A.Model_ID, D.Type,
                            A.Lease_price, A.Qty, A.Year, A.Lease_long, A.IsJakarta
            ViewBag.detail = detail
            ViewBag.PT = New SelectList(customer.myPT, "Value", "Text", tr_ProspectCusts.PT)
            Dim myTbk As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Tbk",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Tbk",
                    .Value = False
                }
            }
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", tr_ProspectCusts.Tbk)
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                }
            }
            ViewBag.City_id = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False), "City_ID", "City", tr_ProspectCusts.City_id)
            Dim myType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "OPL",
                    .Value = "OPL"
                },
                New SelectListItem With {
                    .Text = "COP",
                    .Value = "COP"
                }
            }
            ViewBag.Transaction_Type = New SelectList(myType, "Value", "Text")
            ViewBag.VehicleExists_ID = New SelectList(db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False), "Vehicle_id", "license_no")
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Brand_Name), "Brand_ID", "Brand_Name")
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Type), "Model_ID", "Type")
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name", tr_ProspectCusts.CompanyGroup_ID)
            ViewBag.CustomerExists_ID = New SelectList(db.sp_GetCustomerFromUser(Session("ID")), "Customer_ID", "Company_Name", tr_ProspectCusts.CustomerExists_ID)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", tr_ProspectCusts.Credit_Rating)
            Dim myJakarta As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jakarta",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Jakarta",
                    .Value = False
                }
            }
            ViewBag.IsJakarta = New SelectList(myJakarta, "Value", "Text")
            Return View(tr_ProspectCust)
        End Function
        Public Function EditOrder(orderHD() As Tr_ProspectCust, order() As Tr_ProspectCustDetails, delete() As Tr_ProspectCustDetails) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim header = orderHD.FirstOrDefault
            Dim prospectCustomer = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = header.ProspectCustomer_ID).FirstOrDefault
            Dim result As String = "Error"
            'Validasi
            Dim Valid As Boolean = True
            Dim Message As String = ""
            'jika Open tidak harus semua diisi
            'If (header.IsExists And header.CustomerExists_ID = 0) Then
            '    Message = "Must fill Customer Exists"
            '    Valid = False
            'ElseIf (Not header.IsExists And (header.CompanyGroup_ID = 0)) Then
            '    Message = "Must fill Company Group"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.PT = Nothing) Then
            '    Message = "Must fill PT"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Tbk Is Nothing) Then
            '    Message = "Must fill TBK"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Company_Name Is Nothing) Then
            '    Message = "Must fill Company Name"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Company_Name.Length > 50) Then
            '    Message = "Company Name cant not be more than 50 characters"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Address Is Nothing) Then
            '    Message = "Must fill Address"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.City_id Is Nothing) Then
            '    Message = "Must fill City"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Phone Is Nothing) Then
            '    Message = "Must fill Phone"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Email Is Nothing) Then
            '    Message = "Must fill Email"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.PIC_Name Is Nothing) Then
            '    Message = "Must fill PIC Name"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.PIC_Phone Is Nothing) Then
            '    Message = "Must fill PIC Phone"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.PIC_Email Is Nothing) Then
            '    Message = "Must fill PIC Email"
            '    Valid = False
            'ElseIf (Not header.IsExists And header.Credit_Rating Is Nothing) Then
            '    Message = "Must fill Credit Rating "
            '    Valid = False
            'ElseIf order Is Nothing Then
            '    Message = "Must fill Vehicle"
            '    Valid = False
            'End If
            If header.IsExists Then
                If (header.CustomerExists_ID = 0) Then
                    Message = "Must fill Customer Exists"
                    Valid = False
                End If
            Else
                If ((header.CompanyGroup_ID = 0)) Then
                    Message = "Must fill Company Group"
                    Valid = False
                ElseIf (header.PT = Nothing) Then
                    Message = "Must fill PT"
                    Valid = False
                ElseIf header.Tbk Is Nothing Then
                    Message = "Must fill TBK"
                    Valid = False
                ElseIf header.Company_Name = "" Then
                    Message = "Must fill Company Name"
                    Valid = False
                ElseIf header.Company_Name.Length > 50 Then
                    Message = "Company Name cant not be more than 50 characters"
                    Valid = False
                ElseIf header.Status = "Finish" Then
                    If (header.Address Is Nothing) Then
                        Message = "Must fill Address"
                        Valid = False
                    ElseIf (header.City_id Is Nothing) Then
                        Message = "Must fill City"
                        Valid = False
                    ElseIf (header.Phone Is Nothing) Then
                        Message = "Must fill Phone"
                        Valid = False
                    ElseIf (header.Email Is Nothing) Then
                        Message = "Must fill Email"
                        Valid = False
                    ElseIf (header.PIC_Name Is Nothing) Then
                        Message = "Must fill PIC Name"
                        Valid = False
                    ElseIf (header.PIC_Phone Is Nothing) Then
                        Message = "Must fill PIC Phone"
                        Valid = False
                    ElseIf (header.PIC_Email Is Nothing) Then
                        Message = "Must fill PIC Email"
                        Valid = False
                    ElseIf (header.Credit_Rating Is Nothing) Then
                        Message = "Must fill Credit Rating "
                        Valid = False
                    End If
                End If
            End If
            'If Valid Then
            '    If (header.DateTrans Is Nothing) Then
            '        Message = "Must fill Date"
            '        Valid = False
            '    ElseIf (header.DateTransTime Is Nothing) Then
            '        Message = "Must fill Time"
            '        Valid = False
            '    ElseIf header.Status = "Finish" And order Is Nothing Then
            '        Message = "Must fill Vehicle"
            '        Valid = False
            '    End If
            'End If


            If Not delete Is Nothing Then
                'Check IsCalculate
                For Each item In delete
                    Dim D = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = item.ProspectCustomerDetail_ID).FirstOrDefault()
                    If D.IsCalculate = True Then
                        Valid = False
                        Message = "Do not delete what has been calculate"
                    End If
                Next
            End If

            If Valid Then
                prospectCustomer.IsExists = header.IsExists
                If header.IsExists Then
                    prospectCustomer.CustomerExists_ID = IIf(header.CustomerExists_ID = 0, Nothing, header.CustomerExists_ID)
                Else
                    prospectCustomer.CompanyGroup_ID = IIf(header.CompanyGroup_ID = 0, Nothing, header.CompanyGroup_ID)
                    prospectCustomer.Company_Name = header.Company_Name
                    prospectCustomer.PT = header.PT
                    prospectCustomer.Tbk = header.Tbk
                    prospectCustomer.Address = header.Address
                    prospectCustomer.City_id = header.City_id
                    prospectCustomer.Phone = header.Phone
                    prospectCustomer.Email = header.Email
                    prospectCustomer.PIC_Name = header.PIC_Name
                    prospectCustomer.PIC_Phone = header.PIC_Phone
                    prospectCustomer.PIC_Email = header.PIC_Email
                    prospectCustomer.Credit_Rating = header.Credit_Rating
                End If
                prospectCustomer.ModifiedBy = user
                prospectCustomer.ModifiedDate = DateTime.Now

                If Not delete Is Nothing Then
                    'Ubah IsDeleted
                    For Each item In delete
                        If (item.ProspectCustomerDetail_ID <> 0) Then
                            Dim D = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = item.ProspectCustomerDetail_ID).FirstOrDefault()
                            D.ModifiedBy = user
                            D.ModifiedDate = DateTime.Now
                            D.IsDeleted = True
                        End If
                    Next
                End If
                If order IsNot Nothing Then
                    For Each item In order
                        If (item.ProspectCustomerDetail_ID = 0) Then
                            Dim D As New Tr_ProspectCustDetails
                            D.ProspectCustomer_ID = header.ProspectCustomer_ID
                            D.Transaction_Type = item.Transaction_Type
                            D.IsVehicleExists = item.IsVehicleExists
                            D.VehicleExists_ID = item.VehicleExists_ID
                            D.Brand_ID = item.Brand_ID
                            D.Model_ID = item.Model_ID
                            D.IsJakarta = item.IsJakarta
                            D.Lease_price = item.Lease_price
                            D.Qty = item.Qty
                            D.Year = item.Year
                            D.Lease_long = item.Lease_long
                            D.IsMultiCalculated = False
                            D.IsCalculate = False
                            D.CreatedBy = user
                            D.CreatedDate = DateTime.Now
                            D.IsDeleted = False
                            db.Tr_ProspectCustDetails.Add(D)
                        End If
                    Next
                End If
                db.SaveChanges()
                result = "Success"
            End If
            Return Json(New With {Key .result = result, Key .messages = Message}, JsonRequestBehavior.AllowGet)
        End Function


        ' GET: Prospect/Edit/5
        Function UpdateStatus(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ProspectCusts = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = id).
                Select(Function(x) New Tr_ProspectCust With {.ProspectCustomer_ID = x.ProspectCustomer_ID, .IsExists = x.IsExists,
                           .CustomerExists_ID = x.CustomerExists_ID, .CompanyGroup_ID = x.CompanyGroup_ID, .Company_Name = x.Company_Name, .PT = x.PT,
                           .Tbk = x.Tbk, .Address = x.Address, .City_id = x.City_id, .Phone = x.Phone, .Email = x.Email, .PIC_Name = x.PIC_Name,
                           .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Credit_Rating = x.Credit_Rating, .Status = x.Status, .Notes = x.Notes}).FirstOrDefault
            If IsNothing(tr_ProspectCusts) Then
                Return HttpNotFound()
            End If
            ViewBag.PT = New SelectList(customer.myPT, "Value", "Text", tr_ProspectCusts.PT)
            Dim myTbk As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Tbk",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Tbk",
                    .Value = False
                }
            }
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", tr_ProspectCusts.Tbk)
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                },
                New SelectListItem With {
                    .Text = "Close",
                    .Value = "Close"
                }
            }
            ViewBag.Status = New SelectList(myStatus, "Value", "Text", tr_ProspectCusts.Status)
            ViewBag.City_id = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False), "City_ID", "City", tr_ProspectCusts.City_id)
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False), "CompanyGroup_ID", "CompanyGroup_Name", tr_ProspectCusts.CompanyGroup_ID)
            ViewBag.CustomerExists_ID = New SelectList(db.sp_GetCustomerFromUser(Session("ID")), "Customer_ID", "Company_Name", tr_ProspectCusts.CustomerExists_ID)
            ViewBag.ProspectCategory_ID = New SelectList(db.Ms_ProspectCategorys.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.ProspectCategory), "ProspectCategory_ID", "ProspectCategory")
            tr_ProspectCusts.DateTrans = Now
            tr_ProspectCusts.DateTransTime = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
            Return View(tr_ProspectCusts)
        End Function

        ' POST: Prospect/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function UpdateStatus(<Bind(Include:="ProspectCustomer_ID,IsExists,CustomerExists_ID,CompanyGroup_ID,Company_Name,PT,Tbk,Address,City_id,Phone,Email,PIC_Name,PIC_Phone,PIC_Email,Credit_Rating,Notes,Status,ProspectCategory_ID,DateTrans,DateTransTime,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_ProspectCusts As Tr_ProspectCust) As ActionResult
            If ModelState.IsValid Then
                Dim cekdetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomer_ID = tr_ProspectCusts.ProspectCustomer_ID).Count
                If cekdetail = 0 And tr_ProspectCusts.Status = "Finish" Then
                    ModelState.AddModelError("Status", "You have not entered a vehicle")
                Else
                    Dim user As String
                    If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                    Dim prospect = db.Tr_ProspectCusts.FirstOrDefault(Function(p) (p.ProspectCustomer_ID = tr_ProspectCusts.ProspectCustomer_ID))
                    If (prospect Is Nothing) Then
                        Return HttpNotFound()
                    End If
                    prospect.Status = tr_ProspectCusts.Status
                    prospect.Notes = tr_ProspectCusts.Notes
                    prospect.ModifiedBy = user
                    prospect.ModifiedDate = DateTime.Now
                    Dim history = New Tr_ProspectCustHistorys
                    history.ProspectCustomer_ID = tr_ProspectCusts.ProspectCustomer_ID
                    history.Status = tr_ProspectCusts.Status
                    history.ProspectCategory_ID = tr_ProspectCusts.ProspectCategory_ID
                    Dim DateTransJoin = tr_ProspectCusts.DateTrans + tr_ProspectCusts.DateTransTime
                    history.DateTrans = DateTransJoin
                    history.Notes = tr_ProspectCusts.Notes
                    history.DateTrans = Now.Date
                    history.CreatedBy = user
                    history.CreatedDate = DateTime.Now
                    history.IsDeleted = False
                    history.IsChecked = False
                    db.Tr_ProspectCustHistorys.Add(history)
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                End If
            End If
            ViewBag.PT = New SelectList(customer.myPT, "Value", "Text", tr_ProspectCusts.PT)
            Dim myTbk As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Tbk",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Tbk",
                    .Value = False
                }
            }
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", tr_ProspectCusts.Tbk)
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                },
                New SelectListItem With {
                    .Text = "Close",
                    .Value = "Close"
                }
            }
            ViewBag.Status = New SelectList(myStatus, "Value", "Text", tr_ProspectCusts.Status)
            ViewBag.City_id = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False), "City_ID", "City", tr_ProspectCusts.City_id)
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False), "CompanyGroup_ID", "CompanyGroup_Name", tr_ProspectCusts.CompanyGroup_ID)
            ViewBag.CustomerExists_ID = New SelectList(db.sp_GetCustomerFromUser(Session("ID")), "Customer_ID", "Company_Name", tr_ProspectCusts.CustomerExists_ID)
            ViewBag.ProspectCategory_ID = New SelectList(db.Ms_ProspectCategorys.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.ProspectCategory), "ProspectCategory_ID", "ProspectCategory", tr_ProspectCusts.ProspectCategory_ID)

            Return View(tr_ProspectCusts)
        End Function

        ' GET: Prospect/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_ProspectCusts As V_ProspectCusts = db.V_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = id).FirstOrDefault()
            If IsNothing(tr_ProspectCusts) Then
                Return HttpNotFound()
            End If
            Dim tr_ProspectCust As New Tr_ProspectCust
            tr_ProspectCust.ProspectCustomer_ID = id
            tr_ProspectCust.IsExists = tr_ProspectCusts.IsExists
            tr_ProspectCust.CompanyGroup_ID = tr_ProspectCusts.CompanyGroup_ID
            tr_ProspectCust.CompanyGroup_Name = tr_ProspectCusts.CompanyGroup_Name
            tr_ProspectCust.Company_Name = tr_ProspectCusts.Company_Name
            tr_ProspectCust.PT = tr_ProspectCusts.PT
            tr_ProspectCust.Tbk = tr_ProspectCusts.Tbk
            tr_ProspectCust.Address = tr_ProspectCusts.Address
            tr_ProspectCust.City = tr_ProspectCusts.City
            tr_ProspectCust.Phone = tr_ProspectCusts.Phone
            tr_ProspectCust.Email = tr_ProspectCusts.Email
            tr_ProspectCust.PIC_Name = tr_ProspectCusts.PIC_Name
            tr_ProspectCust.PIC_Phone = tr_ProspectCusts.PIC_Phone
            tr_ProspectCust.PIC_Email = tr_ProspectCusts.PIC_Email
            tr_ProspectCust.Notes = tr_ProspectCusts.Notes
            tr_ProspectCust.CreatedDate = tr_ProspectCusts.CreatedDate
            tr_ProspectCust.CreatedBy = tr_ProspectCusts.CreatedBy
            tr_ProspectCust.ModifiedDate = tr_ProspectCusts.ModifiedDate
            tr_ProspectCust.ModifiedBy = tr_ProspectCusts.ModifiedByName
            Return View(tr_ProspectCust)
        End Function

        ' POST: Prospect/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim Pros As Tr_ProspectCusts = db.Tr_ProspectCusts.Find(id)
            Pros.ModifiedBy = user
            Pros.ModifiedDate = DateTime.Now
            Pros.IsDeleted = True
            'Delete detail
            Dim detail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomer_ID = id).ToList
            For Each i In detail
                Dim updateDetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = i.ProspectCustomerDetail_ID).FirstOrDefault
                updateDetail.ModifiedBy = user
                updateDetail.ModifiedDate = DateTime.Now
                updateDetail.IsDeleted = True
                Dim updateCalDetail = db.Tr_Calculates.Where(Function(x) x.ProspectCustomerDetail_ID = i.ProspectCustomerDetail_ID).FirstOrDefault
                If updateCalDetail IsNot Nothing Then
                    updateCalDetail.ModifiedBy = user
                    updateCalDetail.ModifiedDate = DateTime.Now
                    updateCalDetail.IsDeleted = True
                End If
            Next
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
