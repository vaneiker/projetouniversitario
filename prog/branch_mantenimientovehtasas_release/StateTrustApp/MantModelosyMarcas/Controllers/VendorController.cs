using StateTrustGlobal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateTrustGlobal.ViewModels;
using Newtonsoft.Json;
using MantModelosyMarcas.Utility;

    namespace MantModelosyMarcas.Controllers
    {
    public class VendorController : Controller
    {
        DataAccess DataAccess = new DataAccess();

        #region VendorGp
 
        public ActionResult Index()
        {
            {
                ViewBag.CurrentPage = "Vendor";

                try
                {
                    var model = DataAccess.GetListVendor();
                    return View(model);
                }
                catch (Exception)
                {
                  
                    return RedirectToAction("Index");
                    throw;

            }
        }
    }
 
        public ActionResult MantenimientoVendor(string data)
            {
                var save = "Nuevo";
                var edit = "Editar";

                if (data == null)
                {
                    ViewBag.Operacion = save;
                    return View();
                }


                var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", ""));
                var dec = Tools.Decode(url);               
                var Record = JsonConvert.DeserializeObject<Vendor>(dec);
                ViewBag.Operacion = edit;
                return View(Record);
            }
 
        public ActionResult SaveVendor(Vendor vendor)
        {
            var usuario = Convert.ToInt32(Session["Usuario"]);
            var data = DataAccess.Add_Vendor_edit(vendor,usuario);
            if (data == 1)
            {
                //return Redirect("Vendor/MantenimientoVendor");
                return Json(String.Format("'Success':'true','Error':'Ha habido un error al insertar el registro.'"));
            } 
            else
            {
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al insertar el registro.'"));
                //return Redirect("Vendor/Index");
            }
        }
        #endregion 

        #region CambioFecha

        public ActionResult MantenimientoAgente()
        {
            ViewBag.CurrentPage = "Agentes";

            try
            {
                var model = DataAccess.AGENT_UNIQUE_AGENT_ID();
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
                throw;

            }
        }
        public ActionResult CargarAgente(string data)
        {
            if (data == null)
            {
                return Redirect("~/Vendor/MantenimientoAgente");
            }
            else
            {
                var url = HttpUtility.UrlDecode(data.Replace("+", " ").Replace("/", ""));
                var dec = Tools.Decode(url);
                var Record = JsonConvert.DeserializeObject<Vendor>(dec);              
                return View(Record);
            }           
           
        }
        public ActionResult EditarAgent(Vendor vendor)
        {
            var usuario=Convert.ToInt32(Session["Usuario"]);

            var data = DataAccess.SET_UPDATE_DATE_AGENT(vendor,usuario);
            if (data == 1)
            {
                return Json(String.Format("'Success':'true','success':'Acción Realizada Correctamente.'"));
                 
            }
            else
            {
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al insertar el registro.'"));
                //return Redirect("Vendor/Index");
            } 
        }

        #endregion

    }
    }