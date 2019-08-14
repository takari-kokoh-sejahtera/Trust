@ModelType Trust.Tr_QuotationJoin
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Join Quotation</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="row">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ProspectCustomer_IDTo, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("ProspectCustomer_IDTo", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ProspectCustomer_IDTo, "", New With {.class = "text-danger"})
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ProspectCustomer_IDFrom, htmlAttributes:=New With {.class = "control-label col-md-3"})
                <div class="col-md-9">
                    @Html.DropDownList("ProspectCustomer_IDFrom", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.ProspectCustomer_IDFrom, "", New With {.class = "text-danger"})
                </div>
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
    @Html.ActionLink("Back to List", "IndexPOFromCustomer")
</div>
