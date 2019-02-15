using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicNegocio.Global_Logica;
using Entity.Global_Entity;

namespace WebAplicationMvc.Controllers
{
    public class HomeController : Controller
    {
        VendorLogic metodos = new VendorLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoVendor()
        {
            var L = metodos.ListadoVendorLogica();

            return View(L);
        }

        public JsonResult GetListadoVendor()
        {
            var L = metodos.ListadoVendorLogica();

            return Json(L, JsonRequestBehavior.AllowGet);
        }

        public RedirectResult Saves(int CorpId=0,int AgentId=0,bool NoCommission=false,bool TakeVendorId = false, string VendorId="",bool AgentStatus = false, DateTime? CreateDate=null,DateTime? ModiDate = null, int CreateUsrId=0,int? ModiUsrId=0 ,string Full_Name="",string Hostname="")
        {
            VendorEntitySave save = new VendorEntitySave();
            save.CorpId      =CorpId;
            save.AgentId     =AgentId;
            save.NoCommission=NoCommission;
            save.TakeVendorId=TakeVendorId;
            save.VendorId    =VendorId;
            save.AgentStatus =AgentStatus;
            //save.CreateDate  = CreateDate;
            save.ModiDate    =ModiDate;
            save.CreateUsrId =CreateUsrId;
            save.ModiUsrId   =ModiUsrId;     
            save.Hostname = Hostname;

            var repuesta = metodos.SaveVendor(save);
            if (repuesta == true)
            {
                return Redirect("~/Home/Index");
            }
            else
            {
                return Redirect("GetListadoVendor");
            }
        }

        public ActionResult Obtener(int id = 0)
        {
            if (id == 0)
            {
                return Redirect("~/Home/ListadoVendor");
            }
            else
            {
                var L = metodos.ObtenerVendorLogica(id);
                if (L == null)
                {
                    return Redirect("~/Home/ListadoVendor");
                }
                else
                {
                    return View(L);
                }
            }



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