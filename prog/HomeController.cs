using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_Concurso.Models;
namespace APP_Concurso.Controllers
{
    public class HomeController : Controller
    {
        private Repocitory repocitory = new Repocitory();
        public ActionResult Index()
        {
            string enviarCantidad = "";
            var data = repocitory.GetConcursoList();
            
            var cantidaR = data.Count();

            ViewBag.enviarCantidad = cantidaR.ToString();
            return View(data);
        } 

        [HttpPost]
        public JsonResult GeneralRandom()
        {
            var get = repocitory.GetConcurso();
            //System.Threading.Thread.Sleep(3000);
            dynamic showMessageString = string.Empty;

            if (get.Poliza == null)
            {
                showMessageString = new
                {
                    param1 = 402,
                    param2 = get.ExceptionMessenger
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            } else
            {
                showMessageString = new
                {
                    param1 = 202,
                    param2 = get.Poliza
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            //try
            //{

            //    showMessageString = new
            //    {
            //        param1 = get.Poliza,
            //        param2 = get.NombreCliente
            //    };
            //    return Json(showMessageString, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    var errorMsg = ex.Message.ToString();
            //    showMessageString = new
            //    {
            //        param1 = 404,
            //        param2 = get.ExceptionMessenger
            //    };
            //    return Json(showMessageString, JsonRequestBehavior.AllowGet);
            //}
        }
    }
}