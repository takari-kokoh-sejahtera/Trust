@ModelType PagedList.IPagedList(Of Trust.Tr_Calculate)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Calculate Deviasi"
End Code

@Html.ActionLink("The list has been processed", "IndexDeviasiProcessed")

<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">@ViewData("Title")</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("IndexDeviasi", "Calculate", FormMethod.Get))
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
                                @Html.ActionLink("Company Group Name", "IndexDeviasi", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.ActionLink("Company_Name", "IndexDeviasi", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).IsVehicleExists)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Brand_Name)
                            </th>
                            <th>
                                @Html.ActionLink("Vehicle", "IndexDeviasi", New With {.sortOrder = "Vehicle", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Amount)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Rent_Location_Name)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Plat_Location_Name)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Modification)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).GPS_Cost)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Agent_Fee)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Update_OTR)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Update_Diskon)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Other)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Efektif_Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Replacement_Percent)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Maintenance_Percent)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Percent)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Overhead_Percent)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Assurance_Percent)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Bid_PricePerMonth)
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
                        </tr>
                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @*@If (item.IsQuotation = False) Then
                                            @Html.ActionLink("Deviasi", "EditDeviasiCal", New With {.id = item.Calculate_ID})
                                        End If*@
                                    @Html.ActionLink("Deviasi", "EditDeviasiCal", New With {.id = item.Calculate_ID})
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.IsVehicleExists)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Brand_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Vehicle)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Amount)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Rent_Location_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Plat_Location_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Modification)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.GPS_Cost)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Agent_Fee)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Update_OTR)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Update_Diskon)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Other)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Efektif_Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Replacement_Percent)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Maintenance_Percent)
                                </td>
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
                                    @Html.DisplayFor(Function(modelItem) item.Bid_PricePerMonth)
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
                    @Html.PagedListPager(Model, Function(page) Url.Action("IndexDeviasi", New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize}))
                </ul>
            </div>
        </div>
        <!-- /.box -->
    </div>
</div>
