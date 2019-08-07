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

Partial Public Class Ms_Customers
    Public Property Customer_ID As Integer
    Public Property CompanyGroup_ID As Nullable(Of Integer)
    Public Property Company_Name As String
    Public Property PT As String
    Public Property Tbk As Boolean
    Public Property Address As String
    Public Property City_ID As Nullable(Of Integer)
    Public Property Phone As String
    Public Property Email As String
    Public Property PIC_Name As String
    Public Property PIC_Phone As String
    Public Property PIC_Email As String
    Public Property Notes As String
    Public Property Customer_Class As String
    Public Property Credit_Rating As String
    Public Property Line_of_Business As String
    Public Property Authorized_Capital As Nullable(Of Decimal)
    Public Property Authorized_Signer_Name1 As String
    Public Property Authorized_Signer_Position1 As String
    Public Property Authorized_Signer_Name2 As String
    Public Property Authorized_Signer_Position2 As String
    Public Property IntroducedBy As String
    Public Property NPWP As String
    Public Property Account As String
    Public Property Bank As String
    Public Property IsStamped As Nullable(Of Boolean)
    Public Property Status As Nullable(Of Boolean)
    Public Property Published As Nullable(Of Integer)
    Public Property IsKYC As Nullable(Of Boolean)
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

    Public Overridable Property Ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups
    Public Overridable Property Tr_Invoices As ICollection(Of Tr_Invoices) = New HashSet(Of Tr_Invoices)
    Public Overridable Property Ms_Citys As Ms_Citys
    Public Overridable Property Ms_Customer_KYCs As ICollection(Of Ms_Customer_KYCs) = New HashSet(Of Ms_Customer_KYCs)
    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Tr_ProspectCusts As ICollection(Of Tr_ProspectCusts) = New HashSet(Of Tr_ProspectCusts)

End Class
