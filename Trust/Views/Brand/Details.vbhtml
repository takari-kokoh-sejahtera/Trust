@ModelType Trust.Ms_Vehicle_Brands
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Brand</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayName("Brand Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Brand_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Brand_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
