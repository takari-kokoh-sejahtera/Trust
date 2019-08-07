@ModelType Trust.Tr_TotalLossOnly
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Total Loss Only</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Contract_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("Contract_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Contract_ID, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.ContractDetail_ID, "Vehicle From Contract", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("ContractDetail_ID", Nothing, "Please Select", htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ContractDetail_ID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Vehicle", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @*@Html.EditorFor(Function(model) model.Vehicle_ID, New With {.htmlAttributes = New With {.class = "mySelect2 form-control"}})*@
                <select id="Vehicle_ID" name="Vehicle_ID" class="mySelect2 form-control"></select>
                @Html.ValidationMessage("Vehicle_ID", "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Date, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Date, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Date, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Remark, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Remark, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Remark, "", New With {.class = "text-danger"})
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
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        $(document).ready(function () {
            $(".mySelect2").select2({
                placeholder: "Please Select",
                allowClear: true,
                theme: "classic",
                ajax: {
                    //url: "GetVehicle",
                    url: "@Url.Action("GetVehicle", "TemporaryCar")",
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return { searchTerm: params.term, ID: $('#ContractDetail_ID').val() };
                    },
                    processResults: function (data, params) {
                        return { results: data };
                    }

                }
            });
            //$('#mySelect2').val($("#Vehicle_ID").val()); // Select the option with a value of '1'
            //$('#mySelect2').trigger('change'); // Notify any JS components that the value changed
        });

        $('#Contract_ID').change(function () {
            $('#ContractDetail_ID option').remove();
            var t = $(this).val();
            $.ajax({
                url: '@Url.Action("GetContraactDetail", "TotalLossOnly")?ID=' + t,
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#ContractDetail_ID").append('<option>Please select</option>');
                    $.each(data, function (i, data) {
                        $("#ContractDetail_ID").append('<option value="'
                            + data.Value + '">'
                            + data.Text + '</option>');
                    });
                },
                error: function () {
                    alert("error");
                }
            });
        });

    </script>
End Section
