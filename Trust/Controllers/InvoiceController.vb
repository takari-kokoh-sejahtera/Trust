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
Imports Microsoft.Reporting.WebForms

Namespace Controllers
    Public Class InvoiceController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        ' GET: Invoice
        Function IndexCollectionInvoice(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
            'Dim GroupSubTotal = (From A In db.Tr_InvoiceDetails
            '                     Where A.IsDeleted = False And A.Invoice_ID IsNot Nothing
            '                     Select A.Invoice_ID, A.Amount).AsEnumerable.
            '                     GroupBy(Function(g) g.Invoice_ID).
            '             Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Key, .Sub_Total = x.Sum(Function(f) f.Amount)})

            Dim Query = (From A In db.Tr_Invoices
                         Group Join B In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On A.Contract_ID Equals B.Contract_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Customers.Where(Function(x) x.IsDeleted = False) On A.Customer_ID Equals C.Customer_ID Into AC = Group
                         From C In AC.DefaultIfEmpty
                         Where A.IsDeleted = False And A.IsPayed = False And A.IsPrined = True
                         Select A.Invoice_ID, A.Invoice_No, B.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, C.Company_Name, A.Total, A.CreatedDate).
                         Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Invoice_ID, .Invoice_No = x.Invoice_No, .Contract_No = x.Contract_No, .Company_Name = x.Company_Name, .Total = x.Total, .CreatedDate = x.CreatedDate})


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
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Invoice_No.Contains(searchString) OrElse s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Invoice_No"
                    Query = Query.OrderBy(Function(s) s.Invoice_No)
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToList.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Invoice
        Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?, dateInput As Date?) As ActionResult
            'Dim GroupSubTotal = (From A In db.Tr_InvoiceDetails
            '                     Where A.IsDeleted = False And A.Invoice_ID IsNot Nothing
            '                     Select A.Invoice_ID, A.Amount).AsEnumerable.
            '                     GroupBy(Function(g) g.Invoice_ID).
            '             Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Key, .Sub_Total = x.Sum(Function(f) f.Amount)})

            'Dim Query = (From A In db.Tr_Invoices
            '             Group Join AA In GroupSubTotal On A.Invoice_ID Equals AA.Invoice_ID Into AAA = Group
            '             From AA In AAA.DefaultIfEmpty
            '             Group Join B In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On A.Contract_ID Equals B.Contract_ID Into AB = Group
            '             From B In AB.DefaultIfEmpty
            '             Group Join C In db.Ms_Customers.Where(Function(x) x.IsDeleted = False) On A.Customer_ID Equals C.Customer_ID Into AC = Group
            '             From C In AC.DefaultIfEmpty
            '             Where A.IsDeleted = False And A.IsPayed = False
            '             Select A.Invoice_ID, A.Invoice_No, B.Contract_No, C.Company_Name, AA.Sub_Total, A.CreatedDate).
            '             Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Invoice_ID, .Invoice_No = x.Invoice_No, .Contract_No = x.Contract_No, .Company_Name = x.Company_Name, .Sub_Total = x.Sub_Total, .CreatedDate = x.CreatedDate})

            Dim Query = (From A In db.sp_InvoiceListPerDay(If(dateInput, Date.Now))
                         Select A.Invoice_ID, A.Invoice_No, A.Contract_No, A.Company_Name, A.SubTotal, A.Published_Date).
                         Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Invoice_ID, .Invoice_No = x.Invoice_No, .Published_Date = x.Published_Date, .Contract_No = x.Contract_No, .Company_Name = x.Company_Name, .Sub_Total = x.SubTotal})


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
            ViewBag.dateInput = Format(dateInput, "yyyy-MM-dd")
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Invoice_No.Contains(searchString) OrElse s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Invoice_No"
                    Query = Query.OrderBy(Function(s) s.Invoice_No)
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToList.ToPagedList(pageNumber, pageSize))
        End Function
        Function Print(id As Integer?) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) IsNot Nothing) Then user = Session("ID")

            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/Invoice.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim List = db.sp_InvoicePrint(id, user).ToList
            Dim rd = New ReportDataSource("DSInvoice", List)
            lr.DataSources.Add(rd)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>21.6cm</PageWidth>" +
            " <PageHeight>27.9cm</PageHeight>" +
            " <MarginTop>0in</MarginTop>" +
            " <MarginLeft>0in</MarginLeft>" +
            " <MarginRight>0in</MarginRight>" +
            " <MarginBottom>0in</MarginBottom>" +
            "</DeviceInfo>"
            Dim warnings() As Warning
            Dim streams() As String
            Dim renderedBytes() As Byte
            renderedBytes = lr.Render(
            reportType,
            deviceInfo,
            MimeType,
            endcoding,
            fileNameExtension,
            streams,
            warnings
            )
            Return File(renderedBytes, MimeType)
        End Function
        ' GET: Invoice/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Invoices As Tr_Invoices = Await db.Tr_Invoices.FindAsync(id)
            If IsNothing(tr_Invoices) Then
                Return HttpNotFound()
            End If
            Return View(tr_Invoices)
        End Function

        ' GET: Invoice/Create
        Function Create() As ActionResult
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.PayedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.PrinedBy = New SelectList(db.Cn_Users, "User_ID", "NIK")
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers, "Customer_ID", "Company_Name")
            ViewBag.Contract_ID = New SelectList(db.Tr_Contracts, "Contract_ID", "Contract_No")
            Return View()
        End Function

        ' POST: Invoice/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Invoice_ID,Invoice_No,Contract_No,Company_Name,Total")> ByVal tr_Invoices As Tr_Invoice) As Task(Of ActionResult)
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim invoice = db.Tr_Invoices.Where(Function(x) x.Invoice_ID = tr_Invoices.Invoice_ID).FirstOrDefault
            invoice.IsPayed = True
            invoice.PayedBy = user
            invoice.PayedDate = DateTime.Now
            Return View(tr_Invoices)
        End Function

        ' GET: Invoice/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Query = (From A In db.Tr_Invoices
                         Group Join B In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On A.Contract_ID Equals B.Contract_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join C In db.Ms_Customers.Where(Function(x) x.IsDeleted = False) On A.Customer_ID Equals C.Customer_ID Into AC = Group
                         From C In AC.DefaultIfEmpty
                         Where A.IsDeleted = False And A.IsPayed = False And A.IsPrined = True And A.Invoice_ID = id
                         Select A.Invoice_ID, A.Invoice_No, B.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, C.Company_Name, A.Total, A.CreatedDate).
                         Select(Function(x) New Tr_Invoice With {.Invoice_ID = x.Invoice_ID, .Invoice_No = x.Invoice_No, .Contract_No = x.Contract_No, .Company_Name = x.Company_Name, .Total = x.Total, .CreatedDate = x.CreatedDate}).FirstOrDefault
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If

            Return View(Query)
        End Function

        ' POST: Invoice/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Invoice_ID,Invoice_No,Contract_No,Company_Name,Total,TotalStr")> ByVal tr_Invoices As Tr_Invoice) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim invoice = db.Tr_Invoices.Where(Function(x) x.Invoice_ID = tr_Invoices.Invoice_ID).FirstOrDefault
            'cek di contrak dia udh semua di jadiin invoice
            Dim contract = db.Tr_Contracts.Where(Function(x) x.Contract_ID = invoice.Contract_ID And x.IsInvoicedAll = True And x.IsDeleted = False).ToList
            If contract.Count >= 1 Then
                'cek invoice, kalo udh semua di bayar, kontract IsInvoiceReceiptAll = true
                Dim INvoiceCek = db.Tr_Invoices.Where(Function(x) x.Contract_ID = invoice.Contract_ID And x.IsDeleted = False And x.IsPayed = False And x.Invoice_ID <> tr_Invoices.Invoice_ID).ToList
                If INvoiceCek.Count = 0 Then
                    Dim contractUpdate = db.Tr_Contracts.Where(Function(x) x.Contract_ID = invoice.Contract_ID And x.IsDeleted = False).FirstOrDefault
                    contractUpdate.IsInvoiceReceiptAll = True
                End If
            End If

            invoice.IsPayed = True
            invoice.PayedBy = user
            invoice.PayedDate = DateTime.Now
            db.SaveChanges()
            Return RedirectToAction("IndexCollectionInvoice")
        End Function

        ' GET: Invoice/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Invoices As Tr_Invoices = Await db.Tr_Invoices.FindAsync(id)
            If IsNothing(tr_Invoices) Then
                Return HttpNotFound()
            End If
            Return View(tr_Invoices)
        End Function

        ' POST: Invoice/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_Invoices As Tr_Invoices = Await db.Tr_Invoices.FindAsync(id)
            db.Tr_Invoices.Remove(tr_Invoices)
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
