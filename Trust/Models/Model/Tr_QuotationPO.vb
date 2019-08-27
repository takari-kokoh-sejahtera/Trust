Imports System.ComponentModel.DataAnnotations

Public Class Tr_QuotationPO
    <Required>
    Public Property Quotation_ID As Integer
    <Display(Name:="Prospect Customer")>
    Public Property ProspectCustomer_ID As Nullable(Of Integer)
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Company As String
    Public Property Address As String
    Public Property City As String
    Public Property Phone As String
    Public Property Email As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Phone")>
    Public Property PIC_Phone As String
    <Display(Name:="PIC Email")>
    Public Property PIC_Email As String
    <Display(Name:="No Ref")>
    Public Property No_Ref As String
    <Display(Name:="Quotation Validity")>
    Public Property Quotation_Validity As Nullable(Of Integer)
    <Display(Name:="Is Driver")>
    Public Property IsDriver As Boolean
    <Display(Name:="Driver Qty")>
    Public Property DriverQty As Nullable(Of Integer)
    <Display(Name:="Driver Amount")>
    Public Property DriverAmount As Nullable(Of Decimal)
    Private _driverAmountStr As String
    Public Property DriverAmountStr As String
        Get
            Return _driverAmountStr
        End Get
        Set(ByVal value As String)
            DriverAmount = Val(If(value, "0").Replace(",", ""))
            _driverAmountStr = value
        End Set
    End Property
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property IsApplication As Nullable(Of Boolean)

    <Required>
    Public Property THU As Nullable(Of Integer)
    <Required>
    <Display(Name:="TOP")>
    Public Property TOP_Value As Nullable(Of Integer)

    <Required>
    <Display(Name:="Record For Payment")>
    Public Property Record_For_Payment As String

    Public Property Detail As IEnumerable(Of Tr_QuotationDetailnya)
End Class
Public Class Tr_QuotationDetailnya
    Public Property QuotationDetail_ID As Integer
    Public Property Quotation_ID As Nullable(Of Integer)
    Public Property Calculate_ID As Nullable(Of Integer)
    Public Property Application_ID As Nullable(Of Integer)
    Public Property IsVehicleExists As Nullable(Of Boolean)
    Public Property Brand_Name As String
    Public Property Vehicle As String
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Lease_price As Nullable(Of Double)
    Public Property Qty As Nullable(Of Integer)
    Public Property Year As Nullable(Of Integer)
    Public Property Lease_long As Nullable(Of Integer)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Amount As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Bid_Price As Nullable(Of Double)
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property Check As Boolean
    <Required>
    Public Property Color As String
    Public Property disabled As String

End Class
Public Class Tr_QuotationJoin
    <Required>
    <Display(Name:="No Ref To")>
    Public Property ProspectCustomer_IDTo As Integer
    <Required>
    <Display(Name:="No Ref From")>
    Public Property ProspectCustomer_IDFrom As Integer

End Class
