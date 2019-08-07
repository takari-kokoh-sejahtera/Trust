Public Class Tr_ProspectCustHistory
    Public Property ProspectCustomerHistory_ID As Integer
    Public Property ProspectCustomer_ID As Integer
    Public Property ProspectCategory_ID As Nullable(Of Integer)
    Public Property Status As String
    Public Property DateTrans As Date
    Public Property Notes As String
    Public Property IsChecked As Nullable(Of Boolean)
    Public Property CheckNote As String
    Public Property CheckedBy As Nullable(Of Integer)
    Public Property CheckedDate As Nullable(Of Date)
    Public Property CreatedDate As Date
    Public Property CreatedBy As String
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As String
    Public Property IsDeleted As Boolean

    Public Property CompanyGroup_Name As String
    Public Property Company_Name As String
    Public Property ProspectCategory As String



End Class
