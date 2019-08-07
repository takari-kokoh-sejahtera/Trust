@ModelType Trust.Tr_Deliverys
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Tr_Deliverys</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Delivery_Method)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Delivery_Method)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Expedition_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Expedition_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Driver_Allocated)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Driver_Allocated)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Driver_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Driver_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BSTK_Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BSTK_Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsDeleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users1.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users1.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tr_ContractDetails.Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tr_ContractDetails.Remark)
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
