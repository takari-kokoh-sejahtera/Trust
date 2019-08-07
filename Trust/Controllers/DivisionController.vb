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
    Public Class DivisionController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Division
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
            Dim division = db.Cn_Divisions.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                division = division.Where(Function(s) s.Cn_GMs.GM.Contains(searchString) OrElse s.Division.Contains(searchString))
            End If
            Select Case sortOrder
                Case "GM"
                    division = division.OrderBy(Function(s) s.Cn_GMs.GM)
                Case "Division"
                    division = division.OrderBy(Function(s) s.Division)
                Case Else
                    division = division.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(division.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Division/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Divisions As Cn_Divisions = db.Cn_Divisions.Find(id)
            If IsNothing(cn_Divisions) Then
                Return HttpNotFound()
            End If
            Return View(cn_Divisions)
        End Function

        ' GET: Division/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            ViewBag.GM_ID = New SelectList(db.Cn_GMs.Where(Function(x) x.IsDeleted = False), "GM_ID", "GM")
            Return View()
        End Function

        ' POST: Division/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Division_ID,GM_ID,Division,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Divisions As Cn_Division) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim division = New Cn_Divisions
                division.GM_ID = cn_Divisions.GM_ID
                division.Division = cn_Divisions.Division
                division.CreatedBy = user
                division.CreatedDate = DateTime.Now
                division.IsDeleted = False
                db.Cn_Divisions.Add(division)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.GM_ID = New SelectList(db.Cn_GMs, "GM_ID", "GM", cn_Divisions.GM_ID)
            Return View(cn_Divisions)
        End Function

        ' GET: Division/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Divisions As Cn_Divisions = db.Cn_Divisions.Find(id)
            If IsNothing(cn_Divisions) Then
                Return HttpNotFound()
            End If
            Dim cn_Division As New Cn_Division
            cn_Division.Division_ID = cn_Divisions.Division_ID
            cn_Division.GM_ID = cn_Divisions.GM_ID
            cn_Division.Division = cn_Divisions.Division
            ViewBag.GM_ID = New SelectList(db.Cn_GMs.Where(Function(x) x.IsDeleted = False), "GM_ID", "GM", cn_Divisions.GM_ID)
            Return View(cn_Division)
        End Function

        ' POST: Division/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Division_ID,GM_ID,Division,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Divisions As Cn_Division) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim User1 = db.Cn_Divisions.FirstOrDefault(Function(p) (p.Division_ID = cn_Divisions.Division_ID))
                If (User1 Is Nothing) Then
                    Return HttpNotFound()
                End If
                User1.GM_ID = cn_Divisions.GM_ID
                User1.Division = cn_Divisions.Division
                User1.ModifiedBy = user
                User1.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.GM_ID = New SelectList(db.Cn_GMs, "GM_ID", "GM", cn_Divisions.GM_ID)
            Return View(cn_Divisions)
        End Function

        ' GET: Division/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Divisions As Cn_Divisions = db.Cn_Divisions.Find(id)
            If IsNothing(cn_Divisions) Then
                Return HttpNotFound()
            End If
            Return View(cn_Divisions)
        End Function

        ' POST: Division/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_Divisions As Cn_Divisions = db.Cn_Divisions.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_Divisions.ModifiedBy = user
            cn_Divisions.ModifiedDate = DateTime.Now
            cn_Divisions.IsDeleted = True
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
