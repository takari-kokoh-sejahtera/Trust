@ModelType Trust.Tr_ApplicationPO
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>ApplicationPO</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Vehicle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Vehicle)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.CompanyName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyName)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.ApplicationPO_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ApplicationPO_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Color)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Color)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Delivery_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Delivery_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Usage)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Usage)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Qty)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Qty)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Refund)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Refund)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PaymentByUser)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PaymentByUser)
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
