@ModelType Trust.Cn_GMs
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>GM</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.GM)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.GM)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Directorats.Directorat)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Directorats.Directorat)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.GM_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
