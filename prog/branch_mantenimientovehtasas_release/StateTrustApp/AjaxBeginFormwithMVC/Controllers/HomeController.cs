using AjaxBeginFormwithMVC.Models;
using StateTrustGlobal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace AjaxBeginFormwithMVC.Controllers
{
    public class HomeController : Controller
    {
        DataAccess DataAccess = new DataAccess();
        [HttpGet]
        public ActionResult EmployeeMaster(int? pageNumber, string Search)
        {

            var MostrarDatos = DataAccess.Mostrar_Marcas().ToList();
            return View(MostrarDatos);
          
        }
        [HttpPost]
        public ActionResult EmployeeMaster(EmpModel obj)
        {
            ViewBag.Records = "Name : " + obj.Name + " City:  " + obj.City + " Addreess: " + obj.Address;
            return PartialView("EmployeeMaster");
        }  
    }
}