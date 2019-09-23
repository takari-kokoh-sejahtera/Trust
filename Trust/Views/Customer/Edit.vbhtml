@ModelType Trust.Ms_Customer
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Customer</h4>
        <hr />
        <dim class="row">
            <dim class="col-md-6">
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.Customer_ID)

                <div class="form-group">
                    @Html.Label("Company Group", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("CompanyGroup_ID", Nothing, GeneralControl.Selectval, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.CompanyGroup_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.CodeTransaction_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("CodeTransaction_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.CodeTransaction_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("Compay Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-2">
                        @Html.DropDownList("PT", Nothing, "--", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.PT, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-5">
                        @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                    </div>
                    <div class="col-md-3">
                        @Html.DropDownList("Tbk", Nothing, "--", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Tbk, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.Label("City", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("City_ID", Nothing, GeneralControl.Selectval, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.City_ID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Phone, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Phone, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Credit_Rating, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Credit_Rating", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Credit_Rating, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Line_of_Business, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Line_of_Business, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Line_of_Business, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Capital, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_CapitalStr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Capital, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Name1, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Name1, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Name1, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Position1, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Position1, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Position1, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Customer_Class, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.DropDownList("Customer_Class", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Customer_Class, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Name2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Name2, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Name2, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Authorized_Signer_Position2, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Authorized_Signer_Position2, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Authorized_Signer_Position2, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
            <dim class="col-md-6">
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.NPWP, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.NPWP, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.NPWP, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Account, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Account, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Account, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Bank, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Bank, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Bank, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IsStamped, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.CheckBox("IsStamped", New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.IsStamped, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.IntroducedBy, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.IntroducedBy, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.IntroducedBy, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Name, "PIC Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Name, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Phone, "PIC Phone", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Phone, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Phone, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.PIC_Email, "PIC Email", htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.PIC_Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.PIC_Email, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Notes, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Notes, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Notes, "", New With {.class = "text-danger"})
                    </div>
                </div>
            </dim>
        </dim>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    <script>
        //Class Number Format
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
    </script>
End Section
