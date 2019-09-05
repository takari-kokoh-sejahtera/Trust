Imports System.Web.Mvc
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports Trust.Trust
Imports PagedList

Namespace Controllers
    Public Class ReportCustomerController
        Inherits Controller

        Private db As New TrustEntities
        Dim customer As New CustomerController


        ' GET: ReportCustomer
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
            Dim report = (From A In db.V_ProspectCusts
                          Select A.ProspectCustomer_ID, A.IsExists, A.CompanyGroup_ID, A.CompanyGroup_Name, A.Company_Name, A.PT, A.Tbk, A.Address, A.City_ID, A.City, A.Phone,
                              A.Email, A.PIC_Name, A.PIC_Phone, A.PIC_Email, A.Notes, A.IsQuotation, A.Status, A.Cost_Price, A.CreatedDate, A.CreatedByName, A.CreatedBy, A.ModifiedDate,
                              A.ModifiedByName, A.Quotation_ID, A.Approval_ID).
                              Select(Function(x) New Tr_ProspectCust With {.ProspectCustomer_ID = x.ProspectCustomer_ID, .IsExists = x.IsExists, .CompanyGroup_ID = x.CompanyGroup_ID,
                                         .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .PT = x.PT, .Tbk = x.Tbk, .Address = x.Address, .City_id = x.City_ID, .City = x.City, .Phone = x.Phone,
                              .Email = x.Email, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Notes = x.Notes, .IsQuotation = x.IsQuotation, .Status = x.Status, .Cost_Price = x.Cost_Price, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .CreatedByName = x.CreatedByName,
                              .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedByName, .Quotation_ID = x.Quotation_ID, .Approval_ID = x.Approval_ID})

            If Not String.IsNullOrEmpty(searchString) Then
                report = report.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    report = report.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    report = report.OrderBy(Function(s) s.Company_Name)
                Case Else
                    report = report.OrderByDescending(Function(s) s.CreatedDate)
            End Select

            Dim pageNumber As Integer = If(page, 1)
            Return View(report.ToPagedList(pageNumber, pageSize))
        End Function
        Function Download() As FileContentResult
            Dim csv = "ProspectCustomer_ID,IsExists,CompanyGroup_Name,Company_Name,PT,Tbk,Address,City,Phone,Email,PIC_Name,PIC_Phone,PIC_Email,Status,Notes,CreatedDate,CreatedBy,ModifiedDate,ModifiedByName"
            Dim query = From A In db.V_ProspectCusts
                        Select A.ProspectCustomer_ID, A.IsExists, A.CompanyGroup_Name, A.Company_Name, A.PT, A.Tbk, A.Address, A.City, A.Phone, A.Email, A.PIC_Name, A.PIC_Phone, A.PIC_Email, A.Status, A.Notes, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedByName

            For Each i In query
                csv = csv + Environment.NewLine
                csv = csv + i.ProspectCustomer_ID.ToString() + "," + i.IsExists.ToString() + "," + If(i.CompanyGroup_Name, "").Replace(",", "") + "," + If(i.Company_Name, "").Replace(",", "") + "," + If(i.PT, "").ToString() + "," + If(i.Tbk, "").ToString() + "," + If(i.Address, "").Replace(",", "") + "," + If(i.City, "").Replace(",", "") + "," + If(i.Phone, "").ToString() + "," + If(i.Email, "").Replace(",", "") + "," + If(i.PIC_Name, "").Replace(",", "") + "," + If(i.PIC_Phone, "").ToString() + "," + If(i.PIC_Email, "").Replace(",", "") + "," + If(i.Status, "").ToString() + "," + If(i.Notes, "").Replace(",", "") + "," + i.CreatedDate.ToString() + "," + i.CreatedBy.ToString() + "," + i.ModifiedDate.ToString() + "," + i.ModifiedByName.ToString()
            Next
            Return File(New System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "ReportCustomer.csv")
        End Function
    End Class
End Namespace