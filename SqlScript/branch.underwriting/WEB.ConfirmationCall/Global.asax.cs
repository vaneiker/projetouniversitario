using System;
using System.Web.Http;
using WEB.ConfirmationCall.Common;

namespace WEB.ConfirmationCall
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            JMAudioTools.CheckAddBinPath("binLame");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception excpt = Server.GetLastError().GetBaseException();
            //
            ConfirmationCallLog.Log("Error Server", string.Format("Message {0} TrackTrace {1}", excpt.Message, excpt.StackTrace), "NULLL", 0, "");

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}