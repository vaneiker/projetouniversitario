﻿using KSI.Cobranza.Web.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KSI.Cobranza.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            //Boolean ApplySecurity = Boolean.Parse(WebConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture));

            //if (ApplySecurity)
            //{
            //    HttpContext.Current.Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"].ToString(CultureInfo.InvariantCulture));
            //}
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            string SecurityP = string.Empty;
            SecurityP = System.Configuration.ConfigurationManager.AppSettings["HttpProtocol"].ToString();
            if (SecurityP == "https")
                if (HttpContext.Current.Request.IsSecureConnection.Equals(false))
                {
                    Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.RawUrl);
                }
        }

    }
}
