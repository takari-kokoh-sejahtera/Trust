@ModelType Trust.Ms_FixedCost
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Fixed Cost</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.STNK_Percent, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.STNK_Percent, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.STNK_Percent, "", New With {.class = "text-danger"})
            </div>
            @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Overhead_Percent, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Overhead_Percent, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Overhead_Percent, "", New With {.class = "text-danger"})
            </div>
            @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Assurance_Percent, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.Assurance_Percent, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Assurance_Percent, "", New With {.class = "text-danger"})
            </div>
            @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.OJK, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-9">
                @Html.EditorFor(Function(model) model.OJK, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.OJK, "", New With {.class = "text-danger"})
            </div>
            @Html.Label("%", htmlAttributes:=New With {.class = "control-label col-md-1"})
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
