'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Namespace Trust

    Partial Public Class Tr_Invoices
        Public Property Invoice_ID As Integer
        Public Property Contract_ID As Nullable(Of Integer)
        Public Property Customer_ID As Nullable(Of Integer)
        Public Property Invoice_No As String
        Public Property Address As String
        Public Property NPWP As String
        Public Property Account As String
        Public Property Bank As String
        Public Property Contracted_by As String
        Public Property IsStamped As Nullable(Of Boolean)
        Public Property Sub_Total As Nullable(Of Decimal)
        Public Property VAT As Nullable(Of Decimal)
        Public Property Stamp As Nullable(Of Decimal)
        Public Property Total As Nullable(Of Decimal)
        Public Property From_Date As Nullable(Of Date)
        Public Property Status As String
        Public Property PerMonth As Nullable(Of Integer)
        Public Property Published_Date As Nullable(Of Date)
        Public Property IsPrined As Nullable(Of Boolean)
        Public Property PrinedBy As Nullable(Of Integer)
        Public Property PrinedDate As Nullable(Of Date)
        Public Property IsPayed As Nullable(Of Boolean)
        Public Property PayedBy As Nullable(Of Integer)
        Public Property PayedDate As Nullable(Of Date)
        Public Property CreatedDate As Date
        Public Property CreatedBy As Integer
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Boolean
        Public Property City_ID As Nullable(Of Integer)
        Public Property User_Car As String
        Public Property Faktur_Pajak As String
        Public Property Signature_ID As Nullable(Of Integer)
    
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
        Public Overridable Property Cn_Users2 As Cn_Users
        Public Overridable Property Cn_Users3 As Cn_Users
        Public Overridable Property Cn_Users4 As Cn_Users
        Public Overridable Property Ms_Citys As Ms_Citys
        Public Overridable Property Tr_Contracts As Tr_Contracts
        Public Overridable Property Tr_InvoiceDetails As ICollection(Of Tr_InvoiceDetails) = New HashSet(Of Tr_InvoiceDetails)
        Public Overridable Property Ms_Customers As Ms_Customers
    
    End Class

End Namespace
