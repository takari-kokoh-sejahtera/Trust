@ModelType PagedList.IPagedList(Of Trust.Trust.Ms_Vehicle)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Vehicle"
End Code

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<p>
    @Html.ActionLink("Upload Data", "UploadData")
</p>

@Using (Html.BeginForm("ExportExcel", "Vehicle", FormMethod.Post))
    @<input type="submit" value="Download Tempalte for Upload" />
End Using


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
                                @Html.ActionLink("License No", "Index", New With {.sortOrder = "license_no", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Tmp_Plat)
                            </th>
                            <th>
                                @Html.ActionLink("Model", "Index", New With {.sortOrder = "Model", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                Type
                            </th>
                            <th>
                                @Html.ActionLink("Color", "Index", New With {.sortOrder = "color", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                            </th>
                            <th>
                                Year
                            </th>
                            <th>
                                Chassis No
                            </th>
                            <th>
                                Machine No
                            </th>
                            <th>
                                Title No
                            </th>
                            <th>
                                Serial No
                            </th>
                            <th>
                                Registration_no
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).registration_expdate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).insurance_no)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).discount)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).price)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).acquisition)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).coverage)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).comment)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).date_insurance_start)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).date_insurance_end)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).date_insurance_mod)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).date_book)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_No)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Publish)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Yearly_Renewal)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_5Year_Renewal)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Month)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Name)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Address)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CC)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Fuel)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).NoUrutBuku)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).DO_date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Vehicle_Come)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).STNK_Receipt)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).PO_No)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Harga_Beli)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Kwitansi_Date)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Kwitansi_No)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).FakturPajak)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).FakturPajak_No)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).VAT)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).Dealer)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedDate)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).CreatedBy)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model(0).ModifiedBy)
                            </th>
                            <th></th>
                        </tr>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.license_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Tmp_Plat)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Model)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.type)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.color)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.year)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.chassis_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.machine_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.title_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.serial_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.registration_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.registration_expdate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.insurance_no)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.discount)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.price)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.acquisition)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.coverage)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.comment)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.date_insurance_start)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.date_insurance_end)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.date_insurance_mod)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.date_book)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Publish)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Yearly_Renewal)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_5Year_Renewal)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Month)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Name)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Address)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CC)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Fuel)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.NoUrutBuku)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.DO_date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Vehicle_Come)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.STNK_Receipt)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.PO_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Harga_Beli)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Kwitansi_Date)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Kwitansi_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.FakturPajak)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.FakturPajak_No)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.VAT)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.Dealer)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CreatedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.ModifiedBy)
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Vehicle_id}) |
                                    @Html.ActionLink("Details", "Details", New With {.id = item.Vehicle_id}) |
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Vehicle_id})
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
