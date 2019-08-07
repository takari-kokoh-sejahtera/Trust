@ModelType PagedList.IPagedList(Of Trust.Trust.Ms_Customer_KYC)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "KYC Review"
End Code

<h2>Index</h2>


<div class="row">
    <div class="col-xs-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">@ViewData("Title")</h3>

                <div class="box-tools">

                    @Using (Html.BeginForm("IndexReviewKYC", "KYC", FormMethod.Get))
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
                        <th></th>
                        <th>
                            @Html.ActionLink("Name Customer", "Index", New With {.sortOrder = "Company_Name", .currentFilter = ViewBag.CurrentFilter, .pageSize = ViewBag.pageSize})
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Legal_Domicile_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Approval_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Approval_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Approval_From)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_States_Gazette_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_States_Gazette_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Supplement_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_Supplement_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOE_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Approval_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Approval_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_States_Gazette_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_States_Gazette_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Supplement_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_Supplement_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).AOA_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_SKT_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_SKT_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_SKT_Issued_By)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).NPWP_SKT_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SPPKP_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SPPKP_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SPPKP_Issued_By)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SPPKP_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_IssuedDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_IssuedBy)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_ExpiredDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_ExpiredDate_IsNA)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Business_License_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_IssuedDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_IssuedBy)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_ExpiredDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_ExpiredDate_IsNA)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).TDP_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_Address)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_IssuedDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_IssuedBy)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_ExpiredDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_ExpiredDate_IsNA)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SKDP_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Regarding)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA1_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Regarding)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA2_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Regarding)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA3_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Regarding)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA4_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Regarding)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).DOA5_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_Notary)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_City)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_Type)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_Letter_No)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_Letter_Date)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BOD_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoD_Period)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoD_Mention)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoD_Article)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoD_Appointment)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoD_Expired)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoC_Period)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoC_Mention)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoC_Article)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoC_Appointment)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).BoC_Expired)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Authorized_Capital_BasedOn)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Authorized_Capital)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Issued_Paidup_Capital)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaBy)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaBasedOn)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaDate)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaExpired)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaExpired_IsNA)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasaPenerima_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).SuratKuasa_IsUploaded)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Authorized_Person)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Annual_Income)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Purpose_of_Services)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Identitas)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model(0).Identitas_IsUploaded)
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

                    @For Each item In Model
                        @<tr>
                            <td style="white-space:nowrap">
                                @Html.ActionLink("Review", "Review", New With {.id = item.KYC_ID})
                            </td>

                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Customer_Name)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Legal_Domicile_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Approval_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Approval_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Approval_From)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_States_Gazette_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_States_Gazette_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Supplement_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOE_Supplement_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOE_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOE/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOE</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Approval_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Approval_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_States_Gazette_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_States_Gazette_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Supplement_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.AOA_Supplement_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.AOA_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/AOA/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View AOA</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.NPWP_No)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.NPWP_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/NPWP/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View NPWP</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.NPWP_SKT_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.NPWP_SKT_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.NPWP_SKT_Issued_By)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.NPWP_SKT_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/NPWP_SKT/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View NPWP SKT</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SPPKP_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SPPKP_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SPPKP_Issued_By)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.SPPKP_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/SPPKP/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View SPPKP</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License_IssuedDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License_IssuedBy)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License_ExpiredDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Business_License_ExpiredDate_IsNA)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.Business_License_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/BL/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View BL</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP_IssuedDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP_IssuedBy)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP_ExpiredDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.TDP_ExpiredDate_IsNA)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.TDP_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/TDP/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View TDP</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_Address)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_IssuedDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_IssuedBy)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_ExpiredDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SKDP_ExpiredDate_IsNA)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.SKDP_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/SKDP/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View SKDP</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Regarding)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA1_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOA1_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOA1/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOA1</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Regarding)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA2_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOA2_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOA2/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOA2</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Regarding)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA3_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOA3_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOA3/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOA3</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Regarding)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA4_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOA4_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOA4/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOA4</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Regarding)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.DOA5_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.DOA5_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/DOA5/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View DOA5</a>
                                End If
                            </td>

                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_Notary)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_City)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_Type)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_Letter_No)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BOD_Letter_Date)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.BOD_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/BOD/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View BOD</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoD_Period)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoD_Mention)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoD_Article)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoD_Appointment)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoD_Expired)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoC_Period)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoC_Mention)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoC_Article)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoC_Appointment)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.BoC_Expired)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Authorized_Capital_BasedOn)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Authorized_Capital)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Issued_Paidup_Capital)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SuratKuasaBy)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SuratKuasaBasedOn)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SuratKuasaDate)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SuratKuasaExpired)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.SuratKuasaExpired_IsNA)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.SuratKuasaPenerima_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/SuratKuasaPenerima/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View SuratKuasaPenerima</a>
                                End If
                            </td>
                            <td style="white-space:nowrap">
                                @If item.SuratKuasa_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/SuratKuasa/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View SuratKuasa</a>
                                End If
                            </td>


                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Authorized_Person)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Annual_Income)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.Purpose_of_Services)
                            </td>
                            <td style="white-space:nowrap">
                                @Html.DisplayFor(Function(modelItem) item.IdentitasView)
                            </td>
                            <td style="white-space:nowrap">
                                @If item.Identitas_IsUploaded Then
                                    @<a href="@Url.Action("Legal", "Image")/Identitas/@item.KYC_IDPDF.ToString()"
                                        Type="submit"
                                        id="runReport"
                                        target="_blank"
                                        Class="button Secondary">View Identitas</a>
                                End If
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





