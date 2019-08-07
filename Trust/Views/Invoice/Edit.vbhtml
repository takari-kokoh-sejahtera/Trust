@ModelType Trust.Tr_Invoice
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Collection Invoice</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.Invoice_ID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Invoice_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Invoice_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Invoice_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Contract_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Contract_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Contract_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Total, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TotalStr, New With {.htmlAttributes = New With {.class = "form-control price", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Total, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "IndexCollectionInvoice")
</div>
@Section Scripts
    <script>
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });
    </script>
End Section