using Newtonsoft.Json;
using ShipLogs.Logic;
using ShipLogs.Logic.LogicBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ShipLogs.Frontend.Controllers
{
    public class ShipLogsController : Controller
    {
        private ShioLogsManager LogicManager = new ShioLogsManager();

        public ActionResult _ShipLogSearch(string allData = "")
        {
            var shipModel = LogicManager.GET_Shimet_Logic_All();

            ViewBag.ShipmentNumber = new SelectList(shipModel.Select(x => x.ShipmentNumber).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.CarrierName = new SelectList(shipModel.Select(x => x.CarrierName).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.Operat = new SelectList(shipModel.Select(x => x.Operat).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.Incoming = new SelectList(shipModel.Select(x => x.Incoming).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");


            return View(shipModel);
        }


        public ActionResult CargarShipLogs(string data)
        {
            string isType = "";
            //var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", ""));
            var url = HttpUtility.UrlDecode(data);
            var dec = Tools.Decode(url);

            //valido que tipo de logtype es
            var validalogtype = LogicManager.IsIncomingVerificationLog(dec);

            foreach (var v in validalogtype)
            {
                isType = v.Incoming;
            }

            if (isType == "Incoming")
            {
                //Obtengo el detalle de Incoming
                var detail =LogicManager.Method_Incoming(dec);
            }
            else if (isType == "Outgoing")
            {
                //Obtengo el solo el Outgoing
                var detail = LogicManager.Method_Outgoing(dec);
            } 
            return View();


        }
    }
}

