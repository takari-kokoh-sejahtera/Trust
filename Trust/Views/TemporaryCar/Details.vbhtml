@ModelType Trust.Tr_TemporaryCar
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Temporary Car</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Contract_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contract_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CompanyGroup_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyGroup_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Company_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.license_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.license_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.TemporaryCar_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
