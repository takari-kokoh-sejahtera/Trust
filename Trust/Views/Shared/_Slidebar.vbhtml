<!-- Left side column. contains the logo and sidebar -->
<aside class="main-sidebar">

    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">

        <!-- Sidebar user panel (optional) -->
        <div class="user-panel">
            <div class="pull-left product-img">
                <img src="@Url.Action("Profile", "Image")/@ViewBag.pic" onerror="this.src='@Url.Action("dist", "Content")/img/giphy.gif'" width="210" height="180" class="img-circle" alt="User Image">
            </div>
        </div>

        <!-- search form (Optional) -->
        @*<form action="#" method="get" class="sidebar-form">
                <div class="input-group">
                    <input type="text" name="q" class="form-control" placeholder="Search...">
                    <span class="input-group-btn">
                        <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                            <i class="fa fa-search"></i>
                        </button>
                    </span>
                </div>
            </form>*@
        <!-- /.search form -->
        <!-- Sidebar Menu -->
        <ul class="sidebar-menu" data-widget="tree">
            @*<li class="header">HEADER</li>*@
            <!-- Optionally, you can add icons to the links -->
            @*<li class="active"><a href="#"><i class="fa fa-link"></i> <span>Link</span></a></li>*@
            @*<li><a href="#"><i class="fa fa-link"></i> <span>Another Link</span></a></li>*@
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-cog"></i> <span>Config</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </a>
                <ul class="treeview-menu">
                    <li><a href="@Url.Action("ChangePassword", "Home")">Change Password</a></li>
                    @For Each x In ViewBag.Config
                        @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                    Next
                </ul>
            </li>
            @If ViewBag.MasterCount <> 0 Then
                @:<li Class="treeview">
                    @:<a href="#">
                        @<i class="fa fa-sliders"></i> @<span> Master</span>
                        @<span Class="pull-right-container">
                            <i Class="fa fa-angle-left pull-right"></i>
                        </span>
                    @:</a>
                    @<ul Class="treeview-menu">
                        @For Each x In ViewBag.Master
                            @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                        Next
                    </ul>
                @:</li>


            End If
            @*<li class="treeview">
                <a href="#">
                    <i class="fa fa-check-square-o"></i> <span>Transaksi</span>
                    <span class="pull-right-container">
                        <i class="fa fa-angle-left pull-right"></i>
                    </span>
                </a>
                <ul class="treeview-menu">
                    @For Each x In ViewBag.Transaksi
                        @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                    Next
                </ul>
            </li>*@
            @If ViewBag.TransaksiCount <> 0 Then
                @:<li Class="treeview">
                    @:<a href="#">
                        @<i class="fa fa-check-square-o"></i> @<span> Transaksi</span>
                        @<span Class="pull-right-container">
                            <i Class="fa fa-angle-left pull-right"></i>
                        </span>
                    @:</a>
                    @<ul Class="treeview-menu">
                        @For Each x In ViewBag.Transaksi
                            @<li>@Html.ActionLink(x.Module_Name.ToString, x.Action.ToString, x.Route.ToString)</li>
                        Next
                    </ul>
                @:</li>


            End If

            @*<li><a href="@Url.Action("Login", "Home")"><i class="fa fa-sign-in"></i> <span>Log Out</span></a></li>*@
        </ul>
        <!-- /.sidebar-menu -->
    </section>
    <!-- /.sidebar -->
</aside>
