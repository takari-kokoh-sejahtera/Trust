@ModelType Trust.Trust.Tr_Invoices
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Tr_Invoices</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Invoice_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Invoice_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
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
            @Html.DisplayNameFor(Function(model) model.Contracted_by)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contracted_by)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsStamped)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsStamped)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sub_Total)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sub_Total)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.VAT)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VAT)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Stamp)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Stamp)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Total)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Total)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.From_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.From_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Signature_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Signature_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Signature_Title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Signature_Title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PerMonth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PerMonth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Published_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Published_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsPrined)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsPrined)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsPayed)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsPayed)
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
            @Html.DisplayNameFor(Function(model) model.Cn_Users2.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users2.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users3.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users3.NIK)
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
