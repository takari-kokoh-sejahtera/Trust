@ModelType Trust.Ms_Customer_KYC
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm("Review", "KYC", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>KYC</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.KYC_ID)
        @Html.HiddenFor(Function(model) model.Customer_ID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Customer_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Customer_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
                @Html.ValidationMessageFor(Function(model) model.Customer_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Legal_Domicile_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Legal_Domicile_City_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Legal_Domicile_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div Class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Line Bussiness @Html.ValidationMessageFor(Function(model) model.ValidateLineBussiness, "", New With {.class = "text-danger"})</h3>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="addLineBussiness" value="Add" class="btn btn-default" />
                            </div>
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="deleteLineBussiness" value="Delete" class="btn btn-default" />
                            </div>
                        </div>
                        <table id="lineBussinessTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Line Bussiness</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyid">
                                @if Model.DetailLineBussiness IsNot Nothing Then
                                    @For i = 0 To Model.DetailLineBussiness.Count - 1
                                        @<tr style="white-space:nowrap">
                                            @Html.Hidden("DetailLineBussiness[" + i.ToString + "].LineBussiness_ID", Model.DetailLineBussiness(i).LineBussiness_ID)
                                            <td style="white-space:nowrap">@Html.TextBox("DetailLineBussiness[" + i.ToString + "].LineBussiness", Model.DetailLineBussiness(i).LineBussiness, htmlAttributes:=New With {.class = "form-control"}) @Html.ValidationMessage("DetailLineBussiness[" + i.ToString + "].LineBussiness", "", New With {.class = "text-danger"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>

        <hr>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOE_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOE_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Approval_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Approval_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Approval_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Approval_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Approval_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Approval_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Approval_From, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Approval_From, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Approval_From, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_States_Gazette_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_States_Gazette_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_States_Gazette_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_States_Gazette_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_States_Gazette_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_States_Gazette_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Supplement_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Supplement_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Supplement_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_Supplement_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOE_Supplement_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_Supplement_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOE_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOE_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOE_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("AOA_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.AOA_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Approval_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Approval_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Approval_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Approval_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Approval_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Approval_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_States_Gazette_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_States_Gazette_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_States_Gazette_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_States_Gazette_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_States_Gazette_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_States_Gazette_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Supplement_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Supplement_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Supplement_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_Supplement_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.AOA_Supplement_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_Supplement_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AOA_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.AOA_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AOA_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NPWP_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.NPWP_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_SKT_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NPWP_SKT_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_SKT_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_SKT_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NPWP_SKT_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_SKT_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_SKT_Issued_By, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NPWP_SKT_Issued_By, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_SKT_Issued_By, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NPWP_SKT_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.NPWP_SKT_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NPWP_SKT_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SPPKP_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SPPKP_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SPPKP_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SPPKP_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SPPKP_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SPPKP_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SPPKP_Issued_By, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SPPKP_Issued_By, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SPPKP_Issued_By, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SPPKP_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.SPPKP_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SPPKP_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Business_License_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Business_License_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Business_License_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Business_License_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_IssuedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Business_License_IssuedBy, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Business_License_IssuedBy, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_IssuedDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Business_License_IssuedDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Business_License_IssuedDate, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_ExpiredDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Business_License_ExpiredDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Business_License_ExpiredDate, "", New With {.class = "text-danger"})
                @Html.CheckBox("Business_License_ExpiredDate_IsNA", False)
                @Html.LabelFor(Function(x) x.Business_License_ExpiredDate_IsNA)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Business_License_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Business_License_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Business_License_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("TDP_Type", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.TDP_Type, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TDP, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TDP, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP_IssuedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TDP_IssuedBy, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TDP_IssuedBy, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP_IssuedDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TDP_IssuedDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TDP_IssuedDate, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP_ExpiredDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TDP_ExpiredDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TDP_ExpiredDate, "", New With {.class = "text-danger"})
                @Html.CheckBox("TDP_ExpiredDate_IsNA", False)
                @Html.LabelFor(Function(x) x.TDP_ExpiredDate_IsNA)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TDP_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.TDP_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.TDP_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SKDP_Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_Address, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SKDP_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_IssuedDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SKDP_IssuedDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_IssuedDate, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_IssuedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SKDP_IssuedBy, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_IssuedBy, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_ExpiredDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SKDP_ExpiredDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_ExpiredDate, "", New With {.class = "text-danger"})
                @Html.CheckBox("SKDP_ExpiredDate_IsNA", False)
                @Html.LabelFor(Function(x) x.SKDP_ExpiredDate_IsNA)
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SKDP_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.SKDP_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SKDP_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA1_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA1_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Regarding, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_Regarding, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Regarding, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA1_Type", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Type, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA1_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA1_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOA1_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA1_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA2_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA2_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Regarding, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_Regarding, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Regarding, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA2_Type", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Type, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA2_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA2_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOA2_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA2_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA3_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA3_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Regarding, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_Regarding, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Regarding, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA3_Type", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Type, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA3_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA3_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOA3_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA3_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA4_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA4_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_Regarding, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_Regarding, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_Regarding, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA4_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA4_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA4_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA4_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOA4_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA4_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA5_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA5_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_Regarding, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_Regarding, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_Regarding, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("DOA5_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.DOA5_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.DOA5_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.DOA5_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.DOA5_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.DOA5_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BOD_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BOD_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_Notary, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BOD_Notary, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_Notary, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_City_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("BOD_City_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.BOD_City_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("BOD_Type", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.BOD_Type, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_Letter_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BOD_Letter_No, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_Letter_No, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_Letter_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BOD_Letter_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_Letter_Date, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BOD_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.BOD_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BOD_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Period, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Period, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Period, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Mention, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Mention, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Mention, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Article, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Article, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Article, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Appointment, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Appointment, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Appointment, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Expired, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Expired, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Expired, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div Class="row">
            <div class="col-md-12">
                <!-- Calculate CHART -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Director @Html.ValidationMessageFor(Function(model) model.ValidateDirector, "", New With {.class = "text-danger"})</h3>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="addDirector" value="Add" class="btn btn-default" />
                            </div>
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="deleteDirector" value="Delete" class="btn btn-default" />
                            </div>
                        </div>
                        <table id="directorTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Director</th>
                                    <th>Mr</th>
                                    <th>Mrs</th>
                                    <th>Ms</th>
                                    <th>Position</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyid">
                                @if Model.DetailDirector IsNot Nothing Then
                                    @For i = 0 To Model.DetailDirector.Count - 1
                                        @<tr style="white-space:nowrap">
                                            @Html.Hidden("DetailDirector[" + i.ToString + "].KYC_Director_ID", Model.DetailDirector(i).KYC_Director_ID)
                                            <td style="white-space:nowrap">@Html.TextBox("DetailDirector[" + i.ToString + "].Director", Model.DetailDirector(i).Director, htmlAttributes:=New With {.class = "form-control"})</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailDirector[" + i.ToString + "].Gender", "Mr", Model.DetailDirector(i).Gender = "Mr")</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailDirector[" + i.ToString + "].Gender", "Mrs", Model.DetailDirector(i).Gender = "Mrs")</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailDirector[" + i.ToString + "].Gender", "Ms", Model.DetailDirector(i).Gender = "Ms")</td>
                                            <td style="white-space:nowrap">@Html.TextBox("DetailDirector[" + i.ToString + "].Position", Model.DetailDirector(i).Position, htmlAttributes:=New With {.class = "form-control"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>

        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Period, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Period, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Period, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Mention, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Mention, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Mention, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Article, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Article, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Article, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Appointment, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Appointment, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Appointment, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoD_Expired, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoD_Expired, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoD_Expired, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoC_Period, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoC_Period, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoC_Period, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoC_Mention, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoC_Mention, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoC_Mention, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoC_Article, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoC_Article, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoC_Article, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoC_Appointment, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoC_Appointment, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoC_Appointment, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.BoC_Expired, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.BoC_Expired, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.BoC_Expired, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div Class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Commissioner @Html.ValidationMessageFor(Function(model) model.ValidateCommissioner, "", New With {.class = "text-danger"})</h3>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="addCommissioner" value="Add" class="btn btn-default" />
                            </div>
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="deleteCommissioner" value="Delete" class="btn btn-default" />
                            </div>
                        </div>
                        <table id="commissionerTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Commissioner</th>
                                    <th>Mr</th>
                                    <th>Mrs</th>
                                    <th>Ms</th>
                                    <th>Position</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyid">
                                @if Model.DetailCommissioner IsNot Nothing Then
                                    @For i = 0 To Model.DetailCommissioner.Count - 1
                                        @<tr style="white-space:nowrap">
                                            @Html.Hidden("DetailCommissioner[" + i.ToString + "].KYC_Commissioner_ID", Model.DetailCommissioner(i).KYC_Commissioner_ID)

                                            <td style="white-space:nowrap">@Html.TextBox("DetailCommissioner[" + i.ToString + "].Commissioner", Model.DetailCommissioner(i).Commissioner, htmlAttributes:=New With {.class = "form-control"})</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailCommissioner[" + i.ToString + "].Gender", "Mr", Model.DetailDirector(i).Gender = "Mr")</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailCommissioner[" + i.ToString + "].Gender", "Mrs", Model.DetailDirector(i).Gender = "Mrs")</td>
                                            <td style="white-space:nowrap">@Html.RadioButton("DetailCommissioner[" + i.ToString + "].Gender", "Ms", Model.DetailDirector(i).Gender = "Ms")</td>
                                            <td style="white-space:nowrap">@Html.TextBox("DetailCommissioner[" + i.ToString + "].Position", Model.DetailCommissioner(i).Position, htmlAttributes:=New With {.class = "form-control"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Authorized_Capital_BasedOn, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Authorized_Capital_BasedOn, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Authorized_Capital_BasedOn, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Authorized_Capital, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Authorized_Capital, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Authorized_Capital, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Issued_Paidup_Capital, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Issued_Paidup_Capital, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Issued_Paidup_Capital, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div Class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Shareholder @Html.ValidationMessageFor(Function(model) model.ValidateShareholder, "", New With {.class = "text-danger"})</h3>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="addShareholder" value="Add" class="btn btn-default" />
                            </div>
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="deleteShareholder" value="Delete" class="btn btn-default" />
                            </div>
                        </div>
                        <table id="shareholderTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Shareholder Name</th>
                                    <th>Amount of Shares</th>
                                    <th>Nominal Amount</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyid">
                                @if Model.DetailShareholder IsNot Nothing Then
                                    @For i = 0 To Model.DetailShareholder.Count - 1
                                        @<tr style="white-space:nowrap">
                                            @Html.Hidden("DetailShareholder[" + i.ToString + "].Shareholder_ID", Model.DetailShareholder(i).Shareholder_ID)
                                            <td style="white-space:nowrap">@Html.TextBox("DetailShareholder[" + i.ToString + "].Shareholder_Name", Model.DetailShareholder(i).Shareholder_Name, htmlAttributes:=New With {.class = "form-control"})</td>
                                            <td style="white-space:nowrap">@Html.TextBox("DetailShareholder[" + i.ToString + "].AmountofShares", Model.DetailShareholder(i).AmountofShares, htmlAttributes:=New With {.class = "price form-control"})</td>
                                            <td style="white-space:nowrap">@Html.TextBox("DetailShareholder[" + i.ToString + "].Nominal_Amount", Model.DetailShareholder(i).Nominal_Amount, htmlAttributes:=New With {.class = "price form-control"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Paragraph1, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Paragraph1, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Paragraph1, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Article1, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Article1, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Article1, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph11, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph11, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph11, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph21, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph21, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph21, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph31, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph31, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph31, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Paragraph2, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Paragraph2, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Paragraph2, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Article2, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Article2, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Article2, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph12, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph12, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph12, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph22, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph22, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph22, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.InputParagraph32, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InputParagraph32, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InputParagraph32, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaGender, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("SuratKuasaGender", Nothing, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaGender, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SuratKuasaBy, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaBy, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaBasedOn, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SuratKuasaBasedOn, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaBasedOn, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SuratKuasaDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaDate, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaExpired, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SuratKuasaExpired, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaExpired, "", New With {.class = "text-danger"})
                @Html.CheckBox("SuratKuasaExpired_IsNA", False)
                @Html.LabelFor(Function(x) x.SuratKuasaExpired_IsNA)
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasaPenerima_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.SuratKuasaPenerima_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasaPenerima_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.SuratKuasa_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.SuratKuasa_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SuratKuasa_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div Class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Authorized Signer @Html.ValidationMessageFor(Function(model) model.ValidateAuthorizedSigner, "", New With {.class = "text-danger"})</h3>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="addSigner" value="Add" class="btn btn-default" />
                            </div>
                            <div class="col-md-offset-2 col-md-4">
                                <input type="button" id="deleteSigner" value="Delete" class="btn btn-default" />
                            </div>
                        </div>
                        <table id="signerTable" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Authorized Signer</th>
                                    <th>Position</th>
                                </tr>
                            </thead>
                            <tbody id="tbodyid">
                                @if Model.DetailAuthorizedSigner IsNot Nothing Then
                                    @For i = 0 To Model.DetailAuthorizedSigner.Count - 1
                                        @<tr style="white-space:nowrap">
                                            @Html.Hidden("DetailAuthorizedSigner[" + i.ToString + "].KYC_AuthorizedSigner_ID", Model.DetailAuthorizedSigner(i).KYC_AuthorizedSigner_ID)
                                            <td style="white-space:nowrap">@Html.TextBox("DetailAuthorizedSigner[" + i.ToString + "].AuthorizedSigner", Model.DetailAuthorizedSigner(i).AuthorizedSigner, htmlAttributes:=New With {.class = "form-control"})</td>
                                            <td style="white-space:nowrap">@Html.TextBox("DetailAuthorizedSigner[" + i.ToString + "].Position", Model.DetailAuthorizedSigner(i).Position, htmlAttributes:=New With {.class = "form-control"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>

        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Authorized_Person, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Authorized_Person, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Authorized_Person, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Annual_Income, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Annual_Income, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Annual_Income, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Purpose_of_Services, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Purpose_of_Services, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Purpose_of_Services, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />



        <div class="form-group">
            @Html.LabelFor(Function(model) model.Identitas, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.DropDownList("Identitas", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.Identitas, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Identitas_IsUploadedFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Identitas_IsUploadedFile, New With {.accept = "application/pdf,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Identitas_IsUploadedFile, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" Class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    <script>

        $("#addDirector").click(function (e) {

            var detailsTableBody = $("#directorTable tbody");
            var rowCount = $('#directorTable tr').length - 1;
            var productItem = '<tr><td style="white-space:nowrap"><input name="DetailDirector[' + rowCount + '].Director" type="text" class="form-control" ></td>' +
                '<td style="white-space:nowrap"><input name="DetailDirector[' + rowCount + '].Gender" type="radio" value="Mr" checked></td>' +
                '<td style="white-space:nowrap"><input name="DetailDirector[' + rowCount + '].Gender" type="radio" value="Mrs"></td>' +
                '<td style="white-space:nowrap"><input name="DetailDirector[' + rowCount + '].Gender" type="radio" value="Ms"></td>' +
                '<td style="white-space:nowrap"><input name="DetailDirector[' + rowCount + '].Position" type="text" class="form-control"></td></tr>';
            detailsTableBody.append(productItem);
        });
        $("#deleteDirector").click(function (e) {
            var table = document.getElementById("directorTable");
            var rowCount = table.rows.length;
            if (rowCount > 1) {
                table.deleteRow(rowCount - 1);
            }
        });
        $("#addCommissioner").click(function (e) {

            var detailsTableBody = $("#commissionerTable tbody");
            var rowCount = $('#commissionerTable tr').length - 1;
            var productItem = '<tr><td style="white-space:nowrap"><input name="DetailCommissioner[' + rowCount + '].Commissioner" type="text" class="form-control" ></td>' +
                '<td style="white-space:nowrap"><input name="DetailCommissioner[' + rowCount + '].Gender" type="radio" value="Mr" checked></td>' +
                '<td style="white-space:nowrap"><input name="DetailCommissioner[' + rowCount + '].Gender" type="radio" value="Mrs"></td>' +
                '<td style="white-space:nowrap"><input name="DetailCommissioner[' + rowCount + '].Gender" type="radio" value="Ms"></td>' +
                '<td style="white-space:nowrap"><input name="DetailCommissioner[' + rowCount + '].Position" type="text" class="form-control"></td></tr>';

            detailsTableBody.append(productItem);
        });
        $("#deleteCommissioner").click(function (e) {
            var table = document.getElementById("commissionerTable");
            var rowCount = table.rows.length;
            if (rowCount > 1) {
                table.deleteRow(rowCount - 1);
            }
        });
        $("#addSigner").click(function (e) {
            var detailsTableBody = $("#signerTable tbody");
            var rowCount = $('#signerTable tr').length - 1;
            var productItem = '<tr><td style="white-space:nowrap"><input name="DetailAuthorizedSigner[' + rowCount + '].AuthorizedSigner" type="text" class="form-control" ></td>' +
                '<td style="white-space:nowrap"><input name="DetailAuthorizedSigner[' + rowCount + '].Position" type="text" class="form-control"></td></tr>';
            detailsTableBody.append(productItem);
        });
        $("#deleteSigner").click(function (e) {
            var table = document.getElementById("signerTable");
            var rowCount = table.rows.length;
            if (rowCount > 1) {
                table.deleteRow(rowCount - 1);
            }
        });
        $("#addShareholder").click(function (e) {

            var detailsTableBody = $("#shareholderTable tbody");
            var rowCount = $('#shareholderTable tr').length - 1;
            var productItem = '<tr><td style="white-space:nowrap"><input name="DetailShareholder[' + rowCount + '].Shareholder_Name" type="text" class="form-control"></td>' +
                '<td style="white-space:nowrap"><input name="DetailShareholder[' + rowCount + '].AmountofShares" type="text" class="price form-control"></td>' +
                '<td style="white-space:nowrap"><input name="DetailShareholder[' + rowCount + '].Nominal_Amount" class="price form-control"></td></tr>';
            detailsTableBody.append(productItem);
        });
        $("#deleteShareholder").click(function (e) {
            var table = document.getElementById("shareholderTable");
            var rowCount = table.rows.length;
            if (rowCount > 1) {
                table.deleteRow(rowCount - 1);
            }
        });
        $("#addLineBussiness").click(function (e) {
            var detailsTableBody = $("#lineBussinessTable tbody");
            var rowCount = $('#lineBussinessTable tr').length - 1;
            var productItem = '<tr><td style="white-space:nowrap"><input name="DetailLineBussiness[' + rowCount + '].LineBussiness" type="text" class="form-control"></td></tr>';
            detailsTableBody.append(productItem);
        });
        $("#deleteLineBussiness").click(function (e) {
            var table = document.getElementById("lineBussinessTable");
            var rowCount = table.rows.length;
            if (rowCount > 1) {
                table.deleteRow(rowCount - 1);
            }
        });

        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
        $("#Business_License_ExpiredDate_IsNA").change(function (e) {
            if ($("#Business_License_ExpiredDate_IsNA").prop("checked")) {
                $("#Business_License_ExpiredDate").val('');
                $("#Business_License_ExpiredDate").prop("disabled", true);
            } else {
                $("#Business_License_ExpiredDate").prop("disabled", false);
            }
        });
        $("#TDP_ExpiredDate_IsNA").change(function (e) {
            if ($("#TDP_ExpiredDate_IsNA").prop("checked")) {
                $("#TDP_ExpiredDate").val('');
                $("#TDP_ExpiredDate").prop("disabled", true);
            } else {
                $("#TDP_ExpiredDate").prop("disabled", false);
            }
        });
        $("#SKDP_ExpiredDate_IsNA").change(function (e) {
            if ($("#SKDP_ExpiredDate_IsNA").prop("checked")) {
                $("#SKDP_ExpiredDate").val('');
                $("#SKDP_ExpiredDate").prop("disabled", true);
            } else {
                $("#SKDP_ExpiredDate").prop("disabled", false);
            }
        });
        $("#SuratKuasaExpired_IsNA").change(function (e) {
            if ($("#SuratKuasaExpired_IsNA").prop("checked")) {
                $("#SuratKuasaExpired").val('');
                $("#SuratKuasaExpired").prop("disabled", true);
            } else {
                $("#SuratKuasaExpired").prop("disabled", false);
            }
        });

    </script>
End Section
