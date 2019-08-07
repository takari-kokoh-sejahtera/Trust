Imports System.ComponentModel.DataAnnotations

Public Class Tr_Calculate
    Public Property Calculate_ID As Nullable(Of Integer)
    <Required>
    <Display(Name:="Prospect Customer Detail ID")>
    Public Property ProspectCustomerDetail_ID As Nullable(Of Integer)
    <Display(Name:="Company Group Name")>
    Public Property CompanyGroup_Name As String
    Public Property Penerima As String
    Public Property Jabatan As String
    <Display(Name:="Company Name")>
    Public Property Company_Name As String
    <Display(Name:="Is Used Car")>
    Public Property IsVehicleExists As Nullable(Of Boolean)
    <Display(Name:="Brand Name")>
    Public Property Brand_Name As String
    Public Property Model_ID As Nullable(Of Integer)
    Public Property Vehicle As String
    Public Property Year As Nullable(Of Integer)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Lease Long")>
    Public Property Lease_long As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Lease Price")>
    Public Property Lease_price As Nullable(Of Double)
    Public Property Qty As Nullable(Of Integer)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Amount As Nullable(Of Double)
    <Display(Name:="Transaction Type")>
    Public Property Transaction_Type As String
    '<Required>
    '<Display(Name:="FixCost ID")>
    'Public Property FixCost_ID As Nullable(Of Integer)
    '<Display(Name:="FixCost Name")>
    'Public Property FixCost_Name As String
    <Required>
    <Display(Name:="Rent Location ID")>
    Public Property Rent_Location_ID As Nullable(Of Integer)
    <Required>
    <Display(Name:="Rent Location Name")>
    Public Property Rent_Location_Name As String
    Private _Prop2 As Nullable(Of Integer) = Nothing
    <Required>
    <Display(Name:="Plat Location")>
    Public Property Plat_Location As Nullable(Of Integer)
        Get
            Return _Prop2
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _Prop2 = value
        End Set
    End Property
    <Display(Name:="Plat Location Name")>
    Public Property Plat_Location_Name As String

    Public Property Term_Of_PaymentStr As String
    Private _Term_Of_Payment As Nullable(Of Integer) = Nothing
    <Required>
    <Display(Name:="Term Scheme")>
    Public Property Term_Of_Payment As Nullable(Of Integer)
        Get
            Return _Term_Of_Payment
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _Term_Of_Payment = value
            If value = 1 Then
                Term_Of_PaymentStr = "Month"
            ElseIf value = 3 Then
                Term_Of_PaymentStr = "3 Month"
            ElseIf value = 6 Then
                Term_Of_PaymentStr = "6 Month"
            ElseIf value = 12 Then
                Term_Of_PaymentStr = "12 Month"
            Else
                Term_Of_PaymentStr = ""
            End If
        End Set
    End Property
    <Display(Name:="Pay Month")>
    Public Property PayMonthStr As String
    Private _PayMonth As Nullable(Of Integer) = Nothing
    <Display(Name:="Pay Month")>
    Public Property PayMonth As Nullable(Of Integer)
        Get
            Return _PayMonth
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _PayMonth = value
            If If(value, 0) = 0 Then
                PayMonthStr = "Nothing"
            ElseIf value = 1 Then
                PayMonthStr = "First Month"
            ElseIf value = 2 Then
                PayMonthStr = "Second Month"
            ElseIf value = 3 Then
                PayMonthStr = "Third Month"
            Else
                PayMonthStr = ""
            End If
        End Set
    End Property
    <Display(Name:="Payment Type")>
    Public Property Payment_Condition As String
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Modification As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="GPS Cost")>
    Public Property GPS_Cost As Nullable(Of Double)

    Public Property GPS_CostPerMonthStr As String
    Private _GPS_CostPerMonth As Nullable(Of Integer) = Nothing
    Public Property GPS_CostPerMonth As Nullable(Of Integer)
        Get
            Return _GPS_CostPerMonth
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _GPS_CostPerMonth = value
            If value = 1 Then
                GPS_CostPerMonthStr = "Month"
            ElseIf value = 3 Then
                GPS_CostPerMonthStr = "3 Month"
            ElseIf value = 6 Then
                GPS_CostPerMonthStr = "6 Month"
            ElseIf value = 12 Then
                GPS_CostPerMonthStr = "12 Month"
            Else
                GPS_CostPerMonthStr = ""
            End If
        End Set
    End Property

    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Agent Fee")>
    Public Property Agent_Fee As Nullable(Of Double)

    Public Property Agent_FeePerMonthStr As String
    Public _Agent_FeePerMonth As Nullable(Of Integer) = Nothing
    Public Property Agent_FeePerMonth As Nullable(Of Integer)
        Get
            Return _Agent_FeePerMonth
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _Agent_FeePerMonth = value
            If value = 1 Then
                Agent_FeePerMonthStr = "Month"
            ElseIf value = 3 Then
                Agent_FeePerMonthStr = "3 Month"
            ElseIf value = 6 Then
                Agent_FeePerMonthStr = "6 Month"
            ElseIf value = 12 Then
                Agent_FeePerMonthStr = "12 Month"
            Else
                Agent_FeePerMonthStr = ""
            End If
        End Set
    End Property
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Update OTR")>
    Public Property Update_OTR As Nullable(Of Double)
    Public Property Update_DiskonTick As Nullable(Of Boolean)
    Public Property Update_DiskonSystem As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Update Diskon")>
    Public Property Update_Diskon As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Cost Price")>
    Public Property Cost_Price As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Residual Value")>
    Public Property Residual_Value As Nullable(Of Double)
    <Display(Name:="Residual Percennt")>
    Public Property Residual_ValuePercent As Nullable(Of Double)
    <Display(Name:="Expedition Status")>
    Public Property Expedition_Status As String
    <Display(Name:="Expedition Cost")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Expedition_Cost As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Keur As Nullable(Of Double)
    <Display(Name:="UpFront Fee")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Up_Front_Fee As Nullable(Of Double)
    <Display(Name:="UpFront Fee Percent")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Up_Front_Fee_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Other As Nullable(Of Double)
    <Required>
    <DataType(DataType.Date)>
    <Display(Name:="Efektif Date")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Efektif_Date As Nullable(Of Date)
    <Display(Name:="Replacement Percent")>
    Public Property Replacement_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Replacement As Nullable(Of Double)
    Public Property Replacement_Percent_Before As Nullable(Of Decimal)
    Public Property Replacement_Tick As Boolean
    <Display(Name:="Maintenance Percent")>
    Public Property Maintenance_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Maintenance As Nullable(Of Double)
    Public Property Maintenance_Percent_Before As Nullable(Of Decimal)
    Public Property Maintenance_Tick As Boolean
    <Display(Name:="STNK Percent")>
    Public Property STNK_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property STNK As Nullable(Of Double)
    Public Property STNK_Percent_Before As Nullable(Of Decimal)
    Public Property STNK_Tick As Boolean
    <Display(Name:="Overhead Percent")>
    Public Property Overhead_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Overhead As Nullable(Of Double)
    Public Property Overhead_Percent_Before As Nullable(Of Decimal)
    <Display(Name:="Assurance Percent")>
    Public Property Assurance_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Assurance As Nullable(Of Double)
    Public Property Assurance_Percent_Before As Nullable(Of Decimal)
    Public Property Assurance_Tick As Boolean
    <Display(Name:="Insurance Extra")>
    Public Property AssuranceExtra As Nullable(Of Double)
    Public Property Lease_Profit_Percent As Nullable(Of Double)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Lease_Profit As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Depresiasi_Percent As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Depresiasi As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Funding_Interest As Nullable(Of Decimal)
    Public Property Funding_Interest_Percent As Nullable(Of Decimal)
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    <Display(Name:="Lease Rent / Month")>
    Public Property Bid_PricePerMonth As Nullable(Of Double)
    Public Property Premium As Nullable(Of Decimal)
    Public Property OJK As Nullable(Of Decimal)
    <Display(Name:="Swap Rate")>
    Public Property SwapRate As Nullable(Of Decimal)
    <Display(Name:="Project Rating")>
    Public Property Project_Rating As String
    Public Property Project As String
    Public Property IRR As Nullable(Of Decimal)
    <Display(Name:="Funding Rate")>
    Public Property Funding_Rate As Nullable(Of Decimal)
    Public Property Spread As Nullable(Of Decimal)
    Public Property Profit As Nullable(Of Decimal)
    <Display(Name:="Remark Deviasi")>
    Public Property RemarkDeviasi As String
    <Display(Name:="Deviasi By")>
    Public Property DeviasiBy As String
    <Display(Name:="Deviasi Date")>
    Public Property DeviasiDate As Nullable(Of Date)
    <Display(Name:="Created Date")>
    Public Property CreatedDate As Nullable(Of Date)
    <Display(Name:="Created By")>
    Public Property CreatedBy As String
    Public Property CreatedBy_ID As Nullable(Of Integer)
    <Display(Name:="Modified Date")>
    Public Property ModifiedDate As Nullable(Of Date)
    <Display(Name:="Modified By")>
    Public Property ModifiedBy As String
    Public Property IsDeleted As Nullable(Of Boolean)
    Public Property IsQuotation As Nullable(Of Boolean)
    <Display(Name:="New Vehicle Price")>
    Public Property New_Vehicle_Price As Nullable(Of Decimal)
    <Display(Name:="Location Vehicle")>
    Public Property Location_Vehicle_ID As Nullable(Of Integer)
    <Display(Name:="Location Vehicle")>
    Public Property Location_Vehicle As String


    Public Property Type As String

    Public Property IsTruck As Nullable(Of Boolean)

    Public Property IsJakarta As Nullable(Of Boolean)
    <Display(Name:="Credit Rating")>
    Public Property Credit_Rating As String
    Public Property GoalSeek As String
    Public Property GoalSeekVal As Nullable(Of Decimal)

    Public Property IsMultiCalculated As Boolean

End Class
