Imports System.ComponentModel.DataAnnotations

Public Class Ms_Customer_KYC
    Public Property KYC_ID As Integer
    Private _kYC_IDPDF As String
    Public Property KYC_IDPDF As String
        Get
            _kYC_IDPDF = KYC_ID.ToString + ".pdf"
            Return _kYC_IDPDF
        End Get
        Set(ByVal value As String)
            _kYC_IDPDF = value
        End Set
    End Property

    <Required>
    <Display(Name:="Name of Lessee/Customer")>
    Public Property Customer_ID As Integer
    <Display(Name:="Name Customer")>
    Public Property Customer_Name As String
    '<Required>
    <Display(Name:="Domiciled in")>
    Public Property Legal_Domicile_City_ID As Integer
    <Display(Name:="Domiciled in")>
    Public Property Legal_Domicile_City As String
    '<Required>
    '<Display(Name:="Line Bussiness")>
    'Public Property Line_Bussiness As String
    '<Required>
    <Display(Name:="Deed of Estabilishment (DoE) No.")>
    Public Property DOE_No As String
    '<Required>
    <Display(Name:="Deed of Estabilishment (DOE) Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOE_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOE_Notary As String
    '<Required>
    <Display(Name:="In (City)")>
    Public Property DOE_City_ID As Nullable(Of Integer)
    <Display(Name:="In (City)")>
    Public Property DOE_City As String
    '<Required>
    <Display(Name:="Approval No.")>
    Public Property DOE_Approval_No As String
    <Display(Name:="Approval Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOE_Approval_Date As Nullable(Of Date)
    <Display(Name:="From")>
    Public Property DOE_Approval_From As String
    <Display(Name:="States Gazette No.")>
    Public Property DOE_States_Gazette_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOE_States_Gazette_Date As Nullable(Of Date)
    <Display(Name:="Supplement No.")>
    Public Property DOE_Supplement_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOE_Supplement_Date As Nullable(Of Date)

    <Display(Name:="Deed of Estabilishment (DOE) Upload")>
    Public Property DOE_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed of Article of Association (AOA) Adjustment with UUPT No")>
    Public Property AOA_No As String
    '<Required>
    <Display(Name:="Deed of Article of Association (AOA) Adjustment with UUPT Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property AOA_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property AOA_Notary As String
    '<Required>
    <Display(Name:="In (City)")>
    Public Property AOA_City_ID As Nullable(Of Integer)
    <Display(Name:="In (City)")>
    Public Property AOA_City As String
    <Display(Name:="Approval No.")>
    Public Property AOA_Approval_No As String
    <Display(Name:="Approval Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property AOA_Approval_Date As Nullable(Of Date)
    <Display(Name:="States Gazette No.")>
    Public Property AOA_States_Gazette_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property AOA_States_Gazette_Date As Nullable(Of Date)
    <Display(Name:="Supplement No.")>
    Public Property AOA_Supplement_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property AOA_Supplement_Date As Nullable(Of Date)
    <Display(Name:="Deed of Article of Association (AOA) Adjustment with UUPT Upload")>
    Public Property AOA_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property BOD_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BOD_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property BOD_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property BOD_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property BOD_City As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property BOD_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property BOD_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BOD_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change of BoD & BoC")>
    Public Property BOD_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="Period (years)")>
    Public Property BoD_Period As Nullable(Of Integer)
    <Display(Name:="as mention in Paragraph ")>
    Public Property BoD_Mention As String
    <Display(Name:="Article")>
    Public Property BoD_Article As String
    <Display(Name:="The Latest Appointment on")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BoD_Appointment As Nullable(Of Date)
    <Display(Name:="Shall be valid until")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BoD_Expired As Nullable(Of Date)
    <Display(Name:="Period (years)")>
    Public Property BoC_Period As Nullable(Of Integer)
    <Display(Name:="as mention in Paragraph ")>
    Public Property BoC_Mention As String
    <Display(Name:="Article")>
    Public Property BoC_Article As String
    <Display(Name:="The Latest Appointment on")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BoC_Appointment As Nullable(Of Date)
    <Display(Name:="Shall be valid until")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property BoC_Expired As Nullable(Of Date)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property DOA1_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA1_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOA1_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property DOA1_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property DOA1_City As String
    '<Required>
    <Display(Name:="Regarding")>
    Public Property DOA1_Regarding As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property DOA1_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property DOA1_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA1_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change")>
    Public Property DOA1_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property DOA2_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA2_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOA2_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property DOA2_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property DOA2_City As String
    '<Required>
    <Display(Name:="Regarding")>
    Public Property DOA2_Regarding As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property DOA2_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property DOA2_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    <DataType(DataType.Date)>
    Public Property DOA2_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change")>
    Public Property DOA2_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property DOA3_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA3_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOA3_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property DOA3_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property DOA3_City As String
    '<Required>
    <Display(Name:="Regarding")>
    Public Property DOA3_Regarding As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property DOA3_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property DOA3_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA3_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change")>
    Public Property DOA3_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property DOA4_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA4_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOA4_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property DOA4_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property DOA4_City As String
    '<Required>
    <Display(Name:="Regarding")>
    Public Property DOA4_Regarding As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property DOA4_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property DOA4_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA4_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change")>
    Public Property DOA4_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Deed No.")>
    Public Property DOA5_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA5_Date As Nullable(Of Date)
    '<Required>
    <Display(Name:="Made by Notary")>
    Public Property DOA5_Notary As String
    '<Required>
    <Display(Name:="In")>
    Public Property DOA5_City_ID As Nullable(Of Integer)
    <Display(Name:="In")>
    Public Property DOA5_City As String
    '<Required>
    <Display(Name:="Regarding")>
    Public Property DOA5_Regarding As String
    <Display(Name:="Type : Approval/Acceptance of Notification Letter")>
    Public Property DOA5_Type As String
    '<Required>
    <Display(Name:="No. ")>
    Public Property DOA5_Letter_No As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DOA5_Letter_Date As Nullable(Of Date)
    <Display(Name:="Upload Deed of Change")>
    Public Property DOA5_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Type of Business License")>
    Public Property Business_License_ID As Nullable(Of Integer)
    <Display(Name:="Type of Business License")>
    Public Property Business_License As String
    <Display(Name:="No.")>
    Public Property Business_License_No As String
    '<Required>
    <Display(Name:="Issued by")>
    Public Property Business_License_IssuedBy As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Business_License_IssuedDate As Nullable(Of Date)
    <Display(Name:="Shall be valid until ")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Business_License_ExpiredDate As Nullable(Of Date)
    <Display(Name:="N/A")>
    Public Property Business_License_ExpiredDate_IsNA As Nullable(Of Boolean)
    <Display(Name:="Upload Business Lisence")>
    Public Property Business_License_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="Type of Company Business Registration (TDP/NIB)")>
    Public Property TDP_Type As String
    '<Required>
    <Display(Name:="TDP No.")>
    Public Property TDP As String
    '<Required>
    <Display(Name:="Issued by")>
    Public Property TDP_IssuedBy As String
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property TDP_IssuedDate As Nullable(Of Date)
    <Display(Name:="Shall be valid until")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property TDP_ExpiredDate As Nullable(Of Date)
    Public Property TDP_ExpiredDate_IsNA As Nullable(Of Boolean)
    <Display(Name:="Upload TDP/NIB")>
    Public Property TDP_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="SKDP No")>
    Public Property SKDP_No As String
    '<Required>
    <Display(Name:="Registration Address at")>
    Public Property SKDP_Address As String
    '<Required>
    <Display(Name:="Issued by")>
    Public Property SKDP_IssuedBy As String
    <Display(Name:="Shall be valid until")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property SKDP_ExpiredDate As Nullable(Of Date)
    <Display(Name:="N/A")>
    Public Property SKDP_ExpiredDate_IsNA As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property SKDP_IssuedDate As Nullable(Of Date)
    <Display(Name:="Upload SKDP")>
    Public Property SKDP_IsUploaded As Nullable(Of Boolean)
    '<Required>
    <Display(Name:="NPWP No")>
    Public Property NPWP_No As String
    <Display(Name:="NPWP Upload")>
    Public Property NPWP_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="SKT NPWP No.")>
    Public Property NPWP_SKT_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property NPWP_SKT_Date As Nullable(Of Date)
    <Display(Name:="Issued by")>
    Public Property NPWP_SKT_Issued_By As String
    <Display(Name:="Upload SKT NPWP")>
    Public Property NPWP_SKT_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="SPPKP No.")>
    Public Property SPPKP_No As String
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property SPPKP_Date As Nullable(Of Date)
    <Display(Name:="Issued by")>
    Public Property SPPKP_Issued_By As String
    <Display(Name:="Upload SPPKP")>
    Public Property SPPKP_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="Authorized Person")>
    Public Property Authorized_Person As String
    <Display(Name:="Annual Income")>
    Public Property Annual_Income As String
    <Display(Name:="Purpose of Services")>
    Public Property Purpose_of_Services As String
    '<Required>
    <Display(Name:="Identity")>
    Public Property Identitas As Nullable(Of Boolean)
    Private _identitasView As String
    Public Property IdentitasView As String
        Get
            If Identitas Then
                _identitasView = "WNI"
            Else
                _identitasView = "WNA"
            End If
            Return _identitasView
        End Get
        Set(ByVal value As String)
            _identitasView = value
        End Set
    End Property
    <Display(Name:="Identity Upload")>
    Public Property Identitas_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="Authorized Capital, Issued & Paid-up Capital, & Shareholders composition, based on")>
    Public Property Authorized_Capital_BasedOn As String
    <Display(Name:="Authorized Capital")>
    Public Property Authorized_Capital As String
    <Display(Name:="Issued & Paid-up Capital")>
    Public Property Issued_Paidup_Capital As String
    <Display(Name:="Created Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property CreatedDate As DateTime
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property ModifiedDate As Nullable(Of DateTime)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Is Deleeted")>
    Public Property IsDeleted As Boolean


    Public Property Director As String
    <Display(Name:="Expired Date")>
    <DataType(DataType.Date)>
    Public Property DirectorExpiredDate As DateTime

    Public Property Commissioner As String
    <Display(Name:="Expired Date")>
    <DataType(DataType.Date)>
    Public Property CommissionerExpiredDate As DateTime

    <Display(Name:="Authorized Signer")>
    Public Property AuthorizedSigner As String
    <Display(Name:="Paragraph")>
    Public Property Paragraph1 As Nullable(Of Integer)
    <Display(Name:="Article")>
    Public Property Article1 As Nullable(Of Integer)
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph11 As String
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph21 As String
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph31 As String
    <Display(Name:="Paragraph")>
    Public Property Paragraph2 As Nullable(Of Integer)
    <Display(Name:="Article")>
    Public Property Article2 As Nullable(Of Integer)
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph12 As String
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph22 As String
    <Display(Name:="Input Paragraph")>
    Public Property InputParagraph32 As String
    <Display(Name:="Gender")>
    Public Property SuratKuasaGender As String
    <Display(Name:="by ")>
    Public Property SuratKuasaBy As String
    <Display(Name:="based on")>
    Public Property SuratKuasaBasedOn As String
    <Display(Name:="date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property SuratKuasaDate As Nullable(Of Date)
    <Display(Name:="shall be valid until")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property SuratKuasaExpired As Nullable(Of Date)
    <Display(Name:="N/A")>
    Public Property SuratKuasaExpired_IsNA As Nullable(Of Boolean)
    <Display(Name:="Identity Penerima Surat kuasa")>
    Public Property SuratKuasaPenerima_IsUploaded As Nullable(Of Boolean)
    <Display(Name:="Upload Surat Kuasa")>
    Public Property SuratKuasa_IsUploaded As Nullable(Of Boolean)

    Public Property DetailDirector As IEnumerable(Of Ms_Customer_KYC_Director)
    Public Property DetailCommissioner As IEnumerable(Of Ms_Customer_KYC_Commissioner)
    Public Property DetailAuthorizedSigner As IEnumerable(Of Ms_Customer_KYC_AuthorizedSigner)
    Public Property DetailShareholder As IEnumerable(Of Ms_Customer_KYC_Shareholder)
    Public Property DetailLineBussiness As IEnumerable(Of Ms_Customer_KYC_LineBussiness)

    Public Property ValidateDirector As String
    Public Property ValidateCommissioner As String
    Public Property ValidateAuthorizedSigner As String
    Public Property ValidateShareholder As String
    Public Property ValidateLineBussiness As String

    <Display(Name:="Deed of Estabilishment (DoE) Upload")>
    Public Property DOE_IsUploadedFile As HttpPostedFileBase
    <Display(Name:="Deed of Article of Association (AoA) Adjustment UUPT Upload")>
    Public Property AOA_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change of BoD & BoC")>
    Public Property BOD_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change")>
    Public Property DOA1_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change")>
    Public Property DOA2_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change")>
    Public Property DOA3_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change")>
    Public Property DOA4_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Deed of Change")>
    Public Property DOA5_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload Business Lisence")>
    Public Property Business_License_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload TDP/NIB")>
    Public Property TDP_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload SKDP")>
    Public Property SKDP_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload NPWP")>
    Public Property NPWP_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload SKT NPWP")>
    Public Property NPWP_SKT_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Upload SPPKP")>
    Public Property SPPKP_IsUploadedFile As HttpPostedFileBase

    <Display(Name:="Identity Upload")>
    Public Property Identitas_IsUploadedFile As HttpPostedFileBase
    <Display(Name:="Identity Penerima Surat kuasa")>
    Public Property SuratKuasaPenerima_IsUploadedFile As HttpPostedFileBase
    <Display(Name:="Upload Surat Kuasa")>
    Public Property SuratKuasa_IsUploadedFile As HttpPostedFileBase



End Class
Public Class Ms_Customer_KYC_Report
    Public Property Customer_ID As Integer
    Public Property Company_Name As String
    Public Property Legal_Domicile As String
    Public Property Line_Bussiness As String
    Public Property DOE_No As String
    Public Property DOE_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOE_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOE_DateStr As String
    Public Property DOE_DateStr As String
        Get
            Return _DOE_DateStr
        End Get
        Set(ByVal value As String)
            _DOE_DateStr = value
        End Set
    End Property

    Public Property DOE_Notary As String
    Public Property DOE_City_ID As Nullable(Of Integer)
    Public Property DOE_City As String
    Public Property DOE_Approval_No As String
    Public Property DOE_Approval_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOE_Approval_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOE_Approval_DateStr As String
    Public Property DOE_Approval_DateStr As String
        Get
            Return _DOE_Approval_DateStr
        End Get
        Set(ByVal value As String)
            _DOE_Approval_DateStr = value
        End Set
    End Property
    Public Property DOE_Approval_From As String
    Public Property DOE_States_Gazette_No As String
    Public Property DOE_States_Gazette_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOE_States_Gazette_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOE_States_Gazette_DateStr As String
    Public Property DOE_States_Gazette_DateStr As String
        Get
            Return _DOE_States_Gazette_DateStr
        End Get
        Set(ByVal value As String)
            _DOE_States_Gazette_DateStr = value
        End Set
    End Property
    Public Property DOE_Supplement_No As String
    Public Property DOE_Supplement_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOE_Supplement_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOE_Supplement_DateStr As String
    Public Property DOE_Supplement_DateStr As String
        Get
            Return _DOE_Supplement_DateStr
        End Get
        Set(ByVal value As String)
            _DOE_Supplement_DateStr = value
        End Set
    End Property
    Public Property DOE_IsUploaded As Nullable(Of Boolean)
    Public Property AOA_No As String
    Public Property AOA_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _AOA_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _AOA_DateStr As String
    Public Property AOA_DateStr As String
        Get
            Return _AOA_DateStr
        End Get
        Set(ByVal value As String)
            _AOA_DateStr = value
        End Set
    End Property
    Public Property AOA_Notary As String
    Public Property AOA_City_ID As Nullable(Of Integer)
    Public Property AOA_City As String
    Public Property AOA_Approval_No As String
    Public Property AOA_Approval_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _AOA_Approval_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _AOA_Approval_DateStr As String
    Public Property AOA_Approval_DateStr As String
        Get
            Return _AOA_Approval_DateStr
        End Get
        Set(ByVal value As String)
            _AOA_Approval_DateStr = value
        End Set
    End Property
    Public Property AOA_States_Gazette_No As String
    Public Property AOA_States_Gazette_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _AOA_States_Gazette_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _AOA_States_Gazette_DateStr As String
    Public Property AOA_States_Gazette_DateStr As String
        Get
            Return _AOA_States_Gazette_DateStr
        End Get
        Set(ByVal value As String)
            _AOA_States_Gazette_DateStr = value
        End Set
    End Property
    Public Property AOA_Supplement_No As String
    Public Property AOA_Supplement_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _AOA_Supplement_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _AOA_Supplement_DateStr As String
    Public Property AOA_Supplement_DateStr As String
        Get
            Return _AOA_Supplement_DateStr
        End Get
        Set(ByVal value As String)
            _AOA_Supplement_DateStr = value
        End Set
    End Property
    Public Property AOA_IsUploaded As Nullable(Of Boolean)
    Public Property NPWP_No As String
    Public Property NPWP_IsUploaded As Nullable(Of Boolean)
    Public Property NPWP_SKT_No As String
    Public Property NPWP_SKT_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _NPWP_SKT_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _NPWP_SKT_DateStr As String
    Public Property NPWP_SKT_DateStr As String
        Get
            Return _NPWP_SKT_DateStr
        End Get
        Set(ByVal value As String)
            _NPWP_SKT_DateStr = value
        End Set
    End Property
    Public Property NPWP_SKT_Issued_By As String
    Public Property NPWP_SKT_IsUploaded As Nullable(Of Boolean)
    Public Property SPPKP_No As String
    Public Property SPPKP_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _SPPKP_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _SPPKP_DateStr As String
    Public Property SPPKP_DateStr As String
        Get
            Return _SPPKP_DateStr
        End Get
        Set(ByVal value As String)
            _SPPKP_DateStr = value
        End Set
    End Property
    Public Property SPPKP_Issued_By As String
    Public Property SPPKP_IsUploaded As Nullable(Of Boolean)
    Public Property Business_License_ID As Nullable(Of Integer)
    Public Property Business_License_No As String
    Public Property Business_License_IssuedDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _Business_License_IssuedDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _Business_License_IssuedDateStr As String
    Public Property Business_License_IssuedDateStr As String
        Get
            Return _Business_License_IssuedDateStr
        End Get
        Set(ByVal value As String)
            _Business_License_IssuedDateStr = value
        End Set
    End Property
    Public Property Business_License_IssuedBy As String
    Public Property Business_License_ExpiredDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _Business_License_ExpiredDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _Business_License_ExpiredDateStr As String
    Public Property Business_License_ExpiredDateStr As String
        Get
            Return _Business_License_ExpiredDateStr
        End Get
        Set(ByVal value As String)
            _Business_License_ExpiredDateStr = value
        End Set
    End Property
    Public Property Business_License_ExpiredDate_IsNA As Nullable(Of Boolean)
    Public Property Business_License_IsUploaded As Nullable(Of Boolean)
    Public Property TDP_Type As String
    Public Property TDP As String
    Public Property TDP_IssuedDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _TDP_IssuedDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _TDP_IssuedDateStr As String
    Public Property TDP_IssuedDateStr As String
        Get
            Return _TDP_IssuedDateStr
        End Get
        Set(ByVal value As String)
            _TDP_IssuedDateStr = value
        End Set
    End Property
    Public Property TDP_IssuedBy As String
    Public Property TDP_ExpiredDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _TDP_ExpiredDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _TDP_ExpiredDateStr As String
    Public Property TDP_ExpiredDateStr As String
        Get
            Return _TDP_ExpiredDateStr
        End Get
        Set(ByVal value As String)
            _TDP_ExpiredDateStr = value
        End Set
    End Property
    Public Property TDP_ExpiredDate_IsNA As Nullable(Of Boolean)
    Public Property TDP_IsUploaded As Nullable(Of Boolean)
    Public Property SKDP_Address As String
    Public Property SKDP_No As String
    Public Property SKDP_IssuedDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _SKDP_IssuedDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _SKDP_IssuedDateStr As String
    Public Property SKDP_IssuedDateStr As String
        Get
            Return _SKDP_IssuedDateStr
        End Get
        Set(ByVal value As String)
            _SKDP_IssuedDateStr = value
        End Set
    End Property
    Public Property SKDP_IssuedBy As String
    Public Property SKDP_ExpiredDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _SKDP_ExpiredDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _SKDP_ExpiredDateStr As String
    Public Property SKDP_ExpiredDateStr As String
        Get
            Return _SKDP_ExpiredDateStr
        End Get
        Set(ByVal value As String)
            _SKDP_ExpiredDateStr = value
        End Set
    End Property
    Public Property SKDP_ExpiredDate_IsNA As Nullable(Of Boolean)
    Public Property SKDP_IsUploaded As Nullable(Of Boolean)
    Public Property DOA1_No As String
    Public Property DOA1_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA1_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA1_DateStr As String
    Public Property DOA1_DateStr As String
        Get
            Return _DOA1_DateStr
        End Get
        Set(ByVal value As String)
            _DOA1_DateStr = value
        End Set
    End Property
    Public Property DOA1_Notary As String
    Public Property DOA1_City_ID As Nullable(Of Integer)
    Public Property DOA1_City As String
    Public Property DOA1_Regarding As String
    Public Property DOA1_Type As String
    Public Property DOA1_Letter_No As String
    Public Property DOA1_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA1_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA1_Letter_DateStr As String
    Public Property DOA1_Letter_DateStr As String
        Get
            Return _DOA1_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _DOA1_Letter_DateStr = value
        End Set
    End Property
    Public Property DOA1_IsUploaded As Nullable(Of Boolean)
    Public Property DOA2_No As String
    Public Property DOA2_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA2_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA2_DateStr As String
    Public Property DOA2_DateStr As String
        Get
            Return _DOA2_DateStr
        End Get
        Set(ByVal value As String)
            _DOA2_DateStr = value
        End Set
    End Property
    Public Property DOA2_Notary As String
    Public Property DOA2_City_ID As Nullable(Of Integer)
    Public Property DOA2_City As String
    Public Property DOA2_Regarding As String
    Public Property DOA2_Type As String
    Public Property DOA2_Letter_No As String
    Public Property DOA2_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA2_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA2_Letter_DateStr As String
    Public Property DOA2_Letter_DateStr As String
        Get
            Return _DOA2_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _DOA2_Letter_DateStr = value
        End Set
    End Property
    Public Property DOA2_IsUploaded As Nullable(Of Boolean)
    Public Property DOA3_No As String
    Public Property DOA3_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA3_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA3_DateStr As String
    Public Property DOA3_DateStr As String
        Get
            Return _DOA3_DateStr
        End Get
        Set(ByVal value As String)
            _DOA3_DateStr = value
        End Set
    End Property

    Public Property DOA3_Notary As String
    Public Property DOA3_City_ID As Nullable(Of Integer)
    Public Property DOA3_City As String
    Public Property DOA3_Regarding As String
    Public Property DOA3_Type As String
    Public Property DOA3_Letter_No As String
    Public Property DOA3_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA3_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA3_Letter_DateStr As String
    Public Property DOA3_Letter_DateStr As String
        Get
            Return _DOA3_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _DOA3_Letter_DateStr = value
        End Set
    End Property
    Public Property DOA3_IsUploaded As Nullable(Of Boolean)
    Public Property DOA4_No As String
    Public Property DOA4_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA4_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA4_DateStr As String
    Public Property DOA4_DateStr As String
        Get
            Return _DOA4_DateStr
        End Get
        Set(ByVal value As String)
            _DOA4_DateStr = value
        End Set
    End Property

    Public Property DOA4_Notary As String
    Public Property DOA4_City_ID As Nullable(Of Integer)
    Public Property DOA4_City As String
    Public Property DOA4_Regarding As String
    Public Property DOA4_Type As String
    Public Property DOA4_Letter_No As String
    Public Property DOA4_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA4_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA4_Letter_DateStr As String
    Public Property DOA4_Letter_DateStr As String
        Get
            Return _DOA4_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _DOA4_Letter_DateStr = value
        End Set
    End Property
    Public Property DOA4_IsUploaded As Nullable(Of Boolean)
    Public Property DOA5_No As String
    Public Property DOA5_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA5_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA5_DateStr As String
    Public Property DOA5_DateStr As String
        Get
            Return _DOA5_DateStr
        End Get
        Set(ByVal value As String)
            _DOA5_DateStr = value
        End Set
    End Property
    Public Property DOA5_Notary As String
    Public Property DOA5_City_ID As Nullable(Of Integer)
    Public Property DOA5_City As String
    Public Property DOA5_Regarding As String
    Public Property DOA5_Type As String
    Public Property DOA5_Letter_No As String
    Public Property DOA5_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _DOA5_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _DOA5_Letter_DateStr As String
    Public Property DOA5_Letter_DateStr As String
        Get
            Return _DOA5_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _DOA5_Letter_DateStr = value
        End Set
    End Property
    Public Property DOA5_IsUploaded As Nullable(Of Boolean)
    Public Property BOD_No As String
    Public Property BOD_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BOD_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BOD_DateStr As String
    Public Property BOD_DateStr As String
        Get
            Return _BOD_DateStr
        End Get
        Set(ByVal value As String)
            _BOD_DateStr = value
        End Set
    End Property
    Public Property BOD_Notary As String
    Public Property BOD_City_ID As Nullable(Of Integer)
    Public Property BOD_City As String
    Public Property BOD_Type As String
    Public Property BOD_Letter_No As String
    Public Property BOD_Letter_Date As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BOD_Letter_DateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BOD_Letter_DateStr As String
    Public Property BOD_Letter_DateStr As String
        Get
            Return _BOD_Letter_DateStr
        End Get
        Set(ByVal value As String)
            _BOD_Letter_DateStr = value
        End Set
    End Property
    Public Property BOD_IsUploaded As Nullable(Of Boolean)
    Public Property BoD_Period As Nullable(Of Integer)
    Public Property BoD_Mention As String
    Public Property BoD_Article As String
    Public Property BoD_Appointment As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BoD_AppointmentStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BoD_AppointmentStr As String
    Public Property BoD_AppointmentStr As String
        Get
            Return _BoD_AppointmentStr
        End Get
        Set(ByVal value As String)
            _BoD_AppointmentStr = value
        End Set
    End Property
    Public Property BoD_Expired As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BoD_ExpiredStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BoD_ExpiredStr As String
    Public Property BoD_ExpiredStr As String
        Get
            Return _BoD_ExpiredStr
        End Get
        Set(ByVal value As String)
            _BoD_ExpiredStr = value
        End Set
    End Property
    Public Property BoC_Period As Nullable(Of Integer)
    Public Property BoC_Mention As String
    Public Property BoC_Article As String
    Public Property BoC_Appointment As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BoC_AppointmentStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BoC_AppointmentStr As String
    Public Property BoC_AppointmentStr As String
        Get
            Return _BoC_AppointmentStr
        End Get
        Set(ByVal value As String)
            _BoC_AppointmentStr = value
        End Set
    End Property
    Public Property BoC_Expired As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _BoC_ExpiredStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _BoC_ExpiredStr As String
    Public Property BoC_ExpiredStr As String
        Get
            Return _BoC_ExpiredStr
        End Get
        Set(ByVal value As String)
            _BoC_ExpiredStr = value
        End Set
    End Property
    Public Property Authorized_Capital_BasedOn As String
    Public Property Authorized_Capital As String
    Public Property Issued_Paidup_Capital As String
    Public Property Paragraph1 As Nullable(Of Integer)
    Public Property Article1 As Nullable(Of Integer)
    Public Property InputParagraph11 As String
    Public Property InputParagraph21 As String
    Public Property InputParagraph31 As String
    Public Property SuratKuasaGender As String
    Public Property Paragraph2 As Nullable(Of Integer)
    Public Property Article2 As Nullable(Of Integer)
    Public Property InputParagraph12 As String
    Public Property InputParagraph22 As String
    Public Property InputParagraph32 As String
    Public Property SuratKuasaBy As String
    Public Property SuratKuasaBasedOn As String
    Public Property SuratKuasaDate As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _SuratKuasaDateStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _SuratKuasaDateStr As String
    Public Property SuratKuasaDateStr As String
        Get
            Return _SuratKuasaDateStr
        End Get
        Set(ByVal value As String)
            _SuratKuasaDateStr = value
        End Set
    End Property
    Public Property SuratKuasaExpired As Nullable(Of Date)
        Get

        End Get
        Set(ByVal value As Nullable(Of Date))
            _SuratKuasaExpiredStr = CType(If(value, "1/1/0001"), Date).ToString("yyyy-MMM-dd")
        End Set
    End Property
    Private _SuratKuasaExpiredStr As String
    Public Property SuratKuasaExpiredStr As String
        Get
            Return _SuratKuasaExpiredStr
        End Get
        Set(ByVal value As String)
            _SuratKuasaExpiredStr = value
        End Set
    End Property
    Public Property SuratKuasaExpired_IsNA As Nullable(Of Boolean)
    Public Property SuratKuasaPenerima_IsUploaded As Nullable(Of Boolean)
    Public Property SuratKuasa_IsUploaded As Nullable(Of Boolean)
    Public Property Authorized_Person As String
    Public Property Annual_Income As String
    Public Property Purpose_of_Services As String
    Public Property Identitas As Nullable(Of Boolean)
    Public Property Identitas_IsUploaded As Nullable(Of Boolean)
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property User_Name As String
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean
End Class

Public Class Ms_Customer_KYC_Director
    Public Property KYC_Director_ID As Nullable(Of Integer)
    Public Property KYC_ID As Nullable(Of Integer)
    Public Property Director As String
    Public Property Gender As String
    Public Property Position As String
    Private _validate As Boolean
    Public Property Validate As Boolean
        Get
            _validate = True
            If (Director Is Nothing) Then
                ValidateMessage = "Must fill Director"
                _validate = False
            ElseIf Gender Is Nothing Then
                ValidateMessage = "Must fill Gender"
                _validate = False
            ElseIf Position Is Nothing Then
                ValidateMessage = "Must fill Position"
                _validate = False
            End If
            Return _validate
        End Get
        Set(ByVal value As Boolean)
            _validate = value
        End Set
    End Property
    Public Property ValidateMessage As String
    Private _active As Boolean
    Public Property Active As Boolean
        Get
            _active = False
            If (Director IsNot Nothing And Gender IsNot Nothing And Position IsNot Nothing) Then
                _active = True
            End If
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
    Public Property IsDeleted As Boolean

End Class
Public Class Ms_Customer_KYC_Commissioner
    Public Property KYC_Commissioner_ID As Nullable(Of Integer)
    Public Property KYC_ID As Nullable(Of Integer)
    Public Property Commissioner As String
    Public Property Gender As String
    Public Property Position As String

    Private _validate As Boolean
    Public Property Validate As Boolean
        Get
            _validate = True
            If (Commissioner Is Nothing) Then
                ValidateMessage = "Must fill Commissioner"
                _validate = False
            ElseIf (Gender Is Nothing) Then
                ValidateMessage = "Must fill Gender"
                _validate = False
            ElseIf (Position Is Nothing) Then
                ValidateMessage = "Must fill Position"
                _validate = False
            End If
            Return _validate
        End Get
        Set(ByVal value As Boolean)
            _validate = value
        End Set
    End Property
    Public Property ValidateMessage As String
    Private _active As Boolean
    Public Property Active As Boolean
        Get
            _active = False
            If (Commissioner IsNot Nothing And Gender IsNot Nothing And Position IsNot Nothing) Then
                _active = True
            End If
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
    Public Property IsDeleted As Boolean

End Class
Public Class Ms_Customer_KYC_AuthorizedSigner
    Public Property KYC_AuthorizedSigner_ID As Nullable(Of Integer)
    Public Property KYC_ID As Nullable(Of Integer)
    Public Property AuthorizedSigner As String
    Public Property Position As String
    Public Property ValidateMessage As String
    Private _validate As Boolean
    Public Property Validate As Boolean
        Get
            _validate = True
            If (AuthorizedSigner Is Nothing) Then
                ValidateMessage = "Must fill AuthorizedSigner"
                _validate = False
            ElseIf (Position Is Nothing) Then
                ValidateMessage = "Must fill Position"
                _validate = False
            End If
            Return _validate
        End Get
        Set(ByVal value As Boolean)
            _validate = value
        End Set
    End Property
    Private _active As Boolean
    Public Property Active As Boolean
        Get
            _active = False
            If (AuthorizedSigner IsNot Nothing And Position IsNot Nothing) Then
                _active = True
            End If
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
    Public Property IsDeleted As Boolean

End Class
Public Class Ms_Customer_KYC_Shareholder
    Public Property Shareholder_ID As Nullable(Of Integer)
    Public Property KYC_ID As Integer
    Public Property Shareholder_Name As String
    Public Property AmountofShares As Nullable(Of Decimal)
    Private _amountofShares_Str As String
    Public Property AmountofShares_Str As String
        Get
            Return _amountofShares_Str
        End Get
        Set(ByVal value As String)
            AmountofShares = If(value, "0").Replace(",", "")
            _amountofShares_Str = value
        End Set
    End Property
    Public Property Nominal_Amount As Nullable(Of Int32)
    Private _nominal_Amount_Str As String
    Public Property Nominal_Amount_Str As String
        Get
            Return _nominal_Amount_Str
        End Get
        Set(ByVal value As String)
            Nominal_Amount = If(value, "0").Replace(",", "")
            _nominal_Amount_Str = value
        End Set
    End Property


    Private _validate As Boolean
    Public Property Validate As Boolean
        Get
            _validate = True
            If Not (Shareholder_Name Is Nothing) Then
                If Shareholder_Name Is Nothing Then
                    ValidateMessage = "Must fill Shareholder Name"
                    _validate = False
                ElseIf AmountofShares Is Nothing Then
                    ValidateMessage = "Must fill Amount of Shares"
                    _validate = False
                ElseIf Nominal_Amount Is Nothing Then
                    ValidateMessage = "Must fill Nominal Amount"
                    _validate = False
                End If
            End If
            Return _validate
        End Get
        Set(ByVal value As Boolean)
            _validate = value
        End Set
    End Property
    Public Property ValidateMessage As String
    Private _active As Boolean
    Public Property Active As Boolean
        Get
            _active = False
            If (Shareholder_Name IsNot Nothing And AmountofShares IsNot Nothing And Nominal_Amount IsNot Nothing) Then
                _active = True
            End If
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
End Class

Public Class Ms_Customer_KYC_LineBussiness
    Public Property LineBussiness_ID As Nullable(Of Integer)
    Public Property KYC_ID As Nullable(Of Integer)
    <Required>
    Public Property LineBussiness As String
End Class