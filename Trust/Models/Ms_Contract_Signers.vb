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

Partial Public Class Ms_Contract_Signers
    Public Property Signer_ID As Integer
    Public Property Name As String
    Public Property Title_Ind As String
    Public Property Title_Eng As String
    Public Property Sex As Boolean
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Tr_Quotations As ICollection(Of Tr_Quotations) = New HashSet(Of Tr_Quotations)

End Class
