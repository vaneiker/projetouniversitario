using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models;
using KSI.Cobranza.Web.Models.ViewModels;

namespace KSI.Cobranza.Web.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        public ActionResult Index()
        {                   
            var model = Utility.GenerateDummyData<QueueViewModels>(7).ToList();
            return View(model);
        }
    }
}