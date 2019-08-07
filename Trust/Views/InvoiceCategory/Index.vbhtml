@ModelType IEnumerable(Of Trust.Trust.Ms_Invoice_Categorys)
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
            @Html.DisplayNameFor(Function(model) model.Invoice_Category_Name)
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
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Invoice_Category_Name)
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
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Invoice_Category_ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Invoice_Category_ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Invoice_Category_ID })
        </td>
    </tr>
Next

</table>
