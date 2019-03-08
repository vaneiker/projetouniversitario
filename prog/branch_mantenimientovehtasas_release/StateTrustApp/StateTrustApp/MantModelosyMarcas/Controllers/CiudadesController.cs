using StateTrustGlobal.Data;
using StateTrustGlobal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Dynamic;
namespace MantModelosyMarcas.Controllers
{
    public class CiudadesController : BaseController
    {
        DataAccess DataAccess = new DataAccess();
        //
        // GET: /Ciudades/

        public ActionResult Indexs(int? pageNumber, string Search)
        {

            ViewBag.CurrentPage = "Localidades";

            var Datos = DataAccess.ALL_LOCATIONS().ToList().ToPagedList(pageNumber ?? 1, 8);
            return View(Datos);
        }


        public ActionResult AllMantenimientos()
        {
            ViewBag.CurrentPage = "Localidades";
            dynamic model = new ExpandoObject();
            model.Sector = DataAccess.GET_ALL_SECTOR();
            model.Pais = DataAccess.Mostrar_Pais();
            model.Ciudades = DataAccess.Mostrar_ciudades_x_Provincias();
            model.ALL_LOCATION = DataAccess.ALL_LOCATIONS();
            return View(model);
        }

        public ActionResult Index(Paises_VM paises_VM)
        {
            ViewBag.CurrentPage = "Localidades";
            Session["Usuario"] = GetCurrentUserID();
            Session["UserName"] = GetCurrentUserName();
      

            if (paises_VM.Nombre_Pais == null)
            {
                Llenar_Paises();
      
                   return View();

            }
            else
            {

                var datos = DataAccess.Mostrar_GET_LOCALIDADES_SYSFLEX().Where(x => (x.PAIS == paises_VM.Nombre_Pais) && (x.PROVINCIA == paises_VM.Nombre_Sector));
                var CodPais = datos.ToList()[0].CODPAIS;
                var CodZona = datos.ToList()[0].CODZONA;
                var CodProvinicia = datos.ToList()[0].CODPROV;

                var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                var cod = Domesticregid.ToList()[0].Domesticreg_Id;
                DataAccess.Registrar_SET_ST_PROVINCE_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, 1, paises_VM.Provincias, paises_VM.Nombre_Sector, true, cod, CodPais, CodZona, CodProvinicia, Session["UserName"].ToString());
                Llenar_Paises();
                Success(string.Format("Fue creada la Provincia {0} en   perteneciente a la zona  ", DataAccess.MsgSql), true);
                return View();
            }
        }

        public void Llenar_Paises()
        {
            var paises = DataAccess.Mostrar_Pais();
            ViewBag.Paises = new SelectList(paises, "Global_Country_Id", "Global_Country_Desc");
        }

  
        [HttpPost]
        public JsonResult Llenar_Provincias_x_Ciudades(int Global_Country_Id)
        {

            var Datos = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.Country_Id == Global_Country_Id).ToList();
            Datos.Add(new Provincias { State_Prov_Id = 0, State_Prov_Desc = "<---Seleccione Provincia--->" });
            Datos = Datos.OrderBy(s => s.State_Prov_Desc).ToList();
            return Json(Datos);
        

        }
        [HttpPost]
        public JsonResult Llenar_Ciudades_x_Provincias(int State_Prov_Id)
        {

            var Datos = DataAccess.Mostrar_ciudades_x_Provincias().Where(x => x.State_Prov_Id == State_Prov_Id).ToList();
            Datos.Add(new Ciudades { City_Id = 0, City_Desc = "<---Seleccione Ciudad--->" });
            Datos = Datos.OrderBy(s => s.City_Desc).ToList();
            return Json(Datos);

        }

        public ActionResult Cities()
        {
            return View();
        }
        public ActionResult AllTabs()
        {
            return View();
        }
        public ActionResult Zonas(Paises_VM paises_VM)
        {
            ViewBag.CurrentPage = "Localidades";
            if (paises_VM.Nombre_Zona == null)
            {

                Llenar_Paises();
                return View();
            }
            else
            {
                var datos = DataAccess.Mostrar_GET_LOCALIDADES_SYSFLEX().Where(x => (x.PAIS == paises_VM.Nombre_Pais.ToUpper())).ToList();
                var CodPais = datos.ToList()[0].CODPAIS;
                var CodZona = datos.ToList()[0].CODZONA;
                var CodProvinicia = datos.ToList()[0].CODPROV;

                DataAccess.Registrar_SET_ZONAS_SYSFLEX(CodPais, Convert.ToInt32(null), paises_VM.Nombre_Zona, Session["UserName"].ToString());
                Success(string.Format("Fue creada la Provincia {0} en   perteneciente a la zona  ", DataAccess.MsgSql), true);
                return RedirectToAction("AllMantenimientos");
            }
        }
        
        public ActionResult CreateProvincias(Paises_VM paises_VM)
        {
            ViewBag.CurrentPage = "Localidades";
            if (paises_VM.Nombre_Sector == null)
            {

                Llenar_Paises();
                return View();
            }
            else
            {
                var datos = DataAccess.Mostrar_GET_LOCALIDADES_SYSFLEX().Where(x => (x.PAIS == paises_VM.Nombre_Pais.ToUpper())).ToList();
                var CodPais = datos.ToList()[0].CODPAIS;
                var CodZona = datos.ToList()[0].CODZONA;
                var CodProvinicia = datos.ToList()[0].CODPROV;

                var Domesticregid = DataAccess.Mostrar_Pais().Where(x => x.Global_Country_Id == paises_VM.Paises);
                var cod = Domesticregid.ToList()[0].Domesticreg_Id;
                //Provincia
                DataAccess.Registrar_SET_ST_PROVINCE_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, 1, Convert.ToInt32(null), paises_VM.Nombre_Prov, true, cod, CodPais, CodZona, Convert.ToInt32(null), "Ramartinez");

                var State_Prov_Id = DataAccess.Mostrar_Provincias_x_Pais().Where(x => x.State_Prov_Desc == paises_VM.Nombre_Prov.ToUpper());
                var stateProvId = State_Prov_Id.ToList()[0].State_Prov_Id;

                var datos1 = DataAccess.Mostrar_GET_LOCALIDADES_SYSFLEX().Where(x => (x.PAIS == paises_VM.Nombre_Pais.ToUpper())).ToList();
                var CodPais1 = datos.ToList()[0].CODPAIS;
                var CodZona1 = datos.ToList()[0].CODZONA;
                var CodProvinicia1 = datos.ToList()[0].CODPROV;
                var CodMunicipio1 = datos.ToList()[0].CODMUNICIPIO;
                //Ciudad
                DataAccess.Registrar_SET_ST_CITY_GLOBAL_POS_SITE_POS_SITE_ATL_SYSFLEX(paises_VM.Paises, cod, stateProvId, Convert.ToInt32(null), paises_VM.Nombre_Sector, true, Convert.ToInt32(GetCurrentUserID()), CodPais1, CodZona1, CodProvinicia1, Convert.ToInt32(null), "Ramartinez",0,0);

                //Sectores
                DataAccess.Registrar_SET_SECTORES_SYSFLEX(CodPais1, CodZona1, CodProvinicia1, CodMunicipio1, Convert.ToInt32(null), paises_VM.Nombre_Sector, GetCurrentUserName());

                var sector = DataAccess.GET_ALL_SECTOR().Where(x => x.Descripcion == paises_VM.Nombre_Sector).ToList();
                var CodSector = sector.ToList()[0].Codigo;

                //Ubicacion
                DataAccess.Registrar_SET_UBICACIONES_SYSFLEX(CodPais1, CodZona1, CodProvinicia1, CodMunicipio1, CodSector, Convert.ToInt32(null), paises_VM.Nombre_Ubicacion, "Ramartinez");




                Llenar_Paises();
                Success(string.Format("Fue creada la Provincia {0} en   perteneciente a la zona  ", DataAccess.MsgSql), true);
                return View();
            }
           
        }
	}
}