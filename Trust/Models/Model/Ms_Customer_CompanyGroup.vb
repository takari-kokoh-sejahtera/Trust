Imports System.ComponentModel.DataAnnotations

Public Class Ms_Customer_CompanyGroup
    Public Property CompanyGroup_ID As Integer
    <Required>
    Public Property CompanyGroup_Name As String
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)

End Class
