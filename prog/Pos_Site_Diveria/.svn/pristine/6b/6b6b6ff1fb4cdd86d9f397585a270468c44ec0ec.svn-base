using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace STL.POS.Frontend.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            bool b = System.Web.Configuration.WebConfigurationManager.AppSettings["ApplySecurity"].ToString(System.Globalization.CultureInfo.InvariantCulture) == "false";
            if (b == false)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }
            else
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Account", action = "STFLogin", id = UrlParameter.Optional }
                );
            }
        }
    }
}
