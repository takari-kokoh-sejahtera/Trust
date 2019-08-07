Imports System.ComponentModel.DataAnnotations

Public Class Tr_ApprovalApp
    Public Property ApprovalApp_ID As Integer
    Public Property ApplicationHeader_ID As Integer


    <Display(Name:="Application No")>
    Public Property Application_No As String
    <Display(Name:="CompanyGroup Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Approval As Nullable(Of Boolean)



    <Display(Name:="Maker Date")>
    Public Property MakerDate As Nullable(Of Date)
    <Display(Name:="Maker By")>
    Public Property MakerBy As Nullable(Of Integer)
    <Display(Name:="MakerBy Str")>
    Public Property MakerByStr As String
    <Display(Name:="Checker Date")>
    Public Property CheckerDate As Nullable(Of Date)
    <Display(Name:="Checker By")>
    Public Property CheckerBy As Nullable(Of Integer)
    <Display(Name:="Checker By Str")>
    Public Property CheckerByStr As String
    <Display(Name:="Approval1 Date")>
    Public Property Approval1Date As Nullable(Of Date)
    <Display(Name:="Approval1 By")>
    Public Property Approval1By As Nullable(Of Integer)
    <Display(Name:="Approval1 By Str")>
    Public Property Approval1ByStr As String
    <Display(Name:="Approval2 Date")>
    Public Property Approval2Date As Nullable(Of Date)
    <Display(Name:="Approval2 By")>
    Public Property Approval2By As Nullable(Of Integer)
    <Display(Name:="Approval2 By Str")>
    Public Property Approval2ByStr As String
    <Display(Name:="Approval3 Date")>
    Public Property Approval3Date As Nullable(Of Date)
    <Display(Name:="Approval3 By")>
    Public Property Approval3By As Nullable(Of Integer)
    <Display(Name:="Approval3 By Str")>
    Public Property Approval3ByStr As String
    <Display(Name:="Approval4 Date")>
    Public Property Approval4Date As Nullable(Of Date)
    <Display(Name:="Approval4 By")>
    Public Property Approval4By As Nullable(Of Integer)
    <Display(Name:="Approval4 By Str")>
    Public Property Approval4ByStr As String
    <Display(Name:="Approval5 Date")>
    Public Property Approval5Date As Nullable(Of Date)
    <Display(Name:="Approval5 By")>
    Public Property Approval5By As Nullable(Of Integer)
    <Display(Name:="Approval5 By Str")>
    Public Property Approval5ByStr As String
    <Display(Name:="Status Record")>
    Public Property StatusRecord As Nullable(Of Integer)
    Public Property Status As String
    Public Property Remark As String
    <Display(Name:="Back To")>
    Public Property BackTo As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As Nullable(Of Integer)
    <Display(Name:="Created By Str")>
    Public Property CreatedByStr As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As Nullable(Of Integer)
    <Display(Name:="Modified By Str")>
    Public Property ModifiedByStr As String
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Nullable(Of Boolean)
    <Display(Name:="Cost Price")>
    Public Property Cost_Price As Nullable(Of Decimal)
End Class
