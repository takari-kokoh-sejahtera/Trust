Imports System.ComponentModel.DataAnnotations
Imports Trust.Trust

Public Class Tr_ProspectCust
    <Display(Name:="ProspectCustomer ID")>
    Public Property ProspectCustomer_ID As Integer
    <Display(Name:="Is Exists")>
    Public Property IsExists As Boolean
    <Display(Name:="CustomerExists ID")>
    Public Property CustomerExists_ID As Nullable(Of Integer)
    <Display(Name:="CompanyGroup ID")>
    Public Property CompanyGroup_ID As Nullable(Of Integer)
    <Display(Name:="CompanyGroup Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="PT")>
    Public Property PT As String
    <Display(Name:="Tbk")>
    Public Property Tbk As Nullable(Of Boolean)
    Public Property Address As String
    <Display(Name:="City")>
    Public Property City_id As Nullable(Of Integer)
    Public Property City As String
    Public Property Phone As String
    Public Property Email As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Phone")>
    Public Property PIC_Phone As String
    <Display(Name:="PIC Email")>
    Public Property PIC_Email As String
    <Display(Name:="Credit Rating")>
    Public Property Credit_Rating As String
    <Display(Name:="Is Jakarta")>
    Public Property IsJakarta As Nullable(Of Boolean)
    <Required>
    <Display(Name:="Category")>
    Public Property ProspectCategory_ID As Nullable(Of Integer)
    <Required>
    Public Property Status As String
    Public Property Notes As String
    <Required>
    <Display(Name:="Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DateTrans As Nullable(Of Date)
    <Required>
    <Display(Name:="Time")>
    <DataType(DataType.Time)>
    <DisplayFormat(DataFormatString:="{0:H:mm}")>
    Public Property DateTransTime As Nullable(Of System.TimeSpan)
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Date
    <Display(Name:="Created By")>
    Public Property CreatedBy As Nullable(Of Integer)
    <Display(Name:="Created By")>
    Public Property CreatedByName As String
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    Public Property IsDeleted As Boolean
    Public Property IsQuotation As Nullable(Of Boolean)
    Public Property Cost_Price As Nullable(Of Decimal)
    Public Property Quotation_ID As Nullable(Of Integer)
    Public Property Approval_ID As Nullable(Of Integer)

    Public Overridable Property Ms_Customer_CompanyGroups As Ms_Customer_CompanyGroups
    Public Overridable Property Ms_Customers As Ms_Customers
    Public Overridable Property Tr_ProspectCustDetails As ICollection(Of Tr_ProspectCustDetails) = New HashSet(Of Tr_ProspectCustDetails)
    Public Overridable Property Tr_ProspectCustHistorys As ICollection(Of Tr_ProspectCustHistorys) = New HashSet(Of Tr_ProspectCustHistorys)
    Public Overridable Property Ms_Citys As Ms_Citys
End Class
