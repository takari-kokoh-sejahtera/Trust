Imports System.ComponentModel.DataAnnotations

Public Class Tr_ContractGetDetail
    Public Property ContractDetail_ID As Integer
    Public Property Application_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Vehicle As String
    <Display(Name:="Rent Location")>
    Public Property Rent_Location As String
    <Display(Name:="Delivery Date")>
    Public Property DeliveryDate As String
    <Display(Name:="Lease long")>
    Public Property Lease_long As Nullable(Of Integer)
    <Display(Name:="Start Date")>
    Public Property StartDate As String
    <Display(Name:="End Date")>
    Public Property EndDate As String
    <Display(Name:="Bid Price PerMonth")>
    Public Property Bid_PricePerMonth As Nullable(Of Decimal)
    Public Property Remark As String

End Class
