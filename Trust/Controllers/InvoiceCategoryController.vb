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
    Public Class InvoiceCategoryController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: InvoiceCategory
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
            Dim Query = (From A In db.Ms_Invoice_Categorys.Where(Function(x) x.IsDeleted = False)
                         Select New Ms_Invoice_Category With {.Invoice_Category_ID = A.Invoice_Category_ID, .Invoice_Category_Name = A.Invoice_Category_Name, .CreatedDate = A.CreatedDate,
                             .CreatedBy = A.Cn_Users.User_Name, .ModifiedDate = A.ModifiedDate, .ModifiedBy = A.Cn_Users1.User_Name})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Invoice_Category_Name.Contains(searchString) OrElse s.CreatedBy.Contains(searchString) OrElse s.ModifiedBy.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Invoice_Category_Name"
                    Query = Query.OrderBy(Function(s) s.Invoice_Category_Name)
                Case "CreatedBy"
                    Query = Query.OrderBy(Function(s) s.CreatedBy)
                Case "ModifiedBy"
                    Query = Query.OrderBy(Function(s) s.ModifiedBy)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: InvoiceCategory/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Invoice_Categorys As Ms_Invoice_Categorys = Await db.Ms_Invoice_Categorys.FindAsync(id)
            If IsNothing(ms_Invoice_Categorys) Then
                Return HttpNotFound()
            End If
            Return View(ms_Invoice_Categorys)
        End Function

        ' GET: InvoiceCategory/Create
        Function Create() As ActionResult
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            Return View()
        End Function

        ' POST: InvoiceCategory/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Invoice_Category_ID,Invoice_Category_Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Invoice_Categorys As Ms_Invoice_Categorys) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Ms_Invoice_Categorys.Add(ms_Invoice_Categorys)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.ModifiedBy)
            Return View(ms_Invoice_Categorys)
        End Function

        ' GET: InvoiceCategory/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Invoice_Categorys As Ms_Invoice_Categorys = Await db.Ms_Invoice_Categorys.FindAsync(id)
            If IsNothing(ms_Invoice_Categorys) Then
                Return HttpNotFound()
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.ModifiedBy)
            Return View(ms_Invoice_Categorys)
        End Function

        ' POST: InvoiceCategory/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Invoice_Category_ID,Invoice_Category_Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Invoice_Categorys As Ms_Invoice_Categorys) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(ms_Invoice_Categorys).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Invoice_Categorys.ModifiedBy)
            Return View(ms_Invoice_Categorys)
        End Function

        ' GET: InvoiceCategory/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Invoice_Categorys As Ms_Invoice_Categorys = Await db.Ms_Invoice_Categorys.FindAsync(id)
            If IsNothing(ms_Invoice_Categorys) Then
                Return HttpNotFound()
            End If
            Return View(ms_Invoice_Categorys)
        End Function

        ' POST: InvoiceCategory/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim ms_Invoice_Categorys As Ms_Invoice_Categorys = Await db.Ms_Invoice_Categorys.FindAsync(id)
            db.Ms_Invoice_Categorys.Remove(ms_Invoice_Categorys)
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
