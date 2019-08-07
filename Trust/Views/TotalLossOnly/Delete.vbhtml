@ModelType Trust.Tr_TotalLossOnly
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>TotalLoss Only</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Contract_No)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contract_No)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fromlicense_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fromlicense_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tolicense_no)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tolicense_no)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
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
