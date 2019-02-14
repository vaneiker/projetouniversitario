using Statetrust.Framework.Web.WebParts.Masters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CollectorsModule.Master
{
    public partial class CM : STFMainMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectorSessionEnd(Session["userData"]);
            string path = Path.GetFileName(Request.Url.AbsolutePath);
            if (path == "PaymentHistory.aspx")
            {
                this.btnPaymentHistoryPolicy.Enabled = this.btnPaymentHistoryPolicy.Visible = false;
                this.hlkDailyCash.Visible = this.hlkDailyCash.Enabled = true;
            }
            if (path == "ProcessPayments.aspx")
            {
                this.hlkProcessPayment.Enabled = this.hlkProcessPayment.Visible = false;
                this.hlkDailyCash.Visible = this.hlkDailyCash.Enabled = true;
            }
            if (path == "DailyCash.aspx")
            {
                this.btnPaymentHistoryPolicy.Enabled = this.hlkProcessPayment.Enabled = true;
                this.hlkDailyCash.Visible = this.hlkDailyCash.Enabled = false;
            }
        }
        public int SessionLengthMinutes
        {
            get { return Session.Timeout; }
        }
        public string SessionExpireDestinationUrl
        {
            get { return "SessionExpire.aspx"; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.ContentHeader.Controls.Add(new LiteralControl(
                String.Format("<meta http-equiv='refresh' content='{0};url={1}'>",
                SessionLengthMinutes * 60, SessionExpireDestinationUrl)));
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("userData");
            Response.Redirect(ConfigurationManager.AppSettings["SecurityLogin"].ToString(), true);
        }

        public static void RedirectorSessionEnd(object session)
        {
            if (session == null)
            {
                try
                {
                    if (Path.GetFileName(HttpContext.Current.Request.Url.AbsolutePath) != "SessionExpire.aspx")
                                        HttpContext.Current.Response.Redirect("SessionExpire.aspx", true);
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.Redirect("SessionExpire.aspx", true);
                }
                
            }
        }
    }
}