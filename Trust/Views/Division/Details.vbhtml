@ModelType Trust.Cn_Divisions
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Division</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Division)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Division)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_GMs.GM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_GMs.GM)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Division_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
