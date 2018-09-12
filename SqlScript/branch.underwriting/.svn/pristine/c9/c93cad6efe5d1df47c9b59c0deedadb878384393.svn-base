using System.Web.Http;

namespace WEB.ConfirmationCall
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Date}",
                defaults: new { Date = RouteParameter.Optional }
            );
        }
    }
}
