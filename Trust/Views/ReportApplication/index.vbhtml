@ModelType PagedList.IPagedList(Of Trust.V_ProspectCustDetail)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Report Application "
End Code

<h2>Index</h2>

<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h4 class="box-title">@ViewData("Title")</h4>
                <div class="box-tools">
                    @Using (Html.BeginForm("Index", "ReportApplication", FormMethod.Get))
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
                                @Html.ActionLink("CompanyGroup Name", "Index", New With {.sortOrder = "CompanyGroup_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                                @*CompanyGroup Name*@
                            </th>
                            <th>
                                @Html.ActionLink("Company Name", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                                @*Company Name*@
                            </th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td style = "width:10px" >
                                    <img src="@Url.Action("IconMinPlus", "Image")/plus.png"/>
                                     <div style = "display:none" >
                                        <table class="ChildGrid" cellspacing="0" cellpadding="0">
                                 <tbody>
                                     <tr>
                                         <th>Type</th>
                                         <th>Transaction Type</th>
                                         <th>OTR Price</th>
                                         <th>Normasl Disc</th>
                                         <th>Qty</th>
                                         <th>Lease Long</th>
                                         <th>Create By</th>
                                     </tr>
                                     @for Each i In item.Detail
                                                @<tr>
                                                    <td style="white-space:nowrap">@i.Type</td>
                                                    <td style="white-space:nowrap">@i.Transaction_Type</td>
                                                    <td style="white-space:nowrap">@i.OTR_Price</td>
                                                    <td style="white-space:nowrap">@i.Normal_Disc</td>
                                                    <td style="white-space:nowrap">@i.Qty</td>
                                                    <td style="white-space:nowrap">@i.Lease_long</td>
                                                    <td style="white-space:nowrap">@i.CreatedBy</td>
                                                </tr>
                                     Next
                                            </tbody>
                                        </table>
                                  </div>
                                </td>
                                <td style="white-space:nowrap">
                                    @Html.DisplayFor(Function(modelItem) item.CompanyGroup_Name)
                                </td>
                                <td style = "white-space:nowrap" >
                                    @Html.DisplayFor(Function(modelItem) item.Company_Name)
                                </td>
                            </tr>
                        Next
                    </tbody>
                </Table>
            </div>
            <div Class="box-footer clearfix">
                <ul Class="pagination pagination-sm no-margin pull-right">
                    @Html.PagedListPager(Model, Function(page) Url.Action("Index", New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize}))
                </ul>
            </div>
        </div>
    </div>
</div>

<Script type = "text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

@Section Scripts
    <script>
        $("body").on("click", "img[src*='plus.png']", function () {
            $(this).closest("tr").after("<tr><td style='white - space: nowrap'></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
            $(this).attr("src", "@Url.Action("IconMinPlus", "Image")/minus.png");
        });
        //Assign Click event to Minus Image.
        $("body").on("click", "img[src*='minus.png']", function () {
            $(this).attr("src", "@Url.Action("IconMinPlus", "Image")/plus.png");
            $(this).closest("tr").next().remove();
        });

    </script>
End Section

