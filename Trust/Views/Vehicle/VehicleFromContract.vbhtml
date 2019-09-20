@ModelType Trust.Ms_Vehicle
@Code
    ViewData("Title") = "VehicleFromContract"
End Code

<h2>Input Vehicle</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Vehicle</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(x) x.ApplicationPO_ID)
        @Html.HiddenFor(Function(x) x.Model_ID)
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PO_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PO_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.PO_No, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.CompanyGroup_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.license_no, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.license_no, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.license_no, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Tmp_Plat, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Tmp_Plat, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Tmp_Plat, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Brand_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Brand_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Brand_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Model, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Model, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.color, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.color, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.color, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.year, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.year, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.year, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.chassis_no, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.chassis_no, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.chassis_no, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.machine_no, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.machine_no, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.machine_no, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.comment, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.comment, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.comment, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Dealer, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Dealer, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.Dealer, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.STNK_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.STNK_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.STNK_No, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.STNK_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.STNK_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.STNK_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.STNK_Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.STNK_Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.STNK_Address, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CC, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.CC, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.CC, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Fuel, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Fuel, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Fuel, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.DO_date, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.DO_date, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.DO_date, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Vehicle_Come, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Vehicle_Come, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Vehicle_Come, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.STNK_Receipt, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.STNK_Receipt, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.STNK_Receipt, "", New With {.class = "text-danger"})
                    </div>
                </div>

            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "IndexInputAsset")
</div>
@Section Scripts
    <script>
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });

         function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("VehicleFromContract", "Vehicle")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Create Invoice Is Complete!\n" + data.result);
                        window.location.href = '@Url.Action("IndexInputAsset", "Vehicle")'
                    } else { alert(data.message)}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#Create").click(function (e) {
            e.preventDefault();

             var data = JSON.stringify({
                license_no : $('#license_no').val(),
                Tmp_Plat : $('#Tmp_Plat').val(),
                Model_ID : $('#Model_ID').val(),
                color : $('#color').val(),
                year : $('#year').val(),
                chassis_no : $('#chassis_no').val(),
                machine_no : $('#machine_no').val(),
                comment : $('#comment').val(),
                status : $('#status').val(),
                STNK_No : $('#STNK_No').val(),
                STNK_Name : $('#STNK_Name').val(),
                STNK_Address : $('#STNK_Address').val(),
                CC : $('#CC').val(),
                Fuel : $('#Fuel').val(),
                DO_date : $('#DO_date').val(),
                Vehicle_Come : $('#Vehicle_Come').val(),
                STNK_Receipt : $('#TSTNK_Receipt').val(),
                Dealer : $('#Dealer').val()
              
            });

         
            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
    </script>
End Section