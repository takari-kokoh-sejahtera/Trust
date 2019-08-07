@ModelType Trust.Cn_Departments
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Department</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Department)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Department)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Divisions.Division)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Divisions.Division)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Department_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
