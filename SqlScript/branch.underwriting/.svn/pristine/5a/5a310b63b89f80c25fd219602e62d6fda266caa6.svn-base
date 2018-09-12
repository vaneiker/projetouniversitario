using System;

namespace WEB.ConfirmationCall.UserControls.Common
{
    public partial class UCPDFPopup : System.Web.UI.UserControl
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