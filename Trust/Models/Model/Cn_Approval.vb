Imports System.ComponentModel.DataAnnotations

Public Class Cn_Approval
    Public Property Approval_ID As Integer
    <Required>
    <Display(Name:="Approval")>
    Public Property Approval_Name As String
    <Required>
    <Display(Name:="Module")>
    Public Property Module_ID As Integer
    <Display(Name:="Module")>
    Public Property Modules As String
    <Required>
    <Display(Name:="Level")>
    Public Property Level_ID As Integer
    <Display(Name:="Level")>
    Public Property Level As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String


    Public Property Count As Integer

End Class
