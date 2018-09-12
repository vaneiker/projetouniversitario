using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
//using WEB.ConfirmationCall.Infrastructure.Utils;
//using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.UserControls.Common.MyProfile
{
    public partial class MyProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var excludeLink = new List<LinkButton>();
            foreach (var lnk in this.Controls.OfType<LinkButton>().Where(o => !excludeLink.Contains(o)))
                lnk.Click += lnkRedirectModule_Click;

            if (IsPostBack) return;
            /*if (UserDataProvider.Role == UserDataProvider.Roles.Admin)
            {
                h2AdminAgent.Visible = true;
                lnkAdminNewAgent.Visible = true;
                lnkAdminListAgent.Visible = true;
            }*/
        }

        protected void lnkRedirectModule_Click(object sender, EventArgs e)
        {
            /*var data = SecurityPage.GenerateToken(UserDataProvider.UserId, (LinkButton)sender);

            if (data.Status)
                Response.Redirect(data.UrlPath, true);
            else
                WebUtils.Alertify.Alert(data.errormessage, this);*/
        }
    }
}