@ModelType Trust.Tr_ApprovalPOs
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Tr_ApprovalPOs</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.MakerDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MakerDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MakerRemark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MakerRemark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CheckerDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CheckerDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CheckerRemark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CheckerRemark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval1Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval1Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval1Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval1Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval2Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval2Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval2Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval2Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval3Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval3Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval3Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval3Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval4Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval4Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval4Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval4Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval5Date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval5Date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Approval5Remark)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Approval5Remark)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StatusRecord)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StatusRecord)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RemarkNotApprove)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RemarkNotApprove)
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
            @Html.DisplayNameFor(Function(model) model.Cn_Users2.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users2.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users3.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users3.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users4.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users4.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users5.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users5.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users6.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users6.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users7.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users7.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cn_Users8.NIK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cn_Users8.NIK)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tr_ProspectCusts.Company_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tr_ProspectCusts.Company_Name)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ApprovalPO_ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
