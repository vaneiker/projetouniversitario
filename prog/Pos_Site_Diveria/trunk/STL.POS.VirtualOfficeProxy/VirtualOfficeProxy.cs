﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data;
using STL.POS.VirtualOfficeProxy.VOProxy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STL.POS.VirtualOfficeProxy.ContactsProxy;
using STL.POS.WsProxy.SysflexService;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;
using STL.POS.Data.CSEntities;
using STL.POS.WsProxy;
using System.Globalization;

namespace STL.POS.VirtualOfficeProxy
{
    public delegate int GetMappingElementTypeId(MappingElementType type, string posId, int defaultId = 1);
    public delegate int GetMappingElementTypeIdNew(int type, string posId, int defaultId = 1);
    public delegate IEnumerable<Entity.Entities.ProductLimits> getVehicleProductLimitVehicle(int VehicleId);

    public class VirtualOfficeProxy : IVirtualOfficeProxy
    {
        public enum RequestType
        {
            Emision = 1,
            Inclusion = 2,
            Exclusion = 3,
            Renovacion = 4,
            Cambios = 5,
            InclusionDeclarativa = 6,
            PropuestaRecuperacion = 7,
            ExclusionDeclarativa = 8
        }

        private const string RESPONSE_CODE_SUCCESS = "000";
        private const int BUSINESS_LINE_TYPE_ID = 1;
        private const string ERROR_MESSAGE_TEMPLATE = "Error al informar la cotización a VirtualOffice: {0}\nDetalle: {1}.";
        private const int COUNTRY_ID = 129;
        private int REGION_ID = 1;
        private int CORPORATION_ID = 1;

        private PolicyServiceClient virtualOfficeServiceClient;
        private ContactServiceClient contactsServiceClient;
        private STL.POS.WsProxy.CoreProxy coreProxyClient;
        private SysFlexServiceClient sysFlexServiceClient;
        string connectionStringGlobal = System.Configuration.ConfigurationManager.ConnectionStrings["GlobalLogger"].ConnectionString;
        public string[] ErrorCode { get { return new string[] { "001", "002" }; } }

        public VirtualOfficeProxy()
        {
            virtualOfficeServiceClient = new PolicyServiceClient();
            contactsServiceClient = new ContactServiceClient();
            sysFlexServiceClient = new SysFlexServiceClient();
            coreProxyClient = new WsProxy.CoreProxy(sysFlexServiceClient);
        }

        /// <summary>
        /// Auhtor : Lic. Carlos Ml. Lebron
        /// </summary>
        /// <param name="username"></param>
        /// <param name="agentId"></param>
        /// <param name="idOficina"></param>
        /// <param name="currencyId"></param>
        /// <param name="retryAmount"></param>
        /// <param name="policyId"></param>
        /// <param name="sourceID"></param>
        /// <param name="codRamo"></param>
        /// <param name="oQuotation"></param>
        /// <param name="oDriver"></param>
        /// <param name="oVehicle"></param>
        /// <param name="oCoverage"></param>
        /// <param name="oAllPepFormularys"></param>
        /// <param name="oAllFinalBeneficiarys"></param>
        /// <param name="getMappingFunction"></param>
        /// <param name="personJobForGlobal"></param>
        /// <returns></returns>
        public bool SetAutoQuotationAutoNew(
                                             string username,
                                             int agentId,
                                             int idOficina,
                                             int currencyId,
                                             int retryAmount,
                                             string policyId,
                                             string sourceID,
                                             int codRamo,
                                             Entity.Entities.Quotation oQuotation,
                                             Entity.Entities.Driver oDriver,
                                             Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>> oVehicleCoverage,
                                             IEnumerable<Entity.Entities.PepFormulary> oAllPepFormularys,
                                             IEnumerable<Entity.Entities.IdentificationFinalBeneficiary> oAllFinalBeneficiarys,
                                             GetMappingElementTypeIdNew getMappingFunction,
                                             Dictionary<int, int> personJobForGlobal,
                                             int UserID,
                                             List<Entity.Entities.ListVehicleSourceID> listVehicleSourceID,
                                             getVehicleProductLimitVehicle VehicleProductLitmit,
                                             decimal MinAllowedAmountToPay,
                                             string EndorsementBeneficiary,
                                             string newEndpointCotizacion,
                                             out List<string> statusMessages)
        {
            bool Result = true;
            int count = 1;
            int vehicleIndex = 1;
            int lastVehicleID = 0;
            statusMessages = new List<string>();
            string CustomerNumber = "";
            //Crear el contacto
            var RequestType = (RequestType)Enum.Parse(typeof(RequestType), MyRemoveInvalidCharacters(oQuotation.RequestTypeDesc.Replace(" ", "")));

            try
            {
                switch (RequestType)
                {
                    case RequestType.Emision:
                    case RequestType.InclusionDeclarativa:
                        CustomerNumber = SetContact(oDriver, agentId, getMappingFunction, personJobForGlobal, oQuotation, oAllPepFormularys, oAllFinalBeneficiarys, UserID, RequestType);
                        break;
                    case RequestType.Inclusion:
                    case RequestType.Exclusion:
                    case RequestType.Cambios:
                    case RequestType.PropuestaRecuperacion:
                    case RequestType.ExclusionDeclarativa:
                        var PolicyDataFromGlobal = virtualOfficeServiceClient.GetPolicy(oQuotation.policyNoMain);
                        if (PolicyDataFromGlobal.Code == "000")
                        {
                            var dataJson = PolicyDataFromGlobal.JSONResult;
                            if (!string.IsNullOrEmpty(dataJson))
                            {
                                var dataDeserialize = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(dataJson);
                                var ContactId = int.Parse(((object)dataDeserialize.ContactId).ToString().Replace("{", "").Replace("}", ""));
                                var CustNbrData = contactsServiceClient.GetCustomerNumberByContactId(ContactId);
                                if (CustNbrData.Code == "000")
                                {
                                    CustomerNumber = CustNbrData.JSONResult.Replace("\"", "");

                                    //Actualizar info cliente
                                    UpdateContactByCustomerNumber(CustomerNumber, oDriver, agentId, getMappingFunction, personJobForGlobal, oQuotation, oAllPepFormularys, oAllFinalBeneficiarys, UserID, RequestType);
                                }
                                else
                                {
                                    CustomerNumber = SetContact(oDriver, agentId, getMappingFunction, personJobForGlobal, oQuotation, oAllPepFormularys, oAllFinalBeneficiarys, UserID, RequestType);
                                }
                            }
                        }
                        else
                        {
                            CustomerNumber = SetContact(oDriver, agentId, getMappingFunction, personJobForGlobal, oQuotation, oAllPepFormularys, oAllFinalBeneficiarys, UserID, RequestType);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el contacto.", ex.Message));
                return false;
            }

            //Crear la cabecera de la poliza
            VOProxy.getResult insertedHeader = null;
            try
            {
                insertedHeader = InsertPolicyHeaderNew(oQuotation, oDriver, username, retryAmount, CustomerNumber, policyId, idOficina, currencyId, getMappingFunction, UserID, oVehicleCoverage.Item1);
            }
            catch (Exception ex)
            {
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el header de la cotización.", ex.Message));
                return false;
            }

            dynamic insertPolicyResult = JObject.Parse(insertedHeader.JSONResult);

            if (!string.IsNullOrEmpty(sourceID))
                setPolicySourceId(policyId, sourceID);

            List<PolicyPolicyCoverages> allServicesCoverages = null;
            List<PolicyPolicyCoverages> allThirdDamageCoverages = null;
            List<PolicyPolicyCoverages> allSelfDamageCoverages = null;

            //Insertar los vehiculos y coberturas
            foreach (var vehicle in oVehicleCoverage.Item1)//VehicleProduct
            {
                count = 1;

                /*Repetir el bloque de codigo todas las veces que indique el campo VehicleQuantity*/
                while (count <= vehicle.VehicleQuantity)
                {
                    List<PolicySysFlexGetPrimaCobertura> primacobertura = new List<PolicySysFlexGetPrimaCobertura>();

                    if (RequestType != RequestType.PropuestaRecuperacion)
                    {
                        primacobertura = GetPrimaCoberturaSysflex(Convert.ToDecimal(oQuotation.QuotationCoreNumber), (vehicle.SecuenciaVehicleSysflex.HasValue ? vehicle.SecuenciaVehicleSysflex.Value : 1), newEndpointCotizacion).ToList();
                    }
                    else
                    {
                        PolicyPolicyCoverages[] allCoverages = GetPolizaCoberturasMovCanceladaProspecto(Convert.ToDecimal(oQuotation.QuotationCoreNumber), vehicle.SecuenciaVehicleSysflex.GetValueOrDefault(), oQuotation.secuenciaMov, newEndpointCotizacion);

                        if (allCoverages.Count() > 0)
                        {
                            allCoverages = allCoverages.Select(y =>
                            {
                                y.tipoCobertura = !string.IsNullOrEmpty(y.tipoCobertura) ? y.tipoCobertura.ToLower() : "";

                                return y;
                            }).ToArray();


                            allServicesCoverages = allCoverages.Where(x => x.tipoCobertura == "servicios" && x.TieneCobertura == "S").ToList();
                            allSelfDamageCoverages = allCoverages.Where(x => x.tipoCobertura == "daños propios" && x.TieneCobertura == "S").ToList();
                            allThirdDamageCoverages = allCoverages.Where(x => x.tipoCobertura == "daños a terceros" && x.TieneCobertura == "S").ToList();
                        }
                    }


                    VOProxy.getResult insertedVehicle;
                    string currentVehicleSourceID = "";

                    if (lastVehicleID != vehicle.Id)
                    {
                        var sourcesID = listVehicleSourceID.FirstOrDefault(x => x.VehicleID == vehicle.Id);

                        if (sourcesID != null)
                            currentVehicleSourceID = sourcesID.SourceID;
                    }
                    else
                    {
                        var sourcesIDByIndex = listVehicleSourceID.FirstOrDefault(x => x.Index == vehicleIndex);

                        if (sourcesIDByIndex != null)
                            currentVehicleSourceID = sourcesIDByIndex.SourceID;
                    }

                    //Insertar el vehiculo en cuestion
                    insertedVehicle = AddVehicleInsuredNew(oQuotation, vehicle, insertPolicyResult, getMappingFunction, retryAmount, currentVehicleSourceID, UserID, VehicleProductLitmit, EndorsementBeneficiary);

                    var limit = VehicleProductLitmit(vehicle.Id.GetValueOrDefault()).FirstOrDefault(p => p.IsSelected.GetValueOrDefault());

                    dynamic addVehicleInsuredResponse = JObject.Parse(insertedVehicle.JSONResult);

                    if (limit != null)
                    {
                        List<CoverageDetail> coverages = new List<CoverageDetail>();
                        Decimal? DeductiblePercent = null;
                        if (!string.IsNullOrWhiteSpace(limit.SelectedDeductibleName))
                        {
                            Decimal deduc = 0;
                            var dedArr = limit.SelectedDeductibleName.Split(' ');
                            if (Decimal.TryParse(dedArr[0], out deduc))
                                DeductiblePercent = deduc;
                        }

                        List<PVechicleCoverage> coveragesToSend = new List<PVechicleCoverage>();
                        int productId = 0, productTypeId = 0, coverageGroupId = 0, coverageId = 0;

                        // Get ProductType
                        try
                        {
                            productTypeId = GetProductTypeId((int)insertPolicyResult.CorpId, vehicle.SelectedProductName, retryAmount);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetProductTypeId", ex.Message));
                        }

                        // Get Product Id
                        try
                        {
                            productId = GetProductId(vehicle.SelectedVehicleTypeName, productTypeId, retryAmount);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetProductId", ex.Message));
                            return false;
                        }

                        // Get Coverage Group
                        try
                        {
                            coverageGroupId = GetCoverageGroupId((int)insertPolicyResult.CorpId, vehicle.SelectedCoverageName, retryAmount, codRamo, vehicle.SelectedCoverageCoreId);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetCoverageGroupId", ex.Message));
                        }

                        var ThirdPartyCoverages = oVehicleCoverage.Item2.Where(x => x.CoverageType == "Daños Terceros" && x.vehilceID == vehicle.Id.GetValueOrDefault());

                        foreach (var c in ThirdPartyCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 1, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }

                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = 2;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit.GetValueOrDefault();
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 1; //CoverageType Daños Terceros
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;
                            vehicleCov.DeductiblePercentage = DeductiblePercent;

                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = false;
                            vehicleCov.IsService = false;


                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;
                                    vehicleCov.coveragePercentage = realCObert.PorcientoCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCObert.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCObert.PermiteSumarizar;
                                }
                            }
                            else if (RequestType == RequestType.PropuestaRecuperacion && allThirdDamageCoverages.Count() > 0)
                            {
                                var realCo = allThirdDamageCoverages.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCo != null)
                                {
                                    vehicleCov.UnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.PremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.oldUnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.oldPremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.DeductibleAmount = realCo.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.DeductiblePercentage = realCo.PorcDeducible;
                                    vehicleCov.coveragePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCo.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCo.PermiteSumarizar;
                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        var SelfDamagesCoverages = oVehicleCoverage.Item2.Where(x => x.CoverageType == "Daños Propios" && x.vehilceID == vehicle.Id.GetValueOrDefault());

                        foreach (var c in SelfDamagesCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 2, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }


                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = 2;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit.GetValueOrDefault();
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 2; //CoverageType Daños Propios
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;

                            decimal deductibleRoturaCristales = 10;

                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = true;
                            vehicleCov.IsService = false;

                            var SysFlexProxy = new STL.POS.WsProxy.CoreProxy(new SysFlexServiceClient());

                            //Rotura de Cristal
                            if (c.CoverageDetailCoreId.Equals(14))
                            {
                                var getResult = SysFlexProxy.GetCoverage(vehicle.SelectedCoverageCoreId.GetValueOrDefault(), 0, vehicle.VehiclePrice.GetValueOrDefault(), codRamo);
                                if (getResult.Any())
                                {
                                    var result = getResult.FirstOrDefault(x => x.CoverageDetailName.ToLower() == "Rotura de Cristales".ToLower());

                                    if (result != null)
                                        deductibleRoturaCristales = result.deductible.GetValueOrDefault();

                                    vehicleCov.DeductiblePercentage = deductibleRoturaCristales;
                                }
                            }
                            else
                            {
                                vehicleCov.DeductiblePercentage = DeductiblePercent;
                            }


                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;
                                    vehicleCov.coveragePercentage = realCObert.PorcientoCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCObert.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCObert.PermiteSumarizar;
                                }
                            }
                            else if (RequestType == RequestType.PropuestaRecuperacion && allSelfDamageCoverages.Count() > 0)
                            {
                                var realCo = allSelfDamageCoverages.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCo != null)
                                {
                                    vehicleCov.UnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.PremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.oldUnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.oldPremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.DeductibleAmount = realCo.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.DeductiblePercentage = realCo.PorcDeducible;
                                    vehicleCov.coveragePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCo.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCo.PermiteSumarizar;
                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        var servicesCoverages = oVehicleCoverage.Item2.Where(x => x.CoverageType == "Servicios" && x.vehilceID == vehicle.Id.GetValueOrDefault()).Where(p => p.IsSelected.GetValueOrDefault());


                        foreach (var c in servicesCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 3, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }

                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = 2;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit.GetValueOrDefault();
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 3; //CoverageType Servicios
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;
                            vehicleCov.DeductiblePercentage = DeductiblePercent;

                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = false;
                            vehicleCov.IsService = true;

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;
                                    vehicleCov.coveragePercentage = realCObert.PorcientoCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCObert.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCObert.PermiteSumarizar;
                                }
                            }
                            else if (RequestType == RequestType.PropuestaRecuperacion && allServicesCoverages.Count() > 0)
                            {
                                var realCo = allServicesCoverages.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCo != null)
                                {
                                    vehicleCov.UnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.PremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.oldUnitaryPrice = realCo.PrimaNew.GetValueOrDefault();
                                    vehicleCov.oldPremiumPercentage = realCo.PorcientoNew;

                                    vehicleCov.DeductibleAmount = realCo.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.DeductiblePercentage = realCo.PorcDeducible;
                                    vehicleCov.coveragePercentage = realCo.PorcCobertura.GetValueOrDefault();
                                    vehicleCov.BaseDeductible = realCo.BaseDeducible;
                                    vehicleCov.AllowsToSumarize = realCo.PermiteSumarizar;
                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        foreach (var c in coveragesToSend)
                        {
                            try
                            {
                                CheckCoverageGroupDetailRelation(retryAmount, c);
                                CheckCoverageProductRelationNewPV(oQuotation, insertPolicyResult, vehicle.SelectedVehicleTypeId.Value, retryAmount, c);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido chequear la existencia de la relacion Coverage-Product.", ex.Message));
                                return false;
                            }

                            try
                            {
                                AddVehicleCoverage(retryAmount, c);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido chequear la existencia de la relacion Coverage-Product.", ex.Message));
                                return false;
                            }
                        }
                    }

                    count++;
                    vehicleIndex++;
                    lastVehicleID = vehicle.Id.GetValueOrDefault();
                }
            }

            //Insertanto Acuerdo de Pago
            try
            {
                SetPaymentAgreementNewPV(oQuotation, insertPolicyResult, UserID, MinAllowedAmountToPay);
            }
            catch (Exception ex)
            {
                //Simplemente capturo el error para saber si fallo
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el acuerdo de pago (SetPaymentAgreement).", ex.Message));
            }

            #region Seteando el nivel de riesgo en global antes de llamar la Flag table
            this.SetRiskLevelPolicy(oQuotation.QuotationNumber);
            #endregion

            try
            {
                //Verificar si esta cotizacion tiene reglas de validacion en sysflex                        
                var dataValidationRules = sysFlexServiceClient.GetReglasValidacion(Convert.ToDecimal(oQuotation.QuotationCoreNumber), oQuotation.QuotationNumber);
                var dPolicy = virtualOfficeServiceClient.GetPolicy(oQuotation.QuotationNumber);

                if (!string.IsNullOrEmpty(dPolicy.JSONResult))
                {
                    var dataPolicy = Newtonsoft.Json.JsonConvert.DeserializeObject<PolicyItem>(dPolicy.JSONResult);
                    var dVehicles = virtualOfficeServiceClient.GetVehicleInsured(oQuotation.QuotationNumber);
                    var dataVehicles = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<VehicleItem>>(dVehicles.JSONResult);

                    foreach (var item in dataValidationRules)
                    {
                        long? VehicleUniqueId = null;

                        //Buscar por la placa
                        var vehItemByRegistry = dataVehicles.FirstOrDefault(x => x.Registry == item.placa);
                        if (vehItemByRegistry != null)
                        {
                            VehicleUniqueId = vehItemByRegistry.VehicleUniqueId;
                        }
                        else
                        {   //Buscar por el chassis
                            var vehItemByChassis = dataVehicles.FirstOrDefault(x => x.Chassis == item.chassis);
                            if (vehItemByChassis != null)
                                VehicleUniqueId = vehItemByChassis.VehicleUniqueId;
                        }


                        var parameter = new Policy.ValicationRules
                        {
                            CorpId = dataPolicy.CorpId,
                            RegionId = dataPolicy.RegionId,
                            CountryId = dataPolicy.CountryId,
                            DomesticregId = dataPolicy.DomesticregId,
                            StateProvId = dataPolicy.StateProvId,
                            CityId = dataPolicy.CityId,
                            OfficeId = dataPolicy.OfficeId,
                            CaseSeqNo = dataPolicy.CaseSeqNo,
                            HistSeqNo = dataPolicy.HistSeqNo,
                            vehicleUniqueId = (int?)VehicleUniqueId,
                            ruleId = item.idRegla,
                            description = item.descripcion,
                            comments = null,
                            validated = false,
                            userIdValidated = null,
                            userIdCreate = UserID,
                            statusCase = null,
                            isStop = item.IsStop
                        };

                        var ResultSetValidationRules = virtualOfficeServiceClient.SetValidationRules(parameter);
                    }
                }
            }
            catch (Exception)
            {

            }

            //Actualizar la tabla temporal de la bandeja de cotizaciones
            try
            {
                bool resultFlagTable = false;
                resultFlagTable = this.UpdateOneQuotationInfoTempNewPV(oQuotation, UserID);
            }
            catch (Exception ex)
            {
                string thisError = ex.Message;
            }

            return
                Result;
        }

        /// <summary>
        /// Author: Lic. Carlo ML. Lebron
        /// </summary>
        /// <param name="oDriver"></param>
        /// <param name="AgentId"></param>
        /// <param name="getMappingFunction"></param>
        /// <param name="personJobForGlobal"></param>
        /// <param name="oQuotation"></param>
        /// <returns></returns>
        private string SetContact(Entity.Entities.Driver oDriver,
                                 int AgentId,
                                 GetMappingElementTypeIdNew getMappingFunction,
                                 Dictionary<int, int> personJobForGlobal,
                                 Entity.Entities.Quotation oQuotation,
                                 IEnumerable<Entity.Entities.PepFormulary> oAllPepFormularys,
                                 IEnumerable<Entity.Entities.IdentificationFinalBeneficiary> oAllFinalBeneficiarys,
                                 int UserID,
                                 RequestType requestType)
        {
            Contact contactRequest;
            MatchResult contactMatchResult = null;
            string CustomerNumber = string.Empty;
            var lastMessage = string.Empty;

            DateTime? dob = null;
            bool iscompania = false;

            if (oDriver.IdentificationType == "RNC")
                iscompania = true;
            else
                dob = oDriver.DateOfBirth.Date;

            var contactMatch = new PContactMatch()
            {
                FirstName = oDriver.FirstName,
                FirstLastName = oDriver.FirstSurname,
                Dob = dob,
                Identification = oDriver.IdentificationNumber,
                ContactTypeId = (iscompania ? 5 : 1) //1 Cliente, 5 Compania
            };

            contactMatchResult = contactsServiceClient.GetContactMatch(contactMatch);
            List<contactMatchResult> contactsMatchs = null;
            string InstitutionalName =
                iscompania
                ?
                (
                oDriver.FirstName.TrimStart().TrimEnd()
                +
                (!string.IsNullOrWhiteSpace(oDriver.FirstSurname) ? " " + oDriver.FirstSurname.TrimStart().TrimEnd() : null)
                )
                : null;

            switch (requestType)
            {
                case RequestType.Emision:
                case RequestType.Inclusion:
                case RequestType.Exclusion:
                case RequestType.Cambios:
                case RequestType.InclusionDeclarativa:
                case RequestType.ExclusionDeclarativa:
                    #region Cuando el contacto no existe
                    if (contactMatchResult.CountPossibleMatch == 0)
                    {
                        contactRequest = new Contact
                        {
                            CorpId = CORPORATION_ID,
                            AgentId = AgentId,
                            FirstName = oDriver.FirstName,
                            MiddleName = oDriver.SecondName,
                            FirstLastName = oDriver.FirstSurname,
                            SecondLastName = oDriver.SecondSurname,
                            Gender = oDriver.GetSexOneLetter(),
                            Smoker = false,
                            MaritalStatId = getMappingFunction(Convert.ToInt32(MappingElementType.MaritalStatus, CultureInfo.InvariantCulture), oDriver.MaritalStatus),
                            CountryOfResidenceId = oDriver.City_Country_Id,
                            Dob = dob,
                            CountryOfBirthId = oDriver.Nationality_Global_Country_Id.HasValue ? oDriver.Nationality_Global_Country_Id.Value : 129,
                            InvoiceTypeId = oDriver.InvoiceTypeId.HasValue ? oDriver.InvoiceTypeId.Value : 0,
                            IsCompany = iscompania,

                            finalBeneficiaryOptionId = oDriver.IdentificationFinalBeneficiaryOptionsId == 0 ? null : oDriver.IdentificationFinalBeneficiaryOptionsId,
                            pepFormularyOptionId = oDriver.PepFormularyOptionsId == 0 ? null : oDriver.PepFormularyOptionsId,
                            companyStructureId = oDriver.OwnershipStructureId == 0 ? null : oDriver.OwnershipStructureId,
                            companyActivityId = oDriver.SocialReasonId == 0 ? null : oDriver.SocialReasonId,

                            AnnualPersonalIncome = oDriver.AnnualIncome,
                            CompanyName = oDriver.TypeOfPerson != 1 && oDriver.TypeOfPerson != 3 ? oDriver.FirstName : oDriver.Company,

                            OccupationId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Key : (int?)null,
                            OccupGroupTypeId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Value : (int?)null,
                            creditCardTypeId = oQuotation.Credit_Card_Type_Id == null ? 0 : oQuotation.Credit_Card_Type_Id,
                            creditCardNumber = oQuotation.Credit_Card_Number == null ? string.Empty : oQuotation.Credit_Card_Number,
                            creditCardNumberKey = oQuotation.Credit_Card_Number_Key == null ? string.Empty : oQuotation.Credit_Card_Number_Key,
                            expirationDateYear = oQuotation.Expiration_Date_Year == null ? 0 : oQuotation.Expiration_Date_Year,
                            expirationDateMonth = oQuotation.Expiration_Date_Month == null ? 0 : oQuotation.Expiration_Date_Month,
                            cardHolder = oQuotation.Card_Holder == null ? string.Empty : oQuotation.Card_Holder,
                            homeOwner = oDriver.Home_Owner,
                            qtyEmployees = oDriver.QtyEmployees == null ? 0 : oDriver.QtyEmployees,
                            qtyPersonsDepend = oDriver.QtyPersonsDepend == null ? 0 : oDriver.QtyPersonsDepend,
                            linked = oDriver.Linked,
                            segment = oDriver.Segment,
                            ContactTypeId = iscompania ? 5 : 1, //1 Cliente, 5 Compania

                            WorkAddress = oDriver.WorkAddress != null ? oDriver.WorkAddress : string.Empty,
                            PlaceOfBirth = oDriver.PlaceOfBirth != null ? oDriver.PlaceOfBirth : string.Empty,
                            TypeOfPerson = oDriver.TypeOfPerson,
                            ManagerName = oDriver.ManagerName != null ? oDriver.ManagerName : string.Empty,
                            ManagerPepOptionId = oDriver.ManagerPepOptionId,
                            InstitutionalName = InstitutionalName
                        };


                        //Insertar un nuevo contacto
                        bool addContactSuccess = false;
                        ContactResult AddContactResult = null;

                        try
                        {
                            AddContactResult = contactsServiceClient.AddContact(contactRequest);

                            if (AddContactResult.Code != RESPONSE_CODE_SUCCESS)
                            {
                                lastMessage = AddContactResult.Message;
                                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(contactRequest, Formatting.Indented);
                                addContactSuccess = false;
                            }
                            else
                                addContactSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage = "Error en la llamada al método AddContact.\nDetalle: ResponseCode:" + AddContactResult.Code + "\nMensaje: " + ex.Message;
                        }


                        #region Si no hubo ningun error entonces insertar los Telefonos, correos, Direccion
                        if (addContactSuccess)
                        {
                            CustomerNumber = AddContactResult.customerNumber;

                            var documentRequest = new IdDocument()
                            {
                                customerNumber = CustomerNumber,
                                ExpireDate = oDriver.IdentificationType != "RNC" ? oDriver.IdentificationNumberValidDate.HasValue ? oDriver.IdentificationNumberValidDate : DateTime.MaxValue : DateTime.MaxValue,
                                Id = oDriver.IdentificationNumber,
                                ContactIdType = (UtilityIdentificationType)VirtualOfficeIntegration.GetVirtualOfficeIdentificationType(oDriver.IdentificationType)
                            };

                            var AddIdentificationResult = contactsServiceClient.AddIdentification(documentRequest);

                            var emailRequest = new Email()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                EmailAdress = oDriver.Email,
                                CommunicationType = "Email",
                                DirectoryTypeId = UtilityEmailType.Home,
                                IsPrimary = true
                            };

                            contactsServiceClient.AddEmail(emailRequest);

                            var phoneRequest = new Phone()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                PhoneNumber = oDriver.PhoneNumber,
                                DirectoryTypeId = UtilityPhoneType.Home,
                                CommunicationType = "Phone",
                                IsPrimary = true,
                                CountryCode = " ",
                                AreaCode = " ",
                            };

                            contactsServiceClient.AddPhone(phoneRequest);

                            var workPhoneRequest = new Phone()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                PhoneNumber = oDriver.WorkPhone,
                                DirectoryTypeId = UtilityPhoneType.Work,
                                CommunicationType = "Phone",
                                IsPrimary = false,
                                CountryCode = " ",
                                AreaCode = " ",
                            };

                            contactsServiceClient.AddPhone(workPhoneRequest);

                            var cellPhoneRequest = new Phone()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                PhoneNumber = oDriver.Mobile,
                                DirectoryTypeId = UtilityPhoneType.CellPhone,
                                CommunicationType = "Phone",
                                IsPrimary = false,
                                CountryCode = " ",
                                AreaCode = " ",
                            };

                            contactsServiceClient.AddPhone(cellPhoneRequest);

                            var faxPhoneRequest = new Phone()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                PhoneNumber = oDriver.Fax,
                                DirectoryTypeId = UtilityPhoneType.Fax,
                                CommunicationType = "Phone",
                                IsPrimary = false,
                                CountryCode = " ",
                                AreaCode = " ",
                            };

                            contactsServiceClient.AddPhone(faxPhoneRequest);

                            var personalAddressRequest = new Address()
                            {
                                CorpId = CORPORATION_ID,
                                DirectoryTypeId = UtilityAddressType.HomeAddress,
                                StreetAddress = oDriver.Address,
                                CountryId = oDriver.City_Country_Id,
                                RegionId = 24,
                                DomesticregId = oDriver.City_Domesticreg_Id,
                                StateProvId = oDriver.City_State_Prov_Id,
                                CityId = oDriver.City_City_Id,
                                ZipCode = "898989",
                                IsPrimary = true,
                                CommunicationType = "Address",
                                customerNumber = CustomerNumber
                            };

                            contactsServiceClient.AddAddress(personalAddressRequest);

                            /*Setianndo formularios PEP Y BF*/
                            var contact = contactsServiceClient.GetContact(CORPORATION_ID, CustomerNumber);

                            if (contact.Code == RESPONSE_CODE_SUCCESS)
                            {
                                var cresult = JsonConvert.DeserializeObject<Contact>(contact.JSONResult);
                                if (cresult != null)
                                {
                                    var ContactId = cresult.ContactId;

                                    foreach (var item in oAllFinalBeneficiarys)
                                    {
                                        SetContactFinalBeneficiary(ContactId, item.IdentityId.GetValueOrDefault(), item.name, item.percentageParticipation.GetValueOrDefault(), true, UserID, item.isPEP, item.pepFormularyOptionsId, item.IdentificationTypeId.toInt(), item.IdentificationNumber, item.NationalityCountryId, out lastMessage);
                                    }

                                    foreach (var item in oAllPepFormularys)
                                    {
                                        SetContactPepFormulary(ContactId, item.Id, item.name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, UserID, item.BeneficiaryId, item.IsPepManagerCompany, out lastMessage);
                                    }
                                }
                            }
                            /**/
                        }
                        #endregion
                    }
                    #endregion

                    #region Cuando el contacto Existe actualizar la informacion del contacto
                    else
                    {
                        contactsMatchs = JsonConvert.DeserializeObject<List<contactMatchResult>>(contactMatchResult.JsonResultPossibleMatch);
                        CustomerNumber = contactsMatchs.First().CustomerNumber;

                        UpdateContactByCustomerNumber(CustomerNumber, oDriver, AgentId, getMappingFunction, personJobForGlobal, oQuotation, oAllPepFormularys, oAllFinalBeneficiarys, UserID, requestType);
                    }
                    #endregion
                    break;
                    /*case RequestType.Renovacion:
                        contactsMatchs = JsonConvert.DeserializeObject<List<contactMatchResult>>(contactMatchResult.JsonResultPossibleMatch);
                        CustomerNumber = contactsMatchs.First().CustomerNumber;
                        break;*/
            }

            return
                 CustomerNumber;
        }

        private string UpdateContactByCustomerNumber(string CustomerNumber, Entity.Entities.Driver oDriver,
                                 int AgentId,
                                 GetMappingElementTypeIdNew getMappingFunction,
                                 Dictionary<int, int> personJobForGlobal,
                                 Entity.Entities.Quotation oQuotation,
                                 IEnumerable<Entity.Entities.PepFormulary> oAllPepFormularys,
                                 IEnumerable<Entity.Entities.IdentificationFinalBeneficiary> oAllFinalBeneficiarys,
                                 int UserID,
                                 RequestType requestType
            )
        {
            var lastMessage = string.Empty;

            DateTime? dob = null;
            bool iscompania = false;

            if (oDriver.IdentificationType == "RNC")
                iscompania = true;
            else
                dob = oDriver.DateOfBirth.Date;


            string InstitutionalName =
                iscompania
                ?
                (
                oDriver.FirstName.TrimStart().TrimEnd()
                +
                (!string.IsNullOrWhiteSpace(oDriver.FirstSurname) ? " " + oDriver.FirstSurname.TrimStart().TrimEnd() : null)
                )
                : null;

            Contact oContact = null;

            var dataContact = contactsServiceClient.GetContact(CORPORATION_ID, CustomerNumber);
            if (!string.IsNullOrEmpty(dataContact.JSONResult))
            {
                oContact = JsonConvert.DeserializeObject<Contact>(dataContact.JSONResult);
                if (oContact != null)
                {
                    oContact.CorpId = CORPORATION_ID;
                    oContact.AgentId = AgentId;
                    oContact.MiddleName = oDriver.SecondName;
                    oContact.SecondLastName = oDriver.SecondSurname;
                    oContact.Gender = oDriver.GetSexOneLetter();
                    oContact.MaritalStatId = getMappingFunction(Convert.ToInt32(MappingElementType.MaritalStatus, CultureInfo.InvariantCulture), oDriver.MaritalStatus);
                    oContact.CountryOfResidenceId = oDriver.City_Country_Id;
                    oContact.CountryOfBirthId = oDriver.Nationality_Global_Country_Id.HasValue ? oDriver.Nationality_Global_Country_Id.Value : oContact.CountryOfBirthId;
                    oContact.IsCompany = iscompania;
                    oContact.finalBeneficiaryOptionId = oDriver.IdentificationFinalBeneficiaryOptionsId == 0 ? null : oDriver.IdentificationFinalBeneficiaryOptionsId;
                    oContact.pepFormularyOptionId = oDriver.PepFormularyOptionsId == 0 ? null : oDriver.PepFormularyOptionsId;
                    oContact.companyStructureId = oDriver.OwnershipStructureId == 0 ? null : oDriver.OwnershipStructureId;
                    oContact.companyActivityId = oDriver.SocialReasonId == 0 ? null : oDriver.SocialReasonId;
                    oContact.InvoiceTypeId = oDriver.InvoiceTypeId.HasValue ? oDriver.InvoiceTypeId.Value : 0;
                    oContact.AnnualPersonalIncome = oDriver.AnnualIncome;
                    oContact.CompanyName = oDriver.Company;
                    oContact.OccupationId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Key : (int?)null;
                    oContact.OccupGroupTypeId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Value : (int?)null;
                    oContact.ContactTypeId = iscompania ? 5 : 1; //1 Cliente, 5 Compania
                    oContact.WorkAddress = oDriver.WorkAddress;
                    oContact.PlaceOfBirth = oDriver.PlaceOfBirth;
                    oContact.TypeOfPerson = oDriver.TypeOfPerson;
                    oContact.ManagerName = oDriver.ManagerName;
                    oContact.ManagerPepOptionId = oDriver.ManagerPepOptionId;
                    oContact.InstitutionalName = InstitutionalName;

                    var UpdateContactResult = contactsServiceClient.UpdateContact(oContact);

                    if (!string.IsNullOrEmpty(oDriver.IdentificationNumber))
                    {
                        var dataIdentification = contactsServiceClient.GetAllIdDocuments(CORPORATION_ID, CustomerNumber);
                        bool noidentification = true;
                        var oIdenfication = JsonConvert.DeserializeObject<List<IdDocument>>(dataIdentification.JSONResult);

                        if (oIdenfication.Count() > 0)
                        {
                            var eIdenficationPrimary = oIdenfication.FirstOrDefault(x => x.ContactIdType == (UtilityIdentificationType)VirtualOfficeIntegration.GetVirtualOfficeIdentificationType(oDriver.IdentificationType));
                            if (eIdenficationPrimary != null)
                            {
                                var documentRequest = new IdDocument()
                                {
                                    customerNumber = CustomerNumber,
                                    ExpireDate = oDriver.IdentificationType != "RNC" ? oDriver.IdentificationNumberValidDate.HasValue ? oDriver.IdentificationNumberValidDate : DateTime.MaxValue : DateTime.MaxValue,
                                    Id = oDriver.IdentificationNumber,
                                    ContactIdType = (UtilityIdentificationType)VirtualOfficeIntegration.GetVirtualOfficeIdentificationType(oDriver.IdentificationType),

                                    ContactId = oContact.ContactId,
                                    SeqNo = eIdenficationPrimary.SeqNo,
                                    CountryIssuedBy = eIdenficationPrimary.CountryIssuedBy.HasValue ? eIdenficationPrimary.CountryIssuedBy.Value : 129
                                };

                                var AddIdentificationResult = contactsServiceClient.UpdateIdentification(documentRequest);
                                //if (AddIdentificationResult.Code != RESPONSE_CODE_SUCCESS)
                                //{
                                //    lastMessage += "Response Code: " + AddIdentificationResult.Code + "\nMensaje: " + AddIdentificationResult.Message;
                                //    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(documentRequest, Formatting.Indented) + "\n--\n";                                    
                                //}
                                noidentification = false;
                            }
                        }

                        if (noidentification)
                        {
                            var documentRequest = new IdDocument()
                            {
                                customerNumber = CustomerNumber,
                                ExpireDate = oDriver.IdentificationType != "RNC" ? oDriver.IdentificationNumberValidDate.HasValue ? oDriver.IdentificationNumberValidDate : DateTime.MaxValue : DateTime.MaxValue,
                                Id = oDriver.IdentificationNumber,
                                ContactIdType = (UtilityIdentificationType)VirtualOfficeIntegration.GetVirtualOfficeIdentificationType(oDriver.IdentificationType)
                            };
                            var AddIdentificationResult = contactsServiceClient.AddIdentification(documentRequest);
                        }
                    }



                    if (!string.IsNullOrEmpty(oDriver.Email))
                    {
                        var dataEmail = contactsServiceClient.GetAllEmail(CORPORATION_ID, CustomerNumber);
                        bool noEmail = true;
                        var oEmail = JsonConvert.DeserializeObject<List<Email>>(dataEmail.JSONResult);

                        if (oEmail.Count() > 0)
                        {
                            var emailPrimary = oEmail.FirstOrDefault(x => x.IsPrimary);
                            if (emailPrimary != null)
                            {
                                var dirtype = (STL.POS.VirtualOfficeProxy.ContactsProxy.UtilityEmailType)Enum.Parse(typeof(STL.POS.VirtualOfficeProxy.ContactsProxy.UtilityEmailType), emailPrimary.DirectoryTypeId.ToString());

                                if (dirtype != UtilityEmailType.Home && dirtype != UtilityEmailType.Other && dirtype != UtilityEmailType.Work)
                                {
                                    dirtype = UtilityEmailType.Home;
                                }

                                var emailRequest = new Email()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    EmailAdress = oDriver.Email,
                                    CommunicationType = "Email",
                                    IsPrimary = true,

                                    DirectoryTypeId = dirtype, //emailPrimary.DirectoryTypeId.ToString() == "2" ? 1 : emailPrimary.DirectoryTypeId,
                                    DirectoryDetailId = emailPrimary.DirectoryDetailId
                                };
                                contactsServiceClient.UpdateEmail(emailRequest);
                                noEmail = false;
                            }
                        }

                        if (noEmail)
                        {
                            var emailRequest = new Email()
                            {
                                CorpId = CORPORATION_ID,
                                customerNumber = CustomerNumber,
                                EmailAdress = oDriver.Email,
                                CommunicationType = "Email",
                                DirectoryTypeId = UtilityEmailType.Home,
                                IsPrimary = true
                            };
                            contactsServiceClient.AddEmail(emailRequest);
                        }
                    }


                    var dataPhone = contactsServiceClient.GetAllPhone(CORPORATION_ID, CustomerNumber);
                    var oPhone = JsonConvert.DeserializeObject<List<Phone>>(dataPhone.JSONResult);

                    if (oPhone.Count() > 0)
                    {
                        if (!string.IsNullOrEmpty(oDriver.PhoneNumber))
                        {
                            var phonePrimary = oPhone.FirstOrDefault(x => x.IsPrimary && x.DirectoryTypeId == UtilityPhoneType.Home);
                            bool nophone = true;
                            if (phonePrimary != null)
                            {
                                var phoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.PhoneNumber,
                                    DirectoryTypeId = UtilityPhoneType.Home,
                                    CommunicationType = "Phone",
                                    IsPrimary = true,
                                    CountryCode = " ",
                                    AreaCode = " ",

                                    DirectoryDetailId = phonePrimary.DirectoryDetailId
                                };

                                contactsServiceClient.UpdatePhone(phoneRequest);
                                nophone = false;
                            }

                            if (nophone)
                            {
                                var phoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.PhoneNumber,
                                    DirectoryTypeId = UtilityPhoneType.Home,
                                    CommunicationType = "Phone",
                                    IsPrimary = true,
                                    CountryCode = " ",
                                    AreaCode = " ",
                                };

                                contactsServiceClient.AddPhone(phoneRequest);
                            }
                        }

                        if (!string.IsNullOrEmpty(oDriver.WorkPhone))
                        {
                            var phoneWorkPrimary = oPhone.FirstOrDefault(x => x.DirectoryTypeId == UtilityPhoneType.Work);
                            bool nophonewk = true;
                            if (phoneWorkPrimary != null)
                            {
                                var workPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.WorkPhone,
                                    DirectoryTypeId = UtilityPhoneType.Work,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",

                                    DirectoryDetailId = phoneWorkPrimary.DirectoryDetailId,
                                };

                                contactsServiceClient.UpdatePhone(workPhoneRequest);
                                nophonewk = false;
                            }

                            if (nophonewk)
                            {
                                var workPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.WorkPhone,
                                    DirectoryTypeId = UtilityPhoneType.Work,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",
                                };

                                contactsServiceClient.AddPhone(workPhoneRequest);
                            }
                        }

                        if (!string.IsNullOrEmpty(oDriver.Mobile))
                        {
                            var phoneMobilePrimary = oPhone.FirstOrDefault(x => x.DirectoryTypeId == UtilityPhoneType.CellPhone);
                            bool nophonemob = true;
                            if (phoneMobilePrimary != null)
                            {
                                var cellPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.Mobile,
                                    DirectoryTypeId = UtilityPhoneType.CellPhone,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",

                                    DirectoryDetailId = phoneMobilePrimary.DirectoryDetailId,
                                };

                                contactsServiceClient.UpdatePhone(cellPhoneRequest);
                                nophonemob = false;
                            }

                            if (nophonemob)
                            {
                                var cellPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.Mobile,
                                    DirectoryTypeId = UtilityPhoneType.CellPhone,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",
                                };

                                contactsServiceClient.AddPhone(cellPhoneRequest);
                            }
                        }

                        if (!string.IsNullOrEmpty(oDriver.Fax))
                        {
                            var phonefaxPrimary = oPhone.FirstOrDefault(x => x.DirectoryTypeId == UtilityPhoneType.Fax);
                            bool nophonefax = true;
                            if (phonefaxPrimary != null)
                            {
                                var faxPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.Fax,
                                    DirectoryTypeId = UtilityPhoneType.Fax,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",

                                    DirectoryDetailId = phonefaxPrimary.DirectoryDetailId,
                                };

                                contactsServiceClient.UpdatePhone(faxPhoneRequest);
                                nophonefax = false;
                            }

                            if (nophonefax)
                            {
                                var faxPhoneRequest = new Phone()
                                {
                                    CorpId = CORPORATION_ID,
                                    customerNumber = CustomerNumber,
                                    PhoneNumber = oDriver.Fax,
                                    DirectoryTypeId = UtilityPhoneType.Fax,
                                    CommunicationType = "Phone",
                                    IsPrimary = false,
                                    CountryCode = " ",
                                    AreaCode = " ",
                                };

                                contactsServiceClient.AddPhone(faxPhoneRequest);
                            }
                        }
                    }


                    var dataAddress = contactsServiceClient.GetAllAddress(CORPORATION_ID, CustomerNumber);
                    var oAddress = JsonConvert.DeserializeObject<List<Address>>(dataAddress.JSONResult);
                    bool noAddress = true;

                    if (!string.IsNullOrEmpty(oDriver.Address))
                    {
                        if (oAddress.Count() > 0)
                        {
                            var addressPrimary = oAddress.FirstOrDefault(x => x.IsPrimary);
                            if (addressPrimary != null)
                            {
                                var personalAddressRequest = new Address()
                                {
                                    CorpId = CORPORATION_ID,
                                    DirectoryTypeId = UtilityAddressType.HomeAddress,
                                    StreetAddress = oDriver.Address,
                                    CountryId = oDriver.City_Country_Id,
                                    RegionId = 24,
                                    DomesticregId = oDriver.City_Domesticreg_Id,
                                    StateProvId = oDriver.City_State_Prov_Id,
                                    CityId = oDriver.City_City_Id,
                                    ZipCode = "898989",
                                    IsPrimary = true,
                                    CommunicationType = "Address",
                                    customerNumber = CustomerNumber,

                                    DirectoryDetailId = addressPrimary.DirectoryDetailId
                                };

                                contactsServiceClient.UpdateAddress(personalAddressRequest);
                                noAddress = false;
                            }
                        }

                        if (noAddress)
                        {
                            var personalAddressRequest = new Address()
                            {
                                CorpId = CORPORATION_ID,
                                DirectoryTypeId = UtilityAddressType.HomeAddress,
                                StreetAddress = oDriver.Address,
                                CountryId = oDriver.City_Country_Id,
                                RegionId = 24,
                                DomesticregId = oDriver.City_Domesticreg_Id,
                                StateProvId = oDriver.City_State_Prov_Id,
                                CityId = oDriver.City_City_Id,
                                ZipCode = "898989",
                                IsPrimary = true,
                                CommunicationType = "Address",
                                customerNumber = CustomerNumber
                            };

                            contactsServiceClient.AddAddress(personalAddressRequest);
                        }
                    }

                    /*Setianndo formularios PEP Y BF*/
                    var ContactId = oContact.ContactId;

                    foreach (var item in oAllFinalBeneficiarys)
                    {
                        SetContactFinalBeneficiary(ContactId, item.IdentityId.GetValueOrDefault(), item.name, item.percentageParticipation.GetValueOrDefault(), true, UserID, item.isPEP, item.pepFormularyOptionsId, item.IdentificationTypeId.toInt(), item.IdentificationNumber, item.NationalityCountryId, out lastMessage);
                    }

                    foreach (var item in oAllPepFormularys)
                    {
                        SetContactPepFormulary(ContactId, item.Id, item.name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, UserID, item.BeneficiaryId, item.IsPepManagerCompany, out lastMessage);
                    }
                    /**/
                }
            }

            return
                 CustomerNumber;
        }

        private VOProxy.getResult InsertPolicyHeaderNew
            (
            Entity.Entities.Quotation quotation,
            Entity.Entities.Driver principal,
            string agentNameId,
            int retryAmount,
            string customerNumber,
            string policyId,
            int idOficina,
            int currencyId,
            GetMappingElementTypeIdNew getMappingFunction,
            int UserID,
            IEnumerable<Entity.Entities.VehicleProduct> oVehicles
            )
        {
            var getOfficeCodeSuccess = false;
            var insertPolicySuccess = false;
            string lastMessage = string.Empty;


            VOProxy.getResult insertedHeader = null;

            var newPolicy = new CaseNewCase();
            newPolicy.Age = principal.GetAge();
            newPolicy.AgentNameId = agentNameId;
            newPolicy.AnnualFamilyIncome = null;
            newPolicy.AnnualPersonalIncome = null;
            newPolicy.CityId = 826849;
            newPolicy.CityOfResidenceId = 0;
            newPolicy.CompanyActivity = null;
            newPolicy.CompanyFoundationDate = null;
            newPolicy.CompanyName = principal.Company;
            newPolicy.ContactStatusId = 0;
            newPolicy.CorpId = CORPORATION_ID;
            newPolicy.CountryId = 129;
            newPolicy.CountryOfBirthId = principal.Nationality_Global_Country_Id;
            newPolicy.CountryOfResidenceId = 129;
            newPolicy.CustomerNumber = customerNumber;
            newPolicy.DirectoryId = 0;

            //newPolicy.Dob = principal.DateOfBirth;

            DateTime? dob = null;
            bool iscompania = false;
            if (principal.IdentificationType == "RNC")
            {
                dob = null;
                iscompania = true;
            }
            else
                dob = principal.DateOfBirth.Date;

            string InstitutionalName =
                iscompania
                ?
                (
                principal.FirstName.TrimStart().TrimEnd()
                +
                (!string.IsNullOrWhiteSpace(principal.FirstSurname) ? " " + principal.FirstSurname.TrimStart().TrimEnd() : null)
                )
                : null;


            newPolicy.Dob = dob;
            newPolicy.IsCompany = iscompania;
            newPolicy.ContactTypeId = iscompania ? 5 : 1;

            newPolicy.DomesticregId = 1;
            newPolicy.DomesticRegOfResidenceId = 0;
            newPolicy.FirstLastName = principal.FirstSurname;
            newPolicy.FirstName = principal.FirstName;
            newPolicy.Gender = principal.GetSexOneLetter();
            newPolicy.Height = null;
            newPolicy.HeigthTypeId = null;
            newPolicy.InstitutionalCountryId = 129; //República Dominicana
            newPolicy.InstitutionalName = InstitutionalName;
            newPolicy.IsIllustration = false;
            newPolicy.LaborTasks = null;
            newPolicy.LengthWorkMonth = null;
            newPolicy.LengthWorkYear = null;
            newPolicy.LineOfBusiness = null; // quotation.BusinessLine.Name; Solicitado como null por Carlos Lebron
            newPolicy.LineOfBusiness2 = null; // Solicitado como null por Carlos Lebron
            newPolicy.MaritalStatId = getMappingFunction(Convert.ToInt32(MappingElementType.MaritalStatus, CultureInfo.InvariantCulture), principal.MaritalStatus);
            newPolicy.MiddleName = principal.SecondName;
            newPolicy.NearAge = 0;
            newPolicy.Nickname = principal.FirstName;
            newPolicy.OccupationId = 0;
            newPolicy.OccupGroupTypeId = 0;
            newPolicy.OfficeId = 0;
            newPolicy.PolicyNo = quotation.QuotationNumber;
            newPolicy.PolicyStatusId = 26;
            newPolicy.ReferredByContactId = 0;
            newPolicy.ReferredByRelationshipId = 0;
            newPolicy.RegionId = 24;
            newPolicy.RegionOfBirthId = 0;
            newPolicy.RegionOfResidenceId = 0;
            newPolicy.RelationshiptoAgent = 0;
            newPolicy.RelationshiptoOwner = 0;
            newPolicy.SecondLastName = principal.SecondSurname;
            newPolicy.Smoker = null;
            newPolicy.StateOfResidenceId = 0;
            newPolicy.StateProvId = 815;
            newPolicy.StatusChangeTypeId = 13;
            newPolicy.UserId = UserID;
            newPolicy.Weigth = null;
            newPolicy.WeigthTypeId = null;

            VOProxy.getResult officeResult = null;
            try
            {
                officeResult = virtualOfficeServiceClient.GetOfficeCode(idOficina);

                if (officeResult.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage = "Response Code: " + officeResult.Code + "\nMensaje: " + officeResult.Message + "\n--\n";
                    getOfficeCodeSuccess = false;
                }
                else
                    getOfficeCodeSuccess = true;
            }
            catch (Exception ex)
            {
                lastMessage = ex.Message;
            }
            if (!getOfficeCodeSuccess)
            {
                throw new Exception("Error en la llamada al método GetOfficeCode.\nDetalle: " + lastMessage);
            }

            dynamic office = JObject.Parse(officeResult.JSONResult);
            newPolicy.OfficeCode = office.OfficeCode;

            try
            {
                insertedHeader = virtualOfficeServiceClient.InsertPolicy(newPolicy);

                if (insertedHeader.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage += "Response Code: " + insertedHeader.Code + "\nMensaje: " + insertedHeader.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(newPolicy, Formatting.Indented) + "\n--\n";
                    insertPolicySuccess = false;
                }
                else
                {
                    insertPolicySuccess = true;
                    if (policyId != quotation.QuotationNumber)
                    {
                        virtualOfficeServiceClient.SetPolicyNo(quotation.QuotationNumber, policyId);
                    }
                }
            }
            catch (Exception ex)
            {
                lastMessage += ex.Message + "\n--\n";
            }

            if (!insertPolicySuccess)
            {
                throw new Exception("Error en la llamada al método InsertPolicy.\nDetalle: " + lastMessage);
            }
            else
            {
                var totalInsured = 0m;
                oVehicles.ToList().ForEach(f => totalInsured += f.InsuredAmount.GetValueOrDefault(0));

                dynamic header = JObject.Parse(insertedHeader.JSONResult);
                /*10 = efectiva, 26 = aprobada por el cliente*/
                var policy = new Policy()
                {
                    PolicyStatusId = quotation.SendInspectionOnly.GetValueOrDefault() ? 26 : 10,
                    BussinessLineId = 2,
                    BussinessLineType = BUSINESS_LINE_TYPE_ID,
                    PolicyNo = (quotation.RequestTypeId.GetValueOrDefault() == (int)RequestType.Inclusion) ? quotation.QuotationNumber : policyId,
                    InsuredAmount = totalInsured, //Valor asegurado
                    AnnualPremium = quotation.TotalPrime.Value, //prima anual sin impuestos
                    InitialPremium = quotation.AmountToPayEnteredByUser.GetValueOrDefault(0), //valor pagado
                    CurrencyId = currencyId, //valor moneda
                    PaymentsCurrencyId = currencyId,
                    PolicyCurrencyId = currencyId,
                    QuotationCurrencyId = currencyId,
                    TaxPremium = quotation.TotalISC,
                    TaxPercentage = quotation.ISCPercentage,
                    SubmitDate = quotation.Created,
                    PolicyEffectiveDate = quotation.StartDate,
                    ExpirationDate = quotation.EndDate,
                    InsuranceDuration = quotation.QtyDayOfVigency,//Cantidad de Dias de duracion Cotizacion 
                    DiscountPercentage = ((quotation.FlotillaDiscountPercent.HasValue ? quotation.FlotillaDiscountPercent.Value : 0) / 100),
                    DiscountPremium = (quotation.TotalFlotillaDiscount.HasValue ? quotation.TotalFlotillaDiscount.Value : 0),
                    financed = quotation.Financed,
                    monthlyPayment = quotation.MonthlyPayment,
                    period = quotation.Period,
                    DirectDebit = quotation.Domiciliation,
                    RequestTypeId = quotation.RequestTypeId,
                    ProratedPremium = (decimal?)null,
                    policyNoMain = quotation.policyNoMain,
                    DomicileInitialPayment = quotation.DomicileInitialPayment
                };

                VOProxy.ResultCode updatedHeader = null;
                bool updatePolicySuccess = false;

                try
                {
                    updatedHeader = virtualOfficeServiceClient.UpdatePolicy(policy);

                    if (updatedHeader.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + updatedHeader.Code + "\nMensaje: " + updatedHeader.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(policy, Formatting.Indented) + "\n--\n";
                        updatePolicySuccess = false;
                    }
                    else
                        updatePolicySuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    updatePolicySuccess = false;
                }

                if (!updatePolicySuccess)
                {
                    throw new Exception("Error en la llamada al método UpdatePolicy.\nDetalle: " + lastMessage);
                }
            }

            return
                insertedHeader;
        }

        public bool SetAutoQuotation(QuotationAuto quotation,
            string username,
            int agentId,
            int idOficina,
            int currencyId,
            int retryAmount,
            string policyId,
            string sourceID,
            int codRamo,
            List<STL.POS.Data.CSEntities.ListVehicleSourceID> listVehicleSourceID,
            GetMappingElementTypeId getMappingFunction,
            int UserID,
            List<IdentificationFinalBeneficiary> AllFinalBeneficiarys,
            List<PepFormulary> AllPepFormularys,
            PersonInfo personinfo,
            Dictionary<int, int> personJobForGlobal,
            decimal MinAllowedAmountToPay,
            out List<string> statusMessages
            )
        {
            //First of all, check/create contact
            var principal = quotation.GetPrincipal();
            statusMessages = new List<string>();

            var currentStatusMessage = string.Empty;
            var customerNumber = string.Empty;

            try
            {
                customerNumber = GetCustomerNumber(agentId, principal, retryAmount, getMappingFunction, AllFinalBeneficiarys, AllPepFormularys, personinfo, personJobForGlobal, UserID, quotation);
            }
            catch (Exception ex)
            {
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el contacto.", ex.Message));
                return false;
            }

            VOProxy.getResult insertedHeader;

            try
            {
                insertedHeader = InsertPolicyHeader(quotation, principal, username, retryAmount, customerNumber, policyId, idOficina, currencyId, getMappingFunction, UserID);
            }
            catch (Exception ex)
            {
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el header de la cotización.", ex.Message));
                return false;
            }

            if (!string.IsNullOrEmpty(sourceID))
            {
                /*Insertando el sourceid*/
                try
                {
                    var rs = setPolicySourceId(policyId, sourceID);
                }
                catch (Exception ex)
                {
                    statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido agregar correctamente el source_ID de la cotización.", ex.Message));
                    return false;
                }
                /**/
            }

            dynamic insertPolicyResult = JObject.Parse(insertedHeader.JSONResult);
            int count = 1;
            int vehicleIndex = 1;
            int lastVehicleID = 0;

            foreach (var vehicle in quotation.VehicleProducts)
            {
                count = 1;

                /*Repetir el bloque de codigo todas las veces que indique el campo VehicleQuantity*/
                while (count <= vehicle.VehicleQuantity)
                {
                    var primacobertura = GetPrimaCoberturaSysflex(Convert.ToDecimal(quotation.QuotationCoreNumber), (vehicle.SecuenciaVehicleSysflex.HasValue ? vehicle.SecuenciaVehicleSysflex.Value : 1), "");

                    VOProxy.getResult insertedVehicle;
                    string currentVehicleSourceID = "";

                    if (lastVehicleID != vehicle.Id)
                    {
                        var sourcesID = listVehicleSourceID.FirstOrDefault(x => x.VehicleID == vehicle.Id);

                        if (sourcesID != null)
                        {
                            currentVehicleSourceID = sourcesID.SourceID;
                        }
                    }
                    else
                    {
                        var sourcesIDByIndex = listVehicleSourceID.FirstOrDefault(x => x.Index == vehicleIndex);

                        if (sourcesIDByIndex != null)
                        {
                            currentVehicleSourceID = sourcesIDByIndex.SourceID;
                        }
                    }

                    try
                    {
                        insertedVehicle = AddVehicleInsured(quotation, vehicle, insertPolicyResult, getMappingFunction, retryAmount, currentVehicleSourceID, UserID);
                    }
                    catch (Exception ex)
                    {
                        statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el vehículo (AddVehicleInsured).", ex.Message));
                        return false;
                    }

                    var limit = vehicle.ProductLimits.FirstOrDefault(pl => pl.IsSelected);

                    dynamic addVehicleInsuredResponse = JObject.Parse(insertedVehicle.JSONResult);

                    if (limit != null)
                    {
                        List<CoverageDetail> coverages = new List<CoverageDetail>();
                        Decimal? DeductiblePercent = null;
                        if (!string.IsNullOrWhiteSpace(limit.SelectedDeductibleName))
                        {
                            Decimal deduc = 0;
                            var dedArr = limit.SelectedDeductibleName.Split(' ');
                            if (Decimal.TryParse(dedArr[0], out deduc))
                                DeductiblePercent = deduc;
                        }

                        List<PVechicleCoverage> coveragesToSend = new List<PVechicleCoverage>();
                        int productId = 0, productTypeId = 0, coverageGroupId = 0, coverageId = 0;

                        // Get ProductType
                        try
                        {
                            productTypeId = GetProductTypeId((int)insertPolicyResult.CorpId, vehicle.SelectedProductName, retryAmount);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetProductTypeId", ex.Message));
                        }

                        // Get Product Id
                        try
                        {
                            productId = GetProductId(vehicle.SelectedVehicleTypeName, productTypeId, retryAmount);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetProductId", ex.Message));
                            return false;
                        }

                        // Get Coverage Group
                        try
                        {
                            coverageGroupId = GetCoverageGroupId((int)insertPolicyResult.CorpId, vehicle.SelectedCoverageName, retryAmount);
                        }
                        catch (Exception ex)
                        {
                            statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "Error en el llamado a GetCoverageGroupId", ex.Message));
                        }

                        foreach (var c in limit.ThirdPartyCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 1, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }

                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = quotation.BusinessLine == null ? 2 : quotation.BusinessLine.CoreId;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit;
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 1; //CoverageType Daños Terceros
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;
                            vehicleCov.DeductiblePercentage = DeductiblePercent;
                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = false;
                            vehicleCov.IsService = false;

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;

                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        foreach (var c in limit.SelfDamagesCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 2, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }

                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = quotation.BusinessLine == null ? 2 : quotation.BusinessLine.CoreId;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit;
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 2; //CoverageType Daños Propios
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;

                            decimal deductibleRoturaCristales = 10;

                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = true;
                            vehicleCov.IsService = false;

                            var SysFlexProxy = new STL.POS.WsProxy.CoreProxy(new SysFlexServiceClient());

                            //Rotura de Cristal
                            if (c.CoverageDetailCoreId.Equals(14))
                            {
                                var getResult = SysFlexProxy.GetCoverage(vehicle.SelectedCoverageCoreId.GetValueOrDefault(), 0, vehicle.VehiclePrice, codRamo);
                                if (getResult.Any())
                                {
                                    var result = getResult.FirstOrDefault(x => x.CoverageDetailName.ToLower() == "Rotura de Cristales".ToLower());

                                    if (result != null)
                                        deductibleRoturaCristales = result.deductible.GetValueOrDefault();

                                    vehicleCov.DeductiblePercentage = deductibleRoturaCristales;
                                }
                            }
                            else
                            {
                                vehicleCov.DeductiblePercentage = DeductiblePercent;
                            }


                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;
                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        var servicesCoverages = from sc in limit.ServicesCoverages
                                                from c in sc.Coverages
                                                where c.IsSelected
                                                select c;

                        foreach (var c in servicesCoverages)
                        {
                            try
                            {
                                coverageId = GetCoverageId((int)insertPolicyResult.CorpId, c.Name, 3, retryAmount);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add("Error en la llamada al método GetCoverageId.\nDetalle: " + ex.Message);
                                return false;
                            }

                            var vehicleCov = new PVechicleCoverage();
                            vehicleCov.BlId = quotation.BusinessLine == null ? 2 : quotation.BusinessLine.CoreId;
                            vehicleCov.BlTypeId = BUSINESS_LINE_TYPE_ID;
                            vehicleCov.CorpId = insertPolicyResult.CorpId;
                            vehicleCov.CountryId = insertPolicyResult.CountryId;
                            vehicleCov.CoverageId = coverageId;
                            vehicleCov.CoverageLimit = c.Limit;
                            vehicleCov.CoverageStatus = 1;
                            vehicleCov.CoverageTypeId = 3; //CoverageType Servicios
                            vehicleCov.CurrencyId = currencyId;
                            vehicleCov.GroupId = coverageGroupId;
                            vehicleCov.PackagePrice = 0;
                            vehicleCov.ProductId = productId;
                            vehicleCov.RegionId = insertPolicyResult.RegionId;
                            vehicleCov.UserId = UserID;
                            vehicleCov.VehicleTypeId = vehicle.SelectedVehicleTypeId.Value;
                            vehicleCov.VehicleUniqueId = addVehicleInsuredResponse.VehicleUniqueId;
                            vehicleCov.DeductiblePercentage = DeductiblePercent;

                            vehicleCov.UnitaryPrice = 0;
                            vehicleCov.PremiumPercentage = 0;
                            vehicleCov.oldUnitaryPrice = 0;
                            vehicleCov.oldPremiumPercentage = 0;
                            vehicleCov.applayDiscountSurgarge = false;
                            vehicleCov.IsService = true;

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == c.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    vehicleCov.UnitaryPrice = realCObert.Prima;
                                    vehicleCov.PremiumPercentage = realCObert.Porciento;

                                    vehicleCov.oldUnitaryPrice = realCObert.Prima;
                                    vehicleCov.oldPremiumPercentage = realCObert.Porciento;

                                    vehicleCov.DeductibleAmount = realCObert.MinimoDeducible;
                                    vehicleCov.coinsurancePercentage = realCObert.PorcientoCobertura.HasValue ? realCObert.PorcientoCobertura.Value : 0;
                                    vehicleCov.DeductiblePercentage = realCObert.Deducible;
                                }
                            }

                            coveragesToSend.Add(vehicleCov);
                        }

                        foreach (var c in coveragesToSend)
                        {
                            try
                            {
                                CheckCoverageGroupDetailRelation(retryAmount, c);
                                CheckCoverageProductRelation(quotation, insertPolicyResult, vehicle.SelectedVehicleTypeId.Value, retryAmount, c);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido chequear la existencia de la relacion Coverage-Product.", ex.Message));
                                return false;
                            }

                            try
                            {
                                AddVehicleCoverage(retryAmount, c);
                            }
                            catch (Exception ex)
                            {
                                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido chequear la existencia de la relacion Coverage-Product.", ex.Message));
                                return false;
                            }
                        }
                    }

                    count++;
                    vehicleIndex++;
                    lastVehicleID = vehicle.Id;
                }
            }

            //Insertanto Acuerdo de Pago
            try
            {
                SetPaymentAgreement(quotation, insertPolicyResult, UserID, MinAllowedAmountToPay);
            }
            catch (Exception ex)
            {
                //Simplemente capturo el error para saber si fallo
                statusMessages.Add(string.Format(ERROR_MESSAGE_TEMPLATE, "No se ha podido generar correctamente el acuerdo de pago (SetPaymentAgreement).", ex.Message));
            }

            //Actualizar la tabla temporal de la bandeja de cotizaciones
            //Thread newThread;
            //newThread = new Thread(this.UpdateQuotationTemp);
            //newThread.Start(policyId);         

            try
            {
                bool resultFlagTable = false;
                resultFlagTable = this.UpdateOneQuotationInfoTemp(quotation, UserID);
            }
            catch (Exception ex)
            {
                string thisError = ex.Message;
            }

            return true;
        }

        private VOProxy.getResult InsertPolicyHeader(QuotationAuto quotation,
            Person principal,
            string agentNameId,
            int retryAmount,
            string customerNumber,
            string policyId,
            int idOficina,
            int currencyId,
            GetMappingElementTypeId getMappingFunction,
            int UserID)
        {
            var getOfficeCodeSuccess = false;
            var insertPolicySuccess = false;
            string lastMessage = string.Empty;

            var newPolicy = new CaseNewCase();
            newPolicy.Age = principal.GetAge();
            newPolicy.AgentNameId = agentNameId;
            newPolicy.AnnualFamilyIncome = null;
            newPolicy.AnnualPersonalIncome = null;
            newPolicy.CityId = 826849;
            newPolicy.CityOfResidenceId = 0;
            newPolicy.CompanyActivity = null;
            newPolicy.CompanyFoundationDate = null;
            newPolicy.CompanyName = principal.Company;
            newPolicy.ContactStatusId = 0;
            newPolicy.ContactTypeId = 1;
            newPolicy.CorpId = CORPORATION_ID;
            newPolicy.CountryId = 129;
            newPolicy.CountryOfBirthId = principal.Nationality.Global_Country_Id;
            newPolicy.CountryOfResidenceId = 129;
            newPolicy.CustomerNumber = customerNumber;
            newPolicy.DirectoryId = 0;
            //newPolicy.Dob = principal.DateOfBirth;

            DateTime? dob = null;
            bool iscompania = false;
            if (principal.IdentificationType == "RNC")
            {
                dob = null;
                iscompania = true;
            }
            else
            {
                dob = principal.DateOfBirth.Date;
            }
            newPolicy.Dob = dob;
            newPolicy.IsCompany = iscompania;

            newPolicy.DomesticregId = 1;
            newPolicy.DomesticRegOfResidenceId = 0;
            newPolicy.FirstLastName = principal.FirstSurname;
            newPolicy.FirstName = principal.FirstName;
            newPolicy.Gender = principal.GetSexOneLetter();
            newPolicy.Height = null;
            newPolicy.HeigthTypeId = null;
            newPolicy.InstitutionalCountryId = 129; //República Dominicana
            newPolicy.InstitutionalName = null;
            newPolicy.IsIllustration = false;
            newPolicy.LaborTasks = null;
            newPolicy.LengthWorkMonth = null;
            newPolicy.LengthWorkYear = null;
            newPolicy.LineOfBusiness = null; // quotation.BusinessLine.Name; Solicitado como null por Carlos Lebron
            newPolicy.LineOfBusiness2 = null; // Solicitado como null por Carlos Lebron
            newPolicy.MaritalStatId = getMappingFunction(MappingElementType.MaritalStatus, principal.MaritalStatus);
            newPolicy.MiddleName = principal.SecondName;
            newPolicy.NearAge = 0;
            newPolicy.Nickname = principal.FirstName;
            newPolicy.OccupationId = 0;
            newPolicy.OccupGroupTypeId = 0;
            newPolicy.OfficeId = 0;

            newPolicy.PolicyNo = quotation.QuotationNumber;
            newPolicy.PolicyStatusId = 26;
            newPolicy.ReferredByContactId = 0;
            newPolicy.ReferredByRelationshipId = 0;
            newPolicy.RegionId = 24;
            newPolicy.RegionOfBirthId = 0;
            newPolicy.RegionOfResidenceId = 0;
            newPolicy.RelationshiptoAgent = 0;
            newPolicy.RelationshiptoOwner = 0;
            newPolicy.SecondLastName = principal.SecondSurname;
            newPolicy.Smoker = null;
            newPolicy.StateOfResidenceId = 0;
            newPolicy.StateProvId = 815;
            newPolicy.StatusChangeTypeId = 13;
            newPolicy.UserId = UserID;
            newPolicy.Weigth = null;
            newPolicy.WeigthTypeId = null;

            VOProxy.getResult officeResult = null;
            try
            {
                officeResult = virtualOfficeServiceClient.GetOfficeCode(idOficina);

                if (officeResult.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage = "Response Code: " + officeResult.Code + "\nMensaje: " + officeResult.Message + "\n--\n";
                    getOfficeCodeSuccess = false;
                }
                else
                    getOfficeCodeSuccess = true;
            }
            catch (Exception ex)
            {
                lastMessage = ex.Message;
            }
            if (!getOfficeCodeSuccess)
            {
                throw new Exception("Error en la llamada al método GetOfficeCode.\nDetalle: " + lastMessage);
            }
            dynamic office = JObject.Parse(officeResult.JSONResult);
            newPolicy.OfficeCode = office.OfficeCode;

            var retryCount = 0;
            VOProxy.getResult insertedHeader = null;

            while (!insertPolicySuccess && retryCount < retryAmount)
            {
                try
                {
                    insertedHeader = virtualOfficeServiceClient.InsertPolicy(newPolicy);


                    if (insertedHeader.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + insertedHeader.Code + "\nMensaje: " + insertedHeader.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(newPolicy, Formatting.Indented) + "\n--\n";
                        insertPolicySuccess = false;
                    }
                    else
                    {
                        insertPolicySuccess = true;
                        if (policyId != quotation.QuotationNumber)
                        {
                            virtualOfficeServiceClient.SetPolicyNo(quotation.QuotationNumber, policyId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                }
                retryCount++;
            }

            if (!insertPolicySuccess)
            {
                throw new Exception("Error en la llamada al método InsertPolicy.\nDetalle: " + lastMessage);
            }
            else
            {
                var totalInsured = 0m;
                quotation.VehicleProducts.ToList().ForEach(f => totalInsured += f.InsuredAmount.GetValueOrDefault(0));

                dynamic header = JObject.Parse(insertedHeader.JSONResult);
                /*10 = efectiva, 26 = aprobada por el cliente*/
                var policy = new Policy()
                {
                    PolicyStatusId = quotation.SendInspectionOnly ? 26 : 10, //Issue 0015818
                    BussinessLineId = quotation.BusinessLine == null ? 2 : quotation.BusinessLine.CoreId,
                    BussinessLineType = BUSINESS_LINE_TYPE_ID,
                    PolicyNo = policyId,
                    InsuredAmount = totalInsured, //Valor asegurado
                    AnnualPremium = quotation.TotalPrime.Value, //prima anual sin impuestos
                    InitialPremium = quotation.AmountPaid.GetValueOrDefault(0), //valor pagado
                    CurrencyId = currencyId, //valor moneda
                    PaymentsCurrencyId = currencyId,
                    PolicyCurrencyId = currencyId,
                    QuotationCurrencyId = currencyId,
                    TaxPremium = quotation.TotalISC,
                    TaxPercentage = quotation.ISCPercentage,
                    SubmitDate = quotation.Created,

                    PolicyEffectiveDate = quotation.StartDate,
                    ExpirationDate = quotation.EndDate,
                    InsuranceDuration = quotation.qtyDayOfVigency,//Cantidad de Dias de duracion Cotizacion

                    DiscountPercentage = ((quotation.FlotillaDiscountPercent.HasValue ? quotation.FlotillaDiscountPercent.Value : 0) / 100),
                    DiscountPremium = (quotation.TotalFlotillaDiscount.HasValue ? quotation.TotalFlotillaDiscount.Value : 0),
                    financed = quotation.Financed,
                    monthlyPayment = quotation.MonthlyPayment,
                    period = quotation.Period,
                    DirectDebit = quotation.Domiciliation,
                    RequestTypeId = quotation.Request_Type_Id,
                    DomicileInitialPayment = quotation.DomicileInitialPayment
                };

                retryCount = 0;
                VOProxy.ResultCode updatedHeader = null;
                bool updatePolicySuccess = false;

                while (!updatePolicySuccess && retryCount < retryAmount)
                {
                    try
                    {
                        updatedHeader = virtualOfficeServiceClient.UpdatePolicy(policy);


                        if (updatedHeader.Code != RESPONSE_CODE_SUCCESS)
                        {
                            lastMessage += "Response Code: " + insertedHeader.Code + "\nMensaje: " + insertedHeader.Message;
                            lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(policy, Formatting.Indented) + "\n--\n";
                            updatePolicySuccess = false;
                        }
                        else
                            updatePolicySuccess = true;
                    }
                    catch (Exception ex)
                    {
                        lastMessage += ex.Message + "\n--\n";
                        updatePolicySuccess = false;
                    }
                    retryCount++;
                }

                if (!updatePolicySuccess)
                {
                    throw new Exception("Error en la llamada al método UpdatePolicy.\nDetalle: " + lastMessage);
                }
            }

            return insertedHeader;
        }

        private MakeModelHomologationResult GetMakeModelHomologation(MakeModelHomologation quotation, string lastMessage)
        {
            MakeModelHomologationResult makeModelHomo = null;

            try
            {

                makeModelHomo = virtualOfficeServiceClient.MakeModelHomologation(quotation);

                if (makeModelHomo.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage += "Response Code: " + makeModelHomo.Code + "\nMensaje: " + makeModelHomo.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(quotation, Formatting.Indented) + "\n--\n";
                }

            }
            catch (Exception ex)
            {
                lastMessage += ex.Message + "\n--\n";
            }

            return makeModelHomo;

        }

        private VOProxy.getResult AddVehicleInsured(QuotationAuto quotation, VehicleProduct vehicle, dynamic insertPolicyResult, GetMappingElementTypeId getMappingFunction, int retryAmount, string SourceID, int UserID)
        {
            string lastMessage = string.Empty;
            int retryCount = 0;

            var vInsured = new PVehicleInsured();

            var makeModelHomologationResult = GetMakeModelHomologation(new MakeModelHomologation()
            {
                PosMakeId = vehicle.VehicleModel.Make_Id,
                PosModelId = vehicle.VehicleModel.Model_Id,
                PosMakeDesc = vehicle.VehicleMakeName,
                PosModelDesc = vehicle.VehicleModel.Model_Desc
            }, lastMessage);

            vInsured.AmbulanceTypeId = null;
            vInsured.CaseSeqNo = insertPolicyResult.CaseSeqNo;
            vInsured.Chassis = vehicle.Chassis;
            vInsured.CityId = insertPolicyResult.CityId; //--
            vInsured.ColorId = getMappingFunction(MappingElementType.Color, vehicle.Color);
            vInsured.CorpId = insertPolicyResult.CorpId;//--
            vInsured.CountryId = insertPolicyResult.CountryId; //--
            vInsured.CylindersTons = string.Empty;
            vInsured.DomesticregId = insertPolicyResult.DomesticregId; //--
            vInsured.Garage = vehicle.StoreName == "Garage";
            vInsured.GeographicLimitation = null;
            vInsured.HistSeqNo = insertPolicyResult.HistSeqNo;
            vInsured.InsuredDate = quotation.StartDate;
            vInsured.InsuredVehicleId = null;
            vInsured.MakeId = makeModelHomologationResult.MakeModelHomologation.GloMakeId; //vInsured.MakeId = vehicle.VehicleModel.Make_Id;
            vInsured.ModelId = makeModelHomologationResult.MakeModelHomologation.GloModelId; //vInsured.ModelId = vehicle.VehicleModel.Model_Id;
            vInsured.OfficeId = insertPolicyResult.OfficeId; //--
            int passengers = 0;
            if (int.TryParse(vehicle.Passengers, out passengers))
                vInsured.PassengerNumber = Convert.ToInt32(vehicle.Passengers);
            else
                vInsured.PassengerNumber = null;
            vInsured.PremiumAmount = vehicle.TotalPrime;
            vInsured.RegionId = insertPolicyResult.RegionId; //--
            vInsured.RegistrationId = null;
            vInsured.Registry = vehicle.Plate;
            vInsured.RentLengthId = null;
            vInsured.RentTypeId = null;
            vInsured.StateProvId = insertPolicyResult.StateProvId; //--
            vInsured.StoredId = getMappingFunction(MappingElementType.Storage, vehicle.StoreId.ToString());
            vInsured.UsageId = getMappingFunction(MappingElementType.Usage, vehicle.UsageName);
            vInsured.UserId = UserID;
            vInsured.VehicleTypeId = vehicle.VehicleModel.Vehicle_Type_Id;
            vInsured.VehicleUniqueId = 0;
            vInsured.VehicleValue = Convert.ToInt32(vehicle.InsuredAmount.GetValueOrDefault(0));
            vInsured.Year = vehicle.Year;
            vInsured.IsNew = vehicle.VehicleYearOld == "0 Km";

            var limit = vehicle.ProductLimits.FirstOrDefault(pl => pl.IsSelected);
            if (limit != null)
            {
                vInsured.DPAPremiumAmount = Math.Abs(limit.TpPrime.GetValueOrDefault(0));
                vInsured.DPPremiumAmount = Math.Abs(limit.SdPrime.GetValueOrDefault(0));
                vInsured.SRVPremiumAmount = Math.Abs(limit.ServicesPrime.GetValueOrDefault(0));
            }
            vInsured.SourceId = SourceID;
            vInsured.rateJsonSysFlex = ratejson(vehicle.RateJson);

            /*Campos para Facultativo*/
            vInsured.AppliesToReinsurance = vehicle.IsFacultative.HasValue ? vehicle.IsFacultative.Value : false;
            vInsured.ReinsuranceAmount = vehicle.AmountFacultative.HasValue ? vehicle.AmountFacultative.Value : 0;
            /**/

            retryCount = 0;
            var insertVehicleInsured = false;
            VOProxy.getResult insertedVehicle = null;

            while (!insertVehicleInsured && retryCount < retryAmount)
            {
                try
                {
                    insertedVehicle = virtualOfficeServiceClient.AddVehicleInsured(vInsured);

                    if (insertedVehicle.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + insertedVehicle.Code + "\nMensaje: " + insertedVehicle.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(vInsured, Formatting.Indented) + "\n--\n";
                        insertVehicleInsured = false;
                    }
                    else
                        insertVehicleInsured = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    insertVehicleInsured = false;
                }
                retryCount++;
            }

            if (!insertVehicleInsured)
                throw new Exception("Error en el llamado al método AddVehicleInsured.\nDetalle: " + lastMessage);

            return insertedVehicle;
        }


        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// </summary>
        /// <param name="quotation"></param>
        /// <param name="vehicle"></param>
        /// <param name="insertPolicyResult"></param>
        /// <param name="getMappingFunction"></param>
        /// <param name="retryAmount"></param>
        /// <param name="SourceID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        private VOProxy.getResult AddVehicleInsuredNew(Entity.Entities.Quotation quotation,
                                                       Entity.Entities.VehicleProduct vehicle,
                                                       dynamic insertPolicyResult,
                                                       GetMappingElementTypeIdNew getMappingFunction,
                                                       int retryAmount,
                                                       string SourceID,
                                                       int UserID,
                                                       getVehicleProductLimitVehicle VehicleProductLitmit,
                                                       string EndorsementBeneficiary
                                                       )
        {
            string lastMessage = string.Empty;

            var vInsured = new PVehicleInsured();

            var makeModelHomologationResult = GetMakeModelHomologation(new MakeModelHomologation()
            {
                PosMakeId = vehicle.VehicleModel_Make_Id,
                PosModelId = vehicle.VehicleModel_Model_Id,
                PosMakeDesc = vehicle.VehicleMakeName,
                PosModelDesc = vehicle.ModelDesc
            }, lastMessage);

            vInsured.AmbulanceTypeId = null;
            vInsured.CaseSeqNo = insertPolicyResult.CaseSeqNo;
            vInsured.Chassis = vehicle.Chassis;
            vInsured.CityId = insertPolicyResult.CityId; //--
            vInsured.ColorId = getMappingFunction(Convert.ToInt32(MappingElementType.Color, CultureInfo.InvariantCulture), vehicle.Color);
            vInsured.CorpId = insertPolicyResult.CorpId;//--
            vInsured.CountryId = insertPolicyResult.CountryId; //--
            vInsured.CylindersTons = string.Empty;
            vInsured.DomesticregId = insertPolicyResult.DomesticregId; //--
            vInsured.Garage = vehicle.StoreName == "Garage";
            vInsured.GeographicLimitation = null;
            vInsured.HistSeqNo = insertPolicyResult.HistSeqNo;
            vInsured.InsuredDate = quotation.StartDate;
            vInsured.InsuredVehicleId = null;
            vInsured.proratedPremium = vehicle.ProratedPremium;

            vInsured.MakeId = makeModelHomologationResult.MakeModelHomologation.GloMakeId; //vInsured.MakeId = vehicle.VehicleModel.Make_Id;
            vInsured.ModelId = makeModelHomologationResult.MakeModelHomologation.GloModelId; //vInsured.ModelId = vehicle.VehicleModel.Model_Id;
            vInsured.OfficeId = insertPolicyResult.OfficeId; //--
            int passengers = 0;
            if (int.TryParse(vehicle.Passengers, out passengers))
                vInsured.PassengerNumber = Convert.ToInt32(vehicle.Passengers);
            else
                vInsured.PassengerNumber = null;
            vInsured.PremiumAmount = vehicle.TotalPrime;
            vInsured.RegionId = insertPolicyResult.RegionId; //--
            vInsured.RegistrationId = null;
            vInsured.Registry = vehicle.Plate;
            vInsured.RentLengthId = null;
            vInsured.RentTypeId = null;
            vInsured.StateProvId = insertPolicyResult.StateProvId; //--
            vInsured.StoredId = getMappingFunction(Convert.ToInt32(MappingElementType.Storage, CultureInfo.InvariantCulture), vehicle.StoreId.ToString());
            vInsured.UsageId = getMappingFunction(Convert.ToInt32(MappingElementType.Usage, CultureInfo.InvariantCulture), vehicle.UsageName);
            vInsured.UserId = UserID;
            vInsured.VehicleTypeId = vehicle.SelectedVehicleTypeId;
            vInsured.VehicleUniqueId = 0;
            vInsured.VehicleValue = Convert.ToInt32(vehicle.InsuredAmount.GetValueOrDefault(0));
            vInsured.Year = vehicle.Year;
            vInsured.IsNew = vehicle.VehicleYearOld == "0 Km";
            vInsured.minimumdepreciation = vehicle.minimumdepreciation;
            vInsured.isOverPreMium = vehicle.IsOverPreMium;
            vInsured.minimumdepreciationId = vehicle.minimumdepreciationId;
            vInsured.totaldepreciation = vehicle.TotalDeppreciation;
            vInsured.totaldepreciationId = vehicle.TotalDepreciationId;

            var limit = VehicleProductLitmit(vehicle.Id.GetValueOrDefault()).FirstOrDefault(p => p.IsSelected.GetValueOrDefault());

            if (limit != null)
            {
                vInsured.DPAPremiumAmount = Math.Abs(limit.TpPrime.GetValueOrDefault(0));
                vInsured.DPPremiumAmount = Math.Abs(limit.SdPrime.GetValueOrDefault(0));
                vInsured.SRVPremiumAmount = Math.Abs(limit.ServicesPrime.GetValueOrDefault(0));
            }

            vInsured.SourceId = SourceID;
            vInsured.rateJsonSysFlex = ratejson(vehicle.RateJson);

            /*Campos para Facultativo*/
            vInsured.AppliesToReinsurance = vehicle.IsFacultative.HasValue ? vehicle.IsFacultative.Value : false;
            vInsured.ReinsuranceAmount = vehicle.AmountFacultative.HasValue ? vehicle.AmountFacultative.Value : 0;
            /**/

            /*Seteo de Endoso*/
            vInsured.EndorsementBeneficiary = !string.IsNullOrEmpty(EndorsementBeneficiary) ? EndorsementBeneficiary : null;
            /**/

            var insertVehicleInsured = false;
            VOProxy.getResult insertedVehicle = null;

            try
            {
                insertedVehicle = virtualOfficeServiceClient.AddVehicleInsured(vInsured);

                if (insertedVehicle.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage += "Response Code: " + insertedVehicle.Code + "\nMensaje: " + insertedVehicle.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(vInsured, Formatting.Indented) + "\n--\n";
                    insertVehicleInsured = false;
                }
                else
                    insertVehicleInsured = true;
            }
            catch (Exception ex)
            {
                lastMessage += ex.Message + "\n--\n";
                insertVehicleInsured = false;
            }


            if (!insertVehicleInsured)
                throw new Exception("Error en el llamado al método AddVehicleInsured.\nDetalle: " + lastMessage);


            return
                insertedVehicle;
        }

        private void AddVehicleCoverage(int retryAmount, PVechicleCoverage vehicleCoverage)
        {
            string lastMessage = string.Empty;
            VehicleCoverageResult vcResult;
            bool coverageSendSuccess = false;
            bool coverageStatusOk = false;
            var retryCount = 0;

            while (!coverageSendSuccess && retryCount < retryAmount)
            {
                try
                {
                    vcResult = virtualOfficeServiceClient.AddVehicleCoverage(vehicleCoverage);

                    if (vcResult.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + vcResult.Code + "\nMensaje: " + vcResult.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(vehicleCoverage, Formatting.Indented) + "\n--\n";
                        coverageStatusOk = false;
                    }
                    else
                        coverageStatusOk = true;
                    coverageSendSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    coverageSendSuccess = false;
                }
                retryCount++;
            }

            if (!coverageSendSuccess || !coverageStatusOk)
            {
                throw new Exception("Error en la llamada al método AddVehicleCoverage.\nDetalle: " + lastMessage);
            }
        }

        private string GetCustomerNumber(int agentId, Person principal, int retryAmount, GetMappingElementTypeId getMappingFunction,
            List<IdentificationFinalBeneficiary> AllFinalBeneficiarys, List<PepFormulary> AllPepFormularys, PersonInfo personinfo, Dictionary<int, int> personJobForGlobal, int userID, QuotationAuto quotation = null)
        {
            var getContactMatchSuccess = false;
            var retryCount = 0;
            var lastMessage = string.Empty;

            MatchResult contactMatchResult = null;

            DateTime? dob = null;
            bool iscompania = false;

            if (principal.IdentificationType == "RNC")
            {
                dob = null;
                iscompania = true;
            }
            else
            {
                dob = principal.DateOfBirth.Date;
            }

            var contactMatch = new PContactMatch()
            {
                FirstName = principal.FirstName,
                FirstLastName = principal.FirstSurname,
                Dob = dob,
                Identification = principal.IdentificationNumber
            };

            retryCount = 0;
            while (!getContactMatchSuccess && retryCount < retryAmount)
            {
                try
                {
                    contactMatchResult = contactsServiceClient.GetContactMatch(contactMatch);
                    getContactMatchSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "Error en la llamada al método GetContactMatch.\nDetalle: " + ex.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(contactMatch, Formatting.Indented);
                    getContactMatchSuccess = false;
                }
            }

            if (!getContactMatchSuccess)
            {
                throw new Exception(lastMessage);
            }

            var customerNumber = string.Empty;

            //if (personJobForGlobal != null)
            //{
            //    personJobForGlobalOutput = from pair in personJobForGlobal
            //                               select new { OccupationId = pair.Key, OccupGroupTypeId = pair.Value };
            //}

            if (contactMatchResult.CountPossibleMatch == 0)
            {
                var contactRequest = new Contact
                {
                    CorpId = 1,//Fijo CorpId = 1
                    AgentId = agentId,
                    FirstName = principal.FirstName,
                    MiddleName = principal.SecondName,
                    FirstLastName = principal.FirstSurname,
                    SecondLastName = principal.SecondSurname,
                    Gender = principal.GetSexOneLetter(),
                    Smoker = false,
                    MaritalStatId = getMappingFunction(MappingElementType.MaritalStatus, principal.MaritalStatus),
                    CountryOfResidenceId = principal.City.Country_Id,
                    Dob = dob,
                    CountryOfBirthId = principal.Nationality.Global_Country_Id,
                    InvoiceTypeId = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0,
                    IsCompany = iscompania,

                    finalBeneficiaryOptionId = personinfo.IdentificationFinalBeneficiaryOptionsId == 0 ? null : personinfo.IdentificationFinalBeneficiaryOptionsId,
                    pepFormularyOptionId = personinfo.PepFormularyOptionsId == 0 ? null : personinfo.PepFormularyOptionsId,
                    companyStructureId = personinfo.OwnershipStructureId == 0 ? null : personinfo.OwnershipStructureId,
                    companyActivityId = personinfo.SocialReasonId == 0 ? null : personinfo.SocialReasonId,

                    AnnualPersonalIncome = principal.AnnualIncome,
                    CompanyName = principal.Company,

                    OccupationId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Key : (int?)null,
                    OccupGroupTypeId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Value : (int?)null,
                    creditCardTypeId = quotation.Credit_Card_Type_Id == null ? 0 : quotation.Credit_Card_Type_Id,
                    creditCardNumber = quotation.Credit_Card_Number == null ? string.Empty : quotation.Credit_Card_Number,
                    creditCardNumberKey = quotation.Credit_Card_Number_Key == null ? string.Empty : quotation.Credit_Card_Number_Key,
                    expirationDateYear = quotation.Expiration_Date_Year == null ? 0 : quotation.Expiration_Date_Year,
                    expirationDateMonth = quotation.Expiration_Date_Month == null ? 0 : quotation.Expiration_Date_Month,
                    cardHolder = quotation.Card_Holder == null ? string.Empty : quotation.Card_Holder,
                    homeOwner = principal.Home_Owner,
                    qtyEmployees = principal.QtyEmployees == null ? 0 : principal.QtyEmployees,
                    qtyPersonsDepend = principal.QtyPersonsDepend == null ? 0 : principal.QtyPersonsDepend,
                    linked = principal.Linked,
                    segment = principal.Segment,

                    ContactTypeId = iscompania ? 5 : 1 //1 Cliente, 5 Compania
                };

                var addContactSuccess = false;
                ContactResult addContactResponse = null;
                retryCount = 0;
                while (!addContactSuccess && retryCount < retryAmount)
                {
                    try
                    {
                        addContactResponse = contactsServiceClient.AddContact(contactRequest);

                        if (addContactResponse.Code != RESPONSE_CODE_SUCCESS)
                        {
                            lastMessage = addContactResponse.Message;
                            lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(contactRequest, Formatting.Indented);
                            addContactSuccess = false;
                        }
                        else
                            addContactSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        lastMessage = "Error en la llamada al método AddContact.\nDetalle: ResponseCode:" + addContactResponse.Code + "\nMensaje: " + ex.Message;
                    }
                    retryCount++;
                }

                if (addContactSuccess)
                {
                    IdDocument documentRequest = new IdDocument()
                    {
                        customerNumber = addContactResponse.customerNumber,
                        ExpireDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate.HasValue ? principal.IdentificationNumberValidDate : DateTime.MaxValue : DateTime.MaxValue,
                        Id = principal.IdentificationNumber,
                        ContactIdType = (UtilityIdentificationType)VirtualOfficeIntegration.GetVirtualOfficeIdentificationType(principal.IdentificationType)
                    };


                    Email emailRequest = new Email()
                    {
                        CorpId = CORPORATION_ID,
                        customerNumber = addContactResponse.customerNumber,
                        EmailAdress = principal.Email,
                        CommunicationType = "Email",
                        DirectoryTypeId = UtilityEmailType.Home,
                        IsPrimary = true
                    };

                    Phone phoneRequest = new Phone()
                    {
                        CorpId = CORPORATION_ID,
                        customerNumber = addContactResponse.customerNumber,
                        PhoneNumber = principal.PhoneNumber,
                        DirectoryTypeId = UtilityPhoneType.Home,
                        CommunicationType = "Phone",
                        IsPrimary = true,
                        CountryCode = " ",
                        AreaCode = " ",
                    };

                    Phone workPhoneRequest = new Phone()
                    {
                        CorpId = CORPORATION_ID,
                        customerNumber = addContactResponse.customerNumber,
                        PhoneNumber = principal.WorkPhone,
                        DirectoryTypeId = UtilityPhoneType.Work,
                        CommunicationType = "Phone",
                        IsPrimary = false,
                        CountryCode = " ",
                        AreaCode = " ",
                    };

                    Phone cellPhoneRequest = new Phone()
                    {
                        CorpId = CORPORATION_ID,
                        customerNumber = addContactResponse.customerNumber,
                        PhoneNumber = principal.Mobile,
                        DirectoryTypeId = UtilityPhoneType.CellPhone,
                        CommunicationType = "Phone",
                        IsPrimary = false,
                        CountryCode = " ",
                        AreaCode = " ",
                    };

                    Phone faxPhoneRequest = new Phone()
                    {
                        CorpId = CORPORATION_ID,
                        customerNumber = addContactResponse.customerNumber,
                        PhoneNumber = principal.Fax,
                        DirectoryTypeId = UtilityPhoneType.Fax,
                        CommunicationType = "Phone",
                        IsPrimary = false,
                        CountryCode = " ",
                        AreaCode = " ",
                    };

                    Address personalAddressRequest = new Address()
                    {
                        CorpId = CORPORATION_ID,
                        DirectoryTypeId = UtilityAddressType.HomeAddress,
                        StreetAddress = principal.Address,
                        CountryId = principal.City.Country_Id,
                        RegionId = 24,
                        DomesticregId = principal.City.Domesticreg_Id,
                        StateProvId = principal.City.State_Prov_Id,
                        CityId = principal.City.City_Id,
                        ZipCode = "898989",
                        IsPrimary = true,
                        CommunicationType = "Äddress",
                        customerNumber = addContactResponse.customerNumber
                    };


                    var addContactDetailsSuccess = false;
                    retryCount = 0;
                    while (!addContactDetailsSuccess && retryCount < retryAmount)
                    {
                        try
                        {
                            var r4 = contactsServiceClient.AddIdentification(documentRequest);

                            if (!r4.Message.Contains("successfully"))
                            {
                                lastMessage = "Se produjo un error en la llamada al método AddIdentification.\nDetalle: " + r4.Message;
                                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(documentRequest, Formatting.Indented);
                                addContactDetailsSuccess = false;
                                break;
                            }
                            else
                            {
                                if (phoneRequest != null && !string.IsNullOrWhiteSpace(phoneRequest.PhoneNumber))
                                {
                                    var r6 = contactsServiceClient.AddPhone(phoneRequest);
                                }

                                if (workPhoneRequest != null && !string.IsNullOrWhiteSpace(workPhoneRequest.PhoneNumber))
                                {
                                    var r1 = contactsServiceClient.AddPhone(workPhoneRequest);
                                }

                                if (cellPhoneRequest != null && !string.IsNullOrWhiteSpace(cellPhoneRequest.PhoneNumber))
                                {
                                    var r2 = contactsServiceClient.AddPhone(cellPhoneRequest);
                                }

                                if (faxPhoneRequest != null && !string.IsNullOrWhiteSpace(faxPhoneRequest.PhoneNumber))
                                {
                                    var faxResult = contactsServiceClient.AddPhone(faxPhoneRequest);
                                }

                                var r3 = contactsServiceClient.AddAddress(personalAddressRequest);
                                if (!r3.Message.Contains("successfully"))
                                {
                                    lastMessage = "Se produjo un error en la llamada al método AddAddress.\nDetalle: " + r3.Message;
                                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(personalAddressRequest, Formatting.Indented);
                                    addContactDetailsSuccess = false;
                                    break;
                                }
                                else
                                {
                                    if (emailRequest != null && !string.IsNullOrWhiteSpace(emailRequest.EmailAdress))
                                    {
                                        var r5 = contactsServiceClient.AddEmail(emailRequest);
                                        if (!r5.Message.Contains("successfully"))
                                        {
                                            lastMessage = "Se produjo un error en la llamada al método AddAddress.\nDetalle: " + r5.Message;
                                            lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(emailRequest, Formatting.Indented);
                                            addContactDetailsSuccess = false;
                                            break;
                                        }
                                        else
                                            addContactDetailsSuccess = true;
                                    }
                                    else
                                    {
                                        addContactDetailsSuccess = true;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lastMessage = "Se produjo un error en la llamada a los métodos de agregado de detalles del contacto.\nDetalle" + ex.Message;
                        }
                        retryCount++;
                    }
                    if (!addContactDetailsSuccess)
                    {
                        throw new Exception(lastMessage);
                    }


                    /*Setianndo formularios PEP Y BF*/
                    var contact = contactsServiceClient.GetContact(CORPORATION_ID, addContactResponse.customerNumber);

                    if (contact.Code == RESPONSE_CODE_SUCCESS)
                    {
                        var cresult = JsonConvert.DeserializeObject<Contact>(contact.JSONResult);
                        if (cresult != null)
                        {
                            var ContactId = cresult.ContactId;

                            foreach (var item in AllFinalBeneficiarys)
                            {
                                SetContactFinalBeneficiary(ContactId, item.Id, item.Name, item.PercentageParticipation, true, userID, item.isPEP, item.pepFormularyOptionsId, item.IdentificationTypeId, item.IdentificationNumber, item.NationalityCountryId, out lastMessage);
                                //SetContactFinalBeneficiary(ContactId, item.Id, item.Name, item.PercentageParticipation, true, userID, out lastMessage);
                            }

                            foreach (var item in AllPepFormularys)
                            {
                                SetContactPepFormulary(ContactId, item.Id, item.Name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, userID, item.BeneficiaryId, item.IsPepManagerCompany, out lastMessage);
                                //SetContactPepFormulary(ContactId, item.Id, item.Name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, userID, out lastMessage);
                            }
                        }
                    }
                    /**/
                }
                else
                {
                    throw new Exception(lastMessage);
                }
                customerNumber = addContactResponse.customerNumber;
            }
            else
            {
                List<contactMatchResult> contactsMatchs = JsonConvert.DeserializeObject<List<contactMatchResult>>(contactMatchResult.JsonResultPossibleMatch);
                customerNumber = contactsMatchs.First().CustomerNumber;
                var contact = new Contact();

                var realContact = contactsServiceClient.GetContact(CORPORATION_ID, contactsMatchs.First().CustomerNumber);
                if (realContact.Code == RESPONSE_CODE_SUCCESS)
                {
                    var cresult = JsonConvert.DeserializeObject<Contact>(realContact.JSONResult);
                    if (cresult != null)
                    {
                        contact = cresult;
                    }
                }

                /*var contacts = JsonConvert.DeserializeObject<List<Contact>>(contactMatchResult.JsonResultPossibleMatch);
                Contact contact = contacts.First();
                customerNumber = contact.customerNumber;*/
                //Original 15-11-2017 Jheiron

                //UPDATE CONTACT (Issue 0015819)
                contact.CorpId = CORPORATION_ID;
                contact.AgentId = agentId;
                contact.MiddleName = principal.SecondName;
                contact.SecondLastName = principal.SecondSurname;
                contact.Gender = principal.GetSexOneLetter();
                contact.MaritalStatId = getMappingFunction(MappingElementType.MaritalStatus, principal.MaritalStatus);
                contact.CountryOfResidenceId = principal.City.Country_Id;
                contact.CountryOfBirthId = principal.Nationality.Global_Country_Id;
                contact.IsCompany = iscompania;

                contact.finalBeneficiaryOptionId = personinfo.IdentificationFinalBeneficiaryOptionsId == 0 ? null : personinfo.IdentificationFinalBeneficiaryOptionsId;
                contact.pepFormularyOptionId = personinfo.PepFormularyOptionsId == 0 ? null : personinfo.PepFormularyOptionsId;
                contact.companyStructureId = personinfo.OwnershipStructureId == 0 ? null : personinfo.OwnershipStructureId;
                contact.companyActivityId = personinfo.SocialReasonId == 0 ? null : personinfo.SocialReasonId;

                contact.InvoiceTypeId = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;

                contact.AnnualPersonalIncome = principal.AnnualIncome;
                contact.CompanyName = principal.Company;

                contact.OccupationId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Key : (int?)null;
                contact.OccupGroupTypeId = personJobForGlobal != null ? personJobForGlobal.FirstOrDefault().Value : (int?)null;

                contact.ContactTypeId = iscompania ? 5 : 1; //1 Cliente, 5 Compania

                var updateContactSuccess = false;
                ContactResult updateContactResponse = null;
                try
                {
                    updateContactResponse = contactsServiceClient.UpdateContact(contact);
                    if (updateContactResponse.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage = updateContactResponse.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(contact, Formatting.Indented);
                        updateContactSuccess = false;
                    }
                    else
                        updateContactSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "Error en la llamada al método UpdateContact.\nDetalle: " + ex.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(contact, Formatting.Indented);
                    updateContactSuccess = false;
                }
                if (updateContactSuccess)
                {
                    try
                    {

                        ContactsProxy.getResult getPhoneResultResponse = contactsServiceClient.GetAllPhone(CORPORATION_ID, customerNumber);
                        if (getPhoneResultResponse.Code == RESPONSE_CODE_SUCCESS)
                        {
                            Phone homePhone, workPhone, cellPhone;
                            var phoneList = JsonConvert.DeserializeObject<List<Phone>>(getPhoneResultResponse.JSONResult);
                            //homePhone = phoneList.FirstOrDefault(p => p.IsPrimary && p.DirectoryTypeId == UtilityPhoneType.Home);
                            homePhone = phoneList.FirstOrDefault(p => p.DirectoryTypeId == UtilityPhoneType.Home);
                            if (homePhone != null)
                            {
                                homePhone.PhoneNumber = principal.PhoneNumber;
                                homePhone.CorpId = CORPORATION_ID;
                                homePhone.customerNumber = customerNumber;
                                homePhone.CommunicationType = "Phone";
                                homePhone.CountryCode = " ";
                                homePhone.AreaCode = " ";
                                var r = contactsServiceClient.UpdatePhone(homePhone);
                            }
                            //workPhone = phoneList.FirstOrDefault(p => !p.IsPrimary && p.DirectoryTypeId == UtilityPhoneType.Work);
                            workPhone = phoneList.FirstOrDefault(p => p.DirectoryTypeId == UtilityPhoneType.Work);
                            if (workPhone != null)
                            {
                                workPhone.PhoneNumber = principal.WorkPhone;
                                workPhone.CorpId = CORPORATION_ID;
                                workPhone.customerNumber = customerNumber;
                                workPhone.CommunicationType = "Phone";
                                workPhone.CountryCode = " ";
                                workPhone.AreaCode = " ";
                                var r = contactsServiceClient.UpdatePhone(workPhone);
                            }
                            //cellPhone = phoneList.FirstOrDefault(p => !p.IsPrimary && p.DirectoryTypeId == UtilityPhoneType.CellPhone);
                            cellPhone = phoneList.FirstOrDefault(p => p.DirectoryTypeId == UtilityPhoneType.CellPhone);
                            if (cellPhone != null)
                            {
                                cellPhone.PhoneNumber = principal.Mobile;
                                cellPhone.CorpId = CORPORATION_ID;
                                cellPhone.customerNumber = customerNumber;
                                cellPhone.CommunicationType = "Phone";
                                cellPhone.CountryCode = " ";
                                cellPhone.AreaCode = " ";
                                var r = contactsServiceClient.UpdatePhone(cellPhone);
                            }
                        }

                        ContactsProxy.getResult getEmailResultResponse = contactsServiceClient.GetAllEmail(CORPORATION_ID, customerNumber);
                        if (getEmailResultResponse.Code == RESPONSE_CODE_SUCCESS)
                        {
                            var emailList = JsonConvert.DeserializeObject<List<Email>>(getEmailResultResponse.JSONResult);
                            //Email email = emailList.FirstOrDefault(e => e.IsPrimary && e.DirectoryTypeId == UtilityEmailType.Home);
                            Email email = emailList.FirstOrDefault(e => e.DirectoryTypeId == UtilityEmailType.Home);
                            if (email != null)
                            {
                                email.EmailAdress = principal.Email;
                                email.CorpId = CORPORATION_ID;
                                email.customerNumber = customerNumber;
                                email.CommunicationType = "Email";
                                var r = contactsServiceClient.UpdateEmail(email);
                            }
                        }

                        ContactsProxy.getResult getAddressResultResponse = contactsServiceClient.GetAllAddress(CORPORATION_ID, customerNumber);
                        if (getAddressResultResponse.Code == RESPONSE_CODE_SUCCESS)
                        {
                            var addressList = JsonConvert.DeserializeObject<List<Address>>(getAddressResultResponse.JSONResult);
                            //Address address = addressList.FirstOrDefault(e => e.IsPrimary && e.DirectoryTypeId == UtilityAddressType.HomeAddress);
                            Address address = addressList.FirstOrDefault(e => e.DirectoryTypeId == UtilityAddressType.HomeAddress);
                            if (address != null)
                            {
                                address.StreetAddress = principal.Address;
                                address.CountryId = principal.City.Country_Id;
                                address.DomesticregId = principal.City.Domesticreg_Id;
                                address.StateProvId = principal.City.State_Prov_Id;
                                address.CityId = principal.City.City_Id;
                                address.RegionId = 24;
                                address.ZipCode = "898989";
                                address.CommunicationType = "Äddress";
                                address.customerNumber = customerNumber;
                                var r = contactsServiceClient.UpdateAddress(address);
                            }
                        }


                        /*Setianndo formularios PEP Y BF*/
                        var ContactId = contact.ContactId;

                        foreach (var item in AllFinalBeneficiarys)
                        {
                            SetContactFinalBeneficiary(ContactId, item.Id, item.Name, item.PercentageParticipation, true, userID, item.isPEP, item.pepFormularyOptionsId, item.IdentificationTypeId, item.IdentificationNumber, item.NationalityCountryId, out lastMessage);
                            //SetContactFinalBeneficiary(ContactId, item.Id, item.Name, item.PercentageParticipation, true, userID, out lastMessage);
                        }

                        foreach (var item in AllPepFormularys)
                        {
                            SetContactPepFormulary(ContactId, item.Id, item.Name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, userID, item.BeneficiaryId, item.IsPepManagerCompany, out lastMessage);
                            //SetContactPepFormulary(ContactId, item.Id, item.Name, item.RelationshipId, item.Position, item.FromYear, item.ToYear, true, userID, out lastMessage);
                        }


                        /**/


                    }
                    catch (Exception ex)
                    {
                        lastMessage = "Se produjo un error en la llamada a los métodos de actualización de detalles del contacto.\nDetalle" + ex.Message;
                    }
                }
            }

            return customerNumber;
        }

        private int GetProductTypeId(int corpId, string productTypeName, int retryAmount)
        {
            var voProductTypeParam = new Product.Type.Key()
            {
                CorpId = corpId,
                ProductTypeDesc = productTypeName,
                ProductTypeId = 0,
                Required = true
            };

            var lastMessage = string.Empty;
            var retryCount = 0;
            var getProductTypeSuccess = false;
            VOProxy.getResult voProductTypeJson = null;

            while (!getProductTypeSuccess && retryCount < retryAmount)
            {
                try
                {
                    voProductTypeJson = virtualOfficeServiceClient.GetProductType(voProductTypeParam);
                    if (voProductTypeJson.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += voProductTypeJson.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(voProductTypeParam, Formatting.Indented) + "\n--\n";
                        getProductTypeSuccess = false;
                    }
                    else
                        getProductTypeSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                }
                retryCount++;
            }

            if (!getProductTypeSuccess)
                throw new Exception("Error en el llamado a GetProductType\nDetalle: No se pudo encontrar el producto " + productTypeName + " en Virtual Office. " + lastMessage);

            dynamic voProductType = JObject.Parse(voProductTypeJson.JSONResult);

            return voProductType.ProductTypeId;
        }

        private int GetCoverageGroupId(int corpId, string coverageName, int retryAmount, int? ramo = null, int? subramo = null)
        {
            var lastMessage = string.Empty;
            var retryCount = 0;
            var getCoverageGroupSuccess = false;
            CoverageGroupResult voCoverageGroup = null;

            //Get coverageGroup
            var voCoverageGroupParam = new PCoverageGroupKey
            {
                CorpId = corpId,
                GroupDesc = coverageName,
                //GroupId = 0
                Ramo = ramo,
                SubRamo = subramo
            };

            while (!getCoverageGroupSuccess && retryCount < retryAmount)
            {
                try
                {
                    voCoverageGroup = virtualOfficeServiceClient.GetCoverageGroup(voCoverageGroupParam);
                    if (voCoverageGroup.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += voCoverageGroup.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(voCoverageGroupParam, Formatting.Indented) + "\n--\n";
                        getCoverageGroupSuccess = false;
                    }
                    else
                        getCoverageGroupSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                }
                retryCount++;
            }

            if (!getCoverageGroupSuccess)
            {
                throw new Exception("No se pudo encontrar el Grupo de Producto " + coverageName + " en Virtual Office");
            }

            return voCoverageGroup.Group.GroupId;
        }

        private int GetProductId(string productDesc, int productTypeId, int retryAmount)
        {
            //Get ProductId
            var pProdParam = new Product.PProductKey()
            {
                ProductDesc = productDesc,
            };
            int retryCount = 0;
            bool getProductSuccess = false;
            var lastMessage = string.Empty;
            VOProxy.getResult voProductJson = null;

            while (!getProductSuccess && retryCount < retryAmount)
            {
                try
                {
                    voProductJson = virtualOfficeServiceClient.GetProduct(pProdParam);
                    if (voProductJson.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += voProductJson.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(pProdParam, Formatting.Indented) + "\n--\n";
                        getProductSuccess = false;
                    }
                    else
                        getProductSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                }
                retryCount++;
            }

            if (!getProductSuccess ||
                (getProductSuccess &&
                (string.IsNullOrEmpty(voProductJson.JSONResult) || voProductJson.JSONResult == "null")))
            {
                throw new Exception("Error en el llamado a GetProduct. No se pudo encontrar el producto " + productDesc + " en Virtual Office\nDetalle: " + lastMessage);
            }

            JArray voProducts = JArray.Parse(voProductJson.JSONResult);

            var productId = 0;

            foreach (dynamic product in voProducts.Children<JObject>())
            {
                if (product.ProductTypeId == productTypeId)
                {
                    productId = product.ProductId;
                    break;
                }
            }

            if (productId == 0)
            {
                throw new Exception("Error en el llamado a GetProduct. No se pudo encontrar el producto " + productDesc + " con ProductTypeId " + productTypeId.ToString() + "  en Virtual Office.");
            }

            return productId;
        }

        private int GetCoverageId(int corpId, string coverageName, int coverageType, int retryAmount)
        {
            var commonCoverageParam = new PCoverageKey()
            {
                NameKey = coverageName,
                CoverageDesc = coverageName
            };

            int retryCount = 0;
            bool getCoverageSuccess = false;
            var lastMessage = string.Empty;
            VOProxy.CoverageResult voCoverageJson = null;

            while (!getCoverageSuccess && retryCount < retryAmount)
            {
                try
                {
                    voCoverageJson = virtualOfficeServiceClient.GetCoverage(commonCoverageParam);
                    if (voCoverageJson.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += voCoverageJson.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(commonCoverageParam, Formatting.Indented) + "\n--\n";
                        getCoverageSuccess = false;
                    }
                    else
                        getCoverageSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                }
                retryCount++;
            }

            if (!getCoverageSuccess)
                throw new Exception("Error en el llamado a GetCoverage\nDetalle: No se pudo encontrar la cobertura " + coverageName + " en Virtual Office. " + lastMessage);

            return voCoverageJson.Coverage.CoverageId;
        }

        private void CheckCoverageProductRelation(Quotation quotation, dynamic insertPolicyResult, int vehicleType, int retryAmount, PVechicleCoverage vehicleCoverage)
        {
            int retryCount = 0;
            string lastMessage = string.Empty;

            //Check existence de Coverage-Product relation
            var key = new Product.Key()
            {
                CoverageId = vehicleCoverage.CoverageId,
                GroupId = vehicleCoverage.GroupId,
                ProductId = vehicleCoverage.ProductId,
                VehicleTypeId = vehicleCoverage.VehicleTypeId
            };

            var productCoverageCallSuccess = false;
            retryCount = 0;
            VOProxy.getResult productCoverageFound = null;

            while (!productCoverageCallSuccess && retryCount < retryAmount)
            {
                try
                {
                    productCoverageFound = virtualOfficeServiceClient.GetCoverageProduct(key);
                    if (productCoverageFound.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + productCoverageFound.Code + "\nMensaje: " + productCoverageFound.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(key, Formatting.Indented) + "\n--\n";
                        productCoverageCallSuccess = false;
                    }
                    else
                        productCoverageCallSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    productCoverageCallSuccess = false;
                }
                retryCount++;
            }


            if (productCoverageCallSuccess)
            {
                if (string.IsNullOrEmpty(productCoverageFound.JSONResult) || productCoverageFound.JSONResult == "null" || productCoverageFound.JSONResult == "[]")
                {
                    var covProdParam = new CoverageProduct()
                    {
                        BlId = quotation.BusinessLine == null ? 2 : quotation.BusinessLine.CoreId,
                        BlTypeId = BUSINESS_LINE_TYPE_ID,
                        CorpId = insertPolicyResult.CorpId,
                        CountryId = insertPolicyResult.CountryId,
                        CoverageId = vehicleCoverage.CoverageId,
                        CoverageTypeId = vehicleCoverage.CoverageTypeId,
                        GroupId = vehicleCoverage.GroupId,
                        ProductCoverageStatus = true,
                        ProductId = vehicleCoverage.ProductId,
                        RegionId = insertPolicyResult.RegionId,
                        VehicleTypeId = vehicleType
                    };

                    retryCount = 0;
                    lastMessage = string.Empty;
                    var setCovProdSuccess = false;


                    while (!setCovProdSuccess && retryCount < retryAmount)
                    {
                        try
                        {
                            var setCovProdResponse = virtualOfficeServiceClient.SetCoverageProduct(covProdParam);

                            if (setCovProdResponse.Code != RESPONSE_CODE_SUCCESS)
                            {
                                lastMessage += "Response Code: " + setCovProdResponse.Code + "\nMensaje: " + setCovProdResponse.Message;
                                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(covProdParam, Formatting.Indented) + "\n--\n";
                                setCovProdSuccess = false;
                            }
                            else
                                setCovProdSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage += ex.Message + "\n--\n";
                            setCovProdSuccess = false;
                        }

                        if (!setCovProdSuccess)
                        {
                            throw new Exception("Error en el llamado a SetCoverageProduct.\nDetalle: No se pudo insertar el tandem producto id:" + covProdParam.ProductId.ToString() + "-coverage id:" + covProdParam.CoverageId + " en Virtual Office." + lastMessage);
                        }
                    }
                }
            }
        }

        private void CheckCoverageProductRelationNewPV(Entity.Entities.Quotation quotation, dynamic insertPolicyResult, int vehicleType, int retryAmount, PVechicleCoverage vehicleCoverage)
        {
            int retryCount = 0;
            string lastMessage = string.Empty;

            //Check existence de Coverage-Product relation
            var key = new Product.Key()
            {
                CoverageId = vehicleCoverage.CoverageId,
                GroupId = vehicleCoverage.GroupId,
                ProductId = vehicleCoverage.ProductId,
                VehicleTypeId = vehicleCoverage.VehicleTypeId
            };

            var productCoverageCallSuccess = false;
            retryCount = 0;
            VOProxy.getResult productCoverageFound = null;

            while (!productCoverageCallSuccess && retryCount < retryAmount)
            {
                try
                {
                    productCoverageFound = virtualOfficeServiceClient.GetCoverageProduct(key);
                    if (productCoverageFound.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + productCoverageFound.Code + "\nMensaje: " + productCoverageFound.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(key, Formatting.Indented) + "\n--\n";
                        productCoverageCallSuccess = false;
                    }
                    else
                        productCoverageCallSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    productCoverageCallSuccess = false;
                }
                retryCount++;
            }


            if (productCoverageCallSuccess)
            {
                if (string.IsNullOrEmpty(productCoverageFound.JSONResult) || productCoverageFound.JSONResult == "null" || productCoverageFound.JSONResult == "[]")
                {
                    var covProdParam = new CoverageProduct()
                    {
                        BlId = 2,
                        BlTypeId = BUSINESS_LINE_TYPE_ID,
                        CorpId = insertPolicyResult.CorpId,
                        CountryId = insertPolicyResult.CountryId,
                        CoverageId = vehicleCoverage.CoverageId,
                        CoverageTypeId = vehicleCoverage.CoverageTypeId,
                        GroupId = vehicleCoverage.GroupId,
                        ProductCoverageStatus = true,
                        ProductId = vehicleCoverage.ProductId,
                        RegionId = insertPolicyResult.RegionId,
                        VehicleTypeId = vehicleType
                    };

                    retryCount = 0;
                    lastMessage = string.Empty;
                    var setCovProdSuccess = false;


                    while (!setCovProdSuccess && retryCount < retryAmount)
                    {
                        try
                        {
                            var setCovProdResponse = virtualOfficeServiceClient.SetCoverageProduct(covProdParam);

                            if (setCovProdResponse.Code != RESPONSE_CODE_SUCCESS)
                            {
                                lastMessage += "Response Code: " + setCovProdResponse.Code + "\nMensaje: " + setCovProdResponse.Message;
                                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(covProdParam, Formatting.Indented) + "\n--\n";
                                setCovProdSuccess = false;
                            }
                            else
                                setCovProdSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage += ex.Message + "\n--\n";
                            setCovProdSuccess = false;
                        }

                        if (!setCovProdSuccess)
                        {
                            throw new Exception("Error en el llamado a SetCoverageProduct.\nDetalle: No se pudo insertar el tandem producto id:" + covProdParam.ProductId.ToString() + "-coverage id:" + covProdParam.CoverageId + " en Virtual Office." + lastMessage);
                        }
                    }
                }
            }
        }

        private void CheckCoverageGroupDetailRelation(int retryAmount, PVechicleCoverage vehicleCoverage)
        {
            int retryCount = 0;
            string lastMessage = string.Empty;

            //Check existence of Coverage-Product relation
            var key = new PCoverageGroupDetailKey()
            {
                CoverageId = vehicleCoverage.CoverageId,
                GroupId = vehicleCoverage.GroupId,
                CorpId = vehicleCoverage.CorpId,
                CoverageTypeId = vehicleCoverage.CoverageTypeId,
            };

            var coverageGroupDetailCallSuccess = false;
            retryCount = 0;
            CoverageGroupDetailResult coverageGroupDetailFound = null;

            while (!coverageGroupDetailCallSuccess && retryCount < retryAmount)
            {
                try
                {
                    coverageGroupDetailFound = virtualOfficeServiceClient.GetCoverageGroupDetail(key);
                    if (coverageGroupDetailFound.Code != RESPONSE_CODE_SUCCESS)
                    {
                        lastMessage += "Response Code: " + coverageGroupDetailFound.Code + "\nMensaje: " + coverageGroupDetailFound.Message;
                        lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(key, Formatting.Indented) + "\n--\n";
                        coverageGroupDetailCallSuccess = false;
                    }
                    else
                        coverageGroupDetailCallSuccess = true;
                }
                catch (Exception ex)
                {
                    lastMessage += ex.Message + "\n--\n";
                    coverageGroupDetailCallSuccess = false;
                }
                retryCount++;
            }


            if (coverageGroupDetailCallSuccess)
            {
                if (coverageGroupDetailFound.Detail == null)
                {
                    var covGroupDetailParam = new PCoverageGroupDetail()
                    {
                        CorpId = vehicleCoverage.CorpId,
                        CoverageId = vehicleCoverage.CoverageId,
                        CoverageTypeId = vehicleCoverage.CoverageTypeId,
                        GroupId = vehicleCoverage.GroupId
                    };

                    retryCount = 0;
                    lastMessage = string.Empty;
                    var setCovGroupDetailSuccess = false;

                    while (!setCovGroupDetailSuccess && retryCount < retryAmount)
                    {
                        try
                        {
                            var setCovProdResponse = virtualOfficeServiceClient.SetCoverageGroupDetail(covGroupDetailParam);

                            if (setCovProdResponse.Code != RESPONSE_CODE_SUCCESS)
                            {
                                lastMessage += "Response Code: " + setCovProdResponse.Code + "\nMensaje: " + setCovProdResponse.Message;
                                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(covGroupDetailParam, Formatting.Indented) + "\n--\n";
                                setCovGroupDetailSuccess = false;
                            }
                            else
                                setCovGroupDetailSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage = ex.Message + "\n--\n";
                            setCovGroupDetailSuccess = false;
                        }

                        if (!setCovGroupDetailSuccess)
                        {
                            throw new Exception("Error en el llamado a SetCoverageGroupDetail.\nDetalle: No se pudo insertar la relación CoverageId:" + vehicleCoverage.CoverageId +
                                "-GroupId:" + vehicleCoverage.GroupId +
                                "CoverageTypeId: " + vehicleCoverage.CoverageTypeId + " en Virtual Office. " + lastMessage);
                        }
                    }
                }
            }
        }

        private void UpdateQuotationTemp(object PolicyNo)
        {
            virtualOfficeServiceClient.UpdateQuotationInfoTemp(PolicyNo.ToString());
        }

        public bool UpdateOneQuotationInfoTemp(Quotation quotation, int UserId, bool ReturnResultSet = false)
        {
            bool result = false;
            string query;
            SqlCommand command;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringGlobal))
                {
                    query = "exec [Policy].[SP_SET_FT_GET_QUO_PL_POLICY_GRIDVIEW] @Policy_No,@UserId,@ReturnResultSet";
                    //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GlobalLogger"].ConnectionString);
                    command = new SqlCommand(query, connection);
                    command.CommandTimeout = 0;

                    command.Parameters.Add(new SqlParameter("@Policy_No", quotation.QuotationNumber));
                    command.Parameters.Add(new SqlParameter("@UserId", UserId));
                    command.Parameters.Add(new SqlParameter("@ReturnResultSet", ReturnResultSet));

                    if (connection != null && connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                    result = true;
                    connection.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return
                result;
        }

        public bool UpdateOneQuotationInfoTempNewPV(Entity.Entities.Quotation quotation, int UserId, bool ReturnResultSet = false)
        {
            bool result = false;
            string query;
            SqlCommand command;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringGlobal))
                {
                    query = "exec [Policy].[SP_SET_FT_GET_QUO_PL_POLICY_GRIDVIEW] @Policy_No,@UserId,@ReturnResultSet";
                    //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GlobalLogger"].ConnectionString);
                    command = new SqlCommand(query, connection);
                    command.CommandTimeout = 0;

                    command.Parameters.Add(new SqlParameter("@Policy_No", quotation.QuotationNumber));
                    command.Parameters.Add(new SqlParameter("@UserId", UserId));
                    command.Parameters.Add(new SqlParameter("@ReturnResultSet", ReturnResultSet));

                    if (connection != null && connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();
                    result = true;
                    connection.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return
                result;
        }

        private VOProxy.ResultCode setPolicySourceId(string PolicyNo, string SourceId)
        {
            Policy.PSourceId param = new Policy.PSourceId();
            param.PolicyNo = PolicyNo;
            param.SourceId = SourceId;

            VOProxy.ResultCode InsertedPolicySourceId = null;
            string lastMessage = string.Empty;
            bool InsertedPolicySourceIdBool = true;

            try
            {
                InsertedPolicySourceId = virtualOfficeServiceClient.SetPolicySourceId(param);

                if (InsertedPolicySourceId.Code != RESPONSE_CODE_SUCCESS)
                {
                    lastMessage += "Response Code: " + InsertedPolicySourceId.Code + "\nMensaje: " + InsertedPolicySourceId.Message;
                    lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(param, Formatting.Indented) + "\n--\n";
                    InsertedPolicySourceIdBool = false;
                }
            }
            catch (Exception ex)
            {
                lastMessage += ex.Message + "\n--\n";
            }

            if (!InsertedPolicySourceIdBool)
            {
                throw new Exception("Error en la llamada al método SetPolicySourceId.\nDetalle: " + lastMessage);
            }
            return InsertedPolicySourceId;
        }

        public bool GetPolicy(string policy_no)
        {
            VOProxy.getResult r = virtualOfficeServiceClient.GetPolicy(policy_no);

            return !(r.JSONResult == null);
        }

        public bool DeleteDuplicatePolicy(string policy_no, int userid)
        {
            VOProxy.ResultCode r = virtualOfficeServiceClient.DeleteDuplicatePolicy(policy_no, userid);
            return (r.Code == RESPONSE_CODE_SUCCESS);
        }

        private PolicySysFlexGetPrimaCobertura[] GetPrimaCoberturaSysflex(decimal quotationCoreNumber, int SecuenciaVehicleSysflex, string newEndpointCotizacion)
        {
            var sfsc = new SysFlexServiceClient();

            if (!string.IsNullOrEmpty(newEndpointCotizacion))
            {
                sfsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(newEndpointCotizacion);
            }

            var SysFlexProxy = new STL.POS.WsProxy.CoreProxy(sfsc);
            PolicySysFlexGetPrimaCoberturaKey parm = new PolicySysFlexGetPrimaCoberturaKey();
            parm.Cotizacion = quotationCoreNumber;
            parm.Secuencia = SecuenciaVehicleSysflex;
            return SysFlexProxy.GetPrimaCobertura(parm);
        }

        private string ratejson(string rateJson)
        {
            string result = "";
            if (rateJson.Contains("PARAMETERS: "))
            {
                var spRateJson = rateJson.Split(new string[] { "PARAMETERS: ", " RESPONSE: " }, StringSplitOptions.RemoveEmptyEntries);
                if (spRateJson.Count() > 0)
                {
                    var res = spRateJson[1].Replace(@"\", "");

                    result = "[" + res.Replace(@"}"",""", "}") + "]";
                }
            }
            return result;
        }

        private void SetContactFinalBeneficiary(int? contactId, int finalBeneficiaryId, string name,
            decimal? percentageParticipation, bool? finalBeneficiaryStatus, int? serId, bool? IsPep, int? PepFormularyOptionsId, int? IdentificationTypeId, string IdentificationNumber, int? NationalityCountryId, out string lastMessage)
        {
            lastMessage = "";
            ContactsProxy.getResult r = contactsServiceClient.SetContactFinalBeneficiary(contactId, finalBeneficiaryId, name, percentageParticipation, finalBeneficiaryStatus, serId, IsPep, PepFormularyOptionsId, IdentificationTypeId, IdentificationNumber, NationalityCountryId);
            //ContactsProxy.getResult r = contactsServiceClient.SetContactFinalBeneficiary(contactId, finalBeneficiaryId, name, percentageParticipation, finalBeneficiaryStatus, serId, IsPep, PepFormularyOptionsId);
            //ContactsProxy.getResult r = contactsServiceClient.SetContactFinalBeneficiary(contactId, finalBeneficiaryId, name, percentageParticipation, finalBeneficiaryStatus, serId);
            if (r.Code != RESPONSE_CODE_SUCCESS)
            {
                lastMessage += "Response Code: " + r.Code + "\nMensaje: " + r.Message;
            }
        }

        private void SetContactPepFormulary(int? contactId, int? pepFormularyId, string name,
            int? relationshipId, string position, int? fromYear, int? toYear, bool? pepFormularyStatus, int? userId, int? BeneficiaryId, bool? IsPepManagerCompany, out string lastMessage)
        {
            lastMessage = "";
            ContactsProxy.getResult r = contactsServiceClient.SetContactPepFormulary(contactId, pepFormularyId, name, relationshipId, position, fromYear, toYear, pepFormularyStatus, userId, BeneficiaryId, IsPepManagerCompany);
            //ContactsProxy.getResult r = contactsServiceClient.SetContactPepFormulary(contactId, pepFormularyId, name, relationshipId, position, fromYear, toYear, pepFormularyStatus, userId);
            if (r.Code != RESPONSE_CODE_SUCCESS)
            {
                lastMessage += "Response Code: " + r.Code + "\nMensaje: " + r.Message;
            }
        }

        private dynamic GetOccupationByDesc(string Desc)
        {
            var occupations = contactsServiceClient.GetOccupationByDesc(Desc);
            dynamic insertPolicyResult = null;

            if (occupations.Code == RESPONSE_CODE_SUCCESS)
            {
                insertPolicyResult = JObject.Parse(occupations.JSONResult);
            }

            return insertPolicyResult;
        }

        private VOProxy.ResultCode SetPaymentAgreement(QuotationAuto quotation, dynamic insertPolicyResult, int UserID, decimal MinAllowedAmountToPay)
        {
            string lastMessage = "";
            VOProxy.ResultCode insertPaymentAgreement = null;
            bool wasInsertPaymentAgreement = true;

            var PaymentsAgreementQty = quotation.PaymentFrequencyId.HasValue ? quotation.PaymentFrequencyId.Value : 0;
            var InitialPayment = quotation.AmountToPayEnteredByUser;
            var TotalAgreementPayment = quotation.TotalPrime.Value + quotation.TotalISC.Value;

            if (PaymentsAgreementQty == 0)//es un pago unico
            {
                InitialPayment = TotalAgreementPayment;
            }
            else if (PaymentsAgreementQty != 0 && quotation.AmountToPayEnteredByUser.GetValueOrDefault() <= 0)//No es un pago unico
            {
                InitialPayment = (TotalAgreementPayment * MinAllowedAmountToPay);//Sacando el Porcentaje minimo que se puede pagar
            }

            PaymentAgreementKey param = new PaymentAgreementKey();
            param.CorpId = insertPolicyResult.CorpId;
            param.RegionId = insertPolicyResult.RegionId;
            param.CountryId = insertPolicyResult.CountryId;
            param.DomesticregId = insertPolicyResult.DomesticregId;
            param.StateProvId = insertPolicyResult.StateProvId;
            param.CityId = insertPolicyResult.CityId;
            param.CaseSeqNo = insertPolicyResult.CaseSeqNo;
            param.HistSeqNo = insertPolicyResult.HistSeqNo;
            param.OfficeId = insertPolicyResult.OfficeId;

            param.PaymentAgreementId = (int?)null;
            param.PaymentsAgreementQty = PaymentsAgreementQty;
            param.DiscountPercentage = 0;
            param.DiscountAmount = 0;
            param.DiscountNameKey = string.Empty;
            param.SurchargePercentage = 0;
            param.SurchargeAmount = 0;
            param.SurchargeNameKey = string.Empty;
            param.InitialPayment = InitialPayment;
            param.TotalAgreementPayment = TotalAgreementPayment;
            param.ExternalId = 0;
            param.UserId = UserID;



            insertPaymentAgreement = virtualOfficeServiceClient.SetPaymentAgreementPolicy(param);

            if (insertPaymentAgreement.Code != RESPONSE_CODE_SUCCESS)
            {
                lastMessage += "Response Code: " + insertPaymentAgreement.Code + "\nMensaje: " + insertPaymentAgreement.Message;
                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(param, Formatting.Indented) + "\n--\n";
                wasInsertPaymentAgreement = false;
            }

            if (!wasInsertPaymentAgreement)
            {
                throw new Exception("Error en el llamado al método SetPaymentAgreementPolicy.\nDetalle: " + lastMessage);
            }

            return insertPaymentAgreement;
        }


        private VOProxy.ResultCode SetPaymentAgreementNewPV(Entity.Entities.Quotation quotation, dynamic insertPolicyResult, int UserID, decimal MinAllowedAmountToPay)
        {
            string lastMessage = "";
            VOProxy.ResultCode insertPaymentAgreement = null;
            bool wasInsertPaymentAgreement = true;

            var PaymentsAgreementQty = quotation.PaymentFrequencyId.HasValue ? quotation.PaymentFrequencyId.Value : 0;
            var InitialPayment = quotation.AmountToPayEnteredByUser;
            var TotalAgreementPayment = quotation.TotalPrime.Value + quotation.TotalISC.Value;

            if (PaymentsAgreementQty == 0)//es un pago unico
            {
                InitialPayment = TotalAgreementPayment;
            }
            else if (PaymentsAgreementQty != 0 && quotation.AmountToPayEnteredByUser.GetValueOrDefault() <= 0)//No es un pago unico
            {
                InitialPayment = (TotalAgreementPayment * MinAllowedAmountToPay);//Sacando el Porcentaje minimo que se puede pagar
            }

            PaymentAgreementKey param = new PaymentAgreementKey();
            param.CorpId = insertPolicyResult.CorpId;
            param.RegionId = insertPolicyResult.RegionId;
            param.CountryId = insertPolicyResult.CountryId;
            param.DomesticregId = insertPolicyResult.DomesticregId;
            param.StateProvId = insertPolicyResult.StateProvId;
            param.CityId = insertPolicyResult.CityId;
            param.CaseSeqNo = insertPolicyResult.CaseSeqNo;
            param.HistSeqNo = insertPolicyResult.HistSeqNo;
            param.OfficeId = insertPolicyResult.OfficeId;

            param.PaymentAgreementId = (int?)null;
            param.PaymentsAgreementQty = PaymentsAgreementQty;
            param.DiscountPercentage = 0;
            param.DiscountAmount = 0;
            param.DiscountNameKey = string.Empty;
            param.SurchargePercentage = 0;
            param.SurchargeAmount = 0;
            param.SurchargeNameKey = string.Empty;
            param.InitialPayment = InitialPayment;
            param.TotalAgreementPayment = TotalAgreementPayment;
            param.ExternalId = 0;
            param.UserId = UserID;

            insertPaymentAgreement = virtualOfficeServiceClient.SetPaymentAgreementPolicy(param);

            if (insertPaymentAgreement.Code != RESPONSE_CODE_SUCCESS)
            {
                lastMessage += "Response Code: " + insertPaymentAgreement.Code + "\nMensaje: " + insertPaymentAgreement.Message;
                lastMessage += "\nParámetros: " + JsonConvert.SerializeObject(param, Formatting.Indented) + "\n--\n";
                wasInsertPaymentAgreement = false;
            }

            if (!wasInsertPaymentAgreement)
            {
                throw new Exception("Error en el llamado al método SetPaymentAgreementPolicy.\nDetalle: " + lastMessage);
            }

            return insertPaymentAgreement;
        }

        public STL.POS.VirtualOfficeProxy.VOProxy.CalculateLoansResult GetAmortizationTable(double Amount, int period, string loanType, int Percentage, double pTotalPrimium)
        {

            CalculateLoansResult result = virtualOfficeServiceClient.ksiCalculator(new PolicyksiCalculatorparameter
            {
                Amount = 0,
                DesiredAmount = Amount,
                Periods = period,
                LoanType = (STL.POS.VirtualOfficeProxy.VOProxy.LoanType)Enum.Parse(typeof(STL.POS.VirtualOfficeProxy.VOProxy.LoanType), loanType),
                DownPaymentPercentage = Percentage,
                TotalPremium = pTotalPrimium
            });

            if (result.Code == "002")
            {
                throw new Exception("Ha ocurrido un error generando la tabla de Amortizacion.\nDetalle: " + result.Message);
            }
            else if (result.Code == "001")
            {
                throw new Exception("Faltaron algunos datos para generar la tabla de Amortizacion.\nDetalle: " + result.Message);
            }

            return result;
        }

        public STL.POS.VirtualOfficeProxy.VOProxy.getResult GetEconomicActivities()
        {
            return virtualOfficeServiceClient.ksiEconomyActivity();
        }

        /// <summary>
        /// Domiciliacion del pago con GP
        /// </summary>
        /// <param name="quotation"></param>
        /// <param name="dataResultPaymentAgreement"></param>
        /// <param name="vCompañia"></param>
        /// <param name="Cotizacion"></param>
        /// <param name="BeginDate"></param>
        /// <param name="PolicyNo"></param>
        /// <param name="UserCodeName"></param>
        /// <returns></returns>
        public GpDomiciliationResult Domiciliation(Quotation quotation, int Payments, int vCompañia, decimal Cotizacion, DateTime? BeginDate, string PolicyNo, string UserCodeName)
        {
            var _contractClass = new ST_PC_CONTRACT_CLASSES();

            var _payments = 0;  //Cantidad de pagos a realizar.
            var _Amount = 0m;   //Pagos Siguientes
            var _InitialPayment = 0m; //Pago inicial

            if (quotation.PaymentFrequencyId > 0)
            {
                //Buscar acuerdo en sysflex
                _payments = quotation.PaymentFrequencyId.GetValueOrDefault();
                _InitialPayment = quotation.AmountToPayEnteredByUser.GetValueOrDefault();
                var dataBuscarAcuerdos = coreProxyClient.BuscarAcuerdos(vCompañia, Convert.ToDecimal(quotation.QuotationCoreNumber), 1, _InitialPayment, _payments, "Cotizacion").ToList();
                if (dataBuscarAcuerdos.Count > 0)
                {
                    var cuota = dataBuscarAcuerdos.Where(x => x.Cuota > 0).FirstOrDefault();
                    if (cuota != null)
                        _Amount = cuota.MontoCuota;
                }
            }

            var _Paiment_Frequeci = Convert.ToInt32(Helperes.GpFrecuencytype.Monthly);

            var _contractNumber = string.Empty;
            var _Card_Type = string.Empty;

            var _dpDateBegin = BeginDate.GetValueOrDefault().Date.AddDays(1);
            var _dpDateEnd = _dpDateBegin.Date.AddMonths(_payments);

            Customer _customer = null;
            CardTypes cardType = CardTypes.VISA;

            switch (quotation.Credit_Card_Type_Id)
            {
                case 1:
                    cardType = CardTypes.MASTERCARD;
                    break;
                case 2:
                    cardType = CardTypes.AMEX;
                    break;
                case 3:
                    cardType = CardTypes.VISA;
                    break;
                case 4:
                    cardType = CardTypes.DINERS;
                    break;
                case 5:
                    cardType = CardTypes.DISCOVER;
                    break;
                case 6:
                    cardType = CardTypes.AMEX;
                    break;
            }

            _customer = new Customer
            {
                CustClass = string.Empty,
                Custname = quotation.PrincipalFullName,
                Custnmbr = PolicyNo,
                Inactive = 1
            };

            var dataContract = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
            if (!string.IsNullOrEmpty(dataContract.JSONResult))
                _contractNumber = dataContract.JSONResult.Replace("\"", "");

            var dataGpCardType = virtualOfficeServiceClient.GPGetCardType();

            if (!string.IsNullOrEmpty(dataGpCardType.JSONResult))
            {
                var DataCardType = JsonConvert.DeserializeObject<Helperes.GpItemCardTypes>(dataGpCardType.JSONResult);

                if (DataCardType != null)
                    _Card_Type = DataCardType.CARDNAME.FirstOrDefault(x => x.Trim().Replace(" ", "").ToUpper() == cardType.ToString().Trim().Replace(" ", "").ToUpper());
            }

            #region validacion de Domiciliar el pago inicial
            DateTime _nextDate;

            PolicyGpDomiciliationparameters itemGpDomiciliation;
            GpDomiciliationResult PublicCollectionContractResult = null;

            //_nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();
            _nextDate = _dpDateBegin;

            var PaymentFreqPagoInicial = Convert.ToInt32(Helperes.GpFrecuencytype.Onetime);

            if (quotation.DomicileInitialPayment.GetValueOrDefault()) // valido si desean domiciliar el pago del inicial para contemplar esto o no
            {
                //Pago inicial
                itemGpDomiciliation = new PolicyGpDomiciliationparameters
                {
                    AccountHolderName = quotation.Card_Holder,
                    AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                    AccountType = "CC",
                    CardType = _Card_Type,
                    ContractNumber = _contractNumber,
                    ContratClass = _contractClass,
                    CurrencyId = "Z-DOP$",
                    CustomerNumnber = _customer,
                    ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                    ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                    Frecuency = PaymentFreqPagoInicial,
                    Hold = false,
                    DayofMonth = _dpDateBegin.Day,
                    EndDate = _dpDateEnd,
                    StartDate = _dpDateBegin,
                    NextDate = _nextDate,
                    NumberofPayment = 1,
                    PaymentMethod = 0,
                    RoutingNumber = string.Empty,
                    TaxId = string.Empty,
                    amount = _InitialPayment,
                    user = UserCodeName
                };

                PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);

                var hasError = ErrorCode.Contains(PublicCollectionContractResult.Code);

                if (!hasError)
                {
                    var dataContractNextPay = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
                    if (!string.IsNullOrEmpty(dataContractNextPay.JSONResult))
                        _contractNumber = dataContractNextPay.JSONResult.Replace("\"", "");

                    //Proximos pagos
                    _nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();
                    itemGpDomiciliation = new PolicyGpDomiciliationparameters
                    {
                        AccountHolderName = quotation.Card_Holder,
                        AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                        AccountType = "CC",
                        CardType = _Card_Type,
                        ContractNumber = _contractNumber,
                        ContratClass = _contractClass,
                        CurrencyId = "Z-DOP$",
                        CustomerNumnber = _customer,
                        ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                        ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                        Frecuency = _Paiment_Frequeci,
                        Hold = false,
                        DayofMonth = _dpDateBegin.Day,
                        EndDate = _dpDateEnd,
                        StartDate = _dpDateBegin,
                        NextDate = _nextDate,
                        NumberofPayment = _payments,
                        PaymentMethod = 0,
                        RoutingNumber = string.Empty,
                        TaxId = string.Empty,
                        amount = _Amount,
                        user = UserCodeName
                    };

                    PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);
                }
            }
            else // proceso solo las cuotas y no el inicial
            {
                var dataContractNextPay = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
                if (!string.IsNullOrEmpty(dataContractNextPay.JSONResult))
                    _contractNumber = dataContractNextPay.JSONResult.Replace("\"", "");

                //Proximos pagos
                _nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();
                itemGpDomiciliation = new PolicyGpDomiciliationparameters
                {
                    AccountHolderName = quotation.Card_Holder,
                    AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                    AccountType = "CC",
                    CardType = _Card_Type,
                    ContractNumber = _contractNumber,
                    ContratClass = _contractClass,
                    CurrencyId = "Z-DOP$",
                    CustomerNumnber = _customer,
                    ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                    ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                    Frecuency = _Paiment_Frequeci,
                    Hold = false,
                    DayofMonth = _dpDateBegin.Day,
                    EndDate = _dpDateEnd,
                    StartDate = _dpDateBegin,
                    NextDate = _nextDate,
                    NumberofPayment = _payments,
                    PaymentMethod = 0,
                    RoutingNumber = string.Empty,
                    TaxId = string.Empty,
                    amount = _Amount,
                    user = UserCodeName
                };

                PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);
            }
            #endregion

            return
                PublicCollectionContractResult;
        }
        public GpDomiciliationResult SetDomiciliationNewPosSite(Entity.Entities.Quotation quotation, int Payments, int vCompañia, decimal Cotizacion, DateTime? BeginDate, string PolicyNo, string UserCodeName)
        {
            var _contractClass = new ST_PC_CONTRACT_CLASSES();

            var _payments = 0;  //Cantidad de pagos a realizar.
            var _Amount = 0m;   //Pagos Siguientes
            var _InitialPayment = 0m; //Pago inicial

            if (quotation.PaymentFrequencyId > 0)
            {
                //Buscar acuerdo en sysflex
                _payments = quotation.PaymentFrequencyId.GetValueOrDefault();
                _InitialPayment = quotation.AmountToPayEnteredByUser.GetValueOrDefault();
                var dataBuscarAcuerdos = coreProxyClient.BuscarAcuerdos(vCompañia, Convert.ToDecimal(quotation.QuotationCoreNumber), 1, _InitialPayment, _payments, "Cotizacion").ToList();
                if (dataBuscarAcuerdos.Count > 0)
                {
                    var cuota = dataBuscarAcuerdos.Where(x => x.Cuota > 0).FirstOrDefault();
                    if (cuota != null)
                        _Amount = cuota.MontoCuota;
                }
            }

            var _Paiment_Frequeci = Convert.ToInt32(Helperes.GpFrecuencytype.Monthly);

            var _contractNumber = string.Empty;
            var _Card_Type = string.Empty;

            var _dpDateBegin = BeginDate.GetValueOrDefault().Date.AddDays(1);
            var _dpDateEnd = _dpDateBegin.Date.AddMonths(_payments);

            Customer _customer = null;
            CardTypes cardType = CardTypes.VISA;

            switch (quotation.Credit_Card_Type_Id)
            {
                case 1:
                    cardType = CardTypes.MASTERCARD;
                    break;
                case 2:
                    cardType = CardTypes.AMEX;
                    break;
                case 3:
                    cardType = CardTypes.VISA;
                    break;
                case 4:
                    cardType = CardTypes.DINERS;
                    break;
                case 5:
                    cardType = CardTypes.DISCOVER;
                    break;
                case 6:
                    cardType = CardTypes.AMEX;
                    break;
            }

            _customer = new Customer
            {
                CustClass = string.Empty,
                Custname = quotation.PrincipalFullName,
                Custnmbr = PolicyNo,
                Inactive = 1
            };

            var dataContract = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
            if (!string.IsNullOrEmpty(dataContract.JSONResult))
                _contractNumber = dataContract.JSONResult.Replace("\"", "");

            var dataGpCardType = virtualOfficeServiceClient.GPGetCardType();

            if (!string.IsNullOrEmpty(dataGpCardType.JSONResult))
            {
                var DataCardType = JsonConvert.DeserializeObject<Helperes.GpItemCardTypes>(dataGpCardType.JSONResult);

                if (DataCardType != null)
                    _Card_Type = DataCardType.CARDNAME.FirstOrDefault(x => x.Trim().Replace(" ", "").ToUpper() == cardType.ToString().Trim().Replace(" ", "").ToUpper());
            }

            #region validacion de Domiciliar el pago inicial

            DateTime _nextDate;

            PolicyGpDomiciliationparameters itemGpDomiciliation;
            GpDomiciliationResult PublicCollectionContractResult;


            if (quotation.DomicileInitialPayment.GetValueOrDefault())
            {
                _nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();

                //Pago inicial
                var PaymentFreqPagoInicial = Convert.ToInt32(Helperes.GpFrecuencytype.Onetime);
                itemGpDomiciliation = new PolicyGpDomiciliationparameters
                {
                    AccountHolderName = quotation.Card_Holder,
                    AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                    AccountType = "CC",
                    CardType = _Card_Type,
                    ContractNumber = _contractNumber,
                    ContratClass = _contractClass,
                    CurrencyId = "Z-DOP$",
                    CustomerNumnber = _customer,
                    ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                    ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                    Frecuency = PaymentFreqPagoInicial,
                    Hold = false,
                    DayofMonth = _dpDateBegin.Day,
                    EndDate = _dpDateEnd,
                    StartDate = _dpDateBegin,
                    NextDate = DateTime.Now.AddDays(1),
                    NumberofPayment = 1,
                    PaymentMethod = 0,
                    RoutingNumber = string.Empty,
                    TaxId = string.Empty,
                    amount = _InitialPayment,
                    user = UserCodeName
                };

                PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);

                var hasError = ErrorCode.Contains(PublicCollectionContractResult.Code);

                if (!hasError)
                {
                    var dataContractNextPay = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
                    if (!string.IsNullOrEmpty(dataContractNextPay.JSONResult))
                        _contractNumber = dataContractNextPay.JSONResult.Replace("\"", "");

                    //Proximos pagos
                    _nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();
                    itemGpDomiciliation = new PolicyGpDomiciliationparameters
                    {
                        AccountHolderName = quotation.Card_Holder,
                        AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                        AccountType = "CC",
                        CardType = _Card_Type,
                        ContractNumber = _contractNumber,
                        ContratClass = _contractClass,
                        CurrencyId = "Z-DOP$",
                        CustomerNumnber = _customer,
                        ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                        ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                        Frecuency = _Paiment_Frequeci,
                        Hold = false,
                        DayofMonth = _dpDateBegin.Day,
                        EndDate = _dpDateEnd,
                        StartDate = _dpDateBegin,
                        NextDate = _nextDate,
                        NumberofPayment = _payments,
                        PaymentMethod = 0,
                        RoutingNumber = string.Empty,
                        TaxId = string.Empty,
                        amount = _Amount,
                        user = UserCodeName
                    };

                    PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);
                }
            }
            else
            {
                var dataContractNextPay = virtualOfficeServiceClient.GPGetContractNumber(_customer.Custnmbr, UserCodeName);
                if (!string.IsNullOrEmpty(dataContractNextPay.JSONResult))
                    _contractNumber = dataContractNextPay.JSONResult.Replace("\"", "");

                //Proximos pagos
                _nextDate = GetNextDate(_dpDateBegin, _Paiment_Frequeci).GetValueOrDefault();
                itemGpDomiciliation = new PolicyGpDomiciliationparameters
                {
                    AccountHolderName = quotation.Card_Holder,
                    AccountNumber = Helperes.Decrypt_Query(quotation.Credit_Card_Number),
                    AccountType = "CC",
                    CardType = _Card_Type,
                    ContractNumber = _contractNumber,
                    ContratClass = _contractClass,
                    CurrencyId = "Z-DOP$",
                    CustomerNumnber = _customer,
                    ExpMonth = quotation.Expiration_Date_Month.GetValueOrDefault(),
                    ExpYear = quotation.Expiration_Date_Year.GetValueOrDefault(),
                    Frecuency = _Paiment_Frequeci,
                    Hold = false,
                    DayofMonth = _dpDateBegin.Day,
                    EndDate = _dpDateEnd,
                    StartDate = _dpDateBegin,
                    NextDate = _nextDate,
                    NumberofPayment = _payments,
                    PaymentMethod = 0,
                    RoutingNumber = string.Empty,
                    TaxId = string.Empty,
                    amount = _Amount,
                    user = UserCodeName
                };

                PublicCollectionContractResult = virtualOfficeServiceClient.GPPublicCollectionContract(itemGpDomiciliation);
            }
            #endregion


            return
                PublicCollectionContractResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dpDateBegin"></param>
        /// <param name="_Paiment_Frequeci"></param>
        /// <returns></returns>
        private DateTime? GetNextDate(DateTime _dpDateBegin, int _Paiment_Frequeci)
        {
            try
            {
                var nextDate = _Paiment_Frequeci == 1 ? _dpDateBegin.AddDays(1) :
                        _Paiment_Frequeci == 2 ? _dpDateBegin.AddDays(7) :
                        _Paiment_Frequeci == 3 ? _dpDateBegin.AddDays(14) :
                        _Paiment_Frequeci == 4 ? _dpDateBegin.AddMonths(1) :
                        _Paiment_Frequeci == 5 ? _dpDateBegin.AddMonths(2) :
                        _Paiment_Frequeci == 6 ? _dpDateBegin.AddMonths(3) :
                        _Paiment_Frequeci == 7 ? _dpDateBegin.AddMonths(6) :
                        _Paiment_Frequeci == 8 ? _dpDateBegin.AddYears(1) : _dpDateBegin;

                return nextDate;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string MyRemoveInvalidCharacters(string value)
        {
            return value.Replace("\\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace(":", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("í", "i")
                         .Replace("á", "a").Replace("é", "e").Replace("ó", "o").Replace("ú", "u");
        }



        #region Cupones
        public VOProxy.getResult GenerateCoupons(VOProxy.CouponsGenerateCoupons parameters)
        {
            return virtualOfficeServiceClient.GenerateCoupons(parameters);
        }

        public VOProxy.getResult GetCoupon(VOProxy.CouponsGetCoupons parameters)
        {
            return virtualOfficeServiceClient.GetCoupons(parameters);
        }

        public VOProxy.getResult ValidateCoupon(VOProxy.CouponsValidateCoupon parameters)
        {
            return virtualOfficeServiceClient.ValidateCoupon(parameters);
        }

        public VOProxy.getResult SetCouponProspect(VOProxy.CouponsCouponProspect parameters)
        {
            return virtualOfficeServiceClient.SetCouponProspect(parameters);
        }

        public VOProxy.getResult ValidateCouponByChannel(VOProxy.CouponsValidateCoupon parameters)
        {
            return virtualOfficeServiceClient.ValidateCouponByChannel(parameters);
        }

        #endregion

        public void SetRiskLevelPolicy(string QutoationNumber)
        {
            var result = virtualOfficeServiceClient.SetRiskLevelPolicy(QutoationNumber);
        }

        public string getRiskGetRiskLevelAuto(System.Nullable<int> vechicleCount, string uso, System.Nullable<decimal> premiumAmount, System.Nullable<decimal> totalVehicleValue, System.Nullable<decimal> totalVechicleInsuredAmount, int? PaisId)
        {
            var result = virtualOfficeServiceClient.GetRiskLevelAuto(vechicleCount, uso, premiumAmount, totalVehicleValue, totalVechicleInsuredAmount, PaisId);

            return
                result.JSONResult;
        }

        private PolicyPolicyCoverages[] GetPolizaCoberturasMovCanceladaProspecto(decimal coreQuotationNumber, int? secuenciaVehicleSysflex, int? secuenciaMov, string newEndpointCotizacion)
        {
            var sfsc = new SysFlexServiceClient();

            if (!string.IsNullOrEmpty(newEndpointCotizacion))
            {
                sfsc.Endpoint.Address = new System.ServiceModel.EndpointAddress(newEndpointCotizacion);
            }

            var SysFlexProxy = new CoreProxy(sfsc);

            return SysFlexProxy.GetPolizaCoberturasMovCanceladaProspecto(coreQuotationNumber, secuenciaVehicleSysflex, secuenciaMov);

        }
    }

    public class contactMatchResult
    {
        public string CustomerNumber { get; set; }
        public int ContactTypeId { get; set; }
        public int LanguageId { get; set; }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public DateTime Dob { get; set; }
        public string Ids { get; set; }

        public int ContactId { get; set; }
        public string MiddleName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public string CountryDesc { get; set; }
    }

    public class VehicleItem
    {
        public long? VehicleUniqueId { get; set; }
        public string Registry { get; set; }
        public string Chassis { get; set; }
    }

    public class PolicyItem
    {
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticregId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
    }
}