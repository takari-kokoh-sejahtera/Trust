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
    Public Class UnitController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Unit
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
            Dim unit = db.Cn_Units.Where(Function(x) x.IsDeleted = False)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                unit = unit.Where(Function(s) s.Cn_Departments.Department.Contains(searchString) OrElse s.Unit.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Department"
                    unit = unit.OrderBy(Function(s) s.Cn_Departments.Department)
                Case "Unit"
                    unit = unit.OrderBy(Function(s) s.Unit)
                Case Else
                    unit = unit.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(unit.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Unit/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Units As Cn_Units = db.Cn_Units.Find(id)
            If IsNothing(cn_Units) Then
                Return HttpNotFound()
            End If
            Return View(cn_Units)
        End Function

        ' GET: Unit/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            ViewBag.Department_ID = New SelectList(db.Cn_Departments.Where(Function(x) x.IsDeleted = False), "Department_ID", "Department")
            Return View()
        End Function

        ' POST: Unit/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Unit_ID,Department_ID,Unit,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Units As Cn_Unit) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim unit As New Cn_Units
                unit.Department_ID = cn_Units.Department_ID
                unit.Unit = cn_Units.Unit
                unit.CreatedBy = user
                unit.CreatedDate = DateTime.Now
                unit.IsDeleted = False
                db.Cn_Units.Add(unit)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Department_ID = New SelectList(db.Cn_Departments, "Department_ID", "Department", cn_Units.Department_ID)
            Return View(cn_Units)
        End Function

        ' GET: Unit/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Units As Cn_Units = db.Cn_Units.Find(id)
            If IsNothing(cn_Units) Then
                Return HttpNotFound()
            End If
            Dim cn_Unit As New Cn_Unit
            cn_Unit.Unit_ID = id
            cn_Unit.Department_ID = cn_Units.Department_ID
            cn_Unit.Unit = cn_Units.Unit

            ViewBag.Department_ID = New SelectList(db.Cn_Departments.Where(Function(x) x.IsDeleted = False), "Department_ID", "Department", cn_Units.Department_ID)
            Return View(cn_Unit)
        End Function

        ' POST: Unit/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Unit_ID,Department_ID,Unit,CreatedDate,CreatedBy,ModifiedDate,IsDeleted,ModifiedBy")> ByVal cn_Units As Cn_Unit) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim User1 = db.Cn_Units.FirstOrDefault(Function(p) (p.Unit_ID = cn_Units.Unit_ID))
                If (User1 Is Nothing) Then
                    Return HttpNotFound()
                End If
                User1.Department_ID = cn_Units.Department_ID
                User1.Unit = cn_Units.Unit
                User1.ModifiedBy = user
                User1.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Department_ID = New SelectList(db.Cn_Departments, "Department_ID", "Department", cn_Units.Department_ID)
            Return View(cn_Units)
        End Function

        ' GET: Unit/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Units As Cn_Units = db.Cn_Units.Find(id)
            If IsNothing(cn_Units) Then
                Return HttpNotFound()
            End If
            Return View(cn_Units)
        End Function

        ' POST: Unit/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim cn_units As Cn_Units = db.Cn_Units.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            cn_units.ModifiedBy = user
            cn_units.ModifiedDate = DateTime.Now
            cn_units.IsDeleted = True
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
