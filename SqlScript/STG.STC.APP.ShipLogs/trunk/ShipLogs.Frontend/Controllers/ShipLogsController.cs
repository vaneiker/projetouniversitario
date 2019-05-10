using ShipLogs.Entity.Entity;
using ShipLogs.Logic.LogicBL;
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
           

            var result = new ShipmentEntity();
            //var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", ""));
            if (string.IsNullOrWhiteSpace(data))
            {
                //Redirect("");
            }
            else
            {
                var url = HttpUtility.UrlDecode(data);
                var dec = Tools.Decode(url);

                //valido que tipo de logtype es
                var validalogtype = LogicManager.IsIncomingVerificationLog(dec); 
                if (validalogtype.Incoming)
                {
                    //Obtengo el detalle de Incoming
                    var detail = LogicManager.Method_Incoming(dec);
                }
                else
                {
                    //Obtengo el solo el Outgoing
                    result = LogicManager.Method_Outgoing(dec);
                    
                }

            }
            return View(result);
        }

        public JsonResult GetCurrier(string searchString)
        {
            var data = LogicManager.GetCarrierLogic(searchString);

            return Json(data,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveShipManten(ShipmentEntity objModel)
        {
            dynamic showMessageString = string.Empty;



            if (!objModel.Incoming)
            {
                var resp = LogicManager.Set_Shimet_Logic(objModel);
                showMessageString = new
                {
                    //param1 = 402,
                    //param2 = get.ExceptionMessenger
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            else
            {
                showMessageString = new
                {
                    //param1 = 202,
                    //param2 = get.Poliza,
                    //param3 = get.NombreCliente
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }

        }

    }
}

