Imports System.ComponentModel.DataAnnotations

Public Class Ms_City
    Public Property CIty_ID As Integer
    <Required>
    Public Property City As String
    <Required>
    Public Property Provinsi As String
    Private _expedition_CostStr As String
    Public Property Expedition_CostStr As String
        Get
            Return _expedition_CostStr
        End Get
        Set(ByVal value As String)
            _expedition_Cost = Val(If(value, "0").Replace(",", ""))
            _expedition_CostStr = value
        End Set
    End Property
    Private _expedition_Cost As Nullable(Of Decimal)
    <Display(Name:="Expedition Cost")>
    <DisplayFormat(DataFormatString:="{0:0,0}")>
    Public Property Expedition_Cost As Nullable(Of Decimal)
        Get
            Return _expedition_Cost
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _expedition_CostStr = If(value, "")
            _expedition_Cost = value
        End Set
    End Property
    <Required>
    <Display(Name:="Kode Plat")>
    <StringLength(5)>
    Public Property Kode_Plat As String
    <Required>
    Public Property Remark As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property isDeleted As Boolean
End Class
