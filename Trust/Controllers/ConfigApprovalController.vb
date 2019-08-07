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
    Public Class ConfigApprovalController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: ConfigApproval
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
            Dim approval = db.Cn_Approvals.Where(Function(x) x.IsDeleted = False).Select(Function(x) New Cn_Approval With {.Approval_ID = x.Approval_ID,
                .Approval_Name = x.Approval_Name, .Module_ID = x.Module_ID, .Modules = x.Cn_Modules.Module_Name, .Level_ID = x.Level_ID, .Level = x.Cn_Levels.Level,
                .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            If Not String.IsNullOrEmpty(searchString) Then
                approval = approval.Where(Function(s) s.Approval_Name.Contains(searchString) OrElse s.Modules.Contains(searchString) OrElse s.Level.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Approval_Name"
                    approval = approval.OrderBy(Function(s) s.Approval_Name)
                Case "Modules"
                    approval = approval.OrderBy(Function(s) s.Modules)
                Case "Level"
                    approval = approval.OrderBy(Function(s) s.Level)
                Case Else
                    approval = approval.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(approval.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ConfigApproval/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Approvals = db.Cn_Approvals.Where(Function(x) x.IsDeleted = False And x.Approval_ID = id).Select(Function(x) New Cn_Approval With {.Approval_ID = x.Approval_ID,
                .Approval_Name = x.Approval_Name, .Module_ID = x.Module_ID, .Modules = x.Cn_Modules.Module_Name, .Level_ID = x.Level_ID, .Level = x.Cn_Levels.Level,
                .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(cn_Approvals) Then
                Return HttpNotFound()
            End If
            Return View(cn_Approvals)
        End Function

        ' GET: ConfigApproval/Create
        Function Create() As ActionResult
            ViewBag.Level_ID = New SelectList(db.Cn_Levels.Where(Function(x) x.IsDeleted = False), "Level_ID", "Level")
            ViewBag.Module_ID = New SelectList(db.Cn_Modules.Where(Function(x) x.IsDeleted = False And x.IsApproval = True), "Module_ID", "Module_Name")
            Return View()
        End Function

        ' POST: ConfigApproval/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Approval_ID,Approval_Name,Module_ID,Level_ID")> ByVal cn_Approval As Cn_Approval) As ActionResult
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

                Dim approval As New Cn_Approvals With {.Approval_Name = cn_Approval.Approval_Name, .Module_ID = cn_Approval.Module_ID,
                    .Level_ID = cn_Approval.Level_ID, .CreatedBy = user, .CreatedDate = DateTime.Now, .IsDeleted = False}
                db.Cn_Approvals.Add(approval)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Level_ID = New SelectList(db.Cn_Levels.Where(Function(x) x.IsDeleted = False), "Level_ID", "Level", cn_Approval.Level_ID)
            ViewBag.Module_ID = New SelectList(db.Cn_Modules.Where(Function(x) x.IsDeleted = False And x.IsApproval = True), "Module_ID", "Module_Name", cn_Approval.Module_ID)
            Return View(cn_Approval)
        End Function

        ' GET: ConfigApproval/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Approvals = db.Cn_Approvals.Where(Function(x) x.IsDeleted = False And x.Approval_ID = id).Select(Function(x) New Cn_Approval With {.Approval_ID = x.Approval_ID,
                .Approval_Name = x.Approval_Name, .Module_ID = x.Module_ID, .Modules = x.Cn_Modules.Module_Name, .Level_ID = x.Level_ID, .Level = x.Cn_Levels.Level,
                .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(cn_Approvals) Then
                Return HttpNotFound()
            End If
            ViewBag.Level_ID = New SelectList(db.Cn_Levels.Where(Function(x) x.IsDeleted = False), "Level_ID", "Level", cn_Approvals.Level_ID)
            ViewBag.Module_ID = New SelectList(db.Cn_Modules.Where(Function(x) x.IsDeleted = False And x.IsApproval = True), "Module_ID", "Module_Name", cn_Approvals.Module_ID)
            Return View(cn_Approvals)
        End Function

        ' POST: ConfigApproval/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Approval_ID,Approval_Name,Module_ID,Level_ID")> ByVal cn_Approval As Cn_Approval) As ActionResult
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim approval = db.Cn_Approvals.Where(Function(x) x.Approval_ID = cn_Approval.Approval_ID).FirstOrDefault
                approval.Approval_Name = cn_Approval.Approval_Name
                approval.Module_ID = cn_Approval.Module_ID
                approval.Level_ID = cn_Approval.Level_ID
                approval.ModifiedDate = DateTime.Now
                approval.ModifiedBy = user
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Level_ID = New SelectList(db.Cn_Levels.Where(Function(x) x.IsDeleted = False), "Level_ID", "Level", cn_Approval.Level_ID)
            ViewBag.Module_ID = New SelectList(db.Cn_Modules.Where(Function(x) x.IsDeleted = False And x.IsApproval = True), "Module_ID", "Module_Name", cn_Approval.Module_ID)
            Return View(cn_Approval)
        End Function

        ' GET: ConfigApproval/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Approvals = db.Cn_Approvals.Where(Function(x) x.IsDeleted = False And x.Approval_ID = id).Select(Function(x) New Cn_Approval With {.Approval_ID = x.Approval_ID,
                .Approval_Name = x.Approval_Name, .Module_ID = x.Module_ID, .Modules = x.Cn_Modules.Module_Name, .Level_ID = x.Level_ID, .Level = x.Cn_Levels.Level,
                .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(cn_Approvals) Then
                Return HttpNotFound()
            End If
            Return View(cn_Approvals)
        End Function

        ' POST: ConfigApproval/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim approval = db.Cn_Approvals.Where(Function(x) x.Approval_ID = id).FirstOrDefault
            approval.ModifiedDate = DateTime.Now
            approval.ModifiedBy = user
            approval.IsDeleted = True
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
