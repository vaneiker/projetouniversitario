﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateTrustGlobal.Data;
using PagedList;
using StateTrustGlobal.ViewModels;
using MantModelosyMarcas.Models;
using System.Text;
using System.Dynamic;

namespace MantModelosyMarcas.Controllers
{
    public class MarcasModelosController : BaseController
    {
        private GlobalDbContext db = new GlobalDbContext();
        DataAccess DataAccess = new DataAccess();
        //
        // GET: /MarcasModelos/
        public ActionResult Index()
        {
            try
            {
                ViewBag.CurrentPage = "Index";
                Session["Usuario"] = GetCurrentUserID();
                Session["UserName"] = GetCurrentUserName();
                Session["Host"] = Request.ServerVariables["REMOTE_ADDR"];
                Session["Marca"] = null;
                Session["Edita"] = "0";

                if (Session["UserName"] == null)
                    Session.Add("UserName", GetCurrentUserName());
                else
                    Session["UserName"] = GetCurrentUserName();

                dynamic model = new ExpandoObject();
                model.Marcas = DataAccess.Mostrar_Marcas();
                return View(model);
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error al cargar las Marcas!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index", "Home");

            }
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

                marcas.Make_Id = MostrarDatos.ToList()[0].Make_Id;
                marcas.Make_Desc = MostrarDatos.ToList()[0].Make_Desc;
                marcas.Make_Status = MostrarDatos.ToList()[0].Make_Status;
                marcas.Pos_Flag = MostrarDatos.ToList()[0].Pos_Flag;
                


                var CodigoSysFlex = DataAccess.Consultar_Marcas_SysFlex(marcas.Make_Desc);
                if (CodigoSysFlex.Count() > 0)
                {
                    Session["Make_Codigo_SysFlex"] = CodigoSysFlex.ToList()[0].Codigo;
                }
                else
                {
                    Session["Make_Codigo_SysFlex"] = marcas.Make_Id;
                }

                marcas = new Marcas
                {
                    Make_Id = marcas.Make_Id,
                    Make_Desc = marcas.Make_Desc,
                    Make_Status = marcas.Make_Status,
                    Pos_Flag = marcas.Pos_Flag,

                };
                return PartialView(marcas);


            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error Cargando las Marcas para Editar!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        ///SE MODIFICA LA MARCA
        public ActionResult Edit(Marcas marcas)
        {
            var user = Convert.ToInt32(Session["Usuario"]);

            try
            {

                try
                {
                    var Usuario = Session["Usuario"].ToString();
                    var UserName = Session["UserName"].ToString();
                    var Host = System.Net.Dns.GetHostName();// Session["Host"].ToString();

                    int Cod = 0;

                    if (Session["Make_Codigo_SysFlex"] != null)
                    {
                        int.TryParse(Session["Make_Codigo_SysFlex"].ToString(), out Cod);
                    }


                    switch (marcas.Make_Status)
                    {
                        case "A":
                            DataAccess.Actualizar_Estatus_Marcas(0, marcas.Make_Desc, false, UserName, Host, 3, "A", user);

                            break;
                        case "I":
                            DataAccess.Actualizar_Estatus_Marcas(0, marcas.Make_Desc, false, UserName, Host, 3, "I", user);

                            break;
                    }
                    Success(string.Format("La Marca <b>{0}</b> ha sido Modificada ", marcas.Make_Desc), true);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    string errMessageTitle = string.Format("Error Editando la Marca!!!", "");
                    StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                    Danger(errMessageTitle, true);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error Cargando las Marcas para Edita!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }

        //AQUI SE CREA EL REGISTRO DE LOS MODELOS
        public ActionResult CreateModel(Modelos modelos, FormCollection form)
        {
            var user = Convert.ToInt32(Session["Usuario"]);
            try
            {
                if (modelos.NombreModelo == null)
                {
                   

                    modelos.Make_Id = Convert.ToInt32(Session["NoMarca"].ToString());
                    modelos.Make_Desc = Session["Marca"].ToString();

                    ModelosViews orderView = new ModelosViews();

                    var VersionVehiculo = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var Capacidad = DataAccess.ALL_Capacidad_Vehiculo().OrderBy(x => x.IdCapacidad).ToList();
                    var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().OrderBy(x => x.Descripcion).ToList();
                    orderView.TipoVehiculos = TipoVeh;
                    orderView.VersionVehiculos = VersionVehiculo;
                    orderView.CapacidadTipoVehiculo = Capacidad;
                    orderView.CategoriaVehiculos = CategoriaVeh;
                    return View(orderView);
                }
                else
                {
                    var ConsultaMarca = (from d in DataAccess.Mostrar_Modelos_x_Marcas().Where(x => (x.Make_Desc == Session["Marca"].ToString() && x.Model_desc == modelos.NombreModelo))
                                         select d).Count();
                    if (ConsultaMarca > 0)
                    {

                        Danger(string.Format("El Modelo Introduccido ya Existe en la Marca <b>{0}</b>!!!", Session["Marca"].ToString()), true);
                        return View("CreateModel", modelos);
                    }
                    else
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                //CATEGORIA VEHICULO
                                var cbkCategoriaVehiculo = form.AllKeys.Where(x => x.Contains("cbkCategoriaVehiculo_"));
                                foreach (var item in cbkCategoriaVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CategoriaVehiculo = valor[1].Trim();
                                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Codigo == int.Parse(CategoriaVehiculo)).ToList();
                                    Session["Recargo"] = CategoriaVeh[0].Codigo;
                                }

                                //TIPO VEHICULO
                                var cbkTipoVeh = form.AllKeys.Where(x => x.Contains("cbkTipoVehiculo_"));

                                foreach (var item in cbkTipoVeh)
                                {
                                    var valor = item.Split('_');
                                    var TipoVeh = valor[1].Trim();
                                    var id = DataAccess.Capacidad_Vehiculo(TipoVeh);
                                    Session["DescTipoVehiculo"] = id.ToList()[0].DescTipoVehiculo.ToUpper();
                                }
                                var Nombre_Marca = Session["Marca"].ToString();

                                var IdVehiculo = Session["DescTipoVehiculo"].ToString();

                                //if (IdVehiculo.IndexOf("AUTO PROPULSIÓN ") != -1)
                                //{
                                //    IdVehiculo = "AUTOPROPULSION"; //Esto es temporal hasta que se hagan los arreglos correspondientes a esta app
                                //}

                                var TipoVehiculoPos = DataAccess.Llenar_Tipo_Vehiculos().Where(x => x.Vehicle_Type_Desc == IdVehiculo);
                                var IDCODIGO = TipoVehiculoPos.ToList()[0].Vehicle_Type_Id;
                                
                                //insert
                                DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(IDCODIGO), Convert.ToInt32(Session["Recargo"].ToString()), "");

                                var ModeloSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Nombre_Marca).Max(x => x.Model_Id);

                                //ELIMINO TODOS LOS REGISTROS PARA INSERTARLOS NUEVAMENTE
                                DataAccess.Eliminar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex));

                                var UltimoModel = ModeloSysflex;

                                ///inserta en sysflex solamente
                                //TIPO VEHICULO
                                foreach (var item in cbkTipoVeh)
                                {
                                    var valor = item.Split('_');
                                    var TipoVeh = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, Convert.ToInt32(TipoVeh), 0, 0, "Tipo Vehiculo");
                                }

                                //VERSION VEHICULO
                                var cbkVersionVehiculo = form.AllKeys.Where(x => x.Contains("cbkVersionVehiculo_"));

                                foreach (var item in cbkVersionVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var Version = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), Convert.ToInt32(Version), 0, 0, 0, "Version Vehiculo");
                                }

                                //CAPACIDAD VEHICULO
                                var cbkCapacidadVehiculo = form.AllKeys.Where(x => x.Contains("cbkCapacidadVehiculo_"));

                                foreach (var item in cbkCapacidadVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CapacidadVehiculo = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, 0, Convert.ToInt32(CapacidadVehiculo), "Capacidad Vehiculo");
                                }

                                //CATEGORIA VEHICULO
                                foreach (var item in cbkCategoriaVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CategoriaVehiculo = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, Convert.ToInt32(CategoriaVehiculo), 0, "Categoria Vehiculo");
                                }

                                transaction.Commit();
                                
                                Success(string.Format("El Modelo <b>{0}</b> ha sido Registrado en la Marca <b>{1}</b>", modelos.NombreModelo, Session["Marca"].ToString()), true);

                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();

                                string errMessageTitle = string.Format("Error Mostrando los Modelos!!!", "");
                                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                                Danger(errMessageTitle, true);
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error Mostrando los Modelos!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Modelo(Modelos modelos, FormCollection form)
        {
            try
            {
                if (modelos.NombreModelo == null)
                {
                    ViewBag.Mostrar = false;

                    ModelosViews modeloView = new ModelosViews();

                    var VersionVehiculo = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var Capacidad = DataAccess.ALL_Capacidad_Vehiculo().OrderBy(x => x.IdCapacidad).ToList();
                    var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().OrderBy(x => x.Descripcion).ToList();

                    modeloView.TipoVehiculos = TipoVeh;
                    modeloView.VersionVehiculos = VersionVehiculo;
                    modeloView.CapacidadTipoVehiculo = Capacidad;
                    modeloView.CategoriaVehiculos = CategoriaVeh;
                    return View(modeloView);
                }
                else
                {
                    var ConsultaMarca = (from d in DataAccess.Mostrar_Modelos_x_Marcas().Where(x => (x.Make_Desc == modelos.Make_Desc && x.Model_desc == modelos.NombreModelo))
                                         select d).Count();
                    if (ConsultaMarca > 0)
                    {
                        Danger(string.Format("El Modelo  Introduccida ya Existe  en la Marca <b>{0}</b>!!!", Session["Marca"].ToString()), true);

                        return View("CreateModel", modelos);
                    }
                    else
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {

                            try
                            {

                                //CATEGORIA VEHICULO
                                var cbkCategoriaVehiculo = form.AllKeys.Where(x => x.Contains("cbkCategoriaVehiculo_"));
                                foreach (var item in cbkCategoriaVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CategoriaVehiculo = valor[1].Trim();
                                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Codigo == int.Parse(CategoriaVehiculo)).ToList();
                                    Session["Recargo"] = CategoriaVeh[0].Codigo;
                                }

                                //TIPO VEHICULO
                                var cbkTipoVeh = form.AllKeys.Where(x => x.Contains("cbkTipoVehiculo_"));

                                foreach (var item in cbkTipoVeh)
                                {
                                    var valor = item.Split('_');
                                    var TipoVeh = valor[1].Trim();
                                    var id = DataAccess.Capacidad_Vehiculo(TipoVeh);
                                    Session["DescTipoVehiculo"] = id.ToList()[0].DescTipoVehiculo.ToUpper();
                                }

                                var Nombre_Marca = modelos.Make_Desc;
                                var IdVehiculo = Session["DescTipoVehiculo"].ToString();
                                var TipoVehiculoPos = DataAccess.Llenar_Tipo_Vehiculos().Where(x => x.Vehicle_Type_Desc == IdVehiculo);
                                var IDCODIGO = TipoVehiculoPos.ToList()[0].Vehicle_Type_Id;

                                //insert
                                DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(IDCODIGO), Convert.ToInt32(Session["Recargo"].ToString()), "");

                                var ModeloSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Nombre_Marca).Max(x => x.Model_Id);

                                //ELIMINO TODOS LOS REGISTROS PARA INSERTARLOS NUEVAMENTE
                                DataAccess.Eliminar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex));

                                var UltimoModel = ModeloSysflex;

                                ///inserta en sysflex solamente
                                //TIPO VEHICULO

                                foreach (var item in cbkTipoVeh)
                                {
                                    var valor = item.Split('_');
                                    var TipoVeh = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, Convert.ToInt32(TipoVeh), 0, 0, "Tipo Vehiculo");

                                }

                                //VERSION VEHICULO
                                var cbkVersionVehiculo = form.AllKeys.Where(x => x.Contains("cbkVersionVehiculo_"));

                                foreach (var item in cbkVersionVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var Version = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), Convert.ToInt32(Version), 0, 0, 0, "Version Vehiculo");
                                }

                                //CAPACIDAD VEHICULO
                                var cbkCapacidadVehiculo = form.AllKeys.Where(x => x.Contains("cbkCapacidadVehiculo_"));

                                foreach (var item in cbkCapacidadVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CapacidadVehiculo = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, 0, Convert.ToInt32(CapacidadVehiculo), "Capacidad Vehiculo");
                                }
                                //CATEGORIA VEHICULO
                                foreach (var item in cbkCategoriaVehiculo)
                                {
                                    var valor = item.Split('_');
                                    var CategoriaVehiculo = valor[1].Trim();
                                    DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, Convert.ToInt32(CategoriaVehiculo), 0, "Categoria Vehiculo");
                                }

                                transaction.Commit();

                                Success(string.Format("El Modelo <b>{0}</b>  han sidos Registrado en la Marca <b>{1}</b>", modelos.NombreModelo, modelos.Make_Desc), true);
                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();

                                string errMessageTitle = string.Format("Error Mostrando los Modelos!!!", "");
                                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                                Danger(errMessageTitle, true);
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error Mostrando los Modelos!!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
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

                return View(ConsultaMarca);
            }
            catch (Exception ex)
            {
                string errMessageTitle = string.Format("Error Consultando los modleos por Marca!!", "");
                StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                Danger(errMessageTitle, true);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ModelCreate(Modelos modelos)
        {
            Session["NoMarca"].ToString();
            Session["Marca"].ToString();
            return View();
        }

        public ActionResult ModelEdit(int? ID, Modelos modelos, FormCollection form)
        {
            if (modelos.NombreModelo == null)
            {
                try
                {
                    ModelosViews modelosView = new ModelosViews();
                    var Make_id = Session["NoMarca"].ToString();
                    int ma = Convert.ToInt32(Make_id);
                    var Datos = DataAccess.Mostrar_Detalle_Modelos(Convert.ToInt32(Make_id), Convert.ToInt32(ID)).ToList();

                    var VersionAll = "";
                    var CapacidadAll = "";
                    var TipoVehAll = "";
                    var RecargoAll = "";
                    //version 
                    var version = Datos.Select(x => x.VersionVeh);
                    VersionAll = string.Join(",", version);
                    modelosView.Versiones = VersionAll;
                    //tipo vehiculo
                    var tipovehiculo = Datos.Select(x => x.DescTipoVehiculo);
                    TipoVehAll = string.Join(",", tipovehiculo);
                    modelosView.Tipo_Vehiculos = TipoVehAll;
                    //capacidad
                    var capacidad = Datos.Select(x => x.DescCapacidad);
                    CapacidadAll = string.Join(",", capacidad);
                    modelosView.Capacidad = CapacidadAll;
                    //recargo
                    var recargo = Datos.Select(x => x.Descripcion);
                    RecargoAll = string.Join(",", recargo);
                    modelosView.Recargo = RecargoAll;

                    var VersionVehiculo = DataAccess.SPCBuscaTipoCapacidadModelo("Versión Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var Capacidad = DataAccess.ALL_Capacidad_Vehiculo().OrderBy(x => x.IdCapacidad).ToList();
                    var TipoVeh = DataAccess.SPCBuscaTipoCapacidadModelo("Tipo Vehículo").OrderBy(x => x.DescIdioma).ToList();
                    var CategoriaVeh = DataAccess.Categoria_Vehiculos().OrderBy(x => x.Descripcion).ToList();
                    modelosView.TipoVehiculos = TipoVeh;
                    modelosView.VersionVehiculos = VersionVehiculo;
                    modelosView.CapacidadTipoVehiculo = Capacidad;
                    modelosView.CategoriaVehiculos = CategoriaVeh;
                    modelos.Pos_flag = Convert.ToBoolean(Datos.ToList()[0].Estatus);
                    modelos.NombreModelo = Datos.ToList()[0].DescModelo;
                    modelos.Make_Desc = Datos.ToList()[0].Make_Desc;
                    Session["Model_desc"] = Datos.ToList()[0].DescModelo;
                    modelosView.Modelos = modelos;
                    return View(modelosView);


                }
                catch (Exception ex)
                {
                    string errMessageTitle = string.Format("Error al momento de Mostrar los datos del modelo", "");
                    StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                    Danger(errMessageTitle, true);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                try
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            //CATEGORIA VEHICULO
                            var cbkCategoriaVehiculo = form.AllKeys.Where(x => x.Contains("cbkCategoriaVehiculo_"));
                            foreach (var item in cbkCategoriaVehiculo)
                            {
                                var valor = item.Split('_');
                                var CategoriaVehiculo = valor[1].Trim();
                                var CategoriaVeh = DataAccess.Categoria_Vehiculos().ToList().Where(x => x.Codigo == int.Parse(CategoriaVehiculo)).ToList();
                                Session["Recargo"] = CategoriaVeh[0].Codigo;
                            }

                            //TIPO VEHICULO
                            var cbkTipoVeh = form.AllKeys.Where(x => x.Contains("cbkTipoVehiculo_"));

                            foreach (var item in cbkTipoVeh)
                            {
                                var valor = item.Split('_');
                                var TipoVeh = valor[1].Trim();
                                var id = DataAccess.Capacidad_Vehiculo(TipoVeh);
                                Session["DescTipoVehiculo"] = id.ToList()[0].DescTipoVehiculo.ToUpper();
                            }

                            var Nombre_Marca = Session["Marca"].ToString();
                            if (Session["Marca"] == null)
                                Session.Add("Marca", Nombre_Marca);
                            else
                                Session["Marca"] = Nombre_Marca;

                            var IdVehiculo = Session["DescTipoVehiculo"].ToString();

                            //if (IdVehiculo.IndexOf("AUTO PROPULSIÓN ") != -1)
                            //{
                            //    IdVehiculo = "AUTOPROPULSION"; //Esto es temporal hasta que se hagan los arreglos correspondientes a esta app
                            //}


                            var TipoVehiculoPos = DataAccess.Llenar_Tipo_Vehiculos().Where(x => x.Vehicle_Type_Desc == IdVehiculo);
                            var IDCODIGO = TipoVehiculoPos.ToList()[0].Vehicle_Type_Id;

                            //insert
                            DataAccess.Registrar_Marcas_Modelos_All(Nombre_Marca, modelos.NombreModelo, Convert.ToInt32(IDCODIGO), Convert.ToInt32(Session["Recargo"].ToString()), Convert.ToString(modelos.Pos_flag));
                            

                            var ModeloSysflex = DataAccess.Consultar_Modelos_SysFlex(modelos.NombreModelo, Nombre_Marca).Max(x => x.Model_Id);

                            var UltimoModel = ModeloSysflex;

                            //ELIMINO TODOS LOS REGISTROS PARA INSERTARLOS NUEVAMENTE
                            DataAccess.Eliminar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex));


                            ///inserta en sysflex solamente
                            //TIPO VEHICULO
                            foreach (var item in cbkTipoVeh)
                            {
                                var valor = item.Split('_');
                                var TipoVeh = valor[1].Trim();
                                DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, Convert.ToInt32(TipoVeh), 0, 0, "Tipo Vehiculo");

                            }

                            //VERSION VEHICULO
                            var cbkVersionVehiculo = form.AllKeys.Where(x => x.Contains("cbkVersionVehiculo_"));

                            foreach (var item in cbkVersionVehiculo)
                            {
                                var valor = item.Split('_');
                                var Version = valor[1].Trim();
                                DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), Convert.ToInt32(Version), 0, 0, 0, "Version Vehiculo");
                            }

                            //CAPACIDAD VEHICULO
                            var cbkCapacidadVehiculo = form.AllKeys.Where(x => x.Contains("cbkCapacidadVehiculo_"));

                            foreach (var item in cbkCapacidadVehiculo)
                            {
                                var valor = item.Split('_');
                                var CapacidadVehiculo = valor[1].Trim();
                                DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, 0, Convert.ToInt32(CapacidadVehiculo), "Capacidad Vehiculo");
                            }

                            //CATEGORIA VEHICULO
                            foreach (var item in cbkCategoriaVehiculo)
                            {
                                var valor = item.Split('_');
                                var CategoriaVehiculo = valor[1].Trim();
                                DataAccess.Registrar_VERSION_CATEGORIA_TIPO(Convert.ToInt32(ModeloSysflex), 0, 0, Convert.ToInt32(CategoriaVehiculo), 0, "Categoria Vehiculo");
                            }

                            transaction.Commit();

                            Success(string.Format("El Modelo <b>{0}</b> han sido modificado en la Marca <b>{1}</b>", modelos.NombreModelo, Session["Marca"].ToString()), true);
                            return RedirectToAction("Index");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            string errMessageTitle = string.Format("Error al momento de modificar el modelo", "");
                            StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                            Danger(errMessageTitle, true);
                            return RedirectToAction("Index");
                        }
                    }

                }
                catch (Exception ex)
                {
                    string errMessageTitle = string.Format("Error al momento de modificar el modelo", "");
                    StateTrustGlobal.Helpers.LoggerHelper.Log(GetCurrentUserName(), "MarcasModelos", errMessageTitle, ex.Message, ex);

                    Danger(errMessageTitle, true);
                    return RedirectToAction("Index");
                }
            }
        }
    }
}