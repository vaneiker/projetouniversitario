//using Statetrust.Framework.Security.Bll;
using StateTrustGlobal.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;

namespace MantModelosyMarcas.Controllers
{
    public class EndosatariosController : BaseController
    {

        // GET: /Endosatarios/
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "Endosatarios";
            //Session["Usuario"] = GetCurrentUserID();
            var objeto = Session["Usuario"];
            var model = StateTrustGlobal.Data.DataAccess.Data(new Endorsement.Get.Parameters { });// Endorsement.Get.Data(new Endorsement.Get.Parameters { });
            
            return View(model);
        }

        [HttpPost]
        public JsonResult Guardar(Endorsement.Set.Parameters parameters)
        {
            dynamic result = new Endorsement.Set.Result { };
            Endorsement.Get.Result RncValidar = StateTrustGlobal.Data.DataAccess.Data(new Endorsement.Get.Parameters { Rnc = parameters.Rnc.Replace("-",""), Name = "" });
            if (RncValidar != null)
            {
                if (RncValidar.EndorsementId != parameters.EndorsementId && parameters.Rnc.Replace("-","") == RncValidar.Rnc)
                {
                    result.Message = "El RNC indicado ya está en el sisema, debe seleccionarlo en modo de edición si desea modificarlo.";
                    result.Error = true;
                }
                else
                {
                    parameters.UsrId = Convert.ToInt32(Session["Usuario"]);
                    result = StateTrustGlobal.Data.DataAccess.SaveEndorsements(parameters);
                    result.Error = false;
                }
            }
            else
            {
                parameters.UsrId = Convert.ToInt32(Session["Usuario"]);
                result = StateTrustGlobal.Data.DataAccess.SaveEndorsements(parameters);
                result.Error = false;
            }
            
           
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ValidarRNC(Endorsement.Get.Parameters parameters)
        {
            Endorsement.Get.Result result = StateTrustGlobal.Data.DataAccess.Data(parameters);
            //result = StateTrustGlobal.Data.DataAccess.Data(parameters);
            //result.Message = 
            string json = JsonConvert.SerializeObject(result);
            return Json(json, JsonRequestBehavior.DenyGet);
        }

  
        //protected Usuarios GetCurrentUsuario()
        //{
        //    var sessionManager = Statetrust.Framework.Security.Core.Util.SessionManager.Get(Session);

        //    if (sessionManager == null)
        //        return null;
        //    else
        //        return Usuario;
        //}

        //public int? GetCurrentUserID()
        //{
        //    var usuario = GetCurrentUsuario();
        //    if (usuario != null)
        //    {
        //        return usuario.UserID;
        //    }

        //    return null;
        //}
    }
}