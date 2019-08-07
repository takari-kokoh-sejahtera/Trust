'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Namespace Trust

    Partial Public Class Ms_Vehicles
        Public Property Vehicle_id As Integer
        Public Property license_no As String
        Public Property Tmp_Plat As String
        Public Property Model_ID As Nullable(Of Integer)
        Public Property type As String
        Public Property color As String
        Public Property year As Nullable(Of Integer)
        Public Property chassis_no As String
        Public Property machine_no As String
        Public Property title_no As String
        Public Property serial_no As String
        Public Property registration_no As String
        Public Property registration_expdate As Nullable(Of Date)
        Public Property insurance_no As String
        Public Property discount As Nullable(Of Decimal)
        Public Property price As Nullable(Of Decimal)
        Public Property acquisition As Nullable(Of Decimal)
        Public Property coverage As Nullable(Of Decimal)
        Public Property comment As String
        Public Property status As Integer
        Public Property date_insurance_start As Nullable(Of Date)
        Public Property date_insurance_end As Nullable(Of Date)
        Public Property date_insurance_mod As Nullable(Of Date)
        Public Property date_book As Nullable(Of Date)
        Public Property STNK_No As String
        Public Property STNK_Publish As Nullable(Of Date)
        Public Property STNK_Yearly_Renewal As Nullable(Of Date)
        Public Property STNK_5Year_Renewal As Nullable(Of Date)
        Public Property STNK_Month As Nullable(Of Integer)
        Public Property STNK_Name As String
        Public Property STNK_Address As String
        Public Property CC As Nullable(Of Integer)
        Public Property Fuel As String
        Public Property NoUrutBuku As String
        Public Property DO_date As Nullable(Of Date)
        Public Property Vehicle_Come As Nullable(Of Date)
        Public Property STNK_Receipt As Nullable(Of Date)
        Public Property PO_No As String
        Public Property Harga_Beli As Nullable(Of Decimal)
        Public Property Kwitansi_Date As Nullable(Of Date)
        Public Property Kwitansi_No As String
        Public Property FakturPajak_Date As Nullable(Of Date)
        Public Property FakturPajak_No As String
        Public Property VAT As String
        Public Property Dealer As String
        Public Property ContractDetail_ID As Nullable(Of Integer)
        Public Property CreatedDate As Nullable(Of Date)
        Public Property CreatedBy As Nullable(Of Integer)
        Public Property ModifiedDate As Nullable(Of Date)
        Public Property ModifiedBy As Nullable(Of Integer)
        Public Property IsDeleted As Nullable(Of Boolean)
    
        Public Overridable Property Tr_ContractDetails As Tr_ContractDetails
        Public Overridable Property Tr_ContractDetails1 As ICollection(Of Tr_ContractDetails) = New HashSet(Of Tr_ContractDetails)
        Public Overridable Property Tr_ContractDetailHistorys As ICollection(Of Tr_ContractDetailHistorys) = New HashSet(Of Tr_ContractDetailHistorys)
        Public Overridable Property Tr_InvoiceDetails As ICollection(Of Tr_InvoiceDetails) = New HashSet(Of Tr_InvoiceDetails)
        Public Overridable Property Tr_TemporaryCars As ICollection(Of Tr_TemporaryCars) = New HashSet(Of Tr_TemporaryCars)
        Public Overridable Property Tr_TotalLossOnlys As ICollection(Of Tr_TotalLossOnlys) = New HashSet(Of Tr_TotalLossOnlys)
        Public Overridable Property Tr_ProspectCustDetails As ICollection(Of Tr_ProspectCustDetails) = New HashSet(Of Tr_ProspectCustDetails)
        Public Overridable Property Cn_Users As Cn_Users
        Public Overridable Property Cn_Users1 As Cn_Users
        Public Overridable Property Ms_Vehicle_Models As Ms_Vehicle_Models
    
    End Class

End Namespace
