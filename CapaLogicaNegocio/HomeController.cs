using System;
using System.Collections.Generic;
using System.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.FrontEnd.Agent_Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult CreateUserAgentNew(List<string> codigos)
        {
            dynamic showMessageString = string.Empty;
            //Logica
            showMessageString = new
            {
                param1 = "Success",
                param2 = "Usuarios Creados Exitosamente",
                
            };
            //showMessageString = new
            //{
            //    param1 = "Error",
            //    param2 = "No se Creo Ningún Usuario",
            //    //param3 = resp.ErrorMenssager
            //};

            return Json(showMessageString, JsonRequestBehavior.AllowGet);
        } 
    }
}