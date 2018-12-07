using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Common
{
    /// <summary>
    /// This class allow controling that only a call it from ajax request
    /// </summary>
    public class HttpAjaxRequestAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            if (!controllerContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new Exception("This action " + methodInfo.Name + " can only be called via an Ajax request");
            }
            return true;
        }
    }
}