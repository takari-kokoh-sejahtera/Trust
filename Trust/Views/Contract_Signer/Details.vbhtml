@ModelType Trust.Ms_Contract_Signer
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Signers</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Title_Ind)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title_Ind)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Title_Eng)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title_Eng)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sex)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sex)
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
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Signer_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
