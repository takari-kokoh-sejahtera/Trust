Imports System.ComponentModel.DataAnnotations
Public Class Cn_User_ChangePass
    Public Property User_ID As Integer
    Public Property User_Name As String
    <Required>
    <DataType(DataType.Password)>
    Public Property Password As String
    <DataType(DataType.Password)>
    <Required>
    Public Property NewPassword As String
    <DataType(DataType.Password)>
    <Required>
    <Compare("NewPassword")>
    Public Property ConfirmPassword As String
End Class
Public Class Cn_User
    Public Property User_ID As Integer
    <Required>
    Public Property NIK As String
    <Required>
    Public Property User_Name As String
    <Required>
    <Display(Name:="Full Name")>
    Public Property Full_Name As String
    <Required>
    <DataType(DataType.Password)>
    Public Property Password As String
    <DataType(DataType.Password)>
    <Required>
    Public Property NewPassword As String
    <DataType(DataType.Password)>
    <Required>
    <Compare("NewPassword")>
    Public Property ConfirmPassword As String
    <Required>
    Public Property Directorat_ID As Nullable(Of Integer)
    <Required>
    Public Property GM_ID As Nullable(Of Integer)
    <Required>
    Public Property Division_ID As Nullable(Of Integer)
    Public Property Department_ID As Nullable(Of Integer)
    <Required>
    Public Property Title_ID As Nullable(Of Integer)
    'Private _limited_Approval As Nullable(Of Double)
    '<Required>
    '<DisplayFormat(DataFormatString:="{0:0,0}")>
    'Public Property Limited_Approval As Nullable(Of Double)
    '    Get
    '        Return _limited_Approval
    '    End Get
    '    Set(ByVal value As Nullable(Of Double))
    '        '_limited_ApprovalStr = String.Format("{0:n}", value)
    '        _limited_ApprovalStr = value
    '        _limited_Approval = value
    '    End Set
    'End Property
    'Private _limited_ApprovalStr As String
    'Public Property Limited_ApprovalStr As String
    '    Get
    '        Return _limited_ApprovalStr
    '    End Get
    '    Set(ByVal value As String)
    '        Limited_Approval = Val(value.Replace(",", ""))
    '        _limited_ApprovalStr = value
    '    End Set
    'End Property
    Public Property Role_ID As Nullable(Of Integer)

    Public Property CreatedDate As Nullable(Of Date)
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Nullable(Of Boolean)

    Public Overridable Property Cn_Directorats As Cn_Directorats
    Public Overridable Property Cn_Directorats1 As Cn_Directorats
    Public Overridable Property Cn_Divisions As Cn_Divisions
    Public Overridable Property Cn_Divisions1 As Cn_Divisions
    Public Overridable Property Cn_GMs As Cn_GMs
    Public Overridable Property Cn_GMs1 As Cn_GMs
    Public Overridable Property Cn_Levels As Cn_Levels
    Public Overridable Property Cn_Levels1 As Cn_Levels
    Public Overridable Property Cn_Titles As Cn_Titles
    Public Overridable Property Cn_Titles1 As Cn_Titles

End Class
