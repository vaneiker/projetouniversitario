using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
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

        public JsonResult GetClientesList()
        {


            List<Clientes> clientes = new List<Clientes>();
            clientes.Add(new Clientes { Id = 1, FullName = "Pedro jose Van eiker Rudecindo ", Age = 25 });
            clientes.Add(new Clientes { Id = 2, FullName = "Jherol Dotel", Age = 28 });
            clientes.Add(new Clientes { Id = 3, FullName = "Carlos Lebrón", Age = 50 });
            clientes.Add(new Clientes { Id = 4, FullName = "Julissy Amador", Age = 43 });

            string fullName = Request.QueryString["FullName"];
            string age = Request.QueryString["Age"];
            string id = Request.QueryString["Id"];

            var result = from s in clientes
                         where (string.IsNullOrEmpty(fullName) || s.FullName.Equals(fullName))
                         && (string.IsNullOrEmpty(age) || s.Age == int.Parse(age))
                         && (string.IsNullOrEmpty(id) || s.Id == int.Parse(id))
                         select s;
            var model = result.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}