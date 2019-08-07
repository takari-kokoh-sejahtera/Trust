Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Trust

Namespace Controllers
    Public Class ConfigApprovalUserController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: ConfigApprovalUser
        Async Function Index() As Task(Of ActionResult)
            Dim cn_ApprovalUsers = db.Cn_ApprovalUsers.Include(Function(c) c.Cn_Users).Include(Function(c) c.Cn_Users1).Include(Function(c) c.Cn_Users2)
            Return View(Await cn_ApprovalUsers.ToListAsync())
        End Function

        ' GET: ConfigApprovalUser/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_ApprovalUsers As Cn_ApprovalUsers = Await db.Cn_ApprovalUsers.FindAsync(id)
            If IsNothing(cn_ApprovalUsers) Then
                Return HttpNotFound()
            End If
            Return View(cn_ApprovalUsers)
        End Function

        ' GET: ConfigApprovalUser/Create
        Function Create() As ActionResult
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.User_ID = New SelectList(db.Cn_Users, "User_ID", "NIK")
            Return View()
        End Function

        ' POST: ConfigApprovalUser/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ApprovalUser_ID,User_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_ApprovalUsers As Cn_ApprovalUsers) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Cn_ApprovalUsers.Add(cn_ApprovalUsers)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.ModifiedBy)
            ViewBag.User_ID = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.User_ID)
            Return View(cn_ApprovalUsers)
        End Function

        ' GET: ConfigApprovalUser/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_ApprovalUsers As Cn_ApprovalUsers = Await db.Cn_ApprovalUsers.FindAsync(id)
            If IsNothing(cn_ApprovalUsers) Then
                Return HttpNotFound()
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.ModifiedBy)
            ViewBag.User_ID = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.User_ID)
            Return View(cn_ApprovalUsers)
        End Function

        ' POST: ConfigApprovalUser/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ApprovalUser_ID,User_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_ApprovalUsers As Cn_ApprovalUsers) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(cn_ApprovalUsers).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.ModifiedBy)
            ViewBag.User_ID = New SelectList(db.Cn_Users, "User_ID", "NIK", cn_ApprovalUsers.User_ID)
            Return View(cn_ApprovalUsers)
        End Function

        ' GET: ConfigApprovalUser/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_ApprovalUsers As Cn_ApprovalUsers = Await db.Cn_ApprovalUsers.FindAsync(id)
            If IsNothing(cn_ApprovalUsers) Then
                Return HttpNotFound()
            End If
            Return View(cn_ApprovalUsers)
        End Function

        ' POST: ConfigApprovalUser/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim cn_ApprovalUsers As Cn_ApprovalUsers = Await db.Cn_ApprovalUsers.FindAsync(id)
            db.Cn_ApprovalUsers.Remove(cn_ApprovalUsers)
            Await db.SaveChangesAsync()
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
