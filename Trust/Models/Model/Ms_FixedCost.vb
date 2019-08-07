Imports System.ComponentModel.DataAnnotations

Public Class Ms_FixedCost
    Public Property FixedCost_ID As Integer
    <Required>
    <Display(Name:="STNK Percent")>
    Public Property STNK_Percent As Decimal
    <Required>
    <Display(Name:="Overhead Percent")>
    Public Property Overhead_Percent As Decimal
    <Required>
    <Display(Name:="Assurance Percent")>
    Public Property Assurance_Percent As Decimal
    <Required>
    <Display(Name:="OJK")>
    Public Property OJK As Decimal
    Public Property CreatedDate As Date
    Public Property CreatedBy As String
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As String
    Public Property IsDeleted As Boolean
End Class
