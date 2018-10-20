using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace STL.POS.Frontend.Web.NewVersion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            bool b = System.Web.Configuration.WebConfigurationManager.AppSettings["ApplySecurity"].ToString(System.Globalization.CultureInfo.InvariantCulture) == "false";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            if (b == false)
            {

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

              //  routes.MapRoute(
              //   name: "Vehicle",
              //   url: "{controller}/{action}/{QuotId}{VehicleNumber}",
              //   defaults: new { controller = "Home", action = "GetNextVehicle", QuotId = UrlParameter.Optional, VehicleNumber = UrlParameter.Optional }
              //);
            }
            else
            {
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Login", action = "STFLogin", id = UrlParameter.Optional }
                );
            }      
                   
            
        }
    }
}
