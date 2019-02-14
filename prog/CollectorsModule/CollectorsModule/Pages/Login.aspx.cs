using Statetrust.Framework.Web.WebParts.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Pages
{
    public partial class Login : STFMainPage
    {
        protected override void Page_PreInit(object sender, EventArgs e)
        {
            isLoginPage = true;
            SecurityMenuBar = false;

            if (IsPostBack) return;
            if (ConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
            {
                var userId = 0;
                var result = Login("epimentel", "outiiz/77lQ=", ref userId);

                if (!result) return;
                SetSessionValues();
                Response.Redirect("ProcessPayments.aspx", true);
            }
            else
            {
                if (Request.QueryString.Count>0)
                {
                    var userId = 0;
                    var aplicationId = 0;
                    if (!Login(Request.QueryString[0], ref userId, ref aplicationId)) return;
                    var url = GetDefaultPageByUserID(userId, aplicationId);
                    if (url.Trim() == "") return;
                    SetSessionValues();
                    Response.Redirect(url, true);
                }
                else
                    Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"], true);
            }
        }

        private void SetSessionValues()
        {
            Session["userData"] = Usuario;
        }
    }
}