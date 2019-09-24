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
    Public Class SetDeliveryController
        Inherits Controller
        Private db As New TrustEntities
        'Index'
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

            Dim Query = From A In db.V_ProspectCusts
                        Join B In db.Cn_Users On A.CreatedBy Equals B.User_ID
                        Join C In db.V_SetDeliveryQty On A.Contract_ID Equals C.Contract_ID
                        Join D In db.Tr_Contracts On A.Contract_ID Equals D.Contract_ID
                        Where A.Contract_ID IsNot Nothing And A.IsSetDelivery = False And C.IsInputAsseted = True And D.IsReceiptContract = True
                        Select New Tr_SetDelivery With {.CompanyGroup_Name = A.CompanyGroup_Name, .Company_Name = A.Company_Name, .Contract_No = A.Contract_No,
                            .QtyContract = C.Qty, .QtyDelivery = A.QtyDelivery, .CreatedDate = A.CreatedDate, .Contract_ID = A.Contract_ID,
                            .CreatedBy = B.User_Name, .ModifiedDate = A.ModifiedDate, .ModifiedBy = B.User_Name}

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            Return View(Query)
        End Function
        'Create'
        Function CreateDelivery(ByVal id As Integer?) As ActionResult
            Dim Query = (From A In db.V_ProspectCusts
                         Where A.Contract_ID IsNot Nothing And A.Contract_ID = id
                         Select New Tr_SetDelivery With {.CompanyGroup_Name = A.CompanyGroup_Name, .Company_Name = A.Company_Name, .Contract_No = A.Contract_No, .Contract_ID = A.Contract_ID}).FirstOrDefault
            '
            Dim setDel = db.Tr_SetDeliveryDetails.Where(Function(x) x.Tr_SetDeliveries.Contract_ID = id).Select(Function(x) x.ContractDetail_ID).ToArray
            ViewBag.detail = (From A In db.Tr_ContractDetails
                              Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                              Group Join C In db.Ms_Vehicles On A.Vehicle_ID Equals C.Vehicle_id Into CA = Group
                              From C In CA.DefaultIfEmpty()
                              Where A.IsDeleted = False And A.Contract_ID = Query.Contract_ID And Not setDel.Contains(A.ContractDetail_ID)
                              Select A.ContractDetail_ID, C.license_no, B.Brand_Name, B.Type, C.color, B.Year).ToList

            Return View(Query)
        End Function
        'save'
        Public Function SaveOrder(Contract_ID As Integer, DeliveryDate As DateTime?, Address_Delivery As String, PIC_Name As String, PIC_Number As String, order() As Tr_SetDeliveryDetails) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim result As String = "Error", Message As String = ""

            'Validasi
            Dim Valid As Boolean = True

            If DeliveryDate Is Nothing Then
                Valid = False
                Message = "Must fill Delivery Date"
            ElseIf Address_Delivery = "" Then
                Valid = False
                Message = "Must fill Delivery Address"
            ElseIf PIC_Name = "" Then
                Valid = False
                Message = "Must fill PIC Name"
            ElseIf PIC_Number = "" Then
                Valid = False
                Message = "Must fill PIC Number"
            ElseIf order Is Nothing Then
                Valid = False
                Message = "Must fill Choice License Number"
            End If

            If Valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim SetDel As New Tr_SetDeliveries
                        SetDel.Contract_ID = Contract_ID
                        SetDel.DeliveryDate = DeliveryDate
                        SetDel.Address_Delivery = Address_Delivery
                        SetDel.PIC_Name = PIC_Name
                        SetDel.PIC_Number = PIC_Number
                        SetDel.CreatedBy = user
                        SetDel.CreatedDate = DateTime.Now
                        SetDel.IsDeleted = False
                        db.Tr_SetDeliveries.Add(SetDel)
                        db.SaveChanges()
                        For Each item In order
                            Dim D As New Tr_SetDeliveryDetails
                            D.setDelivery_ID = SetDel.SetDelivery_ID
                            D.ContractDetail_ID = item.ContractDetail_ID
                            D.CreatedBy = user
                            D.CreatedDate = DateTime.Now
                            D.Isdeleted = False
                            db.Tr_SetDeliveryDetails.Add(D)
                        Next
                        db.SaveChanges()
                        If (db.V_SetDeliveryQty.Where(Function(x) x.Contract_ID = Contract_ID And x.Qty = x.QtyDelivery).Any) Then
                            Dim contrak = db.Tr_Contracts.Where(Function(x) x.Contract_ID = Contract_ID).FirstOrDefault
                            contrak.IsSetDelivery = True
                        End If
                        db.SaveChanges()
                        dbs.Commit()
                        result = "Success"
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using

            End If
            Return Json(New With {.result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace