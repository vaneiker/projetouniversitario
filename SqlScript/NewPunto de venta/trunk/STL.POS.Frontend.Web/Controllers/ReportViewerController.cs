using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Controllers
{
    public class ReportViewerController : Controller
    {

        public ReportViewerController()
        {
        }

        // GET: Home
        //[Authorize]
        public ActionResult Index(string reportPath, int idQuotation)
        {
            ViewBag.reportPath = reportPath;
            ViewBag.idQuotation = idQuotation;

            return View();
        }

        public ActionResult PrintReport(string sourceFile)
        {
            string tmpDir = System.AppDomain.CurrentDomain.BaseDirectory + "Tmp";

            //Eliminamos los archivos temporales generados por las impresiones
            DirectoryInfo di = new DirectoryInfo(tmpDir);
            di.GetFiles().Where(f => f.Name.StartsWith("TMP_")).ToList().ForEach(t => t.Delete());

            var pdfLocalFilePath = System.AppDomain.CurrentDomain.BaseDirectory + sourceFile;

            var path = "\\TMP_" + Path.GetRandomFileName() + ".pdf";
            using (var outputStream = new FileStream(tmpDir + path, FileMode.CreateNew))
            {
                //outputStream.Flush();
                PdfReader reader = new PdfReader(pdfLocalFilePath);
                int pageCount = reader.NumberOfPages;
                Rectangle pageSize = reader.GetPageSize(1);

                // Set up Writer 
                Document document = new Document(pageSize);

                PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

                document.Open();
                document.AddAuthor("Atlantica");

                //Copy each page 
                PdfContentByte content = writer.DirectContent;

                for (int i = 0; i < pageCount; i++)
                {
                    document.NewPage();
                    // page numbers are one based 
                    PdfImportedPage page = writer.GetImportedPage(reader, i + 1);
                    // x and y correspond to position on the page 
                    content.AddTemplate(page, 0, 0);
                }

                // Inert Javascript to print the document after a fraction of a second to allow time to become visible.
                //string jsText = @"this.print\({bUI:true,bSilent:false,bShrinkToFit:true}\);";

                string jsTextNoWait = "var pp = this.getPrintParams();pp.interactive = pp.constants.interactionLevel.full;this.print(pp);";
                PdfAction js = PdfAction.JavaScript(jsTextNoWait, writer);
                //writer.AddJavaScript(js);
                PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
                writer.SetOpenAction(action);
                writer.SetAdditionalAction(PdfWriter.DID_PRINT, PdfAction.JavaScript("self.close())", writer));


                document.Close();
            }

            return Json(new { reportName = "\\Tmp" + path }, JsonRequestBehavior.AllowGet);
        }

    }
}