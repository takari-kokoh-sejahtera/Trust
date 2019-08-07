Imports System.ComponentModel.DataAnnotations

Public Class Login
    Public Property User_ID As Integer
    Public Property NIK As String
    <Required>
    Public Property User_Name As String
    <Required>
    <DataType(DataType.Password)>
    Public Property Password As String
    Public Property Directorat_ID As Nullable(Of Integer)
    Public Property GM_ID As Nullable(Of Integer)
    Public Property Division_ID As Nullable(Of Integer)
    Public Property Title_ID As Nullable(Of Integer)
    Public Property Level_ID As Nullable(Of Integer)
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)
End Class
