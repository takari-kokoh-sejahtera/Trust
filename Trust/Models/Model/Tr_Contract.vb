Imports System.ComponentModel.DataAnnotations

Public Class Tr_Contract
    <Key>
    <Required>
    Public Property Contract_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Approval_ID As Nullable(Of Integer)
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    <Required>
    Public Property Penerima As String
    <Required>
    Public Property Jabatan As String
    <Required>
    <Display(Name:="Per Month")>
    Public Property PerMonth As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Display(Name:="Is Deleted")>
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property Detail As IEnumerable(Of Tr_ContractGetDetail)

    <Display(Name:="Draft Contract")>
    Public Property IsDraftContractFile As HttpPostedFileBase
    <Display(Name:="Type Contract")>
    Public Property TypeContract As String
    Public Property Description As String


End Class
Public Class Tr_Contract_Join
    <Key>
    <Required>
    Public Property Contract_ID As Integer

End Class

Public Class Tr_ContractGetDetail
    Public Property ContractDetail_ID As Integer
    Public Property Application_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Vehicle As String
    <Display(Name:="Rent Location")>
    Public Property Rent_Location As String
    <Display(Name:="Delivery Date")>
    Public Property DeliveryDate As String
    <Display(Name:="Lease long")>
    Public Property Lease_long As Nullable(Of Integer)
    <Display(Name:="Start Date")>
    Public Property StartDate As String
    <Display(Name:="End Date")>
    Public Property EndDate As String
    <Display(Name:="Bid Price PerMonth")>
    Public Property Bid_PricePerMonth As Nullable(Of Decimal)
    Public Property Remark As String

End Class
Public Class Tr_Contract_Draft

    Public Property ContractDraft_ID As Integer

    Public Property ContractDraft_ID_PDF As String
        Get
            Return ContractDraft_ID.ToString + ".pdf"
        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Contract_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Approval_ID As Nullable(Of Integer)
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Per Month")>
    Public Property PerMonth As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Required>
    Public Property Description As String
    <Required>
    <Display(Name:="Draft Contract")>
    Public Property IsDraftContractFile As HttpPostedFileBase
    <Required>
    <Display(Name:="Type Contract")>
    Public Property TypeContract As String

End Class

Public Class Tr_Contract_DraftEdit

    Public Property ContractDraft_ID As Integer
    Public Property Contract_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    Public Property Approval_ID As Nullable(Of Integer)
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Per Month")>
    Public Property PerMonth As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Required>
    Public Property Description As String
    <Display(Name:="Draft Contract")>
    Public Property IsDraftContractFile As HttpPostedFileBase
    <Required>
    <Display(Name:="Type Contract")>
    Public Property TypeContract As String

End Class
Public Class Tr_Contract_Send
    Public Property Contract_ID As Integer
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="Type Contract")>
    Public Property TypeContract As String
    Public Property Description As String
    Public Property Approval_ID As Nullable(Of Integer)
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Per Month")>
    Public Property PerMonth As String
    <Display(Name:="Send Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Send By")>
    Public Property CreatedBy As String
    <Display(Name:="Resend Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Resend By")>
    Public Property ModifiedBy As String
    <Display(Name:="Draft Contract")>
    Public Property IsDraftContractFile As HttpPostedFileBase
End Class
Public Class Tr_Contract_Receipt
    Public Property Contract_ID As Integer
    Public Property Contract_ID_PDF As String
        Get
            Return Contract_ID.ToString + ".pdf"
        End Get
        Set(value As String)

        End Set
    End Property

    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="Type Contract")>
    Public Property TypeContract As String
    Public Property Description As String
    Public Property Approval_ID As Nullable(Of Integer)
    <Display(Name:="Contract No")>
    Public Property Contract_No As String
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Per Month")>
    Public Property PerMonth As String
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    <Required>
    <Display(Name:="Contract")>
    Public Property ContractFile As HttpPostedFileBase
    <Required>
    <Display(Name:="Receipt")>
    Public Property ReceiptFile As HttpPostedFileBase
End Class

Public Class Tr_Contract_Receipt_Print
    Public Property Receipt_No As String
    Public Property Send_Date As Date
    Public Property Company_Name As String
    Public Property Description As String
    Public Property PIC_Name As String
    Public Property Address As String
    Public Property PIC_Phone As String
    Public Property Qty As Integer
    Public Property Type As String
End Class