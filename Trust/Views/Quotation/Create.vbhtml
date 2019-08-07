@ModelType Trust.Tr_Quotation
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Quotation</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ProspectCustomer_ID, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("ProspectCustomer_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ProspectCustomer_ID, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.CompanyGroup_Name, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.City, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.City, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.City, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Phone, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Phone, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PIC_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.PIC_Name, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PIC_Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PIC_Phone, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.PIC_Phone, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PIC_Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PIC_Email, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.PIC_Email, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="button" id="selected" value="Select All" class="btn btn-default" />
        </div>
    </div>

    <table id="detailsTable" class="table">
        <thead>
            <tr>
                <th style="width:5%">Select</th>
                <th style="width:5%">Used Car</th>
                <th style="width:15%">Brand Name</th>
                <th style="width:15%">Vehicle</th>
                <th style="width:10%">Lease Price</th>
                <th style="width:5%">Qty</th>
                <th style="width:5%">Year</th>
                <th style="width:10%">Lease Term</th>
                <th style="width:15%">Amount</th>
                <th style="width:15%">Bid PricePerMonth</th>
            </tr>
        </thead>
        <tbody id="tbodyid">
            @*@For Each x In ViewBag.detail
                    @<tr><td>@x.IsVehicleExists</td><td id=@x.VehicleExists_ID>@x.license_no</td><td id=@x.Brand_ID>@x.Brand_Name</td><td id=@x.Model_ID>@x.Type</td><td>@x.Lease_price</td> <td>@x.Qty</td><td>@x.Year</td> <td>@x.Lease_long</td> <td><a data-itemId=@x.ProspectCustomerDetail_ID href="#" Class="deleteItem">Remove</a></td></tr>
                Next*@
        </tbody>
    </table>
    <hr />
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Signer_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("Signer_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.Signer_ID, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.RemarkInternal, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.RemarkInternal, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.RemarkInternal, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Quotation_Validity, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Quotation_Validity, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Quotation_Validity, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.IsDriver, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="checkbox">
                @Html.EditorFor(Function(model) model.IsDriver, New With {.htmlAttributes = New With {.id = "IsDriver"}})
                @Html.ValidationMessageFor(Function(model) model.IsDriver, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.DriverQty, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DriverQty, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
            @Html.ValidationMessageFor(Function(model) model.DriverQty, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.DriverAmount, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DriverAmountStr, New With {.htmlAttributes = New With {.class = "form-control price", .disabled = "disabled"}})
            @Html.ValidationMessageFor(Function(model) model.DriverAmount, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" id="saveOrder" value="Create" class="btn btn-default" />
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
        function clearHeader() {
            $("#CompanyGroup_Name")[0].value = "";
            $("#Company_Name")[0].value = "";
            $("#Address")[0].value = "";
            $("#City")[0].value = "";
            $("#Phone")[0].value = "";
            $("#Email")[0].value = "";
            $("#PIC_Name")[0].value = "";
            $("#PIC_Phone")[0].value = "";
            $("#PIC_Email")[0].value = "";
        };
        $("#ProspectCustomer_ID").change(function () {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("FillCustomer", "Quotation")?val=' + t,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    clearHeader();
                    $("#tbodyid").empty();
                    if (data.success == "true") {
                        $("#CompanyGroup_Name")[0].value = data.CompanyGroup_Name;
                        $("#Company_Name")[0].value = data.Company_Name;
                        $("#Address")[0].value = data.Address;
                        $("#City")[0].value = data.City;
                        $("#Phone")[0].value = data.Phone;
                        $("#Email")[0].value = data.Email;
                        $("#PIC_Name")[0].value = data.PIC_Name;
                        $("#PIC_Phone")[0].value = data.PIC_Phone;
                        $("#PIC_Email")[0].value = data.PIC_Email;

                        var detailsTableBody = $("#detailsTable tbody");
                        $.each(data.Detail, function (i, data) {
                            var productItem = '<tr><td><input type="checkbox"  id="' + data.Calculate_ID + '"/></td><td>' + data.IsVehicleExists + '</td><td>' + data.Brand_Name + '</td><td>' + data.Vehicle + '</td><td>' + number_format(data.Lease_price) + '</td><td>' + data.Qty + '</td><td>' + data.Year + '</td><td>' + data.Lease_long + '</td><td>' + number_format(data.Amount) + '</td><td>' + number_format(data.Bid_PricePerMonth) + '</td></tr>';
                            detailsTableBody.append(productItem);
                        });

                        //detailsTableBody = $("#detailsTable tbody");

                        //var productItem = '<tr><td>' + true + '</td><td id="' + vehicleid + '">' + vehicle + '</td><td></td><td></td><td></td><td></td><td></td><td>' + long + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                        //detailsTableBody.append(productItem);


                    }
                },
                error: function () {
                    alert("error");
                }
            });
        });
        $("#selected").click(function () {
            selected();
        });

        function selected() {
            var stat;
            if ($("#selected").val() == "Select All") {
                stat = true;
                $("#selected").attr('value', "Unselect All");
            } else {
                stat = false;
                $("#selected").prop('value', "Select All");
            }
            $.each($("#detailsTable tbody tr"), function () {
                $(this).find('input:eq(0)').prop('checked', stat);
                
            });


        }

                //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("SaveOrder", "Quotation")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Quotation Is Complete!");
                        window.location.href = '@Url.Action("Index", "Quotation")'
                    } else { alert(data.message);}
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

            $.each($("#detailsTable tbody tr"), function () {
                if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        Calculate_ID: $(this).find('input:eq(0)').attr('id')
                    });
                }
            });

            var data = JSON.stringify({
                ProspectCustomer_ID: ($("#ProspectCustomer_ID").val() === "") ? 0 : $("#ProspectCustomer_ID").val(),
                Remark: ($("#Remark").val() === "") ? "" : $("#Remark").val(),
                RemarkInternal: ($("#RemarkInternal").val() === "") ? "" : $("#RemarkInternal").val(),
                Quotation_Validity: ($("#Quotation_Validity").val() === "") ? 0 : $("#Quotation_Validity").val(),
                IsDriver: ($("#IsDriver:checked").val() === undefined) ? false : $("#IsDriver:checked").val(),
                DriverQty: ($("#DriverQty").val() === "") ? 0 : $("#DriverQty").val(),
                DriverAmount: ($("#DriverAmountStr").val().replace(/,/g, "") === "") ? 0 : $("#DriverAmountStr").val().replace(/,/g, ""),
                Signer_ID: ($("#Signer_ID").val() === "") ? 0 : $("#Signer_ID").val(),
                order: orderArr
            });

            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
        $("#IsDriver").change(function (e) {
            var i = true
            if ($("#IsDriver:checked").val() == "true") {
                i = true;
            }
            else { i = false; }
            document.getElementById("DriverQty").disabled = !i;
            document.getElementById("DriverAmountStr").disabled = !i;
            $("#DriverQty").val('');
            $("#DriverAmountStr").val('');
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
