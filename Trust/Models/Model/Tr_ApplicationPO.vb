Imports System.ComponentModel.DataAnnotations

Public Class Tr_ApplicationPO
    Public Property ApplicationPO_ID As Integer
    <Display(Name:="ApplicationPO No")>
    Public Property ApplicationPO_No As String
    <Display(Name:="Company Name")>
    Public Property CompanyName As String
    Public Property No_Ref As String
    Public Property Vehicle As String
    Public Property ProspectCustomer_ID As Integer
    Public Property ProspectCustomerDetail_ID As Integer
    <Required>
    Public Property Color As String
    <Required>
    <Display(Name:="Delivery Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Delivery_Date As Nullable(Of Date)
    Public Property Usage As String
    <Required>
    Public Property Qty As Nullable(Of Integer)
    <Display(Name:="Qty App PO")>
    Public Property QtyAppPO As Nullable(Of Integer)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Refund As Nullable(Of Decimal)
    Public ReadOnly Property RefundStr() As String
        Get
            Return String.Format("{0:n}", Refund)
        End Get
    End Property
    <Display(Name:="Payment By User")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property PaymentByUser As Nullable(Of Decimal)
    Public ReadOnly Property PaymentByUserStr() As String
        Get
            Return String.Format("{0:n}", PaymentByUser)
        End Get
    End Property
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Plat Location")>
    Public Property Plat_Location_ID As Nullable(Of Integer)
    <Display(Name:="Plat Status")>
    Public Property Plat_Status As String
    Public Property Note1 As String
    Public Property Note2 As String


    'deltail
    <Display(Name:="Dealer")>
    Public Property Dealer_ID As Nullable(Of Integer)
    <Display(Name:="OTR Price")>
    Public Property OTR_Price As Nullable(Of Decimal)
    Public Property Discount As Nullable(Of Decimal)
    Public Property Status As String
    <Display(Name:="Tambahan Aksesoris")>
    Public Property Aksesoris As String
    Public Property Comment As String

    <Display(Name:="OTR Price Calculate")>
    Public Property OTR_Price_Cal As Nullable(Of Decimal)
    Public ReadOnly Property OTR_Price_CalStr() As String
        Get
            Return String.Format("{0:n}", OTR_Price_Cal)
        End Get
    End Property

    <Display(Name:="Discount Calculate")>
    Public Property Discount_Cal As Nullable(Of Decimal)
    Public ReadOnly Property Discount_CalStr() As String
        Get
            Return String.Format("{0:n}", Discount_Cal)
        End Get
    End Property

    'dari ProspectCustomer
    Public Property IsApplicationPO As Boolean
    Public Property IsNotApproved As Boolean
    <Display(Name:="Remark Not Approved")>
    Public Property RemarkNotApproved As String

    Public Property Quotation_ID As String

    Public ReadOnly Property Pdf As String
        Get
            Return Quotation_ID.ToString + ".pdf"
        End Get
    End Property

    Public Property Detail As IEnumerable(Of Tr_ApplicationPODetail)
End Class

Public Class Tr_ApplicationPODetail
    Public Property ApplicationPODetail_ID As Nullable(Of Integer)
    Public Property ApplicationPO_ID As Nullable(Of Integer)
    Public Property Dealer_ID As Nullable(Of Integer)
    Public Property Dealer As String
    <Display(Name:="OTR Price")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property OTR_Price As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Discount As Nullable(Of Decimal)
    Public Property Status As String
    Public Property IsChecked As Boolean



End Class
