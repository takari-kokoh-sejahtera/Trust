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
    @Html.HiddenFor(Function(model) model.Replacement_Percent_Before)
    @Html.HiddenFor(Function(model) model.Maintenance_Percent_Before)
    @Html.HiddenFor(Function(model) model.STNK_Percent_Before)
    @Html.HiddenFor(Function(model) model.Assurance_Percent_Before)
    @Html.HiddenFor(Function(model) model.Update_DiskonSystem)
    @*@Html.HiddenFor(Function(model) model.Project_Rating)*@
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Credit_Rating, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Credit_Rating", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Credit_Rating, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Project_Rating, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Project_Rating, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Project_Rating, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Transaction_Type", CType(ViewBag.Transaction_Type, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "Transaction_Type"})
                    @Html.ValidationMessage("Transaction_Type", "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Is Used Car", htmlAttributes:=New With {.class = "control-label col-md-2"})
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
                @Html.LabelFor(Function(model) model.IsJakarta, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("IsJakarta", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.IsJakarta, "", New With {.class = "text-danger"})
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
            <div class="form-group">
                @Html.LabelFor(Function(model) model.New_Vehicle_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.New_Vehicle_Price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.New_Vehicle_Price, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Location_Vehicle_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Location_Vehicle_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                    @Html.ValidationMessageFor(Function(model) model.Location_Vehicle_ID, "", New With {.class = "text-danger"})
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
            @*<div class="form-group">
                    @Html.Label("Amount Price", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextBox("Total", Nothing, htmlAttributes:=New With {.class = "form-control", .id = "total", .readonly = "readonly"})
                    </div>
                </div>*@
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
                @Html.LabelFor(Function(x) x.PayMonth, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("PayMonth", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.PayMonth, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Payment Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Payment_Condition", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Payment_Condition, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(x) x.Term_Of_Payment, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Term_Of_Payment", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Term_Of_Payment, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Expedition_Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Expedition_Status", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Expedition_Status, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Premium, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Premium, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.OJK, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.OJK, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.SwapRate, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.SwapRate, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
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
                    @Html.EditorFor(Function(model) model.Residual_ValuePercent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
                @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
            </div>
            <div class="form-group">
                @Html.Label("Depresiasi", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.Editor("Depresiasi", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
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
                    @Html.EditorFor(Function(model) model.Expedition_Cost, New With {.htmlAttributes = New With {.class = "form-control price", .readonly = "readonly"}})
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
                @Html.LabelFor(Function(x) x.Update_Diskon, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-7">
                    @Html.EditorFor(Function(model) model.Update_Diskon, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Update_Diskon, "", New With {.class = "text-danger"})
                </div>
                @Html.CheckBox("Update_DiskonTick", htmlAttributes:=New With {.class = "col-md-offset-0"})
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
                <div class="col-md-6">
                    @Html.Editor("Replacement", New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement"}})
                </div>
                <div class="col-md-2">
                    @Html.EditorFor(Function(model) model.Replacement_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly", .id = "Replacement_Percent"}})
                    @Html.ValidationMessageFor(Function(model) model.Replacement_Percent, "", New With {.class = "text-danger"})
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
                    @Html.ValidationMessageFor(Function(model) model.Maintenance_Percent, "", New With {.class = "text-danger"})
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
                    @Html.ValidationMessageFor(Function(model) model.STNK_Percent, "", New With {.class = "text-danger"})
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
                @Html.LabelFor(Function(model) model.AssuranceExtra, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.AssuranceExtra, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.AssuranceExtra, "", New With {.class = "text-danger"})
                </div>
            </div>


            <div class="form-group">
                @Html.Label("Lease Profit", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-6">
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
            <br />
            <p id="labelProvit" style="font-size:25px;color:orangered;">Goal seek</p>
            <div class="form-group">
                @Html.Label("Nothing", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Lease Rent / Month", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "PerMonth", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("IRR", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "IRR", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Spread", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "Spread", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("RV", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "RV", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("UpFront Fee", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.RadioButtonFor(Function(x) x.GoalSeek, "UpFrontFee", New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Value", htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.GoalSeekVal, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>
            </div>
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        $('#Replacement_Tick').change(function () {
            var tick = $("#Replacement_Tick").prop("checked");
            if (tick) {
                $("#Replacement_Percent")[0].value = 0;
            } else {
                $("#Replacement_Percent")[0].value = $("#Replacement_Percent_Before")[0].value;
            }
        });
        $('#Maintenance_Tick').change(function () {
            var tick = $("#Maintenance_Tick").prop("checked");
            if (tick) {
                $("#Maintenance_Percent")[0].value = 0;
            } else {
                $("#Maintenance_Percent")[0].value = $("#Maintenance_Percent_Before")[0].value;
            }
        });
        $('#STNK_Tick').change(function () {
            var tick = $("#STNK_Tick").prop("checked");
            if (tick) {
                $("#STNK_Percent")[0].value = 0;
            } else {
                $("#STNK_Percent")[0].value = $("#STNK_Percent_Before")[0].value;
            }
        });
        $('#Assurance_Tick').change(function () {
            var tick = $("#Assurance_Tick").prop("checked");
            if (tick) {
                $("#Assurance_Percent")[0].value = 0;
            } else {
                $("#Assurance_Percent")[0].value = $("#Assurance_Percent_Before")[0].value;
            }
        });

        $("#lama").change(function (e) {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("GetFundingCost", "Calculate")?lama=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#Funding_Interest_Percent")[0].value = data.percent
                },
                error: function () {
                    alert("error");
                }
            });
        });

        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
        $('#Credit_Rating').change(function () {
            FillFixedCost();
            CalVehicleExists();
        })
        $('#lama').change(function () {
            FillFixedCost();
        })
        //$('#Model_ID').change(function () {
        //    FillFixedCost();
        //})

        function FillFixedCost() {
            if ($('#lama').val() == "" || $('#Model_ID').val() == "" || $('#Credit_Rating').val() == "" ) { return;}
            var Lease_long = $('#lama').val();
            var Credit_Rating = $('#Credit_Rating').val();
            var model = $('#Model_ID').val();
            $("#Funding_Rate")[0].value = "";
            $("#Project_Rating")[0].value = "";
            $.ajax({
                url: '@Url.Action("FillCustomerInSimutalion", "Calculate")?model_id=' + model + '&Credit_Rating=' + Credit_Rating + '&Lease_long=' + Lease_long,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#SwapRate")[0].value = data.SwapRate;
                        $("#Premium")[0].value = data.Premium;
                        $("#OJK")[0].value = data.OJK;
                        $("#Funding_Rate")[0].value = data.Funding_Rate;
                        $("#Project_Rating")[0].value = data.Project_Rating;
                        $("#Update_DiskonSystem")[0].value = data.Normal_Disc;
                        if ($("#Update_DiskonTick").prop("checked")) {
                            $("#Update_Diskon")[0].value = number_format($("#Update_DiskonSystem")[0].value);
                            $("#Update_Diskon").prop("readOnly", true)
                        } else {
                            $("#Update_Diskon")[0].value = 0;
                            $("#Update_Diskon").prop("readOnly", false)
                        }
                        $("#Assurance_Percent")[0].value = data.Assurance_Percent;
                        $("#Assurance_Percent_Before")[0].value = data.Assurance_Percent;
                        $("#AssuranceExtra")[0].value = number_format(data.AssuranceExtra);
                        RecVal();
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

        function changeCity() {
            if ($('#Rent_Location_ID').val() == "" || $('#Plat_Location').val() == "" || $('#Model_ID').val() == "" || $('#Transaction_Type').val() == "" || $('#Expedition_Status').val() == "") { return;}
            var rent = $('#Rent_Location_ID').val();
            var plat = $('#Plat_Location').val();
            var Expedition_Status = $('#Expedition_Status').val();
            var model = $("#Model_ID option:selected").text();
            var vehicleExists = $("#IsVehicleExists").prop("checked");
            var Transaction_Type = $('#Transaction_Type').val();
            $("#Replacement_Percent")[0].value = "";
            $("#Maintenance_Percent")[0].value = "";
            //$("#Expedition_Cost")[0].value = "";
            var data = JSON.stringify({
                rent: rent,
                plat: plat,
                model: model,
                Expedition_Status: Expedition_Status,
                IsVehicleExists: vehicleExists,
                Transaction_Type: Transaction_Type
            });
            $.ajax({
                url: '@Url.Action("GetExpredition", "Calculate")',
                data: data,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        var Replacementtick = $("#Replacement_Tick").prop("checked");
                        var Maintenancetick = $("#Maintenance_Tick").prop("checked");
                        if (Replacementtick == false) {
                            $("#Replacement_Percent")[0].value = data.Replacement;
                        }
                        if (Maintenancetick == false) {
                            $("#Maintenance_Percent")[0].value = data.Maintenance;
                        }
                        $("#Replacement_Percent_Before")[0].value = data.Replacement;
                        $("#Maintenance_Percent_Before")[0].value = data.Maintenance;

                        //Jia Plat No Di luar jakarta maka manual
                        if (document.getElementById("IsVehicleExists").checked == false) {
                            if ($('#Plat_Location option:selected').text() == 'Jakarta') { document.getElementById("Expedition_Cost").readOnly = true; }
                            else { document.getElementById("Expedition_Cost").readOnly = false; }
                        }


                        if (document.getElementById("Expedition_Cost").readOnly == true) {
                            $("#Expedition_Cost")[0].value = data.expredisi;
                        };
                        $("#Keur")[0].value = data.keur;
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
        $('#Rent_Location_ID').change(function () {
            changeCity();
        });
        //cascading City, To get Expedition
        $('#Plat_Location').change(function () {
            changeCity();
        });
        $('#Expedition_Status').change(function () {
            changeCity();
        });

        @*//cascading model
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
        });*@

        //Clear Prospect Customer
        function clearItem() {
            $("#Transaction_Type")[0].value = "";
            $("#brand")[0].value = "";
            $("#Model_ID")[0].value = "";
            $("#tahun")[0].value = "";
            $("#lama")[0].value = "";
            $("#harga")[0].value = "";
            $("#qty")[0].value = "";
            //$("#total")[0].value = "";
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
            //$("#Replacement_Percent")[0].value = "";
            $("#Maintenance_Percent")[0].value = "";
            $("#STNK_Percent")[0].value = "";
            $("#Overhead_Percent")[0].value = "";
            $("#Assurance_Percent")[0].value = "";
            $("#Lease_Profit_Percent")[0].value = "";
        }

        function CalVehicleExists() {
            var VehicleExists_ID = $("#VehicleExists_ID")[0].value;
            var Credit_Rating = $("#Credit_Rating")[0].value;
            var vehicleExists = $("#IsVehicleExists").prop("checked");
            var Transaction_Type = $("#Transaction_Type")[0].value;

            if (VehicleExists_ID == "" || Credit_Rating == "" || Transaction_Type == "" || vehicleExists == false) {return;}
            $.ajax({
                url: '@Url.Action("GetVehicleExists", "Calculate")?VehicleExists_ID=' + VehicleExists_ID + '&Credit_Rating=' + Credit_Rating + '&Transaction_Type=' + Transaction_Type,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#tahun")[0].value = "";
                    $("#New_Vehicle_Price")[0].value = "";
                    $('#Brand_ID').val(data.brand_ID);
                    $('#Model_ID').val(data.model_ID);
                    $("#tahun")[0].value = data.year;
                    $("#New_Vehicle_Price")[0].value = data.price;
                    $("#Project_Rating")[0].value = data.ProjekRating;
                },
                error: function () {
                    alert("error");
                }
            });
        };
        $('#VehicleExists_ID').change(function () {
            CalVehicleExists();
        });
        


        //Clear Expedisi
        $('#Model_ID').change(function () {
            FillFixedCost();
            RecVal();
            changeCity();
        })
        $('#Transaction_Type').change(function () {
            EnabledVehicle();
            RecVal();
            changeCity();
        })
        $('#lama').change(function () {
            FillFixedCost();
            RecVal();
        })

        function RecVal() {
            var t = $("#Model_ID")[0].value;
            var type = $("#Transaction_Type")[0].value;
            var vehicleExists = $("#IsVehicleExists").prop("checked")
            var leaselong = $("#lama")[0].value;
            var Project_Rating = $("#Project_Rating")[0].value;
            if (t == "" || leaselong == "" || Project_Rating == "" || type != "OPL" ) {
                return;
            }
            $.ajax({
                url: '@Url.Action("GetRV", "Calculate")?val=' + t + '&type=' + type + '&vehicleExists=' + vehicleExists + '&leaselong=' + leaselong + '&Project_Rating=' + Project_Rating,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var rvReadonly = $("#Residual_ValuePercent").prop("readOnly");
                    $("#Residual_ValuePercent")[0].value = ""
                    if (data.success = 'true' && data.rv != undefined && rvReadonly) {
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
            //changeCity();
            var amount = Number($("#harga")[0].value.replace(/,/g, ""))
            if (Number($("#Update_OTR")[0].value.replace(/,/g, "")) != 0) {
                amount = Number($("#Update_OTR")[0].value.replace(/,/g, ""))
            }
            if (amount == 0) { return; };
            $("#Cost_Price")[0].value = number_format(amount - Number($("#Update_Diskon")[0].value.replace(/,/g, "")));
            $("#Replacement")[0].value = number_format(($("#Replacement_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);

            if (document.getElementById("IsVehicleExists").checked) {
                var hargaBaru = $("#New_Vehicle_Price")[0].value.replace(/,/g, "");
                $("#Maintenance")[0].value = number_format(($("#Maintenance_Percent")[0].value * hargaBaru) / 100);
                $("#STNK")[0].value = number_format((Number($("#STNK_Percent")[0].value) * hargaBaru) / 100);
                $("#Assurance")[0].value = $.number((Number(hargaBaru) + Number($("#Modification")[0].value.replace(/,/g, ""))) * Number($("#lama")[0].value) / 12 * ((Number($("#Assurance_Percent")[0].value) * Math.pow(0.955, Number($("#lama")[0].value) / 12)) / 100), 2);
            }
            else {
                $("#Maintenance")[0].value = number_format(($("#Maintenance_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
                $("#STNK")[0].value = number_format((Number($("#STNK_Percent")[0].value) * amount) / 100);
                $("#Assurance")[0].value = $.number((Number(amount) + Number($("#Modification")[0].value.replace(/,/g, ""))) * Number($("#lama")[0].value) / 12 * ((Number($("#Assurance_Percent")[0].value) * Math.pow(0.955, Number($("#lama")[0].value) / 12)) / 100), 2);
            }
            //$("#Maintenance")[0].value = number_format(($("#Maintenance_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            //$("#STNK")[0].value = number_format((Number($("#STNK_Percent")[0].value) * amount) / 100);
            //$("#Assurance")[0].value = $.number((amount + Number($("#Modification")[0].value.replace(/,/g, ""))) * Number($("#lama")[0].value) / 12 * ((Number($("#Assurance_Percent")[0].value) * Math.pow(0.955, Number($("#lama")[0].value) / 12)) / 100), 2);

            $("#Overhead")[0].value = number_format(($("#Overhead_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Lease_Profit")[0].value = number_format((Number($("#Lease_Profit_Percent")[0].value) * Number($("#Cost_Price")[0].value.replace(/,/g, "")) * Number($("#lama")[0].value)) / 12 /100);
            //$("#Residual_Value")[0].value = number_format(($("#Residual_ValuePercent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Up_Front_Fee")[0].value = number_format(($("#Up_Front_Fee_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            //$("#Depresiasi_Percent")[0].value = number_format(100 - Number($("#Residual_ValuePercent")[0].value) );
            //$("#Depresiasi")[0].value = number_format(($("#Depresiasi_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100);
            $("#Funding_Interest")[0].value = number_format((($("#Funding_Interest_Percent")[0].value * $("#Cost_Price")[0].value.replace(/,/g, "")) / 100) * (Number($("#lama")[0].value)/12));
            //var Total =
            //    //Cost
            //    (((Number($("#Replacement")[0].value.replace(/,/g, "")) + Number($("#Maintenance")[0].value.replace(/,/g, "")) + Number($("#STNK")[0].value.replace(/,/g, "")) + Number($("#Overhead")[0].value.replace(/,/g, "")) + (Number($("#GPS_Cost")[0].value.replace(/,/g, "")) / Number($("#GPS_CostPerMonth")[0].value))) * (Number($("#lama")[0].value) / 12))
            //    //Fix Cost
            //    + Number($("#Assurance")[0].value.replace(/,/g, "")) + Number($("#Depresiasi")[0].value.replace(/,/g, "")) + Number($("#Expedition_Cost")[0].value.replace(/,/g, "")) + Number($("#Modification")[0].value.replace(/,/g, ""))
            //    //Interest
            //    + (Number($("#Funding_Interest")[0].value.replace(/,/g, "")))
            //        + Number($("#Other")[0].value.replace(/,/g, "")));

            //var leaseRent = ((Total * (1 / 98 * 100)) / Number($("#lama")[0].value)) + Number($("#Lease_Profit")[0].value.replace(/,/g, "")) / Number($("#lama")[0].value);
            //$("#Bid_PricePerMonth")[0].value = $.number(Math.ceil(leaseRent / 1000) * 1000);

            var Expedition_Status = $("#Expedition_Status")[0].value;
            var PayMonth = $("#PayMonth")[0].value;
            var Cost_Price = Number($("#Cost_Price")[0].value.replace(/,/g, ""));
            var DP = Number($("#Up_Front_Fee")[0].value.replace(/,/g, ""));
            var DPPercent = Number($("#Up_Front_Fee_Percent")[0].value.replace(/,/g, ""));
            var Replacement = Number($("#Replacement")[0].value.replace(/,/g, ""));
            var Maintenance = Number($("#Maintenance")[0].value.replace(/,/g, ""));
            var STNK = Number($("#STNK")[0].value.replace(/,/g, ""));
            var Overhead = Number($("#Overhead")[0].value.replace(/,/g, ""));
            //var Insurance = Number($("#Assurance")[0].value.replace(/,/g, "")) / (Number($("#lama")[0].value) / 12);
            var Insurance = Number($("#Assurance")[0].value.replace(/,/g, "")) + Number($("#AssuranceExtra")[0].value.replace(/,/g, ""));
            var Price_Month = Number($("#Bid_PricePerMonth")[0].value.replace(/,/g, ""));
            var RV = Number($("#Residual_Value")[0].value.replace(/,/g, ""));
            var RVPercent = Number($("#Residual_ValuePercent")[0].value.replace(/,/g, ""));
            var Expedition_Cost = Number($("#Expedition_Cost")[0].value.replace(/,/g, ""));
            var lama = $("#lama")[0].value;
            var type = $("#Transaction_Type")[0].value;
            var Payment = $("#Payment_Condition")[0].value;
            var Term_Of_Payment = $("#Term_Of_Payment")[0].value;
            var Modification = Number($("#Modification")[0].value.replace(/,/g, ""));
            var GPS_Cost = Number($("#GPS_Cost")[0].value.replace(/,/g, ""));
            var GPS_CostPerMonth = Number($("#GPS_CostPerMonth")[0].value);
            var Agent_Fee = Number($("#Agent_Fee")[0].value.replace(/,/g, ""));
            var Agent_FeePerMonth = Number($("#Agent_FeePerMonth")[0].value);
            var Other = Number($("#Other")[0].value.replace(/,/g, ""));
            var Keur = Number($("#Keur")[0].value.replace(/,/g, ""));
            var Funding_Rate = $("#Funding_Rate")[0].value;

            var Depresiasi = Number($("#Depresiasi")[0].value.replace(/,/g, ""));
            var DepresiasiPercent = Number($("#Depresiasi_Percent")[0].value.replace(/,/g, ""));
            var Funding_Interest = Number($("#Funding_Interest")[0].value.replace(/,/g, ""));
            var GoalSeek = $("input[name=GoalSeek]:checked")[0].value;
            var GoalSeekVal = Number($("#GoalSeekVal")[0].value.replace(/,/g, ""));
            var Lease_Profit = Number($("#Lease_Profit")[0].value.replace(/,/g, ""));
            var Lease_Profit_Percent = Number($("#Lease_Profit_Percent")[0].value);
            var InsuranceReal = Number($("#Assurance")[0].value.replace(/,/g, ""));

            $.ajax({
                url: '@Url.Action("FillIRRGoalSeek", "Calculate")?Expedition_Status=' + Expedition_Status + '&PayMonth=' + PayMonth + '&Cost_Price=' + Cost_Price + '&DP=' + DP + '&DPPercent=' + DPPercent + '&Replacement=' + Replacement + '&Maintenance=' + Maintenance + '&STNK=' + STNK + '&Overhead=' + Overhead + '&Insurance=' + Insurance + '&Price_Month=' + Price_Month + '&RV=' + RV + '&RVPercent=' + RVPercent + '&lama=' + lama + '&Expedition_Cost=' + Expedition_Cost + '&type=' + type + '&Payment=' + Payment + '&Term_Of_Payment=' + Term_Of_Payment + '&Modification=' + Modification + '&GPS_Cost=' + GPS_Cost + '&GPS_CostPerMonth=' + GPS_CostPerMonth + '&Agent_Fee=' + Agent_Fee + '&Agent_FeePerMonth=' + Agent_FeePerMonth + '&Other=' + Other + '&Keur=' + Keur + '&Funding_Rate=' + Funding_Rate + '&Depresiasi=' + Depresiasi + '&DepresiasiPercent=' + DepresiasiPercent + '&Funding_Interest=' + Funding_Interest + '&GoalSeek=' + GoalSeek + '&GoalSeekVal=' + GoalSeekVal + '&Lease_Profit=' + Lease_Profit + '&Lease_Profit_Percent=' + Lease_Profit_Percent + '&InsuranceReal=' + InsuranceReal,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#IRR")[0].value = $.number(data.irr,2);
                        $("#Spread")[0].value = $.number(Number(data.Spread), 2);
                        $("#Profit")[0].value = $.number(data.Profit, 2);
                        $("#Lease_Profit")[0].value = $.number(data.Lease_Profit, 2);
                        $("#Lease_Profit_Percent")[0].value = data.Lease_Profit_Percent;
                        $("#Bid_PricePerMonth")[0].value = $.number(data.Price_Month, 2);
                        $("#Residual_Value")[0].value = $.number(data.RV, 2);
                        $("#Residual_ValuePercent")[0].value = data.RVPercent;
                        $("#Depresiasi")[0].value = $.number(data.Depresiasi, 2);
                        $("#Depresiasi_Percent")[0].value = data.DepresiasiPercent;
                        $("#Up_Front_Fee")[0].value = $.number(data.DP,2);
                        $("#Up_Front_Fee_Percent")[0].value = data.DPPercent;

                        $("input[name=GoalSeek][value='']").prop('checked', true);
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
                        else { document.getElementById("labelProvit").innerHTML = "Best Profit";}
                    }
                    else if (data.success == "false") {
                        alert(data.message)
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
        @*$("#FixCost_ID").change(function () {
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
        });*@

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

        function EnabledVehicle() {
            var type = $("#Transaction_Type")[0].value;
            if (type == 'COP') {
                //$("#IsVehicleExists").prop("checked", false);
                $("#Residual_ValuePercent").prop("readonly", false);

                $("#Replacement_Tick").prop("disabled", false);
                $("#Maintenance_Tick").prop("disabled", false);
                $("#STNK_Tick").prop("disabled", false);
                $("#Assurance_Tick").prop("disabled", false);
            } else {
                $("#Residual_ValuePercent").prop("readonly", true);

                $("#Replacement_Tick").prop("checked", false);
                $("#Replacement_Tick").prop("disabled", true);
                $("#Replacement_Percent")[0].value = $("#Replacement_Percent_Before")[0].value;
                $("#Maintenance_Tick").prop("checked", false);
                $("#Maintenance_Tick").prop("disabled", true);
                $("#Maintenance_Percent")[0].value = $("#Maintenance_Percent_Before")[0].value;
                $("#STNK_Tick").prop("checked", false);
                $("#STNK_Tick").prop("disabled", true);
                $("#STNK_Percent")[0].value = $("#STNK_Percent_Before")[0].value;
                $("#Assurance_Tick").prop("checked", false);
                $("#Assurance_Tick").prop("disabled", true);
                $("#Assurance_Percent")[0].value = $("#Assurance_Percent_Before")[0].value;
            };
            $("#tahun")[0].value = "";
            $("#New_Vehicle_Price")[0].value = "";
            var i = true
            if ($("#IsVehicleExists:checked").val() == "true") {
                i = true;
            }
            else { i = false; }
            document.getElementById("VehicleExists_ID").disabled = !i;
            document.getElementById("Brand_ID").disabled = i;
            document.getElementById("Model_ID").disabled = i;
            document.getElementById("IsJakarta").disabled = i;
            document.getElementById("tahun").disabled = i;
            document.getElementById("Location_Vehicle_ID").disabled = !i;
        };
        $("#IsVehicleExists").change(function (e) {
            EnabledVehicle();
        });

        $("#Model_ID").change(function (e) {
            ModelPrice();
        });
        $("#IsJakarta").change(function (e) {
            ModelPrice();
        });
        //$("#qty").change(function (e) {
        //    ModelPrice();
        //});
        $("#harga").change(function (e) {
            ModelPrice();
        });
        function ModelPrice() {
            if ($("#IsJakarta").val() == "True") { document.getElementById("harga").disabled = true; }
            else {
                document.getElementById("harga").disabled = false;
                //$("#total").val(number_format(Number($("#harga").val().replace(/,/g, "")) * Number($("#qty").val())));
                return;
            }

            //if ($("#Model_ID").val() == "" || $("#qty").val() == "") { return; }
            if ($("#Model_ID").val() == "" ) { return; }
            var t = $("#Model_ID").val();
            $.ajax({
                url: '@Url.Action("GetModelPrice", "Prospect")?ID=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#harga").val(number_format(data.Price));
                    $("#total").val(number_format(data.Price * Number($("#qty").val())));
                },
                error: function () {
                    alert("error");
                }
            });
        };
        $('#Location_Vehicle_ID').change(function () {
            changeCityLocationVehicle();
        });

        function changeCityLocationVehicle() {
            if ($('#Location_Vehicle_ID option:selected').text() == "Jakarta") {
                document.getElementById("Expedition_Cost").readOnly = true;
            } else {
                document.getElementById("Expedition_Cost").readOnly = false;
            }
        };
        $("#Update_DiskonTick").change(function (e) {
            FillFixedCost();
        });

    </script>
End Section