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
    Public Class CompanyGroupController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: CompanyGroup
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
            Dim companyGroup = From A In db.Ms_Customer_CompanyGroups.Where(Function(x) x.IsDeleted = False)
            If Not String.IsNullOrEmpty(searchString) Then
                companyGroup = companyGroup.Where(Function(s) s.CompanyGroup_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    companyGroup = companyGroup.OrderBy(Function(s) s.CompanyGroup_Name)
                Case Else
                    companyGroup = companyGroup.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(companyGroup.ToPagedList(pageNumber, pageSize))
            'Return View(db.Cn_Roles.ToList())
        End Function

        ' GET: CompanyGroup/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups = db.Ms_Customer_CompanyGroups.Find(id)
            If IsNothing(ms_Customer_CompanyGroups) Then
                Return HttpNotFound()
            End If
            Return View(ms_Customer_CompanyGroups)
        End Function

        ' GET: CompanyGroup/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Return View()
        End Function

        ' POST: CompanyGroup/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CompanyGroup_ID,CompanyGroup_Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Customer_CompanyGroups As Ms_Customer_CompanyGroup) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim companygroup As New Ms_Customer_CompanyGroups
                companygroup.CompanyGroup_Name = ms_Customer_CompanyGroups.CompanyGroup_Name
                companygroup.CreatedBy = user
                companygroup.CreatedDate = DateTime.Now
                companygroup.IsDeleted = False
                db.Ms_Customer_CompanyGroups.Add(companygroup)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_Customer_CompanyGroups)
        End Function

        ' GET: CompanyGroup/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups = db.Ms_Customer_CompanyGroups.Find(id)
            If IsNothing(ms_Customer_CompanyGroups) Then
                Return HttpNotFound()
            End If
            Dim ms_Customer_CompanyGroup As New Ms_Customer_CompanyGroup
            ms_Customer_CompanyGroup.CompanyGroup_ID = id
            ms_Customer_CompanyGroup.CompanyGroup_Name = ms_Customer_CompanyGroups.CompanyGroup_Name
            Return View(ms_Customer_CompanyGroup)
        End Function

        ' POST: CompanyGroup/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CompanyGroup_ID,CompanyGroup_Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Customer_CompanyGroups As Ms_Customer_CompanyGroup) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim companygrouop = db.Ms_Customer_CompanyGroups.FirstOrDefault(Function(p) (p.CompanyGroup_ID = ms_Customer_CompanyGroups.CompanyGroup_ID))
                If (companygrouop Is Nothing) Then
                    Return HttpNotFound()
                End If

                companygrouop.CompanyGroup_Name = ms_Customer_CompanyGroups.CompanyGroup_Name
                companygrouop.ModifiedBy = user
                companygrouop.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_Customer_CompanyGroups)
        End Function

        ' GET: CompanyGroup/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups = db.Ms_Customer_CompanyGroups.Find(id)
            If IsNothing(ms_Customer_CompanyGroups) Then
                Return HttpNotFound()
            End If
            Return View(ms_Customer_CompanyGroups)
        End Function

        ' POST: CompanyGroup/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups = db.Ms_Customer_CompanyGroups.Find(id)
            ms_Customer_CompanyGroups.ModifiedBy = user
            ms_Customer_CompanyGroups.ModifiedDate = DateTime.Now
            ms_Customer_CompanyGroups.IsDeleted = True
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
