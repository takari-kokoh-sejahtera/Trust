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

    Partial Public Class Cn_Levels
        Public Property Level_ID As Integer
        Public Property Level As Nullable(Of Integer)
        Public Property Remark As String
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Cn_Approvals As ICollection(Of Cn_Approvals) = New HashSet(Of Cn_Approvals)
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
    
    End Class

End Namespace
