Imports System.ComponentModel.DataAnnotations

Public Class Ms_Dealer
    Public Property Dealer_ID As Integer
    <Required>
    <Display(Name:="Dealer Name")>
    Public Property Dealer_Name As String
    Public Property Address As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Phone")>
    <DataType(DataType.PhoneNumber)>
    Public Property PIC_Phone As String
    <DataType(DataType.EmailAddress)>
    <Display(Name:="PIC Email")>
    Public Property PIC_Email As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String

End Class
