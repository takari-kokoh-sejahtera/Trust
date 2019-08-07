@ModelType PagedList.IPagedList(Of Trust.Tr_ApplicationHeader)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "ApplicationHeader"
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
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).IsExists)
                            </th>
                            <th>
                                @Html.ActionLink("CompanyGroup Name", "Index", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("City", "Index", New With {.sortOrder = "City", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("PIC Name", "Index", New With {.sortOrder = "PIC_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).IsTruck)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).IsQuick)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model

                            @<tr style="@item.Color">
                                 <td style="white-space:nowrap">
                                     @If item.Status = "Finish" Then
                                         @Html.ActionLink("Print", "Zip", New With {.id = item.ApplicationHeader_ID})
                                     End If
                                 </td>

                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsExists)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.City)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PIC_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsTruck)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsQuick)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.Status <> "Finish" Then
                                        @Html.ActionLink("Delete", "Delete", New With {.id = item.ApplicationHeader_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.Status <> "Finish" And Not item.IsNotApproved Then
                                        @Html.ActionLink("Edit", "Edit", New With {.id = item.ApplicationHeader_ID})
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.IsNotApproved Then
                                        @Html.DisplayFor(Function(modelItem) item.NotApproveSTR)
                                    End If
                                </td>
                                <td style="white-space:nowrap">
                                    @If item.IsNotApproved Then
                                        @Html.DisplayFor(Function(modelItem) item.RemarkNotApproved)
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

@Section Scripts
    <script>
        @*function Print(id) {
            return $.ajax({
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("Report", "ApplicationHeader")?id="id
            });
        }*@

    </script>
End Section
