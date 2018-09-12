using System;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class PdfViewer : WEB.UnderWriting.Common.UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Viewer.LicenseKey = Service.PdfViewerKey;
        }
        public void LoadPdf(byte[] BinaryData, Unit width = new  Unit(), Unit height = new Unit())
        {
            Viewer.Width = width;
            Viewer.Height = height;
            Viewer.PdfSourceBytes = BinaryData;
            Viewer.DataBind();
        }
    }
}