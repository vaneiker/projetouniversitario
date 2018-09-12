using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.Common.UserControls
{
    public partial class WUCRightMenu : UC
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translate();
        }

        public void Translate()
        {
            Tools.InnerHtml = Resources.ToolsLabel.ToUpper();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}