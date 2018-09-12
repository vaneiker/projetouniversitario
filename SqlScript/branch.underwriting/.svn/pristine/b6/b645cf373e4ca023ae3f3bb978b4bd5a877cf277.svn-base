using System;
using System.Web.Configuration;

namespace WEB.ConfirmationCall.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"]);
            //id = Session.SessionID;


        }
    }
}