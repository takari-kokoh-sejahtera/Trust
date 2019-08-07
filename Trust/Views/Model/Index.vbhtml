@ModelType PagedList.IPagedList(Of Trust.Ms_Vehicle_Models)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Model"
End Code

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<p>
    @Html.ActionLink("Download Template For Upload", "DownloadCSV")
</p>
<p>
    @Html.ActionLink("Upload Update Master", "UploadUpdateMaster")
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
                                @Html.ActionLink("Brand Name", "Index", New With {.sortOrder = "Brand_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Type", "Index", New With {.sortOrder = "Type", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                OTR Price
                            </th>
                            <th>
                                Normal Disc
                            </th>
                            <th>
                                Year1
                            </th>
                            <th>
                                Year2
                            </th>
                            <th>
                                Year3
                            </th>
                            <th>
                                Year4
                            </th>
                            <th>
                                Year5
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Description)
                            </th>
                            <th>
                                Is Keur
                            </th>
                            <th>
                                Is Truck
                            </th>
                            <th>
                                Asset Rating
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Active)
                            </th>
                            <th>
                                @Html.DisplayName("Created Date")
                            </th>
                            <th>
                                @Html.DisplayName("Created By")
                            </th>
                            <th>
                                @Html.DisplayName("Modified Date")
                            </th>
                            <th>
                                @Html.DisplayName("Modified By")
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
                                    @Html.DisplayFor(Function(modelItem) item.Ms_Vehicle_Brands.Brand_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Type)
                                </td>
                                <td style="white-space:nowrap">
                                    @String.Format("{0:n}", item.OTR_Price)
                                </td>
                                <td style="white-space:nowrap">
                                    @String.Format("{0:n}", item.Normal_Disc)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Year1)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Year2)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Year3)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Year4)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Year5)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Description)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsKeur)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsTruck)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Asset_Rating)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Active)
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
                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Model_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Details", "Details", New With {.id = item.Model_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Model_ID})
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



