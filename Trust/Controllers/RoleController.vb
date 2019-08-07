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
Imports PagedList

Namespace Controllers
    Public Class RoleController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Role
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
            Dim cn_Roles = From A In db.Cn_Roles.Where(Function(x) x.IsDeleted = False)
            If Not String.IsNullOrEmpty(searchString) Then
                cn_Roles = cn_Roles.Where(Function(s) s.Role_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Role_Name"
                    cn_Roles = cn_Roles.OrderBy(Function(s) s.Role_Name)
                Case Else
                    cn_Roles = cn_Roles.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(cn_Roles.ToPagedList(pageNumber, pageSize))
            'Return View(db.Cn_Roles.ToList())
        End Function

        ' GET: Role/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Roles As Cn_Roles = Await db.Cn_Roles.FindAsync(id)
            If IsNothing(cn_Roles) Then
                Return HttpNotFound()
            End If
            Dim detail = db.sp_RoleGetEditDetail(id)
            ViewBag.detail = detail
            Return View(cn_Roles)
        End Function

        ' GET: Role/Create
        Function Create() As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim detail = db.Cn_Modules.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Tab).ThenBy(Function(x) x.Order).ToList
            ViewBag.detail = detail
            Return View()
        End Function
        'Save Detail
        Public Function SaveOrder(Role_Name As String, order() As Cn_RoleAuthorizations) As ActionResult
            Dim user As String
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim result As String = "Error"
            'Validasi
            Dim Valid As Boolean = False
            If (Trim(Role_Name) <> "") And order IsNot Nothing Then
                Valid = True
            End If

            If Valid Then
                Dim Role As New Cn_Roles
                Role.Role_Name = Role_Name
                Role.CreatedBy = user
                Role.CreatedDate = DateTime.Now
                Role.IsDeleted = False
                db.Cn_Roles.Add(Role)
                For Each item In order
                    Dim D As New Cn_RoleAuthorizations
                    D.Role_ID = Role.Role_ID
                    D.Module_ID = item.Module_ID
                    D.CreatedBy = user
                    D.CreatedDate = DateTime.Now
                    D.IsDeleted = Not item.IsDeleted
                    db.Cn_RoleAuthorizations.Add(D)
                Next
                db.SaveChanges()
                result = "Success"
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function


        ' GET: Role/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Roles = db.Cn_Roles.Where(Function(x) x.Role_ID = id).FirstOrDefault
            If IsNothing(cn_Roles) Then
                Return HttpNotFound()
            End If
            Dim detail = db.sp_RoleGetEditDetail(id)
            ViewBag.detail = detail
            Return View(cn_Roles)
        End Function

        Public Function EditOrder(Role_ID As Integer, Role_Name As String, order() As Cn_RoleAuthorizations) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim result As String = "Error"
            'Validasi
            Dim Valid As Boolean = False
            If (Trim(Role_Name) <> "") And order IsNot Nothing Then
                Valid = True
            End If

            If Valid Then
                Dim Role = db.Cn_Roles.Where(Function(x) x.Role_ID = Role_ID).FirstOrDefault
                Role.Role_Name = Role_Name
                Role.ModifiedBy = user
                Role.ModifiedDate = DateTime.Now
                Dim neww = order.Where(Function(x) x.RoleAuthorization_ID = 0)
                For Each item In neww
                    Dim D As New Cn_RoleAuthorizations
                    D.Role_ID = Role.Role_ID
                    D.Module_ID = item.Module_ID
                    D.CreatedBy = user
                    D.CreatedDate = DateTime.Now
                    D.IsDeleted = Not item.IsDeleted
                    db.Cn_RoleAuthorizations.Add(D)
                Next
                Dim old = order.Where(Function(x) x.RoleAuthorization_ID <> 0)
                For Each item In old
                    Dim D = db.Cn_RoleAuthorizations.Where(Function(x) x.RoleAuthorization_ID = item.RoleAuthorization_ID).FirstOrDefault()
                    D.ModifiedBy = user
                    D.ModifiedDate = DateTime.Now
                    D.IsDeleted = Not item.IsDeleted
                Next
                db.SaveChanges()
                result = "Success"
            End If
            Return Json(result, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Role/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Roles As Cn_Roles = Await db.Cn_Roles.FindAsync(id)
            If IsNothing(cn_Roles) Then
                Return HttpNotFound()
            End If
            Return View(cn_Roles)
        End Function

        ' POST: Role/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim cn_Roles As Cn_Roles = Await db.Cn_Roles.FindAsync(id)
            cn_Roles.IsDeleted = True
            cn_Roles.ModifiedBy = user
            cn_Roles.ModifiedDate = DateTime.Now
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
