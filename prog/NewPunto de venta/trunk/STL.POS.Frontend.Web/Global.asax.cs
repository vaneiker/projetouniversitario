using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using STL.POS.Data;
using STL.POS.Frontend.Web.App_Start;
using STL.POS.GlobalLogger;

namespace STL.POS.Frontend.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Initialise();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            var logEntry = new PosLogEntry();
            logEntry.Category = Categories.Error;
            logEntry.Priority = 0;
            logEntry.Message = "Error general en la aplicación (Excepción no controlada): " + ex.Message + "\nStacktrace: " + ex.StackTrace;
            //Logger.Write(logEntry);
            
            try { 
                GLogger.LogError(ex); 
            }
            catch (Exception error)
            {
                throw error;  
            } 
        }
    }
}