@ModelType PagedList.IPagedList(Of Trust.Trust.Ms_RiskGrading)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "RiskGrading"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>


<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Risk Grading</h3>

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
                                @Html.DisplayNameFor(Function(model) model(0).Project_Rating)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).RiskGrading)
                            </th>
                            <th>
                                @Html.ActionLink("Created By", "Index", New With {.sortOrder = "CreatedBy", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th>
                                @Html.ActionLink("Modified By", "Index", New With {.sortOrder = "ModifiedBy", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedDate)
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Project_Rating)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.RiskGrading)
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
                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.RiskGrading_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Details", "Details", New With {.id = item.RiskGrading_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.RiskGrading_ID})
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
