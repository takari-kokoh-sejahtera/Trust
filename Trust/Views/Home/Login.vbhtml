@ModelType Trust.Login
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
    <link rel="shortcut icon" href="@Url.Action("Img", "Content")/takari-logo.png">
    @Styles.Render("~/BundlesLogin/css")
    @*@Scripts.Render("~/bundles/modernizr")*@
</head>
<body>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @*@<div class="form-horizontal">
                <h1>Login</h1>
                <div Class="form-horizontal">
                    <hr />
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    <div Class="form-group">
                        @Html.Label("User Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            @Html.EditorFor(Function(model) model.User_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.User_Name, "", New With {.class = "text-danger"})
                        </div>
                    </div>

                    <div Class="form-group">
                        @Html.LabelFor(Function(model) model.Password, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            @Html.EditorFor(Function(model) model.Password, New With {.htmlAttributes = New With {.class = "form-control"}})
                            @Html.ValidationMessageFor(Function(model) model.Password, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div Class="form-group">
                        <div Class="col-md-offset-2 col-md-10">
                            <input type="submit" value="Login" Class="btn btn-default" />
                        </div>
                    </div>
                </div>
            </div>*@
        @<div Class="container">
            <div Class="row">
                <div Class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 Class="text-center login-title">Sign in to continue to TRUST</h1>
                    <div Class="account-wall">
                        <img Class="profile-img" src="@Url.Action("Img", "Content")/takari-logo.png"
                             alt="">
                        <form Class="form-signin">
                            @Html.EditorFor(Function(model) model.User_Name, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "User Name", .autofocus = "autofocus"}})
                            @*<input type="text" name="User_Name" Class="form-control" placeholder="Email" required autofocus>*@
                            @Html.ValidationMessageFor(Function(model) model.User_Name, "", New With {.class = "text-danger"})
                            @Html.EditorFor(Function(model) model.Password, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "Password"}})
                            @Html.ValidationMessageFor(Function(model) model.Password, "", New With {.class = "text-danger"})
                            <Button Class="btn btn-lg btn-primary btn-block" type="submit">
                                Sign in
                            </Button>
                            @*<Label Class="checkbox pull-left">
                                    <input type="checkbox" value="remember-me">
                                    Remember me
                                </Label>*@
                            <p class="pull-right need-help">If you need help, please contact IT </p><span class="clearfix"></span>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    End Using
    @Scripts.Render("~/BundlesLogin/js")

    @*@Scripts.Render("~/Bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")*@
</body>
</html>
