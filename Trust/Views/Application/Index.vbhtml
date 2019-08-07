@ModelType IEnumerable(Of Trust.Tr_Applications)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Payment_Condition)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Modification)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.GPS_Cost)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.GPS_CostPerMonth)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Agent_Fee)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Agent_FeePerMonth)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Update_OTR)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Residual_Value)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Residual_ValuePercent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Expedition_Cost)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Keur)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Update_Diskon)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cost_Price)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Up_Front_Fee)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Up_Front_Fee_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Other)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Efektif_Date)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Replacement_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Replacement)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Maintenance_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Maintenance)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.STNK_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.STNK)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Overhead_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Overhead)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Assurance_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Assurance)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Lease_Profit)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Lease_Profit_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Depresiasi)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Depresiasi_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Funding_Interest)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Funding_Interest_Percent)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Bid_PricePerMonth)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IRR)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Funding_Rate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Spread)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedBy)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ModifiedBy)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Ms_Citys.City)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Ms_Citys1.City)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Payment_Condition)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Modification)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.GPS_Cost)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.GPS_CostPerMonth)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Agent_Fee)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Agent_FeePerMonth)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Update_OTR)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Residual_Value)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Residual_ValuePercent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Expedition_Cost)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Keur)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Update_Diskon)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cost_Price)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Up_Front_Fee)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Up_Front_Fee_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Other)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Efektif_Date)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Replacement_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Replacement)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Maintenance_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Maintenance)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.STNK_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.STNK)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Overhead_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Overhead)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Assurance_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Assurance)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Lease_Profit)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Lease_Profit_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Depresiasi)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Depresiasi_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Funding_Interest)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Funding_Interest_Percent)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Bid_PricePerMonth)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IRR)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Funding_Rate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Spread)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreatedDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreatedBy)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ModifiedBy)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsDeleted)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Ms_Citys.City)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Ms_Citys1.City)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Application_ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Application_ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Application_ID })
        </td>
    </tr>
Next

</table>
