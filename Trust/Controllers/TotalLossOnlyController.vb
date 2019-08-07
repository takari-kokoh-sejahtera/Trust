Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Trust
Imports PagedList

Namespace Controllers
    Public Class TotalLossOnlyController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: TotalLossOnly
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
            Dim Query = (From A In db.Tr_TotalLossOnlys
                         Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID
                         Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On B.Vehicle_ID Equals D.Vehicle_id Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals E.Vehicle_id Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Group Join F In db.Cn_Users.Where(Function(x) x.IsDeleted = False) On A.CreatedBy Equals F.User_ID Into AF = Group
                         From F In AF.DefaultIfEmpty
                         Where A.IsDeleted = False
                         Order By A.CreatedDate Descending
                         Select A.TotalLossOnly_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Fromlicense_no = D.license_no, FromTmp_Plat = D.Tmp_Plat, Tolicense_no = E.license_no, ToTmp_Plat = E.Tmp_Plat, A.Remark, A.Date, A.CreatedDate, CreatedBy = F.User_Name, A.IsEdited).
                         Select(Function(x) New Tr_TotalLossOnly With {.TotalLossOnly_ID = x.TotalLossOnly_ID, .Contract_No = x.Contract_No,
                         .Fromlicense_no = If(x.Fromlicense_no, x.FromTmp_Plat), .Tolicense_no = If(x.Tolicense_no, x.ToTmp_Plat), .Remark = x.Remark, .Date = x.Date,
                         .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy, .IsEdited = x.IsEdited})

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.Fromlicense_no.Contains(searchString) OrElse s.Tolicense_no.Contains(searchString) OrElse s.Remark.Contains(searchString) OrElse s.CreatedBy.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "Fromlicense_no"
                    Query = Query.OrderBy(Function(s) s.Fromlicense_no)
                Case "Tolicense_no"
                    Query = Query.OrderBy(Function(s) s.Tolicense_no)
                Case "Remark"
                    Query = Query.OrderBy(Function(s) s.Remark)
                Case "CreatedBy"
                    Query = Query.OrderBy(Function(s) s.CreatedBy)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: TotalLossOnly/Details/5
        Function Details(ByVal id As Integer?) As ActionResult

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim Query = (From A In db.Tr_TotalLossOnlys
                         Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID
                         Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On B.Vehicle_ID Equals D.Vehicle_id Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals E.Vehicle_id Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Group Join F In db.Cn_Users.Where(Function(x) x.IsDeleted = False) On A.CreatedBy Equals F.User_ID Into AF = Group
                         From F In AF.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TotalLossOnly_ID = id
                         Order By A.CreatedDate Descending
                         Select A.TotalLossOnly_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Fromlicense_no = D.license_no, FromTmp_Plat = D.Tmp_Plat, Tolicense_no = E.license_no, ToTmp_Plat = E.Tmp_Plat, A.Remark, A.Date, A.CreatedDate, CreatedBy = F.User_Name).
                         Select(Function(x) New Tr_TotalLossOnly With {.TotalLossOnly_ID = x.TotalLossOnly_ID, .Contract_No = x.Contract_No,
                         .Fromlicense_no = If(x.Fromlicense_no, x.FromTmp_Plat), .Tolicense_no = If(x.Tolicense_no, x.ToTmp_Plat), .Remark = x.Remark, .Date = x.Date,
                         .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy}).FirstOrDefault

            If IsNothing(Query) Then
                Return HttpNotFound()
            End If

            Return View(Query)
        End Function
        Function GetContraactDetail(ByVal ID As Integer?) As ActionResult
            Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
            Dim Query = (From A In db.Tr_ContractDetails
                         Join B In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals B.Vehicle_id
                         Where A.IsDeleted = False And A.IsDelivery = True And A.IsInvoiced = True And A.IsTotalLossOnly = False And A.Contract_ID = ID
                         Select A.ContractDetail_ID, B.license_no, B.Tmp_Plat).
                         Select(Function(x) New Tr_ContractDetail With {.ContractDetail_ID = x.ContractDetail_ID, .license_no = If(x.license_no, x.Tmp_Plat)})

            For Each row In Query
                list.Add(New SelectListItem With {.Text = Convert.ToString(row.license_no), .Value = Convert.ToString(row.ContractDetail_ID)})
            Next
            Return Json(New SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet))
        End Function
        ' GET: TotalLossOnly/Create
        Function Create() As ActionResult
            Dim ConDet = db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False And x.IsDelivery = True And x.IsInvoiced = True And x.IsTotalLossOnly = False).
                Select(Function(x) x.Contract_ID).ToArray
            ViewBag.Contract_ID = New SelectList(db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And ConDet.Contains(x.Contract_ID)), "Contract_ID", "Contract_No")
            Dim nulleee As List(Of SelectListItem) = New List(Of SelectListItem)()
            ViewBag.ContractDetail_ID = New SelectList(nulleee)
            Return View()
        End Function

        ' POST: TotalLossOnly/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="TotalLossOnly_ID,Contract_ID,ContractDetail_ID,Vehicle_ID,Vehicle_ID1,Remark,Date,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_TotalLossOnlys As Tr_TotalLossOnly) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim tlo = New Tr_TotalLossOnlys
                        tlo.ContractDetail_ID = tr_TotalLossOnlys.ContractDetail_ID
                        tlo.Vehicle_ID = tr_TotalLossOnlys.Vehicle_ID
                        tlo.Remark = tr_TotalLossOnlys.Remark
                        tlo.Date = tr_TotalLossOnlys.Date
                        tlo.CreatedBy = user
                        tlo.CreatedDate = DateTime.Now
                        tlo.IsDeleted = False
                        tlo.IsEdited = True
                        db.Tr_TotalLossOnlys.Add(tlo)
                        Dim conDetail = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = tr_TotalLossOnlys.ContractDetail_ID).FirstOrDefault
                        conDetail.IsTotalLossOnly = True
                        db.SaveChanges()
                        'Input di history
                        Dim contractDetaiH = New Tr_ContractDetailHistorys
                        contractDetaiH.ID = tlo.TotalLossOnly_ID
                        contractDetaiH.Status = "TotalLossOnly"
                        contractDetaiH.Date = tlo.Date
                        contractDetaiH.Vehicle_ID = tlo.Vehicle_ID
                        contractDetaiH.ContractDetail_ID = tlo.ContractDetail_ID
                        contractDetaiH.CreatedBy = user
                        contractDetaiH.CreatedDate = DateTime.Now
                        contractDetaiH.IsDeleted = False
                        db.Tr_ContractDetailHistorys.Add(contractDetaiH)
                        db.SaveChanges()
                        dbs.Commit()

                        Return RedirectToAction("Index")
                    Catch ex As Exception
                        dbs.Rollback()
                    End Try
                End Using
            End If
            Dim ConDet = db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False And x.IsDelivery = True And x.IsInvoiced = True And x.IsTotalLossOnly = False).
                Select(Function(x) x.Contract_ID).ToArray
            ViewBag.Contract_ID = New SelectList(db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And ConDet.Contains(x.Contract_ID)), "Contract_ID", "Contract_No", tr_TotalLossOnlys.Contract_ID)
            Dim Query = From A In db.Tr_ContractDetails
                        Join B In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals B.Vehicle_id
                        Where A.IsDeleted = False And A.IsDelivery = True And A.IsInvoiced = True And A.IsTotalLossOnly = False And A.Contract_ID = tr_TotalLossOnlys.Contract_ID
                        Select A.ContractDetail_ID, B.license_no
            ViewBag.ContraactDetail = New SelectList(Query.ToList, "ContractDetail_ID", "license_no", tr_TotalLossOnlys.ContractDetail_ID)
            Return View(tr_TotalLossOnlys)
        End Function

        ' GET: TotalLossOnly/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_TotalLossOnlys As Tr_TotalLossOnlys = Await db.Tr_TotalLossOnlys.FindAsync(id)
            If IsNothing(tr_TotalLossOnlys) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_TotalLossOnlys
                         Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID
                         Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On B.Vehicle_ID Equals D.Vehicle_id Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals E.Vehicle_id Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Group Join F In db.Cn_Users.Where(Function(x) x.IsDeleted = False) On A.CreatedBy Equals F.User_ID Into AF = Group
                         From F In AF.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TotalLossOnly_ID = id
                         Order By A.CreatedDate Descending
                         Select A.TotalLossOnly_ID, A.ContractDetail_ID, C.Contract_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Fromlicense_no = D.license_no, FromTmp_Plat = D.Tmp_Plat, Tolicense_no = E.license_no, ToTmp_Plat = E.Tmp_Plat, A.Remark, A.Date).
                         Select(Function(x) New Tr_TotalLossOnly With {.TotalLossOnly_ID = x.TotalLossOnly_ID, .ContractDetail_ID = x.ContractDetail_ID, .Contract_No = x.Contract_No, .Contract_ID = x.Contract_ID,
                         .Fromlicense_no = If(x.Fromlicense_no, x.FromTmp_Plat), .Tolicense_no = If(x.Tolicense_no, x.ToTmp_Plat), .Remark = x.Remark, .Date = x.Date}).FirstOrDefault
            Return View(Query)
        End Function

        ' POST: TotalLossOnly/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="TotalLossOnly_ID,Contract_No,Contract_ID,Fromlicense_no,Tolicense_no,ContractDetail_ID,Vehicle_ID,Remark,Date,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal tr_TotalLossOnlys As Tr_TotalLossOnly) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim tlo = db.Tr_TotalLossOnlys.Where(Function(x) x.TotalLossOnly_ID = tr_TotalLossOnlys.TotalLossOnly_ID And x.IsDeleted = False).FirstOrDefault
                        tlo.Vehicle_ID = tr_TotalLossOnlys.Vehicle_ID
                        tlo.Remark = tr_TotalLossOnlys.Remark
                        tlo.Date = tr_TotalLossOnlys.Date
                        tlo.ModifiedBy = user
                        tlo.ModifiedDate = DateTime.Now
                        'Input di history
                        Dim contractDetaiH = db.Tr_ContractDetailHistorys.Where(Function(x) x.IsDeleted = False And x.ID = tr_TotalLossOnlys.TotalLossOnly_ID And x.Status = "TotalLossOnly" And x.ContractDetail_ID = tr_TotalLossOnlys.ContractDetail_ID).FirstOrDefault
                        contractDetaiH.Date = tlo.Date
                        contractDetaiH.Vehicle_ID = tlo.Vehicle_ID
                        contractDetaiH.ModifiedBy = user
                        contractDetaiH.ModifiedDate = DateTime.Now
                        db.SaveChanges()
                        dbs.Commit()

                        Return RedirectToAction("Index")
                    Catch ex As Exception
                        dbs.Rollback()
                    End Try
                End Using
            End If
            Return View(tr_TotalLossOnlys)
        End Function

        ' GET: TotalLossOnly/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Query = (From A In db.Tr_TotalLossOnlys
                         Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID
                         Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On B.Vehicle_ID Equals D.Vehicle_id Into DB = Group
                         From D In DB.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals E.Vehicle_id Into AE = Group
                         From E In AE.DefaultIfEmpty
                         Group Join F In db.Cn_Users.Where(Function(x) x.IsDeleted = False) On A.CreatedBy Equals F.User_ID Into AF = Group
                         From F In AF.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TotalLossOnly_ID = id
                         Order By A.CreatedDate Descending
                         Select A.TotalLossOnly_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Fromlicense_no = D.license_no, FromTmp_Plat = D.Tmp_Plat, Tolicense_no = E.license_no, ToTmp_Plat = E.Tmp_Plat, A.Remark, A.Date, A.CreatedDate, CreatedBy = F.User_Name).
                         Select(Function(x) New Tr_TotalLossOnly With {.TotalLossOnly_ID = x.TotalLossOnly_ID, .Contract_No = x.Contract_No,
                         .Fromlicense_no = If(x.Fromlicense_no, x.FromTmp_Plat), .Tolicense_no = If(x.Tolicense_no, x.ToTmp_Plat), .Remark = x.Remark, .Date = x.Date,
                         .CreatedDate = x.CreatedDate, .CreatedBy = x.CreatedBy}).FirstOrDefault
            If IsNothing(Query) Then
                Return HttpNotFound()
            End If
            Return View(Query)
        End Function

        ' POST: TotalLossOnly/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Using dbs = db.Database.BeginTransaction
                Try
                    Dim tlo = db.Tr_TotalLossOnlys.Where(Function(x) x.TotalLossOnly_ID = id And x.IsDeleted = False).FirstOrDefault
                    tlo.ModifiedBy = user
                    tlo.ModifiedDate = DateTime.Now
                    tlo.IsDeleted = True
                    Dim conDetail = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = tlo.ContractDetail_ID).FirstOrDefault
                    conDetail.IsTotalLossOnly = False
                    'delete di history
                    Dim contractDetaiH = db.Tr_ContractDetailHistorys.Where(Function(x) x.IsDeleted = False And x.ID = id And x.Status = "TotalLossOnly" And x.ContractDetail_ID = tlo.ContractDetail_ID).FirstOrDefault
                    contractDetaiH.ModifiedBy = user
                    contractDetaiH.ModifiedDate = DateTime.Now
                    contractDetaiH.IsDeleted = True
                    db.SaveChanges()
                    dbs.Commit()

                    Return RedirectToAction("Index")
                Catch ex As Exception
                    dbs.Rollback()
                End Try
            End Using
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
