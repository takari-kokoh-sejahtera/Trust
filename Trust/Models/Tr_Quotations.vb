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

Partial Public Class Tr_Quotations
    Public Property Quotation_ID As Integer
    Public Property ProspectCustomer_ID As Nullable(Of Integer)
    Public Property No_Ref As String
    Public Property Quotation_Validity As Nullable(Of Integer)
    Public Property IsDriver As Nullable(Of Boolean)
    Public Property DriverQty As Nullable(Of Integer)
    Public Property DriverAmount As Nullable(Of Decimal)
    Public Property IsApplication As Nullable(Of Boolean)
    Public Property THU As Nullable(Of Integer)
    Public Property Record_For_Payment As String
    Public Property Remark As String
    Public Property RemarkInternal As String
    Public Property IsPO As Nullable(Of Boolean)
    Public Property POBy As Nullable(Of Integer)
    Public Property Signer_ID As Nullable(Of Integer)
    Public Property IsNotApproved As Nullable(Of Boolean)
    Public Property RemarkNotApproved As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)

    Public Overridable Property Cn_Users As Cn_Users
    Public Overridable Property Cn_Users1 As Cn_Users
    Public Overridable Property Cn_Users2 As Cn_Users
    Public Overridable Property Ms_Contract_Signers As Ms_Contract_Signers
    Public Overridable Property Tr_Approvals As ICollection(Of Tr_Approvals) = New HashSet(Of Tr_Approvals)
    Public Overridable Property Tr_QuotationDetails As ICollection(Of Tr_QuotationDetails) = New HashSet(Of Tr_QuotationDetails)
    Public Overridable Property Tr_QuotationDetails1 As ICollection(Of Tr_QuotationDetails) = New HashSet(Of Tr_QuotationDetails)
    Public Overridable Property Tr_ProspectCusts As Tr_ProspectCusts

End Class
