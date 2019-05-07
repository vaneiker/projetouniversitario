using Declarative.Invoicing.CustomCode;
using Declarative.Invoicing.CustomCode.TH;
using Declarative.Invoicing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Declarative.Invoicing.Controllers
{
    public class QueueController : BaseController
    {
        // GET: Queue
        public ActionResult Index(string policy = null, DateTime? date = null)
        {
            List<Entities.Queue> allQueue = new List<Entities.Queue>();

            try
            {
                allQueue = oQueueManager.GetQueue(policy, date).ToList();

                var allPeriods = oQueueManager.GetPeriods(null);
                ViewBag.allPeriods = new SelectList(allPeriods.Select(i => new SelectListItem { Text = i.Period_Name.ToString(), Value = i.Period_Name.ToString() }), "Value", "Text");

            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo Index del Queue (Facturacion Declarativa)", ex.Message, ex);
            }

            return View(allQueue);
        }

        public ActionResult History()
        {
            List<Entities.Queue.Historic> allHistoric = new List<Entities.Queue.Historic>();
            try
            {
                allHistoric = oQueueManager.GetHistoric("").ToList();

                var allPeriods = oQueueManager.GetPeriods(null);
                ViewBag.allPeriods = new SelectList(allPeriods.Select(i => new SelectListItem { Text = i.Period_Name.ToString(), Value = i.Period_Name.ToString() }), "Value", "Text");
            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo History (Facturacion Declarativa)", ex.Message, ex);
            }

            return View(allHistoric);
        }

        [HttpPost]
        public ActionResult HistorySearch(FormCollection form)
        {
            List<Entities.Queue.Historic> realHistoric = new List<Entities.Queue.Historic>();
            var allPeriods = oQueueManager.GetPeriods(null);
            ViewBag.allPeriods = new SelectList(allPeriods.Select(i => new SelectListItem { Text = i.Period_Name.ToString(), Value = i.Period_Name.ToString() }), "Value", "Text");

            try
            {
                var allHistoric = oQueueManager.GetHistoric("").ToList();

                string fd = form["txtFfrom"] != null ? form["txtFfrom"].ToString() : "";
                string ft = form["txtFto"] != null ? form["txtFto"].ToString() : "";
                string policy = form["txtHistoricPolicy"] != null ? form["txtHistoricPolicy"].ToString().TrimStart().TrimEnd() : "";
                string period = form["ddlQueueDateHistoric"] != null ? form["ddlQueueDateHistoric"].ToString().TrimStart().TrimEnd() : "";

                DateTime realfd;
                DateTime realft;

                DateTime.TryParse(fd, out realfd);
                DateTime.TryParse(ft, out realft);

                if (!string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(fd) && !string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.poliza == policy && x.fechaFacturacion.Date >= realfd.Date && x.fechaFacturacion.Date <= realft.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(policy) && string.IsNullOrEmpty(fd) && string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.poliza == policy).ToList();
                }
                else if (!string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(fd) && string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.poliza == policy && x.fechaFacturacion.Date >= realfd.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(policy) && string.IsNullOrEmpty(fd) && !string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.poliza == policy && x.fechaFacturacion.Date <= realft.Date).ToList();
                }
                else if (string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(fd) && !string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.fechaFacturacion.Date >= realfd.Date && x.fechaFacturacion.Date <= realft.Date).ToList();
                }
                else if (string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(fd) && string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.fechaFacturacion.Date >= realfd.Date).ToList();
                }
                else if (string.IsNullOrEmpty(policy) && string.IsNullOrEmpty(fd) && !string.IsNullOrEmpty(ft))
                {
                    realHistoric = allHistoric.Where(x => x.fechaFacturacion.Date <= realft.Date).ToList();
                }
                else if (!string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(period))
                {
                    realHistoric = allHistoric.Where(x => x.poliza == policy && x.periodoFacturacion == period).ToList();

                    ViewBag.allPeriods = new SelectList(allPeriods.Select(i => new SelectListItem { Text = i.Period_Name.ToString(), Value = i.Period_Name.ToString() }), "Value", "Text", period);
                }
                else if (string.IsNullOrEmpty(policy) && !string.IsNullOrEmpty(period))
                {
                    realHistoric = allHistoric.Where(x => x.periodoFacturacion == period).ToList();
                    ViewBag.allPeriods = new SelectList(allPeriods.Select(i => new SelectListItem { Text = i.Period_Name.ToString(), Value = i.Period_Name.ToString() }), "Value", "Text", period);
                }
                else
                {
                    realHistoric = allHistoric;
                }
            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo HistorySearch (Facturacion Declarativa)", ex.Message, ex);
            }

            return View("History", realHistoric);
        }

        public JsonResult getPolicyItems(string policyNo)
        {
            string vjson = string.Empty;
            string cljson = string.Empty;

            try
            {
                var realPlNo = Utility.Decode(policyNo);

                var vi = oSysFlexService.GetVehiculosFromPolizaDeclarativa(realPlNo).ToList();
                vjson = vi.ToJson();

                cljson = string.Empty;

                var pbi = oSysFlexService.GetPolizaDeclarativaBasicInfo(realPlNo);
                if (pbi != null)
                {
                    DeclarativeInvoicingViewModel.PolicyInfo p = new DeclarativeInvoicingViewModel.PolicyInfo();
                    p.Policy = pbi.Poliza;
                    p.Insured = pbi.Asegurado;
                    p.StartDate = pbi.InicioVigencia.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    p.EndDate = pbi.FinVigencia.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    cljson = p.ToJson();
                }
            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo getPolicyItems (Facturacion Declarativa)", ex.Message, ex);
            }

            return Json(new { vdata = vjson, cdata = cljson }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPolicyInvoices(string policyNo)
        {
            string pinvjson = string.Empty;
            string cljson = string.Empty;

            try
            {
                var realPlNo = Utility.Decode(policyNo);

                var pinv = oSysFlexService.GetInvoicesDeclarativa(realPlNo).Select(x => new Entities.Invoices()
                {
                    CantidadFacturados = x.CantidadFacturados,
                    CodigoConcepto = x.CodigoConcepto,
                    Concepto = x.Concepto,
                    FacturaNumero = x.FacturaNumero,
                    Fecha = x.Fecha,
                    ISC = x.ISC,
                    Ncf = x.Ncf,
                    Poliza = x.Poliza,
                    PrimaNeta = x.PrimaNeta,
                    SecuenciaMov = x.SecuenciaMov,
                    TotalAPagar = x.TotalAPagar,
                    ValorFactura = x.ValorFactura,
                    ValorItbis = x.ValorItbis,
                    FechaString = x.Fecha.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ValorFacturaString = x.ValorFactura.GetValueOrDefault().ToString(numberFormat, CultureInfo.InvariantCulture)
                }).OrderByDescending(z => z.Fecha);

                pinvjson = pinv.ToJson();

                var pbi = oSysFlexService.GetPolizaDeclarativaBasicInfo(realPlNo);
                if (pbi != null)
                {
                    DeclarativeInvoicingViewModel.PolicyInfo p = new DeclarativeInvoicingViewModel.PolicyInfo();
                    p.Policy = pbi.Poliza;
                    p.Insured = pbi.Asegurado;
                    p.StartDate = pbi.InicioVigencia.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    p.EndDate = pbi.FinVigencia.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    cljson = p.ToJson();
                }
            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo getPolicyInvoices (Facturacion Declarativa)", ex.Message, ex);
            }
            return Json(new { pinvdata = pinvjson, cdata = cljson }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getInvoicePdf(string policyNo, string invoiceNumber)
        {
            string PathFile = "";

            try
            {

                var realPlNo = Utility.Decode(policyNo);

                var pinv = oSysFlexService.GetInvoicesDeclarativa(realPlNo).Where(x => x.FacturaNumero == invoiceNumber).ToList().Select(x => new Entities.Invoices()
                {
                    FacturaNumero = x.FacturaNumero,
                    Poliza = x.Poliza,
                    Fecha = x.Fecha,
                    Ncf = x.Ncf,
                    CantidadFacturados = x.CantidadFacturados,
                    PrimaNeta = x.PrimaNeta,
                    ISC = x.ISC,
                    TotalAPagar = x.TotalAPagar,
                    CodigoConcepto = x.CodigoConcepto,
                    Concepto = x.Concepto,
                    ValorFactura = x.ValorFactura,
                    ValorItbis = x.ValorItbis,
                    SecuenciaMov = x.SecuenciaMov,
                    TipoComprobante = x.TipoComprobante,
                    cedulaCliente = x.cedulaCliente,
                    NombreCliente = x.NombreCliente,
                    CodigoVendedor = x.CodigoVendedor,
                    Direccion = x.Direccion,
                    CodigoCliente = x.CodigoCliente,
                    TelRes = x.TelRes,
                    TelOfic = x.TelOfic,
                    TelCel = x.TelCel,
                    CodigoSupervisor = x.CodigoSupervisor,
                    NombreSupervisor = x.NombreSupervisor,
                    NombreVendedor = x.NombreVendedor,
                    CodigoAgente = x.CodigoAgente,
                    DireccionAgente = x.DireccionAgente,
                    VigenciaDesde = x.VigenciaDesde,
                    VigenciaHasta = x.VigenciaHasta,
                    Oficina = x.Oficina,
                    Ramo = x.Ramo,
                    SumaAsegurada = x.SumaAsegurada,
                    UserName = x.UserName,
                    Producto = x.Producto,
                    FechaString = x.Fecha.GetValueOrDefault().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ValorFacturaString = x.ValorFactura.GetValueOrDefault().ToString(numberFormat, CultureInfo.InvariantCulture)
                }).FirstOrDefault();

                string FileName = string.Concat("Invoice-", invoiceNumber, ".pdf");
                var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);

                deleteFiles(Server.MapPath("~/Tmp/"), FileName);

                var Xml = THMethods.GenerateXMLInvoiceToThunderhead(pinv);

                var PdfFileByteArray = oTHSettings.NewSendToTHExecutePreview(Xml);
                System.IO.File.WriteAllBytes(FullFileName, PdfFileByteArray);
                PathFile = @"\Tmp\" + FileName;
            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo getInvoicePdf (Facturacion Declarativa)", ex.Message, ex);
            }

            return
                Json(PathFile, JsonRequestBehavior.AllowGet);
        }

        private void deleteFiles(string path, string fileName)
        {
            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);

                foreach (System.IO.FileInfo file in di.GetFiles())
                {
                    if (file.Name == fileName)
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}