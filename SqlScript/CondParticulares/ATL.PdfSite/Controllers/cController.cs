//using ATL.PdfSite.OnBaseBinary;
//using ATL.PdfSite.OnBaseSusVeh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ATL.PdfSite.Modelos;
using ATL.PdfSite.TokenWeb;

namespace ATL.PdfSite.Controllers
{
    public class cController : Controller
    {
        //
        // GET: /Cond/
        /*public ActionResult Index()
        {
            return View();
        }*/

        public FileStreamResult q(string i)
        {
            if (i == null) return null;

            //23-05-466099;SRV-Condiciones Particulares

            var client = new OnBaseSusVeh.HylandOutBoundContractClient();
            var binaryClient = new OnBaseBinary.HylandOutBoundContractClient();
            var query = new OnBaseSusVeh.OBCustomQueryGetDocument_DMPoliza();
            var wToken = new ATL.PdfSite.TokenWeb.Token();
            var dec = wToken.Dencrypt(i.Replace(" ", "+"), "1");
            var p = dec.key;

            //var enc = wToken.Encrypt(i, "1");
            
            string policy = p.Split(';')[0];
            string docType = p.Split(';')[1];


            query.Keywords = new OnBaseSusVeh.CustomQueryKeywordsGetDocument_DMPoliza
            {
                NúmerodePóliza = policy,
            };

            var result = client.GetDocument_DMPoliza(query);
            var filter = docType; // "SRV-Condiciones Particulares"; //"SUS-Marbete Provicional";
            var docHandle = result.DocumentResults.First(x => x.docTypeName == filter).documentHandle;

            var response = binaryClient.Get_document_data(new OnBaseBinary.DocumentBytesInput
            {
                documentHandle = docHandle
            });

            var doc = Convert.FromBase64String(response.Base64FileStream);

            var file = new FileStreamResult(new MemoryStream(doc), "application/pdf");
             

            //file.FileDownloadName = string.Format("CondPart{0}.pdf", policy.Replace("-", ""));

            return file;
        }
    }
}