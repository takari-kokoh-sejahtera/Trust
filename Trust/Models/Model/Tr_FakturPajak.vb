Imports System.ComponentModel.DataAnnotations

Public Class Tr_FakturPajak
    Public Property FakturPajak_ID As Integer
    <Display(Name:="No Faktur Pajak Start")>
    Public Property NoFaktur_Start As Nullable(Of Integer)

    <Display(Name:="No Faktur Pajak End")>
    Public Property NoFaktur_End As Nullable(Of Integer)

    <Display(Name:="Date Start")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Date_Start As Nullable(Of DateTime)

    <Display(Name:="Date End")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property Date_End As Nullable(Of DateTime)

End Class
