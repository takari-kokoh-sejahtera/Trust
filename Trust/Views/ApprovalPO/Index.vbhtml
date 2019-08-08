@ModelType PagedList.IPagedList(Of Trust.Tr_ApprovalPO)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "ApprovalPO"
End Code

@*<p>
        @Html.ActionLink("Create New", "Create")
    </p>*@


<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">@ViewData("Title")</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("Index", ViewData("Title").ToString(), FormMethod.Get))
                        @<div Class="input-group input-group-sm">
                            <p>
                                Show @Html.TextBox("PageSize", TryCast(ViewBag.pageSize, String), htmlAttributes:=New With {.style = "width:30px"}) @Html.TextBox("SearchString", TryCast(ViewBag.CurrentFilter, String))
                                <input type="submit" value="Search" />
                            </p>
                        </div>
                    End Using
                </div>
            </div>
            <!-- /.box-header -->
            <div Class="box-body table-responsive no-padding">
                <Table Class="table table-hover">
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>

                            <th>
                                @Html.ActionLink("No Ref", "Index", New With {.sortOrder = "No_Ref", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedBy)
                            </th>
                            <th>
                                Cost Price
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).MakerDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).MakerBy)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).MakerRemark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CheckerDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CheckerBy)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CheckerRemark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval1Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval1By)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval1Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval2Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval2By)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval2Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval3Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval3By)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval3Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval4Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval4By)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval4Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval5Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval5By)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval5Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).StatusRecord)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Status)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).RemarkNotApprove)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedBy)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @*Jika LevelGroup dia Approve Quotation dan Bawahnya Jika sudah masuk DI Approve dia*@
                                    @if (item.Approve) Then
                                        @Html.ActionLink("ApprovePO", "Create", New With {.id = item.ApprovalPO_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Print", "Zip", "ApprovalPO", New With {.id = item.ProspectCustomer_ID}, Nothing)
                                </td>
                                @*<td style="white-space:nowrap">
                                    @Html.ActionLink("Detail", "Detail", New With {.id = item.ApprovalPO_ID}, Nothing)
                                </td>*@

                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.No_Ref)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedBy)
                                </td>

                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Cost_Price)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.MakerDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.MakerBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.MakerRemark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CheckerDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CheckerBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CheckerRemark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval1Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval1By)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval1Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval2Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval2By)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval2Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval3Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval3By)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval3Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval4Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval4By)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval4Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval5Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval5By)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval5Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.StatusRecord)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Status)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.RemarkNotApprove)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedBy)
                                </td>
                            </tr>
                        Next
                    </tbody>
                </Table>
            </div>
            <!-- /.box-body -->
            <div class="box-footer clearfix">
                <ul class="pagination pagination-sm no-margin pull-right">
                    @Html.PagedListPager(Model, Function(page) Url.Action("Index", New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize}))
                </ul>
            </div>
        </div>
        <!-- /.box -->
    </div>
</div>

