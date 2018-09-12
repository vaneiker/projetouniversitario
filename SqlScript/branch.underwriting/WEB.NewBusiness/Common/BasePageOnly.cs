using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;
using WEB.NewBusiness.Common.Illustration;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.Common
{
    public class BasePageOnly :Page
    {
        private Services _services;        

        private string ProjectSessionName;          

        public Services ObjServices
        {
            get
            {
                Control hdnSessionName = null;

                try
                {
                    hdnSessionName = this.Page.Master.FindControl("hdnSessionName");
                }
                catch (Exception)
                {   //Este caso es unico y exclusivo del tab de requirements
                    ProjectSessionName = "NewBusiness";
                }

                if (!hdnSessionName.isNullReferenceControl())
                    ProjectSessionName = (hdnSessionName as System.Web.UI.WebControls.HiddenField).Value;

                return _services ?? new Services(ProjectSessionName);
            }
        }             
            
    }
}