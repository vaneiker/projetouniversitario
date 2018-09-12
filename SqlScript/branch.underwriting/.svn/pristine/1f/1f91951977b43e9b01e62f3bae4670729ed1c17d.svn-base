using System;

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class UCShowPDFPopup : System.Web.UI.UserControl
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


    }
}