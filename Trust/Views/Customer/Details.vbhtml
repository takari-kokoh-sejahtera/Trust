@ModelType Trust.Trust.Ms_Customers
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Customer</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayName("Company Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company_Name)
        </dd>
        <dt>
            @Html.DisplayName("CompanyGroup Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Customer_CompanyGroups.CompanyGroup_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ms_Citys.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Citys.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayName("PIC Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Name)
        </dd>

        <dt>
            @Html.DisplayName("PIC Phone")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Phone)
        </dd>

        <dt>
            @Html.DisplayName("PIC Email")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Notes)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Notes)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.NPWP)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NPWP)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Account)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Account)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Bank)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Bank)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.IsStamped)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsStamped)
        </dd>


    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Customer_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
