Imports System.ComponentModel.DataAnnotations

Public Class Ms_Vehicle_Model_Import
    Public Property Model_ID As Nullable(Of Integer)
    <Required>
    Public Property Brand_Name As String
    <Required>
    Public Property Type As String
    <Required>
    <Display(Name:="OTR Price")>
    Public Property OTR_Price As Nullable(Of Double)
    <Required>
    <Display(Name:="Normal Disc")>
    Public Property Normal_Disc As Nullable(Of Double)
    <Required>
    Public Property Year1 As Nullable(Of Integer)
    <Required>
    Public Property Year2 As Nullable(Of Integer)
    <Required>
    Public Property Year3 As Nullable(Of Integer)
    <Required>
    Public Property Year4 As Nullable(Of Integer)
    <Required>
    Public Property Year5 As Nullable(Of Integer)
    Public Property Description As String
    Public Property IsKeur As Nullable(Of Boolean)
    Public Property IsTruck As Nullable(Of Boolean)
    <Required>
    <Display(Name:="Asset Rating")>
    Public Property Asset_Rating As Nullable(Of Integer)
End Class
