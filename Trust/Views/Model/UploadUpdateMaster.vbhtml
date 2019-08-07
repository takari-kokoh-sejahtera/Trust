@Imports System.Data
@Code
    ViewData("Title") = "Upload"
End Code

<h2>Upload</h2>

@Using (Html.BeginForm("UploadUpdateMaster", "Model", Nothing, FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<div Class="form-group">
        <input type="file" id="dataFile" name="uploaded" />
    </div>

    @<div Class="form-group">
        <input type="submit" value="Upload" name="submit" Class="btn btn-default" />
    </div>
    @<div Class="form-group">
        @Html.Label("", htmlAttributes:=New With {.class = "Name=Messages control-label col-md-2"})
    </div>
    @ViewBag.Messages
End Using
<div>
    @Html.ActionLink("Back to List", "Index")
</div>
