@ModelType Trust.Ms_Citys
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>City</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Provinsi)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Provinsi)
        </dd>
        <dt>
            Expedition Cost
        </dt>

        <dd>
            @String.Format("{0:n}", Model.Expedition_Cost)
        </dd>
        <dt>
            Kode Plat
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Kode_Plat)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Remark)
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
