using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vendor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "MostrarVendedor",
           //    url: "Home/Sumar/{data}",
           //    defaults: new { controller = "Home", action = "Sumar" }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Vendor", id = UrlParameter.Optional }
            );
        }
    }
}
