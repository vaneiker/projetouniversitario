using StateTrustGlobal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateTrustGlobal.ViewModels;

namespace MantModelosyMarcas.Controllers
{
    public class IgnoreValidationController : BaseController
    {
        DataAccess DataAccess = new DataAccess();

        //
        // GET: /IgnoreValidation/
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "IgnoreValidation";

            try
            {
                var model = DataAccess.getAllQuotations();
                return View(model);
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al cargar las cotizaciones", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "IgnoreValidation", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AddQuot(string quotNum = "")
        {
            ViewBag.CurrentPage = "IgnoreValidation";

            try
            {
                if (!string.IsNullOrEmpty(quotNum))
                {
                    var model = DataAccess.getAllQuotations(quotNum);
                    if (model.Count() > 0)
                    {
                        return View(model.FirstOrDefault());
                    }
                }

                return View(new IgnoreValidacion());
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al editar la cotizacion!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "IgnoreValidation", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddQuot(IgnoreValidacion model, FormCollection form)
        {
            try
            {
                model.UserID = UserData.UserID;
                var Ignore_Status = form["Ignore_Status"];
                if (Ignore_Status != null)
                {
                    if (Ignore_Status == "A")
                    {
                        model.Status = true;
                    }
                    else
                    {
                        model.Status = false;
                    }
                }

                DataAccess.SetQuotationNoValidate(model);

                Success(string.Format("A la cotizacion: {0} le fue {1} la validación de Rnc/Cedula", model.QuotationNumber, model.Status == true ? "Desactivada" : "Activada"), true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al Desactivar/Activar la validación de Rnc/Cedula a la cotización: {0}", model.QuotationNumber);
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "IgnoreValidation", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }
    }
}