Imports System.ComponentModel.DataAnnotations

Public Class Cn_ApprovalUser
    Public Property ApprovalUser_ID As Integer
    <Required>
    <Display(Name:="User")>
    Public Property User_ID As Integer
    Public Property User As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String

    Public Property Cn_ApprovalUserDetail As IEnumerable(Of Cn_ApprovalUserDetail)
    Public Property Cn_ApprovalUserDetailDelete As IEnumerable(Of Cn_ApprovalUserDetail)

End Class
Public Class Cn_ApprovalUserDetail
    Public Property ApprovalUserDetail_ID As Integer
    Public Property ApprovalUser_ID As Integer
    Public Property Approval_ID As Integer
    Public Property Approval_IDstr As String
    Private _limited_Approval As Nullable(Of Double)
    <Required>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Limited_Approval As Nullable(Of Double)
        Get
            Return _Limited_Approval
        End Get
        Set(ByVal value As Nullable(Of Double))
            _limited_ApprovalStr = String.Format("{0:N0}", value)
            _limited_Approval = value
        End Set
    End Property
    Private _limited_ApprovalStr As String
    Public Property Limited_ApprovalStr As String
        Get
            Return _limited_ApprovalStr
        End Get
        Set(ByVal value As String)
            Limited_Approval = Val(value.Replace(",", ""))
            _limited_ApprovalStr = value
        End Set
    End Property
End Class
