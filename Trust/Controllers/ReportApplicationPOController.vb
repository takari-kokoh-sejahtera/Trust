Imports System.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports Trust.Trust
Imports PagedList
Imports System.IO
Imports Ionic.Zip
Imports Microsoft.Reporting.WebForms

Namespace Controllers
    Public Class ReportApplicationPOController
        Inherits System.Web.Mvc.Controller
        Private db As New TrustEntities

        ' GET: ReportApplicationPO
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
            'Cache untuk di group, BitArray bisa di bandingin
            Dim appPO = From A In db.V_ProspectCusts
                        Join B In db.V_ProspectCustDetails On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID
                        Group Join C In db.V_ApplicationPO On B.ProspectCustomerDetail_ID Equals C.ProspectCustomerDetail_ID Into BC = Group
                        From C In BC.DefaultIfEmpty
                        Where A.IsPO And B.IsFillOTR = False And B.Qty <> If(C.Qty, 0)
                        Select New Tr_ApplicationPO With {.CompanyName = B.Company_Name, .Vehicle = B.Vehicle, .Qty = B.Qty, .QtyAppPO = B.QtyAppPO, .No_Ref = A.No_Ref, .ProspectCustomerDetail_ID = B.ProspectCustomerDetail_ID, .CreatedDate = A.CreatedDate, .Quotation_ID = A.Quotation_ID}
            If Not String.IsNullOrEmpty(searchString) Then
                appPO = appPO.Where(Function(s) s.No_Ref.Contains(searchString) OrElse s.CompanyName.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "No_Ref"
                    appPO = appPO.OrderBy(Function(s) s.No_Ref)
                Case "CompanyName"
                    appPO = appPO.OrderBy(Function(s) s.CompanyName)
                Case "Vehicle"
                    appPO = appPO.OrderBy(Function(s) s.Vehicle)
                Case Else
                    appPO = appPO.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(appPO.ToPagedList(pageNumber, pageSize))
        End Function
    End Class
End Namespace