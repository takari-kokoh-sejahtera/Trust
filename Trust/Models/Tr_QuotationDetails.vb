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

Partial Public Class Tr_QuotationDetails
    Public Property QuotationDetail_ID As Integer
    Public Property Quotation_ID As Nullable(Of Integer)
    Public Property Calculate_ID As Nullable(Of Integer)
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)

    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Tr_Applications As ICollection(Of Tr_Applications) = New HashSet(Of Tr_Applications)
    Public Overridable Property Tr_Quotations As Tr_Quotations
    Public Overridable Property Tr_Quotations1 As Tr_Quotations
    Public Overridable Property Tr_Calculates As Tr_Calculates

End Class
