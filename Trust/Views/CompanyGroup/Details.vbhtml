@ModelType Trust.Trust.Ms_Customer_CompanyGroups
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Company Group</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayName("CompanyGroup Name")
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyGroup_Name)
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.CompanyGroup_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
