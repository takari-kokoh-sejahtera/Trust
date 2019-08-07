@ModelType Trust.Tr_Contracts
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Contract</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Contract_ID)

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Contract_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Contract_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.Contract_No, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Penerima, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Penerima, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Penerima, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Jabatan, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Jabatan, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Jabatan, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Invoice Payment / Month", htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-8">
            @Html.DropDownList("PerMonth", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.PerMonth, "", New With {.class = "text-danger"})
        </div>
    </div>
    <hr />
    <form id="myform">
        <table id="detailsTable" class="table">
            <thead>
                <tr>
                    <th>Company Name</th>
                    <th>Vehicle</th>
                    <th>Delivery Date</th>
                    <th>Start</th>
                    <th>End</th>
                    <th>Rent Location</th>
                    <th>Lease Term</th>
                    <th>Bid Price PerMonth</th>
                    <th>Remart</th>
                </tr>
            </thead>
            <tbody>
                @For Each x In ViewBag.Detail
                    @<tr>
                        <td id=@x.ContractDetail_ID>@x.Company_Name</td>
                        <td style="white-space:nowrap">@x.Vehicle</td>
                        <td style="white-space:nowrap">
                            @Html.Editor("DeliveryDate", New With {.htmlAttributes = New With {.class = "myTextarea", .type = "date", .Value = x.DeliveryDate}})
                        </td>
                        <td style="white-space:nowrap">
                            @Html.Editor("StartDate", New With {.htmlAttributes = New With {.class = "myTextarea", .type = "date", .Value = x.StartDate}})
                        </td>
                        <td style="white-space:nowrap">
                            @Html.Editor("StartDate", New With {.htmlAttributes = New With {.class = "myTextarea", .type = "date", .Value = x.EndDate}})
                        </td>
                        <td style="white-space:nowrap">@x.Rent_Location</td>
                        <td style="white-space:nowrap">@x.Lease_long</td>
                        <td style="white-space:nowrap">@String.Format("{0:n}", x.Bid_PricePerMonth)</td>
                        <td style = "white-space:nowrap" >
                            <textarea class="myTextarea">@x.Remark</textarea>
                                                                            </td>
                    </tr>
                Next
            </tbody>
        </table>
        <hr />
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" id="saveOrder" value="Save" class="btn btn-default" />
            </div>
        </div>
    </form>
</div>
End Using

                                <div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
dataType: 'json',
type: 'POST',
url: "@Url.Action("EditOrder", "Contract")",
                data: data,
                success: function (data) {
                    if (data.result == "Success") {
                        alert("Success! Contract Is Complete!");
                        window.location.href = '@Url.Action("Index", "Contract")'
                    } else { alert(data.message)}
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
                orderArr.push({
                    ContractDetail_ID:  $(this).find('td:eq(0)').attr('id'),
                    Delivery: $(this).find('td:eq(2)').find('input').val(),
                    Start: $(this).find('td:eq(3)').find('input').val(),
                    Ends: $(this).find('td:eq(4)').find('input').val(),
                    Remark: $(this).find('td:eq(8)').find('textarea').val().trim()
                    //,
                    //VehicleExists_ID: $(this).find('td:eq(2)').attr('id'),
                    //Brand_ID: $(this).find('td:eq(3)').attr('id'),
                    //Model_ID: $(this).find('td:eq(4)').attr('id'),
                    //Lease_price: $(this).find('td:eq(5)').html(),
                    //Qty: $(this).find('td:eq(6)').html(),
                    //Year: $(this).find('td:eq(7)').html(),
                    //Lease_long: $(this).find('td:eq(8)').html()
                });
            });

            var data = JSON.stringify({
                Contract_ID:  $("#Contract_ID").val(),
                Penerima: $("#Penerima").val(),
                Jabatan: $("#Jabatan").val(),
                PerMonth: $("#PerMonth").val(),
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
