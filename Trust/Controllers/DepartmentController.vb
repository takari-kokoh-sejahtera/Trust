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
    Public Class DepartmentController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Department
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
            Dim department = db.Cn_Departments.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                department = department.Where(Function(s) s.Cn_Divisions.Division.Contains(searchString) OrElse s.Department.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Division"
                    department = department.OrderBy(Function(s) s.Cn_Divisions.Division)
                Case "Department"
                    department = department.OrderBy(Function(s) s.Department)
                Case Else
                    department = department.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(department.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Department/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Departments As Cn_Departments = db.Cn_Departments.Find(id)
            If IsNothing(cn_Departments) Then
                Return HttpNotFound()
            End If
            Return View(cn_Departments)
        End Function

        ' GET: Department/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions.Where(Function(x) x.IsDeleted = False), "Division_ID", "Division")
            Return View()
        End Function

        ' POST: Department/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Department_ID,Division_ID,Department,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Departments As Cn_Department) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim department = New Cn_Departments
                department.Division_ID = cn_Departments.Division_ID
                department.Department = cn_Departments.Department
                department.CreatedBy = user
                department.CreatedDate = DateTime.Now
                department.IsDeleted = False
                db.Cn_Departments.Add(department)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions, "Division_ID", "Division", cn_Departments.Division_ID)
            Return View(cn_Departments)
        End Function

        ' GET: Department/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Departments As Cn_Departments = db.Cn_Departments.Find(id)
            If IsNothing(cn_Departments) Then
                Return HttpNotFound()
            End If
            Dim department As New Cn_Department
            department.Department_ID = cn_Departments.Department_ID
            department.Division_ID = cn_Departments.Division_ID
            department.Department = cn_Departments.Department
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions.Where(Function(x) x.IsDeleted = False), "Division_ID", "Division", cn_Departments.Division_ID)
            Return View(department)
        End Function

        ' POST: Department/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Department_ID,Division_ID,Department,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Departments As Cn_Department) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim User1 = db.Cn_Departments.FirstOrDefault(Function(p) (p.Department_ID = cn_Departments.Department_ID))
                If (User1 Is Nothing) Then
                    Return HttpNotFound()
                End If
                User1.Division_ID = cn_Departments.Division_ID
                User1.Department = cn_Departments.Department
                User1.ModifiedBy = user
                User1.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions, "Division_ID", "Division", cn_Departments.Division_ID)
            Return View(cn_Departments)
        End Function

        ' GET: Department/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Departments As Cn_Departments = db.Cn_Departments.Find(id)
            If IsNothing(cn_Departments) Then
                Return HttpNotFound()
            End If
            Return View(cn_Departments)
        End Function

        ' POST: Department/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_Departments As Cn_Departments = db.Cn_Departments.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_Departments.ModifiedBy = user
            cn_Departments.ModifiedDate = DateTime.Now
            cn_Departments.IsDeleted = True
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
