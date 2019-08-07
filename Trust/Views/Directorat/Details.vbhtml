@ModelType Trust.Cn_Directorats
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Directorat</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Directorat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Directorat)
        </dd>
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Directorat_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
