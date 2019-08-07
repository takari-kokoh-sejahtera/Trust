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
    Public Class ProspectCategoryController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: ProspectCategory
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
            Dim category = From s In db.Ms_ProspectCategorys.Where(Function(x) x.IsDeleted = False)
                           Select New Ms_ProspectCategory With {.ProspectCategory_ID = s.ProspectCategory_ID, .ProspectCategory = s.ProspectCategory, .CreatedDate = s.CreatedDate, .CreatedBy = s.Cn_Users.User_Name, .ModifiedDate = s.ModifiedDate, .ModifiedBy = s.Cn_Users1.User_Name}
            If Not String.IsNullOrEmpty(searchString) Then
                category = category.Where(Function(s) s.ProspectCategory.Contains(searchString) OrElse s.CreatedBy.Contains(searchString) OrElse s.ModifiedBy.Contains(searchString))
            End If
            Select Case sortOrder
                Case "ProspectCategory"
                    category = category.OrderBy(Function(s) s.ProspectCategory)
                Case "CreatedBy"
                    category = category.OrderBy(Function(s) s.CreatedBy)
                Case "ModifiedBy"
                    category = category.OrderBy(Function(s) s.ModifiedBy)
                Case Else
                    category = category.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(category.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ProspectCategory/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_ProspectCategorys = db.Ms_ProspectCategorys.Where(Function(x) x.ProspectCategory_ID = id).
            Select(Function(x) New Ms_ProspectCategory With {.ProspectCategory_ID = x.ProspectCategory_ID, .ProspectCategory = x.ProspectCategory,
            .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_ProspectCategorys) Then
                Return HttpNotFound()
            End If
            Return View(ms_ProspectCategorys)
        End Function

        ' GET: ProspectCategory/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ProspectCategory/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ProspectCategory_ID,ProspectCategory")> ByVal ms_ProspectCategory As Ms_ProspectCategory) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim Ms_ProspectCategorys = New Ms_ProspectCategorys
                Ms_ProspectCategorys.ProspectCategory = ms_ProspectCategory.ProspectCategory
                Ms_ProspectCategorys.CreatedBy = user
                Ms_ProspectCategorys.CreatedDate = DateTime.Now
                Ms_ProspectCategorys.IsDeleted = False
                db.Ms_ProspectCategorys.Add(Ms_ProspectCategorys)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_ProspectCategory)
        End Function

        ' GET: ProspectCategory/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_ProspectCategory = db.Ms_ProspectCategorys.Where(Function(x) x.ProspectCategory_ID = id).
            Select(Function(x) New Ms_ProspectCategory With {.ProspectCategory_ID = x.ProspectCategory_ID, .ProspectCategory = x.ProspectCategory,
            .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_ProspectCategory) Then
                Return HttpNotFound()
            End If
            Return View(ms_ProspectCategory)
        End Function

        ' POST: ProspectCategory/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ProspectCategory_ID,ProspectCategory")> ByVal ms_ProspectCategory As Ms_ProspectCategorys) As ActionResult
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim ms_ProspectCategorys = db.Ms_ProspectCategorys.Where(Function(x) x.ProspectCategory_ID = ms_ProspectCategory.ProspectCategory_ID).FirstOrDefault
                ms_ProspectCategorys.ProspectCategory = ms_ProspectCategory.ProspectCategory
                ms_ProspectCategorys.ModifiedBy = user
                ms_ProspectCategorys.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_ProspectCategory)
        End Function

        ' GET: ProspectCategory/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_ProspectCategory = db.Ms_ProspectCategorys.Where(Function(x) x.ProspectCategory_ID = id).
            Select(Function(x) New Ms_ProspectCategory With {.ProspectCategory_ID = x.ProspectCategory_ID, .ProspectCategory = x.ProspectCategory,
            .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_ProspectCategory) Then
                Return HttpNotFound()
            End If
            Return View(ms_ProspectCategory)
        End Function

        ' POST: ProspectCategory/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim ms_ProspectCategorys = db.Ms_ProspectCategorys.Where(Function(x) x.ProspectCategory_ID = id).FirstOrDefault
            ms_ProspectCategorys.ModifiedBy = user
            ms_ProspectCategorys.ModifiedDate = DateTime.Now
            ms_ProspectCategorys.IsDeleted = True
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
