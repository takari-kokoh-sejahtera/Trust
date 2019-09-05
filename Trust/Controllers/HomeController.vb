Imports System.IO
Imports System.Net
Imports System.Web.Helpers
Imports System.Web.Mvc
Imports System.Web.Security
Imports Trust.Trust

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Private db As New TrustEntities
#Region "Java"

    Public Function Notif() As ActionResult
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")

        If (Not (Session("ID")) Is Nothing) Then
            Dim Query = db.GetCountApprove(Session("ID")).FirstOrDefault
            Dim Qty As Integer = 0
            If Not Query Is Nothing Then
                Qty = Query.Quotation
            End If

            'Dim amount = Query.Amount.ToString("#,##0.00")
            Return Json(New With {Key .success = "true", Key .qty = Qty, Key .nama = Session("User_ID")})
        End If
        Return Json(New With {Key .success = "false"})
    End Function

    Public Function GetMarketingChar() As ActionResult
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")

        If (Not (Session("ID")) Is Nothing) Then
            Dim prospectCust = db.sp_ProspectCharFromUser(1, Session("ID"))
            Dim calculate = db.sp_CalcucationCharFromUser(1, Session("ID"))
            Dim quotation = db.sp_QuotationCharFromUser(1, Session("ID"))
            Dim prospectHistory = db.sp_ProspectCustHistoryCharFromUser(1, Session("ID"))

            'Dim amount = Query.Amount.ToString("#,##0.00")
            Return Json(New With {Key .success = "true", Key .prospectCust = prospectCust, Key .calculate = calculate, Key .quotation = quotation, Key .prospectHistory = prospectHistory})
        End If
        Return Json(New With {Key .success = "false"})
    End Function
#End Region
    Function Errors() As ActionResult

        Return View()
    End Function

    Function ChangePassword() As ActionResult
        Dim id As String
        If ((Session("User_ID")) Is Nothing) Then
            Return RedirectToAction("Login", "Home")
        Else
            id = Session("ID")
        End If
        Dim user = (From A In db.Cn_Users
                    Where A.User_ID = id
                    Select A.User_ID, A.User_Name, A.Password).
        Select(Function(x) New Cn_User_ChangePass With {.User_ID = x.User_ID, .User_Name = x.User_Name}).FirstOrDefault()
        Return View(user)
    End Function

    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function ChangePassword(<Bind(Include:="User_ID,User_Name,Password,NewPassword,ConfirmPassword")> ByVal cn_User As Cn_User_ChangePass) As ActionResult
        If ModelState.IsValid Then
            Dim id As String
            If ((Session("User_ID")) Is Nothing) Then
                Return RedirectToAction("Login", "Home")
            Else
                id = Session("ID")
            End If
            Dim wrapper As New UserManagemen(cn_User.Password)
            Dim cipherText As String = wrapper.EncryptData("")
            Dim newwrapper As New UserManagemen(cn_User.NewPassword)
            Dim newcipherText As String = newwrapper.EncryptData("")
            Dim user = db.Cn_Users.Where(Function(x) x.User_ID = cn_User.User_ID And x.Password = cipherText).FirstOrDefault()
            If (user Is Nothing) Then
                ModelState.AddModelError("Password", "Wrong Password")
            Else
                user.Password = newcipherText
                db.SaveChanges()
                Return View("Index")
            End If
        End If
        Return View(cn_User)
    End Function
    Public Function SideMenu() As ActionResult
        Dim data = db.sp_ModuleUser(Session("ID")).ToList()
        ViewBag.Config = data.Where(Function(x) x.Tab = "Config")
        ViewBag.Master = data.Where(Function(x) x.Tab = "Master")
        ViewBag.Transaksi = data.Where(Function(x) x.Tab = "Transaksi")
        ViewBag.Report = data.Where(Function(x) x.Tab = "Report")
        Return PartialView("SideMenu")
    End Function

    Public Function _Slidebar() As ActionResult
        Dim data = db.sp_ModuleUser(Session("ID")).ToList()
        ViewBag.Config = data.Where(Function(x) x.Tab = "Config")
        ViewBag.Master = data.Where(Function(x) x.Tab = "Master")
        ViewBag.MasterCount = data.Where(Function(x) x.Tab = "Master").Count
        ViewBag.Transaksi = data.Where(Function(x) x.Tab = "Transaksi")
        ViewBag.TransaksiCount = data.Where(Function(x) x.Tab = "Transaksi").Count
        ViewBag.Report = data.Where(Function(x) x.Tab = "Report")
        ViewBag.ReportCount = data.Where(Function(x) x.Tab = "Report").Count
        ViewBag.pic = Session("Pic")
        Return PartialView("_Slidebar")
    End Function
    Public Function _Header() As ActionResult
#If DEBUG Then
        Dim item As Object = Session("ID")
        If item = Nothing Then
            Dim user = 1
            Dim querys = db.Cn_Users.Where(Function(o) o.IsDeleted = False And o.User_ID = user).FirstOrDefault
            Dim Approval = db.V_Approval.Where(Function(o) o.User_ID = user).ToList
            Session("User_ID") = querys.User_Name.ToUpper()
            Session("ID") = querys.User_ID


            'Session("Level_ID") = querys.Level_ID
            'Session("LevelGroup_ID") = querys.LevelGroup_ID

            Session("Level_ID_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.LEVEL).FirstOrDefault
            Session("Level_ID_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.LEVEL).FirstOrDefault
            Session("Level_ID_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.LEVEL).FirstOrDefault
            Session("Limited_Approval_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.Limited_Approval).FirstOrDefault
            Session("Limited_Approval_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.Limited_Approval).FirstOrDefault
            Session("Limited_Approval_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.Limited_Approval).FirstOrDefault
            Session("pic") = If(querys.Pic, "")
            Session("Title") = If(querys.Cn_Titles2.Title, "")
            Session("Division_ID") = If(querys.Division_ID, "0")
            Session("Department_ID") = If(querys.Department_ID, "0")
            Session("Role_ID") = If(querys.Role_ID, "0")
        End If
#End If

        Dim nameDB = db.Database.Connection.Database
        Session("NameDB") = nameDB

        Dim ispaswordDefault = 0
        If Session("Password") = "10ghiQSwQJc=" Then
            ispaswordDefault = 1
        End If
        Dim idnya As Integer? = Session("ID")
        Dim Query = db.GetCountApprove(idnya).FirstOrDefault
        Dim qty As Integer = 0
        If Not Query.Quotation = 0 Then
            qty = qty + 1
        End If
        If Not Query.POFromCust = 0 Then
            qty = qty + 1
        End If
        If Not Query.ApplicationPO = 0 Then
            qty = qty + 1
        End If
        If Not Query.Application = 0 Then
            qty = qty + 1
        End If
        If Not Query.CountKYC = 0 Then
            qty = qty + 1
        End If
        If Not Query.CountReviewed = 0 Then
            qty = qty + 1
        End If
        If ispaswordDefault = 1 Then
            qty = qty + 1
        End If


        ViewBag.IsPasswordDefault = ispaswordDefault
        ViewBag.Quotation = Query.Quotation
        ViewBag.POFromCust = Query.POFromCust
        ViewBag.ApplicationPO = Query.ApplicationPO
        ViewBag.Application = Query.Application
        ViewBag.CountKYC = Query.CountKYC
        ViewBag.CountReviewed = Query.CountReviewed
        ViewBag.Qty = qty
        ViewBag.pic = Session("Pic")
        'ViewBag.LevelGroup_ID = Session("LevelGroup_ID")
        ViewBag.user = Session("User_ID")
        ViewBag.title = Session("Title")
        Return PartialView("_Header")
    End Function
    Function Index() As ActionResult
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
        Dim Query As Object
        If Session("Division_ID") = 1 Then
            Query = db.sp_DashboardMarketing(Session("ID")).FirstOrDefault
            Dim role_ID As Integer? = Session("Role_ID")
            Dim user_ID = Session("ID")
            Dim department = Session("Department_ID")
            Dim department_ID As Integer? = CType(department, Integer?)

            'yang role id nya HEAD MARKETING
            If role_ID = 8 Then
                Dim arrayUser = db.Cn_Users.Where(Function(x) x.Department_ID = department_ID And role_ID = 8).Select(Function(x) x.User_ID).ToArray
                'Checker List
                Dim listChecker = (From A In db.Tr_ProspectCustHistorys.Where(Function(x) x.IsDeleted = False)
                                   Group Join B In db.V_ProspectCusts On A.ProspectCustomer_ID Equals B.ProspectCustomer_ID Into AB = Group
                                   From B In AB.DefaultIfEmpty
                                   Group Join C In db.Ms_ProspectCategorys On A.ProspectCategory_ID Equals C.ProspectCategory_ID Into AC = Group
                                   From C In AC.DefaultIfEmpty
                                   Where A.IsChecked = False And arrayUser.Contains(A.CreatedBy)
                                   Order By B.CompanyGroup_Name, B.Company_Name
                                   Select A.ProspectCustomerHistory_ID, B.CompanyGroup_Name, B.Company_Name, C.ProspectCategory, A.Status, A.DateTrans, A.Notes, A.CheckNote).ToList
                ViewBag.ListChecker = listChecker
            End If
            ViewBag.Role_ID = role_ID

            ViewBag.Division_ID = Session("Division_ID")
            ViewBag.Data = Query
        End If
        Return View()
    End Function
    Function Checked(detail As IEnumerable(Of Tr_ProspectCustHistory)) As ActionResult
        Dim user As Integer
        If ((Session("ID")) Is Nothing) Then Return RedirectToAction("Login", "Home") Else user = Session("ID")
        If IsNothing(detail) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim cek = detail.Where(Function(x) x.CheckNote IsNot Nothing).ToList
        For Each i In cek
            Dim checkin = db.Tr_ProspectCustHistorys.Where(Function(x) x.ProspectCustomerHistory_ID = i.ProspectCustomerHistory_ID).FirstOrDefault
            checkin.CheckNote = i.CheckNote
            checkin.CheckedBy = user
            checkin.CheckedDate = Now
            checkin.IsChecked = True
        Next
        db.SaveChanges()
        Return RedirectToAction("Index", "Home")
    End Function

    Function ProfileUser() As ActionResult
#If Not DEBUG Then
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
        ViewBag.pic = Session("Pic")
        ViewBag.user = Session("User_ID")
        ViewBag.title = Session("Title")
        Return View()
    End Function
    Function FileUpload(file As HttpPostedFileBase) As ActionResult
#If Not DEBUG Then
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
#End If
        If file IsNot Nothing Then
            Dim pic As String = System.IO.Path.GetFileName(file.FileName)
            Dim path As String = System.IO.Path.Combine(Server.MapPath("~/Image/Profile"), pic)
            Dim id = Convert.ToInt16(Session("ID"))
            Dim user = db.Cn_Users.Where(Function(x) x.User_ID = id).FirstOrDefault
            If Not user Is Nothing Then
                user.Pic = pic
                db.SaveChanges()
                file.SaveAs(path)
                Using ms As MemoryStream = New MemoryStream()
                    file.InputStream.CopyTo(ms)
                    Dim array As Byte() = ms.GetBuffer()
                End Using
                Session("Pic") = pic
            End If
        End If

        Return RedirectToAction("Index", "Home")
    End Function

    Function About() As ActionResult
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        If ((Session("User_ID")) Is Nothing) Then Return RedirectToAction("Login", "Home")
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    Function Login() As ActionResult
        Session("User_ID") = Nothing
        Return View()
    End Function
    <HttpPost()>
    Function Login(<Bind(Include:="User_Name,Password")> ByVal cn_Users As Login) As ActionResult
        If ModelState.IsValid Then
            If (db.Cn_Users.Where(Function(o) o.IsDeleted = False And o.User_Name.Equals(cn_Users.User_Name)).Any()) Then
                Dim wrapper As New UserManagemen(cn_Users.Password)
                Dim cipherText As String = wrapper.EncryptData("")
                Dim pass = db.Cn_Users.Where(Function(o) o.IsDeleted = False And o.User_Name.Equals(cn_Users.User_Name)).FirstOrDefault.Password
                Dim query = db.Cn_Users.Where(Function(o) o.IsDeleted = False And o.User_Name.Equals(cn_Users.User_Name)).FirstOrDefault
                Dim Approval = db.V_Approval.Where(Function(o) o.User_ID = query.User_ID).ToList

#If DEBUG Then
                Session("User_ID") = cn_Users.User_Name.ToUpper()
                Session("ID") = query.User_ID
                Session("Level_ID_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.LEVEL).FirstOrDefault
                Session("Level_ID_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.LEVEL).FirstOrDefault
                Session("Level_ID_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.LEVEL).FirstOrDefault
                Session("Limited_Approval_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.Limited_Approval).FirstOrDefault
                Session("Limited_Approval_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.Limited_Approval).FirstOrDefault
                Session("Limited_Approval_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.Limited_Approval).FirstOrDefault
                Session("pic") = If(query.Pic, "")
                Session("Title") = If(query.Cn_Titles2.Title, "")
                Session("Division_ID") = If(query.Division_ID, 0)
                Session("Department_ID") = If(query.Department_ID, 0)
                Session("Role_ID") = If(query.Role_ID, 0)
                Session("Password") = pass
                Return RedirectToAction("Index")
#Else
                If (pass = cipherText) Then
                    Session("User_ID") = cn_Users.User_Name.ToUpper()
                    Session("ID") = query.User_ID
                    Session("Level_ID_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.LEVEL).FirstOrDefault
                    Session("Level_ID_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.LEVEL).FirstOrDefault
                    Session("Level_ID_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.LEVEL).FirstOrDefault
                    Session("Limited_Approval_Quotation") = Approval.Where(Function(x) x.Module_ID = 19).Select(Function(x) x.Limited_Approval).FirstOrDefault
                    Session("Limited_Approval_Application") = Approval.Where(Function(x) x.Module_ID = 1025).Select(Function(x) x.Limited_Approval).FirstOrDefault
                    Session("Limited_Approval_ApplicationPO") = Approval.Where(Function(x) x.Module_ID = 1050).Select(Function(x) x.Limited_Approval).FirstOrDefault
                    Session("pic") = If(query.Pic, "")
                    Session("Title") = If(query.Cn_Titles2.Title, "")
                    Session("Division_ID") = If(query.Division_ID, "0")
                    Session("Department_ID") = If(query.Department_ID, "0")
                    Session("Role_ID") = If(query.Role_ID, "0")
                    Session("Password") = pass
                    Return RedirectToAction("Index")
                Else
                    ModelState.AddModelError("Password", "Wrong Password")
                End If
#End If
            Else
                ModelState.AddModelError("User_Name", "User Name is not exists")
            End If
        End If
        Return View(cn_Users)
    End Function
End Class
