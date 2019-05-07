using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShipLogsEntity.Entity;
using ShipLogsLogic.Logic;
using System.Linq.Dynamic;

namespace ShipAplication.Controllers
{
    public class ShipLogsController : Controller
    {
        private ShipLogsManager shipLogsManager = new ShipLogsManager();
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult LoadData()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();            
            var start= Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][columns]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var CarrierName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            var ShipmentNumber = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();

            var pageSize = length != null ?length : "";
            var skip= start != null ? start : "";
            var recordsTotal = 0;

            var v = shipLogsManager.GetShipLogs();
            if (string.IsNullOrWhiteSpace(CarrierName))
            {
                v = v.Where(x => x.CarrierName == CarrierName);
            }

            if (string.IsNullOrWhiteSpace(ShipmentNumber))
            {
                v = v.Where(x => x.ShipmentNumber == ShipmentNumber);
            }

            //if(!(string.IsNullOrWhiteSpace(sortColumn) && string.IsNullOrWhiteSpace(sortColumnDir)))
            //{
            //    v =v.OrderBy(sortColumn + " " + sortColumnDir);
            //}

            recordsTotal = v.Count();
            var data = v.Skip(int.Parse(skip)).Take(int.Parse(pageSize)).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }





        public ActionResult _ShipLogsTable(string allData = "")
        {
            var listModel = shipLogsManager.GetShipLogs();

            //ViewBag.SellerCodes = new SelectList(ainfoModel.Select(x => x.AgentCode).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
             ViewBag.ShipmentNumber = new SelectList(listModel.Select(x => x.ShipmentNumber).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
             ViewBag.CarrierName = new SelectList(listModel.Select(x => x.CarrierName).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
             //ViewBag.ShipmentDate = new SelectList(listModel.Select(x => x.ShipmentDate).Distinct().ToList().Select(i => new SelectListItem { Text = i, Value = i }), "Value", "Text");
             
 

            return PartialView(listModel);
        }

    }
}