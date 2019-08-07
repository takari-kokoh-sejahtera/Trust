Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports LumenWorks.Framework.IO.Csv
Imports PagedList
Imports Trust

Namespace Controllers
    Public Class ModelController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Model
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
            Dim model = From s In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False) Select s
            If Not String.IsNullOrEmpty(searchString) Then
                model = model.Where(Function(s) s.Ms_Vehicle_Brands.Brand_Name.Contains(searchString) OrElse s.Type.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Brand_Name"
                    model = model.OrderBy(Function(s) s.Ms_Vehicle_Brands.Brand_Name)
                Case "Type"
                    model = model.OrderBy(Function(s) s.Type)
                Case Else
                    model = model.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(model.ToPagedList(pageNumber, pageSize))
        End Function

        Function DownloadCSV() As FileContentResult
            Dim csv = "Model_ID,Brand_Name,Type,OTR_Price,Normal_Disc,Year1,Year2,Year3,Year4,Year5,Description,IsKeur,Asset_Rating,IsTruck"
            Dim query = From A In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False)
                        Join B In db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False) On A.Brand_ID Equals B.Brand_ID
                        Select A.Model_ID, B.Brand_Name, A.Type, A.OTR_Price, A.Normal_Disc, A.Year1, A.Year2, A.Year3, A.Year4, A.Year5, A.Description, A.IsKeur, A.Asset_Rating, A.IsTruck
            For Each i In query
                csv = csv + Environment.NewLine
                csv = csv + i.Model_ID.ToString() + "," + i.Brand_Name.Replace(",", "") + "," + i.Type.Replace(",", "") + "," + i.OTR_Price.ToString() + "," + i.Normal_Disc.ToString() + "," + i.Year1.ToString() + "," + i.Year2.ToString() + "," + i.Year3.ToString() + "," + i.Year4.ToString() + "," + i.Year5.ToString() + "," + If(i.Description, "").Replace(",", "") + "," + i.IsKeur.ToString + "," + i.Asset_Rating.ToString() + "," + i.IsTruck.ToString()
            Next
            Return File(New System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "FormatUpload.csv")
        End Function

        Function UploadUpdateMaster() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function UploadUpdateMaster(uploaded As HttpPostedFileBase) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                If (uploaded IsNot Nothing And uploaded.ContentLength > 0) Then
                    If (uploaded.FileName.EndsWith(".csv")) Then
                        Dim stream = uploaded.InputStream
                        Dim csvTable = New DataTable()
                        Using csvReader = New CsvReader(New StreamReader(stream), True)
                            csvTable.Load(csvReader)
                        End Using
                        Dim message = ""
                        Dim validate = True
                        Dim import = (From DataRow In csvTable).
                        Select(Function(x) New Ms_Vehicle_Model_Import With {.Model_ID = If(x("Model_ID") IsNot DBNull.Value, Convert.ToInt64(x("Model_ID")), Nothing), .Brand_Name = If(x("Brand_Name") IsNot DBNull.Value, x("Brand_Name").ToString.Trim, Nothing), .Type = If(x("Type") IsNot DBNull.Value, x("Type").ToString.Trim, Nothing), .OTR_Price = If(x("OTR_Price") IsNot DBNull.Value, Convert.ToDecimal(x("OTR_Price")), Nothing),
                                   .Normal_Disc = If(x("Normal_Disc") IsNot DBNull.Value, Convert.ToDecimal(x("Normal_Disc")), Nothing), .Year1 = If(x("Year1") IsNot DBNull.Value, Convert.ToInt64(x("Year1")), Nothing), .Year2 = If(x("Year2") IsNot DBNull.Value, Convert.ToInt64(x("Year2")), Nothing), .Year3 = If(x("Year3") IsNot DBNull.Value, Convert.ToInt64(x("Year3")), Nothing), .Year4 = If(x("Year4") IsNot DBNull.Value, Convert.ToInt64(x("Year4")), Nothing), .Year5 = If(x("Year5") IsNot DBNull.Value, Convert.ToInt64(x("Year5")), Nothing),
                                   .Description = If(x("Description") IsNot DBNull.Value, x("Description").ToString.Trim, Nothing), .IsKeur = If(x("IsKeur") IsNot DBNull.Value, Convert.ToBoolean(x("IsKeur")), False), .Asset_Rating = If(x("Asset_Rating") IsNot DBNull.Value, Convert.ToInt64(x("Asset_Rating")), Nothing), .IsTruck = If(x("IsTruck") IsNot DBNull.Value, Convert.ToBoolean(x("IsTruck")), False)}).ToList
#Region "Validasi"
                        Dim assetRatingRange = {3, 4, 5}
                        Dim arrayBrand = db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Brand_Name).ToArray
                        Dim arrayType = db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.Type).ToArray
                        If import.Where(Function(x) Not assetRatingRange.Contains(x.Asset_Rating)).Any Then
                            message = "Assets Rating can only be 3, 4 and 5"
                            validate = False
                        ElseIf import.Where(Function(x) Not arrayBrand.Contains(x.Brand_Name) And x.Model_ID = 0).Any Then
                            message = "In new model, Brand name is wrong"
                            validate = False
                        ElseIf import.Where(Function(x) arrayType.Contains(x.Type) And x.Model_ID = 0).Any Then
                            message = "In new model, can't enter the same name"
                            validate = False
                        ElseIf import.Where(Function(x) x.IsKeur Is Nothing).Any Then
                            message = "IsKeur must be fill"
                            validate = False
                        End If

#End Region

                        If validate Then
                            'Update
                            For Each i In import.Where(Function(x) x.Model_ID <> 0)
                                Dim model = db.Ms_Vehicle_Models.Where(Function(x) x.Model_ID = i.Model_ID).FirstOrDefault
                                model.OTR_Price = i.OTR_Price
                                model.Normal_Disc = i.Normal_Disc
                                model.Year1 = i.Year1
                                model.Year2 = i.Year2
                                model.Year3 = i.Year3
                                model.Year4 = i.Year4
                                model.Year5 = i.Year5
                                model.Description = i.Description
                                model.IsKeur = i.IsKeur
                                model.IsTruck = i.IsTruck
                                model.Asset_Rating = i.Asset_Rating
                                model.ModifiedBy = user
                                model.ModifiedDate = DateTime.Now
                            Next
                            'New
                            For Each i In import.Where(Function(x) x.Model_ID = 0)
                                Dim brand_id = db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False And x.Brand_Name = i.Brand_Name).Select(Function(x) x.Brand_ID).FirstOrDefault
                                Dim modelNew As New Ms_Vehicle_Models
                                modelNew.Brand_ID = brand_id
                                modelNew.Type = i.Type
                                modelNew.OTR_Price = i.OTR_Price
                                modelNew.Normal_Disc = i.Normal_Disc
                                modelNew.Year1 = i.Year1
                                modelNew.Year2 = i.Year2
                                modelNew.Year3 = i.Year3
                                modelNew.Year4 = i.Year4
                                modelNew.Year5 = i.Year5
                                modelNew.IsKeur = i.IsKeur
                                modelNew.IsTruck = i.IsTruck
                                modelNew.Description = i.Description
                                modelNew.Asset_Rating = i.Asset_Rating
                                modelNew.Active = True
                                modelNew.CreatedBy = user
                                modelNew.CreatedDate = DateTime.Now
                                modelNew.IsDeleted = False
                                db.Ms_Vehicle_Models.Add(modelNew)
                            Next
                            db.SaveChanges()
                            Return RedirectToAction("Index")
                        Else
                            ViewBag.Messages = message
                            Return View()
                        End If

                    Else
                        ModelState.AddModelError("File", "This file format is not supported")
                        Return View(uploaded)
                    End If
                End If
            Else
                ModelState.AddModelError("File", "Please Upload Your file")
            End If
            Return View(uploaded)
        End Function

        ' GET: Model/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Models As Ms_Vehicle_Models = db.Ms_Vehicle_Models.Find(id)
            If IsNothing(ms_Vehicle_Models) Then
                Return HttpNotFound()
            End If
            Return View(ms_Vehicle_Models)
        End Function

        ' GET: Model/Create
        Function Create() As ActionResult
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name")
            ViewBag.Asset_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Asset_Rating), "Key", "Key")
            Return View()
        End Function

        ' POST: Model/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Model_ID,Brand_ID,Type,OTR_Price,OTR_PriceStr,Normal_Disc,Normal_DiscStr,Year1,Year2,Year3,Year4,Year5,Description,Asset_Rating,IsKeur,IsTruck,Active,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle_Model As Ms_Vehicle_Model) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_Vehicle_Models As New Ms_Vehicle_Models
                ms_Vehicle_Models.Brand_ID = ms_Vehicle_Model.Brand_ID
                ms_Vehicle_Models.Type = ms_Vehicle_Model.Type
                ms_Vehicle_Models.OTR_Price = ms_Vehicle_Model.OTR_Price
                ms_Vehicle_Models.Normal_Disc = ms_Vehicle_Model.Normal_Disc
                ms_Vehicle_Models.Year1 = ms_Vehicle_Model.Year1
                ms_Vehicle_Models.Year2 = ms_Vehicle_Model.Year2
                ms_Vehicle_Models.Year3 = ms_Vehicle_Model.Year3
                ms_Vehicle_Models.Year4 = ms_Vehicle_Model.Year4
                ms_Vehicle_Models.Year5 = ms_Vehicle_Model.Year5
                ms_Vehicle_Models.Description = ms_Vehicle_Model.Description
                ms_Vehicle_Models.Asset_Rating = ms_Vehicle_Model.Asset_Rating
                ms_Vehicle_Models.IsKeur = ms_Vehicle_Model.IsKeur
                ms_Vehicle_Models.IsTruck = ms_Vehicle_Model.IsTruck
                ms_Vehicle_Models.Active = ms_Vehicle_Model.Active
                ms_Vehicle_Models.CreatedBy = user
                ms_Vehicle_Models.CreatedDate = DateTime.Now
                ms_Vehicle_Models.IsDeleted = False
                db.Ms_Vehicle_Models.Add(ms_Vehicle_Models)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands, "Brand_ID", "Brand_Name", ms_Vehicle_Model.Brand_ID)
            ViewBag.Asset_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Asset_Rating), "Key", "Key", ms_Vehicle_Model.Asset_Rating)
            Return View(ms_Vehicle_Model)
        End Function

        ' GET: Model/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Models As Ms_Vehicle_Models = db.Ms_Vehicle_Models.Find(id)
            If IsNothing(ms_Vehicle_Models) Then
                Return HttpNotFound()
            End If
            Dim ms_Vehicle_Model As New Ms_Vehicle_Model
            ms_Vehicle_Model.Model_ID = id
            ms_Vehicle_Model.Brand_ID = ms_Vehicle_Models.Brand_ID
            ms_Vehicle_Model.Type = ms_Vehicle_Models.Type
            ms_Vehicle_Model.OTR_Price = ms_Vehicle_Models.OTR_Price
            ms_Vehicle_Model.Normal_Disc = ms_Vehicle_Models.Normal_Disc
            ms_Vehicle_Model.Year1 = ms_Vehicle_Models.Year1
            ms_Vehicle_Model.Year2 = ms_Vehicle_Models.Year2
            ms_Vehicle_Model.Year3 = ms_Vehicle_Models.Year3
            ms_Vehicle_Model.Year4 = ms_Vehicle_Models.Year4
            ms_Vehicle_Model.Year5 = ms_Vehicle_Models.Year5
            ms_Vehicle_Model.Description = ms_Vehicle_Models.Description
            ms_Vehicle_Model.IsKeur = ms_Vehicle_Models.IsKeur
            ms_Vehicle_Model.IsTruck = ms_Vehicle_Models.IsTruck
            ms_Vehicle_Model.Active = ms_Vehicle_Models.Active
            ms_Vehicle_Model.Asset_Rating = ms_Vehicle_Models.Asset_Rating
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands.Where(Function(x) x.IsDeleted = False), "Brand_ID", "Brand_Name", ms_Vehicle_Model.Brand_ID)
            ViewBag.Asset_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Asset_Rating), "Key", "Key", ms_Vehicle_Model.Asset_Rating)
            Return View(ms_Vehicle_Model)
        End Function

        ' POST: Model/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Model_ID,Brand_ID,Type,OTR_Price,Normal_Disc,OTR_PriceStr,Normal_DiscStr,Year1,Year2,Year3,Year4,Year5,Description,Asset_Rating,IsKeur,IsTruck,Active,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Vehicle_Models As Ms_Vehicle_Model) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim model = db.Ms_Vehicle_Models.FirstOrDefault(Function(p) (p.Model_ID = ms_Vehicle_Models.Model_ID))
                If (model Is Nothing) Then
                    Return HttpNotFound()
                End If
                model.Brand_ID = ms_Vehicle_Models.Brand_ID
                model.Type = ms_Vehicle_Models.Type
                model.OTR_Price = ms_Vehicle_Models.OTR_Price
                model.Normal_Disc = ms_Vehicle_Models.Normal_Disc
                model.Year1 = ms_Vehicle_Models.Year1
                model.Year2 = ms_Vehicle_Models.Year2
                model.Year3 = ms_Vehicle_Models.Year3
                model.Year4 = ms_Vehicle_Models.Year4
                model.Year5 = ms_Vehicle_Models.Year5
                model.Description = ms_Vehicle_Models.Description
                model.Asset_Rating = ms_Vehicle_Models.Asset_Rating
                model.IsKeur = ms_Vehicle_Models.IsKeur
                model.IsTruck = ms_Vehicle_Models.IsTruck
                model.Active = ms_Vehicle_Models.Active
                model.ModifiedBy = user
                model.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Brand_ID = New SelectList(db.Ms_Vehicle_Brands, "Brand_ID", "Brand_Name", ms_Vehicle_Models.Brand_ID)
            ViewBag.Asset_Rating = New SelectList(db.Ms_ProjRatingMatrixs.GroupBy(Function(x) x.Asset_Rating), "Key", "Key", ms_Vehicle_Models.Asset_Rating)
            Return View(ms_Vehicle_Models)
        End Function

        ' GET: Model/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Vehicle_Models As Ms_Vehicle_Models = db.Ms_Vehicle_Models.Find(id)
            If IsNothing(ms_Vehicle_Models) Then
                Return HttpNotFound()
            End If
            Return View(ms_Vehicle_Models)
        End Function

        ' POST: Model/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim model As Ms_Vehicle_Models = db.Ms_Vehicle_Models.Find(id)
            model.ModifiedBy = user
            model.ModifiedDate = DateTime.Now
            model.IsDeleted = True
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
