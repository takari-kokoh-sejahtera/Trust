Imports System.ComponentModel.DataAnnotations

Public Class Ms_Customer
    Public Property Customer_ID As Integer
    <Required>
    Public Property CompanyGroup_ID As Nullable(Of Integer)
    <Display(Name:="Code Transaction")>
    Public Property CodeTransaction_ID As Nullable(Of Integer)
    <Required>
    Public Property Company_Name As String
    Public Property PT As String
    <Required>
    Public Property Tbk As Nullable(Of Boolean)
    <Required>
    Public Property Address As String
    Public Property City_ID As Nullable(Of Integer)
    <Required>
    Public Property Phone As String
    <Required>
    <DataType(DataType.EmailAddress)>
    Public Property Email As String
    <Required>
    Public Property PIC_Name As String
    <Required>
    Public Property PIC_Phone As String
    <Required>
    <DataType(DataType.EmailAddress)>
    Public Property PIC_Email As String
    Public Property Notes As String
    <Display(Name:="Customer Class")>
    Public Property Customer_Class As String
    <Required>
    <Display(Name:="Credit Rating")>
    Public Property Credit_Rating As String
    <Display(Name:="Line of Business")>
    Public Property Line_of_Business As String
    Private _authorized_Capital As Nullable(Of Decimal)
    <Display(Name:="Authorized Capital")>
    Public Property Authorized_Capital As Nullable(Of Decimal)
        Get
            Return _authorized_Capital
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _authorized_CapitalStr = CType(If(value, 0), Double)
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
    Public Property NPWP As String
    Public Property Account As String
    Public Property Bank As String
    <Display(Name:="Stamped")>
    Public Property IsStamped As Nullable(Of Boolean)
    Public Property Status As Nullable(Of Boolean)
    <Display(Name:="Published Date")>
    Public Property Published_Date As Nullable(Of Date)
    Public Property CreatedDate As Date
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

End Class
Public Class Ms_Customer_Combo
    <Required>
    Public Property Customer_ID As Integer
    <Required>
    Public Property Company_Name As String
End Class

Public Class Ms_Customer_ChangeOwnership
    <Required>
    <Display(Name:="Customer")>
    Public Property Customer_ID As Integer
    <Required>
    <Display(Name:="Customer Ownership")>
    Public Property CreatedBy As Integer
End Class