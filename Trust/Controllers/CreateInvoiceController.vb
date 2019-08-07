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
    Public Class CreateInvoiceController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: CreateInvoice
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
            Dim Query = (From A In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False)
                         Join B In db.V_ProspectCusts On A.ApprovalApp_ID Equals B.ApprovalApp_ID
                         Where A.IsInvoicedAll = False And A.IsReceiptContract = True
                         Select A.Contract_ID, A.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, B.CompanyGroup_Name, B.Company_Name, A.Penerima, A.Jabatan, A.CreatedDate).
                         Select(Function(x) New Tr_Invoice With {.Contract_ID = x.Contract_ID, .Contract_No = x.Contract_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Penerima = x.Penerima, .Jabatan = x.Jabatan, .CreatedDate = x.CreatedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Penerima.Contains(searchString) OrElse s.Jabatan.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Penerima"
                    Query = Query.OrderBy(Function(s) s.Penerima)
                Case "Jabatan"
                    Query = Query.OrderBy(Function(s) s.Jabatan)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function
        Public Function GetDateBSTK(order() As Tr_ContractDetail) As ActionResult
            If order IsNot Nothing Then
                Dim detail = order.Select(Function(x) x.ContractDetail_ID).ToArray
                Dim data = db.Tr_Deliverys.Where(Function(x) x.IsDeleted = False And detail.Contains(x.ContractDetail_ID)).OrderBy(Function(x) x.CreatedDate).Select(Function(x) x.CreatedDate).FirstOrDefault()
                If data = Nothing Then
                    Return Json(New With {Key .result = "Error", .message = "Not found Receipt Contract"})
                End If
                Return Json(New With {Key .result = "Success", .CreatedDate = Format(data, "yyyy-MM-dd")})
            End If
            Return Json(New With {Key .result = "Error", .message = "Cant found Contract ID"})
        End Function

        Public Function GetDateContract(orderHeader() As Tr_Contract) As ActionResult
            If orderHeader IsNot Nothing Then
                Dim Header = orderHeader.FirstOrDefault
                Dim data = db.Tr_ContractReceipts.Where(Function(x) x.Contract_ID = Header.Contract_ID).FirstOrDefault()
                If data Is Nothing Then
                    Return Json(New With {Key .result = "Error", .message = "Not found Receipt Contract"})
                End If
                Return Json(New With {Key .result = "Success", .CreatedDate = Format(data.CreatedDate, "yyyy-MM-dd")})
            End If
            Return Json(New With {Key .result = "Error", .message = "Cant found Contract ID"})
        End Function
        ' GET: CreateInvoice/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Query = (From A In db.Tr_Contracts.Where(Function(x) x.IsDeleted = 0)
                         Join B In db.V_ProspectCusts On A.ApprovalApp_ID Equals B.ApprovalApp_ID
                         Where A.IsInvoicedAll = False And A.IsReceiptContract = True And A.Contract_ID = id
                         Select A.Contract_ID, A.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, B.CompanyGroup_Name, B.Company_Name, A.Penerima, A.Jabatan, A.CreatedDate, B.CustomerExists_ID).
                         Select(Function(x) New Tr_Invoice With {.Contract_ID = x.Contract_ID, .Contract_No = x.Contract_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Penerima = x.Penerima, .Jabatan = x.Jabatan, .Status = "Costum", .CreatedDate = x.CreatedDate, .Customer_ID = x.CustomerExists_ID}).FirstOrDefault
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Dim detail = (From A In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = 0 And (x.IsDelivery = True Or x.IsTemporaryCar = True))
                          Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                          Group Join C In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = 0) On A.Vehicle_ID Equals C.Vehicle_id Into AC = Group
                          From C In AC.DefaultIfEmpty
                          Group Join D In db.Tr_TemporaryCars.Where(Function(x) x.IsDeleted = 0) On A.ContractDetail_ID Equals D.ContractDetail_ID Into AD = Group
                          From D In AD.DefaultIfEmpty
                          Group Join E In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = 0) On D.Vehicle_ID Equals E.Vehicle_id Into DE = Group
                          From E In DE.DefaultIfEmpty
                          Where A.Contract_ID = id And A.IsInvoiced = False
                          Select A.ContractDetail_ID, B.Brand_Name, B.Type, C.Vehicle_id, C.license_no, C.Tmp_Plat, B.Lease_long, A.Bid_PricePerMonth, A.IsTemporaryCar, Vehicle_ID1 = D.Vehicle_ID, license_no1 = E.license_no).
                        Select(Function(x) New Tr_InvoiceDetail With {.ContractDetail_ID = x.ContractDetail_ID, .Brand_Name = x.Brand_Name, .Type = x.Type, .Vehicle_ID = If(x.IsTemporaryCar, x.Vehicle_ID1, x.Vehicle_id), .license_no = If(x.IsTemporaryCar, x.license_no1, If(x.license_no, x.Tmp_Plat)), .Lease_Long = x.Lease_long, .Bid_PricePerMonth = x.Bid_PricePerMonth}).ToList

            ViewBag.detail = detail
            Return View(Query)
        End Function
        Dim message = ""
        Function validateHeader(header As Tr_Invoice) As Boolean
            If header.Contract_ID Is Nothing Then
                message = "Contract_ID not Fount"
                Return False
            ElseIf header.Customer_ID Is Nothing Then
                message = "Customer_ID not Fount"
                Return False
            ElseIf header.Status Is Nothing Then
                message = "Status not Fount"
                Return False
            ElseIf header.From_Date Is Nothing Then
                message = "From_Date not Fount"
                Return False
            ElseIf header.Signature_Name Is Nothing Then
                message = "Signature_Name not Fount"
                Return False
            ElseIf header.Signature_Title Is Nothing Then
                message = "Signature_Title not Fount"
                Return False
            ElseIf header.PerMonth Is Nothing Then
                message = "Master Contract:Paymeny Ivoice / Month Is Nothing"
                Return False
            End If
            Return True
        End Function
        Function validateDetail(order() As Tr_InvoiceDetail) As Boolean
            If order Is Nothing Then
                message = "Not have item"
                Return False
            End If
            For Each d In order
                If d.ContractDetail_ID Is Nothing Then
                    message = NameOf(d.ContractDetail_ID) + " Is Nothing"
                    Return False
                ElseIf d.Amount Is Nothing Then
                    message = NameOf(d.Amount) + " Is Nothing"
                    Return False
                ElseIf d.Vehicle_ID Is Nothing Then
                    message = NameOf(d.Vehicle_ID) + " Is Nothing"
                    Return False
                ElseIf d.Lease_Long Is Nothing Then
                    message = NameOf(d.Lease_Long) + " Is Nothing"
                    Return False
                End If
            Next
            Return True
        End Function
        Function validateCustomer(Cust As Ms_Customers) As Boolean
            If Cust.Address Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.Address) + " Is Nothing"
                Return False
            ElseIf Cust.NPWP Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.NPWP) + " Is Nothing"
                Return False
            ElseIf Cust.Account Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.Account) + " Is Nothing"
                Return False
            ElseIf Cust.Bank Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.Bank) + " Is Nothing"
                Return False
            ElseIf Cust.IsStamped Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.IsStamped) + " Is Nothing"
                Return False
            ElseIf Cust.Published Is Nothing Then
                message = "Master Customer:" + NameOf(Cust.Published) + " Is Nothing"
                Return False
            End If
            Return True
        End Function


        Public Function EditData(orderHeader() As Tr_Invoice, order() As Tr_InvoiceDetail) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            If orderHeader IsNot Nothing Or order IsNot Nothing Then
                Dim header = orderHeader.FirstOrDefault
                Dim dataCust = db.Ms_Customers.Where(Function(x) x.Customer_ID = header.Customer_ID).FirstOrDefault
                Dim ApprovalApp_ID = db.Tr_Contracts.Where(Function(x) x.Contract_ID = header.Contract_ID And x.IsDeleted = False).Select(Function(s) s.ApprovalApp_ID).FirstOrDefault
                Dim ApplicationHeader_ID = db.Tr_ApprovalApps.Where(Function(x) x.ApprovalApp_ID = ApprovalApp_ID And x.IsDeleted = False).Select(Function(s) s.ApplicationHeader_ID).FirstOrDefault
                Dim dataApp = db.Tr_ApplicationHeaders.Where(Function(x) x.ApplicationHeader_ID = ApplicationHeader_ID And x.IsDeleted = False).FirstOrDefault
                'ambil permonth dari contract
                Dim conDet_idNew = order.Select(Function(x) x.ContractDetail_ID).ToArray
                Dim cal_ID = db.V_ProspectCustDetails.Where(Function(x) conDet_idNew.Contains(x.ContractDetail_ID)).Select(Function(z) z.Calculate_ID).ToArray

                header.PerMonth = CType(db.Tr_Calculates.Where(Function(x) cal_ID.Contains(x.Calculate_ID)).Max(Function(z) z.Term_Of_Payment), Integer)
                'nga boleh lebih kecil dari tgl BSTK, kalo ada BSTKnya
                Dim validasiTgl = True
                Dim details = order.Select(Function(x) x.ContractDetail_ID).ToArray
                Dim data = db.Tr_Deliverys.Where(Function(x) x.IsDeleted = False And details.Contains(x.ContractDetail_ID)).OrderBy(Function(x) x.CreatedDate).Select(Function(x) x.CreatedDate).FirstOrDefault()
                If data <> Nothing Then
                    If Format(data, "yyyy-MM-dd") > Format(header.From_Date, "yyyy-MM-dd") Then
                        validasiTgl = False
                        message = "From Date exceed the date of BSTK " + Format(data, "yyyy-MM-dd")
                    End If
                End If


                If validasiTgl And validateHeader(header) And validateDetail(order) And validateCustomer(dataCust) Then
                    Using dbs = db.Database.BeginTransaction
                        Try
                            'create no
                            Dim trans = "Invoice"
                            Dim no = db.Cn_NoSerieSetup.Where(Function(x) x.Transaction = trans And x.YearNo = DateTime.Now.Year).FirstOrDefault()
                            Dim number As Integer
                            If no Is Nothing Then
                                number = 1
                            Else
                                number = no.NextNo + 1
                            End If
                            'save Tr_CreateInvoices
                            Dim max = order.Max(Function(x) x.Lease_Long)
                            'pake step biar kalo 1 atau 3 atau 12 masih ok
                            For i As Integer = 1 To max Step header.PerMonth
                                Dim detail As New List(Of Tr_InvoiceDetails)
                                Dim SubTotal As Decimal = 0
                                Dim fromDate As Date = DateAdd("M", i - 1, header.From_Date)
                                Dim toDate As Date = DateAdd("d", -1, DateAdd("M", i, header.From_Date))

                                'masukin dulu detail ke temp
                                For Each d In order
                                    If d.Lease_Long >= i Then
                                        Dim invoiceDetail As New Tr_InvoiceDetails
                                        invoiceDetail.ContractDetail_ID = d.ContractDetail_ID
                                        invoiceDetail.From_Date = fromDate
                                        invoiceDetail.To_Date = toDate
                                        Dim amount = d.Amount * header.PerMonth
                                        invoiceDetail.Amount = amount
                                        invoiceDetail.Vehicle_ID = d.Vehicle_ID
                                        invoiceDetail.Lease_Long = d.Lease_Long
                                        SubTotal = SubTotal + amount
                                        detail.Add(invoiceDetail)
                                    End If
                                Next
                                'add Invoice
                                Dim InsertH As New Tr_Invoices
                                InsertH.Contract_ID = header.Contract_ID
                                InsertH.Invoice_No = "IV" + DateTime.Now.Year.ToString + number.ToString("D5")
                                number = number + 1
                                InsertH.Customer_ID = header.Customer_ID
                                InsertH.From_Date = header.From_Date
                                InsertH.Status = header.Status
                                InsertH.PerMonth = header.PerMonth

                                'menentukan Publish Date
                                Dim cekdaymonthlast = If(System.DateTime.DaysInMonth(fromDate.Year, fromDate.Month) < dataCust.Published, System.DateTime.DaysInMonth(fromDate.Year, fromDate.Month), dataCust.Published)
                                InsertH.Published_Date = fromDate.Year.ToString() & "-" & fromDate.Month.ToString("D2") & "-" & CType(cekdaymonthlast, Integer).ToString("D2")


                                InsertH.Address = dataCust.Address
                                InsertH.NPWP = dataCust.NPWP
                                InsertH.Account = dataCust.Account
                                InsertH.Bank = dataCust.Bank
                                InsertH.Contracted_by = dataApp.Contracted_by
                                InsertH.IsStamped = dataCust.IsStamped
                                Dim Total As Decimal = 0
                                InsertH.Sub_Total = SubTotal
                                Total = Total + SubTotal
                                InsertH.VAT = SubTotal * 10 / 100
                                Total = Total + SubTotal * 10 / 100
                                Dim Stamp = 0
                                If dataCust.IsStamped Then
                                    If SubTotal <= 1000000 Then
                                        Stamp = 3000
                                    Else
                                        Stamp = 6000
                                    End If
                                End If
                                InsertH.Stamp = Stamp
                                Total = Total + Stamp
                                InsertH.Total = Total
                                InsertH.Signature_Name = header.Signature_Name
                                InsertH.Signature_Title = header.Signature_Title
                                InsertH.IsPrined = False
                                InsertH.IsPayed = False
                                InsertH.CreatedBy = user
                                InsertH.CreatedDate = DateTime.Now
                                InsertH.IsDeleted = False
                                db.Tr_Invoices.Add(InsertH)
                                'add Invoice Detail
                                For Each d In detail
                                    Dim InvD As New Tr_InvoiceDetails
                                    InvD.Invoice_ID = InsertH.Invoice_ID
                                    InvD.ContractDetail_ID = d.ContractDetail_ID
                                    InvD.Vehicle_ID = d.Vehicle_ID
                                    InvD.From_Date = d.From_Date
                                    InvD.To_Date = d.To_Date
                                    InvD.Amount = d.Amount
                                    InvD.Lease_Long = d.Lease_Long
                                    InvD.CreatedBy = user
                                    InvD.CreatedDate = DateTime.Now
                                    InvD.IsDeleted = False
                                    db.Tr_InvoiceDetails.Add(InvD)
                                Next
                                'Update Contract Detail
                                Dim conDet_ID = order.Select(Function(x) x.ContractDetail_ID)
                                Dim conDet = db.Tr_ContractDetails.Where(Function(x) x.Contract_ID = header.Contract_ID And conDet_ID.Contains(x.ContractDetail_ID) And x.IsDeleted = False).ToList
                                For Each d In conDet
                                    d.IsInvoiced = True
                                Next
                                'Update Contract Header Jika sudah semua
                                Dim BelumInvoiceCOunt = db.Tr_ContractDetails.Where(Function(x) x.Contract_ID = header.Contract_ID And Not conDet_ID.Contains(x.ContractDetail_ID) And x.IsDeleted = False And x.IsInvoiced = False).Count
                                If BelumInvoiceCOunt = 0 Then
                                    Dim ConHeader = db.Tr_Contracts.Where(Function(x) x.Contract_ID = header.Contract_ID).FirstOrDefault
                                    ConHeader.IsInvoicedAll = True
                                End If
                                db.SaveChanges()

                            Next
                            'udate NO Series Setup
                            If no Is Nothing Then
                                Dim NoSeries As New Cn_NoSerieSetup
                                NoSeries.Transaction = trans
                                NoSeries.YearNo = DateTime.Now.Year
                                NoSeries.NextNo = number - 1
                                NoSeries.CreatedDate = DateTime.Now
                                NoSeries.CreatedBy = user
                                NoSeries.IsDeleted = False
                                db.Cn_NoSerieSetup.Add(NoSeries)
                            Else
                                no.NextNo = number - 1
                                no.ModifiedBy = user
                                no.ModifiedDate = DateTime.Now
                            End If
                            db.SaveChanges()

                            dbs.Commit()
                            Return Json(New With {Key .result = "Success"})
                        Catch ex As Exception
                            message = ex.Message
                            dbs.Rollback()
                        End Try
                    End Using
                End If
            End If
            Return Json(New With {Key .result = "Error", .message = message})
        End Function


        Function JoinInvoice() As ActionResult

            Dim query = db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And x.IsInvoicedAll = True And x.IsInvoiceReceiptAll = False)
            Dim contract = From a In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And x.IsInvoicedAll = True And x.IsInvoiceReceiptAll = False)
                           Join b In db.V_ProspectCusts On a.Contract_ID Equals b.Contract_ID
                           Select a.Contract_ID, b.Contract_No


            ViewBag.Contract_ID = New SelectList(contract, "Contract_ID", "Contract_No")
            Return View()
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function JoinInvoice(<Bind(Include:="Contract_ID")> ByVal Contract As Tr_Contract_Join) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                'Dim hasil = db.sp_InvoiceJoin(Contract.Contract_ID)
                'Dim hasilnya = hasil.FirstOrDefault
                'If hasilnya.Status = "Error" Then
                '    ModelState.AddModelError("Contract_ID", hasilnya.Message)
                'End If

                Return RedirectToAction("Index")
            End If

            Dim contractlist = From a In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And x.IsInvoicedAll = True And x.IsInvoiceReceiptAll = False)
                               Join b In db.V_ProspectCusts On a.Contract_ID Equals b.Contract_ID
                               Select a.Contract_ID, b.Contract_No
            ViewBag.Contract_ID = New SelectList(contractlist, "Contract_ID", "Contract_No", Contract.Contract_ID)
            Return View(Contract)
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
