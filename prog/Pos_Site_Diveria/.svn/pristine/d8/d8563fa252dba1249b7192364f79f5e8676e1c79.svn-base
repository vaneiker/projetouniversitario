using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace STL.POS.Frontend.Web.App_Start
{
    public class BundleConfig
    {


        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // ----------------------------------------------------------------------------//
            // --------------------------------- SCRIPTS ----------------------------------//
            // ----------------------------------------------------------------------------//

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cbpNTAccordion*",
                        "~/Scripts/jquery.jstepper*",
                        "~/Scripts/jquery.mask*",
                        "~/Scripts/MaskedInput.js",
                        "~/Scripts/jquery.qtip.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                        "~/Scripts/underscore*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                        "~/Scripts/global.js"));

            bundles.Add(new ScriptBundle("~/bundles/kickstart").Include(
                        "~/Scripts/kickstart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popupbuttons").Include(
                        "~/Scripts/popup_btns.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockoutjs").Include(
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/ko.moneyExtender.js",
                        "~/Scripts/knockout.mapping*",
                        "~/Scripts/knockout-jqAutocomplete*"));

            bundles.Add(new ScriptBundle("~/bundles/autoKO").Include(
                        "~/Scripts/root/posViewModel.js",
                        "~/Scripts/root/paymentViewModel.js",
                        "~/Scripts/root/resumePricingViewModel.js",
                        "~/Scripts/Areas/Auto/additionalProductSelectedViewModel.js",
                        "~/Scripts/Areas/Auto/additionalCoverageViewModel.js",
                        "~/Scripts/Areas/Auto/productViewModel.js",
                        "~/Scripts/Areas/Auto/driverViewModel.js",
                        "~/Scripts/Areas/Auto/vehicleViewModel.js",
                        "~/Scripts/Areas/Auto/autoViewModel.js",
                        "~/Scripts/Areas/Auto/init.js",
                        "~/Scripts/Areas/Auto/finalBeneficiaryViewModel.js",
                        "~/Scripts/Areas/Auto/pepViewModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/saludKO").Include(
                        "~/Scripts/root/posViewModel.js",
                        "~/Scripts/root/paymentViewModel.js",
                        "~/Scripts/root/resumePricingViewModel.js",
                        "~/Scripts/Areas/Salud/personViewModel.js",
                        "~/Scripts/Areas/Salud/saludViewModel.js",
                        "~/Scripts/Areas/Salud/init.js"));

            bundles.Add(new ScriptBundle("~/bundles/security/login").Include(
                        "~/Scripts/Areas/Security/login_init.js"));

            bundles.Add(new ScriptBundle("~/bundles/security/changePassword").Include(
                        "~/Scripts/Areas/Security/changePassword_init.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").Include(
                        "~/Scripts/jquery.validate*")
                        .Include("~/Scripts/additional-methods*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui*",
                        "~/Scripts/datepicker-es.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                        "~/Scripts/moment*",
                        "~/Scripts/moment-with-locales*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/root/homeInit.js",
                        "~/Scripts/root/pagingQuotationViewModel.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/homeCountryBl").Include(
                       "~/Scripts/root/countryBlViewModel.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/selectQuotation").Include(
                       "~/Scripts/root/selectQuotationViewModel.js"
               ));


            // ----------------------------------------------------------------------------//
            // --------------------------------- STYLES ---------------------------------- //
            // ----------------------------------------------------------------------------//

            bundles.Add(new StyleBundle("~/Content/menuBundle")
                .Include("~/Content/menu.css"));

            bundles.Add(new StyleBundle("~/Content/accordion")
                .Include("~/Content/accordion.css"));

            bundles.Add(new StyleBundle("~/Content/amr")
                .Include("~/Content/amr.css",
                "~/Content/amr02.css",
                "~/Content/amr-custom.css",
                "~/Content/top_menu.css"));

            bundles.Add(new StyleBundle("~/Content/component")
                .Include("~/Content/component.css"));

            bundles.Add(new StyleBundle("~/Content/dtl")
                .Include("~/Content/dtl.css")
                .Include("~/Content/dtlCustom.css"));

            bundles.Add(new StyleBundle("~/Content/kickstart")
                .Include("~/Content/kickstart.min.css"));

            bundles.Add(new StyleBundle("~/Content/reset")
                .Include("~/Content/reset.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryuilib")
                .Include("~/Content/jqueryui/jquery-ui*",
                "~/Content/jqueryui/jquery-ui.structure*",
                "~/Content/jqueryui/jquery-ui.theme*",
                "~/Content/jquery.qtip.min.css"));

            bundles.Add(new StyleBundle("~/Content/vo")
                .Include("~/Content/vo_menu.css"));
        }
    }
}