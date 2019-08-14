@ModelType Trust.Tr_QuotationPO
@Code
    ViewData("Title") = "Create"
End Code

<h2>Upload SPH and PO</h2>
@Using (Html.BeginForm("FileUpload", "Application", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(x) x.Quotation_ID)
    @<div class="form-horizontal">
        <div class="row">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.No_Ref, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.No_Ref, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.THU, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.THU, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.THU, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Record_For_Payment, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("Record_For_Payment", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Record_For_Payment, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <label for="file">Upload SPH and PO:</label>
                        <input type="file" name="file" id="file" style="width: 100%;" accept="application/pdf,application/vnd.ms-excel" />
                        @Html.ValidationMessage("File", "", New With {.class = "text-danger"})
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <label for="file">Upload IM or Other File:</label>
                        <input type="file" name="file1" id="file1" style="width: 100%;" accept="application/pdf,application/vnd.ms-excel" />
                        @Html.ValidationMessage("File1", "", New With {.class = "text-danger"})
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Check</th>
                            <th>Vehicle</th>
                            <th>Color</th>
                            <th>Price</th>
                            <th>Qty</th>
                            <th>Amount</th>
                            <th>Bid Price / Month</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyid">
                        @For i = 0 To Model.Detail.Count - 1
                            @Html.Hidden("[" + i.ToString + "].Application_ID", Model.Detail(i).Application_ID)
                            @Html.Hidden("[" + i.ToString + "].Vehicle", Model.Detail(i).Vehicle)
                            @Html.Hidden("[" + i.ToString + "].Lease_price", Model.Detail(i).Lease_price)
                            @Html.Hidden("[" + i.ToString + "].Qty", Model.Detail(i).Qty)
                            @Html.Hidden("[" + i.ToString + "].Amount", Model.Detail(i).Amount)
                            @Html.Hidden("[" + i.ToString + "].Bid_Price", Model.Detail(i).Bid_Price)
                            @<tr style="white-space:nowrap">
                                <td style="white-space:nowrap">
                                    @Html.CheckBox("[" + i.ToString + "].Check", Model.Detail(i).Check) @Html.ValidationMessage("[" + i.ToString + "].Check", "", New With {.class = "text-danger"})
                                </td>
                                <td style="white-space:nowrap">
                                    @Model.Detail(i).Vehicle
                                </td>
                                @if Model.Detail(i).IsVehicleExists Then
                                    @<td style="white-space:nowrap">@Html.TextBox("[" + i.ToString + "].Color", Model.Detail(i).Color, New With {.readonly = "readonly"}) @Html.ValidationMessage("[" + i.ToString + "].Color", "", New With {.class = "text-danger"})</td>
                                Else
                                    @<td style="white-space:nowrap">@Html.TextBox("[" + i.ToString + "].Color", Model.Detail(i).Color) @Html.ValidationMessage("[" + i.ToString + "].Color", "", New With {.class = "text-danger"})</td>

                                End If
                                <td style="white-space:nowrap">@String.Format("{0:0,##}", Model.Detail(i).Lease_price)</td>
                                <td style="white-space:nowrap">@Model.Detail(i).Qty</td>
                                <td style="white-space:nowrap">@String.Format("{0:0,##}", Model.Detail(i).Amount)</td>
                                <td style="white-space:nowrap">@String.Format("{0:0,##}", Model.Detail(i).Bid_Price)</td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <input type="submit" value="Upload" class="submit" />
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
    </div>
End Using

@Section Scripts
    <script>
                                                                //$(document).ready(function () {
                                                                //    if ($("#IsVehicleExists").val() == true) {
                                                                //        document.getElementById("Color").disabled = true;
                                                                //    };
                                                                //});
                                                                ////Class Number Format
                                                                //$(".price").priceFormat({
                                                                //    thousamdSeparator: ",",
                                                                //    centsLimit: 0
                                                                //});
    </script>
End Section
