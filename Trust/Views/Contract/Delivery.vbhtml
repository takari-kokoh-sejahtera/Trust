@ModelType Trust.Tr_Delivery
@Code
    ViewData("Title") = "Delivery"
End Code

<h2>@ViewData("Title")</h2>

@Using (Html.BeginForm("FileUploadDelivery", "Contract", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Contract Receipt</h4>
    <hr />

    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(x) x.ContractDetail_ID)
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Company_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Company_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.Company_Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Brand_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Brand_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.Brand_Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Vehicle, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Vehicle, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.Vehicle, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.license_no, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.license_no, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
            @Html.ValidationMessageFor(Function(model) model.license_no, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.DeliveryDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DeliveryDate, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Address_Delivery, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Address_Delivery, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.PIC_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.PIC_Name, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.PIC_Number, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.PIC_Number, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Delivery_Method, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("Delivery_Method", Nothing, htmlAttributes:=New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.Delivery_Method, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Expedition_Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Expedition_Name, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
            @Html.ValidationMessageFor(Function(model) model.Expedition_Name, "", New With {.class = "text-danger"})
        </div>
    </div>
   
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Driver_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownList("Driver_ID", Nothing, "Please select", htmlAttributes:=New With {.class = "form-control", .disabled = "disabled"})
            @Html.ValidationMessageFor(Function(model) model.Driver_ID, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.BSTK_Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.BSTK_Date, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.BSTK_Date, "", New With {.class = "text-danger"})
        </div>
    </div>

    <!-- Profile Image -->
    <div class="box box-primary">
        <div class="box-body box-profile">
            <label for="file">Upload BSTK:</label>
            <input type="file" name="file" id="file" style="width: 100%;" accept="application/pdf,application/vnd.ms-excel" />
            <input type="submit" value="Upload" class="submit" />
            @Html.ValidationMessageFor(Function(model) model.Delivery_ID, "", New With {.class = "text-danger"})
        </div>
        <!-- /.box-body -->
    </div>
</div>End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        $(document).ready(function () {
            if ($('#Delivery_Method').val() == 'Expedition') {
                document.getElementById("Expedition_Name").disabled = false;
                document.getElementById("Driver_ID").disabled = true;
                document.getElementById("file").disabled = false;
            } else {
                document.getElementById("Expedition_Name").disabled = true;
                document.getElementById("Driver_ID").disabled = false;}
                document.getElementById("file").disabled = true;
        });

        $('#Delivery_Method').change(function () {
            $("#Expedition_Name").val('');
            if ($('#Delivery_Method').val() == 'Expedition') {
                document.getElementById("Expedition_Name").disabled = false;
                document.getElementById("Driver_ID").disabled = true;
                document.getElementById("file").disabled = false;
            } else {
                document.getElementById("Expedition_Name").disabled = true;
                document.getElementById("Driver_ID").disabled = false;
                document.getElementById("file").disabled = true;
            }
        });
    </script>
End Section
