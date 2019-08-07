Imports System.ComponentModel.DataAnnotations

Public Class Tr_InvoiceDetail
    Public Property InvoiceDetail_ID As Integer
    Public Property Invoice_ID As Nullable(Of Integer)
    Public Property ContractDetail_ID As Nullable(Of Integer)

    Public Property Brand_Name As String
    Public Property Type As String
    Public Property license_no As String
    Public Property Bid_PricePerMonth As Nullable(Of Decimal)
    Public Property Vehicle_ID As Nullable(Of Integer)

    <Display(Name:="From Date")>
    Public Property From_Date As Nullable(Of Date)
    <Display(Name:="To Date")>
    Public Property To_Date As Nullable(Of Date)
    Public Property Amount As Nullable(Of Decimal)
    <Display(Name:="Lease Term")>
    Public Property Lease_Long As Nullable(Of Integer)
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As Integer
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As Nullable(Of Integer)
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Boolean
End Class
