using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ServicioTest.Service1Client cliente = new ServicioTest.Service1Client();

        public ActionResult Index()
        {
            var resultado = cliente.Mierda(10,20);
            var resultGetdata = cliente.GetData(10);
            var resultGetdata2 = cliente.GetDataUsingDataContract(new ServicioTest.CompositeType
            {
                BoolValue = true,
                StringValue = "sds"
            });

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
    }
}