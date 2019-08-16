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

    Partial Public Class Tr_ApplicationHeaders
        Public Property ApplicationHeader_ID As Integer
        Public Property Approval_ID As Nullable(Of Integer)
        Public Property Application_No As String
        Public Property Contract_No As String
        Public Property Credit_Rating As String
        Public Property Contracted_by As String
        Public Property Customer_Class As String
        Public Property Line_of_Business As String
        Public Property Authorized_Capital As Nullable(Of Decimal)
        Public Property Authorized_Signer_Name1 As String
        Public Property Authorized_Signer_Position1 As String
        Public Property Authorized_Signer_Name2 As String
        Public Property Authorized_Signer_Position2 As String
        Public Property IntroducedBy As String
        Public Property Expec_Contract_Date As Nullable(Of Date)
        Public Property Outstanding_Balance_Application As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Group As Nullable(Of Decimal)
        Public Property Outstanding_Balance_MUL_Group As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Amount As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Transaction_FL As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Application_FL As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Group_FL As Nullable(Of Decimal)
        Public Property Outstanding_Balance_MUL_Group_FL As Nullable(Of Decimal)
        Public Property Outstanding_Balance_Amount_FL As Nullable(Of Decimal)
        Public Property Run_Application As Nullable(Of Integer)
        Public Property RunContractCompany As Nullable(Of Integer)
        Public Property RunContractGroup As Nullable(Of Integer)
        Public Property Run_Transaction_FL As Nullable(Of Integer)
        Public Property Run_Application_FL As Nullable(Of Integer)
        Public Property RunContractCompany_FL As Nullable(Of Integer)
        Public Property RunContractGroup_FL As Nullable(Of Integer)
        Public Property ApplicationType As String
        Public Property Remark As String
        Public Property IsTruck As Nullable(Of Boolean)
        Public Property IsQuick As Nullable(Of Boolean)
        Public Property IsNotApproved As Nullable(Of Boolean)
        Public Property RemarkNotApproved As String
        Public Property CreatedDate As Date
        Public Property CreatedBy As Integer
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Boolean
    
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
        Public Overridable Property Tr_Applications As ICollection(Of Tr_Applications) = New HashSet(Of Tr_Applications)
        Public Overridable Property Tr_Approvals As Tr_Approvals
        Public Overridable Property Tr_ApprovalApps As ICollection(Of Tr_ApprovalApps) = New HashSet(Of Tr_ApprovalApps)
    
    End Class

End Namespace
