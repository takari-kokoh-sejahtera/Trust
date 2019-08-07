Imports System.ComponentModel.DataAnnotations

Public Class Tr_ApplicationPOFromCustomer

    Public Property IsVehicleExists As Nullable(Of Boolean)
    <Required>
    Public Property THU As Nullable(Of Integer)
    Public Property Color As String
    Public Property Application_ID As Integer
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
End Class
