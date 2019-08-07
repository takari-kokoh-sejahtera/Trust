@ModelType Trust.Cn_Approval
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Approval</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Modules)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Modules)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Level)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Level)
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
