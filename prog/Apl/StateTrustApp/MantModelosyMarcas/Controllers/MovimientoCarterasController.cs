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
        //
        // GET: /MovimientoCarteras/
        DataAccess DataAccess = new DataAccess();
        public ActionResult Index()
        {
            ViewBag.CurrentPage = "MovimientoCarteras";
            var moveAgentesCartera = new MovimientoCartera();
            moveAgentesCartera.ListAgentes = new List<Agentes>();
            Session["moveAgentesCartera"] = moveAgentesCartera;
            Llenar_Agentes();
            return View(moveAgentesCartera);
        }

        public void Llenar_Agentes()
        {
            var agentes = DataAccess.Mostrar_Agentes();
            //ViewBag.Agentes = new SelectList(agentes, "Agent_id", "Name");

            List<Agentes> Agentes = agentes.OrderBy(x => x.Name).ToList();

            // pass results to viewbag

            ViewBag.Agentes = Agentes;

        }

        [HttpGet]
        public ActionResult MostrarAgentes(string ID)
        {
            if (ID == null)//Cargo la pantalla por primera vez
            {
                var Datos = DataAccess.Mostrar_Agentes();
                return View(Datos);
            }
            else// SE AGREGA EL PRIMER REGISTRO     
            {
                var Datos = DataAccess.Mostrar_Agentes(ID);
                var Names = Datos.ToList()[0].Name;
                var Agent_ids = Datos.ToList()[0].Agent_id;
                var Agent_Codes = Datos.ToList()[0].Agent_Code;
                var moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
               var agentes = new Agentes
                {
                    Name = Names,
                    Agent_id = Agent_ids,
                    Agent_Code = Agent_Codes
                };
                moveAgentesCartera.ListAgentes.Add(agentes);
                Session["moveAgentesCartera"] = moveAgentesCartera;
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult MostrarAgentes(string ID, Agentes agentes)
        {
            ViewBag.CurrentPage = "MovimientoCarteras";
            if (ID == null)//Cargo la pantalla por primera vez
            {
                var Datos = DataAccess.Mostrar_Agentes();
                return View(Datos);
            }
            else
            {
                var moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
                if (moveAgentesCartera.ListAgentes.Count > 0)
                {
                    #region Recorro la lista de los agentes que estan agregados para agregar agentes diferentes

                    for (int a = 0; a < moveAgentesCartera.ListAgentes.Count; a++)
                    {
                        int Agent_id = moveAgentesCartera.ListAgentes.ToList()[a].Agent_id;

                        if (Agent_id == int.Parse(ID))
                        {
                            var Datos = DataAccess.Mostrar_Agentes().Take(50);
                            TempData["msg"] = (string.Format("El Agente <b>{0}</b> ya fue seleccionado !!", moveAgentesCartera.ListAgentes.ToList()[a].Name));
                            // Danger(string.Format("El Agente <b>{0}</b> ya fue seleccionado !!", moveAgentesCartera.ListAgentes.ToList()[a].Name), true);
                            return View(Datos);
                        }
                    }
                    #endregion
                    var Datos1 = DataAccess.Mostrar_Agentes(ID);
                    var Names = Datos1.ToList()[0].Name;
                    var Agent_ids = Datos1.ToList()[0].Agent_id;
                    var Agent_Codes = Datos1.ToList()[0].Agent_Code;

                    agentes = new Agentes
                    {
                        Name = Names,
                        Agent_id = Agent_ids,
                        Agent_Code = Agent_Codes
                    };
                    moveAgentesCartera.ListAgentes.Add(agentes);
                    Session["moveAgentesCartera"] = moveAgentesCartera;
                    return View("Index", moveAgentesCartera);

                }
                else// SE AGREGA EL PRIMER REGISTRO
                {
                    var Datos = DataAccess.Mostrar_Agentes(ID);
                    var Names = Datos.ToList()[0].Name;
                    var Agent_ids = Datos.ToList()[0].Agent_id;
                    var Agent_Codes = Datos.ToList()[0].Agent_Code;

                    agentes = new Agentes
                    {
                        Name = Names,
                        Agent_id = Agent_ids,
                        Agent_Code = Agent_Codes
                    };
                    moveAgentesCartera.ListAgentes.Add(agentes);
                    Session["moveAgentesCartera"] = moveAgentesCartera;
                    return View("Index", moveAgentesCartera);
                }
            }
        }

        [HttpPost]
        public ActionResult Index(MovimientoCartera movimientoCartera, FormCollection form)
        {
            ViewBag.CurrentPage = "MovimientoCarteras";
            string[] selitems = form.GetValues("Agentes");
            foreach (var item in selitems)
            {
                var GetAgentes = DataAccess.Mostrar_Agentes().Where(x => x.Agent_id == int.Parse(item)).ToList();
            }
            return View();
        }
        [HttpPost]
        //public ActionResult OtrosDatos()
        //{
        //    ViewBag.CurrentPage = "MovimientoCarteras";
           
            
        //        var moveAgentesCartera = new MovimientoCartera();
        //        moveAgentesCartera.ListAgentes = new List<Agentes>();
        //        moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
             
        //       var agentes = new Agentes
        //        {
        //            Name = moveAgentesCartera.ListAgentes.ToList()[0].Name,
        //            Agent_id = moveAgentesCartera.ListAgentes.ToList()[0].Agent_id,
        //            Agent_Code = moveAgentesCartera.ListAgentes.ToList()[0].Agent_Code
        //        };
        //        Session["moveAgentesCartera"] = moveAgentesCartera;

        //        Session["DateOut"] = movimientoCartera.DateOut;
        //        Session["DateIn"] = movimientoCartera.DateIn;
        //        Session["Note"] = movimientoCartera.Note;
        //        Session["New_Supervisor_Agent_Id"] = movimientoCartera.New_Supervisor_Agent_Id;
        //        Session["New_Supervisor_Agent_Code"] = movimientoCartera.New_Supervisor_Agent_Code;
        //        return View("AllDatos", moveAgentesCartera);

        //}
        public ActionResult AllDatos()
        {
            ViewBag.CurrentPage = "MovimientoCarteras";
            var moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;
            var agentes = new Agentes
              {
                  Name = moveAgentesCartera.ListAgentes.ToList()[0].Name,
                  Agent_id = moveAgentesCartera.ListAgentes.ToList()[0].Agent_id,
                  Agent_Code = moveAgentesCartera.ListAgentes.ToList()[0].Agent_Code
              };
            Session["moveAgentesCartera"] = moveAgentesCartera;
            return View(moveAgentesCartera);
        }

        public ActionResult VolverOtrosDatos(MovimientoCartera movimientoCartera)
        {
            ViewBag.CurrentPage = "MovimientoCarteras";

    
                movimientoCartera.DateOut = Convert.ToDateTime(Session["DateOut"].ToString());
                movimientoCartera.DateIn = Convert.ToDateTime(Session["DateIn"].ToString());
                movimientoCartera.Note = Session["Note"].ToString();
                movimientoCartera.New_Supervisor_Agent_Id = Convert.ToInt32(Session["New_Supervisor_Agent_Id"].ToString());
                movimientoCartera.New_Supervisor_Agent_Code = Convert.ToInt32(Session["New_Supervisor_Agent_Code"].ToString());
                return View(movimientoCartera);
            
        }
        [HttpPost]
        public ActionResult VolverOtros_Datos(MovimientoCartera movimientoCartera)
        {
            ViewBag.CurrentPage = "MovimientoCarteras";

            Session["DateOut"] = movimientoCartera.DateOut;
            Session["DateIn"] = movimientoCartera.DateIn;
            Session["Note"] = movimientoCartera.Note;
            Session["New_Supervisor_Agent_Id"] = movimientoCartera.New_Supervisor_Agent_Id;
            Session["New_Supervisor_Agent_Code"] = movimientoCartera.New_Supervisor_Agent_Code;
            var moveAgentesCartera = new MovimientoCartera();
            moveAgentesCartera.ListAgentes = new List<Agentes>();
            moveAgentesCartera = Session["moveAgentesCartera"] as MovimientoCartera;


            var agentes = new Agentes
            {
                Name = moveAgentesCartera.ListAgentes.ToList()[0].Name,
                Agent_id = moveAgentesCartera.ListAgentes.ToList()[0].Agent_id,
                Agent_Code = moveAgentesCartera.ListAgentes.ToList()[0].Agent_Code
            };
            Session["moveAgentesCartera"] = moveAgentesCartera;
            return View("AllDatos", moveAgentesCartera);

        }

    }
}
 



      
