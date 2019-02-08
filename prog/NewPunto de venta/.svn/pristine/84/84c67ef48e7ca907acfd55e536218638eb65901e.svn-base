using Entity.Entities;
using Newtonsoft.Json;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public class CotizarRenovacionController : BaseController
    {
        // GET: CotizarRenovacion
        public ActionResult CotizarRenovacion(bool isFromHistory)
        {
            IsAQuotation = false;

            base.onlyLoggedUsers = allowOnlyLoggedUsers();

            base.RequestType = CommonEnums.RequestType.PropuestaRecuperacion;
            ViewBag.isSearchVisible = true;

            var LoadQuotation = this.QuotationId > 0;
            if (isFromHistory && LoadQuotation)
            {
                var quotData = getQuotationData(this.QuotationId);
                ViewBag.PolicyNoMain = quotData.policyNoMain;
                QuotationNumber = quotData.QuotationNumber;

                var dr = getDriverData(this.QuotationId);

                ViewBag.DriverID = dr.FirstOrDefault(x => x.IsPrincipal).Id;
                ViewBag.isSearchVisible = false;
            }

            return PartialView("_LoadInfoRenovacion");
        }

        public JsonResult GetBasicDataCustomerFromPolicy(string PolicyNumber)
        {
            JsonResult result = null;
            var DataCoreCustomer = oCoreProxy.GetClienteFromPoliza(PolicyNumber);

            if (DataCoreCustomer != null)
            {
                Entity.Entities.WSEntities.AgentTreeInfoNewWS userAgenCode = null;
                bool IsvalidAgent = true;
                var CheckPolicy = oCoreProxy.GetVehiculosFromPoliza(PolicyNumber);
                var isActivePolicy = true;

                /*
                var isActivePolicy = CheckPolicy.Any() ? CheckPolicy.FirstOrDefault().EstatusPoliza == "ACTIVO" : false;

                if (!isActivePolicy)
                    result = Json(new { code = "003", msg = string.Format("La poliza \"{0}\" no esta Activa", PolicyNumber) }, JsonRequestBehavior.AllowGet);
                */

                if (isActivePolicy)
                {
                    //Si es un agente el que se loguea validar que el agente del cliente este en su cadena
                    if (base.onlyLoggedUsers)
                    {
                        userAgenCode = GetAgentInfo(DataCoreCustomer.Intermediario.ToString());
                        if (userAgenCode != null)
                        {
                            var AgentList = GetAgentsChain().Select(x => x.FullNameAll.ToString());
                            IsvalidAgent = AgentList.Contains(userAgenCode.FullNameAll);
                            result = Json(new
                            {
                                DataCoreCustomer = DataCoreCustomer,
                                userAgenCode = userAgenCode,
                                IsvalidAgent = IsvalidAgent
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                            result = Json(new { code = "004", msg = "Usted no tiene cadena de agentes" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
                result = Json(new { code = "001", msg = string.Format("La poliza \"{0}\" no existe en nuestro Sistema", PolicyNumber) }, JsonRequestBehavior.AllowGet);

            return
                 result;
        }

        public JsonResult GetDataVehicleFromPolicy(string PolicyNumber, bool isFromHistory = false)
        {
            var DataCoreVehicle = oCoreProxy.GetVehiculosFromPolizaCanceladasProspecto(PolicyNumber);

            if (DataCoreVehicle.Count() <= 0 || DataCoreVehicle == null)
            {
                string msj = string.Format("Esta poliza \"{0}\" no aplica para este tipo de proceso", PolicyNumber);

                return
                Json(new
                {
                    DataCoreVehicle = "",
                    PolicyNumber = PolicyNumber,
                    Message = msj
                }, JsonRequestBehavior.AllowGet);
            }
            IEnumerable<VehicleProduct> allVehiclesSaved = null;

            string toNotExclude = "";

            if (isFromHistory)
            {
                allVehiclesSaved = oQuotationManager.GetQuotationVehicles(this.QuotationId);
                if (allVehiclesSaved.Count() > 0)
                {
                    toNotExclude = string.Join(",", allVehiclesSaved.Select(a => a.SecuenciaVehicleSysflex).ToArray());
                }
            }


            var newDataCoreVehicle = DataCoreVehicle.Select(x => new Entity.Entities.WSEntities.PolicyCanceladasProspectoVehicleWS()
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
                FechaFinString = x.FechaFin.GetValueOrDefault().ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Prima = x.Prima,
                ChasisId = x.ChasisId,
                ColorId = x.ColorId,
                PlacaId = x.PlacaId,

                SubramoNew = x.SubramoNew,
                DescripcionSubramoNew = x.DescripcionSubramoNew,
                PrimaBrutaNew = x.PrimaBrutaNew,
                primaproratadiasinimpuestosNew = x.primaproratadiasinimpuestosNew,
                TipoPolizaDescripcionNew = x.TipoPolizaDescripcionNew,
                Secuenciamov = x.Secuenciamov,
                conceptomovimiento = x.conceptomovimiento,
                TipoPolizaNew = x.TipoPolizaNew,

                vehicleId =
                isFromHistory
                ?
               (
               (allVehiclesSaved.FirstOrDefault(a => a.SecuenciaVehicleSysflex == x.Item) != null)
                ?
                allVehiclesSaved.FirstOrDefault(a => a.SecuenciaVehicleSysflex == x.Item).Id
                :
                null
               )
                :
                null,

                TipoCombustible = x.TipoCombustible,
                IdTipoCombustible = x.IdTipoCombustible,
                Capacidad = x.Capacidad,
                IdCapacidad = x.IdCapacidad,
                PorcientoRecargoVenta = x.PorcientoRecargoVenta,

            }).ToList();

            return
                Json(new
                {
                    DataCoreVehicle = newDataCoreVehicle,
                    PolicyNumber = PolicyNumber,
                    Message = "",
                    QuotationNumber = QuotationNumber,
                    toNotExclude = toNotExclude
                }, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<Entity.Entities.WSEntities.AgentTreeInfoNewWS> GetAgentsChain()
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

        public ActionResult VehicleData(string dataVehicle)
        {
            //var dataVh = JsonConvert.DeserializeObject<List<CustomCode.Utility.CotizarRenovacionData>>(dataVehicle); 
            var dataVh = JsonConvert.DeserializeObject<CustomCode.Utility.CotizarRenovacionData>(dataVehicle);

            ViewBag.dataVehicle = dataVehicle;

            return PartialView("_VehicleData", dataVh);
        }

        public JsonResult SaveDataCotizarReno(string jsoVhnData, string jsonQtData)
        {
            //Guardando la informacion 
            var result = SetQuotationData(jsonQtData);

            int quotationID = result.Item1;//ID Cotizacion
            int driverID = result.Item2;//Id Conductor
            bool tienelicenciaExtranjera = result.Item3;//tienelicenciaExtranjera;
            int secuenciaMov = 0;
            decimal coreQuotationNumber = 0;

            List<object> matchDinamicVehicleWithCreated = new List<object>();
            string dic = "";
            try
            {
                var newVehicles = JsonConvert.DeserializeObject<List<dynamic>>(jsoVhnData);

                decimal percentISC = 16;
                decimal PercentByQtyVehicle = 0;
                decimal TotalByQtyVehicle = 0;

                var realVehicleQty = newVehicles.Select(x => (int)x.VehicleQuantity).Cast<int>().ToList();
                var realVehicleQty_Sum = realVehicleQty.Sum();

                var tp = newVehicles.Select(x => (decimal)x.totalPrime * (decimal)x.VehicleQuantity).Cast<decimal>().ToList();
                decimal totalVehiclesPrime = tp.Sum();

                string[] arr = new[] { "DE LEY", "ULTRA" };

                List<bool> allLawProdcts = new List<bool>();

                foreach (var vehicle in newVehicles)
                {
                    #region Vehicle

                    var Makes = oDropDownManager.GetDropDown(CommonEnums.DropDownType.BRANDS.ToString()).Select(x => new Generic()
                    {
                        name = !string.IsNullOrEmpty(x.name) ? x.name.ToLower().TrimStart().TrimEnd() : "",
                        Value = x.Value
                    });
                    int realMakeID = 0;
                    int realModelID = 0;

                    if (Makes.Any())
                    {
                        string realMakeName = !string.IsNullOrEmpty(vehicle.vehicleMakeName.ToString()) ? vehicle.vehicleMakeName.ToString().ToLower().TrimStart().TrimEnd() : "";
                        var r = Makes.FirstOrDefault(a => a.name == realMakeName);
                        if (r != null)
                        {
                            realMakeID = r.Value.ToInt();
                            var Models = oDropDownManager.GetVehicleModels(realMakeID).Select(x => new VehicleModel()
                            {
                                CoreId = x.CoreId,
                                Id = x.Id,
                                Name = !string.IsNullOrEmpty(x.Name) ? x.Name.ToLower().TrimStart().TrimEnd() : ""
                            });

                            if (Models.Any())
                            {
                                int w = vehicle.vehicleModel_Model_Id;
                                var mr = Models.FirstOrDefault(x => x.CoreId == w);
                                if (mr != null)
                                {
                                    realModelID = mr.Id;
                                }
                                else
                                {
                                    string modelodesc = !string.IsNullOrEmpty(vehicle.ModeloDesc.ToString()) ? vehicle.ModeloDesc.ToString().ToLower().TrimStart().TrimEnd() : "";
                                    var mr2 = Models.FirstOrDefault(x => x.Name == modelodesc);
                                    if (mr2 != null)
                                    {
                                        realModelID = mr2.Id;
                                    }
                                }
                            }
                        }
                    }


                    VehicleProduct.Parameter vparam = new VehicleProduct.Parameter();
                    vparam.id = vehicle.id != null ? vehicle.id : null;
                    vparam.vehicleDescription = vehicle.vehicleDescription;
                    vparam.year = vehicle.Year;
                    vparam.vehiclePrice = vehicle.VehiclePrice;
                    vparam.insuredAmount = vehicle.insuredAmount;
                    vparam.percentageToInsure = vehicle.percentageToInsure;
                    vparam.totalPrime = vehicle.totalPrime;
                    vparam.totalIsc = vehicle.totalIsc;
                    vparam.totalDiscount = 0;
                    vparam.selectedProductCoreId = vehicle.selectedProductCoreId;
                    var vtCore = oDropDownManager.GetVehicleTypes((int?)realMakeID, (int?)realModelID).FirstOrDefault();
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
                    vparam.driver_Id = driverID;
                    vparam.vehicleModel_Make_Id = realMakeID;
                    vparam.vehicleModel_Model_Id = realModelID;
                    vparam.quotation_Id = quotationID;

                    vparam.selectedVehicleTypeId = vehicle.selectedVehicleTypeId;
                    vparam.selectedVehicleTypeName = vehicle.selectedVehicleTypeName;
                    vparam.selectedCoverageCoreId = vehicle.selectedCoverageCoreId;
                    vparam.selectedCoverageName = vehicle.selectedCoverageName;
                    vparam.vehicleYearOld = vehicle.vehicleYearOld;
                    vparam.surChargePercentage = (vehicle.surChargePercentage == 0) ? 0 : vehicle.surChargePercentage;
                    vparam.numeroFormulario = null;

                    var rjson = createRateJson
                        (
                        Convert.ToInt32(vehicle.IdMarca),
                        vparam.usageId.GetValueOrDefault(),
                        vparam.selectedVehicleTypeId.GetValueOrDefault(),
                        Convert.ToInt32(vehicle.Idano),
                        Convert.ToInt32(vehicle.SelectedDeductibleCoreId),
                        vparam.storeId.GetValueOrDefault(),
                        Convert.ToInt32(vehicle.Idmodelo),
                        Convert.ToInt32(vehicle.IdCapacidad),
                        vehicle.Capacidad.ToString(),
                        Convert.ToDecimal(vehicle.PorcientoRecargoVenta),
                        tienelicenciaExtranjera,
                        Convert.ToInt32(vehicle.IdTipoCombustible),
                        vehicle.TipoCombustible.ToString()
                        );

                    vparam.rateJson = rjson;


                    vparam.userId = GetCurrentUserID();
                    vparam.secuenciaVehicleSysflex = vehicle.secuenciaVehicleSysflex;
                    vparam.isFacultative = vehicle.isFacultative;
                    vparam.amountFacultative = vehicle.amountFacultative;
                    vparam.vehicleQuantity = vehicle.VehicleQuantity;
                    vparam.ProratedPremium = 0;
                    vparam.SelectedVehicleFuelTypeId = Convert.ToInt32(vehicle.IdTipoCombustible);
                    vparam.SelectedVehicleFuelTypeDesc = vehicle.TipoCombustible.ToString();

                    vparam.chassis = vehicle.chassis;
                    vparam.plate = vehicle.plate;
                    vparam.color = vehicle.color;

                    //Llamar el metodo que guarda o modifica los datos del vehiculo          
                    var vehicleSaved = oVehicleProductManager.SetVehicleProduct(vparam);

                    var currentVehicleID = vehicleSaved.EntityId;

                    //if (arr.Contains(vparam.selectedProductName.Trim()))
                    //{
                    //    allLawProdcts.Add(true);
                    //}
                    //else
                    //{
                    //    allLawProdcts.Add(false);
                    //}

                    #region ProductsLimits                   

                    //Borrado masivo de coverturas y productlimits
                    oVehicleProductManager.DeleteVehicleProductCoveragesServices(currentVehicleID, false);
                    //

                    decimal sumServicesPrime = 0;
                    decimal sumTpPrime = 0;
                    decimal sumSdPrime = 0;
                    List<WsProxy.SysflexService.PolicyPolicyCoverages> allServicesCoverages = null;
                    List<WsProxy.SysflexService.PolicyPolicyCoverages> allThirdDamageCoverages = null;
                    List<WsProxy.SysflexService.PolicyPolicyCoverages> allSelfDamageCoverages = null;

                    secuenciaMov = vehicle.secuenciaMov;
                    coreQuotationNumber = vehicle.coreQuotationNumber;
                    int secuenciaVehicleSysflex = vehicle.secuenciaVehicleSysflex;

                    WsProxy.SysflexService.PolicyPolicyCoverages[] allCoverages = oCoreProxy.GetPolizaCoberturasMovCanceladaProspecto(coreQuotationNumber, secuenciaVehicleSysflex, secuenciaMov);

                    allCoverages = allCoverages.Select(y =>
                    {
                        y.tipoCobertura = !string.IsNullOrEmpty(y.tipoCobertura) ? y.tipoCobertura.ToLower() : "";

                        return y;
                    }).ToArray();

                    if (allCoverages.Count() > 0)
                    {
                        sumServicesPrime = allCoverages.Where(x => x.tipoCobertura == "servicios" && x.TieneCobertura == "S").Sum(x => x.PrimaNew.GetValueOrDefault());
                        sumTpPrime = allCoverages.Where(x => x.tipoCobertura == "daños a terceros" && x.TieneCobertura == "S").Sum(x => x.PrimaNew.GetValueOrDefault());
                        sumSdPrime = allCoverages.Where(x => x.tipoCobertura == "daños propios" && x.TieneCobertura == "S").Sum(x => x.PrimaNew.GetValueOrDefault());


                        allServicesCoverages = allCoverages.Where(x => x.tipoCobertura == "servicios" && x.TieneCobertura == "S").ToList();
                        allSelfDamageCoverages = allCoverages.Where(x => x.tipoCobertura == "daños propios" && x.TieneCobertura == "S").ToList();
                        allThirdDamageCoverages = allCoverages.Where(x => x.tipoCobertura == "daños a terceros" && x.TieneCobertura == "S").ToList();
                    }

                    //

                    ProductLimits.Parameter prodParam = new ProductLimits.Parameter();
                    prodParam.id = null;
                    prodParam.vehicleProduct_Id = currentVehicleID;
                    prodParam.isSelected = true;//productLimitSet.IsSelected;
                    prodParam.totalIsc = vehicle.TotalIsc;
                    prodParam.totalDiscount = vehicle.TotalDiscount;
                    prodParam.totalPrime = vehicle.TotalPrime;
                    prodParam.servicesPrime = sumServicesPrime;
                    prodParam.tpPrime = sumTpPrime;
                    prodParam.sdPrime = sumSdPrime;
                    prodParam.selectedDeductibleCoreId = vehicle.SelectedDeductibleCoreId;
                    prodParam.selectedDeductibleName = vehicle.SelectedDeductibleName;
                    prodParam.userId = GetCurrentUserID();
                    var productLimitSaved = oProductLimitsManager.SetProudctLimits(prodParam);
                    var currentProductLimit = productLimitSaved.EntityId;


                    #region Services

                    List<string> headers = new List<string>();
                    BaseEntity serviceTypeSaved = new BaseEntity();

                    //Si hay servicios seleccionados
                    if (allServicesCoverages.Count() > 0)
                    {
                        foreach (var sc in allServicesCoverages)
                        {
                            if (!headers.Contains(sc.GrupoServicios))
                            {
                                ServicesTypes.Parameter stParam = new ServicesTypes.Parameter();
                                stParam.id = null;
                                stParam.servicesTypesToProductLimits = currentProductLimit;
                                stParam.name = sc.GrupoServicios;
                                stParam.userId = GetCurrentUserID();
                                serviceTypeSaved = oServicesTypesRepositoryManager.SetServiceType(stParam);

                                headers.Add(sc.tipoCobertura);
                            }

                            var currentServiceType = serviceTypeSaved.EntityId;

                            #region SE Coverages

                            Coverage.Parameter scParam = new Coverage.Parameter();

                            decimal realLimitSer = 0;
                            string MontoInformativo = sc.MontoInformativo.Replace(",", "");
                            decimal.TryParse(MontoInformativo, out realLimitSer);

                            scParam.id = null;
                            scParam.isSelected = true;
                            scParam.coverageDetailCoreId = sc.Secuencia;
                            scParam.name = sc.Descripcion;

                            scParam.amount = sc.PrimaNew;
                            scParam.limit = realLimitSer;

                            scParam.minDeductible = sc.MinimoDeducible.HasValue ? sc.MinimoDeducible.Value : 0;
                            scParam.deductible = sc.PorcDeducible.HasValue ? sc.PorcDeducible.Value : 0;
                            scParam.selfDamagesToProductLimits = null;
                            scParam.thirdPartyToProductLimits = null;
                            scParam.serviceType_Id = currentServiceType;
                            scParam.userId = GetCurrentUserID();
                            scParam.coveragePercentage = sc.PorcCobertura;

                            scParam.baseDeductible = sc.BaseDeducible;
                            scParam.allowsToSummarize = sc.PermiteSumarizar;

                            oCoverageManager.SetCoverageDetail(scParam);

                        }
                    }
                    else
                    {
                        List<WsProxy.SysflexService.PolicyPolicyCoverages> NoServicesCoverages = allCoverages.Where(x => x.tipoCobertura == "Servicios" && x.TieneCobertura == "N").ToList();
                        foreach (var sc in NoServicesCoverages)
                        {
                            if (!headers.Contains(sc.GrupoServicios))
                            {
                                ServicesTypes.Parameter stParam = new ServicesTypes.Parameter();
                                stParam.id = null;
                                stParam.servicesTypesToProductLimits = currentProductLimit;
                                stParam.name = sc.GrupoServicios;
                                stParam.userId = GetCurrentUserID();
                                serviceTypeSaved = oServicesTypesRepositoryManager.SetServiceType(stParam);

                                headers.Add(sc.tipoCobertura);
                            }
                        }
                    }
                    #endregion                   

                    #endregion

                    #region Self Damage Coverages

                    Coverage.Parameter sdParam = new Coverage.Parameter();

                    if (allSelfDamageCoverages.Count() > 0)
                    {
                        foreach (var sdc in allSelfDamageCoverages)
                        {
                            sdParam = new Coverage.Parameter();

                            decimal realLimit = 0;
                            string MontoInformativo = sdc.MontoInformativo.Replace(",", "");
                            decimal.TryParse(MontoInformativo, out realLimit);

                            sdParam.id = null;
                            sdParam.isSelected = false;
                            sdParam.coverageDetailCoreId = sdc.Secuencia;
                            sdParam.name = sdc.Descripcion;
                            sdParam.amount = realLimit;
                            sdParam.limit = realLimit;
                            sdParam.minDeductible = sdc.MinimoDeducible.HasValue ? sdc.MinimoDeducible.Value : 0;
                            sdParam.deductible = sdc.PorcDeducible.HasValue ? sdc.PorcDeducible.Value : 0;
                            sdParam.selfDamagesToProductLimits = currentProductLimit;
                            sdParam.thirdPartyToProductLimits = null;
                            sdParam.serviceType_Id = null;
                            sdParam.userId = GetCurrentUserID();
                            sdParam.coveragePercentage = sdc.PorcCobertura;

                            sdParam.baseDeductible = sdc.BaseDeducible;
                            sdParam.allowsToSummarize = sdc.PermiteSumarizar;

                            oCoverageManager.SetCoverageDetail(sdParam);
                        }
                    }

                    #endregion

                    #region Third Party Coverages

                    Coverage.Parameter tpParam = new Coverage.Parameter();

                    if (allThirdDamageCoverages.Count() > 0)
                    {
                        foreach (var tpc in allThirdDamageCoverages)
                        {
                            tpParam = new Coverage.Parameter();

                            decimal realLimit = 0;
                            string MontoInformativo = tpc.MontoInformativo.Replace(",", "");
                            decimal.TryParse(MontoInformativo, out realLimit);

                            tpParam.id = null;
                            tpParam.isSelected = false;
                            tpParam.coverageDetailCoreId = tpc.Secuencia;
                            tpParam.name = tpc.Descripcion;
                            tpParam.amount = realLimit;
                            tpParam.limit = realLimit;
                            tpParam.minDeductible = tpc.MinimoDeducible.HasValue ? tpc.MinimoDeducible.Value : 0;
                            tpParam.deductible = tpc.PorcDeducible.HasValue ? tpc.PorcDeducible.Value : 0;
                            tpParam.selfDamagesToProductLimits = null;
                            tpParam.thirdPartyToProductLimits = currentProductLimit;
                            tpParam.serviceType_Id = null;
                            tpParam.userId = GetCurrentUserID();
                            tpParam.coveragePercentage = tpc.PorcCobertura;

                            tpParam.baseDeductible = tpc.BaseDeducible;
                            tpParam.allowsToSummarize = tpc.PermiteSumarizar;

                            oCoverageManager.SetCoverageDetail(tpParam);
                        }
                    }
                    #endregion

                    #endregion

                    #endregion
                }

                PercentByQtyVehicle = getFlotillaPercentByQty(realVehicleQty_Sum);

                //Actualizando la cotizacion con los totales de prima
                Quotation.parameter qparam = new Quotation.parameter();
                qparam.id = quotationID;

                qparam.totalISC = (totalVehiclesPrime * (percentISC / 100));
                qparam.totalPrime = totalVehiclesPrime;

                var prod = GetQuotationProduct(quotationID);
                qparam.quotationProduct = prod == "Flotilla" ? "Varios" : prod;

                qparam.flotillaDiscountPercent = PercentByQtyVehicle;
                qparam.totalFlotillaDiscount = totalVehiclesPrime * (PercentByQtyVehicle / 100);

                qparam.secuenciaMov = secuenciaMov;
                qparam.quotationCoreNumber = coreQuotationNumber.ToString();

                var getquo = oQuotationManager.GetQuotation(quotationID);
                if (getquo != null)
                {
                    qparam.monthlyPayment = getquo.MonthlyPayment;
                    qparam.financed = getquo.Financed;
                    qparam.period = getquo.Period;


                    QuotationId = getquo.Id.Value;
                    QuotationNumber = getquo.QuotationNumber;
                }

                //Si al menos hay un false, entonces hay otro producto que no es de ley
                //if (allLawProdcts.Contains(false))
                qparam.sendInspectionOnly = true;
                //else
                //    qparam.sendInspectionOnly = false;

                isNotLawProduct = qparam.sendInspectionOnly.GetValueOrDefault();
                qparam.modi_UserId = GetCurrentUserID();

                if (!string.IsNullOrEmpty(base.RiskLevel))
                    qparam.RiskLevel = base.RiskLevel;

                oQuotationManager.SetQuotation(qparam);

                //var allVehicles = oQuotationManager.GetQuotationVehicles(QuotationId);

                //foreach (var v in allVehicles)
                //{
                //    var exist = newVehicles.FirstOrDefault(a => a.VehicleDescription == v.VehicleDescription);

                //    if (exist != null)
                //    {
                //        dynamic MyDynamic = new System.Dynamic.ExpandoObject(); // note, the type MUST be dynamic to use dynamic invoking.
                //        MyDynamic.randomId = Convert.ToInt32(exist.randomId);
                //        MyDynamic.vehicleID = v.Id.Value;
                //        MyDynamic.QuotationId = QuotationId;
                //        MyDynamic.QuotationNumber = QuotationNumber;
                //        MyDynamic.Driver = driverID;

                //        matchDinamicVehicleWithCreated.Add(MyDynamic);
                //    }
                //}

                //dic = JsonConvert.SerializeObject(matchDinamicVehicleWithCreated);
                //
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();

                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), quotationID, "Error al guardar el/los Vehiculos(s)", "Mensaje: " + ex.Message, ex);

                //devolmeos un mensaje de error
                return Json(new { MessageError = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { MessageSucess = "", QuotationId = QuotationId, QuotationNumber = QuotationNumber, showNextSection = true, VehicleDataMatch = dic, DriverId = driverID }, JsonRequestBehavior.AllowGet);
        }

        private Tuple<int, int, bool> SetQuotationData(string jsonQtData)
        {
            int quotationID = 0;
            int driverID = 0;
            bool tienelicenciaExtranjera = false;
            var agentNameId = oDropDownManager.GetParameter("PARAMETER_KEY_AGENT_NAME").Value;
            try
            {
                var form = JsonConvert.DeserializeObject<dynamic>(jsonQtData);

                quotationID = form.quotationID;

                var usuario = GetCurrentUsuario();
                Entity.Entities.WSEntities.AgentTreeInfoNewWS agent = null;

                if (form.agentSelected != null)
                {
                    agent = JsonConvert.DeserializeObject<Entity.Entities.WSEntities.AgentTreeInfoNewWS>(form.agentSelected.ToString());
                }

                bool isNewQuotation = quotationID == 0;
                var currDate = DateTime.Now;

                string Mask = oDropDownManager.GetParameter("PARAMETER_KEY_CREDIT_CARD_MASK").Value;
                string strCreditCardNumber = string.Empty;
                string msgValidationCreditCard = string.Empty;
                bool IsFinanced = false;

                #region Insertando Cotizacion en Pos_site
                Quotation.parameter param = new Quotation.parameter();
                param.id = quotationID;

                if (isNewQuotation)
                {
                    param.productNumber = "01";
                    param.businessLine_Id = 1;
                    param.cardnetPaymentStatus = CommonEnums.QuotationCardnetStatus.NotSent.ToInt();
                    isNewQuotation = true;

                    param.quotationDailyNumber = GetNewDailyQuotationNumber();
                    param.quotationNumber = param.productNumber + DateTime.Now.ToString("yyyyMMdd") + param.quotationDailyNumber.ToString().PadLeft(4, '0');

                    param.startDate = DateTime.Now.Date;
                    param.endDate = DateTime.Now.AddYears(1).Date;
                }
                else
                {
                    string startDate = form.StartDate;
                    string endDate = form.EndDate;
                    DateTime newDate = DateTime.Parse(startDate, CultureInfo.InvariantCulture);
                    if (newDate.TimeOfDay.TotalHours > 0)
                    {
                        param.startDate = newDate.Date;
                    }
                    else
                    {
                        param.startDate = newDate.Date;
                    }

                    DateTime newDateEnd = DateTime.Parse(endDate, CultureInfo.InvariantCulture);
                    if (newDateEnd.TimeOfDay.TotalHours <= 0)
                    {
                        param.endDate = newDateEnd.Date;
                    }
                    else
                    {
                        param.endDate = newDateEnd.Date;
                    }

                    if (param.startDate.Value.Date < DateTime.Now.Date)
                    {
                        throw new Exception("La Fecha Inicio de Vigencia no puede ser menor a la Fecha Actual.");
                    }

                    if (param.endDate.Value.Date < DateTime.Now.Date)
                    {
                        throw new Exception("La Fecha Fin de Vigencia no puede ser menor a la Fecha Actual.");
                    }
                }

                param.lastStepVisited = 1;

                if (isNewQuotation)
                {
                    param.paymentFrequencyId = null;
                    param.paymentFrequency = "N/A";
                    param.paymentWay = null;

                    param.currency_Id = 1;
                    param.currencySymbol = "RD$";

                    param.achAccountHolderGovId = null;
                    param.achBankRoutingNumber = null;
                    param.achName = string.Empty;
                    param.achNumber = null;
                    param.achType = 0;

                    param.iSCPercentage = 16;
                    param.discountPercentage = 0;
                    param.amountToPayEnteredByUser = 0;
                    param.sendInspectionOnly = true;
                    param.declined = false;
                    param.messaging = false;

                    param.financed = IsFinanced;
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
                }

                #region Usuarios Datos
                if (usuario == null)
                {
                    if (isNewQuotation)
                    {
                        param.user_Id = CheckUser(agentNameId, null, null, null);
                    }
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(agentNameId, null, null, null);
                        }
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant)
                {
                    if (agent != null)
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                        }
                    }
                }
                else if (usuario.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                {
                    param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email);
                }
                else //Agent
                {
                    if (agent != null)
                    {
                        param.user_Id = CheckUser(agent.NameId, agent.FullName, "", string.Empty, agent.AgentId);
                    }
                    else
                    {
                        var us = CheckQuotationHasUser(param.id.GetValueOrDefault());
                        if (us > 0)
                        {
                            param.user_Id = us;
                        }
                        else
                        {
                            param.user_Id = CheckUser(usuario.UserLogin, usuario.FirstName, usuario.LastName, usuario.Email, usuario.AgentId);
                        }
                    }
                }
                #endregion

                int qtyDayOfVigency = Utility.QuantityOfDays(param.startDate.Value, param.endDate.Value);
                param.qtyDayOfVigency = qtyDayOfVigency == 0 ? 365 : qtyDayOfVigency;// 365;

                param.status = 0;
                param.modi_UserId = GetCurrentUserID();
                param.RequestTypeId = CommonEnums.RequestType.PropuestaRecuperacion.ToInt();
                param.policy_No_Main = form.Poliza.ToString();

                param.isExternal = false;
                param.contactFormId = 0;

                if (!string.IsNullOrEmpty(base.RiskLevel))
                    param.RiskLevel = base.RiskLevel;

                var quotSaved = oQuotationManager.SetQuotation(param);
                quotationID = quotSaved.EntityId;

                #endregion


                //Buscando la info del cliente
                WsProxy.SysflexService.Policyinclusioncontact clientInfor = oCoreProxy.GetClienteFromPoliza(form.Poliza.ToString());
                //

                #region Person/Driver

                Person.PersonParameters pers = new Person.PersonParameters();
                pers.id = form.driverId > 0 ? form.driverId : (int?)null;
                pers.isPrincipal = true;

                pers.firstName = clientInfor.Nombre;
                pers.firstSurname = clientInfor.Apellidos;
                pers.sex = clientInfor.Sexo;
                pers.foreignLicense = clientInfor.Licencia_Extranjera == "Si" ? true : false;

                tienelicenciaExtranjera = (clientInfor.Licencia_Extranjera == "Si");

                string identf = !string.IsNullOrEmpty(clientInfor.IdentificationType.ToString()) ? clientInfor.IdentificationType : "";

                if (!string.IsNullOrEmpty(clientInfor.FechaNacimiento.ToString()) && identf != "RNC")
                {
                    pers.dateOfBirth = Convert.ToDateTime(clientInfor.FechaNacimiento, CultureInfo.InvariantCulture);
                }
                else
                {
                    pers.dateOfBirth = new DateTime(1753, 01, 01);//FEcha por default cuando sea rnc que podria venir vacio
                }
                pers.identificationType = identf;

                string[] ident = new string[] { "Cédula", "Licencia", "RNC" };

                if (!string.IsNullOrEmpty(clientInfor.RNC.ToString()) && ident.Contains(identf))
                {
                    pers.identificationNumber = clientInfor.RNC.ToString().Replace("-", "");
                }
                else
                {
                    pers.identificationNumber = clientInfor.RNC.ToString();
                }

                pers.phoneNumber = clientInfor.TelefonoResidencia;
                pers.mobile = clientInfor.Celular;
                pers.workPhone = clientInfor.TelefonoOficina;
                pers.email = clientInfor.Email;
                pers.invoiceTypeId = clientInfor.Ncf;
                pers.address = clientInfor.Direccion;

                /*Poner la ciudad por default*/
                var city = oDropDownManager.GetDropDown(CommonEnums.DropDownType.DEFAULTCITY.ToString()).FirstOrDefault();
                var keyCity = city.Value.Split('-');
                if (keyCity.Count() > 2)
                {
                    pers.country_Id = 129;
                    pers.domesticreg_Id = keyCity[0].ToInt();
                    pers.state_Prov_Id = keyCity[1].ToInt();
                    pers.city_Id = keyCity[3].ToInt();
                }

                int? ubicationID = clientInfor.Ubicacion;
                if (ubicationID.HasValue)
                {
                    var dataUbication = oPersonManagerManager.GetPersonCountryUbicationByUbicationSysflex(ubicationID.Value);
                    if (dataUbication.Count() > 0)
                    {
                        pers.country_Id = dataUbication.FirstOrDefault().Country_Id;
                        pers.domesticreg_Id = dataUbication.FirstOrDefault().Domesticreg_Id;
                        pers.state_Prov_Id = dataUbication.FirstOrDefault().State_Prov_Id;
                        pers.city_Id = dataUbication.FirstOrDefault().City_Id;
                    }
                }

                pers.userId = GetCurrentUserID();
                var personSaved = oPersonManagerManager.SetPerson(pers);
                driverID = personSaved.EntityId;

                Driver.parameters dri = new Driver.parameters();
                dri.accidentsLast3Years = null;
                dri.yearsDriving = null;
                dri.userId = GetCurrentUserID();
                dri.quotationId = quotSaved.EntityId;
                dri.id = personSaved.EntityId;
                var driverSaved = oDriverManager.SetDriver(dri);

                var currentDriverSaved = oQuotationManager.GetQuotationDrivers(quotationID);
                Driver PrincipalDriver = new Driver();
                if (currentDriverSaved != null)
                {
                    PrincipalDriver = currentDriverSaved.FirstOrDefault(x => x.IsPrincipal);
                }

                #endregion

                #region Actualizando Cotizacion con los datos de sysflex

                Quotation.parameter UpdParam = new Quotation.parameter();
                UpdParam.id = quotationID;

                UpdParam.principalFullName = PrincipalDriver.FirstName.Trim() + (!string.IsNullOrEmpty(PrincipalDriver.FirstSurname) ? " " + PrincipalDriver.FirstSurname.Trim() : "");
                UpdParam.principalIdentificationNumber = PrincipalDriver.IdentificationNumber;

                UpdParam.quotationCoreNumber = null;

                UpdParam.modi_UserId = GetCurrentUserID();

                //set risklevel
                if (!string.IsNullOrEmpty(base.RiskLevel))
                    UpdParam.RiskLevel = base.RiskLevel;

                oQuotationManager.SetQuotation(UpdParam);

                #endregion

            }
            catch (Exception ex)
            {
                var user = GetCurrentUsuario();

                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (user != null ? user.UserLogin : "VentaDirecta"), quotationID, "Error al guardar nueva cotización", "Mensaje: " + ex.Message, ex);

                //devolmeos un mensaje de error
                //return Json(new { messageError = "Error al guardar nueva cotización" }, JsonRequestBehavior.AllowGet);
            }

            //string quotationIdEncript = Utility.Encode(QuotationId.ToString());

            //return Json(new { MessageSucess = "", QuotationId = ViewBag.QuotationID, QuotationNumber = ViewBag.QuotationNumber, showNextSection = true, quotationIdEncript = quotationIdEncript }, JsonRequestBehavior.AllowGet);

            return new Tuple<int, int, bool>(quotationID, driverID, tienelicenciaExtranjera);
        }

        private int GetNewDailyQuotationNumber()
        {
            var nextQ = oDropDownManager.GetDropDown(CommonEnums.DropDownType.NEXTQUOTATION.ToString());

            if (nextQ.Count() > 0)
                return nextQ.FirstOrDefault().Value.ToInt() + 1;
            else
                return 0;
        }

        public string GetQuotationProduct(int quotationID)
        {
            var data = oQuotationManager.GetQuotationVehicles(quotationID);

            if (data.Count() > 0)
            {
                var prods = data.Select(c => c.SelectedProductName).Distinct();

                if (prods.Count() > 1)
                    return "Flotilla";
                else
                    return prods.First();
            }
            else
                return string.Empty;
        }

        public JsonResult GetQuotationData(string PolicyNumber)
        {
            JsonResult result = null;
            var DataCoreCustomer = oCoreProxy.GetClienteFromPoliza(PolicyNumber);

            if (DataCoreCustomer != null)
            {
                Entity.Entities.WSEntities.AgentTreeInfoNewWS userAgenCode = null;
                bool IsvalidAgent = true;
                var CheckPolicy = oCoreProxy.GetVehiculosFromPoliza(PolicyNumber);
                var isActivePolicy = true;

                /*
                var isActivePolicy = CheckPolicy.Any() ? CheckPolicy.FirstOrDefault().EstatusPoliza == "ACTIVO" : false;

                if (!isActivePolicy)
                    result = Json(new { code = "003", msg = string.Format("La poliza \"{0}\" no esta Activa", PolicyNumber) }, JsonRequestBehavior.AllowGet);
                */

                if (isActivePolicy)
                {
                    //Si es un agente el que se loguea validar que el agente del cliente este en su cadena
                    if (base.onlyLoggedUsers)
                    {
                        userAgenCode = GetAgentInfo(DataCoreCustomer.Intermediario.ToString());
                        if (userAgenCode != null)
                        {
                            var AgentList = GetAgentsChain().Select(x => x.FullNameAll.ToString());
                            IsvalidAgent = AgentList.Contains(userAgenCode.FullNameAll);
                            result = Json(new
                            {
                                DataCoreCustomer = DataCoreCustomer,
                                userAgenCode = userAgenCode,
                                IsvalidAgent = IsvalidAgent
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                            result = Json(new { code = "004", msg = "Usted no tiene cadena de agentes" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
                result = Json(new { code = "001", msg = string.Format("La poliza \"{0}\" no existe en nuestro Sistema", PolicyNumber) }, JsonRequestBehavior.AllowGet);

            return
                 result;
        }

        public JsonResult deleteVehicle(int vehicleID = 0)
        {
            string message = "";
            try
            {
                if (vehicleID > 0)
                {
                    oVehicleProductManager.DeleteVehicleProductCoveragesServices(vehicleID, true);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        public string createRateJson
            (
            int IdMarcavehiculo,
            int IdUsovehiculo,
            int Idtipoveh,
            int IdAniovehiculo,
            int IdDeductible,
            int IdStorage,
            int IdModeloVehiculo,
            int IdCapacidad,
            string Capacidad,
            decimal PorcientoRecargoVentas,
            bool licenciaExtranjera,
            int IdTipoCombustible,
            string TipoCombustible
            )
        {
            string result = "";

            dynamic objD = new System.Dynamic.ExpandoObject();

            objD.idMarcaVehiculo = IdMarcavehiculo;
            objD.idUso = IdUsovehiculo;
            objD.idTipoVehiculo = Idtipoveh;
            objD.idAnoVehiculo = IdAniovehiculo;
            objD.iddeducible = IdDeductible;
            objD.idEstacionaEn = IdStorage;
            objD.idModeloVehiculo = IdModeloVehiculo;
            objD.idCapacidad = IdCapacidad;
            objD.capacidad = Capacidad;
            objD.PorcientoRecargoVentas = PorcientoRecargoVentas;
            objD.licenciaExtranjera = licenciaExtranjera;
            objD.idTipoCombustible = IdTipoCombustible;
            objD.tipoCombustible = TipoCombustible;

            result = "PARAMETERS: " + JsonConvert.SerializeObject(objD);

            result = JsonConvert.SerializeObject(new object[] { result, " RESPONSE: " + JsonConvert.SerializeObject(new { }) });


            return result;

        }
















    }
}