@ModelType PagedList.IPagedList(Of Trust.Trust.Tr_TemporaryCar)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "TemporaryCar"
End Code

<p>
    @Html.ActionLink("Create New", "Create")
</p>

<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Temporary Car</h3>

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
                                @Html.ActionLink("Contract No", "Index", New With {.sortOrder = "Contract_No", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Group Name", "Index", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("License No", "Index", New With {.sortOrder = "license_no", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Type", "Index", New With {.sortOrder = "Type", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>

                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            @*<th></th>*@
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Contract_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.license_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Type)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Details", "Details", New With {.id = item.TemporaryCar_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @if (item.IsDelivery = False) And (item.IsInvoiced = False) Then
                                        @Html.ActionLink("Delete", "Delete", New With {.id = item.TemporaryCar_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @if (item.IsDelivery = False) And (item.IsInvoiced = False) Then
                                        @Html.ActionLink("Edit", "Edit", New With {.id = item.TemporaryCar_ID})
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

