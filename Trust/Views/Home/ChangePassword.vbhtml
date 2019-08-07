@ModelType  Trust.Cn_User_ChangePass
@Code
    ViewData("Title") = "ChangePassword"
End Code

<h2>Change Password</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.User_ID)

    <div class="form-group">
        @Html.LabelFor(Function(model) model.User_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.User_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.User_Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.Label("Old Password", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Password, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Password, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("New Password", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.NewPassword, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.NewPassword, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Confirm Password", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.ConfirmPassword, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.ConfirmPassword, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Create" class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
