@ModelType Trust.Tr_ApplicationOTR
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Application</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.Calculate_ID)
        @Html.HiddenFor(Function(model) model.Premium)
        @Html.HiddenFor(Function(model) model.OJK)
        @Html.HiddenFor(Function(model) model.SwapRate)
        @Html.HiddenFor(Function(model) model.Project_Rating)

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
                        @Html.CheckBox("IsVehicleExists", Nothing, htmlAttributes:=New With {.id = "IsVehicleExists", .disabled = "disabled"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Brand", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Brand_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(x) x.Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Type, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
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
                    @Html.LabelFor(Function(x) x.Lease_price, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Lease_price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
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
                        @Html.ValidationMessageFor(Function(model) model.Transaction_Type, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Rent Location", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Rent_Location_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Rent_Location_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Plat Nomer", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Plat_Location", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Plat_Location, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(x) x.PayMonth, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("PayMonth", Nothing, htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.PayMonth, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Payment Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Payment_Condition", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Payment_Condition, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(x) x.Term_Of_Payment, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Term_Of_Payment", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Term_Of_Payment, "", New With {.class = "text-danger"})
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
                        @Html.ValidationMessageFor(Function(model) model.Modification, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.GPS_Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-6">
                        @Html.EditorFor(Function(model) model.GPS_Cost, New With {.htmlAttributes = New With {.class = "form-control price", .id = "GPS_Cost", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.GPS_Cost, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                    <div class="col-md-3">
                        @Html.DropDownList("GPS_CostPerMonth", Nothing, htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Agent_Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-6">
                        @Html.EditorFor(Function(model) model.Agent_Fee, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Agent_Fee", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Agent_Fee, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("/", htmlAttributes:=New With {.class = "control-label col-md-1"})
                    <div class="col-md-3">
                        @Html.DropDownList("Agent_FeePerMonth", Nothing, htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
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
                    @Html.LabelFor(Function(model) model.Expedition_Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Expedition_Status", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Expedition_Status, "", New With {.class = "text-danger"})
                    </div>
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
                        @Html.EditorFor(Function(model) model.Up_Front_Fee_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Up_Front_Fee_Percent, "", New With {.class = "text-danger"})
                    </div>
                    @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Other, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Other, New With {.htmlAttributes = New With {.class = "form-control price", .id = "Other", .readonly = "readonly"}})
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
                        @Html.EditorFor(Function(model) model.Efektif_Date, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Efektif_Date, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Expec_Delivery_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Expec_Delivery_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Expec_Delivery_Date, "", New With {.class = "text-danger"})
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
                        @Html.EditorFor(Function(model) model.Lease_Profit_Percent, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
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
            </div>
        </div>
        <hr />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-12">
                <input type="submit" value="Save" id="save" class="btn btn-default" />
            </div>
        </div>
    </div>      End Using

<div>
    @Html.ActionLink("Back to List", "IndexOTR")
</div>
@Section Scripts
    <script>
        ////Load
        $(document).ready(function () {
            $("#total")[0].value = $.number($("#total")[0].value,2);
            $("#Lease_price")[0].value = $.number($("#Lease_price")[0].value, 2);
            $("#Modification")[0].value = $.number($("#Modification")[0].value, 2);
            $("#GPS_Cost")[0].value = $.number($("#GPS_Cost")[0].value, 2);
            $("#Agent_Fee")[0].value = $.number($("#Agent_Fee")[0].value, 2);
            $("#Residual_Value")[0].value = $.number($("#Residual_Value")[0].value, 2);
            $("#Expedition_Cost")[0].value = $.number($("#Expedition_Cost")[0].value, 2);
            $("#Keur")[0].value = $.number($("#Keur")[0].value, 2);
            $("#Cost_Price")[0].value = $.number($("#Cost_Price")[0].value, 2);
            $("#Up_Front_Fee")[0].value = $.number($("#Up_Front_Fee")[0].value, 2);
            $("#Other")[0].value = $.number($("#Other")[0].value, 2);
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
            $("#Profit")[0].value = $.number($("#Profit")[0].value, 2);
            if (!$('#IsVehicleExists').is(':checked') && $("#Transaction_Type")[0].value == "OPL") { $("#Residual_ValuePercent").prop("readonly", true); } else { $("#Residual_ValuePercent").prop("readonly", false); }

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

        });
                //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("EditData", "Application")",
                data: data,
                success: function (result) {
                    if (result == "Success") {
                        alert("Success! EditOTR Is Complete!");
                        window.location.href = '@Url.Action("IndexOTR", "Application")'
                    } else { alert("Error! EditOTR Is Not Complete!")}
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
                Application_ID: ($("#Calculate_ID").val() === "") ? 0 : $("#Calculate_ID").val(),
                Rent_Location_ID: ($("#Rent_Location_ID").val() === "") ? 0 : $("#Rent_Location_ID").val(),
                Plat_Location: ($("#Plat_Location").val() === "") ? 0 : $("#Plat_Location").val(),
                PayMonth: $("#PayMonth").val(),
                Payment_Condition: ($("#Payment_Condition").val() === "") ? "" : $("#Payment_Condition").val(),
                Term_Of_Payment: ($("#Term_Of_Payment").val() === "") ? "" : $("#Term_Of_Payment").val(),

                Modification: ($("#Modification").val() === "") ? 0 : $("#Modification").val().replace(/,/g, ""),
                GPS_Cost: ($("#GPS_Cost").val() === "") ? 0 : $("#GPS_Cost").val().replace(/,/g, ""),
                GPS_CostPerMonth: ($("#GPS_CostPerMonth").val() === "") ? 0 : $("#GPS_CostPerMonth").val().replace(/,/g, ""),
                Agent_Fee: ($("#Agent_Fee").val() === "") ? 0 : $("#Agent_Fee").val().replace(/,/g, ""),
                Agent_FeePerMonth: ($("#Agent_FeePerMonth").val() === "") ? 0 : $("#Agent_FeePerMonth").val().replace(/,/g, ""),

                Update_OTR: ($("#Update_OTR").val() === "") ? 0 : $("#Update_OTR").val().replace(/,/g, ""),

                Residual_Value: ($("#Residual_Value").val() === "") ? 0 : $("#Residual_Value").val().replace(/,/g, ""),
                Residual_ValuePercent: ($("#Residual_ValuePercent").val() === "") ? 0 : $("#Residual_ValuePercent").val().replace(/,/g, ""),
                Expedition_Status: ($("#Expedition_Status").val() === "") ? "" : $("#Expedition_Status").val(),
                Expedition_Cost: ($("#Expedition_Cost").val() === "") ? 0 : $("#Expedition_Cost").val().replace(/,/g, ""),
                Keur: ($("#Keur").val() === "") ? 0 : $("#Keur").val().replace(/,/g, ""),

                Update_Diskon: ($("#Update_Diskon").val() === "") ? 0 : $("#Update_Diskon").val().replace(/,/g, ""),
                Cost_Price: ($("#Cost_Price").val() === "") ? 0 : $("#Cost_Price").val().replace(/,/g, ""),
                Up_Front_Fee: ($("#Up_Front_Fee").val() === "") ? 0 : $("#Up_Front_Fee").val().replace(/,/g, ""),
                Up_Front_Fee_Percent: ($("#Up_Front_Fee_Percent").val() === "") ? 0 : $("#Up_Front_Fee_Percent").val().replace(/,/g, ""),

                Other: ($("#Other").val() === "") ? 0 : $("#Other").val().replace(/,/g, ""),
                Efektif_Date: ($("#Efektif_Date").val() === "") ? undefined : $("#Efektif_Date").val(),
                Expec_Delivery_Date: ($("#Expec_Delivery_Date").val() === "") ? undefined : $("#Expec_Delivery_Date").val(),
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
                Premium: ($("#Premium").val() === "") ? 0 : $("#Premium").val(),
                OJK: ($("#OJK").val() === "") ? 0 : $("#OJK").val(),
                SwapRate: ($("#SwapRate").val() === "") ? 0 : $("#SwapRate").val(),
                Project_Rating: ($("#Project_Rating").val() === "") ? "" : $("#Project_Rating").val(),
                IRR: ($("#IRR").val() === "") ? 0 : $("#IRR").val().replace(/,/g, ""),
                Funding_Rate: ($("#Funding_Rate").val() === "") ? 0 : $("#Funding_Rate").val().replace(/,/g, ""),
                Spread: ($("#Spread").val() === "") ? 0 : $("#Spread").val().replace(/,/g, ""),
                Profit: ($("#Profit").val() === "") ? 0 : $("#Profit").val().replace(/,/g, "")
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
        //Clear Type
        function changeCity() {
            if ($('#Rent_Location_ID').val() == "" || $('#Model_ID').val() == "" || $('#Transaction_Type').val() == "" || $('#Expedition_Status').val() == "") { return;}
            var rent = $('#Rent_Location_ID').val();
            var Expedition_Status = $('#Expedition_Status').val();
            var model = $("#Model_ID option:selected").val();
            var vehicleExists = $("#IsVehicleExists").prop("checked")
            var Transaction_Type = $('#Transaction_Type').val();
            $("#Replacement_Percent")[0].value = "";
            $("#Maintenance_Percent")[0].value = "";
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
                data: data;
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
        }

        //cascading City, To get Expedition
        $('#Model_ID').change(function () {
            changeCity();
        });
        $('#Rent_Location_ID').change(function () {
            changeCity();
        });
        //cascading City, To get Expedition
        $('#Expedition_Status').change(function () {
            changeCity();
        });

        ////Clear Type
        //function cleartype() {
        //    $("#Replacement")[0].value = "";
        //    $("#Maintenance")[0].value = "";
        //    $("#STNK")[0].value = "";
        //    $("#Overhead")[0].value = "";
        //    $("#Assurance")[0].value = "";
        //    $("#Spread")[0].value = "";
        //    $("#Bid_Price")[0].value = "";
        //    $("#Replacement_Percent")[0].value = "";
        //    $("#Maintenance_Percent")[0].value = "";
        //    $("#STNK_Percent")[0].value = "";
        //    $("#Overhead_Percent")[0].value = "";
        //    $("#Assurance_Percent")[0].value = "";
        //    $("#Spread_Percent")[0].value = "";
        //}
        //Clear Expedisi

        //Calculate
        function calculate() {
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
            var Total =
                //Cost
                (((Number($("#Replacement")[0].value.replace(/,/g, "")) + Number($("#Maintenance")[0].value.replace(/,/g, "")) + Number($("#STNK")[0].value.replace(/,/g, "")) + Number($("#Overhead")[0].value.replace(/,/g, "")) + (Number($("#GPS_Cost")[0].value.replace(/,/g, "")) / Number($("#GPS_CostPerMonth")[0].value))) * (Number($("#lama")[0].value) / 12))
                //Fix Cost
                + Number($("#Assurance")[0].value.replace(/,/g, "")) + Number($("#Depresiasi")[0].value.replace(/,/g, "")) + Number($("#Expedition_Cost")[0].value.replace(/,/g, "")) + Number($("#Modification")[0].value.replace(/,/g, "")) 
                //Interest
                + (Number($("#Funding_Interest")[0].value.replace(/,/g, "")))
                    + Number($("#Other")[0].value.replace(/,/g, "")));

            var leaseRent = ((Total * (1 / 98 * 100)) / Number($("#lama")[0].value)) + Number($("#Lease_Profit")[0].value.replace(/,/g, "")) / Number($("#lama")[0].value);
            $("#Bid_PricePerMonth")[0].value = $.number(Math.ceil(leaseRent / 1000) * 1000);

            var Expedition_Status = $("#Expedition_Status")[0].value;
            var PayMonth = $("#PayMonth")[0].value;
            var Cost_Price = Number($("#Cost_Price")[0].value.replace(/,/g, ""));
            var DP = Number($("#Up_Front_Fee")[0].value.replace(/,/g, ""));
            var Replacement = Number($("#Replacement")[0].value.replace(/,/g, ""));
            var Maintenance = Number($("#Maintenance")[0].value.replace(/,/g, ""));
            var STNK = Number($("#STNK")[0].value.replace(/,/g, ""));
            var Overhead = Number($("#Overhead")[0].value.replace(/,/g, ""));
            //var Insurance = Number($("#Assurance")[0].value.replace(/,/g, "")) / (Number($("#lama")[0].value) / 12);
            var Insurance = Number($("#Assurance")[0].value.replace(/,/g, ""));
            var Price_Month = Number($("#Bid_PricePerMonth")[0].value.replace(/,/g, ""));
            var RV = Number($("#Residual_Value")[0].value.replace(/,/g, ""));
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
            $.ajax({
                url: '@Url.Action("FillIRR", "Calculate")?Expedition_Status=' + Expedition_Status + '&PayMonth=' + PayMonth + '&Cost_Price=' + Cost_Price + '&DP=' + DP + '&Replacement=' + Replacement + '&Maintenance=' + Maintenance + '&STNK=' + STNK + '&Overhead=' + Overhead + '&Insurance=' + Insurance + '&Price_Month=' + Price_Month + '&RV=' + RV + '&lama=' + lama + '&Expedition_Cost=' + Expedition_Cost + '&type=' + type + '&Payment=' + Payment + '&Term_Of_Payment=' + Term_Of_Payment + '&Modification=' + Modification + '&GPS_Cost=' + GPS_Cost + '&GPS_CostPerMonth=' + GPS_CostPerMonth + '&Agent_Fee=' + Agent_Fee + '&Agent_FeePerMonth=' + Agent_FeePerMonth + '&Other=' + Other + '&Keur=' + Keur + '&Funding_Rate=' + Funding_Rate,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        $("#IRR")[0].value = $.number(data.irr,2);
                        $("#Spread")[0].value = $.number(Number(data.irr) - Number($("#Funding_Rate")[0].value), 2);
                        $("#Profit")[0].value = $.number(data.Profit, 2);
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
        @*//fill Type
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
    </script>
End Section