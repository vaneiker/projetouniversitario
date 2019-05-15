using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using Microsoft.Reporting.WebForms;
using iTextSharp.text.pdf;

namespace STL.POS.Frontend.Web.Helpers
{
    public class WebReportRenderer : IDisposable
    {
        #region "Private fields"
        private string downloadFileName;
        private LocalReport reportInstance;
        private MemoryStream reportMemoryStream;
        private string reportMimeType;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WebReportRenderer"/> class.
        /// </summary>
        /// <param name="reportPath">The report path.</param>
        /// <param name="downloadFileName">Name of the download file.</param>
        public WebReportRenderer(byte[] file, string downloadFileName)
        {
            if (HttpContext.Current == null) throw new InvalidOperationException("This class is only for use from web applications.");

            this.downloadFileName = downloadFileName;
            using (System.IO.MemoryStream reportFile = new System.IO.MemoryStream(file))
            {
                reportInstance = new LocalReport();
                reportInstance.LoadReportDefinition(reportFile);
            }
        }

        public void AddSubReportDefinition(string subreportName, byte[] subreportDefinition)
        {
            using (System.IO.MemoryStream reportFile = new System.IO.MemoryStream(subreportDefinition))
            {
                ReportInstance.LoadSubreportDefinition(subreportName, reportFile);
            }
        }

        #region "Properties"
        /// <summary>
        /// Gets the report instance.
        /// </summary>
        /// <value>The report instance.</value>
        public LocalReport ReportInstance
        {
            get
            {
                return reportInstance;
            }
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Renders the current ReportInstance to the user's browser as a PDF download.
        /// </summary>
        /// <param name="pdfDeviceInfoSettings">The PDF device info settings (see http://msdn2.microsoft.com/en-us/library/ms154682.aspx).</param>
        /// <returns></returns>
        public Warning[] RenderToBrowserPDF(string pdfDeviceInfoSettings)
        {
            CreateStreamCallback callback = new Microsoft.Reporting.WebForms.CreateStreamCallback(CreateWebBrowserStream);
            Warning[] warnings;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + downloadFileName + "\"");
            reportInstance.Render("PDF", null, callback, out warnings);
            return warnings;
        }
        /// <summary>
        /// Renders the current ReportInstance to the user's browser as a PDF download.
        /// </summary>
        /// <returns></returns>
        public Warning[] RenderToBrowserPDF()
        {
            return RenderToBrowserPDF(null);
        }

        /// <summary>
        /// Renders the current ReportInstance to an email with a file attachment containing the report.
        /// </summary>
        /// <param name="pdfDeviceInfoSettings">The PDF device info settings (see http://msdn2.microsoft.com/en-us/library/ms154682.aspx).</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="fromAddress">From address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public Warning[] RenderToEmailPDF(string pdfDeviceInfoSettings, string toAddress, string fromAddress, string subject, string body)
        {
            CreateStreamCallback callback = CreateMemoryStream;
            Warning[] warnings;
            reportInstance.Render("PDF", pdfDeviceInfoSettings, callback, out warnings);
            reportMemoryStream.Seek(0, SeekOrigin.Begin);

            var client = new SmtpClient();
            using (var message = new MailMessage(fromAddress, toAddress, subject, body))
            using (var attachment = new Attachment(reportMemoryStream, reportMimeType))
            {
                attachment.Name = downloadFileName;
                message.Attachments.Add(attachment);
                client.Send(message);
            }
            return warnings;
        }


        public byte[] RenderToBytesPDF()
        {
            string mimeType;
            string encoding;
            string fileNameExtension;
            string[] streams;
            Warning[] warnings;
            byte[] result = reportInstance.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams,
                                         out warnings);

            //Fix render
            PdfReader reader = new PdfReader(result);
            MemoryStream stream = new MemoryStream();
            PdfStamper stamper = new PdfStamper(reader, stream);
            stamper.Close();
            reader.Close();
            //

            return stream.ToArray();
        }

        public byte[] RenderToBytesExcel()
        {
            string mimeType;
            string encoding;
            string fileNameExtension;
            string[] streams;
            Warning[] warnings;
            return reportInstance.Render("EXCEL", null, out mimeType, out encoding, out fileNameExtension, out streams,
                                         out warnings);
        }

        /// <summary>
        /// Renders the current ReportInstance to an email with a file attachment containing the report.
        /// </summary>        
        /// <param name="toAddress">To address.</param>
        /// <param name="fromAddress">From address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public Warning[] RenderToEmailPDF(string toAddress, string fromAddress, string subject, string body)
        {
            return RenderToEmailPDF(null, toAddress, fromAddress, subject, body);
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Formats the current response output and returns the output stream suitable for rendering to the browser as a file download.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="willSeek">if set to <c>true</c> [will seek].</param>
        /// <returns></returns>
        private Stream CreateWebBrowserStream(string name, string extension, System.Text.Encoding encoding, string mimeType, bool willSeek)
        {

            return HttpContext.Current.Response.OutputStream;
        }

        /// <summary>
        /// Creates a memory stream that can be used by the report when rendering to an email attachment.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="willSeek">if set to <c>true</c> [will seek].</param>
        /// <returns></returns>
        private Stream CreateMemoryStream(string name, string extension, System.Text.Encoding encoding, string mimeType, bool willSeek)
        {
            reportMemoryStream = new MemoryStream();
            reportMimeType = mimeType;
            return reportMemoryStream;
        }
        #endregion

        #region "IDisposable Members"

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.reportInstance != null) this.reportInstance.Dispose();
            if (this.reportMemoryStream != null) this.reportMemoryStream.Dispose();
        }

        #endregion
    }
}