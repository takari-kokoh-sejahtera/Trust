@ModelType Trust.Tr_Quotation
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Quotation</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Quotation_ID)
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
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
                @Html.LabelFor(Function(model) model.Company, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Company, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Company, "", New With {.class = "text-danger"})
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
            @For Each x In ViewBag.detail
                @<tr id="@IIf(x.IsDeleted = Nothing, "False", "True")"><td><input type="checkbox" id="@x.Calculate_ID" /></td><td id="@x.QuotationDetail_ID">@x.IsVehicleExists</td><td>@x.Brand_Name</td><td>@x.Vehicle</td><td>@x.Lease_price</td><td>@x.Qty</td><td>@x.Year</td><td>@x.Lease_long</td><td>@x.Amount</td><td>@x.Bid_PricePerMonth</td></tr>
            Next
        </tbody>
    </table>
    <hr />
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
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
            @Html.EditorFor(Function(model) model.IsDriver, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.IsDriver, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.DriverQty, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DriverQty, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.DriverQty, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.DriverAmount, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DriverAmountStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
            @Html.ValidationMessageFor(Function(model) model.DriverAmount, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" id="saveOrder" value="Save" class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        $(document).ready(function () {
            $("#detailsTable tbody tr").each(function () {
                if ($(this).attr('id') == 'True') {
                    $(this).find("input[type=checkbox]").attr("checked", true);
                }
            });
        });

        //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("EditOrder", "Quotation")",
                data: data,
                success: function (result) {
                    if (result != "Error") {
                        alert("Success! Quotation Is Complete!\n" + result);
                        window.location.href = '@Url.Action("Index", "Quotation")'
                    } else { alert("Error! Quotation Is Not Complete!")}
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
                //if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        Calculate_ID: $(this).find('input:eq(0)').attr('id'),
                        QuotationDetail_ID: $(this).find('td:eq(1)').attr('id'),
                        Check: $(this).find('input:eq(0)').prop('checked')
                    });
                //}
            });

            var data = JSON.stringify({
                Quotation_ID: ($("#Quotation_ID").val() === "") ? 0 : $("#Quotation_ID").val(),
                Remark: ($("#Remark").val() === "") ? "" : $("#Remark").val(),
                Quotation_Validity: ($("#Quotation_Validity").val() === "") ? 0 : $("#Quotation_Validity").val(),
                IsDriver: ($("#IsDriver:checked").val() === undefined) ? false : $("#IsDriver:checked").val(),
                DriverQty: ($("#DriverQty").val() === "") ? 0 : $("#DriverQty").val(),
                DriverAmount: ($("#DriverAmountStr").val().replace(/,/g, "") === "") ? 0 : $("#DriverAmountStr").val().replace(/,/g, ""),
                order: orderArr
            });

            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });



        function number_format(number, decimals) {
            var decPoint = ".", thousandsSep = ","
            decimals = decimals || 0;
            number = parseFloat(number);

            if (!decPoint || !thousandsSep) {
                decPoint = '.';
                thousandsSep = ',';
            }

            var roundedNumber = Math.round(Math.abs(number) * ('1e' + decimals)) + '';
            var numbersString = decimals ? roundedNumber.slice(0, decimals * -1) : roundedNumber;
            var decimalsString = decimals ? roundedNumber.slice(decimals * -1) : '';
            var formattedNumber = "";

            while (numbersString.length > 3) {
                formattedNumber += thousandsSep + numbersString.slice(-3)
                numbersString = numbersString.slice(0, -3);
            }

            return (number < 0 ? '-' : '') + numbersString + formattedNumber + (decimalsString ? (decPoint + decimalsString) : '');
        }
    </script>


End Section
