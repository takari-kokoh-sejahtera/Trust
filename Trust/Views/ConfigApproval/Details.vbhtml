@ModelType Trust.Cn_Approval
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedDate)
        </dd>


    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Approval_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
