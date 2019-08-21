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

    Partial Public Class Tr_Approvals
        Public Property Approval_ID As Integer
        Public Property Quotation_ID As Nullable(Of Integer)
        Public Property MakerDate As Nullable(Of Date)
        Public Property MakerBy As Nullable(Of Integer)
        Public Property MakerRemark As String
        Public Property CheckerDate As Nullable(Of Date)
        Public Property CheckerBy As Nullable(Of Integer)
        Public Property CheckerRemark As String
        Public Property Approval1Date As Nullable(Of Date)
        Public Property Approval1By As Nullable(Of Integer)
        Public Property Approval1Remark As String
        Public Property Approval2Date As Nullable(Of Date)
        Public Property Approval2By As Nullable(Of Integer)
        Public Property Approval2Remark As String
        Public Property Approval3Date As Nullable(Of Date)
        Public Property Approval3By As Nullable(Of Integer)
        Public Property Approval3Remark As String
        Public Property Approval4Date As Nullable(Of Date)
        Public Property Approval4By As Nullable(Of Integer)
        Public Property Approval4Remark As String
        Public Property Approval5Date As Nullable(Of Date)
        Public Property Approval5By As Nullable(Of Integer)
        Public Property Approval5Remark As String
        Public Property StatusRecord As Nullable(Of Integer)
        Public Property Status As String
        Public Property RemarkNotApprove As String
        Public Property IsApplicationHeader As Nullable(Of Boolean)
        Public Property IsApplicationHeaderDone As Nullable(Of Boolean)
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
        Public Overridable Property Cn_Users2 As Cn_Users
        Public Overridable Property Cn_Users3 As Cn_Users
        Public Overridable Property Cn_Users4 As Cn_Users
        Public Overridable Property Cn_Users5 As Cn_Users
        Public Overridable Property Cn_Users6 As Cn_Users
        Public Overridable Property Cn_Users7 As Cn_Users
        Public Overridable Property Cn_Users8 As Cn_Users
        Public Overridable Property Tr_Quotations As Tr_Quotations
        Public Overridable Property Tr_ApplicationHeaders As ICollection(Of Tr_ApplicationHeaders) = New HashSet(Of Tr_ApplicationHeaders)
        Public Overridable Property Tr_Applications As ICollection(Of Tr_Applications) = New HashSet(Of Tr_Applications)
    
    End Class

End Namespace
