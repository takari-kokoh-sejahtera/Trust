Imports System.ComponentModel.DataAnnotations

Public Class Ms_Vehicle_Brand
    Public Property Brand_ID As Integer
    <Required>
    Public Property Brand_Name As String
    Public Property Description As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

End Class
