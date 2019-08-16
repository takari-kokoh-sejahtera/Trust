Imports System.ComponentModel.DataAnnotations

Public Class Tr_ApplicationHeader

    <Key>
    Public Property ApplicationHeader_ID As Integer
    <Display(Name:="Approval_ID")>
    Public Property Approval_ID As Integer
    <Display(Name:="Exist Customer")>
    Public Property IsExists As Boolean
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property City As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String


    'for APPROVAL
    Public Property StatusRecord As Nullable(Of Integer)
    Public Property Status As String
    Public Property ApprovalApp_ID As Nullable(Of Integer)
    Public Property Cost_Price As Nullable(Of Double)
    Public Property Remark As String


    'for create 
    Public Property Address As String
    Public Property Phone As String
    Public Property Email As String
    <Display(Name:="PIC Phone")>
    Public Property PIC_Phone As String
    <Display(Name:="PIC Email")>
    Public Property PIC_Email As String


    <Display(Name:="Application No")>
    Public Property Application_No As String
    <Display(Name:="Project Rating")>
    Public Property Project_Rating As String
    <Display(Name:="Credit Rating")>
    Public Property Credit_Rating As String
    <Display(Name:="Asset Rating")>
    Public Property Asset_Rating As Nullable(Of Integer)
    <Display(Name:="Contracted by")>
    Public Property Contracted_by As String
    <Display(Name:="Customer Class")>
    Public Property Customer_Class As String
    <Display(Name:="Line of Business")>
    Public Property Line_of_Business As String
    Private _authorized_Capital As Nullable(Of Decimal)
    <Display(Name:="Authorized Capital")>
    Public Property Authorized_Capital As Nullable(Of Decimal)
        Get
            Return _authorized_Capital
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _authorized_CapitalStr = CType(If(value, 0), Nullable(Of Double))
            _authorized_Capital = value
        End Set
    End Property
    Private _authorized_CapitalStr As String
    Public Property Authorized_CapitalStr As String
        Get
            Return _authorized_CapitalStr
        End Get
        Set(ByVal value As String)
            _authorized_Capital = Val(If(value, "0").Replace(",", ""))
            _authorized_CapitalStr = value
        End Set
    End Property
    <Display(Name:="Signer Name1")>
    Public Property Authorized_Signer_Name1 As String
    <Display(Name:="Signer Position1")>
    Public Property Authorized_Signer_Position1 As String
    <Display(Name:="Signer Name2")>
    Public Property Authorized_Signer_Name2 As String
    <Display(Name:="Signer Position2")>
    Public Property Authorized_Signer_Position2 As String
    <Display(Name:="Introduced By")>
    Public Property IntroducedBy As String
    <Required>
    <DataType(DataType.Date)>
    <Display(Name:="Expec Contract Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Expec_Contract_Date As Nullable(Of DateTime)


    Private _outstanding_Balance_Transaction_FL As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Transaction FL")>
    Public Property Outstanding_Balance_Transaction_FL As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Transaction_FL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_Transaction_FL = value
            _outstanding_Balance_Transaction_FLStr = String.Format("{0:N0}", value)
        End Set
    End Property
    Private _outstanding_Balance_Transaction_FLStr As String
    Public Property Outstanding_Balance_Transaction_FLStr As String
        Get
            Return _outstanding_Balance_Transaction_FLStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Transaction_FL = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_Transaction_FLStr = value
        End Set
    End Property
    Private _outstanding_Balance_Application_FL As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Application FL")>
    Public Property Outstanding_Balance_Application_FL As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Application_FL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_Application_FL = value
            _outstanding_Balance_Application_FLStr = String.Format("{0:N0}", value)
        End Set
    End Property
    Private _outstanding_Balance_Application_FLStr As String
    Public Property Outstanding_Balance_Application_FLStr As String
        Get
            Return _outstanding_Balance_Application_FLStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Application_FL = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_Application_FLStr = value
        End Set
    End Property

    Private _outstanding_Balance_Group_FL As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Group FL")>
    Public Property Outstanding_Balance_Group_FL As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Group_FL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_Group_FL = value
            _outstanding_Balance_Group_FLStr = String.Format("{0:N0}", value)
        End Set
    End Property
    Private _outstanding_Balance_Group_FLStr As String
    Public Property Outstanding_Balance_Group_FLStr As String
        Get
            Return _outstanding_Balance_Group_FLStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Group_FL = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_Group_FLStr = value
        End Set
    End Property

    Private _outstanding_Balance_MUL_Group_FL As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance MUL Group FL")>
    Public Property Outstanding_Balance_MUL_Group_FL As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_MUL_Group_FL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_MUL_Group_FL = value
            _outstanding_Balance_MUL_Group_FLStr = String.Format("{0:N0}", value)
        End Set
    End Property
    Private _outstanding_Balance_MUL_Group_FLStr As String
    Public Property Outstanding_Balance_MUL_Group_FLStr As String
        Get
            Return _outstanding_Balance_MUL_Group_FLStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_MUL_Group_FL = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_MUL_Group_FLStr = value
        End Set
    End Property

    Private _outstanding_Balance_Amount_FL As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Amount FL")>
    Public Property Outstanding_Balance_Amount_FL As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Amount_FL
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_Amount_FL = value
            _outstanding_Balance_Amount_FLStr = String.Format("{0:N0}", value)
        End Set
    End Property
    Private _outstanding_Balance_Amount_FLStr As String
    Public Property Outstanding_Balance_Amount_FLStr As String
        Get
            Return _outstanding_Balance_Amount_FLStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Amount_FL = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_Amount_FLStr = value
        End Set
    End Property


    Private _outstanding_Balance_Application As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Application")>
    Public Property Outstanding_Balance_Application As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Application
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_ApplicationStr = CType(If(value, 0), Nullable(Of Double))
            _outstanding_Balance_Application = value
        End Set
    End Property
    Private _outstanding_Balance_ApplicationStr As String
    Public Property Outstanding_Balance_ApplicationStr As String
        Get
            Return _outstanding_Balance_ApplicationStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Application = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_ApplicationStr = value
        End Set
    End Property

    Private _outstanding_Balance_Group As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance Group")>
    Public Property Outstanding_Balance_Group As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_Group
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_GroupStr = CType(If(value, 0), Nullable(Of Double))
            _outstanding_Balance_Group = value
        End Set
    End Property
    Private _outstanding_Balance_GroupStr As String
    Public Property Outstanding_Balance_GroupStr As String
        Get
            Return _outstanding_Balance_GroupStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_Group = Val(If(value, "0").Replace(",", ""))
            _outstanding_Balance_GroupStr = value
        End Set
    End Property
    Private _outstanding_Balance_MUL_Group As Nullable(Of Decimal)
    <Display(Name:="Outstanding Balance MUL Group")>
    Public Property Outstanding_Balance_MUL_Group As Nullable(Of Decimal)
        Get
            Return _outstanding_Balance_MUL_Group
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _outstanding_Balance_MUL_GroupStr = CType(If(value, 0), Nullable(Of Double))
            _outstanding_Balance_MUL_Group = value
        End Set
    End Property
    Private _outstanding_Balance_MUL_GroupStr As String
    Public Property Outstanding_Balance_MUL_GroupStr As String
        Get
            Return _outstanding_Balance_MUL_GroupStr
        End Get
        Set(ByVal value As String)
            _outstanding_Balance_MUL_Group = Val(If(value, "").Replace(",", ""))
            _outstanding_Balance_MUL_GroupStr = value
        End Set
    End Property
    <Display(Name:="Outstanding Balance Amount")>
    Public Property Outstanding_Balance_Amount As Nullable(Of Decimal)
    <Display(Name:="Run Application")>
    Public Property Run_Application As Nullable(Of Integer)
    <Display(Name:="Run Contract Company")>
    Public Property RunContractCompany As Nullable(Of Integer)
    <Display(Name:="Run Contract Group")>
    Public Property RunContractGroup As Nullable(Of Integer)
    <Display(Name:="Run Transaction FL")>
    Public Property Run_Transaction_FL As Nullable(Of Integer)
    <Display(Name:="Run Application FL")>
    Public Property Run_Application_FL As Nullable(Of Integer)
    <Display(Name:="Run Contract Company FL")>
    Public Property RunContractCompany_FL As Nullable(Of Integer)
    <Display(Name:="Run Contract Group FL")>
    Public Property RunContractGroup_FL As Nullable(Of Integer)
    <Display(Name:="Application Type")>
    Public Property ApplicationType As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As Nullable(Of Integer)
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As Nullable(Of Integer)

    <Display(Name:="Back To")>
    Public Property BackTo As String
    <Required>
    <Display(Name:="Is Truck")>
    Public Property IsTruck As Boolean
    <Required>
    <Display(Name:="Is Quick")>
    Public Property IsQuick As Boolean
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    Public Property IsNotApproved As Boolean
    Public Property RemarkNotApproved As String
    Public ReadOnly Property Color() As String
        Get
            Return If(IsNotApproved, "background-color: #ffc4c4;", "")
        End Get
    End Property
    Public ReadOnly Property NotApproveSTR() As String
        Get
            Return "Not Approve"
        End Get
    End Property

    Public Property Detail As IEnumerable(Of Tr_ApplicationHeaderDetail)



End Class
Public Class Tr_ApplicationHeaderDetail
    Public Property Application_ID As Nullable(Of Integer)
    Public Property QuotationDetail_ID As Nullable(Of Integer)
    Public Property IsVehicleExists As String
    Public Property Brand_Name As String
    Public Property Vehicle As String
    Public Property OTR_Price As Nullable(Of Decimal)
    Public Property OTR_PriceApp As Nullable(Of Decimal)
    Public ReadOnly Property OTR_PriceAppColor() As String
        Get
            Return If(If(OTR_Price, 0) >= If(OTR_PriceApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Qty As Nullable(Of Integer)
    Public Property Year As Nullable(Of Integer)
    Public Property STNK As Nullable(Of Decimal)
    Public Property Replacement As Nullable(Of Decimal)
    Public Property Lease_long As Nullable(Of Integer)
    Public Property Bid_PricePerMonth As Nullable(Of Decimal)
    Public Property Bid_PricePerMonthApp As Nullable(Of Decimal)
    Public ReadOnly Property Bid_PricePerMonthAppColor() As String
        Get
            Return If(If(Bid_PricePerMonth, 0) >= If(Bid_PricePerMonthApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Rent_Location As String
    Public Property Plat_Location As String
    Public Property Update_Diskon As Nullable(Of Decimal)
    Public Property Update_DiskonApp As Nullable(Of Decimal)
    'Diskon kebalik, makin gede makin untung
    Public ReadOnly Property Update_DiskonAppColor() As String
        Get
            Return If(If(Update_Diskon, 0) <= If(Update_DiskonApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Net As Nullable(Of Decimal)
    Public Property NetApp As Nullable(Of Decimal)
    Public ReadOnly Property NetAppColor() As String
        Get
            Return If(If(Net, 0) >= If(NetApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Depresiasi_Percent As Nullable(Of Decimal)
    Public Property Residual_ValuePercent As Nullable(Of Decimal)
    Public Property Residual_Value As Nullable(Of Decimal)
    Public Property Maintenance_Percent As Nullable(Of Decimal)
    Public Property Assurance_Percent As Nullable(Of Decimal)
    Public Property Expedition_Cost As Nullable(Of Decimal)
    Public Property Modification As Nullable(Of Decimal)
    Public Property GPS_Cost As Nullable(Of Decimal)
    Public Property Agent_Fee As Nullable(Of Decimal)
    Public Property Keur As Nullable(Of Decimal)
    Public Property IRR As Nullable(Of Decimal)
    Public Property IRRApp As Nullable(Of Decimal)
    Public ReadOnly Property IRRAppColor() As String
        Get
            Return If(If(IRR, 0) >= If(IRRApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Profit As Nullable(Of Decimal)
    Public Property ProfitApp As Nullable(Of Decimal)
    Public ReadOnly Property ProfitAppColor() As String
        Get
            Return If(If(Profit, 0) >= If(ProfitApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Spread As Nullable(Of Decimal)
    Public Property SpreadApp As Nullable(Of Decimal)
    Public ReadOnly Property SpreadAppColor() As String
        Get
            Return If(If(Spread, 0) >= If(SpreadApp, 0), Right, Wrong)
        End Get
    End Property
    Public Property Transaction_Type As String
    Public Property Funding_Rate As Nullable(Of Decimal)
    Public Property Funding_RateApp As Nullable(Of Decimal)
    Public ReadOnly Property Funding_RateAppColor() As String
        Get
            Return If(If(Funding_Rate, 0) >= If(Funding_RateApp, 0), Right, Wrong)
        End Get
    End Property

    Public ReadOnly Property Wrong() As String
        Get
            Return "#fad4d4"
        End Get
    End Property
    Public ReadOnly Property Right() As String
        Get
            Return "#e7ffd9"
        End Get
    End Property

End Class