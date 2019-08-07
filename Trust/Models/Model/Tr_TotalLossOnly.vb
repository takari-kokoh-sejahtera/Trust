Imports System.ComponentModel.DataAnnotations

Public Class Tr_TotalLossOnly


    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    <Display(Name:="License No")>
    Public Property license_no As String
    <Display(Name:="From License No")>
    Public Property Fromlicense_no As String
    <Display(Name:="To License No")>
    Public Property Tolicense_no As String
    Public Property Type As String
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property IsDelivery As Nullable(Of Boolean)
    Public Property IsInvoiced As Nullable(Of Boolean)

    <Display(Name:="Contract")>
    Public Property Contract_ID As Nullable(Of Integer)

    Public Property TotalLossOnly_ID As Integer
    <Required>
    Public Property ContractDetail_ID As Nullable(Of Integer)
    <Required>
    <Display(Name:="Vehicle")>
    Public Property Vehicle_ID As Nullable(Of Integer)
    Public Property Remark As String
    <Required>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property [Date] As Nullable(Of Date)
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    Public Property IsEdited As Nullable(Of Boolean)

End Class

