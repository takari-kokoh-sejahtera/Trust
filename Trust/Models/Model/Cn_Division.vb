Imports System.ComponentModel.DataAnnotations

Public Class Cn_Division
    Public Property Division_ID As Integer
    <Required>
    Public Property GM_ID As Nullable(Of Integer)
    <Required>
    Public Property Division As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property ModifiedBy As Nullable(Of Integer)
End Class
