using System.Web;
using System.Web.Optimization;

namespace Bootstrap3
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryall").Include(
                        "~/Scripts/jquery.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryOdd").Include(
                        "~/Scripts/npm.js",                         
                          "~/Scripts/respond.min.js",
                           "~/Scripts/skycons.min.js",
                            "~/Scripts/waves.js",
                             "~/Scripts/wow.min.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/bootstrap-theme.css",
                       "~/Content/css/bootstrap-theme.css.map",
                        "~/Content/css/helper.css",
                        "~/Content/css/style.css",
                        "~/Content/css/waves-effect.css",
                          "~/Content/css/material-design-iconic-font.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets").Include(
                      "~/Content/assets/sweet-alert/sweet-alert.min.css",
                       "~/Content/assets/font-awesome/css/font-awesome.min.css",
                       "~/Content/assets/ionicon/css/ionicons.min.css",
                       "~/Contentcss/material-design-iconic-font.min.css"));
        }
    }
}
