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

    Partial Public Class Ms_Customer_CompanyGroups
        Public Property CompanyGroup_ID As Integer
        Public Property CompanyGroup_Name As String
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
        Public Overridable Property Ms_Customers As ICollection(Of Ms_Customers) = New HashSet(Of Ms_Customers)
        Public Overridable Property Tr_ProspectCusts As ICollection(Of Tr_ProspectCusts) = New HashSet(Of Tr_ProspectCusts)
    
    End Class

End Namespace
