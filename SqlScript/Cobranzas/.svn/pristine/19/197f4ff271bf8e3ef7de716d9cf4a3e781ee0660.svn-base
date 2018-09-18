using System.Web;
using System.Web.Optimization;

namespace KSI.Cobranza.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/jquery-ui-1.9.2.custom.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-switch.css",
                      "~/Content/font-awesome.css",
                      "~/Content/kredisi.css",
                      "~/Content/kredisi-menu.css",
                      "~/Content/vo_menu.css",
                      "~/Content/cobranzas.css",
                      "~/Content/Master.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/jquery-ui-1.9.2.custom.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-switch.js",
                      "~/Scripts/MaskedInput.js",
                      "~/Scripts/alertify.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsExt").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.unobtrusive.js",
                      "~/Scripts/JSTools.js",
                      "~/Scripts/Layout.js",
                      "~/Scripts/MaskedInput.js",
                      "~/Scripts/date.format.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/Search").Include(
                     "~/Scripts/ViewJS/Search.js"
                     ));  

            bundles.Add(new ScriptBundle("~/bundles/Process").Include(
                     "~/Scripts/ViewJS/Process.js"
                     ));
        }
    }
}
