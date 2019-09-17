Imports System.ComponentModel.DataAnnotations
Public Class Tr_ApplicationPO_InputAsset
    <Key>
    Public Property ApplicationPO_ID As Nullable(Of Integer)

    <Display(Name:="CompanyGroup Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Dealer As String
    Public Property Company_Name As String
    <Display(Name:="Brand")>
    Public Property Brand_Name As String
    Public Property Qty As Nullable(Of Integer)
    <Display(Name:="Qty Input")>
    Public Property QtyInput As Nullable(Of Integer)
    <Display(Name:="Model")>
    Public Property Vehicle As String

    <Display(Name:="License No")>
    Public Property license_no As String
    <Display(Name:="Delivery Date")>
    <DataType(DataType.Date)>
    Public Property Delivery_Date As Nullable(Of DateTime)
    Public ReadOnly Property Aging() As Nullable(Of Integer)
        Get
            If Delivery_Date Is Nothing Then
                Return 0
            End If
            Dim ts = New TimeSpan
            ts = CType(Delivery_Date, DateTime).Subtract(DateTime.Now)
            Return ts.Days
        End Get
    End Property

    <Display(Name:="Is Temporary Car")>
    Public Property IsTemporaryCar As Nullable(Of Boolean)

    Public Property Contract_ID As Nullable(Of Integer)
    Public Property QuotationDetail_ID As Nullable(Of Integer)
    Public Property DeliveryDate As Nullable(Of Date)
    Public Property Delivery As String
    Public Property StartDate As Nullable(Of Date)
    Public Property Start As String
    Public Property EndDate As Nullable(Of Date)
    Public Property Ends As String
    Public Property Remark As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property IsSetDelivery As Nullable(Of Boolean)

End Class
