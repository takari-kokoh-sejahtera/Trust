Public Class V_ProspectCustDetail

    Public Property CompanyGroup_Name As String
        Public Property Company_Name As String
        Public Property Transaction_Type As String
        Public Property Type As String
        Public Property OTR_Price As Nullable(Of Integer)
        Public Property Normal_Disc As Nullable(Of Integer)
        Public Property Qty As Nullable(Of Integer)
        Public Property Lease_long As Nullable(Of Integer)
        Public Property CreatedBy As String
        Public Property Detail As IQueryable(Of Tr_ProspectCustD)

    End Class
    Public Class Tr_ProspectCustD
        Public Property Transaction_Type As String
        Public Property Type As String
        Public Property OTR_Price As Nullable(Of Integer)
        Public Property Normal_Disc As Nullable(Of Integer)
        Public Property Qty As Nullable(Of Integer)
        Public Property Lease_long As Nullable(Of Integer)
        Public Property CreatedBy As String

    End Class

