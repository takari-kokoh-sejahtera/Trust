Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports LumenWorks.Framework.IO.Csv
Imports PagedList
Imports Trust

Namespace Controllers
    Public Class CustomerController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Public myPT As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PT",
                    .Value = "PT"
                },
                New SelectListItem With {
                    .Text = "CV",
                    .Value = "CV"
                },
                New SelectListItem With {
                    .Text = "Perum Peruri",
                    .Value = "Perum Peruri"
                },
                New SelectListItem With {
                    .Text = "Yayasan",
                    .Value = "Yayasan"
                },
                New SelectListItem With {
                    .Text = "UD",
                    .Value = "UD"
                },
                New SelectListItem With {
                    .Text = "",
                    .Value = ""
                }
            }

        ' GET: Customer
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
            Dim customer = From A In db.Ms_Customers.Where(Function(x) x.IsDeleted = False)
            If Not String.IsNullOrEmpty(searchString) Then
                customer = customer.Where(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    customer = customer.OrderBy(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name)
                Case "Company_Name"
                    customer = customer.OrderBy(Function(s) s.Company_Name)
                Case Else
                    customer = customer.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(customer.ToPagedList(pageNumber, pageSize))
        End Function
        Function IndexPublished(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            Dim customer = From A In db.Ms_Customers.Where(Function(x) x.IsDeleted = False)
            If Not String.IsNullOrEmpty(searchString) Then
                customer = customer.Where(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    customer = customer.OrderBy(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name)
                Case "Company_Name"
                    customer = customer.OrderBy(Function(s) s.Company_Name)
                Case Else
                    customer = customer.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(customer.ToPagedList(pageNumber, pageSize))
        End Function
        Function IndexChangeOwnership(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            Dim customer = From A In db.Ms_Customers.Where(Function(x) x.IsDeleted = False)
            If Not String.IsNullOrEmpty(searchString) Then
                customer = customer.Where(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    customer = customer.OrderBy(Function(s) s.Ms_Customer_CompanyGroups.CompanyGroup_Name)
                Case "Company_Name"
                    customer = customer.OrderBy(Function(s) s.Company_Name)
                Case Else
                    customer = customer.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(customer.ToPagedList(pageNumber, pageSize))
        End Function

        Function ChangeOwnership(ByVal id As Integer?) As ActionResult
#If DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Session("User_ID") = "System"
#Else
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            If IsNothing(ms_Customers) Then
                Return HttpNotFound()
            End If

            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False).OrderBy(Function(z) z.Company_Name), "Customer_ID", "Company_Name", id)
            ViewBag.CreatedBy = New SelectList(db.Cn_Users.Where(Function(x) x.Division_ID = 1).OrderBy(Function(z) z.User_Name), "User_ID", "User_Name", ms_Customers.CreatedBy)
            Return View()
        End Function

        ' POST: Customer/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function ChangeOwnership(ms_Customers As Ms_Customer_ChangeOwnership) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_Customer = db.Ms_Customers.Where(Function(x) x.Customer_ID = ms_Customers.Customer_ID).FirstOrDefault
                ms_Customer.CreatedBy = ms_Customers.CreatedBy
                ms_Customer.ModifiedBy = user
                ms_Customer.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("IndexChangeOwnership")
            End If

            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False).OrderBy(Function(z) z.Company_Name), "Customer_ID", "Company_Name", ms_Customers.Customer_ID)
            ViewBag.CreatedBy = New SelectList(db.Cn_Users.Where(Function(x) x.Division_ID = 1).OrderBy(Function(z) z.User_Name), "User_ID", "User_Name", ms_Customers.CreatedBy)
            Return View()
        End Function



#Region "BUat Show data csv"
        Function Upload() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Upload(uploaded As HttpPostedFileBase) As ActionResult
            If ModelState.IsValid Then
                If (uploaded IsNot Nothing And uploaded.ContentLength > 0) Then
                    If (uploaded.FileName.EndsWith(".csv")) Then
                        Dim stream = uploaded.InputStream
                        Dim csvTable = New DataTable()
                        Using csvReader = New CsvReader(New StreamReader(stream), True)
                            csvTable.Load(csvReader)
                        End Using
                        Return View(csvTable)
                    Else
                        ModelState.AddModelError("File", "This file format is not supported")
                        Return View()
                    End If
                End If
            Else
                ModelState.AddModelError("File", "Please Upload Your file")
            End If
            Return View()
        End Function
#End Region


        ' GET: Customer/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            If IsNothing(ms_Customers) Then
                Return HttpNotFound()
            End If
            Return View(ms_Customers)
        End Function

        ' GET: Customer/Create
        Function Create() As ActionResult
#If DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Session("User_ID") = "System"
#Else
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If

            ViewBag.PT = New SelectList(myPT, "Value", "Text")
            'Dim myContracted_by As List(Of SelectListItem) = New List(Of SelectListItem)() From {
            '    New SelectListItem With {
            '        .Text = "PT Takari Kokoh Sejahtera",
            '        .Value = "PT Takari Kokoh Sejahtera"
            '    },
            '    New SelectListItem With {
            '        .Text = "PT Takari Sumber Mulia",
            '        .Value = "PT Takari Sumber Mulia"
            '    }
            '}
            'ViewBag.Contracted_by = New SelectList(myContracted_by, "Value", "Text")
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
            Dim Customer_Class As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Japanese",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non-Japanese",
                    .Value = False
                }
            }
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text")
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name")
            ViewBag.City_ID = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "City_ID", "City")
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key")
            Return View()
        End Function

        ' POST: Customer/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Customer_ID,CompanyGroup_ID,Company_Name,PT,Tbk,Address,Line_of_Business,City_ID,Phone,Email,PIC_Name,PIC_Phone,PIC_Email,Notes,Customer_Class,Credit_Rating,Authorized_Capital,Authorized_CapitalStr,Authorized_Signer_Name1,Authorized_Signer_Position1,Authorized_Signer_Name2,Authorized_Signer_Position2,IntroducedBy,NPWP,Account,Bank,IsStamped,Status,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Customers As Ms_Customer) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_Customer As New Ms_Customers
                ms_Customer.CompanyGroup_ID = ms_Customers.CompanyGroup_ID
                ms_Customer.Company_Name = ms_Customers.Company_Name
                ms_Customer.PT = ms_Customers.PT
                ms_Customer.Tbk = ms_Customers.Tbk
                ms_Customer.Address = ms_Customers.Address
                ms_Customer.City_ID = ms_Customers.City_ID
                ms_Customer.Phone = ms_Customers.Phone
                ms_Customer.Email = ms_Customers.Email
                ms_Customer.PIC_Name = ms_Customers.PIC_Name
                ms_Customer.PIC_Phone = ms_Customers.PIC_Phone
                ms_Customer.PIC_Email = ms_Customers.PIC_Email
                ms_Customer.Notes = ms_Customers.Notes
                ms_Customer.Customer_Class = ms_Customers.Customer_Class
                ms_Customer.Credit_Rating = ms_Customers.Credit_Rating
                ms_Customer.Line_of_Business = ms_Customers.Line_of_Business
                ms_Customer.Authorized_Capital = ms_Customers.Authorized_Capital
                ms_Customer.Authorized_Signer_Name1 = ms_Customers.Authorized_Signer_Name1
                ms_Customer.Authorized_Signer_Position1 = ms_Customers.Authorized_Signer_Position1
                ms_Customer.Authorized_Signer_Name2 = ms_Customers.Authorized_Signer_Name2
                ms_Customer.Authorized_Signer_Position2 = ms_Customers.Authorized_Signer_Position2
                ms_Customer.IntroducedBy = ms_Customers.IntroducedBy
                ms_Customer.NPWP = ms_Customers.NPWP
                ms_Customer.Account = ms_Customers.Account
                ms_Customer.Bank = ms_Customers.Bank
                ms_Customer.IsStamped = ms_Customers.IsStamped
                ms_Customer.CreatedBy = user
                ms_Customer.CreatedDate = DateTime.Now
                ms_Customer.IsDeleted = False
                ms_Customer.IsKYC = False
                db.Ms_Customers.Add(ms_Customer)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            'Dim myContracted_by As List(Of SelectListItem) = New List(Of SelectListItem)() From {
            '    New SelectListItem With {
            '        .Text = "PT Takari Kokoh Sejahtera",
            '        .Value = "PT Takari Kokoh Sejahtera"
            '    },
            '    New SelectListItem With {
            '        .Text = "PT Takari Sumber Mulia",
            '        .Value = "PT Takari Sumber Mulia"
            '    }
            '}
            'ViewBag.Contracted_by = New SelectList(myContracted_by, "Value", "Text", ms_Customers.Contracted_by)
            ViewBag.PT = New SelectList(myPT, "Value", "Text", ms_Customers.PT)
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
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", ms_Customers.Tbk)
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
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", ms_Customers.Customer_Class)

            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name", ms_Customers.CompanyGroup_ID)
            ViewBag.City_ID = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "City_ID", "City", ms_Customers.City_ID)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key")
            Return View(ms_Customers)
        End Function
        ' GET: Customer/Edit/5
        Function EditPublished(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            If IsNothing(ms_Customers) Then
                Return HttpNotFound()
            End If
            Dim ms_Customer As New Ms_CustomerPublisher
            ms_Customer.Customer_ID = ms_Customers.Customer_ID
            ms_Customer.Company_Name = ms_Customers.Company_Name
            ms_Customer.Published = ms_Customers.Published
            Return View(ms_Customer)
        End Function

        ' POST: Customer/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditPublished(<Bind(Include:="Customer_ID,Company_Name,Published")> ByVal ms_Customers As Ms_CustomerPublisher) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim customer = db.Ms_Customers.FirstOrDefault(Function(p) (p.Customer_ID = ms_Customers.Customer_ID))
                If (user Is Nothing) Then
                    Return HttpNotFound()
                End If
                customer.Published = ms_Customers.Published
                customer.ModifiedBy = user
                customer.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("IndexPublished")
            End If
            Return View(ms_Customers)
        End Function
        ' GET: Customer/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            If IsNothing(ms_Customers) Then
                Return HttpNotFound()
            End If
            Dim ms_Customer As New Ms_Customer
            ms_Customer.Customer_ID = ms_Customers.Customer_ID
            ms_Customer.CompanyGroup_ID = ms_Customers.CompanyGroup_ID
            ms_Customer.Company_Name = ms_Customers.Company_Name
            ms_Customer.PT = ms_Customers.PT
            ms_Customer.Tbk = ms_Customers.Tbk
            ms_Customer.Address = ms_Customers.Address
            ms_Customer.City_ID = ms_Customers.City_ID
            ms_Customer.Phone = ms_Customers.Phone
            ms_Customer.Email = ms_Customers.Email
            ms_Customer.PIC_Name = ms_Customers.PIC_Name
            ms_Customer.PIC_Phone = ms_Customers.PIC_Phone
            ms_Customer.PIC_Email = ms_Customers.PIC_Email
            ms_Customer.Notes = ms_Customers.Notes
            ms_Customer.Customer_Class = ms_Customers.Customer_Class
            ms_Customer.Credit_Rating = ms_Customers.Credit_Rating
            ms_Customer.Line_of_Business = ms_Customers.Line_of_Business
            ms_Customer.Authorized_Capital = ms_Customers.Authorized_Capital
            ms_Customer.Authorized_Signer_Name1 = ms_Customers.Authorized_Signer_Name1
            ms_Customer.Authorized_Signer_Position1 = ms_Customers.Authorized_Signer_Position1
            ms_Customer.Authorized_Signer_Name2 = ms_Customers.Authorized_Signer_Name2
            ms_Customer.Authorized_Signer_Position2 = ms_Customers.Authorized_Signer_Position2
            ms_Customer.IntroducedBy = ms_Customers.IntroducedBy
            ms_Customer.NPWP = ms_Customers.NPWP
            ms_Customer.Account = ms_Customers.Account
            ms_Customer.Bank = ms_Customers.Bank
            ms_Customer.IsStamped = ms_Customers.IsStamped

            ViewBag.PT = New SelectList(myPT, "Value", "Text", ms_Customers.PT)
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
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", ms_Customers.Tbk)
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
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", ms_Customers.Customer_Class)
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name", ms_Customers.CompanyGroup_ID)
            ViewBag.City_ID = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "City_ID", "City", ms_Customers.City_ID)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating).ToList, "Key", "Key", ms_Customers.Credit_Rating)
            Return View(ms_Customer)
        End Function

        ' POST: Customer/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Customer_ID,CompanyGroup_ID,Company_Name,PT,Tbk,Address,Line_of_Business,City_ID,Phone,Email,PIC_Name,PIC_Phone,PIC_Email,Notes,Customer_Class,Credit_Rating,Authorized_Capital,Authorized_CapitalStr,Authorized_Signer_Name1,Authorized_Signer_Position1,Authorized_Signer_Name2,Authorized_Signer_Position2,IntroducedBy,NPWP,Account,Bank,IsStamped,Status,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Customers As Ms_Customer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim customer = db.Ms_Customers.FirstOrDefault(Function(p) (p.Customer_ID = ms_Customers.Customer_ID))
                If (user Is Nothing) Then
                    Return HttpNotFound()
                End If

                customer.CompanyGroup_ID = ms_Customers.CompanyGroup_ID
                customer.Company_Name = ms_Customers.Company_Name
                customer.Address = ms_Customers.Address
                customer.City_ID = ms_Customers.City_ID
                customer.Phone = ms_Customers.Phone
                customer.Email = ms_Customers.Email
                customer.PIC_Name = ms_Customers.PIC_Name
                customer.PIC_Phone = ms_Customers.PIC_Phone
                customer.PIC_Email = ms_Customers.PIC_Email
                customer.Notes = ms_Customers.Notes
                customer.Customer_Class = ms_Customers.Customer_Class
                customer.Credit_Rating = ms_Customers.Credit_Rating
                customer.Authorized_Capital = ms_Customers.Authorized_Capital
                customer.Line_of_Business = ms_Customers.Line_of_Business
                customer.Authorized_Signer_Name1 = ms_Customers.Authorized_Signer_Name1
                customer.Authorized_Signer_Position1 = ms_Customers.Authorized_Signer_Position1
                customer.Authorized_Signer_Name2 = ms_Customers.Authorized_Signer_Name2
                customer.Authorized_Signer_Position2 = ms_Customers.Authorized_Signer_Position2
                customer.IntroducedBy = ms_Customers.IntroducedBy
                customer.NPWP = ms_Customers.NPWP
                customer.Account = ms_Customers.Account
                customer.Bank = ms_Customers.Bank
                customer.IsStamped = ms_Customers.IsStamped
                customer.Status = ms_Customers.Status
                customer.PT = ms_Customers.PT
                customer.Tbk = ms_Customers.Tbk
                customer.ModifiedBy = user
                customer.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.PT = New SelectList(myPT, "Value", "Text", ms_Customers.PT)
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
            ViewBag.Tbk = New SelectList(myTbk, "Value", "Text", ms_Customers.Tbk)
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
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", ms_Customers.Customer_Class)
            ViewBag.CompanyGroup_ID = New SelectList(db.Ms_Customer_CompanyGroups.OrderBy(Function(x) x.CompanyGroup_Name), "CompanyGroup_ID", "CompanyGroup_Name", ms_Customers.CompanyGroup_ID)
            ViewBag.City_ID = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "City_ID", "City", ms_Customers.City_ID)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", ms_Customers.Credit_Rating)
            Return View(ms_Customers)
        End Function

        ' GET: Customer/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            If IsNothing(ms_Customers) Then
                Return HttpNotFound()
            End If
            Return View(ms_Customers)
        End Function

        ' POST: Customer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim ms_Customers As Ms_Customers = db.Ms_Customers.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            ms_Customers.ModifiedBy = user
            ms_Customers.ModifiedDate = DateTime.Now
            ms_Customers.IsDeleted = True
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
