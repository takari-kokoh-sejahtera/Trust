@ModelType Trust.Tr_ProspectCust
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Prospect Customer</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})


        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IsExists, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        <div class="checkbox">
                            @Html.EditorFor(Function(model) model.IsExists, New With {.htmlAttributes = New With {.id = "isexists"}})
                            @Html.ValidationMessageFor(Function(model) model.IsExists, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Customer Exists", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownListFor(Function(model) model.CustomerExists_ID, CType(ViewBag.CustomerExists_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "customer", .disabled = "true"})
                        @Html.ValidationMessageFor(Function(model) model.CustomerExists_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CompanyGroup_ID, "Company Group", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownListFor(Function(model) model.CompanyGroup_ID, CType(ViewBag.CompanyGroup_ID, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "company"})
                        @Html.ValidationMessageFor(Function(model) model.CompanyGroup_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Compay Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-2">

                        @Html.DropDownListFor(Function(model) model.PT, CType(ViewBag.PT, SelectList), "--", htmlAttributes:=New With {.class = "form-control", .id = "pt"})
                        @Html.ValidationMessageFor(Function(model) model.PT, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-5">
                        @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .id = "company_name"}})
                        @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-3">
                        @Html.DropDownListFor(Function(model) model.Tbk, CType(ViewBag.Tbk, SelectList), "--", htmlAttributes:=New With {.class = "form-control", .id = "tbk"})
                        @Html.ValidationMessageFor(Function(model) model.Tbk, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control", .id = "address"}})
                        @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.City_id, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownListFor(Function(model) model.City_id, CType(ViewBag.City_id, SelectList), "Please select", htmlAttributes:=New With {.class = "form-control", .id = "City_id"})
                        @Html.ValidationMessageFor(Function(model) model.City_id, "", New With {.class = "text-danger"})
                    </div>
                </div>


            </div>
            <div class="col-md-6">

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Phone, New With {.htmlAttributes = New With {.class = "form-control", .id = "phone"}})
                        @Html.ValidationMessageFor(Function(model) model.Phone, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control", .id = "email"}})
                        @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control", .id = "pic_name"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Phone, New With {.htmlAttributes = New With {.class = "form-control", .id = "pic_phone"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Phone, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Email, New With {.htmlAttributes = New With {.class = "form-control", .id = "pic_email"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Email, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Credit_Rating, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Credit_Rating", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Credit_Rating, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </div>
        </div>
        <hr />
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
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.Label("OTR Price", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.Editor("Lease_price", New With {.htmlAttributes = New With {.class = "form-control price", .id = "Lease_price"}})
                        @Html.ValidationMessage("Lease_price", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Qty", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.Editor("Qty", New With {.htmlAttributes = New With {.class = "form-control", .id = "Qty"}})
                        @Html.ValidationMessage("Qty", "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Year", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.Editor("Year", New With {.htmlAttributes = New With {.class = "form-control", .id = "Year"}})
                        @Html.ValidationMessage("Year", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.Label("Lease Term", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.Editor("Lease_long", New With {.htmlAttributes = New With {.class = "form-control", .id = "Lease_long"}})
                        @Html.CheckBox("IsMultiCalculated", New With {.htmlAttributes = New With {.id = "IsVehicleExists"}}) Multi Cal
                        @Html.ValidationMessage("Lease_long", "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="col-md-1">
                    <a id="addToList" class="btn btn-primary">Add To List</a>
                </div>
            </div>
        </div>
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Type</th>
                            <th>Is Used Car</th>
                            <th>Used Car</th>
                            <th>Brand</th>
                            <th>Model</th>
                            <th>IsJakarta</th>
                            <th>Lease Price</th>
                            <th>Qty</th>
                            <th>Year</th>
                            <th>Lease Term</th>
                            <th>MultiCal</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>

        <hr />
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Status", Nothing, New With {.htmlAttributes = New With {.class = "form-control", .id = "Status"}})
                        @Html.ValidationMessageFor(Function(model) model.Status, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.ProspectCategory_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("ProspectCategory_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.ProspectCategory_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.DateTrans, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.DateTrans, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.DateTrans, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.DateTransTime, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.DateTransTime, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.DateTransTime, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Notes, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Notes, New With {.htmlAttributes = New With {.class = "form-control", .id = "notes"}})
                        @Html.ValidationMessageFor(Function(model) model.Notes, "", New With {.class = "text-danger"})
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" id="saveOrder" value="Create" class="btn btn-default" />
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
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
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

        $("#isexists").change(function (e) {
            var i = true
            if ($("#isexists:checked").val() == "true") {
                i = true;
            }
            else { i = false; }
            document.getElementById("customer").disabled = !i;
            document.getElementById("company").disabled = i;
            document.getElementById("company_name").disabled = i;
            document.getElementById("pt").disabled = i;
            document.getElementById("tbk").disabled = i;
            document.getElementById("address").disabled = i;
            document.getElementById("City_id").disabled = i;
            document.getElementById("phone").disabled = i;
            document.getElementById("email").disabled = i;
            document.getElementById("pic_name").disabled = i;
            document.getElementById("pic_phone").disabled = i;
            document.getElementById("pic_email").disabled = i;
            document.getElementById("Credit_Rating").disabled = i;
            
        });

        function CheckMultiCalculate() {
            $("#Lease_long")[0].value = "12";
        };

        $("#IsMultiCalculated").change(function (e) {
            CheckMultiCalculate();
        });

        function EnabledVehicle() {
            var type = $("#Transaction_Type")[0].value;
            var i = true
            if ($("#IsVehicleExists:checked").val() == "true") {
                i = true;
            }
            else { i = false; }
            document.getElementById("VehicleExists_ID").disabled = !i;
            document.getElementById("Brand_ID").disabled = i;
            document.getElementById("Model_ID").disabled = i;
            document.getElementById("IsJakarta").disabled = i;
            //document.getElementById("Lease_price").disabled = false;
            document.getElementById("Qty").disabled = i;
            document.getElementById("Year").disabled = i;
            //CheckMultiCalculate();
        };

        $('#Transaction_Type').change(function () {
            EnabledVehicle();
        });

        $("#IsVehicleExists").change(function (e) {
            EnabledVehicle();
        });

        $("#Model_ID").change(function (e) {
            ModelPrice();
        });
        $("#IsJakarta").change(function (e) {
            ModelPrice();
        });
        //$("#Qty").change(function (e) {
        //    ModelPrice();
        //});
        function ModelPrice() {
            if ($("#IsJakarta").val() == "True" && document.getElementById("IsVehicleExists").checked == false) { document.getElementById("Lease_price").disabled = true; }
            else { document.getElementById("Lease_price").disabled = false; return; }

            //if ($("#Model_ID").val() == "" || $("#Qty").val() == "") { return; }
            if ($("#Model_ID").val() == "" ) { return; }
            var t = $("#Model_ID").val();
            $.ajax({
                url: '@Url.Action("GetModelPrice", "Prospect")?ID=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    //$("#Lease_price").val(number_format(data.Price * Number($("#Qty").val())));
                    $("#Lease_price").val(number_format(data.Price));
                },
                error: function () {
                    alert("error");
                }
            });
        }

        //Cleare Detail
        function clearItem() {
            //$("#Lease_price").val('');
            //$("#Qty").val('');
            $("#Year").val('');
            $("#Lease_long").val('');
            document.getElementById("IsMultiCalculated").checked = false;
        }
        //Add Multiple Order.
        $("#addToList").click(function (e) {
            e.preventDefault();
            if ($("#IsVehicleExists:checked").val() == "true") {
                if ($.trim($("#VehicleExists_ID").val()) == "" || $("#Transaction_Type").val() == "" || $("#Lease_long").val() == "" || !$.isNumeric($("#Lease_long").val()) || $("#Lease_price").val() == "" || !$.isNumeric($("#Lease_price").val().replace(/,/g, ""))) return;
                var vehicle = $("#VehicleExists_ID option:selected").text(),
                    long = $("#Lease_long").val(),
                    price = $("#Lease_price").val(),
                    vehicleid = $("#VehicleExists_ID option:selected").val(),
                    Type = $("#Transaction_Type option:selected").val(),
                    detailsTableBody = $("#detailsTable tbody"),
                    IsMultiCalculated = $("#IsMultiCalculated:checked").val();

                var productItem = '<tr><td>' + Type + '</td><td>' + true + '</td><td id="' + vehicleid + '">' + vehicle + '</td><td></td><td></td><td></td><td>' + price + '</td><td></td><td></td><td>' + long + '</td><td>' + IsMultiCalculated + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                detailsTableBody.append(productItem);
                clearItem();
            }
            else {
                if ($.trim($("#Brand_ID").val()) == "" || $("#Transaction_Type").val() == "" || $.trim($("#Model_ID").val()) == "" || $("#IsJakarta").val() == "" || $.trim($("#Lease_price").val()) == "" || !$.isNumeric(Number($("#Lease_price")[0].value.replace(/,/g, ""))) || $.trim($("#Qty").val()) == "" || !$.isNumeric($("#Qty").val()) || $.trim($("#Year").val()) == "" || !$.isNumeric($("#Year").val()) || $.trim($("#Lease_long").val()) == "" || !$.isNumeric($("#Lease_long").val())) return;
                var brand = $("#Brand_ID option:selected").text(),
                    Type = $("#Transaction_Type option:selected").val(),
                    brandid = $("#Brand_ID option:selected").val(),
                    model = $("#Model_ID option:selected").text(),
                    modelid = $("#Model_ID option:selected").val(),
                    price = $("#Lease_price").val(),
                    qty = $("#Qty").val(),
                    year = $("#Year").val(),
                    long = $("#Lease_long").val(),
                    detailsTableBody = $("#detailsTable tbody"),
                    IsJakarta = $("#IsJakarta").val(),
                    IsMultiCalculated = $("#IsMultiCalculated:checked").val();


                var productItem = '<tr><td>' + Type + '</td><td>' + false + '</td><td></td><td id="' + brandid + '">' + brand + '</td><td id="' + modelid + '">' + model + '</td><td>' + IsJakarta + '</td><td>' + price + '</td><td>' + qty + '</td><td>' + year + '</td><td>' + long + '</td><td>' + IsMultiCalculated + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                detailsTableBody.append(productItem);
                clearItem();
            }
        });
        //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("SaveOrder", "Prospect")",
                data: data,
                success: function (data) {
                    if (data.result == "Success") {
                        alert("Success! Prospect Customer Is Complete!");
                        window.location.href = '@Url.Action("Index", "Prospect")'
                    } else { alert(data.messages)}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#saveOrder").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;
            var orderHD = [];
            orderHD.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                orderArr.push({
                    Transaction_Type: $(this).find('td:eq(0)').html(),
                    IsVehicleExists: $(this).find('td:eq(1)').html(),
                    VehicleExists_ID: $(this).find('td:eq(2)').attr('id'),
                    Brand_ID: $(this).find('td:eq(3)').attr('id'),
                    Model_ID: $(this).find('td:eq(4)').attr('id'),
                    IsJakarta: $(this).find('td:eq(5)').html(),
                    Lease_price: Number($(this).find('td:eq(6)').html().replace(/,/g, "")),
                    Qty: $(this).find('td:eq(7)').html(),
                    Year: $(this).find('td:eq(8)').html(),
                    Lease_long: $(this).find('td:eq(9)').html(),
                    IsMultiCalculated: $(this).find('td:eq(10)').html()
                });
            });
            orderHD.push({
                IsExists: ($("#isexists:checked").val() === undefined) ? false : $("#isexists:checked").val(),
                CustomerExists_ID: ($("#customer").val() === "") ? 0 : $("#customer").val(),
                CompanyGroup_ID: ($("#company").val() === "") ? 0 : $("#company").val(),
                Company_Name: ($("#company_name").val() === undefined) ? "" : $("#company_name").val(),
                PT: ($("#pt").val() === undefined) ? "" : $("#pt").val(),
                Tbk: ($("#tbk").val() === undefined) ? false : $("#tbk").val(),
                Address: ($("#address").val() === undefined) ? "" : $("#address").val(),
                City_id: ($("#City_id").val() === "") ? 0 : $("#City_id").val(),
                Phone: ($("#phone").val() === undefined) ? "" : $("#phone").val(),
                Email: ($("#email").val() === undefined) ? "" : $("#email").val(),
                PIC_Name: ($("#pic_name").val() === undefined) ? "" : $("#pic_name").val(),
                PIC_Phone: ($("#pic_phone").val() === undefined) ? "" : $("#pic_phone").val(),
                PIC_Email: ($("#pic_email").val() === undefined) ? "" : $("#pic_email").val(),
                Credit_Rating: ($("#Credit_Rating").val() === "") ? "" : $("#Credit_Rating").val(),
                Status: $("#Status").val(),
                ProspectCategory_ID: $("#ProspectCategory_ID").val(),
                DateTrans: $("#DateTrans").val(),
                DateTransTime: $("#DateTransTime").val(),
                Notes: ($("#Notes").val() === undefined) ? "" : $("#Notes").val()
            });
            var data = JSON.stringify({
                orderHD: orderHD,
                order: orderArr
            });
            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
        // After Add A New Order In The List, If You Want, You Can Remove It.
        $(document).on('click', 'a.deleteItem', function (e) {
            e.preventDefault();
            var $self = $(this);
            if ($(this).attr('data-itemId') == "0") {
                $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
                    $(this).remove();
                });
            }
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
    </script>
End Section