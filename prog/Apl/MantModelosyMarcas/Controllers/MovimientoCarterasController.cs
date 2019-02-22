using StateTrustGlobal.Data;
using StateTrustGlobal.Helpers;
using StateTrustGlobal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace MantModelosyMarcas.Controllers
{
    public class MovimientoCarterasController : BaseController
    {
        private GlobalDbContext db = new GlobalDbContext();
        //
        // GET: /MovimientoCarteras/
        DataAccess DataAccess = new DataAccess();
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "MovimientoCarteras";
            Session["Usuario"] = GetCurrentUserID();
            Session["UserName"] = GetCurrentUserName();
         

            if (Session["UserName"] == null)
                Session.Add("UserName", GetCurrentUserName());
            else
                Session["UserName"] = GetCurrentUserName();
            Llenar_Agentes();
            Llenar_Supervisores();
            return View();
        }

        public void Llenar_Agentes()
        {
            var agentes = DataAccess.Mostrar_Agentes();
            List<Agentes> Agentes = agentes.OrderBy(x => x.Name).ToList();
            ViewBag.Agentes = Agentes;
        }
        public void Llenar_Supervisores()
        {
            var supervisores = DataAccess.Mostrar_Supervisores().ToList();
            supervisores.Add(new Agentes { Agent_id = 0, Name = "Seleccione Supervisor" });
            supervisores.OrderBy(x => x.Name).ToList();
            ViewBag.New_Supervisor_Agent_Id = new SelectList(supervisores, "Agent_id", "Name");
        }
        [HttpPost]
        public ActionResult Index(MovimientoCartera movimientoCartera, FormCollection form)
        {
            ViewBag.CurrentPage = "MovimientoCarteras";

            string[] selitems = form.GetValues("Agentes");
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in selitems)
                    {
                        var GetAgentes = DataAccess.Mostrar_Agentes().Where(x => x.Agent_id == int.Parse(item)).ToList();
                        DataAccess.MovimientoCartera(movimientoCartera.DateOut, movimientoCartera.DateIn, movimientoCartera.Note, Session["UserName"].ToString(), 
                            movimientoCartera.New_Supervisor_Agent_Id, movimientoCartera.New_Supervisor_Agent_Code, item, GetAgentes[0].Agent_Code);
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            Llenar_Agentes();
            Llenar_Supervisores();
            return View();
        }
       

    }
}
 



      
