﻿using Entity.Entities;
using Newtonsoft.Json;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using STL.POS.WsProxy.SysflexService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public partial class InclusionController : BaseController
    {

        public class ServiceSelected
        {
            public string CoverageType { get; set; }
            public int Id { get; set; }
            public bool IsSelected { get; set; }
            public int CoverageDetailCoreId { get; set; }
            public string Name { get; set; }
            public double Amount { get; set; }
            public int MinDeductible { get; set; }
            public object SelfDamagesToProductLimits { get; set; }
            public object ThirdPartyToProductLimits { get; set; }
            public int ServiceType_Id { get; set; }
            public double Limit { get; set; }
            public int UserId { get; set; }
            public int Deductible { get; set; }
            public int vehilceID { get; set; }
            public object Action { get; set; }
            public int EntityId { get; set; }
        }

        public class Plan
        {
            public int Id { get; set; }
            public string UsoDescripcion { get; set; }
            public string ProductoDescripcion { get; set; }
        }
        public class VehicleData
        {
            public int makeId { get; set; }
            public int modelId { get; set; }
            public int Year { get; set; }
            public string TypeId { get; set; }
            public string TypeIdDesc { get; set; }
            public int PrincipalUsageId { get; set; }
            public string PrincipalUsageDesc { get; set; }
            public int StorageId { get; set; }
            public decimal VehicleValue { get; set; }
            public string VehicleYearsOld { get; set; }
            public string storeName { get; set; }
            public string vehicleDescription { get; set; }
            public string vehicleMakeName { get; set; }
            public string vehicleModelName { get; set; }
            public int SecuenciaSysFlex { get; set; }
            public int VehicleId { get; set; }
            public int VehicleQuantity { get; set; }
            public IEnumerable<ServiceSelected> serviceSelected { get; set; }

            public Nullable<int> SelectedVehicleFuelTypeId { get; set; }
            public string SelectedVehicleFuelTypeDesc { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int IdCapacidad { get; set; }
            public string DescCapacidad { get; set; }
            public string IdUso { get; set; }
            public string DescUso { get; set; }
        }

        public class DataCoverage
        {
            public int makeId { get; set; }
            public int modelId { get; set; }
            public decimal VehicleValue { get; set; }
            public string VechicleDesc { get; set; }
            public List<Plan> planData { get; set; }
            public List<Product> Products { get; set; }
            public VehicleData vehicleData { get; set; }
            public string SelectedProductName { get; set; }
            public string SelectedCoverageName { get; set; }
            public string SelectedDeductibleName { get; set; }
            public string divId { get; set; }
            public bool? IsEditing { get; set; }
        }

        public class itemServicesSelected
        {
            public string CoverageGroupName { get; set; }
            public int CoverageDetailCoreId { get; set; }
            public bool isSelected { get; set; }
        }

        public JsonResult DeleteVehicleOnSysflexInclusion(int SecuenciaVehicleSysflex, decimal quotationCoreNumber, int vehicleId)
        {
            try
            {
                int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();

                //borrando en sysflex
                oCoreProxy.DeleteVehicleOnSysflex(cod_company, SecuenciaVehicleSysflex, quotationCoreNumber);

                //borrando en possite
                oVehicleProductManager.DeleteVehicleProductCoveragesServices(vehicleId, true);

                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "POS-VentaDirecta"), -1, "Error al BORRAR el vehiculo en sysflex/Punto de venta.", "Detalle: Cotizacion id Sysflex: " + quotationCoreNumber + " MENSAJE: " + ex.Message + " StackTrace: " + ex.StackTrace, ex);
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SetAdditionalServicesCheckMark(string jsonDataServices, string SelectedServices)
        {
            var oListitemServicesSelected = Utility.deserializeJSON<IEnumerable<itemServicesSelected>>(SelectedServices);
            var DataServices = Utility.deserializeJSON<List<Entity.Entities.WSEntities.ServiceTypeWS>>(jsonDataServices);
            foreach (var item in oListitemServicesSelected)
            {
                var itemDataService = DataServices.FirstOrDefault(i => i.Name == item.CoverageGroupName);
                if (itemDataService != null)
                {
                    var itemCoverage = itemDataService.Coverages.FirstOrDefault(c => c.CoverageDetailCoreId == item.CoverageDetailCoreId);
                    if (itemCoverage != null)
                        itemCoverage.IsSelected = item.isSelected;
                }
            }

            return
                 Json(DataServices, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _AdditionalServices(string jsonDataServices)
        {
            var DataServices = Utility.deserializeJSON<List<Entity.Entities.WSEntities.ServiceTypeWS>>(jsonDataServices);
            ViewBag.Services = jsonDataServices;
            return
                  PartialView(DataServices);
        }

        //
        // GET: /Inclusion/
        public ActionResult Inclusion(String Title, bool isFromHistory)
        {
            IsAQuotation = false;

            if (!isFromHistory)
                this.QuotationId = 0;

            if (string.IsNullOrEmpty(Title))
            {
                Title = "INCLUSIONES";
            }

            if (Title == "INCLUSIONES")
            {
                base.RequestType = CommonEnums.RequestType.Inclusion;
            }
            else if (Title == "EXCLUSIONES")
            {
                base.RequestType = CommonEnums.RequestType.Exclusion;
            }
            else if (Title == "CAMBIOS")
            {
                base.RequestType = CommonEnums.RequestType.Cambios;
            }

            base.onlyLoggedUsers = allowOnlyLoggedUsers();
            ViewBag.onlyLoggedUsers = onlyLoggedUsers;

            var LoadQuotation = this.QuotationId > 0;
            ViewBag.QuotationIdFromEdit = 0;
            ViewBag.IntermediarioIdFromEdit = 0;
            ViewBag.PolicyMainFromEdit = "";
            ViewBag.CustomerDataInclusionFromEdit = "";
            ViewBag.SearchIsVisible = true;

            //Cargar la cotizacion para editarla
            if (LoadQuotation)
            {
                ViewBag.QuotationIdFromEdit = this.QuotationId;
                var dataQuotation = getQuotationData(this.QuotationId);
                base.QuotationNumber = dataQuotation.QuotationNumber;
                ViewBag.IntermediarioIdFromEdit = dataQuotation.User_Id;
                ViewBag.PolicyMainFromEdit = dataQuotation.policyNoMain;

                string title = "INCLUSIONES";

                if (base.RequestType == CommonEnums.RequestType.Exclusion)
                {
                    title = "EXCLUSIONES";
                }
                else if (base.RequestType == CommonEnums.RequestType.Cambios)
                {
                    title = "CAMBIOS";
                }

                //string title = (base.RequestType == CommonEnums.RequestType.Exclusion) ? "EXCLUSIONES" : "INCLUSIONES";

                ViewBag.CustomerDataInclusionFromEdit = GetDataCustomerFromPolicy("", dataQuotation.policyNoMain, title);
                ViewBag.SearchIsVisible = false;
            }

            ViewBag.Title = Title;
            ViewBag.CoreQuotationNumber = base.CoreQuotationNumber;
            VehicleNumber = 0;
            GetViewBag();

            Colors = oDropDownManager.GetDropDown("COLORS").Select(c => new SelectListItem
            {
                Text = c.name,
                Value = c.name
            });

            ViewBag.Colors = Colors;

            return
                PartialView("_Inclusion");
        }

        public ActionResult getCoverage(DataCoverage data)
        {
            VehicleNumber = data.vehicleData.SecuenciaSysFlex;
            ViewBag.UsageFilterPlan = Utility.serializeToJSON(data.planData);
            ViewBag.SecuenciaSysFlex = VehicleNumber;
            ViewBag.VehicleNumber = VehicleNumber;
            ViewBag.dvVehicleId = string.Format("dvVehicle{0}", ViewBag.VehicleNumber);
            data.divId = ViewBag.dvVehicleId;
            ViewBag.VehicleId = data.vehicleData.VehicleId;
            ViewBag.IsEditing = data.IsEditing.HasValue ? data.IsEditing : false;

            if (base.SecuenciaVehicleInclusion.HasValue)
                base.SecuenciaVehicleInclusion++;
            else
                base.SecuenciaVehicleInclusion = 1;

            ViewBag.SecuenciaVehicleInclusion = base.SecuenciaVehicleInclusion;

            var Products = data.Products;

            var ListItems = (from a in Products
                             join b in data.planData
                             on a.Name equals b.ProductoDescripcion
                             select new
                             {
                                 Value = a.Id.ToString(),
                                 Text = b.ProductoDescripcion,
                             }).ToList();

            var dataPlanData = ListItems.Distinct().ToList();
            dataPlanData.Insert(0, new { Value = "", Text = "Seleccione" });

            var itemsPlanData = new List<SelectListItem>(0);
            foreach (var item in dataPlanData)
                itemsPlanData.Add(new SelectListItem { Text = item.Text, Value = item.Value });

            ViewBag.plaData = itemsPlanData;
            ViewBag.vehicleData = Utility.serializeToJSON(data.vehicleData);
            ViewBag.VehicleQuantity = data.vehicleData.VehicleQuantity == 0 ? 1 : data.vehicleData.VehicleQuantity;
            ViewBag.ServiceSelected = data.vehicleData.serviceSelected != null ? Utility.serializeToJSON(data.vehicleData.serviceSelected) : "";

            var itemsSurchargeData = new List<SelectListItem>(0);

            var usuario = GetCurrentUsuario();
            if (usuario != null)
            {
                if (usuario.CanApplySurcharge)
                {
                    var sur = oDropDownManager.GetDropDown(CommonEnums.DropDownType.SURCHARGEPERCENTAGE.ToString()).ToList();
                    sur.Insert(0, new Generic() { Value = "", name = "Seleccione" });

                    foreach (var s in sur)
                    {
                        itemsSurchargeData.Add(new SelectListItem()
                        {
                            Text = s.name,
                            Value = s.Value
                        });
                    }
                    //var output = from v in sur
                    //             select new { id = v.Value, name = v.name };
                    //return Json(output.ToArray(), JsonRequestBehavior.AllowGet);
                }
            }
            ViewBag.SurchargeData = itemsSurchargeData;
            ViewBag.userCanApplySurCharge = usuario != null ? usuario.CanApplySurcharge ? "S" : "N" : "N";

            return
                 PartialView("_Coverage", data);
        }

        private SelectList GetVehicleAvailableYearsList(int selectedValue = 0)
        {
            //1960 to now
            string minYear = oDropDownManager.GetParameter("PARAMETER_KEY_MIN_YEAR_VEHICLE").Value;
            var year = !string.IsNullOrEmpty(minYear) ? minYear.ToInt() : 1960;

            var list = new List<string>();
            for (int i = DateTime.Now.Year + 1; i >= year; i--)
                list.Add(i.ToString());

            list.Insert(0, "");

            return
                new SelectList(list.Select(i => new SelectListItem { Text = i.ToString(), Value = i }), "Value", "Text", selectedValue);
        }

        public JsonResult GetDataCustomerFromPolicy(string Id, string PolicyNumber, string Title = "")
        {
            JsonResult result = null;
            var DataCoreCustomer = oCoreProxy.GetClienteFromPoliza(PolicyNumber);

            if (DataCoreCustomer != null)
            {

                //Preguntar si ya hay una cotizacion con ese numero de poliza en cola ya sea en la bandeja o en global

                Entity.Entities.WSEntities.AgentTreeInfoNewWS userAgenCode = null;
                bool IsvalidAgent = true;
                var CheckPolicy = oCoreProxy.GetVehiculosFromPoliza(PolicyNumber);

                var isActivePolicy = CheckPolicy.Any() ? CheckPolicy.FirstOrDefault().EstatusPoliza == "ACTIVO" : false;

                if (!isActivePolicy)
                    result = Json(new { code = "003", msg = string.Format("La poliza \"{0}\" no esta Activa", PolicyNumber) }, JsonRequestBehavior.AllowGet);


                if (string.IsNullOrEmpty(Title))
                {
                    Title = "INCLUSIONES";
                }

                if (Title == "INCLUSIONES")
                {
                    base.RequestType = CommonEnums.RequestType.Inclusion;
                }
                else if (Title == "EXCLUSIONES")
                {
                    base.RequestType = CommonEnums.RequestType.Exclusion;
                }
                else if (Title == "CAMBIOS")
                {
                    base.RequestType = CommonEnums.RequestType.Cambios;
                }

                if (isActivePolicy)
                {
                    //Si es un agente el que se loguea validar que el agente del cliente este en su cadena
                    if (base.onlyLoggedUsers)
                    {
                        userAgenCode = GetAgentInfo(DataCoreCustomer.Intermediario.ToString());
                        if (userAgenCode != null)
                        {
                            var AgentList = GetAgentsInlcusion().Select(x => x.FullNameAll.ToString());
                            IsvalidAgent = AgentList.Contains(userAgenCode.FullNameAll);
                            result = Json(new
                            {
                                DataCoreCustomer = DataCoreCustomer,
                                userAgenCode = userAgenCode,
                                IsvalidAgent = IsvalidAgent,
                                IsExclusion = (Title == "EXCLUSIONES"),
                                IsVehicleChange = (Title == "CAMBIOS")
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                            result = Json(new { code = "004", msg = "Usted no tiene cadena de agentes" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //Validar que el id sea el mismo que se introdujo
                        if (!(DataCoreCustomer.RNC == Id))
                            result = Json(new { code = "002", msg = string.Format("Esta poliza \"{0}\" no le pertenece a esta identificación", PolicyNumber) }, JsonRequestBehavior.AllowGet);
                        else
                            result = Json(new
                            {
                                DataCoreCustomer = DataCoreCustomer,
                                userAgenCode = userAgenCode,
                                IsvalidAgent = IsvalidAgent,
                                IsExclusion = (Title == "EXCLUSIONES"),
                                IsVehicleChange = (Title == "CAMBIOS")
                            }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
                result = Json(new { code = "001", msg = string.Format("La poliza \"{0}\" no existe en nuestro Sistema", PolicyNumber) }, JsonRequestBehavior.AllowGet);

            return
                 result;
        }

        public JsonResult GetDataVehicleFromPolicy(string PolicyNumber)
        {
            var DataCoreVehicle = oCoreProxy.GetVehiculosFromPoliza(PolicyNumber);

            var newDataCoreVehicle = DataCoreVehicle.Select(x => new Entity.Entities.WSEntities.PolicyInclusionVehicleWS()
            {
                Cotizacion = x.Cotizacion,
                ramo = x.ramo,
                Poliza = x.Poliza,
                EstatusPoliza = x.EstatusPoliza,
                Item = x.Item,
                FechaFin = x.FechaFin,
                SubRamo = x.SubRamo,
                DescripcionSubramo = x.DescripcionSubramo,
                EstatusItem = x.EstatusItem,
                TipoVehiculo = x.TipoVehiculo,
                Idtipovehiculo = x.Idtipovehiculo,
                Marca = x.Marca,
                IdMarca = x.IdMarca,
                Modelo = x.Modelo,
                Idmodelo = x.Idmodelo,
                Ano = x.Ano,
                Idano = x.Idano,
                Uso = x.Uso,
                Iduso = x.Iduso,
                Estacionamiento = x.Estacionamiento,
                IdEstacionamiento = x.IdEstacionamiento,
                ValorVehiculo = x.ValorVehiculo,
                Deducible = x.Deducible,
                Iddeducible = x.Iddeducible,
                placa = x.placa,
                chasis = x.chasis,
                color = x.color,
                primaproratadiasinimpuestos = x.primaproratadiasinimpuestos,
                DescripcionTarifa = x.DescripcionTarifa,
                Financed = x.Financed,
                TipoPolizaDescripcion = x.TipoPolizaDescripcion,
                TieneEndoso = x.TieneEndoso,
                ValorEndosoCesion = x.ValorEndosoCesion,
                RNC = x.RNC,
                FechaFinString = x.FechaFin.GetValueOrDefault().ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture),
                Prima = x.Prima,
                ChasisId = x.ChasisId,
                ColorId = x.ColorId,
                PlacaId = x.PlacaId
            }).ToList();

            return
                Json(new
                {
                    DataCoreVehicle = newDataCoreVehicle,
                    PolicyNumber = PolicyNumber
                }, JsonRequestBehavior.AllowGet);
        }

        private bool ExisteMarcaSysflex(List<STL.POS.WsProxy.SysflexService.PolicySysflexMarcaVehiculo> ListaSysflex, string descripcion)
        {
            var existe = false;

            foreach (var m in ListaSysflex)
            {
                if (m.Descripcion.ToUpper() == descripcion.ToUpper())
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }

        public JsonResult getVehiclesModelsByBrands(int BrandId)
        {
            var Models = oDropDownManager.GetVehicleModels(BrandId);

            return Json(Models, JsonRequestBehavior.AllowGet);
        }

        private SelectList getVehiclesBrands(int selectedValue = 0)
        {
            var ListaMarcasSysflex = new List<STL.POS.WsProxy.SysflexService.PolicySysflexMarcaVehiculo>();
            ListaMarcasSysflex = oCoreProxy.GetVehicleMakes();

            var ListaMarcasPost = new List<MakePos>();

            var Brands = oDropDownManager.GetDropDown(CommonEnums.DropDownType.BRANDS.ToString());

            foreach (var m in Brands)
            {
                if (!string.IsNullOrEmpty(m.name) && !string.IsNullOrWhiteSpace(m.name))
                {
                    string newName = m.name.Trim();
                    if (ExisteMarcaSysflex(ListaMarcasSysflex, newName))
                        ListaMarcasPost.Add(new MakePos() { id = m.Value.ToInt(), name = newName });
                }
            }

            ListaMarcasPost.Insert(0, new MakePos() { id = -1, name = "" });

            return new SelectList(ListaMarcasPost.OrderBy(x => x.name).Select(i => new SelectListItem { Text = i.name, Value = i.id.ToString() }), "Value", "Text", selectedValue);
        }

        public JsonResult GetVehicleTypes_New(int brandId, int modelId, int vehicleYear, string AgentCode)
        {
            var model = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();

            if (model != null)
            {
                var paramDeLey = oDropDownManager.GetParameter("PARAMETER_KEY_DELEY_DISCRIMINATOR").Value;
                int codRamo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

                try
                {
                    var usersysflexornotProducts = oDropDownManager.GetParameter("PARAMETER_KEY_USE_OR_NOT_SYSFLEX_PRODUCTS").Value;

                    if (usersysflexornotProducts == "S")
                    {
                        var prods = oCoreProxy.GetVehicleTypes_NewPV(model.CoreVehicleTypeId, vehicleYear, paramDeLey, codRamo);

                        var realProds = ProductsFromSysflex.GetVehicleTypes_NewPV(prods);

                        return Json(realProds.ToArray(), JsonRequestBehavior.AllowGet);
                    }
                    else if (usersysflexornotProducts == "N")
                    {
                        var prods = ProductsFromSysflex.GetProductsSysflex(model.CoreVehicleTypeId, vehicleYear, null, codRamo, AgentCode);
                        return Json(prods.ToArray(), JsonRequestBehavior.AllowGet);
                    }

                    return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    var msg = string.Format("BrandId: {0} - ModelId: {1} - VehicleYear: {2}\nMensaje: {3}\nDetalle: {4}"
                                 , brandId.ToString()
                                 , modelId.ToString()
                                 , vehicleYear.ToString()
                                 , ex.Message
                                 , ex.StackTrace);
                    LoggerHelper.Log(CommonEnums.Categories.Error, UserIdentityName, -1, "Error al obtener datos de productos desde Sysflex", msg, ex);
                    return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(new System.Collections.ArrayList(), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<SelectListItem> GetStoreStates()
        {
            var param = oDropDownManager.GetParameter("PARAMETER_KEY_STORED_VALUES").Value;

            Dictionary<int, string> values = JsonConvert.DeserializeObject<Dictionary<int, string>>(param);

            var output = values.Select(p => new SelectListItem { Value = p.Key.ToString(), Text = p.Value }).ToList();
            output.Insert(0, new SelectListItem { Text = "", Value = "" });

            return
                output;
        }

        public ActionResult GetUsageStates()
        {
            var output = oDropDownManager.GetUsageStates().Select(u => new
            {
                id = u.Id,
                name = u.Name,
                allowed = u.Allowed,
                message = u.UsageMessage
            });

            return Json(output.OrderBy(x => x.allowed).ThenBy(n => n.name), JsonRequestBehavior.AllowGet);
        }

        public Entity.Entities.WSEntities.ProductLimitWS GetCoverageDetails(int coverageCoreId, decimal vehiclePrice, int codRamo)
        {
            Entity.Entities.WSEntities.ProductLimitWS pLimit = new Entity.Entities.WSEntities.ProductLimitWS();
            decimal temp;

            var selfAndOthers = oCoreProxy.GetCoverageNewDetail(coverageCoreId, (int)WsProxy.SysFlexCoverageDetailsIndicators.SelfAndThirdParty, vehiclePrice, codRamo);

            pLimit.ThirdPartyCoverages = (from s in selfAndOthers
                                          where s.CoverageDetailType.ToLower() == Entity.Entities.WSEntities.CoverageDetailWS.CoverageDetailTypeThirdParty.ToLower()
                                          orderby s.CoverageDetailName
                                          select new Entity.Entities.WSEntities.CoverageDetailWS()
                                          {
                                              CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                              Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                              Name = s.CoverageDetailName
                                          }).ToList();

            pLimit.SelfDamagesCoverages = (from s in selfAndOthers
                                           where s.CoverageDetailType.ToLower() == Entity.Entities.WSEntities.CoverageDetailWS.CoverageDetailTypeSelfDamages.ToLower()
                                           orderby s.CoverageDetailName
                                           select new Entity.Entities.WSEntities.CoverageDetailWS()
                                           {
                                               CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                               Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                               Name = s.CoverageDetailName
                                           }).ToList();

            //Additionals
            var services = oCoreProxy.GetCoverageNewDetail(coverageCoreId, (int)WsProxy.SysFlexCoverageDetailsIndicators.AdditionalServices, vehiclePrice, codRamo);

            pLimit.ServicesCoverages = (from s in services
                                        orderby s.CoverageDetailType
                                        select s.CoverageDetailType).Distinct().Select(s =>
                                            new Entity.Entities.WSEntities.ServiceTypeWS
                                            {
                                                Name = s,
                                                Coverages = new List<Entity.Entities.WSEntities.CoverageDetailWS>()
                                            }).Distinct().ToList();

            var rand = new Random(DateTime.Now.Millisecond);

            pLimit.ServicesCoverages.ToList().ForEach(sc =>
            {
                var coverages = (from s in services
                                 where s.CoverageDetailType == sc.Name
                                 orderby s.CoverageDetailName
                                 select new Entity.Entities.WSEntities.CoverageDetailWS()
                                 {
                                     Id = rand.Next(10000) * -1,
                                     CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                     IsSelected = s.mandatory,
                                     Amount = s.Premium.GetValueOrDefault(0m),
                                     Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                     MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                     Name = s.CoverageDetailName
                                 }).ToList();

                sc.Coverages = coverages;
            });

            return pLimit;
        }

        private int GetModelCoreId(int makeId, int modelId)
        {
            int coreId = -1;

            var models = oDropDownManager.GetVehicleModels(makeId);
            if (models != null)
            {
                var realmodel = models.FirstOrDefault(x => x.Id == modelId);
                if (realmodel != null)
                {
                    coreId = realmodel.CoreId.ToInt();
                }
            }

            return
                coreId;
        }

        public JsonResult GetCoverageDetailsOfVehicle(int coverageCoreId, int makeId, int modelId, decimal vehiclePrice = 0)
        {
            int coreId;
            int codRamo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();
            int DEDUCIBLE_SURCHARGE = oDropDownManager.GetParameter("PARAMETER_KEY_ID_DEDUCIBLE_SURCHARGE").Value.ToInt();

            try
            {
                coreId = GetModelCoreId(makeId, modelId);

                var coverageLimits = GetCoverageDetails(coverageCoreId, vehiclePrice, codRamo);

                var surcharges = oCoreProxy.GetDeductibles_NewPV(coverageCoreId, DEDUCIBLE_SURCHARGE, coreId, codRamo); ;

                var deductibles = from s in surcharges
                                  orderby s.Descripcion
                                  select new Entity.Entities.WSEntities.DeductibleValuesWS() { CoreId = s.Secuencia, Name = s.Descripcion };

                return Json(new { deductibles = deductibles.ToArray(), coverageLimits = coverageLimits }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var msg = string.Format("CoverageId: {0} - MakeId: {1} - ModelId: {2} - vehiclePrice: {3}\nMensaje: {4}\nDetalle: {5}", coverageCoreId.ToString()
                    , makeId.ToString()
                    , modelId.ToString()
                    , vehiclePrice.ToString()
                    , ex.Message
                    , ex.StackTrace);
                LoggerHelper.Log(CommonEnums.Categories.Error, UserIdentityName, -1, "Error al obtener datos de coberturas y deducibles desde Sysflex", msg, ex);
                throw ex;
            }
        }

        private int GetNewDailyQuotationNumber()
        {
            var nextQ = oDropDownManager.GetDropDown(CommonEnums.DropDownType.NEXTQUOTATION.ToString());

            if (nextQ.Count() > 0)
                return nextQ.FirstOrDefault().Value.ToInt() + 1;
            else
                return 0;
        }
        private Entity.Entities.WSEntities.OfficeMatchWS GetOfficeMatch(int globalOfficeId)
        {
            Entity.Entities.WSEntities.OfficeMatchWS result = null;

            var dataResult = oCoreProxy.GetofficeMatch_NewPV(globalOfficeId).FirstOrDefault();
            if (dataResult != null)
            {
                result = new Entity.Entities.WSEntities.OfficeMatchWS
                {
                    OfficeDesc = dataResult.OfficeDesc,
                    OfficeIdGlobal = dataResult.OfficeIdGlobal,
                    OfficeIdSysFlex = dataResult.OfficeIdSysFlex
                };
            }

            return result;
        }

        public Entity.Entities.WSEntities.AgentTreeInfoNewWS GetAgentInfo(string AgentCode)
        {
            var Usuario = GetCurrentUsuario();

            var result = oAgentWSProxy.GetAgentTreeNewInfoCallNew(Usuario.AgentOffices.FirstOrDefault().CorpId, Usuario.AgentId, Usuario.AgentNameId, 2)
                .Select(r => new Entity.Entities.WSEntities.AgentTreeInfoNewWS
                {
                    AgentCode = r.AgentCode,
                    CorpId = r.CorpId,
                    FullName = r.FullName,
                    FullNameAll = r.FullNameAll,
                    NameId = r.NameId
                }).FirstOrDefault(x => x.AgentCode == AgentCode);

            return
                result;
        }

        public JsonResult CreateQuotationByInclusion(string EndDate, string AgentCode, string DataCustomer, string policyNoMain, string StartDate = "")
        {
            var usuario = GetCurrentUsuario();
            var param = new Quotation.parameter();
            DateTime startDate = string.IsNullOrEmpty(StartDate) ? DateTime.Now : DateTime.Parse(StartDate, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.Parse(EndDate, CultureInfo.InvariantCulture);
            param.startDate = startDate.Date;
            param.endDate = endDate.Date;
            param.RequestTypeId = base.RequestType.ToInt();// CommonEnums.RequestType.Inclusion.ToInt();
            param.productNumber = "01";
            param.businessLine_Id = 1;
            param.cardnetPaymentStatus = CommonEnums.QuotationCardnetStatus.NotSent.ToInt();
            param.quotationDailyNumber = GetNewDailyQuotationNumber();
            param.quotationNumber = param.productNumber + DateTime.Now.ToString("yyyyMMdd") + param.quotationDailyNumber.ToString().PadLeft(4, '0');
            param.lastStepVisited = 1;
            param.paymentFrequencyId = null;
            param.paymentFrequency = "0 pago";
            param.paymentWay = null;
            param.currency_Id = 1;
            param.currencySymbol = "RD$";
            param.achAccountHolderGovId = null;
            param.achBankRoutingNumber = null;
            param.achName = string.Empty;
            param.achNumber = null;
            param.achType = 0;
            param.iSCPercentage = 0;
            param.discountPercentage = 0;
            param.sendInspectionOnly = false;
            param.amountToPayEnteredByUser = 0;
            param.declined = false;
            param.messaging = false;
            param.financed = false;
            param.monthlyPayment = null;
            param.period = null;
            param.credit_Card_Type_Id = 0;
            param.credit_Card_Number_Key = null;
            param.credit_Card_Number = null;
            param.expiration_Date_Year = 0;
            param.expiration_Date_Month = 0;
            param.card_Holder = null;
            param.domiciliation = false;
            param.quotationProduct = "";
            param.discountPercentage = 0;
            param.totalISC = 0;
            param.totalPrime = 0;
            param.totalDiscount = 0;
            param.flotillaDiscountPercent = 0;
            param.totalFlotillaDiscount = 0;
            param.policy_No_Main = policyNoMain;

            var agent = GetAgentInfo(AgentCode);

            if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
            {
                if (agent != null)
                    param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                else
                {
                    var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                    param.user_Id = (us > 0) ? us : CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                }
            }
            else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
            else //Agent
            {
                if (agent != null)
                    param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                else
                {
                    var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                    param.user_Id = (us > 0) ? us : CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email, usuario.AgentId);
                }
            }

            int qtyDayOfVigency = Utility.QuantityOfDays(param.startDate.Value.Date, param.endDate.Value.Date);
            param.qtyDayOfVigency = qtyDayOfVigency == 0 ? 365 : qtyDayOfVigency;// 365;

            param.status = 0;
            param.lastStepVisited = 1;
            param.modi_UserId = Usuario.UserID;
            var InsertQuotResult = oQuotationManager.SetQuotation(param);
            var currentQuotationSaved = oQuotationManager.GetQuotation(InsertQuotResult.EntityId);
            var quotationIdEncript = Utility.Encode(InsertQuotResult.EntityId.ToString());
            base.QuotationId = InsertQuotResult.EntityId;
            var driverData = CreateCustomerPOS(DataCustomer);

            var PrincipalDriver = driverData.FirstOrDefault(x => x.IsPrincipal);
            string NoCotizacionCore = "0";

            if (base.RequestType == CommonEnums.RequestType.Inclusion)
            {
                var codMonedaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA").Value.ToInt();
                var codMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_COD_MONEDA_SYSFLEX").Value.ToInt();
                var tasaMoneda = oDropDownManager.GetParameter("PARAMETER_KEY_TASA_MONEDA").Value.ToInt();
                var idOficina = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA").Value.ToInt();
                var idOficinaVO = oDropDownManager.GetParameter("PARAMETER_KEY_COD_OFICINA_VO").Value.ToInt();
                var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
                var agentId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_ID").Value.ToInt();
                var servicesRetryAmount = oDropDownManager.GetParameter("PARAMETER_KEY_SERVICES_RETRY_AMOUNT").Value.ToInt();

                string messageError;
                var codramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();

                var quotationUser = getQuotationUser(agent.NameId);

                int agentCode = -1;
                if (base.QuotationId > 0 && quotationUser != null && quotationUser.AgentId > 0)
                {
                    var userAgenCode = getAgenteUserInfo(quotationUser.AgentId.GetValueOrDefault());
                    if (userAgenCode != null)
                    {
                        if (userAgenCode.AgentId <= 0)
                            userAgenCode = getAgenteUserInfo(quotationUser.Username);//que es el nameid

                        int.TryParse(userAgenCode.AgentCode, out agentCode);
                    }
                }

                if (agentCode <= 0)
                {
                    agentCode = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToInt();
                }

                if (usuario != null && usuario.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User) //Agent or Suscriptor
                {
                    if (base.QuotationId > 0 && quotationUser != null && quotationUser.AgentId > 0)
                    {
                        var userAgentOffice = getAgenteUserInfo(quotationUser.AgentId.GetValueOrDefault());
                        if (userAgentOffice != null)
                        {
                            if (userAgentOffice.AgentId <= 0)
                            {
                                userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                            }

                            var OfficeId = 13;
                            foreach (var item in userAgentOffice.AgentOffices)
                            {
                                idOficinaVO = item.OfficeId;
                                continue;
                            }

                            var dataMatch = GetOfficeMatch(idOficinaVO);

                            if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                                OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                            idOficina = OfficeId;
                        }
                    }
                    else
                        idOficina = idOficinaVO = usuario.AgentOffices.First().OfficeId;
                }
                else if (usuario == null)
                {
                    if (base.QuotationId > 0 && quotationUser != null && quotationUser.AgentId > 0)
                    {
                        var userAgentOffice = getAgenteUserInfo(quotationUser.AgentId.GetValueOrDefault());
                        if (userAgentOffice != null)
                        {
                            if (userAgentOffice.AgentId <= 0)
                            {
                                userAgentOffice = getAgenteUserInfo(quotationUser.Username);//que es el nameid
                            }
                            var OfficeId = 13;
                            foreach (var item in userAgentOffice.AgentOffices)
                            {
                                idOficinaVO = item.OfficeId;
                                continue;
                            }


                            var dataMatch = GetOfficeMatch(idOficinaVO);
                            if (dataMatch != null && dataMatch.OfficeIdSysFlex.GetValueOrDefault() > 0)
                                OfficeId = dataMatch.OfficeIdSysFlex.GetValueOrDefault();

                            idOficina = OfficeId;
                        }
                    }
                }

                decimal flotillaPercent = param.flotillaDiscountPercent.GetValueOrDefault();
                int DESCUENTO_FLOTILLA_ID = oDropDownManager.GetParameter("PARAMETER_KEY_DESCUENTO_FLOTILLA_ID_SYSFLEX").Value.ToInt();

                decimal prontoPagoPercent = param.discountPercentage.GetValueOrDefault();
                int PRONTO_PAGO_ID = oDropDownManager.GetParameter("PARAMETER_KEY_PRONTO_PAGO_ID_SYSFLEX").Value.ToInt();

                int cod_COMPANY = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();
                string Sistema = oDropDownManager.GetParameter("PARAMETER_KEY_SYSTEMA").Value;

                NoCotizacionCore = (string.IsNullOrEmpty(currentQuotationSaved.QuotationCoreNumber)) ? GetQuotationCoreNumber(base.QuotationId)
                                                                                                     : currentQuotationSaved.QuotationCoreNumber;


                int? ubicationID = null;

                if (PrincipalDriver != null && PrincipalDriver.City_City_Id > 0)
                {
                    ubicationID = oPersonManagerManager.GetPersonCountryUbicationOnSysflex(PrincipalDriver.City_Country_Id, PrincipalDriver.City_State_Prov_Id, PrincipalDriver.City_City_Id);
                }


                if (NoCotizacionCore == "0" || string.IsNullOrEmpty(NoCotizacionCore))
                {
                    //Crear la cabecera de la cotizacion en SysFlex
                    NoCotizacionCore = oCoreProxy.SetAutoQuotationHeaderForGetCoreQuotationNumber_NewPV
                         (currentQuotationSaved,
                         PrincipalDriver,
                         codMoneda,
                         tasaMoneda,
                         agentCode,
                         idOficina,
                         codramo,
                         servicesRetryAmount,
                         "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : ""),
                         cod_COMPANY,
                         flotillaPercent,
                         DESCUENTO_FLOTILLA_ID,
                         prontoPagoPercent,
                         PRONTO_PAGO_ID,
                         ubicationID,
                         Sistema,
                         out messageError
                         );
                }
            }

            #region Actualizando Cotizacion con los datos de sysflex
            Quotation.parameter UpdParam = new Quotation.parameter();
            UpdParam.id = currentQuotationSaved.Id;

            UpdParam.principalFullName = PrincipalDriver.FirstName.Trim() + (!string.IsNullOrEmpty(PrincipalDriver.FirstSurname) ? " " + PrincipalDriver.FirstSurname.Trim() : "");
            UpdParam.principalIdentificationNumber = PrincipalDriver.IdentificationNumber;

            UpdParam.quotationCoreNumber = NoCotizacionCore;
            base.CoreQuotationNumber = NoCotizacionCore;
            param.modi_UserId = Usuario.UserID;
            oQuotationManager.SetQuotation(UpdParam);
            #endregion

            return
                Json(new { quotationIdEncript = quotationIdEncript, Quotation = currentQuotationSaved, driverData = driverData }, JsonRequestBehavior.AllowGet);
        }

        public string GetQuotationCoreNumber(int quotationPossitenumber)
        {
            var quotation = oQuotationManager.GetQuotation(quotationPossitenumber);

            if (quotation != null && quotation.QuotationCoreNumber != null)
            {
                return quotation.QuotationCoreNumber;
            }
            else { return "0"; }
        }

        public IEnumerable<Driver> CreateCustomerPOS(string jsonData)
        {
            int country_Id = 129;
            int domesticreg_Id = 0;
            int state_Prov_Id = 0;
            int city_Id = 0;

            var dContact = JsonConvert.DeserializeObject<dynamic>(jsonData);

            /*Poner la ciudad por default*/
            var city = oDropDownManager.GetDropDown(CommonEnums.DropDownType.DEFAULTCITY.ToString()).FirstOrDefault();
            var keyCity = city.Value.Split('-');
            if (keyCity.Count() > 2)
            {
                domesticreg_Id = keyCity[0].ToInt();
                state_Prov_Id = keyCity[1].ToInt();
                city_Id = keyCity[3].ToInt();
            }


            int? ubicationID = dContact.Ubicacion;
            if (ubicationID.HasValue)
            {
                var dataUbication = oPersonManagerManager.GetPersonCountryUbicationByUbicationSysflex(ubicationID.Value);
                if (dataUbication.Count() > 0)
                {
                    country_Id = dataUbication.FirstOrDefault().Country_Id;
                    domesticreg_Id = dataUbication.FirstOrDefault().Domesticreg_Id;
                    state_Prov_Id = dataUbication.FirstOrDefault().State_Prov_Id;
                    city_Id = dataUbication.FirstOrDefault().City_Id;
                }
            }


            var Apellidos = ((object)dContact.Apellidos).ToString().Split(' ');
            var Apellido1 = string.Empty;
            var Apellido2 = string.Empty;

            if (Apellidos.Length > 1)
            {
                Apellido1 = Apellidos[0];
                Apellido2 = Apellidos[1];
            }
            else
                Apellido1 = dContact.Apellidos;


            var _invoiceTypeId = dContact.Ncf;
            string _sex = (!string.IsNullOrEmpty(dContact.IdentificationType.ToString()) && dContact.IdentificationType.ToString() == "RNC" ? "Empresa" : dContact.Sexo);

            var itemPerson = new Person.PersonParameters
            {
                firstName = dContact.Nombre,
                secondName = string.Empty,
                firstSurname = Apellido1,
                secondSurname = Apellido2,
                dateOfBirth = dContact.FechaNacimiento,
                isPrincipal = true,
                address = dContact.Direccion,
                phoneNumber = dContact.TelefonoResidencia,
                mobile = dContact.Celular,
                workPhone = dContact.TelefonoOficina,
                identificationType = dContact.IdentificationType,
                identificationNumber = dContact.RNC,
                sex = _sex,
                maritalStatus = string.Empty,
                job = string.Empty,
                company = string.Empty,
                yearsInCompany = null,
                country_Id = country_Id,
                domesticreg_Id = domesticreg_Id,
                state_Prov_Id = state_Prov_Id,
                city_Id = city_Id,
                nationalityGlobalCountry_Id = null,
                email = dContact.Email,
                foreignLicense = false,
                identificationNumberValidDate = null,
                invoiceTypeId = _invoiceTypeId,
                postalCode = string.Empty,
                annualIncome = null,
                socialReasonId = null,
                ownershipStructureId = null,
                identificationFinalBeneficiaryOptionsId = null,
                pepFormularyOptionsId = null,
                home_Owner = null,
                qtyPersonsDepend = null,
                qtyEmployees = null,
                linked = string.Empty,
                segment = string.Empty,
                fax = string.Empty,
                uRL = string.Empty,
                userId = GetCurrentUserID()
            };

            var SetPersonResult = oPersonManagerManager.SetPerson(itemPerson);

            var itemDriver = new Driver.parameters
            {
                id = SetPersonResult.EntityId,
                quotationId = this.QuotationId,
                yearsDriving = null,
                accidentsLast3Years = null,
                userId = GetCurrentUserID()
            };

            var SetDriverResult = oDriverManager.SetDriver(itemDriver);
            var dataDriver = oQuotationManager.GetQuotationDrivers(base.QuotationId);

            return
                   dataDriver;
        }

        public JsonResult SaveVehicleInclusion(string jsondataVehicle)
        {
            var dvehicle = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(jsondataVehicle);

            var principalFullName = "";
            var principalIdentificationNumber = "";
            var totalVehiclesPrime = 0;
            var DriverExist = false;
            var DriverId = 0;

            var dataDriver = oQuotationManager.GetQuotationDrivers(base.QuotationId);
            if (dataDriver.Any())
            {
                var oDriver = dataDriver.FirstOrDefault(r => r.IsPrincipal);

                principalFullName = string.Concat(oDriver.FirstName, " ", oDriver.FirstSurname);
                principalIdentificationNumber = oDriver.IdentificationNumber;
                DriverId = oDriver.Id;
                DriverExist = true;
            }

            decimal? PercentByQtyVehicle = dvehicle.Select(x => (decimal)x.PercentByQtyVehicle).Cast<decimal>().FirstOrDefault();
            decimal? TotalByQtyVehicle = dvehicle.Select(x => (decimal)x.TotalByQtyVehicle).Cast<decimal>().FirstOrDefault();

            foreach (var vehicle in dvehicle)
            {
                if (!DriverExist)
                {
                    principalFullName = vehicle.principalFullName;
                    principalIdentificationNumber = vehicle.IdentificationNumber;
                }

                var vparam = new VehicleProduct.Parameter();
                vparam.id = vehicle.id != null ? vehicle.id : null;
                vparam.vehicleDescription = vehicle.vehicleDescription;
                vparam.year = vehicle.year;
                vparam.vehiclePrice = vehicle.vehiclePrice;
                vparam.insuredAmount = vehicle.insuredAmount;
                vparam.percentageToInsure = vehicle.percentageToInsure;
                vparam.totalPrime = vehicle.totalPrime;
                vparam.totalIsc = vehicle.totalIsc;
                vparam.ProratedPremium = vehicle.ProratedPremium;
                vparam.isFacultative = vehicle.IsFacultative;
                vparam.amountFacultative = vehicle.AmountFacultative;

                vparam.totalDiscount = 0;
                vparam.selectedProductCoreId = vehicle.selectedProductCoreId;
                var vtCore = oDropDownManager.GetVehicleTypes((int?)vehicle.vehicleModel_Make_Id, (int?)vehicle.vehicleModel_Model_Id).FirstOrDefault();

                if (vtCore != null)
                {
                    vparam.vehicleTypeCoreId = vtCore.CoreVehicleTypeId;
                    vparam.vehicleTypeName = vtCore.VehicleTypeDesc;
                }

                vparam.selectedProductName = vehicle.selectedProductName;
                vparam.vehicleMakeName = vehicle.vehicleMakeName;
                vparam.usageId = vehicle.usageId;
                vparam.usageName = vehicle.usageName;
                vparam.storeId = vehicle.storeId;
                vparam.storeName = vehicle.storeName;
                vparam.driver_Id = DriverExist ? DriverId : vehicle.driver_Id;
                vparam.vehicleModel_Make_Id = vehicle.vehicleModel_Make_Id;
                vparam.vehicleModel_Model_Id = vehicle.vehicleModel_Model_Id;
                vparam.quotation_Id = this.QuotationId;
                vparam.selectedVehicleTypeId = vehicle.selectedVehicleTypeId;
                vparam.selectedVehicleTypeName = vehicle.selectedVehicleTypeName;
                vparam.selectedCoverageCoreId = vehicle.selectedCoverageCoreId;
                vparam.selectedCoverageName = vehicle.selectedCoverageName;
                vparam.vehicleYearOld = vehicle.vehicleYearOld;
                vparam.surChargePercentage = (vehicle.surChargePercentage == 0) ? 0 : vehicle.surChargePercentage;
                vparam.numeroFormulario = null;
                vparam.rateJson = vehicle.rateJson;
                vparam.userId = GetCurrentUserID();
                vparam.secuenciaVehicleSysflex = vehicle.secuenciaVehicleSysflex;
                vparam.secuenciaVehicleSysflex = vparam.secuenciaVehicleSysflex == 0 ? 1 : vehicle.secuenciaVehicleSysflex;
                vparam.isFacultative = vehicle.IsFacultative;
                vparam.amountFacultative = vehicle.AmountFacultative;
                vparam.vehicleQuantity = vehicle.vehicleQuantity;

                vparam.SelectedVehicleFuelTypeId = vehicle.SelectedVehicleFuelTypeId;
                vparam.SelectedVehicleFuelTypeDesc = vehicle.SelectedVehicleFuelTypeDesc;

                var SetVehicleResult = oVehicleProductManager.SetVehicleProduct(vparam);

                var currentVehicleID = SetVehicleResult.EntityId;
                var Total = (Convert.ToDecimal(vehicle.totalPrime) * vparam.vehicleQuantity.GetValueOrDefault());
                totalVehiclesPrime += Total;

                #region Guardar Coberturas del vehiculo

                var json = JsonConvert.SerializeObject(vehicle.productLimit);

                if (json != "null")
                {
                    ProductLimits productLimitSet = JsonConvert.DeserializeObject<ProductLimits>(json);
                    productLimitSet.TotalIsc = vehicle.totalIsc;
                    productLimitSet.TotalDiscount = 0;
                    productLimitSet.TotalPrime = vehicle.totalPrime;

                    //Mark this productlimitset as the one selected by the user
                    productLimitSet.IsSelected = true;
                    if (vehicle.selectedDeductible.ToString() != "")
                    {
                        productLimitSet.SelectedDeductibleCoreId = vehicle.selectedDeductible;
                        json = JsonConvert.SerializeObject(vehicle.GlobalDataDeductibleList);
                        List<Entity.Entities.WSEntities.DeductibleValues> deductibleList = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.DeductibleValues>>(json);

                        Entity.Entities.WSEntities.DeductibleValues deductible = deductibleList.FirstOrDefault(d => d.CoreId == productLimitSet.SelectedDeductibleCoreId);
                        productLimitSet.SelectedDeductibleName = deductible != null ? deductible.Name : null;
                    }

                    //Borrado masivo de coverturas y productlimits
                    oVehicleProductManager.DeleteVehicleProductCoveragesServices(currentVehicleID, false);
                    //

                    var prodParam = new ProductLimits.Parameter();
                    prodParam.id = null;
                    prodParam.vehicleProduct_Id = currentVehicleID;
                    prodParam.isSelected = true;
                    prodParam.totalIsc = productLimitSet.TotalIsc;
                    prodParam.totalDiscount = productLimitSet.TotalDiscount;
                    prodParam.totalPrime = productLimitSet.TotalPrime;
                    prodParam.servicesPrime = productLimitSet.ServicesPrime;
                    prodParam.tpPrime = productLimitSet.TpPrime;
                    prodParam.sdPrime = productLimitSet.SdPrime;
                    prodParam.selectedDeductibleCoreId = productLimitSet.SelectedDeductibleCoreId;
                    prodParam.selectedDeductibleName = productLimitSet.SelectedDeductibleName;
                    prodParam.userId = GetCurrentUserID();

                    var productLimitSaved = oProductLimitsManager.SetProudctLimits(prodParam);
                    var currentProductLimit = productLimitSaved.EntityId;

                    var parm = new STL.POS.WsProxy.SysflexService.PolicySysFlexGetPrimaCoberturaKey();
                    parm.Cotizacion = decimal.Parse(this.GetQuotationCoreNumber(this.QuotationId));
                    parm.Secuencia = vehicle.secuenciaVehicleSysflex;
                    parm.Secuencia = parm.Secuencia == 0 ? 1 : parm.Secuencia;

                    var primacobertura = oCoreProxy.GetPrimaCobertura(parm);

                    #region Services

                    List<string> headers = new List<string>();
                    BaseEntity serviceTypeSaved = new BaseEntity();

                    var jsonST = JsonConvert.SerializeObject(vehicle.ServicesSelected);
                    var st = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.ServiceTypeWS>>(jsonST);
                    foreach (var stList in st)
                    {
                        foreach (var sc in stList.Coverages)
                        {
                            if (!headers.Contains(stList.Name))
                            {
                                ServicesTypes.Parameter stParam = new ServicesTypes.Parameter();
                                stParam.id = null;
                                stParam.servicesTypesToProductLimits = currentProductLimit;
                                stParam.name = stList.Name;
                                stParam.userId = GetCurrentUserID();
                                serviceTypeSaved = oServicesTypesRepositoryManager.SetServiceType(stParam);

                                headers.Add(stList.Name);
                            }

                            var currentServiceType = serviceTypeSaved.EntityId;

                            #region SE Coverages

                            if (sc.IsSelected)
                            {
                                var scParam = new Coverage.Parameter();

                                if (primacobertura.Count() > 0)
                                {
                                    var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == sc.CoverageDetailCoreId);
                                    if (realCObert != null)
                                    {
                                        decimal realLimitSer = 0;
                                        string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                        decimal.TryParse(MontoInformativo, out realLimitSer);

                                        scParam.id = null;
                                        scParam.isSelected = sc.IsSelected;
                                        scParam.coverageDetailCoreId = sc.CoverageDetailCoreId;
                                        scParam.name = sc.Name;
                                        //scParam.amount = realCObert.Prima;
                                        //scParam.limit = realCObert.Prima;

                                        scParam.amount = realCObert.Prima;
                                        scParam.limit = realLimitSer;

                                        scParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                        scParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                        scParam.selfDamagesToProductLimits = null;
                                        scParam.thirdPartyToProductLimits = null;
                                        scParam.serviceType_Id = currentServiceType;
                                        scParam.userId = GetCurrentUserID();
                                        oCoverageManager.SetCoverageDetail(scParam);
                                    }
                                }
                            }
                        }
                        #endregion
                    }

                    #endregion

                    #region Self Damage Coverages

                    var jsonSelfDamages = JsonConvert.SerializeObject(vehicle.limitself.SelfDamagesCoverages);
                    var sfd = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageDetailWS>>(jsonSelfDamages);

                    var sdParam = new Coverage.Parameter();

                    if (sfd != null)
                    {
                        foreach (var sdc in sfd)
                        {
                            sdParam = new Coverage.Parameter();

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == sdc.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    decimal realLimit = 0;
                                    string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                    decimal.TryParse(MontoInformativo, out realLimit);
                                    sdParam.id = null;
                                    sdParam.isSelected = false;
                                    sdParam.coverageDetailCoreId = sdc.CoverageDetailCoreId;
                                    sdParam.name = sdc.Name;
                                    sdParam.amount = realLimit;
                                    sdParam.limit = realLimit;
                                    sdParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                    sdParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                    sdParam.selfDamagesToProductLimits = currentProductLimit;
                                    sdParam.thirdPartyToProductLimits = null;
                                    sdParam.serviceType_Id = null;
                                    sdParam.userId = GetCurrentUserID();
                                }
                            }

                            oCoverageManager.SetCoverageDetail(sdParam);
                        }
                    }

                    #endregion

                    #region Third Party Coverages
                    var jsonThirdParty = JsonConvert.SerializeObject(vehicle.limitself.ThirdPartyCoverages);
                    var tps = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageDetailWS>>(jsonThirdParty);
                    var tpParam = new Coverage.Parameter();

                    if (tps != null)
                    {
                        foreach (var tpc in tps)
                        {
                            tpParam = new Coverage.Parameter();

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == tpc.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    decimal realLimit = 0;
                                    string MontoInformativo = realCObert.MontoInformativo.Replace(",", "");
                                    decimal.TryParse(MontoInformativo, out realLimit);
                                    tpc.Amount = realLimit;
                                    tpc.Limit = realLimit;
                                    tpc.MinDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                    tpc.Deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;

                                    tpParam.id = null;
                                    tpParam.isSelected = false;
                                    tpParam.coverageDetailCoreId = tpc.CoverageDetailCoreId;
                                    tpParam.name = tpc.Name;
                                    tpParam.amount = realLimit;
                                    tpParam.limit = realLimit;
                                    tpParam.minDeductible = realCObert.MinimoDeducible.HasValue ? realCObert.MinimoDeducible.Value : 0;
                                    tpParam.deductible = realCObert.Deducible.HasValue ? realCObert.Deducible.Value : 0;
                                    tpParam.selfDamagesToProductLimits = null;
                                    tpParam.thirdPartyToProductLimits = currentProductLimit;
                                    tpParam.serviceType_Id = null;
                                    tpParam.userId = GetCurrentUserID();
                                }
                            }
                            oCoverageManager.SetCoverageDetail(tpParam);
                        }
                    }
                    #endregion
                }
                #endregion
            }

            decimal percentISC = 16m;

            //Actualizando la cotizacion con los totales de prima
            var qparam = new Quotation.parameter();
            qparam.id = this.QuotationId;
            qparam.totalISC = totalVehiclesPrime * (percentISC / 100);
            qparam.totalPrime = totalVehiclesPrime;
            qparam.iSCPercentage = percentISC;
            var prod = GetQuotationProduct(this.QuotationId);
            qparam.quotationProduct = prod == "Flotilla" ? "Varios" : prod;

            qparam.principalFullName = principalFullName;
            qparam.principalIdentificationNumber = principalIdentificationNumber;

            qparam.flotillaDiscountPercent = PercentByQtyVehicle;
            qparam.totalFlotillaDiscount = TotalByQtyVehicle;

            //Si al menos hay un true, entonces no es de ley, porque para ser de ley todo debe ser false
            var dataIsNotLaw = dvehicle.Select(x => bool.Parse(x.isNotLaw.ToString().ToLower()));
            qparam.sendInspectionOnly = dataIsNotLaw.Contains(true);
            isNotLawProduct = qparam.sendInspectionOnly.GetValueOrDefault();

            var getquo = oQuotationManager.GetQuotation(this.QuotationId);

            if (getquo != null)
            {
                var startDatetime = getquo.StartDate.GetValueOrDefault().Date < DateTime.Now.Date ? DateTime.Now.Date : getquo.StartDate.Value.Date;
                qparam.startDate = startDatetime;
                qparam.monthlyPayment = getquo.MonthlyPayment;
                qparam.financed = getquo.Financed;
                qparam.period = getquo.Period;
            }

            qparam.modi_UserId = GetCurrentUserID();

            if (!string.IsNullOrEmpty(base.RiskLevel))
                qparam.RiskLevel = base.RiskLevel;

            oQuotationManager.SetQuotation(qparam);

            QuotationId = qparam.id.Value;
            QuotationNumber = qparam.quotationNumber;

            return
                  Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehiclesFromInclusion(string PolicyNo)
        {
            var DataCoreCustomer = oCoreProxy.GetClienteFromPoliza(PolicyNo);
            var userAgenCode = GetAgentInfo(DataCoreCustomer.Intermediario.ToString());

            string sysflexVehiclesIdToExclude = "";

            var dataVehicles = base.getVehicleData(base.QuotationId).Select(y =>
            {
                y.SelectedDeductibleName = oQuotationManager.GetQuotationProductLimits(y.Id.GetValueOrDefault()).FirstOrDefault().SelectedDeductibleName;
                return y;
            });

            string title = "INCLUSIONES";

            if (base.RequestType == CommonEnums.RequestType.Exclusion)
            {
                title = "EXCLUSIONES";
            }
            else if (base.RequestType == CommonEnums.RequestType.Cambios)
            {
                title = "CAMBIOS";
            }

            var dataCustomer = GetDataCustomerFromPolicy("", PolicyNo, title);
            var ExclusionStartDate = "";
            bool isExlusion = false;
            bool IsVehicleChange = false;


            if (base.RequestType == CommonEnums.RequestType.Exclusion)
            {
                var quotData = oQuotationManager.GetQuotation(base.QuotationId);

                if (quotData != null)
                {
                    ExclusionStartDate = quotData.StartDate.GetValueOrDefault().ToString("dd-MMM-yyyy");
                    isExlusion = true;

                    var q = dataVehicles.Select(x => x.SecuenciaVehicleSysflex.ToString()).ToArray();
                    sysflexVehiclesIdToExclude = string.Join(",", q);
                }
            }
            else if (base.RequestType == CommonEnums.RequestType.Cambios)
            {
                var quotData = oQuotationManager.GetQuotation(base.QuotationId);

                if (quotData != null)
                {
                    var q = dataVehicles.Select(x => x.SecuenciaVehicleSysflex.ToString()).ToArray();
                    sysflexVehiclesIdToExclude = string.Join(",", q);

                    IsVehicleChange = true;
                }
            }

            return Json(new
            {
                dataVehicles = dataVehicles,
                QuotationNumber = base.QuotationNumber,
                dataCustomer = DataCoreCustomer,
                userAgenCode = userAgenCode,
                ExclusionStartDate = ExclusionStartDate,
                IsExclusion = isExlusion,
                sysflexVehiclesIdToExclude = sysflexVehiclesIdToExclude,
                IsVehicleChange = IsVehicleChange

            }, JsonRequestBehavior.AllowGet);
        }

        public string GetQuotationProduct(int quotationID)
        {
            var _vehicles = base.getVehicleData(quotationID);

            if (_vehicles != null && _vehicles.Count() > 0)
            {
                var prods = _vehicles.Select(c => c.SelectedProductName).Distinct();

                if (prods.Count() > 1)
                    return "Flotilla";
                else
                    return prods.First();
            }
            else
                return string.Empty;
        }

        public IEnumerable<Entity.Entities.WSEntities.AgentTreeInfoNewWS> GetAgentsInlcusion()
        {
            var usuario = GetCurrentUsuario();
            List<Entity.Entities.WSEntities.AgentTreeInfoNewWS> agentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();
            if (usuario != null)
            {
                int bl = 2;

                if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    var a = oAgentWSProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
                    foreach (var r in a)
                    {
                        string json = JsonConvert.SerializeObject(r);
                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                        {
                            AgentCode = r.AgentCode,
                            CorpId = r.CorpId,
                            FullName = r.FullName,
                            FullNameAll = r.FullNameAll,
                            NameId = r.NameId,
                            jsonAgentTree = json
                        });
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                {
                    var a = oAgentWSProxy.GetAgentTreeNewInfoCallNew(usuario.AgentOffices.FirstOrDefault().CorpId, usuario.AgentId, usuario.AgentNameId, bl);
                    foreach (var r in a)
                    {
                        string json = JsonConvert.SerializeObject(r);

                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS()
                        {
                            AgentCode = r.AgentCode,
                            CorpId = r.CorpId,
                            FullName = r.FullName,
                            FullNameAll = r.FullNameAll,
                            NameId = r.NameId,
                            jsonAgentTree = json
                        });


                    }

                    if (agentList.Count() == 0 || agentList.Count() == 1)
                    {
                        agentList = new List<Entity.Entities.WSEntities.AgentTreeInfoNewWS>();
                        string userNameID = !string.IsNullOrEmpty(usuario.AgentNameId) ? usuario.AgentNameId : usuario.UserLogin;

                        agentList.Add(new Entity.Entities.WSEntities.AgentTreeInfoNewWS() { FullNameAll = usuario.FirstName + " " + usuario.LastName + "(" + usuario.AgentCode + ")", NameId = userNameID, AgentId = usuario.AgentId });
                    }
                }
            }

            agentList = agentList.OrderBy(o => o.FullNameAll).ToList();

            return agentList;
        }

        public JsonResult getMaximoReaseguroSubRamo_NewInlcusion(int SecuenciaVehicleSysflex, decimal quotationCoreNumber, string make, string model, string year)
        {
            int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();

            string message = "";
            bool IsFacultative = false;
            decimal AmountFacultative = 0;

            var result = oCoreProxy.GetReinsuranceByItemVehicle(cod_company, quotationCoreNumber, SecuenciaVehicleSysflex);

            if (result.Count() > 0 && result.FirstOrDefault() != null)
            {
                if (result.FirstOrDefault().ValorFacultativo > 0)
                {
                    IsFacultative = true;
                    AmountFacultative = result.FirstOrDefault().ValorFacultativo.GetValueOrDefault();

                    var messageParam = oDropDownManager.GetParameter("PARAMETER_KEY_MESSAGE_REINSURANCE").Value;
                    message = string.Format(messageParam, make, model, year);
                }
            }

            return Json(new { IsFacultative = IsFacultative, message = message, AmountFacultative = AmountFacultative }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQtyYearsBack0KmVipInclusion()
        {
            var Param = oDropDownManager.GetParameter("PARAMETER_KEY_QTY_YEARS_BACK_OKM_VIP").Value;
            return Json(Param, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener las marcas de los vehiculos a incluir
        /// </summary>
        public void GetViewBag()
        {
            ViewBag.Brands = getVehiclesBrands();
            ViewBag.Years = GetVehicleAvailableYearsList();
            ViewBag.Stores = GetStoreStates();
        }

        public JsonResult GetRates(
         int coverageCoreId,   //Subramo
         int brandId,          //Id de la marca
         int modelId,          //Id del modelo
         int vehicleYear,      //Año del vehicuo                
         decimal insuredAmount, //Valor del vehiculo         
         int storageId,         //id del estacionamiento
         string deductibleId, //Id del deducible        
         int qtyVehicles,//Cantidad de Vehiculos
         int usage, //Id del uso
         int secuencia = 1,
         bool Esdeley = false,
         int idCapacidad = 0,
         string descCapacidad = "",
         string Services = "",
         string limitself = "",
         string usagename = "",
         string isSemifull = "",
         decimal? percentSurCharge = null,
         int coveragePercent = 100,
         int fuelTypeId = 0,
         string fuelTypeDesc = ""
        )
        {
            List<string> statusMessages = new List<string>();
            int cod_company = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_ID_SYSFLEX").Value.ToInt();
            int ramo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();
            string gender = string.Empty;
            var QuotationData = oQuotationManager.GetQuotation(base.QuotationId);
            var currentDriverSaved = oQuotationManager.GetQuotationDrivers(base.QuotationId);
            var PrincipalDriver = new Driver();
            if (currentDriverSaved != null)
                PrincipalDriver = currentDriverSaved.FirstOrDefault(x => x.IsPrincipal);

            gender = PrincipalDriver.Sex;

            #region Insertando Detalle/Obteniendo prima de la cotizacion

            var model = oDropDownManager.GetVehicleModels(brandId).FirstOrDefault(x => x.Id == modelId);
            var Marca = oDropDownManager.GetDropDown(CommonEnums.DropDownType.BRANDS.ToString()).FirstOrDefault(x => x.Value == brandId.ToString());
            var Type = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();
            var Type1 = oDropDownManager.GetVehicleTypes(brandId, modelId).FirstOrDefault();

            /*Storage from POS_SITE*/
            var param = oDropDownManager.GetParameter("PARAMETER_KEY_STORED_VALUES").Value;
            Dictionary<int, string> values = JsonConvert.DeserializeObject<Dictionary<int, string>>(param);
            var StorageOutput = from pair in values
                                select new { id = pair.Key, name = pair.Value };

            var storageName = "";
            if (StorageOutput.Count() > 0)
            {
                var storage = StorageOutput.FirstOrDefault(x => x.id == storageId);
                if (storage != null)
                    storageName = storage.name;
            }

            if (deductibleId == "") { deductibleId = "0"; }
            var success = false;

            var tipoveh = new List<Entity.Entities.WSEntities.ComboCondicion>();
            var Marcavehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
            var Usovehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
            var Aniovehiculo = new List<Entity.Entities.WSEntities.ComboCondicion>();
            var Deductible = new List<Entity.Entities.WSEntities.ComboCondicion>();
            var Storage = new List<Entity.Entities.WSEntities.ComboCondicion>();

            /*type MakesVEH*/
            Marcavehiculo = ComboConditionsMethods.GetComboCondicion_New("MakesVEH", ramo, coverageCoreId, "MARCA VEHÍCULO", Marca.name, null, null);
            /*type YearVEH*/
            Aniovehiculo = ComboConditionsMethods.GetAnioVehiculo_New("YearVEH", ramo, coverageCoreId, "AÑOS VEHICULOS", null, vehicleYear, null);
            /*type DeducibleVEH*/
            Deductible = ComboConditionsMethods.GetDeductible_New("DeducibleVEH", ramo, coverageCoreId, "DEDUCIBLE", null, vehicleYear, Convert.ToInt32(deductibleId));
            /*type StorageVEH*/
            Storage = ComboConditionsMethods.GetDeductible_New("StorageVEH", ramo, coverageCoreId, "Estacionamiento", storageName, null, null);

            var cDetail = new PolicyQuotationSysFlexCotDetKey();

            var startDatetime = QuotationData.StartDate.GetValueOrDefault().Date < DateTime.Now.Date ? DateTime.Now : QuotationData.StartDate;
            var endDatetime = startDatetime.GetValueOrDefault().AddYears(1);
            var quotationCore = QuotationData.QuotationCoreNumber.ToDecimal();

            cDetail.cotizacion = quotationCore;
            cDetail.ramo = ramo;
            cDetail.subRamo = coverageCoreId;
            cDetail.secuencia = secuencia;
            cDetail.montoAsegurado = insuredAmount;
            cDetail.tasa = 0;
            cDetail.formadePago = "";
            cDetail.idTipoVehiculo = Type.CoreVehicleTypeId.ToString();

            if (Marcavehiculo.Count() > 0)
                cDetail.idMarcaVehiculo = Marcavehiculo.FirstOrDefault().Codigo.ToString();

            cDetail.idModeloVehiculo = model.CoreId.ToString();
            cDetail.idVersion = "";
            cDetail.version = "";

            if (Aniovehiculo.Count() > 0)
                cDetail.idAnoVehiculo = Aniovehiculo.FirstOrDefault().Codigo.ToString();

            cDetail.anoVehiculo = vehicleYear.ToString();
            cDetail.idUso = usage.ToString();

            if (Storage.Count() > 0)
                cDetail.idEstacionaEn = Storage.FirstOrDefault().Codigo.ToString();

            cDetail.idColor = "";
            cDetail.color = "";
            cDetail.idCapacidad = idCapacidad.ToString();
            cDetail.capacidad = descCapacidad;

            cDetail.fechaInicio = startDatetime.GetValueOrDefault().Date;
            cDetail.fechaFin = endDatetime.Date;

            /*Actualziacion de fecha de vencimiento en base a 6 meses*/
            if (isSemifull.Contains("(6 Meses)")
                || isSemifull.Contains("( 6 Meses )")
                || isSemifull.Contains("( 6 Meses)")
                || isSemifull.Contains("(6 Meses )")
                )
            {
                var dateStart = startDatetime;
                DateTime newEndDate = dateStart.GetValueOrDefault().AddMonths(6);
                cDetail.fechaFin = newEndDate.Date;
                cDetail.fechaInicio = startDatetime.GetValueOrDefault().Date;
            }

            //si es de ley no lleva deducible
            if (!Esdeley)
            {
                if (Deductible.Count() > 0 && Deductible.FirstOrDefault().Codigo != null & Deductible.FirstOrDefault().Descripcion != null)
                {
                    cDetail.iddeducible = Deductible.FirstOrDefault().Codigo.ToString();
                    cDetail.deducible = Deductible.FirstOrDefault().Descripcion.ToString();
                }
                else
                {
                    cDetail.iddeducible = "0";
                    cDetail.deducible = "";
                }
            }

            cDetail.compania = cod_company;

            var quantityOfMonth = Utility.QuantityOfMonth(cDetail.fechaInicio.Value, cDetail.fechaFin.Value);
            cDetail.cantidadMeses = quantityOfMonth == 0 ? 1 : quantityOfMonth;// 12;

            cDetail.codigoTarifa = 1;
            cDetail.categoria = "";
            cDetail.tipoVehiculo = Type.VehicleTypeDesc;
            cDetail.marcaVehiculo = Marca.name;
            cDetail.modeloVehiculo = model.Name;
            cDetail.uso = usagename;
            cDetail.estacionaEn = Storage.Count() > 0 ? Storage.FirstOrDefault().Descripcion : storageName;
            cDetail.renovacionAutomatica = "S";
            cDetail.usuario = "POS-" + GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "";
            cDetail.estatus = "ACTIVO";
            cDetail.porciendoCobertura = coveragePercent.ToString();

            cDetail.PorcientoRecargoVentas = percentSurCharge.GetValueOrDefault();
            bool foreingLicence = PrincipalDriver.ForeignLicense.GetValueOrDefault();

            if (gender == "Empresa")
            {
                var foreingLicenceParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_FOREIGNLICENSE").Value;
                bool.TryParse(foreingLicenceParam, out foreingLicence);
            }

            cDetail.licenciaExtranjera = foreingLicence;

            var genderId = 1;

            if (gender == "Femenino")
                genderId = 2;

            DateTime birthday = DateTime.Now;
            int age = 0;

            if (gender == "Empresa")
            {
                var genderParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_SEX").Value;
                int genderCompany = 0;
                int.TryParse(genderParam, out genderCompany);

                if (genderCompany > 0)
                {
                    genderId = genderCompany;
                    gender = "N/A";
                }

                var ageParam = oDropDownManager.GetParameter("PARAMETER_KEY_COMPANY_DEFAULT_AGE").Value;
                int ageCompany = 0;
                int.TryParse(ageParam, out ageCompany);

                if (ageCompany > 0)
                    age = 0;
            }
            else
            {
                birthday = PrincipalDriver.DateOfBirth;
                age = Utility.GetAge(birthday);
            }

            var paramSex = new WsProxy.SysflexService.PolicySexoEdadKeyParameter();
            paramSex.Sexo = gender;
            paramSex.Edad = age.ToString();
            paramSex.RamoID = ramo;
            paramSex.subramo = coverageCoreId;

            var resultSexoEdad = oCoreProxy.GetSexoEdad(paramSex);
            var sexage = !string.IsNullOrEmpty(resultSexoEdad) ? resultSexoEdad : null;
            cDetail.sexoEdad = sexage;

            cDetail.idTipoCombustible = fuelTypeId.ToString();
            cDetail.tipoCombustible = fuelTypeDesc;

            success = false;

            try
            {
                //Inserto el detalle de la cotizacion
                var output = oCoreProxy.GetRates_New(cDetail, out statusMessages);

                /*inserto las cobeturas del vehiculo actual*/
                if (!string.IsNullOrEmpty(limitself))
                {
                    List<Entity.Entities.WSEntities.CoverageJsonClass> selfAndThirdCoverage = new List<Entity.Entities.WSEntities.CoverageJsonClass>();

                    var self = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageJsonClass>>(limitself);

                    if (self != null)
                        foreach (var st in self.ToList())
                            selfAndThirdCoverage.Add(st);

                    List<Entity.Entities.WSEntities.CoverageJsonClass> ServiceCoverage = new List<Entity.Entities.WSEntities.CoverageJsonClass>();

                    if (!string.IsNullOrEmpty(Services) && Services != "[]")
                    {
                        var serviceCov = JsonConvert.DeserializeObject<List<Entity.Entities.WSEntities.CoverageJsonClass>>(Services);

                        if (serviceCov != null)
                        {
                            foreach (var ser in serviceCov.ToList())
                            {
                                Entity.Entities.WSEntities.CoverageJsonClass servicesActual = new Entity.Entities.WSEntities.CoverageJsonClass();
                                servicesActual.CoverageDetailCoreId = ser.CoverageDetailCoreId;
                                servicesActual.Name = ser.Name;
                                servicesActual.Limit = ser.Limit;
                                servicesActual.isSelected = ser.isSelected;
                                ServiceCoverage.Add(servicesActual);
                            }
                        }
                    }

                    oCoreProxy.SetCoverageVehicle_GetRate_NewPV(selfAndThirdCoverage, ServiceCoverage, Convert.ToDecimal(quotationCore), secuencia, cod_company, out statusMessages);
                    //Inserto otra vez el detalle de manera que se actualize con los cambios de las coberturas
                    output = oCoreProxy.GetRates_New(cDetail, out statusMessages);
                }

                if (statusMessages.Count() > 0)
                {
                    string realMessage = "";
                    foreach (var stmsg in statusMessages)
                        realMessage += "\n" + stmsg;

                    LoggerHelper.Log(CommonEnums.Categories.Error, UserIdentityName, base.QuotationId, "Error al obtener la prima", "Mensaje: " + " QuotationID: " + QuotationNumber + " " + realMessage, null);
                    throw new Exception("Error al obtener la Prima.");
                }
                success = true;
                return Json(new { output = output, IsLawProduct = Esdeley, quotationCore = quotationCore }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (statusMessages.Count() > 0)
                {
                    string realMessage = "";
                    foreach (var stmsg in statusMessages)
                        realMessage += "\n" + stmsg;
                    LoggerHelper.Log(CommonEnums.Categories.Error, UserIdentityName, base.QuotationId, "Error al obtener la prima", "Mensaje: " + " QuotationID: " + QuotationNumber + " " + realMessage, null);
                }
                success = false;
                throw ex;
            }
            #endregion
        }

        public JsonResult GetPercentByQtyVehicle(int qtyVehicles)
        {
            //List<decimal> lvalues = new List<decimal>();

            if (qtyVehicles > 0)
            {
                var jsonParam = oDropDownManager.GetParameter("PARAMETER_KEY_PERCENT_FLOTILLA_DISCOUNT").Value;
                decimal percentParam = 0;

                var json = JsonConvert.DeserializeObject<List<Utility.Percent_Flotilla_Discount>>(jsonParam);

                foreach (var qty in json)
                {
                    if (qtyVehicles >= qty.From && qtyVehicles <= qty.To)
                    {
                        percentParam = (qty.Porc * 100);

                        //lvalues.Add(percentParam);
                        //return Json(lvalues, JsonRequestBehavior.AllowGet);
                        return Json(percentParam, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getQuotedDays()
        {
            var qid = base.QuotationId;
            var qdata = base.getQuotationData(qid);

            if (qdata != null)
            {
                var stdate = qdata.StartDate.GetValueOrDefault().Date < DateTime.Now.Date ? DateTime.Now : qdata.StartDate;
                var DiasCotizados = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, stdate.GetValueOrDefault().Date, qdata.EndDate.GetValueOrDefault().Date);

                return Json(DiasCotizados, JsonRequestBehavior.AllowGet);
            }
            return Json(365, JsonRequestBehavior.AllowGet);
        }
    }
}