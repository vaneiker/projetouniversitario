using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.Helpers
{
    public class AjaxHandleErrorAttribute : HandleErrorAttribute
    {

        public string CustomMessage { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.Result = new JsonResult
                {
                    Data = new { success = false, error = "Se ha producido un error en el servidor: " +  filterContext.Exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
                base.OnException(filterContext);
        }
    }
}