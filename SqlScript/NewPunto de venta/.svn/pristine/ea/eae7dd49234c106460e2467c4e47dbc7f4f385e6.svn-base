using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Areas.Salud
{
    public class SaludAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Salud";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Salud_default",
                "Salud/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}