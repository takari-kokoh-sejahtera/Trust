@ModelType PagedList.IPagedList(Of Trust.Trust.Ms_Contract_Signer)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Signer"
End Code


<p>
    @Html.ActionLink("Create New", "Create")
</p>


<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">@ViewData("Title")</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("Index", "Contract_Signer", FormMethod.Get))
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
                <table class="table table-hover">
                    <tr>
                        <th>
                            @Html.ActionLink("Name", "Index", New With {.sortOrder = "Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                        </th>
                        <th>
                            @Html.ActionLink("Title Ind", "Index", New With {.sortOrder = "Title_Ind", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                        </th>
                        <th>
                            @Html.ActionLink("Title Eng", "Index", New With {.sortOrder = "Title_Eng", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Sex)
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
                    </tr>

                    @For Each item In Model
                        @<tr>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Name)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Title_Ind)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Title_Eng)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Sex_Name)
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
                                @Html.ActionLink("Edit", "Edit", New With {.id = item.Signer_ID}) |
                                @Html.ActionLink("Details", "Details", New With {.id = item.Signer_ID}) |
                                @Html.ActionLink("Delete", "Delete", New With {.id = item.Signer_ID})
                            </td>
                        </tr>
                    Next

                </table>
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

