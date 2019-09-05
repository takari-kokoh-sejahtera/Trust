﻿@ModelType Trust.Trust.Cn_Modules
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Cn_Modules</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Module_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Module_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tab)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tab)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Route)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Route)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Action)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Action)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsApproval)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsApproval)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Order)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Order)
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

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Module_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>