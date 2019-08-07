Imports System.ComponentModel.DataAnnotations

Public Class Tr_Application



    Public Property pdf As String



    Public Property Approve As Nullable(Of Boolean)
    Public Property CreatedDateApp As Nullable(Of Date)


    <Display(Name:="Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Vehicle As String
    Private _lease_price As Nullable(Of Decimal)
    <Display(Name:="Lease Price")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Lease_price As Nullable(Of Decimal)
        Get
            Return _lease_price
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _lease_pricestr = CType(If(value, 0), Nullable(Of Double))
            _lease_price = value
        End Set
    End Property
    Private _lease_pricestr As String
    Public Property Lease_pricestr As String
        Get
            Return _lease_pricestr
        End Get
        Set(ByVal value As String)
            Lease_price = Val(If(value, "0").Replace(",", ""))
            _lease_pricestr = value
        End Set
    End Property
    Public Property Qty As Nullable(Of Integer)
    Private _amount As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Amount As Nullable(Of Decimal)
        Get
            Return _amount
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _amountstr = CType(If(value, 0), Nullable(Of Double))
            _amount = value
        End Set
    End Property
    Private _amountstr As String
    Public Property Amountstr As String
        Get
            Return _amountstr
        End Get
        Set(ByVal value As String)
            Amount = Val(If(value, "0").Replace(",", ""))
            _amountstr = value
        End Set
    End Property


    Public Property Agent_FeeStat As Nullable(Of Boolean)
    Public Property IsCOP As Nullable(Of Boolean)

    Public Property Transaction_Type As String
    Public Property Brand_Name As String
    Public Property Color As String
    Public Property Expec_Delivery_DateStr As String
    Public Property Expec_Delivery_Date As Nullable(Of Date)
    Public Property Application_ID As Integer
    Public Property Approval_ID As Integer
    Public Property IsPO As Boolean
    <Display(Name:="PO From Customer")>
    Public Property POFromCustomer As String
    Public Property QuotationDetail_ID As Integer
    Public Property Rent_Location_ID As Nullable(Of Integer)
    Public Property Plat_Location As Nullable(Of Integer)
    Public Property Payment_Condition As String
    Public Property Modification As Nullable(Of Decimal)
    Public Property GPS_Cost As Nullable(Of Decimal)
    Public Property GPS_CostPerMonth As Nullable(Of Integer)
    Public Property Agent_Fee As Nullable(Of Decimal)
    Public Property Agent_FeePerMonth As Nullable(Of Integer)
    Private _update_OTR As Nullable(Of Decimal)
    <Required>
    <Display(Name:="Update OTR")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Update_OTR As Nullable(Of Decimal)
        Get
            Return _update_OTR
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _update_OTRstr = CType(If(value, 0), Nullable(Of Double))
            _update_OTR = value
        End Set
    End Property
    Private _update_OTRstr As String
    Public Property Update_OTRstr As String
        Get
            Return _update_OTRstr
        End Get
        Set(ByVal value As String)
            Update_OTR = Val(If(value, "0").Replace(",", ""))
            _update_OTRstr = value
        End Set
    End Property

    Public Property Residual_Value As Nullable(Of Decimal)
    Public Property Residual_ValuePercent As Nullable(Of Decimal)
    Public Property Expedition_Cost As Nullable(Of Decimal)
    Public Property Keur As Nullable(Of Decimal)
    Public Property _update_Diskon As Nullable(Of Decimal)
    <Required>
    <Display(Name:="Update Diskon")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Update_Diskon As Nullable(Of Decimal)
        Get
            Return _update_Diskon
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _update_Diskonstr = CType(If(value, 0), Nullable(Of Double))
            _update_Diskon = value
        End Set
    End Property
    Private _update_Diskonstr As String
    Public Property Update_Diskonstr As String
        Get
            Return _update_Diskonstr
        End Get
        Set(ByVal value As String)
            Update_Diskon = Val(If(value, "0").Replace(",", ""))
            _update_Diskonstr = value
        End Set
    End Property
    Public Property Cost_Price As Nullable(Of Decimal)
    Public Property Up_Front_Fee As Nullable(Of Decimal)
    Public Property Up_Front_Fee_Percent As Nullable(Of Decimal)
    Public Property Other As Nullable(Of Decimal)
    Public Property Efektif_Date As Nullable(Of Date)
    Public Property Replacement_Percent As Nullable(Of Decimal)
    Public Property Replacement As Nullable(Of Decimal)
    Public Property Maintenance_Percent As Nullable(Of Decimal)
    Public Property Maintenance As Nullable(Of Decimal)
    Public Property STNK_Percent As Nullable(Of Decimal)
    Public Property STNK As Nullable(Of Decimal)
    Public Property Overhead_Percent As Nullable(Of Decimal)
    Public Property Overhead As Nullable(Of Decimal)
    Public Property Assurance_Percent As Nullable(Of Decimal)
    Public Property Assurance As Nullable(Of Decimal)
    Public Property Lease_Profit As Nullable(Of Decimal)
    Public Property Lease_Profit_Percent As Nullable(Of Double)
    Public Property Depresiasi As Nullable(Of Decimal)
    Public Property Depresiasi_Percent As Nullable(Of Decimal)
    Public Property Funding_Interest As Nullable(Of Decimal)
    Public Property Funding_Interest_Percent As Nullable(Of Decimal)
    Private _bid_PricePerMonth As Nullable(Of Decimal)
    <Display(Name:="Bid Price Per Month")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Bid_PricePerMonth As Nullable(Of Decimal)
        Get
            Return _bid_PricePerMonth
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _bid_PricePerMonthstr = CType(If(value, 0), Nullable(Of Double))
            _bid_PricePerMonth = value
        End Set
    End Property
    Private _bid_PricePerMonthstr As String
    Public Property Bid_PricePerMonthstr As String
        Get
            Return _bid_PricePerMonthstr
        End Get
        Set(ByVal value As String)
            Bid_PricePerMonth = Val(If(value, "0").Replace(",", ""))
            _bid_PricePerMonthstr = value
        End Set
    End Property
    Public Property IRR As Nullable(Of Decimal)
    Public Property Funding_Rate As Nullable(Of Decimal)
    Public Property Spread As Nullable(Of Decimal)
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property Payee As String
    Public Property PayeeRemark As String
    Public Property Purchaser As String
    Public Property Purchase_Type As String
    Public Property Project_Rating As String
    Public Property Asset_Rating As Nullable(Of Integer)

    Public Property IsVehicleExists As Nullable(Of Boolean)
    Public Property THU As Nullable(Of Integer)
    Public Property Code_Open As String

End Class
