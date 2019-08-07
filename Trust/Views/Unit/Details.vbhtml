@ModelType Trust.Cn_Units
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Unit_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
