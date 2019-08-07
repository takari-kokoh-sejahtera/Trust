Imports System.ComponentModel.DataAnnotations

Public Class Cn_LevelGroup
    Public Property LevelGroup_ID As Integer
    <Required>
    <Display(Name:="LevelGroup Name")>
    Public Property LevelGroup_Name As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As Integer
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As Nullable(Of Integer)
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Boolean

End Class
