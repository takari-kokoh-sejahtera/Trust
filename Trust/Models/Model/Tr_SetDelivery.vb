Imports System.ComponentModel.DataAnnotations
Public Class Tr_SetDelivery
    Public Property Contract_ID As Nullable(Of Integer)
    Public Property SetDelivery_ID As Nullable(Of Integer)
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:=" Contract Number")>
    Public Property Contract_No As String
    <Display(Name:="Qty Contract")>
    Public Property QtyContract As Nullable(Of Integer)
    <Display(Name:="Qty Delivery")>
    Public Property QtyDelivery As Nullable(Of Integer)
    Public Property CreatedDate As Nullable(Of DateTime)
    Public Property CreatedBy As String
    Public Property ModifiedDate As DateTime
    Public Property ModifiedBy As String
    <Display(Name:="Delivery Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{yy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property DeliveryDate As Nullable(Of Date)
    <Display(Name:="Delivery Address")>
    Public Property Address_Delivery As String
    <Display(Name:="PIC Name")>
    Public Property PIC_Name As String
    <Display(Name:="PIC Number")>
    Public Property PIC_Number As String
    Public Property IsDeleted As Boolean




End Class
