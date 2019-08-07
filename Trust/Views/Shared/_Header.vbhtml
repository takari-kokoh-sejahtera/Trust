<!-- Main Header -->
<header class="main-header">

    <!-- Logo -->
    <a href="@Url.Action("Index", "Home")" class="logo">
        <!-- mini logo for sidebar mini 50x50 pixels -->
        <span class="logo-mini"><b>T</b></span>
        <!-- logo for regular state and mobile devices -->
        <span class="logo-lg"><b>@Session("NameDB")</b></span>
    </a>

    <!-- Header Navbar -->
    <nav class="navbar navbar-static-top" role="navigation">
        <!-- Sidebar toggle button-->
        <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
            <span class="sr-only">Toggle navigation</span>
        </a>
        <!-- Navbar Right Menu -->
        <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
                <!-- /.messages-menu -->
                <!-- Notifications Menu -->
                <li class="dropdown notifications-menu">

                    @if ViewBag.Qty <> 0 Then

                        '<!-- Menu toggle button -->
                        @<a href="#" Class="dropdown-toggle" data-toggle="dropdown">
                            <i Class="fa fa-bell-o"></i>
                            <span Class="label label-warning">@ViewBag.Qty</span>
                        </a>
                        @<ul Class="dropdown-menu">
                            @*<li Class="header">You have 10 notifications</li>*@
                            <li>
                                <!-- Inner Menu: contains the notifications -->
                                <ul Class="menu">
                                    @if ViewBag.IsPasswordDefault = 1 Then
                                        @<li>
                                            <a href="@Url.Action("ChangePassword", "Home")">
                                                <i Class="fa fa-key text-aqua"></i> You must change the Password
                                            </a>
                                        </li>
                                    End If
                                    @if ViewBag.Quotation <> 0 Then
                                        @<li>
                                            <a href="@Url.Action("Index", "Approval")">
                                                <i Class="fa fa-question text-aqua"></i> @ViewBag.Quotation New approval
                                            </a>
                                        </li>

                                    End If
                                    @if ViewBag.POFromCust <> 0 Then
                                        @<li>
                                            <!-- start notification -->
                                            <a href="@Url.Action("IndexPOFromCustomer", "Application")">
                                                <i Class="fa fa-newspaper-o text-aqua"></i> @ViewBag.POFromCust New Input PO
                                            </a>
                                        </li>
                                    End If
                                    @if ViewBag.ApplicationPO <> 0 Then
                                        @<li>
                                            <!-- start notification -->
                                            <a href="@Url.Action("Index", "ApprovalPO")">
                                                <i Class="fa fa-newspaper-o text-aqua"></i> @ViewBag.ApplicationPO New Approve Application PO
                                            </a>
                                        </li>
                                    End If
                                    @if ViewBag.Application <> 0 Then
                                        @<li>
                                            <!-- start notification -->
                                            <a href="@Url.Action("Index", "ApprovalApp")">
                                                <i Class="fa fa-money text-aqua"></i> @ViewBag.Application New Application
                                            </a>
                                        </li>
                                    End If
                                    @if ViewBag.CountKYC <> 0 Then
                                        @<li>
                                            <!-- start notification -->
                                            <a href="@Url.Action("Create", "KYC")">
                                                <i Class="fa fa-money text-aqua"></i> @ViewBag.CountKYC New KYC
                                            </a>
                                        </li>
                                    End If
                                    @if ViewBag.CountReviewed <> 0 Then
                                        @<li>
                                            <!-- start notification -->
                                            <a href="@Url.Action("IndexReviewKYC", "KYC")">
                                                <i Class="fa fa-money text-aqua"></i> @ViewBag.CountReviewed New Review KYC
                                            </a>
                                        </li>
                                    End If
                                    <!-- end notification -->
                                </ul>
                            </li>
                        </ul>
                    End If
                </li>
                <!-- User Account Menu -->
                <li Class="dropdown user user-menu">
                    <!-- Menu Toggle Button -->
                    <a href="#" Class="dropdown-toggle" data-toggle="dropdown">
                        <!-- The user image in the navbar-->
                        @*<img src="@Url.Action("Profile", "Image")/@ViewBag.pic" onerror="this.src='@Url.Action("dist", "Content")/img/giphy.gif'" width="160" height="160" Class="user-image" alt="User Image">*@
                        <!-- hidden-xs hides the username on small devices so only the image appears. -->
                        <span Class="hidden-xs">@ViewBag.user</span>
                    </a>
                    <ul Class="dropdown-menu">
                        <!-- The user image in the menu -->
                        <li Class="user-header">
                            <img src="@Url.Action("Profile", "Image")/@ViewBag.pic" onerror="this.src='@Url.Action("dist", "Content")/img/giphy.gif'" Class="img-circle" alt="User Image">

                            <p>
                                @ViewBag.user - @ViewBag.title
                            </p>
                        </li>
                        <!-- Menu Footer-->
                        <li Class="user-footer">
                            <div Class="pull-left">
                                <a href="@Url.Action("ProfileUser", "Home")" Class="btn btn-default btn-flat">Profile</a>
                            </div>
                            <div Class="pull-right">
                                <a href="@Url.Action("Login", "Home")" Class="btn btn-default btn-flat">Sign out</a>
                            </div>
                        </li>
                    </ul>
                </li>
                <!-- Control Sidebar Toggle Button -->
                <li>
                    <a href="#" data-toggle="control-sidebar"><i Class="fa fa-gears"></i></a>
                </li>
            </ul>
        </div>
    </nav>
</header>
