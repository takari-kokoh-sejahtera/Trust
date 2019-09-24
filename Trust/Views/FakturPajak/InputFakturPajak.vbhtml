@ModelType Trust.Tr_FakturPajak
@Code
    ViewData("Title") = "InputFakturPajak"
End Code

<h2>Input Faktur Pajak</h2>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.NoFaktur_Start, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoFaktur_Start, New With {.htmlAttributes = New With {.Class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NoFaktur_Start, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NoFaktur_End, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NoFaktur_End, New With {.htmlAttributes = New With {.Class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NoFaktur_End, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Date_Start, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Date_Start, New With {.htmlAttributes = New With {.Class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Date_Start, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Date_End, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Date_End, New With {.htmlAttributes = New With {.Class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Date_End, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" id="save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

@Section Scripts
    <script>
  function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("SaveOrder", "FakturPajak")",
                data: data,
                success: function (data) {
                if (data.result != "Error") {
                alert("Success! Input Faktur Pajak Is Complete!\n" + data.result);
                window.location.href = '@Url.Action("Index", "Invoice")'
                } else { alert(data.message)}
                },
                error: function () {
                alert("Error!")
                }
                });
                }

                //Collect Multiple Order List For Pass To Controller
                $("#save").click(function (e) {
                e.preventDefault();

                
                var data = JSON.stringify({
                FakturPajak_ID: $("#FakturPajak_ID").val(),
                NoFaktur_Start: $("#NoFaktur_Start").val(),
                NoFaktur_End: $("#NoFaktur_End").val(),
                Date_Start: $("#Date_Start").val(),
                Date_End : $("#Date_End").val()
                });

               
                $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
                }).fail(function (err) {
                console.log(err);
                });
                });

    </script>
End Section

