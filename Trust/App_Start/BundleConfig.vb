Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        'bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
        '            "~/Scripts/jquery.price_format.2.0.js",
        '            "~/Scripts/jquery.number.min.js",
        '            "~/Scripts/jquery-{version}.js"))


        'bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
        '            "~/Scripts/jquery.validate*"))
        ''Added for toaster
        'bundles.Add(New ScriptBundle("~/bundles/toastr").Include(
        '               "~/Scripts/toastr.js*",
        '               "~/Scripts/toastrImp.js"))
        '' Use the development version of Modernizr to develop with and learn from. Then, when you're
        '' ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        'bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
        '            "~/Scripts/modernizr-*"))

        ''bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
        ''          "~/Scripts/bootstrap.js"))

        'bundles.Add(New StyleBundle("~/Content/css").Include(
        '          "~/Content/bootstrap.css",
        '          "~/Content/toastr.css",
        '          "~/Content/site.css"))

        'BundleTable.EnableOptimizations = False

        bundles.Add(New ScriptBundle("~/Bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Content/dist/js/adminlte.js",
                    "~/Scripts/jquery.price_format.2.0.js",
                    "~/Scripts/jquery.number.min.js",
                    "~/Scripts/select2.js",
                    "~/Content/bower_components/jquery/dist/jquery.js",
                    "~/Content/bower_components/jquery/dist/jquery.js",
                    "~/Content/bower_components/chart.js/Chart.js",
                    "~/Content/bower_components/fastclick/lib/fastclick.js",
                    "~/Content/dist/js/demo.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Bundles/css").
                  Include("~/Content/PagedList.css", New CssRewriteUrlTransform()).
                  Include("~/Content/Costum.css", New CssRewriteUrlTransform()).
                  Include("~/Content/bootstrap.css", New CssRewriteUrlTransform()).
                  Include("~/Content/css/select2.css", New CssRewriteUrlTransform()).
                  Include("~/Content/bower_components/Ionicons/css/ionicons.min.css", New CssRewriteUrlTransform()).
                  Include("~/Content/bower_components/font-awesome/css/font-awesome.min.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/AdminLTE.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-blue.min.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-black-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-black.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-blue-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-green-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-green.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-purple-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-purple.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-red-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-red.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-yellow-light.css", New CssRewriteUrlTransform()).
                  Include("~/Content/dist/css/skins/skin-yellow.css", New CssRewriteUrlTransform())
                  )
        bundles.Add(New ScriptBundle("~/bundles/toastr").Include(
                       "~/Scripts/toastr.js*",
                       "~/Scripts/toastrImp.js"))
        'bundles.Add(New StyleBundle("~/Content/css").Include(
        '          "~/Content/bootstrap.css",
        '          "~/Content/site.css"))

        bundles.Add(New StyleBundle("~/BundlesLogin/css").
                  Include("~/Content/StyleLogin/css/StyleLogin.css", New CssRewriteUrlTransform()).
                  Include("~/Content/StyleLogin/css/bootstrap.min.css", New CssRewriteUrlTransform()))
        bundles.Add(New ScriptBundle("~/BundlesLogin/js").
                  Include("~/Content/StyleLogin/js/bootstrap.min.js").
                  Include("~/Content/StyleLogin/js/jquery-1.11.1.min.js"))

        BundleTable.EnableOptimizations = False

    End Sub
End Module

