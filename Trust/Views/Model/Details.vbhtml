@ModelType Trust.Ms_Vehicle_Models
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Model</h4>
    <hr />
    <dl class="dl-horizontal">

        <dt>
            @Html.DisplayName("Brand Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Vehicle_Brands.Brand_Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>
        <dt>
            OTR Price
        </dt>

        <dd>
            @String.Format("{0:n}", Model.OTR_Price)
        </dd>
        <dt>
            Normal Disc
        </dt>

        <dd>
            @String.Format("{0:n}", Model.Normal_Disc)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Year1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Year1)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Year2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Year2)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Year3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Year3)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Year4)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Year4)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Year5)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Year5)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            Asset Rating
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Asset_Rating)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Active)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Active)
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Model_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
