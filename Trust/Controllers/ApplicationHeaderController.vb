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
Imports Microsoft.Reporting.WebForms
Imports Ionic.Zip
Imports System.IO
Imports PagedList

Namespace Controllers
    Public Class ApplicationHeaderController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Private calControl As New CalculateController
        Private quotControl As New QuotationController

#Region "Declare"
        ReadOnly Customer_Class As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Japanese",
                    .Value = "Japanese"
                },
                New SelectListItem With {
                    .Text = "Non-Japanese",
                    .Value = "Non-Japanese"
                }
            }
        ReadOnly Contracted_by As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "PT Takari Kokoh Sejahtera",
                    .Value = "PT Takari Kokoh Sejahtera"
                },
                New SelectListItem With {
                    .Text = "PT Takari Sumber Mulia",
                    .Value = "PT Takari Sumber Mulia"
                }
            }
        ReadOnly IsTruck As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Non Truck",
                    .Value = False
                },
                New SelectListItem With {
                    .Text = "Truck",
                    .Value = True
                }
            }
        ReadOnly IsQuick As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "-",
                    .Value = False
                },
                New SelectListItem With {
                    .Text = "Quick",
                    .Value = True
                }
            }
        ReadOnly IsCode_Open As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Non Open",
                    .Value = "Non Open"
                }
            }
        ReadOnly ApplicationType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "New Transaction",
                    .Value = "New Transaction"
                },
                New SelectListItem With {
                    .Text = "List Extantion",
                    .Value = "List Extantion"
                },
                 New SelectListItem With {
                    .Text = "Agrement Transfer",
                    .Value = "Agrement Transfer"
                },
                 New SelectListItem With {
                    .Text = "Permanet Extantion",
                    .Value = "Permanet Extantion"
                },
                 New SelectListItem With {
                    .Text = "Changing Application",
                    .Value = "Changing Application"
                }
            }
        ReadOnly PeriodeType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Not Open",
                    .Value = "Not Open"
                }
           }

        Sub Validasi(Header As Tr_ApplicationHeader, ByRef Valid As Boolean, ByRef Message As String, order As Tr_Application(), Optional Status As String = "Create")
            If (Status = "Create" And Header.Approval_ID = Nothing) Then
                Valid = False
                Message = "Please Fill Customer"
            End If

            'cek kalo customer baru
            If Valid Then
                If (Header.Credit_Rating Is Nothing) Then
                    Valid = False
                    Message = "Master Customer: Please Fill Credit Rating"
                ElseIf (Header.Customer_Class Is Nothing) Then
                    Valid = False
                    Message = "Master Customer: You must Fill Customer Class"
                ElseIf (Header.Expec_Contract_Date Is Nothing) Then
                    Valid = False
                    Message = "Master Customer: You must Fill Expec Contract Date"
                End If
            End If
            'kalo nga ada detail
            If (Valid And order Is Nothing) Then
                Valid = False
                Message = "You must Fill Customer Class"
                'Cek kalau di Expec Contrak nya kosong
            ElseIf order.Where(Function(x) x.Code_Open Is Nothing).Any Then
                Valid = False
                Message = "You must Fill Code Open"
            ElseIf order.Where(Function(x) x.Expec_Delivery_Date Is Nothing).Any Then
                Valid = False
                Message = "You must Fill Expec Delivery Date"
            End If
        End Sub
#End Region
#Region "Java"

        Private Sub ReportView(id As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/ApplicationTmpView.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationDetailNew(id).ToList
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
            " <MarginTop>1cm</MarginTop>" +
            " <MarginLeft>1.5cm</MarginLeft>" +
            " <MarginRight>0.5cm</MarginRight>" +
            " <MarginBottom>1cm</MarginBottom>" +
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
            zip.AddEntry("Application.pdf", renderedBytes)
            'If count > 1 Then
            'End If
        End Sub
        Function Views(id As String) As ActionResult
            Try

                Dim outputStream = New MemoryStream
                Using zip1 As ZipFile = New ZipFile()
                    ReportView(id, zip1)
                    Dim application = db.V_ProspectCustDetails.Where(Function(x) x.ApplicationHeader_ID = id).ToList
                    For Each i In application
                        ReportCal(i.Application_ID, zip1)
                        ReportCalCashFlow(i.Application_ID, zip1)
                        quotControl.ReportCal(i.Calculate_ID, zip1)
                        quotControl.ReportCalCashFlow(i.Calculate_ID, zip1)
                    Next

                    zip1.Save(outputStream)
                End Using
                outputStream.Position = 0
                Return File(outputStream, "application/zip", "Application.zip")
            Catch ex As Exception
                TempData("ErrorMessage") = ex.Message
                Return RedirectToAction("Errors")
            End Try
        End Function

        <HandleError>
        Function Zip(id As String) As ActionResult
            Try

                Dim outputStream = New MemoryStream
                Using zip1 As ZipFile = New ZipFile()
                    'Dim H = Print(id)
                    'If H <> "" Then
                    '    zip1.AddFile(H, "")
                    'End If
                    Dim count = db.V_ApplicationHD.Where(Function(x) x.ApplicationHeader_ID = id).Count
                    Dim q = db.V_ProspectCusts.Where(Function(x) x.ApplicationHeader_ID = id).FirstOrDefault
                    'ReportNewAtt(id, zip1, q.Transaction_Type)
                    'ReportNewAttDet(id, zip1, q.Transaction_Type)
                    If count = 1 Then
                        ReportNew(id, zip1, q.Transaction_Type)
                    Else
                        ReportNewAtt(id, zip1, q.Transaction_Type)
                        ReportNewAttDet(id, zip1, q.Transaction_Type)
                    End If
                    If q.Transaction_Type = "COP" Then
                        ReportCOP(id, zip1)
                    End If
                    zip1.AddFile(Server.MapPath("~/Image/POFromCustomer/" + q.Quotation_ID.ToString + ".pdf"), "")
                    Dim application = db.V_ProspectCustDetails.Where(Function(x) x.ApplicationHeader_ID = id).ToList
                    For Each i In application
                        ReportCal(i.Application_ID, zip1)
                        ReportCalCashFlow(i.Application_ID, zip1)
                        'quotControl.ReportCal(i.Calculate_ID, zip1)
                        'quotControl.ReportCalCashFlow(i.Calculate_ID, zip1)
                    Next

                    zip1.Save(outputStream)
                End Using
                outputStream.Position = 0
                Return File(outputStream, "application/zip", "Application.zip")
            Catch ex As Exception
                TempData("ErrorMessage") = ex.Message
                Return RedirectToAction("Errors")
            End Try
        End Function
        Sub ReportCalCashFlow(Application_ID As String, zip As ZipFile)
            Try
                Dim lr = New LocalReport()
                Dim path = Server.MapPath("~/Report/CalculateApplicationCashFlow.rdlc")
                If (System.IO.File.Exists(path)) Then
                    lr.ReportPath = path
                End If
                Dim List = db.sp_PrintApplicationCashFlow(Application_ID).ToList
                Dim rd = New ReportDataSource("DSPrintApplicationCashFlow", List)
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
                " <MarginTop>0cm</MarginTop>" +
                " <MarginLeft>0cm</MarginLeft>" +
                " <MarginRight>0cm</MarginRight>" +
                " <MarginBottom>0cm</MarginBottom>" +
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

                zip.AddEntry(List.FirstOrDefault.Type.Replace("/", "") + " " + Application_ID.ToString + " CashFlow.pdf", renderedBytes)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        Sub ReportCal(Application_ID As String, zip As ZipFile)
            Try
                Dim lr = New LocalReport()
                Dim path = Server.MapPath("~/Report/CalculateApplication.rdlc")
                If (System.IO.File.Exists(path)) Then
                    lr.ReportPath = path
                End If
                Dim List = db.sp_PrintApplication(Application_ID).ToList
                Dim rd = New ReportDataSource("DSCalculateApplication", List)
                lr.DataSources.Add(rd)
                Dim reportType = "PDF"
                Dim MimeType As String = MimeMapping.GetMimeMapping(path)
                Dim endcoding As String
                Dim fileNameExtension As String = ".pdf"

                Dim deviceInfo =
                "<DeviceInfo>" +
                " <OutputFormat>" + "PDF" + "</OutputFormat>" +
                " <PageWidth>8.3in</PageWidth>" +
                " <PageHeight>11in</PageHeight>" +
                " <MarginTop>0.3in</MarginTop>" +
                " <MarginLeft>0.3in</MarginLeft>" +
                " <MarginRight>0.3in</MarginRight>" +
                " <MarginBottom>0.3in</MarginBottom>" +
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

                zip.AddEntry(List.FirstOrDefault.Vehicle.Replace("/", "") + " " + Application_ID.ToString + ".pdf", renderedBytes)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        Private Sub ReportNew(id As String, zip As ZipFile, Transaction_Type As String)
            Dim lr = New LocalReport()
            'Dim path = Server.MapPath("~/Report/ApplicationNew.rdlc")
            Dim path = ""
            If (Transaction_Type = "COP") Then
                path = Server.MapPath("~/Report/ApplicationTmpCOP.rdlc")
            Else
                path = Server.MapPath("~/Report/ApplicationTmpOPL.rdlc")
            End If
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationDetailNew(id).ToList
            'Dim count = List.Count
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
            " <MarginTop>1cm</MarginTop>" +
            " <MarginLeft>1.5cm</MarginLeft>" +
            " <MarginRight>0.5cm</MarginRight>" +
            " <MarginBottom>1cm</MarginBottom>" +
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
            zip.AddEntry("Application.pdf", renderedBytes)
            'If count > 1 Then
            'End If
        End Sub
        Private Sub ReportNewAtt(id As String, zip As ZipFile, Transaction_Type As String)
            Dim lr = New LocalReport()
            'Dim path = Server.MapPath("~/Report/ApplicationNew.rdlc")
            Dim path = ""
            path = Server.MapPath("~/Report/ApplicationTmpAtt.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationDetailNew(id).ToList
            'Dim count = List.Count
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
            " <MarginTop>1cm</MarginTop>" +
            " <MarginLeft>1.5cm</MarginLeft>" +
            " <MarginRight>0.5cm</MarginRight>" +
            " <MarginBottom>1cm</MarginBottom>" +
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
            zip.AddEntry("Application.pdf", renderedBytes)
            'If count > 1 Then
            'End If
        End Sub
        Private Sub ReportNewAttDet(id As String, zip As ZipFile, Transaction_Type As String)
            Dim lr = New LocalReport()
            'Dim path = Server.MapPath("~/Report/ApplicationNew.rdlc")
            Dim path = ""
            If (Transaction_Type = "COP") Then
                path = Server.MapPath("~/Report/ApplicationTmpAttDetCOP.rdlc")
            Else
                path = Server.MapPath("~/Report/ApplicationTmpAttDetOPL.rdlc")
            End If
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationDetailNew(id).ToList
            'Dim count = List.Count
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
            " <MarginTop>1cm</MarginTop>" +
            " <MarginLeft>1cm</MarginLeft>" +
            " <MarginRight>1cm</MarginRight>" +
            " <MarginBottom>1cm</MarginBottom>" +
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
            zip.AddEntry("ApplicationDet.pdf", renderedBytes)
        End Sub

        Private Sub ReportCOP(id As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/ManajementConsent.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationCOP(id).ToList
            'Dim count = List.Count
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
            " <PageWidth>21cm</PageWidth>" +
            " <PageHeight>29.7cm</PageHeight>" +
            " <MarginTop>2cm</MarginTop>" +
            " <MarginLeft>2cm</MarginLeft>" +
            " <MarginRight>2cm</MarginRight>" +
            " <MarginBottom>2cm</MarginBottom>" +
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
            zip.AddEntry("ApplicationCOP.pdf", renderedBytes)
            'If count > 1 Then
            'End If
        End Sub
        Function Report(id As String, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/Application.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If

            Dim List = db.sp_PrintApplicationDetail(id).ToList
            Dim count = List.Count
            'If List.Count <= 1 Then
            '    Return ""
            'End If
            Dim rd = New ReportDataSource("DSApp", List)
            lr.DataSources.Add(rd)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>38.7cm</PageWidth>" +
            " <PageHeight>21cm</PageHeight>" +
            " <MarginTop>0in</MarginTop>" +
            " <MarginLeft>0.3in</MarginLeft>" +
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
                zip.AddEntry("Application.pdf", renderedBytes)
            End If
        End Function

#Region "Print Replace"
        '        Function Print(id As Integer) As String
        '            '#If DEBUG Then
        '            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report/Application.rtf"))
        '            '#Else
        '            '            Dim strVal As String = System.IO.File.ReadAllText(Server.MapPath("~/Report2/Application.rtf"))
        '            '#End If
        '            Try
        '                Dim query = (From A In db.Tr_ApplicationHeaders
        '                             Group Join BB In db.Tr_ApprovalApps On A.ApplicationHeader_ID Equals BB.ApplicationHeader_ID Into BBA = Group
        '                             From BB In BBA.DefaultIfEmpty
        '                             Group Join B In db.Tr_Contracts On BB.ApprovalApp_ID Equals B.ApprovalApp_ID Into AB = Group
        '                             From B In AB.DefaultIfEmpty
        '                             Group Join C In db.V_ProspectCusts On A.Approval_ID Equals C.Approval_ID Into AC = Group
        '                             From C In AC.DefaultIfEmpty
        '                             Group Join UserPros In db.Cn_Users On C.CreatedBy Equals UserPros.User_ID Into CUserPros = Group
        '                             From UserPros In CUserPros.DefaultIfEmpty
        '                             Group Join Dep In db.Cn_Departments On UserPros.Department_ID Equals Dep.Department_ID Into UsDep = Group
        '                             From Dep In UsDep.DefaultIfEmpty
        '                             Where A.ApplicationHeader_ID = id
        '                             Select A.THU, A.RunContractCompany, A.RunContractGroup, A.Application_No, A.Contract_No, A.CreatedDate, C.Company_Name, C.Customer_ID, C.Address, C.PIC_Name, C.IsExists, C.CreatedBy, UserPros.User_Name, Dep.Department, Dep.Department_ID,
        '                             C.Authorized_Capital, C.Authorized_Signer_Name1, C.Authorized_Signer_Name2, C.Authorized_Signer_Position1, C.Authorized_Signer_Position2, C.IntroducedBy,
        '                             C.Customer_Class, C.Credit_Rating, C.CompanyGroup_Name, A.Line_of_Business, A.Outstanding_Balance_Group, A.Outstanding_Balance_MUL_Group, A.Remark, A.Record_For_Payment).FirstOrDefault()
        '                '8 Head Marketing
        '                Dim lead = (From A In db.Cn_Users
        '                            Where A.Department_ID = query.Department_ID And A.Role_ID = 8
        '                            Select A.User_Name).FirstOrDefault
        '                Dim detail = (From A In db.Tr_Applications
        '                              Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into AB = Group
        '                              From B In AB.DefaultIfEmpty
        '                              Group Join C In db.Tr_ApplicationHeaders.Where(Function(x) x.IsDeleted = False) On A.ApplicationHeader_ID Equals C.ApplicationHeader_ID Into AC = Group
        '                              From C In AC.DefaultIfEmpty
        '                              Where A.ApplicationHeader_ID = id And A.IsDeleted = False
        '                              Select B.Vehicle, B.IsVehicleExists, B.Rent_Location, A.Expedition_Cost,
        'PurcPrice = A.Cost_Price, A.Bid_PricePerMonth, B.Lease_long, A.IRR, A.Spread, A.Funding_Rate,
        'A.Lease_Profit, A.Residual_Value, A.Agent_Fee, A.Payee, A.PayeeRemark, B.Transaction_Type, A.Purchaser, A.Purchase_Type, B.Qty, A.Project_Rating, A.Color, C.Expec_Contract_Date, A.Expec_Delivery_Date, B.Asset_Rating, A.PayMonth
        '                          ).ToList

        '                Dim count = detail.Count
        '                Dim qtyall = detail.Sum(Function(x) x.Qty)
        '                Dim detailF = detail.FirstOrDefault
        '                Dim PurcP = detail.Sum(Function(x) x.PurcPrice)
        '                Dim Amount = PurcP + query.Outstanding_Balance_Group + query.Outstanding_Balance_MUL_Group


        '                'Untuk Header
        '                strVal = strVal.Replace("<AppNo>", query.Application_No)
        '                strVal = strVal.Replace("<CTRNo>", query.Contract_No)
        '                strVal = strVal.Replace("<Date>", query.CreatedDate.ToString("dd/MMM/yyyy"))
        '                strVal = strVal.Replace("<Cust>", If(query.Customer_ID, ""))
        '                strVal = strVal.Replace("<PIC>", If(query.User_Name, ""))
        '                strVal = strVal.Replace("<Team>", If(query.Department, ""))
        '                strVal = strVal.Replace("<CustName>", query.Company_Name)
        '                strVal = strVal.Replace("<CustAddress>", If(query.Address, ""))
        '                strVal = strVal.Replace("<IsExists>", If(query.IsExists, "Existing", "New"))
        '                strVal = strVal.Replace("<LineOfBusiness>", If(query.Line_of_Business, ""))
        '                strVal = strVal.Replace("<AutCap>", FormatNumber(CType(If(query.Authorized_Capital, 0), Double), 0,,, TriState.True))
        '                strVal = strVal.Replace("<CustomerGroup>", If(query.CompanyGroup_Name, ""))
        '                strVal = strVal.Replace("<introduced>", If(query.IntroducedBy, ""))
        '                strVal = strVal.Replace("<NameSigner1>", If(query.Authorized_Signer_Name1, ""))
        '                strVal = strVal.Replace("<PositionSigner1>", If(query.Authorized_Signer_Position1, ""))
        '                strVal = strVal.Replace("<NameSigner2>", If(query.Authorized_Signer_Name2, ""))
        '                strVal = strVal.Replace("<PositionSigner2>", If(query.Authorized_Signer_Position2, ""))
        '                strVal = strVal.Replace("<Remark>", If(query.Remark, ""))
        '                strVal = strVal.Replace("<top>", If(detailF.PayMonth, 0))
        '                strVal = strVal.Replace("<rfp>", If(query.Record_For_Payment, ""))
        '                strVal = strVal.Replace("<cr>", If(query.Credit_Rating, ""))
        '                strVal = strVal.Replace("<Group>", FormatNumber(If(query.Outstanding_Balance_Group, 0), 0, , , TriState.True))
        '                strVal = strVal.Replace("<MULGroup>", FormatNumber(If(query.Outstanding_Balance_MUL_Group, 0), 0, , , TriState.True))
        '                strVal = strVal.Replace("<TotalBalance>", FormatNumber(If(Amount, 0), 0, , , TriState.True))
        '                strVal = strVal.Replace("<Qty>", If(qtyall, 0))
        '                strVal = strVal.Replace("<PurchPrice>", FormatNumber(If(PurcP, 0), 0,,, TriState.True))

        '#Region "Detail"
        '                'jika hanya 1
        '                If count = 1 Then
        '                    strVal = strVal.Replace("<VehiclreName>", detailF.Vehicle)
        '                    strVal = strVal.Replace("<Color>", detailF.Color)
        '                    strVal = strVal.Replace("<IsVehicleExists>", If(detailF.IsVehicleExists, "Use", "New"))
        '                    strVal = strVal.Replace("<Location>", detailF.Rent_Location)
        '                    strVal = strVal.Replace("<ExpDate>", CType(detailF.Expec_Contract_Date, Date).ToString("dd/MMM/yyyy"))
        '                    strVal = strVal.Replace("<DeliveryDate>", If(detailF.Expec_Delivery_Date Is Nothing, "", CType(detailF.Expec_Delivery_Date, Date).ToString("dd/MMM/yyyy")))
        '                    strVal = strVal.Replace("<MonthRent>", FormatNumber(detailF.Bid_PricePerMonth, 0,,, TriState.True))
        '                    strVal = strVal.Replace("<Perd>", If(detailF.Lease_long, 0))
        '                    strVal = strVal.Replace("<Cycle>", 1)
        '                    strVal = strVal.Replace("<IRR>", If(detailF.IRR, 0))
        '                    strVal = strVal.Replace("<Spread>", If(detailF.Spread, 0))
        '                    strVal = strVal.Replace("<FR>", If(detailF.Funding_Rate, 0))
        '                    strVal = strVal.Replace("<Profit>", FormatNumber(If(detailF.Lease_Profit, 0), 0,,, TriState.True))
        '                    strVal = strVal.Replace("<RV>", FormatNumber(If(detailF.Residual_Value, 0), 0,,, TriState.True))

        '                    'jika dia ada Agen Fee
        '                    If (If(detailF.Agent_Fee, 0) <> 0) Then
        '                        strVal = strVal.Replace("<AgentFeeStat>", "Yes")
        '                        strVal = strVal.Replace("<TotalAgenFee>", FormatNumber(If(detailF.Agent_Fee, 0), 0,,, TriState.True))
        '                        strVal = strVal.Replace("<PayeeName>", If(detailF.Payee, ""))
        '                        strVal = strVal.Replace("<Payee>", If(detailF.PayeeRemark, ""))
        '                    Else
        '                        strVal = strVal.Replace("<AgentFeeStat>", "No")
        '                        strVal = strVal.Replace("<TotalAgenFee>", "")
        '                        strVal = strVal.Replace("<PayeeName>", "")
        '                        strVal = strVal.Replace("<Payee>", "")
        '                    End If
        '                    If detailF.Transaction_Type = "COP" Then
        '                        strVal = strVal.Replace("<COPCon>", "Yes")
        '                    Else
        '                        strVal = strVal.Replace("<COPCon>", "No")
        '                    End If
        '                    strVal = strVal.Replace("<PR>", If(detailF.Project_Rating, ""))
        '                    strVal = strVal.Replace("<ar>", If(detailF.Asset_Rating, 0))

        '                    'strVal = strVal.Replace("<Group>", String.Format("{0:0,0}", query.Outstanding_Balance_Group))
        '                Else
        '                    'jika lebih dari 1
        '                    strVal = strVal.Replace("<VehiclreName>", "Attached in another documents")
        '                    strVal = strVal.Replace("<Color>", "Attached")
        '                    strVal = strVal.Replace("<IsVehicleExists>", "Attached")
        '                    strVal = strVal.Replace("<Location>", "Attached in another documents")
        '                    strVal = strVal.Replace("<ExpDate>", "Attached")
        '                    strVal = strVal.Replace("<DeliveryDate>", "Attached")
        '                    'strVal = strVal.Replace("<PurchPrice>", "Attached in another documents")
        '                    strVal = strVal.Replace("<MonthRent>", "Attached in another documents")
        '                    strVal = strVal.Replace("<Perd>", "")
        '                    strVal = strVal.Replace("<Cycle>", "")
        '                    strVal = strVal.Replace("<IRR>", "Attached")
        '                    strVal = strVal.Replace("<Spread>", "Attached")
        '                    strVal = strVal.Replace("<FR>", "Attached")
        '                    strVal = strVal.Replace("<Profit>", "Attached")
        '                    strVal = strVal.Replace("<RV>", "Attached in another documents")

        '                    strVal = strVal.Replace("<AgentFeeStat>", "")
        '                    strVal = strVal.Replace("<TotalAgenFee>", "")
        '                    strVal = strVal.Replace("<PayeeName>", "")
        '                    strVal = strVal.Replace("<Payee>", "Attached in another documents")
        '                    strVal = strVal.Replace("<COPCon>", "")
        '                    strVal = strVal.Replace("<PR>", "")
        '                    'strVal = strVal.Replace("<cr>", "")
        '                    strVal = strVal.Replace("<ar>", "")
        '                    'strVal = strVal.Replace("<Qty>", "")
        '                    'strVal = strVal.Replace("<Group>", "")
        '                    'strVal = strVal.Replace("<MULGroup>", "")
        '                    'strVal = strVal.Replace("<TotalBalance>", "")
        '                    'strVal = strVal.Replace("<Remark>", "")
        '                    'strVal = strVal.Replace("<top>", "")
        '                    'strVal = strVal.Replace("<rfp>", "")

        '                End If
        '#End Region

        '                strVal = strVal.Replace("<thu>", If(query.THU, ""))
        '                strVal = strVal.Replace("<RCC>", If(query.RunContractCompany, ""))
        '                strVal = strVal.Replace("<RCG>", If(query.RunContractGroup, ""))
        '                strVal = strVal.Replace("<Lead>", lead)



        '                '#If DEBUG Then
        '                System.IO.File.WriteAllText(Server.MapPath("~/Report/ApplicationPrint.rtf"), strVal)
        '                ConvertWordToPDF(Server.MapPath("~/Report/ApplicationPrint.rtf"))
        '                Return Server.MapPath("~/Report/ApplicationPrint.pdf")
        '                '#Else
        '                '            System.IO.File.WriteAllText(Server.MapPath("~/Report2/ApplicationPrint.rtf"), strVal)
        '                '            ConvertWordToPDF(Server.MapPath("~/Report2/ApplicationPrint.rtf"))
        '                '            Return Server.MapPath("~/Report2/ApplicationPrint.pdf")
        '                '#End If
        '            Catch ex As Exception
        '                Throw New Exception(ex.Message)
        '            End Try


        '        End Function
#End Region



        Public Function FillDetail(ByVal val As Integer?) As ActionResult
            If val IsNot Nothing Then
                If val = 0 Then
                    Return Json(New With {Key .success = "false"})
                End If

                Dim detail = (From A In db.Tr_Applications
                              Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
                              From B In Group.DefaultIfEmpty()
                              Where A.IsDeleted = False And A.IsFillOTR = True And A.Approval_ID = val
                              Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
                                  A.Application_ID, B.Brand_Name,
                                  B.Vehicle, A.Payee, A.PayeeRemark,
                                  B.Transaction_Type,
                                  A.Purchaser, A.Purchase_Type, B.Asset_Rating).ToList()
                If detail Is Nothing Then
                    Return Json(New With {Key .success = "false"})
                End If

                Return Json(New With {Key .success = "true", .Detail = detail})
            End If
            Return Json(New With {Key .success = "false"})
        End Function
        Public Function FillCustomer(ByVal val As Integer?) As ActionResult
            If val IsNot Nothing Then
                If val = 0 Then
                    Return Json(New With {Key .success = "false"})
                End If

                Dim detail = (From A In db.Tr_Applications
                              Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
                              From B In Group.DefaultIfEmpty()
                              Where A.IsDeleted = False And A.IsFillOTR = True And A.Approval_ID = val
                              Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
                                  A.Application_ID, B.Brand_Name,
                                  B.Vehicle, A.Payee, A.PayeeRemark,
                                  B.Transaction_Type,
                                  A.Purchaser, A.Purchase_Type, B.Asset_Rating, B.IsVehicleExists, B.Color, A.Expec_Delivery_Date).
                                  Select(Function(x) New Tr_Application With {.Agent_FeeStat = x.AgenFeeStat, .Agent_Fee = x.Agent_Fee, .Application_ID = x.Application_ID, .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle,
                                  .Payee = x.Payee, .PayeeRemark = x.PayeeRemark, .Transaction_Type = x.Transaction_Type, .Purchaser = x.Purchaser, .Purchase_Type = x.Purchase_Type, .Asset_Rating = x.Asset_Rating, .IsVehicleExists = x.IsVehicleExists,
                                  .Color = x.Color}).ToList

                Dim Query = (From A In db.V_ProspectCusts
                             Where A.Approval_ID = val
                             Select A.IsExists, A.Customer_ID, A.CompanyGroup_Name, A.Company_Name, A.PT, A.Tbk, A.Address, A.City, A.Phone, A.Email, A.PIC_Name, A.PIC_Phone, A.PIC_Email, A.Credit_Rating, A.THU).FirstOrDefault()
                If Query.IsExists Then
                    Dim cust = (From A In db.Ms_Customers
                                Group Join B In db.Ms_Customer_CompanyGroups On A.CompanyGroup_ID Equals B.CompanyGroup_ID Into AB = Group
                                From B In AB.DefaultIfEmpty
                                Where A.Customer_ID = Query.Customer_ID
                                Select A.Customer_Class, A.Credit_Rating, A.Authorized_Capital, A.Line_of_Business, A.Authorized_Signer_Name1, A.Authorized_Signer_Position1, A.Authorized_Signer_Name2, A.Authorized_Signer_Position2, A.IntroducedBy).FirstOrDefault
                    Return Json(New With {Key .success = "true", Key .CompanyGroup_Name = Query.CompanyGroup_Name, Key .Company_Name = Query.Company_Name,
                            .Address = Query.Address, .City = Query.City, .Phone = Query.Phone, .Email = Query.Email, .PIC_Name = Query.PIC_Name, .PIC_Phone = Query.PIC_Phone, .PIC_Email = Query.PIC_Email,
                            .IsExists = Query.IsExists, .Credit_Rating = Query.Credit_Rating, .THU = Query.THU, .Authorized_Capital = If(CType(cust.Authorized_Capital, Nullable(Of Double)), 0), .Authorized_Signer_Name1 = cust.Authorized_Signer_Name1,
                            .Authorized_Signer_Position1 = cust.Authorized_Signer_Position1, .Authorized_Signer_Name2 = cust.Authorized_Signer_Name2, .Authorized_Signer_Position2 = cust.Authorized_Signer_Position2,
                            .IntroducedBy = cust.IntroducedBy, .Customer_Class = cust.Customer_Class, .Line_of_Business = cust.Line_of_Business, .Detail = detail})
                End If


                'Dim amount = Query.Amount.ToString("#,##0.00")
                Return Json(New With {Key .success = "true", Key .CompanyGroup_Name = Query.CompanyGroup_Name, .Company_Name = Query.Company_Name,
                            .Address = Query.Address, .City = Query.City, .Phone = Query.Phone, .Email = Query.Email, .PIC_Name = Query.PIC_Name, .PIC_Phone = Query.PIC_Phone, .PIC_Email = Query.PIC_Email,
                            .IsExists = Query.IsExists, .Credit_Rating = Query.Credit_Rating, .THU = Query.THU, .Detail = detail})
            End If
            Return Json(New With {Key .success = "false"})
        End Function
        'Public Function FillCustomerEdit(ByVal val As Integer?) As ActionResult
        '    If val IsNot Nothing Then
        '        If val = 0 Then
        '            Return Json(New With {Key .success = "false"})
        '        End If

        '        Dim detail = (From AA In db.Tr_ApplicationHeaders
        '                      Join A In db.Tr_Applications On AA.ApplicationHeader_ID Equals A.ApplicationHeader_ID
        '                      Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
        '                      From B In Group.DefaultIfEmpty()
        '                      Group Join C In db.Ms_Vehicles On B.VehicleExists_ID Equals C.Vehicle_id Into BC = Group
        '                      From C In BC.DefaultIfEmpty()
        '                      Where A.IsDeleted = False And A.IsFillOTR = True And A.Approval_ID = val
        '                      Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
        '                          A.Application_ID, B.Brand_Name,
        '                          B.Vehicle, A.Payee, A.PayeeRemark,
        '                          B.Transaction_Type,
        '                          A.Purchaser, A.Purchase_Type, A.Asset_Rating, B.IsVehicleExists, A.Color, A.Expec_Contract_Date, A.Expec_Delivery_Date).ToList()
        '        If detail IsNot Nothing Then
        '            Return Json(New With {Key .success = "true", .Detail = detail})
        '        End If
        '    End If
        '    Return Json(New With {Key .success = "false"})
        'End Function
#End Region
        Private Sub ConvertWordToPDF(filename As String)
            Dim wordApplication As New Microsoft.Office.Interop.Word.Application
            Dim wordDocument As Microsoft.Office.Interop.Word.Document = Nothing
            Dim outputFilename As String

            Try
                wordDocument = wordApplication.Documents.Open(filename)
                outputFilename = System.IO.Path.ChangeExtension(filename, "pdf")

                If Not wordDocument Is Nothing Then
                    wordDocument.ExportAsFixedFormat(outputFilename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, False, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)
                End If
            Catch ex As Exception
                'TODO: handle exception
            Finally
                If Not wordDocument Is Nothing Then
                    wordDocument.Close(False)
                    wordDocument = Nothing
                End If

                If Not wordApplication Is Nothing Then
                    wordApplication.Quit()
                    wordApplication = Nothing
                End If
            End Try

        End Sub
        ' GET: ApplicationHeader
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
            Dim query = (From A In db.Tr_ApplicationHeaders
                         Join B In db.V_ProspectCusts On A.Approval_ID Equals B.Approval_ID
                         Group Join C In db.Tr_ApprovalApps On A.ApplicationHeader_ID Equals C.ApplicationHeader_ID Into AC = Group
                         From C In AC.DefaultIfEmpty()
                         Where C.IsDeleted = False And A.IsDeleted = False
                         Select A.ApplicationHeader_ID, B.IsExists, B.CompanyGroup_Name, B.Company_Name, B.City, B.PIC_Name, A.CreatedDate, C.StatusRecord, C.Status,
                             A.IsTruck, A.ApplicationType, A.PeriodeType, A.IsQuick, A.IsNotApproved, A.RemarkNotApproved).Select(
                         Function(x) New Tr_ApplicationHeader With {.ApplicationHeader_ID = x.ApplicationHeader_ID, .IsExists = x.IsExists, .CompanyGroup_Name = x.CompanyGroup_Name,
                         .Company_Name = x.Company_Name, .City = x.City, .PIC_Name = x.PIC_Name, .CreatedDate = x.CreatedDate, .StatusRecord = x.StatusRecord, .Status = x.Status, .IsTruck = x.IsTruck, .ApplicationType = x.ApplicationType, .PeriodeType = x.PeriodeType,
                         .IsQuick = x.IsQuick, .IsNotApproved = x.IsNotApproved, .RemarkNotApproved = x.RemarkNotApproved})

            If Not String.IsNullOrEmpty(searchString) Then
                query = query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.City.Contains(searchString) OrElse s.PIC_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    query = query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    query = query.OrderBy(Function(s) s.Company_Name)
                Case "City"
                    query = query.OrderBy(Function(s) s.City)
                Case "PIC_Name"
                    query = query.OrderBy(Function(s) s.PIC_Name)
                Case Else
                    query = query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(query.ToPagedList(pageNumber, pageSize))

            Return View(query)
        End Function
        Function Errors() As ActionResult

            Return View()
        End Function
        ' GET: ApplicationHeader/Create
        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If

            Dim Approval_ID = From A In db.Tr_Approvals
                              Join B In db.V_ProspectCusts On A.Quotation_ID Equals B.Quotation_ID
                              Where A.IsApplicationHeader = True And B.IsApplicationPO And A.IsApplicationHeaderDone = False
                              Select New With {A.Approval_ID, B.No_Ref}
            ViewBag.Approval_ID = New SelectList(Approval_ID, "Approval_ID", "No_Ref")
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key")
            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text")
            ViewBag.Contracted_by = New SelectList(Contracted_by, "Value", "Text")
            ViewBag.ApplicationType = New SelectList(ApplicationType, "Value", "Text")
            ViewBag.PeriodeType = New SelectList(PeriodeType, "Value", "Text")
            ViewBag.IsTruck = New SelectList(IsTruck, "Value", "Text")
            ViewBag.IsQuick = New SelectList(IsQuick, "Value", "Text")
            ViewBag.Code_Open = New SelectList(IsCode_Open, "Value", "Text")
            Return View()
        End Function
        Function TestRecal(ByVal id As Integer?) As ActionResult
            Dim i = db.Tr_Applications.Where(Function(x) x.Application_ID = id).FirstOrDefault()
            'Hitung Ulang
            Dim vProcDet = db.V_ProspectCustDetails.Where(Function(x) x.Application_ID = i.Application_ID).FirstOrDefault
            Dim cal As New Tr_Calculate
            cal.Lease_long = vProcDet.Lease_long
            cal.Replacement_Tick = i.Replacement_Tick
            cal.Maintenance_Tick = i.Maintenance_Tick
            cal.STNK_Tick = i.STNK_Tick
            cal.Assurance_Tick = i.Assurance_Tick
            cal.IsVehicleExists = vProcDet.IsVehicleExists
            cal.Transaction_Type = vProcDet.Transaction_Type
            cal.Type = vProcDet.Type
            cal.Lease_price = vProcDet.Lease_price
            cal.Rent_Location_ID = i.Rent_Location_ID
            cal.Plat_Location = i.Plat_Location
            cal.Term_Of_Payment = i.Term_Of_Payment
            cal.PayMonth = i.PayMonth
            cal.Payment_Condition = i.Payment_Condition
            cal.Modification = i.Modification
            cal.GPS_Cost = i.GPS_Cost
            cal.GPS_CostPerMonth = i.GPS_CostPerMonth
            cal.Agent_Fee = i.Agent_Fee
            cal.Agent_FeePerMonth = i.Agent_FeePerMonth
            cal.Update_OTR = i.Update_OTR
            cal.Residual_Value = i.Residual_Value
            cal.Residual_ValuePercent = i.Residual_ValuePercent
            cal.Expedition_Status = i.Expedition_Status
            cal.Expedition_Cost = i.Expedition_Cost
            cal.Keur = i.Keur
            cal.Update_Diskon = i.Update_Diskon
            cal.Cost_Price = i.Cost_Price
            cal.Up_Front_Fee = i.Up_Front_Fee
            cal.Up_Front_Fee_Percent = i.Up_Front_Fee_Percent
            cal.Other = i.Other
            cal.Efektif_Date = i.Efektif_Date
            cal.Replacement_Percent = i.Replacement_Percent
            cal.Replacement = i.Replacement
            cal.Maintenance_Percent = i.Maintenance_Percent
            cal.Maintenance = i.Maintenance
            cal.STNK_Percent = i.STNK_Percent
            cal.STNK = i.STNK
            cal.Overhead_Percent = i.Overhead_Percent
            cal.Overhead = i.Overhead
            cal.Assurance_Percent = i.Assurance_Percent
            cal.Assurance = i.Assurance
            cal.AssuranceExtra = i.AssuranceExtra
            cal.Lease_Profit = i.Lease_Profit
            cal.Lease_Profit_Percent = i.Lease_Profit_Percent
            cal.Depresiasi = i.Depresiasi
            cal.Depresiasi_Percent = i.Depresiasi_Percent
            cal.Funding_Interest = i.Funding_Interest
            cal.Funding_Interest_Percent = i.Funding_Interest_Percent
            cal.Bid_PricePerMonth = i.Bid_PricePerMonth
            cal.Premium = i.Premium
            cal.OJK = i.OJK
            cal.SwapRate = i.SwapRate
            cal.Project_Rating = i.Project_Rating
            cal.IRR = i.IRR
            cal.Funding_Rate = i.Funding_Rate
            cal.Spread = i.Spread
            cal.Profit = i.Profit
            cal.IsTruck = vProcDet.IsTruck
            cal.New_Vehicle_Price = i.New_Vehicle_Price
            'Recalculate
            cal = calControl.ReCalculate(db, cal)

            i.GPS_Cost = cal.GPS_Cost
            i.GPS_CostPerMonth = cal.GPS_CostPerMonth
            i.Agent_Fee = cal.Agent_Fee
            i.Agent_FeePerMonth = cal.Agent_FeePerMonth
            i.Update_OTR = cal.Update_OTR
            i.Residual_Value = cal.Residual_Value
            i.Residual_ValuePercent = cal.Residual_ValuePercent
            i.Expedition_Status = cal.Expedition_Status
            i.Expedition_Cost = cal.Expedition_Cost
            i.Keur = cal.Keur
            i.Update_Diskon = cal.Update_Diskon
            i.Cost_Price = cal.Cost_Price
            i.Up_Front_Fee = cal.Up_Front_Fee
            i.Up_Front_Fee_Percent = cal.Up_Front_Fee_Percent
            i.Other = cal.Other
            i.Replacement_Percent = cal.Replacement_Percent
            i.Replacement = cal.Replacement
            i.Maintenance_Percent = cal.Maintenance_Percent
            i.Maintenance = cal.Maintenance
            i.STNK_Percent = cal.STNK_Percent
            i.STNK = cal.STNK
            i.Overhead_Percent = cal.Overhead_Percent
            i.Overhead = cal.Overhead
            i.Assurance_Percent = cal.Assurance_Percent
            i.Assurance = cal.Assurance
            i.AssuranceExtra = cal.AssuranceExtra
            i.Lease_Profit = cal.Lease_Profit
            i.Lease_Profit_Percent = cal.Lease_Profit_Percent
            i.Depresiasi = cal.Depresiasi
            i.Depresiasi_Percent = cal.Depresiasi_Percent
            i.Funding_Interest = cal.Funding_Interest
            i.Funding_Interest_Percent = cal.Funding_Interest_Percent
            i.Bid_PricePerMonth = cal.Bid_PricePerMonth
            i.Premium = cal.Premium
            i.OJK = cal.OJK
            i.SwapRate = cal.SwapRate
            i.Project_Rating = cal.Project_Rating
            i.IRR = cal.IRR
            i.Funding_Rate = cal.Funding_Rate
            i.Spread = cal.Spread
            i.Profit = cal.Profit

            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        'Save Detail
        Public Function SaveOrder(orderHeader() As Tr_ApplicationHeader, order() As Tr_Application) As ActionResult
            Dim user As String
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") else user = Session("ID")
#End If
            Dim result As String = "Error"
            Dim Valid As Boolean = True
            Dim Message As String = ""
            Dim Header = orderHeader.FirstOrDefault

#Region "Validate"
            Validasi(Header, Valid, Message, order)

#End Region
            If Valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim trans As String = "Application"
                        'No Otomatis
                        Dim no = db.Cn_NoSerieSetup.Where(Function(x) x.Transaction = trans).FirstOrDefault()
                        Dim number As Integer
                        If no Is Nothing Then
                            Dim NoSeries As New Cn_NoSerieSetup
                            NoSeries.Transaction = trans
                            NoSeries.NextNo = 1
                            NoSeries.CreatedDate = DateTime.Now
                            NoSeries.CreatedBy = user
                            NoSeries.IsDeleted = False
                            db.Cn_NoSerieSetup.Add(NoSeries)
                            number = 1
                        Else
                            no.NextNo = no.NextNo + 1
                            no.ModifiedBy = user
                            no.ModifiedDate = DateTime.Now
                            number = no.NextNo
                        End If
                        Dim Application_No As String = number.ToString

                        'ambil Total Cost Price di applikasi
                        Dim app_ID_array = order.Select(Function(x) x.Application_ID).ToArray
                        Dim Amount = db.Tr_Applications.Where(Function(x) app_ID_array.Contains(x.Application_ID)).Sum(Function(x) x.Cost_Price)

                        Dim appHeader As New Tr_ApplicationHeaders
                        appHeader.Approval_ID = Header.Approval_ID
                        appHeader.Application_No = Application_No
                        appHeader.Contract_No = Header.Contract_No
                        appHeader.Credit_Rating = Header.Credit_Rating
                        appHeader.Contracted_by = Header.Contracted_by
                        appHeader.ApplicationType = Header.ApplicationType
                        appHeader.PeriodeType = Header.PeriodeType
                        appHeader.Customer_Class = Header.Customer_Class
                        appHeader.Line_of_Business = Header.Line_of_Business
                        appHeader.Authorized_Capital = Header.Authorized_Capital
                        appHeader.Authorized_Signer_Name1 = Header.Authorized_Signer_Name1
                        appHeader.Authorized_Signer_Position1 = Header.Authorized_Signer_Position1
                        appHeader.Authorized_Signer_Name2 = Header.Authorized_Signer_Name2
                        appHeader.Authorized_Signer_Position2 = Header.Authorized_Signer_Position2
                        appHeader.IntroducedBy = Header.IntroducedBy
                        appHeader.Expec_Contract_Date = Header.Expec_Contract_Date
                        appHeader.Remark = Header.Remark
                        appHeader.Outstanding_Balance_Application = Header.Outstanding_Balance_Application
                        appHeader.Outstanding_Balance_Group = Header.Outstanding_Balance_Group
                        appHeader.Outstanding_Balance_MUL_Group = Header.Outstanding_Balance_MUL_Group
                        appHeader.Outstanding_Balance_Amount = Amount + Header.Outstanding_Balance_Application + Header.Outstanding_Balance_Group + Header.Outstanding_Balance_MUL_Group
                        appHeader.Outstanding_Balance_Transaction_FL = Header.Outstanding_Balance_Transaction_FL
                        appHeader.Outstanding_Balance_Application_FL = Header.Outstanding_Balance_Application_FL
                        appHeader.Outstanding_Balance_Group_FL = Header.Outstanding_Balance_Group_FL
                        appHeader.Outstanding_Balance_MUL_Group_FL = Header.Outstanding_Balance_MUL_Group_FL
                        appHeader.Outstanding_Balance_Amount_FL = Header.Outstanding_Balance_Transaction_FL + Header.Outstanding_Balance_Application_FL + Header.Outstanding_Balance_Group_FL + Header.Outstanding_Balance_MUL_Group_FL
                        'appHeader.THU = Header.THU
                        appHeader.IsTruck = Header.IsTruck
                        appHeader.IsQuick = Header.IsQuick
                        appHeader.Run_Application = Header.Run_Application
                        appHeader.RunContractCompany = Header.RunContractCompany
                        appHeader.RunContractGroup = Header.RunContractGroup
                        appHeader.Run_Transaction_FL = Header.Run_Transaction_FL
                        appHeader.Run_Application_FL = Header.Run_Application_FL
                        appHeader.RunContractCompany_FL = Header.RunContractCompany_FL
                        appHeader.RunContractGroup_FL = Header.RunContractGroup_FL
                        appHeader.CreatedBy = user
                        appHeader.CreatedDate = DateTime.Now
                        appHeader.IsDeleted = False
                        appHeader.IsNotApproved = False
                        db.Tr_ApplicationHeaders.Add(appHeader)
                        For Each item In order
                            Dim D = db.Tr_Applications.Where(Function(x) x.Application_ID = item.Application_ID).FirstOrDefault()
                            'D.ApplicationHeader_ID = appHeader.ApplicationHeader_ID
                            If (item.Agent_FeeStat) Then
                                D.Payee = item.Payee
                                D.PayeeRemark = item.PayeeRemark
                            End If
                            If (item.Agent_FeeStat) Then
                                D.Purchaser = item.Purchaser
                                D.Purchase_Type = item.Purchase_Type
                            End If
                            D.Code_Open = item.Code_Open
                            D.Expec_Delivery_Date = item.Expec_Delivery_Date
                            'Dim Rating = db.Ms_ProjRatingMatrixs.Where(Function(x) x.Asset_Rating = item.Asset_Rating And x.Credit_Rating = appHeader.Credit_Rating).FirstOrDefault
                            'If Rating Is Nothing Then
                            '    D.Project_Rating = "0"
                            'Else
                            '    D.Project_Rating = Rating.Project_Rating
                            'End If
                            D.ModifiedBy = user
                            D.ModifiedDate = DateTime.Now
                        Next
                        Dim approval = db.Tr_Approvals.Where(Function(x) x.Approval_ID = appHeader.Approval_ID).FirstOrDefault
                        approval.IsApplicationHeaderDone = True
                        'add ApprovalApp
                        Dim A As New Tr_ApprovalApps
                        A.ApplicationHeader_ID = appHeader.ApplicationHeader_ID
                        A.StatusRecord = 1
                        A.Status = "Open"
                        A.CreatedBy = user
                        A.CreatedDate = DateTime.Now
                        A.IsDeleted = False
                        db.Tr_ApprovalApps.Add(A)

                        db.SaveChanges()
                        'kalo dia ambil langsun id si header nga mau
                        For Each item In order
                            Dim i = db.Tr_Applications.Where(Function(x) x.Application_ID = item.Application_ID).FirstOrDefault()
                            i.ApplicationHeader_ID = appHeader.ApplicationHeader_ID
                            'Hitung Ulang
                            Dim vProcDet = db.V_ProspectCustDetails.Where(Function(x) x.Application_ID = i.Application_ID).FirstOrDefault
                            Dim cal As New Tr_Calculate
                            cal.Lease_long = vProcDet.Lease_long
                            cal.Replacement_Tick = i.Replacement_Tick
                            cal.Maintenance_Tick = i.Maintenance_Tick
                            cal.STNK_Tick = i.STNK_Tick
                            cal.Assurance_Tick = i.Assurance_Tick
                            cal.IsVehicleExists = vProcDet.IsVehicleExists
                            cal.Transaction_Type = vProcDet.Transaction_Type
                            cal.Type = vProcDet.Type
                            cal.Lease_price = vProcDet.Lease_price
                            cal.Rent_Location_ID = i.Rent_Location_ID
                            cal.Plat_Location = i.Plat_Location
                            cal.Term_Of_Payment = i.Term_Of_Payment
                            cal.PayMonth = i.PayMonth
                            cal.Payment_Condition = i.Payment_Condition
                            cal.Modification = i.Modification
                            cal.GPS_Cost = i.GPS_Cost
                            cal.GPS_CostPerMonth = i.GPS_CostPerMonth
                            cal.Agent_Fee = i.Agent_Fee
                            cal.Agent_FeePerMonth = i.Agent_FeePerMonth
                            cal.Update_OTR = i.Update_OTR
                            cal.Residual_Value = i.Residual_Value
                            cal.Residual_ValuePercent = i.Residual_ValuePercent
                            cal.Expedition_Status = i.Expedition_Status
                            cal.Expedition_Cost = i.Expedition_Cost
                            cal.Keur = i.Keur
                            cal.Update_Diskon = i.Update_Diskon
                            cal.Cost_Price = i.Cost_Price
                            cal.Up_Front_Fee = i.Up_Front_Fee
                            cal.Up_Front_Fee_Percent = i.Up_Front_Fee_Percent
                            cal.Other = i.Other
                            cal.Efektif_Date = i.Efektif_Date
                            cal.Replacement_Percent = i.Replacement_Percent
                            cal.Replacement = i.Replacement
                            cal.Maintenance_Percent = i.Maintenance_Percent
                            cal.Maintenance = i.Maintenance
                            cal.STNK_Percent = i.STNK_Percent
                            cal.STNK = i.STNK
                            cal.Overhead_Percent = i.Overhead_Percent
                            cal.Overhead = i.Overhead
                            cal.Assurance_Percent = i.Assurance_Percent
                            cal.Assurance = i.Assurance
                            cal.AssuranceExtra = i.AssuranceExtra
                            cal.Lease_Profit = i.Lease_Profit
                            cal.Lease_Profit_Percent = i.Lease_Profit_Percent
                            cal.Depresiasi = i.Depresiasi
                            cal.Depresiasi_Percent = i.Depresiasi_Percent
                            cal.Funding_Interest = i.Funding_Interest
                            cal.Funding_Interest_Percent = i.Funding_Interest_Percent
                            cal.Bid_PricePerMonth = i.Bid_PricePerMonth
                            cal.Premium = i.Premium
                            cal.OJK = i.OJK
                            cal.SwapRate = i.SwapRate
                            cal.Project_Rating = i.Project_Rating
                            cal.IRR = i.IRR
                            cal.Funding_Rate = i.Funding_Rate
                            cal.Spread = i.Spread
                            cal.Profit = i.Profit
                            cal.IsTruck = vProcDet.IsTruck
                            cal.New_Vehicle_Price = i.New_Vehicle_Price
                            'Recalculate
                            cal = calControl.ReCalculate(db, cal)

                            i.GPS_Cost = cal.GPS_Cost
                            i.GPS_CostPerMonth = cal.GPS_CostPerMonth
                            i.Agent_Fee = cal.Agent_Fee
                            i.Agent_FeePerMonth = cal.Agent_FeePerMonth
                            i.Update_OTR = cal.Update_OTR
                            i.Residual_Value = cal.Residual_Value
                            i.Residual_ValuePercent = cal.Residual_ValuePercent
                            i.Expedition_Status = cal.Expedition_Status
                            i.Expedition_Cost = cal.Expedition_Cost
                            i.Keur = cal.Keur
                            i.Update_Diskon = cal.Update_Diskon
                            i.Cost_Price = cal.Cost_Price
                            i.Up_Front_Fee = cal.Up_Front_Fee
                            i.Up_Front_Fee_Percent = cal.Up_Front_Fee_Percent
                            i.Other = cal.Other
                            i.Replacement_Percent = cal.Replacement_Percent
                            i.Replacement = cal.Replacement
                            i.Maintenance_Percent = cal.Maintenance_Percent
                            i.Maintenance = cal.Maintenance
                            i.STNK_Percent = cal.STNK_Percent
                            i.STNK = cal.STNK
                            i.Overhead_Percent = cal.Overhead_Percent
                            i.Overhead = cal.Overhead
                            i.Assurance_Percent = cal.Assurance_Percent
                            i.Assurance = cal.Assurance
                            i.AssuranceExtra = cal.AssuranceExtra
                            i.Lease_Profit = cal.Lease_Profit
                            i.Lease_Profit_Percent = cal.Lease_Profit_Percent
                            i.Depresiasi = cal.Depresiasi
                            i.Depresiasi_Percent = cal.Depresiasi_Percent
                            i.Funding_Interest = cal.Funding_Interest
                            i.Funding_Interest_Percent = cal.Funding_Interest_Percent
                            i.Bid_PricePerMonth = cal.Bid_PricePerMonth
                            i.Premium = cal.Premium
                            i.OJK = cal.OJK
                            i.SwapRate = cal.SwapRate
                            i.Project_Rating = cal.Project_Rating
                            i.IRR = cal.IRR
                            i.Funding_Rate = cal.Funding_Rate
                            i.Spread = cal.Spread
                            i.Profit = cal.Profit

                            db.SaveChanges()

                            'cahsFlow Ulang
                            Dim AssuranceCashFlow = (i.Assurance + i.AssuranceExtra) / (vProcDet.Lease_long / 12)
                            Dim Application_ID = i.Application_ID
                            Dim Expedition_Status = i.Expedition_Status, PayMonth = i.PayMonth, CostPrice = i.Cost_Price, Up_Front_Fee = i.Up_Front_Fee,
                            Replacement = i.Replacement, Maintenance = i.Maintenance, STNK = i.STNK, Overhead = i.Overhead,
                                     Bid_PricePerMonth = i.Bid_PricePerMonth, Residual_Value = i.Residual_Value, Lease_long = vProcDet.Lease_long,
                            Expedition_Cost = i.Expedition_Cost, Transaction_Type = vProcDet.Transaction_Type, Payment_Condition = i.Payment_Condition, Term_Of_Payment = i.Term_Of_Payment,
                            Modification = i.Modification, GPS_Cost = i.GPS_Cost, GPS_CostPerMonth = i.GPS_CostPerMonth, Agent_Fee = i.Agent_Fee, Agent_FeePerMonth = i.Agent_FeePerMonth,
                            Other = i.Other, Keur = i.Keur, Funding_Rate = i.Funding_Rate

                            Dim messageResult = db.sp_SaveCashFlow(False, Application_ID, user, Expedition_Status, PayMonth, CostPrice, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                                     Bid_PricePerMonth, Residual_Value, vProcDet.Lease_long, Expedition_Cost, vProcDet.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                                     GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                            If messageResult.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                                Throw New Exception(messageResult.Select(Function(x) x.Message).FirstOrDefault)
                            End If
                            db.SaveChanges()
                        Next



                        result = "Success"
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using
                'Print(appHeader.ApplicationHeader_ID)
            End If
            Return Json(New With {Key .result = result, Key .message = Message}, JsonRequestBehavior.AllowGet)
        End Function

        ' GET: ApplicationHeader/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            Dim user As String
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Tr_ApplicationHeaders
                         Join B In db.V_ProspectCusts On A.Approval_ID Equals B.Approval_ID
                         Group Join C In db.Ms_Customers On B.Customer_ID Equals C.Customer_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Where A.IsDeleted = False And A.ApplicationHeader_ID = id
                         Select A.ApplicationHeader_ID, B.Address, B.CompanyGroup_Name, B.Company_Name, B.City, B.PIC_Name, B.PIC_Phone, B.PIC_Email, B.Phone, B.Email,
                             B.IsExists, A.Credit_Rating, CCredit_Rating = C.Credit_Rating, A.Line_of_Business, CLine_of_Business = C.Line_of_Business, A.Authorized_Capital, CAuthorized_Capital = C.Authorized_Capital, A.Authorized_Signer_Name1, CAuthorized_Signer_Name1 = C.Authorized_Signer_Name1,
                             CC = A.Customer_Class, CCC = C.Customer_Class, A.Authorized_Signer_Position1, CAuthorized_Signer_Position1 = C.Authorized_Signer_Position1, A.Authorized_Signer_Name2, CAuthorized_Signer_Name2 = C.Authorized_Signer_Name2,
                             A.Authorized_Signer_Position2, CAuthorized_Signer_Position2 = C.Authorized_Signer_Position2, A.IntroducedBy, CIntroducedBy = C.IntroducedBy,
                             CB = A.Contracted_by, A.ApplicationType, A.PeriodeType, A.Outstanding_Balance_Group, A.Outstanding_Balance_MUL_Group, A.RunContractCompany, A.RunContractGroup, A.Expec_Contract_Date,
                             A.Remark, A.IsTruck, A.IsQuick, A.Contract_No,
                             A.Outstanding_Balance_Application, A.Outstanding_Balance_Transaction_FL, A.Outstanding_Balance_Application_FL,
                             A.Outstanding_Balance_Group_FL, A.Outstanding_Balance_MUL_Group_FL, A.Run_Application, A.Run_Transaction_FL, A.Run_Application_FL,
                             A.RunContractCompany_FL, A.RunContractGroup_FL).
            Select(Function(x) New Tr_ApplicationHeader With {.ApplicationHeader_ID = x.ApplicationHeader_ID, .Address = x.Address, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                             .City = x.City, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Phone = x.Phone, .Email = x.Email, .IsExists = x.IsExists, .Credit_Rating = If(x.IsExists, x.CCredit_Rating, x.Credit_Rating),
                             .Line_of_Business = If(x.IsExists, x.CLine_of_Business, x.Line_of_Business), .Authorized_Capital = If(x.IsExists, x.CAuthorized_Capital, x.Authorized_Capital), .Authorized_Signer_Name1 = If(x.IsExists, x.CAuthorized_Signer_Name1, x.Authorized_Signer_Name1), .Customer_Class = If(x.IsExists, x.CCC, x.CC), .Authorized_Signer_Position1 = If(x.IsExists, x.CAuthorized_Signer_Position1, x.Authorized_Signer_Position1),
                             .Authorized_Signer_Name2 = If(x.IsExists, x.CAuthorized_Signer_Name2, x.Authorized_Signer_Name2), .Authorized_Signer_Position2 = If(x.IsExists, x.CAuthorized_Signer_Position2, x.Authorized_Signer_Position2), .IntroducedBy = If(x.IsExists, x.CIntroducedBy, x.IntroducedBy), .Contracted_by = x.CB,
                             .Outstanding_Balance_Group = x.Outstanding_Balance_Group, .Outstanding_Balance_MUL_Group = x.Outstanding_Balance_MUL_Group, .RunContractCompany = x.RunContractCompany,
                             .RunContractGroup = x.RunContractGroup, .Expec_Contract_Date = x.Expec_Contract_Date, .Remark = x.Remark, .IsQuick = x.IsQuick,
                             .IsTruck = x.IsTruck, .ApplicationType = x.ApplicationType, .PeriodeType = x.PeriodeType, .Contract_No = x.Contract_No, .Outstanding_Balance_Application = x.Outstanding_Balance_Application,
                             .Outstanding_Balance_Transaction_FL = x.Outstanding_Balance_Transaction_FL, .Outstanding_Balance_Application_FL = x.Outstanding_Balance_Application_FL,
                             .Outstanding_Balance_Group_FL = x.Outstanding_Balance_Group_FL, .Outstanding_Balance_MUL_Group_FL = x.Outstanding_Balance_MUL_Group_FL,
                             .Run_Application = x.Run_Application, .Run_Transaction_FL = x.Run_Transaction_FL, .Run_Application_FL = x.Run_Application_FL, .RunContractCompany_FL = x.RunContractCompany_FL,
                             .RunContractGroup_FL = x.RunContractGroup_FL}).FirstOrDefault()
            If IsNothing(query) Then
                Return HttpNotFound()
            End If
            'Dim detail = (From A In db.Tr_Applications
            '              Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
            '              From B In Group.DefaultIfEmpty()
            '              Where A.IsDeleted = False And A.IsFillOTR = True And A.ApplicationHeader_ID = id
            '              Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
            '                      A.Application_ID, B.Brand_Name,
            '                      B.Vehicle, A.Payee, A.PayeeRemark,
            '                      B.Transaction_Type, IsCOP = If(B.Transaction_Type = "COP", True, False),
            '                      A.Purchaser, A.Purchase_Type, B.Asset_Rating, IsDisabled = If(B.IsVehicleExists, "disabled", ""),
            '                  Expec_Contract_Date = Format(CType(A.Expec_Contract_Date, DateTime), "yyyy-MM-dd"),
            '                  Expec_Delivery_Date = Format(CType(A.Expec_Delivery_Date, Date), "yyyy-MM-dd"), A.Color,
            '                  IsDisabledAgenFee = If(If(A.Agent_Fee, 0) = 0, "disabled", ""), SelectOneTime = If(A.PayeeRemark = "One Time", "selected", ""),
            '                  SelectByInstallment = If(A.PayeeRemark = "By Installment", "selected", "")
            '                  ).ToList()

            Dim detail = (From A In db.Tr_Applications
                          Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
                          From B In Group.DefaultIfEmpty()
                          Where A.IsDeleted = False And A.IsFillOTR = True And A.ApplicationHeader_ID = id
                          Select AgenFeeStat = If(If(A.Agent_Fee, 0) = 0, False, True), A.Agent_Fee,
                                  A.Application_ID, B.Brand_Name,
                                  B.Vehicle, A.Payee, A.PayeeRemark,
                                  B.Transaction_Type, IsCOP = If(B.Transaction_Type = "COP", True, False),
                                  A.Purchaser, A.Purchase_Type, B.Asset_Rating, IsDisabled = If(B.IsVehicleExists, "disabled", ""),
                              IsDisabledCOP = If(B.Transaction_Type <> "COP", "disabled", ""),
                              A.Expec_Delivery_Date, A.Color,
                              IsDisabledAgenFee = If(If(A.Agent_Fee, 0) = 0, "disabled", ""), SelectOneTime = If(A.PayeeRemark = "One Time", "selected", ""),
                              SelectByInstallment = If(A.PayeeRemark = "By Installment", "selected", ""),
                              SelectOfferingLetter = If(A.Purchase_Type = "Offering Letter", "selected", ""),
                              SelectPurchaseAgreement = If(A.Purchase_Type = "Purchase Agreement", "selected", "")
                              ).ToList()

            ViewBag.Customer_Class = New SelectList(Customer_Class, "Value", "Text", query.Customer_Class)
            ViewBag.Contracted_by = New SelectList(Contracted_by, "Value", "Text", query.Contracted_by)
            ViewBag.ApplicationType = New SelectList(ApplicationType, "Value", "Text", query.ApplicationType)
            ViewBag.PeriodeType = New SelectList(PeriodeType, "Value", "Text", query.PeriodeType)
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", query.Credit_Rating)
            ViewBag.IsQuick = New SelectList(IsQuick, "Value", "Text", query.IsQuick)
            ViewBag.IsTruck = New SelectList(IsTruck, "Value", "Text", query.IsTruck)

            ViewBag.Detail = detail
            Return View(query)
        End Function
        'Edit Detail
        Public Function EditOrder(orderHeader() As Tr_ApplicationHeader, order() As Tr_Application) As ActionResult
            Dim user As String
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim result As String = "Error"
            Dim Valid As Boolean = True
            Dim Message As String = ""
            Dim Header = orderHeader.FirstOrDefault
#Region "Validate"
            Validasi(Header, Valid, Message, order, "Edit")
#End Region

            Dim trans As String = "Application"

            If Valid Then
                Dim app_ID_array = order.Select(Function(x) x.Application_ID).ToArray
                Dim Amount = db.Tr_Applications.Where(Function(x) app_ID_array.Contains(x.Application_ID)).Sum(Function(x) x.Cost_Price)

                Dim appHeader = db.Tr_ApplicationHeaders.Where(Function(x) x.ApplicationHeader_ID = Header.ApplicationHeader_ID And x.IsDeleted = False).FirstOrDefault
                appHeader.Credit_Rating = Header.Credit_Rating
                appHeader.Contracted_by = Header.Contracted_by
                appHeader.ApplicationType = Header.ApplicationType
                appHeader.PeriodeType = Header.PeriodeType
                appHeader.Contract_No = Header.Contract_No
                appHeader.Customer_Class = Header.Customer_Class
                appHeader.Line_of_Business = Header.Line_of_Business
                appHeader.Authorized_Capital = Header.Authorized_Capital
                appHeader.Authorized_Signer_Name1 = Header.Authorized_Signer_Name1
                appHeader.Authorized_Signer_Position1 = Header.Authorized_Signer_Position1
                appHeader.Authorized_Signer_Name2 = Header.Authorized_Signer_Name2
                appHeader.Authorized_Signer_Position2 = Header.Authorized_Signer_Position2
                appHeader.IntroducedBy = Header.IntroducedBy
                appHeader.Expec_Contract_Date = Header.Expec_Contract_Date
                appHeader.Remark = Header.Remark
                appHeader.Outstanding_Balance_Application = Header.Outstanding_Balance_Application
                appHeader.Outstanding_Balance_Group = Header.Outstanding_Balance_Group
                appHeader.Outstanding_Balance_MUL_Group = Header.Outstanding_Balance_MUL_Group
                appHeader.Outstanding_Balance_Amount = Amount + Header.Outstanding_Balance_Application + Header.Outstanding_Balance_Group + Header.Outstanding_Balance_MUL_Group
                appHeader.Outstanding_Balance_Transaction_FL = Header.Outstanding_Balance_Transaction_FL
                appHeader.Outstanding_Balance_Application_FL = Header.Outstanding_Balance_Application_FL
                appHeader.Outstanding_Balance_Group_FL = Header.Outstanding_Balance_Group_FL
                appHeader.Outstanding_Balance_MUL_Group_FL = Header.Outstanding_Balance_MUL_Group_FL
                appHeader.Outstanding_Balance_Amount_FL = Header.Outstanding_Balance_Transaction_FL + Header.Outstanding_Balance_Application_FL + Header.Outstanding_Balance_Group_FL + Header.Outstanding_Balance_MUL_Group_FL
                'appHeader.THU = Header.THU
                appHeader.IsTruck = Header.IsTruck
                appHeader.IsQuick = Header.IsQuick
                appHeader.Run_Application = Header.Run_Application
                appHeader.RunContractCompany = Header.RunContractCompany
                appHeader.RunContractGroup = Header.RunContractGroup
                appHeader.Run_Transaction_FL = Header.Run_Transaction_FL
                appHeader.Run_Application_FL = Header.Run_Application_FL
                appHeader.RunContractCompany_FL = Header.RunContractCompany_FL
                appHeader.RunContractGroup_FL = Header.RunContractGroup_FL
                appHeader.ModifiedBy = user
                appHeader.ModifiedDate = DateTime.Now
                For Each item In order
                    Dim D = db.Tr_Applications.Where(Function(x) x.Application_ID = item.Application_ID).FirstOrDefault()
                    'D.ApplicationHeader_ID = appHeader.ApplicationHeader_ID
                    If (item.Agent_FeeStat) Then
                        D.Payee = item.Payee
                        D.PayeeRemark = item.PayeeRemark
                    End If
                    If (item.Agent_FeeStat) Then
                        D.Purchaser = item.Purchaser
                        D.Purchase_Type = item.Purchase_Type
                    End If
                    D.Code_Open = item.Code_Open
                    D.Expec_Delivery_Date = item.Expec_Delivery_Date
                    'D.Asset_Rating = item.Asset_Rating
                    'Dim Rating = db.Ms_ProjRatingMatrixs.Where(Function(x) x.Asset_Rating = item.Asset_Rating And x.Credit_Rating = appHeader.Credit_Rating).FirstOrDefault
                    'D.Project_Rating = If(Rating.Project_Rating, "0")
                    D.ModifiedBy = user
                    D.ModifiedDate = DateTime.Now
                Next
                db.SaveChanges()
                result = "Success"
            End If
            Return Json(New With {Key .result = result, Key .message = Message}, JsonRequestBehavior.AllowGet)
        End Function

        ' GET: ApplicationHeader/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim query = (From A In db.Tr_ApplicationHeaders
                         Join B In db.V_ProspectCusts On A.Approval_ID Equals B.Approval_ID
                         Where A.IsDeleted = False And A.ApplicationHeader_ID = id
                         Select A.ApplicationHeader_ID, B.Address, B.CompanyGroup_Name, B.Company_Name, B.City, B.PIC_Name, B.PIC_Phone, B.PIC_Email, B.Phone, B.Email,
                             B.IsExists, A.Credit_Rating, A.Authorized_Capital, A.Authorized_Signer_Name1, CC = A.Customer_Class, A.Authorized_Signer_Position1, A.Authorized_Signer_Name2,
                             A.Authorized_Signer_Position2, A.IntroducedBy, CB = A.Contracted_by, A.ApplicationType, A.PeriodeType, A.Outstanding_Balance_Group, A.Outstanding_Balance_MUL_Group, A.RunContractCompany, A.RunContractGroup, A.IsTruck, A.IsQuick).
            Select(Function(x) New Tr_ApplicationHeader With {.ApplicationHeader_ID = x.ApplicationHeader_ID, .Address = x.Address, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                             .City = x.City, .PIC_Name = x.PIC_Name, .PIC_Phone = x.PIC_Phone, .PIC_Email = x.PIC_Email, .Phone = x.Phone, .Email = x.Email, .IsExists = x.IsExists, .Credit_Rating = x.Credit_Rating,
                             .Authorized_Capital = x.Authorized_Capital, .Authorized_Signer_Name1 = x.Authorized_Signer_Name1, .Customer_Class = x.CC, .Authorized_Signer_Position1 = x.Authorized_Signer_Position1,
                             .Authorized_Signer_Name2 = x.Authorized_Signer_Name2, .Authorized_Signer_Position2 = x.Authorized_Signer_Position2, .IntroducedBy = x.IntroducedBy, .Contracted_by = x.CB,
                             .Outstanding_Balance_Group = x.Outstanding_Balance_Group, .Outstanding_Balance_MUL_Group = x.Outstanding_Balance_MUL_Group, .RunContractCompany = x.RunContractCompany,
                             .RunContractGroup = x.RunContractGroup, .IsQuick = x.IsQuick, .IsTruck = x.IsTruck,.ApplicationType = x.ApplicationType, .PeriodeType = x.PeriodeType}).FirstOrDefault()

            If IsNothing(query) Then
                Return HttpNotFound()
            End If
            Return View(query)
        End Function

        ' POST: ApplicationHeader/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim tr_ApplicationHeader = db.Tr_ApplicationHeaders.Where(Function(x) x.ApplicationHeader_ID = id).FirstOrDefault()
            tr_ApplicationHeader.IsDeleted = True
            tr_ApplicationHeader.ModifiedBy = user
            tr_ApplicationHeader.ModifiedDate = DateTime.Now
            Dim apprapp = db.Tr_ApprovalApps.Where(Function(x) x.ApplicationHeader_ID = id).FirstOrDefault
            apprapp.IsDeleted = True
            apprapp.ModifiedBy = user
            apprapp.ModifiedDate = DateTime.Now

            Dim approval = db.Tr_Approvals.Where(Function(x) x.Approval_ID = tr_ApplicationHeader.Approval_ID).FirstOrDefault
            approval.IsApplicationHeader = False
            approval.IsApplicationHeaderDone = False
            approval.ModifiedBy = user
            approval.ModifiedDate = DateTime.Now


            Dim pros = db.V_ProspectCusts.Where(Function(x) x.ApplicationHeader_ID = id).FirstOrDefault
            Dim prosDet = db.V_ProspectCustDetails.Where(Function(x) x.Quotation_ID = Pros.Quotation_ID).ToList
            Dim app = db.Tr_Applications.Where(Function(x) x.ApplicationHeader_ID = id)
            For Each ap In app
                'jika dia di bawah Applikasi maka di false biar keapus di applikasi
                ap.ApplicationHeader_ID = Nothing

                If prosDet.Where(Function(x) x.Application_ID = ap.Application_ID And x.IsVehicleExists = False).Any Then
                    ap.IsFillOTR = False
                End If
                ap.ModifiedBy = user
                ap.ModifiedDate = DateTime.Now
                Dim appCashFowa = db.Tr_ApplicationCashFlows.Where(Function(x) x.Application_ID = ap.Application_ID).ToList
                For Each i In appCashFowa
                    i.IsDeleted = True
                    i.ModifiedBy = user
                    i.ModifiedDate = DateTime.Now
                Next
            Next


            Dim appPO = db.Tr_ApplicationPOs.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = pros.ProspectCustomer_ID)
            For Each i In appPO
                i.IsNotApproved = True
                i.RemarkNotApproved = tr_ApplicationHeader.RemarkNotApproved
            Next
            'Update Prospect IsApplicationPO
            Dim pross = db.Tr_ProspectCusts.Where(Function(x) x.ProspectCustomer_ID = pros.ProspectCustomer_ID).FirstOrDefault
            pross.IsApplicationPO = False
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
