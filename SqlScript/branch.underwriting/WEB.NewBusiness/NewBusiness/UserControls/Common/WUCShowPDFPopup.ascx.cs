using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCShowPDFPopup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerMyPreviewPDF.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
        }
     
        public void LoadPDFPreview(byte[] PDF)
        {
            pdfViewerMyPreviewPDF.PdfSourceBytes = PDF;
            pdfViewerMyPreviewPDF.DataBind();
        }

        public void LoadPDFPreviewURL(String url)
        {
            pdfViewerMyPreviewPDF.PdfSourceURL = url;
            pdfViewerMyPreviewPDF.DataBind();
        }

        public void setSize(int width, int height)
        {
            pdfViewerMyPreviewPDF.Width = width;
            pdfViewerMyPreviewPDF.Height = height;
        }
    }
}