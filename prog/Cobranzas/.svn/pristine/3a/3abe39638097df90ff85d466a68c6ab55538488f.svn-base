using KSI.Cobranza.LogicLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jass.Utilities;
using KSI.Cobranza.LogicLayer;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;

namespace KSI.Cobranza.Web.Controllers
{
    public class DocumentController : BaseController
    {
        #region Fields

        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// proveedor de datos que le concede a este controlador acceso a la data
        /// </summary>
        LoanManager _dataManager = new LoanManager();

        #endregion

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoca la página de visualizacion, generacion y carga de documentos
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public ActionResult Index(long accountId)
        {
            return View(_dataManager.GetDocument(accountId));
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Genera y fuerza la descarga de un documento proveniente de ThunderHead
        /// </summary>
        /// <param name="accountId">Id de prestamo</param>
        /// <param name="IdRequirement">Id de documento</param>
        /// <returns>Dispara una descarga en el navegador</returns>
        public ActionResult Generate(long accountId, int IdRequirement)
        {
            ResultLogic<Loan.Document> documentResult 
                = _dataManager.GetDocument(accountId, IdRequirement);

            IDocumentsXmlProvider xmlProvider 
                = documentResult.SingleResult.ModelNameForDownload.GetInstance() as IDocumentsXmlProvider;

            xmlProvider.SetDataManager(_dataManager);

            ThunderheadWrap.THAPIWeb.ExternalJobRequestAPI request 
                = new ThunderheadWrap.THAPIWeb.ExternalJobRequestAPI();
            ThunderheadWrap.THAPIWeb.JobAPIWebService api 
                = new ThunderheadWrap.THAPIWeb.JobAPIWebService();
            Infrastructure.Helpers.THSecurityAssertion sercurityAssertion 
                = new Infrastructure.Helpers.THSecurityAssertion(
                    System.Configuration.ConfigurationManager.AppSettings["UserName"], 
                    System.Configuration.ConfigurationManager.AppSettings["Password"]);

            api.Url = System.Configuration.ConfigurationManager.AppSettings["UrlServiceTH"];

            request.batchConfigResID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchConfigResID"]);
            request.batchName = System.Configuration.ConfigurationManager.AppSettings["batchName"];
            request.projectID = int.Parse(System.Configuration.ConfigurationManager.AppSettings["projectID"]);
            request.batchCollect = int.Parse(System.Configuration.ConfigurationManager.AppSettings["batchCollect"]);
            request.finOption = int.Parse(System.Configuration.ConfigurationManager.AppSettings["finOption"]);
            request.jobType = int.Parse(System.Configuration.ConfigurationManager.AppSettings["jobType"]);
            request.transactionData = xmlProvider.GetXml();

            api.SetPolicy(new Microsoft.Web.Services3.Design.Policy(sercurityAssertion));
            ThunderheadWrap.THAPIWeb.PackageAPI result 
                = api.executePreview(request);

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(result.masterChannels[0].data, 0,
                result.masterChannels[0].data.Length, true, true);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", string.Format(
                "attachment;filename=Intimacion_de_Pago.pdf"));
            Response.Buffer = true;
            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
    }
}