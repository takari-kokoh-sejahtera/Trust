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
    Public Class DeliveryController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Delivery
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
            Dim Query = (From A In db.Tr_Quotations
                         Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                         Where A.IsDeleted = False
                         Select A.Quotation_ID, B.Company_Name, A.No_Ref, A.Quotation_Validity, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.IsApplication).
                         Select(Function(x) New Tr_Quotation With {.Quotation_ID = x.Quotation_ID, .Company_Name = x.Company_Name, .No_Ref = x.No_Ref, .Quotation_Validity = x.Quotation_Validity, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy,
                             .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy, .IsApplication = x.IsApplication})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Company_Name.Contains(searchString) OrElse s.No_Ref.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "No_Ref"
                    Query = Query.OrderBy(Function(s) s.No_Ref)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))


            'Dim tr_Deliverys = db.Tr_Deliverys.Include(Function(t) t.Cn_Users).Include(Function(t) t.Cn_Users1).Include(Function(t) t.Tr_ContractDetails)
            'Return View(tr_Deliverys)
        End Function

        ' GET: Delivery/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Deliverys As Tr_Deliverys = Await db.Tr_Deliverys.FindAsync(id)
            If IsNothing(tr_Deliverys) Then
                Return HttpNotFound()
            End If
            Return View(tr_Deliverys)
        End Function

        ' GET: Delivery/Create
        Function Create() As ActionResult
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.ContractDetail_ID = New SelectList(db.Tr_ContractDetails, "ContractDetail_ID", "Remark")
            Return View()
        End Function

        ' POST: Delivery/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Delivery_ID,ContractDetail_ID,Delivery_Method,Expedition_Name,Driver_Allocated,Driver_Name,BSTK_Date,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Deliverys As Tr_Deliverys) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Tr_Deliverys.Add(tr_Deliverys)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.ModifiedBy)
            ViewBag.ContractDetail_ID = New SelectList(db.Tr_ContractDetails, "ContractDetail_ID", "Remark", tr_Deliverys.ContractDetail_ID)
            Return View(tr_Deliverys)
        End Function

        ' GET: Delivery/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Deliverys As Tr_Deliverys = Await db.Tr_Deliverys.FindAsync(id)
            If IsNothing(tr_Deliverys) Then
                Return HttpNotFound()
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.ModifiedBy)
            ViewBag.ContractDetail_ID = New SelectList(db.Tr_ContractDetails, "ContractDetail_ID", "Remark", tr_Deliverys.ContractDetail_ID)
            Return View(tr_Deliverys)
        End Function

        ' POST: Delivery/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Delivery_ID,ContractDetail_ID,Delivery_Method,Expedition_Name,Driver_Allocated,Driver_Name,BSTK_Date,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Deliverys As Tr_Deliverys) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(tr_Deliverys).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", tr_Deliverys.ModifiedBy)
            ViewBag.ContractDetail_ID = New SelectList(db.Tr_ContractDetails, "ContractDetail_ID", "Remark", tr_Deliverys.ContractDetail_ID)
            Return View(tr_Deliverys)
        End Function

        ' GET: Delivery/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Deliverys As Tr_Deliverys = Await db.Tr_Deliverys.FindAsync(id)
            If IsNothing(tr_Deliverys) Then
                Return HttpNotFound()
            End If
            Return View(tr_Deliverys)
        End Function

        ' POST: Delivery/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_Deliverys As Tr_Deliverys = Await db.Tr_Deliverys.FindAsync(id)
            db.Tr_Deliverys.Remove(tr_Deliverys)
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
