﻿using Declarative.Invoicing.CustomCode;
using Declarative.Invoicing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Declarative.Invoicing.Controllers
{
    public class PolicyController : BaseController
    {
        // GET: Policy
        public ActionResult Index(string Policy, string Period = "", string partial = "Si")
        {
            DeclarativeInvoicingViewModel allData = null;

            try
            {
                var realPolicy = Utility.Decode(Policy);
                DateTime? pStart = null;
                DateTime? pEnd = null;
                string periodoDesc = "";
                int policyInfoId = 0;
                int periodId = 0;
                int periodPolicyId = 0;

                if (!string.IsNullOrEmpty(Period))
                {
                    var realPeriod = Utility.Decode(Period);
                    string[] sp = realPeriod.Split('|');

                    pStart = Convert.ToDateTime(sp[0]);
                    pEnd = Convert.ToDateTime(sp[1]);
                    periodoDesc = sp[2];
                    policyInfoId = sp[3].ToInt();
                    periodId = sp[4].ToInt();
                    periodPolicyId = sp[5].ToInt();
                }

                allData = getDataPolicy(realPolicy, pStart, pEnd, periodoDesc, policyInfoId, periodId, periodPolicyId);

                if (pStart.HasValue && pEnd.HasValue)
                {
                    ViewBag.PeriodStart = pStart;
                    ViewBag.PeriodEnd = pEnd;
                }

                ViewBag.showLayout = false;

            }
            catch (Exception ex)
            {
                Utility.Log(GetCurrentUserLogin(), "Error en el metodo Index de Policy (Facturacion Declarativa)", ex.Message, ex);
            }

            if (partial == "Si")
            {
                return PartialView(allData);
            }
            else
            {
                ViewBag.showLayout = true;
                return View(allData);
            }
        }

        private DeclarativeInvoicingViewModel getDataPolicy(string policy, DateTime? periodStart, DateTime? periodEnd, string periodoDesc = "", int PolicyInfoId = 0, int periodId = 0, int periodPolicyId = 0)
        {
            DeclarativeInvoicingViewModel data = new DeclarativeInvoicingViewModel();
            var pbi = oSysFlexService.GetPolizaDeclarativaBasicInfo(policy);
            DeclarativeInvoicingViewModel.PolicyInfo _policyInfo = new DeclarativeInvoicingViewModel.PolicyInfo();

            if (pbi != null)
            {
                _policyInfo.Policy = pbi.Poliza;
                _policyInfo.Insured = pbi.Asegurado;
                _policyInfo.StartDate = periodStart.GetValueOrDefault().ToString("dd/MM/yyyy");
                _policyInfo.EndDate = periodEnd.GetValueOrDefault().ToString("dd/MM/yyyy");
                _policyInfo.InsuredAmount = pbi.SumaAsegurada.GetValueOrDefault().ToString(numberFormat, System.Globalization.CultureInfo.InvariantCulture);
                _policyInfo.Office = pbi.Oficina;
                _policyInfo.CoreQuotation = pbi.Cotizacion;
            }
            data._policyInfo = _policyInfo;

            List<DeclarativeInvoicingViewModel.VehiclesFromPolicy> _vehicleInfo = new List<DeclarativeInvoicingViewModel.VehiclesFromPolicy>();
            var vi = oSysFlexService.GetVehiculosFromPolizaDeclarativa(policy).ToList();

            if (vi.Any())
            {
                _vehicleInfo = vi.Select(v => new DeclarativeInvoicingViewModel.VehiclesFromPolicy()
                {
                    Ano = v.Ano,
                    Cliente = v.Cliente,
                    Cotizacion = v.Cotizacion,
                    DescripcionSubramo = v.DescripcionSubramo,
                    EstatusItem = v.EstatusItem,
                    FechaAdicion = v.FechaAdicion,
                    IdMarca = v.IdMarca,
                    Idmodelo = v.Idmodelo,
                    Item = v.Item,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Poliza = v.Poliza,
                    Prima = v.Prima,
                    Ramo = v.Ramo,
                    SubRamo = v.SubRamo,
                    chasis = v.chasis,
                    color = v.color,
                    placa = v.placa,
                    ProrrataMensual = v.ProrrataMensual,
                    FechaExlusion = v.FechaExlusion,
                    FechaInclusion = v.FechaInclusion
                }).ToList();
            }
            data._vehicles = _vehicleInfo;

            data._invoicingHistoric = new List<DeclarativeInvoicingViewModel.InvoicingHistoric>();

            DeclarativeInvoicingViewModel.InvoicingResume inre = new DeclarativeInvoicingViewModel.InvoicingResume();
            decimal? sumProrrata = 0;
            decimal? itbis = 0;
            decimal? total = 0;

            if (vi.Any())
            {
                inre.InvoicingPeriod = periodoDesc;

                sumProrrata = vi.Where(x => x.EstatusItem == "ACTIVO").Sum(x => Math.Round(x.ProrrataMensual.GetValueOrDefault(), 2,MidpointRounding.AwayFromZero));
                itbis = (sumProrrata * (0.16M));

                sumProrrata = (sumProrrata - itbis);
                total = sumProrrata + itbis;

                inre.SubTotal = sumProrrata.GetValueOrDefault().ToString(numberFormat, System.Globalization.CultureInfo.InvariantCulture);
                inre.Itbis = itbis.GetValueOrDefault().ToString(numberFormat, System.Globalization.CultureInfo.InvariantCulture);
                inre.TotalToPay = total.GetValueOrDefault().ToString(numberFormat, System.Globalization.CultureInfo.InvariantCulture);
            }
            data._invoicingResume = inre;

            var objInvoicing = new
            {
                Policy = data._policyInfo.Policy,
                quotCore = data._policyInfo.CoreQuotation.GetValueOrDefault(),
                billingDate = periodEnd,
                policyOffice = data._policyInfo.Office,
                subTotal = sumProrrata,
                Itbis = itbis,
                PolicyInfoId = PolicyInfoId,
                PeriodId = periodId,
                PeriodPolicyId = periodPolicyId
            };

            data._billingInformation = objInvoicing.ToJson();

            return data;
        }

        public JsonResult ProcessDeclarativePolicy(string jsondata)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsondata);

            string messageError = "";
            bool success = true;

            try
            {
                int? compania = 30;
                string poliza = data.Policy;
                decimal? cotizacion = data.quotCore;
                int? concepto = 62;//Facturacion Declarativa
                string usuario = GetCurrentUserLogin();
                string fechaAFacturar = Convert.ToString(data.billingDate);
                int? oficina = data.policyOffice;
                string rutaWebServices = "";
                int secuenciaMov = 0;

                int PolicyInfoId = data.PolicyInfoId;
                int PeriodId = data.PeriodId;
                int PeriodPolicyId = data.PeriodPolicyId;

                decimal Subtotal = data.subTotal;
                decimal Taxes = data.Itbis;
                decimal totalWithTaxes = Subtotal + Taxes;

                string invoiceNumber = "";

                #region Facturacion Declarativa 

                DateTime fefac = Convert.ToDateTime(fechaAFacturar);
                string realDate = fefac.ToString("yyyyMMdd", CultureInfo.InvariantCulture);

                var d = oSysFlexService.FacturacionDeclarativa(compania, poliza, cotizacion, concepto, usuario, realDate, oficina, rutaWebServices);

                if (d != null)
                {
                    secuenciaMov = d.SecuenciaMov.GetValueOrDefault();
                }
                else
                {
                    messageError = "Ha ocurrido un error haciendo la facturacion de la poliza";

                    return Json(new { success = false, messageError = messageError }, JsonRequestBehavior.AllowGet);
                }

                #endregion

                #region Facturacion sin gp 

                SysflexServices.NCFInvoiceResult emisionInvoiceNumber = oSysFlexService.GetNCFandInvoiceNumber(poliza, DateTime.Now, totalWithTaxes, Taxes);

                if (emisionInvoiceNumber == null || !string.IsNullOrEmpty(emisionInvoiceNumber.Error))
                {
                    return Json(new { success = false, messageError = "Fallo en la Emision de la Facuta en Sysflex. Metodo: GetNCFandInvoiceNumber. ERROR: " + emisionInvoiceNumber.Error }, JsonRequestBehavior.AllowGet);
                }
                else if (emisionInvoiceNumber.Successful)
                {
                    var ResultFactSinGp = oSysFlexService.FacturacionMovimientoSinGP(compania, cotizacion, secuenciaMov, usuario, 1, rutaWebServices, 1,
                        emisionInvoiceNumber.NCFNumber, emisionInvoiceNumber.InvoiceNumber, emisionInvoiceNumber.Error, false);

                    invoiceNumber = emisionInvoiceNumber.InvoiceNumber;
                }

                #endregion

                #region Guardando en mi historico

                var vehicles = oSysFlexService.GetVehiculosFromPolizaDeclarativa(poliza).ToList();
                DateTime dt = fechaAFacturar.ToDatetime();

                var allActive = vehicles.Where(x => x.EstatusItem == "ACTIVO").ToList();

                var allExclude = vehicles.Where(x => x.EstatusItem == "EXCLUIDO"
                && x.FechaExlusion.GetValueOrDefault().Date.Month == dt.Month
                && x.FechaExlusion.GetValueOrDefault().Date.Year == dt.Year).LastOrDefault();

                var allIncludePeriod = vehicles.Where(x => x.EstatusItem == "ACTIVO"
                && x.FechaInclusion.GetValueOrDefault().Date.Month == dt.Month
                && x.FechaInclusion.GetValueOrDefault().Date.Year == dt.Year).LastOrDefault();

                var iheade = oInvoiceManager.SetInvoiceHeader(new Entities.Invoices.InvoiceHeaderParams()
                {
                    Id = null,
                    CoreQuotNumber = cotizacion.ToLong(),
                    InvoiceAmount = totalWithTaxes,
                    InvoiceNumber = invoiceNumber,
                    SecuenciaMov = secuenciaMov,
                    UserId = GetCurrentUserID().GetValueOrDefault(),
                    InvoicingPeriod = fechaAFacturar.ToDatetime(),
                    LastInclusion = allIncludePeriod != null ? allIncludePeriod.FechaInclusion : null,
                    LastExclusion = allExclude != null ? allExclude.FechaExlusion : null,
                    PolicyInfoId = PolicyInfoId,
                    PeriodPolicyId = PeriodPolicyId
                });

                foreach (var v in allActive)
                {
                    oInvoiceManager.SetInvoiceDetail(new Entities.Invoices.InvoiceDetailParams()
                    {
                        Id = null,
                        InvoiceHeaderId = iheade.Id,
                        Item = v.Item.GetValueOrDefault(),
                        ClientName = v.Cliente,
                        MakeId = v.IdMarca.ToInt(),
                        MakeName = v.Marca,
                        ModelId = v.Idmodelo.ToInt(),
                        ModelName = v.Modelo,
                        Chassis = v.chasis,
                        Plate = v.placa,
                        Year = v.Ano.ToInt(),
                        Amount = v.Prima.GetValueOrDefault(),
                        Status = v.EstatusItem,
                        DateProcess = DateTime.Now
                    });
                }

                oInvoiceManager.SetPeriodInvoiced(PolicyInfoId, PeriodId, DateTime.Now);

                #endregion
            }
            catch (Exception ex)
            {
                messageError = "Ha ocurrido un error: " + ex.Message;
                success = false;

                Utility.Log(GetCurrentUserLogin(), "Error en el metodo ProcessDeclarativePolicy (Facturacion Declarativa)", ex.Message, ex);
            }

            return Json(new { success = success, messageError = messageError }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult validateInvoicingDate(string jsondata)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsondata);

            string messageError = "";

            string fechaAFacturar = Convert.ToString(data.billingDate);

            DateTime fefac = Convert.ToDateTime(fechaAFacturar);

            //Valido que la fecha actual no sea menor a la fecha a facturar
            DateTime currDate = DateTime.Now;
            if (currDate.Date < fefac.Date)
            {
                //, ¿Está seguro que desea continuar?
                messageError = string.Format("El periodo de facturación de la póliza {0} aún no ha concluido, no puede continuar.", data.Policy);
                return Json(new { messageError = messageError }, JsonRequestBehavior.AllowGet);
            }
            //

            return Json(new { messageError = messageError }, JsonRequestBehavior.AllowGet);
        }
    }
}