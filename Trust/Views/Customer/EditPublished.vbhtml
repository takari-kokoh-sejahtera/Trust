@ModelType Trust.Ms_CustomerPublisher
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
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            @Html.HiddenFor(Function(model) model.Customer_ID)

            <div class="form-group">
                @Html.Label("Compay Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                    @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Published, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Published, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Published, "", New With {.class = "text-danger"})
                </div>
            </div>
        </dim>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>  End Using

<div>
    @Html.ActionLink("Back to List", "IndexPublished")
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
