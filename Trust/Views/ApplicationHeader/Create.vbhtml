@ModelType Trust.Tr_ApplicationHeader
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Application</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Approval_ID, "No Ref", htmlAttributes:=New With {.class = "control-label col-md-3"})
                    <div class="col-md-9">
                        @Html.DropDownList("Approval_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Approval_ID, "", New With {.class = "text-danger"})
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
                        @Html.EditorFor(Function(model) model.Line_of_Business, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
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
                    <tbody id="tbodyid"></tbody>
                </table>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" id="SaveData" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    <script>
        function clearHeader() {
            $("#Company_Name")[0].value = "";
            $("#CompanyGroup_Name")[0].value = "";
            $("#Address")[0].value = "";
            $("#City")[0].value = "";
            $("#Phone")[0].value = "";
            $("#Email")[0].value = "";
            $("#PIC_Name")[0].value = "";
            $("#PIC_Phone")[0].value = "";
            $("#PIC_Email")[0].value = "";

            document.getElementById('Credit_Rating').selectedIndex = 0;
            document.getElementById('Customer_Class').selectedIndex = 0;
            $("#Line_of_Business")[0].value = "";
            $("#Authorized_CapitalStr")[0].value = "";
            $("#Authorized_Signer_Name1")[0].value = "";
            $("#Authorized_Signer_Position1")[0].value = "";
            $("#Authorized_Signer_Name2")[0].value = "";
            $("#Authorized_Signer_Position2")[0].value = "";
            $("#IntroducedBy")[0].value = "";
            $("#Expec_Contract_Date")[0].value = "";
        };

        $("#Approval_ID").change(function () {
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("FillCustomer", "ApplicationHeader")?val=' + t,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    clearHeader();
                    $("#tbodyid").empty();
                    if (data.success == "true") {
                        $("#CompanyGroup_Name")[0].value = data.CompanyGroup_Name;
                        $("#Company_Name")[0].value = data.Company_Name;
                        $("#Address")[0].value = data.Address;
                        $("#City")[0].value = data.City;
                        $("#Phone")[0].value = data.Phone;
                        $("#Email")[0].value = data.Email;
                        $("#PIC_Name")[0].value = data.PIC_Name;
                        $("#PIC_Phone")[0].value = data.PIC_Phone;
                        $("#PIC_Email")[0].value = data.PIC_Email;
                        $('#IsExists').prop('checked', data.IsExists);
                        $("#Credit_Rating")[0].value = data.Credit_Rating;

                        if (data.IsExists) {
                            var i = true
                            document.getElementById("Customer_Class").disabled = i;
                            document.getElementById("Line_of_Business").disabled = i;
                            document.getElementById("Authorized_CapitalStr").disabled = i;
                            document.getElementById("Authorized_Signer_Name1").disabled = i;
                            document.getElementById("Authorized_Signer_Position1").disabled = i;
                            document.getElementById("Authorized_Signer_Name2").disabled = i;
                            document.getElementById("Authorized_Signer_Position2").disabled = i;
                            document.getElementById("IntroducedBy").disabled = i;

                            $("#Customer_Class")[0].value = data.Customer_Class;
                            $("#Line_of_Business")[0].value = data.Line_of_Business;
                            $("#Authorized_CapitalStr")[0].value = number_format(data.Authorized_Capital);
                            $("#Authorized_Signer_Name1")[0].value = data.Authorized_Signer_Name1;
                            $("#Authorized_Signer_Position1")[0].value = data.Authorized_Signer_Position1;
                            $("#Authorized_Signer_Name2")[0].value = data.Authorized_Signer_Name2;
                            $("#Authorized_Signer_Position2")[0].value = data.Authorized_Signer_Position2;
                            $("#IntroducedBy")[0].value = data.IntroducedBy;
                        }
                        else {
                            var i = false
                            document.getElementById("Customer_Class").disabled = i;
                            document.getElementById("Line_of_Business").disabled = i;
                            document.getElementById("Authorized_CapitalStr").disabled = i;
                            document.getElementById("Authorized_Signer_Name1").disabled = i;
                            document.getElementById("Authorized_Signer_Position1").disabled = i;
                            document.getElementById("Authorized_Signer_Name2").disabled = i;
                            document.getElementById("Authorized_Signer_Position2").disabled = i;
                            document.getElementById("IntroducedBy").disabled = i;

                        }
                        var detailsTableBody = $("#detailsTable tbody");

                        
                        $.each(data.Detail, function (i, data) {
                            var Code_Open = '<select name="Code_Open"><option value="Open">Open</option><option value="Non Open">Non Open</option></select>'
                            var AgenfeeNo = '<td style="white-space:nowrap"><input type="text" name="Payee" disabled></td>' +
                                '<td style="white-space:nowrap"><select name="PayeeRemark" disabled><option value="One Time">One Time</option><option value="By Installment">By Installment</option></select></td>'
                            var AgenfeeYes = '<td style="white-space:nowrap"><input type="text" name="Payee"></td>' +
                                '<td style="white-space:nowrap"><select name="PayeeRemark"><option value="One Time">One Time</option><option value="By Installment">By Installment</option></select></td>'
                            var COPNo = '<td style="white-space:nowrap"><input type="text" name="Purchaser" disabled></td>' +
                                '<td style="white-space:nowrap"><select name="Purchase_Type" disabled><option value="Offering Letter">Offering Letter</option><option value="Purchase Agreement">Purchase Agreement</option></select></td>'
                            var COPYes = '<td style="white-space:nowrap"><input type="text" name="Purchaser"></td>' +
                                '<td style="white-space:nowrap"><select name="Purchase_Type"><option value="Offering Letter">Offering Letter</option><option value="Purchase Agreement">Purchase Agreement</option></select></td>'
                            var productItem = '<tr style="white-space:nowrap" id=' + data.Application_ID + '><td style="white-space:nowrap" id="' + (data.AgenFeeStat === true ? "True" : "False") + '">' + data.Brand_Name + '</td><td style="white-space:nowrap" id="' + (data.Transaction_Type === 'COP' ? "True" : "False") + '">' + data.Vehicle + '</td>' +
                                //cek dia Vehicle Exists nga
                                '<td style="white-space:nowrap">' + data.Color + '</td><td style="white-space:nowrap">' + Code_Open + '</td>' +
                                //cek dia ada Agen Fee nga
                                (data.AgenFeeStat === true ? AgenfeeYes : AgenfeeNo) +
                                //cek dia COP
                                (data.Transaction_Type === 'COP' ? COPYes : COPNo) +
                                '<td style="white-space:nowrap">' + data.Asset_Rating + '</td>' +
                                '<td style="white-space:nowrap"><input type="date" name="exDelDate"></td>' +
                                '</tr>';
                            detailsTableBody.append(productItem);
                        });

                    }
                },
                error: function () {
                    alert("error");
                }
            });
        });
        function formatDate(date) {
            var d = new Date(date),
                month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();

            if (month.length < 2) month = '0' + month;
            if (day.length < 2) day = '0' + day;

            return [year, month, day].join('-');
        }
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });

        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("SaveOrder", "ApplicationHeader")",
                data: data,
                success: function (data) {
                    if (data.result != "Error") {
                        alert("Success! Application Is Complete!\n" + data.result);
                        window.location.href = '@Url.Action("Index", "ApplicationHeader")'
                    } else {
                        alert(data.message);
                        $("#SaveData").attr("disabled", false);
                    }
                },
                error: function () {
                    alert("Error!");
                    $("#SaveData").attr("disabled", false);
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#SaveData").click(function (e) {
            $("#SaveData").attr("disabled", true);
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
                Approval_ID: $("#Approval_ID").val(),
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
                Contracted_by: $("#Contracted_by").val(),
                IsTruck: $("#IsTruck").val(),
                IsQuick: $("#IsQuick").val(),
                Contract_No: $("#Contract_No").val(),
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
                RunContractGroup_FL: $("#RunContractGroup_FL").val()
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
        function number_format(nStr) {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }
    </script>
End Section
