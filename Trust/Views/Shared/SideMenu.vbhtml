<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            @Html.ActionLink("Trust", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        Config
                        <span class="caret"></span>
                    </a>
                    <ul id="Config" class="dropdown-menu" role="menu">
                        <li>@Html.ActionLink("Change Password", "ChangePassword", "Home")</li>
                        @For Each x In ViewBag.Config
                            @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                        Next
                    </ul>
                </li>
                <li>
                    <a Class="dropdown-toggle" data-toggle="dropdown" href="#">
                        Master
                        <span Class="caret"></span>
                    </a>
                    <ul id="Master" Class="dropdown-menu" role="menu">
                        @For Each x In ViewBag.Master
                            @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                        Next
                    </ul>
                </li>
                <li>
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        Transaksi
                        <span class="caret"></span>
                    </a>
                    <ul id="Transaksi" class="dropdown-menu" role="menu">
                        @For Each x In ViewBag.Transaksi
                            @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                        Next
                    </ul>
                </li>
                @*<li>
                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                    Report and Print
                    <span class="caret"></span>
                </a>
                <ul class="dropdown-menu" role="menu">
                    <li>@Html.ActionLink("Approval List Pending", "ApprovalList", "ProspectCustomer")</li>
                    <li>@Html.ActionLink("Agreement", "Agreement", "ProspectCustomer")</li>
                    <li>@Html.ActionLink("Purchase Order", "PurchaseOrder", "ProspectCustomer")</li>
                    <li>@Html.ActionLink("Handover", "Handover", "ProspectCustomer")</li>
                    <li>@Html.ActionLink("Invoice", "Invoice", "ProspectCustomer")</li>
                </ul>
            </li>*@
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li>@Html.ActionLink("Log Out", "Login", "Home")</li>

            </ul>

        </div>
    </div>
</div>