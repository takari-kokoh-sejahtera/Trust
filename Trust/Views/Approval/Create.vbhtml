@ModelType Trust.Tr_Approval
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(model) model.Approval_ID)
    @<div class="form-horizontal">
        <h4>Approval</h4>
        <hr />
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IsExistsStr, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.EditorFor(Function(model) model.IsExistsStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        @Html.ValidationMessageFor(Function(model) model.IsExistsStr, "", New With {.class = "text-danger"})
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
                @If Session("Role_ID") <> 8 Then
                    @<div Class="form-group">
                        @Html.LabelFor(Function(model) model.PIC_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                            @Html.ValidationMessageFor(Function(model) model.PIC_Name, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    @<div Class="form-group">
                        @Html.LabelFor(Function(model) model.PIC_Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            @Html.EditorFor(Function(model) model.PIC_Phone, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                            @Html.ValidationMessageFor(Function(model) model.PIC_Phone, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    @<div Class="form-group">
                        @Html.LabelFor(Function(model) model.PIC_Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div Class="col-md-10">
                            @Html.EditorFor(Function(model) model.PIC_Email, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                            @Html.ValidationMessageFor(Function(model) model.PIC_Email, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                End If
            </div>
        </div>
        <hr />
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Is Used Car</th>
                            <th style="background-color: #d1fff6;">Transaction Type</th>
                            <th>Brand Name</th>
                            <th>Vehicle</th>
                            <th>Year</th>
                            <th>Qty</th>
                            <th>Lease Term</th>
                            <th style="background-color: #d1fff6;">Bid Price PerMonth</th>
                            <th>Rent Location</th>
                            <th>Plat Location</th>
                            <th>OTR Price</th>
                            <th>Diskon</th>
                            <th style="background-color: #d1fff6;">Net</th>
                            <th>Depresiasi Percent</th>
                            <th style="background-color: #d1fff6;">Residual Value Percent</th>
                            <th>Residual Value</th>
                            <th style="background-color: #d1fff6;">STNK</th>
                            <th style="background-color: #d1fff6;">Replacement</th>
                            <th style="background-color: #d1fff6;">Maintenance Percent</th>
                            <th style="background-color: #d1fff6;">Insurance Percent</th>
                            <th>Expedition Cost</th>
                            <th>Modification</th>
                            <th>GPS Cost</th>
                            <th>Agent Fee</th>
                            <th>KIR</th>
                            <th>IRR</th>
                            <th>Profit</th>
                            <th style="background-color: #d1fff6;">Spread</th>
                            <th>Funding Rate</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyid">
                        @For Each x In ViewBag.detail
                            @If (x.IsDeleted <> Nothing) Then
                                @<tr>
                                    <td style="white-space:nowrap" id="@x.QuotationDetail_ID">@x.IsVehicleExists</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@x.Transaction_Type</td>
                                    <td style="white-space:nowrap">@x.Brand_Name</td>
                                    <td style="white-space:nowrap">@x.Vehicle</td>
                                    <td style="white-space:nowrap">@x.Year</td>
                                    <td style="white-space:nowrap">@x.Qty</td>
                                    <td style="white-space:nowrap">@x.Lease_long</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Bid_PricePerMonth)</td>
                                    <td style="white-space:nowrap">@x.Rent_Location</td>
                                    <td style="white-space:nowrap">@x.Plat_Location</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.OTR_Price)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Update_Diskon)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Net)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Depresiasi_Percent)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Residual_ValuePercent)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Residual_Value)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.STNK)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Replacement)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Maintenance_Percent)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Assurance_Percent)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Expedition_Cost)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Modification)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.GPS_Cost)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Agent_Fee)</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Keur)</td>
                                    <td style="white-space:nowrap">@x.IRR</td>
                                    <td style="white-space:nowrap">@String.Format("{0:n}", x.Profit)</td>
                                    <td style="white-space:nowrap;background-color: #d1fff6;">@x.Spread</td>
                                    <td style="white-space:nowrap">@x.Funding_Rate</td>
                                </tr>
                            End If
                        Next
                    </tbody>
                </table>
            </div>

        </div>

        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.CreatedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CreatedBy, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Quotation_Validity, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Quotation_Validity, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.RemarkQuotation, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.RemarkQuotation, htmlAttributes:=New With {.Class = "form-control", .readonly = "readonly"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.RemarkInternal, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.RemarkInternal, htmlAttributes:=New With {.Class = "form-control", .readonly = "readonly"})
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Approve" class="btn btn-success" onclick="return confirm('Are you sure wants to Approve?');" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input id="notApprove" type="button" value="Not Approve" class="btn btn-warning" onclick="return confirm('Are you sure wants to Not Approve?');" />
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        $("#notApprove").click(function () {
            $.ajax({
                url: '@Url.Action("NotApprove", "Approval")?Approval_ID=' + @Model.Approval_ID + '&val=' + $("#Remark").val(),
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        alert("Success");
                        window.location.href = "@Url.Action("Index", "Approval")";
                    }
                    if (data.success == "false") {
                        alert(data.error);
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        });
    </script>
End Section
