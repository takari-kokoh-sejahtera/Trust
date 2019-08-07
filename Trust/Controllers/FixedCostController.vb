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
    Public Class FixedCostController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: FixedCost
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
            Dim Query = db.Ms_FixedCosts.OrderByDescending(Function(x) x.CreatedDate).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).
                Select(Function(x) New Ms_FixedCost With {.FixedCost_ID = x.FixedCost_ID, .STNK_Percent = x.STNK_Percent, .Overhead_Percent = x.Overhead_Percent,
                .Assurance_Percent = x.Assurance_Percent, .OJK = x.OJK, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
                .ModifiedBy = x.Cn_Users1.User_Name, .IsDeleted = Not x.IsDeleted})

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

        ' GET: FixedCost/Create
        Function Create() As ActionResult
            Dim fixedCosts = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).FirstOrDefault
            Dim fixedCost As New Ms_FixedCost
            fixedCost.STNK_Percent = fixedCosts.STNK_Percent
            fixedCost.Overhead_Percent = fixedCosts.Overhead_Percent
            fixedCost.Assurance_Percent = fixedCosts.Assurance_Percent
            fixedCost.OJK = fixedCosts.OJK
            Return View(fixedCost)
        End Function

        ' POST: FixedCost/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="FixedCost_ID,STNK_Percent,Overhead_Percent,Assurance_Percent,OJK")> ByVal ms_FixedCosts As Ms_FixedCost) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim deletein = db.Ms_FixedCosts.Where(Function(x) x.IsDeleted = False).ToList
                For Each i In deletein
                    i.IsDeleted = True
                Next
                Dim fixecdCost As New Ms_FixedCosts
                fixecdCost.STNK_Percent = ms_FixedCosts.STNK_Percent
                fixecdCost.Overhead_Percent = ms_FixedCosts.Overhead_Percent
                fixecdCost.Assurance_Percent = ms_FixedCosts.Assurance_Percent
                fixecdCost.OJK = ms_FixedCosts.OJK
                fixecdCost.CreatedBy = user
                fixecdCost.CreatedDate = DateTime.Now
                fixecdCost.IsDeleted = False
                db.Ms_FixedCosts.Add(fixecdCost)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_FixedCosts)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
