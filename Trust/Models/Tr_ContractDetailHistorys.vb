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

    Partial Public Class Tr_ContractDetailHistorys
        Public Property ContractDetailHistory_ID As Integer
        Public Property ContractDetail_ID As Nullable(Of Integer)
        Public Property Vehicle_ID As Nullable(Of Integer)
        Public Property ID As Nullable(Of Integer)
        Public Property Status As String
        Public Property [Date] As Nullable(Of Date)
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Tr_ContractDetails As Tr_ContractDetails
        Public Overridable Property Ms_Vehicles As Ms_Vehicles
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
    
    End Class

End Namespace
