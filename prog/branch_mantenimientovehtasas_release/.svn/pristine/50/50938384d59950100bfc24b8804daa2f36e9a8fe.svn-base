using System;
using System.Linq;
using System.Web.Mvc;
using StateTrustGlobal.Data;
using StateTrustGlobal.ViewModels;
using System.Dynamic;

namespace VehiculosyMarcas.Controllers
{
    public class MarcasModelosController : BaseController
    {
        private GlobalDbContext db = new GlobalDbContext();
        DataAccess DataAccess = new DataAccess();
        //
        // GET: /MarcasModelos/
        public ActionResult Index(int? pageNumber, string Search)
        {
            try
            {
                ViewBag.CurrentPage = "Index";
                Session["Usuario"] = GetCurrentUserID();
                Session["UserName"] = GetCurrentUserName();
                Session["Host"] = Request.ServerVariables["REMOTE_ADDR"];
                Session["Marca"] = null;
                Session["Edita"]="0";

                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();
                dynamic model = new ExpandoObject();
                model.Marcas = DataAccess.Mostrar_Marcas().Take(50);
                return View(model);
                /*
                if (Search == null)
                {
                    if (Session["Edita"].ToString() == "Editar")
                    {
                        ViewBag.Mostrar = true;
                        var MostrarDatos = DataAccess.Mostrar_Marcas().ToList().ToPagedList(pageNumber ?? 1, 8);
                        return View(MostrarDatos);
                    }
                    else
                    {
                        ViewBag.Mostrar = false;
                        var MostrarDatos = DataAccess.Mostrar_Marcas().ToList().ToPagedList(pageNumber ?? 1, 8);
                        return View(MostrarDatos);
                    }
                }
                else
                {
                    ViewBag.Mostrar = false;
                    var MostrarDatos = DataAccess.Mostrar_Marcas(Search.ToUpper()).ToList().ToPagedList(pageNumber ?? 1, 8);
                    return View(MostrarDatos);
                }*/
            }
            catch (Exception)
            {
                Danger(string.Format("Error al cargar las Marcas!!!", ""), true);
                return RedirectToAction("Index", "Home");

            }
        }
        public JsonResult AutoCompleteCountry(string term)
        {
            var result = (from r in DataAccess.Mostrar_Marcas()
                          where r.Make_Desc.ToLower().Contains(term.ToLower())
                          select new { r.Make_Desc }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        ///SE MODIFICA LA MARCA
        public ActionResult Edit(int? ID, Marcas marcas)
        {

            try
            {
                ViewBag.Mostrar = true;
                Session["Edita"] = "Editar";
                var MostrarDatos = DataAccess.Mostrar_Marcas().ToList().Where(x => x.Make_Id == ID).ToList();
                //Marcas marcas = new Marcas();
                marcas.Make_Id = MostrarDatos.ToList()[0].Make_Id;
                marcas.Make_Desc = MostrarDatos.ToList()[0].Make_Desc;
                marcas.Make_Status = MostrarDatos.ToList()[0].Make_Status;
                marcas.Pos_Flag = MostrarDatos.ToList()[0].Pos_Flag;
                //marcas.Estatus = MostrarDatos.ToList()[0].Estatus;

                var CodigoSysFlex = DataAccess.Consultar_Marcas_SysFlex(marcas.Make_Desc);
                Session["Make_Codigo_SysFlex"] = CodigoSysFlex.ToList()[0].Codigo;

                marcas = new Marcas
                {
                    Make_Id = marcas.Make_Id,
                    Make_Desc = marcas.Make_Desc,
                    Make_Status = marcas.Make_Status,
                    Pos_Flag = marcas.Pos_Flag,
                   // Estatus = marcas.Estatus,
                };
                return View(marcas);


            }
            catch (Exception)
            {

                Danger(string.Format("Error Cargando las Marcas para Editar !!", ""), true);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        ///SE MODIFICA LA MARCA
        public ActionResult Edit(Marcas marcas)
        {
          
            try
            {
   
                try
                {
                    var Usuario = Session["Usuario"].ToString();
                    var UserName = Session["UserName"].ToString();
                    var Host = Session["Host"].ToString();


                   // DataAccess.Actualizar_Estatus_Marcas(Convert.ToInt32(marcas.Make_Id), marcas.Make_Desc, Convert.ToBoolean(marcas.Make_Status), Usuario, Host, 1, "", 0);

                  //  DataAccess.Actualizar_Estatus_Marcas(Convert.ToInt32(marcas.Make_Id), marcas.Make_Desc, Convert.ToBoolean(marcas.Make_Status), Usuario, Host, 2, "", 0);

                    //////Opcion uno para registrar en la base de datos SysFlexSeguros tabla dbo.P_MarcaVehiculo


                    int Cod = Convert.ToInt32(Session["Make_Codigo_SysFlex"].ToString());
                    switch (marcas.Make_Status)
                    {
                        case "A":
                          //  DataAccess.Actualizar_Estatus_Marcas(0, marcas.Make_Desc, false, UserName, Host, 3, "A", Cod);

                            break;
                        case "I":
                           // DataAccess.Actualizar_Estatus_Marcas(0, marcas.Make_Desc, false, UserName, Host, 3, "I", Cod);

                            break;
                    }
                    Success(string.Format("La Marca <b>{0}</b>  han sidos Modificada ", marcas.Make_Desc), true);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    Danger(string.Format("Error Editando la Marca  !!", ""), true);
                    return RedirectToAction("Index");
                } 
            }
            catch (Exception)
            {
                Danger(string.Format("Error Cargando las Marcas para Editar !!", ""), true);
                return RedirectToAction("Index");
            }
        }

        //AQUI SE CREA EL REGISTRO DE LOS MODELOS
        public ActionResult CreateModel(Modelos modelos)
        {
            try
            {
                if (modelos.NombreModelo == null)
                {

                    Llenar_Tipo_Vehiculos();
                    Llenar_CategoriaVeh();
                    Llenar_Version_Vehiculos();
                    modelos.Make_Id = Convert.ToInt32(Session["NoMarca"].ToString());
                    modelos.Make_Desc = Session["Marca"].ToString();
                    return View(modelos);
                }
                else
                {

                    var ConsultaMarca = (from d in DataAccess.Mostrar_Modelos_x_Marcas().Where(x => (x.Make_Desc == Session["Marca"].ToString() && x.Model_desc == modelos.NombreModelo))
                                         select d).Count();
                    if (ConsultaMarca > 0)
                    {

                        Danger(string.Format("El Modelo  Introduccida ya Existe  en la Marca <b>{0}</b>!!!", Session["Marca"].ToString()), true);
                        Llenar_Tipo_Vehiculos();
                        Llenar_CategoriaVeh();
                        Llenar_Version_Vehiculos();
                        return View("CreateModel", modelos);
                    }
                    else
                    {

                        var descripcion = Request["CategoriaVehiculos"];
                        var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Descripcion == descripcion).ToList();



                        var Vehicle_Type_Id = Request["TipoVehiculos"];

                        var Pos_Flag = Request["Pos_Flag"];

                        Session["Recargo"] = CategoriaVeh.ToList()[0].Recargo;


                        decimal Recargo = CategoriaVeh.ToList()[0].Recargo;


                        var Nombre_Marca = Session["Marca"].ToString();

                        var id = DataAccess.Capacidad_Vehiculo(Vehicle_Type_Id);

                        var IdVehiculo = id.ToList()[0].DescTipoVehiculo.ToUpper();
                        var TipoVehiculoPos = DataAccess.Llenar_Tipo_Vehiculos().Where(x => x.Vehicle_Type_Desc == IdVehiculo);
                        var IDCODIGO = TipoVehiculoPos.ToList()[0].Vehicle_Type_Id;
                        //insert
                        DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(IDCODIGO), Convert.ToInt32(CategoriaVeh.ToList()[0].Codigo));

                        var ModeloSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Nombre_Marca).Max(x => x.Model_Id);
                        var UltimoModel = ModeloSysflex;
                        var VersionId = Request["VersionVeh"];
                        var CapacidadId = Request["Capacidad"];
                        var capid = DataAccess.Capacidad_Vehiculo(Vehicle_Type_Id);
                        var idcap = capid.ToList()[0].IdCapacidad;
                        var VersionVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").Where(x => x.DescIdioma == VersionId);

                        var version = VersionVeh.ToList()[0].IdListaHeader;


                        ///inserta en sysflex solamente
                        DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), Convert.ToInt32(version), Convert.ToInt32(Vehicle_Type_Id), Convert.ToInt32(Vehicle_Type_Id), Convert.ToInt32(idcap));
                        Success(string.Format("El Modelo <b>{0}</b>  han sidos Registrado en la Marca <b>{1}</b>", modelos.NombreModelo, Session["Marca"].ToString()), true);
                        return RedirectToAction("Index");
                    }
                }
            }


            catch (Exception)
            {

                Danger(string.Format("Error Mostrando los Modelos !!", ""), true);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Modelo(Modelos modelos)
        {
            try
            {
                if (modelos.NombreModelo == null)
                {
                    ViewBag.Mostrar = false;
                    Llenar_Tipo_Vehiculos();
                    Llenar_CategoriaVeh();


                    return View();
                }
                else
                {

                    var ConsultaMarca = (from d in DataAccess.Mostrar_Modelos_x_Marcas().Where(x => (x.Make_Desc == modelos.Make_Desc && x.Model_desc == modelos.NombreModelo))
                                         select d).Count();
                    if (ConsultaMarca > 0)
                    {

                        Danger(string.Format("El Modelo  Introduccida ya Existe  en la Marca <b>{0}</b>!!!", Session["Marca"].ToString()), true);
                        Llenar_Tipo_Vehiculos();
                        Llenar_CategoriaVeh();
                        return View("CreateModel", modelos);
                    }
                    else
                    {
                        var descripcion = Request["CategoriaVehiculos"];
                        var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Descripcion == descripcion).ToList();



                        var Vehicle_Type_Id = Request["TipoVehiculos"];

                        var Pos_Flag = Request["Pos_Flag"];

                        Session["Recargo"] = CategoriaVeh.ToList()[0].Recargo;


                        decimal Recargo = CategoriaVeh.ToList()[0].Recargo;


                        var Nombre_Marca = modelos.Make_Desc;

                        DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(Vehicle_Type_Id), Convert.ToInt32(CategoriaVeh.ToList()[0].Codigo));

                        Success(string.Format("El Modelo <b>{0}</b>  han sidos Registrado en la Marca <b>{1}</b>", modelos.NombreModelo, modelos.Make_Desc), true);
                        return RedirectToAction("Index");

                    }
                }
            }

            catch (Exception)
            {

                Danger(string.Format("Error Mostrando los Modelos !!", ""), true);
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// muestro la vista de los modelos de acuerdo a la marca
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult ModelCreate(int? ID)
        {

            try
            {
    
                var MarcaID = DataAccess.Mostrar_Marcas().Where(a => a.Make_Id == ID).ToList();
                Session["NoMarca"] = MarcaID.ToList()[0].Make_Id;
                Session["Marca"] = MarcaID.ToList()[0].Make_Desc;

                var ConsultaMarca = DataAccess.Mostrar_Detalle_Modelos(Convert.ToInt32(MarcaID.ToList()[0].Make_Id));
              
                ////Llenar_Tipo_Vehiculos();
                ////Llenar_CategoriaVeh();
                //Llenar_Version_Vehiculos();
         
                return View(ConsultaMarca);
            }
            catch (Exception)
            {

                Danger(string.Format("Error Consultando los modleos por Marca  !!", ""), true);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]

        public ActionResult ModelCreate(Modelos modelos)
        {
            return View();
        }

        public void Llenar_Tipo_Vehiculos()
        {
            var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").ToList();
            ViewBag.TipoVehiculos = new SelectList(TipoVeh, "IdListaHeader", "DescIdioma");
        }

        public void Llenar_Version_Vehiculos()
        {
            var VersionVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").ToList();
            ViewBag.VersionVeh = new SelectList(VersionVeh, "DescIdioma", "DescIdioma");
        }
     
        public void Llenar_CategoriaVeh()
        {
            var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList();
            ViewBag.CategoriaVehiculos = new SelectList(CategoriaVeh, "Descripcion", "Descripcion");
        }
        public void Mostrar_Capacidad_TipoVehiculo1(string IDTipoVehiculos, string Vehiculo)
        {
            var Make_Id = Convert.ToInt32(Session["NoMarca"].ToString());
            var Datos = from AD in DataAccess.Capacidad_Vehiculo(/*Make_Id, */IDTipoVehiculos).ToList()
                        select new
                        {
                            AD.DescCapacidad,
                            AD.IdTipoVehiculo
                        };
            ViewBag.Capacidad = new SelectList(Datos, "IdTipoVehiculo", "DescCapacidad", Vehiculo);
            
        }
        public void Mostrar_Capacidad_TipoVehiculo1(string IDTipoVehiculos)
        {
            var Make_Id = Convert.ToInt32(Session["NoMarca"].ToString());
            var Datos = from AD in DataAccess.Capacidad_Vehiculo(/*Make_Id, */IDTipoVehiculos).ToList()
                        select new
                        {
                            AD.DescCapacidad,
                            AD.IdTipoVehiculo
                        };
            ViewBag.Capacidad = new SelectList(Datos, "IdTipoVehiculo", "DescCapacidad");

        }
        public ActionResult ModelEdit(int? ID, Modelos modelos, string IdCapacidad)
        {
            if (modelos.NombreModelo == null)
            {
                try
                {
                    var Make_id = Session["NoMarca"].ToString();
                    int ma = Convert.ToInt32(Make_id);
                    var Datos = DataAccess.Mostrar_Detalle_Modelos(Convert.ToInt32(Make_id), Convert.ToInt32(ID));
                    //Modelos modelos = new Modelos();
                    modelos = new Modelos();
                    modelos.NombreModelo = Datos.ToList()[0].DescModelo;
                    //modelos.Descripcion = Datos.ToList()[0].Descripcion;
                    modelos.Vehicle_Type_Desc = Datos.ToList()[0].DescTipoVehiculo;
                    modelos.Vehicle_Type_Id = Datos.ToList()[0].IdTipoVehiculo;
                    modelos.Pos_flag = Convert.ToBoolean(Datos.ToList()[0].Estatus);
                    modelos.IdTipoVehiculo = Datos.ToList()[0].IdTipoVehiculo;
                    modelos.Model_Id = Datos.ToList()[0].Modelo;
                    Session["Model_desc"] = Datos.ToList()[0].DescModelo;


                    var DatoSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Session["Marca"].ToString());


                    var modelosSysflex = new Modelos();

                    //var Get_Version_Veh = DataAccess.GET_VERSION_VEHICULO(DatoSysflex.ToList()[0].Make_Id, DatoSysflex.ToList()[0].Model_Id);
                    var Get_Version_Veh = DataAccess.Mostrar_Detalle_Modelos(Convert.ToInt32(Make_id), Convert.ToInt32(modelos.Model_Id));
                    if (Get_Version_Veh.ToList().Count > 0)
                    {
                        //string IdVersion = Get_Version_Veh.Rows[0]["Descripcion"].ToString();
                        string IdVersion = Get_Version_Veh.ToList()[0].VersionVeh;
                        var VersionVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").ToList();
                        ViewBag.VersionVeh = new SelectList(VersionVeh, "DescIdioma", "DescIdioma", IdVersion);
                    }
                    else
                    {
                        var VersionVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").ToList();
                        ViewBag.VersionVeh = new SelectList(VersionVeh, "DescIdioma", "DescIdioma");
                    }

                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList();
                    ViewBag.CategoriaVehiculos = new SelectList(CategoriaVeh, "Descripcion", "Descripcion", modelos.Descripcion);

                    //var Get_Tipo_Veh = DataAccess.GET_TIPO_VEHICULO(DatoSysflex.ToList()[0].Make_Id, DatoSysflex.ToList()[0].Model_Id);
                    var Get_Tipo_Veh = DataAccess.Mostrar_Detalle_Modelos(Convert.ToInt32(Make_id), Convert.ToInt32(modelos.Model_Id));
                    if (Get_Tipo_Veh.ToList().Count > 0)
                    {
                        //var IdTipo = Get_Tipo_Veh.Rows[0]["Descripcion"].ToString();
                        var IdTipo = Get_Tipo_Veh.ToList()[0].DescTipoVehiculo;
                        var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").ToList();
                        ViewBag.TipoVehiculos = new SelectList(TipoVeh, "DescIdioma", "DescIdioma", IdTipo);
                      

                        //var capid = DataAccess.Capacidad_Vehiculo(Convert.ToString(Get_Tipo_Veh.ToList()[0].IdTipoVehiculo)).Where(x=>x.IdTipoVehiculo==modelos.IdTipoVehiculo);
                        var capid = DataAccess.Capacidad_Vehiculo(Convert.ToString(Get_Tipo_Veh.ToList()[0].IdTipoVehiculo)).ToList();
                        //var idcap = Get_Version_Veh.ToList()[0].DescCapacidad;
                        var idcap = Get_Version_Veh.ToList()[0].IdCapacidad;
                        ViewBag.Capacidad = new SelectList(capid, "IdTipoVehiculo", "DescCapacidad", idcap);
                    }
                    else
                    {
                        var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").ToList();
                        ViewBag.TipoVehiculos = new SelectList(TipoVeh, "DescIdioma", "DescIdioma");
                        Mostrar_Capacidad_TipoVehiculo1("TipoVeh");
                    }

                    return View(modelos);
                }
                catch (Exception)
                {
                    Danger(string.Format("Error al momento de Mostrar los datos del modelo", ""), true);
                    return RedirectToAction("Index");
                }
            }
            else
            {

                try
                {
                    var descripcion = Request["CategoriaVehiculos"];
                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Descripcion == descripcion).ToList();

                    var Nombre_Marca = Session["Marca"].ToString();


                    var Vehicle_Type_Id = Request["TipoVehiculos"];

                    var GetId = DataAccess.GET_ID_VEHICULO(Vehicle_Type_Id).ToList();
                    var id = DataAccess.Capacidad_Vehiculo(Vehicle_Type_Id);

                    var IdVehiculo = id.ToList()[0].DescTipoVehiculo.ToUpper();
                    var TipoVehiculoPos = DataAccess.Llenar_Tipo_Vehiculos(IdVehiculo);
                    var IDCODIGO = TipoVehiculoPos.ToList()[0].Vehicle_Type_Id;

                    //Registro 
                    //DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(GetId.ToList()[0].IdListaHeader), Convert.ToInt32(CategoriaVeh.ToList()[0].Codigo));

                    DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(IDCODIGO), Convert.ToInt32(CategoriaVeh.ToList()[0].Codigo));

                    var ModeloSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Nombre_Marca).Max(x => x.Model_Id);
                    var UltimoModel = ModeloSysflex;
                    var VersionId = Request["VersionVeh"];
                    
                    var CapacidadId = Request["Capacidad"];
                    var a = ViewBag.Number;

                    var capid = DataAccess.GET_ID_VEHICULO(modelos.capacidad1);
                    var idcap = capid.ToList()[0].IdListaHeader;

                    var VersionVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").Where(x => x.DescIdioma == VersionId);

                    var version = VersionVeh.ToList()[0].IdListaHeader;

                   var vehicle_Type_Id = DataAccess.GET_ID_VEHICULO(Vehicle_Type_Id).ToList();
                   var codVeh = vehicle_Type_Id.ToList()[0].IdListaHeader;
                    ///inserta en sysflex solamente
                   DataAccess.Modificar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), Convert.ToInt32(version), Convert.ToInt32(codVeh), Convert.ToInt32(codVeh), Convert.ToInt32(idcap));
                

                    Success(string.Format("El Modelo <b>{0}</b> han sido modificado en la Marca <b>{1}</b>", modelos.NombreModelo, Session["Marca"].ToString()), true);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    Danger(string.Format("Error al momento de modificar el modelo", ""), true);
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public JsonResult Mostrar_Capacidad_TipoVehiculo(string IDTipoVehiculos)
        {
            
                var Make_Id = Convert.ToInt32(Session["NoMarca"].ToString());
                var Datos = DataAccess.Capacidad_Vehiculo(/*Make_Id, */IDTipoVehiculos).ToList();
                Datos.Add(new CapacidadTipoVehiculo { IdTipoVehiculo = 0, DescCapacidad = "<---Seleccione Capacidad--->" });
                Datos = Datos.OrderBy(s => s.DescCapacidad).ToList();
                return Json(Datos);
            
             
        }
    }
}