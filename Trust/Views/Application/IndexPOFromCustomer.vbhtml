@ModelType PagedList.IPagedList(Of Trust.Trust.Tr_QuotationPO)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "POFromCustomer"
End Code

<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Upload SPH and PO</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("IndexPOFromCustomer", "Application", FormMethod.Get))
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
                                @Html.ActionLink("No Ref", "IndexPOFromCustomer", New With {.sortOrder = "No_Ref", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("CompanyGroup Name", "IndexPOFromCustomer", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("company name", "indexpofromcustomer", New With {.sortorder = "company_name", .currentfilter = ViewBag.currentfilter, .pagesize = ViewBag.pagesize})
                            </th>
                            <th>
                                Created Date
                            </th>
                            <th>
                                Created By
                            </th>
                            <th>
                                Modified Date
                            </th>
                            <th>
                                Modified By
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Fill SPH", "POFromCustomer", New With {.id = item.Quotation_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.No_Ref)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
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
                    @Html.PagedListPager(Model, Function(page) Url.Action("IndexPOFromCustomer", New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize}))
                </ul>
            </div>
        </div>
        <!-- /.box -->
    </div>
</div>