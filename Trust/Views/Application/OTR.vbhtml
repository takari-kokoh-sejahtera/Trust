@ModelType Trust.Tr_Application
@Code
    ViewData("Title") = "Create"
End Code

<h2>Fill OTR</h2>

<div class="row">
    <div class="col-lg-6">
        <div class="form-group">
            @Html.LabelFor(Function(model) model.CompanyGroup_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.CompanyGroup_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Vehicle, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Update_OTR, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Update_OTRstr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                @Html.ValidationMessageFor(Function(model) model.Update_OTR, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Update_Diskon, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Update_Diskonstr, New With {.htmlAttributes = New With {.class = "form-control price"}})
                @Html.ValidationMessageFor(Function(model) model.Update_Diskon, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
    <div class="col-lg-6">
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Lease_price, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Lease_price, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Qty, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Qty, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Amount, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Amount, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Bid_PricePerMonth, htmlAttributes:=New With {.class = "control-label col-md-3"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Bid_PricePerMonth, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            </div>
        </div>
    </div>
    <br>
    <hr />
    <div class="form-group">
        <div class="col-md-offset-1 col-md-12">
            <input type="submit" value="Create" id="save" class="btn btn-default" />
        </div>
    </div>
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
