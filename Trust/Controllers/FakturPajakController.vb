Imports System.Web.Mvc
Imports Trust.Trust
Imports PagedList

Namespace Controllers
    Public Class FakturPajakController
        Inherits Controller
        Private db As New TrustEntities
        ' GET: FakturPajak
        Function InputFakturPajak() As ActionResult
            Return View()
        End Function

        Function SaveOrder(model As Tr_FakturPajak) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim result As String = "Error"
            Dim Valid As Boolean = True
            Dim Message As String = ""


            If Valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim Faktur As New Tr_FakturPajaks
                        Faktur.NoFaktur_Start = model.NoFaktur_Start
                        Faktur.NoFaktur_End = model.NoFaktur_End
                        Faktur.Date_Start = model.Date_Start
                        Faktur.Date_End = model.Date_End
                        Faktur.CreatedDate = DateTime.Now
                        Faktur.CreatedBy = user
                        Faktur.IsDeleted = False
                        db.Tr_FakturPajaks.Add(Faktur)
                        db.SaveChanges()
                        For i As Integer = model.NoFaktur_Start To model.NoFaktur_End
                            Dim det As New Tr_FakturPajakDetails
                            det.FakturPajak_ID = Faktur.FakturPajak_ID
                            det.No_Faktur = i
                            det.CreatedDate = DateTime.Now
                            det.CreatedBy = user
                            det.IsDeleted = False
                            db.Tr_FakturPajakDetails.Add(det)
                        Next
                        db.SaveChanges()
                        result = "Success"
                        dbs.Commit()
                    Catch ex As Exception
                        dbs.Rollback()
                    Message = ex.Message
                    End Try
                End Using
                'Print(appHeader.ApplicationHeader_ID)
            End If
            Return Json(New With {Key .result = result, Key .message = Message}, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace