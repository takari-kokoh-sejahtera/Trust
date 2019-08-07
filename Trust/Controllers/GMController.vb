Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PagedList
Imports Trust.Trust

Namespace Controllers
    Public Class GMController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: GM
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
            Dim gm = db.Cn_GMs.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                gm = gm.Where(Function(s) s.Cn_Directorats.Directorat.Contains(searchString) OrElse s.GM.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Directorat"
                    gm = gm.OrderBy(Function(s) s.Cn_Directorats.Directorat)
                Case "GM"
                    gm = gm.OrderBy(Function(s) s.GM)
                Case Else
                    gm = gm.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(gm.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: GM/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_GMs As Cn_GMs = db.Cn_GMs.Find(id)
            If IsNothing(cn_GMs) Then
                Return HttpNotFound()
            End If
            Return View(cn_GMs)
        End Function

        ' GET: GM/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats.Where(Function(x) x.IsDeleted = False), "Directorat_ID", "Directorat")
            Return View()
        End Function

        ' POST: GM/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="GM_ID,Directorat_ID,GM,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_GMs As Cn_GM) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim gm As New Cn_GMs
                gm.Directorat_ID = cn_GMs.Directorat_ID
                gm.GM = cn_GMs.GM
                gm.CreatedBy = user
                gm.CreatedDate = DateTime.Now
                gm.IsDeleted = False
                db.Cn_GMs.Add(gm)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats, "Directorat_ID", "Directorat", cn_GMs.Directorat_ID)
            Return View(cn_GMs)
        End Function

        ' GET: GM/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_GMs As Cn_GMs = db.Cn_GMs.Find(id)
            If IsNothing(cn_GMs) Then
                Return HttpNotFound()
            End If
            Dim cn_GM As New Cn_GM
            cn_GM.GM_ID = id
            cn_GM.GM = cn_GMs.GM
            cn_GM.Directorat_ID = cn_GMs.Directorat_ID

            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats.Where(Function(x) x.IsDeleted = False), "Directorat_ID", "Directorat", cn_GM.Directorat_ID)
            Return View(cn_GM)
        End Function

        ' POST: GM/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="GM_ID,Directorat_ID,GM,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_GMs As Cn_GM) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim User1 = db.Cn_GMs.FirstOrDefault(Function(p) (p.GM_ID = cn_GMs.GM_ID))
                If (User1 Is Nothing) Then
                    Return HttpNotFound()
                End If
                User1.Directorat_ID = cn_GMs.Directorat_ID
                User1.GM = cn_GMs.GM
                User1.ModifiedBy = user
                User1.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats, "Directorat_ID", "Directorat", cn_GMs.Directorat_ID)
            Return View(cn_GMs)
        End Function

        ' GET: GM/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_GMs As Cn_GMs = db.Cn_GMs.Find(id)
            If IsNothing(cn_GMs) Then
                Return HttpNotFound()
            End If
            Return View(cn_GMs)
        End Function

        ' POST: GM/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_GMs As Cn_GMs = db.Cn_GMs.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_GMs.ModifiedBy = user
            cn_GMs.ModifiedDate = DateTime.Now
            cn_GMs.IsDeleted = True
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
