using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Areas.CardNet
{
    public class CardNetAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CardNet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CardNet_default",
                "CardNet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}