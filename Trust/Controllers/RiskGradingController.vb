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
    Public Class RiskGradingController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: RiskGrading
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
            Dim Query = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False).OrderByDescending(Function(x) x.CreatedDate).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).
                Select(Function(x) New Ms_RiskGrading With {.RiskGrading_ID = x.RiskGrading_ID, .Project_Rating = x.Project_Rating, .RiskGrading = x.RiskGrading,
                .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
                .ModifiedBy = x.Cn_Users1.User_Name})

            If Not String.IsNullOrEmpty(searchString) Then
                Query = Query.Where(Function(s) s.CreatedBy.Contains(searchString) OrElse s.ModifiedBy.Contains(searchString))
            End If
            Select Case sortOrder
                Case "CreatedBy"
                    Query = Query.OrderBy(Function(s) s.CreatedBy)
                Case "ModifiedBy"
                    Query = Query.OrderBy(Function(s) s.ModifiedBy)
                Case Else
                    Query = Query.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(Query.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: RiskGrading/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_RiskGrading = db.Ms_RiskGradings.Where(Function(x) x.RiskGrading_ID = id And x.IsDeleted = False).
                Select(Function(x) New Ms_RiskGrading With {.RiskGrading_ID = x.RiskGrading_ID, .Project_Rating = x.Project_Rating, .RiskGrading = x.RiskGrading}).FirstOrDefault
            If IsNothing(ms_RiskGrading) Then
                Return HttpNotFound()
            End If
            Return View(ms_RiskGrading)
        End Function

        ' GET: RiskGrading/Create
        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Return View()
        End Function

        ' POST: RiskGrading/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="RiskGrading_ID,Project_Rating,RiskGrading,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_RiskGradings As Ms_RiskGrading) As ActionResult
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim riskGrading As New Ms_RiskGradings
                riskGrading.Project_Rating = ms_RiskGradings.Project_Rating
                riskGrading.RiskGrading = ms_RiskGradings.RiskGrading
                riskGrading.CreatedBy = user
                riskGrading.CreatedDate = DateTime.Now
                riskGrading.IsDeleted = False
                db.Ms_RiskGradings.Add(riskGrading)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_RiskGradings)
        End Function

        ' GET: RiskGrading/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_RiskGradings = db.Ms_RiskGradings.Where(Function(x) x.RiskGrading_ID = id).
                Select(Function(x) New Ms_RiskGrading With {.RiskGrading_ID = x.RiskGrading_ID, .Project_Rating = x.Project_Rating, .RiskGrading = x.RiskGrading}).FirstOrDefault
            If IsNothing(ms_RiskGradings) Then
                Return HttpNotFound()
            End If
            Return View(ms_RiskGradings)
        End Function

        ' POST: RiskGrading/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="RiskGrading_ID,Project_Rating,RiskGrading,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_RiskGradings As Ms_RiskGrading) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim riskGrading = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.RiskGrading_ID = ms_RiskGradings.RiskGrading_ID).FirstOrDefault
                riskGrading.Project_Rating = ms_RiskGradings.Project_Rating
                riskGrading.RiskGrading = ms_RiskGradings.RiskGrading
                riskGrading.ModifiedBy = user
                riskGrading.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_RiskGradings)
        End Function

        ' GET: RiskGrading/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_RiskGradings = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.RiskGrading_ID = id).
                Select(Function(x) New Ms_RiskGrading With {.RiskGrading_ID = x.RiskGrading_ID, .Project_Rating = x.Project_Rating, .RiskGrading = x.RiskGrading}).FirstOrDefault
            If IsNothing(ms_RiskGradings) Then
                Return HttpNotFound()
            End If
            Return View(ms_RiskGradings)
        End Function

        ' POST: RiskGrading/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim ms_RiskGradings = db.Ms_RiskGradings.Where(Function(x) x.IsDeleted = False And x.RiskGrading_ID = id).FirstOrDefault
            ms_RiskGradings.IsDeleted = True
            ms_RiskGradings.ModifiedBy = user
            ms_RiskGradings.ModifiedDate = DateTime.Now
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
