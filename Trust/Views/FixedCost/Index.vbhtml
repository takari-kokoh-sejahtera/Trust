@ModelType PagedList.IPagedList(Of Trust.Trust.Ms_FixedCost)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "FixedCost"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>


<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Fixed Cost</h3>

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
                                STNK Percent
                            </th>
                            <th>
                                Overhead Percent
                            </th>
                            <th>
                                Assurance Percent
                            </th>
                            <th>
                                OJK
                            </th>
                            <th>
                                @Html.ActionLink("Created By", "Index", New With {.sortOrder = "CreatedBy", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                Created Date
                            </th>
                            <th>
                                @Html.ActionLink("Modified By", "Index", New With {.sortOrder = "ModifiedBy", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                Modified Date
                            </th>
                            <th>
                                Active
                            </th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Percent)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Overhead_Percent)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Assurance_Percent)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.OJK)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsDeleted)
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
