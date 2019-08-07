Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PagedList
Imports Trust

Namespace Controllers
    Public Class BrandController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Brand
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
            Dim brand = From s In db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False) Select s
            If Not String.IsNullOrEmpty(searchString) Then
                brand = brand.Where(Function(s) s.Brand_Name.Contains(searchString) OrElse s.Description.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Brand_Name"
                    brand = brand.OrderBy(Function(s) s.Brand_Name)
                Case "Description"
                    brand = brand.OrderBy(Function(s) s.Description)
                Case Else
                    brand = brand.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(brand.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Brand/Details/5
        Function Details(ByVal id As Integer?) As ActionResult

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Brands As Ms_Vehicle_Brands = db.Ms_Vehicle_Brands.Find(id)
            If IsNothing(ms_Vehicle_Brands) Then
                Return HttpNotFound()
            End If
            Return View(ms_Vehicle_Brands)
        End Function

        ' GET: Brand/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Return View()
        End Function

        ' POST: Brand/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Brand_ID,Brand_Name,Description,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle_Brand As Ms_Vehicle_Brand) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_Vehicle_Brands As New Ms_Vehicle_Brands
                ms_Vehicle_Brands.Brand_Name = ms_Vehicle_Brand.Brand_Name
                ms_Vehicle_Brands.Description = ms_Vehicle_Brand.Description
                ms_Vehicle_Brands.CreatedBy = user
                ms_Vehicle_Brands.CreatedDate = DateTime.Now
                ms_Vehicle_Brands.IsDeleted = False
                db.Ms_Vehicle_Brands.Add(ms_Vehicle_Brands)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_Vehicle_Brand)
        End Function

        ' GET: Brand/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Brands As Ms_Vehicle_Brands = db.Ms_Vehicle_Brands.Find(id)
            If IsNothing(ms_Vehicle_Brands) Then
                Return HttpNotFound()
            End If
            Dim ms_Vehicle_Brand As New Ms_Vehicle_Brand
            ms_Vehicle_Brand.Brand_ID = ms_Vehicle_Brands.Brand_ID
            ms_Vehicle_Brand.Brand_Name = ms_Vehicle_Brands.Brand_Name
            ms_Vehicle_Brand.Description = ms_Vehicle_Brands.Description
            Return View(ms_Vehicle_Brand)
        End Function

        ' POST: Brand/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Brand_ID,Brand_Name,Description,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle_Brands As Ms_Vehicle_Brand) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim brand = db.Ms_Vehicle_Brands.FirstOrDefault(Function(p) (p.Brand_ID = ms_Vehicle_Brands.Brand_ID))
                If (brand Is Nothing) Then
                    Return HttpNotFound()
                End If
                brand.Brand_Name = ms_Vehicle_Brands.Brand_Name
                brand.Description = ms_Vehicle_Brands.Description
                brand.ModifiedBy = user
                brand.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_Vehicle_Brands)
        End Function

        ' GET: Brand/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Brands As Ms_Vehicle_Brands = db.Ms_Vehicle_Brands.Find(id)
            If IsNothing(ms_Vehicle_Brands) Then
                Return HttpNotFound()
            End If
            Return View(ms_Vehicle_Brands)
        End Function

        ' POST: Brand/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim brand As Ms_Vehicle_Brands = db.Ms_Vehicle_Brands.Find(id)
            brand.ModifiedBy = user
            brand.ModifiedDate = DateTime.Now
            brand.IsDeleted = True
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
