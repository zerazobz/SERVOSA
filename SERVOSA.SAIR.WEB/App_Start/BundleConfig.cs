﻿using System.Web;
using System.Web.Optimization;

namespace SERVOSA.SAIR.WEB
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryuiwithdatepickerculture").Include(
                        "~/Scripts/jquery-ui-1.9.2.js",
                        "~/Scripts/jquery.ui.datepicker-es.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-corlate.min.js",
                      "~/Scripts/html5shiv.js",
                      "~/Scripts/jquery.isotope.min.js",
                      "~/Scripts/jquery.prettyPhoto.js",
                      "~/Scripts/main.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        //"~/Content/bootstrap.css",
                        "~/Content/animate.min.css",
                        "~/Content/bootstrap-corlate.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/main.css",
                        "~/Content/prettyPhoto.css",
                        "~/Content/responsive.css",
                      "~/Content/site.css"));
        }
    }
}
