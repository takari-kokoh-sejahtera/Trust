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
    Public Class ReportApplicationController
        Inherits Controller
        Private db As New TrustEntities


        ' GET: ReportApplication
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
            Dim cust_ID = db.V_ProspectCustDetails.Select(Function(x) x.Customer_ID)
            Dim report = (From A In db.Ms_Customers
                          Join B In db.Ms_Customer_CompanyGroups On A.CompanyGroup_ID Equals B.CompanyGroup_ID
                          Where cust_ID.Contains(A.Customer_ID)
                          Select B.CompanyGroup_Name, A.Company_Name, A.Customer_ID).
            Select(Function(x) New V_ProspectCustDetail With {.CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
            .Detail = db.V_ProspectCustDetails.Where(Function(a) a.Customer_ID = x.Customer_ID).
            Select(Function(y) New Tr_ProspectCustD With {.Type = y.Type, .Transaction_Type = y.Transaction_Type, .OTR_Price = y.OTR_Price, .Normal_Disc = y.Normal_Disc, .Qty = y.Qty,
            .Lease_long = y.Lease_long, .CreatedBy = db.Cn_Users.Where(Function(w) w.User_ID = y.CreatedBy).Select(Function(t) t.User_Name).FirstOrDefault()})})


            If Not String.IsNullOrEmpty(searchString) Then
                report = report.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    report = report.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    report = report.OrderBy(Function(s) s.Company_Name)
                Case Else
                    report = report.OrderBy(Function(s) s.Company_Name)
            End Select

            Dim pageNumber As Integer = If(page, 1)
            Return View(report.ToPagedList(pageNumber, pageSize))
        End Function
    End Class
End Namespace