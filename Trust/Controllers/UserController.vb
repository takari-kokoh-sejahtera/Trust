Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PagedList
Imports Trust.Trust

Namespace Controllers
    Public Class UserController
        Inherits System.Web.Mvc.Controller

        Private db As New TrustEntities

        ' GET: User
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
            Dim cn_Users = db.Cn_Users.Where(Function(x) x.IsDeleted = False).Include(Function(c) c.Cn_Directorats).Include(Function(c) c.Cn_Divisions).Include(Function(c) c.Cn_GMs).Include(Function(c) c.Cn_Levels).Include(Function(c) c.Cn_Titles)
            'Return View(cn_Users.Where(Function(x) x.IsDeleted = False).ToList())
            If Not String.IsNullOrEmpty(searchString) Then
                cn_Users = cn_Users.Where(Function(s) s.NIK.Contains(searchString) OrElse s.User_Name.Contains(searchString) OrElse s.Cn_Divisions2.Division.Contains(searchString))
            End If
            Select Case sortOrder
                Case "NIK"
                    cn_Users = cn_Users.OrderBy(Function(s) s.NIK)
                Case "User_Name"
                    cn_Users = cn_Users.OrderBy(Function(s) s.User_Name)
                Case "Division"
                    cn_Users = cn_Users.OrderBy(Function(s) s.Cn_Divisions2.Division)
                Case Else
                    cn_Users = cn_Users.OrderByDescending(Function(s) s.CreatedDate)
            End Select

            Dim pageNumber As Integer = If(page, 1)
            Return View(cn_Users.ToPagedList(pageNumber, pageSize))

        End Function

        ' GET: User/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Users As Cn_Users = db.Cn_Users.Find(id)
            If IsNothing(cn_Users) Then
                Return HttpNotFound()
            End If
            Return View(cn_Users)
        End Function

        ' GET: User/Create
        Function Create() As ActionResult
#If Not DEBUG Then
            If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats.Where(Function(x) x.IsDeleted = False), "Directorat_ID", "Directorat")
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions.Where(Function(x) x.IsDeleted = False), "Division_ID", "Division")
            ViewBag.Department_ID = New SelectList(db.Cn_Departments.Where(Function(x) x.IsDeleted = False), "Department_ID", "Department")
            ViewBag.GM_ID = New SelectList(db.Cn_GMs.Where(Function(x) x.IsDeleted = False), "GM_ID", "GM")
            ViewBag.Title_ID = New SelectList(db.Cn_Titles.Where(Function(x) x.IsDeleted = False), "TItle_ID", "TItle")
            ViewBag.Role_ID = New SelectList(db.Cn_Roles.Where(Function(x) x.IsDeleted = False), "Role_ID", "Role_Name")
            Return View()
        End Function

        ' POST: User/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="User_ID,NIK,User_Name,Full_Name,Password,Directorat_ID,GM_ID,Division_ID,Department_ID,Title_ID,Role_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_Users As Cn_User) As ActionResult
            ModelState.Remove("NewPassword")
            ModelState.Remove("ConfirmPassword")
            If ModelState.IsValid Then
                Dim user As String
                If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
                Dim wrapper As New UserManagemen(cn_Users.Password)
                Dim cipherText As String = wrapper.EncryptData("")
                Dim userdb As New Cn_Users
                userdb.NIK = cn_Users.NIK
                userdb.User_Name = cn_Users.User_Name
                userdb.Full_Name = cn_Users.Full_Name
                userdb.Directorat_ID = cn_Users.Directorat_ID
                userdb.GM_ID = cn_Users.GM_ID
                userdb.Division_ID = cn_Users.Division_ID
                userdb.Department_ID = cn_Users.Department_ID
                userdb.Title_ID = cn_Users.Title_ID
                userdb.Role_ID = cn_Users.Role_ID
                userdb.Password = cipherText
                userdb.CreatedBy = user
                userdb.CreatedDate = DateTime.Now
                userdb.IsDeleted = False
                db.Cn_Users.Add(userdb)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats.Where(Function(x) x.IsDeleted = False), "Directorat_ID", "Directorat", cn_Users.Directorat_ID)
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions.Where(Function(x) x.IsDeleted = False), "Division_ID", "Division", cn_Users.Division_ID)
            ViewBag.Department_ID = New SelectList(db.Cn_Departments.Where(Function(x) x.IsDeleted = False), "Department_ID", "Department", cn_Users.Department_ID)
            ViewBag.GM_ID = New SelectList(db.Cn_GMs.Where(Function(x) x.IsDeleted = False), "GM_ID", "GM", cn_Users.GM_ID)
            ViewBag.Title_ID = New SelectList(db.Cn_Titles.Where(Function(x) x.IsDeleted = False), "TItle_ID", "TItle", cn_Users.Title_ID)
            ViewBag.Role_ID = New SelectList(db.Cn_Roles.Where(Function(x) x.IsDeleted = False), "Role_ID", "Role_Name", cn_Users.Role_ID)
            Return View(cn_Users)
        End Function

        ' GET: User/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Users As Cn_Users = db.Cn_Users.Find(id)
            If IsNothing(cn_Users) Then
                Return HttpNotFound()
            End If
            Dim cn_User As New Cn_User
            cn_User.User_ID = id
            cn_User.NIK = cn_Users.NIK
            cn_User.User_Name = cn_Users.User_Name
            cn_User.Full_Name = cn_Users.Full_Name
            cn_User.Directorat_ID = cn_Users.Directorat_ID
            cn_User.GM_ID = cn_Users.GM_ID
            cn_User.Division_ID = cn_Users.Division_ID
            cn_User.Title_ID = cn_Users.Title_ID
            cn_User.Role_ID = cn_Users.Role_ID
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats.Where(Function(x) x.IsDeleted = False), "Directorat_ID", "Directorat", cn_Users.Directorat_ID)
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions.Where(Function(x) x.IsDeleted = False), "Division_ID", "Division", cn_Users.Division_ID)
            ViewBag.Department_ID = New SelectList(db.Cn_Departments.Where(Function(x) x.IsDeleted = False), "Department_ID", "Department", cn_Users.Department_ID)
            ViewBag.GM_ID = New SelectList(db.Cn_GMs.Where(Function(x) x.IsDeleted = False), "GM_ID", "GM", cn_Users.GM_ID)
            ViewBag.Title_ID = New SelectList(db.Cn_Titles.Where(Function(x) x.IsDeleted = False), "TItle_ID", "TItle", cn_Users.Title_ID)
            ViewBag.Role_ID = New SelectList(db.Cn_Roles.Where(Function(x) x.IsDeleted = False), "Role_ID", "Role_Name", cn_Users.Role_ID)
            Return View(cn_User)
        End Function

        ' POST: User/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="User_ID,NIK,User_Name,Full_Name,Password,Directorat_ID,GM_ID,Division_ID,Department_ID,Title_ID,Role_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsDeleted")> ByVal cn_Users As Cn_User) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            ModelState.Remove("NewPassword")
            ModelState.Remove("ConfirmPassword")
            ModelState.Remove("Password")
            If ModelState.IsValid Then
                Dim User1 = db.Cn_Users.FirstOrDefault(Function(p) (p.User_ID = cn_Users.User_ID))
                If (User1 Is Nothing) Then
                    Return HttpNotFound()
                End If

                User1.NIK = cn_Users.NIK
                User1.User_Name = cn_Users.User_Name
                User1.Full_Name = cn_Users.Full_Name
                User1.Directorat_ID = cn_Users.Directorat_ID
                User1.GM_ID = cn_Users.GM_ID
                User1.Division_ID = cn_Users.Division_ID
                User1.Department_ID = cn_Users.Department_ID
                User1.Title_ID = cn_Users.Title_ID
                User1.Role_ID = cn_Users.Role_ID
                User1.ModifiedBy = user
                User1.ModifiedDate = DateTime.Now
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.Directorat_ID = New SelectList(db.Cn_Directorats, "Directorat_ID", "Directorat", cn_Users.Directorat_ID)
            ViewBag.Division_ID = New SelectList(db.Cn_Divisions, "Division_ID", "Division", cn_Users.Division_ID)
            ViewBag.Department_ID = New SelectList(db.Cn_Departments, "Department_ID", "Department", cn_Users.Department_ID)
            ViewBag.GM_ID = New SelectList(db.Cn_GMs, "GM_ID", "GM", cn_Users.GM_ID)
            ViewBag.Title_ID = New SelectList(db.Cn_Titles, "TItle_ID", "TItle", cn_Users.Title_ID)
            ViewBag.Role_ID = New SelectList(db.Cn_Roles, "Role_ID", "Role_Name", cn_Users.Role_ID)
            Return View(cn_Users)
        End Function

        ' GET: User/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cn_Users As Cn_Users = db.Cn_Users.Find(id)
            If IsNothing(cn_Users) Then
                Return HttpNotFound()
            End If
            Return View(cn_Users)
        End Function

        ' POST: User/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As String
            If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID").ToString
            Dim cn_Users As Cn_Users = db.Cn_Users.Find(id)
            cn_Users.IsDeleted = True
            cn_Users.ModifiedBy = User
            cn_Users.ModifiedDate = DateTime.Now
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
