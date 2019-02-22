using Statetrust.Framework.Security.Bll;
using Statetrust.Framework.Web.Mvc.WebParts.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace MantModelosyMarcas.Controllers
{
    public class BbaseController : STFMainController
    {
        //
        // GET: /Bbase/
        public ActionResult Index()
        {
            return View();
        }
	}
}