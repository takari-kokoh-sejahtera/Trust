@ModelType Trust.Cn_Units
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Unit</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Unit)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Unit)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Departments.Department)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Departments.Department)
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
