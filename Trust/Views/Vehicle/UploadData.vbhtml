@ModelType Trust.Ms_Vehicle_Import_Form
@Code
    ViewData("Title") = "UploadData"
End Code

<h2>Upload Data Vehicle</h2>

@Using (Html.BeginForm("UploadData", "Vehicle", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<div Class="form-group">
        <div Class="col-md-12">
            @Html.TextBoxFor(Function(model) model.uploaded, New With {.accept = "application/xlsx,application", .type = "file", .htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.uploaded, "", New With {.class = "text-danger"})
        </div>
    </div>
    @<div Class="form-group">
         <div Class="col-md-12">
             @Html.CheckBoxFor(Function(model) model.TKS, New With {.htmlAttributes = New With {.class = "form-control"}}) TKS
             @Html.CheckBoxFor(Function(model) model.Trust, New With {.htmlAttributes = New With {.class = "form-control"}}) Trust
         </div>
    </div>

    @<div Class="form-group">
        <input type="submit" value="Upload" name="submit" Class="btn btn-default" />
    </div>
    @<div Class="form-group">
        @Html.Label("", htmlAttributes:=New With {.class = "Name=Messages control-label col-md-2"})
    </div>
    @ViewBag.Message
End Using
<div>
    @Html.ActionLink("Back to List", "Index")
</div>
