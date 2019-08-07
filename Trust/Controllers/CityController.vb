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
    Public Class CityController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities


        Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?, pageSize As Integer?) As ActionResult
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
            Dim city = From s In db.Ms_Citys.Where(Function(x) x.isDeleted = False) Select s
            If Not String.IsNullOrEmpty(searchString) Then
                city = city.Where(Function(s) s.City.Contains(searchString) OrElse s.Provinsi.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Provinsi"
                    city = city.OrderBy(Function(s) s.Provinsi)
                Case "City"
                    city = city.OrderBy(Function(s) s.City)
                Case Else
                    city = city.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(city.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: City/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_City As Ms_Citys = db.Ms_Citys.Find(id)
            If IsNothing(ms_City) Then
                Return HttpNotFound()
            End If
            Return View(ms_City)
        End Function

        ' GET: City/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            Dim Remark As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jawa Ada Cabang",
                    .Value = "Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Jawa Tidak Ada Cabang",
                    .Value = "Jawa Tidak Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Ada Cabang",
                    .Value = "Luar Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Tidak Ada Cabang",
                    .Value = "Luar Jawa Tidak Ada Cabang"
                }
            }
            ViewBag.Remark = New SelectList(Remark, "Value", "Text")

            Return View()
        End Function

        ' POST: City/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="CIty_ID,City,Provinsi,Expedition_Cost,Expedition_CostStr,Remark,Kode_Plat,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,isDeleted")> ByVal ms_City As Ms_City) As ActionResult
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_Citys As New Ms_Citys
                ms_Citys.City = ms_City.City
                ms_Citys.Provinsi = ms_City.Provinsi
                ms_Citys.Expedition_Cost = ms_City.Expedition_Cost
                ms_Citys.Kode_Plat = ms_City.Kode_Plat
                ms_Citys.Remark = ms_City.Remark
                ms_Citys.CreatedBy = user
                ms_Citys.CreatedDate = DateTime.Now
                ms_Citys.isDeleted = False
                db.Ms_Citys.Add(ms_Citys)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_City)
        End Function

        ' GET: City/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Citys As Ms_Citys = db.Ms_Citys.Find(id)
            Dim ms_City As New Ms_City
            If IsNothing(ms_City) Then
                Return HttpNotFound()
            End If
            ms_City.CIty_ID = ms_Citys.CIty_ID
            ms_City.City = ms_Citys.City
            ms_City.Provinsi = ms_Citys.Provinsi
            ms_City.Expedition_Cost = ms_Citys.Expedition_Cost
            ms_City.Kode_Plat = ms_Citys.Kode_Plat
            ms_City.Remark = ms_Citys.Remark
            Dim Remark As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jawa Ada Cabang",
                    .Value = "Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Jawa Tidak Ada Cabang",
                    .Value = "Jawa Tidak Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Ada Cabang",
                    .Value = "Luar Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Tidak Ada Cabang",
                    .Value = "Luar Jawa Tidak Ada Cabang"
                }
            }
            ViewBag.Remark = New SelectList(Remark, "Value", "Text", ms_Citys.Remark)
            Return View(ms_City)
        End Function

        ' POST: City/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="CIty_ID,City,Provinsi,Expedition_Cost,Expedition_CostStr,Remark,Kode_Plat,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,isDeleted")> ByVal ms_City As Ms_City) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim city = db.Ms_Citys.FirstOrDefault(Function(p) (p.CIty_ID = ms_City.CIty_ID))
                If (city Is Nothing) Then
                    Return HttpNotFound()
                End If
                city.City = ms_City.City
                city.Provinsi = ms_City.Provinsi
                city.Expedition_Cost = ms_City.Expedition_Cost
                city.Kode_Plat = ms_City.Kode_Plat
                city.Remark = ms_City.Remark
                city.ModifiedBy = user
                city.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Dim Remark As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Jawa Ada Cabang",
                    .Value = "Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Jawa Tidak Ada Cabang",
                    .Value = "Jawa Tidak Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Ada Cabang",
                    .Value = "Luar Jawa Ada Cabang"
                },
                New SelectListItem With {
                    .Text = "Luar Jawa Tidak Ada Cabang",
                    .Value = "Luar Jawa Tidak Ada Cabang"
                }
            }
            ViewBag.Remark = New SelectList(Remark, "Value", "Text", ms_City.Remark)
            Return View(ms_City)
        End Function

        ' GET: City/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_City As Ms_Citys = db.Ms_Citys.Find(id)
            If IsNothing(ms_City) Then
                Return HttpNotFound()
            End If
            Return View(ms_City)
        End Function

        ' POST: City/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim ms_City As Ms_Citys = db.Ms_Citys.Find(id)
            ms_City.ModifiedBy = user
            ms_City.ModifiedDate = DateTime.Now
            ms_City.isDeleted = True
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
