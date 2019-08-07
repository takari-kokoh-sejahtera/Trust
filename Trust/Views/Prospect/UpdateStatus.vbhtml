@ModelType Trust.Tr_ProspectCust
@Code
    ViewData("Title") = "UpdateStatus"
End Code

<h2>Update Status</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Prospect Customer</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.ProspectCustomer_ID)
    @Html.HiddenFor(Function(model) model.IsExists)
    @Html.HiddenFor(Function(model) model.CustomerExists_ID)
    @Html.HiddenFor(Function(model) model.CompanyGroup_ID)
    @Html.HiddenFor(Function(model) model.PT)
    @Html.HiddenFor(Function(model) model.Tbk)
    @Html.HiddenFor(Function(model) model.City_id)
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.IsExists, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    <div class="checkbox">
                        @Html.EditorFor(Function(model) model.IsExists, New With {.htmlAttributes = New With {.disabled = "true"}})
                        @Html.ValidationMessageFor(Function(model) model.IsExists, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Customer Exists", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("CustomerExists_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "true"})
                    @Html.ValidationMessageFor(Function(model) model.CustomerExists_ID, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.CompanyGroup_ID, "Company Group", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("CompanyGroup_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "true"})
                    @Html.ValidationMessageFor(Function(model) model.CompanyGroup_ID, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.Label("Compay Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-2">

                    @Html.DropDownList("PT", Nothing, "--", htmlAttributes:=New With {.class = "form-control", .disabled = "true"})
                    @Html.ValidationMessageFor(Function(model) model.PT, "", New With {.class = "text-danger"})
                </div>
                <div class="col-md-5">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                </div>
                <div class="col-md-3">
                    @Html.DropDownList("Tbk", Nothing, "--", htmlAttributes:=New With {.class = "form-control", .disabled = "true"})
                    @Html.ValidationMessageFor(Function(model) model.Tbk, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.City_id, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("City_id", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "true"})
                    @Html.ValidationMessageFor(Function(model) model.City_id, "", New With {.class = "text-danger"})
                </div>
            </div>


        </div>
        <div class="col-md-6">

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
    <hr />
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Status", Nothing, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Status, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ProspectCategory_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("ProspectCategory_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ProspectCategory_ID, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.DateTrans, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DateTrans, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.DateTrans, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.DateTransTime, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.DateTransTime, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.DateTransTime, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Notes, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.TextAreaFor(Function(model) model.Notes, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Notes, "", New With {.class = "text-danger"})
                </div>
            </div>

        </div>
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</div>  End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
