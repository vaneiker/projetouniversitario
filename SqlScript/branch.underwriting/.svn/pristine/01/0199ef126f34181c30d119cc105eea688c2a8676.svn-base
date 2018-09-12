using System;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            JMAudioTools.CheckAddBinPath("binLame");
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
            //Exception ex;
            //StackTrace trace;
            //string sss = "";
            //ex = Server.GetLastError().GetBaseException();
            //trace = new StackTrace(ex, true);

            ////Exception ex = Server.GetLastError();


            ////if (ex.Message == "File does not exist.")
            ////{
            ////    throw new Exception(string.Format("{0} {1}", ex.Message, HttpContext.Current.Request.Url.ToString()), ex);
            ////}

            //sss = Request.RawUrl;


            ////Capturar los errores generados por la aplicacion
            //ex = Server.GetLastError().GetBaseException();
            //// Tools.SaveExceptions(ex, 1);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}