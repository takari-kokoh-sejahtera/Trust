Imports System.ComponentModel.DataAnnotations

Public Class Ms_CustomerPublisher
    Public Property Customer_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Required>
    <Display(Name:="Published")>
    <Range(1, 32)>
    Public Property Published As Nullable(Of Integer)

End Class
