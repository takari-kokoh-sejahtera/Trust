@ModelType Trust.Tr_Invoice
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Create Invoice</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Contract_ID)
    @Html.HiddenFor(Function(model) model.Customer_ID)
    <div class="form-group">
        @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Penerima, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Penerima, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Jabatan, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Jabatan, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>

    <div class="form-group">
        @Html.Label("Contract", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.RadioButtonFor(Function(x) x.Status, "Contract", New With {.htmlAttributes = New With {.class = "form-control"}})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("BSTK", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.RadioButtonFor(Function(x) x.Status, "BSTK", New With {.htmlAttributes = New With {.class = "form-control"}})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Costum", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.RadioButtonFor(Function(x) x.Status, "Costum", New With {.htmlAttributes = New With {.class = "form-control"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.From_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.From_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.From_Date, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Signature_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Signature_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Signature_Name, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Signature_Title, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Signature_Title, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Signature_Title, "", New With {.class = "text-danger"})
        </div>
    </div>
    <table id="detailsTable" class="table">
        <thead>
            <tr>
                <th></th>
                <th>Brand Name</th>
                <th>Type</th>
                <th>License No</th>
                <th>Lease Term</th>
                <th>BidPricePerMonth</th>
            </tr>
        </thead>
        <tbody id="tbodyid">
            @For Each x In ViewBag.detail
                @<tr id="@x.ContractDetail_ID"><td style="white-space:nowrap"><input type="checkbox" checked /></td><td style="white-space:nowrap">@x.Brand_Name</td><td style="white-space:nowrap">@x.Type</td><td style="white-space:nowrap" id="@x.Vehicle_ID">@x.license_no</td><td style="white-space:nowrap">@x.Lease_long</td><td style="white-space:nowrap">@String.Format("{0:n}", x.Bid_PricePerMonth)</td></tr>
            Next
        </tbody>
    </table>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Save" id="save" class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        function CekDate(value) {

            var i = true
            if (value != "Costum") {
                document.getElementById("From_Date").disabled = i;
            } else {
                document.getElementById("From_Date").disabled = !i;
            }

            $("#From_Date").val(undefined);
            var i = true
            if (value == "Contract") {
                var headerArr = [];
                headerArr.length = 0;

                headerArr.push({
                    Contract_ID: $("#Contract_ID").val()
                });

                var data = JSON.stringify({
                    orderHeader: headerArr
                });

                return $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: "@Url.Action("GetDateContract", "CreateInvoice")",
                    data: data,
                    success: function (data) {
                        if (data.result != "Error") {
                            $('#From_Date').val(data.CreatedDate);
                        } else { alert(data.message)}
                    },
                    error: function () {
                        alert("Error!")
                    }
                });
            }
            else if (value == "BSTK") {
                var orderArr = [];
                orderArr.length = 0;

                $.each($("#detailsTable tbody tr"), function () {
                    if ($(this).find('input:eq(0)').prop('checked')) {
                        orderArr.push({
                            ContractDetail_ID: $(this).attr('id')
                        });
                    }
                });

                var data = JSON.stringify({
                    order: orderArr
                });

                return $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: "@Url.Action("GetDateBSTK", "CreateInvoice")",
                    data: data,
                    success: function (data) {
                        if (data.result != "Error") {
                            $('#From_Date').val(data.CreatedDate);
                        } else { $("#From_Date").val(undefined);}
                    },
                    error: function () {
                        alert("Error!")
                    }
                });
            }

        };
        $(':radio[name=Status]').change(function () {
            // read the value of the selected radio
            var value = $(this).val();
            CekDate(value);
        });

        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("EditData", "CreateInvoice")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Create Invoice Is Complete!\n" + data.result);
                        window.location.href = '@Url.Action("Index", "CreateInvoice")'
                    } else { alert(data.message)}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#save").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;
            var headerArr = [];
            headerArr.length = 0;
            if ($("#Approval_ID").val() == "") { return;}
            $.each($("#detailsTable tbody tr"), function () {
                if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        ContractDetail_ID: $(this).attr('id'),
                        Vehicle_ID: $(this).find('td:eq(3)').attr('id'),
                        Amount: Number($(this).find('td:eq(5)').html().replace(/,/g, "")),
                        Lease_Long: $(this).find('td:eq(4)').html()
                    });
                }
            });
            //Masukin Header di Module
            headerArr.push({
                Contract_ID: $("#Contract_ID").val(),
                Customer_ID: $("#Customer_ID").val(),
                Status: $("#Status").val(),
                From_Date: $("#From_Date").val(),
                Signature_Name: $("#Signature_Name").val(),
                Signature_Title: $("#Signature_Title").val()
            });

            var data = JSON.stringify({
                orderHeader: headerArr,
                order: orderArr
            });

            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
    </script>
End Section