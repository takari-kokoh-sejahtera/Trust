@ModelType Trust.Tr_ApplicationPO
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

<div class="form-horizontal">
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
        @Html.LabelFor(Function(model) model.Color, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Color, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Delivery_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Delivery_Date, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Usage, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.Usage, New With {.class = "form-control", .readonly = "readonly"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Refund, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.RefundStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.PaymentByUser, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.PaymentByUserStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
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
                    </tr>
                </thead>
                <tbody>
                    @If Model.Detail IsNot Nothing Then
                        @For j = 0 To Model.Detail.Count - 1
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(model) model.Detail(j).Dealer)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(model) model.Detail(j).OTR_Price)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(model) model.Detail(j).Discount)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(model) model.Detail(j).Status)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(model) model.Detail(j).IsChecked)
                                </td>

                            </tr>

                        Next

                    End If

                </tbody>

            </table>
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.RemarkNotApproved, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.RemarkNotApproved, New With {.class = "form-control", .readonly = "readonly"})
        </div>
    </div>

</div>

<div>
    @Html.ActionLink("Back to List", "Index")
</div>