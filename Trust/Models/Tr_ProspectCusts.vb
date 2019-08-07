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

Partial Public Class Tr_ProspectCusts
    Public Property ProspectCustomer_ID As Integer
    Public Property IsExists As Boolean
    Public Property CustomerExists_ID As Nullable(Of Integer)
    Public Property CompanyGroup_ID As Nullable(Of Integer)
    Public Property Company_Name As String
    Public Property PT As String
    Public Property Tbk As Nullable(Of Boolean)
    Public Property Address As String
    Public Property City_id As Nullable(Of Integer)
    Public Property Phone As String
    Public Property Email As String
    Public Property PIC_Name As String
    Public Property PIC_Phone As String
    Public Property PIC_Email As String
    Public Property Credit_Rating As String
    Public Property Status As String
    Public Property Notes As String
    Public Property IsQuotation As Nullable(Of Boolean)
    Public Property IsApplicationPO As Nullable(Of Boolean)
    Public Property PO_No As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Ms_Citys As Ms_Citys
    Public Overridable Property Ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups
    Public Overridable Property Ms_Customers As Ms_Customers
    Public Overridable Property Tr_ApprovalPOs As ICollection(Of Tr_ApprovalPOs) = New HashSet(Of Tr_ApprovalPOs)
    Public Overridable Property Tr_ProspectCustDetails As ICollection(Of Tr_ProspectCustDetails) = New HashSet(Of Tr_ProspectCustDetails)
    Public Overridable Property Tr_ProspectCustHistorys As ICollection(Of Tr_ProspectCustHistorys) = New HashSet(Of Tr_ProspectCustHistorys)
    Public Overridable Property Tr_Quotations As ICollection(Of Tr_Quotations) = New HashSet(Of Tr_Quotations)
    Public Overridable Property Tr_ApplicationPOs As ICollection(Of Tr_ApplicationPOs) = New HashSet(Of Tr_ApplicationPOs)

End Class
