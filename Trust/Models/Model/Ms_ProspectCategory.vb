Imports System.ComponentModel.DataAnnotations

Public Class Ms_ProspectCategory
    Public Property ProspectCategory_ID As Integer
    <Required>
    <Display(Name:="Prospect Category")>
    Public Property ProspectCategory As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    Public Property IsDeleted As Nullable(Of Boolean)


End Class
