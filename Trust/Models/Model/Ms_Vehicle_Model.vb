Imports System.ComponentModel.DataAnnotations

Public Class Ms_Vehicle_Model
    Public Property Model_ID As Integer
    <Required>
    Public Property Brand_ID As Nullable(Of Integer)
    <Required>
    Public Property Type As String
    <Required>
    <Display(Name:="OTR Price")>
    Private _oTR_Price As Nullable(Of Double)
    Public Property OTR_Price As Nullable(Of Double)
        Get
            Return _oTR_Price
        End Get
        Set(ByVal value As Nullable(Of Double))
            '_limited_ApprovalStr = String.Format("{0:n}", value)
            _oTR_PriceStr = value
            _oTR_Price = value
        End Set
    End Property
    Private _oTR_PriceStr As String
    Public Property OTR_PriceStr As String
        Get
            Return _oTR_PriceStr
        End Get
        Set(ByVal value As String)
            _oTR_Price = Val(If(value, "0").Replace(",", ""))
            _oTR_PriceStr = value
        End Set
    End Property
    Private _normal_Disc As Nullable(Of Double)
    <Required>
    <Display(Name:="Normal Disc")>
    Public Property Normal_Disc As Nullable(Of Double)
        Get
            Return _normal_Disc
        End Get
        Set(ByVal value As Nullable(Of Double))
            '_limited_ApprovalStr = String.Format("{0:n}", value)
            _normal_DiscStr = value
            _normal_Disc = value
        End Set
    End Property
    Private _normal_DiscStr As String
    Public Property Normal_DiscStr As String
        Get
            Return _normal_DiscStr
        End Get
        Set(ByVal value As String)
            _normal_Disc = Val(If(value, "0").Replace(",", ""))
            _normal_DiscStr = value
        End Set
    End Property
    <Required>
    Public Property Year1 As Nullable(Of Integer)
    <Required>
    Public Property Year2 As Nullable(Of Integer)
    <Required>
    Public Property Year3 As Nullable(Of Integer)
    <Required>
    Public Property Year4 As Nullable(Of Integer)
    <Required>
    Public Property Year5 As Nullable(Of Integer)
    Public Property Description As String
    <Required>
    <Display(Name:="Asset Rating")>
    Public Property Asset_Rating As Nullable(Of Integer)
    Public Property IsKeur As Boolean
    Public Property IsTruck As Boolean
    <Required>
    Public Property Active As Boolean
    Public Property CreatedDate As Date
    Public Property CreatedBy As Nullable(Of Integer)
    Public Property ModifiedDate As Nullable(Of Date)
    Public Property ModifiedBy As Nullable(Of Integer)
    Public Property IsDeleted As Boolean

End Class
