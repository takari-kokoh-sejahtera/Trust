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

Partial Public Class Tr_ProspectCustDetails
    Public Property ProspectCustomerDetail_ID As Integer
    Public Property ProspectCustomer_ID As Integer
    Public Property IsVehicleExists As Boolean
    Public Property VehicleExists_ID As Nullable(Of Integer)
    Public Property Brand_ID As Nullable(Of Integer)
    Public Property Model_ID As Nullable(Of Integer)
    Public Property IsJakarta As Nullable(Of Boolean)
    Public Property Lease_price As Nullable(Of Decimal)
    Public Property Qty As Nullable(Of Integer)
    Public Property IsMultiCalculated As Nullable(Of Boolean)
    Public Property MultiCalculateGroup As Nullable(Of Integer)
    Public Property Year As Nullable(Of Integer)
    Public Property Lease_long As Nullable(Of Integer)
    Public Property Transaction_Type As String
    Public Property IsCalculate As Nullable(Of Boolean)
    Public Property CreatedDate As Date
    Public Property CreatedBy As Integer
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

    Public Overridable Property Ms_Vehicle_Brands As Ms_Vehicle_Brands
    Public Overridable Property Ms_Vehicles As Ms_Vehicles
    Public Overridable Property Ms_Vehicle_Models As Ms_Vehicle_Models
    Public Overridable Property Tr_ProspectCusts As Tr_ProspectCusts
    Public Overridable Property Tr_ApplicationPOs As ICollection(Of Tr_ApplicationPOs) = New HashSet(Of Tr_ApplicationPOs)

End Class
