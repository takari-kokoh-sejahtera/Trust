@ModelType Trust.Tr_ApplicationHeader
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Application Header</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Application_No)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Application_No)
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
            @Html.DisplayNameFor(Function(model) model.Project_Rating)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Project_Rating)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Credit_Rating)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Credit_Rating)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Asset_Rating)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Asset_Rating)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Contracted_by)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contracted_by)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer_Class)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer_Class)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Capital)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Capital)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Signer_Name1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Signer_Name1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Signer_Position1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Signer_Position1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Signer_Name2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Signer_Name2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Authorized_Signer_Position2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Authorized_Signer_Position2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IntroducedBy)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IntroducedBy)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Outstanding_Balance_Group)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Outstanding_Balance_Group)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Outstanding_Balance_MUL_Group)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Outstanding_Balance_MUL_Group)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Outstanding_Balance_Amount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Outstanding_Balance_Amount)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.IsQuick)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsQuick)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.IsTruck)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsTruck)
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
