Imports System.ComponentModel.DataAnnotations

Public Class Cn_Level
    Public Property Level_ID As Integer
    <Required>
    Public Property Level As Integer
    <Required>
    Public Property Remark As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property ModifiedBy As Nullable(Of Integer)
End Class
