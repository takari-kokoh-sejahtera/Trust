@ModelType Trust.Tr_Calculate
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Calculate</h4>
    <hr />
    <dl class="dl-horizontal">
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
            @Html.DisplayNameFor(Function(model) model.IsVehicleExists)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsVehicleExists)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Brand_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Brand_Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Vehicle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Vehicle)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Amount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Amount)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Rent_Location_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Rent_Location_Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Plat_Location_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plat_Location_Name)
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
            @Html.DisplayNameFor(Function(model) model.Agent_Fee)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Agent_Fee)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Update_OTR)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Update_OTR)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Update_Diskon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Update_Diskon)
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
            @Html.DisplayNameFor(Function(model) model.Maintenance_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Maintenance_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Overhead_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Overhead_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Assurance_Percent)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Assurance_Percent)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Spread)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Spread)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Bid_PricePerMonth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Bid_PricePerMonth)
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
