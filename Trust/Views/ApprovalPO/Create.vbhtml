@ModelType Trust.Tr_ApprovalPO
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm("Create", "ApprovalPO", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>ApprovalPO</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.ProspectCustomer_ID)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.No_Ref, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.No_Ref, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <hr />
        @For i = 0 To Model.Detail.Count - 1
            @<div Class="row">
                <div Class="col-md-6">
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Vehicle, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Qty, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).Qty, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Color, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).Color, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Delivery_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).Delivery_Date, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                </div>
                <div Class="col-md-6">
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Usage, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).Usage, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).Refund, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).RefundStr, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(model) model.Detail(i).PaymentByUser, htmlAttributes:=New With {.class = "control-label col-md-2"})
                        <div class="col-md-10">
                            @Html.EditorFor(Function(model) model.Detail(i).PaymentByUser, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                        </div>
                    </div>
                </div>

            </div>
            @<div class="box">
                <div Class="box-body table-responsive no-padding">
                    <Table Class="table table-hover">
                        <thead>
                            <tr>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.Detail(i).Detail(0).Dealer)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.Detail(i).Detail(0).OTR_Price)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.Detail(i).Detail(0).Discount)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.Detail(i).Detail(0).Status)
                                </th>
                                <th>
                                    @Html.DisplayNameFor(Function(model) model.Detail(i).Detail(0).IsChecked)
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            @If Model.Detail(i).Detail IsNot Nothing Then
                                @For j = 0 To Model.Detail(i).Detail.Count - 1
                                    @<tr>
                                        @Html.HiddenFor(Function(model) model.Detail(i).Detail(j).Dealer)
                                        @Html.HiddenFor(Function(model) model.Detail(i).Detail(j).OTR_Price)
                                        @Html.HiddenFor(Function(model) model.Detail(i).Detail(j).Discount)
                                        @Html.HiddenFor(Function(model) model.Detail(i).Detail(j).Status)
                                        @Html.HiddenFor(Function(model) model.Detail(i).Detail(j).IsChecked)
                                        <td style="white-space:nowrap">
                                            @Html.DisplayFor(Function(model) model.Detail(i).Detail(j).Dealer)
                                        </td>
                                        <td style="white-space:nowrap">
                                            @Html.DisplayFor(Function(model) model.Detail(i).Detail(j).OTR_Price)
                                        </td>
                                        <td style="white-space:nowrap">
                                            @Html.DisplayFor(Function(model) model.Detail(i).Detail(j).Discount)
                                        </td>
                                        <td style="white-space:nowrap">
                                            @Html.DisplayFor(Function(model) model.Detail(i).Detail(j).Status)
                                        </td>
                                        <td style="white-space:nowrap">
                                            @Html.DisplayFor(Function(model) model.Detail(i).Detail(j).IsChecked)
                                        </td>

                                    </tr>

                                Next

                            End If

                        </tbody>
                    </Table>

                </div>

            </div>
        Next
        <div class="form-group">
            @Html.LabelFor(Function(model) model.RemarkNotApprove, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.RemarkNotApprove, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>


        <div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input type="submit" value="Approve" Class="btn btn-default" onclick="return confirm('Are you sure wants to Approve?');" />
            </div>
        </div>
        <div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input id="notApprove" type="button" value="Not Approve" Class="btn btn-default" onclick="return confirm('Are you sure wants to Not Approve?');" />
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
                url: '@Url.Action("NotApprove", "ApprovalPO")?ApprovalPO_ID=' + @Model.ApprovalPO_ID + '&val=' + $("#RemarkNotApprove").val(),
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.success == "true") {
                        alert("Success");
                        window.location.href = "@Url.Action("Index", "ApprovalPO")";
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
