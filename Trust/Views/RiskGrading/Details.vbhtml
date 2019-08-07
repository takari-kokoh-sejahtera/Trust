@ModelType Trust.Ms_RiskGrading
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Risk Grading</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Project_Rating)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Project_Rating)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RiskGrading)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RiskGrading)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.RiskGrading_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
