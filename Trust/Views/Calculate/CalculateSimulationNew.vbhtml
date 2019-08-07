@ModelType Trust.Tr_Calculate
@Code
    ViewData("Title") = "CalculateSimulation"
End Code

<h2>Calculate Simulation</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Calculate</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.Label("Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Transaction_Type", CType(ViewBag.Transaction_Type, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "Transaction_Type"})
                        @Html.ValidationMessage("Transaction_Type", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Is Userd Car", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        <div class="checkbox">
                            @Html.CheckBox("IsVehicleExists", New With {.htmlAttributes = New With {.id = "IsVehicleExists"}})
                            @Html.ValidationMessage("IsVehicleExists", "", New With {.class = "text-danger"})
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Used Car", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @*@Html.DropDownList("VehicleExists_ID", CType(ViewBag.VehicleExists_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "VehicleExists_ID", .disabled = "true"})*@
                        <select id="VehicleExists_ID" class="mySelect2 form-control" disabled="True"></select>
                        @Html.ValidationMessage("VehicleExists_ID", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Brand", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Brand_ID", CType(ViewBag.Brand_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "Brand_ID"})
                        @Html.ValidationMessage("Brand_ID", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Model", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Model_ID", CType(ViewBag.Model_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "Model_ID"})
                        @Html.ValidationMessage("Model_ID", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Tahun", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("tahun", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "tahun"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Lease Term", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("lama", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "lama"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Harga Unit", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("harga", Nothing, htmlAttributes:=New With {.class = "form-control price", .id = "harga"})
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.Label("Qty", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("qty", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "qty"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Amount Price", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("Total", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "total", .readonly = "readonly"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Rent Location", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Rent_Location_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Rent_Location_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Plat Nomer", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Plat_Location", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Plat_Location, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Payment Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Payment_Condition", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Payment_Condition, "", New With {.class = "text-danger"})
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
                        @Html.EditorFor(Function(model) model.Modification, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Modification"}})
                        @Html.ValidationMessageFor(Function(model) model.Modification, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.GPS_Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-6">
                        @Html.EditorFor(Function(model) model.GPS_Cost, New With {.htmlAttributes = New With {.class = "form-control price", .id = "GPS_Cost"}})
                        @Html.ValidationMessageFor(Function(model) model.GPS_Cost, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                    <div class="col-md-3">
                        @Html.DropDownList("GPS_CostPerMonth", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Agent_Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-6">
                        @Html.EditorFor(Function(model) model.Agent_Fee, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Agent_Fee"}})
                        @Html.ValidationMessageFor(Function(model) model.Agent_Fee, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                    <div class="col-md-3">
                        @Html.DropDownList("Agent_FeePerMonth", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Update_OTR, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Update_OTR, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Update_OTR"}})
                        @Html.ValidationMessageFor(Function(model) model.Update_OTR, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Residual_Value, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.EditorFor(Function(model) model.Residual_Value, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Residual_Value, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Residual_ValuePercent, New With {.htmlAttributes = New With {.class = "form-control"}})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>
                <div class="form-group">
                    @Html.Label("Depresiasi", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Depresiasi", New With {.htmlAttributes = New With {.class = "form-control price", .readonly = "readonly"}})
                        @Html.ValidationMessage("Depresiasi", "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-2">
                        @Html.Editor("Depresiasi_Percent", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessage("Depresiasi_Percent", "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Expedition_Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Expedition_Cost, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Expedition_Cost, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Keur, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Keur, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Keur, "", New With {.class = "text-danger"})
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.Label("Update Diskon", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Update_Diskon, New With {.htmlAttributes = New With {.class = "form-control price"}})
                        @Html.ValidationMessageFor(Function(model) model.Update_Diskon, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(x) x.Cost_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Cost_Price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Cost_Price, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Up_Front_Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.EditorFor(Function(model) model.Up_Front_Fee, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Up_Front_Fee, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Up_Front_Fee_Percent, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Up_Front_Fee_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Other, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Other, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Other"}})
                        @Html.ValidationMessageFor(Function(model) model.Other, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Funding Interest", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Funding_Interest", New With {.htmlAttributes = New With {.class = "form-control price", .readonly = "readonly"}})
                        @Html.ValidationMessage("Funding_Interest", "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-2">
                        @Html.Editor("Funding_Interest_Percent", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessage("Funding_Interest_Percent", "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("Efektif Date", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Efektif_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Efektif_Date, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-6">
                @*<div class="form-group">
                        @Html.LabelFor(Function(model) model.FixCost_ID, "Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.DropDownListFor(Function(model) model.FixCost_ID, CType(ViewBag.FixCost_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "FixCost_ID"})
                            @Html.ValidationMessageFor(Function(model) model.FixCost_ID, "", New With {.class = "text-danger"})
                        </div>
                    </div>*@
                <div class="form-group">
                    @Html.Label("Replacement", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Replacement", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Replacement_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement_Percent"}})
                        @Html.ValidationMessageFor(Function(model) model.Replacement_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("Maintenance", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Maintenance", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Maintenance"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Maintenance_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Maintenance_Percent"}})
                        @Html.ValidationMessageFor(Function(model) model.Maintenance_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("STNK", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("STNK", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "STNK"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.STNK_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "STNK_Percent"}})
                        @Html.ValidationMessageFor(Function(model) model.STNK_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("Overhead", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Overhead", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Overhead"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Overhead_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Overhead_Percent"}})
                        @Html.ValidationMessageFor(Function(model) model.Overhead_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("Insurance", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Assurance", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Assurance"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Assurance_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Assurance_Percent"}})
                        @Html.ValidationMessageFor(Function(model) model.Assurance_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                <div class="form-group">
                    @Html.Label("Lease Profit", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-7">
                        @Html.Editor("Lease_Profit", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                    <div class="col-md-2">
                        @Html.EditorFor(Function(model) model.Lease_Profit_Percent, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Lease_Profit_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>

                @*<div class="form-group">
                        @Html.Label("Bid Price", htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Bid_Price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                            @Html.ValidationMessageFor(Function(model) model.Bid_Price, "", New With {.class = "text-danger"})
                        </div>
                    </div>*@
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

            </div>
            <div class="col-md-6">
                <p id="labelProvit" style="font-size:50px;color:red;">Normal Profit</p>
                <input type="button" id="cal" value="Calculate" class="btn-success form-control" />

            </div>
        </div>
    </div>  End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        ////Load
        $(document).ready(function () {
            $("#STNK_Percent")[0].value = 1.65;
            $("#Overhead_Percent")[0].value = 2;
            $("#Assurance_Percent")[0].value = 2.1;
            $("#Funding_Rate")[0].value = 9.45;
        });

                //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("CreateData", "Calculate")",
                data: data,
                success: function (result) {
                    if (result == "Success") {
                        alert("Success! Calculate Is Complete!");
                        window.location.href = '@Url.Action("Index", "Calculate")'
                    } else { alert("Error! Calculate Is Not Complete!")}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#save").click(function (e) {
            e.preventDefault();
            calculate();
            var orderArr = [];
            orderArr.length = 0;

            var data = JSON.stringify({
                ProspectCustomerDetail_ID: ($("#ProspectCustomerDetail_ID").val() === "") ? 0 : $("#ProspectCustomerDetail_ID").val(),
                //FixCost_ID: ($("#FixCost_ID").val() === "") ? 0 : $("#FixCost_ID").val(),
                Rent_Location_ID: ($("#Rent_Location_ID").val() === "") ? 0 : $("#Rent_Location_ID").val(),
                Plat_Location: ($("#Plat_Location").val() === "") ? 0 : $("#Plat_Location").val(),
                Payment_Condition: ($("#Payment_Condition").val() === "") ? "" : $("#Payment_Condition").val(),

                Modification: ($("#Modification").val() === "") ? 0 : $("#Modification").val().replace(/,/g, ""),
                GPS_Cost: ($("#GPS_Cost").val() === "") ? 0 : $("#GPS_Cost").val().replace(/,/g, ""),
                GPS_CostPerMonth: ($("#GPS_CostPerMonth").val() === "") ? 0 : $("#GPS_CostPerMonth").val().replace(/,/g, ""),
                Agent_Fee: ($("#Agent_Fee").val() === "") ? 0 : $("#Agent_Fee").val().replace(/,/g, ""),
                Agent_FeePerMonth: ($("#Agent_FeePerMonth").val() === "") ? 0 : $("#Agent_FeePerMonth").val().replace(/,/g, ""),

                Update_OTR: ($("#Update_OTR").val() === "") ? 0 : $("#Update_OTR").val().replace(/,/g, ""),

                Residual_Value: ($("#Residual_Value").val() === "") ? 0 : $("#Residual_Value").val().replace(/,/g, ""),
                Residual_ValuePercent: ($("#Residual_ValuePercent").val() === "") ? 0 : $("#Residual_ValuePercent").val().replace(/,/g, ""),
                Expedition_Cost: ($("#Expedition_Cost").val() === "") ? 0 : $("#Expedition_Cost").val().replace(/,/g, ""),
                Keur: ($("#Keur").val() === "") ? 0 : $("#Keur").val().replace(/,/g, ""),

                Update_Diskon: ($("#Update_Diskon").val() === "") ? 0 : $("#Update_Diskon").val().replace(/,/g, ""),
                Cost_Price: ($("#Cost_Price").val() === "") ? 0 : $("#Cost_Price").val().replace(/,/g, ""),
                Up_Front_Fee: ($("#Up_Front_Fee").val() === "") ? 0 : $("#Up_Front_Fee").val().replace(/,/g, ""),
                Up_Front_Fee_Percent: ($("#Up_Front_Fee_Percent").val() === "") ? 0 : $("#Up_Front_Fee_Percent").val().replace(/,/g, ""),

                Other: ($("#Other").val() === "") ? 0 : $("#Other").val().replace(/,/g, ""),
                Efektif_Date: ($("#Efektif_Date").val() === "") ? undefined : $("#Efektif_Date").val(),
                Replacement_Percent: ($("#Replacement_Percent").val() === "") ? 0 : $("#Replacement_Percent").val(),
                Replacement: ($("#Replacement").val() === "") ? 0 : $("#Replacement").val().replace(/,/g, ""),
                Maintenance_Percent: ($("#Maintenance_Percent").val() === "") ? 0 : $("#Maintenance_Percent").val(),
                Maintenance: ($("#Maintenance").val() === "") ? 0 : $("#Maintenance").val().replace(/,/g, ""),
                STNK_Percent: ($("#STNK_Percent").val() === "") ? 0 : $("#STNK_Percent").val(),
                STNK: ($("#STNK").val() === "") ? 0 : $("#STNK").val().replace(/,/g, ""),
                Overhead_Percent: ($("#Overhead_Percent").val() === "") ? 0 : $("#Overhead_Percent").val(),
                Overhead: ($("#Overhead").val() === "") ? 0 : $("#Overhead").val().replace(/,/g, ""),
                Assurance_Percent: ($("#Assurance_Percent").val() === "") ? 0 : $("#Assurance_Percent").val(),
                Assurance: ($("#Assurance").val() === "") ? 0 : $("#Assurance").val().replace(/,/g, ""),
                Depresiasi_Percent: ($("#Depresiasi_Percent").val() === "") ? 0 : $("#Depresiasi_Percent").val(),
                Depresiasi: ($("#Depresiasi").val() === "") ? 0 : $("#Depresiasi").val().replace(/,/g, ""),
                Funding_Interest_Percent: ($("#Funding_Interest_Percent").val() === "") ? 0 : $("#Funding_Interest_Percent").val(),
                Funding_Interest: ($("#Funding_Interest").val() === "") ? 0 : $("#Funding_Interest").val().replace(/,/g, ""),
                Lease_Profit_Percent: ($("#Lease_Profit_Percent").val() === "") ? 0 : $("#Lease_Profit_Percent").val(),
                Lease_Profit: ($("#Lease_Profit").val() === "") ? 0 : $("#Lease_Profit").val().replace(/,/g, ""),
                Bid_PricePerMonth: ($("#Bid_PricePerMonth").val() === "") ? 0 : $("#Bid_PricePerMonth").val().replace(/,/g, ""),
                IRR: ($("#IRR").val() === "") ? 0 : $("#IRR").val().replace(/,/g, ""),
                Funding_Rate: ($("#Funding_Rate").val() === "") ? 0 : $("#Funding_Rate").val().replace(/,/g, ""),
                Spread: ($("#Spread").val() === "") ? 0 : $("#Spread").val().replace(/,/g, "")
            });

            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
        function changeCity() {
            clearExpedisi();
            if ($('#Rent_Location_ID').val() == "" || $('#Plat_Location').val() == "" || $('#Transaction_Type').val() == "") { return;}
            var rent = $('#Rent_Location_ID').val();
            var plat = $('#Plat_Location').val();
            var type = $('#Transaction_Type').val();
            var model = $("#Model_ID option:selected").text();
            $("#Replacement_Percent")[0].value = "";
            $("#Maintenance_Percent")[0].value = "";
            $("#Expedition_Cost")[0].value = "";
            var data = JSON.stringify({
                rent: rent,
                plat: plat,
                model: model,
                Expedition_Status: Expedition_Status,
                IsVehicleExists: vehicleExists,
                Transaction_Type: Transaction_Type
            });
            $.ajax({
                url: '@Url.Action("GetExpredition", "Calculate")?rent=' + rent + '&plat=' + plat + '&type=' + type + '&model=' + model,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#Replacement_Percent")[0].value = data.Replacement;
                        $("#Maintenance_Percent")[0].value = data.Maintenance;

                        $("#Expedition_Cost")[0].value = data.expredisi;
                    }
                    else if (data.success == "false") {
                    }
                    else { alert("error"); }
                },
                error: function () {
                    alert("error");
                }
            });
        };
        //cascading City, To get Expedition
        $('#Rent_Location_ID').change(function () {
            changeCity();
        });
        //cascading City, To get Expedition
        $('#Plat_Location').change(function () {
            changeCity();
        });

        //cascading model
        $('#ProspectCustomer_ID').change(function () {
            $('#ProspectCustomerDetail_ID option').remove();
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("GetVehicle", "Calculate")?ID=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    clearItem();
                    $("#ProspectCustomerDetail_ID").append('<option value="">Please select</option>');
                    $.each(data, function (i, data) {
                        $("#ProspectCustomerDetail_ID").append('<option value="'
                            + data.Value + '">'
                            + data.Text + '</option>');
                    });
                },
                error: function () {
                    alert("error");
                }
            });
        });

        //Clear Prospect Customer
        function clearItem() {
            $("#Transaction_Type")[0].value = "";
            $("#brand")[0].value = "";
            $("#Model_ID")[0].value = "";
            $("#tahun")[0].value = "";
            $("#lama")[0].value = "";
            $("#harga")[0].value = "";
            $("#qty")[0].value = "";
            $("#total")[0].value = "";
            $("#Residual_ValuePercent")[0].value = "";
            $("#Keur")[0].value = "";
        }
        //Clear Type
        function cleartype() {
            $("#Replacement")[0].value = "";
            $("#Maintenance")[0].value = "";
            $("#STNK")[0].value = "";
            $("#Overhead")[0].value = "";
            $("#Assurance")[0].value = "";
            $("#Lease_Profit")[0].value = "";
            //$("#Bid_Price")[0].value = "";
            $("#Replacement_Percent")[0].value = "";
            $("#Maintenance_Percent")[0].value = "";
            $("#STNK_Percent")[0].value = "";
            $("#Overhead_Percent")[0].value = "";
            $("#Assurance_Percent")[0].value = "";
            $("#Lease_Profit_Percent")[0].value = "";
        }
        //Clear Expedisi
        function clearExpedisi() {
            $("#Expedition_Cost")[0].value = "";
        }
        $('#Model_ID').change(function () {
            RecVal();
        })
        $('#Transaction_Type').change(function () {
            RecVal();
        })
        $('#IsVehicleExists').change(function () {
            RecVal();
        })
        $('#lama').change(function () {
            RecVal();
        })

        function RecVal() {
            var t = $("#Model_ID")[0].value;
            var type = $("#Transaction_Type")[0].value;
            var vehicleExists = $("#IsVehicleExists").prop("checked")
            var leaselong = $("#lama")[0].value;
            if (t == "" || leaselong == "" || type != "OPL") {
                return;
            }
            $.ajax({
                url: '@Url.Action("GetRV", "Calculate")?val=' + t + '&type=' + type + '&vehicleExists=' + vehicleExists + '&leaselong=' + leaselong,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#Residual_ValuePercent")[0].value = ""
                    if (data.success = 'true' && data.rv != undefined) {
                        $("#Residual_ValuePercent")[0].value  = data.rv;
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
        //Clear Type
        function calculate() {
            $("#total")[0].value = Number($("#harga")[0].value.replace(/,/g, "")) * Number($("#qty")[0].value)
            var amount = Number($("#total")[0].value.replace(/,/g, ""))
            if (Number($("#Update_OTR")[0].value.replace(/,/g, "")) != 0) {
                amount = Number($("#Update_OTR")[0].value.replace(/,/g, ""))
            }
            if (amount == 0) { return; };
            $("#Cost_Price")[0].value = number_format(amount - Number($("#Update_Diskon")[0].value.replace(/,/g, "")));
            $("#Replacement")[0].value = number_format(($("#Replacement_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Maintenance")[0].value = number_format(($("#Maintenance_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#STNK")[0].value = number_format((Number($("#STNK_Percent")[0].value) * amount) / 100);
            $("#Overhead")[0].value = number_format(($("#Overhead_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Assurance")[0].value = $.number((amount + Number($("#Modification")[0].value.replace(/,/g, ""))) * Number($("#lama")[0].value) / 12 * ((Number($("#Assurance_Percent")[0].value) * Math.pow(0.955, Number($("#lama")[0].value) / 12))/100),2 );
            $("#Lease_Profit")[0].value = number_format((Number($("#Lease_Profit_Percent")[0].value) * Number($("#Cost_Price")[0].value.replace(/,/g, "")) * Number($("#lama")[0].value)) / 12 /100);
            $("#Residual_Value")[0].value = number_format(($("#Residual_ValuePercent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Up_Front_Fee")[0].value = number_format(($("#Up_Front_Fee_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Depresiasi_Percent")[0].value = number_format(100 - Number($("#Residual_ValuePercent")[0].value) );
            $("#Depresiasi")[0].value = number_format(($("#Depresiasi_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Funding_Interest")[0].value = number_format((($("#Funding_Interest_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100) * (Number($("#lama")[0].value)/12));
            $("#Spread")[0].value = Number($("#Lease_Profit_Percent")[0].value);
            $("#IRR")[0].value = Number($("#Spread")[0].value) + Number($("#Funding_Rate")[0].value);
            var Cost_Price = Number($("#Cost_Price")[0].value.replace(/,/g, ""))
            var lama = $("#lama")[0].value;
            var IRR = $("#IRR")[0].value;
            var RV = Number($("#Residual_Value")[0].value.replace(/,/g, ""));
            $.ajax({
                url: '@Url.Action("PMTProccess", "Calculate")?IRR=' + IRR + '&lama=' + lama + '&Cost_Price=' + Cost_Price + '&Residual_Value=' + RV ,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#Bid_PricePerMonth")[0].value = $.number(data.PerMonth, 2);
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
                    }
                    else if (data.success == "false") {

                    }
                    else { alert("error"); }
                },
                error: function () {
                    alert("error");
                }
            });
        }
        //Calculate button
        $("#cal").click(function () {
            calculate();
        });
        //fill Type
        $("#FixCost_ID").change(function () {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("FillType", "Calculate")?val=' + t,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        cleartype();
                        $("#Replacement_Percent")[0].value = data.repla;
                        $("#Maintenance_Percent")[0].value = data.maintenanc;
                        $("#STNK_Percent")[0].value = data.stn;
                        $("#Overhead_Percent")[0].value = data.overhea;
                        $("#Assurance_Percent")[0].value = data.ass;
                    }
                    else if (data.success == "false") {
                        cleartype();
                    }
                    else { alert("error"); }
                },
                error: function () {
                    alert("error");
                }
            });
        });
        //fill Prospect customer
        $("#ProspectCustomerDetail_ID").change(function () {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("FillCustomer", "Calculate")?val=' + t,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#brand")[0].value = data.brand;
                        if (data.IsVehicleExists) { $("#IsVehicleExists").prop("checked", true); } else { $("#IsVehicleExists").prop("checked", false);}
                        //$("#IsVehicleExists")[0].value = data.IsVehicleExists;
                        $("#Transaction_Type")[0].value = data.Transaction_Type;
                        $("#Model_ID")[0].value = data.model;
                        $("#tahun")[0].value = data.tahun;
                        $("#lama")[0].value = data.lama;
                        $("#harga")[0].value = data.harga;
                        $("#qty")[0].value = data.qty;
                        $("#total")[0].value = data.total;
                        $("#Residual_ValuePercent")[0].value = data.RV;
                        if (data.RV == 0) { $("#Residual_ValuePercent").prop("readonly", false); } else { $("#Residual_ValuePercent").prop("readonly", true ); }
                        $("#Keur")[0].value = data.Keur;
                        $("#Funding_Interest_Percent")[0].value = data.FundingCost;
                    }
                    else if (data.success == "false") {
                        clearItem();
                    }
                    else { alert("error"); }
                },
                error: function () {
                    alert("error");
                }
            });
        });
        function number_format(nStr) {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }
        $(document).ready(function () {
            $(".mySelect2").select2({
                placeholder: "Please Select",
                allowClear: true,
                theme: "classic",
                ajax: {
                    //url: "GetVehicle",
                    url: "@Url.Action("GetVehicle", "Prospect")",
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return { searchTerm: params.term };
                    },
                    processResults: function (data, params) {
                        return { results: data };
                    }

                }
            });
        });
                //cascading model
        $('#Brand_ID').change(function () {
            $('#Model_ID option').remove();
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("GetModel", "Prospect")?ID=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#Model_ID").append('<option>Please select</option>');
                    $.each(data, function (i, data) {
                        $("#Model_ID").append('<option value="'
                            + data.Value + '">'
                            + data.Text + '</option>');
                    });
                },
                error: function () {
                    alert("error");
                }
            });
        });
        $("#IsVehicleExists").change(function (e) {
            var i = true
            if ($("#IsVehicleExists:checked").val() == "true") {
                i = true;
            }
            else { i = false; }
            document.getElementById("VehicleExists_ID").disabled = !i;
            document.getElementById("Brand_ID").disabled = i;
            document.getElementById("Model_ID").disabled = i;
        });
    </script>
End Section