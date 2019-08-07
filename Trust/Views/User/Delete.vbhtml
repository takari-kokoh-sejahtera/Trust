@ModelType Trust.Cn_Users
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>User</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NIK)
        </dd>

        <dt>
            @Html.DisplayName("User Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.User_Name)
        </dd>

        <dt>
            Full Name
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Full_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Directorats2.Directorat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Directorats2.Directorat)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Divisions2.Division)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Divisions2.Division)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Departments.Department)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Departments.Department)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_GMs2.GM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_GMs2.GM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Titles2.Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Titles2.Title)
        </dd>
    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
