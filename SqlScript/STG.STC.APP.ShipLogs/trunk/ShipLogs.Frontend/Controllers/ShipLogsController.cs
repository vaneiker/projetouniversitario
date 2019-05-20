﻿using ShipLogs.Entity.Entity;
using ShipLogs.Logic.LogicBL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ShipLogs.Frontend.Controllers
{
    public class ShipLogsController : Controller
    {
        private ShioLogsManager LogicManager = new ShioLogsManager();

        public ActionResult ShipLogSearch()
        {
            var shipModel = LogicManager.GET_Shimet_Logic_All();

            ViewBag.ShipmentNumber = new SelectList(shipModel.Select(x => x.ShipmentNumber).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.CarrierName = new SelectList(shipModel.Select(x => x.CarrierName).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.Sender = new SelectList(shipModel.Select(x => x.Sender).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.Receiver = new SelectList(shipModel.Select(x => x.Receiver).Distinct().ToArray().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
            ViewBag.conteo = shipModel.Count().ToString();

            return View(shipModel);
        }
        public ActionResult CargarShipLogs(string data)
        {





            string msjbtn = "";
            var shipModel = LogicManager.GET_Shimet_Logic_All();
            var result = new ShipmentEntity();
            //var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", "")); 


            ViewBag.Carrier = LogicManager.CarrierLogicDirect();
            ViewBag.Operator = LogicManager.GetOperator();

            var temp = data == null ? "SAVE" : "UPDATE";

            // data is null? set the value a MA== 
            if (string.IsNullOrWhiteSpace(data) || data=="null")
            {  
                data = HttpUtility.UrlDecode("MA==");
            }
            else
            {
                var url = HttpUtility.UrlDecode(data);
                var dec = Tools.Decode(url);

                if (dec != "0")
                {
                    //valido que tipo de logtype es
                    var validalogtype = LogicManager.IsIncomingVerificationLog(dec);

                    if (validalogtype.Incoming)
                    {
                        //Obtengo el detalle de Incoming
                        var p = LogicManager.Method_Incoming(dec);

                    }
                    else
                    {
                        //Obtengo el solo el Outgoing
                        result = LogicManager.Method_Outgoing(dec);

                    }
                }
                else
                {
                    result = null;
                }
            }
            ViewBag.btnMenssager = temp;
            return View(result);
        }

        public JsonResult GetCurrier(string searchString)
        {
            var data = LogicManager.CarrierLogic(searchString);

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveShipManten(ShipmentEntity objModel)
        {

            dynamic showMessageString = string.Empty;
            if (!objModel.Incoming)
            {
                var resp = LogicManager.Set_Shimet_Logic(objModel);

                if (resp.Value == "INSERT" || resp.Value == "UPDATE")
                {
                    showMessageString = new
                    {
                        param1 = 202,
                        param2 = "The Registry was successfully saved!",
                        param3 = resp.id

                    };

                }
                else
                {
                    showMessageString = new
                    {
                        param1 = 404,
                        param2 = "The Record was not saved successfully!",
                        param3 = resp.Value
                    };
                }

            }
            return Json(showMessageString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveShipMantenDetail(List<ShipmentEntity.ShipmentDetailEntity> datalle)
        {
            dynamic showMessageString = string.Empty;
            var resp = LogicManager.Set_ShimetDetailsInsert_Logic(datalle);

            return Json(showMessageString, JsonRequestBehavior.AllowGet);
        }
    }
}
