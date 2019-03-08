using StateTrustGlobal.Data;
using StateTrustGlobal.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MantModelosyMarcas.Controllers
{
    public class LocalidadesController : BaseController
    {
        DataAccess DataAccess = new DataAccess();
        #region PROVINCIAS
        public ActionResult Provincies()
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                dynamic model = new ExpandoObject();
                model.Provincias = DataAccess.Mostrar_Provincias_x_Pais();
                return View(model);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index","Home");

            }
        }
        [HttpGet]
        public ActionResult CreateProvincies(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    var datos = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.State_Prov_Id == ID).ToList();
                    var idPais = datos.ToList()[0].Country_Id;

                    var paises = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == idPais);
                    
                    var NomPais = paises.ToList()[0].Global_Country_Desc;

                                     
                    Paises_VM paises_VM = new Paises_VM();

                    var datosp = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == NomPais.ToUpper()).ToList();
                    paises_VM.Nombre_Prov = datos.ToList()[0].State_Prov_Desc;
                    paises_VM.Nombre_Pais = datosp[0].Descripcion;

                    Session["Nombre_Prov"] = "Actualizar";
                    ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc", idPais);
                    Session["State_Prov_Id"] = datos[0].State_Prov_Id;


                    var ProvSysFlex = DataAccess.All_ProvinciasSysFlex().Where(x => x.Descripcion == paises_VM.Nombre_Prov).ToList();
                    Session["CodProv"] = ProvSysFlex[0].Codigo;


                    Llenar_Zonas();
                    return View(paises_VM);

                }
                else
                {
                    ViewBag.CurrentPage = "Localidades";
                    Session["Nombre_Prov"] = "Crear";
                    Llenar_Paises();
                    Llenar_Zonas();
                    return View();
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult CreateProvincies(Paises_VM paises_VM)
        {
            try
            {

                ViewBag.CurrentPage = "Localidades";
                Session["UserName"] = GetCurrentUserName();
                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();



                Session["Usuario"] = GetCurrentUserID();
                if (Session["Usuario"] == null)
                    Session.Add("Usuario", GetCurrentUserID());
                else
                    Session["Usuario"] = GetCurrentUserID();



                if (Session["Nombre_Prov"].ToString() == "Actualizar")
                {
                    var Nombrepais = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);

                    var datos = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == paises_VM.Nombre_Pais.ToUpper());
                    var CodPais = datos.ToList()[0].Codigo;
                    var CodZona = Request["Zonas"];

                    var CodSy = Session["CodProv"].ToString();
                    var State_Prov_Id = Session["State_Prov_Id"].ToString();

                    var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                    var cod = Domesticregid.ToList()[0].Domesticreg_Id;
                    //Provincia
                    DataAccess.Registrar_SET_ST_PROVINCE_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, 1, Convert.ToInt32(State_Prov_Id), paises_VM.Nombre_Prov, true, cod, Convert.ToInt32(CodPais), int.Parse(CodZona), Convert.ToInt32(CodSy), GetCurrentUserName());

                    Success(string.Format("Ha sido creada y/o modificada la Provincia <b>{0}</b> ", paises_VM.Nombre_Prov), true);
                    return RedirectToAction("Provincies");
                }
                else
                {

                    var Nombrepais = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);

                    var datos = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == paises_VM.Nombre_Pais.ToUpper());
                    var CodPais = datos.ToList()[0].Codigo;
                    var CodZona = Request["Zonas"];


                    var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                    var cod = Domesticregid.ToList()[0].Domesticreg_Id;
                    //Provincia
                    DataAccess.Registrar_SET_ST_PROVINCE_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, Convert.ToInt32(cod), Convert.ToInt32(null), paises_VM.Nombre_Prov, true, Convert.ToInt32(Session["Usuario"].ToString()), CodPais, int.Parse(CodZona), Convert.ToInt32(null), GetCurrentUserName());

                    Success(string.Format("Ha sido creada y/o modificada la Provincia <b>{0}</b> ", paises_VM.Nombre_Prov), true);
                    return RedirectToAction("Provincies");
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de crear registros"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        #region CIUDADES
        public ActionResult Ciudades()
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                dynamic model = new ExpandoObject();
                model.Ciudades = DataAccess.Mostrar_ciudades_x_Provincias();
                return View(model);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult CreateCities(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    var datos = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.City_Id == ID).ToList();
                    var paises = DataAccess.Mostrar_Pais();
                    var idPais = datos.ToList()[0].Country_Id;
                    var idProv = datos.ToList()[0].State_Prov_Id;
                    Paises_VM paises_VM = new Paises_VM();
                    paises_VM.Nombre_Ciudad = datos.ToList()[0].City_Desc;
                    ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc", idPais);

                    var provincias = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.Country_Id == idPais).ToList();
                    ViewBag.Provincias = new SelectList(provincias, "State_Prov_Id", "State_Prov_Desc", idProv);

                    return View(paises_VM);

                }
                else
                {
                    ViewBag.CurrentPage = "Localidades";
                    Llenar_Paises();
                    Llenar_Zonas();
                    return View();
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateCities(Paises_VM paises_VM)
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                Session["UserName"] = GetCurrentUserName();
                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();

                Session["Usuario"] = GetCurrentUserID();
                if (Session["Usuario"] == null)
                    Session.Add("Usuario", GetCurrentUserID());
                else
                    Session["Usuario"] = GetCurrentUserID();

                var Nombrepais = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);

                var datos = DataAccess.All_Provincias().Where(x => x.Descripcion == paises_VM.Nombre_Provincia).ToList();
                var CodProvinicia = datos.ToList()[0].Codigo;

                var datosz = DataAccess.All_Zonas().Where(x => x.Descripcion == paises_VM.Nombre_Zona);
                var CodPais = datosz.ToList()[0].CodPais;
                var CodZona = datosz.ToList()[0].Codigo;


                var State_Prov_Id = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.State_Prov_Id == paises_VM.Provincias);
                var stateProvId = State_Prov_Id.ToList()[0].State_Prov_Id;
                var Nombre_Prov = State_Prov_Id.ToList()[0].State_Prov_Desc;

                var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                var cod = Domesticregid.ToList()[0].Domesticreg_Id;
                //Ciudad
                DataAccess.Registrar_SET_ST_CITY_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, cod, stateProvId, Convert.ToInt32(null), paises_VM.Nombre_Ciudad, true, Convert.ToInt32(Session["Usuario"].ToString()), 
                    CodPais, CodZona, CodProvinicia, Convert.ToInt32(null), Session["UserName"].ToString(),Convert.ToInt32(null), Convert.ToInt32(null));

                var GetDataCity = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.City_Desc == paises_VM.Nombre_Ciudad.ToUpper()).ToList();
                var state_Prov_Id = GetDataCity[0].State_Prov_Id;
                var city_Id = GetDataCity[0].City_Id;
                var country_Id = GetDataCity[0].Country_Id;


                //INSERTO CIUDAD
                DataAccess.Registrar_SET_ST_CITY(country_Id, state_Prov_Id, city_Id);

                Success(string.Format("Ha sido creada y/o modificada la Ciudad <b>{0}</b>  en la provincia <b>{1}</b>", paises_VM.Nombre_Ciudad, Nombre_Prov), true);
                return RedirectToAction("Ciudades");
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de crear registros"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        #region SECTORES
        public ActionResult Sectores()
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                dynamic model = new ExpandoObject();
                model.Sector = DataAccess.GET_ALL_SECTOR();
                return View(model);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult CreateSectors(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    var datos = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.City_Id == ID).ToList();
                    var paises = DataAccess.Mostrar_Pais();
                    var idPais = datos.ToList()[0].Country_Id;
                    var idProv = datos.ToList()[0].State_Prov_Id;
                    Paises_VM paises_VM = new Paises_VM();
                    paises_VM.Nombre_Ciudad = datos.ToList()[0].City_Desc;
                    ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc", idPais);

                    var provincias = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.Country_Id == idPais).ToList();
                    ViewBag.Provincias = new SelectList(provincias, "State_Prov_Id", "State_Prov_Desc", idProv);

                    return View(paises_VM);

                }
                else
                {
                    ViewBag.CurrentPage = "Localidades";
                    Llenar_Paises();
                    Llenar_Zonas();
                    return View();
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateSectors(Paises_VM paises_VM)
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                Session["UserName"] = GetCurrentUserName();
                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();


                var Nombrepais = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises).ToList();
                var NomPais=Nombrepais[0].Global_Country_Desc;

                var datos = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == NomPais.ToUpper()).ToList();
                var CodProvinicia = datos.ToList()[0].Codigo;

                var datosz = DataAccess.All_Zonas().Where(x => x.Descripcion == paises_VM.Nombre_Zona);
                var CodPais = datosz.ToList()[0].CodPais;
                var CodZona = datosz.ToList()[0].Codigo;

                var datosm = DataAccess.All_Municipios().Where(x => x.Descripcion == paises_VM.Nombre_Municipio);
                var CodMunicipio = datosm.ToList()[0].Codigo;

                var State_Prov_Id = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.State_Prov_Id == paises_VM.Provincias);
                var stateProvId = State_Prov_Id.ToList()[0].State_Prov_Id;
                var Nombre_Prov = State_Prov_Id.ToList()[0].State_Prov_Desc;

                var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                var cod = Domesticregid.ToList()[0].Domesticreg_Id;

                //Sectores
                DataAccess.Registrar_SET_SECTORES_SYSFLEX(CodPais, CodZona, CodProvinicia, CodMunicipio, Convert.ToInt32(null), paises_VM.Nombre_Sector, Session["UserName"].ToString());

                Success(string.Format("Ha sido creado y/o modificado el Sector <b>{0}</b>  perteneciente a la provincia <b>{0}</b>", paises_VM.Nombre_Sector, Nombre_Prov), true);
                return RedirectToAction("Sectores");
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de crear registros"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        #region ZONAS
        [HttpGet]
        public ActionResult Zonas()
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";
                dynamic model = new ExpandoObject();
                model.Zonas = DataAccess.All_Zonas();
                return View(model);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult CreateZonas(int? ID)
        {
            try
            {
                if (ID != null)
                {
                    var datos = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.City_Id == ID).ToList();
                    var paises = DataAccess.Mostrar_Pais();
                    var idPais = datos.ToList()[0].Country_Id;
                    var idProv = datos.ToList()[0].State_Prov_Id;
                    Paises_VM paises_VM = new Paises_VM();
                    paises_VM.Nombre_Ciudad = datos.ToList()[0].City_Desc;
                    ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc", idPais);

                    var provincias = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.Country_Id == idPais).ToList();
                    ViewBag.Provincias = new SelectList(provincias, "State_Prov_Id", "State_Prov_Desc", idProv);

                    return View(paises_VM);

                }
                else
                {
                    ViewBag.CurrentPage = "Localidades";
                    Llenar_Paises();
                    return View();
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateZonas(Paises_VM paises_VM)
        {

            try
            {
                ViewBag.CurrentPage = "Localidades";

                Session["UserName"] = GetCurrentUserName();
                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();

                var Nombrepais = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == paises_VM.Nombre_Pais.ToUpper());
                var CodPais = Nombrepais.ToList()[0].Codigo;


                //Zonas
                DataAccess.Registrar_SET_ZONAS_SYSFLEX(CodPais, Convert.ToInt32(null), paises_VM.Nombre_Zona, Session["UserName"].ToString());

                Success(string.Format("Ha sido creado y/o modificado la Zona <b>{0}</b> ", paises_VM.Nombre_Zona), true);
                return RedirectToAction("Zonas", "Localidades");
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de crear registros"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        #region UBICACIONES
        //
        // GET: /Localidades/
        public ActionResult Index(int? ID)
        {
            try
            {
                ViewBag.CurrentPage = "Localidades";

                Session["UserName"] = GetCurrentUserName();
                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();

                dynamic model = new ExpandoObject();
                model.ALL_LOCATION = DataAccess.ALL_LOCATIONS();
                return View(model);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public ActionResult CreateUbicaciones()
        {
            try
            {
                Llenar_Paises();
                Llenar_Zonas();
                return View();
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de cargar Página"), true);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateUbicaciones(Paises_VM paises_VM)
        {

            try
            {
                if (paises_VM.Nombre_Ubicacion == null)
                {
                    Llenar_Paises();
                    return View();
                }
                else
                {
                    Session["UserName"] = GetCurrentUserName();
                    if (Session["UserName"] == null)
                        Session.Add("UserName", GetCurrentUserName());
                    else
                        Session["UserName"] = GetCurrentUserName();

                    ViewBag.CurrentPage = "Localidades";


                    var Nombrepais = DataAccess.All_PaisesSysFlex().Where(x => x.Descripcion == paises_VM.Nombre_Pais.ToUpper());
                    var CodPais = Nombrepais.ToList()[0].Codigo;

                    var Zona = Request["Zonas"];
                    var codMun = Session["codMun"].ToString();
                    var codS = Session["codS"].ToString();
                    var Datos = DataAccess.GET_ALL_SECTOR().Where(x => x.CodProvincia == int.Parse(codS)).ToList();
                    var CodSector = Datos[0].Codigo;
                    //Ubicacion
                    DataAccess.Registrar_SET_UBICACIONES_SYSFLEX(Convert.ToInt32(CodPais), int.Parse(Zona), int.Parse(codS), int.Parse(codMun), Convert.ToInt32(CodSector), Convert.ToInt32(null), paises_VM.Nombre_Ubicacion, Session["UserName"].ToString());
                    Success(string.Format("Ha sido creada y/o modificada la Ubicacion <b>{0}</b> ", paises_VM.Nombre_Ubicacion), true);
                    return RedirectToAction("Index", "Localidades");
                }
            }
            catch (Exception)
            {

                Danger(string.Format("Error Mostrando de crear registros"), true);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        public void Llenar_Paises()
        {
            var paises = DataAccess.Mostrar_Pais();
            ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc");
        }       
        public void Llenar_Zonas()
        {
            var zonas = DataAccess.All_Zonas();
            ViewBag.Zonas = new SelectList(zonas, "Codigo", "Descripcion");
        }
        [HttpPost]
        public JsonResult Llenar_Provincias_x_Ciudades(int Global_Country_Id)
        {

            try
            {
                var Datos = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.Country_Id == Global_Country_Id).ToList();
                Datos.Add(new Provincias { State_Prov_Id = 0, State_Prov_Desc = "<---Seleccione Provincia--->" });
                Datos = Datos.OrderBy(s => s.State_Prov_Desc).ToList();
                return Json(Datos);

            }
            catch (Exception)
            {
                
                throw;
            }

        }
        [HttpPost]
        public JsonResult Llenar_Ciudades_x_provincias(int CodProvincia)
        {
            try
            {
                var Datos = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.State_Prov_Id == CodProvincia).ToList();
                Datos.Add(new Ciudades { City_Id = 0, City_Desc = "<---Seleccione Ciudad--->" });
                Datos = Datos.OrderBy(s => s.State_Prov_Desc).ToList();
                var Nombre_Prov = Datos.ToList()[0].State_Prov_Desc;
                return Json(Datos);

            }
            catch (Exception)
            {
                
                throw;
            }

        }
        [HttpPost]
        public JsonResult Llenar_Sectores_x_Municipios(int CodProvincia)
        {
            try
            {
                var DatosC = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.City_Id == CodProvincia).ToList();

                var Nombre_Provincia = DatosC[0].State_Prov_Desc;

                var datosS = DataAccess.All_ProvinciasSysFlex().Where(x => x.Descripcion == Nombre_Provincia);
                var codS = datosS.ToList()[0].Codigo;
                Session["codS"] = codS;

                var datosM = DataAccess.All_Municipios().Where(x => x.CodProvincia == codS).ToList();
                var codMun = datosM[0].Codigo;
                Session["codMun"] = codMun;


                var Datos = DataAccess.GET_ALL_SECTOR().Where(x => (x.CodProvincia == codS) && (x.CodMunicipio == codMun)).ToList();
                Datos.Add(new Sector { Codigo = 0, Descripcion = "<---Seleccione Sector--->" });
                Datos = Datos.OrderBy(s => s.Descripcion).ToList();
                return Json(Datos);
            }
            catch (Exception)
            {
                
                throw;
            } 
        }
  
    }
}