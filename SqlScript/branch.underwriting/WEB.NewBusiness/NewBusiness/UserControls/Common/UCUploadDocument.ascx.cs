using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class UCUploadDocument : System.Web.UI.UserControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator();
        }

        private void Translator()
        {
            UploadDocument.InnerHtml = Resources.UPLOAD;
            fuFile.BrowseButton.Text = Resources.Browse;
            CancelBtn.Text = Resources.Cancel;
            SaveBtn.Text = Resources.Save;
            CloseBtn.Text = Resources.Close;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}