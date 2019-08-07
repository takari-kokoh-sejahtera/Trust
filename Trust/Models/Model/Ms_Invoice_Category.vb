Imports System.ComponentModel.DataAnnotations

Public Class Ms_Invoice_Category
    Public Property Invoice_Category_ID As Integer
    <Required>
    <Display(Name:="Category Name")>
    Public Property Invoice_Category_Name As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As String
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As String
End Class
