using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Requirements
{
    public partial class WUCPDFViewerReq : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerPdfPopUp.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
        }

        public void FillPDF(byte[] PDF)
        {
            pdfViewerPdfPopUp.PdfSourceBytes = PDF;
            pdfViewerPdfPopUp.DataBind();
        }
    }
}