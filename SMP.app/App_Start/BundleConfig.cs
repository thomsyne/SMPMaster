using System.Web;
using System.Web.Optimization;

namespace SMP.app
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/temp/vendors/jquery/dist/jquery.min.js",
                         "~/temp/vendors/bootstrap/dist/js/bootstrap.min.js",
                         "~/temp/vendors/fastclick/lib/fastclick.js",
                         "~/temp/vendors/nprogress/nprogress.js",
                         "~/temp/vendors/Chart.js/dist/Chart.min.js",
                         "~/temp/vendors/gauge.js/dist/gauge.min.js",
                         "~/temp/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                         "~/temp/vendors/iCheck/icheck.min.js",
                         "~/temp/vendors/skycons/skycons.js",
                         "~/temp/vendors/Flot/jquery.flot.js",
                         "~/temp/vendors/Flot/jquery.flot.pie.js",
                         "~/temp/vendors/Flot/jquery.flot.time.js",
                         "~/temp/vendors/Flot/jquery.flot.stack.js",
                         "~/temp/vendors/Flot/jquery.flot.resize.js",
                         "~/temp/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                         "~/temp/vendors/flot-spline/js/jquery.flot.spline.min.js",
                         "~/temp/vendors/flot.curvedlines/curvedLines.js",
                         "~/temp/vendors/DateJS/build/date.js",
                         "~/temp/vendors/jqvmap/dist/jquery.vmap.js",
                         "~/temp/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                         "~/temp/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                         "~/temp/vendors/moment/min/moment.min.js",
                         "~/Scripts/datepicker/bootstrap-datepicker.js",
                         "~/temp/vendors/bootstrap-daterangepicker/daterangepicker.js",
                         "~/temp/build/js/custom.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/temp/vendors/bootstrap/dist/css/bootstrap.min.css",
                   "~/temp/vendors/font-awesome/css/font-awesome.min.css",
                   "~/temp/vendors/nprogress/nprogress.css",
                   "~/temp/vendors/iCheck/skins/flat/green.css",
                   "~/temp/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                   "~/temp/vendors/jqvmap/dist/jqvmap.min.css",
                    "~/Content/alertifyjs/css/themes/default.css",
                   "~/Content/alertifyjs/css/alertify.min.css",
                   "~/temp/vendors/bootstrap-daterangepicker/daterangepicker.css",
                   "~/temp/build/css/custom.min.css",
                   "~/Content/custom.css"));
        }
    }
}

