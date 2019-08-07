@ModelType PagedList.IPagedList(Of Trust.Ms_Customers)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Change Ownership"
End Code



<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">@ViewData("Title")</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("IndexChangeOwnership", "Customer".ToString(), FormMethod.Get))
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
                                @Html.ActionLink("Company Name", "IndexChangeOwnership", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("CompanyGroup Name", "IndexChangeOwnership", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayName("Created Date")
                            </th>
                            <th>
                                @Html.DisplayName("Created By")
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Address)
                            </th>
                            <th>
                                @Html.DisplayName("City")
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Phone)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Email)
                            </th>
                            <th>
                                @Html.DisplayName("PIC Name")
                            </th>
                            <th>
                                @Html.DisplayName("PIC Phone")
                            </th>
                            <th>
                                @Html.DisplayName("PIC Email")
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Notes)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Status)
                            </th>
                            <th>
                                @Html.DisplayName("NPWP")
                            </th>
                            <th>
                                @Html.DisplayName("Account")
                            </th>
                            <th>
                                @Html.DisplayName("Bank")
                            </th>
                            <th>
                                @Html.DisplayName("IsStamped")
                            </th>
                            <th>
                                @Html.DisplayName("Modified Date")
                            </th>
                            <th>
                                @Html.DisplayName("Modified By")
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @Code
                            Dim message = ""
                        End Code
                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Change Ownership", "ChangeOwnership", New With {.id = item.Customer_ID})
                                </td>

                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PT)
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                    @Select Case item.Tbk
                                        Case True
                                            message = " Tbk"
                                        Case False
                                            message = ""
                                    End Select
                                    @message.ToString()
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Ms_Customer_CompanyGroups.CompanyGroup_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Cn_Users.User_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Address)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Ms_Citys.City)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Phone)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Email)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PIC_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PIC_Phone)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PIC_Email)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Notes)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Status)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.NPWP)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Account)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Bank)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsStamped)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Cn_Users1.User_Name)
                                </td>
                            </tr>
                        Next
                    </tbody>
                </Table>
            </div>
            <!-- /.box-body -->
            <div class="box-footer clearfix">
                <ul class="pagination pagination-sm no-margin pull-right">
                    @Html.PagedListPager(Model, Function(page) Url.Action("IndexChangeOwnership", New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize}))
                </ul>
            </div>
        </div>
        <!-- /.box -->
    </div>
</div>
