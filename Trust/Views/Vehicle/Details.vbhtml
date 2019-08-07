@ModelType Trust.Ms_Vehicle
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Vehicle</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.license_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.license_no)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Tmp_Plat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tmp_Plat)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Brand_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Brand_Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Model)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Model)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.color)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.color)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.year)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.year)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.chassis_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.chassis_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.machine_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.machine_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.title_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.title_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.serial_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.serial_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.registration_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.registration_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.registration_expdate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.registration_expdate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.insurance_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.insurance_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.discount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.discount)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.price)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.price)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.acquisition)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.acquisition)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.coverage)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.coverage)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.comment)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.comment)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.date_insurance_start)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.date_insurance_start)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.date_insurance_end)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.date_insurance_end)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.date_insurance_mod)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.date_insurance_mod)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.date_book)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.date_book)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Publish)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Publish)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Yearly_Renewal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Yearly_Renewal)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_5Year_Renewal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_5Year_Renewal)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Month)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Month)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CC)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CC)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fuel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fuel)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NoUrutBuku)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NoUrutBuku)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DO_date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DO_date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Vehicle_Come)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Vehicle_Come)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.STNK_Receipt)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.STNK_Receipt)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PO_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PO_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Harga_Beli)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Harga_Beli)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Kwitansi_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Kwitansi_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Kwitansi_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Kwitansi_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FakturPajak)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FakturPajak)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FakturPajak_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FakturPajak_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.VAT)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VAT)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Dealer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Dealer)
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
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedBy)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Vehicle_id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
