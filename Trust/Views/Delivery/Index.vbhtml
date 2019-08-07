@ModelType IEnumerable(Of Trust.Trust.Tr_Deliverys)
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
            @Html.DisplayNameFor(Function(model) model.Delivery_Method)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Expedition_Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Driver_Allocated)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Driver_Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BSTK_Date)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CreatedDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ModifiedDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cn_Users.NIK)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cn_Users1.NIK)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Tr_ContractDetails.Remark)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Delivery_Method)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Expedition_Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Driver_Allocated)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Driver_Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BSTK_Date)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CreatedDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ModifiedDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsDeleted)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cn_Users.NIK)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cn_Users1.NIK)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Tr_ContractDetails.Remark)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Delivery_ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Delivery_ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Delivery_ID })
        </td>
    </tr>
Next

</table>
