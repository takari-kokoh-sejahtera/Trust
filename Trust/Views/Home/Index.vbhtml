@Code
    ViewData("Title") = "Home Page"
End Code

@*jika dia Marketing*@
@If ViewBag.Division_ID = 1 Then

    @<section Class="content-header">
        <h1>
            Marketing Dashboard
            <small>Preview page</small>
        </h1>
        <ol Class="breadcrumb">
            <li Class="active">Home</li>
        </ol>
    </section>
    @<section class="content">
        @Using (Html.BeginForm("Checked", "Home", FormMethod.Post, htmlAttributes:=New With {.enctype = "multipart/form-data"}))
            @Html.AntiForgeryToken()
            @if ViewBag.Role_ID = 8 Then
                @<div Class="row">
                    <div Class="col-md-12">
                        <div Class="box box-primary">
                            <div Class="box-header with-border">
                                <h3 Class="box-title">Check Prospect Marketing</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                </div>
                                <div Class="box-body table-responsive no-padding">
                                    <Table Class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Company Group Name
                                                </th>
                                                <th>
                                                    Company Name
                                                </th>
                                                <th>
                                                    Prospect Category
                                                </th>
                                                <th>
                                                    Status
                                                </th>
                                                <th>
                                                    Date
                                                </th>
                                                <th>
                                                    Notes
                                                </th>
                                                <th>
                                                    Check Note
                                                </th>
                                                <th></th>
                                            </tr>

                                        </thead>
                                        <tbody>
                                            @For i = 0 To ViewBag.ListChecker.Count - 1
                                                @Html.Hidden("[" + i.ToString + "].ProspectCustomerHistory_ID", ViewBag.ListChecker(i).ProspectCustomerHistory_ID)
                                                @<tr style="white-space:nowrap">
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).CompanyGroup_Name
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).Company_Name
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).ProspectCategory
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).Status
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).DateTrans
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @ViewBag.ListChecker(i).Notes
                                                    </td>
                                                    <td style="white-space:nowrap">
                                                        @Html.TextBox("[" + i.ToString + "].CheckNote", "")
                                                    </td>
                                                </tr>
                                            Next

                                        </tbody>
                                    </Table>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <input type="submit" value="Check" class="btn btn-default" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            End If
        End Using



        <div Class="row">
            <div Class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div Class="small-box bg-aqua">
                    <div Class="inner">
                        <h3>@ViewBag.Data.CountProspect</h3>

                        <p> Prospect Customer</p>
                    </div>
                    <div Class="icon">
                        <i Class="fa fa-shopping-cart"></i>
                    </div>
                    <a href="@Url.Action("Index", "Prospect")" Class="small-box-footer">
                        More info <i Class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <!-- ./col -->
            <div Class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div Class="small-box bg-green">
                    <div Class="inner">
                        <h3>@ViewBag.Data.CountCalculate</h3>

                        <p> Calculate</p>
                    </div>
                    <div Class="icon">
                        <i Class="ion ion-stats-bars"></i>
                    </div>
                    <a href="@Url.Action("Index", "Calculate")" Class="small-box-footer">
                        More info <i Class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <!-- ./col -->
            <div Class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div Class="small-box bg-yellow">
                    <div Class="inner">
                        <h3>@ViewBag.Data.CountQuotation</h3>

                        <p> Quotation</p>
                    </div>
                    <div Class="icon">
                        <i Class="ion ion-person-add"></i>
                    </div>
                    <a href="@Url.Action("Index", "Quotation")" Class="small-box-footer">
                        More info <i Class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
            <!-- ./col -->
            <div Class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div Class="small-box bg-red">
                    <div Class="inner">
                        <h3>@ViewBag.Data.CountProspectHistory</h3>

                        <p> Prospect</p>
                    </div>
                    <div Class="icon">
                        <i Class="ion ion-pie-graph"></i>
                    </div>
                    <a href="@Url.Action("Index", "Prospect")" Class="small-box-footer">
                        More info <i Class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>

        </div>

        <div Class="row">

            <div class="col-md-6">
                <!-- Prospect Customer CHART -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Prospect Customer</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <canvas id="canvas" height="203" width="271" style="width: 271px; height: 203px;"></canvas>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-md-6">
                <!-- Calculate CHART -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Calculate</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <canvas id="calculate" height="203" width="271" style="width: 271px; height: 203px;"></canvas>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-md-6">
                <!-- Quotation CHART -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Quotation</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <canvas id="quotation" height="203" width="271" style="width: 271px; height: 203px;"></canvas>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <div class="col-md-6">
                <!-- History CHART -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Prospect</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <div class="box-body chart-responsive" style="">
                        <canvas id="history" height="203" width="271" style="width: 271px; height: 203px;"></canvas>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <!-- ./col -->
        </div>
    </section>
End If

@Section Scripts
    <script>

        //Jika Divisi Marketing
        if (@ViewBag.Division_ID == 1) {

            window.onload = function () {

                var month = [];
                month.length = 0;
                var qty = [];
                qty.length = 0;

                var monthcal = [];
                monthcal.length = 0;
                var qtycal = [];
                qtycal.length = 0;

                var monthquot = [];
                monthquot.length = 0;
                var qtyquot = [];
                qtyquot.length = 0;

                var monthhistory = [];
                monthhistory.length = 0;
                var qtyhistory = [];
                qtyhistory.length = 0;

                $.ajax({
                    url: '@Url.Action("GetMarketingChar", "Home")',
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        if (data.success == "true") {

                            $.each(data.prospectCust, function (i, x) {
                                month.push(x.Month);
                                qty.push(x.Qty);
                            });
                            $.each(data.calculate, function (i, x) {
                                monthcal.push(x.Month);
                                qtycal.push(x.Qty);
                            });
                            $.each(data.quotation, function (i, x) {
                                monthquot.push(x.Month);
                                qtyquot.push(x.Qty);
                            });
                            $.each(data.prospectHistory, function (i, x) {
                                monthhistory.push(x.Month);
                                qtyhistory.push(x.Qty);
                            });

                            var lineChartData = {
                                labels: month,
                                datasets: [
                                    {
                                        label: "My First dataset",
                                        fillColor: "rgba(220,220,220,0.2)",
                                        strokeColor: "rgba(220,220,220,1)",
                                        pointColor: "rgba(220,220,220,1)",
                                        pointStrokeColor: "#fff",
                                        pointHighlightFill: "#fff",
                                        pointHighlightStroke: "rgba(220,220,220,1)",
                                        data: qty
                                    }
                                ]

                            }
                            var lineChartcalData = {
                                labels: monthcal,
                                datasets: [
                                    {
                                        label: "My First dataset",
                                        fillColor: "rgba(220,220,220,0.2)",
                                        strokeColor: "rgba(220,220,220,1)",
                                        pointColor: "rgba(220,220,220,1)",
                                        pointStrokeColor: "#fff",
                                        pointHighlightFill: "#fff",
                                        pointHighlightStroke: "rgba(220,220,220,1)",
                                        data: qtycal
                                    }
                                ]

                            }
                            var lineChartquotData = {
                                labels: monthquot,
                                datasets: [
                                    {
                                        label: "My First dataset",
                                        fillColor: "rgba(220,220,220,0.2)",
                                        strokeColor: "rgba(220,220,220,1)",
                                        pointColor: "rgba(220,220,220,1)",
                                        pointStrokeColor: "#fff",
                                        pointHighlightFill: "#fff",
                                        pointHighlightStroke: "rgba(220,220,220,1)",
                                        data: qtyquot
                                    }
                                ]

                            }
                            var lineCharthistoryData = {
                                labels: monthhistory,
                                datasets: [
                                    {
                                        label: "My First dataset",
                                        fillColor: "rgba(220,220,220,0.2)",
                                        strokeColor: "rgba(220,220,220,1)",
                                        pointColor: "rgba(220,220,220,1)",
                                        pointStrokeColor: "#fff",
                                        pointHighlightFill: "#fff",
                                        pointHighlightStroke: "rgba(220,220,220,1)",
                                        data: qtyhistory
                                    }
                                ]

                            }

                            var ctx = document.getElementById("canvas").getContext("2d");
                            window.myLine = new Chart(ctx).Line(lineChartData, {
                                responsive: true
                            });
                            var ctx1 = document.getElementById("calculate").getContext("2d");
                            window.myLine = new Chart(ctx1).Line(lineChartcalData, {
                                responsive: true
                            });
                            var ctx2 = document.getElementById("quotation").getContext("2d");
                            window.myLine = new Chart(ctx2).Line(lineChartquotData, {
                                responsive: true
                            });
                            var ctx3 = document.getElementById("history").getContext("2d");
                            window.myLine = new Chart(ctx3).Line(lineCharthistoryData, {
                                responsive: true
                            });

                        }
                        else if (data.success == "false") {
                        }
                        //else { alert("error"); }
                    },
                    error: function () {
                        alert("error");
                    }
                });

            }
        }
            window.SessionTimeout = (function() {
        var _timeLeft, _popupTimer, _countDownTimer;

        var stopTimers = function() {
            window.clearTimeout(_popupTimer);
            window.clearTimeout(_countDownTimer);
        };

        var updateCountDown = function() {
            var min = Math.floor(_timeLeft / 60);
            var sec = _timeLeft % 60;
            if(sec < 10)
                sec = "0" + sec;

            document.getElementById("CountDownHolder").innerHTML = min + ":" + sec;

            if(_timeLeft > 0) {
                _timeLeft--;
                _countDownTimer = window.setTimeout(updateCountDown, 1000);
            } else  {
                window.location = "Home/TimeOutPage";
            }
        };

        var showPopup = function() {
            _timeLeft = 60;
            updateCountDown();
            ClientTimeoutPopup.Show();
        };

        var schedulePopup = function() {
            stopTimers();
            _popupTimer = window.setTimeout(showPopup, @PopupShowDelay);
        };

        var sendKeepAlive = function() {
            stopTimers();
            ClientTimeoutPopup.Hide();
            SessionTimeout.schedulePopup();
        };

        return {
            schedulePopup: schedulePopup,
            sendKeepAlive: sendKeepAlive
        };

    })();

    </script>
End Section
@functions
    Public ReadOnly Property PopupShowDelay As Integer
        Get
            Return 1000 * (Convert.ToInt32(FormsAuthentication.Timeout.TotalSeconds) - 130)
        End Get
    End Property
End Functions