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

Partial Public Class Ms_Customer_BusinessLicenses
    Public Property BusinessLicense_ID As Integer
    Public Property BusinessLicense As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

    Public Overridable Property Ms_Customer_KYCs As ICollection(Of Ms_Customer_KYCs) = New HashSet(Of Ms_Customer_KYCs)
    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users

End Class
