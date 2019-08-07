@ModelType Trust.Cn_Roles
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Role</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.Label("Role Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Role_Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Role_Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
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
                    @<tr><td><input type="checkbox" id=@x.Module_ID /></td><td>@x.Module_Name</td><td>@x.Tab</td></tr>
                Next
            </tbody>
        </table>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input id="saveOrder" type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    <script>
        //After Click Save Button Pass All Data View To Controller For Save Database
        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("SaveOrder", "Role")",
                data: data,
                success: function (result) {
                    if (result != "Error") {
                        alert("Success! Role Is Complete!\n" + result);
                        window.location.href = '@Url.Action("Index", "Role")'
                    } else { alert("Error! Role Is Not Complete!")}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#saveOrder").click(function (e) {
            e.preventDefault();

            var orderArr = [];
            orderArr.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                //if ($(this).find('input:eq(0)').prop('checked')) {
                    orderArr.push({
                        Module_ID: $(this).find('input:eq(0)').attr('id'),
                        IsDeleted: $(this).find('input:eq(0)').prop('checked')
                    });
                //}
            });

            var data = JSON.stringify({
                Role_Name: $("#Role_Name").val(),
                order: orderArr
            });

            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });
    </script>
End Section
