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
Imports System.IO
Imports Ionic.Zip
Imports Microsoft.Reporting.WebForms
Imports Word = Microsoft.Office.Interop.Word


Namespace Controllers
    Public Class KYCController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Function Zip(id As Integer) As ActionResult
            Dim outputStream = New MemoryStream
            Using zip1 As ZipFile = New ZipFile()
                ReportIMWord(id, zip1)
                zip1.Save(outputStream)
            End Using
            outputStream.Position = 0
            Return File(outputStream, "application/zip", "Agreement.zip")
        End Function
        Function NoToRomawi(i As Integer) As String
            Dim result = ""
            If i = 1 Then
                result = "i"
            ElseIf i = 2 Then
                result = "ii"
            ElseIf i = 3 Then
                result = "iii"
            ElseIf i = 4 Then
                result = "iv"
            ElseIf i = 5 Then
                result = "v"
            ElseIf i = 6 Then
                result = "vi"
            ElseIf i = 7 Then
                result = "vii"
            ElseIf i = 8 Then
                result = "viii"
            ElseIf i = 9 Then
                result = "ix"
            ElseIf i = 10 Then
                result = "x"
            ElseIf i = 11 Then
                result = "xi"
            ElseIf i = 12 Then
                result = "xii"
            ElseIf i = 13 Then
                result = "xiii"
            ElseIf i = 14 Then
                result = "xiv"
            End If
            Return result
        End Function

        Sub ReportIMWord(KYC_ID As Integer, zip As ZipFile)
            ' Get the Word application object.
            Dim word_app = New Word.Application()

            ' Make Word visible (optional).
            'word_app.Visible = False

            ' Create the Word document.
            Dim word_doc As Word._Document = word_app.Documents.Add()
            'data dari DB
            Dim kyc = db.sp_KYCIM(KYC_ID).Select(Function(x) New Ms_Customer_KYC_Report With {.Customer_ID = x.Customer_ID,
.Company_Name = x.Company_Name,
.Legal_Domicile = x.Legal_Domicile,
.Line_Bussiness = x.Line_Bussiness,
.DOE_No = x.DOE_No,
.DOE_Date = x.DOE_Date,
.DOE_Notary = x.DOE_Notary,
.DOE_City_ID = x.DOE_City_ID,
.DOE_City = x.DOE_City,
.DOE_Approval_No = x.DOE_Approval_No,
.DOE_Approval_Date = x.DOE_Approval_Date,
.DOE_Approval_From = x.DOE_Approval_From,
.DOE_States_Gazette_No = x.DOE_States_Gazette_No,
.DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No,
.DOE_Supplement_Date = x.DOE_Supplement_Date,
.DOE_IsUploaded = x.DOE_IsUploaded,
.AOA_No = x.AOA_No,
.AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary,
.AOA_City_ID = x.AOA_City_ID,
.AOA_City = x.AOA_City,
.AOA_Approval_No = x.AOA_Approval_No,
.AOA_Approval_Date = x.AOA_Approval_Date,
.AOA_States_Gazette_No = x.AOA_States_Gazette_No,
.AOA_States_Gazette_Date = x.AOA_States_Gazette_Date,
.AOA_Supplement_No = x.AOA_Supplement_No,
.AOA_Supplement_Date = x.AOA_Supplement_Date,
.AOA_IsUploaded = x.AOA_IsUploaded,
.NPWP_No = x.NPWP_No,
.NPWP_IsUploaded = x.NPWP_IsUploaded,
.NPWP_SKT_No = x.NPWP_SKT_No,
.NPWP_SKT_Date = x.NPWP_SKT_Date,
.NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By,
.NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded,
.SPPKP_No = x.SPPKP_No,
.SPPKP_Date = x.SPPKP_Date,
.SPPKP_Issued_By = x.SPPKP_Issued_By,
.SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID,
.Business_License_No = x.Business_License_No,
.Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy,
.Business_License_ExpiredDate = x.Business_License_ExpiredDate,
.Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA,
.Business_License_IsUploaded = x.Business_License_IsUploaded,
.TDP_Type = x.TDP_Type,
.TDP = x.TDP,
.TDP_IssuedDate = x.TDP_IssuedDate,
.TDP_IssuedBy = x.TDP_IssuedBy,
.TDP_ExpiredDate = x.TDP_ExpiredDate,
.TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA,
.TDP_IsUploaded = x.TDP_IsUploaded,
.SKDP_Address = x.SKDP_Address,
.SKDP_No = x.SKDP_No,
.SKDP_IssuedDate = x.SKDP_IssuedDate,
.SKDP_IssuedBy = x.SKDP_IssuedBy,
.SKDP_ExpiredDate = x.SKDP_ExpiredDate,
.SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA,
.SKDP_IsUploaded = x.SKDP_IsUploaded,
.DOA1_No = x.DOA1_No,
.DOA1_Date = x.DOA1_Date,
.DOA1_Notary = x.DOA1_Notary,
.DOA1_City_ID = x.DOA1_City_ID,
.DOA1_City = x.DOA1_City,
.DOA1_Regarding = x.DOA1_Regarding,
.DOA1_Type = x.DOA1_Type,
.DOA1_Letter_No = x.DOA1_Letter_No,
.DOA1_Letter_Date = x.DOA1_Letter_Date,
.DOA1_IsUploaded = x.DOA1_IsUploaded,
.DOA2_No = x.DOA2_No,
.DOA2_Date = x.DOA2_Date,
.DOA2_Notary = x.DOA2_Notary,
.DOA2_City_ID = x.DOA2_City_ID,
.DOA2_City = x.DOA2_City,
.DOA2_Regarding = x.DOA2_Regarding,
.DOA2_Type = x.DOA2_Type,
.DOA2_Letter_No = x.DOA2_Letter_No,
.DOA2_Letter_Date = x.DOA2_Letter_Date,
.DOA2_IsUploaded = x.DOA2_IsUploaded,
.DOA3_No = x.DOA3_No,
.DOA3_Date = x.DOA3_Date,
.DOA3_Notary = x.DOA3_Notary,
.DOA3_City_ID = x.DOA3_City_ID,
.DOA3_City = x.DOA3_City,
.DOA3_Regarding = x.DOA3_Regarding,
.DOA3_Type = x.DOA3_Type,
.DOA3_Letter_No = x.DOA3_Letter_No,
.DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded,
.DOA4_No = x.DOA4_No,
.DOA4_Date = x.DOA4_Date,
.DOA4_Notary = x.DOA4_Notary,
.DOA4_City_ID = x.DOA4_City_ID,
.DOA4_City = x.DOA4_City,
.DOA4_Regarding = x.DOA4_Regarding,
.DOA4_Type = x.DOA4_Type,
.DOA4_Letter_No = x.DOA4_Letter_No,
.DOA4_Letter_Date = x.DOA4_Letter_Date,
.DOA4_IsUploaded = x.DOA4_IsUploaded,
.DOA5_No = x.DOA5_No,
.DOA5_Date = x.DOA5_Date,
.DOA5_Notary = x.DOA5_Notary,
.DOA5_City_ID = x.DOA5_City_ID,
.DOA5_City = x.DOA5_City,
.DOA5_Regarding = x.DOA5_Regarding,
.DOA5_Type = x.DOA5_Type,
.DOA5_Letter_No = x.DOA5_Letter_No,
.DOA5_Letter_Date = x.DOA5_Letter_Date,
.DOA5_IsUploaded = x.DOA5_IsUploaded,
.BOD_No = x.BOD_No,
.BOD_Date = x.BOD_Date,
.BOD_Notary = x.BOD_Notary,
.BOD_City_ID = x.BOD_City_ID,
.BOD_City = x.BOD_City,
.BOD_Type = x.BOD_Type,
.BOD_Letter_No = x.BOD_Letter_No,
.BOD_Letter_Date = x.BOD_Letter_Date,
.BOD_IsUploaded = x.BOD_IsUploaded,
.BoD_Period = x.BoD_Period,
.BoD_Mention = x.BoD_Mention,
.BoD_Article = x.BoD_Article,
.BoD_Appointment = x.BoD_Appointment,
.BoD_Expired = x.BoD_Expired,
.BoC_Period = x.BoC_Period,
.BoC_Mention = x.BoC_Mention,
.BoC_Article = x.BoC_Article,
.BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired,
.Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn,
.Authorized_Capital = x.Authorized_Capital,
.Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1,
.Article1 = x.Article1,
.InputParagraph11 = x.InputParagraph11,
.InputParagraph21 = x.InputParagraph21,
.InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender,
.Paragraph2 = x.Paragraph2,
.Article2 = x.Article2,
.InputParagraph12 = x.InputParagraph12,
.InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32,
.SuratKuasaBy = x.SuratKuasaBy,
.SuratKuasaBasedOn = x.SuratKuasaBasedOn,
.SuratKuasaDate = x.SuratKuasaDate,
.SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA,
.SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded,
.SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person,
.Annual_Income = x.Annual_Income,
.Purpose_of_Services = x.Purpose_of_Services,
.Identitas = x.Identitas,
.Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate,
.CreatedBy = x.CreatedBy,
.User_Name = x.User_Name,
.ModifiedDate = x.ModifiedDate,
.ModifiedBy = x.ModifiedBy,
.IsDeleted = x.IsDeleted
}).FirstOrDefault
            Dim direktor = db.Ms_Customer_KYC_Directors.Where(Function(x) x.KYC_ID = KYC_ID).ToList
            Dim commisioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.KYC_ID = KYC_ID).ToList
            ' Create a header paragraph.
            Dim para As Word.Paragraph = word_doc.Paragraphs.Add()
            'Dim para2 As Word.Paragraph = word_doc.Paragraphs.Add()
            para.Range.Text = "INTERNAL MEMO"
            para.Range.Style = "Strong"
            para.Range.InsertParagraphAfter()

            '' Add more text.
            'para.Range.Text = "To make a chrysanthemum curve, use the following " &
            '    "parametric equations as t goes from 0 to 21 * π to generate " &
            '    "points and then connect them."
            'para.Range.InsertParagraphAfter()

            ' Save the current font and start using Courier New.
            para.Range.Font.Name = "Consolas"
            para.Range.Style = "Normal"
            para.Range.Bold = 0
            ' Add the equations.
            Dim text = "To  : Management" & vbCrLf &
                "From: Legal & Contract Department" & vbCrLf &
                "Re  : Summary of Lessee’s KYC Documents" & vbCrLf &
                "Date: " & kyc.CreatedDate.ToString("yyyy/MMM/dd") & vbCrLf & vbCrLf &
                "Name of Lessee  :" & kyc.Company_Name & vbCrLf &
                "Domiciled in    :" & kyc.Legal_Domicile & vbCrLf &
                "Line of Business:" & kyc.Line_Bussiness & vbCrLf
            para.Range.Text = text
            para.Range.InsertParagraphAfter()
            para.Range.Font.Name = "Arial"
            text = "Summary:" & vbCrLf &
            "1. Deed of Establishment (""DoE"”) No. " & kyc.DOE_No & ", dated " & kyc.DOE_DateStr & ", made by Notary " & kyc.DOE_Notary & ", in " & kyc.DOE_City & ", with its Approval No. " & kyc.DOE_Approval_No & ", dated " & kyc.DOE_Approval_DateStr & ", from " & kyc.DOE_Approval_From & " and its States Gazette No. " & kyc.DOE_States_Gazette_No & ", dated " & kyc.DOE_States_Gazette_DateStr & ", with its Supplement No. " & kyc.DOE_Supplement_No & ", dated " & kyc.DOE_Supplement_DateStr & ".  " & vbCrLf &
            "2. Deed of Article of Association (""AoA"") No. " & kyc.AOA_No & ", dated " & kyc.AOA_DateStr & ", made by Notary " & kyc.AOA_Notary & ", in " & kyc.AOA_City & ", with its Approval No. " & kyc.AOA_Approval_No & ", dated " & kyc.AOA_Approval_DateStr & ", regarding the adjustment of company’s article association with Regulation No.40 Year 2007 concerning Company Limited (""UU PT"") from the Ministry of Law and Human Rights of the Republic of Indonesia and its States Gazette No. " & kyc.AOA_States_Gazette_No & ", dated " & kyc.AOA_States_Gazette_DateStr & ", with its Supplement No. " & kyc.AOA_Supplement_No & ", dated " & kyc.AOA_Supplement_DateStr & "." & vbCrLf &
            "3. Tax Registration Number (NPWP) No. " & kyc.NPWP_No & ", issued by the Directorate General of Taxation, Ministry of Finance of the Republic of Indonesia." & vbCrLf &
            "4. Certificate of Registered of the Taxpayer Registration Number (""SKT-NPWP"") No. " & kyc.NPWP_SKT_No & ", dated " & kyc.NPWP_SKT_DateStr & ", issued by " & kyc.NPWP_SKT_Issued_By & " the Directorate General of Taxation, Ministry of Finance of the Republic of Indonesia." & vbCrLf &
            "5. Taxable Entrepreneur Confirmation Letter Surat Pengukuhan Pengusaha Kena Pajak (""SPPKP"")] No. " & kyc.SPPKP_No & ", dated " & kyc.SPPKP_DateStr & ", issued by " & kyc.SPPKP_Issued_By & " the Directorate General of Taxation, Ministry of Finance of the Republic of Indonesia." & vbCrLf &
            "6. (Business License example: SIUP/IUT/IU from BKPM/other license) No. " & kyc.Business_License_No & ", dated " & kyc.Business_License_IssuedDateStr & ", issued by " & kyc.Business_License_IssuedBy & ", shall be valid until " & kyc.Business_License_ExpiredDateStr & "." & vbCrLf &
            "Trading Business License [Surat Izin Perdagangan (SIUP)] issued dated [*] by Government of the Republic of Indonesia cq the Online Single Submission (OSS)." & vbCrLf &
            "7. Certificate of Company Registration (TDP) No. " & kyc.TDP & ", dated " & kyc.TDP_IssuedDateStr & ", issued by " & kyc.TDP_IssuedBy & ", shall be valid until " & kyc.TDP_ExpiredDateStr & "." & vbCrLf &
            "Single Business Number (NIB) No. " & kyc.SKDP_No & " issued dated " & kyc.SKDP_IssuedDateStr & " by Government of the Republic of Indonesia cq the Online Single Submission (OSS)." & vbCrLf &
            "8. Registered Address at " & kyc.SKDP_Address & ", based on Letter of Domicile (SKDP) No. " & kyc.SKDP_No & ", dated " & kyc.SKDP_IssuedDateStr & ", issued by " & kyc.SKDP_IssuedBy & ", shall be valid until " & kyc.SKDP_ExpiredDateStr & "." & vbCrLf &
            "9. Deed No. " & kyc.DOA1_No & ", dated " & kyc.DOA1_DateStr & ", made by Notary " & kyc.DOA1_Notary & ", in " & kyc.DOA1_City & ", regarding " & kyc.DOA1_Regarding & ", with its Approval No. " & kyc.DOA1_Letter_No & "/Acceptance of Notification Letter No. " & kyc.DOA1_Letter_No & ", dated " & kyc.DOA1_Letter_DateStr & ", from the Ministry of Law & Human Rights of the Republic of Indonesia[." & vbCrLf &
            "10. Deed No. " & kyc.BOD_No & ", on " & kyc.BOD_Letter_DateStr & ", made by Notary " & kyc.BOD_Notary & ", in " & kyc.BOD_DateStr & ", regarding the changes of Board of Directors (""BoD"") and Board of Commissioner (""BoC"") composition, with its Acceptance of Notification Letter No. [BOD_Letter_No], on [BOD_Letter_Date] from the Ministry of Law and Human Rights of the Republic Indonesia." & vbCrLf &
            "11. Composition of BoD & BoC:" & vbCrLf
            para.Range.Text = text
            para.TabStops.Add(0.2)
            para.Range.ParagraphFormat.TabHangingIndent(1)

            text = "A. BoD: the members of the BoD are appointed for " & kyc.BoD_Period.ToString & " years as mentioned in paragraph " & kyc.Paragraph1.ToString & " Article " & kyc.BoD_Article & " of AoA. The latest appointment on " & kyc.BoD_AppointmentStr & ", so it shall be valid until " & kyc.BoD_ExpiredStr & ", with composition as follows:" & vbCrLf
            para.Range.Text = text
            text = ""
            'para.Range.ParagraphFormat.TabHangingIndent(1)
            Dim no = 1
            For Each i In direktor
                text = text & vbTab & NoToRomawi(no) & ". " & i.Gender & ". " & i.Director & " as " & i.Position & vbCrLf
                no += 1
            Next
            para.Range.ParagraphFormat.TabHangingIndent(-1)
            text = text & "B. BoC: the members of the BoC are appointed for " & kyc.BoC_Period.ToString & " years as mentioned in paragraph " & kyc.Paragraph2.ToString & " Article " & kyc.BoC_Article & " of AoA. The latest appointment on  " & kyc.BoC_AppointmentStr & ", so it shall be valid until " & kyc.BoC_ExpiredStr & ", with composition as follows:" & vbCrLf
            'para.Range.ParagraphFormat.TabHangingIndent(1)
            no = 1
            For Each i In commisioner
                text = text & vbTab & NoToRomawi(no) & ". " & i.Gender & ". " & i.Commissioner & " as " & i.Position & vbCrLf
                no += 1
            Next
            'para.Range.ParagraphFormat.TabHangingIndent(0)
            text = text & "12. Authorized Capital, Issued & Paid-up Capital and Shareholders composition based on " & kyc.Authorized_Capital_BasedOn & "." & vbCrLf &
            "A. Authorized Capital      : IDR" & kyc.Authorized_Capital & vbCrLf &
            "B. Issued & Paid-up Capital    : IDR[*]" & vbCrLf &
            "C. Shareholders composition    : " & vbCrLf

            para.Range.Text = text
            para.Range.InsertParagraphAfter()

            'Insert a 3 x 5 table, fill it with data, and make the first row
            'bold and italic.
            'Dim oTable As Word.Table
            'Dim r As Integer, c As Integer
            'oTable = word_doc.Tables.Add(word_doc.Bookmarks.Item("\endofdoc").Range, 3, 5)
            'oTable.Range.ParagraphFormat.SpaceAfter = 6
            'For r = 1 To 3
            '    For c = 1 To 5
            '        oTable.Cell(r, c).Range.Text = "r" & r & "c" & c
            '    Next
            'Next
            'oTable.Rows.Item(1).Range.Font.Bold = True
            'oTable.Rows.Item(1).Range.Font.Italic = True

            'Add some text after the table.
            'oTable.Range.InsertParagraphAfter()
            'para = word_doc.Content.Paragraphs.Add(word_doc.Bookmarks.Item("\endofdoc").Range)
            'para.Range.InsertParagraphAfter()





            '"i.	  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"ii.  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"iii. Mr/Mrs/Ms. [*] as [*]:" & vbCrLf &
            '"iv.  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"v.	  Mr/Mrs/Ms. [*] as [*]." & vbCrLf &
            '"B.	BoC: the members of the BoC are appointed for [*] years as mentioned in paragraph [*] Article [*] of AoA. The latest appointment on  [*], so it shall be valid until [*], with composition as follows:" & vbCrLf &
            '"i.	  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"ii.  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"iii. Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"iv.  Mr/Mrs/Ms. [*] as [*];" & vbCrLf &
            '"v.	  Mr/Mrs/Ms. [*] as [*]." & vbCrLf

            ' Start a new paragraph and then switch back to the original font.

            ' Save the document.
            Dim filename = Server.MapPath("~/Report/IMWord.doc")
            word_doc.SaveAs(filename)

            ' Close.
            Dim save_changes As Object = False
            word_doc.Close(save_changes)
            word_app.Quit(save_changes)
            zip.AddFile(filename, "")
        End Sub
        Sub ReportIM(KYC_ID As Integer, zip As ZipFile)
            Dim lr = New LocalReport()
            Dim path = Server.MapPath("~/Report/KYCIMTEST.rdlc")
            If (System.IO.File.Exists(path)) Then
                lr.ReportPath = path
            End If
            Dim kyc = db.sp_KYCIM(KYC_ID).ToList
            Dim director = db.sp_KYCIMDirector(KYC_ID).ToList
            'Dim commissioner = db.sp_KYCIMCommissioner(KYC_ID).ToList
            'Dim shareholder = db.sp_KYCIMShareholder(KYC_ID).ToList
            Dim rdkyc = New ReportDataSource("DSKYCIM", kyc)
            Dim rdDirector = New ReportDataSource("DSKYCIMDirector", director)
            'Dim rdCommissioner = New ReportDataSource("DSKYCIMCommissioner", commissioner)
            'Dim rdShareholder = New ReportDataSource("DSKYCIMShareholder", shareholder)
            lr.DataSources.Add(rdkyc)
            lr.DataSources.Add(rdDirector)
            'lr.DataSources.Add(rdCommissioner)
            'lr.DataSources.Add(rdShareholder)
            Dim reportType = "PDF"
            Dim MimeType As String = MimeMapping.GetMimeMapping(path)
            Dim endcoding As String
            Dim fileNameExtension As String = ".pdf"

            Dim deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>" + "PDF" + "</OutputFormat>" +
            " <PageWidth>21cm</PageWidth>" +
            " <PageHeight>2.54cm</PageHeight>" +
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

            zip.AddEntry("IM.pdf", renderedBytes)

        End Sub
        ' GET: KYC
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
            Dim kyc = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Customer_ID = x.Customer_ID,
.Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City, .DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary,
.DOE_City_ID = x.DOE_City_ID, .DOE_City = x.Ms_Citys7.City, .DOE_Approval_No = x.DOE_Approval_No, .DOE_Approval_Date = x.DOE_Approval_Date,
.DOE_Approval_From = x.DOE_Approval_From, .DOE_States_Gazette_No = x.DOE_States_Gazette_No, .DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No, .DOE_Supplement_Date = x.DOE_Supplement_Date, .DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID, .AOA_City = x.Ms_Citys.City, .AOA_Approval_No = x.AOA_Approval_No, .AOA_Approval_Date = x.AOA_Approval_Date,
.AOA_States_Gazette_No = x.AOA_States_Gazette_No, .AOA_States_Gazette_Date = x.AOA_States_Gazette_Date, .AOA_Supplement_No = x.AOA_Supplement_No,
.AOA_Supplement_Date = x.AOA_Supplement_Date, .AOA_IsUploaded = x.AOA_IsUploaded, .NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded,
.NPWP_SKT_No = x.NPWP_SKT_No, .NPWP_SKT_Date = x.NPWP_SKT_Date, .NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By, .NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded,
.SPPKP_No = x.SPPKP_No, .SPPKP_Date = x.SPPKP_Date, .SPPKP_Issued_By = x.SPPKP_Issued_By, .SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License = x.Ms_Customer_BusinessLicenses.BusinessLicense, .Business_License_No = x.Business_License_No, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_ExpiredDate = x.Business_License_ExpiredDate,
.Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA, .Business_License_IsUploaded = x.Business_License_IsUploaded, .TDP_Type = x.TDP_Type,
.TDP = x.TDP, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_IssuedBy = x.TDP_IssuedBy, .TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA,
.TDP_IsUploaded = x.TDP_IsUploaded, .SKDP_Address = x.SKDP_Address, .SKDP_No = x.SKDP_No, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IssuedBy = x.SKDP_IssuedBy,
.SKDP_ExpiredDate = x.SKDP_ExpiredDate, .SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA, .SKDP_IsUploaded = x.SKDP_IsUploaded, .DOA1_No = x.DOA1_No,
.DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID, .DOA1_City = x.Ms_Citys2.City, .DOA1_Regarding = x.DOA1_Regarding, .DOA1_Type = x.DOA1_Type,
.DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded, .DOA2_No = x.DOA2_No, .DOA2_Date = x.DOA2_Date,
.DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_City = x.Ms_Citys3.City, .DOA2_Regarding = x.DOA2_Regarding, .DOA2_Type = x.DOA2_Type, .DOA2_Letter_No = x.DOA2_Letter_No,
.DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date, .DOA3_Notary = x.DOA3_Notary,
.DOA3_City_ID = x.DOA3_City_ID, .DOA3_City = x.Ms_Citys4.City, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Type = x.DOA3_Type, .DOA3_Letter_No = x.DOA3_Letter_No, .DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID, .DOA4_City = x.Ms_Citys5.City,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Type = x.DOA4_Type, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date,
.DOA4_IsUploaded = x.DOA4_IsUploaded, .DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_City = x.Ms_Citys6.City,
.DOA5_Regarding = x.DOA5_Regarding, .DOA5_Type = x.DOA5_Type, .DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date,
.DOA5_IsUploaded = x.DOA5_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date, .BOD_Notary = x.BOD_Notary, .BOD_City_ID = x.BOD_City_ID, .BOD_City = x.Ms_Citys1.City, .BOD_Type = x.BOD_Type,
.BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date, .BOD_IsUploaded = x.BOD_IsUploaded, .BoD_Period = x.BoD_Period, .BoD_Mention = x.BoD_Mention,
.BoD_Article = x.BoD_Article, .BoD_Appointment = x.BoD_Appointment, .BoD_Expired = x.BoD_Expired, .BoC_Period = x.BoC_Period, .BoC_Mention = x.BoC_Mention, .BoC_Article = x.BoC_Article, .BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired, .Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1, .Article1 = x.Article1, .InputParagraph11 = x.InputParagraph11, .InputParagraph21 = x.InputParagraph21, .InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender, .Paragraph2 = x.Paragraph2, .Article2 = x.Article2, .InputParagraph12 = x.InputParagraph12, .InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32, .SuratKuasaBy = x.SuratKuasaBy, .SuratKuasaBasedOn = x.SuratKuasaBasedOn, .SuratKuasaDate = x.SuratKuasaDate, .SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA, .SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded, .SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person, .Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas, .Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            If Not String.IsNullOrEmpty(searchString) Then
                kyc = kyc.Where(Function(s) s.Customer_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Customer_Name"
                    kyc = kyc.OrderBy(Function(s) s.Customer_Name)
                Case Else
                    kyc = kyc.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(kyc.ToPagedList(pageNumber, pageSize))
        End Function
        Function IndexReviewKYC(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            Dim kyc = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.IsReviewed = False).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Customer_ID = x.Customer_ID,
.Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City, .DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary,
.DOE_City_ID = x.DOE_City_ID, .DOE_City = x.Ms_Citys7.City, .DOE_Approval_No = x.DOE_Approval_No, .DOE_Approval_Date = x.DOE_Approval_Date,
.DOE_Approval_From = x.DOE_Approval_From, .DOE_States_Gazette_No = x.DOE_States_Gazette_No, .DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No, .DOE_Supplement_Date = x.DOE_Supplement_Date, .DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID, .AOA_City = x.Ms_Citys.City, .AOA_Approval_No = x.AOA_Approval_No, .AOA_Approval_Date = x.AOA_Approval_Date,
.AOA_States_Gazette_No = x.AOA_States_Gazette_No, .AOA_States_Gazette_Date = x.AOA_States_Gazette_Date, .AOA_Supplement_No = x.AOA_Supplement_No,
.AOA_Supplement_Date = x.AOA_Supplement_Date, .AOA_IsUploaded = x.AOA_IsUploaded, .NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded,
.NPWP_SKT_No = x.NPWP_SKT_No, .NPWP_SKT_Date = x.NPWP_SKT_Date, .NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By, .NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded,
.SPPKP_No = x.SPPKP_No, .SPPKP_Date = x.SPPKP_Date, .SPPKP_Issued_By = x.SPPKP_Issued_By, .SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License = x.Ms_Customer_BusinessLicenses.BusinessLicense, .Business_License_No = x.Business_License_No, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_ExpiredDate = x.Business_License_ExpiredDate,
.Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA, .Business_License_IsUploaded = x.Business_License_IsUploaded, .TDP_Type = x.TDP_Type,
.TDP = x.TDP, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_IssuedBy = x.TDP_IssuedBy, .TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA,
.TDP_IsUploaded = x.TDP_IsUploaded, .SKDP_Address = x.SKDP_Address, .SKDP_No = x.SKDP_No, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IssuedBy = x.SKDP_IssuedBy,
.SKDP_ExpiredDate = x.SKDP_ExpiredDate, .SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA, .SKDP_IsUploaded = x.SKDP_IsUploaded, .DOA1_No = x.DOA1_No,
.DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID, .DOA1_City = x.Ms_Citys2.City, .DOA1_Regarding = x.DOA1_Regarding, .DOA1_Type = x.DOA1_Type,
.DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded, .DOA2_No = x.DOA2_No, .DOA2_Date = x.DOA2_Date,
.DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_City = x.Ms_Citys3.City, .DOA2_Regarding = x.DOA2_Regarding, .DOA2_Type = x.DOA2_Type, .DOA2_Letter_No = x.DOA2_Letter_No,
.DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date, .DOA3_Notary = x.DOA3_Notary,
.DOA3_City_ID = x.DOA3_City_ID, .DOA3_City = x.Ms_Citys4.City, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Type = x.DOA3_Type, .DOA3_Letter_No = x.DOA3_Letter_No, .DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID, .DOA4_City = x.Ms_Citys5.City,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Type = x.DOA4_Type, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date,
.DOA4_IsUploaded = x.DOA4_IsUploaded, .DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_City = x.Ms_Citys6.City,
.DOA5_Regarding = x.DOA5_Regarding, .DOA5_Type = x.DOA5_Type, .DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date,
.DOA5_IsUploaded = x.DOA5_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date, .BOD_Notary = x.BOD_Notary, .BOD_City_ID = x.BOD_City_ID, .BOD_City = x.Ms_Citys1.City, .BOD_Type = x.BOD_Type,
.BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date, .BOD_IsUploaded = x.BOD_IsUploaded, .BoD_Period = x.BoD_Period, .BoD_Mention = x.BoD_Mention,
.BoD_Article = x.BoD_Article, .BoD_Appointment = x.BoD_Appointment, .BoD_Expired = x.BoD_Expired, .BoC_Period = x.BoC_Period, .BoC_Mention = x.BoC_Mention, .BoC_Article = x.BoC_Article, .BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired, .Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1, .Article1 = x.Article1, .InputParagraph11 = x.InputParagraph11, .InputParagraph21 = x.InputParagraph21, .InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender, .Paragraph2 = x.Paragraph2, .Article2 = x.Article2, .InputParagraph12 = x.InputParagraph12, .InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32, .SuratKuasaBy = x.SuratKuasaBy, .SuratKuasaBasedOn = x.SuratKuasaBasedOn, .SuratKuasaDate = x.SuratKuasaDate, .SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA, .SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded, .SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person, .Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas, .Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                kyc = kyc.Where(Function(s) s.Customer_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Customer_Name"
                    kyc = kyc.OrderBy(Function(s) s.Customer_Name)
                Case Else
                    kyc = kyc.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(kyc.ToPagedList(pageNumber, pageSize))
        End Function
        ' GET: KYC/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim kyc = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Customer_ID = x.Customer_ID,
.Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City, .DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary,
.DOE_City_ID = x.DOE_City_ID, .DOE_City = x.Ms_Citys7.City, .DOE_Approval_No = x.DOE_Approval_No, .DOE_Approval_Date = x.DOE_Approval_Date,
.DOE_Approval_From = x.DOE_Approval_From, .DOE_States_Gazette_No = x.DOE_States_Gazette_No, .DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No, .DOE_Supplement_Date = x.DOE_Supplement_Date, .DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID, .AOA_City = x.Ms_Citys.City, .AOA_Approval_No = x.AOA_Approval_No, .AOA_Approval_Date = x.AOA_Approval_Date,
.AOA_States_Gazette_No = x.AOA_States_Gazette_No, .AOA_States_Gazette_Date = x.AOA_States_Gazette_Date, .AOA_Supplement_No = x.AOA_Supplement_No,
.AOA_Supplement_Date = x.AOA_Supplement_Date, .AOA_IsUploaded = x.AOA_IsUploaded, .NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded,
.NPWP_SKT_No = x.NPWP_SKT_No, .NPWP_SKT_Date = x.NPWP_SKT_Date, .NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By, .NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded,
.SPPKP_No = x.SPPKP_No, .SPPKP_Date = x.SPPKP_Date, .SPPKP_Issued_By = x.SPPKP_Issued_By, .SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License = x.Ms_Customer_BusinessLicenses.BusinessLicense, .Business_License_No = x.Business_License_No, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_ExpiredDate = x.Business_License_ExpiredDate,
.Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA, .Business_License_IsUploaded = x.Business_License_IsUploaded, .TDP_Type = x.TDP_Type,
.TDP = x.TDP, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_IssuedBy = x.TDP_IssuedBy, .TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA,
.TDP_IsUploaded = x.TDP_IsUploaded, .SKDP_Address = x.SKDP_Address, .SKDP_No = x.SKDP_No, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IssuedBy = x.SKDP_IssuedBy,
.SKDP_ExpiredDate = x.SKDP_ExpiredDate, .SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA, .SKDP_IsUploaded = x.SKDP_IsUploaded, .DOA1_No = x.DOA1_No,
.DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID, .DOA1_City = x.Ms_Citys2.City, .DOA1_Regarding = x.DOA1_Regarding, .DOA1_Type = x.DOA1_Type,
.DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded, .DOA2_No = x.DOA2_No, .DOA2_Date = x.DOA2_Date,
.DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_City = x.Ms_Citys3.City, .DOA2_Regarding = x.DOA2_Regarding, .DOA2_Type = x.DOA2_Type, .DOA2_Letter_No = x.DOA2_Letter_No,
.DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date, .DOA3_Notary = x.DOA3_Notary,
.DOA3_City_ID = x.DOA3_City_ID, .DOA3_City = x.Ms_Citys4.City, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Type = x.DOA3_Type, .DOA3_Letter_No = x.DOA3_Letter_No, .DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID, .DOA4_City = x.Ms_Citys5.City,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Type = x.DOA4_Type, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date,
.DOA4_IsUploaded = x.DOA4_IsUploaded, .DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_City = x.Ms_Citys6.City,
.DOA5_Regarding = x.DOA5_Regarding, .DOA5_Type = x.DOA5_Type, .DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date,
.DOA5_IsUploaded = x.DOA5_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date, .BOD_Notary = x.BOD_Notary, .BOD_City_ID = x.BOD_City_ID, .BOD_City = x.Ms_Citys1.City, .BOD_Type = x.BOD_Type,
.BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date, .BOD_IsUploaded = x.BOD_IsUploaded, .BoD_Period = x.BoD_Period, .BoD_Mention = x.BoD_Mention,
.BoD_Article = x.BoD_Article, .BoD_Appointment = x.BoD_Appointment, .BoD_Expired = x.BoD_Expired, .BoC_Period = x.BoC_Period, .BoC_Mention = x.BoC_Mention, .BoC_Article = x.BoC_Article, .BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired, .Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1, .Article1 = x.Article1, .InputParagraph11 = x.InputParagraph11, .InputParagraph21 = x.InputParagraph21, .InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender, .Paragraph2 = x.Paragraph2, .Article2 = x.Article2, .InputParagraph12 = x.InputParagraph12, .InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32, .SuratKuasaBy = x.SuratKuasaBy, .SuratKuasaBasedOn = x.SuratKuasaBasedOn, .SuratKuasaDate = x.SuratKuasaDate, .SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA, .SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded, .SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person, .Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas, .Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(kyc) Then
                Return HttpNotFound()
            End If
            Return View(kyc)
        End Function

        ' GET: KYC/Create
        Function Create() As ActionResult
            Dim city = New SelectList(db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City), "CIty_ID", "City")
            ViewBag.AOA_City_ID = city
            ViewBag.BOD_City_ID = city
            ViewBag.DOA1_City_ID = city
            ViewBag.DOA2_City_ID = city
            ViewBag.DOA3_City_ID = city
            ViewBag.DOA4_City_ID = city
            ViewBag.DOA5_City_ID = city
            ViewBag.DOE_City_ID = city
            ViewBag.Legal_Domicile_City_ID = city
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.BusinessLicense), "BusinessLicense_ID", "BusinessLicense")
            ViewBag.Identitas_ID = New SelectList(db.Ms_Customer_Identitass.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Identitas), "Identitas_ID", "Identitas")
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False And x.IsKYC = False).OrderBy(Function(x) x.Company_Name).
                                                 Select(Function(x) New Ms_Customer_Combo With {.Customer_ID = x.Customer_ID, .Company_Name = x.PT + " " + x.Company_Name + " " + If(x.Tbk, "Tbk", "Non Tbk")}), "Customer_ID", "Company_Name")
            Dim kyc As New Ms_Customer_KYC
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text")
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text")
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text")
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.Gender = New SelectList(GenderList, "Value", "Text")
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text")

            Return View(kyc)
        End Function

        Private Sub Validate(model As Ms_Customer_KYC)
            'Dim validDirector = model.DetailDirector.Where(Function(x) x.Validate = False).FirstOrDefault
            'If model.DetailDirector IsNot Nothing Then
            '    If validDirector IsNot Nothing Then
            '        ModelState.AddModelError("ValidateDirector", validDirector.ValidateMessage)
            '    End If

            'Else
            '    'ModelState.AddModelError("ValidateDirector", "Must Fill Director")
            'End If
            'If model.DetailCommissioner IsNot Nothing Then
            '    Dim validCommissioner = model.DetailCommissioner.Where(Function(x) x.Validate = False).FirstOrDefault
            '    If validCommissioner IsNot Nothing Then
            '        ModelState.AddModelError("ValidateCommissioner", validCommissioner.ValidateMessage)
            '    End If
            'Else
            '    'ModelState.AddModelError("ValidateCommissioner", "Must Fill Director")
            'End If
            'If model.DetailShareholder IsNot Nothing Then
            '    Dim validShareholder = model.DetailShareholder.Where(Function(x) x.Validate = False).FirstOrDefault
            '    If validShareholder IsNot Nothing Then
            '        ModelState.AddModelError("ValidateShareholder", validShareholder.ValidateMessage)
            '    End If
            'Else
            '    'ModelState.AddModelError("ValidateShareholder", "Must Fill Shareholder")
            'End If


            If (model.DetailDirector IsNot Nothing) Then
                If Not (model.DetailDirector.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateDirector", "Fill the Director")
                End If
            End If

            If (model.DetailCommissioner IsNot Nothing) Then
                If Not (model.DetailCommissioner.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateCommissioner", "Fill the Commissioner")
                End If
            End If

            'If (model.DetailAuthorizedSigner IsNot Nothing) Then
            '    If Not (model.DetailAuthorizedSigner.Any(Function(x) x.Active = True)) Then
            '        ModelState.AddModelError("ValidateAuthorizedSigner", "Fill the AuthorizedSigner")
            '    End If
            'Else
            '    ModelState.AddModelError("ValidateAuthorizedSigner", "Fill the AuthorizedSigner")
            'End If

            'If (model.DetailShareholder IsNot Nothing) Then
            '    If Not (model.DetailShareholder.Any(Function(x) x.Active = True)) Then
            '        ModelState.AddModelError("ValidateShareholder", "Fill the Shareholder")
            '    End If
            'End If
            'If (model.DetailLineBussiness Is Nothing) Then
            '    ModelState.AddModelError("ValidateLineBussiness", "Fill the LineBussiness")
            'End If

            'Isi status biar gampang nanti di edit
            If model.DOE_IsUploadedFile Is Nothing Then
                model.DOE_IsUploaded = False
            Else
                model.DOE_IsUploaded = True
            End If
            If model.AOA_IsUploadedFile Is Nothing Then
                model.AOA_IsUploaded = False
            Else
                model.AOA_IsUploaded = True
            End If
            If model.BOD_IsUploadedFile Is Nothing Then
                model.BOD_IsUploaded = False
            Else
                model.BOD_IsUploaded = True
            End If
            If model.DOA1_IsUploadedFile Is Nothing Then
                model.DOA1_IsUploaded = False
            Else
                model.DOA1_IsUploaded = True
            End If
            If model.DOA2_IsUploadedFile Is Nothing Then
                model.DOA2_IsUploaded = False
            Else
                model.DOA2_IsUploaded = True
            End If
            If model.DOA3_IsUploadedFile Is Nothing Then
                model.DOA3_IsUploaded = False
            Else
                model.DOA3_IsUploaded = True
            End If
            If model.DOA4_IsUploadedFile Is Nothing Then
                model.DOA4_IsUploaded = False
            Else
                model.DOA4_IsUploaded = True
            End If
            If model.DOA5_IsUploadedFile Is Nothing Then
                model.DOA5_IsUploaded = False
            Else
                model.DOA5_IsUploaded = True
            End If
            If model.Business_License_IsUploadedFile Is Nothing Then
                model.Business_License_IsUploaded = False
            Else
                model.Business_License_IsUploaded = True
            End If
            If model.TDP_IsUploadedFile Is Nothing Then
                model.TDP_IsUploaded = False
            Else
                model.TDP_IsUploaded = True
            End If
            If model.SKDP_IsUploadedFile Is Nothing Then
                model.SKDP_IsUploaded = False
            Else
                model.SKDP_IsUploaded = True
            End If
            If model.NPWP_IsUploadedFile Is Nothing Then
                model.NPWP_IsUploaded = False
            Else
                model.NPWP_IsUploaded = True
            End If
            If model.NPWP_SKT_IsUploadedFile Is Nothing Then
                model.NPWP_SKT_IsUploaded = False
            Else
                model.NPWP_SKT_IsUploaded = True
            End If
            If model.SPPKP_IsUploadedFile Is Nothing Then
                model.SPPKP_IsUploaded = False
            Else
                model.SPPKP_IsUploaded = True
            End If

            If model.Identitas_IsUploadedFile Is Nothing Then
                model.Identitas_IsUploaded = False
            Else
                model.Identitas_IsUploaded = True
            End If
            If model.SuratKuasaPenerima_IsUploadedFile Is Nothing Then
                model.SuratKuasaPenerima_IsUploaded = False
            Else
                model.SuratKuasaPenerima_IsUploaded = True
            End If
            If model.SuratKuasa_IsUploadedFile Is Nothing Then
                model.SuratKuasa_IsUploaded = False
            Else
                model.SuratKuasa_IsUploaded = True
            End If

        End Sub
        ' POST: KYC/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(model As Ms_Customer_KYC) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Validate(model)
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim kycs As New Ms_Customer_KYCs
                        kycs.Customer_ID = model.Customer_ID
                        kycs.Legal_Domicile_City_ID = model.Legal_Domicile_City_ID
                        kycs.DOE_No = model.DOE_No
                        kycs.DOE_Date = model.DOE_Date
                        kycs.DOE_Notary = model.DOE_Notary
                        kycs.DOE_City_ID = model.DOE_City_ID
                        kycs.DOE_Approval_No = model.DOE_Approval_No
                        kycs.DOE_Approval_Date = model.DOE_Approval_Date
                        kycs.DOE_Approval_From = model.DOE_Approval_From
                        kycs.DOE_States_Gazette_No = model.DOE_States_Gazette_No
                        kycs.DOE_States_Gazette_Date = model.DOE_States_Gazette_Date
                        kycs.DOE_Supplement_No = model.DOE_Supplement_No
                        kycs.DOE_Supplement_Date = model.DOE_Supplement_Date
                        kycs.DOE_IsUploaded = model.DOE_IsUploaded
                        kycs.AOA_No = model.AOA_No
                        kycs.AOA_Date = model.AOA_Date
                        kycs.AOA_Notary = model.AOA_Notary
                        kycs.AOA_City_ID = model.AOA_City_ID
                        kycs.AOA_Approval_No = model.AOA_Approval_No
                        kycs.AOA_Approval_Date = model.AOA_Approval_Date
                        kycs.AOA_States_Gazette_No = model.AOA_States_Gazette_No
                        kycs.AOA_States_Gazette_Date = model.AOA_States_Gazette_Date
                        kycs.AOA_Supplement_No = model.AOA_Supplement_No
                        kycs.AOA_Supplement_Date = model.AOA_Supplement_Date
                        kycs.AOA_IsUploaded = model.AOA_IsUploaded
                        kycs.NPWP_No = model.NPWP_No
                        kycs.NPWP_IsUploaded = model.NPWP_IsUploaded
                        kycs.NPWP_SKT_No = model.NPWP_SKT_No
                        kycs.NPWP_SKT_Date = model.NPWP_SKT_Date
                        kycs.NPWP_SKT_Issued_By = model.NPWP_SKT_Issued_By
                        kycs.NPWP_SKT_IsUploaded = model.NPWP_SKT_IsUploaded
                        kycs.SPPKP_No = model.SPPKP_No
                        kycs.SPPKP_Date = model.SPPKP_Date
                        kycs.SPPKP_Issued_By = model.SPPKP_Issued_By
                        kycs.SPPKP_IsUploaded = model.SPPKP_IsUploaded
                        kycs.Business_License_ID = model.Business_License_ID
                        kycs.Business_License_No = model.Business_License_No
                        kycs.Business_License_IssuedDate = model.Business_License_IssuedDate
                        kycs.Business_License_IssuedBy = model.Business_License_IssuedBy
                        kycs.Business_License_ExpiredDate = model.Business_License_ExpiredDate
                        kycs.Business_License_ExpiredDate_IsNA = model.Business_License_ExpiredDate_IsNA
                        kycs.Business_License_IsUploaded = model.Business_License_IsUploaded
                        kycs.TDP_Type = model.TDP_Type
                        kycs.TDP = model.TDP
                        kycs.TDP_IssuedDate = model.TDP_IssuedDate
                        kycs.TDP_IssuedBy = model.TDP_IssuedBy
                        kycs.TDP_ExpiredDate = model.TDP_ExpiredDate
                        kycs.TDP_ExpiredDate_IsNA = model.TDP_ExpiredDate_IsNA
                        kycs.TDP_IsUploaded = model.TDP_IsUploaded
                        kycs.SKDP_Address = model.SKDP_Address
                        kycs.SKDP_No = model.SKDP_No
                        kycs.SKDP_IssuedDate = model.SKDP_IssuedDate
                        kycs.SKDP_IssuedBy = model.SKDP_IssuedBy
                        kycs.SKDP_ExpiredDate = model.SKDP_ExpiredDate
                        kycs.SKDP_ExpiredDate_IsNA = model.SKDP_ExpiredDate_IsNA
                        kycs.SKDP_IsUploaded = model.SKDP_IsUploaded
                        kycs.DOA1_No = model.DOA1_No
                        kycs.DOA1_Date = model.DOA1_Date
                        kycs.DOA1_Notary = model.DOA1_Notary
                        kycs.DOA1_City_ID = model.DOA1_City_ID
                        kycs.DOA1_Regarding = model.DOA1_Regarding
                        kycs.DOA1_Type = model.DOA1_Type
                        kycs.DOA1_Letter_No = model.DOA1_Letter_No
                        kycs.DOA1_Letter_Date = model.DOA1_Letter_Date
                        kycs.DOA1_IsUploaded = model.DOA1_IsUploaded
                        kycs.DOA2_No = model.DOA2_No
                        kycs.DOA2_Date = model.DOA2_Date
                        kycs.DOA2_Notary = model.DOA2_Notary
                        kycs.DOA2_City_ID = model.DOA2_City_ID
                        kycs.DOA2_Regarding = model.DOA2_Regarding
                        kycs.DOA2_Type = model.DOA2_Type
                        kycs.DOA2_Letter_No = model.DOA2_Letter_No
                        kycs.DOA2_Letter_Date = model.DOA2_Letter_Date
                        kycs.DOA2_IsUploaded = model.DOA2_IsUploaded
                        kycs.DOA3_No = model.DOA3_No
                        kycs.DOA3_Date = model.DOA3_Date
                        kycs.DOA3_Notary = model.DOA3_Notary
                        kycs.DOA3_City_ID = model.DOA3_City_ID
                        kycs.DOA3_Regarding = model.DOA3_Regarding
                        kycs.DOA3_Type = model.DOA3_Type
                        kycs.DOA3_Letter_No = model.DOA3_Letter_No
                        kycs.DOA3_Letter_Date = model.DOA3_Letter_Date
                        kycs.DOA3_IsUploaded = model.DOA3_IsUploaded
                        kycs.DOA4_No = model.DOA4_No
                        kycs.DOA4_Date = model.DOA4_Date
                        kycs.DOA4_Notary = model.DOA4_Notary
                        kycs.DOA4_City_ID = model.DOA4_City_ID
                        kycs.DOA4_Regarding = model.DOA4_Regarding
                        kycs.DOA4_Type = model.DOA4_Type
                        kycs.DOA4_Letter_No = model.DOA4_Letter_No
                        kycs.DOA4_Letter_Date = model.DOA4_Letter_Date
                        kycs.DOA4_IsUploaded = model.DOA4_IsUploaded
                        kycs.DOA5_No = model.DOA5_No
                        kycs.DOA5_Date = model.DOA5_Date
                        kycs.DOA5_Notary = model.DOA5_Notary
                        kycs.DOA5_City_ID = model.DOA5_City_ID
                        kycs.DOA5_Regarding = model.DOA5_Regarding
                        kycs.DOA5_Type = model.DOA5_Type
                        kycs.DOA5_Letter_No = model.DOA5_Letter_No
                        kycs.DOA5_Letter_Date = model.DOA5_Letter_Date
                        kycs.DOA5_IsUploaded = model.DOA5_IsUploaded
                        kycs.BOD_No = model.BOD_No
                        kycs.BOD_Date = model.BOD_Date
                        kycs.BOD_Notary = model.BOD_Notary
                        kycs.BOD_City_ID = model.BOD_City_ID
                        kycs.BOD_Type = model.BOD_Type
                        kycs.BOD_Letter_No = model.BOD_Letter_No
                        kycs.BOD_Letter_Date = model.BOD_Letter_Date
                        kycs.BOD_IsUploaded = model.BOD_IsUploaded
                        kycs.BoD_Period = model.BoD_Period
                        kycs.BoD_Mention = model.BoD_Mention
                        kycs.BoD_Article = model.BoD_Article
                        kycs.BoD_Appointment = model.BoD_Appointment
                        kycs.BoD_Expired = model.BoD_Expired
                        kycs.BoC_Period = model.BoC_Period
                        kycs.BoC_Mention = model.BoC_Mention
                        kycs.BoC_Article = model.BoC_Article
                        kycs.BoC_Appointment = model.BoC_Appointment
                        kycs.BoC_Expired = model.BoC_Expired
                        kycs.Authorized_Capital_BasedOn = model.Authorized_Capital_BasedOn
                        kycs.Authorized_Capital = model.Authorized_Capital
                        kycs.Issued_Paidup_Capital = model.Issued_Paidup_Capital
                        kycs.Paragraph1 = model.Paragraph1
                        kycs.Article1 = model.Article1
                        kycs.InputParagraph11 = model.InputParagraph11
                        kycs.InputParagraph21 = model.InputParagraph21
                        kycs.InputParagraph31 = model.InputParagraph31
                        kycs.Paragraph2 = model.Paragraph2
                        kycs.Article2 = model.Article2
                        kycs.InputParagraph12 = model.InputParagraph12
                        kycs.InputParagraph22 = model.InputParagraph22
                        kycs.InputParagraph32 = model.InputParagraph32
                        kycs.SuratKuasaBy = model.SuratKuasaBy
                        kycs.SuratKuasaGender = model.SuratKuasaGender
                        kycs.SuratKuasaBasedOn = model.SuratKuasaBasedOn
                        kycs.SuratKuasaDate = model.SuratKuasaDate
                        kycs.SuratKuasaExpired = model.SuratKuasaExpired
                        kycs.SuratKuasaExpired_IsNA = model.SuratKuasaExpired_IsNA
                        kycs.SuratKuasaPenerima_IsUploaded = model.SuratKuasaPenerima_IsUploaded
                        kycs.SuratKuasa_IsUploaded = model.SuratKuasa_IsUploaded
                        kycs.Authorized_Person = model.Authorized_Person
                        kycs.Annual_Income = model.Annual_Income
                        kycs.Purpose_of_Services = model.Purpose_of_Services
                        kycs.Identitas = model.Identitas
                        kycs.Identitas_IsUploaded = model.Identitas_IsUploaded
                        kycs.IsReviewed = False
                        kycs.CreatedBy = user
                        kycs.CreatedDate = DateTime.Now
                        kycs.IsDeleted = False
                        db.Ms_Customer_KYCs.Add(kycs)
                        If model.DetailLineBussiness IsNot Nothing Then
                            For Each i In model.DetailLineBussiness
                                Dim LineBussiness As New Ms_Customer_KYC_LineBussinesss
                                LineBussiness.KYC_ID = kycs.KYC_ID
                                LineBussiness.LineBussiness = i.LineBussiness
                                LineBussiness.CreatedBy = user
                                LineBussiness.CreatedDate = DateTime.Now
                                LineBussiness.IsDeleted = False
                                db.Ms_Customer_KYC_LineBussinesss.Add(LineBussiness)
                            Next
                        End If
                        If model.DetailDirector IsNot Nothing Then
                            For Each i In model.DetailDirector.Where(Function(x) x.Active = True)
                                Dim director As New Ms_Customer_KYC_Directors
                                director.KYC_ID = kycs.KYC_ID
                                director.Director = i.Director
                                director.Gender = i.Gender
                                director.Position = i.Position
                                director.CreatedBy = user
                                director.CreatedDate = DateTime.Now
                                director.IsDeleted = False
                                db.Ms_Customer_KYC_Directors.Add(director)
                            Next
                        End If
                        If model.DetailCommissioner IsNot Nothing Then
                            For Each i In model.DetailCommissioner.Where(Function(x) x.Active = True)
                                Dim commissioner As New Ms_Customer_KYC_Commissioners
                                commissioner.KYC_ID = kycs.KYC_ID
                                commissioner.Commissioner = i.Commissioner
                                commissioner.Gender = i.Gender
                                commissioner.Position = i.Position
                                commissioner.CreatedBy = user
                                commissioner.CreatedDate = DateTime.Now
                                commissioner.IsDeleted = False
                                db.Ms_Customer_KYC_Commissioners.Add(commissioner)
                            Next
                        End If
                        If model.DetailAuthorizedSigner IsNot Nothing Then
                            For Each i In model.DetailAuthorizedSigner.Where(Function(x) x.Active = True)
                                Dim authorizedSigner As New Ms_Customer_KYC_AuthorizedSigners
                                authorizedSigner.KYC_ID = kycs.KYC_ID
                                authorizedSigner.AuthorizedSigner = i.AuthorizedSigner
                                authorizedSigner.Position = i.Position
                                authorizedSigner.CreatedBy = user
                                authorizedSigner.CreatedDate = DateTime.Now
                                authorizedSigner.IsDeleted = False
                                db.Ms_Customer_KYC_AuthorizedSigners.Add(authorizedSigner)
                            Next
                        End If

                        If model.DetailShareholder IsNot Nothing Then
                            For Each i In model.DetailShareholder.Where(Function(x) x.Active = True)
                                Dim Shareholder As New Ms_Customer_KYC_Shareholders
                                Shareholder.KYC_ID = kycs.KYC_ID
                                Shareholder.Shareholder_Name = i.Shareholder_Name
                                Shareholder.AmountofShares = i.AmountofShares
                                Shareholder.Nominal_Amount = i.Nominal_Amount
                                Shareholder.CreatedBy = user
                                Shareholder.CreatedDate = DateTime.Now
                                Shareholder.IsDeleted = False
                                db.Ms_Customer_KYC_Shareholders.Add(Shareholder)
                            Next
                        End If


                        Dim updateCust = db.Ms_Customers.Where(Function(x) x.Customer_ID = model.Customer_ID).FirstOrDefault
                        updateCust.IsKYC = True
                        'udpate isKYC di update true
                        db.SaveChanges()
                        'save file
                        If model.DOE_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOE"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOE_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOE_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.AOA_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/AOA"), kycs.KYC_ID.ToString() + ".pdf")
                            model.AOA_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.AOA_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.BOD_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BOD"), kycs.KYC_ID.ToString() + ".pdf")
                            model.BOD_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.BOD_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA1_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA1"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA1_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA1_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA2_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA2"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA2_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA2_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA3_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA3"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA3_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA3_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA4_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA4"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA4_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA4_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA5_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA5"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA5_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA5_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Business_License_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BL"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Business_License_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Business_License_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.TDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/TDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.TDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.TDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SKDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SKDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SKDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SKDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_SKT_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP_SKT"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_SKT_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_SKT_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SPPKP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SPPKP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SPPKP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SPPKP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Identitas_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/Identitas"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Identitas_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Identitas_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasaPenerima_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasaPenerima"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasaPenerima_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasaPenerima_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasa_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasa"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasa_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasa_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        dbs.Commit()
                        Return RedirectToAction("Index")
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("", ex.Message)
                    End Try
                End Using

            End If
            Dim city = db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City)
            ViewBag.AOA_City_ID = New SelectList(city, "CIty_ID", "City", model.AOA_City_ID)
            ViewBag.BOD_City_ID = New SelectList(city, "CIty_ID", "City", model.BOD_City_ID)
            ViewBag.DOA1_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA1_City_ID)
            ViewBag.DOA2_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA2_City_ID)
            ViewBag.DOA3_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA3_City_ID)
            ViewBag.DOA4_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA4_City_ID)
            ViewBag.DOA5_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA5_City_ID)
            ViewBag.DOE_City_ID = New SelectList(city, "CIty_ID", "City", model.DOE_City_ID)
            ViewBag.Legal_Domicile_City_ID = New SelectList(city, "CIty_ID", "City", model.Legal_Domicile_City_ID)
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.BusinessLicense), "BusinessLicense_ID", "BusinessLicense", model.Business_License_ID)
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False And x.IsKYC = False).OrderBy(Function(x) x.Company_Name), "Customer_ID", "Company_Name", model.Customer_ID)
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text", model.Identitas)
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text")
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text")
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text")
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.Gender = New SelectList(GenderList, "Value", "Text")
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text")
            Return View(model)
        End Function

        'Get :   KYC/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_KYCs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_ID = x.Customer_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City,
.DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary, .DOE_City_ID = x.DOE_City_ID, .DOE_Approval_No = x.DOE_Approval_No,
.DOE_Approval_Date = x.DOE_Approval_Date, .DOE_Approval_From = x.DOE_Approval_From, .DOE_States_Gazette_No = x.DOE_States_Gazette_No, .DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No, .DOE_Supplement_Date = x.DOE_Supplement_Date, .DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID, .AOA_Approval_No = x.AOA_Approval_No, .AOA_Approval_Date = x.AOA_Approval_Date, .AOA_States_Gazette_No = x.AOA_States_Gazette_No,
.AOA_States_Gazette_Date = x.AOA_States_Gazette_Date, .AOA_Supplement_No = x.AOA_Supplement_No, .AOA_Supplement_Date = x.AOA_Supplement_Date, .AOA_IsUploaded = x.AOA_IsUploaded,
.NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded, .NPWP_SKT_No = x.NPWP_SKT_No, .NPWP_SKT_Date = x.NPWP_SKT_Date, .NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By,
.NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded, .SPPKP_No = x.SPPKP_No, .SPPKP_Date = x.SPPKP_Date, .SPPKP_Issued_By = x.SPPKP_Issued_By, .SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License_No = x.Business_License_No, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_ExpiredDate = x.Business_License_ExpiredDate, .Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA,
.Business_License_IsUploaded = x.Business_License_IsUploaded, .TDP_Type = x.TDP_Type, .TDP = x.TDP, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_IssuedBy = x.TDP_IssuedBy,
.TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA, .TDP_IsUploaded = x.TDP_IsUploaded, .SKDP_Address = x.SKDP_Address,
.SKDP_No = x.SKDP_No, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IssuedBy = x.SKDP_IssuedBy, .SKDP_ExpiredDate = x.SKDP_ExpiredDate, .SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA,
.SKDP_IsUploaded = x.SKDP_IsUploaded, .DOA1_No = x.DOA1_No, .DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID, .DOA1_Regarding = x.DOA1_Regarding,
.DOA1_Type = x.DOA1_Type, .DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded, .DOA2_No = x.DOA2_No,
.DOA2_Date = x.DOA2_Date, .DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_Regarding = x.DOA2_Regarding, .DOA2_Type = x.DOA2_Type,
.DOA2_Letter_No = x.DOA2_Letter_No, .DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date,
.DOA3_Notary = x.DOA3_Notary, .DOA3_City_ID = x.DOA3_City_ID, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Type = x.DOA3_Type, .DOA3_Letter_No = x.DOA3_Letter_No,
.DOA3_Letter_Date = x.DOA3_Letter_Date, .DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Type = x.DOA4_Type, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date, .DOA4_IsUploaded = x.DOA4_IsUploaded,
.DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_Regarding = x.DOA5_Regarding, .DOA5_Type = x.DOA5_Type,
.DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date, .DOA5_IsUploaded = x.DOA5_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date,
.BOD_Notary = x.BOD_Notary, .BOD_City_ID = x.BOD_City_ID, .BOD_Type = x.BOD_Type, .BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date,
.BOD_IsUploaded = x.BOD_IsUploaded, .BoD_Period = x.BoD_Period, .BoD_Mention = x.BoD_Mention, .BoD_Article = x.BoD_Article, .BoD_Appointment = x.BoD_Appointment,
.BoD_Expired = x.BoD_Expired, .BoC_Period = x.BoC_Period, .BoC_Mention = x.BoC_Mention, .BoC_Article = x.BoC_Article, .BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired, .Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1, .Article1 = x.Article1, .InputParagraph11 = x.InputParagraph11, .InputParagraph21 = x.InputParagraph21, .InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender, .Paragraph2 = x.Paragraph2, .Article2 = x.Article2, .InputParagraph12 = x.InputParagraph12, .InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32, .SuratKuasaBy = x.SuratKuasaBy, .SuratKuasaBasedOn = x.SuratKuasaBasedOn, .SuratKuasaDate = x.SuratKuasaDate, .SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA, .SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded, .SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person, .Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas, .Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_Customer_KYCs) Then
                Return HttpNotFound()
            End If
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City)
            ViewBag.AOA_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.AOA_City_ID)
            ViewBag.BOD_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.BOD_City_ID)
            ViewBag.DOA1_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA1_City_ID)
            ViewBag.DOA2_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA2_City_ID)
            ViewBag.DOA3_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA3_City_ID)
            ViewBag.DOA4_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA4_City_ID)
            ViewBag.DOA5_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA5_City_ID)
            ViewBag.DOE_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOE_City_ID)
            ViewBag.Legal_Domicile_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.Legal_Domicile_City_ID)
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses, "BusinessLicense_ID", "BusinessLicense", ms_Customer_KYCs.Business_License_ID)
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers, "Customer_ID", "Company_Name", ms_Customer_KYCs.Customer_ID)
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text", ms_Customer_KYCs.Identitas)
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text", ms_Customer_KYCs.TDP_Type)
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA1_Type)
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA2_Type)
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA3_Type)
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA4_Type)
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA5_Type)
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.BOD_Type)
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text", ms_Customer_KYCs.SuratKuasaGender)

            ms_Customer_KYCs.DetailLineBussiness = db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_LineBussiness With {.LineBussiness_ID = x.LineBussiness_ID, .LineBussiness = x.LineBussiness}).ToList
            ms_Customer_KYCs.DetailDirector = db.Ms_Customer_KYC_Directors.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Director With {.KYC_Director_ID = x.KYC_Director_ID, .Director = x.Director, .Gender = x.Gender, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailCommissioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Commissioner With {.KYC_Commissioner_ID = x.KYC_Commissioner_ID, .Commissioner = x.Commissioner, .Gender = x.Gender, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailAuthorizedSigner = db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_AuthorizedSigner With {.KYC_AuthorizedSigner_ID = x.KYC_AuthorizedSigner_ID, .AuthorizedSigner = x.AuthorizedSigner, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailShareholder = db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Shareholder With {.Shareholder_ID = x.Shareholder_ID, .Shareholder_Name = x.Shareholder_Name, .AmountofShares = x.AmountofShares, .Nominal_Amount = x.Nominal_Amount}).ToList

            Return View(ms_Customer_KYCs)
        End Function

        ' POST: KYC/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(model As Ms_Customer_KYC) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Validate(model)
            If ModelState.IsValid Then

                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim kycs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = model.KYC_ID).FirstOrDefault
                        kycs.Customer_ID = model.Customer_ID
                        kycs.Legal_Domicile_City_ID = model.Legal_Domicile_City_ID
                        kycs.DOE_No = model.DOE_No
                        kycs.DOE_Date = model.DOE_Date
                        kycs.DOE_Notary = model.DOE_Notary
                        kycs.DOE_City_ID = model.DOE_City_ID
                        kycs.DOE_Approval_No = model.DOE_Approval_No
                        kycs.DOE_Approval_Date = model.DOE_Approval_Date
                        kycs.DOE_Approval_From = model.DOE_Approval_From
                        kycs.DOE_States_Gazette_No = model.DOE_States_Gazette_No
                        kycs.DOE_States_Gazette_Date = model.DOE_States_Gazette_Date
                        kycs.DOE_Supplement_No = model.DOE_Supplement_No
                        kycs.DOE_Supplement_Date = model.DOE_Supplement_Date
                        If model.DOE_IsUploaded Then
                            kycs.DOE_IsUploaded = model.DOE_IsUploaded
                        End If
                        kycs.AOA_No = model.AOA_No
                        kycs.AOA_Date = model.AOA_Date
                        kycs.AOA_Notary = model.AOA_Notary
                        kycs.AOA_City_ID = model.AOA_City_ID
                        kycs.AOA_Approval_No = model.AOA_Approval_No
                        kycs.AOA_Approval_Date = model.AOA_Approval_Date
                        kycs.AOA_States_Gazette_No = model.AOA_States_Gazette_No
                        kycs.AOA_States_Gazette_Date = model.AOA_States_Gazette_Date
                        kycs.AOA_Supplement_No = model.AOA_Supplement_No
                        kycs.AOA_Supplement_Date = model.AOA_Supplement_Date
                        If model.AOA_IsUploaded Then
                            kycs.AOA_IsUploaded = model.AOA_IsUploaded
                        End If
                        kycs.NPWP_No = model.NPWP_No
                        If model.NPWP_IsUploaded Then
                            kycs.NPWP_IsUploaded = model.NPWP_IsUploaded
                        End If
                        kycs.NPWP_SKT_No = model.NPWP_SKT_No
                        kycs.NPWP_SKT_Date = model.NPWP_SKT_Date
                        kycs.NPWP_SKT_Issued_By = model.NPWP_SKT_Issued_By
                        If model.NPWP_SKT_IsUploaded Then
                            kycs.NPWP_SKT_IsUploaded = model.NPWP_SKT_IsUploaded
                        End If
                        kycs.SPPKP_No = model.SPPKP_No
                        kycs.SPPKP_Date = model.SPPKP_Date
                        kycs.SPPKP_Issued_By = model.SPPKP_Issued_By
                        If model.SPPKP_IsUploaded Then
                            kycs.SPPKP_IsUploaded = model.SPPKP_IsUploaded
                        End If
                        kycs.Business_License_ID = model.Business_License_ID
                        kycs.Business_License_No = model.Business_License_No
                        kycs.Business_License_IssuedDate = model.Business_License_IssuedDate
                        kycs.Business_License_IssuedBy = model.Business_License_IssuedBy
                        kycs.Business_License_ExpiredDate = model.Business_License_ExpiredDate
                        kycs.Business_License_ExpiredDate_IsNA = model.Business_License_ExpiredDate_IsNA
                        If model.Business_License_IsUploaded Then
                            kycs.Business_License_IsUploaded = model.Business_License_IsUploaded
                        End If
                        kycs.TDP_Type = model.TDP_Type
                        kycs.TDP = model.TDP
                        kycs.TDP_IssuedDate = model.TDP_IssuedDate
                        kycs.TDP_IssuedBy = model.TDP_IssuedBy
                        kycs.TDP_ExpiredDate = model.TDP_ExpiredDate
                        kycs.TDP_ExpiredDate_IsNA = model.TDP_ExpiredDate_IsNA
                        If model.TDP_IsUploaded Then
                            kycs.TDP_IsUploaded = model.TDP_IsUploaded
                        End If
                        kycs.SKDP_Address = model.SKDP_Address
                        kycs.SKDP_No = model.SKDP_No
                        kycs.SKDP_IssuedDate = model.SKDP_IssuedDate
                        kycs.SKDP_IssuedBy = model.SKDP_IssuedBy
                        kycs.SKDP_ExpiredDate = model.SKDP_ExpiredDate
                        kycs.SKDP_ExpiredDate_IsNA = model.SKDP_ExpiredDate_IsNA
                        If model.SKDP_IsUploaded Then
                            kycs.SKDP_IsUploaded = model.SKDP_IsUploaded
                        End If
                        kycs.DOA1_No = model.DOA1_No
                        kycs.DOA1_Date = model.DOA1_Date
                        kycs.DOA1_Notary = model.DOA1_Notary
                        kycs.DOA1_City_ID = model.DOA1_City_ID
                        kycs.DOA1_Regarding = model.DOA1_Regarding
                        kycs.DOA1_Type = model.DOA1_Type
                        kycs.DOA1_Letter_No = model.DOA1_Letter_No
                        kycs.DOA1_Letter_Date = model.DOA1_Letter_Date
                        If model.DOA1_IsUploaded Then
                            kycs.DOA1_IsUploaded = model.DOA1_IsUploaded
                        End If
                        kycs.DOA2_No = model.DOA2_No
                        kycs.DOA2_Date = model.DOA2_Date
                        kycs.DOA2_Notary = model.DOA2_Notary
                        kycs.DOA2_City_ID = model.DOA2_City_ID
                        kycs.DOA2_Regarding = model.DOA2_Regarding
                        kycs.DOA2_Type = model.DOA2_Type
                        kycs.DOA2_Letter_No = model.DOA2_Letter_No
                        kycs.DOA2_Letter_Date = model.DOA2_Letter_Date
                        If model.DOA2_IsUploaded Then
                            kycs.DOA2_IsUploaded = model.DOA2_IsUploaded
                        End If
                        kycs.DOA3_No = model.DOA3_No
                        kycs.DOA3_Date = model.DOA3_Date
                        kycs.DOA3_Notary = model.DOA3_Notary
                        kycs.DOA3_City_ID = model.DOA3_City_ID
                        kycs.DOA3_Regarding = model.DOA3_Regarding
                        kycs.DOA3_Type = model.DOA3_Type
                        kycs.DOA3_Letter_No = model.DOA3_Letter_No
                        kycs.DOA3_Letter_Date = model.DOA3_Letter_Date
                        If model.DOA3_IsUploaded Then
                            kycs.DOA3_IsUploaded = model.DOA3_IsUploaded
                        End If
                        kycs.DOA4_No = model.DOA4_No
                        kycs.DOA4_Date = model.DOA4_Date
                        kycs.DOA4_Notary = model.DOA4_Notary
                        kycs.DOA4_City_ID = model.DOA4_City_ID
                        kycs.DOA4_Regarding = model.DOA4_Regarding
                        kycs.DOA4_Type = model.DOA4_Type
                        kycs.DOA4_Letter_No = model.DOA4_Letter_No
                        kycs.DOA4_Letter_Date = model.DOA4_Letter_Date
                        If model.DOA4_IsUploaded Then
                            kycs.DOA4_IsUploaded = model.DOA4_IsUploaded
                        End If
                        kycs.DOA5_No = model.DOA5_No
                        kycs.DOA5_Date = model.DOA5_Date
                        kycs.DOA5_Notary = model.DOA5_Notary
                        kycs.DOA5_City_ID = model.DOA5_City_ID
                        kycs.DOA5_Regarding = model.DOA5_Regarding
                        kycs.DOA5_Type = model.DOA5_Type
                        kycs.DOA5_Letter_No = model.DOA5_Letter_No
                        kycs.DOA5_Letter_Date = model.DOA5_Letter_Date
                        If model.DOA5_IsUploaded Then
                            kycs.DOA5_IsUploaded = model.DOA5_IsUploaded
                        End If
                        kycs.BOD_No = model.BOD_No
                        kycs.BOD_Date = model.BOD_Date
                        kycs.BOD_Notary = model.BOD_Notary
                        kycs.BOD_City_ID = model.BOD_City_ID
                        kycs.BOD_Type = model.BOD_Type
                        kycs.BOD_Letter_No = model.BOD_Letter_No
                        kycs.BOD_Letter_Date = model.BOD_Letter_Date
                        If model.BOD_IsUploaded Then
                            kycs.BOD_IsUploaded = model.BOD_IsUploaded
                        End If
                        kycs.BoD_Period = model.BoD_Period
                        kycs.BoD_Mention = model.BoD_Mention
                        kycs.BoD_Article = model.BoD_Article
                        kycs.BoD_Appointment = model.BoD_Appointment
                        kycs.BoD_Expired = model.BoD_Expired
                        kycs.BoC_Period = model.BoC_Period
                        kycs.BoC_Mention = model.BoC_Mention
                        kycs.BoC_Article = model.BoC_Article
                        kycs.BoC_Appointment = model.BoC_Appointment
                        kycs.BoC_Expired = model.BoC_Expired
                        kycs.Authorized_Capital_BasedOn = model.Authorized_Capital_BasedOn
                        kycs.Authorized_Capital = model.Authorized_Capital
                        kycs.Issued_Paidup_Capital = model.Issued_Paidup_Capital
                        kycs.Paragraph1 = model.Paragraph1
                        kycs.Article1 = model.Article1
                        kycs.InputParagraph11 = model.InputParagraph11
                        kycs.InputParagraph21 = model.InputParagraph21
                        kycs.InputParagraph31 = model.InputParagraph31
                        kycs.Paragraph2 = model.Paragraph2
                        kycs.Article2 = model.Article2
                        kycs.InputParagraph12 = model.InputParagraph12
                        kycs.InputParagraph22 = model.InputParagraph22
                        kycs.InputParagraph32 = model.InputParagraph32
                        kycs.SuratKuasaBy = model.SuratKuasaBy
                        kycs.SuratKuasaGender = model.SuratKuasaGender
                        kycs.SuratKuasaBasedOn = model.SuratKuasaBasedOn
                        kycs.SuratKuasaDate = model.SuratKuasaDate
                        kycs.SuratKuasaExpired = model.SuratKuasaExpired
                        kycs.SuratKuasaExpired_IsNA = model.SuratKuasaExpired_IsNA
                        If model.SuratKuasaPenerima_IsUploaded Then
                            kycs.SuratKuasaPenerima_IsUploaded = model.SuratKuasaPenerima_IsUploaded
                        End If
                        If model.SuratKuasa_IsUploaded Then
                            kycs.SuratKuasa_IsUploaded = model.SuratKuasa_IsUploaded
                        End If
                        kycs.Authorized_Person = model.Authorized_Person
                        kycs.Annual_Income = model.Annual_Income
                        kycs.Purpose_of_Services = model.Purpose_of_Services
                        kycs.Identitas = model.Identitas
                        If model.Identitas_IsUploaded Then
                            kycs.Identitas_IsUploaded = model.Identitas_IsUploaded
                        End If
                        kycs.ModifiedBy = user
                        kycs.ModifiedDate = DateTime.Now
                        db.SaveChanges()

                        If model.DetailLineBussiness IsNot Nothing Then
                            'Delete Item
                            Dim listLineBussiness = model.DetailLineBussiness.Select(Function(x) x.LineBussiness_ID).ToArray
                            For Each i In db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listLineBussiness.Contains(x.LineBussiness_ID)).ToList
                                i.ModifiedBy = user
                                i.ModifiedDate = DateTime.Now
                                i.IsDeleted = True
                            Next
                            db.SaveChanges()
                            'masukin yang baru
                            For Each i In model.DetailLineBussiness.Where(Function(x) x.LineBussiness_ID Is Nothing)
                                Dim linebussiness As New Ms_Customer_KYC_LineBussinesss With {
                                .KYC_ID = kycs.KYC_ID,
                                .LineBussiness = i.LineBussiness,
                                .CreatedBy = user,
                                .CreatedDate = DateTime.Now,
                                .IsDeleted = False
                            }
                                db.Ms_Customer_KYC_LineBussinesss.Add(linebussiness)
                            Next
                            db.SaveChanges()
                            'update yang lama
                            For Each i In model.DetailLineBussiness.Where(Function(x) x.LineBussiness_ID IsNot Nothing)
                                Dim linebussiness = db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.LineBussiness_ID = i.LineBussiness_ID).FirstOrDefault
                                linebussiness.LineBussiness = i.LineBussiness
                                linebussiness.ModifiedBy = user
                                linebussiness.ModifiedDate = DateTime.Now
                            Next
                            db.SaveChanges()
                        End If


                        If model.DetailDirector IsNot Nothing Then
                            'Delete Item
                            Dim listDirector = model.DetailDirector.Select(Function(x) x.KYC_Director_ID And x.Active).ToArray
                            For Each i In db.Ms_Customer_KYC_Directors.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listDirector.Contains(x.KYC_Director_ID)).ToList
                                i.ModifiedBy = user
                                i.ModifiedDate = DateTime.Now
                                i.IsDeleted = True
                            Next
                            db.SaveChanges()
                            'masukin yang baru
                            For Each i In model.DetailDirector.Where(Function(x) x.Active = True And x.KYC_Director_ID Is Nothing)
                                Dim director As New Ms_Customer_KYC_Directors
                                director.KYC_ID = kycs.KYC_ID
                                director.Director = i.Director
                                director.Gender = i.Gender
                                director.Position = i.Position
                                director.CreatedBy = user
                                director.CreatedDate = DateTime.Now
                                director.IsDeleted = False
                                db.Ms_Customer_KYC_Directors.Add(director)
                            Next
                            db.SaveChanges()
                            'update yang lama
                            For Each i In model.DetailDirector.Where(Function(x) x.Active = True And x.KYC_Director_ID IsNot Nothing)
                                Dim director = db.Ms_Customer_KYC_Directors.Where(Function(x) x.KYC_Director_ID = i.KYC_Director_ID).FirstOrDefault
                                director.Director = i.Director
                                director.Gender = i.Gender
                                director.Position = i.Position
                                director.ModifiedBy = user
                                director.ModifiedDate = DateTime.Now
                            Next
                            db.SaveChanges()
                        End If

                        If model.DetailCommissioner IsNot Nothing Then
                            'Delete Item
                            Dim listCommissioners = model.DetailCommissioner.Select(Function(x) x.KYC_Commissioner_ID And x.Active).ToArray
                            For Each i In db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listCommissioners.Contains(x.KYC_Commissioner_ID)).ToList
                                i.ModifiedBy = user
                                i.ModifiedDate = DateTime.Now
                                i.IsDeleted = True
                            Next
                            db.SaveChanges()

                            'masukin yang baru
                            For Each i In model.DetailCommissioner.Where(Function(x) x.Active = True And x.KYC_Commissioner_ID Is Nothing)
                                Dim Commissioners As New Ms_Customer_KYC_Commissioners
                                Commissioners.KYC_ID = kycs.KYC_ID
                                Commissioners.Commissioner = i.Commissioner
                                Commissioners.Gender = i.Gender
                                Commissioners.Position = i.Position
                                Commissioners.CreatedBy = user
                                Commissioners.CreatedDate = DateTime.Now
                                Commissioners.IsDeleted = False
                                db.Ms_Customer_KYC_Commissioners.Add(Commissioners)
                            Next
                            db.SaveChanges()
                            'update yang lama
                            For Each i In model.DetailCommissioner.Where(Function(x) x.Active = True And x.KYC_Commissioner_ID IsNot Nothing)
                                Dim Commissioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.KYC_Commissioner_ID = i.KYC_Commissioner_ID).FirstOrDefault
                                Commissioner.Commissioner = i.Commissioner
                                Commissioner.Gender = i.Gender
                                Commissioner.Position = i.Position
                                Commissioner.ModifiedBy = user
                                Commissioner.ModifiedDate = DateTime.Now
                            Next
                            db.SaveChanges()
                        End If

                        If model.DetailAuthorizedSigner IsNot Nothing Then
                            'Delete Item
                            Dim listAuthorizedSigner = model.DetailAuthorizedSigner.Select(Function(x) x.KYC_AuthorizedSigner_ID And x.Active).ToArray
                            For Each i In db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listAuthorizedSigner.Contains(x.KYC_AuthorizedSigner_ID)).ToList
                                i.ModifiedBy = user
                                i.ModifiedDate = DateTime.Now
                                i.IsDeleted = True
                            Next
                            db.SaveChanges()

                            'masukin yang baru
                            For Each i In model.DetailAuthorizedSigner.Where(Function(x) x.Active = True And x.KYC_AuthorizedSigner_ID Is Nothing)
                                Dim AuthorizedSigner As New Ms_Customer_KYC_AuthorizedSigners
                                AuthorizedSigner.KYC_ID = kycs.KYC_ID
                                AuthorizedSigner.AuthorizedSigner = i.AuthorizedSigner
                                AuthorizedSigner.Position = i.Position
                                AuthorizedSigner.CreatedBy = user
                                AuthorizedSigner.CreatedDate = DateTime.Now
                                AuthorizedSigner.IsDeleted = False
                                db.Ms_Customer_KYC_AuthorizedSigners.Add(AuthorizedSigner)
                            Next
                            db.SaveChanges()

                            'update yang lama
                            For Each i In model.DetailAuthorizedSigner.Where(Function(x) x.Active = True And x.KYC_AuthorizedSigner_ID IsNot Nothing)
                                Dim AuthorizedSigner = db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.KYC_AuthorizedSigner_ID = i.KYC_AuthorizedSigner_ID).FirstOrDefault
                                AuthorizedSigner.AuthorizedSigner = i.AuthorizedSigner
                                AuthorizedSigner.Position = i.Position
                                AuthorizedSigner.ModifiedBy = user
                                AuthorizedSigner.ModifiedDate = DateTime.Now
                            Next
                            db.SaveChanges()
                        End If

                        If model.DetailShareholder IsNot Nothing Then
                            'Delete Item
                            Dim listShareholder = model.DetailShareholder.Select(Function(x) x.Shareholder_ID And x.Active).ToArray
                            For Each i In db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listShareholder.Contains(x.Shareholder_ID)).ToList
                                i.ModifiedBy = user
                                i.ModifiedDate = DateTime.Now
                                i.IsDeleted = True
                            Next
                            db.SaveChanges()

                            'masukin yang baru
                            For Each i In model.DetailShareholder.Where(Function(x) x.Active = True And x.Shareholder_ID Is Nothing)
                                Dim Shareholder As New Ms_Customer_KYC_Shareholders
                                Shareholder.KYC_ID = kycs.KYC_ID
                                Shareholder.Shareholder_Name = i.Shareholder_Name
                                Shareholder.AmountofShares = i.AmountofShares
                                Shareholder.Nominal_Amount = i.Nominal_Amount
                                Shareholder.CreatedBy = user
                                Shareholder.CreatedDate = DateTime.Now
                                Shareholder.IsDeleted = False
                                db.Ms_Customer_KYC_Shareholders.Add(Shareholder)
                            Next
                            db.SaveChanges()

                            'update yang lama
                            For Each i In model.DetailShareholder.Where(Function(x) x.Active = True And x.Shareholder_ID IsNot Nothing)
                                Dim Shareholder = db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.Shareholder_ID = i.Shareholder_ID).FirstOrDefault
                                Shareholder.Shareholder_Name = i.Shareholder_Name
                                Shareholder.AmountofShares = i.AmountofShares
                                Shareholder.Nominal_Amount = i.Nominal_Amount
                                Shareholder.ModifiedBy = user
                                Shareholder.ModifiedDate = DateTime.Now
                            Next
                            db.SaveChanges()
                        End If



                        'save file
                        If model.DOE_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOE"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOE_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOE_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.AOA_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/AOA"), kycs.KYC_ID.ToString() + ".pdf")
                            model.AOA_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.AOA_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.BOD_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BOD"), kycs.KYC_ID.ToString() + ".pdf")
                            model.BOD_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.BOD_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA1_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA1"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA1_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA1_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA2_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA2"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA2_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA2_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA3_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA3"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA3_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA3_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA4_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA4"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA4_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA4_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA5_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA5"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA5_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA5_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Business_License_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BL"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Business_License_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Business_License_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.TDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/TDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.TDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.TDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SKDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SKDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SKDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SKDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_SKT_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP_SKT"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_SKT_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_SKT_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SPPKP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SPPKP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SPPKP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SPPKP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Identitas_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/Identitas"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Identitas_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Identitas_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasaPenerima_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasaPenerima"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasaPenerima_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasaPenerima_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasa_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasa"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasa_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasa_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("ValidateAuthorizedSigner", ex.Message)
                        GoTo Lanjut
                    End Try
                End Using
                Return RedirectToAction("Index")
            End If
Lanjut:
            Dim city = db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City)
            ViewBag.AOA_City_ID = New SelectList(city, "CIty_ID", "City", model.AOA_City_ID)
            ViewBag.BOD_City_ID = New SelectList(city, "CIty_ID", "City", model.BOD_City_ID)
            ViewBag.DOA1_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA1_City_ID)
            ViewBag.DOA2_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA2_City_ID)
            ViewBag.DOA3_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA3_City_ID)
            ViewBag.DOA4_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA4_City_ID)
            ViewBag.DOA5_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA5_City_ID)
            ViewBag.DOE_City_ID = New SelectList(city, "CIty_ID", "City", model.DOE_City_ID)
            ViewBag.Legal_Domicile_City_ID = New SelectList(city, "CIty_ID", "City", model.Legal_Domicile_City_ID)
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.BusinessLicense), "BusinessLicense_ID", "BusinessLicense", model.Business_License_ID)
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False And x.IsKYC = False).OrderBy(Function(x) x.Company_Name), "Customer_ID", "Company_Name", model.Customer_ID)
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text", model.Identitas)
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text", model.TDP_Type)
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA1_Type)
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA2_Type)
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA3_Type)
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA4_Type)
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA5_Type)
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text", model.BOD_Type)
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text", model.SuratKuasaGender)
            Return View(model)
        End Function


        ' GET: KYC/Review/5
        Function Review(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_KYCs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Customer_ID = x.Customer_ID,
.Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City, .DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary,
.DOE_City_ID = x.DOE_City_ID, .DOE_City = x.Ms_Citys7.City, .DOE_Approval_No = x.DOE_Approval_No, .DOE_Approval_Date = x.DOE_Approval_Date,
.DOE_Approval_From = x.DOE_Approval_From, .DOE_States_Gazette_No = x.DOE_States_Gazette_No, .DOE_States_Gazette_Date = x.DOE_States_Gazette_Date,
.DOE_Supplement_No = x.DOE_Supplement_No, .DOE_Supplement_Date = x.DOE_Supplement_Date, .DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date,
.AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID, .AOA_City = x.Ms_Citys.City, .AOA_Approval_No = x.AOA_Approval_No, .AOA_Approval_Date = x.AOA_Approval_Date,
.AOA_States_Gazette_No = x.AOA_States_Gazette_No, .AOA_States_Gazette_Date = x.AOA_States_Gazette_Date, .AOA_Supplement_No = x.AOA_Supplement_No,
.AOA_Supplement_Date = x.AOA_Supplement_Date, .AOA_IsUploaded = x.AOA_IsUploaded, .NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded,
.NPWP_SKT_No = x.NPWP_SKT_No, .NPWP_SKT_Date = x.NPWP_SKT_Date, .NPWP_SKT_Issued_By = x.NPWP_SKT_Issued_By, .NPWP_SKT_IsUploaded = x.NPWP_SKT_IsUploaded,
.SPPKP_No = x.SPPKP_No, .SPPKP_Date = x.SPPKP_Date, .SPPKP_Issued_By = x.SPPKP_Issued_By, .SPPKP_IsUploaded = x.SPPKP_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License = x.Ms_Customer_BusinessLicenses.BusinessLicense, .Business_License_No = x.Business_License_No, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_ExpiredDate = x.Business_License_ExpiredDate,
.Business_License_ExpiredDate_IsNA = x.Business_License_ExpiredDate_IsNA, .Business_License_IsUploaded = x.Business_License_IsUploaded, .TDP_Type = x.TDP_Type,
.TDP = x.TDP, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_IssuedBy = x.TDP_IssuedBy, .TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_ExpiredDate_IsNA = x.TDP_ExpiredDate_IsNA,
.TDP_IsUploaded = x.TDP_IsUploaded, .SKDP_Address = x.SKDP_Address, .SKDP_No = x.SKDP_No, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IssuedBy = x.SKDP_IssuedBy,
.SKDP_ExpiredDate = x.SKDP_ExpiredDate, .SKDP_ExpiredDate_IsNA = x.SKDP_ExpiredDate_IsNA, .SKDP_IsUploaded = x.SKDP_IsUploaded, .DOA1_No = x.DOA1_No,
.DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID, .DOA1_City = x.Ms_Citys2.City, .DOA1_Regarding = x.DOA1_Regarding, .DOA1_Type = x.DOA1_Type,
.DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded, .DOA2_No = x.DOA2_No, .DOA2_Date = x.DOA2_Date,
.DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_City = x.Ms_Citys3.City, .DOA2_Regarding = x.DOA2_Regarding, .DOA2_Type = x.DOA2_Type, .DOA2_Letter_No = x.DOA2_Letter_No,
.DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date, .DOA3_Notary = x.DOA3_Notary,
.DOA3_City_ID = x.DOA3_City_ID, .DOA3_City = x.Ms_Citys4.City, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Type = x.DOA3_Type, .DOA3_Letter_No = x.DOA3_Letter_No, .DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID, .DOA4_City = x.Ms_Citys5.City,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Type = x.DOA4_Type, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date,
.DOA4_IsUploaded = x.DOA4_IsUploaded, .DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_City = x.Ms_Citys6.City,
.DOA5_Regarding = x.DOA5_Regarding, .DOA5_Type = x.DOA5_Type, .DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date,
.DOA5_IsUploaded = x.DOA5_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date, .BOD_Notary = x.BOD_Notary, .BOD_City_ID = x.BOD_City_ID, .BOD_City = x.Ms_Citys1.City, .BOD_Type = x.BOD_Type,
.BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date, .BOD_IsUploaded = x.BOD_IsUploaded, .BoD_Period = x.BoD_Period, .BoD_Mention = x.BoD_Mention,
.BoD_Article = x.BoD_Article, .BoD_Appointment = x.BoD_Appointment, .BoD_Expired = x.BoD_Expired, .BoC_Period = x.BoC_Period, .BoC_Mention = x.BoC_Mention, .BoC_Article = x.BoC_Article, .BoC_Appointment = x.BoC_Appointment,
.BoC_Expired = x.BoC_Expired, .Authorized_Capital_BasedOn = x.Authorized_Capital_BasedOn, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.Paragraph1 = x.Paragraph1, .Article1 = x.Article1, .InputParagraph11 = x.InputParagraph11, .InputParagraph21 = x.InputParagraph21, .InputParagraph31 = x.InputParagraph31,
.SuratKuasaGender = x.SuratKuasaGender, .Paragraph2 = x.Paragraph2, .Article2 = x.Article2, .InputParagraph12 = x.InputParagraph12, .InputParagraph22 = x.InputParagraph22,
.InputParagraph32 = x.InputParagraph32, .SuratKuasaBy = x.SuratKuasaBy, .SuratKuasaBasedOn = x.SuratKuasaBasedOn, .SuratKuasaDate = x.SuratKuasaDate, .SuratKuasaExpired = x.SuratKuasaExpired,
.SuratKuasaExpired_IsNA = x.SuratKuasaExpired_IsNA, .SuratKuasaPenerima_IsUploaded = x.SuratKuasaPenerima_IsUploaded, .SuratKuasa_IsUploaded = x.SuratKuasa_IsUploaded,
.Authorized_Person = x.Authorized_Person, .Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas, .Identitas_IsUploaded = x.Identitas_IsUploaded,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_Customer_KYCs) Then
                Return HttpNotFound()
            End If
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City)
            ViewBag.AOA_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.AOA_City_ID)
            ViewBag.BOD_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.BOD_City_ID)
            ViewBag.DOA1_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA1_City_ID)
            ViewBag.DOA2_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA2_City_ID)
            ViewBag.DOA3_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA3_City_ID)
            ViewBag.DOA4_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA4_City_ID)
            ViewBag.DOA5_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOA5_City_ID)
            ViewBag.DOE_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.DOE_City_ID)
            ViewBag.Legal_Domicile_City_ID = New SelectList(city, "CIty_ID", "City", ms_Customer_KYCs.Legal_Domicile_City_ID)
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses, "BusinessLicense_ID", "BusinessLicense", ms_Customer_KYCs.Business_License_ID)
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers, "Customer_ID", "Company_Name", ms_Customer_KYCs.Customer_ID)
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text", ms_Customer_KYCs.Identitas)
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text", ms_Customer_KYCs.TDP_Type)
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA1_Type)
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA2_Type)
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA3_Type)
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA4_Type)
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.DOA5_Type)
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text", ms_Customer_KYCs.BOD_Type)
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text", ms_Customer_KYCs.SuratKuasaGender)

            ms_Customer_KYCs.DetailLineBussiness = db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_LineBussiness With {.LineBussiness_ID = x.LineBussiness_ID, .LineBussiness = x.LineBussiness}).ToList
            ms_Customer_KYCs.DetailDirector = db.Ms_Customer_KYC_Directors.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Director With {.KYC_Director_ID = x.KYC_Director_ID, .Director = x.Director, .Gender = x.Gender, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailCommissioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Commissioner With {.KYC_Commissioner_ID = x.KYC_Commissioner_ID, .Commissioner = x.Commissioner, .Gender = x.Gender, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailAuthorizedSigner = db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_AuthorizedSigner With {.KYC_AuthorizedSigner_ID = x.KYC_AuthorizedSigner_ID, .AuthorizedSigner = x.AuthorizedSigner, .Position = x.Position}).ToList
            ms_Customer_KYCs.DetailShareholder = db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.IsDeleted = False And x.KYC_ID = ms_Customer_KYCs.KYC_ID).
                Select(Function(x) New Ms_Customer_KYC_Shareholder With {.Shareholder_ID = x.Shareholder_ID, .Shareholder_Name = x.Shareholder_Name, .AmountofShares = x.AmountofShares, .Nominal_Amount = x.Nominal_Amount}).ToList

            Return View(ms_Customer_KYCs)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Review(model As Ms_Customer_KYC) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If model.DetailDirector IsNot Nothing Then
                Dim validDirector = model.DetailDirector.Where(Function(x) x.Validate = False).FirstOrDefault
                If validDirector IsNot Nothing Then
                    ModelState.AddModelError("ValidateDirector", validDirector.ValidateMessage)
                End If
            Else
                ModelState.AddModelError("ValidateDirector", "Must Fill Director")
            End If

            If model.DetailCommissioner IsNot Nothing Then
                Dim validCommissioner = model.DetailCommissioner.Where(Function(x) x.Validate = False).FirstOrDefault
                If validCommissioner IsNot Nothing Then
                    ModelState.AddModelError("ValidateCommissioner", validCommissioner.ValidateMessage)
                End If
            Else
                ModelState.AddModelError("ValidateCommissioner", "Must Fill Director")
            End If
            If model.DetailShareholder IsNot Nothing Then
                Dim validShareholder = model.DetailShareholder.Where(Function(x) x.Validate = False).FirstOrDefault
                If validShareholder IsNot Nothing Then
                    ModelState.AddModelError("ValidateShareholder", validShareholder.ValidateMessage)
                End If
            Else
                'ModelState.AddModelError("ValidateShareholder", "Must Fill Shareholder")
            End If

            If (model.DetailDirector IsNot Nothing) Then
                If Not (model.DetailDirector.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateDirector", "Fill the Director")
                End If
            End If

            If (model.DetailCommissioner IsNot Nothing) Then
                If Not (model.DetailCommissioner.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateCommissioner", "Fill the Commissioner")
                End If
            End If
            If (model.DetailAuthorizedSigner IsNot Nothing) Then
                If Not (model.DetailAuthorizedSigner.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateAuthorizedSigner", "Fill the AuthorizedSigner")
                End If
            Else
                ModelState.AddModelError("ValidateAuthorizedSigner", "Fill the AuthorizedSigner")
            End If
            If (model.DetailShareholder IsNot Nothing) Then
                If Not (model.DetailShareholder.Any(Function(x) x.Active = True)) Then
                    ModelState.AddModelError("ValidateShareholder", "Fill the Shareholder")
                End If
            End If
            If (model.DetailLineBussiness Is Nothing) Then
                ModelState.AddModelError("ValidateLineBussiness", "Fill the LineBussiness")
            End If

            'Isi status biar gampang nanti di edit
            If model.DOE_IsUploadedFile Is Nothing Then
                model.DOE_IsUploaded = False
            Else
                model.DOE_IsUploaded = True
            End If
            If model.AOA_IsUploadedFile Is Nothing Then
                model.AOA_IsUploaded = False
            Else
                model.AOA_IsUploaded = True
            End If
            If model.BOD_IsUploadedFile Is Nothing Then
                model.BOD_IsUploaded = False
            Else
                model.BOD_IsUploaded = True
            End If
            If model.DOA1_IsUploadedFile Is Nothing Then
                model.DOA1_IsUploaded = False
            Else
                model.DOA1_IsUploaded = True
            End If
            If model.DOA2_IsUploadedFile Is Nothing Then
                model.DOA2_IsUploaded = False
            Else
                model.DOA2_IsUploaded = True
            End If
            If model.DOA3_IsUploadedFile Is Nothing Then
                model.DOA3_IsUploaded = False
            Else
                model.DOA3_IsUploaded = True
            End If
            If model.DOA4_IsUploadedFile Is Nothing Then
                model.DOA4_IsUploaded = False
            Else
                model.DOA4_IsUploaded = True
            End If
            If model.DOA5_IsUploadedFile Is Nothing Then
                model.DOA5_IsUploaded = False
            Else
                model.DOA5_IsUploaded = True
            End If
            If model.Business_License_IsUploadedFile Is Nothing Then
                model.Business_License_IsUploaded = False
            Else
                model.Business_License_IsUploaded = True
            End If
            If model.TDP_IsUploadedFile Is Nothing Then
                model.TDP_IsUploaded = False
            Else
                model.TDP_IsUploaded = True
            End If
            If model.SKDP_IsUploadedFile Is Nothing Then
                model.SKDP_IsUploaded = False
            Else
                model.SKDP_IsUploaded = True
            End If
            If model.NPWP_IsUploadedFile Is Nothing Then
                model.NPWP_IsUploaded = False
            Else
                model.NPWP_IsUploaded = True
            End If
            If model.NPWP_SKT_IsUploadedFile Is Nothing Then
                model.NPWP_SKT_IsUploaded = False
            Else
                model.NPWP_SKT_IsUploaded = True
            End If
            If model.SPPKP_IsUploadedFile Is Nothing Then
                model.SPPKP_IsUploaded = False
            Else
                model.SPPKP_IsUploaded = True
            End If
            If model.Identitas_IsUploadedFile Is Nothing Then
                model.Identitas_IsUploaded = False
            Else
                model.Identitas_IsUploaded = True
            End If
            If model.SuratKuasaPenerima_IsUploadedFile Is Nothing Then
                model.SuratKuasaPenerima_IsUploaded = False
            Else
                model.SuratKuasaPenerima_IsUploaded = True
            End If
            If model.SuratKuasa_IsUploadedFile Is Nothing Then
                model.SuratKuasa_IsUploaded = False
            Else
                model.SuratKuasa_IsUploaded = True
            End If


            If ModelState.IsValid Then

                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim kycs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = model.KYC_ID).FirstOrDefault
                        kycs.Customer_ID = model.Customer_ID
                        kycs.Legal_Domicile_City_ID = model.Legal_Domicile_City_ID
                        kycs.DOE_No = model.DOE_No
                        kycs.DOE_Date = model.DOE_Date
                        kycs.DOE_Notary = model.DOE_Notary
                        kycs.DOE_City_ID = model.DOE_City_ID
                        kycs.DOE_Approval_No = model.DOE_Approval_No
                        kycs.DOE_Approval_Date = model.DOE_Approval_Date
                        kycs.DOE_Approval_From = model.DOE_Approval_From
                        kycs.DOE_States_Gazette_No = model.DOE_States_Gazette_No
                        kycs.DOE_States_Gazette_Date = model.DOE_States_Gazette_Date
                        kycs.DOE_Supplement_No = model.DOE_Supplement_No
                        kycs.DOE_Supplement_Date = model.DOE_Supplement_Date
                        If model.DOE_IsUploaded Then
                            kycs.DOE_IsUploaded = model.DOE_IsUploaded
                        End If
                        kycs.AOA_No = model.AOA_No
                        kycs.AOA_Date = model.AOA_Date
                        kycs.AOA_Notary = model.AOA_Notary
                        kycs.AOA_City_ID = model.AOA_City_ID
                        kycs.AOA_Approval_No = model.AOA_Approval_No
                        kycs.AOA_Approval_Date = model.AOA_Approval_Date
                        kycs.AOA_States_Gazette_No = model.AOA_States_Gazette_No
                        kycs.AOA_States_Gazette_Date = model.AOA_States_Gazette_Date
                        kycs.AOA_Supplement_No = model.AOA_Supplement_No
                        kycs.AOA_Supplement_Date = model.AOA_Supplement_Date
                        If model.AOA_IsUploaded Then
                            kycs.AOA_IsUploaded = model.AOA_IsUploaded
                        End If
                        kycs.NPWP_No = model.NPWP_No
                        If model.NPWP_IsUploaded Then
                            kycs.NPWP_IsUploaded = model.NPWP_IsUploaded
                        End If
                        kycs.NPWP_SKT_No = model.NPWP_SKT_No
                        kycs.NPWP_SKT_Date = model.NPWP_SKT_Date
                        kycs.NPWP_SKT_Issued_By = model.NPWP_SKT_Issued_By
                        If model.NPWP_SKT_IsUploaded Then
                            kycs.NPWP_SKT_IsUploaded = model.NPWP_SKT_IsUploaded
                        End If
                        kycs.SPPKP_No = model.SPPKP_No
                        kycs.SPPKP_Date = model.SPPKP_Date
                        kycs.SPPKP_Issued_By = model.SPPKP_Issued_By
                        If model.SPPKP_IsUploaded Then
                            kycs.SPPKP_IsUploaded = model.SPPKP_IsUploaded
                        End If
                        kycs.Business_License_ID = model.Business_License_ID
                        kycs.Business_License_No = model.Business_License_No
                        kycs.Business_License_IssuedDate = model.Business_License_IssuedDate
                        kycs.Business_License_IssuedBy = model.Business_License_IssuedBy
                        kycs.Business_License_ExpiredDate = model.Business_License_ExpiredDate
                        kycs.Business_License_ExpiredDate_IsNA = model.Business_License_ExpiredDate_IsNA
                        If model.Business_License_IsUploaded Then
                            kycs.Business_License_IsUploaded = model.Business_License_IsUploaded
                        End If
                        kycs.TDP_Type = model.TDP_Type
                        kycs.TDP = model.TDP
                        kycs.TDP_IssuedDate = model.TDP_IssuedDate
                        kycs.TDP_IssuedBy = model.TDP_IssuedBy
                        kycs.TDP_ExpiredDate = model.TDP_ExpiredDate
                        kycs.TDP_ExpiredDate_IsNA = model.TDP_ExpiredDate_IsNA
                        If model.TDP_IsUploaded Then
                            kycs.TDP_IsUploaded = model.TDP_IsUploaded
                        End If
                        kycs.SKDP_Address = model.SKDP_Address
                        kycs.SKDP_No = model.SKDP_No
                        kycs.SKDP_IssuedDate = model.SKDP_IssuedDate
                        kycs.SKDP_IssuedBy = model.SKDP_IssuedBy
                        kycs.SKDP_ExpiredDate = model.SKDP_ExpiredDate
                        kycs.SKDP_ExpiredDate_IsNA = model.SKDP_ExpiredDate_IsNA
                        If model.SKDP_IsUploaded Then
                            kycs.SKDP_IsUploaded = model.SKDP_IsUploaded
                        End If
                        kycs.DOA1_No = model.DOA1_No
                        kycs.DOA1_Date = model.DOA1_Date
                        kycs.DOA1_Notary = model.DOA1_Notary
                        kycs.DOA1_City_ID = model.DOA1_City_ID
                        kycs.DOA1_Regarding = model.DOA1_Regarding
                        kycs.DOA1_Type = model.DOA1_Type
                        kycs.DOA1_Letter_No = model.DOA1_Letter_No
                        kycs.DOA1_Letter_Date = model.DOA1_Letter_Date
                        If model.DOA1_IsUploaded Then
                            kycs.DOA1_IsUploaded = model.DOA1_IsUploaded
                        End If
                        kycs.DOA2_No = model.DOA2_No
                        kycs.DOA2_Date = model.DOA2_Date
                        kycs.DOA2_Notary = model.DOA2_Notary
                        kycs.DOA2_City_ID = model.DOA2_City_ID
                        kycs.DOA2_Regarding = model.DOA2_Regarding
                        kycs.DOA2_Type = model.DOA2_Type
                        kycs.DOA2_Letter_No = model.DOA2_Letter_No
                        kycs.DOA2_Letter_Date = model.DOA2_Letter_Date
                        If model.DOA2_IsUploaded Then
                            kycs.DOA2_IsUploaded = model.DOA2_IsUploaded
                        End If
                        kycs.DOA3_No = model.DOA3_No
                        kycs.DOA3_Date = model.DOA3_Date
                        kycs.DOA3_Notary = model.DOA3_Notary
                        kycs.DOA3_City_ID = model.DOA3_City_ID
                        kycs.DOA3_Regarding = model.DOA3_Regarding
                        kycs.DOA3_Type = model.DOA3_Type
                        kycs.DOA3_Letter_No = model.DOA3_Letter_No
                        kycs.DOA3_Letter_Date = model.DOA3_Letter_Date
                        If model.DOA3_IsUploaded Then
                            kycs.DOA3_IsUploaded = model.DOA3_IsUploaded
                        End If
                        kycs.DOA4_No = model.DOA4_No
                        kycs.DOA4_Date = model.DOA4_Date
                        kycs.DOA4_Notary = model.DOA4_Notary
                        kycs.DOA4_City_ID = model.DOA4_City_ID
                        kycs.DOA4_Regarding = model.DOA4_Regarding
                        kycs.DOA4_Type = model.DOA4_Type
                        kycs.DOA4_Letter_No = model.DOA4_Letter_No
                        kycs.DOA4_Letter_Date = model.DOA4_Letter_Date
                        If model.DOA4_IsUploaded Then
                            kycs.DOA4_IsUploaded = model.DOA4_IsUploaded
                        End If
                        kycs.DOA5_No = model.DOA5_No
                        kycs.DOA5_Date = model.DOA5_Date
                        kycs.DOA5_Notary = model.DOA5_Notary
                        kycs.DOA5_City_ID = model.DOA5_City_ID
                        kycs.DOA5_Regarding = model.DOA5_Regarding
                        kycs.DOA5_Type = model.DOA5_Type
                        kycs.DOA5_Letter_No = model.DOA5_Letter_No
                        kycs.DOA5_Letter_Date = model.DOA5_Letter_Date
                        If model.DOA5_IsUploaded Then
                            kycs.DOA5_IsUploaded = model.DOA5_IsUploaded
                        End If
                        kycs.BOD_No = model.BOD_No
                        kycs.BOD_Date = model.BOD_Date
                        kycs.BOD_Notary = model.BOD_Notary
                        kycs.BOD_City_ID = model.BOD_City_ID
                        kycs.BOD_Type = model.BOD_Type
                        kycs.BOD_Letter_No = model.BOD_Letter_No
                        kycs.BOD_Letter_Date = model.BOD_Letter_Date
                        If model.BOD_IsUploaded Then
                            kycs.BOD_IsUploaded = model.BOD_IsUploaded
                        End If
                        kycs.BoD_Period = model.BoD_Period
                        kycs.BoD_Mention = model.BoD_Mention
                        kycs.BoD_Article = model.BoD_Article
                        kycs.BoD_Appointment = model.BoD_Appointment
                        kycs.BoD_Expired = model.BoD_Expired
                        kycs.BoC_Period = model.BoC_Period
                        kycs.BoC_Mention = model.BoC_Mention
                        kycs.BoC_Article = model.BoC_Article
                        kycs.BoC_Appointment = model.BoC_Appointment
                        kycs.BoC_Expired = model.BoC_Expired
                        kycs.Authorized_Capital_BasedOn = model.Authorized_Capital_BasedOn
                        kycs.Authorized_Capital = model.Authorized_Capital
                        kycs.Issued_Paidup_Capital = model.Issued_Paidup_Capital
                        kycs.Paragraph1 = model.Paragraph1
                        kycs.Article1 = model.Article1
                        kycs.InputParagraph11 = model.InputParagraph11
                        kycs.InputParagraph21 = model.InputParagraph21
                        kycs.InputParagraph31 = model.InputParagraph31
                        kycs.Paragraph2 = model.Paragraph2
                        kycs.Article2 = model.Article2
                        kycs.InputParagraph12 = model.InputParagraph12
                        kycs.InputParagraph22 = model.InputParagraph22
                        kycs.InputParagraph32 = model.InputParagraph32
                        kycs.SuratKuasaBy = model.SuratKuasaBy
                        kycs.SuratKuasaGender = model.SuratKuasaGender
                        kycs.SuratKuasaBasedOn = model.SuratKuasaBasedOn
                        kycs.SuratKuasaDate = model.SuratKuasaDate
                        kycs.SuratKuasaExpired = model.SuratKuasaExpired
                        kycs.SuratKuasaExpired_IsNA = model.SuratKuasaExpired_IsNA
                        If model.SuratKuasaPenerima_IsUploaded Then
                            kycs.SuratKuasaPenerima_IsUploaded = model.SuratKuasaPenerima_IsUploaded
                        End If
                        If model.SuratKuasa_IsUploaded Then
                            kycs.SuratKuasa_IsUploaded = model.SuratKuasa_IsUploaded
                        End If
                        kycs.Authorized_Person = model.Authorized_Person
                        kycs.Annual_Income = model.Annual_Income
                        kycs.Purpose_of_Services = model.Purpose_of_Services
                        kycs.Identitas = model.Identitas
                        If model.Identitas_IsUploaded Then
                            kycs.Identitas_IsUploaded = model.Identitas_IsUploaded
                        End If
                        kycs.ModifiedBy = user
                        kycs.ModifiedDate = DateTime.Now
                        kycs.ReviewedBy = user
                        kycs.ReviewedDate = DateTime.Now
                        kycs.IsReviewed = True
                        db.SaveChanges()

                        'Delete Item
                        Dim listLineBussiness = model.DetailLineBussiness.Select(Function(x) x.LineBussiness_ID).ToArray
                        For Each i In db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listLineBussiness.Contains(x.LineBussiness_ID)).ToList
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                            i.IsDeleted = True
                        Next
                        db.SaveChanges()
                        'masukin yang baru
                        For Each i In model.DetailLineBussiness.Where(Function(x) x.LineBussiness_ID Is Nothing)
                            Dim linebussiness As New Ms_Customer_KYC_LineBussinesss
                            linebussiness.KYC_ID = kycs.KYC_ID
                            linebussiness.LineBussiness = i.LineBussiness
                            linebussiness.CreatedBy = user
                            linebussiness.CreatedDate = DateTime.Now
                            linebussiness.IsDeleted = False
                            db.Ms_Customer_KYC_LineBussinesss.Add(linebussiness)
                        Next
                        db.SaveChanges()
                        'update yang lama
                        For Each i In model.DetailLineBussiness.Where(Function(x) x.LineBussiness_ID IsNot Nothing)
                            Dim linebussiness = db.Ms_Customer_KYC_LineBussinesss.Where(Function(x) x.LineBussiness_ID = i.LineBussiness_ID).FirstOrDefault
                            linebussiness.LineBussiness = i.LineBussiness
                            linebussiness.ModifiedBy = user
                            linebussiness.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        'Delete Item
                        Dim listDirector = model.DetailDirector.Select(Function(x) x.KYC_Director_ID And x.Active).ToArray
                        For Each i In db.Ms_Customer_KYC_Directors.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listDirector.Contains(x.KYC_Director_ID)).ToList
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                            i.IsDeleted = True
                        Next
                        db.SaveChanges()
                        'masukin yang baru
                        For Each i In model.DetailDirector.Where(Function(x) x.Active = True And x.KYC_Director_ID Is Nothing)
                            Dim director As New Ms_Customer_KYC_Directors
                            director.KYC_ID = kycs.KYC_ID
                            director.Director = i.Director
                            director.Gender = i.Gender
                            director.Position = i.Position
                            director.CreatedBy = user
                            director.CreatedDate = DateTime.Now
                            director.IsDeleted = False
                            db.Ms_Customer_KYC_Directors.Add(director)
                        Next
                        db.SaveChanges()
                        'update yang lama
                        For Each i In model.DetailDirector.Where(Function(x) x.Active = True And x.KYC_Director_ID IsNot Nothing)
                            Dim director = db.Ms_Customer_KYC_Directors.Where(Function(x) x.KYC_Director_ID = i.KYC_Director_ID).FirstOrDefault
                            director.Director = i.Director
                            director.Gender = i.Gender
                            director.Position = i.Position
                            director.ModifiedBy = user
                            director.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        'Delete Item
                        Dim listCommissioners = model.DetailCommissioner.Select(Function(x) x.KYC_Commissioner_ID And x.Active).ToArray
                        For Each i In db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listCommissioners.Contains(x.KYC_Commissioner_ID)).ToList
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                            i.IsDeleted = True
                        Next
                        db.SaveChanges()

                        'masukin yang baru
                        For Each i In model.DetailCommissioner.Where(Function(x) x.Active = True And x.KYC_Commissioner_ID Is Nothing)
                            Dim Commissioners As New Ms_Customer_KYC_Commissioners
                            Commissioners.KYC_ID = kycs.KYC_ID
                            Commissioners.Commissioner = i.Commissioner
                            Commissioners.Gender = i.Gender
                            Commissioners.Position = i.Position
                            Commissioners.CreatedBy = user
                            Commissioners.CreatedDate = DateTime.Now
                            Commissioners.IsDeleted = False
                            db.Ms_Customer_KYC_Commissioners.Add(Commissioners)
                        Next
                        db.SaveChanges()
                        'update yang lama
                        For Each i In model.DetailCommissioner.Where(Function(x) x.Active = True And x.KYC_Commissioner_ID IsNot Nothing)
                            Dim Commissioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.KYC_Commissioner_ID = i.KYC_Commissioner_ID).FirstOrDefault
                            Commissioner.Commissioner = i.Commissioner
                            Commissioner.Gender = i.Gender
                            Commissioner.Position = i.Position
                            Commissioner.ModifiedBy = user
                            Commissioner.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        'Delete Item
                        Dim listAuthorizedSigner = model.DetailAuthorizedSigner.Select(Function(x) x.KYC_AuthorizedSigner_ID And x.Active).ToArray
                        For Each i In db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listAuthorizedSigner.Contains(x.KYC_AuthorizedSigner_ID)).ToList
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                            i.IsDeleted = True
                        Next
                        db.SaveChanges()

                        'masukin yang baru
                        For Each i In model.DetailAuthorizedSigner.Where(Function(x) x.Active = True And x.KYC_AuthorizedSigner_ID Is Nothing)
                            Dim AuthorizedSigner As New Ms_Customer_KYC_AuthorizedSigners
                            AuthorizedSigner.KYC_ID = kycs.KYC_ID
                            AuthorizedSigner.AuthorizedSigner = i.AuthorizedSigner
                            AuthorizedSigner.Position = i.Position
                            AuthorizedSigner.CreatedBy = user
                            AuthorizedSigner.CreatedDate = DateTime.Now
                            AuthorizedSigner.IsDeleted = False
                            db.Ms_Customer_KYC_AuthorizedSigners.Add(AuthorizedSigner)
                        Next
                        db.SaveChanges()

                        'update yang lama
                        For Each i In model.DetailAuthorizedSigner.Where(Function(x) x.Active = True And x.KYC_AuthorizedSigner_ID IsNot Nothing)
                            Dim AuthorizedSigner = db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.KYC_AuthorizedSigner_ID = i.KYC_AuthorizedSigner_ID).FirstOrDefault
                            AuthorizedSigner.AuthorizedSigner = i.AuthorizedSigner
                            AuthorizedSigner.Position = i.Position
                            AuthorizedSigner.ModifiedBy = user
                            AuthorizedSigner.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        'Delete Item
                        Dim listShareholder = model.DetailShareholder.Select(Function(x) x.Shareholder_ID And x.Active).ToArray
                        For Each i In db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.KYC_ID = model.KYC_ID And x.IsDeleted = False And Not listShareholder.Contains(x.Shareholder_ID)).ToList
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                            i.IsDeleted = True
                        Next
                        db.SaveChanges()

                        'masukin yang baru
                        For Each i In model.DetailShareholder.Where(Function(x) x.Active = True And x.Shareholder_ID Is Nothing)
                            Dim Shareholder As New Ms_Customer_KYC_Shareholders
                            Shareholder.KYC_ID = kycs.KYC_ID
                            Shareholder.Shareholder_Name = i.Shareholder_Name
                            Shareholder.AmountofShares = i.AmountofShares
                            Shareholder.Nominal_Amount = i.Nominal_Amount
                            Shareholder.CreatedBy = user
                            Shareholder.CreatedDate = DateTime.Now
                            Shareholder.IsDeleted = False
                            db.Ms_Customer_KYC_Shareholders.Add(Shareholder)
                        Next
                        db.SaveChanges()

                        'update yang lama
                        For Each i In model.DetailShareholder.Where(Function(x) x.Active = True And x.Shareholder_ID IsNot Nothing)
                            Dim Shareholder = db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.Shareholder_ID = i.Shareholder_ID).FirstOrDefault
                            Shareholder.Shareholder_Name = i.Shareholder_Name
                            Shareholder.AmountofShares = i.AmountofShares
                            Shareholder.Nominal_Amount = i.Nominal_Amount
                            Shareholder.ModifiedBy = user
                            Shareholder.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        'save file
                        If model.DOE_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOE"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOE_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOE_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.AOA_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/AOA"), kycs.KYC_ID.ToString() + ".pdf")
                            model.AOA_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.AOA_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.BOD_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BOD"), kycs.KYC_ID.ToString() + ".pdf")
                            model.BOD_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.BOD_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA1_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA1"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA1_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA1_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA2_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA2"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA2_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA2_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA3_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA3"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA3_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA3_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA4_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA4"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA4_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA4_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.DOA5_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/DOA5"), kycs.KYC_ID.ToString() + ".pdf")
                            model.DOA5_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.DOA5_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Business_License_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/BL"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Business_License_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Business_License_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.TDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/TDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.TDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.TDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SKDP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SKDP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SKDP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SKDP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.NPWP_SKT_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/NPWP_SKT"), kycs.KYC_ID.ToString() + ".pdf")
                            model.NPWP_SKT_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.NPWP_SKT_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SPPKP_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SPPKP"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SPPKP_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SPPKP_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.Identitas_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/Identitas"), kycs.KYC_ID.ToString() + ".pdf")
                            model.Identitas_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.Identitas_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasaPenerima_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasaPenerima"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasaPenerima_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasaPenerima_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        If model.SuratKuasa_IsUploaded Then
                            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Legal/SuratKuasa"), kycs.KYC_ID.ToString() + ".pdf")
                            model.SuratKuasa_IsUploadedFile.SaveAs(path)
                            Using ms As MemoryStream = New MemoryStream()
                                ms.Position = 0
                                model.SuratKuasa_IsUploadedFile.InputStream.CopyTo(ms)
                            End Using
                        End If
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        ModelState.AddModelError("ValidateAuthorizedSigner", ex.Message)
                        Return View(model)
                    End Try
                End Using
                Return RedirectToAction("IndexReviewKYC")
            End If
            Dim city = db.Ms_Citys.Where(Function(x) x.isDeleted = False).OrderBy(Function(x) x.City)
            ViewBag.AOA_City_ID = New SelectList(city, "CIty_ID", "City", model.AOA_City_ID)
            ViewBag.BOD_City_ID = New SelectList(city, "CIty_ID", "City", model.BOD_City_ID)
            ViewBag.DOA1_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA1_City_ID)
            ViewBag.DOA2_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA2_City_ID)
            ViewBag.DOA3_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA3_City_ID)
            ViewBag.DOA4_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA4_City_ID)
            ViewBag.DOA5_City_ID = New SelectList(city, "CIty_ID", "City", model.DOA5_City_ID)
            ViewBag.DOE_City_ID = New SelectList(city, "CIty_ID", "City", model.DOE_City_ID)
            ViewBag.Legal_Domicile_City_ID = New SelectList(city, "CIty_ID", "City", model.Legal_Domicile_City_ID)
            ViewBag.Business_License_ID = New SelectList(db.Ms_Customer_BusinessLicenses.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.BusinessLicense), "BusinessLicense_ID", "BusinessLicense", model.Business_License_ID)
            ViewBag.Customer_ID = New SelectList(db.Ms_Customers.Where(Function(x) x.IsDeleted = False And x.IsKYC = False).OrderBy(Function(x) x.Company_Name), "Customer_ID", "Company_Name", model.Customer_ID)
            Dim identityList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "WNI",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "WNA",
                    .Value = False
                }
            }
            ViewBag.Identitas = New SelectList(identityList, "Value", "Text", model.Identitas)
            Dim TypeCompanyList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "TDP",
                    .Value = "TDP"
                },
                New SelectListItem With {
                    .Text = "NIB",
                    .Value = "NIB"
                }
            }
            ViewBag.TDP_Type = New SelectList(TypeCompanyList, "Value", "Text", model.TDP_Type)
            Dim DOATypeList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Approval",
                    .Value = "Approval"
                },
                New SelectListItem With {
                    .Text = "Acceptance of Notification Letter",
                    .Value = "Acceptance of Notification Letter"
                }
            }
            ViewBag.DOA1_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA1_Type)
            ViewBag.DOA2_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA2_Type)
            ViewBag.DOA3_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA3_Type)
            ViewBag.DOA4_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA4_Type)
            ViewBag.DOA5_Type = New SelectList(DOATypeList, "Value", "Text", model.DOA5_Type)
            ViewBag.BOD_Type = New SelectList(DOATypeList, "Value", "Text", model.BOD_Type)
            Dim GenderList As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Mr",
                    .Value = "Mr"
                },
                New SelectListItem With {
                    .Text = "Mrs",
                    .Value = "Mrs"
                },
                New SelectListItem With {
                    .Text = "Ms",
                    .Value = "Ms"
                }
            }
            ViewBag.SuratKuasaGender = New SelectList(GenderList, "Value", "Text", model.SuratKuasaGender)
            Return View(model)
        End Function


        ' GET: KYC/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Customer_KYCs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).
                Select(Function(x) New Ms_Customer_KYC With {.KYC_ID = x.KYC_ID, .Customer_ID = x.Customer_ID, .Customer_Name = x.Ms_Customers.Company_Name, .Legal_Domicile_City_ID = x.Legal_Domicile_City_ID, .Legal_Domicile_City = x.Ms_Citys8.City,
.DOE_No = x.DOE_No, .DOE_Date = x.DOE_Date, .DOE_Notary = x.DOE_Notary, .DOE_City_ID = x.DOE_City_ID, .DOE_Approval_No = x.DOE_Approval_No,
.DOE_IsUploaded = x.DOE_IsUploaded, .AOA_No = x.AOA_No, .AOA_Date = x.AOA_Date, .AOA_Notary = x.AOA_Notary, .AOA_City_ID = x.AOA_City_ID,
.AOA_IsUploaded = x.AOA_IsUploaded, .BOD_No = x.BOD_No, .BOD_Date = x.BOD_Date, .BOD_Notary = x.BOD_Notary,
.BOD_City_ID = x.BOD_City_ID, .BOD_Letter_No = x.BOD_Letter_No, .BOD_Letter_Date = x.BOD_Letter_Date,
.BOD_IsUploaded = x.BOD_IsUploaded, .DOA1_No = x.DOA1_No, .DOA1_Date = x.DOA1_Date, .DOA1_Notary = x.DOA1_Notary, .DOA1_City_ID = x.DOA1_City_ID,
.DOA1_Regarding = x.DOA1_Regarding, .DOA1_Letter_No = x.DOA1_Letter_No, .DOA1_Letter_Date = x.DOA1_Letter_Date, .DOA1_IsUploaded = x.DOA1_IsUploaded,
.DOA2_No = x.DOA2_No, .DOA2_Date = x.DOA2_Date, .DOA2_Notary = x.DOA2_Notary, .DOA2_City_ID = x.DOA2_City_ID, .DOA2_Regarding = x.DOA2_Regarding,
.DOA2_Letter_No = x.DOA2_Letter_No, .DOA2_Letter_Date = x.DOA2_Letter_Date, .DOA2_IsUploaded = x.DOA2_IsUploaded, .DOA3_No = x.DOA3_No, .DOA3_Date = x.DOA3_Date,
.DOA3_Notary = x.DOA3_Notary, .DOA3_City_ID = x.DOA3_City_ID, .DOA3_Regarding = x.DOA3_Regarding, .DOA3_Letter_No = x.DOA3_Letter_No, .DOA3_Letter_Date = x.DOA3_Letter_Date,
.DOA3_IsUploaded = x.DOA3_IsUploaded, .DOA4_No = x.DOA4_No, .DOA4_Date = x.DOA4_Date, .DOA4_Notary = x.DOA4_Notary, .DOA4_City_ID = x.DOA4_City_ID,
.DOA4_Regarding = x.DOA4_Regarding, .DOA4_Letter_No = x.DOA4_Letter_No, .DOA4_Letter_Date = x.DOA4_Letter_Date, .DOA4_IsUploaded = x.DOA4_IsUploaded,
.DOA5_No = x.DOA5_No, .DOA5_Date = x.DOA5_Date, .DOA5_Notary = x.DOA5_Notary, .DOA5_City_ID = x.DOA5_City_ID, .DOA5_Regarding = x.DOA5_Regarding,
.DOA5_Letter_No = x.DOA5_Letter_No, .DOA5_Letter_Date = x.DOA5_Letter_Date, .DOA5_IsUploaded = x.DOA5_IsUploaded,
.Business_License_ID = x.Business_License_ID, .Business_License_IssuedBy = x.Business_License_IssuedBy, .Business_License_IssuedDate = x.Business_License_IssuedDate,
.Business_License_ExpiredDate = x.Business_License_ExpiredDate, .Business_License_IsUploaded = x.Business_License_IsUploaded,
.TDP = x.TDP, .TDP_IssuedBy = x.TDP_IssuedBy, .TDP_IssuedDate = x.TDP_IssuedDate, .TDP_ExpiredDate = x.TDP_ExpiredDate, .TDP_IsUploaded = x.TDP_IsUploaded,
.SKDP_No = x.SKDP_No, .SKDP_Address = x.SKDP_Address, .SKDP_IssuedBy = x.SKDP_IssuedBy, .SKDP_IssuedDate = x.SKDP_IssuedDate, .SKDP_IsUploaded = x.SKDP_IsUploaded,
.NPWP_No = x.NPWP_No, .NPWP_IsUploaded = x.NPWP_IsUploaded, .Authorized_Person = x.Authorized_Person,
.Annual_Income = x.Annual_Income, .Purpose_of_Services = x.Purpose_of_Services, .Identitas = x.Identitas,
.Identitas_IsUploaded = x.Identitas_IsUploaded, .Authorized_Capital = x.Authorized_Capital, .Issued_Paidup_Capital = x.Issued_Paidup_Capital,
.CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_Customer_KYCs) Then
                Return HttpNotFound()
            End If
            Return View(ms_Customer_KYCs)
        End Function

        ' POST: KYC/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim ms_Customer_KYCs = db.Ms_Customer_KYCs.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).FirstOrDefault
            If IsNothing(ms_Customer_KYCs) Then
                Return HttpNotFound()
            End If
            Dim Director = db.Ms_Customer_KYC_Directors.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).ToList
            Dim Commisioner = db.Ms_Customer_KYC_Commissioners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).ToList
            Dim Signer = db.Ms_Customer_KYC_AuthorizedSigners.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).ToList
            Dim Shareholder = db.Ms_Customer_KYC_Shareholders.Where(Function(x) x.IsDeleted = False And x.KYC_ID = id).ToList
            Dim Customer = db.Ms_Customers.Where(Function(x) x.IsDeleted = False And x.Customer_ID = ms_Customer_KYCs.Customer_ID).First
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            ms_Customer_KYCs.IsDeleted = True
            ms_Customer_KYCs.ModifiedBy = user
            ms_Customer_KYCs.ModifiedDate = DateTime.Now
            For Each i In Director
                i.IsDeleted = True
                i.ModifiedBy = user
                i.ModifiedDate = DateTime.Now
            Next
            For Each i In Commisioner
                i.IsDeleted = True
                i.ModifiedBy = user
                i.ModifiedDate = DateTime.Now
            Next
            For Each i In Signer
                i.IsDeleted = True
                i.ModifiedBy = user
                i.ModifiedDate = DateTime.Now
            Next
            For Each i In Shareholder
                i.IsDeleted = True
                i.ModifiedBy = user
                i.ModifiedDate = DateTime.Now
            Next
            Customer.IsKYC = False
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
