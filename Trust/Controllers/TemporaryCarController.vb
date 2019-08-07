Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Trust.Trust
Imports PagedList

Namespace Controllers
    Public Class TemporaryCarController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: TemporaryCar
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
            Dim Query = (From A In db.Tr_TemporaryCars
                         Group Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join Pros In db.V_ProspectCustDetails On B.Application_ID Equals Pros.Application_ID Into BPros = Group
                         From Pros In BPros.DefaultIfEmpty
                         Group Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals D.Vehicle_id Into AD = Group
                         From D In AD.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False) On D.Model_ID Equals E.Model_ID Into DE = Group
                         From E In DE.DefaultIfEmpty
                         Where A.IsDeleted = False
                         Select A.TemporaryCar_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Pros.CompanyGroup_Name, Pros.Company_Name, D.license_no, E.Type, A.CreatedDate, B.IsDelivery, B.IsInvoiced).
                         Select(Function(x) New Tr_TemporaryCar With {.TemporaryCar_ID = x.TemporaryCar_ID, .Contract_No = x.Contract_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                         .license_no = x.license_no, .Type = x.Type, .CreatedDate = x.CreatedDate, .IsDelivery = x.IsDelivery, .IsInvoiced = x.IsInvoiced})
            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.Contract_No.Contains(searchString) OrElse s.CompanyGroup_Name.Contains(searchString) OrElse s.Company_Name.Contains(searchString) OrElse s.license_no.Contains(searchString) OrElse s.Type.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Contract_No"
                    Query = Query.OrderBy(Function(s) s.Contract_No)
                Case "CompanyGroup_Name"
                    Query = Query.OrderBy(Function(s) s.CompanyGroup_Name)
                Case "Company_Name"
                    Query = Query.OrderBy(Function(s) s.Company_Name)
                Case "license_no"
                    Query = Query.OrderBy(Function(s) s.license_no)
                Case "Type"
                    Query = Query.OrderBy(Function(s) s.Type)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: TemporaryCar/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_TemporaryCars As Tr_TemporaryCars = Await db.Tr_TemporaryCars.FindAsync(id)
            If IsNothing(tr_TemporaryCars) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_TemporaryCars
                         Group Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join Pros In db.V_ProspectCustDetails On B.Application_ID Equals Pros.Application_ID Into BPros = Group
                         From Pros In BPros.DefaultIfEmpty
                         Group Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals D.Vehicle_id Into AD = Group
                         From D In AD.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False) On D.Model_ID Equals E.Model_ID Into DE = Group
                         From E In DE.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TemporaryCar_ID = id
                         Select A.TemporaryCar_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Pros.CompanyGroup_Name, Pros.Company_Name, D.license_no, E.Type, A.CreatedDate, B.IsDelivery, B.IsInvoiced).
                         Select(Function(x) New Tr_TemporaryCar With {.TemporaryCar_ID = x.TemporaryCar_ID, .Contract_No = x.Contract_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                         .license_no = x.license_no, .Type = x.Type, .CreatedDate = x.CreatedDate, .IsDelivery = x.IsDelivery, .IsInvoiced = x.IsInvoiced}).FirstOrDefault
            Return View(Query)
        End Function
        'untuk select vehicle
        Public Function GetVehicle(searchTerm As String, ID As Integer?) As JsonResult
            Dim model_ID As Integer? = (From A In db.Tr_ContractDetails
                                        Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                                        Where A.IsDeleted = False And B.IsVehicleExists = False And A.ContractDetail_ID = ID
                            ).Select(Function(x) x.B.Model_ID).FirstOrDefault

            'Dim vehicle = db.Ms_Vehicles.Where(Function(x) x.license_no.Contains(searchTerm) And x.Model_ID = model_ID)
            Dim vehicle = db.Ms_Vehicles.Where(Function(x) x.license_no.Contains(searchTerm))
            Dim data = (vehicle.OrderBy(Function(x) x.license_no).Select(Function(x) New With {.id = x.Vehicle_id, .text = x.license_no})).Take(5)
            Return Json(data, JsonRequestBehavior.AllowGet)
        End Function

        Function GetContraactDetail(ByVal ID As Integer?) As ActionResult
            Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
            Dim Query = From A In db.Tr_ContractDetails
                        Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                        Where A.IsDeleted = False And B.IsVehicleExists = False And A.IsDelivery = False And A.IsInvoiced = False And A.IsTemporaryCar = False And A.Contract_ID = ID
                        Select A.ContractDetail_ID, B.Type
            For Each row In Query
                list.Add(New SelectListItem With {.Text = Convert.ToString(row.Type), .Value = Convert.ToString(row.ContractDetail_ID)})
            Next
            Return Json(New SelectList(list, "Value", "Text", JsonRequestBehavior.AllowGet))
        End Function

        ' GET: TemporaryCar/Create
        Function Create() As ActionResult
            Dim ConDet = db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False And x.IsDelivery = False And x.IsTemporaryCar = False And x.IsInvoiced = False).
                Select(Function(x) x.Contract_ID).ToArray
            ViewBag.Contract_ID = New SelectList(db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And ConDet.Contains(x.Contract_ID)), "Contract_ID", "Contract_No")
            Dim nulleee As List(Of SelectListItem) = New List(Of SelectListItem)()
            ViewBag.ContractDetail_ID = New SelectList(nulleee)
            Return View()
        End Function

        ' POST: TemporaryCar/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="TemporaryCar_ID,Contract_ID,ContractDetail_ID,Vehicle_ID,Remark")> ByVal tr_TemporaryCars As Tr_TemporaryCar) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then

                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim tempcar = New Tr_TemporaryCars
                        tempcar.ContractDetail_ID = tr_TemporaryCars.ContractDetail_ID
                        tempcar.Vehicle_ID = tr_TemporaryCars.Vehicle_ID
                        tempcar.Remark = tr_TemporaryCars.Remark
                        tempcar.CreatedBy = user
                        tempcar.CreatedDate = DateTime.Now
                        tempcar.IsDeleted = False
                        db.Tr_TemporaryCars.Add(tempcar)
                        Dim conDetail = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = tr_TemporaryCars.ContractDetail_ID).FirstOrDefault
                        conDetail.IsTemporaryCar = True
                        db.SaveChanges()
                        'Input di history
                        Dim contractDetaiH = New Tr_ContractDetailHistorys
                        contractDetaiH.ID = tempcar.TemporaryCar_ID
                        contractDetaiH.Status = "Temporary Car"
                        contractDetaiH.Date = tempcar.CreatedDate
                        contractDetaiH.Vehicle_ID = tempcar.Vehicle_ID
                        contractDetaiH.ContractDetail_ID = tempcar.ContractDetail_ID
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

            Dim ConDet = db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False And x.IsDelivery = False And x.IsTemporaryCar = False And x.IsInvoiced = False).
                Select(Function(x) x.Contract_ID).ToArray
            ViewBag.Contract_ID = New SelectList(db.Tr_Contracts.Where(Function(x) x.IsDeleted = False And ConDet.Contains(x.Contract_ID)), "Contract_ID", "Contract_No", tr_TemporaryCars.Contract_ID)

            Dim Detail = From A In db.Tr_ContractDetails
                         Join B In db.V_ProspectCustDetails On A.Application_ID Equals B.Application_ID
                         Where A.IsDeleted = False And B.IsVehicleExists = False And A.IsDelivery = False And A.IsInvoiced = False And A.IsTemporaryCar = False And A.ContractDetail_ID = tr_TemporaryCars.ContractDetail_ID
                         Select A.ContractDetail_ID, B.Type

            ViewBag.ContractDetail_ID = New SelectList(Detail, "ContractDetail_ID", "Type", tr_TemporaryCars.ContractDetail_ID)
            Return View(tr_TemporaryCars)
        End Function

        ' GET: TemporaryCar/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            Dim user As Integer
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_TemporaryCars As Tr_TemporaryCars = Await db.Tr_TemporaryCars.FindAsync(id)
            If IsNothing(tr_TemporaryCars) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_TemporaryCars
                         Group Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join Pros In db.V_ProspectCustDetails On B.Application_ID Equals Pros.Application_ID Into BPros = Group
                         From Pros In BPros.DefaultIfEmpty
                         Group Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TemporaryCar_ID = id
                         Select A.TemporaryCar_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Pros.Type, A.ContractDetail_ID, A.Vehicle_ID, A.Remark).
                         Select(Function(x) New Tr_TemporaryCar With {.TemporaryCar_ID = x.TemporaryCar_ID, .Contract_No = x.Contract_No, .Type = x.Type,
                         .ContractDetail_ID = x.ContractDetail_ID, .Vehicle_ID = x.Vehicle_ID, .Remark = x.Remark}).FirstOrDefault

            ViewBag.Vehicle_ID = New SelectList(db.Ms_Vehicles, "Vehicle_id", "license_no", Query.Vehicle_ID)
            Return View(Query)
        End Function

        ' POST: TemporaryCar/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="TemporaryCar_ID,ContractDetail_ID,Contract_No,Type,Vehicle_ID,Remark")> ByVal tr_TemporaryCars As Tr_TemporaryCar) As ActionResult
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            If ModelState.IsValid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim tempcar = db.Tr_TemporaryCars.Where(Function(x) x.TemporaryCar_ID = tr_TemporaryCars.TemporaryCar_ID And x.IsDeleted = False).FirstOrDefault
                        tempcar.Vehicle_ID = tr_TemporaryCars.Vehicle_ID
                        tempcar.Remark = tr_TemporaryCars.Remark
                        tempcar.ModifiedBy = user
                        tempcar.ModifiedDate = DateTime.Now
                        'Input di history
                        Dim contractDetaiH = db.Tr_ContractDetailHistorys.Where(Function(x) x.Status = "Temporary Car" And x.ID = tr_TemporaryCars.TemporaryCar_ID And x.IsDeleted = False).FirstOrDefault
                        contractDetaiH.Vehicle_ID = tr_TemporaryCars.Vehicle_ID
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
            ViewBag.Vehicle_ID = New SelectList(db.Ms_Vehicles, "Vehicle_id", "license_no", tr_TemporaryCars.Vehicle_ID)
            Return View(tr_TemporaryCars)
        End Function

        ' GET: TemporaryCar/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tr_TemporaryCars As Tr_TemporaryCars = Await db.Tr_TemporaryCars.FindAsync(id)
            If IsNothing(tr_TemporaryCars) Then
                Return HttpNotFound()
            End If
            Dim Query = (From A In db.Tr_TemporaryCars
                         Group Join B In db.Tr_ContractDetails.Where(Function(x) x.IsDeleted = False) On A.ContractDetail_ID Equals B.ContractDetail_ID Into AB = Group
                         From B In AB.DefaultIfEmpty
                         Group Join Pros In db.V_ProspectCustDetails On B.Application_ID Equals Pros.Application_ID Into BPros = Group
                         From Pros In BPros.DefaultIfEmpty
                         Group Join C In db.Tr_Contracts.Where(Function(x) x.IsDeleted = False) On B.Contract_ID Equals C.Contract_ID Into BC = Group
                         From C In BC.DefaultIfEmpty
                         Group Join D In db.Ms_Vehicles.Where(Function(x) x.IsDeleted = False) On A.Vehicle_ID Equals D.Vehicle_id Into AD = Group
                         From D In AD.DefaultIfEmpty
                         Group Join E In db.Ms_Vehicle_Models.Where(Function(x) x.IsDeleted = False) On D.Model_ID Equals E.Model_ID Into DE = Group
                         From E In DE.DefaultIfEmpty
                         Where A.IsDeleted = False And A.TemporaryCar_ID = id
                         Select A.TemporaryCar_ID, C.Tr_ApprovalApps.Tr_ApplicationHeaders.Contract_No, Pros.CompanyGroup_Name, Pros.Company_Name, D.license_no, E.Type, A.CreatedDate, B.IsDelivery, B.IsInvoiced).
                         Select(Function(x) New Tr_TemporaryCar With {.TemporaryCar_ID = x.TemporaryCar_ID, .Contract_No = x.Contract_No, .CompanyGroup_Name = x.CompanyGroup_Name, .Company_Name = x.Company_Name,
                         .license_no = x.license_no, .Type = x.Type, .CreatedDate = x.CreatedDate, .IsDelivery = x.IsDelivery, .IsInvoiced = x.IsInvoiced}).FirstOrDefault

            Return View(Query)
        End Function

        ' POST: TemporaryCar/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim user As Integer
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
            Dim tr_TemporaryCars As Tr_TemporaryCars = Await db.Tr_TemporaryCars.FindAsync(id)
            tr_TemporaryCars.IsDeleted = True
            tr_TemporaryCars.ModifiedBy = user
            tr_TemporaryCars.ModifiedDate = DateTime.Now
            Dim conDetail = db.Tr_ContractDetails.Where(Function(x) x.ContractDetail_ID = tr_TemporaryCars.ContractDetail_ID).FirstOrDefault
            conDetail.IsTemporaryCar = False
            Dim ContractHistory = db.Tr_ContractDetailHistorys.Where(Function(x) x.ID = id And x.Status = "Temporary Car").FirstOrDefault
            ContractHistory.IsDeleted = True
            ContractHistory.ModifiedBy = user
            ContractHistory.ModifiedDate = DateTime.Now
            Await db.SaveChangesAsync()
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
