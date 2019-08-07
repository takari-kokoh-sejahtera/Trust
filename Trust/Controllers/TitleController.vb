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
    Public Class TitleController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Title
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
            Dim title = db.Cn_Titles.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                title = title.Where(Function(s) s.Title.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Title"
                    title = title.OrderBy(Function(s) s.Title)
                Case Else
                    title = title.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(title.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Title/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Titles As Cn_Titles = db.Cn_Titles.Find(id)
            If IsNothing(cn_Titles) Then
                Return HttpNotFound()
            End If
            Return View(cn_Titles)
        End Function

        ' GET: Title/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Return View()
        End Function

        ' POST: Title/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="TItle_ID,TItle,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Titles As Cn_Title) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim title As New Cn_Titles
                title.Title = cn_Titles.TItle
                title.CreatedBy = user
                title.CreatedDate = DateTime.Now
                title.IsDeleted = False
                db.Cn_Titles.Add(title)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Titles)
        End Function

        ' GET: Title/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Titles As Cn_Titles = db.Cn_Titles.Find(id)
            If IsNothing(cn_Titles) Then
                Return HttpNotFound()
            End If
            Dim title As New Cn_Title
            title.TItle_ID = id
            title.TItle = cn_Titles.Title
            Return View(title)
        End Function

        ' POST: Title/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="TItle_ID,TItle,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Titles As Cn_Title) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim title = db.Cn_Titles.FirstOrDefault(Function(p) (p.Title_ID = cn_Titles.TItle_ID))
                If (title Is Nothing) Then
                    Return HttpNotFound()
                End If
                title.Title = cn_Titles.TItle
                title.ModifiedBy = user
                title.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Titles)
        End Function

        ' GET: Title/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Titles As Cn_Titles = db.Cn_Titles.Find(id)
            If IsNothing(cn_Titles) Then
                Return HttpNotFound()
            End If
            Return View(cn_Titles)
        End Function

        ' POST: Title/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_Titles As Cn_Titles = db.Cn_Titles.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_Titles.ModifiedBy = user
            cn_Titles.ModifiedDate = DateTime.Now
            cn_Titles.IsDeleted = True
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
