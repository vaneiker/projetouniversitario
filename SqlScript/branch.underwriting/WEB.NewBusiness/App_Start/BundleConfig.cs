using System.Web;
using System.Web.Optimization;

namespace WEB.NewBusiness.App_Start
{     /*
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/GeneralA")
                .Include("~/Scripts/modernizr.custom.js")
                .Include("~/Scripts/JQuery/Core/jquery-1.9.1.js")
                .Include("~/Scripts/JQuery/JQueryUI/jquery-ui-1.10.3.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/GeneralB")
                .Include("~/Scripts/classie.js")
                .Include("~/Scripts/sidebarEffects.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/GeneralC")
                .Include("~/Scripts/jquery.nicescroll.min.js")
                .Include("~/Scripts/ga.js")
                .Include("~/Scripts/jquery.nestedAccordion.js")
                .Include("~/Scripts/grids.min.js")
                .Include("~/Scripts/jquery.sliderTabs.js")
                .Include("~/Scripts/scripts.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/TableEffects")
                .Include("~/Scripts/TableEffects.js")
                );

            bundles.Add(new StyleBundle("~/bundles/JqueryUI")
                .Include("~/Scripts/JQuery/JQueryUI/jquery-ui-1.9.0.custom.min.css", new CssRewriteUrlTransformWrapper())
                );

            bundles.Add(new StyleBundle("~/bundles/CSS")
                .Include("~/Content/Site.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/style.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/Master.css", new CssRewriteUrlTransformWrapper())
                );

            bundles.Add(new ScriptBundle("~/AddNewClient/AddNewClient")
               .Include("~/Scripts/JSPages/AddNewClient/AddNewClient.js")
               );

            bundles.Add(new ScriptBundle("~/Requirements/Requirements")
             .Include("~/Scripts/JSPages/Requirements/Requirements.js")
             );

            bundles.Add(new ScriptBundle("~/SubmittedPolicies/SubmittedPolicies")
               .Include("~/Scripts/JSPages/SubmittedPolicies/SubmittedPolicies.js")
               );

            bundles.Add(new ScriptBundle("~/ReadyToReview/ReadyToReview")
              .Include("~/Scripts/JSPages/ReadyToReview/ReadyToReview.js")
              );

            bundles.Add(new ScriptBundle("~/CasesInProcess/CasesInProcess")
            .Include("~/Scripts/JSPages/CasesInProcess/CasesInProcess.js")
            );

            bundles.Add(new ScriptBundle("~/JQWidgets/jqxCss")
                .Include("~/Scripts/JQuery/Pluggins/JQWidgets/styles/jqx.base.css")
                .Include("~/Scripts/JQuery/Pluggins/JQWidgets/styles/jqx.black.css")
               );

            bundles.Add(new ScriptBundle("~/JQWidgets/jqx-all")
             .Include("~/Scripts/JQuery/Pluggins/JQWidgets/jqx-all.js")
             );

            bundles.Add(new ScriptBundle("~/Utilities/JSTools")
             .Include("~/Scripts/Utilities/JSTools.js")
             );

            bundles.Add(new ScriptBundle("~/JQuery/MeioMask")
             .Include("~/Scripts/JQuery/Pluggins/MeioMask/MeioMask.js")
             );

            // BundleTable.EnableOptimizations = true;
        }
 
    }


    public class CssRewriteUrlTransformWrapper : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            string result, temp;
            result = new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);

            return
                result;
        }
    }
  */
}