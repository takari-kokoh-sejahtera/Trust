@ModelType Trust.Trust.Ms_Customers
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
