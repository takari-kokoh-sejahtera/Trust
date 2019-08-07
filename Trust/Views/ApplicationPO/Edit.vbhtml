@ModelType Trust.Tr_ApplicationPO
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Application PO</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(x) x.ProspectCustomerDetail_ID)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.No_Ref, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.No_Ref, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CompanyName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CompanyName, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Vehicle, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Qty, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Qty, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.QtyAppPO, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.QtyAppPO, New With {.htmlAttributes = New With {.class = "form-control price"}})
                @Html.ValidationMessageFor(Function(model) model.QtyAppPO, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Color, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Color, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Color, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Delivery_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Delivery_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Delivery_Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Usage, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Usage, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Usage, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Refund, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Refund, New With {.htmlAttributes = New With {.class = "form-control price"}})
                @Html.ValidationMessageFor(Function(model) model.Refund, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PaymentByUser, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PaymentByUser, New With {.htmlAttributes = New With {.class = "form-control price"}})
                @Html.ValidationMessageFor(Function(model) model.PaymentByUser, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Dealer_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Dealer_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.OTR_Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.OTR_Price, New With {.htmlAttributes = New With {.class = "form-control price"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Discount, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Discount, New With {.htmlAttributes = New With {.class = "form-control price"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.RadioButtonFor(Function(model) model.Status, "Verbal", New With {.htmlAttributes = New With {.class = "form-control"}}) Verbal
                @Html.RadioButtonFor(Function(model) model.Status, "Written", New With {.htmlAttributes = New With {.class = "form-control"}}) Written
            </div>
        </div>


        <div class="form-group">
            <a id="addToList" class="btn btn-primary">Add To List</a>
        </div>
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Dealer</th>
                            <th>OTR Price</th>
                            <th>Discount</th>
                            <th>Status</th>
                            <th>IsChecked</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "IndexProcess")
</div>
