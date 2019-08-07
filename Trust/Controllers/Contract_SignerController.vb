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
    Public Class Contract_SignerController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Contract_Signer
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
            Dim signer = db.Ms_Contract_Signers.Where(Function(x) x.IsDeleted = False).
                Select(Function(x) New Ms_Contract_Signer With {.Signer_ID = x.Signer_ID, .Name = x.Name, .Title_Ind = x.Title_Ind, .Title_Eng = x.Title_Eng,
                .Sex = x.Sex, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                signer = signer.Where(Function(s) s.Name.Contains(searchString) OrElse s.Title_Ind.Contains(searchString) OrElse s.Title_Eng.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Name"
                    signer = signer.OrderBy(Function(s) s.Name)
                Case "Title_Ind"
                    signer = signer.OrderBy(Function(s) s.Title_Ind)
                Case "Title_Eng"
                    signer = signer.OrderBy(Function(s) s.Title_Eng)
                Case Else
                    signer = signer.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(signer.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Contract_Signer/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Contract_Signers = db.Ms_Contract_Signers.Where(Function(x) x.IsDeleted = False).
                Select(Function(x) New Ms_Contract_Signer With {.Signer_ID = x.Signer_ID, .Name = x.Name, .Title_Ind = x.Title_Ind, .Title_Eng = x.Title_Eng,
                .Sex = x.Sex, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            If IsNothing(ms_Contract_Signers) Then
                Return HttpNotFound()
            End If
            Return View(ms_Contract_Signers)
        End Function

        ' GET: Contract_Signer/Create
        Function Create() As ActionResult
            Dim sex As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Man",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Woman",
                    .Value = False
                }
            }
            ViewBag.Sex = New SelectList(sex, "Value", "Text")
            Return View()
        End Function

        ' POST: Contract_Signer/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Signer_ID,Name,Title_Ind,Title_Eng,Sex,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Contract_Signer As Ms_Contract_Signer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim ms_Contract_Signers As New Ms_Contract_Signers
                ms_Contract_Signers.Name = ms_Contract_Signer.Name
                ms_Contract_Signers.Title_Ind = ms_Contract_Signer.Title_Ind
                ms_Contract_Signers.Title_Eng = ms_Contract_Signer.Title_Eng
                ms_Contract_Signers.Sex = ms_Contract_Signer.Sex
                ms_Contract_Signers.CreatedBy = user
                ms_Contract_Signers.CreatedDate = DateTime.Now
                ms_Contract_Signers.IsDeleted = False
                db.Ms_Contract_Signers.Add(ms_Contract_Signers)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Dim sex As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Man",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Woman",
                    .Value = False
                }
            }
            ViewBag.Sex = New SelectList(sex, "Value", "Text", ms_Contract_Signer.Sex)
            Return View(ms_Contract_Signer)
        End Function

        ' GET: Contract_Signer/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Contract_Signer = db.Ms_Contract_Signers.Where(Function(x) x.Signer_ID = id And x.IsDeleted = False).
                Select(Function(x) New Ms_Contract_Signer With {.Signer_ID = x.Signer_ID, .Name = x.Name, .Title_Ind = x.Title_Ind, .Title_Eng = x.Title_Eng,
                .Sex = x.Sex, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_Contract_Signer) Then
                Return HttpNotFound()
            End If
            Dim sex As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Man",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Woman",
                    .Value = False
                }
            }
            ViewBag.Sex = New SelectList(sex, "Value", "Text", ms_Contract_Signer.Sex)
            Return View(ms_Contract_Signer)
        End Function

        ' POST: Contract_Signer/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Signer_ID,Name,Title_Ind,Title_Eng,Sex,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal ms_Contract_Signer As Ms_Contract_Signer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            If ModelState.IsValid Then
                Dim ms_Contract_Signers = db.Ms_Contract_Signers.Where(Function(x) x.Signer_ID = ms_Contract_Signer.Signer_ID And x.IsDeleted = False).FirstOrDefault
                If IsNothing(ms_Contract_Signers) Then
                    Return HttpNotFound()
                End If
                ms_Contract_Signers.Name = ms_Contract_Signer.Name
                ms_Contract_Signers.Title_Ind = ms_Contract_Signer.Title_Ind
                ms_Contract_Signers.Title_Eng = ms_Contract_Signer.Title_Eng
                ms_Contract_Signers.Sex = ms_Contract_Signer.Sex
                ms_Contract_Signers.ModifiedBy = user
                ms_Contract_Signers.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Dim sex As List(Of SelectListItem) = New List(Of SelectListItem)() From {
                New SelectListItem With {
                    .Text = "Man",
                    .Value = True
                },
                New SelectListItem With {
                    .Text = "Woman",
                    .Value = False
                }
            }
            ViewBag.Sex = New SelectList(sex, "Value", "Text", ms_Contract_Signer.Sex)
            Return View(ms_Contract_Signer)
        End Function

        ' GET: Contract_Signer/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Contract_Signer = db.Ms_Contract_Signers.Where(Function(x) x.Signer_ID = id).
                Select(Function(x) New Ms_Contract_Signer With {.Signer_ID = x.Signer_ID, .Name = x.Name, .Title_Ind = x.Title_Ind, .Title_Eng = x.Title_Eng,
                .Sex = x.Sex, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(ms_Contract_Signer) Then
                Return HttpNotFound()
            End If
                Return View(ms_Contract_Signer)
        End Function

        ' POST: Contract_Signer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim ms_Contract_Signers = db.Ms_Contract_Signers.Where(Function(x) x.Signer_ID = id).FirstOrDefault
            ms_Contract_Signers.ModifiedBy = user
            ms_Contract_Signers.ModifiedDate = DateTime.Now
            ms_Contract_Signers.IsDeleted = True
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
