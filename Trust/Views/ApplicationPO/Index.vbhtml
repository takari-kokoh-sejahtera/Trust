@ModelType PagedList.IPagedList(Of Trust.Tr_ApplicationPO)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "ApplicationPO"
End Code

<p>
    @Html.ActionLink("List has not been processed", "IndexProcess")
</p>

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
                            <th>
                                @Html.ActionLink("ApplicationPO No", "Index", New With {.sortOrder = "ApplicationPO_No", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "CompanyName", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Vehicle", "Index", New With {.sortOrder = "Vehicle", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Color)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Delivery_Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Usage)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Qty)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Refund)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).PaymentByUser)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedBy)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedBy)
                            </th>
                            <th></th>
                            <th></th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ApplicationPO_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyName)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Vehicle)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Color)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Delivery_Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Usage)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Qty)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Refund)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PaymentByUser)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @*@Html.ActionLink("Edit", "Edit", New With {.id = item.ApplicationPO_ID}) |
                                        @Html.ActionLink("Details", "Details", New With {.id = item.ApplicationPO_ID}) |*@
                                    @If Not item.IsApplicationPO Then
                                        @Html.ActionLink("Delete", "Delete", New With {.id = item.ApplicationPO_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.IsNotApproved Then
                                        @Html.ActionLink("Not Approve", "Details", New With {.id = item.ApplicationPO_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.IsApplicationPO = True Then
                                        @Html.ActionLink("Print Application PO", "Zip", New With {.id = item.ProspectCustomer_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.IsApplication = True Then
                                     @Html.ActionLink("Print PO For Dealer", "Zip2", New With {.id = item.ProspectCustomer_ID})
                                    End If
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


