@ModelType Trust.Tr_ApplicationHeader
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Application</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.ApplicationHeader_ID)
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
                @Html.LabelFor(Function(model) model.Line_of_Business, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Line_of_Business, New With {.htmlAttributes = New With {.class = "form-control price", .disabled = "disabled"}})
                    @Html.ValidationMessageFor(Function(model) model.Line_of_Business, "", New With {.class = "text-danger"})
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
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Expec_Contract_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Expec_Contract_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Expec_Contract_Date, "", New With {.class = "text-danger"})
                </div>
            </div>
        </dim>
    </dim>
    <div class="row">
        <dim class="col-lg-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Contracted_by, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("Contracted_by", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Contracted_by, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.IsTruck, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("IsTruck", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.IsTruck, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.IsQuick, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("IsQuick", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.IsQuick, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Contract_No, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Contract_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Contract_No, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_Application, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_ApplicationStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Application, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_Group, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_GroupStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Group, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_MUL_Group, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_MUL_GroupStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_MUL_Group, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Run_Application, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Run_Application, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Run_Application, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.RunContractCompany, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.RunContractCompany, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.RunContractCompany, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.RunContractGroup, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.RunContractGroup, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.RunContractGroup, "", New With {.class = "text-danger"})
                </div>
            </div>

        </dim>
        <dim class="col-lg-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_Transaction_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_Transaction_FLStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Transaction_FL, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_Application_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_Application_FLStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Application_FL, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_Group_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_Group_FLStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_Group_FL, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Outstanding_Balance_MUL_Group_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Outstanding_Balance_MUL_Group_FLStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                    @Html.ValidationMessageFor(Function(model) model.Outstanding_Balance_MUL_Group_FL, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Run_Transaction_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Run_Transaction_FL, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Run_Transaction_FL, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Run_Application_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.Run_Application_FL, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Run_Application_FL, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.RunContractCompany_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.RunContractCompany_FL, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.RunContractCompany_FL, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.RunContractGroup_FL, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.EditorFor(Function(model) model.RunContractGroup_FL, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.RunContractGroup_FL, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.ApplicationType, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("ApplicationType", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ApplicationType, "", New With {.class = "text-danger"})
                </div>
            </div>
        </dim>
    </div>
    <hr />
    <div class="box">
        <div Class="box-body table-responsive no-padding">
            <table id="detailsTable" class="table table-hover">
                <thead>
                    <tr>
                        <th>Brand Name</th>
                        <th>Vehicle</th>
                        <th>Color</th>
                        <th>Code Open</th>
                        <th>Payee</th>
                        <th>PayeeRemark</th>
                        <th>Purchaser</th>
                        <th>Purchase Type</th>
                        <th>Asset Rating</th>
                        <th>Ex Del Date</th>
                    </tr>
                </thead>
                <tbody id="tbodyid">
                    @For Each x In ViewBag.detail
                        @<tr style="white-space:nowrap" id=@x.Application_ID>
                            <td style="white-space:nowrap" id=@x.AgenFeeStat.ToString>
                                @x.Brand_Name
                            </td>
                            <td style="white-space:nowrap" id=@x.IsCOP.ToString>
                                @x.Vehicle
                            </td>
                            <td style="white-space:nowrap">@x.color</td>
                            <td style="white-space:nowrap"><select name="Code_Open"><option value="Open">Open</option><option value="Non Open">Non Open</option></select></td>
                            <td style="white-space:nowrap"><input type="text" name="Payee" @x.IsDisabledAgenFee></td>
                            <td style="white-space:nowrap"><select name="PayeeRemark" @x.IsDisabledAgenFee><option value="One Time" @x.SelectOneTime>One Time</option><option value="By Installment" @x.SelectByInstallment>By Installment</option></select></td>
                            <td style="white-space:nowrap"><input type="text" name="Purchaser" @x.IsDisabledCOP value="@x.Purchaser"></td>
                            <td style="white-space:nowrap"><select name="Purchase_Type" @x.IsDisabledCOP><option value="Offering Letter" @x.SelectOfferingLetter>Offering Letter</option><option value="Purchase Agreement" @x.SelectPurchaseAgreement>Purchase Agreement</option></select></td>
                            <td style="white-space:nowrap">@x.Asset_Rating</td>
                            <td style="white-space:nowrap"><input type="date" name="exDelDate" value="@Format(x.Expec_Delivery_Date, "yyyy-MM-dd")"></td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    </div>

    <div Class="form-group">
        <div Class="col-md-offset-2 col-md-10">
            <input type="submit" id="SaveData" value="Create" Class="btn btn-default" />
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
            var i = true
            if (data.IsExists) {
                document.getElementById("Credit_Rating").disabled = i;
                document.getElementById("Customer_Class").disabled = i;
                document.getElementById("Line_of_Business").disabled = i;
                document.getElementById("Authorized_CapitalStr").disabled = i;
                document.getElementById("Authorized_Signer_Name1").disabled = i;
                document.getElementById("Authorized_Signer_Position1").disabled = i;
                document.getElementById("Authorized_Signer_Name2").disabled = i;
                document.getElementById("Authorized_Signer_Position2").disabled = i;
                document.getElementById("IntroducedBy").disabled = i;
            }
            else {
                document.getElementById("Credit_Rating").disabled = !i;
                document.getElementById("Customer_Class").disabled = !i;
                document.getElementById("Line_of_Business").disabled = !i;
                document.getElementById("Authorized_CapitalStr").disabled = !i;
                document.getElementById("Authorized_Signer_Name1").disabled = !i;
                document.getElementById("Authorized_Signer_Position1").disabled = !i;
                document.getElementById("Authorized_Signer_Name2").disabled = !i;
                document.getElementById("Authorized_Signer_Position2").disabled = !i;
                document.getElementById("IntroducedBy").disabled = !i;
            }

        });



        //save Edit
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("EditOrder", "ApplicationHeader")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Application Is Complete!\n" + data.result);
                        window.location.href = '@Url.Action("Index", "ApplicationHeader")'
                    } else { alert(data.message)}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#SaveData").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;
            var headerArr = [];
            headerArr.length = 0;
            if ($("#Approval_ID").val() == "") { return;}
            $.each($("#detailsTable tbody tr"), function () {
                //if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        Application_ID: $(this).attr('id'),
                        Code_Open: $(this).find('select:eq(0)').val(),
                        Payee: $(this).find('input:eq(0)').val(),
                        PayeeRemark: $(this).find('select:eq(1)').val(),
                        Purchaser: $(this).find('input:eq(1)').val(),
                        Purchase_Type: $(this).find('select:eq(2)').val(),
                        Asset_Rating: $(this).find('td:eq(7)').html(),
                        Agent_FeeStat: ($(this).find('td:eq(0)').attr('id') == "True" ? true : false),
                        IsCOP: ($(this).find('td:eq(1)').attr('id') == "True" ? true : false),
                        Expec_Delivery_Date: $(this).find('input:eq(2)').val()
                    });
                //}
            });
            //Masukin Header di Module
            headerArr.push({
                ApplicationHeader_ID: $("#ApplicationHeader_ID").val(),
                IsExists: $("#IsExists:checkbox").prop('checked'),
                Credit_Rating: $("#Credit_Rating").val(),
                Line_of_Business: $("#Line_of_Business").val(),
                Authorized_CapitalStr: $("#Authorized_CapitalStr").val(),
                Authorized_Signer_Name1: $("#Authorized_Signer_Name1").val(),
                Customer_Class: $("#Customer_Class").val(),
                Authorized_Signer_Position1: $("#Authorized_Signer_Position1").val(),
                Authorized_Signer_Name2: $("#Authorized_Signer_Name2").val(),
                Authorized_Signer_Position2: $("#Authorized_Signer_Position2").val(),
                IntroducedBy: $("#IntroducedBy").val(),
                Expec_Contract_Date: $("#Expec_Contract_Date").val(),
                IsTruck: $("#IsTruck").val(),
                IsQuick: $("#IsQuick").val(),
                Contract_No: $("#Contract_No").val(),
                Contracted_by: $("#Contracted_by").val(),
                Remark: $("#Remark").val(),
                Record_For_Payment: $("#Record_For_Payment").val(),
                Outstanding_Balance_ApplicationStr: $("#Outstanding_Balance_ApplicationStr").val(),
                Outstanding_Balance_GroupStr: $("#Outstanding_Balance_GroupStr").val(),
                Outstanding_Balance_MUL_GroupStr: $("#Outstanding_Balance_MUL_GroupStr").val(),
                Outstanding_Balance_Transaction_FLStr: $("#Outstanding_Balance_Transaction_FLStr").val(),
                Outstanding_Balance_Application_FLStr: $("#Outstanding_Balance_Application_FLStr").val(),
                Outstanding_Balance_Group_FLStr: $("#Outstanding_Balance_Group_FLStr").val(),
                Outstanding_Balance_MUL_Group_FLStr: $("#Outstanding_Balance_MUL_Group_FLStr").val(),
                Run_Application: $("#Run_Application").val(),
                RunContractCompany: $("#RunContractCompany").val(),
                RunContractGroup: $("#RunContractGroup").val(),
                Run_Transaction_FL: $("#Run_Transaction_FL").val(),
                Run_Application_FL: $("#Run_Application_FL").val(),
                RunContractCompany_FL: $("#RunContractCompany_FL").val(),
                RunContractGroup_FL: $("#RunContractGroup_FL").val(),
                ApplicationType: $("#ApplicationType").val()
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
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
    </script>
End Section
