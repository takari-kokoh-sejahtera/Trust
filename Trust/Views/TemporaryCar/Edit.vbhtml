@ModelType Trust.Tr_TemporaryCar
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Temporary Car</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.TemporaryCar_ID)
        @Html.HiddenFor(Function(model) model.ContractDetail_ID)


        <div class="form-group">
            @Html.LabelFor(Function(model) model.Contract_No, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Contract_No, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Contract_No, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Type, New With {.htmlAttributes = New With {.class = "form-control", .readonly = "readonly"}})
                @Html.ValidationMessageFor(Function(model) model.Type, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.Label("Temporary Car", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @*@Html.EditorFor(Function(model) model.Vehicle_ID, New With {.htmlAttributes = New With {.class = "mySelect2 form-control"}})*@
                <select id="Vehicle_ID" name="Vehicle_ID" class="mySelect2 form-control" value="873"></select>
                @Html.ValidationMessage("Vehicle_ID", "", New With {.class = "text-danger"})
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
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>      End Using

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

        });
    </script>
End Section