@ModelType Trust.Ms_Contract_Signer
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Signer</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Title_Ind)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title_Ind)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Title_Eng)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Title_Eng)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sex_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sex_Name)
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
