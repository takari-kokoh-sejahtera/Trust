@ModelType Trust.Cn_ApprovalUser
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>ApprovalUser</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.User)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.User)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedBy)
        </dd>


    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ApprovalUser_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
