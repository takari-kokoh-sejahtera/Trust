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
    Public Class DirectoratController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Directorat
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
            Dim directorat = db.Cn_Directorats.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                directorat = directorat.Where(Function(s) s.Directorat.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Directorat"
                    directorat = directorat.OrderBy(Function(s) s.Directorat)
                Case Else
                    directorat = directorat.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(directorat.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Directorat/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Directorats As Cn_Directorats = db.Cn_Directorats.Find(id)
            If IsNothing(cn_Directorats) Then
                Return HttpNotFound()
            End If
            Return View(cn_Directorats)
        End Function

        ' GET: Directorat/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Return View()
        End Function

        ' POST: Directorat/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Directorat_ID,Directorat,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_Directorats As Cn_Directorat) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim directorat As New Cn_Directorats
                directorat.Directorat = cn_Directorats.Directorat
                directorat.CreatedBy = user
                directorat.CreatedDate = DateTime.Now
                directorat.IsDeleted = False
                db.Cn_Directorats.Add(directorat)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Directorats)
        End Function

        ' GET: Directorat/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Directorats As Cn_Directorats = db.Cn_Directorats.Find(id)
            If IsNothing(cn_Directorats) Then
                Return HttpNotFound()
            End If
            Dim directorat As New Cn_Directorat
            directorat.Directorat_ID = cn_Directorats.Directorat_ID
            directorat.Directorat = cn_Directorats.Directorat
            Return View(directorat)
        End Function

        ' POST: Directorat/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Directorat_ID,Directorat,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_Directorats As Cn_Directorat) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim directorat = db.Cn_Directorats.FirstOrDefault(Function(p) (p.Directorat_ID = cn_Directorats.Directorat_ID))
                If (directorat Is Nothing) Then
                    Return HttpNotFound()
                End If
                directorat.Directorat = cn_Directorats.Directorat
                directorat.ModifiedBy = user
                directorat.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Directorats)
        End Function

        ' GET: Directorat/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Directorats As Cn_Directorats = db.Cn_Directorats.Find(id)
            If IsNothing(cn_Directorats) Then
                Return HttpNotFound()
            End If
            Dim directorat As New Cn_Directorat
            directorat.Directorat_ID = id
            directorat.Directorat = cn_Directorats.Directorat
            Return View(directorat)
        End Function

        ' POST: Directorat/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_Directorats As Cn_Directorats = db.Cn_Directorats.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_Directorats.ModifiedBy = user
            cn_Directorats.ModifiedDate = DateTime.Now
            cn_Directorats.IsDeleted = True
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
