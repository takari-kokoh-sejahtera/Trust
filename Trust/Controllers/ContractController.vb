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
Imports System.IO
Imports Ionic.Zip
Imports Microsoft.Reporting.WebForms

Namespace Controllers
    Public Class ContractController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
#Region "Java"
        Sub ContractSendData(Contract_ID As Integer, user As Integer)
            If db.Tr_ContractSends.Where(Function(x) x.Contract_ID = Contract_ID And x.IsDeleted = False).Any Then
                Dim sendUpdate = db.Tr_ContractSends.Where(Function(x) x.Contract_ID = Contract_ID And x.IsDeleted = False).FirstOrDefault
                sendUpdate.Send_Date = DateTime.Now
                sendUpdate.ModifiedDate = DateTime.Now
                sendUpdate.ModifiedBy = user
            Else
                Dim contract = db.Tr_Contracts.Where(Function(x) x.Contract_ID = Contract_ID).FirstOrDefault
                contract.IsSendedContract = True
                Dim send = New Tr_ContractSends With {.Contract_ID = Contract_ID, .Send_Date = DateTime.Now, .CreatedBy = user, .CreatedDate = DateTime.Now, .IsDeleted = False}
                db.Tr_ContractSends.Add(send)
            End If
            db.SaveChanges()
        End Sub
        Function PrintReceipt(id As String) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            ContractSendData(id, user)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/ContractReceipt.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintContractReceipt(id).ToList
            Dim count = List.Count
            'If List.Count <= 1 Then
            '    Return ""
            'End If
            Dim rd = New ReportDataSource("DS", List)
            lr.DataSources.Add(rd)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>29.7cm</PageWidth>" +
            " <PageHeight>21cm</PageHeight>" +
            " <MarginTop>2.54cm</MarginTop>" +
            " <MarginLeft>2.54cm</MarginLeft>" +
            " <MarginRight>2.54cm</MarginRight>" +
            " <MarginBottom>2.54cm</MarginBottom>" +
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
            'Dim outputStream = New MemoryStream
            'Using zip1 As ZipFile = New ZipFile()
            '    Dim H = Print(id)
            '    If H <> "" Then
            '        zip1.AddFile(H, "")
            '    End If
            '    Report(id, zip1)
            '    zip1.Save(outputStream)
            'End Using
            'outputStream.Position = 0
            Return File(renderedBytes, MimeType)
        End Function
        Function Zip(id As String) As ActionResult
            Dim outputStream = New MemoryStream
            Using zip1 As ZipFile = New ZipFile()
                Dim H = Print(id)
                If H <> "" Then
                    zip1.AddFile(H, "")
                End If
                Report(id, zip1)
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "Contract.zip")
        End Function
        Function Report(id As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/ContractDetail.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_ContractDetailPrint(id).ToList
            Dim count = List.Count
            'If List.Count <= 1 Then
            '    Return ""
            'End If
            Dim rd = New ReportDataSource("DSContractDetail", List)
            lr.DataSources.Add(rd)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>29.7cm</PageWidth>" +
            " <PageHeight>21cm</PageHeight>" +
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
            If count > 1 Then
                zip.AddEntry("Lampiran1.pdf", renderedBytes)
            End If
        End Function
        Function Print(id As Integer) As String
#Region "Sebelum"
            '#If DEBUG Then
            '            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report/OperatingLeaseAgreement.rtf"))
            '#Else
            '            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report2/OperatingLeaseAgreement.rtf"))
            '#End If
            '            Dim query = db.sp_ContractPrint(id).ToList
            '            Dim queryH = query.FirstOrDefault()
            '            strVal = strVal.Replace("[PT]", queryH.Company_Name)
            '            strVal = strVal.Replace("[Contract]", queryH.Contract_No)
            '            strVal = strVal.Replace("[Tgl]", Format(queryH.CreatedDate, "dd/MMM/yyyy"))
            '            strVal = strVal.Replace("[alamat]", queryH.Address)
            '            strVal = strVal.Replace("[Penerima]", queryH.Penerima)
            '            strVal = strVal.Replace("[Tlp]", queryH.Phone)
            '            strVal = strVal.Replace("[Fax]", "")
            '            strVal = strVal.Replace("[Email]", queryH.Email)
            '            strVal = strVal.Replace("[PICEmail]", queryH.PIC_Email)
            '            strVal = strVal.Replace("[PICName]", queryH.PIC_Name)
            '            strVal = strVal.Replace("[Jabatan]", queryH.Jabatan)

            '            Dim no As Integer = 1
            '            For Each i In query
            '                strVal = strVal.Replace("[vehicle" + no.ToString + "]", i.Vehicle)
            '                strVal = strVal.Replace("[platNo" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[locasi" + no.ToString + "]", i.Rent_Location)
            '                strVal = strVal.Replace("[deliveryDate" + no.ToString + "]", If(i.DeliveryDate Is Nothing, "", Format(i.DeliveryDate, "dd/MMM/yyyy")))
            '                strVal = strVal.Replace("[leaseRent" + no.ToString + "]", i.Lease_long)
            '                strVal = strVal.Replace("[start" + no.ToString + "]", If(i.StartDate Is Nothing, "", Format(i.StartDate, "dd/MMM/yyyy")))
            '                strVal = strVal.Replace("[end" + no.ToString + "]", If(i.EndDate Is Nothing, "", Format(i.EndDate, "dd/MMM/yyyy")))
            '                strVal = strVal.Replace("[bidPricePreMoth" + no.ToString + "]", String.Format("{0:n}", i.Bid_PricePerMonth))
            '                strVal = strVal.Replace("[remark" + no.ToString + "]", i.Remark)
            '                no = no + 1
            '            Next
            '            For i = no To 4
            '                strVal = strVal.Replace("[vehicle" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[platNo" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[locasi" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[deliveryDate" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[leaseRent" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[start" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[end" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[bidPricePreMoth" + no.ToString + "]", "")
            '                strVal = strVal.Replace("[remark" + no.ToString + "]", "")
            '                no = no + 1
            '            Next i
            '#If DEBUG Then
            '            System.IO.File.WriteAllText(Server.MapPath("~/Report/OperatingLeaseAgreementPrint.rtf"), strVal)
            '            Return File("~/Report/OperatingLeaseAgreementPrint.rtf", "application/rtf", "OperatingLeaseAgreementPrint.rtf")
            '#Else
            '            System.IO.File.WriteAllText(Server.MapPath("~/Report2/OperatingLeaseAgreementPrint.rtf"), strVal)
            '            Return File("~/Report2/OperatingLeaseAgreementPrint.rtf", "application/rtf", "OperatingLeaseAgreementPrint.rtf")
            '#End If
#End Region

            '#If DEBUG Then
            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report/OperatingLeaseAgreementNew.rtf"))
            '#Else
            '            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report2/OperatingLeaseAgreementNew.rtf"))
            '#End If
            Dim query = db.sp_ContractPrint(id).ToList
            Dim queryH = query.FirstOrDefault()
            strVal = strVal.Replace("[PT]", queryH.Company_Name)
            strVal = strVal.Replace("[Contract]", queryH.Contract_No)
            strVal = strVal.Replace("[Tgl]", Format(queryH.CreatedDate, "dd/MMM/yyyy"))
            strVal = strVal.Replace("[alamat]", queryH.Address)
            strVal = strVal.Replace("[Penerima]", queryH.Penerima)
            strVal = strVal.Replace("[Tlp]", queryH.Phone)
            strVal = strVal.Replace("[Fax]", "")
            strVal = strVal.Replace("[Email]", queryH.Email)
            strVal = strVal.Replace("[PICEmail]", queryH.PIC_Email)
            strVal = strVal.Replace("[PICName]", queryH.PIC_Name)
            strVal = strVal.Replace("[Jabatan]", queryH.Jabatan)

            Dim no As Integer = 1
            For Each i In query
                strVal = strVal.Replace("[vehicle" + no.ToString + "]", i.Vehicle)
                strVal = strVal.Replace("[platNo" + no.ToString + "]", "")
                strVal = strVal.Replace("[locasi" + no.ToString + "]", i.Rent_Location)
                strVal = strVal.Replace("[deliveryDate" + no.ToString + "]", If(i.DeliveryDate Is Nothing, "", Format(i.DeliveryDate, "dd/MMM/yyyy")))
                strVal = strVal.Replace("[leaseRent" + no.ToString + "]", i.Lease_long)
                strVal = strVal.Replace("[start" + no.ToString + "]", If(i.StartDate Is Nothing, "", Format(i.StartDate, "dd/MMM/yyyy")))
                strVal = strVal.Replace("[end" + no.ToString + "]", If(i.EndDate Is Nothing, "", Format(i.EndDate, "dd/MMM/yyyy")))
                strVal = strVal.Replace("[bidPricePreMoth" + no.ToString + "]", String.Format("{0:n}", i.Bid_PricePerMonth))
                strVal = strVal.Replace("[remark" + no.ToString + "]", i.Remark)
                no = no + 1
            Next
            For i = no To 4
                strVal = strVal.Replace("[vehicle" + no.ToString + "]", "")
                strVal = strVal.Replace("[platNo" + no.ToString + "]", "")
                strVal = strVal.Replace("[locasi" + no.ToString + "]", "")
                strVal = strVal.Replace("[deliveryDate" + no.ToString + "]", "")
                strVal = strVal.Replace("[leaseRent" + no.ToString + "]", "")
                strVal = strVal.Replace("[start" + no.ToString + "]", "")
                strVal = strVal.Replace("[end" + no.ToString + "]", "")
                strVal = strVal.Replace("[bidPricePreMoth" + no.ToString + "]", "")
                strVal = strVal.Replace("[remark" + no.ToString + "]", "")
                no = no + 1
            Next i
            '#If DEBUG Then
            System.IO.File.WriteAllText(Server.MapPath("~/Report/OperatingLeaseAgreementPrint.rtf"), strVal)
            Return Server.MapPath("~/Report/OperatingLeaseAgreementPrint.rtf")
            '#Else
            '            System.IO.File.WriteAllText(Server.MapPath("~/Report2/OperatingLeaseAgreementPrint.rtf"), strVal)
            '            Return Server.MapPath("~/Report2/OperatingLeaseAgreementPrint.rtf")
            '#End If
        End Function
#End Region
        ' GET: Contract Receipt
        Function IndexDelivery(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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

            Dim Query = (From A In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False)
                         Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals C.Vehicle_id Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Group Join D In db.Tr_SetDeliveryDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals D.ContractDetail_ID Into AD = Group
                         From D In AD.DefaultIfEmpty()
                         Where A.IsDelivery = False And A.Vehicle_ID IsNot Nothing
                         Select A.ContractDetail_ID, B.CompanyGroup_Name, B.Company_Name, B.Brand_Name, B.Vehicle, C.license_no, C.Tmp_Plat, D.Tr_SetDeliveries.DeliveryDate, A.Tr_Contracts.IsSetDelivery, A.CreatedDate).
                Select(Function(x) New Tr_ContractDetail With {.ContractDetail_ID = x.ContractDetail_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Brand_Name = x.Brand_Name,
                .Vehicle = x.Vehicle, .Delivery_Date = x.DeliveryDate, .IsSetDelivery = x.IsSetDelivery, .license_no = If(x.license_no, x.Tmp_Plat), .CreatedDate = x.CreatedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Brand_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString) OrElse s.license_no.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Brand_Name"
                    Query = Query.OrderBy(Function(s) s.Brand_Name)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Vehicle)
                Case "license_no"
                    Query = Query.OrderBy(Function(s) s.license_no)
                Case Else
                    Query = Query.OrderBy(Function(s) s.Delivery_Date)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            Return View(Query)
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function FileUploadDelivery(file As HttpPostedFileBase, model As Tr_Delivery) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim valid = True
            If (model.Delivery_Method = "Expedition") Then
                If model.Expedition_Name Is Nothing Then
                    ModelState.AddModelError("Expedition_Name", "Must Fill Expedition Name")
                End If
            End If
            If (model.Delivery_Method = "TKS Operation") Then
                If model.Driver_ID Is Nothing Then
                    ModelState.AddModelError("Driver_ID", "Must Fill Driver Name")
                End If
            End If
            If ModelState.IsValid Then
                If file IsNot Nothing Then
                    Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Delivery"), model.ContractDetail_ID.ToString() + ".pdf")
                    Dim Con = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = model.ContractDetail_ID).FirstOrDefault
                    If Not Con Is Nothing Then
                        Using dbs = db.Database.BeginTransaction
                            Try
                                Con.IsDelivery = True
                                Dim Del As New Tr_Deliverys
                                Del.ContractDetail_ID = model.ContractDetail_ID
                                Del.Delivery_Method = model.Delivery_Method
                                Del.Expedition_Name = model.Expedition_Name
                                Del.Driver_ID = model.Driver_ID
                                Del.BSTK_Date = model.BSTK_Date
                                Del.CreatedBy = user
                                Del.CreatedDate = DateTime.Now
                                Del.IsDeleted = False
                                db.Tr_Deliverys.Add(Del)
                                db.SaveChanges()
                                Dim contractDetaiH = New Tr_ContractDetailHistorys
                                contractDetaiH.ID = Del.Delivery_ID
                                contractDetaiH.Status = "Delivery"
                                contractDetaiH.Date = Del.BSTK_Date
                                Dim vehicle_ID = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = model.ContractDetail_ID).Select(Function(x) x.Vehicle_ID).FirstOrDefault
                                contractDetaiH.Vehicle_ID = vehicle_ID
                                contractDetaiH.ContractDetail_ID = Del.ContractDetail_ID
                                contractDetaiH.CreatedBy = user
                                contractDetaiH.CreatedDate = DateTime.Now
                                contractDetaiH.IsDeleted = False
                                db.Tr_ContractDetailHistorys.Add(contractDetaiH)
                                db.SaveChanges()
                                file.SaveAs(path)
                                Using ms As MemoryStream = New MemoryStream()
                                    file.InputStream.CopyTo(ms)
                                    Dim array As Byte() = ms.GetBuffer()
                                End Using
                                dbs.Commit()
                                Return RedirectToAction("IndexDelivery", "Contract")
                            Catch ex As Exception
                                dbs.Rollback()
                            End Try
                        End Using
                    End If
                Else
                    ModelState.AddModelError("Delivery_ID", "Must Fill Upload File")
                End If
            End If
            Return View("Delivery", model)
        End Function
        Function Delivery(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Query = (From A In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False)
                         Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals C.Vehicle_id Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Join D In db.Tr_SetDeliveries On A.Contract_ID Equals D.Contract_ID
                         Where A.IsDelivery = False And A.Vehicle_ID IsNot Nothing And A.ContractDetail_ID = id
                         Select A.ContractDetail_ID, B.CompanyGroup_Name, B.Company_Name, B.Brand_Name, B.Vehicle, C.license_no, C.Tmp_Plat, A.CreatedDate, D.DeliveryDate, D.Address_Delivery, D.PIC_Name, D.PIC_Number).
                Select(Function(x) New Tr_Delivery With {.ContractDetail_ID = x.ContractDetail_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Brand_Name = x.Brand_Name,
                .Vehicle = x.Vehicle, .license_no = If(x.license_no, x.Tmp_Plat), .CreatedDate = x.CreatedDate, .DeliveryDate = x.DeliveryDate, .Address_Delivery = x.Address_Delivery, .PIC_Name = x.PIC_Name, .PIC_Number = x.PIC_Number}).FirstOrDefault


            'Dim tr_Applications = (From A In db.Tr_Applications
            '                       Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
            '                       From B In AB.DefaultIfEmpty
            '                       Where A.Application_ID = id
            '                       Select B.CompanyGroup_Name, B.Company_Name, B.Vehicle, B.Lease_price, B.Qty, B.Amount, B.Bid_PricePerMonth).Select(
            '                       Function(x) New Tr_Application With {.Application_ID = id, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .Vehicle = x.Vehicle, .Lease_price = CType(x.Lease_price, Decimal?),
            '                       .Qty = x.Qty, .Amount = CType(x.Amount, Decimal?), .Bid_PricePerMonth = CType(x.Bid_PricePerMonth, Decimal?)}).FirstOrDefault()
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Dim myPT As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TKS Operation",
                    .Value = "TKS Operation"
                },
                New SelectListItem With {
                    .Text = "Expedition",
                    .Value = "Expedition"
                }
            }
            ViewBag.Driver_ID = New SelectList(db.Cn_Users.OrderBy(Function(a) a.User_Name).Where(Function(x) x.Division_ID = 15), "User_ID", "User_Name")
            ViewBag.Delivery_Method = New SelectList(myPT, "Value", "Text")
            Return View(Query)
        End Function
        Function IndexSend(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
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

            Dim Query = (From A In db.Tr_ContractDrafts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDeleted = False And A.Tr_Contracts.IsDraftedContract = True And A.Tr_Contracts.IsReceiptContract = False
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.TypeContract, A.Description, A.CreatedDate).
                Select(Function(x) New Tr_Contract_Draft With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No, .TypeContract = x.TypeContract, .Description = x.Description, .CreatedDate = x.CreatedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            Return View(Query)
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function EditDraft(model As Tr_Contract_DraftEdit) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Dim draft = db.Tr_ContractDrafts.Where(Function(x) x.IsDeleted = False And x.ContractDraft_ID = model.ContractDraft_ID).FirstOrDefault
                draft.TypeContract = model.TypeContract
                draft.Description = model.Description
                draft.ModifiedDate = DateTime.Now
                draft.ModifiedBy = user
                If model.IsDraftContractFile IsNot Nothing Then
                    Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/ContractDraft"), draft.ContractDraft_ID.ToString() + ".pdf")
                    model.IsDraftContractFile.SaveAs(path)
                    Using ms As MemoryStream = New MemoryStream()
                        model.IsDraftContractFile.InputStream.CopyTo(ms)
                        Dim array As Byte() = ms.GetBuffer()
                    End Using
                End If
                db.SaveChanges()
                Return RedirectToAction("IndexEditDraft")
            End If

            Dim type As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PPJB",
                    .Value = "PPJB"
                },
                New SelectListItem With {
                    .Text = "Contract Master",
                    .Value = "Contract Master"
                },
                New SelectListItem With {
                    .Text = "Appendix",
                    .Value = "Appendix"
                },
                New SelectListItem With {
                    .Text = "Schedule",
                    .Value = "Schedule"
                },
                New SelectListItem With {
                    .Text = "Addendum",
                    .Value = "Addendum"
                },
                New SelectListItem With {
                    .Text = "Amandment",
                    .Value = "Amandment"
                }
            }
            ViewBag.TypeContract = New SelectList(type, "Value", "Text", model.TypeContract)
            Return View(model)
        End Function

        Function EditDraft(ByVal id As Integer?) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim draft = (From A In db.Tr_ContractDrafts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDraftedContract And A.ContractDraft_ID = id
                         Select A.ContractDraft_ID, B.Contract_No, B.Company_Name, A.Tr_Contracts.Penerima, A.Tr_Contracts.Jabatan, CreatedBy = A.Cn_Users.User_Name, A.CreatedDate,
                             ModifiedBy = A.Cn_Users1.User_Name, A.ModifiedDate, A.TypeContract, A.Description).
                Select(Function(x) New Tr_Contract_DraftEdit With {.ContractDraft_ID = x.ContractDraft_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No, .TypeContract = x.TypeContract, .Description = x.Description}).FirstOrDefault
            If IsNothing(draft) Then
                Return HttpNotFound()
            End If
            Dim type As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PPJB",
                    .Value = "PPJB"
                },
                New SelectListItem With {
                    .Text = "Contract Master",
                    .Value = "Contract Master"
                },
                New SelectListItem With {
                    .Text = "Appendix",
                    .Value = "Appendix"
                },
                New SelectListItem With {
                    .Text = "Schedule",
                    .Value = "Schedule"
                },
                New SelectListItem With {
                    .Text = "Addendum",
                    .Value = "Addendum"
                },
                New SelectListItem With {
                    .Text = "Amandment",
                    .Value = "Amandment"
                }
            }
            ViewBag.TypeContract = New SelectList(type, "Value", "Text", draft.TypeContract)
            Return View(draft)
        End Function
        Function IndexEditDraft(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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

            'nga bisa di jadiin 1 sama yg Edit Data Draft karna kalo di Tablenya yg di parameterin hanya IsDraftedContract
            Dim Query = (From A In db.Tr_ContractDrafts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDraftedContract
                         Select A.ContractDraft_ID, B.Contract_No, B.Company_Name, A.Tr_Contracts.Penerima, A.Tr_Contracts.Jabatan, CreatedBy = A.Cn_Users.User_Name, A.CreatedDate,
                             ModifiedBy = A.Cn_Users1.User_Name, A.ModifiedDate, A.TypeContract, A.Description).
                Select(Function(x) New Tr_Contract_Draft With {.ContractDraft_ID = x.ContractDraft_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No,
                .Penerima = x.Penerima, .Jabatan = x.Jabatan, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy,
                .ModifiedDate = x.ModifiedDate, .TypeContract = x.TypeContract, .Description = x.Description})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Penerima.Contains(searchString) OrElse s.Jabatan.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
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

            Return View(Query)
        End Function
        Function IndexDraft(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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

            'nga bisa di jadiin 1 sama yg Edit Data Draft karna kalo di Tablenya yg di parameterin hanya IsDraftedContract
            Dim Query = (From A In db.Tr_Contracts
                         Group Join B In db.V_ProspectCusts On A.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Tr_ContractDrafts.Where(Function(x) x.IsDeleted = False) On A.Contract_ID Equals C.Contract_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.IsDraftedContract = False
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.Penerima, A.Jabatan, CreatedBy = A.Cn_Users.User_Name, A.CreatedDate,
                             ModifiedBy = A.Cn_Users1.User_Name, A.ModifiedDate, A.Tr_ContractDrafts, C.TypeContract, C.Description).
                Select(Function(x) New Tr_Contract With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No,
                .Penerima = x.Penerima, .Jabatan = x.Jabatan, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy,
                .ModifiedDate = x.ModifiedDate, .TypeContract = x.TypeContract, .Description = x.Description})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Penerima.Contains(searchString) OrElse s.Jabatan.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
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

            Return View(Query)
        End Function
        ' GET: Contract Receipt
        Function IndexListReceipt(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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

            Dim Query = (From A In db.Tr_ContractReceipts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Tr_ContractDrafts.Where(Function(x) x.IsDeleted = False) On A.Contract_ID Equals C.Contract_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDeleted = False And A.Tr_Contracts.IsDraftedContract = True And A.Tr_Contracts.IsReceiptContract = True And
                             A.Tr_Contracts.IsSendedContract = True
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, C.TypeContract, C.Description, CreatedBy = A.Cn_Users.User_Name, A.CreatedDate, ModifiedBy = A.Cn_Users1.User_Name, A.ModifiedDate).
                Select(Function(x) New Tr_Contract_Receipt With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No,
                .TypeContract = x.TypeContract, .Description = x.Description, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function

        Function IndexReceipt(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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

            Dim Query = (From A In db.Tr_ContractDrafts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Tr_ContractSends.Where(Function(x) x.IsDeleted = False) On A.Tr_Contracts.Contract_ID Equals C.Contract_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDeleted = False And A.Tr_Contracts.IsDraftedContract = True And
                             A.Tr_Contracts.IsSendedContract = True And A.Tr_Contracts.IsReceiptContract = False
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.TypeContract, A.Description, CreatedBy = C.Cn_Users.User_Name, C.CreatedDate, ModifiedBy = C.Cn_Users1.User_Name, C.ModifiedDate).
                Select(Function(x) New Tr_Contract_Send With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No,
                .TypeContract = x.TypeContract, .Description = x.Description, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Penerima.Contains(searchString) OrElse s.Jabatan.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function ContractReceipt(model As Tr_Contract_Receipt) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Dim Con = db.Tr_Contracts.Where(Function(x) x.Contract_ID = model.Contract_ID).FirstOrDefault
                If Not Con Is Nothing Then
                    Using dbs = db.Database.BeginTransaction
                        Try
                            Con.IsReceiptContract = True
                            Dim ConRec As New Tr_ContractReceipts
                            ConRec.Contract_ID = Con.Contract_ID
                            ConRec.CreatedBy = user
                            ConRec.CreatedDate = DateTime.Now
                            ConRec.IsDeleted = False
                            db.Tr_ContractReceipts.Add(ConRec)
                            db.SaveChanges()
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/ContractReceipt"), model.Contract_ID.ToString() + ".pdf")
                            Dim path1 As String = System.IO.Path.Combine(Server.MapPath("~/Image/Receipt"), model.Contract_ID.ToString() + ".pdf")
                            model.ContractFile.SaveAs(path)
                            model.ContractFile.SaveAs(path1)
                            Using ms As MemoryStream = New MemoryStream()
                                model.ContractFile.InputStream.CopyTo(ms)
                                Dim array As Byte() = ms.GetBuffer()
                            End Using
                            dbs.Commit()
                            Return RedirectToAction("IndexReceipt", "Contract")
                        Catch ex As Exception
                            dbs.Rollback()
                        End Try
                    End Using
                End If
            End If
            Return View(model)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function DraftContract(model As Tr_Contract_Draft) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim Con = db.Tr_Contracts.Where(Function(x) x.Contract_ID = model.Contract_ID).FirstOrDefault
                        If Not Con Is Nothing Then
                            Con.IsDraftedContract = True
                            Dim ConDraft As New Tr_ContractDrafts
                            ConDraft.Contract_ID = Con.Contract_ID
                            ConDraft.Description = model.Description
                            ConDraft.CreatedBy = user
                            ConDraft.CreatedDate = DateTime.Now
                            ConDraft.IsDeleted = False
                            db.Tr_ContractDrafts.Add(ConDraft)
                            db.SaveChanges()
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/ContractDraft"), ConDraft.ContractDraft_ID.ToString() + ".pdf")
                            model.IsDraftContractFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                model.IsDraftContractFile.InputStream.CopyTo(ms)
                                Dim array As Byte() = ms.GetBuffer()
                            End Using
                        End If
                        dbs.Commit()
                        Return RedirectToAction("IndexDraft", "Contract")
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("IsDraftContractFile", ex.Message)
                    End Try
                End Using
            End If
            Return View(model)
        End Function
        Function DraftContract(ByVal id As Integer?) As ActionResult

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Query = (From A In db.Tr_Contracts
                         Group Join C In db.Tr_ApprovalApps On A.ApprovalApp_ID Equals C.ApprovalApp_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Group Join B In db.V_ProspectCusts On C.ApplicationHeader_ID Equals B.ApplicationHeader_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.IsDraftedContract = False And A.Contract_ID = id
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.Penerima, A.Jabatan, A.CreatedBy, A.CreatedDate, A.ModifiedBy, A.ModifiedDate).
                Select(Function(x) New Tr_Contract_Draft With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No, .Penerima = x.Penerima, .Jabatan = x.Jabatan, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate}).FirstOrDefault
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Dim type As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PPJB",
                    .Value = "PPJB"
                },
                New SelectListItem With {
                    .Text = "Contract Master",
                    .Value = "Contract Master"
                },
                New SelectListItem With {
                    .Text = "Appendix",
                    .Value = "Appendix"
                },
                New SelectListItem With {
                    .Text = "Schedule",
                    .Value = "Schedule"
                },
                New SelectListItem With {
                    .Text = "Addendum",
                    .Value = "Addendum"
                },
                New SelectListItem With {
                    .Text = "Amandment",
                    .Value = "Amandment"
                }
            }
            ViewBag.TypeContract = New SelectList(type, "Value", "Text")
            Return View(Query)
        End Function
        Function ContractReceipt(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Query = (From A In db.Tr_ContractDrafts
                         Group Join B In db.V_ProspectCusts On A.Tr_Contracts.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Group Join C In db.Tr_ContractSends.Where(Function(x) x.IsDeleted = False) On A.Tr_Contracts.Contract_ID Equals C.Contract_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Where A.IsDeleted = False And A.Tr_Contracts.IsDeleted = False And A.Tr_Contracts.IsDraftedContract = True And
                             A.Tr_Contracts.IsSendedContract = True And A.Tr_Contracts.IsReceiptContract = False And A.Contract_ID = id
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.TypeContract, A.Description, CreatedBy = C.Cn_Users.User_Name, C.CreatedDate, ModifiedBy = C.Cn_Users1.User_Name, C.ModifiedDate).
                Select(Function(x) New Tr_Contract_Receipt With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No,
                .TypeContract = x.TypeContract, .Description = x.Description, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate}).FirstOrDefault

            If IsNothing(Query) Then
                Return HttpNotFound()
            End If

            Return View(Query)
        End Function
        ' GET: Contract
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

            Dim Query = (From A In db.Tr_Contracts
                         Group Join C In db.Tr_ApprovalApps On A.ApprovalApp_ID Equals C.ApprovalApp_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Group Join B In db.V_ProspectCusts On C.ApplicationHeader_ID Equals B.ApplicationHeader_ID Into AB = Group
                         From B In AB.DefaultIfEmpty()
                         Where A.IsDeleted = False
                         Select A.Contract_ID, B.Contract_No, B.Company_Name, A.Penerima, A.Jabatan, A.PerMonth, A.CreatedBy, A.CreatedDate, A.ModifiedBy, A.ModifiedDate).
                Select(Function(x) New Tr_Contract With {.Contract_ID = x.Contract_ID, .Company_Name = x.Company_Name, .Contract_No = x.Contract_No, .Penerima = x.Penerima, .Jabatan = x.Jabatan, .PerMonth = x.PerMonth, .CreatedBy = x.CreatedBy, .CreatedDate = x.CreatedDate, .ModifiedBy = x.ModifiedBy, .ModifiedDate = x.ModifiedDate})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Penerima.Contains(searchString) OrElse s.Jabatan.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
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

            Return View(Query)
        End Function

        ' GET: Contract/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Contracts As Tr_Contracts = Await db.Tr_Contracts.FindAsync(id)
            If IsNothing(tr_Contracts) Then
                Return HttpNotFound()
            End If
            Return View(tr_Contracts)
        End Function

        ' GET: Contract/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Contracts As Tr_Contracts = Await db.Tr_Contracts.FindAsync(id)
            If IsNothing(tr_Contracts) Then
                Return HttpNotFound()
            End If
            Dim Detail = db.sp_ContractGetDetail(id)
            Dim myPT As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = 1,
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = 3,
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = 12,
                    .Value = 12
                }
            }
            ViewBag.PerMonth = New SelectList(myPT, "Value", "Text", tr_Contracts.PerMonth)
            ViewBag.Detail = Detail
            Return View(tr_Contracts)
        End Function
        Function EditNew(ByVal id As Integer?) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Detail = db.sp_ContractGetDetail(id).
                Select(Function(x) New Tr_ContractGetDetail With {.ContractDetail_ID = x.ContractDetail_ID, .Application_ID = x.Application_ID,
                .Company_Name = x.Company_Name, .Vehicle = x.Vehicle, .Rent_Location = x.Rent_Location, .DeliveryDate = x.DeliveryDate, .Lease_long = x.Lease_long,
                .StartDate = x.StartDate, .EndDate = x.EndDate, .Bid_PricePerMonth = x.Bid_PricePerMonth, .Remark = x.Remark})
            Dim tr_Contracts = db.Tr_Contracts.Where(Function(x) x.Contract_ID = id).
                Select(Function(x) New Tr_Contract With {.Contract_ID = x.Contract_ID, .Contract_No = x.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, .Penerima = x.Penerima, .Jabatan = x.Jabatan, .PerMonth = x.PerMonth, .Detail = Detail}).FirstOrDefault
            If IsNothing(tr_Contracts) Then
                Return HttpNotFound()
            End If
            Dim myPT As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = 1,
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = 3,
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = 12,
                    .Value = 12
                }
            }
            ViewBag.PerMonth = New SelectList(myPT, "Value", "Text", tr_Contracts.PerMonth)
            ViewBag.Detail = Detail
            Return View(tr_Contracts)
        End Function

        ' POST: Contract/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Async Function Edit(<Bind(Include:="Contract_ID,Approval_ID,Contract_No,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Contracts As Tr_Contracts) As Task(Of ActionResult)
        '    If ModelState.IsValid Then
        '        db.Entry(tr_Contracts).State = EntityState.Modified
        '        Await db.SaveChangesAsync()
        '        Return RedirectToAction("Index")
        '    End If
        '    ViewBag.Approval_ID = New SelectList(db.Tr_Approvals, "Approval_ID", "MakerBy", tr_Contracts.Approval_ID)
        '    Return View(tr_Contracts)
        'End Function

        Public Function EditOrder(Contract_ID As Integer?, Penerima As String, Jabatan As String, PerMonth As Nullable(Of Integer), order() As Tr_ContractDetail) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim result As String = "Error"
            Dim message As String = ""
            Dim Valid As Boolean = True

            If (Penerima = "") Then
                Valid = False
                message = "Penerima is Nothing"
            ElseIf (Jabatan = "") Then
                Valid = False
                message = "Jabatan is Nothing"
            ElseIf (PerMonth Is Nothing) Then
                Valid = False
                message = "PerMonth is Nothing"
            End If
            If Not Valid Then
                Return Json(New With {Key .result = "false", Key .message = message})
            End If

            Dim tr_Contracts = db.Tr_Contracts.Where(Function(x) x.Contract_ID = Contract_ID).FirstOrDefault
            If Not order Is Nothing Then
                tr_Contracts.Penerima = Penerima
                tr_Contracts.Jabatan = Jabatan
                tr_Contracts.PerMonth = PerMonth
                tr_Contracts.ModifiedBy = user
                tr_Contracts.ModifiedDate = DateTime.Now
                For Each item In order
                    Dim D = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = item.ContractDetail_ID).FirstOrDefault
                    D.DeliveryDate = item.DeliveryDate
                    D.StartDate = item.StartDate
                    D.EndDate = item.EndDate
                    D.Remark = item.Remark
                    D.ModifiedBy = user
                    D.ModifiedDate = DateTime.Now
                Next
                db.SaveChanges()
                result = "Success"
            End If
            Return Json(New With {Key .result = result}, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Contract/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Contracts As Tr_Contracts = Await db.Tr_Contracts.FindAsync(id)
            If IsNothing(tr_Contracts) Then
                Return HttpNotFound()
            End If
            Return View(tr_Contracts)
        End Function

        ' POST: Contract/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim tr_Contracts As Tr_Contracts = Await db.Tr_Contracts.FindAsync(id)
            db.Tr_Contracts.Remove(tr_Contracts)
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
