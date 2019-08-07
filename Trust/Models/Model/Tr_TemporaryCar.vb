Imports System.ComponentModel.DataAnnotations

Public Class Tr_TemporaryCar


    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    <Display(Name:="License No")>
    Public Property license_no As String
    Public Property Type As String
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property IsDelivery As Nullable(Of Boolean)
    Public Property IsInvoiced As Nullable(Of Boolean)

    <Display(Name:="Contract")>
    Public Property Contract_ID As Nullable(Of Integer)

    Public Property TemporaryCar_ID As Integer
    <Required>
    <Display(Name:="ContractDetail ID")>
    Public Property ContractDetail_ID As Nullable(Of Integer)
    <Required>
    <Display(Name:="Vehicle ID")>
    Public Property Vehicle_ID As Nullable(Of Integer)
    Public Property Remark As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String



End Class
