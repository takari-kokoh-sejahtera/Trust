@ModelType Trust.Cn_Titles
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Title</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.TItle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TItle)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.TItle_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
