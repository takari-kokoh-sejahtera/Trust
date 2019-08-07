@ModelType Trust.Ms_RiskGrading
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
