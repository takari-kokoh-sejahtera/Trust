Imports System.ComponentModel.DataAnnotations

Public Class Tr_ApprovalPO
    Public Property Approve As Nullable(Of Boolean)
    <Key>
    Public Property ApprovalPO_ID As Integer
    Public Property ProspectCustomer_ID As Nullable(Of Integer)
    <Display(Name:="Maker Date")>
    Public Property MakerDate As Nullable(Of Date)
    <Display(Name:="Maker By")>
    Public Property MakerBy As String
    <Display(Name:="Maker Remark")>
    Public Property MakerRemark As String
    <Display(Name:="Checker Date")>
    Public Property CheckerDate As Nullable(Of Date)
    <Display(Name:="Checker By")>
    Public Property CheckerBy As String
    <Display(Name:="Checker Remark")>
    Public Property CheckerRemark As String
    <Display(Name:="Approval1 Date")>
    Public Property Approval1Date As Nullable(Of Date)
    <Display(Name:="Approval1 By")>
    Public Property Approval1By As String
    <Display(Name:="Approval1 Remark")>
    Public Property Approval1Remark As String
    <Display(Name:="Approval2 Date")>
    Public Property Approval2Date As Nullable(Of Date)
    <Display(Name:="Approval2 By")>
    Public Property Approval2By As String
    <Display(Name:="Approval2 Remark")>
    Public Property Approval2Remark As String
    <Display(Name:="Approval3 Date")>
    Public Property Approval3Date As Nullable(Of Date)
    <Display(Name:="Approval3 By")>
    Public Property Approval3By As String
    <Display(Name:="Approval3 Remark")>
    Public Property Approval3Remark As String
    <Display(Name:="Approval4 Date")>
    Public Property Approval4Date As Nullable(Of Date)
    <Display(Name:="Approval4 By")>
    Public Property Approval4By As String
    <Display(Name:="Approval4 Remark")>
    Public Property Approval4Remark As String
    <Display(Name:="Approval5 Date")>
    Public Property Approval5Date As Nullable(Of Date)
    <Display(Name:="Approval5 By")>
    Public Property Approval5By As String
    <Display(Name:="Approval5 Remark")>
    Public Property Approval5Remark As String
    <Display(Name:="Status Record")>
    Public Property StatusRecord As Nullable(Of Integer)
    Public Property Status As String
    <Display(Name:="Remark")>
    Public Property RemarkNotApprove As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    Public Property CreatedBy_ID As Nullable(Of Integer)
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String



    <Display(Name:="No Ref")>
    Public Property No_Ref As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Cost Price")>
    Public Property Cost_Price As Nullable(Of Double)

    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    Public Property Company As String
    Public Property Address As String
    Public Property City As String
    Public Property Phone As String
    Public Property Email As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Phone")>
    Public Property PIC_Phone As String
    <Display(Name:="PIC Email")>
    Public Property PIC_Email As String
    Public Property Detail As List(Of Tr_ApplicationPO)
End Class
