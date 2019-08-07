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
    Public Class LevelController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Level
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
            Dim level = db.Cn_Levels.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                level = level.Where(Function(s) s.Level.ToString.Contains(searchString) OrElse s.Remark.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Level"
                    level = level.OrderBy(Function(s) s.Level)
                Case "Remark"
                    level = level.OrderBy(Function(s) s.Remark)
                Case Else
                    level = level.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(level.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Level/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Levels As Cn_Levels = db.Cn_Levels.Find(id)
            If IsNothing(cn_Levels) Then
                Return HttpNotFound()
            End If
            Return View(cn_Levels)
        End Function

        ' GET: Level/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Return View()
        End Function

        ' POST: Level/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Level_ID,Level,Remark,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Levels As Cn_Level) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level As New Cn_Levels
                level.Level = cn_Levels.Level
                level.Remark = cn_Levels.Remark
                level.CreatedBy = user
                level.CreatedDate = DateTime.Now
                level.IsDeleted = False
                db.Cn_Levels.Add(level)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Levels)
        End Function

        ' GET: Level/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Levels As Cn_Levels = db.Cn_Levels.Find(id)
            If IsNothing(cn_Levels) Then
                Return HttpNotFound()
            End If
            Dim cn_Level As New Cn_Level
            cn_Level.Level_ID = cn_Levels.Level_ID
            cn_Level.Level = cn_Levels.Level
            cn_Level.Remark = cn_Levels.Remark
            Return View(cn_Level)
        End Function

        ' POST: Level/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Level_ID,Level,Remark,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Levels As Cn_Level) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim level = db.Cn_Levels.FirstOrDefault(Function(p) (p.Level_ID = cn_Levels.Level_ID))
                If (level Is Nothing) Then
                    Return HttpNotFound()
                End If
                level.Level = cn_Levels.Level
                level.Remark = cn_Levels.Remark
                level.ModifiedBy = user
                level.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(cn_Levels)
        End Function

        ' GET: Level/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Levels As Cn_Levels = db.Cn_Levels.Find(id)
            If IsNothing(cn_Levels) Then
                Return HttpNotFound()
            End If
            Return View(cn_Levels)
        End Function

        ' POST: Level/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_levels As Cn_Levels = db.Cn_Levels.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_levels.ModifiedBy = user
            cn_levels.ModifiedDate = DateTime.Now
            cn_levels.IsDeleted = True
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
