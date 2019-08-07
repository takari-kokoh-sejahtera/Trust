@ModelType Trust.Tr_ApplicationHeader
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Approval</h2>

@Using (Html.BeginForm("Create", "ApprovalApp", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Application</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.ApplicationHeader_ID)
        @Html.HiddenFor(Function(model) model.ApprovalApp_ID)
        @Html.HiddenFor(Function(model) model.Cost_Price)
        @Html.HiddenFor(Function(model) model.Contract_No)
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

        <dim class="row">
            <dim class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IsExists, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        <div class="checkbox">
                            @Html.EditorFor(Function(model) model.IsExists, New With {.htmlAttributes = New With {.disabled = "disabled"}})
                            @Html.ValidationMessageFor(Function(model) model.IsExists, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Credit_Rating, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.DropDownList("Credit_Rating", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Credit_Rating, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Capital, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.EditorFor(Function(model) model.Authorized_CapitalStr, New With {.htmlAttributes = New With {.class = "form-control price", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Capital, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Name1, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Name1, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Name1, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Customer_Class, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.DropDownList("Customer_Class", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Customer_Class, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
            <dim class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Position1, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Position1, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Position1, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Name2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Name2, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Name2, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Position2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Position2, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Position2, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IntroducedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.IntroducedBy, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.IntroducedBy, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
        </dim>

        <div class="row">
            <dim class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Contracted_by, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.DropDownList("Contracted_by", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                        @Html.ValidationMessageFor(Function(model) model.Contracted_by, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Outstanding_Balance_Group, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.EditorFor(Function(model) model.Outstanding_Balance_GroupStr, New With {.htmlAttributes = New With {.class = "form-control price", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Group, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Outstanding_Balance_MUL_Group, htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.EditorFor(Function(model) model.Outstanding_Balance_MUL_GroupStr, New With {.htmlAttributes = New With {.class = "form-control price", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_MUL_Group, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
            <dim class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.RunContractCompany, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.RunContractCompany, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.RunContractCompany, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.RunContractGroup, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.RunContractGroup, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                        @Html.ValidationMessageFor(Function(model) model.RunContractGroup, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
        </div>
        <hr />

        <div Class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table">
                    <thead>
                        <tr>
                            <th>Is Used Car</th>
                            <th style="background-color: #d1fff6;"> Transaction Type</th>
                            <th> Brand Name</th>
                            <th> Vehicle</th>
                            <th> Year</th>
                            <th> Qty</th>
                            <th> Lease Term</th>
                            <th style="background-color: #d1fff6;"> Bid Price PerMonth</th>
                            <th> Rent Location</th>
                            <th> Plat Location</th>
                            <th style="background-color: #d1fff6;"> OTR Price</th>
                            <th style="background-color: #e7ffd9;"> OTR Price App</th>
                            <th style="background-color: #d1fff6;"> Diskon</th>
                            <th style="background-color: #e7ffd9;"> Diskon App</th>
                            <th style="background-color: #d1fff6;"> Net</th>
                            <th style="background-color: #e7ffd9;"> Net App</th>
                            <th> Depresiasi Percent</th>
                            <th style="background-color: #d1fff6;"> Residual Value Percent</th>
                            <th> Residual Value</th>
                            <th style="background-color: #d1fff6;"> STNK</th>
                            <th style="background-color: #d1fff6;"> Replacement</th>
                            <th style="background-color: #d1fff6;"> Maintenance Percent</th>
                            <th style="background-color: #d1fff6;"> Insurance Percent</th>
                            <th> Expedition Cost</th>
                            <th> Modification</th>
                            <th> GPS Cost</th>
                            <th> Agent Fee</th>
                            <th> KIR</th>
                            <th style="background-color: #d1fff6;"> IRR</th>
                            <th style="background-color: #e7ffd9;"> IRR App</th>
                            <th style="background-color: #d1fff6;"> Profit</th>
                            <th style="background-color: #e7ffd9;"> Profit App</th>
                            <th style="background-color: #d1fff6;"> Spread</th>
                            <th style="background-color: #e7ffd9;"> Spread App</th>
                            <th style="background-color: #d1fff6;"> Funding Rate</th>
                            <th style="background-color: #e7ffd9;"> Funding Rate App</th>
                        </tr>
                    </thead>
                    <tbody id="tbodyid">
                        @For Each x In Model.Detail
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
                                <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.OTR_Price)</td>
                                <td style="white-space:nowrap;background-color: @x.OTR_PriceAppColor;">@String.Format("{0:n}", x.OTR_PriceApp)</td>
                                <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Update_Diskon)</td>
                                <td style="white-space:nowrap;background-color: @x.Update_DiskonAppColor;">@String.Format("{0:n}", x.Update_DiskonApp)</td>
                                <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Net)</td>
                                <td style="white-space:nowrap;background-color: @x.NetAppColor;">@String.Format("{0:n}", x.NetApp)</td>
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
                                <td style="white-space:nowrap;background-color: #d1fff6;">@x.IRR</td>
                                <td style="white-space:nowrap;background-color: @x.IRRAppColor;">@x.IRRApp</td>
                                <td style="white-space:nowrap;background-color: #d1fff6;">@String.Format("{0:n}", x.Profit)</td>
                                <td style="white-space:nowrap;background-color: @x.ProfitAppColor;">@String.Format("{0:n}", x.ProfitApp)</td>
                                <td style="white-space:nowrap;background-color: #d1fff6;">@x.Spread</td>
                                <td style="white-space:nowrap;background-color: @x.SpreadAppColor;">@x.SpreadApp</td>
                                <td style="white-space:nowrap;background-color: #d1fff6;">@x.Funding_Rate</td>
                                <td style="white-space:nowrap;background-color: @x.Funding_RateAppColor;">@x.Funding_RateApp</td>
                            </tr>
                        Next
                    </tbody>
                </table>

            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Approve" class="btn btn-success" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input id="notApprove" type="button" value="Not Approve" class="btn btn-warning" />
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
            </div>
        </div>
        <br />
        <p id="labelProvit" style="font-size:40px;color:orangered;">Back To</p>
        <div class="form-group">
            @Html.Label("Upload SPH and PO", htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.RadioButtonFor(Function(x) x.BackTo, "Upload SPH and PO", New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Application PO", htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.RadioButtonFor(Function(x) x.BackTo, "Application PO", New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>
        </div>
        <div class="form-group">
            @Html.Label("Application", htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.RadioButtonFor(Function(x) x.BackTo, "Application", New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>
        </div>

    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        $(document).ready(function () {
            var i = true;
                document.getElementById("Credit_Rating").disabled = i;
                document.getElementById("Customer_Class").disabled = i;
                document.getElementById("Authorized_CapitalStr").disabled = i;
                document.getElementById("Authorized_Signer_Name1").disabled = i;
                document.getElementById("Authorized_Signer_Position1").disabled = i;
                document.getElementById("Authorized_Signer_Name2").disabled = i;
                document.getElementById("Authorized_Signer_Position2").disabled = i;
                document.getElementById("IntroducedBy").disabled = i;

        });

        $("#notApprove").click(function () {
            var BackTo = $("input[name=BackTo]:checked")[0].value;

            $.ajax({
                url: '@Url.Action("NotApprove", "ApprovalApp")?ApprovalApp_ID=' + @Model.ApprovalApp_ID + '&val=' + $("#Remark").val() + '&BackTo=' + BackTo,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        alert("Success");
                        window.location.href = "@Url.Action("Index", "ApprovalApp")";
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
