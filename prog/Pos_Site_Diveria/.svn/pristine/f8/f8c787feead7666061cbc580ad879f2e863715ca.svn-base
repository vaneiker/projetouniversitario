using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Controllers
{
    public class VersionController : Controller
    {

        public VersionController()
        {
        }

        public ActionResult GetSystemVersionInfo()
        {
            Assembly currAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version v = currAssembly.GetName().Version;
            var stringVersion = v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;

            string configuration = "No configuration";
            var confAtt = currAssembly.GetCustomAttributes(false).Where(attr => attr.GetType() == typeof(AssemblyConfigurationAttribute)).FirstOrDefault();
            if (confAtt != null)
                configuration = (confAtt as AssemblyConfigurationAttribute).Configuration;

            return Content(@"v" + stringVersion + " (" + configuration + ")");
        }

    }
}