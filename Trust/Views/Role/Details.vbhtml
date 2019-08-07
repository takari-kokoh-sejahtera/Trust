@ModelType Trust.Cn_Roles
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Role</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            Role Name
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Role_Name)
        </dd>

        <dt>
            Created Date
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedDate)
        </dd>

        <dt>
            Created By
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedBy)
        </dd>

        <dt>
            Modified Date
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedDate)
        </dd>

        <dt>
            Modified By
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModifiedBy)
        </dd>
    </dl>
    <table id="detailsTable" class="table">
        <thead>
            <tr>
                <th style="width:5%">Select</th>
                <th style="width:15%">Module Name</th>
                <th style="width:15%">Tab</th>
            </tr>
        </thead>
        <tbody id="tbodyid">
            @For Each x In ViewBag.detail
                @<tr id="@IIf(x.IsDeleted = True, "False", "True")"><td id=@x.RoleAuthorization_ID><input type="checkbox" id=@x.Module_ID /></td><td>@x.Module_Name</td><td>@x.Tab</td></tr>
            Next
        </tbody>
    </table>

</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Role_ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
@Section Scripts
    <script>
        $(document).ready(function () {
            $("#detailsTable tbody tr").each(function () {
                if ($(this).attr('id') == 'True') {
                    $(this).find("input[type=checkbox]").attr("checked", true);
                }
            });
        });
    </script>
End Section