using System.Web;
using System.Web.Optimization;

namespace SERVOSA.SAIR.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string[] jqueryMinimal = new string[]
            {
                ""
            };

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryuiwithdatepickerculture").Include(
                        "~/Scripts/jquery-ui-1.9.2.js",
                        "~/Scripts/jquery.ui.datepicker-es.js"));

            bundles.Add(new StyleBundle("~/bundles/jtableStyles").Include(
                        "~/Content/themes/base/jquery-ui.css",
                        "~/Scripts/jtable/themes/jqueryui/jtable_jqueryui.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jtableReferences").Include(
                        "~/Scripts/jquery-ui-1.9.2.js", new CssRewriteUrlTransform())
                        .Include("~/Scripts/jtable/jquery.jtable.js", new CssRewriteUrlTransform())
                        .Include("~/Scripts/jtable/localization/jquery.jtable.es.js", new CssRewriteUrlTransform())
                        );

            bundles.Add(new ScriptBundle("~/bundles/Brands").Include(
                        "~/Scripts/ViewController/Brands/BrandViewController.js"
                        ));

            bundles.Add(new ScriptBundle("~/servosamaincore").Include(
                        "~/Scripts/Core/ServosaMainCore.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css"
                      , "~/Content/site.css"
                      ));
            bundles.Add(new ScriptBundle("~/Momentsjs").Include(
                    "~/Scripts/moment.js"
                ));

        }
    }
}
