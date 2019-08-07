@ModelType Trust.Tr_Calculates
@Code
    ViewData("Title") = "ModalProspectDetail"
End Code

<h2>ModalProspectDetail</h2>
<div class="form-group">
    @Html.Label("Prospect Customer", htmlAttributes:=New With {.class = "control-label col-md-2"})
    <div class="col-md-10">
        @Html.DropDownList("ProspectCustomer_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
    </div>
</div>

<table id="detailsTable" class="table table-responsive">
    <thead>
        <tr>
            <th>Courier</th>
            <th>Service</th>
            <th>Service</th>
        </tr>
    </thead>
    <tbody>
        @*<tr>
                <td>
                    <div class="radio">
                        <label><input type="radio" id='regular' name="optradio">TIKI</label>
                    </div>
                </td>
                <td>
                    <div class="radiotext">
                        <label for='regular'>Regular Shipping</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="radio">
                        <label><input type="radio" id='express' name="optradio">JNE</label>
                    </div>
                </td>
                <td>
                    <div class="radiotext">
                        <label for='express'>Express Shipping</label>
                    </div>
                </td>
            </tr>*@
    </tbody>
</table>
@Section Scripts
    <script>
        //Cleare Table
        function clearTable() {
            var T = document.getElementById("ProspectCustomer_ID");
            var B = T.getElementsByTagName('tbody');
            var L = B.length;
            while (L) T.removeChild(B[--L]);
        }
        //fillList
        $("#ProspectCustomer_ID").change(function () {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("FillList", "Calculate")?val=' + t,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        clearTable()
                        var detailsTableBody = $("#detailsTable tbody");
                        data.list.forEach(function (x) {
                            var productItem = '<tr><td>' + x.IsVehicleExists + '</td><td>' + x.license_no + '</td><td>' + x.type + '</td></tr>';
                            detailsTableBody.append(productItem);
                        });
                    }
                    else { alert("error"); }
                },
                error: function () {
                    alert("error");
                }
            });
        });
        //Add Multiple Order.
        $("#ProspectCustom").change(function (e) {
            e.preventDefault();
            if ($("#IsVehicleExists:checked").val() == "true") {
                if ($.trim($("#VehicleExists_ID").val()) == "") return;
                var vehicle = $("#VehicleExists_ID option:selected").text(),
                    vehicleid = $("#VehicleExists_ID option:selected").val(),
                    detailsTableBody = $("#detailsTable tbody");

                var productItem = '<tr><td>' + true + '</td><td id="' + vehicleid + '">' + vehicle + '</td><td></td><td></td><td></td><td></td><td></td><td></td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                detailsTableBody.append(productItem);
                clearItem();
            }
            else {
                if ($.trim($("#Brand_ID").val()) == "" || $.trim($("#Model_ID").val()) == "" || $.trim($("#Lease_price").val()) == "" || $.trim($("#Qty").val()) == "" || $.trim($("#Year").val()) == "" || $.trim($("#Lease_long").val()) == "") return;
                var brand = $("#Brand_ID option:selected").text(),
                    brandid = $("#Brand_ID option:selected").val(),
                    model = $("#Model_ID option:selected").text(),
                    modelid = $("#Model_ID option:selected").val(),
                    price = $("#Lease_price").val(),
                    qty = $("#Qty").val(),
                    year = $("#Year").val(),
                    long = $("#Lease_long").val(),
                    detailsTableBody = $("#detailsTable tbody");

                var productItem = '<tr><td>' + false + '</td><td></td><td id="' + brandid + '">' + brand + '</td><td id="' + modelid + '">' + model + '</td><td>' + price + '</td><td>' + qty + '</td><td>' + year + '</td><td>' + long + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                detailsTableBody.append(productItem);
                clearItem();
            }
        });
    </script>
End Section

