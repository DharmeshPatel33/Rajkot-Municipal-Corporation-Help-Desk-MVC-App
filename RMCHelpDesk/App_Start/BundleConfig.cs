using System.Web;
using System.Web.Optimization;

namespace RMCHelpDesk
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery-2.1.1.js",
                        "~/Scripts/js/bootstrap.min.js",
                        "~/Scripts/js/plugins/metisMenu/jquery.metisMenu.js",
                        "~/Scripts/js/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/Scripts/js/inspinia.js",
                        "~/Scripts/js/plugins/pace/pace.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/font/font-awesome/css/font-awesome.css",
                      "~/Content/css/plugins/morris/morris-0.4.3.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/style-md.css"));
        }
    }
}
