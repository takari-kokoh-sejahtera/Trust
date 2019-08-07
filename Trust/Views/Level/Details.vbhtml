@ModelType Trust.Cn_Levels
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Level</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Level)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Level)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Remark)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Level_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
