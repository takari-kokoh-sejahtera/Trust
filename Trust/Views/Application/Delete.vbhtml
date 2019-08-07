@ModelType Trust.Tr_Applications
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Tr_Applications</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.POFromCustomer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.POFromCustomer)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Payment_Condition)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Payment_Condition)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Modification)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Modification)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.GPS_Cost)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.GPS_Cost)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.GPS_CostPerMonth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.GPS_CostPerMonth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Agent_Fee)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Agent_Fee)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Agent_FeePerMonth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Agent_FeePerMonth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Update_OTR)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Update_OTR)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Residual_Value)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Residual_Value)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Residual_ValuePercent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Residual_ValuePercent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Expedition_Cost)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Expedition_Cost)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Keur)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Keur)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Update_Diskon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Update_Diskon)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cost_Price)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cost_Price)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Up_Front_Fee)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Up_Front_Fee)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Up_Front_Fee_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Up_Front_Fee_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Other)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Other)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Efektif_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Efektif_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Replacement_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Replacement_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Replacement)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Replacement)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Maintenance_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Maintenance_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Maintenance)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Maintenance)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Overhead_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Overhead_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Overhead)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Overhead)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Assurance_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Assurance_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Assurance)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Assurance)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Lease_Profit)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Lease_Profit)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Lease_Profit_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Lease_Profit_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Depresiasi)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Depresiasi)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Depresiasi_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Depresiasi_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Funding_Interest)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Funding_Interest)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Funding_Interest_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Funding_Interest_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Bid_PricePerMonth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Bid_PricePerMonth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IRR)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IRR)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Funding_Rate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Funding_Rate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Spread)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Spread)
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsDeleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ms_Citys.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Citys.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ms_Citys1.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ms_Citys1.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tr_ProspectCustDetails.Transaction_Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tr_ProspectCustDetails.Transaction_Type)
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
