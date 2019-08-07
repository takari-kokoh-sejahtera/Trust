@ModelType Trust.Ms_Customer_CompanyGroups
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>CompanyGroup</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayName("CompanyGroup Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyGroup_Name)
        </dd>
    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
