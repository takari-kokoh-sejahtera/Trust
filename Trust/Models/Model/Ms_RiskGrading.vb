Imports System.ComponentModel.DataAnnotations

Public Class Ms_RiskGrading
    Public Property RiskGrading_ID As Integer
    <Required>
    <Display(Name:="Project Rating")>
    <StringLength(3)>
    Public Property Project_Rating As String
    <Required>
    <Display(Name:="Risk Grading")>
    Public Property RiskGrading As Decimal
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Boolean
End Class
