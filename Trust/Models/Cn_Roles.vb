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

Partial Public Class Cn_Roles
    Public Property Role_ID As Integer
    Public Property Role_Name As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)

    Public Overridable Property Cn_RoleAuthorizations As ICollection(Of Cn_RoleAuthorizations) = New HashSet(Of Cn_RoleAuthorizations)
    Public Overridable Property Cn_RoleAuthorizations1 As ICollection(Of Cn_RoleAuthorizations) = New HashSet(Of Cn_RoleAuthorizations)
    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Cn_Users2 As ICollection(Of Cn_Users) = New HashSet(Of Cn_Users)

End Class
