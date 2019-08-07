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
    Public Class DealerController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: Dealer
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
            Dim dealer = From x In db.Ms_Dealers.Where(Function(x) x.IsDeleted = False)
                         Select New Ms_Dealer With {.Dealer_ID = x.Dealer_ID, .Dealer_Name = x.Dealer_Name, .Address = x.Address, .PIC_Name = x.PIC_Name, .PIC_Email = x.PIC_Email, .PIC_Phone = x.PIC_Phone,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate}
            If Not String.IsNullOrEmpty(searchString) Then
                dealer = dealer.Where(Function(s) s.Dealer_Name.Contains(searchString) OrElse s.PIC_Name.Contains(searchString))
            End If
            Select Case sortOrder
                Case "Dealer_Name"
                    dealer = dealer.OrderBy(Function(s) s.Dealer_Name)
                Case "PIC_Name"
                    dealer = dealer.OrderBy(Function(s) s.PIC_Name)
                Case Else
                    dealer = dealer.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(dealer.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Dealer/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dealer = (From x In db.Ms_Dealers.Where(Function(x) x.IsDeleted = False And x.Dealer_ID = id)
                          Select New Ms_Dealer With {.Dealer_ID = x.Dealer_ID, .Dealer_Name = x.Dealer_Name, .Address = x.Address, .PIC_Name = x.PIC_Name, .PIC_Email = x.PIC_Email, .PIC_Phone = x.PIC_Phone,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate}).FirstOrDefault

            If IsNothing(dealer) Then
                Return HttpNotFound()
            End If
            Return View(dealer)
        End Function

        ' GET: Dealer/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Dealer/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Dealer_ID,Dealer_Name,Address,PIC_Name,PIC_Phone,PIC_Email")> ByVal ms_Dealer As Ms_Dealer) As Task(Of ActionResult)
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim dealerNew = New Ms_Dealers With {
                    .Dealer_ID = ms_Dealer.Dealer_ID,
                    .Dealer_Name = ms_Dealer.Dealer_Name,
                    .Address = ms_Dealer.Address,
                    .PIC_Name = ms_Dealer.PIC_Name,
                    .PIC_Phone = ms_Dealer.PIC_Phone,
                    .PIC_Email = ms_Dealer.PIC_Email,
                    .CreatedBy = user,
                    .CreatedDate = DateTime.Now,
                    .IsDeleted = False
                }
                db.Ms_Dealers.Add(dealerNew)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.CreatedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Dealer.CreatedBy)
            ViewBag.ModifiedBy = New SelectList(db.Cn_Users, "User_ID", "NIK", ms_Dealer.ModifiedBy)
            Return View(ms_Dealer)
        End Function

        ' GET: Dealer/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Dealers = Await (From x In db.Ms_Dealers.Where(Function(x) x.IsDeleted = False And x.Dealer_ID = id)
                                    Select New Ms_Dealer With {.Dealer_ID = x.Dealer_ID, .Dealer_Name = x.Dealer_Name, .Address = x.Address, .PIC_Name = x.PIC_Name, .PIC_Email = x.PIC_Email, .PIC_Phone = x.PIC_Phone,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate}).FirstOrDefaultAsync

            If IsNothing(ms_Dealers) Then
                Return HttpNotFound()
            End If
            Return View(ms_Dealers)
        End Function

        ' POST: Dealer/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Dealer_ID,Dealer_Name,Address,PIC_Name,PIC_Phone,PIC_Email")> ByVal ms_Dealer As Ms_Dealer) As ActionResult
            If ModelState.IsValid Then
                Dim user As Integer
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim dealer = db.Ms_Dealers.Where(Function(x) x.IsDeleted = False And x.Dealer_ID = ms_Dealer.Dealer_ID).FirstOrDefault
                dealer.Dealer_Name = ms_Dealer.Dealer_Name
                dealer.Address = ms_Dealer.Address
                dealer.PIC_Name = ms_Dealer.PIC_Name
                dealer.PIC_Phone = ms_Dealer.PIC_Phone
                dealer.PIC_Email = ms_Dealer.PIC_Email
                dealer.ModifiedBy = user
                dealer.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(ms_Dealer)
        End Function

        ' GET: Dealer/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim ms_Dealers = Await (From x In db.Ms_Dealers.Where(Function(x) x.IsDeleted = False And x.Dealer_ID = id)
                                    Select New Ms_Dealer With {.Dealer_ID = x.Dealer_ID, .Dealer_Name = x.Dealer_Name, .Address = x.Address, .PIC_Name = x.PIC_Name, .PIC_Email = x.PIC_Email, .PIC_Phone = x.PIC_Phone,
                             .CreatedBy = x.Cn_Users.User_Name, .CreatedDate = x.CreatedDate, .ModifiedBy = x.Cn_Users1.User_Name, .ModifiedDate = x.ModifiedDate}).FirstOrDefaultAsync
            If IsNothing(ms_Dealers) Then
                Return HttpNotFound()
            End If
            Return View(ms_Dealers)
        End Function

        ' POST: Dealer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim dealer = db.Ms_Dealers.Where(Function(x) x.IsDeleted = False And x.Dealer_ID = id).FirstOrDefault
            dealer.IsDeleted = True
            dealer.ModifiedBy = user
            dealer.ModifiedDate = DateTime.Now
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
