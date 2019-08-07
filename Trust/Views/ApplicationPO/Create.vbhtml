@ModelType Trust.Tr_ApplicationPO
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Application PO</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(x) x.ProspectCustomerDetail_ID)
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.No_Ref, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.No_Ref, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CompanyName, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.CompanyName, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Qty, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Qty, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Vehicle, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.OTR_Price_Cal, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.OTR_Price_CalStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Discount_Cal, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Discount_CalStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    </div>
                </div>
            </div>
        </div>



        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.QtyAppPO, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.QtyAppPO, New With {.htmlAttributes = New With {.class = "form-control price"}})
                        @Html.ValidationMessageFor(Function(model) model.QtyAppPO, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Color, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Color, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Color, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Delivery_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Delivery_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Delivery_Date, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Usage, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Usage, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Usage, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Refund, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Refund, New With {.htmlAttributes = New With {.class = "form-control price"}})
                        @Html.ValidationMessageFor(Function(model) model.Refund, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PaymentByUser, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PaymentByUser, New With {.htmlAttributes = New With {.class = "form-control price"}})
                        @Html.ValidationMessageFor(Function(model) model.PaymentByUser, "", New With {.class = "text-danger"})
                    </div>
                </div>

            </div>
            <div class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Plat_Location_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Plat_Location_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Plat_Location_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Plat_Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Plat_Status", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Plat_Status, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Note1, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Note1, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Note1, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Note2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Note2, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Note2, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Aksesoris, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Aksesoris, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Aksesoris, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Comment, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.TextAreaFor(Function(model) model.Comment, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Comment, "", New With {.class = "text-danger"})
                    </div>
                </div>

            </div>
        </div>    
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Dealer_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Dealer_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.OTR_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.OTR_Price, New With {.htmlAttributes = New With {.class = "form-control price"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Discount, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Discount, New With {.htmlAttributes = New With {.class = "form-control price"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.RadioButtonFor(Function(model) model.Status, "Verbal", New With {.htmlAttributes = New With {.class = "form-control"}}) Verbal
                @Html.RadioButtonFor(Function(model) model.Status, "Written", New With {.htmlAttributes = New With {.class = "form-control"}}) Written
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <a id="addToList" class="btn btn-primary">Add To List</a>
            </div>
        </div>
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Dealer</th>
                            <th>OTR Price</th>
                            <th>Discount</th>
                            <th>Status</th>
                            <th>IsChecked</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="button" value="Create" id="saveOrder" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List Process", "IndexProcess")
</div>
@Section Scripts
    <script>
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
        //Cleare Detail
        function clearItem() {
            $("#OTR_Price").val('');
            $("#Discount").val('');
        }

        //Add Multiple Order.
        $("#addToList").click(function (e) {
            e.preventDefault();

            if ($.trim($("#OTR_Price").val()) == "") return;
            var detailsTableBody = $("#detailsTable tbody"),
                Dealer_ID = $("#Dealer_ID option:selected").val(),
                Dealer_Name = $("#Dealer_ID option:selected").text(),
                OTR_Price = $("#OTR_Price").val(),
                Discount = $("#Discount").val(),
                Status = $("#Status").val(),
                Validate = false

            $.each($("#detailsTable tbody tr"), function () {
                if ($(this).find('td:eq(0)').attr('id') == Dealer_ID) {
                    alert("Dealer, Has been add to list");
                    Validate = true;
                }
            });
            if (Validate)
                return;
            var productItem = '<tr><td id="' + Dealer_ID + '">' + Dealer_Name + '</td><td>' + OTR_Price +
                '</td><td>' + Discount + '</td><td>' + Status + '</td><td><input type="radio" name="IsChecked" value="' + Dealer_ID + '"></td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
            detailsTableBody.append(productItem);
            clearItem();
        });

        $(document).on('click', 'a.deleteItem', function (e) {
            e.preventDefault();
            var $self = $(this);
            if ($(this).attr('data-itemId') == "0") {
                $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
                    $(this).remove();
                });
            }
        });

        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("Create")",
                data: data,
                success: function (data) {
                    if (data.result) {
                        alert("Success! ApplicationPO Is Complete!");
                        window.location.href = '@Url.Action("IndexProcess")'
                    } else { alert(data.messages)}
                },
                error: function () {
                    alert("Error!");
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
                    Dealer_ID: $(this).find('td:eq(0)').attr('id'),
                    OTR_Price: Number($(this).find('td:eq(1)').html().replace(/,/g, "")),
                    Discount: Number($(this).find('td:eq(2)').html().replace(/,/g, "")),
                    Status: $(this).find('td:eq(3)').html(),
                    IsChecked: $(this).find('input:eq(0):checked').prop('checked')
                });
            });
            orderHD.push({
                ProspectCustomerDetail_ID: ($("#ProspectCustomerDetail_ID").val() === undefined) ? false : $("#ProspectCustomerDetail_ID").val(),
                QtyAppPO: ($("#QtyAppPO").val() === "") ? 0 : $("#QtyAppPO").val(),
                Color: ($("#Color").val() === "") ? "" : $("#Color").val(),
                Delivery_Date: ($("#Delivery_Date").val() === "") ? "" : $("#Delivery_Date").val(),
                Usage: ($("#Usage").val() === "") ? "" : $("#Usage").val(),
                Refund: ($("#Refund").val() === "") ? 0 : $("#Refund").val().replace(/,/g, ""),
                PaymentByUser: ($("#PaymentByUser").val() === "") ? 0 : $("#PaymentByUser").val().replace(/,/g, ""),
                Plat_Location_ID: ($("#Plat_Location_ID").val() === "") ? 0 : $("#Plat_Location_ID").val(),
                Plat_Status: ($("#Plat_Status").val() === "") ? "" : $("#Plat_Status").val(),
                Note1: ($("#Note1").val() === "") ? "" : $("#Note1").val(),
                Note2: ($("#Note2").val() === "") ? "" : $("#Note2").val(),
                Aksesoris: ($("#Aksesoris").val() === "") ? "" : $("#Aksesoris").val(),
                Comment: ($("#Comment").val() === "") ? "" : $("#Comment").val(),
                Detail: orderArr
            });
            var data = JSON.stringify({
                orderHD: orderHD
            });
            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
    </script>
End Section
