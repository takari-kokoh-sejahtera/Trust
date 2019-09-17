Imports System.ComponentModel.DataAnnotations

Public Class Ms_Vehicle
    Public Property Vehicle_id As Integer
    Public Property ContractDetail_ID As Nullable(Of Integer)
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String

    <Display(Name:="License No")>
    Public Property license_no As String
    <Display(Name:="Temp Plat")>
    Public Property Tmp_Plat As String
    <Display(Name:="Brand")>
    Public Property Brand_ID As Nullable(Of Integer)
    <Display(Name:="Brand")>
    Public Property Brand_Name As String
    <Display(Name:="Model ID")>
    <Required>
    Public Property Model_ID As Nullable(Of Integer)
    <Display(Name:="Model")>
    Public Property Model As String
    <Display(Name:="Type")>
    Public Property type As String
    <Display(Name:="Color")>
    Public Property color As String
    <Display(Name:="Year")>
    Public Property year As Nullable(Of Integer)
    <Display(Name:="Chassis No")>
    Public Property chassis_no As String
    <Display(Name:="Machine No")>
    Public Property machine_no As String
    <Display(Name:="Title No")>
    Public Property title_no As String
    <Display(Name:="Serial No")>
    Public Property serial_no As String
    <Display(Name:="Registration No")>
    Public Property registration_no As String
    <DataType(DataType.Date)>
    <Display(Name:="Registration Expdate")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property registration_expdate As Nullable(Of Date)
    <Display(Name:="Insurance No")>
    Public Property insurance_no As String

    Private _discount As Nullable(Of Decimal)
    <Display(Name:="Discount")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property discount As Nullable(Of Decimal)
        Get
            Return _discount
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _discountStr = CType(If(value, 0), Nullable(Of Double))
            _discount = value
        End Set
    End Property
    Private _discountStr As String
    Public Property discountStr As String
        Get
            Return _discountStr
        End Get
        Set(ByVal value As String)
            _discount = Val(If(value, "0").Replace(",", ""))
            _discountStr = value
        End Set
    End Property

    Private _price As Nullable(Of Decimal)
    <Display(Name:="Price")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property price As Nullable(Of Decimal)
        Get
            Return _price
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _priceStr = CType(If(value, 0), Nullable(Of Double))
            _price = value
        End Set
    End Property
    Private _priceStr As String
    Public Property priceStr As String
        Get
            Return _priceStr
        End Get
        Set(ByVal value As String)
            _price = Val(If(value, "0").Replace(",", ""))
            _priceStr = value
        End Set
    End Property

    Private _acquisition As Nullable(Of Decimal)
    <Display(Name:="Acquisition")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property acquisition As Nullable(Of Decimal)
        Get
            Return _acquisition
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _acquisitionStr = CType(If(value, 0), Nullable(Of Double))
            _acquisition = value
        End Set
    End Property
    Private _acquisitionStr As String
    Public Property acquisitionStr As String
        Get
            Return _acquisitionStr
        End Get
        Set(ByVal value As String)
            _acquisition = Val(If(value, "0").Replace(",", ""))
            _acquisitionStr = value
        End Set
    End Property

    Private _coverage As Nullable(Of Decimal)
    <Display(Name:="Coverage")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property coverage As Nullable(Of Decimal)
        Get
            Return _coverage
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _coverageStr = CType(If(value, 0), Nullable(Of Double))
            _coverage = value
        End Set
    End Property
    Private _coverageStr As String
    Public Property coverageStr As String
        Get
            Return _coverageStr
        End Get
        Set(ByVal value As String)
            _coverage = Val(If(value, "0").Replace(",", ""))
            _coverageStr = value
        End Set
    End Property
    <Display(Name:="Comment")>
    Public Property comment As String
    <DataType(DataType.Date)>
    <Display(Name:="Date Insurance Start")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property date_insurance_start As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="Date Insurance End")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property date_insurance_end As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="Date Insurance Mod")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property date_insurance_mod As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="Date Book")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property date_book As Nullable(Of Date)
    <Display(Name:="STNK No")>
    Public Property STNK_No As String
    <DataType(DataType.Date)>
    <Display(Name:="STNK Publish")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property STNK_Publish As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="STNK Yearly Renewal")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property STNK_Yearly_Renewal As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="STNK 5Year Renewal")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property STNK_5Year_Renewal As Nullable(Of Date)
    <Display(Name:="STNK Month")>
    Public Property STNK_Month As Nullable(Of Integer)
    <Display(Name:="STNK Name")>
    Public Property STNK_Name As String
    <Display(Name:="STNK Address")>
    Public Property STNK_Address As String
    <Display(Name:="CC")>
    Public Property CC As Nullable(Of Integer)
    <Display(Name:="Fuel")>
    Public Property Fuel As String
    <Display(Name:="No Urut Buku")>
    Public Property NoUrutBuku As String
    <DataType(DataType.Date)>
    <Display(Name:="DO Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DO_date As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="Vehicle Come")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Vehicle_Come As Nullable(Of Date)
    <DataType(DataType.Date)>
    <Display(Name:="STNK Receipt")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property STNK_Receipt As Nullable(Of Date)
    <Display(Name:="PO No")>
    Public Property PO_No As String
    Public Property _harga_Beli As Nullable(Of Decimal)
    <Display(Name:="Harga Beli")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Harga_Beli As Nullable(Of Decimal)
        Get
            Return _harga_Beli
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _Harga_BeliStr = CType(If(value, 0), Nullable(Of Double))
            _harga_Beli = value
        End Set
    End Property
    Private _harga_BeliStr As String
    Public Property Harga_BeliStr As String
        Get
            Return _harga_BeliStr
        End Get
        Set(ByVal value As String)
            _harga_Beli = Val(If(value, "0").Replace(",", ""))
            _harga_BeliStr = value
        End Set
    End Property
    <DataType(DataType.Date)>
    <Display(Name:="Kwitansi Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Kwitansi_Date As Nullable(Of Date)
    <Display(Name:="Kwitansi No")>
    Public Property Kwitansi_No As String
    <DataType(DataType.Date)>
    <Display(Name:="Faktur Pajak")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FakturPajak As Nullable(Of Date)
    <Display(Name:="Faktur Pajak No")>
    Public Property FakturPajak_No As String
    <Display(Name:="VAT")>
    Public Property VAT As String
    <Display(Name:="Dealer")>
    Public Property Dealer As String
    <DataType(DataType.Date)>
    <Display(Name:="Created Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <DataType(DataType.Date)>
    <Display(Name:="Modified Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Nullable(Of Boolean)

End Class
