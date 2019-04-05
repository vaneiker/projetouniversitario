using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using StateTrust.Security.Common;
using System.Configuration;
using System.Globalization;
using Statetrust.Framework.Security.Core;


    public class BasePage : SecurityPage
    {
        protected override void Page_LoadComplete(object sender, EventArgs e)
        {
           //base.Page_LoadComplete(sender, e);
        }

        public void ValidPage(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "true")
            {
                this.Page_LoadComplete(sender, e);
            }
        }
    }
