@ModelType Trust.Tr_SetDelivery
@Code
    ViewData("Title") = "Set Delivery"
End Code

<h2>Set Delivery</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Set Delivery</h4>
    <hr />
    @Html.HiddenFor(Function(model) model.Contract_ID)
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="row">
        <div class="col-lg-6">
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
                @Html.LabelFor(Function(model) model.Contract_No, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Contract_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Contract_No, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.DeliveryDate, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.DeliveryDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.DeliveryDate, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Address_Delivery, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.TextAreaFor(Function(model) model.Address_Delivery, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Address_Delivery, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PIC_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.PIC_Name, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.PIC_Number, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.PIC_Number, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.PIC_Number, "", New With {.class = "text-danger"})
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
    <table id="detailsTable" class="table table-hover">
        <thead>
            <tr>
                <th style="white-space:nowrap">Select</th>
                <th style="white-space:nowrap">License No</th>
                <th style="white-space:nowrap">Brand Name</th>
                <th style="white-space:nowrap">Type</th>
                <th style="white-space:nowrap">Color</th>
                <th style="white-space:nowrap">Year</th>
            </tr>
        </thead>
        <tbody id="tbodyid">
            @For Each x In ViewBag.detail
                @<tr><td><input type="checkbox" id=@x.ContractDetail_ID /></td><td style="white-space:nowrap">@x.license_no</td><td>@x.Brand_Name</td><td>@x.Type</td><td>@x.color</td><td>@x.Year</td></tr>
            Next
        </tbody>
    </table>
    <hr />
    <div Class="form-group">
        <div Class="col-md-offset-2 col-md-10">
            <input type="button" id="saveOrder" value="Create" Class="btn btn-default" />
        </div>
    </div>
</div>
End Using

                                                                                    <div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    <script>
                                                                                    
        $("#selected").click(function () {
            selected();
        });

        function selected() {
            var stat;
            if ($("#selected").val() == "Select All") {
                stat = true;
                $("#selected").attr('value', "Unselect All");
            }
            else {
                stat = false;
                $("#selected").prop('value', "Select All");
            }

            $.each($("#detailsTable tbody tr"), function () {
                $(this).find('input:eq(0)').prop('checked', stat);

            });
        }


         function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
dataType: 'json',
type: 'POST',
url: "@Url.Action("SaveOrder", "SetDelivery")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Set Delivery Is Complete!");
                        window.location.href = '@Url.Action("Index", "SetDelivery")'
                    } else { alert(data.message);}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }

        $("#saveOrder").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        ContractDetail_ID:  $(this).find('input:eq(0)').attr('id')
                    });
                }
            });

            var data = JSON.stringify({
                Contract_ID: ($("#Contract_ID").val() === "") ? 0 : $("#Contract_ID").val(),
                DeliveryDate:  ($("#DeliveryDate").val() === "") ? 0 : $("#DeliveryDate").val(),
                Address_Delivery: ($("#Address_Delivery").val() === "") ? "" : $("#Address_Delivery").val(),
                PIC_Name: ($("#PIC_Name").val() === "") ? "" : $("#PIC_Name").val(),
                PIC_Number: ($("#PIC_Number").val() === "") ? "" : $("#PIC_Number").val(),
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