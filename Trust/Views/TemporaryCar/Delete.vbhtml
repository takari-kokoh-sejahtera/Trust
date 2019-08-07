@ModelType Trust.Tr_TemporaryCar
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Temporary Car</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Contract_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contract_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CompanyGroup_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyGroup_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Company_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Company_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.license_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.license_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
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
