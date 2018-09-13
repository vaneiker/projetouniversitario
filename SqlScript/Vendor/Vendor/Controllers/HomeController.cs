using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using Modelo.Model;
using Newtonsoft.Json;
using Vendor.ServicioWeb;

namespace Vendor.Controllers
{
    public class HomeController : Controller
    {


        _Repocitory g = new _Repocitory();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Vendor(string vendor,string agentId)
        {
            if(string.IsNullOrWhiteSpace(vendor)|| string.IsNullOrWhiteSpace(agentId))
            {
                return View(g.Listado().ToList());
            }

            return View(g.SearchVendor(vendor, agentId).ToList());
           
        }
        

        public ActionResult MostrarVendor(string data)
        {
            if (data == null)
            {
                return Redirect("~/Home/Vendor");
            }
            var url = HttpUtility.UrlDecode(data.Replace("+", "").Replace("/", ""));
           //var desc = Tools.Encode(url);
            var Record = JsonConvert.DeserializeObject<EN_AGENT_GP_COMMISSION_entity>(url);

            return View(Record);
        }

        

        public ActionResult SaveVendor(string data)
        {
             if (data == null)
            {
                return Redirect("~/Home/Vendor");
            }
            var url = HttpUtility.UrlDecode(data.Replace("+", "").Replace("/", ""));
            //var desc = Tools.Encode(url);
            var Record = JsonConvert.DeserializeObject<EN_AGENT_GP_COMMISSION_entity>(url);

            return View(Record);
        }

        // El Json recibido será serializado automáticamente al objeto nuevo cocche teniendo en cuenta que las propiedades han de tener el mismo nombre
         
        public ActionResult SaveVendorJs(EN_AGENT_GP_COMMISSION_entity vendorP)
        {
            if (g.AddVendor(vendorP))
                return Redirect("~/Home/Vendor");
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al insertar el registro.'"));
        }

    }
}