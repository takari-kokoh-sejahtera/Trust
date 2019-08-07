@ModelType Trust.Tr_Calculate
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

@Html.AntiForgeryToken()

<div class="form-horizontal">

    <h4>Calculate</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                @Html.LabelFor(Function(x) x.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Vehicle", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Is Used Car", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.CheckBox("IsVehicleExists", htmlAttributes:=New With {.id = "IsVehicleExists", .disabled = "disabled"})
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Brand", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Brand_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Type, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Type, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Tahun", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Year, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Lease Term", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Lease_long, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "lama"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.New_Vehicle_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.New_Vehicle_Price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Location_Vehicle_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Location_Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Project_Rating, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.Editor("Project", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                @Html.Label("Qty", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.TextBox("qty", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "qty", .readonly = "readonly"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Amount Price", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Amount, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "total"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Transaction_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Transaction_Type, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Rent_Location_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Rent_Location_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Plat_Location_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Plat_Location_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.PayMonthStr, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PayMonthStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Payment_Condition, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Payment_Condition, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(x) x.Term_Of_Payment, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Term_Of_PaymentStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Expedition_Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Expedition_Status, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-6">

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Modification, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Modification, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Modification", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.GPS_Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.EditorFor(Function(model) model.GPS_Cost, New With {.htmlAttributes = New With {.class = "form-control price", .id = "GPS_Cost", .readonly = "readonly"}})
                </div>
                @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                <div class="col-md-3">
                    @Html.EditorFor(Function(model) model.GPS_CostPerMonthStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Agent_Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.EditorFor(Function(model) model.Agent_Fee, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Agent_Fee", .readonly = "readonly"}})
                </div>
                @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                <div class="col-md-3">
                    @Html.EditorFor(Function(model) model.Agent_FeePerMonthStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Update_OTR, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Update_OTR, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Update_OTR", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Residual_Value, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.EditorFor(Function(model) model.Residual_Value, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Residual_ValuePercent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>
            <div class="form-group">
                @Html.Label("Depresiasi", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.Editor("Depresiasi", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                <div class="col-md-2">
                    @Html.Editor("Depresiasi_Percent", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Expedition_Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Expedition_Cost, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Keur, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Keur, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

        </div>
        <div class="col-md-6">
            <div class="form-group">
                @Html.Label("Update Diskon", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.EditorFor(Function(model) model.Update_Diskon, New With {.htmlAttributes = New With {.class = "form-control price", .readonly = "readonly"}})
                </div>
                @Html.CheckBox("Update_DiskonTick", htmlAttributes:=New With {.class = "col-md-offset-0", .disabled = "disabled"})
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(x) x.Cost_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Cost_Price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Up_Front_Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.EditorFor(Function(model) model.Up_Front_Fee, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Up_Front_Fee_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Other, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Other, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Other", .readonly = "readonly"}})
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Funding Interest", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.Editor("Funding_Interest", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                <div class="col-md-2">
                    @Html.Editor("Funding_Interest_Percent", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>

            <div class="form-group">
                @Html.Label("Efektif Date", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Efektif_Date, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-6">

            <div class="form-group">
                @Html.Label("Replacement", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("Replacement", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Replacement_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement_Percent"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                @Html.CheckBox("Replacement_Tick", New With {.disabled = "disabled"})
            </div>

            <div class="form-group">
                @Html.Label("Maintenance", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("Maintenance", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Maintenance"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Maintenance_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Maintenance_Percent"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                @Html.CheckBox("Maintenance_Tick", New With {.disabled = "disabled"})
            </div>

            <div class="form-group">
                @Html.Label("STNK", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("STNK", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "STNK"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.STNK_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "STNK_Percent"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                @Html.CheckBox("STNK_Tick", New With {.disabled = "disabled"})
            </div>

            <div class="form-group">
                @Html.Label("Overhead", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("Overhead", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Overhead"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Overhead_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Overhead_Percent"}})
                    @Html.ValidationMessageFor(Function(model) model.Overhead_Percent, "", New With {.class = "text-danger"})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1 left"})
            </div>

            <div class="form-group">
                @Html.Label("Insurance", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("Assurance", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Assurance"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Assurance_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Assurance_Percent"}})
                    @Html.ValidationMessageFor(Function(model) model.Assurance_Percent, "", New With {.class = "text-danger"})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                @Html.CheckBox("Assurance_Tick", New With {.disabled = "disabled"})
            </div>

            <div class="form-group">
                @Html.Label("Lease Profit", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
                    @Html.Editor("Lease_Profit", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Lease_Profit_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Bid_PricePerMonth, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Bid_PricePerMonth, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Bid_PricePerMonth, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.IRR, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-3">
                    @Html.EditorFor(Function(model) model.IRR, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.IRR, "", New With {.class = "text-danger"})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-7"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Funding_Rate, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-3">
                    @Html.EditorFor(Function(model) model.Funding_Rate, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Funding_Rate, "", New With {.class = "text-danger"})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-7"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Spread, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-3">
                    @Html.EditorFor(Function(model) model.Spread, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Spread, "", New With {.class = "text-danger"})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-7"})
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Profit, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Profit, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Profit, "", New With {.class = "text-danger"})
                </div>
            </div>

        </div>
        <div class="col-md-6">
            <p id="labelProvit" style="font-size:50px;color:red;">Normal Profit</p>
            <input type="button" id="cal" value="Calculate" class="btn-success form-control" />
        </div>
    </div>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.Calculate_ID}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
@Section Scripts
    <script>
        $(document).ready(function () {
            $("#total")[0].value = $.number($("#total")[0].value, 2);
            $("#Modification")[0].value = $.number($("#Modification")[0].value, 0);
            $("#GPS_Cost")[0].value = $.number($("#GPS_Cost")[0].value, 0);
            $("#Agent_Fee")[0].value = $.number($("#Agent_Fee")[0].value, 0);
            $("#Update_OTR")[0].value = $.number($("#Update_OTR")[0].value, 0);
            $("#Residual_Value")[0].value = $.number($("#Residual_Value")[0].value, 2);
            $("#Expedition_Cost")[0].value = $.number($("#Expedition_Cost")[0].value, 2);
            $("#Keur")[0].value = $.number($("#Keur")[0].value, 2);
            $("#Update_Diskon")[0].value = $.number($("#Update_Diskon")[0].value, 0);
            $("#Cost_Price")[0].value = $.number($("#Cost_Price")[0].value, 2);
            $("#Up_Front_Fee")[0].value = $.number($("#Up_Front_Fee")[0].value, 2);
            $("#Other")[0].value = $.number($("#Other")[0].value, 0);
            $("#Replacement")[0].value = $.number($("#Replacement")[0].value, 2);
            $("#Maintenance")[0].value = $.number($("#Maintenance")[0].value, 2);
            $("#STNK")[0].value = $.number($("#STNK")[0].value, 2);
            $("#Overhead")[0].value = $.number($("#Overhead")[0].value, 2);
            $("#Assurance")[0].value = $.number($("#Assurance")[0].value, 2);
            $("#Lease_Profit")[0].value = $.number($("#Lease_Profit")[0].value, 2);
            $("#Depresiasi")[0].value = $.number($("#Depresiasi")[0].value, 2);
            $("#Funding_Interest")[0].value = $.number($("#Funding_Interest")[0].value, 2);
            $("#Spread")[0].value = $.number($("#Spread")[0].value, 2);
            $("#Bid_PricePerMonth")[0].value = $.number($("#Bid_PricePerMonth")[0].value, 2);
            $("#New_Vehicle_Price")[0].value = $.number($("#New_Vehicle_Price")[0].value, 2);
            $("#Profit")[0].value = $.number($("#Profit")[0].value, 2);
            //if (!$('#IsVehicleExists').is(':checked') && $("#Transaction_Type")[0].value == "OPL") { $("#Residual_ValuePercent").prop("readonly", true); } else { $("#Residual_ValuePercent").prop("readonly", false); }
            if ($('#IsVehicleExists').is(':checked')) {
                document.getElementById("Location_Vehicle_ID").disabled = false;
                document.getElementById("Expedition_Cost").readOnly = false;
            } else {
                document.getElementById("Location_Vehicle_ID").disabled = true;
                document.getElementById("Expedition_Cost").readOnly = true;
            }
            if ($('#IsVehicleExists').is(':checked')) {
                if ($('#Location_Vehicle_ID option:selected').text() == "Jakarta") {
                    document.getElementById("Expedition_Cost").readOnly = true;
                } else {
                    document.getElementById("Expedition_Cost").readOnly = false;
                }
            }
            if (Number($("#Spread")[0].value) < 1) {
                document.getElementById("labelProvit").innerHTML = "Loss Profit";
            }
            else if (Number($("#Spread")[0].value) < 1.59) {
                document.getElementById("labelProvit").innerHTML = "Low Profit";
            }
            else if (Number($("#Spread")[0].value) < 2.99) {
                document.getElementById("labelProvit").innerHTML = "Normal Profit";
            }
            else if (Number($("#Spread")[0].value) < 5) {
                document.getElementById("labelProvit").innerHTML = "High Profit";
            }
            else { document.getElementById("labelProvit").innerHTML = "Best Profit"; }
            EnabledVehicle();
            if ($("#Update_DiskonTick").prop("checked")) {
                $("#Update_Diskon").prop("readOnly", true)
            } else {
                $("#Update_Diskon").prop("readOnly", false)
            }
        });
    </script>
End Section