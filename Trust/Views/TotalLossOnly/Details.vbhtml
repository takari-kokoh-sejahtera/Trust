@ModelType Trust.Tr_TotalLossOnly
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Total Loss Only</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Contract_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contract_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fromlicense_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fromlicense_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tolicense_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tolicense_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Date)
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
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.TotalLossOnly_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
