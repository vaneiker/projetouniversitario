using Newtonsoft.Json;
using ShipLogs.Entity.Entity;
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

            string url = "";
            string dec = "";

            string msjbtn = "";


            ShipmentEntityViewModel result = new ShipmentEntityViewModel();

            List<ShipmentEntityViewModel.detail> detail = new List<ShipmentEntityViewModel.detail>();
            ShipmentEntityViewModel.ShipmentEntity shipmentEntity = new ShipmentEntityViewModel.ShipmentEntity();

            //var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", "")); 


            ViewBag.Carrier = LogicManager.CarrierLogicDirect();
            ViewBag.Operator = LogicManager.GetOperator();

            var temp = data == null ? "SAVE" : "UPDATE";

            // data is null? set the value a MA== 
            if (string.IsNullOrWhiteSpace(data) || data == "null")
            {
                data = HttpUtility.UrlDecode("MA==");

                shipmentEntity.Incoming = false;
                shipmentEntity.ShipUniqueID = 0;


            }
            else
            {
                url = HttpUtility.UrlDecode(data);
                dec = Tools.Decode(url);

                if (dec != "0")
                {
                    //valido que tipo de logtype es
                    var validalogtype = LogicManager.IsIncomingVerificationLog(dec);

                    if (validalogtype.Incoming)
                    {
                        //Obtengo el detalle de Incoming
                        shipmentEntity = LogicManager.Method_Incoming(dec);
                        result.shipmentEntity = shipmentEntity;

                        //result = LogicManager.Method_Incoming(dec);
                        result.detalles = LogicManager.GET_SHIPMENTDETAILSLog(dec);

                    }
                    else
                    {
                        //Obtengo el solo el Outgoing
                        result.shipmentEntity = LogicManager.Method_Outgoing(dec);

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
        public JsonResult SaveShipManten(ShipmentEntityViewModel objModel)
        {
            var objetoreal = new ShipmentEntity();

            dynamic showMessageString = string.Empty;

            objetoreal.ShipUniqueID = objModel.shipmentEntity.ShipUniqueID;
            objetoreal.CarrierName = objModel.shipmentEntity.CarrierName;
            objetoreal.AccountNumber = objModel.shipmentEntity.AccountNumber;
            objetoreal.ShipmentNumber = objModel.shipmentEntity.ShipmentNumber;
            objetoreal.ShipmentDate = objModel.shipmentEntity.ShipmentDate;
            objetoreal.ShipmentWeight = objModel.shipmentEntity.ShipmentWeight;
            objetoreal.ShipmentQTY = objModel.shipmentEntity.ShipmentQTY;
            objetoreal.ShipPackageType = objModel.shipmentEntity.ShipPackageType.TrimEnd().TrimStart();
            objetoreal.Operator = objModel.shipmentEntity.Operator;
            objetoreal.Sender = objModel.shipmentEntity.Sender;
            objetoreal.Receiver = objModel.shipmentEntity.Receiver;
            objetoreal.ReceiverAttn = objModel.shipmentEntity.ReceiverAttn;
            objetoreal.ReceiverAddress = objModel.shipmentEntity.ReceiverAddress;
            objetoreal.ReceiverCity = objModel.shipmentEntity.ReceiverCity;
            objetoreal.ReceiverState = objModel.shipmentEntity.ReceiverState;
            objetoreal.ReceiverZipCode = objModel.shipmentEntity.ReceiverZipCode;
            objetoreal.ReceiverCountry = objModel.shipmentEntity.ReceiverCountry;
            objetoreal.ReceiverPhoneNumber = objModel.shipmentEntity.ReceiverPhoneNumber;
            objetoreal.ShipmentComments = objModel.shipmentEntity.ShipmentComments;
            objetoreal.Transit = objModel.shipmentEntity.Transit;
            objetoreal.Incoming = objModel.shipmentEntity.Incoming;
            objetoreal.CommissionChecks = objModel.shipmentEntity.CommissionChecks;
            objetoreal.Materials = objModel.shipmentEntity.Materials;
            objetoreal.OtherContents = objModel.shipmentEntity.OtherContents;








            var resp = LogicManager.Set_Shimet_Logic(objetoreal);

            if (resp.Value == "INSERT" || resp.Value == "UPDATE")
            {
                showMessageString = new
                {
                    param1 = 202,
                    param2 = "The Registry was successfully saved!",
                    param3 = resp.id,
                    param4 = resp.IdAlf,
                    param5 = resp.Value
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

            return Json(showMessageString, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SaveDet(string jsonDataDetail, int idHeader, string operation)
        {  //deserializando json
            var form = JsonConvert.DeserializeObject<List<dynamic>>(jsonDataDetail);

            if (operation == "UPDATE")
            {
                var isdelete = LogicManager.Set_ShimetDetailsDelete_Logic(idHeader);

                foreach (var itemDetail in form)
                {
                    //aqui mi procedure de guardar el detail
                    LogicManager.Set_ShimetDetailsInsert_Logic(new ShipmentDetailEntity()
                    {
                        AssignedTo = itemDetail.txtAssignedTo.ToString(),
                        ItemDetail = itemDetail.txtTypethedetails.ToString(),
                        DetailUniqueID = 0,
                        ShipUniqueID = idHeader
                    });
                }
            }

            else if (operation == "INSERT")
            {
                foreach (var itemDetail in form)
                {
                    //aqui mi procedure de guardar el detail
                    LogicManager.Set_ShimetDetailsInsert_Logic(new ShipmentDetailEntity()
                    {
                        AssignedTo = itemDetail.txtAssignedTo.ToString(),
                        ItemDetail = itemDetail.txtTypethedetails.ToString(),
                        DetailUniqueID = 0,
                        ShipUniqueID = idHeader
                    });
                }
            }
            return Json("good", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //public JsonResult ListShipDetail(int id)
        //{
        //    var data = LogicManager.GET_SHIPMENTDETAILSLog(id);

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult SaveShipMantenDetail(List<ShipmentDetailEntity> datalle)
        {
            dynamic showMessageString = string.Empty;
            var resp = LogicManager.Set_ShimetDetailsInsert_Logic(datalle);

            return Json(showMessageString, JsonRequestBehavior.AllowGet);
        }
    }
}
