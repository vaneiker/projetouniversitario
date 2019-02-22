
using StateTrustGlobal.Data;
using StateTrustGlobal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MantModelosyMarcas.Controllers
{
    public class MovimientoCarteras1Controller : Controller
    {
/*
        //
        // GET: /MovimientoCarteras/
        DataAccess DataAccess = new DataAccess();
        public ActionResult Index(MovimientoCartera movimientoCartera)
        {
            if (movimientoCartera.Note == null)
            {
                ViewBag.CurrentPage = "MovimientoCarteras";

                return View();
            }
            else
            {
                Session["DateOut"] = movimientoCartera.DateOut;
                Session["DateIn"] = movimientoCartera.DateIn;
                Session["Note"] = movimientoCartera.Note;
                Session["New_Supervisor_Agent_Id"] = movimientoCartera.New_Supervisor_Agent_Id;
                Session["New_Supervisor_Agent_Code"] = movimientoCartera.New_Supervisor_Agent_Code;
                var moveAgentesCartera = new MovimientoCartera();
                moveAgentesCartera.MostrarAgentes = new List<Agentes>();
                moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
                return RedirectToAction("MoveAgentesCartera", moveAgentesCartera);
            }
        }


        public ActionResult MoveAgentesCartera()
        {
            var moveAgentesCartera = new MovimientoCartera();
            moveAgentesCartera.MostrarAgentes = new List<Agentes>();
            moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
            return View(moveAgentesCartera);
        }




        public ActionResult MostrarAgentes(string ID, Agentes agentes)
        {
            if (ID == null)
            {
                var Datos = DataAccess.Mostrar_Agentes();
                return View(Datos);
            }
            else
            {
                var Datos = DataAccess.Mostrar_Agentes(ID);
                var Names = Datos.ToList()[0].Name;
                var Agent_ids = Datos.ToList()[0].Agent_id;
                var Agent_Codes = Datos.ToList()[0].Agent_Code;

                var moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;

                agentes = new Agentes
                {
                    Name = Names,
                    Agent_id = Agent_ids,
                    Agent_Code = Agent_Codes
                };
                moveAgentesCartera.MostrarAgentes.Add(agentes);

                return View(Datos);
            }
      }
	  */
    }
}