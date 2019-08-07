@ModelType Trust.Ms_Dealer
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Ms_Dealers</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Dealer_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Dealer_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Email)
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
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Dealer_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
