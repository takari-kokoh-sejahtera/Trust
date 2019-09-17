Imports System.ComponentModel.DataAnnotations

Public Class Tr_Delivery
    Public Property Delivery_ID As Integer
    <Display(Name:="Delivery Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DeliveryDate As Nullable(Of Date)
    <Display(Name:="Delivery Address")>
    Public Property Address_Delivery As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Number")>
    Public Property PIC_Number As String
    Public Property ContractDetail_ID As Integer
    <Display(Name:="Delivery Method")>
    <Required>
    Public Property Delivery_Method As String
    <Display(Name:="Expedition Name")>
    Public Property Expedition_Name As String
    <Display(Name:="Driver Allocated")>
    <Required>
    Public Property Driver_Allocated As Boolean
    <Display(Name:="Driver Name")>
    Public Property Driver_ID As String
    <Display(Name:="BSTK Date")>
    <Required>
    <DataType(DataType.Date)>
    Public Property BSTK_Date As Date
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

    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="Brand Name")>
    Public Property Brand_Name As String
    <Display(Name:="Model")>
    Public Property Vehicle As String
    <Display(Name:="License No")>
    Public Property license_no As String


End Class
