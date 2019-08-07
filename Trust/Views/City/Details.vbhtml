@ModelType Trust.Ms_Citys
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>City</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Provinsi)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Provinsi)
        </dd>

        <dt>
            Expedition Cost
        </dt>

        <dd>
            @String.Format("{0:n}", Model.Expedition_Cost)
        </dd>

        <dt>
            Kode Plat
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Kode_Plat)
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
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.CIty_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
