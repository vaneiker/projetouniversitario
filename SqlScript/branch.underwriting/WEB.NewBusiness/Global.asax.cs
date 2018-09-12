using System;
using System.Diagnostics;
using System.Web;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //try
            //{
            //    string[] files = Directory.GetFiles(Server.MapPath("~/TempFiles"));
            //    DateTime hoy = DateTime.Today.AddDays(-1);

            //    foreach (string item in files.Where(item => File.GetCreationTime(item) <= hoy && !item.Contains("readme.txt")))
            //        File.Delete(item);
            //}
            //catch (Exception)
            //{

            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex;
            StackTrace trace;
            //Capturar los errores generados por la aplicacion
            ex = Server.GetLastError().GetBaseException();
            //System.Web.UI.Page mypage = (System.Web.UI.Page)HttpContext.Current.Handler;
            //mypage.RegisterStartupScript("alert", string.Format("CustomDialogMessage({0})", ex.Message));

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}