Imports System.ComponentModel.DataAnnotations

Public Class Tr_Invoice

    Public Property CreateInvoice_ID As Integer
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="User")>
    Public Property User_Car As String
    <Display(Name:="Area")>
    Public Property City_ID As String
    <Display(Name:="Signature Name")>
    Public Property Signature_ID As Nullable(Of Integer)
    Public Property Customer_ID As Nullable(Of Integer)
    Public Property Status As String
    <Display(Name:="From Date")>
    <Required>
    <DataType(DataType.Date)>
    Public Property From_Date As Nullable(Of Date)
    <Display(Name:="Published Date")>
    <Required>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Published_Date As Nullable(Of Date)
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As Integer
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As Nullable(Of Integer)

    Public Property PerMonth As Nullable(Of Integer)

    Public Property Invoice_ID As Integer
    Public Property Contract_ID As Nullable(Of Integer)
    <Display(Name:="Invoice No")>
    Public Property Invoice_No As String
    Public Property Address As String
    Public Property NPWP As String
    Public Property Account As String
    Public Property Bank As String
    Public Property Contracted_by As String
    Public Property IsStamped As Nullable(Of Boolean)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Sub_Total As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property VAT As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Stamp As Nullable(Of Decimal)
    Private _total As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Total As Nullable(Of Decimal)
        Get
            Return _total
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _totalStr = CType(If(value, 0), Nullable(Of Double))
            _total = value
        End Set
    End Property
    Private _totalStr As String
    Public Property TotalStr As String
        Get
            Return _totalStr
        End Get
        Set(ByVal value As String)
            _total = Val(If(value, "0").Replace(",", ""))
            _totalStr = value
        End Set
    End Property
    Public Property IsPrined As Nullable(Of Boolean)
    Public Property PrinedBy As Integer
    Public Property IsPayed As Nullable(Of Boolean)
    Public Property PayedBy As Integer
End Class
