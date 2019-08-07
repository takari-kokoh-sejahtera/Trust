Imports System.ComponentModel.DataAnnotations

Public Class Ms_CostOfFund
    Public Property CostOfFund_ID As Integer
    <Required>
    <Display(Name:="Year 1")>
    Public Property Year1 As Decimal
    <Required>
    <Display(Name:="Year 2")>
    Public Property Year2 As Decimal
    <Required>
    <Display(Name:="Year 3")>
    Public Property Year3 As Decimal
    <Required>
    <Display(Name:="Year 4")>
    Public Property Year4 As Decimal
    <Required>
    <Display(Name:="Year 5")>
    Public Property Year5 As Decimal
    <Required>
    <Display(Name:="Year 6")>
    Public Property Year6 As Decimal
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
