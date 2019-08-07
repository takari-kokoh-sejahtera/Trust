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
    Public Class CostOfFundController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: CostOfFund
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
            Dim Query = db.Ms_CostOfFunds.OrderByDescending(Function(x) x.CreatedDate).Include(Function(m) m.Cn_Users).Include(Function(m) m.Cn_Users1).
                Select(Function(x) New Ms_CostOfFund With {.CostOfFund_ID = x.CostOfFund_ID, .Year1 = x.Year1, .Year2 = x.Year2,
                .Year3 = x.Year3, .Year4 = x.Year4, .Year5 = x.Year5, .Year6 = x.Year6, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
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

        ' GET: CostOfFund/Create
        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            Dim cstoffund = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).
                Select(Function(x) New Ms_CostOfFund With {.Year1 = x.Year1, .Year2 = x.Year2, .Year3 = x.Year3, .Year4 = x.Year4, .Year5 = x.Year5, .Year6 = x.Year6}).FirstOrDefault
            Return View(cstoffund)
        End Function

        ' POST: CostOfFund/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="CostOfFund_ID,Year1,Year2,Year3,Year4,Year5,Year6,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_CostOfFunds As Ms_CostOfFund) As Task(Of ActionResult)
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim deletein = db.Ms_CostOfFunds.Where(Function(x) x.IsDeleted = False).ToList
                For Each i In deletein
                    i.IsDeleted = True
                Next
                Dim costoffund As New Ms_CostOfFunds
                costoffund.Year1 = ms_CostOfFunds.Year1
                costoffund.Year2 = ms_CostOfFunds.Year2
                costoffund.Year3 = ms_CostOfFunds.Year3
                costoffund.Year4 = ms_CostOfFunds.Year4
                costoffund.Year5 = ms_CostOfFunds.Year5
                costoffund.Year6 = ms_CostOfFunds.Year6
                costoffund.CreatedBy = user
                costoffund.CreatedDate = DateTime.Now
                costoffund.IsDeleted = False
                db.Ms_CostOfFunds.Add(costoffund)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(ms_CostOfFunds)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
