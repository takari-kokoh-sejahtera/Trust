Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PagedList
Imports Trust.Trust

Namespace Controllers
    Public Class CalculateController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities
        Dim expedisiStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {New SelectListItem With {
                    .Text = "Return",
                    .Value = "Return"
                },
                New SelectListItem With {
                    .Text = "One Way",
                    .Value = "One Way"
                }
            }
#Region "Java"
        Public Function GetVehicleExists(ByVal VehicleExists_ID As Integer?, Credit_Rating As String, Transaction_Type As String) As ActionResult

            If VehicleExists_ID IsNot Nothing Then
                Dim query = db.Ms_Vehicles.Where(Function(x) x.Vehicle_id = VehicleExists_ID).FirstOrDefault()
                If query Is Nothing Then
                    Return Json(New With {Key .success = "false"})
                End If
                Dim ProjekRating = db.Ms_ProjRatingMatrixs.Where(Function(x) x.IsDeleted = False And x.Credit_Rating = Credit_Rating And x.Asset_Rating = query.Ms_Vehicle_Models.Asset_Rating).Select(Function(x) x.Project_Rating).FirstOrDefault

                'If ProjekRating IsNot Nothing Then
                '    If ProjekRating = "1" Or ProjekRating = "2" Or ProjekRating = "3" Or ProjekRating = "4" Or ProjekRating = "5" Then
                '        RV = 100 - (Year * 5)
                '    ElseIf ProjekRating = "6-1" Or ProjekRating = "6-2" Or ProjekRating = "7-1" Or ProjekRating = "7-2" Then
                '        RV = 100 - (Year * 10)
                '    End If
                'End If
                'If RV < 0 Then RV = 0

                Return Json(New With {Key .success = "true", Key .brand_ID = query.Ms_Vehicle_Models.Brand_ID, Key .model_ID = query.Model_ID,
                            .year = query.year, .price = FormatNumber(If(Transaction_Type = "OPL", query.Ms_Vehicle_Models.OTR_Price, If(Transaction_Type = "COP", query.price, 0)), 0), .ProjekRating = ProjekRating})
            End If
            Return Json(New With {Key .success = "false"})
        End Function
        Public Function GetRV(ByVal val As Integer?, type As String, vehicleExists As Boolean, leaselong As Integer?, Project_Rating As String) As ActionResult

            If val IsNot Nothing Then
                Dim query = db.Ms_Vehicle_Models.Where(Function(x) x.Model_ID = val).FirstOrDefault()
                If query Is Nothing Then
                    Return Json(New With {Key .success = "false"})
                End If
                If type = "OPL" And vehicleExists = False Then
                    If leaselong <= 12 Then
                        Return Json(New With {Key .success = "true", Key .rv = query.Year1})
                    ElseIf leaselong <= 24 Then
                        Return Json(New With {Key .success = "true", Key .rv = query.Year2})
                    ElseIf leaselong <= 36 Then
                        Return Json(New With {Key .success = "true", Key .rv = query.Year3})
                    ElseIf leaselong <= 48 Then
                        Return Json(New With {Key .success = "true", Key .rv = query.Year4})
                    ElseIf leaselong <= 60 Then
                        Return Json(New With {Key .success = "true", Key .rv = query.Year5})
                    Else
                        Return Json(New With {Key .success = "false"})
                    End If
                ElseIf type = "OPL" And vehicleExists Then
                    Dim year As Integer = 0
                    Dim RV As Integer = 0
                    If leaselong <= 12 Then
                        year = 1
                    ElseIf leaselong <= 24 Then
                        year = 2
                    ElseIf leaselong <= 36 Then
                        year = 3
                    ElseIf leaselong <= 48 Then
                        year = 4
                    ElseIf leaselong <= 60 Then
                        year = 5
                    End If
                    If Project_Rating IsNot Nothing Then
                        If Project_Rating = "1" Or Project_Rating = "2" Or Project_Rating = "3" Or Project_Rating = "4" Or Project_Rating = "5" Then
                            RV = 100 - (year * 5)
                        ElseIf Project_Rating = "6-1" Or Project_Rating = "6-2" Or Project_Rating = "7-1" Or Project_Rating = "7-2" Then
                            RV = 100 - (year * 10)
                        End If
                        If RV < 0 Then RV = 0
                        Return Json(New With {Key .success = "true", Key .rv = RV})
                    End If
                End If
                Return Json(New With {Key .success = "false"})
            End If
            Return Json(New With {Key .success = "false"})
        End Function
        Function GetRVPersent(RVPersen As Integer, Transaction_Type As String, IsVehicleExists As Boolean, Lease_long As Integer, ProjekRating As String) As Integer
            Dim RV As Integer = 0
            If Transaction_Type = "OPL" Then
                If IsVehicleExists Then
                    Dim tahunke = 0
                    If Lease_long <= 12 Then
                        tahunke = 1
                    ElseIf Lease_long <= 24 Then
                        tahunke = 2
                    ElseIf Lease_long <= 36 Then
                        tahunke = 3
                    ElseIf Lease_long <= 48 Then
                        tahunke = 4
                    ElseIf Lease_long <= 60 Then
                        tahunke = 5
                    ElseIf Lease_long <= 72 Then
                        tahunke = 6
                    ElseIf Lease_long <= 84 Then
                        tahunke = 7
                    End If
                    If ProjekRating IsNot Nothing Then
                        If ProjekRating = "1" Or ProjekRating = "2" Or ProjekRating = "3" Or ProjekRating = "4" Or ProjekRating = "5" Then
                            RV = 100 - (tahunke * 5)
                        ElseIf ProjekRating = "6-1" Or ProjekRating = "6-2" Or ProjekRating = "7-1" Or ProjekRating = "7-2" Then
                            RV = 100 - (tahunke * 10)
                        End If
                    End If
                    If RV < 0 Then RV = 0
                Else
                    RV = RVPersen
                End If
            ElseIf Transaction_Type = "COP" Then
                RV = RVPersen
            End If
            Return RV
        End Function

        Function swapRateFunc(Lease_long As Integer?) As Decimal?
            If (Lease_long <= 12) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year1).FirstOrDefault
            ElseIf (Lease_long <= 24) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year2).FirstOrDefault
            ElseIf (Lease_long <= 36) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year3).FirstOrDefault
            ElseIf (Lease_long <= 48) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year4).FirstOrDefault
            ElseIf (Lease_long <= 60) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year5).FirstOrDefault
            ElseIf (Lease_long <= 72) Then
                Return db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year6).FirstOrDefault
            End If
            Return 0
        End Function
        Sub assuransiFunc(IsTruck As Boolean?, Lease_long As Integer?, ByRef Assurance_Percent As Decimal, ByRef AssuranceExtra As Decimal)
            If IsTruck Then
                Assurance_Percent = 2.72
                AssuranceExtra = 685000 * (Lease_long / 12)
            End If
        End Sub

        Public Function FillCustomer(ByVal val As Integer?) As ActionResult
            Dim validate = True
            Dim message = ""
            If val IsNot Nothing Then
                If val = 0 Then
                    message = "ProspectDetail_ID is empty"
                    validate = False
                    Return Json(New With {Key .success = "false", .message = message})
                End If
                Dim Query = (From A In db.V_ProspectCustDetails
                             Where A.ProspectCustomerDetail_ID = val
                             Select A.Brand_Name, A.IsVehicleExists, A.Type, A.Normal_Disc, A.Transaction_Type, A.Vehicle, A.Year, A.Lease_long, A.Lease_price, A.OTR_Price, A.Qty, A.Amount, A.RVPersen, A.Keur, A.FundingCost, A.Credit_Rating, A.Asset_Rating, A.IsMultiCalculated, A.Model_ID, A.IsTruck).FirstOrDefault()

                Dim ProjekRating = db.Ms_ProjRatingMatrixs.Where(Function(x) x.IsDeleted = False And x.Credit_Rating = Query.Credit_Rating And x.Asset_Rating = Query.Asset_Rating).Select(Function(x) x.Project_Rating).FirstOrDefault
                'ubah RVnya karna dia mobil bekas
                Dim RV As Integer = GetRVPersent(Query.RVPersen, Query.Transaction_Type, Query.IsVehicleExists, Query.Lease_long, ProjekRating)
                'If Query.Transaction_Type = "OPL" Then
                '    If Query.IsVehicleExists Then
                '        Dim tahunke = Query.Lease_long
                '        If Query.Lease_long <= 12 Then
                '            tahunke = 1
                '        ElseIf Query.Lease_long <= 24 Then
                '            tahunke = 2
                '        ElseIf Query.Lease_long <= 36 Then
                '            tahunke = 3
                '        ElseIf Query.Lease_long <= 48 Then
                '            tahunke = 4
                '        ElseIf Query.Lease_long <= 60 Then
                '            tahunke = 5
                '        ElseIf Query.Lease_long <= 72 Then
                '            tahunke = 6
                '        ElseIf Query.Lease_long <= 84 Then
                '            tahunke = 7
                '        End If
                '        If ProjekRating IsNot Nothing Then
                '            If ProjekRating = "1" Or ProjekRating = "2" Or ProjekRating = "3" Or ProjekRating = "4" Or ProjekRating = "5" Then
                '                RV = 100 - (tahunke * 5)
                '            ElseIf ProjekRating = "6-1" Or ProjekRating = "6-2" Or ProjekRating = "7-1" Or ProjekRating = "7-2" Then
                '                RV = 100 - (tahunke * 10)
                '            End If
                '        End If
                '        If RV < 0 Then RV = 0
                '    Else
                '        RV = Query.RVPersen
                '    End If
                'ElseIf Query.Transaction_Type = "COP" Then
                '    RV = Query.RVPersen
                'End If



                Dim Premium = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.Project_Rating = ProjekRating).Select(Function(x) x.RiskGrading).FirstOrDefault
                Dim SwapRate = swapRateFunc(Query.Lease_long)

                'Ambil SwapRate dari CostOfFund
                'If (Query.Lease_long <= 12) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year1).FirstOrDefault
                'ElseIf (Query.Lease_long <= 24) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year2).FirstOrDefault
                'ElseIf (Query.Lease_long <= 36) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year3).FirstOrDefault
                'ElseIf (Query.Lease_long <= 48) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year4).FirstOrDefault
                'ElseIf (Query.Lease_long <= 60) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year5).FirstOrDefault
                'ElseIf (Query.Lease_long <= 72) Then
                '    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year6).FirstOrDefault
                'End If

                'ambil OJK
                Dim OJK = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.OJK).FirstOrDefault
                'Masukin FI
                Dim Funding_Rate = Premium + OJK + SwapRate



                'Validate
                If Query.Credit_Rating Is Nothing Then
                    message = "Credit_Rating is empty, Check this Customer"
                    validate = False
                ElseIf Query.Asset_Rating Is Nothing Then
                    message = "Asset_Rating is empty, Check this Model"
                    validate = False
                ElseIf IsNothing(Query.Lease_long) Then
                    message = "Lease_long is empty, Check this Prospect Customer"
                    validate = False
                ElseIf IsNothing(ProjekRating) Then
                    message = "Project_Rating is empty, Check this Asset Rating and Credit Rating"
                    validate = False
                ElseIf IsNothing(Premium) Then
                    message = "Premium is empty, Check Master RiskGrading"
                    validate = False
                ElseIf IsNothing(SwapRate) Then
                    message = "SwapRate is empty, Check Master CostOfFund"
                    validate = False
                ElseIf IsNothing(SwapRate) Then
                    message = "SwapRate is empty, Check Master CostOfFund"
                    validate = False
                End If

                'Persen asuransi kalo dia TRUCK ada tambahan persenan sama Assuransi Extra
                Dim fixedCost = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
                Dim Assurance_Percent As Decimal = fixedCost.Assurance_Percent
                Dim AssuranceExtra As Decimal = 0

                assuransiFunc(Query.IsTruck, Query.Lease_long, Assurance_Percent, AssuranceExtra)
                'If (Query.IsTruck) Then
                '    Assurance_Percent = 2.72
                '    AssuranceExtra = 685000 * (Query.Lease_long / 12)
                'End If

                If validate Then
                    Return Json(New With {Key .success = "true", Key .brand = Query.Brand_Name, .model = Query.Type, .Normal_Disc = Query.Normal_Disc, .IsVehicleExists = Query.IsVehicleExists,
                            .Transaction_Type = Query.Transaction_Type, .tahun = Query.Year, .lama = Query.Lease_long, .harga = String.Format("{0:N0}", Query.Lease_price), .OTR_Price = String.Format("{0:N0}", Query.OTR_Price),
                            .qty = Query.Qty, .total = String.Format("{0:N0}", Query.Amount), .RV = RV,
                            .Keur = String.Format("{0:N0}", Query.Keur * Query.Qty), .FundingCost = Query.FundingCost, .Project_Rating = ProjekRating, .SwapRate = SwapRate, .Premium = Premium,
                            .OJK = OJK, .Funding_Rate = Funding_Rate, .IsMultiCalculated = Query.IsMultiCalculated, .Model_ID = Query.Model_ID, .Assurance_Percent = Assurance_Percent, .AssuranceExtra = AssuranceExtra})
                Else
                    Return Json(New With {Key .success = "false", .message = message})
                End If
            End If
            Return Json(New With {Key .success = "false", .message = message})
        End Function
        Public Function FillCustomerInSimutalion(ByVal model_id As Integer?, Credit_Rating As String, Lease_long As Integer?) As ActionResult
            If Not IsNothing(model_id) And Not IsNothing(Credit_Rating) And Not IsNothing(Lease_long) Then
                Dim Query = db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False And x.Model_ID = model_id).FirstOrDefault
                Dim asset_rating = Query.Asset_Rating
                Dim Normal_Disc = Query.Normal_Disc
                Dim Project_Rating = db.Ms_ProjRatingMatrixs.Where(Function(x) x.IsDeleted = False And x.Asset_Rating = asset_rating And x.Credit_Rating = Credit_Rating).Select(Function(x) x.Project_Rating).FirstOrDefault
                Dim Premium = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.Project_Rating = Project_Rating).Select(Function(x) x.RiskGrading).FirstOrDefault
                Dim SwapRate As Decimal?

                'Ambil SwapRate dari CostOfFund
                If (Lease_long <= 12) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year1).FirstOrDefault
                ElseIf (Lease_long <= 24) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year2).FirstOrDefault
                ElseIf (Lease_long <= 36) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year3).FirstOrDefault
                ElseIf (Lease_long <= 48) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year4).FirstOrDefault
                ElseIf (Lease_long <= 60) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year5).FirstOrDefault
                ElseIf (Lease_long <= 72) Then
                    SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year6).FirstOrDefault
                End If

                'ambil OJK
                Dim OJK = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.OJK).FirstOrDefault
                'Masukin FI
                Dim Funding_Rate = Premium + OJK + SwapRate

                'assuransi kalo Truck
                Dim fixedCost = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
                Dim Assurance_Percent As Decimal = fixedCost.Assurance_Percent
                Dim AssuranceExtra As Decimal = 0

                If (Query.IsTruck) Then
                    Assurance_Percent = 2.72
                    AssuranceExtra = 685000 * (Lease_long / 12)
                End If

                Return Json(New With {Key .success = "true", .SwapRate = SwapRate, .Premium = Premium,
                            .OJK = OJK, .Funding_Rate = Funding_Rate, .Project_Rating = Project_Rating, .Normal_Disc = Normal_Disc, .Assurance_Percent = Assurance_Percent, .AssuranceExtra = AssuranceExtra})
            Else
                Return Json(New With {Key .success = "false"})
            End If
            Return Json(New With {Key .success = "false"})
        End Function

        Function expedition(ByVal rent As Integer?, ByVal plat As Integer?, ByVal model As String, Expedition_Status As String, IsVehicleExists As Boolean, Transaction_Type As String) As Tr_Calculate
            Dim cal As New Tr_Calculate
            Dim kali As Integer = 1
            If (Expedition_Status = "One Way") Then
                kali = 1
            ElseIf (Expedition_Status = "Return") Then
                kali = 2
            End If
            Dim query = db.sp_GetParameterCost(rent, model, Transaction_Type).FirstOrDefault()
            Dim iskeur = db.Ms_Vehicle_Models.Where(Function(x) x.Type = model).Select(Function(x) x.IsKeur).FirstOrDefault()

            'jika sama lokasinya maka expedisinya 0
            If plat = rent Then
                query.Expedition_Cost = 0
            End If

            Dim keur = 0
            If (If(iskeur, False)) Then
                keur = 700000
            End If
            If IsVehicleExists And query.Maintenance < 3.5 Then
                query.Maintenance = 3.5
            End If
            cal.Expedition_Cost = query.Expedition_Cost * kali
            cal.Replacement_Percent = query.Replacement
            cal.Maintenance_Percent = query.Maintenance
            cal.Keur = keur

            Return cal

        End Function
        Public Function GetExpredition(ByVal rent As Integer?, ByVal plat As Integer?, ByVal model As String, Expedition_Status As String, IsVehicleExists As Boolean, Transaction_Type As String) As ActionResult
            If rent IsNot Nothing Then
                'If rent = plat Then
                '    Return Json(New With {Key .success = "false"})
                'End If
                Dim cal As New Tr_Calculate
                cal = expedition(rent, plat, model, Expedition_Status, IsVehicleExists, Transaction_Type)
                Return Json(New With {Key .success = "true", Key .expredisi = String.Format("{0:N0}", cal.Expedition_Cost), Key .Replacement = cal.Replacement_Percent, Key .Maintenance = cal.Maintenance_Percent, .keur = String.Format("{0:N0}", cal.Keur)})
            Else
                Return Json(New With {Key .success = "false"})
            End If
        End Function
        'Public Function FillType(ByVal val As Integer?) As ActionResult
        '    If val IsNot Nothing Then
        '        If val = 0 Then
        '            Return Json(New With {Key .success = "false"})
        '        End If

        '        Dim type = db.Ms_FixCosts.Where(Function(x) x.FixCost_ID = val).FirstOrDefault()
        '        Return Json(New With {Key .success = "true", Key .repla = type.Replacement, .maintenanc = type.Maintenance,
        '                        .stn = type.Stnk, .overhea = type.Overhead, .ass = type.Insurance})
        '    Else
        '        Return Json(New With {Key .success = "false"})
        '    End If
        'End Function


        Public Sub SaveCashFlow(ByVal IsCalculate As Boolean, Calculate_ID As Integer, user As Integer, Expedition_Status As String, PayMonth As Integer, Cost_Price As Double?, DP As Double?,
                                Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, Insurance As Double?, Price_Month As Double?, RV As Double?, lama As Double?, Expedition_Cost As Double?, type As String, Payment As String, Term_Of_Payment As Integer, Modification As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, Agent_Fee As Double?, Agent_FeePerMonth As Double?, Other As Double?, Keur As Double?, Funding_Rate As Decimal?)
            'item di cashflow di declar
            Dim monthStart As Integer = 0
            If Payment = "Payment in arrear" Then
                monthStart = 0
            ElseIf Payment = "Payment in advance" Then
                monthStart = 1
            End If
            Dim Start As Boolean = True
            For i As Integer = monthStart To lama
                Dim cf_CalculateCashFlow_No As Integer = 0, cf_CashFlow As Decimal? = Nothing, cf_Lease_Payment As Decimal? = Nothing, cf_STNK As Decimal? = Nothing, cf_Replacement As Decimal? = Nothing, cf_Overhead As Decimal? = Nothing, cf_Maintenance As Decimal? = Nothing, cf_Insurance As Decimal? = Nothing, cf_Residual_Value As Decimal? = Nothing, cf_Expedition As Decimal? = Nothing, cf_Modification As Decimal? = Nothing, cf_GPS As Decimal? = Nothing, cf_Agent_Fee As Decimal? = Nothing, cf_Keur As Decimal? = Nothing, cf_Profit As Decimal? = Nothing
                cf_CalculateCashFlow_No = i
                Dim value As Double = 0
                If (Start) Then
                    value = -Cost_Price + DP - Modification - Other
                    cf_Modification = Modification
                    If Expedition_Status = "One Way" Then
                        value = value - Expedition_Cost
                        cf_Expedition = Expedition_Cost
                    ElseIf Expedition_Status = "Return" Then
                        value = value - (Expedition_Cost / 2)
                        cf_Expedition = (Expedition_Cost / 2)
                    End If

                    'jika dia ADA GPS atau AgenFee dia langsung di kenakan juga, And i = 0  karna hanya 0, kalo yg 1 ke atas udh di hadle
                    If GPS_CostPerMonth = 1 And i = 0 Then
                        value = value - GPS_Cost
                        cf_GPS = GPS_Cost
                    End If
                    If Agent_FeePerMonth = 1 And i = 0 Then
                        value = value - Agent_Fee
                        cf_Agent_Fee = Agent_Fee
                    End If

                    Start = False
                End If
                If (i > 0) Then
                    'untuk Lease Payment
                    'maksimal 6 thn
                    'Tambahan ada PayMonth, jika dia ada paymonth, dia nga di bayar bulan itu
                    If i > PayMonth Then
                        If Term_Of_Payment = 1 Then
                            value = value + Price_Month
                            cf_Lease_Payment = Price_Month
                        ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
                            value = value + Price_Month * Term_Of_Payment
                            cf_Lease_Payment = Price_Month
                        ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
                            value = value + Price_Month * Term_Of_Payment
                            cf_Lease_Payment = Price_Month
                        ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
                            value = value + Price_Month * Term_Of_Payment
                            cf_Lease_Payment = Price_Month
                        End If
                    End If


                    If GPS_CostPerMonth = 1 Then
                        'If Payment = "Payment in advance" And i = 1 Then
                        'Else
                        value = value - GPS_Cost
                        cf_GPS = GPS_Cost
                        'End If
                    ElseIf GPS_CostPerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
                        value = value - GPS_Cost
                        cf_GPS = GPS_Cost
                    ElseIf GPS_CostPerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
                        value = value - GPS_Cost
                        cf_GPS = GPS_Cost
                    ElseIf GPS_CostPerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
                        value = value - GPS_Cost
                        cf_GPS = GPS_Cost
                    End If
                    If Agent_FeePerMonth = 1 Then
                        'If Payment = "Payment in advance" And i = 1 Then
                        'Else
                        value = value - Agent_Fee
                        cf_Agent_Fee = Agent_Fee
                        'End If
                    ElseIf Agent_FeePerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
                        value = value - Agent_Fee
                        cf_Agent_Fee = Agent_Fee
                    ElseIf Agent_FeePerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
                        value = value - Agent_Fee
                        cf_Agent_Fee = Agent_Fee
                        'ElseIf Agent_FeePerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
                    ElseIf Agent_FeePerMonth = 12 And (i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66) Then
                        value = value - Agent_Fee
                        cf_Agent_Fee = Agent_Fee
                    End If
                    'STNK
                    If i = 11 Or i = 23 Or i = 35 Or i = 47 Or i = 59 Or i = 71 Or i = 83 Or i = 95 Or i = 107 Then
                        value = value - STNK
                        cf_STNK = STNK
                    End If
                    'insuran
                    If i = 1 Or i = 13 Or i = 25 Or i = 37 Or i = 49 Or i = 61 Or i = 73 Or i = 85 Or i = 97 Then
                        value = value - Insurance
                        cf_Insurance = Insurance
                    End If

                    'masukan biaya bulanan
                    If i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66 Or i = 78 Or i = 90 Or i = 102 Then
                        value = value - (Replacement + Maintenance + Overhead)
                        cf_Replacement = Replacement
                        cf_Maintenance = Maintenance
                        cf_Overhead = Overhead
                    End If

                    'masukan biaya Expedisi
                    If i = lama Then
                        If Expedition_Status = "Return" Then
                            ''dikali dia kalo return akhirnya ada lebihnya
                            'Dim dikalipertahun As Integer = 100
                            'If lama <= 12 Then
                            '    dikalipertahun = 105
                            'ElseIf lama <= 24 Then
                            '    dikalipertahun = 110
                            'ElseIf lama <= 36 Then
                            '    dikalipertahun = 115
                            'ElseIf lama <= 48 Then
                            '    dikalipertahun = 120
                            'ElseIf lama <= 60 Then
                            '    dikalipertahun = 125
                            'ElseIf lama <= 72 Then
                            '    dikalipertahun = 130
                            'End If
                            'value = value - ((Expedition_Cost / 2) * dikalipertahun / 100)
                            'cf_Expedition = ((Expedition_Cost / 2) * dikalipertahun / 100)
                            value = value - (Expedition_Cost / 2)
                            cf_Expedition = (Expedition_Cost / 2)
                        End If
                    End If
                    'masukan biaya Keur
                    If i = (6 * 1) Or i = (6 * 2) Or i = (6 * 3) Or i = (6 * 4) Or i = (6 * 5) Or i = (6 * 6) Or i = (6 * 7) Or i = (6 * 8) Or i = (6 * 9) Or i = (6 * 10) Or i = (6 * 11) Or i = (6 * 12) Then
                        value = value - Keur
                        cf_Keur = Keur
                    End If
                    'Masukin RV dan DP
                    'Kalo ada PayMonth, dia di akhir bayarnya
                    If (i = lama And PayMonth = 0) Then
                        value = value + RV
                        cf_Residual_Value = RV
                    End If
                End If
                cf_CashFlow = value
                'untuk Provit
                If Payment = "Payment in arrear" Then
                    cf_Profit = value / (1 + (Funding_Rate / 100) / 12) ^ i
                ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
                    cf_Profit = value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1)
                Else
                    cf_Profit = 0
                End If

                If IsCalculate Then
                    Dim cashFlow = New Tr_CalculateCashFlows
                    cashFlow.Calculate_ID = Calculate_ID
                    cashFlow.CalculateCashFlow_No = cf_CalculateCashFlow_No
                    cashFlow.CashFlow = cf_CashFlow
                    cashFlow.Lease_Payment = cf_Lease_Payment
                    cashFlow.STNK = cf_STNK
                    cashFlow.Replacement = cf_Replacement
                    cashFlow.OverHead = cf_Overhead
                    cashFlow.Maintenance = cf_Maintenance
                    cashFlow.Insurance = cf_Insurance
                    cashFlow.Residual_Value = cf_Residual_Value
                    cashFlow.Expedition = cf_Expedition
                    cashFlow.Modification = cf_Modification
                    cashFlow.GPS = cf_GPS
                    cashFlow.Agent_Fee = cf_Agent_Fee
                    cashFlow.Keur = cf_Keur
                    cashFlow.Profit = cf_Profit
                    cashFlow.CreatedBy = user
                    cashFlow.CreatedDate = DateTime.Now
                    cashFlow.IsDeleted = False
                    db.Tr_CalculateCashFlows.Add(cashFlow)
                Else
                    Dim cashFlow = New Tr_ApplicationCashFlows
                    cashFlow.Application_ID = Calculate_ID
                    cashFlow.CalculateCashFlow_No = cf_CalculateCashFlow_No
                    cashFlow.CashFlow = cf_CashFlow
                    cashFlow.Lease_Payment = cf_Lease_Payment
                    cashFlow.STNK = cf_STNK
                    cashFlow.Replacement = cf_Replacement
                    cashFlow.OverHead = cf_Overhead
                    cashFlow.Maintenance = cf_Maintenance
                    cashFlow.Insurance = cf_Insurance
                    cashFlow.Residual_Value = cf_Residual_Value
                    cashFlow.Expedition = cf_Expedition
                    cashFlow.Modification = cf_Modification
                    cashFlow.GPS = cf_GPS
                    cashFlow.Agent_Fee = cf_Agent_Fee
                    cashFlow.Keur = cf_Keur
                    cashFlow.Profit = cf_Profit
                    cashFlow.CreatedBy = user
                    cashFlow.CreatedDate = DateTime.Now
                    cashFlow.IsDeleted = False
                    db.Tr_ApplicationCashFlows.Add(cashFlow)
                End If
            Next
            'Ini Untuk yang PayMonth
            If PayMonth > 0 Then
                For i As Integer = lama + 1 To lama + PayMonth
                    Dim cf_CalculateCashFlow_No As Integer = 0, cf_CashFlow As Decimal? = Nothing, cf_Lease_Payment As Decimal? = Nothing, cf_STNK As Decimal? = Nothing, cf_Replacement As Decimal? = Nothing, cf_Overhead As Decimal? = Nothing, cf_Maintenance As Decimal? = Nothing, cf_Insurance As Decimal? = Nothing, cf_Residual_Value As Decimal? = Nothing, cf_Expedition As Decimal? = Nothing, cf_Modification As Decimal? = Nothing, cf_GPS As Decimal? = Nothing, cf_Agent_Fee As Decimal? = Nothing, cf_Keur As Decimal? = Nothing, cf_Profit As Decimal? = Nothing
                    cf_CalculateCashFlow_No = i
                    Dim value As Double = 0
                    If Term_Of_Payment = 1 Then
                        value = value + Price_Month
                        cf_Lease_Payment = Price_Month
                    ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
                        value = value + Price_Month * Term_Of_Payment
                        cf_Lease_Payment = Price_Month
                    ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
                        value = value + Price_Month * Term_Of_Payment
                        cf_Lease_Payment = Price_Month
                    ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
                        value = value + Price_Month * Term_Of_Payment
                        cf_Lease_Payment = Price_Month
                    End If

                    If (i = lama + PayMonth) Then
                        value = value + RV
                        cf_Residual_Value = RV
                    End If
                    cf_CashFlow = value

                    'untuk Provit
                    If Payment = "Payment in arrear" Then
                        cf_Profit = value / (1 + (Funding_Rate / 100) / 12) ^ i
                    ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
                        cf_Profit = value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1)
                    Else
                        cf_Profit = 0
                    End If

                    If IsCalculate Then
                        Dim cashFlow = New Tr_CalculateCashFlows
                        cashFlow.Calculate_ID = Calculate_ID
                        cashFlow.CalculateCashFlow_No = cf_CalculateCashFlow_No
                        cashFlow.CashFlow = cf_CashFlow
                        cashFlow.Lease_Payment = cf_Lease_Payment
                        cashFlow.STNK = cf_STNK
                        cashFlow.Replacement = cf_Replacement
                        cashFlow.OverHead = cf_Overhead
                        cashFlow.Maintenance = cf_Maintenance
                        cashFlow.Insurance = cf_Insurance
                        cashFlow.Residual_Value = cf_Residual_Value
                        cashFlow.Expedition = cf_Expedition
                        cashFlow.Modification = cf_Modification
                        cashFlow.GPS = cf_GPS
                        cashFlow.Agent_Fee = cf_Agent_Fee
                        cashFlow.Keur = cf_Keur
                        cashFlow.Profit = cf_Profit
                        cashFlow.CreatedBy = user
                        cashFlow.CreatedDate = DateTime.Now
                        cashFlow.IsDeleted = False
                        db.Tr_CalculateCashFlows.Add(cashFlow)
                    Else
                        Dim cashFlow = New Tr_ApplicationCashFlows
                        cashFlow.Application_ID = Calculate_ID
                        cashFlow.CalculateCashFlow_No = cf_CalculateCashFlow_No
                        cashFlow.CashFlow = cf_CashFlow
                        cashFlow.Lease_Payment = cf_Lease_Payment
                        cashFlow.STNK = cf_STNK
                        cashFlow.Replacement = cf_Replacement
                        cashFlow.OverHead = cf_Overhead
                        cashFlow.Maintenance = cf_Maintenance
                        cashFlow.Insurance = cf_Insurance
                        cashFlow.Residual_Value = cf_Residual_Value
                        cashFlow.Expedition = cf_Expedition
                        cashFlow.Modification = cf_Modification
                        cashFlow.GPS = cf_GPS
                        cashFlow.Agent_Fee = cf_Agent_Fee
                        cashFlow.Keur = cf_Keur
                        cashFlow.Profit = cf_Profit
                        cashFlow.CreatedBy = user
                        cashFlow.CreatedDate = DateTime.Now
                        cashFlow.IsDeleted = False
                        db.Tr_ApplicationCashFlows.Add(cashFlow)
                    End If
                Next
            End If

            db.SaveChanges()
        End Sub


        Public Sub CalIRR(Expedition_Status As String, PayMonth As Integer?, Cost_Price As Double?, DP As Double?, Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, Insurance As Double?, Price_Month As Double?, RV As Double?, lama As Double?, Expedition_Cost As Double?, type As String, Payment As String, Term_Of_Payment As Integer?, Modification As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, Agent_Fee As Double?, Agent_FeePerMonth As Double?, Other As Double?, Keur As Double?, Funding_Rate As Decimal?, ByRef IRRValue As Decimal?, ByRef Profit As Decimal?)
            'Dim list As Double()
            Dim monthStart As Integer = 0
            If Payment = "Payment in arrear" Then
                monthStart = 0
            ElseIf Payment = "Payment in advance" Then
                monthStart = 1
            End If
            Dim list As New List(Of Double)
            Dim listProfit As New List(Of Decimal)
            Dim Start As Boolean = True
            For i As Integer = monthStart To lama
                Dim value As Double = 0
                If (Start) Then
                    value = -Cost_Price + DP - Modification - Other
                    If Expedition_Status = "One Way" Then
                        value = value - Expedition_Cost
                    ElseIf Expedition_Status = "Return" Then
                        value = value - (Expedition_Cost / 2)
                    End If

                    'jika dia ADA GPS atau AgenFee dia langsung di kenakan juga
                    If GPS_CostPerMonth = 1 And i = 0 Then
                        value = value - GPS_Cost
                    End If
                    If Agent_FeePerMonth = 1 And i = 0 Then
                        value = value - Agent_Fee
                    End If

                    Start = False
                End If
                If (i > 0) Then
                    'untuk Lease Payment
                    'maksimal 6 thn
                    If i > PayMonth Then
                        If Term_Of_Payment = 1 Then
                            value = value + Price_Month
                        ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
                            value = value + Price_Month * Term_Of_Payment
                        ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
                            value = value + Price_Month * Term_Of_Payment
                        ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
                            value = value + Price_Month * Term_Of_Payment
                        End If
                    End If



                    If GPS_CostPerMonth = 1 Then
                        'If Payment = "Payment in advance" And i = 1 Then
                        'Else
                        value = value - GPS_Cost
                        'End If
                    ElseIf GPS_CostPerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
                        value = value - GPS_Cost
                    ElseIf GPS_CostPerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
                        value = value - GPS_Cost
                    ElseIf GPS_CostPerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
                        value = value - GPS_Cost
                    End If
                    If Agent_FeePerMonth = 1 Then
                        'If Payment = "Payment in advance" And i = 1 Then
                        'Else
                        value = value - Agent_Fee
                        'End If
                    ElseIf Agent_FeePerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
                        value = value - Agent_Fee
                    ElseIf Agent_FeePerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
                        value = value - Agent_Fee
                        'ElseIf Agent_FeePerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
                    ElseIf Agent_FeePerMonth = 12 And (i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66) Then
                        value = value - Agent_Fee
                    End If
                    'STNK
                    If i = 11 Or i = 23 Or i = 35 Or i = 47 Or i = 59 Or i = 71 Or i = 83 Or i = 95 Or i = 107 Then
                        value = value - STNK
                    End If
                    'insuran
                    If i = 1 Or i = 13 Or i = 25 Or i = 37 Or i = 49 Or i = 61 Or i = 73 Or i = 85 Or i = 97 Then
                        value = value - Insurance
                    End If

                    'masukan biaya bulanan
                    If i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66 Or i = 78 Or i = 90 Or i = 102 Then
                        value = value - (Replacement + Maintenance + Overhead)
                    End If
                    'masukan biaya Expedisi
                    If i = lama Then
                        If Expedition_Status = "Return" Then
                            'dikali dia kalo return akhirnya ada lebihnya
                            'Dim dikalipertahun As Integer = 100
                            'If lama <= 12 Then
                            '    dikalipertahun = 105
                            'ElseIf lama <= 24 Then
                            '    dikalipertahun = 110
                            'ElseIf lama <= 36 Then
                            '    dikalipertahun = 115
                            'ElseIf lama <= 48 Then
                            '    dikalipertahun = 120
                            'ElseIf lama <= 60 Then
                            '    dikalipertahun = 125
                            'ElseIf lama <= 72 Then
                            '    dikalipertahun = 130
                            'End If
                            'value = value - ((Expedition_Cost / 2) * dikalipertahun / 100)
                            value = value - (Expedition_Cost / 2)
                        End If
                    End If

                    'masukan biaya Keur
                    If i = (6 * 1) Or i = (6 * 2) Or i = (6 * 3) Or i = (6 * 4) Or i = (6 * 5) Or i = (6 * 6) Or i = (6 * 7) Or i = (6 * 8) Or i = (6 * 9) Or i = (6 * 10) Or i = (6 * 11) Or i = (6 * 12) Then
                        value = value - Keur
                    End If
                    'Masukin RV dan DP
                    If (i = lama And PayMonth = 0) Then
                        value = value + RV
                    End If
                End If
                list.Add(value)

                'untuk Provit
                If Payment = "Payment in arrear" Then
                    listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
                ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
                    listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
                Else
                    listProfit.Add(0)
                End If
            Next
            'Ini Untuk yang PayMonth
            If PayMonth > 0 Then
                For i As Integer = lama + 1 To lama + PayMonth
                    Dim value As Double = 0
                    If Term_Of_Payment = 1 Then
                        value = value + Price_Month
                    ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
                        value = value + Price_Month * Term_Of_Payment
                    ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
                        value = value + Price_Month * Term_Of_Payment
                    ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
                        value = value + Price_Month * Term_Of_Payment
                    End If

                    If (i = lama + PayMonth) Then
                        value = value + RV
                    End If
                    list.Add(value)

                    'untuk Provit
                    If Payment = "Payment in arrear" Then
                        listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
                    ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
                        listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
                    Else
                        listProfit.Add(0)
                    End If
                Next
            End If
            IRRValue = IRR(list.ToArray, 0.001) * 12 * 100
            Profit = listProfit.Sum
        End Sub

        'Function CalIRR(PayMonth As Integer?, Cost_Price As Double?, DP As Double?, Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, Insurance As Double?, Price_Month As Double?, RV As Double?, lama As Double?, Expedition_Cost As Double?, type As String, Payment As String, Term_Of_Payment As Integer?, Modification As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, Agent_Fee As Double?, Agent_FeePerMonth As Double?, Other As Double?, Keur As Double?, Funding_Rate As Decimal?, ByRef IRRValue As Decimal?, ByRef Profit As Decimal?)
        '    'Dim list As Double()
        '    Dim monthStart As Integer = 0
        '    If Payment = "Payment in arrear" Then
        '        monthStart = 0
        '    ElseIf Payment = "Payment in advance" Then
        '        monthStart = 1
        '    End If
        '    Dim list As New List(Of Double)
        '    Dim listProfit As New List(Of Decimal)
        '    Dim Start As Boolean = True
        '    For i As Integer = monthStart To lama
        '        Dim value As Double = 0
        '        If (Start) Then
        '            value = -Cost_Price + DP - Modification - Other
        '            Start = False
        '        End If
        '        If (i > 0) Then
        '            'untuk Lease Payment
        '            'maksimal 6 thn
        '            If i > PayMonth Then
        '                If Term_Of_Payment = 1 Then
        '                    value = value + Price_Month
        '                ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
        '                    value = value + Price_Month * Term_Of_Payment
        '                ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
        '                    value = value + Price_Month * Term_Of_Payment
        '                ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
        '                    value = value + Price_Month * Term_Of_Payment
        '                End If
        '            End If



        '            If GPS_CostPerMonth = 1 Then
        '                If Payment = "Payment in advance" And i = 1 Then
        '                Else
        '                    value = value - GPS_Cost
        '                End If
        '            ElseIf GPS_CostPerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
        '                value = value - GPS_Cost
        '            ElseIf GPS_CostPerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
        '                value = value - GPS_Cost
        '            ElseIf GPS_CostPerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
        '                value = value - GPS_Cost
        '            End If
        '            If Agent_FeePerMonth = 1 Then
        '                If Payment = "Payment in advance" And i = 1 Then
        '                Else
        '                    value = value - Agent_Fee
        '                End If
        '            ElseIf Agent_FeePerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
        '                value = value - Agent_Fee
        '            ElseIf Agent_FeePerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
        '                value = value - Agent_Fee
        '            ElseIf Agent_FeePerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
        '                value = value - Agent_Fee
        '            End If
        '            'masukan biaya bulanan
        '            If i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66 Or i = 78 Or i = 90 Or i = 102 Then
        '                value = value - (Replacement + Maintenance + STNK + Overhead + Insurance)
        '            End If
        '            'masukan biaya Expedisi
        '            If i = 6 Then
        '                If type = "COP" Then
        '                    value = value - Expedition_Cost
        '                ElseIf type = "OPL" Then
        '                    value = value - (Expedition_Cost / 2)
        '                End If
        '            ElseIf i = (lama - 6) Then
        '                If type = "OPL" Then
        '                    value = value - (Expedition_Cost / 2)
        '                End If
        '            End If
        '            'masukan biaya Keur
        '            If i = (6 * 1) Or i = (6 * 2) Or i = (6 * 3) Or i = (6 * 4) Or i = (6 * 5) Or i = (6 * 6) Or i = (6 * 7) Or i = (6 * 8) Or i = (6 * 9) Or i = (6 * 10) Or i = (6 * 11) Or i = (6 * 12) Then
        '                value = value - Keur
        '            End If
        '            'Masukin RV dan DP
        '            If (i = lama And PayMonth = 0) Then
        '                value = value + RV
        '            End If
        '        End If
        '        list.Add(value)

        '        'untuk Provit
        '        If Payment = "Payment in arrear" Then
        '            listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
        '        ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
        '            listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
        '        Else
        '            listProfit.Add(0)
        '        End If
        '    Next
        '    'Ini Untuk yang PayMonth
        '    If PayMonth > 0 Then
        '        For i As Integer = lama + 1 To lama + PayMonth
        '            Dim value As Double = 0
        '            If Term_Of_Payment = 1 Then
        '                value = value + Price_Month
        '            ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
        '                value = value + Price_Month * Term_Of_Payment
        '            ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
        '                value = value + Price_Month * Term_Of_Payment
        '            ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
        '                value = value + Price_Month * Term_Of_Payment
        '            End If

        '            If (i = lama + PayMonth) Then
        '                value = value + RV
        '            End If
        '            list.Add(value)

        '            'untuk Provit
        '            If Payment = "Payment in arrear" Then
        '                listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
        '            ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
        '                listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
        '            Else
        '                listProfit.Add(0)
        '            End If
        '        Next
        '    End If
        '    IRRValue = IRR(list.ToArray, 0.001) * 12 * 100
        '    Profit = listProfit.Sum
        'End Function


        Function CalLease_Profit(ByVal Lease_Profit_Percent As Decimal?, Cost_Price As Double?, lama As Double?) As Decimal?
            Try
                Return (Lease_Profit_Percent * Cost_Price * lama) / 12 / 100
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CalPrice_Month(ByVal Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, lama As Double?, Insurance As Double?, Depresiasi As Decimal?, Expedition_Cost As Double?, Modification As Double?, Funding_Interest As Decimal?, Other As Double?, Lease_Profit As Decimal?) As Decimal?
            Try
                Dim cost = (Replacement + Maintenance + STNK + Overhead + (GPS_Cost / GPS_CostPerMonth)) * (lama / 12)
                Dim Fix_Cost = Insurance + Depresiasi + Expedition_Cost + Modification
                Dim Interest = Funding_Interest + CType(Other, Decimal)
                Dim total = CType(cost + Fix_Cost + Interest, Decimal)
                Dim leaseRent = CType(((total * (1 / 98 * 100)) / lama) + Lease_Profit / lama, Decimal)
                Return Math.Ceiling(leaseRent / 1000) * 1000

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Function CalRV(CostPrice As Double?, RVPerc As Decimal, ByRef DepresiasiPercent As Decimal, ByRef Depresiasi As Double) As Decimal?
            Try
                Dim RV = CostPrice * RVPerc / 100
                DepresiasiPercent = 100 - RVPerc
                Depresiasi = CostPrice * DepresiasiPercent / 100
                Return RV

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        Private Function CalDP(CostPrice As Double?, DPPercent As Decimal) As Decimal?
            Return CostPrice * DPPercent / 100
        End Function

        Public Function FillIRRGoalSeek(ByVal Expedition_Status As String, PayMonth As Integer?, Cost_Price As Double?, DP As Double?, DPPercent As Decimal?, Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, Insurance As Double?, Price_Month As Double?, RV As Double?, RVPercent As Decimal?, lama As Double?, Expedition_Cost As Double?, type As String, Payment As String, Term_Of_Payment As Integer?, Modification As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, Agent_Fee As Double?, Agent_FeePerMonth As Double?, Other As Double?, Keur As Double?, Funding_Rate As Decimal?, Depresiasi As Decimal?, DepresiasiPercent As Decimal?, Funding_Interest As Decimal?, GoalSeek As String, GoalSeekVal As Decimal?, Lease_Profit As Decimal?, Lease_Profit_Percent As Decimal?, IsVehicleExists As Boolean?, New_Vehicle_Price As Decimal?, Gross As Decimal?) As ActionResult
            Try

                If Price_Month IsNot Nothing Then
                    Dim result As String = "Error"
                    Dim Message As String = ""
                    Dim Validate As Boolean = True
#Region "Validasi"
                    If Term_Of_Payment Is Nothing Then
                        Message = "Payment Scheme must be fill"
                        Validate = False
                    ElseIf IsNothing(Expedition_Status) Then
                        Message = "Expedition_Status must be fill"
                        Validate = False
                    ElseIf IsNothing(PayMonth) Then
                        Message = "PayMonth must be fill"
                        Validate = False
                    End If
#End Region
                    If Not Validate Then Return Json(New With {Key .success = "false", .message = Message})

                    Dim Replacement_Percent As Double?, Maintenance_Percent As Double?, STNK_Percent As Double?, Overhead_Percent As Double?, Assurance_Percent As Double?
                    If GoalSeek = "Replacement" Then
                        Replacement_Percent = GoalSeekVal * 100 / Cost_Price
                        Replacement = GoalSeekVal
                    ElseIf GoalSeek = "Maintenance" Then
                        If IsVehicleExists Then
                            Maintenance_Percent = GoalSeekVal * 100 / New_Vehicle_Price
                            Maintenance = GoalSeekVal
                        Else
                            Maintenance_Percent = GoalSeekVal * 100 / Cost_Price
                            Maintenance = GoalSeekVal
                        End If
                    ElseIf GoalSeek = "STNK" Then
                        If IsVehicleExists Then
                            STNK_Percent = GoalSeekVal * 100 / New_Vehicle_Price
                            STNK = GoalSeekVal
                        Else
                            STNK_Percent = GoalSeekVal * 100 / Gross
                            STNK = GoalSeekVal
                        End If
                    ElseIf GoalSeek = "Overhead" Then
                        Overhead_Percent = GoalSeekVal * 100 / Cost_Price
                        Overhead = GoalSeekVal
                    ElseIf GoalSeek = "Assurance" Then
                        If IsVehicleExists Then
                            Assurance_Percent = GoalSeekVal * 100 / Math.Pow(0.955, lama / 12) * 12 / lama / (New_Vehicle_Price + Modification)
                            Insurance = GoalSeekVal
                        Else
                            Assurance_Percent = GoalSeekVal * 100 / Math.Pow(0.955, lama / 12) * 12 / lama / (Gross + Modification)
                            Insurance = GoalSeekVal
                        End If
                    End If

                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                    DP = CalDP(Cost_Price, DPPercent)
                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                    'GoalSeek Price Month
                    'upFront Fee
                    If GoalSeek = "UpFrontFee" Then
                        DP = GoalSeekVal
                        DPPercent = DP * 100 / Cost_Price
                    End If
                    'RV
                    If GoalSeek = "RV" Then
                        If Not (GoalSeekVal = 0 Or GoalSeekVal Is Nothing) Then
                            If RV = GoalSeekVal Then GoTo lastrv
                            If RV > GoalSeekVal Then
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.01
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.01
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.0001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.0001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.00001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.00001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.0000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.0000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.00000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.00000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.0000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.0000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.00000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.00000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv
                                RVPercent = RVPercent + 0.000000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV > GoalSeekVal
                                    RVPercent = RVPercent - 0.0000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV < GoalSeekVal Then
                                    RVPercent = RVPercent + 0.0000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End If
lastrv:
                            ElseIf RV < GoalSeekVal Then
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.01
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.01
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.0001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.0001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.00001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.00001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.0000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.0000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.00000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.00000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.0000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.0000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.00000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.00000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV = GoalSeekVal Then GoTo lastrv1
                                RVPercent = RVPercent - 0.000000000001
                                RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                While RV < GoalSeekVal
                                    RVPercent = RVPercent + 0.0000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End While
                                If RV > GoalSeekVal Then
                                    RVPercent = RVPercent - 0.0000000000001
                                    RV = CalRV(Cost_Price, RVPercent, DepresiasiPercent, Depresiasi)
                                End If
lastrv1:
                            End If
                        End If
                    End If


                    If GoalSeek = "PerMonth" Then
                        If Not (GoalSeekVal = 0 Or GoalSeekVal Is Nothing) Then
                            If Price_Month = GoalSeekVal Then GoTo last
                            Lease_Profit_Percent = FormatNumber(Lease_Profit_Percent)
                            Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                            Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                            If Price_Month > GoalSeekVal Then
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.0001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.0001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.00001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.00001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.0000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.0000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.00000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.00000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.0000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.0000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.00000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.00000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last
                                Lease_Profit_Percent = Lease_Profit_Percent + 0.000000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.0000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                'If Price_Month = GoalSeekVal Then GoTo last
                                'Lease_Profit_Percent = Lease_Profit_Percent + 0.0000000000001
                                'Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                'Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                'While Price_Month > GoalSeekVal
                                '    Lease_Profit_Percent = Lease_Profit_Percent - 0.00000000000001
                                '    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                '    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                'End While
                                If Price_Month < GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.0000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End If
last:
                            ElseIf Price_Month < GoalSeekVal Then
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.0001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.0001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.00001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.00001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.0000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.0000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.00000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.00000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.0000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.0000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.00000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.00000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                If Price_Month = GoalSeekVal Then GoTo last1
                                Lease_Profit_Percent = Lease_Profit_Percent - 0.000000000001
                                Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                While Price_Month < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.0000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End While
                                'If Price_Month = GoalSeekVal Then GoTo last1
                                'Lease_Profit_Percent = Lease_Profit_Percent - 0.0000000000001
                                'Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                'Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)

                                'While Price_Month < GoalSeekVal
                                '    Lease_Profit_Percent = Lease_Profit_Percent + 0.00000000000001
                                '    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                '    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                'End While
                                If Price_Month > GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.0000000000001
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                End If
last1:
                            End If
                        End If
                    End If



                    Dim IRRVal As Decimal?
                    Dim Profit As Decimal?

                    Dim AssuranceCashFlow = Insurance / (lama / 12)
                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                    Dim Spread = IRRVal - Funding_Rate

                    'GoalSeek IRR
                    If GoalSeek = "IRR" Then
                        If Not (GoalSeekVal = 0 Or GoalSeekVal Is Nothing Or Not (CType(GoalSeekVal, Decimal) <= 100 And CType(GoalSeekVal, Decimal) >= 1)) Then
                            If IRRVal > GoalSeekVal Then
                                While IRRVal > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End While
                                If IRRVal < GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End If
                            ElseIf IRRVal < GoalSeekVal Then
                                While IRRVal < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End While
                                If IRRVal > GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End If
                            End If
                        End If
                    End If

                    'GoalSeek Price Month
                    If GoalSeek = "Spread" Then
                        If Not (GoalSeekVal Is Nothing Or Not (CType(GoalSeekVal, Decimal) <= 100 And CType(GoalSeekVal, Decimal) >= 0)) Then
                            If Spread > GoalSeekVal Then
                                While Spread > GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End While
                                If Spread < GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End If
                            ElseIf Spread < GoalSeekVal Then
                                While Spread < GoalSeekVal
                                    Lease_Profit_Percent = Lease_Profit_Percent + 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End While
                                If Spread > GoalSeekVal Then
                                    Lease_Profit_Percent = Lease_Profit_Percent - 0.01
                                    Lease_Profit = CalLease_Profit(Lease_Profit_Percent, Cost_Price, lama)
                                    Price_Month = CalPrice_Month(Replacement, Maintenance, STNK, Overhead, GPS_Cost, GPS_CostPerMonth, lama, Insurance, Depresiasi, Expedition_Cost, Modification, Funding_Interest, Other, Lease_Profit)
                                    CalIRR(Expedition_Status, PayMonth, Cost_Price, DP, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Price_Month, RV, lama, Expedition_Cost, type, Payment, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate, IRRVal, Profit)
                                    Spread = IRRVal - Funding_Rate
                                End If
                            End If
                        End If
                    End If

                    Return Json(New With {Key .success = "true", Key .irr = IRRVal, .Profit = Profit, .Spread = Spread, .Lease_Profit = Lease_Profit, .Lease_Profit_Percent = Lease_Profit_Percent, .Price_Month = Price_Month, .RV = RV, .RVPercent = RVPercent, .Depresiasi = Depresiasi, .DepresiasiPercent = DepresiasiPercent, .DP = DP, .DPPercent = DPPercent,
                                .Replacement = Replacement, .Replacement_Percent = Replacement_Percent, .Maintenance = Maintenance, .Maintenance_Percent = Maintenance_Percent, .STNK = STNK, .STNK_Percent = STNK_Percent,
                                .Overhead = Overhead, .Overhead_Percent = Overhead_Percent, .Assurance = Insurance, .Assurance_Percent = Assurance_Percent})
                End If
                Return Json(New With {Key .success = "false", .message = ""})
            Catch ex As Exception
                Return Json(New With {Key .success = "false", .message = ex.Message})
            End Try
        End Function

        '        Public Function FillIRR(ByVal Expedition_Status As String, PayMonth As Integer?, Cost_Price As Double?, DP As Double?, Replacement As Double?, Maintenance As Double?, STNK As Double?, Overhead As Double?, Insurance As Double?, Price_Month As Double?, RV As Double?, lama As Double?, Expedition_Cost As Double?, type As String, Payment As String, Term_Of_Payment As Integer?, Modification As Double?, GPS_Cost As Double?, GPS_CostPerMonth As Double?, Agent_Fee As Double?, Agent_FeePerMonth As Double?, Other As Double?, Keur As Double?, Funding_Rate As Decimal?) As ActionResult
        '            If Price_Month IsNot Nothing Then
        '                Dim result As String = "Error"
        '                Dim Message As String = ""
        '                Dim Validate As Boolean = True
        '#Region "Validasi"
        '                If Term_Of_Payment Is Nothing Then
        '                    Message = "Payment Scheme must be fill"
        '                    Validate = False
        '                ElseIf IsNothing(Expedition_Status) Then
        '                    Message = "Expedition_Status must be fill"
        '                    Validate = False
        '                ElseIf IsNothing(PayMonth) Then
        '                    Message = "PayMonth must be fill"
        '                    Validate = False
        '                End If
        '#End Region
        '                If Not Validate Then
        '                    Return Json(New With {Key .success = "false", .message = Message})
        '                End If
        '                'Dim list As Double()
        '                Dim monthStart As Integer = 0
        '                If Payment = "Payment in arrear" Then
        '                    monthStart = 0
        '                ElseIf Payment = "Payment in advance" Then
        '                    monthStart = 1
        '                End If
        '                Dim list As New List(Of Double)
        '                Dim listProfit As New List(Of Decimal)
        '                Dim Start As Boolean = True
        '                For i As Integer = monthStart To lama
        '                    Dim value As Double = 0
        '                    If (Start) Then
        '                        value = -Cost_Price + DP - Modification - Other
        '                        Start = False
        '                    End If
        '                    If (i > 0) Then
        '                        'untuk Lease Payment
        '                        'maksimal 6 thn
        '                        If i > PayMonth Then
        '                            If Term_Of_Payment = 1 Then
        '                                value = value + Price_Month
        '                            ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
        '                                value = value + Price_Month * Term_Of_Payment
        '                            ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
        '                                value = value + Price_Month * Term_Of_Payment
        '                            ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
        '                                value = value + Price_Month * Term_Of_Payment
        '                            End If
        '                        End If



        '                        If GPS_CostPerMonth = 1 Then
        '                            If Payment = "Payment in advance" And i = 1 Then
        '                            Else
        '                                value = value - GPS_Cost
        '                            End If
        '                        ElseIf GPS_CostPerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
        '                            value = value - GPS_Cost
        '                        ElseIf GPS_CostPerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
        '                            value = value - GPS_Cost
        '                        ElseIf GPS_CostPerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
        '                            value = value - GPS_Cost
        '                        End If
        '                        If Agent_FeePerMonth = 1 Then
        '                            If Payment = "Payment in advance" And i = 1 Then
        '                            Else
        '                                value = value - Agent_Fee
        '                            End If
        '                        ElseIf Agent_FeePerMonth = 3 And (i = 3 Or i = 6 Or i = 9 Or i = 12 Or i = 15 Or i = 18 Or i = 21 Or i = 24 Or i = 27 Or i = 30 Or i = 33 Or i = 36 Or i = 39 Or i = 42 Or i = 45 Or i = 48 Or i = 51 Or i = 54 Or i = 57 Or i = 60 Or i = 63 Or i = 66 Or i = 69 Or i = 72 Or i = 75) Then
        '                            value = value - Agent_Fee
        '                        ElseIf Agent_FeePerMonth = 6 And (i = 6 Or i = 12 Or i = 18 Or i = 24 Or i = 30 Or i = 36 Or i = 42 Or i = 48 Or i = 54 Or i = 60 Or i = 66 Or i = 72) Then
        '                            value = value - Agent_Fee
        '                        ElseIf Agent_FeePerMonth = 12 And (i = 12 Or i = 24 Or i = 36 Or i = 48 Or i = 60 Or i = 72) Then
        '                            value = value - Agent_Fee
        '                        End If
        '                        'masukan biaya bulanan
        '                        If i = 6 Or i = 18 Or i = 30 Or i = 42 Or i = 54 Or i = 66 Or i = 78 Or i = 90 Or i = 102 Then
        '                            value = value - (Replacement + Maintenance + STNK + Overhead + Insurance)
        '                        End If
        '                        'masukan biaya Expedisi
        '                        If i = 6 Then
        '                            If type = "COP" Then
        '                                value = value - Expedition_Cost
        '                            ElseIf type = "OPL" Then
        '                                value = value - (Expedition_Cost / 2)
        '                            End If
        '                        ElseIf i = (lama - 6) Then
        '                            If type = "OPL" Then
        '                                value = value - (Expedition_Cost / 2)
        '                            End If
        '                        End If
        '                        'masukan biaya Keur
        '                        If i = (6 * 1) Or i = (6 * 2) Or i = (6 * 3) Or i = (6 * 4) Or i = (6 * 5) Or i = (6 * 6) Or i = (6 * 7) Or i = (6 * 8) Or i = (6 * 9) Or i = (6 * 10) Or i = (6 * 11) Or i = (6 * 12) Then
        '                            value = value - Keur
        '                        End If
        '                        'Masukin RV dan DP
        '                        If (i = lama And PayMonth = 0) Then
        '                            value = value + RV
        '                        End If
        '                    End If
        '                    list.Add(value)

        '                    'untuk Provit
        '                    If Payment = "Payment in arrear" Then
        '                        listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
        '                    ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
        '                        listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
        '                    Else
        '                        listProfit.Add(0)
        '                    End If
        '                Next
        '                'Ini Untuk yang PayMonth
        '                If PayMonth > 0 Then
        '                    For i As Integer = lama + 1 To lama + PayMonth
        '                        Dim value As Double = 0
        '                        If Term_Of_Payment = 1 Then
        '                            value = value + Price_Month
        '                        ElseIf Term_Of_Payment = 3 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12) Or i = 1 + (Term_Of_Payment * 13) Or i = 1 + (Term_Of_Payment * 14) Or i = 1 + (Term_Of_Payment * 15) Or i = 1 + (Term_Of_Payment * 16) Or i = 1 + (Term_Of_Payment * 17) Or i = 1 + (Term_Of_Payment * 18) Or i = 1 + (Term_Of_Payment * 19) Or i = 1 + (Term_Of_Payment * 20) Or i = 1 + (Term_Of_Payment * 21) Or i = 1 + (Term_Of_Payment * 22) Or i = 1 + (Term_Of_Payment * 23) Or i = 1 + (Term_Of_Payment * 24)) Then
        '                            value = value + Price_Month * Term_Of_Payment
        '                        ElseIf Term_Of_Payment = 6 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6) Or i = 1 + (Term_Of_Payment * 7) Or i = 1 + (Term_Of_Payment * 8) Or i = 1 + (Term_Of_Payment * 9) Or i = 1 + (Term_Of_Payment * 10) Or i = 1 + (Term_Of_Payment * 11) Or i = 1 + (Term_Of_Payment * 12)) Then
        '                            value = value + Price_Month * Term_Of_Payment
        '                        ElseIf Term_Of_Payment = 12 And (i = 1 Or i = 1 + (Term_Of_Payment * 1) Or i = 1 + (Term_Of_Payment * 2) Or i = 1 + (Term_Of_Payment * 3) Or i = 1 + (Term_Of_Payment * 4) Or i = 1 + (Term_Of_Payment * 5) Or i = 1 + (Term_Of_Payment * 6)) Then
        '                            value = value + Price_Month * Term_Of_Payment
        '                        End If

        '                        If (i = lama + PayMonth) Then
        '                            value = value + RV
        '                        End If
        '                        list.Add(value)

        '                        'untuk Provit
        '                        If Payment = "Payment in arrear" Then
        '                            listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ i)
        '                        ElseIf Payment = "Payment in advance" And i - 1 >= 0 Then
        '                            listProfit.Add(value / (1 + (Funding_Rate / 100) / 12) ^ (i - 1))
        '                        Else
        '                            listProfit.Add(0)
        '                        End If
        '                    Next
        '                End If
        '                Return Json(New With {Key .success = "true", Key .irr = IRR(list.ToArray, 0.001) * 12 * 100, .Profit = listProfit.Sum})
        '            End If
        '            Return Json(New With {Key .success = "false"})
        '        End Function

        Public Function PMTProccess(ByVal IRR As Double?, lama As Integer?, Cost_Price As Double?, Residual_Value As Double?,
                                    Modification As Double?, GPS_Cost As Double?, GPS_Cost_Month As Double?, Agent_Fee As Double?, Agent_Fee_Month As Double?, Expedition_Cost As Double?,
                                    Keur As Double?, Other As Double?) As ActionResult
            If IRR IsNot Nothing Or lama IsNot Nothing Or Cost_Price IsNot Nothing Or Residual_Value IsNot Nothing Then

                Return Json(New With {Key .success = "true", Key .PerMonth = Pmt(IRR / 100 / 12, lama, -Cost_Price, Residual_Value, 0)})
            End If
            Return Json(New With {Key .success = "false"})
        End Function

        Function GetFundingCost(ByVal lama As Integer?) As ActionResult
            Dim percent = (From A In db.Ms_FundingCosts
                           Where lama >= A.MonthFrom And lama <= A.MonthTo
                           Select A.FundingCost).FirstOrDefault
            Return Json(New With {Key .percent = percent})
        End Function

        Function GetVehicle(ByVal ID As Integer?) As ActionResult
            Dim list As List(Of SelectListItem) = New List(Of SelectListItem)

            'For Each row In db.V_ProspectCustDetails.Where(Function(p) p.ProspectCustomer_ID = CType(ID, Integer) And p.IsCalculate = CType(False, Nullable(Of Boolean)))
            '    list.Add(New SelectListItem With {.Text = Convert.ToString(row.Vehicle), .Value = Convert.ToString(row.ProspectCustomerDetail_ID)})
            'Next

            Dim lists = (From A In db.V_ProspectCustDetails
                         Where A.ProspectCustomer_ID = ID And A.IsCalculate = False And ((A.IsMultiCalculated = False) Or (A.IsMultiCalculated = True And A.Lease_long = 12))
                         Select A.Vehicle, A.ProspectCustomerDetail_ID).ToList

            For Each i In lists
                list.Add(New SelectListItem With {.Text = Convert.ToString(i.Vehicle), .Value = Convert.ToString(i.ProspectCustomerDetail_ID)})
            Next
            Return Json(New SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet))
        End Function
#End Region
        ' GET: Calculate
        Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim user As Integer? = Session("ID")
            Dim role_ID As Integer? = Session("Role_ID")
            Dim department_ID As Integer? = Session("Department_ID")

            ViewBag.CurrentSort = sortOrder
            If Not searchString Is Nothing Then
                page = 1
            Else
                searchString = currentFilter
            End If
            ViewBag.CurrentFilter = searchString
            ViewBag.pageSize = pageSize
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If

            Dim Query = From A In db.Tr_Calculates.Where(Function(x) x.IsDeleted = False)
                        Group Join B In db.V_ProspectCustDetails.Where(Function(x) x.Status = "Finish") On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into AB = Group
                        From B In AB.DefaultIfEmpty
                        Select New Tr_Calculate With {.Calculate_ID = A.Calculate_ID, .CompanyGroup_Name = B.CompanyGroup_Name, .Company_Name = B.Company_Name, .IsVehicleExists = B.IsVehicleExists,
                                .Brand_Name = B.Brand_Name, .Vehicle = B.Vehicle, .Amount = B.Amount, .IsQuotation = B.IsQuotation,
                                .Rent_Location_ID = A.Rent_Location_ID, .Lease_long = B.Lease_long,
            .Rent_Location_Name = A.Ms_Citys.City, .Plat_Location = A.Plat_Location, .Plat_Location_Name = A.Ms_Citys1.City, .Modification = A.Modification, .GPS_Cost = A.GPS_Cost,
            .Agent_Fee = A.Agent_Fee, .Update_OTR = A.Update_OTR, .Update_Diskon = A.Update_Diskon, .Other = A.Other, .Efektif_Date = A.Efektif_Date, .Replacement_Percent = A.Replacement_Percent,
            .Maintenance_Percent = A.Maintenance_Percent, .STNK_Percent = A.STNK_Percent, .Overhead_Percent = A.Overhead_Percent, .Assurance_Percent = A.Assurance_Percent,
            .Bid_PricePerMonth = A.Bid_PricePerMonth, .CreatedDate = A.CreatedDate, .CreatedBy = A.Cn_Users.User_Name, .CreatedBy_ID = A.CreatedBy, .ModifiedDate = A.ModifiedDate, .ModifiedBy = A.Cn_Users1.User_Name
            }
            Dim Prospec = New ProspectController
            Dim list = Prospec.GetUserMarketing(Session("ID"), Session("Role_ID"), Session("Department_ID"))
            If list.FirstOrDefault = 0 Then
                Return New HttpStatusCodeResult(HttpStatusCode.ExpectationFailed, "You are not part of marketing")
            End If

            Query = Query.Where(Function(x) list.Contains(x.CreatedBy_ID))

            'Dim Query = (db.sp_CalculateGetIndex(Session("ID"))).
            '                Select(Function(x) New Tr_Calculate With {.Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
            '                    .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .IsQuotation = x.IsQuotation,
            '                    .Rent_Location_ID = x.Rent_Location_ID,
            '.Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost,
            '.Agent_Fee = x.Agent_Fee, .Update_OTR = x.Update_OTR, .Update_Diskon = x.Update_Diskon, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent,
            '.Maintenance_Percent = x.Maintenance_Percent, .STNK_Percent = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent, .Assurance_Percent = x.Assurance_Percent,
            '.Bid_PricePerMonth = x.Bid_PricePerMonth, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy
            '})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Vehicle)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))

            'Return View(Query.ToList())
        End Function
        Function IndexDeviasi(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.CurrentSort = sortOrder
            If Not searchString Is Nothing Then
                page = 1
            Else
                searchString = currentFilter
            End If
            ViewBag.CurrentFilter = searchString
            ViewBag.pageSize = pageSize
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If
            Dim Query = (From A In db.Tr_Calculates
                         Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Where A.IsDeleted = False And A.IsEdit = True And B.Status = "Finish" And A.DeviasiBy Is Nothing
                         Order By A.CreatedDate Descending
                         Select A.Calculate_ID, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, B.IsQuotation, A.Rent_Location_ID, Rent_Location_Name = D.City,
    A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Other, A.Efektif_Date, A.Replacement_Percent,
    A.Maintenance_Percent, A.STNK_Percent, A.Overhead_Percent, A.Assurance_Percent, A.Bid_PricePerMonth, A.CreatedDate, CreatedBy = A.Cn_Users.User_Name, A.ModifiedDate, ModifiedBy = A.Cn_Users2.User_Name).
    Select(Function(x) New Tr_Calculate With {.Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .IsQuotation = x.IsQuotation,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost,
            .Agent_Fee = x.Agent_Fee, .Update_OTR = x.Update_OTR, .Update_Diskon = x.Update_Diskon, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent,
            .Maintenance_Percent = x.Maintenance_Percent, .STNK_Percent = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent, .Assurance_Percent = x.Assurance_Percent,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .CreatedDate = x.CreatedDate,
            .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy
            })

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Vehicle)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToList.ToPagedList(pageNumber, pageSize))

            'Return View(Query.ToList())
        End Function
        Function IndexDeviasiProcessed(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.CurrentSort = sortOrder
            If Not searchString Is Nothing Then
                page = 1
            Else
                searchString = currentFilter
            End If
            ViewBag.CurrentFilter = searchString
            ViewBag.pageSize = pageSize
            If pageSize Is Nothing Or pageSize = 0 Then
                pageSize = 10
            End If
            Dim Query = (From A In db.Tr_Calculates
                         Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Where A.IsDeleted = False And A.IsEdit = True And B.Status = "Finish" And A.DeviasiBy IsNot Nothing
                         Order By A.CreatedDate Descending
                         Select A.Calculate_ID, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, B.IsQuotation, A.Rent_Location_ID, Rent_Location_Name = D.City,
    A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Other, A.Efektif_Date, A.Replacement_Percent,
    A.Maintenance_Percent, A.STNK_Percent, A.Overhead_Percent, A.Assurance_Percent, A.Bid_PricePerMonth, A.CreatedDate, CreatedBy = A.Cn_Users.User_Name, A.ModifiedDate, ModifiedBy = A.Cn_Users2.User_Name,
                             Deviasiby = A.Cn_Users1.User_Name, A.DeviasiDate, A.RemarkDeviasi).
    Select(Function(x) New Tr_Calculate With {.Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .IsQuotation = x.IsQuotation,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost,
            .Agent_Fee = x.Agent_Fee, .Update_OTR = x.Update_OTR, .Update_Diskon = x.Update_Diskon, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent,
            .Maintenance_Percent = x.Maintenance_Percent, .STNK_Percent = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent, .Assurance_Percent = x.Assurance_Percent,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .CreatedDate = x.CreatedDate,
            .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy, .DeviasiBy = x.Deviasiby, .DeviasiDate = x.DeviasiDate, .RemarkDeviasi = x.RemarkDeviasi
            })

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.Vehicle.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "Vehicle"
                    Query = Query.OrderBy(Function(s) s.Vehicle)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToList.ToPagedList(pageNumber, pageSize))

            'Return View(Query.ToList())
        End Function


        Function ModalProspectDetail() As ActionResult

            Dim Query = From c In db.Tr_ProspectCusts
                        Where c.Status = "Finish"
                        Group Join p In db.Ms_Customers On c.CustomerExists_ID Equals p.Customer_ID Into Group
                        From p In Group.DefaultIfEmpty()
                        Select c.ProspectCustomer_ID, Company_Name = If(p Is Nothing, c.Company_Name, p.Company_Name)

            ViewBag.ProspectCustomer_ID = New SelectList(Query, "ProspectCustomer_ID", "Company_Name")


            Return View()

        End Function
        Public Function FillList(ByVal val As Integer?) As ActionResult

            If val IsNot Nothing Then
                Dim Query = From A In db.Tr_ProspectCustDetails
                            Where A.ProspectCustomer_ID = val
                            Group Join B In db.Ms_Vehicles On A.VehicleExists_ID Equals B.Vehicle_id Into vehicle = Group
                            From AB In vehicle.DefaultIfEmpty
                            Group Join C In db.Ms_Vehicle_Brands On A.Brand_ID Equals C.Brand_ID Into brand = Group
                            From AC In brand.DefaultIfEmpty()
                            Group Join D In db.Ms_Vehicle_Models On A.Model_ID Equals D.Model_ID Into model = Group
                            From AD In model.DefaultIfEmpty()
                            Select A.ProspectCustomerDetail_ID, A.IsVehicleExists, AB.license_no, AB.type, AC.Brand_Name, Model = AD.Type,
                                A.Lease_price, A.Qty, AB.price, Total = If(A.IsVehicleExists = False, A.Lease_price * A.Qty, AB.price)
                Return Json(New With {Key .success = "true", .list = Query})
            End If
            Return Json(New With {Key .success = "false"})

        End Function

        ' GET: Calculate/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Calculates = (From A In db.Tr_Calculates
                                 Where A.IsDeleted = False And A.Calculate_ID = id
                                 Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                                 From B In Group.DefaultIfEmpty()
                                 Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                                 From D In DA.DefaultIfEmpty()
                                 Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                                 From E In EA.DefaultIfEmpty()
                                 Select B.Transaction_Type, A.Residual_ValuePercent, A.Expedition_Cost, A.Keur, A.Residual_Value, A.Agent_FeePerMonth, A.GPS_CostPerMonth, A.Payment_Condition, A.Calculate_ID, B.Year, B.Lease_price, B.Lease_long, B.Qty, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Update_DiskonSystem, A.Update_DiskonTick, A.Cost_Price, A.Up_Front_Fee, A.Up_Front_Fee_Percent, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Replacement_Percent_Before, A.Replacement, A.Replacement_Tick, A.Maintenance_Percent, A.Maintenance_Percent_Before, A.Maintenance, A.Maintenance_Tick,
                            A.STNK_Percent, A.STNK_Percent_Before, A.STNK, A.STNK_Tick, A.Overhead_Percent, A.Overhead, A.Assurance_Percent, A.Assurance_Percent_Before, A.Assurance, A.Assurance_Tick, A.Lease_Profit_Percent, A.Lease_Profit, A.Depresiasi_Percent, A.Depresiasi, A.Funding_Interest_Percent, A.Funding_Interest, A.Bid_PricePerMonth,
                            A.IRR, A.Funding_Rate, A.Spread, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.Term_Of_Payment, A.Expedition_Status, A.Premium, A.OJK, A.SwapRate, A.Project_Rating, A.Profit, A.PayMonth, A.New_Vehicle_Price, A.Location_Vehicle_ID, Location_Vehicle = A.Ms_Citys.City, B.Type, B.Model_ID).
                            Select(Function(x) New Tr_Calculate With {.Transaction_Type = x.Transaction_Type, .Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .Year = x.Year, .Lease_price = x.Lease_price, .Lease_long = x.Lease_long, .Qty = x.Qty,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Payment_Condition = x.Payment_Condition, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost, .GPS_CostPerMonth = x.GPS_CostPerMonth,
            .Agent_Fee = x.Agent_Fee, .Agent_FeePerMonth = x.Agent_FeePerMonth, .Update_OTR = x.Update_OTR, .Residual_Value = x.Residual_Value, .Residual_ValuePercent = x.Residual_ValuePercent, .Expedition_Cost = x.Expedition_Cost, .Keur = x.Keur, .Update_Diskon = x.Update_Diskon, .Update_DiskonSystem = x.Update_DiskonSystem, .Update_DiskonTick = x.Update_DiskonTick, .Cost_Price = x.Cost_Price, .Up_Front_Fee = x.Up_Front_Fee, .Up_Front_Fee_Percent = x.Up_Front_Fee_Percent, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent, .Replacement_Percent_Before = x.Replacement_Percent_Before, .Replacement = x.Replacement, .Replacement_Tick = x.Replacement_Tick,
            .Maintenance_Percent = x.Maintenance_Percent, .Maintenance_Percent_Before = x.Maintenance_Percent_Before, .Maintenance = x.Maintenance, .Maintenance_Tick = x.Maintenance_Tick, .STNK_Percent = x.STNK_Percent, .STNK_Percent_Before = x.STNK_Percent_Before, .STNK = x.STNK, .STNK_Tick = x.STNK_Tick, .Overhead_Percent = x.Overhead_Percent, .Overhead = x.Overhead,
            .Assurance_Percent = x.Assurance_Percent, .Assurance_Percent_Before = x.Assurance_Percent_Before, .Assurance = x.Assurance, .Assurance_Tick = x.Assurance_Tick, .Lease_Profit_Percent = x.Lease_Profit_Percent, .Lease_Profit = x.Lease_Profit, .Depresiasi_Percent = x.Depresiasi_Percent, .Depresiasi = x.Depresiasi, .Funding_Interest_Percent = x.Funding_Interest_Percent, .Funding_Interest = x.Funding_Interest,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .IRR = x.IRR, .Funding_Rate = x.Funding_Rate, .Spread = x.Spread, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy,
            .Term_Of_Payment = x.Term_Of_Payment, .Expedition_Status = x.Expedition_Status, .Premium = x.Premium, .OJK = x.OJK, .SwapRate = x.SwapRate, .Project_Rating = x.Project_Rating, .Project = x.Project_Rating, .Profit = x.Profit, .PayMonth = x.PayMonth,
            .New_Vehicle_Price = x.New_Vehicle_Price, .Location_Vehicle_ID = x.Location_Vehicle_ID, .Location_Vehicle = x.Location_Vehicle, .Type = x.Type, .Model_ID = x.Model_ID
            }).FirstOrDefault()

            If IsNothing(tr_Calculates) Then
                Return HttpNotFound()
            End If
            Return View(tr_Calculates)
        End Function
        Function CalculateSimulation() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                }
            }
            ViewBag.Status = New SelectList(myStatus, "Value", "Text")
            Dim myType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "OPL",
                    .Value = "OPL"
                },
                New SelectListItem With {
                    .Text = "COP",
                    .Value = "COP"
                }
            }
            ViewBag.Transaction_Type = New SelectList(myType, "Value", "Text")
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name")
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False), "Model_ID", "Type")

            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City")
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City")
            Dim Query = From prospect In db.V_ProspectCusts
                        Where prospect.IsQuotation = False
                        Select prospect.ProspectCustomer_ID, prospect.Company_Name
            ViewBag.ProspectCustomer_ID = New SelectList(Query, "ProspectCustomer_ID", "Company_Name")
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            ViewBag.Term_Of_Payment = New SelectList(month, "Value", "Text")
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text")
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text")
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                },
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text")

            ViewBag.Expedition_Status = New SelectList(expedisiStatus, "Value", "Text")
            Dim MyPayMonth As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Nothing",
                    .Value = 0
                },
                New SelectListItem With {
                    .Text = "First Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "Second Month",
                    .Value = 2
                },
                New SelectListItem With {
                    .Text = "Third Month",
                    .Value = 3
                }
            }
            ViewBag.PayMonth = New SelectList(MyPayMonth, "Value", "Text")
            ViewBag.Credit_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Credit_Rating), "Key", "Key", 3)
            Dim myJakarta As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jakarta",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Non Jakarta",
                    .Value = False
                }
            }

            ViewBag.IsJakarta = New SelectList(myJakarta, "Value", "Text")
            ViewBag.Location_Vehicle_ID = New SelectList(city, "CIty_ID", "City")
            'fill fixedCost
            Dim fixedCost = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
            Dim calculate As New Tr_Calculate
            calculate.STNK_Percent = fixedCost.STNK_Percent
            calculate.STNK_Percent_Before = fixedCost.STNK_Percent
            calculate.Overhead_Percent = fixedCost.Overhead_Percent
            calculate.Assurance_Percent = fixedCost.Assurance_Percent
            calculate.Assurance_Percent_Before = fixedCost.Assurance_Percent
            'calculate.Funding_Rate = fixedCost.Funding_Rate
            calculate.OJK = fixedCost.OJK
            calculate.GoalSeek = ""
            calculate.Efektif_Date = Date.Now
            Return View(calculate)
        End Function
        Function CalculateSimulationNew() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim myStatus As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Open",
                    .Value = "Open"
                },
                New SelectListItem With {
                    .Text = "Finish",
                    .Value = "Finish"
                }
            }
            ViewBag.Status = New SelectList(myStatus, "Value", "Text")
            Dim myType As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "OPL",
                    .Value = "OPL"
                },
                New SelectListItem With {
                    .Text = "COP",
                    .Value = "COP"
                }
            }
            ViewBag.Transaction_Type = New SelectList(myType, "Value", "Text")
            ViewBag.VehicleExists_ID = New SelectList(db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False), "Vehicle_id", "license_no")
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name")
            ViewBag.Model_ID = New SelectList(db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False), "Model_ID", "Type")

            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City")
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City")
            Dim Query = From prospect In db.V_ProspectCusts
                        Where prospect.IsQuotation = False
                        Select prospect.ProspectCustomer_ID, prospect.Company_Name
            ViewBag.ProspectCustomer_ID = New SelectList(Query, "ProspectCustomer_ID", "Company_Name")
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text")
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text")
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                },
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text")
            Return View()
        End Function

        Function ReCalculate(db As TrustEntities, cal As Tr_Calculate) As Tr_Calculate
            Dim fixedCost = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
            cal.STNK_Percent = fixedCost.STNK_Percent
            cal.STNK_Percent_Before = fixedCost.STNK_Percent
            cal.Overhead_Percent = fixedCost.Overhead_Percent
            cal.Assurance_Percent = fixedCost.Assurance_Percent
            cal.Assurance_Percent_Before = fixedCost.Assurance_Percent
            cal.OJK = fixedCost.OJK
            cal.Premium = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.Project_Rating = cal.Project_Rating).Select(Function(x) x.RiskGrading).FirstOrDefault
            cal.SwapRate = swapRateFunc(cal.Lease_long)
            cal.Funding_Rate = cal.Premium + cal.OJK + cal.SwapRate

            assuransiFunc(cal.IsTruck, cal.Lease_long, cal.Assurance_Percent, cal.AssuranceExtra)


            'Expedition
            Dim calExpedition As New Tr_Calculate
            calExpedition = expedition(cal.Rent_Location_ID, cal.Plat_Location, cal.Type, cal.Expedition_Status, cal.IsVehicleExists, cal.Transaction_Type)
            If Not cal.Replacement_Tick Then
                cal.Replacement_Percent = calExpedition.Replacement_Percent
            End If
            If Not cal.Replacement_Tick Then
                cal.Replacement_Percent = calExpedition.Replacement_Percent
            End If
            'Jika dia Jakarta
            If Not cal.IsVehicleExists And cal.Plat_Location = 28 Then
                cal.Expedition_Cost = calExpedition.Expedition_Cost
            End If
            cal.Keur = calExpedition.Keur
            Dim amount = If(If(cal.Update_OTR, 0) = 0, cal.Lease_price, cal.Update_OTR)
            cal.Cost_Price = amount - If(cal.Update_Diskon, 0)
            cal.Replacement = (cal.Replacement_Percent * cal.Cost_Price) / 100
            If cal.IsVehicleExists Then
                cal.Maintenance = (cal.Maintenance_Percent * cal.New_Vehicle_Price) / 100
                cal.STNK = (cal.STNK_Percent * cal.New_Vehicle_Price) / 100
                cal.Assurance = (cal.New_Vehicle_Price + cal.Modification) * cal.Lease_long / 12 * ((cal.Assurance_Percent * Math.Pow(0.955, cal.Lease_long / 12)) / 100)
            Else
                cal.Maintenance = (cal.Maintenance_Percent * cal.Cost_Price) / 100
                cal.STNK = (cal.STNK_Percent * amount) / 100
                cal.Assurance = (amount + cal.Modification) * cal.Lease_long / 12 * ((cal.Assurance_Percent * Math.Pow(0.955, cal.Lease_long / 12)) / 100)
            End If
            cal.Overhead = (cal.Overhead_Percent * cal.Cost_Price) / 100
            cal.Lease_Profit = (cal.Lease_Profit_Percent * cal.Cost_Price * cal.Lease_long) / 12 / 100
            cal.Up_Front_Fee = (cal.Up_Front_Fee_Percent * cal.Cost_Price) / 100
            cal.Funding_Interest = (cal.Funding_Interest_Percent * cal.Cost_Price / 100) * (cal.Lease_long / 12)
            cal.Residual_Value = CalRV(cal.Cost_Price, cal.Residual_ValuePercent, cal.Depresiasi_Percent, cal.Depresiasi)
            cal.Up_Front_Fee = CalDP(cal.Cost_Price, cal.Up_Front_Fee_Percent)
            cal.Bid_PricePerMonth = CalPrice_Month(cal.Replacement, cal.Maintenance, cal.STNK, cal.Overhead, cal.GPS_Cost, cal.GPS_CostPerMonth, cal.Lease_long, cal.Assurance + cal.AssuranceExtra, cal.Depresiasi, cal.Expedition_Cost, cal.Modification, cal.Funding_Interest, cal.Other, cal.Lease_Profit)


            Dim AssuranceCashFlow = (cal.Assurance + cal.AssuranceExtra) / (cal.Lease_long / 12)
            CalIRR(cal.Expedition_Status, cal.PayMonth, cal.Cost_Price, cal.Up_Front_Fee, cal.Replacement, cal.Maintenance, cal.STNK, cal.Overhead, AssuranceCashFlow, cal.Bid_PricePerMonth, cal.Residual_Value, cal.Lease_long, cal.Expedition_Cost, cal.Type, cal.Payment_Condition, cal.Term_Of_Payment, cal.Modification, cal.GPS_Cost, cal.GPS_CostPerMonth, cal.Agent_Fee, cal.Agent_FeePerMonth, cal.Other, cal.Keur, cal.Funding_Rate, cal.IRR, cal.Profit)
            cal.Spread = cal.IRR - cal.Funding_Rate

            Return cal
        End Function

        ' GET: Calculate/Create
        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City")
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City")
            Dim Query = db.sp_GetProspectFromUser(1, Session("ID")).Where(Function(x) x.Status = "Finish")
            ViewBag.ProspectCustomer_ID = New SelectList(Query.ToList, "ProspectCustomer_ID", "Company_Name")
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }

            ViewBag.Term_Of_Payment = New SelectList(month, "Value", "Text")
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text")
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text")
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                },
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text")
            ViewBag.Expedition_Status = New SelectList(expedisiStatus, "Value", "Text")
            Dim MyPayMonth As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Nothing",
                    .Value = 0
                },
                New SelectListItem With {
                    .Text = "First Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "Second Month",
                    .Value = 2
                },
                New SelectListItem With {
                    .Text = "Third Month",
                    .Value = 3
                }
            }
            ViewBag.PayMonth = New SelectList(MyPayMonth, "Value", "Text")
            ViewBag.Location_Vehicle_ID = New SelectList(city, "CIty_ID", "City")

            'fill fixedCost
            Dim fixedCost = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
            Dim calculate As New Tr_Calculate
            calculate.STNK_Percent = fixedCost.STNK_Percent
            calculate.STNK_Percent_Before = fixedCost.STNK_Percent
            calculate.Overhead_Percent = fixedCost.Overhead_Percent
            calculate.Assurance_Percent = fixedCost.Assurance_Percent
            calculate.Assurance_Percent_Before = fixedCost.Assurance_Percent
            'calculate.Funding_Rate = fixedCost.Funding_Rate
            calculate.OJK = fixedCost.OJK
            calculate.GoalSeek = ""
            calculate.Efektif_Date = Date.Now
            Return View(calculate)
        End Function
        Sub Validation(H As Tr_Calculate, ByRef Validate As Boolean, ByRef Message As String)
            If H.Rent_Location_ID = 0 Then
                Message = "Rent Location must be fill"
                Validate = False
            ElseIf H.Plat_Location = 0 Then
                Message = "Plat Location must be fill"
                Validate = False
            ElseIf H.Payment_Condition = "" Then
                Message = "Payment Type must be fill"
                Validate = False
            ElseIf H.Term_Of_Payment = 0 Then
                Message = "Payment Scheme must be fill"
                Validate = False
            ElseIf H.Efektif_Date Is Nothing Then
                Message = "Efektif Date must be fill"
                Validate = False
            ElseIf H.Bid_PricePerMonth = 0 Then
                Message = "Lease Rent / Month must be fill"
                Validate = False
            ElseIf H.Expedition_Status = "" Then
                Message = "Expedition Status must be fill"
                Validate = False
            ElseIf H.Project_Rating = "" Then
                Message = "Project Rating is Empty"
                Validate = False
            ElseIf H.IsVehicleExists And H.Location_Vehicle_ID = 0 Then
                Message = "Must fill Location Vehicle"
                Validate = False
                'ElseIf Not H.Replacement_Tick And H.Replacement_Percent = 0 Then
                '    Message = "Must fill Replacement Percent"
                '    Validate = False
            ElseIf Not H.Maintenance_Tick And H.Maintenance_Percent = 0 Then
                Message = "Must fill Replacement Percent"
                Validate = False
            End If
        End Sub
        Public Function CreateData(orderHD() As Tr_Calculate) As ActionResult
            Dim H = orderHD.FirstOrDefault
            Dim result As String = "Error"
            Dim Message As String = ""
            Dim Validate As Boolean = True
            If H.ProspectCustomerDetail_ID = 0 Then
                Message = "Vehicle must be fill"
                Validate = False
            Else
                Validation(H, Validate, Message)
            End If

            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If Validate Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim calculate = addCaculate(H, user)
                        Dim detail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = H.ProspectCustomerDetail_ID).FirstOrDefault()
                        detail.IsCalculate = True
                        db.SaveChanges()
                        Dim prospDetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = H.ProspectCustomerDetail_ID).FirstOrDefault
                        Dim AssuranceCashFlow = (H.Assurance + H.AssuranceExtra) / (prospDetail.Lease_long / 12)

                        Dim Calculate_ID = calculate.Calculate_ID, Expedition_Status = H.Expedition_Status, PayMonth = H.PayMonth, Cost_Price = H.Cost_Price, Up_Front_Fee = H.Up_Front_Fee,
                        Replacement = H.Replacement, Maintenance = H.Maintenance, STNK = H.STNK, Overhead = H.Overhead, Bid_PricePerMonth = H.Bid_PricePerMonth, Residual_Value = H.Residual_Value,
                        Lease_long = prospDetail.Lease_long, Expedition_Cost = H.Expedition_Cost, Transaction_Type = prospDetail.Transaction_Type, Payment_Condition = H.Payment_Condition,
                        Term_Of_Payment = H.Term_Of_Payment, Modification = H.Modification, GPS_Cost = H.GPS_Cost, GPS_CostPerMonth = H.GPS_CostPerMonth, Agent_Fee = H.Agent_Fee, Agent_FeePerMonth = H.Agent_FeePerMonth,
                        Other = H.Other, Keur = H.Keur, Funding_Rate = H.Funding_Rate
                        SaveCashFlow(True, calculate.Calculate_ID, user, H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, AssuranceCashFlow, H.Bid_PricePerMonth, H.Residual_Value, prospDetail.Lease_long, H.Expedition_Cost, prospDetail.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate)
                        'Dim messageResult = db.sp_SaveCashFlow(True, Calculate_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                        '             Bid_PricePerMonth, Residual_Value, Lease_long, Expedition_Cost, Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                        '             GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                        'If messageResult.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                        '    Throw New System.Exception(messageResult.Select(Function(x) x.Message).FirstOrDefault)
                        'End If

                        'Perhitungan sekali 5 tahun
                        If H.IsMultiCalculated Then
                            Dim model = db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).ToList
                            Dim costOfFund = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).FirstOrDefault
                            Dim looper = {24, 36, 48, 60}
                            For Each i In looper
                                If (db.Tr_ProspectCustDetails.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = prospDetail.ProspectCustomer_ID And x.MultiCalculateGroup = prospDetail.MultiCalculateGroup And x.Lease_long = i).Any) Then
                                    H.Lease_long = i
                                    'Set RV Sesuai tahun
                                    If model.Where(Function(x) x.Model_ID = H.Model_ID).Any Then
                                        If H.Lease_long <= 12 Then
                                            H.Residual_ValuePercent = model.Where(Function(x) x.Model_ID = H.Model_ID).Select(Function(x) x.Year1).FirstOrDefault
                                        ElseIf H.Lease_long <= 24 Then
                                            H.Residual_ValuePercent = model.Where(Function(x) x.Model_ID = H.Model_ID).Select(Function(x) x.Year2).FirstOrDefault
                                        ElseIf H.Lease_long <= 36 Then
                                            H.Residual_ValuePercent = model.Where(Function(x) x.Model_ID = H.Model_ID).Select(Function(x) x.Year3).FirstOrDefault
                                        ElseIf H.Lease_long <= 48 Then
                                            H.Residual_ValuePercent = model.Where(Function(x) x.Model_ID = H.Model_ID).Select(Function(x) x.Year4).FirstOrDefault
                                        ElseIf H.Lease_long <= 60 Then
                                            H.Residual_ValuePercent = model.Where(Function(x) x.Model_ID = H.Model_ID).Select(Function(x) x.Year5).FirstOrDefault
                                        End If
                                        model.Where(Function(x) x.Model_ID = H.Model_ID)
                                    Else
                                        Throw New Exception("Model ID Not Exists!")
                                    End If
                                    H.Residual_ValuePercent = GetRVPersent(H.Residual_ValuePercent, H.Transaction_Type, H.IsVehicleExists, H.Lease_long, H.Project_Rating)
                                    H.Residual_Value = CalRV(H.Cost_Price, H.Residual_ValuePercent, H.Depresiasi_Percent, H.Depresiasi)


                                    H.ProspectCustomerDetail_ID = db.Tr_ProspectCustDetails.Where(Function(x) x.IsDeleted = False And x.ProspectCustomer_ID = prospDetail.ProspectCustomer_ID And x.MultiCalculateGroup = prospDetail.MultiCalculateGroup And x.Lease_long = i).Select(Function(x) x.ProspectCustomerDetail_ID).FirstOrDefault
                                    If H.IsVehicleExists Then
                                        H.Assurance = ((H.New_Vehicle_Price + H.Modification) * H.Lease_long / 12 * ((H.Assurance_Percent * Math.Pow(0.955, H.Lease_long / 12)) / 100))
                                    Else
                                        H.Assurance = (((H.Cost_Price - H.Update_Diskon) + H.Modification) * H.Lease_long / 12 * ((H.Assurance_Percent * Math.Pow(0.955, H.Lease_long / 12)) / 100))
                                    End If
                                    H.Lease_Profit = CalLease_Profit(H.Lease_Profit_Percent, H.Cost_Price, H.Lease_long)
                                    H.Funding_Interest_Percent = db.Ms_FundingCosts.Where(Function(x) x.MonthFrom <= H.Lease_long And x.MonthTo >= H.Lease_long).Select(Function(x) x.FundingCost).FirstOrDefault
                                    H.Funding_Interest = ((H.Funding_Interest_Percent * H.Cost_Price) / 100) * (H.Lease_long / 12)
                                    H.Bid_PricePerMonth = CalPrice_Month(H.Replacement, H.Maintenance, H.STNK, H.Overhead, H.GPS_Cost, H.GPS_CostPerMonth, H.Lease_long, H.Assurance + H.AssuranceExtra, H.Depresiasi, H.Expedition_Cost, H.Modification, H.Funding_Interest, H.Other, H.Lease_Profit)
                                    CalIRR(H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, H.Assurance + H.AssuranceExtra, H.Bid_PricePerMonth, H.Residual_Value, H.Lease_long, H.Expedition_Cost, H.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate, H.IRR, H.Profit)
                                    If H.Lease_long <= 12 Then
                                        H.SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year1).FirstOrDefault
                                    ElseIf H.Lease_long <= 24 Then
                                        H.SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year2).FirstOrDefault
                                    ElseIf H.Lease_long <= 36 Then
                                        H.SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year3).FirstOrDefault
                                    ElseIf H.Lease_long <= 48 Then
                                        H.SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year4).FirstOrDefault
                                    ElseIf H.Lease_long <= 60 Then
                                        H.SwapRate = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Year5).FirstOrDefault
                                    End If
                                    H.Funding_Rate = H.Premium + H.OJK + H.SwapRate
                                    H.Spread = H.IRR - H.Funding_Rate
                                    Dim calculate1 = addCaculate(H, user)
                                    Dim detail1 = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = H.ProspectCustomerDetail_ID).FirstOrDefault()
                                    detail1.IsCalculate = True
                                    db.SaveChanges()
                                    Dim AssuranceCashFlow1 = (H.Assurance + H.AssuranceExtra) / (H.Lease_long / 12)
                                    SaveCashFlow(True, calculate1.Calculate_ID, user, H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, AssuranceCashFlow1, H.Bid_PricePerMonth, H.Residual_Value, H.Lease_long, H.Expedition_Cost, prospDetail.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate)
                                    'Calculate_ID = calculate1.Calculate_ID
                                    'Residual_Value = H.Residual_Value
                                    'Bid_PricePerMonth = H.Bid_PricePerMonth
                                    'Funding_Rate = H.Funding_Rate
                                    'Lease_long = H.Lease_long

                                    'Dim messageResult1 = db.sp_SaveCashFlow(True, Calculate_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance,
                                    '                                       STNK, Overhead, AssuranceCashFlow1,
                                    ' Bid_PricePerMonth, Residual_Value, Lease_long, Expedition_Cost, Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                                    ' GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                                    'If messageResult1.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                                    '    Throw New System.Exception(messageResult1.Select(Function(x) x.Message).FirstOrDefault)
                                    'End If

                                End If
                            Next
                        End If

                        dbs.Commit()
                        result = "Success"
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using
            End If
            Return Json(New With {Key .result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function

        Function addCaculate(H As Tr_Calculate, User As Integer) As Tr_Calculates
            Dim calculate As New Tr_Calculates
            calculate.ProspectCustomerDetail_ID = H.ProspectCustomerDetail_ID
            calculate.Rent_Location_ID = H.Rent_Location_ID
            calculate.Plat_Location = H.Plat_Location
            calculate.Modification = H.Modification
            calculate.PayMonth = H.PayMonth
            calculate.Payment_Condition = H.Payment_Condition
            calculate.Term_Of_Payment = H.Term_Of_Payment
            calculate.GPS_Cost = H.GPS_Cost
            calculate.GPS_CostPerMonth = H.GPS_CostPerMonth
            calculate.Agent_Fee = H.Agent_Fee
            calculate.Agent_FeePerMonth = H.Agent_FeePerMonth
            calculate.Update_OTR = H.Update_OTR
            calculate.Residual_Value = H.Residual_Value
            calculate.Residual_ValuePercent = H.Residual_ValuePercent
            calculate.Expedition_Status = H.Expedition_Status
            calculate.Expedition_Cost = H.Expedition_Cost
            calculate.Keur = H.Keur
            calculate.Update_Diskon = H.Update_Diskon
            calculate.Update_DiskonSystem = H.Update_DiskonSystem
            calculate.Update_DiskonTick = H.Update_DiskonTick
            calculate.Cost_Price = H.Cost_Price
            calculate.Up_Front_Fee = H.Up_Front_Fee
            calculate.Up_Front_Fee_Percent = H.Up_Front_Fee_Percent
            calculate.Other = H.Other
            calculate.Efektif_Date = H.Efektif_Date
            calculate.Replacement_Percent = H.Replacement_Percent
            calculate.Replacement_Percent_Before = H.Replacement_Percent_Before
            calculate.Replacement = H.Replacement
            calculate.Replacement_Tick = H.Replacement_Tick
            calculate.Maintenance_Percent = H.Maintenance_Percent
            calculate.Maintenance_Percent_Before = H.Maintenance_Percent_Before
            calculate.Maintenance = H.Maintenance
            calculate.Maintenance_Tick = H.Maintenance_Tick
            calculate.STNK_Percent = H.STNK_Percent
            calculate.STNK_Percent_Before = H.STNK_Percent_Before
            calculate.STNK = H.STNK
            calculate.STNK_Tick = H.STNK_Tick
            calculate.Overhead_Percent = H.Overhead_Percent
            calculate.Overhead = H.Overhead
            calculate.Assurance_Percent = H.Assurance_Percent
            calculate.Assurance_Percent_Before = H.Assurance_Percent_Before
            calculate.Assurance = H.Assurance
            calculate.Assurance_Tick = H.Assurance_Tick
            calculate.AssuranceExtra = H.AssuranceExtra
            calculate.Lease_Profit_Percent = H.Lease_Profit_Percent
            calculate.Lease_Profit = H.Lease_Profit
            calculate.Depresiasi_Percent = H.Depresiasi_Percent
            calculate.Depresiasi = H.Depresiasi
            calculate.Funding_Interest_Percent = H.Funding_Interest_Percent
            calculate.Funding_Interest = H.Funding_Interest
            calculate.Bid_PricePerMonth = H.Bid_PricePerMonth
            calculate.Premium = H.Premium
            calculate.OJK = H.OJK
            calculate.SwapRate = H.SwapRate
            calculate.Project_Rating = H.Project_Rating
            calculate.IRR = H.IRR
            calculate.Spread = H.Spread
            calculate.Profit = H.Profit
            calculate.Funding_Rate = H.Funding_Rate
            If H.IsVehicleExists Then
                calculate.New_Vehicle_Price = H.New_Vehicle_Price
                calculate.Location_Vehicle_ID = H.Location_Vehicle_ID
            End If
            calculate.CreatedBy = User
            calculate.CreatedDate = DateTime.Now
            calculate.IsDeleted = False
            'Initialize buat deviasi, kalo dia masuh 1 masih bisa di edit
            calculate.IsEdit = True
            db.Tr_Calculates.Add(calculate)
            Return calculate
        End Function
        Function CreateNew() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City")
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City")
            Dim Query = db.sp_GetProspectFromUser(1, Session("ID")).Where(Function(x) x.Status = "Finish")
            ViewBag.ProspectCustomer_ID = New SelectList(Query.ToList, "ProspectCustomer_ID", "Company_Name")
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }

            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text")
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text")
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                },
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text")
            Return View()
        End Function

        Public Function EditDataDeviasiCalNew(orderHD() As Tr_Calculate) As ActionResult
            Dim H = orderHD.FirstOrDefault
            Dim result As String = "Error"
            Dim Message As String = ""
            Dim Validate As Boolean = True
            If H.Calculate_ID = 0 Then
                Message = "Calculate ID be fill"
                Validate = False
            ElseIf H.RemarkDeviasi Is Nothing Then
                Message = "Must fill Remark"
                Validate = False
            Else
                Validation(H, Validate, Message)
            End If
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If Validate Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim calculate = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = H.Calculate_ID).FirstOrDefault()
                        calculate.Rent_Location_ID = H.Rent_Location_ID
                        calculate.Plat_Location = H.Plat_Location
                        calculate.Modification = H.Modification
                        calculate.PayMonth = H.PayMonth
                        calculate.Payment_Condition = H.Payment_Condition
                        calculate.Term_Of_Payment = H.Term_Of_Payment
                        calculate.GPS_Cost = H.GPS_Cost
                        calculate.GPS_CostPerMonth = H.GPS_CostPerMonth
                        calculate.Agent_Fee = H.Agent_Fee
                        calculate.Agent_FeePerMonth = H.Agent_FeePerMonth
                        calculate.Update_OTR = H.Update_OTR
                        calculate.Residual_Value = H.Residual_Value
                        calculate.Residual_ValuePercent = H.Residual_ValuePercent
                        calculate.Expedition_Status = H.Expedition_Status
                        calculate.Expedition_Cost = H.Expedition_Cost
                        calculate.Keur = H.Keur
                        calculate.Update_Diskon = H.Update_Diskon
                        calculate.Update_DiskonSystem = H.Update_DiskonSystem
                        calculate.Update_DiskonTick = H.Update_DiskonTick
                        calculate.Cost_Price = H.Cost_Price
                        calculate.Up_Front_Fee = H.Up_Front_Fee
                        calculate.Up_Front_Fee_Percent = H.Up_Front_Fee_Percent
                        calculate.Other = H.Other
                        calculate.Efektif_Date = H.Efektif_Date
                        calculate.Replacement_Percent = H.Replacement_Percent
                        calculate.Replacement_Percent_Before = H.Replacement_Percent_Before
                        calculate.Replacement = H.Replacement
                        calculate.Replacement_Tick = H.Replacement_Tick
                        calculate.Maintenance_Percent = H.Maintenance_Percent
                        calculate.Maintenance_Percent_Before = H.Maintenance_Percent_Before
                        calculate.Maintenance = H.Maintenance
                        calculate.Maintenance_Tick = H.Maintenance_Tick
                        calculate.STNK_Percent = H.STNK_Percent
                        calculate.STNK_Percent_Before = H.STNK_Percent_Before
                        calculate.STNK = H.STNK
                        calculate.STNK_Tick = H.STNK_Tick
                        calculate.Overhead_Percent = H.Overhead_Percent
                        calculate.Overhead = H.Overhead
                        calculate.Assurance_Percent = H.Assurance_Percent
                        calculate.Assurance_Percent_Before = H.Assurance_Percent_Before
                        calculate.Assurance = H.Assurance
                        calculate.Assurance_Tick = H.Assurance_Tick
                        calculate.AssuranceExtra = H.AssuranceExtra
                        calculate.Lease_Profit_Percent = H.Lease_Profit_Percent
                        calculate.Lease_Profit = H.Lease_Profit
                        calculate.Depresiasi_Percent = H.Depresiasi_Percent
                        calculate.Depresiasi = H.Depresiasi
                        calculate.Funding_Interest_Percent = H.Funding_Interest_Percent
                        calculate.Funding_Interest = H.Funding_Interest
                        calculate.Bid_PricePerMonth = H.Bid_PricePerMonth
                        calculate.Premium = H.Premium
                        calculate.OJK = H.OJK
                        calculate.SwapRate = H.SwapRate
                        calculate.Project_Rating = H.Project_Rating
                        calculate.IRR = H.IRR
                        calculate.Spread = H.Spread
                        calculate.Profit = H.Profit
                        calculate.Funding_Rate = H.Funding_Rate
                        If H.IsVehicleExists Then
                            calculate.New_Vehicle_Price = H.New_Vehicle_Price
                            calculate.Location_Vehicle_ID = H.Location_Vehicle_ID
                        End If
                        calculate.RemarkDeviasi = H.RemarkDeviasi
                        calculate.DeviasiDate = DateTime.Now
                        calculate.DeviasiBy = user
                        db.SaveChanges()
                        'Dim detail = db.Tr_CalculateCashFlows.Where(Function(x) x.Calculate_ID = H.Calculate_ID).ToList
                        'For Each i In detail
                        '    i.IsDeleted = True
                        '    i.ModifiedBy = user
                        '    i.ModifiedDate = DateTime.Now
                        'Next
                        'db.SaveChanges()
                        Dim prospectDetail_ID = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = H.Calculate_ID And x.IsDeleted = False).Select(Function(x) x.ProspectCustomerDetail_ID).FirstOrDefault
                        Dim prospDetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = prospectDetail_ID).FirstOrDefault
                        Dim AssuranceCashFlow = (H.Assurance + H.AssuranceExtra) / (prospDetail.Lease_long / 12)
                        SaveCashFlow(True, H.Calculate_ID, user, H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, AssuranceCashFlow, H.Bid_PricePerMonth, H.Residual_Value, prospDetail.Lease_long, H.Expedition_Cost, prospDetail.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate)
                        'Dim Calculate_ID = H.Calculate_ID, Expedition_Status = H.Expedition_Status, PayMonth = H.PayMonth, CostPrice = H.Cost_Price,
                        'Up_Front_Fee = H.Up_Front_Fee, Replacement = H.Replacement, Maintenance = H.Maintenance, STNK = H.STNK, Overhead = H.Overhead,
                        '             Bid_PricePerMonth = H.Bid_PricePerMonth, Residual_Value = H.Residual_Value, Lease_long = prospDetail.Lease_long,
                        'Expedition_Cost = H.Expedition_Cost, Transaction_Type = prospDetail.Transaction_Type, Payment_Condition = H.Payment_Condition, Term_Of_Payment = H.Term_Of_Payment,
                        'Modification = H.Modification, GPS_Cost = H.GPS_Cost, GPS_CostPerMonth = H.GPS_CostPerMonth, Agent_Fee = H.Agent_Fee, Agent_FeePerMonth = H.Agent_FeePerMonth,
                        'Other = H.Other, Keur = H.Keur, Funding_Rate = H.Funding_Rate

                        'Dim messageResult = db.sp_SaveCashFlow(True, Calculate_ID, user, Expedition_Status, PayMonth, CostPrice, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                        '             Bid_PricePerMonth, Residual_Value, Lease_long, Expedition_Cost, Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                        '             GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                        'If messageResult.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                        '    Throw New System.Exception(messageResult.Select(Function(x) x.Message).FirstOrDefault)
                        'End If

                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using
                result = "Success"
            End If
            Return Json(New With {Key .result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Calculate/Edit/5
        'Public Function EditDataDeviasiCal(Calculate_ID As Integer, Rent_Location_ID As Integer, Plat_Location As Integer, PayMonth As Integer, Payment_Condition As String, Term_Of_Payment As Integer, Modification As Double, GPS_Cost As Double, GPS_CostPerMonth As Integer?, Agent_Fee As Double, Agent_FeePerMonth As Integer?, Update_OTR As Double, Residual_Value As Double?, Residual_ValuePercent As Decimal, Expedition_Status As String, Expedition_Cost As Double, Keur As Double, Update_Diskon As Double, Cost_Price As Double, Up_Front_Fee As Double, Up_Front_Fee_Percent As Decimal, Other As Double, Efektif_Date As Date?, Replacement_Percent As Decimal, Replacement As Double, Maintenance_Percent As Decimal, Maintenance As Double, STNK_Percent As Decimal, STNK As Double, Overhead_Percent As Decimal, Overhead As Double, Assurance_Percent As Decimal, Assurance As Double, Depresiasi_Percent As Decimal, Depresiasi As Double, Funding_Interest_Percent As Decimal, Funding_Interest As Double, Lease_Profit_Percent As Decimal, Lease_Profit As Double, Bid_PricePerMonth As Double, Premium As Decimal, OJK As Decimal, SwapRate As Decimal, Project_Rating As String, IRR As Decimal, Funding_Rate As Decimal, Spread As Decimal, Profit As Decimal, Remark As String, Replacement_Percent_Before As Decimal, Maintenance_Percent_Before As Decimal, STNK_Percent_Before As Decimal, Overhead_Percent_Before As Decimal, Assurance_Percent_Before As Decimal) As ActionResult
        '    Dim result As String = "Error"
        '    Dim Message As String = ""
        '    Dim Validate As Boolean = True
        '    If Calculate_ID = 0 Then
        '        Message = "Calculate ID be fill"
        '        Validate = False
        '    ElseIf Rent_Location_ID = 0 Then
        '        Message = "Rent Location must be fill"
        '        Validate = False
        '    ElseIf Plat_Location = 0 Then
        '        Message = "Plat Location must be fill"
        '        Validate = False
        '    ElseIf Payment_Condition = "" Then
        '        Message = "Payment Type must be fill"
        '        Validate = False
        '    ElseIf Term_Of_Payment = 0 Then
        '        Message = "Payment Scheme must be fill"
        '        Validate = False
        '    ElseIf Efektif_Date Is Nothing Then
        '        Message = "Efektif Date must be fill"
        '        Validate = False
        '    ElseIf Bid_PricePerMonth = 0 Then
        '        Message = "Lease Rent / Month must be fill"
        '        Validate = False
        '    End If
        '    Dim user As String
        '    If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
        '    If Validate Then
        '        Using dbs = db.Database.BeginTransaction
        '            Try
        '                Dim calculate = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = Calculate_ID).FirstOrDefault()
        '                calculate.Rent_Location_ID = Rent_Location_ID
        '                calculate.Plat_Location = Plat_Location
        '                calculate.Modification = Modification
        '                calculate.PayMonth = PayMonth
        '                calculate.Payment_Condition = Payment_Condition
        '                calculate.Term_Of_Payment = Term_Of_Payment
        '                calculate.GPS_Cost = GPS_Cost
        '                calculate.GPS_CostPerMonth = GPS_CostPerMonth
        '                calculate.Agent_Fee = Agent_Fee
        '                calculate.Agent_FeePerMonth = Agent_FeePerMonth
        '                calculate.Update_OTR = Update_OTR
        '                calculate.Residual_Value = Residual_Value
        '                calculate.Residual_ValuePercent = Residual_ValuePercent
        '                calculate.Expedition_Status = Expedition_Status
        '                calculate.Expedition_Cost = Expedition_Cost
        '                calculate.Keur = Keur
        '                calculate.Update_Diskon = Update_Diskon
        '                calculate.Cost_Price = Cost_Price
        '                calculate.Up_Front_Fee = Up_Front_Fee
        '                calculate.Up_Front_Fee_Percent = Up_Front_Fee_Percent
        '                calculate.Other = Other
        '                calculate.Efektif_Date = Efektif_Date
        '                calculate.Replacement_Percent = Replacement_Percent
        '                calculate.Replacement_Percent_Before = Replacement_Percent_Before
        '                calculate.Replacement = Replacement
        '                calculate.Maintenance_Percent = Maintenance_Percent
        '                calculate.Maintenance_Percent_Before = Maintenance_Percent_Before
        '                calculate.Maintenance = Maintenance
        '                calculate.STNK_Percent = STNK_Percent
        '                calculate.STNK_Percent_Before = STNK_Percent_Before
        '                calculate.STNK = STNK
        '                calculate.Overhead_Percent = Overhead_Percent
        '                calculate.Overhead_Percent_Before = Overhead_Percent_Before
        '                calculate.Overhead = Overhead
        '                calculate.Assurance_Percent = Assurance_Percent
        '                calculate.Assurance_Percent_Before = Assurance_Percent_Before
        '                calculate.Assurance = Assurance
        '                calculate.Lease_Profit_Percent = Lease_Profit_Percent
        '                calculate.Lease_Profit = Lease_Profit
        '                calculate.Depresiasi_Percent = Depresiasi_Percent
        '                calculate.Depresiasi = Depresiasi
        '                calculate.Funding_Interest_Percent = Funding_Interest_Percent
        '                calculate.Funding_Interest = Funding_Interest
        '                calculate.Bid_PricePerMonth = Bid_PricePerMonth
        '                calculate.Premium = Premium
        '                calculate.OJK = OJK
        '                calculate.SwapRate = SwapRate
        '                calculate.Project_Rating = Project_Rating
        '                calculate.IRR = IRR
        '                calculate.Spread = Spread
        '                calculate.Profit = Profit
        '                calculate.Funding_Rate = Funding_Rate
        '                calculate.ModifiedBy = user
        '                calculate.ModifiedDate = DateTime.Now
        '                calculate.Remark = Remark
        '                calculate.DeviasiBy = user
        '                db.SaveChanges()
        '                Dim detail = db.Tr_CalculateCashFlows.Where(Function(x) x.Calculate_ID = Calculate_ID).ToList
        '                For Each i In detail
        '                    i.IsDeleted = True
        '                    i.ModifiedBy = user
        '                    i.ModifiedDate = DateTime.Now
        '                Next
        '                db.SaveChanges()
        '                Dim prospectDetail_ID = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = Calculate_ID And x.IsDeleted = False).Select(Function(x) x.ProspectCustomerDetail_ID).FirstOrDefault
        '                Dim prospDetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = prospectDetail_ID).FirstOrDefault
        '                Dim AssuranceCashFlow = Assurance / (prospDetail.Lease_long / 12)
        '                SaveCashFlow(True, Calculate_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow, Bid_PricePerMonth, Residual_Value, prospDetail.Lease_long, Expedition_Cost, prospDetail.Transaction_Type, Payment_Condition, Term_Of_Payment, Modification, GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate)
        '                dbs.Commit()
        '            Catch ex As Exception
        '                dbs.Rollback()
        '                Message = ex.Message
        '            End Try
        '        End Using
        '        result = "Success"
        '    End If
        '    Return Json(New With {Key .result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        'End Function

        Function EditDeviasiCal(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Calculates As Tr_Calculates = db.Tr_Calculates.Find(id)
            If IsNothing(tr_Calculates) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_Calculates
                         Where A.IsDeleted = False And A.Calculate_ID = id
                         Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                         From B In Group.DefaultIfEmpty()
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                         From D In DA.DefaultIfEmpty()
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                         From E In EA.DefaultIfEmpty()
                         Select B.Transaction_Type, A.Residual_ValuePercent, A.Expedition_Cost, A.Keur, A.Residual_Value, A.Agent_FeePerMonth, A.GPS_CostPerMonth, A.Payment_Condition, A.Calculate_ID, B.Year, B.Lease_price, B.Lease_long, B.Qty, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Cost_Price, A.Up_Front_Fee, A.Up_Front_Fee_Percent, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Replacement, A.Replacement_Tick, A.Maintenance_Percent, A.Maintenance, A.Maintenance_Tick,
                            A.STNK_Percent, A.STNK, A.STNK_Tick, A.Overhead_Percent, A.Overhead, A.Assurance_Percent, A.Assurance, A.AssuranceExtra, A.Assurance_Tick, A.Lease_Profit_Percent, A.Lease_Profit, A.Depresiasi_Percent, A.Depresiasi, A.Funding_Interest_Percent, A.Funding_Interest, A.Bid_PricePerMonth,
                            A.IRR, A.Funding_Rate, A.Spread, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.Term_Of_Payment, A.Expedition_Status, A.Premium, A.OJK, A.SwapRate, A.Project_Rating, A.Profit, A.PayMonth, A.New_Vehicle_Price, A.Location_Vehicle_ID).
                            Select(Function(x) New Tr_Calculate With {.Transaction_Type = x.Transaction_Type, .Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .Year = x.Year, .Lease_price = x.Lease_price, .Lease_long = x.Lease_long, .Qty = x.Qty,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Payment_Condition = x.Payment_Condition, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost, .GPS_CostPerMonth = x.GPS_CostPerMonth,
            .Agent_Fee = x.Agent_Fee, .Agent_FeePerMonth = x.Agent_FeePerMonth, .Update_OTR = x.Update_OTR, .Residual_Value = x.Residual_Value, .Residual_ValuePercent = x.Residual_ValuePercent, .Expedition_Cost = x.Expedition_Cost, .Keur = x.Keur, .Update_Diskon = x.Update_Diskon, .Cost_Price = x.Cost_Price, .Up_Front_Fee = x.Up_Front_Fee, .Up_Front_Fee_Percent = x.Up_Front_Fee_Percent, .Other = x.Other, .Efektif_Date = x.Efektif_Date,
            .Replacement_Percent = x.Replacement_Percent, .Replacement = x.Replacement, .Replacement_Percent_Before = x.Replacement_Percent,
            .Maintenance_Percent = x.Maintenance_Percent, .Maintenance = x.Maintenance, .Maintenance_Percent_Before = x.Maintenance_Percent, .STNK_Percent = x.STNK_Percent, .STNK = x.STNK, .STNK_Percent_Before = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent, .Overhead = x.Overhead, .Overhead_Percent_Before = x.Overhead_Percent,
            .Assurance_Percent = x.Assurance_Percent, .Assurance = x.Assurance, .Assurance_Percent_Before = x.Assurance_Percent, .Lease_Profit_Percent = x.Lease_Profit_Percent, .Lease_Profit = x.Lease_Profit, .Depresiasi_Percent = x.Depresiasi_Percent, .Depresiasi = x.Depresiasi, .Funding_Interest_Percent = x.Funding_Interest_Percent, .Funding_Interest = x.Funding_Interest,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .IRR = x.IRR, .Funding_Rate = x.Funding_Rate, .Spread = x.Spread, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy,
            .Term_Of_Payment = x.Term_Of_Payment, .Expedition_Status = x.Expedition_Status, .Premium = x.Premium, .OJK = x.OJK, .SwapRate = x.SwapRate, .Project_Rating = x.Project_Rating, .Profit = x.Profit, .PayMonth = x.PayMonth,
            .New_Vehicle_Price = x.New_Vehicle_Price, .Location_Vehicle_ID = x.Location_Vehicle_ID, .AssuranceExtra = x.AssuranceExtra, .Replacement_Tick = x.Replacement_Tick, .Maintenance_Tick = x.Maintenance_Tick, .STNK_Tick = x.STNK_Tick, .Assurance_Tick = x.Assurance_Tick
            }).FirstOrDefault()
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City", Query.Plat_Location)
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City", Query.Rent_Location_ID)
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            ViewBag.Term_Of_Payment = New SelectList(month, "Value", "Text", Query.Term_Of_Payment)
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text", Query.GPS_CostPerMonth)
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text", Query.Agent_FeePerMonth)
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                },
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text", Query.Payment_Condition)
            ViewBag.Expedition_Status = New SelectList(expedisiStatus, "Value", "Text", Query.Expedition_Status)
            Dim MyPayMonth As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Nothing",
                    .Value = 0
                },
                New SelectListItem With {
                    .Text = "First Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "Second Month",
                    .Value = 2
                },
                New SelectListItem With {
                    .Text = "Third Month",
                    .Value = 3
                }
            }
            ViewBag.PayMonth = New SelectList(MyPayMonth, "Value", "Text", Query.PayMonth)
            ViewBag.Location_Vehicle_ID = New SelectList(city, "CIty_ID", "City", Query.Location_Vehicle_ID)
            Query.GoalSeek = ""
            Return View(Query)
        End Function
        ' GET: Calculate/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Calculates As Tr_Calculates = db.Tr_Calculates.Find(id)
            If IsNothing(tr_Calculates) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_Calculates
                         Where A.IsDeleted = False And A.Calculate_ID = id
                         Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                         From B In Group.DefaultIfEmpty()
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                         From D In DA.DefaultIfEmpty()
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                         From E In EA.DefaultIfEmpty()
                         Select B.Transaction_Type, A.Residual_ValuePercent, A.Expedition_Cost, A.Keur, A.Residual_Value, A.Agent_FeePerMonth, A.GPS_CostPerMonth, A.Payment_Condition, A.Calculate_ID, B.Year, B.Lease_price, B.Lease_long, B.Qty, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Update_DiskonSystem, A.Update_DiskonTick, A.Cost_Price, A.Up_Front_Fee, A.Up_Front_Fee_Percent, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Replacement_Percent_Before, A.Replacement, A.Replacement_Tick, A.Maintenance_Percent, A.Maintenance_Percent_Before, A.Maintenance, A.Maintenance_Tick,
                            A.STNK_Percent, A.STNK_Percent_Before, A.STNK, A.STNK_Tick, A.Overhead_Percent, A.Overhead, A.Assurance_Percent, A.Assurance_Percent_Before, A.Assurance, A.Assurance_Tick, A.Lease_Profit_Percent, A.Lease_Profit, A.Depresiasi_Percent, A.Depresiasi, A.Funding_Interest_Percent, A.Funding_Interest, A.Bid_PricePerMonth,
                            A.IRR, A.Funding_Rate, A.Spread, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.Term_Of_Payment, A.Expedition_Status, A.Premium, A.OJK, A.SwapRate, A.Project_Rating, A.Profit, A.PayMonth, A.New_Vehicle_Price, A.Location_Vehicle_ID, Location_Vehicle = A.Ms_Citys.City, B.Type, B.Model_ID, A.AssuranceExtra).
                            Select(Function(x) New Tr_Calculate With {.Transaction_Type = x.Transaction_Type, .Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .Year = x.Year, .Lease_price = x.Lease_price, .Lease_long = x.Lease_long, .Qty = x.Qty,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Payment_Condition = x.Payment_Condition, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost, .GPS_CostPerMonth = x.GPS_CostPerMonth,
            .Agent_Fee = x.Agent_Fee, .Agent_FeePerMonth = x.Agent_FeePerMonth, .Update_OTR = x.Update_OTR, .Residual_Value = x.Residual_Value, .Residual_ValuePercent = x.Residual_ValuePercent, .Expedition_Cost = x.Expedition_Cost, .Keur = x.Keur, .Update_Diskon = x.Update_Diskon, .Update_DiskonSystem = x.Update_DiskonSystem, .Update_DiskonTick = x.Update_DiskonTick, .Cost_Price = x.Cost_Price, .Up_Front_Fee = x.Up_Front_Fee, .Up_Front_Fee_Percent = x.Up_Front_Fee_Percent, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent, .Replacement_Percent_Before = x.Replacement_Percent_Before, .Replacement = x.Replacement, .Replacement_Tick = x.Replacement_Tick,
            .Maintenance_Percent = x.Maintenance_Percent, .Maintenance_Percent_Before = x.Maintenance_Percent_Before, .Maintenance = x.Maintenance, .Maintenance_Tick = x.Maintenance_Tick, .STNK_Percent = x.STNK_Percent, .STNK_Percent_Before = x.STNK_Percent_Before, .STNK = x.STNK, .STNK_Tick = x.STNK_Tick, .Overhead_Percent = x.Overhead_Percent, .Overhead = x.Overhead,
            .Assurance_Percent = x.Assurance_Percent, .Assurance_Percent_Before = x.Assurance_Percent_Before, .Assurance = x.Assurance, .Assurance_Tick = x.Assurance_Tick, .Lease_Profit_Percent = x.Lease_Profit_Percent, .Lease_Profit = x.Lease_Profit, .Depresiasi_Percent = x.Depresiasi_Percent, .Depresiasi = x.Depresiasi, .Funding_Interest_Percent = x.Funding_Interest_Percent, .Funding_Interest = x.Funding_Interest,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .IRR = x.IRR, .Funding_Rate = x.Funding_Rate, .Spread = x.Spread, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy,
            .Term_Of_Payment = x.Term_Of_Payment, .Expedition_Status = x.Expedition_Status, .Premium = x.Premium, .OJK = x.OJK, .SwapRate = x.SwapRate, .Project_Rating = x.Project_Rating, .Project = x.Project_Rating, .Profit = x.Profit, .PayMonth = x.PayMonth,
            .New_Vehicle_Price = x.New_Vehicle_Price, .Location_Vehicle_ID = x.Location_Vehicle_ID, .Location_Vehicle = x.Location_Vehicle, .Type = x.Type, .Model_ID = x.Model_ID, .AssuranceExtra = x.AssuranceExtra
            }).FirstOrDefault()
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City", Query.Rent_Location_ID)
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City", Query.Plat_Location)
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            ViewBag.Term_Of_Payment = New SelectList(month, "Value", "Text", Query.Term_Of_Payment)
            ViewBag.GPS_CostPerMonth = New SelectList(month, "Value", "Text", Query.GPS_CostPerMonth)
            ViewBag.Agent_FeePerMonth = New SelectList(month, "Value", "Text", Query.Agent_FeePerMonth)
            Dim payment As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Payment in arrear",
                    .Value = "Payment in arrear"
                },
                New SelectListItem With {
                    .Text = "Payment in advance",
                    .Value = "Payment in advance"
                }
            }
            ViewBag.Payment_Condition = New SelectList(payment, "Value", "Text", Query.Payment_Condition)
            ViewBag.Expedition_Status = New SelectList(expedisiStatus, "Value", "Text", Query.Expedition_Status)
            Dim MyPayMonth As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Nothing",
                    .Value = 0
                },
                New SelectListItem With {
                    .Text = "First Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "Second Month",
                    .Value = 2
                },
                New SelectListItem With {
                    .Text = "Third Month",
                    .Value = 3
                }
            }
            ViewBag.PayMonth = New SelectList(MyPayMonth, "Value", "Text", Query.PayMonth)
            ViewBag.Location_Vehicle_ID = New SelectList(city, "CIty_ID", "City", Query.Location_Vehicle_ID)
            Query.GoalSeek = ""
            Return View(Query)
        End Function
        Public Function EditData(orderHD() As Tr_Calculate) As ActionResult
            Dim H = orderHD.FirstOrDefault
            Dim result As String = "Error"
            Dim Message As String = ""
            Dim Validate As Boolean = True
            If H.Calculate_ID = 0 Then
                Message = "Calculate ID be fill"
                Validate = False
            ElseIf H.Rent_Location_ID = 0 Then
                Message = "Rent Location must be fill"
                Validate = False
            ElseIf H.Plat_Location = 0 Then
                Message = "Plat Location must be fill"
                Validate = False
            ElseIf H.Payment_Condition = "" Then
                Message = "Payment Type must be fill"
                Validate = False
            ElseIf H.Term_Of_Payment = 0 Then
                Message = "Payment Scheme must be fill"
                Validate = False
            ElseIf H.Efektif_Date Is Nothing Then
                Message = "Efektif Date must be fill"
                Validate = False
            ElseIf H.Bid_PricePerMonth = 0 Then
                Message = "Lease Rent / Month must be fill"
                Validate = False
            ElseIf H.Expedition_Status = "" Then
                Message = "Expedition Status must be fill"
                Validate = False
            ElseIf H.Project_Rating = "" Then
                Message = "Project Rating is Empty"
                Validate = False
            ElseIf H.IsVehicleExists And H.Location_Vehicle_ID = 0 Then
                Message = "Must fill Location Vehicle"
                Validate = False
            End If
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If Validate Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim calculate = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = H.Calculate_ID).FirstOrDefault()
                        calculate.Rent_Location_ID = H.Rent_Location_ID
                        calculate.Plat_Location = H.Plat_Location
                        calculate.Modification = H.Modification
                        calculate.PayMonth = H.PayMonth
                        calculate.Payment_Condition = H.Payment_Condition
                        calculate.Term_Of_Payment = H.Term_Of_Payment
                        calculate.GPS_Cost = H.GPS_Cost
                        calculate.GPS_CostPerMonth = H.GPS_CostPerMonth
                        calculate.Agent_Fee = H.Agent_Fee
                        calculate.Agent_FeePerMonth = H.Agent_FeePerMonth
                        calculate.Update_OTR = H.Update_OTR
                        calculate.Residual_Value = H.Residual_Value
                        calculate.Residual_ValuePercent = H.Residual_ValuePercent
                        calculate.Expedition_Status = H.Expedition_Status
                        calculate.Expedition_Cost = H.Expedition_Cost
                        calculate.Keur = H.Keur
                        calculate.Update_Diskon = H.Update_Diskon
                        calculate.Update_DiskonSystem = H.Update_DiskonSystem
                        calculate.Update_DiskonTick = H.Update_DiskonTick
                        calculate.Cost_Price = H.Cost_Price
                        calculate.Up_Front_Fee = H.Up_Front_Fee
                        calculate.Up_Front_Fee_Percent = H.Up_Front_Fee_Percent
                        calculate.Other = H.Other
                        calculate.Efektif_Date = H.Efektif_Date
                        calculate.Replacement_Percent = H.Replacement_Percent
                        calculate.Replacement_Percent_Before = H.Replacement_Percent_Before
                        calculate.Replacement = H.Replacement
                        calculate.Replacement_Tick = H.Replacement_Tick
                        calculate.Maintenance_Percent = H.Maintenance_Percent
                        calculate.Maintenance_Percent_Before = H.Maintenance_Percent_Before
                        calculate.Maintenance = H.Maintenance
                        calculate.Maintenance_Tick = H.Maintenance_Tick
                        calculate.STNK_Percent = H.STNK_Percent
                        calculate.STNK_Percent_Before = H.STNK_Percent_Before
                        calculate.STNK = H.STNK
                        calculate.STNK_Tick = H.STNK_Tick
                        calculate.Overhead_Percent = H.Overhead_Percent
                        calculate.Overhead = H.Overhead
                        calculate.Assurance_Percent = H.Assurance_Percent
                        calculate.Assurance_Percent_Before = H.Assurance_Percent_Before
                        calculate.Assurance = H.Assurance
                        calculate.Assurance_Tick = H.Assurance_Tick
                        calculate.AssuranceExtra = H.AssuranceExtra
                        calculate.Lease_Profit_Percent = H.Lease_Profit_Percent
                        calculate.Lease_Profit = H.Lease_Profit
                        calculate.Depresiasi_Percent = H.Depresiasi_Percent
                        calculate.Depresiasi = H.Depresiasi
                        calculate.Funding_Interest_Percent = H.Funding_Interest_Percent
                        calculate.Funding_Interest = H.Funding_Interest
                        calculate.Bid_PricePerMonth = H.Bid_PricePerMonth
                        calculate.Premium = H.Premium
                        calculate.OJK = H.OJK
                        calculate.SwapRate = H.SwapRate
                        calculate.Project_Rating = H.Project_Rating
                        calculate.IRR = H.IRR
                        calculate.Spread = H.Spread
                        calculate.Profit = H.Profit
                        calculate.Funding_Rate = H.Funding_Rate
                        If H.IsVehicleExists Then
                            calculate.New_Vehicle_Price = H.New_Vehicle_Price
                            calculate.Location_Vehicle_ID = H.Location_Vehicle_ID
                        End If
                        calculate.ModifiedBy = user
                        calculate.ModifiedDate = DateTime.Now
                        db.SaveChanges()
                        Dim detail = db.Tr_CalculateCashFlows.Where(Function(x) x.Calculate_ID = H.Calculate_ID).ToList
                        For Each i In detail
                            i.IsDeleted = True
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        Dim cashFlow = db.Tr_CalculateCashFlows.Where(Function(X) X.IsDeleted = False And X.Calculate_ID = H.Calculate_ID).ToList
                        For Each i In cashFlow
                            i.IsDeleted = False
                            i.ModifiedBy = user
                            i.ModifiedDate = DateTime.Now
                        Next
                        db.SaveChanges()

                        Dim AssuranceCashFlow = (H.Assurance + H.AssuranceExtra) / (H.Lease_long / 12)
                        SaveCashFlow(True, H.Calculate_ID, user, H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, AssuranceCashFlow, H.Bid_PricePerMonth, H.Residual_Value, H.Lease_long, H.Expedition_Cost, H.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate)
                        'Dim Calculate_ID = H.Calculate_ID, Expedition_Status = H.Expedition_Status, PayMonth = H.PayMonth, Cost_Price = H.Cost_Price,
                        'Up_Front_Fee = H.Up_Front_Fee, Replacement = H.Replacement, Maintenance = H.Maintenance, STNK = H.STNK, Overhead = H.Overhead,
                        'Bid_PricePerMonth = H.Bid_PricePerMonth, Residual_Value = H.Residual_Value, Lease_long = H.Lease_long, Expedition_Cost = H.Expedition_Cost,
                        'Transaction_Type = H.Transaction_Type, Payment_Condition = H.Payment_Condition, Term_Of_Payment = H.Term_Of_Payment, Modification = H.Modification,
                        'GPS_Cost = H.GPS_Cost, GPS_CostPerMonth = H.GPS_CostPerMonth, Agent_Fee = H.Agent_Fee, Agent_FeePerMonth = H.Agent_FeePerMonth, Other = H.Other,
                        'Keur = H.Keur, Funding_Rate = H.Funding_Rate
                        'Dim messageResult = db.sp_SaveCashFlow(True, Calculate_ID, user, Expedition_Status, PayMonth, Cost_Price, Up_Front_Fee, Replacement, Maintenance, STNK, Overhead, AssuranceCashFlow,
                        '             Bid_PricePerMonth, Residual_Value, Lease_long, Expedition_Cost, Transaction_Type, Payment_Condition, Term_Of_Payment, Modification,
                        '             GPS_Cost, GPS_CostPerMonth, Agent_Fee, Agent_FeePerMonth, Other, Keur, Funding_Rate).ToList

                        'If messageResult.Select(Function(x) x.Message).FirstOrDefault <> "Success" Then
                        '    Throw New System.Exception(messageResult.Select(Function(x) x.Message).FirstOrDefault)
                        'End If

                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                        Message = ex.Message
                    End Try
                End Using
                result = "Success"
            End If
            Return Json(New With {Key .result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function

        ' EDIT OTR Application
        Function EditOTR(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Calculates As Tr_Applications = db.Tr_Applications.Find(id)
            If IsNothing(tr_Calculates) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_Applications
                         Where A.IsDeleted = False And A.Application_ID = id
                         Group Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID Into Group
                         From B In Group.DefaultIfEmpty()
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                         From D In DA.DefaultIfEmpty()
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                         From E In EA.DefaultIfEmpty()
                         Select B.Transaction_Type, A.Residual_ValuePercent, A.Expedition_Cost, A.Keur, A.Residual_Value, A.Agent_FeePerMonth, A.GPS_CostPerMonth, A.Payment_Condition, A.Application_ID, B.Year, B.Lease_price, B.Lease_long, B.Qty, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Update_DiskonSystem, A.Update_DiskonTick, A.Cost_Price, A.Up_Front_Fee, A.Up_Front_Fee_Percent, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Replacement_Percent_Before, A.Replacement, A.Replacement_Tick, A.Maintenance_Percent, A.Maintenance_Percent_Before, A.Maintenance, A.Maintenance_Tick,
                            A.STNK_Percent, A.STNK_Percent_Before, A.STNK, A.STNK_Tick, A.Overhead_Percent, A.Overhead, A.Assurance_Percent, A.Assurance_Percent_Before, A.Assurance, A.Assurance_Tick, A.Lease_Profit_Percent, A.Lease_Profit, A.Depresiasi_Percent, A.Depresiasi, A.Funding_Interest_Percent, A.Funding_Interest, A.Bid_PricePerMonth,
                            A.IRR, A.Funding_Rate, A.Spread, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy, A.Term_Of_Payment, A.Expedition_Status, A.Premium, A.OJK, A.SwapRate, A.Project_Rating, A.Profit, A.PayMonth, A.New_Vehicle_Price, A.Location_Vehicle_ID, B.Type, B.Model_ID, A.AssuranceExtra).
                            Select(Function(x) New Tr_Calculate With {.Transaction_Type = x.Transaction_Type, .Calculate_ID = x.Application_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount, .Year = x.Year, .Lease_price = x.Lease_price, .Lease_long = x.Lease_long, .Qty = x.Qty,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Payment_Condition = x.Payment_Condition, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost, .GPS_CostPerMonth = x.GPS_CostPerMonth,
            .Agent_Fee = x.Agent_Fee, .Agent_FeePerMonth = x.Agent_FeePerMonth, .Update_OTR = x.Update_OTR, .Residual_Value = x.Residual_Value, .Residual_ValuePercent = x.Residual_ValuePercent, .Expedition_Cost = x.Expedition_Cost, .Keur = x.Keur, .Update_Diskon = x.Update_Diskon, .Update_DiskonSystem = x.Update_DiskonSystem, .Update_DiskonTick = x.Update_DiskonTick, .Cost_Price = x.Cost_Price, .Up_Front_Fee = x.Up_Front_Fee, .Up_Front_Fee_Percent = x.Up_Front_Fee_Percent, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent, .Replacement_Percent_Before = x.Replacement_Percent_Before, .Replacement = x.Replacement, .Replacement_Tick = x.Replacement_Tick,
            .Maintenance_Percent = x.Maintenance_Percent, .Maintenance_Percent_Before = x.Maintenance_Percent_Before, .Maintenance = x.Maintenance, .Maintenance_Tick = x.Maintenance_Tick, .STNK_Percent = x.STNK_Percent, .STNK_Percent_Before = x.STNK_Percent_Before, .STNK = x.STNK, .STNK_Tick = x.STNK_Tick, .Overhead_Percent = x.Overhead_Percent, .Overhead = x.Overhead,
            .Assurance_Percent = x.Assurance_Percent, .Assurance_Percent_Before = x.Assurance_Percent_Before, .Assurance = x.Assurance, .Assurance_Tick = x.Assurance_Tick, .Lease_Profit_Percent = x.Lease_Profit_Percent, .Lease_Profit = x.Lease_Profit, .Depresiasi_Percent = x.Depresiasi_Percent, .Depresiasi = x.Depresiasi, .Funding_Interest_Percent = x.Funding_Interest_Percent, .Funding_Interest = x.Funding_Interest,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .IRR = x.IRR, .Funding_Rate = x.Funding_Rate, .Spread = x.Spread, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy,
            .Term_Of_Payment = x.Term_Of_Payment, .Expedition_Status = x.Expedition_Status, .Premium = x.Premium, .OJK = x.OJK, .SwapRate = x.SwapRate, .Project_Rating = x.Project_Rating, .Project = x.Project_Rating, .Profit = x.Profit, .PayMonth = x.PayMonth,
            .New_Vehicle_Price = x.New_Vehicle_Price, .Location_Vehicle_ID = x.Location_Vehicle_ID, .Type = x.Type, .Model_ID = x.Model_ID, .AssuranceExtra = x.AssuranceExtra
            }).FirstOrDefault()
            Dim city = db.Ms_Citys.OrderBy(Function(x) x.City).ToList()
            ViewBag.Rent_Location_ID = New SelectList(city, "CIty_ID", "City", Query.Rent_Location_ID)
            ViewBag.Plat_Location = New SelectList(city, "CIty_ID", "City", Query.Plat_Location)
            Dim month As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Month",
                    .Value = 1
                },
                New SelectListItem With {
                    .Text = "3 Month",
                    .Value = 3
                },
                New SelectListItem With {
                    .Text = "6 Month",
                    .Value = 6
                },
                New SelectListItem With {
                    .Text = "12 Month",
                    .Value = 12
                }
            }
            Query.GoalSeek = ""
            Return View(Query)
        End Function
        Public Function EditOTRData(orderHD() As Tr_Calculate) As ActionResult
            'Dim H = orderHD.FirstOrDefault
            'Dim result As String = "Error"
            'Dim Message As String = ""
            'Dim Validate As Boolean = True
            'If H.Calculate_ID = 0 Then
            '    Message = "Calculate ID be fill"
            '    Validate = False
            'ElseIf H.Rent_Location_ID = 0 Then
            '    Message = "Rent Location must be fill"
            '    Validate = False
            'ElseIf H.Plat_Location = 0 Then
            '    Message = "Plat Location must be fill"
            '    Validate = False
            'ElseIf H.Payment_Condition = "" Then
            '    Message = "Payment Type must be fill"
            '    Validate = False
            'ElseIf H.Term_Of_Payment = 0 Then
            '    Message = "Payment Scheme must be fill"
            '    Validate = False
            'ElseIf H.Efektif_Date Is Nothing Then
            '    Message = "Efektif Date must be fill"
            '    Validate = False
            'ElseIf H.Bid_PricePerMonth = 0 Then
            '    Message = "Lease Rent / Month must be fill"
            '    Validate = False
            'ElseIf H.Expedition_Status = "" Then
            '    Message = "Expedition Status must be fill"
            '    Validate = False
            'ElseIf H.Project_Rating = "" Then
            '    Message = "Project Rating is Empty"
            '    Validate = False
            'ElseIf H.IsVehicleExists And H.Location_Vehicle_ID = 0 Then
            '    Message = "Must fill Location Vehicle"
            '    Validate = False
            'End If
            'Dim user As String
            'If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            'If Validate Then
            '    Using dbs = db.Database.BeginTransaction
            '        Try
            '            'Edit OTR ke Applikasi
            '            Dim calculate = db.Tr_Applications.Where(Function(x) x.Application_ID = H.Calculate_ID).FirstOrDefault()
            '            'calculate.Rent_Location_ID = H.Rent_Location_ID
            '            'calculate.Plat_Location = H.Plat_Location
            '            'calculate.Modification = H.Modification
            '            'calculate.PayMonth = H.PayMonth
            '            'calculate.Payment_Condition = H.Payment_Condition
            '            'calculate.Term_Of_Payment = H.Term_Of_Payment
            '            'calculate.GPS_Cost = H.GPS_Cost
            '            'calculate.GPS_CostPerMonth = H.GPS_CostPerMonth
            '            'calculate.Agent_Fee = H.Agent_Fee
            '            'calculate.Agent_FeePerMonth = H.Agent_FeePerMonth
            '            calculate.Update_OTR = H.Update_OTR
            '            calculate.Residual_Value = H.Residual_Value
            '            calculate.Residual_ValuePercent = H.Residual_ValuePercent
            '            calculate.Expedition_Status = H.Expedition_Status
            '            calculate.Expedition_Cost = H.Expedition_Cost
            '            calculate.Keur = H.Keur
            '            calculate.Update_Diskon = H.Update_Diskon
            '            calculate.Update_DiskonSystem = H.Update_DiskonSystem
            '            calculate.Update_DiskonTick = H.Update_DiskonTick
            '            calculate.Cost_Price = H.Cost_Price
            '            calculate.Up_Front_Fee = H.Up_Front_Fee
            '            calculate.Up_Front_Fee_Percent = H.Up_Front_Fee_Percent
            '            calculate.Other = H.Other
            '            calculate.Efektif_Date = H.Efektif_Date
            '            calculate.Replacement_Percent = H.Replacement_Percent
            '            calculate.Replacement_Percent_Before = H.Replacement_Percent_Before
            '            calculate.Replacement = H.Replacement
            '            calculate.Replacement_Tick = H.Replacement_Tick
            '            calculate.Maintenance_Percent = H.Maintenance_Percent
            '            calculate.Maintenance_Percent_Before = H.Maintenance_Percent_Before
            '            calculate.Maintenance = H.Maintenance
            '            calculate.Maintenance_Tick = H.Maintenance_Tick
            '            calculate.STNK_Percent = H.STNK_Percent
            '            calculate.STNK_Percent_Before = H.STNK_Percent_Before
            '            calculate.STNK = H.STNK
            '            calculate.STNK_Tick = H.STNK_Tick
            '            calculate.Overhead_Percent = H.Overhead_Percent
            '            calculate.Overhead = H.Overhead
            '            calculate.Assurance_Percent = H.Assurance_Percent
            '            calculate.Assurance_Percent_Before = H.Assurance_Percent_Before
            '            calculate.Assurance = H.Assurance
            '            calculate.Assurance_Tick = H.Assurance_Tick
            '            calculate.AssuranceExtra = H.AssuranceExtra
            '            calculate.Lease_Profit_Percent = H.Lease_Profit_Percent
            '            calculate.Lease_Profit = H.Lease_Profit
            '            calculate.Depresiasi_Percent = H.Depresiasi_Percent
            '            calculate.Depresiasi = H.Depresiasi
            '            calculate.Funding_Interest_Percent = H.Funding_Interest_Percent
            '            calculate.Funding_Interest = H.Funding_Interest
            '            calculate.Bid_PricePerMonth = H.Bid_PricePerMonth
            '            calculate.Premium = H.Premium
            '            calculate.OJK = H.OJK
            '            calculate.SwapRate = H.SwapRate
            '            calculate.Project_Rating = H.Project_Rating
            '            calculate.IRR = H.IRR
            '            calculate.Spread = H.Spread
            '            calculate.Profit = H.Profit
            '            calculate.Funding_Rate = H.Funding_Rate
            '            If H.IsVehicleExists Then
            '                calculate.New_Vehicle_Price = H.New_Vehicle_Price
            '                calculate.Location_Vehicle_ID = H.Location_Vehicle_ID
            '            End If
            '            calculate.ModifiedBy = user
            '            calculate.ModifiedDate = DateTime.Now
            '            calculate.IsFillOTR = True
            '            calculate.FillOTRBy = user
            '            db.SaveChanges()
            '            Dim detail = db.Tr_ApplicationCashFlows.Where(Function(x) x.Application_ID = H.Calculate_ID).ToList
            '            For Each i In detail
            '                i.IsDeleted = True
            '                i.ModifiedBy = user
            '                i.ModifiedDate = DateTime.Now
            '            Next
            '            db.SaveChanges()
            '            'Dim prospectDetail_ID = db.Tr_Calculates.Where(Function(x) x.Calculate_ID = H.Calculate_ID And x.IsDeleted = False).Select(Function(x) x.ProspectCustomerDetail_ID).FirstOrDefault
            '            'Dim prospDetail = db.Tr_ProspectCustDetails.Where(Function(x) x.ProspectCustomerDetail_ID = prospectDetail_ID).FirstOrDefault
            '            Dim AssuranceCashFlow = (H.Assurance + H.AssuranceExtra) / (H.Lease_long / 12)
            '            SaveCashFlow(False, H.Calculate_ID, user, H.Expedition_Status, H.PayMonth, H.Cost_Price, H.Up_Front_Fee, H.Replacement, H.Maintenance, H.STNK, H.Overhead, AssuranceCashFlow, H.Bid_PricePerMonth, H.Residual_Value, H.Lease_long, H.Expedition_Cost, H.Transaction_Type, H.Payment_Condition, H.Term_Of_Payment, H.Modification, H.GPS_Cost, H.GPS_CostPerMonth, H.Agent_Fee, H.Agent_FeePerMonth, H.Other, H.Keur, H.Funding_Rate)
            '            'samain Qty, kalo Qty sama maka dia bisa buat Application Header
            '            Dim approval_id = db.Tr_Applications.Where(Function(x) x.Application_ID = H.Calculate_ID And x.IsDeleted = False).Select(Function(x) x.Approval_ID).FirstOrDefault
            '            Dim CountApp = db.Tr_Applications.Where(Function(x) x.Approval_ID = approval_id And x.IsFillOTR = True And x.IsDeleted = False).Count
            '            Dim approval = db.Tr_Approvals.Where(Function(x) x.Approval_ID = approval_id And x.IsDeleted = False).FirstOrDefault
            '            Dim CountQuotDetail = db.Tr_QuotationDetails.Where(Function(x) x.Quotation_ID = approval.Quotation_ID And x.IsDeleted = False).Count

            '            If CountApp = CountQuotDetail Then
            '                approval.IsApplicationHeader = True
            '            End If
            '            db.SaveChanges()
            '            dbs.Commit()
            '        Catch ex As Exception
            '            dbs.Rollback()
            '            Message = ex.Message
            '        End Try
            '    End Using
            '    result = "Success"
            'End If
            'Return Json(New With {Key .result = result, .message = Message}, JsonRequestBehavior.AllowGet)
        End Function


        '' POST: Calculate/Edit/5
        ''To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        ''more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        '<HttpPost()>
        '<ValidateAntiForgeryToken()>
        'Function Edit(<Bind(Include:="Calculate_ID,ProspectCustomer_ID,FixCost_ID,Rent_Location_ID,Plat_Location,Modification,GPS_Cost,Agent_Fee,Update_OTR,Update_Diskon,Other,Efektif_Date,Replacement_Percent,Maintenance_Percent,STNK_Percent,Overhead_Percent,Assurance_Percent,Spread_Percent,Bid_Price,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_Calculates As Tr_Calculates) As ActionResult
        '    If ModelState.IsValid Then
        '        db.Entry(tr_Calculates).State = EntityState.Modified
        '        db.SaveChanges()
        '        Return RedirectToAction("Index")
        '    End If
        '    ViewBag.FixCost_ID = New SelectList(db.Ms_FixCosts, "FixCost_ID", "FixCost_Name", tr_Calculates.FixCost_ID)
        '    ViewBag.Plat_Location = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Calculates.Plat_Location)
        '    ViewBag.Rent_Location_ID = New SelectList(db.Ms_Citys, "CIty_ID", "City", tr_Calculates.Rent_Location_ID)
        '    'Dim Query = From prospect In db.Tr_ProspectCusts
        '    '            Join cust In db.Ms_Customers
        '    '            On prospect.Customer_ID Equals cust.Customer_ID
        '    '            Select prospect.ProspectCustomer_ID, cust.Company_Name
        '    'ViewBag.ProspectCustomer_ID = New SelectList(Query, "ProspectCustomer_ID", "Company_Name")
        '    Return View(tr_Calculates)
        'End Function

        ' GET: Calculate/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_Calculates As Tr_Calculates = db.Tr_Calculates.Find(id)
            If IsNothing(tr_Calculates) Then
                Return HttpNotFound()
            End If

            Dim Query = (From A In db.Tr_Calculates
                         Where A.IsDeleted = False And A.Calculate_ID = id
                         Group Join B In db.V_ProspectCustDetails On A.ProspectCustomerDetail_ID Equals B.ProspectCustomerDetail_ID Into Group
                         From B In Group.DefaultIfEmpty()
                         Group Join D In db.Ms_Citys On A.Rent_Location_ID Equals D.CIty_ID Into DA = Group
                         From D In DA.DefaultIfEmpty()
                         Group Join E In db.Ms_Citys On A.Plat_Location Equals E.CIty_ID Into EA = Group
                         From E In EA.DefaultIfEmpty()
                         Select A.Calculate_ID, B.CompanyGroup_Name, B.Company_Name, B.IsVehicleExists, B.Brand_Name, B.Vehicle, B.Amount, A.Rent_Location_ID, Rent_Location_Name = D.City,
                            A.Plat_Location, Plat_Location_Name = E.City, A.Modification, A.GPS_Cost, A.Agent_Fee, A.Update_OTR, A.Update_Diskon, A.Other, A.Efektif_Date, A.Replacement_Percent, A.Maintenance_Percent,
                            A.STNK_Percent, A.Overhead_Percent, A.Assurance_Percent, A.Bid_PricePerMonth, A.CreatedDate, A.CreatedBy, A.ModifiedDate, A.ModifiedBy).
                            Select(Function(x) New Tr_Calculate With {.Calculate_ID = x.Calculate_ID, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name, .IsVehicleExists = x.IsVehicleExists,
                                .Brand_Name = x.Brand_Name, .Vehicle = x.Vehicle, .Amount = x.Amount,
                                .Rent_Location_ID = x.Rent_Location_ID,
            .Rent_Location_Name = x.Rent_Location_Name, .Plat_Location = x.Plat_Location, .Plat_Location_Name = x.Plat_Location_Name, .Modification = x.Modification, .GPS_Cost = x.GPS_Cost,
            .Agent_Fee = x.Agent_Fee, .Update_OTR = x.Update_OTR, .Update_Diskon = x.Update_Diskon, .Other = x.Other, .Efektif_Date = x.Efektif_Date, .Replacement_Percent = x.Replacement_Percent,
            .Maintenance_Percent = x.Maintenance_Percent, .STNK_Percent = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent, .Assurance_Percent = x.Assurance_Percent,
            .Bid_PricePerMonth = x.Bid_PricePerMonth, .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.ModifiedBy
            }).FirstOrDefault()
            Return View(Query)
        End Function

        ' POST: Calculate/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tr_Calculates As Tr_Calculates = db.Tr_Calculates.Find(id)
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            tr_Calculates.ModifiedBy = user
            tr_Calculates.ModifiedDate = DateTime.Now
            tr_Calculates.IsDeleted = True
            Dim tr_ProspectCustDetails As Tr_ProspectCustDetails = db.Tr_ProspectCustDetails.Find(tr_Calculates.ProspectCustomerDetail_ID)
            tr_ProspectCustDetails.IsCalculate = False
            Dim tr_CalculateCashFlow = db.Tr_CalculateCashFlows.Where(Function(x) x.Calculate_ID = id).ToList
            For Each i In tr_CalculateCashFlow
                i.ModifiedBy = user
                i.ModifiedDate = DateTime.Now
                i.IsDeleted = True
            Next
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
