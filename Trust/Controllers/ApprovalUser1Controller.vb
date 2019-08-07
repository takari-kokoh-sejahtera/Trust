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
    Public Class ApprovalUser1Controller
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: ApprovalUser1
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
            Dim AppUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False).Select(Function(x) New Cn_ApprovalUser With {.ApprovalUser_ID = x.ApprovalUser_ID,
                .User_ID = x.User_ID, .User = x.Cn_Users2.User_Name, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name})
            If Not String.IsNullOrEmpty(searchString) Then
                AppUser = AppUser.Where(Function(s) s.User.Contains(searchString))
            End If
            Select Case sortOrder
                Case "User"
                    AppUser = AppUser.OrderBy(Function(s) s.User)
                Case Else
                    AppUser = AppUser.OrderByDescending(Function(s) s.CreatedDate)
            End Select
            Dim pageNumber As Integer = If(page, 1)
            Return View(AppUser.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: ApprovalUser1/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim AppUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False And x.ApprovalUser_ID = id).Select(Function(x) New Cn_ApprovalUser With {.ApprovalUser_ID = x.ApprovalUser_ID,
                .User_ID = x.User_ID, .User = x.Cn_Users2.User_Name, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate, .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            If IsNothing(AppUser) Then
                Return HttpNotFound()
            End If
            Return View(AppUser)
        End Function
        Public Function CheckAdd(order() As Cn_ApprovalUserDetail) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim prospectCustomer As New Tr_ProspectCusts
            Dim result As String = "Error"
            Dim Message = ""

            'Validasi
#Region "Validasi"
            Dim Valid As Boolean = True
            Dim CheckDouble = order.GroupBy(Function(x) x.Approval_ID).Select(Function(x) New Cn_Approval With {.Approval_ID = x.Key, .Count = x.Count})
            Dim detail = order.Select(Function(x) x.Approval_ID)




            'validate
            If (CheckDouble.Where(Function(x) x.Count > 1).Any) Then
                Message = "Can't add double Approval"
                Valid = False
            End If
            Dim approval = db.Cn_Approvals.Where(Function(x) detail.Contains(x.Approval_ID)).GroupBy(Function(x) x.Module_ID).Select(Function(x) New Cn_Approval With {.Module_ID = x.Key, .Count = x.Count}).ToList
            If (Valid And approval.Where(Function(x) x.Count > 1).Any) Then
                Message = "Can't add double Module"
                Valid = False
            End If
#End Region

            If Valid Then
                result = "Success"
            End If
            Return Json(New With {Key .result = result, Key .messages = Message}, JsonRequestBehavior.AllowGet)
        End Function

        ' GET: ApprovalUser1/Create
        Function Create() As ActionResult
            Dim listUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.User_ID).ToArray
            ViewBag.User_ID = New SelectList(db.Cn_Users.Where(Function(x) x.IsDeleted = False And Not listUser.Contains(x.User_ID)).OrderBy(Function(x) x.User_Name), "User_ID", "User_Name")
            ViewBag.Approval_ID = New SelectList(db.Cn_Approvals.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Approval_Name), "Approval_ID", "Approval_Name")

            Return View()
        End Function
        Function Validate(approvUser As Cn_ApprovalUser, ByRef message As String, Status As String) As Boolean
            Dim valid = True
            If Status = "New" And (db.Cn_ApprovalUsers.Where(Function(x) x.User_ID = approvUser.User_ID And x.IsDeleted = False).Any) Then
                valid = False
                message = "User Already Exists!"
            ElseIf approvUser.Cn_ApprovalUserDetail Is Nothing Then
                valid = False
                message = "Must fiil Approval!"
            End If
            Return valid
        End Function
        Function CreateData(appUser() As Cn_ApprovalUser) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim header = appUser.FirstOrDefault
            Dim message = "", valid = True, result = "Error"
            'VALIDATION
            valid = Validate(header, message, "New")
            If valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        Dim appUsers = New Cn_ApprovalUsers With
                        {.User_ID = header.User_ID, .CreatedDate = DateTime.Now, .CreatedBy = user, .IsDeleted = False}
                        db.Cn_ApprovalUsers.Add(appUsers)
                        db.SaveChanges()
                        For Each i In header.Cn_ApprovalUserDetail
                            Dim appUserDetails = New Cn_ApprovalUserDetails With
                                {.ApprovalUser_ID = appUsers.ApprovalUser_ID, .Approval_ID = i.Approval_ID, .Limited_Approval = i.Limited_Approval,
                                .CreatedDate = DateTime.Now, .CreatedBy = user, .IsDeleted = False}
                            db.Cn_ApprovalUserDetails.Add(appUserDetails)
                        Next
                        db.SaveChanges()
                        dbs.Commit()
                        result = "Success"
                    Catch ex As Exception
                        dbs.Rollback()
                        message = ex.Message
                    End Try
                End Using
            End If
            Return Json(New With {Key .result = result, .message = message})
        End Function
        ' GET: ApprovalUser1/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_ApprovalUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False And x.ApprovalUser_ID = id).Select(Function(x) New Cn_ApprovalUser With {.ApprovalUser_ID = x.ApprovalUser_ID,
                .User_ID = x.User_ID, .User = x.Cn_Users2.User_Name, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
                .ModifiedBy = x.Cn_Users1.User_Name, .Cn_ApprovalUserDetail = x.Cn_ApprovalUserDetails.Where(Function(z) z.IsDeleted = False).
                Select(Function(y) New Cn_ApprovalUserDetail With
                {.ApprovalUserDetail_ID = y.ApprovalUserDetail_ID, .Approval_ID = y.Approval_ID, .Approval_IDstr = y.Cn_Approvals.Approval_Name,
                .Limited_Approval = y.Limited_Approval})}).FirstOrDefault
            'Dim cn_ApprovalUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False And x.ApprovalUser_ID = id).Select(Function(x) New Cn_ApprovalUser With {.ApprovalUser_ID = x.ApprovalUser_ID,
            '    .User_ID = x.User_ID, .User = x.Cn_Users2.User_Name, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
            '    .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault
            'cn_ApprovalUser.Cn_ApprovalUserDetail = db.Cn_ApprovalUserDetails.Where(Function(x) x.IsDeleted = False And x.ApprovalUser_ID = id)
            If IsNothing(cn_ApprovalUser) Then
                Return HttpNotFound()
            End If
            Dim listUser = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False).Select(Function(x) x.User_ID).ToArray
            ViewBag.User_ID = New SelectList(db.Cn_Users.Where(Function(x) x.IsDeleted = False And (Not listUser.Contains(x.User_ID) Or x.User_ID = cn_ApprovalUser.User_ID)).OrderBy(Function(x) x.User_Name), "User_ID", "User_Name", cn_ApprovalUser.User_ID)
            ViewBag.Approval_ID = New SelectList(db.Cn_Approvals.Where(Function(x) x.IsDeleted = False).OrderBy(Function(x) x.Approval_Name), "Approval_ID", "Approval_Name")
            Return View(cn_ApprovalUser)
        End Function
        Function EditData(appUser() As Cn_ApprovalUser) As ActionResult
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString

            Dim header = appUser.FirstOrDefault
            Dim message = "", valid = True, result = "Error"
            'VALIDATION
            valid = Validate(header, message, "Edit")
            If valid Then
                Using dbs = db.Database.BeginTransaction
                    Try
                        'header
                        Dim appUsers = db.Cn_ApprovalUsers.Where(Function(x) x.ApprovalUser_ID = header.ApprovalUser_ID).FirstOrDefault
                        appUsers.ModifiedBy = user
                        appUsers.ModifiedDate = DateTime.Now
                        db.SaveChanges()
                        For Each i In header.Cn_ApprovalUserDetail.Where(Function(x) x.ApprovalUserDetail_ID = 0)
                            Dim appUserDetails = New Cn_ApprovalUserDetails With
                                {.ApprovalUser_ID = header.ApprovalUser_ID, .Approval_ID = i.Approval_ID, .Limited_Approval = i.Limited_Approval,
                                .CreatedDate = DateTime.Now, .CreatedBy = user, .IsDeleted = False}
                            db.Cn_ApprovalUserDetails.Add(appUserDetails)
                        Next
                        db.SaveChanges()
                        If header.Cn_ApprovalUserDetailDelete IsNot Nothing Then
                            For Each i In header.Cn_ApprovalUserDetailDelete
                                Dim detail = db.Cn_ApprovalUserDetails.Where(Function(x) x.ApprovalUserDetail_ID = i.ApprovalUserDetail_ID).FirstOrDefault
                                detail.IsDeleted = True
                                detail.ModifiedBy = user
                                detail.ModifiedDate = DateTime.Now
                                db.SaveChanges()
                            Next
                        End If
                        dbs.Commit()
                        result = "Success"
                    Catch ex As Exception
                        dbs.Rollback()
                        message = ex.Message
                    End Try
                End Using
            End If
            Return Json(New With {Key .result = result, .message = message})
        End Function


        ' GET: ApprovalUser1/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_ApprovalUsers = db.Cn_ApprovalUsers.Where(Function(x) x.IsDeleted = False And x.ApprovalUser_ID = id).Select(Function(x) New Cn_ApprovalUser With {.ApprovalUser_ID = x.ApprovalUser_ID,
                .User_ID = x.User_ID, .User = x.Cn_Users2.User_Name, .CreatedDate = x.CreatedDate, .CreatedBy = x.Cn_Users.User_Name, .ModifiedDate = x.ModifiedDate,
                .ModifiedBy = x.Cn_Users1.User_Name}).FirstOrDefault

            If IsNothing(cn_ApprovalUsers) Then
                Return HttpNotFound()
            End If
            Return View(cn_ApprovalUsers)
        End Function

        ' POST: ApprovalUser1/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim user As Integer
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim cn_ApprovalUsers As Cn_ApprovalUsers = Await db.Cn_ApprovalUsers.FindAsync(id)
            cn_ApprovalUsers.IsDeleted = True
            cn_ApprovalUsers.ModifiedBy = user
            cn_ApprovalUsers.ModifiedDate = DateTime.Now
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
