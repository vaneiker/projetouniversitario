using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STL.POS.Data;
using System.IO;
using System.Configuration;

namespace STL.POS.Frontend.Web.Areas.Auto.Controllers
{
    public class GnlPPController : Controller
    {
        // GET: Auto/GnlPP
        public ActionResult Index()
        {
            var model = new PosModel().ProductTypeFamilyBrochures
                .Include("ProductTypes")
                .Include("ProductTypes.CoverageTypes")
                .Include("ProductTypes.CoverageTypes.Coverages")
                .Include("ProductTypes.CoverageTypes.Coverages.CoverageDetails")
                .Include("ProductTypes.Benefits")
                .ToArray();
            return PartialView(model);
        }

        public ActionResult BrochurePdf(string title) {
            var path = Path.Combine(ConfigurationManager.AppSettings["PdfBrochoure"], title + ".pdf");
            return File(path, "application/pdf");
        }
    }
}