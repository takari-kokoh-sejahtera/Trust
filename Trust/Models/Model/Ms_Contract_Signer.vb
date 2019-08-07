Imports System.ComponentModel.DataAnnotations

Public Class Ms_Contract_Signer
    <Required>
    Public Property Signer_ID As Integer
    <Display(Name:="Name")>
    Public Property Name As String
    <Required>
    <Display(Name:="Title Indo")>
    Public Property Title_Ind As String
    <Required>
    <Display(Name:="Title Eng")>
    Public Property Title_Eng As String
    <Required>
    Public Property Sex As Boolean
    Private _sex_Name As String
    <Required>
    <Display(Name:="Sex")>
    Public Property Sex_Name As String
        Get
            Return If(Sex, "Man", "Woman")
        End Get
        Set(ByVal value As String)
            _sex_Name = value
        End Set
    End Property

    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String

End Class
