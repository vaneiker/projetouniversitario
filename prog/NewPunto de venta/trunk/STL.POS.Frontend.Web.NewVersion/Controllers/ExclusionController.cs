﻿using Entity.Entities;
using Newtonsoft.Json;
using STL.POS.Frontend.Web.NewVersion.CustomCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public partial class InclusionController : BaseController
    {
        public JsonResult CreateQuotationByExclusion(string EndDate, string AgentCode, string DataCustomer, string policyNoMain)
        {
            return
                CreateQuotationByInclusion(EndDate, AgentCode, DataCustomer, policyNoMain);
        }

        public JsonResult SaveVehicleExclusion(string jsondataVehicle, string StartDate, string EndDate, string AgentCode, string DataCustomer, string policyNoMain, string QuotationId)
        {
            if (QuotationId.ToInt() <= 0)
            {
                object quotationResult = new object();
                try
                {
                    //Insertando COtizacion
                    quotationResult = CreateQuotationByInclusion(EndDate, AgentCode, DataCustomer, policyNoMain, StartDate);
                    //
                }
                catch (Exception ex)
                {
                    LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "VentaDirecta"), QuotationId.ToInt(), "Error al guardar la exclusion", "Mensaje: " + ex.Message, ex);

                    //devolmeos un mensaje de error
                    return Json(new { messageError = "Error al guardar la exclusion." }, JsonRequestBehavior.AllowGet);
                }
            }

            try
            {
                var dvehicle = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(jsondataVehicle);

                var principalFullName = "";
                var principalIdentificationNumber = "";
                decimal totalVehiclesPrime = 0;
                var DriverExist = false;
                var DriverId = 0;
                bool isFinanced = false;

                List<string> QuotProduct = new List<string>();

                var dataDriver = oQuotationManager.GetQuotationDrivers(base.QuotationId);
                if (dataDriver.Any())
                {
                    var oDriver = dataDriver.FirstOrDefault(r => r.IsPrincipal);

                    principalFullName = string.Concat(oDriver.FirstName, " ", oDriver.FirstSurname);
                    principalIdentificationNumber = oDriver.IdentificationNumber;
                    DriverId = oDriver.Id;
                    DriverExist = true;
                }

                //borrando todos los vehiculos de la cotizacion
                var allVeh = oQuotationManager.GetQuotationVehicles(base.QuotationId);
                if (allVeh.Any())
                {
                    foreach (var vh in allVeh)
                    {
                        oVehicleProductManager.DeleteVehicleProductCoveragesServices(vh.Id.GetValueOrDefault(), true);
                    }
                }
                //

                foreach (var vehicle in dvehicle)
                {
                    if (!DriverExist)
                    {
                        principalFullName = vehicle.principalFullName;
                        principalIdentificationNumber = vehicle.IdentificationNumber;
                    }

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
                    vparam.vehicleTypeCoreId = vehicle.selectedVehicleTypeId;
                    vparam.vehicleTypeName = vehicle.selectedVehicleTypeName;

                    vparam.selectedProductName = vehicle.selectedProductName;
                    vparam.vehicleMakeName = vehicle.vehicleMakeName;
                    vparam.usageId = vehicle.usageId;
                    vparam.usageName = vehicle.usageName;
                    vparam.storeId = vehicle.storeId;
                    vparam.storeName = vehicle.storeName;
                    vparam.driver_Id = DriverExist ? DriverId : vehicle.driver_Id;
                    vparam.vehicleModel_Make_Id = realMakeID;
                    vparam.vehicleModel_Model_Id = realModelID;
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
                    vparam.chassis = string.IsNullOrEmpty(vehicle.Chassis.ToString()) ? "" : vehicle.Chassis.ToString().ToUpper();
                    vparam.plate = string.IsNullOrEmpty(vehicle.Plate.ToString()) ? "" : vehicle.Plate.ToString().ToUpper(); ;
                    vparam.color = vehicle.Color;
                    isFinanced = vehicle.isFinanced;

                    totalVehiclesPrime += Convert.ToDecimal(vehicle.totalPrime);

                    QuotProduct.Add(vehicle.selectedProductName.ToString());

                    var SetVehicleResult = oVehicleProductManager.SetVehicleProduct(vparam);

                    var currentVehicleID = SetVehicleResult.EntityId;

                    #region Guardar Coberturas del vehiculo                    
                    var prodParam = new ProductLimits.Parameter();
                    prodParam.id = null;
                    prodParam.vehicleProduct_Id = currentVehicleID;
                    prodParam.isSelected = true;
                    prodParam.totalIsc = 0;
                    prodParam.totalDiscount = 0;
                    prodParam.totalPrime = 0;
                    prodParam.servicesPrime = 0;
                    prodParam.tpPrime = 0;
                    prodParam.sdPrime = 0;
                    prodParam.selectedDeductibleCoreId = null;
                    prodParam.selectedDeductibleName = null;
                    prodParam.userId = GetCurrentUserID();

                    var productLimitSaved = oProductLimitsManager.SetProudctLimits(prodParam);
                    var currentProductLimit = productLimitSaved.EntityId;

                    #region Services

                    ServicesTypes.Parameter stParam = new ServicesTypes.Parameter();
                    stParam.id = null;
                    stParam.servicesTypesToProductLimits = currentProductLimit;
                    stParam.name = "Aero Ambulancia";//Cobertura Servicios por Default Exclusiones
                    stParam.userId = GetCurrentUserID();
                    oServicesTypesRepositoryManager.SetServiceType(stParam);

                    #endregion

                    #region Self Damage Coverages

                    var sdParam = new Coverage.Parameter();
                    sdParam.id = null;
                    sdParam.isSelected = false;
                    sdParam.coverageDetailCoreId = 6;
                    sdParam.name = "Colision y Vuelco";//Cobertura Danos Propios por Default Exclusiones
                    sdParam.amount = 0;
                    sdParam.limit = 0;
                    sdParam.minDeductible = 0;
                    sdParam.deductible = 0;
                    sdParam.selfDamagesToProductLimits = currentProductLimit;
                    sdParam.thirdPartyToProductLimits = null;
                    sdParam.serviceType_Id = null;
                    sdParam.userId = GetCurrentUserID();
                    oCoverageManager.SetCoverageDetail(sdParam);

                    #endregion

                    #region Third Party Coverages

                    var tpParam = new Coverage.Parameter();
                    tpParam.id = null;
                    tpParam.isSelected = false;
                    tpParam.coverageDetailCoreId = 1;
                    tpParam.name = "Daños a La Propiedad Ajena";//Cobertura Daños Terceros por Default Exclusiones
                    tpParam.amount = 0;
                    tpParam.limit = 0;
                    tpParam.minDeductible = 0;
                    tpParam.deductible = 0;
                    tpParam.selfDamagesToProductLimits = null;
                    tpParam.thirdPartyToProductLimits = currentProductLimit;
                    tpParam.serviceType_Id = null;
                    tpParam.userId = GetCurrentUserID();
                    oCoverageManager.SetCoverageDetail(tpParam);

                    #endregion

                    #endregion
                }

                //Actualizando la cotizacion con los totales de prima
                Quotation.parameter qparam = new Quotation.parameter();
                qparam.id = base.QuotationId;
                qparam.sendInspectionOnly = true;
                qparam.financed = isFinanced;
                qparam.totalPrime = totalVehiclesPrime;

                var prods = QuotProduct.Distinct();

                if (prods.Count() > 1)
                {
                    qparam.quotationProduct = "FLOTILLA";
                }
                else
                {
                    qparam.quotationProduct = prods.First();
                }

                qparam.modi_UserId = GetCurrentUserID();
                oQuotationManager.SetQuotation(qparam);


                var quot = oQuotationManager.GetQuotation(base.QuotationId);
                if (quot != null)
                {
                    base.QuotationNumber = quot.QuotationNumber;
                }

                return Json(new { MessageSucess = "", QuotationId = base.QuotationId, QuotationNumber = base.QuotationNumber }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(CommonEnums.Categories.Error, "POS-" + (GetCurrentUsuario() != null ? GetCurrentUsuario().UserLogin : "VentaDirecta"), QuotationId.ToInt(), "Error al guardar los vehiculos de la exclusion", "Mensaje: " + ex.Message, ex);

                //devolmeos un mensaje de error
                return Json(new { messageError = "Error al guardar los vehiculos de la exclusion." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}