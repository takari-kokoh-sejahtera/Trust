@ModelType Trust.Tr_CreateInvoices
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Tr_CreateInvoices</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.From_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.From_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.To_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.To_Date)
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsDeleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users1.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users1.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ms_Customers.Company_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Customers.Company_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tr_Contracts.Contract_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tr_Contracts.Contract_No)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.CreateInvoice_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
