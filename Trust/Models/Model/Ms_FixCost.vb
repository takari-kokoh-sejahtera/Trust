Imports System.ComponentModel.DataAnnotations

Public Class Ms_FixCost
    Public Property FixCost_ID As Integer
    <Required>
    Public Property FixCost_Name As String
    <Required>
    <Range(0, 100)>
    Public Property Replacement As Decimal
    <Required>
    <Range(0, 100)>
    Public Property Maintenance As Decimal
    <Required>
    <Range(0, 100)>
    Public Property Stnk As Decimal
    <Required>
    <Range(0, 100)>
    Public Property Overhead As Decimal
    <Required>
    <Range(0, 100)>
    Public Property Insurance As Decimal
    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)


End Class
