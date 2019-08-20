@ModelType PagedList.IPagedList(Of Trust.Tr_ApprovalApp)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "ApprovalApp"
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
                                @Html.ActionLink("Application No", "Index", New With {.sortOrder = "Application_No", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("CompanyGroup Name", "Index", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).MakerDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).MakerByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CheckerDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CheckerByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval1Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval1ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval2Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval2ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval3Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval3ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval4Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval4ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval5Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval5ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval6Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval6ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval7Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval7ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval8Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Approval8ByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).StatusRecord)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Status)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Remark)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedByStr)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedByStr)
                            </th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @*Jika LevelGroup dia Approve Quotation dan Bawahnya Jika sudah masuk DI Approve dia*@
                                    @if (item.Status = "Open" And item.StatusRecord = ViewBag.Level_ID - 1) Then
                                        @Html.ActionLink("Approval", "Create", New With {.id = item.ApprovalApp_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Print", "Zip", "ApplicationHeader", New With {.id = item.ApplicationHeader_ID}, Nothing)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Application_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.MakerDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.MakerByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CheckerDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CheckerByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval1Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval1ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval2Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval2ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval3Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval3ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval4Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval4ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval5Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval5ByStr)
                                </td>
                                 <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval6Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval6ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval7Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval7ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval8Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Approval8ByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.StatusRecord)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Status)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Remark)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedByStr)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedByStr)
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
