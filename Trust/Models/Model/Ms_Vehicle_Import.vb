Public Class Ms_Vehicle_Import
    Public Property owner_id As Nullable(Of Integer)
    Public Property license_no As String
    Public Property manufacturer_id As Nullable(Of Integer)
    Public Property Model_ID As Nullable(Of Integer)
    Public Property color As String
    Public Property year As Nullable(Of Integer)
    Public Property chassis_no As String
    Public Property machine_no As String
    Public Property title_no As String
    Public Property serial_no As String
    Public Property registration_no As String
    Public Property registration_expdate As Nullable(Of Date)
    Public Property discount As Nullable(Of Decimal)
    Public Property price As Nullable(Of Decimal)
    Public Property comment As String
    Public Property date_book As Nullable(Of Date)

    Public Property Tmp_Plat As String
    Public Property CarType As String
    Public Property STNK_Name As String
    Public Property STNK_Address As String
    Public Property CC As Nullable(Of Integer)
    Public Property PO_No As String
    Public Property Harga_Beli As Nullable(Of Decimal)
    Public Property Kwitansi_Date As Nullable(Of Date)
    Public Property Kwitansi_No As String
    Public Property FakturPajak_Date As Nullable(Of Date)
    Public Property FakturPajak_No As String
    Public Property VAT As String
    Public Property Dealer As String
    Public Property Type As String

End Class
Public Class Ms_Vehicle_Import_Form
    Public Property uploaded As HttpPostedFileBase
    Public Property TKS As Boolean
    Public Property Trust As Boolean

End Class
