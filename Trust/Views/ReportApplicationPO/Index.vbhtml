@ModelType PagedList.IPagedList(Of Trust.Tr_ApplicationPO)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Application PO"
End Code

<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Application PO</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("Index", "ReportApplicationPO", FormMethod.Get))
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
                            <th>
                                @Html.ActionLink("No Ref", "Index", New With {.sortOrder = "No_Ref", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "CompanyName", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Vehicle", "Index", New With {.sortOrder = "Vehicle", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Qty)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).QtyAppPO)
                            </th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                 <td></td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.No_Ref)
                                </td>
                                <td style = "white-space:nowrap" >
                                    @Html.DisplayFor(Function(modelItem) item.CompanyName)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Vehicle)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Qty)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.QtyAppPO)
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
<div>
    @Html.ActionLink("Back to List", "Index")
</div>

