@ModelType Trust.Cn_ApprovalUser
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Approval User</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="row">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.User_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("User_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(model) model.User_ID, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="form-group">
                @Html.Label("Approval", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.DropDownList("Approval_ID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                </div>
            </div>
            <div class="form-group">
                @Html.Label("Limited Approval", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.Editor("Limited_Approval", "Limited Approval", New With {.htmlAttributes = New With {.class = "form-control price"}})
                </div>
            </div>
            <div class="col-md-1">
                <a id="addToList" class="btn btn-primary">Add To List</a>
            </div>
        </div>
        <div class="box">
            <div Class="box-body table-responsive no-padding">
                <table id="detailsTable" class="table table-hover">
                    <thead>
                        <tr>
                            <th>Approval</th>
                            <th>Limited Approval</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="button" value="Create" id="save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    <script>
        $(".price").priceFormat({
            thousamdSeparator: ",",
            centsLimit: 0
        });

        $("#addToList").click(function (e) {
            e.preventDefault();
            var message = "";
            //if ($.trim($("#Approval").val()) == "" || $("#Limited_Approval").val() == "" || $("#Lease_long").val() == "" || !$.isNumeric($("#Lease_long").val()) || $("#Lease_price").val() == "" || !$.isNumeric($("#Lease_price").val().replace(/,/g, ""))) return;

            var Approval = $("#Approval_ID option:selected").text() || "",
                Approval_ID = $("#Approval_ID option:selected").val() || 0,
                Limited_Approval = $("#Limited_Approval").val() || 0,
                detailsTableBody = $("#detailsTable tbody");

            var orderHD = [];
            orderHD.length = 0;
            var orderArr = [];
            orderArr.length = 0;

            //Validateion
            if (Approval == "") { message = "Please select Approval"; }
            else if (Limited_Approval == 0) { message = "Must fill Limited Approval"; }

            if (message == "") {
                //Check Lagi apakah dia ada double di add nya
                $.each($("#detailsTable tbody tr"), function () {
                    orderArr.push({
                        Approval_ID: $(this).find('td:eq(0)').attr('id'),
                        Limited_ApprovalStr: $(this).find('td:eq(1)').html()
                    });
                });
                //Masukin juga yg baru
                orderArr.push({
                    Approval_ID: Approval_ID,
                    Limited_ApprovalStr: Limited_Approval
                });
                var data = JSON.stringify({
                    order: orderArr
                });
                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: "@Url.Action("CheckAdd", "ApprovalUser1")",
                    data: data,
                    success: function (data) {
                        if (data.result == "Success") {
                            var productItem = '<tr><td id="' + Approval_ID + '">' + Approval + '</td><td style="white-space:nowrap">' + Limited_Approval + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
                            detailsTableBody.append(productItem);
                            clearItem();
                        } else { alert(data.messages);}
                    },
                    error: function () {
                        alert(data.messages);
                    }
                });


            }
            else {
                alert(message);
            }
        });
        function clearItem() {
            $("#Limited_Approval").val('');
        }

        $(document).on('click', 'a.deleteItem', function (e) {
            e.preventDefault();
            var $self = $(this);
            if ($(this).attr('data-itemId') == "0") {
                $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
                    $(this).remove();
                });
            }
        });

        function saveOrder(data) {
            return $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                type: 'POST',
                url: "@Url.Action("CreateData", "ApprovalUser1")",
                data: data,
                success: function (data) {
                    if (data.result == "Success") {
                        alert("Success! Create Data Is Complete!");
                        window.location.href = '@Url.Action("Index", "ApprovalUser1")'
                    } else { alert(data.message)}
                },
                error: function () {
                    alert("Error!")
                }
            });
        }
        //Collect Multiple Order List For Pass To Controller
        $("#save").click(function (e) {
            e.preventDefault();
            var orderHD = [];
            orderHD.length = 0;
            var orderDetail = [];
            orderDetail.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                orderDetail.push({
                    Approval_ID: $(this).find('td:eq(0)').attr('id'),
                    Limited_ApprovalStr: $(this).find('td:eq(1)').html()
                });
            });

            orderHD.push({
                User_ID: $("#User_ID option:selected").val() || 0,
                Cn_ApprovalUserDetail: orderDetail
            });

            var data = JSON.stringify({
                appUser: orderHD
            });
            $.when(saveOrder(data)).success.then(function (response) {
                console.log(response);
            }).fail(function (err) {
                console.log(err);
            });
        });


    </script>
End Section