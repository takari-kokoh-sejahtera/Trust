@ModelType Trust.Tr_ProspectCust
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Prospect Customer</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.IsExists)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsExists)
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
            @Html.DisplayNameFor(Function(model) model.PT)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PT)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tbk)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tbk)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PIC_Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PIC_Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Notes)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Notes)
        </dd>

        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Status</th>
                            <th>Category</th>
                            <th>Date</th>
                            <th>Note</th>
                            <th>Check Note</th>
                            <th>Checked Date</th>
                            <th>Checked By</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each x In ViewBag.historys
                            @<tr>
                                <td style="white-space:nowrap">
                                    @x.Status
                                </td>
                                <td style="white-space:nowrap">
                                    @x.ProspectCategory
                                </td>
                                <td style="white-space:nowrap">
                                    @x.DateTrans
                                </td>
                                <td style="white-space:nowrap">
                                    @x.Notes
                                </td>
                                <td style="white-space:nowrap">
                                    @x.CheckNote
                                </td>
                                <td style="white-space:nowrap">
                                    @x.CheckedDate
                                </td>
                                <td style="white-space:nowrap">
                                    @x.CheckedBy
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </div>

    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.ProspectCustomer_ID}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
