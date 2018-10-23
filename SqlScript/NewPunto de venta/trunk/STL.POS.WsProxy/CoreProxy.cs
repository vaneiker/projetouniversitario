﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using STL.POS.Data;
using STL.POS.WsProxy.WSSysFlexVehicleService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.WsProxy.SysflexService;

namespace STL.POS.WsProxy
{
    public enum SysFlexCoverageDetailsIndicators
    {
        SelfAndThirdParty = 0,
        AdditionalServices = 1
    }

    public class CoreProxy : ICoreProxy
    {
        private WSSysFlexVehicleSoapClient soapClient = new WSSysFlexVehicleSoapClient();
        private SysFlexServiceClient soapClient2;
        public delegate IEnumerable<Entity.Entities.ProductLimits> getVehicleProductLimitVehicle(int VehicleId);

        private int COD_COMPANIA = 30;
        private string[] ErrorCode { get { return new string[] { "001", "002" }; } }

        public CoreProxy(SysFlexServiceClient sClient)
        {
            soapClient2 = sClient;
        }

        public IList<VehicleTypeWS> GetVehicleTypes(int vehicleTypeCoreId, int vehicleYear, string coreDeLeyStringDiscriminator, int codRamo)
        {
            var output = new List<VehicleTypeWS>();

            //var prods = soapClient.GetProducts(0, vehicleTypeCoreId, vehicleYear);

            PolicyProductSysFlexProductsKey param = new PolicyProductSysFlexProductsKey();
            param.ProductoId = null;
            param.TipoVehiculo = vehicleTypeCoreId;
            param.ano = vehicleYear;
            param.RamoId = codRamo;

            var prods = soapClient2.GetProductsEx(param);

            var vehicleTypes = (from p in prods
                                orderby p.ProductName
                                select p.ProductName).Distinct().ToList();

            //var j = prods.Where(x => !x.ProductTypeID.HasValue).Select(a => a).ToArray();
            foreach (var vtId in vehicleTypes.OrderBy(t => t))
            {
                var vehicleType = new VehicleTypeWS();
                //vehicleType.Id = vtId.Id;
                vehicleType.Name = vtId;
                vehicleType.Products = new List<ProductWS>();

                var products = (from p in prods
                                where p.ProductName == vtId
                                select p.ProductTypeID.Value).Distinct().ToList();

                foreach (var p in products)
                {
                    var prod = new ProductWS();
                    prod.Id = p;
                    prod.Name = prods.First(pd => pd.ProductTypeID.Value == p).ProducttypeName;
                    prod.Coverages = new List<CoverageWS>();

                    var cobs = (from pr in prods
                                where pr.ProductName == vtId
                                && pr.ProductTypeID == p
                                select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();

                    /*
                     NOTA:
                     Si un producto requiere inspección, eso significa que no es de Ley, si no la requiere es un producto de ley.                     
                     pr.RequiereInspeccion == false ? true : false
                     */

                    foreach (var c in cobs)
                    {
                        var cov = new CoverageWS();
                        cov.Id = c.Id;
                        cov.Name = c.Name;
                        //cov.IsLaw = c.Type == coreDeLeyStringDiscriminato//ORIGINAL 26-09-2016;
                        cov.IsLaw = c.IsLaw;

                        prod.Coverages.Add(cov);
                    }

                    prod.Coverages = prod.Coverages.OrderBy(c => c.Name).ToList();

                    vehicleType.Products.Add(prod);

                }
                vehicleType.Products = vehicleType.Products.OrderBy(p => p.Name).ToList();

                output.Add(vehicleType);
            }

            return output;
        }

        /// <summary>
        /// Obtener las coberturas
        /// </summary>
        /// <param name="coverageCoreId"></param>
        /// <param name="Indicador"></param>
        /// <param name="vehiclePrice"></param>
        /// <returns></returns>
        public IEnumerable<PolicyCoverageSysFlexCoverageDetails> GetCoverage(int coverageCoreId, int Indicador, decimal vehiclePrice, int codRamo)
        {
            var result = GetCoverageNewDetail(coverageCoreId, Indicador, vehiclePrice, codRamo);

            return result;
        }

        /// <summary>
        /// Obtener las coberturas
        /// </summary>
        /// <param name="coverageCoreId"></param>
        /// <param name="Indicador"></param>
        /// <param name="vehiclePrice"></param>
        /// <returns></returns>
        public IEnumerable<PolicyCoverageSysFlexCoverageDetails> GetCoverageNewDetail(int coverageCoreId, int Indicador, decimal vehiclePrice, int codRamo)
        {
            PolicyCoverageSysFlexCoverageDetailsKey param = new PolicyCoverageSysFlexCoverageDetailsKey();
            param.CoverageID = coverageCoreId;
            param.Indicador = Indicador;
            param.Ramo = codRamo;
            param.VehiculoMonto = vehiclePrice;

            var result = soapClient2.GetCoverageDetails(param);

            return result;

        }

        public ProductLimit GetCoverageDetails(int coverageCoreId, decimal vehiclePrice, int codRamo)
        {
            ProductLimit pLimit = new ProductLimit();
            decimal temp;

            //var selfAndOthersORIGINAL = soapClient.GetCoverageDetails(coverageCoreId, (int)SysFlexCoverageDetailsIndicators.SelfAndThirdParty, vehiclePrice);

            var selfAndOthers = GetCoverageNewDetail(coverageCoreId, (int)SysFlexCoverageDetailsIndicators.SelfAndThirdParty, vehiclePrice, codRamo);

            pLimit.ThirdPartyCoverages = (from s in selfAndOthers
                                          where s.CoverageDetailType.ToLower() == CoverageDetail.CoverageDetailTypeThirdParty.ToLower()
                                          orderby s.CoverageDetailName
                                          select new CoverageDetail()
                                          {
                                              CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                              Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                              MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                              Name = s.CoverageDetailName
                                          }).ToList();

            pLimit.SelfDamagesCoverages = (from s in selfAndOthers
                                           where s.CoverageDetailType.ToLower() == CoverageDetail.CoverageDetailTypeSelfDamages.ToLower()
                                           orderby s.CoverageDetailName
                                           select new CoverageDetail()
                                           {
                                               CoverageDetailCoreId = s.CoverageDetailID.GetValueOrDefault(),
                                               Amount = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               Limit = decimal.TryParse(s.CoverageDetaiInformationAmount, out temp) ? Convert.ToDecimal(s.CoverageDetaiInformationAmount) : 0m,
                                               MinDeductible = s.MinimumDeductible.GetValueOrDefault(),
                                               Name = s.CoverageDetailName
                                           }).ToList();

            //Additionals
            //var services = soapClient.GetCoverageDetails(coverageCoreId, (int)SysFlexCoverageDetailsIndicators.AdditionalServices, vehiclePrice);
            var services = GetCoverageNewDetail(coverageCoreId, (int)SysFlexCoverageDetailsIndicators.AdditionalServices, vehiclePrice, codRamo);

            pLimit.ServicesCoverages = (from s in services
                                        orderby s.CoverageDetailType
                                        select s.CoverageDetailType).Distinct().Select(s =>
                                        new ServiceType
                                        {
                                            Name = s,
                                            Coverages = new List<CoverageDetail>()
                                        }).Distinct().ToList();

            var rand = new Random(DateTime.Now.Millisecond);

            pLimit.ServicesCoverages.ToList().ForEach(sc =>
            {
                var coverages = (from s in services
                                 where s.CoverageDetailType == sc.Name
                                 orderby s.CoverageDetailName
                                 select new CoverageDetail()
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

        public int GetProductId(int coverageId, int vehicleTypeCoreId, string productDescription, int vehicleYear, int codRamo)
        {
            //var product = soapClient.GetProducts(0, vehicleTypeCoreId, vehicleYear).FirstOrDefault(p => p.ProductName == productDescription

            PolicyProductSysFlexProductsKey param = new PolicyProductSysFlexProductsKey();
            param.ProductoId = null;
            param.TipoVehiculo = vehicleTypeCoreId;
            param.ano = vehicleYear;
            param.RamoId = codRamo;

            var product = soapClient2.GetProductsEx(param).FirstOrDefault(p => p.ProductName == productDescription && p.CoverageID == coverageId);
            if (product != null)
                return product.ProductID.GetValueOrDefault(0);
            else
                return 0;
        }

        /// <summary>
        /// Obtiene el equivalente de la oficina de sysflex con la de global
        /// </summary>
        /// <param name="globalOfficeId"></param>
        /// <returns></returns>
        public OfficeMatchWS GetOfficeMatch(int globalOfficeId)
        {
            OfficeMatchWS result = null;

            //var dataResult = soapClient.GetOfficeMatch(globalOfficeId).FirstOrDefault();
            var dataResult = soapClient2.GetMatchOffice(globalOfficeId).FirstOrDefault();
            if (dataResult != null)
            {
                result = new OfficeMatchWS
                {
                    OfficeDesc = dataResult.OfficeDesc,
                    OfficeIdGlobal = dataResult.OfficeIdGlobal,
                    OfficeIdSysFlex = dataResult.OfficeIdSysFlex
                };
            }

            return result;
        }


        public Dictionary<string, object> GetRates(int coverageGroupSysFlexId,
            //public Dictionary<string, decimal> GetRates(int coverageGroupSysFlexId,
            string productSysflexDescription,
            int vehicleYear,
            int vehicleTypeCoreId,
            decimal insuredAmount,
            int coveragePercent,
            int storageId,
            int sexId,
            int age,
            DateTime beginDate,
            DateTime endDate,
            string deductibleId,
            string servicesIdList,
            int coreModelId,
            int intermediario,
            decimal? percentSurCharge,
            bool LicenciaExtranjera,
            int qtyVehicles,
            int codRamo)
        {

            var productId = GetProductId(coverageGroupSysFlexId, vehicleTypeCoreId, productSysflexDescription, vehicleYear, codRamo);

            var param = new PolicyRateKey();
            param.CoverageID = coverageGroupSysFlexId;
            param.TarifaLeyID = productId;
            param.SumaAsegurada = insuredAmount;
            param.FechaInicio = beginDate;
            param.FechaFin = endDate;
            param.Modelo = coreModelId;
            param.AnoVehiculo = vehicleYear;
            param.ServicesID = servicesIdList;
            param.RecargosID = (string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId);
            param.RecargosIDDeducible = string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId.ToString();
            param.RecargosIDEstaciona = storageId.ToString();
            param.RecargoEdad = age.ToString();
            param.RecargosSexo = sexId.ToString();
            param.PorcientoCobertura = coveragePercent;
            param.RamoID = codRamo;
            param.Intermediario = intermediario;
            param.PorcIntermediarioRecargo = percentSurCharge.HasValue ? percentSurCharge.Value : 0.0m;
            param.LicenciaExtranjera = LicenciaExtranjera;
            param.CantidadVehiculos = qtyVehicles;

            /*var rates = soapClient.GetRates(overageGroupSysFlexId
                , productId
                , vehicleYear
                , insuredAmount
                , coveragePercent
                , servicesIdList
                , string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId
                , beginDate
                , endDate
                , storageId.ToString()
                , string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId.ToString()
                , sexId.ToString()
                , age.ToString()
                , coreModelId
                , intermediario
                , percentSurCharge.HasValue ? percentSurCharge.Value : 0.0m
                , LicenciaExtranjera,
                qtyVehicles)*/

            var rates = soapClient2.GetRate(param);

            if (rates != null)
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("CoverageID", coverageGroupSysFlexId);
                parameters.Add("ProductID", productId);
                parameters.Add("VehicleYear", vehicleYear);
                parameters.Add("insuredAmount", insuredAmount);
                parameters.Add("coveragePercent", coveragePercent);
                parameters.Add("ServicesIDS", servicesIdList);
                parameters.Add("surchargeIDS", string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId);
                parameters.Add("beginDate", beginDate);
                parameters.Add("EndgDate", endDate);
                parameters.Add("RecargosIDEstaciona", storageId.ToString());
                parameters.Add("RecargosIDDeducible", string.IsNullOrEmpty(deductibleId) ? string.Empty : deductibleId.ToString());
                parameters.Add("RecargosSexo", sexId.ToString());
                parameters.Add("RecargoEdad", age.ToString());
                parameters.Add("Modelo", coreModelId);
                parameters.Add("Intermediario", intermediario);
                parameters.Add("PorcIntermediarioRecargo", percentSurCharge.HasValue ? percentSurCharge.Value : 0.0m);
                parameters.Add("LicenciaExtranjera", LicenciaExtranjera);
                parameters.Add("CantidadVehiculos", qtyVehicles);
                parameters.Add("fechaLlamada", DateTime.Now);

                var AllToJson = JsonConvert.SerializeObject(new object[] { parameters, rates });

                //var output = new Dictionary<string, decimal>();
                var output = new Dictionary<string, object>();
                output.Add("TpPrime", rates.FirstOrDefault().PrimaTerceros);
                output.Add("SdPrime", (rates.FirstOrDefault().PrimaDanosPropio + rates.FirstOrDefault().MontoRecargos - rates.FirstOrDefault().MontoDescuentos));
                output.Add("ServicesPrime", rates.FirstOrDefault().PrimaServicio);
                output.Add("TotalIsc", rates.FirstOrDefault().MontoImpuesto);
                output.Add("VehicleTypeId", productId);
                output.Add("jsonRates", AllToJson);
                output.Add("PrimaDanosPropio", rates.FirstOrDefault().PrimaDanosPropio);
                output.Add("PorcImpuesto", rates.FirstOrDefault().PorcImpuesto);

                return output;
            }
            else
                return null;
        }

        public IList<DeductibleValues> GetDeductibles(int coverageCoreId, Parameter seqId, int modelo, int codRamo)
        {
            //var surcharges2 = soapClient.GetSurcharges(coverageCoreId, Convert.ToInt32(seqId.Value), modelo);

            var param = new PolicyRefillsKey();
            param.coveregeID = coverageCoreId;
            param.CondicionId = Convert.ToInt32(seqId.Value);
            param.modelo = modelo;
            param.RamoId = codRamo;

            var surcharges = soapClient2.GetRefills(param);

            var output = from s in surcharges
                         orderby s.Descripcion
                         select new DeductibleValues() { CoreId = s.Secuencia, Name = s.Descripcion };

            return output.ToList();
        }

        public IList<decimal> GetPercentagesForCoverage(int coverageId, int vehicleYear)
        {
            var output = new List<decimal>();
            //var percentages = soapClient.GetVehicleYears(vehicleYear, coverageId).FirstOrDefault();
            PolicyVehicleSysFlexVehicleYearsKey param = new PolicyVehicleSysFlexVehicleYearsKey();
            param.CoverageID = coverageId;
            param.Year = vehicleYear;

            var percentages = soapClient2.GetVehicleYears(param).FirstOrDefault();

            if (percentages != null)
            {
                if (percentages.Percent_First.GetValueOrDefault() > 0)
                    output.Add(percentages.Percent_First.Value);

                if (percentages.Percent_Second.GetValueOrDefault() > 0)
                    output.Add(percentages.Percent_Second.Value);

                if (percentages.Percent_Third.GetValueOrDefault() > 0)
                    output.Add(percentages.Percent_Third.Value);

                if (percentages.Percent_Fourth.GetValueOrDefault() > 0)
                    output.Add(percentages.Percent_Fourth.Value);
            }
            else
                output.Add(100);

            return output;
        }

        public bool? GetPolicyMov(string PolicyNumber)
        {
            return
                soapClient2.GetCanMakePolicyMov(PolicyNumber);
        }

        public bool SetAutoQuotation(QuotationAuto quotation,
            int codMoneda,
            int tasaMoneda,
            int codIntermediario,
            int codOficina,
            int codRamo,
            int retryAmount,
            string username,
            int companySysflex,
            decimal porcDescuentoFlotilla,
            int descuentoFlotillaIDSysflex,
            decimal porcProntoPago,
            int descuentoProntoPagoIDSysflex,
            string Sistema,
            out string poliza,
            out decimal quotationCoreIdNumber,
            out decimal clientId,
            out List<string> statusMessages,
            out string SourceID,
            out Dictionary<int, string> listVehicleSourceID,
            out bool errorGP
            )
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "Punto de Venta";
            }

            COD_COMPANIA = companySysflex;


            //SetClient
            //SetCotizaciónCobertura
            //SetCotizacionDetail
            //SetCEmision
            //SetCEmisionPagos
            poliza = string.Empty;
            quotationCoreIdNumber = 0;
            clientId = 0;
            statusMessages = new List<string>();
            var status = true;
            var lastMessage = string.Empty;
            var success = false;
            SourceID = string.Empty;
            listVehicleSourceID = new Dictionary<int, string>();
            errorGP = false;

            #region Clientes/SetQuotationHeader

            //var client = new SysFlexClientParameters();
            var client = new PolicyQuotationKey();
            var principal = quotation.Drivers.Where(d => d.IsPrincipal).FirstOrDefault();

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = COD_COMPANIA;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;

            if (principal.IdentificationType == "RNC")
            {
                //dob = null;
                dob = new DateTime(1753, 1, 1);
            }
            client.FechaNacimiento = dob;

            client.Intermediario = codIntermediario;
            client.Nacionalidad = principal.Nationality.Global_Country_Desc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = username;

            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            client.Cedula = principal.IdentificationNumber;

            //client.FechaLicencia = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;
            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;

            client.Sexo = sysflexSexMatch(principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;

            var retryCount = 0;

            //SysFlexCotizacionHeader clientResp = null;
            PolicyQuotationHeader clientResp = null;

            while (!success && retryCount < retryAmount)
            {
                try
                {
                    clientResp = soapClient2.SetQuotationHeader(client);

                    poliza = clientResp.Poliza;
                    quotationCoreIdNumber = clientResp.Cotizacion;
                    clientId = clientResp.Cliente.GetValueOrDefault(0);
                    success = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "El cliente " + principal.FirstName + " " + principal.FirstSurname + " no ha podido ser creado en Sysflex. Falla en el método SetQuotationHeader. Detalle: " + ex.Message;
                    success = false;
                }
                retryCount++;
            }
            #endregion

            if (!success)
            {
                statusMessages.Add(lastMessage);
                status = false;
            }
            else
            {
                #region Vehiculos

                var cantItems = quotation.VehicleProducts.Count;
                int i = 1;
                foreach (var vProd in quotation.VehicleProducts)
                {
                    //var cDetail = new SysFlexCotizacionDetailParameters();
                    var cDetail = new PolicyQuotationSysFlexCotDetExKey();

                    cDetail.anoVehiculo = vProd.Year.Value.ToString();
                    cDetail.chasis = vProd.Chassis;
                    //cDetail.Cilindro = vProd.Cylinders.Value.ToString();
                    cDetail.color = vProd.Color;
                    cDetail.compania = COD_COMPANIA;
                    cDetail.cotizacion = clientResp.Cotizacion;
                    cDetail.estacionaEn = vProd.StoreName;

                    /*Actualziacion de fecha de vencimiento en base a 6 meses*/
                    if (vProd.SelectedCoverageName.Contains("(6 Meses)")
                        || vProd.SelectedCoverageName.Contains("( 6 Meses )")
                        || vProd.SelectedCoverageName.Contains("( 6 Meses)")
                        || vProd.SelectedCoverageName.Contains("(6 Meses )")
                        )
                    {
                        var dateStart = quotation.StartDate.Value;
                        DateTime newEndDate = dateStart.AddMonths(6);

                        cDetail.fechaFin = newEndDate;
                        cDetail.fechaInicio = quotation.StartDate.Value;

                    }
                    else
                    {
                        cDetail.fechaFin = quotation.EndDate.Value;
                        cDetail.fechaInicio = quotation.StartDate.Value;
                    }

                    cDetail.items = i;// cantItems;
                    cDetail.marcaVehiculo = vProd.VehicleMakeName;
                    cDetail.modeloVehiculo = vProd.VehicleModel.Model_Desc;

                    cDetail.primaBruta = vProd.TotalPrime.Value;
                    cDetail.montoImpuesto = vProd.TotalIsc.GetValueOrDefault();
                    //cDetail.MontoDescuento = vProd.TotalDiscount.GetValueOrDefault();//OROIGINAL 02-12-2016
                    cDetail.montoDescuento = 0;
                    cDetail.primaNeta = cDetail.primaBruta + cDetail.montoImpuesto;

                    cDetail.montoRecargo = 0;
                    int passengers = 0;
                    int.TryParse(vProd.Passengers, out passengers);
                    //cDetail.Pasajeros = passengers;
                    cDetail.placa = vProd.Plate;
                    cDetail.porcDescuento = quotation.DiscountPercentage.GetValueOrDefault(0);
                    cDetail.porcDescuento = 0;
                    cDetail.porcImpuesto = quotation.ISCPercentage.GetValueOrDefault(0);
                    cDetail.porcRecargo = 0;
                    cDetail.ramo = codRamo;
                    cDetail.subRamo = vProd.SelectedCoverageCoreId.GetValueOrDefault();
                    cDetail.sumaAsegurada = vProd.InsuredAmount.Value;
                    cDetail.tarifaLeyID = vProd.SelectedVehicleTypeId.GetValueOrDefault();
                    cDetail.tasa = vProd.PercentageToInsure.Value;
                    cDetail.tipoVehiculo = vProd.VehicleTypeName;
                    cDetail.uso = vProd.UsageName;
                    cDetail.usuario = username;
                    cDetail.numeroFormulario = vProd.NumeroFormulario;

                    retryCount = 0;
                    success = false;
                    lastMessage = string.Empty;
                    //SysFlexCotizacionDetail cDetailResp = null;
                    string sourceID = ""; ;
                    while (!success && retryCount < retryAmount)
                    {
                        try
                        {
                            //cDetailResp = soapClient.SetCotizacionDetail(cDetail);
                            //listVehicleSourceID.Add(vProd.Id, cDetailResp.SourceId);

                            var r = soapClient2.SetQuotationDetailEx(cDetail);
                            sourceID = r.Insured_Vehicle_Id_Source_ID;
                            listVehicleSourceID.Add(vProd.Id, sourceID);
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage = "Falla en el webservice SetQuotationDetail. Detalle: " + ex.Message;
                            success = false;
                        }
                        retryCount++;
                    }

                    if (!success)
                    {
                        var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                        status &= false;
                    }


                    var limit = vProd.ProductLimits.Where(l => l.IsSelected).FirstOrDefault();

                    foreach (var cov in limit.SelfDamagesCoverages.Concat(limit.ThirdPartyCoverages))
                    {
                        //var cotCobertura = new SysFlexCotizacionCoberturas();
                        var cotCobertura = new PolicyQuotationCoverageKey();
                        cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                        cotCobertura.Compania = COD_COMPANIA;
                        cotCobertura.Cotizacion = clientResp.Cotizacion;
                        cotCobertura.Items = i;
                        cotCobertura.Limite = cov.Limit.ToString();

                        retryCount = 0;
                        success = false;
                        lastMessage = string.Empty;
                        //bool ccResp = false;
                        int ccResp = 0;
                        bool SetQuotationCoverageFail = false;
                        while (!success && retryCount < retryAmount)
                        {
                            try
                            {
                                //ccResp = soapClient.SetCotizacionCobertura(cotCobertura);
                                ccResp = soapClient2.SetQuotationCoverage(cotCobertura);
                                success = true;
                                SetQuotationCoverageFail = true;
                            }
                            catch (Exception ex)
                            {
                                lastMessage = "Falla en el webservice SetQuotationCoverage. Detalle: " + ex.Message;
                                success = false;
                                SetQuotationCoverageFail = false;
                            }
                            retryCount++;
                        }

                        //if (!ccResp)
                        if (!success && !SetQuotationCoverageFail)
                        {
                            var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                                msg += lastMessage;
                            statusMessages.Add(msg);
                            status &= false;
                        }
                    }

                    foreach (var vServ in limit.ServicesCoverages)
                    {
                        foreach (var cov in vServ.Coverages.Where(s => s.IsSelected))
                        {
                            //var cotCobertura = new SysFlexCotizacionCoberturas();
                            var cotCobertura = new PolicyQuotationCoverageKey();
                            cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                            cotCobertura.Compania = COD_COMPANIA;
                            cotCobertura.Cotizacion = clientResp.Cotizacion;
                            cotCobertura.Items = i;
                            cotCobertura.Limite = cov.Limit.ToString();

                            retryCount = 0;
                            success = false;
                            lastMessage = string.Empty;
                            //bool ccResp = false;
                            int ccResp = 0;
                            bool SetQuotationCoverageFail = false;
                            while (!success && retryCount < retryAmount)
                            {
                                try
                                {
                                    //ccResp = soapClient.SetCotizacionCobertura(cotCobertura);
                                    ccResp = soapClient2.SetQuotationCoverage(cotCobertura);
                                    success = true;
                                    SetQuotationCoverageFail = true;
                                }
                                catch (Exception ex)
                                {
                                    lastMessage = "Falla en el webservice SetQuotationCoverage. Detalle: " + ex.Message;
                                    success = false;
                                    SetQuotationCoverageFail = false;
                                }
                                retryCount++;
                            }

                            //if (!ccResp)
                            if (!success && !SetQuotationCoverageFail)
                            {
                                var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                    msg += lastMessage;
                                statusMessages.Add(msg);
                                status &= false;
                            }
                        }

                    }

                    i++;
                }
                #endregion


                #region Emision
                if (!quotation.SendInspectionOnly)
                {
                    //var emisionParam = new SysFlexEmisionParameter();
                    var emisionParam = new PolicyQuotationCoverageEmitionKey();
                    emisionParam.CodigoConcepto = 1;
                    emisionParam.Compania = COD_COMPANIA;
                    emisionParam.Cotizacion = clientResp.Cotizacion;
                    emisionParam.Usuario = username;

                    retryCount = 0;
                    success = false;
                    lastMessage = string.Empty;
                    //SysFlexEmision emisionResp = null;
                    PolicyQuotationCoverageEmition emisionResp = null;
                    while (!success && retryCount < retryAmount)
                    {
                        try
                        {
                            //emisionResp = soapClient.SetCEmision(emisionParam);
                            emisionResp = soapClient2.SetQuotationEmition(emisionParam);
                            poliza = emisionResp.Poliza;
                            SourceID = emisionResp.SourceId;
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage = ex.Message;
                            success = false;
                        }
                        retryCount++;
                    }


                    if (emisionResp != null)
                    {
                        try
                        {
                            //GENERANDO PAGO EN GP
                            //var emisionFactura = soapClient.SetCEmisionFactura(emisionParam);
                            var emisionFactura = soapClient2.SetQuotationEmitionFactura(emisionParam);
                            if (emisionFactura.Code != 1)//ERROR
                            {
                                success = false;
                                errorGP = true;
                                statusMessages.Add(emisionFactura.Message);
                            }
                            else if (emisionFactura.Code == 1)
                            {
                                success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetCEmisionFactura.";
                            lastMessage = ex.Message;
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                            {
                                msg += lastMessage;
                            }
                            statusMessages.Add(msg);
                            success = false;
                            errorGP = true;
                        }

                        if (success)
                        {
                            try
                            {
                                /*Acuerdo de Pago*/
                                //SysFlexAcuerdoDePagoParameter paramAcuerdoDePago = new SysFlexAcuerdoDePagoParameter();
                                PolicyPaymentAgreementKey paramAcuerdoDePago = new PolicyPaymentAgreementKey();
                                paramAcuerdoDePago.compania = COD_COMPANIA;
                                paramAcuerdoDePago.cotizacion = clientResp.Cotizacion;
                                paramAcuerdoDePago.sistema = Sistema;
                                paramAcuerdoDePago.usuario = username;

                                if (quotation.PaymentFrequencyId.HasValue)
                                {
                                    paramAcuerdoDePago.cantidadCuotas = quotation.PaymentFrequencyId.GetValueOrDefault();//la frecuencia de pago
                                    paramAcuerdoDePago.inicial = Convert.ToInt32(quotation.AmountToPayEnteredByUser);  //monto que escribrieron
                                }
                                else
                                {
                                    paramAcuerdoDePago.cantidadCuotas = 0;
                                    paramAcuerdoDePago.inicial = 0;
                                }

                                //var x = soapClient.SetAcuerdoDePago(paramAcuerdoDePago);
                                var x = soapClient2.SetPaymentAgreement(paramAcuerdoDePago);
                                success = true;
                                /**/
                            }
                            catch (Exception ex)
                            {
                                var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPaymentAgreement.";
                                lastMessage = ex.Message;
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                {
                                    msg += lastMessage;
                                }
                                statusMessages.Add(msg);
                                success = false;
                            }

                            //if (quotation.Messaging && quotation.PaymentFrequencyId.HasValue && quotation.PaymentFrequencyId.Value == 1 && quotation.User != null && quotation.User.AgentId.HasValue)//Efectivo
                            if (quotation.Messaging && quotation.PaymentWay.HasValue && (int)quotation.PaymentWay.Value == 1 && quotation.User != null && quotation.User.AgentId.HasValue && success)//Efectivo
                            {
                                try
                                {
                                    /*Mensajeria*/
                                    //SysFlexMensajeriaParameter param = new SysFlexMensajeriaParameter();
                                    PolicySysFlexMensajeriaKey param = new PolicySysFlexMensajeriaKey();
                                    param.Compania = COD_COMPANIA;
                                    param.Cotizacion = clientResp.Cotizacion;
                                    param.Usuario = username;
                                    //var mens = soapClient.SetMensajeria(param);
                                    var mens = soapClient2.SetMensajeria(param);

                                    success = true;
                                    /**/
                                }
                                catch (Exception ex)
                                {
                                    var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetMensajeria.";
                                    lastMessage = ex.Message;
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                    {
                                        msg += lastMessage;
                                    }
                                    statusMessages.Add(msg);
                                    success = false;
                                }
                            }

                            if (porcDescuentoFlotilla > 0)
                            {
                                try
                                {
                                    /*Si hay descuento de flotilla procesar el de flotilla primero*/
                                    /*Descuentos a Polizas Flotilla*/
                                    //SysFlexPolizaDescuentoParameter paramDiscount = new SysFlexPolizaDescuentoParameter();
                                    PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                    paramDiscount.Compania = COD_COMPANIA;
                                    paramDiscount.Sistema = Sistema;
                                    paramDiscount.Usuario = username;

                                    paramDiscount.Poliza = emisionResp.Poliza;
                                    paramDiscount.ConceptoId = descuentoFlotillaIDSysflex;
                                    paramDiscount.PorcDescuento = (porcDescuentoFlotilla / 100);

                                    //soapClient.SetPolizaDescuento(paramDiscount);
                                    soapClient2.SetPolizaDescuento(paramDiscount);
                                    success = true;
                                }
                                catch (Exception ex)
                                {
                                    var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Flotilla.";
                                    lastMessage = ex.Message;
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                    {
                                        msg += lastMessage;
                                    }
                                    statusMessages.Add(msg);
                                    success = false;
                                }
                            }

                            if (porcProntoPago > 0)
                            {
                                try
                                {
                                    /*Descuentos a Polizas Protno Pago*/
                                    //SysFlexPolizaDescuentoParameter paramDiscount = new SysFlexPolizaDescuentoParameter();
                                    PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                    paramDiscount.Compania = COD_COMPANIA;
                                    paramDiscount.Sistema = Sistema;
                                    paramDiscount.Usuario = username;

                                    paramDiscount.Poliza = emisionResp.Poliza;
                                    paramDiscount.ConceptoId = descuentoProntoPagoIDSysflex;
                                    paramDiscount.PorcDescuento = (porcProntoPago / 100);

                                    //soapClient.SetPolizaDescuento(paramDiscount);
                                    soapClient2.SetPolizaDescuento(paramDiscount);
                                    success = true;
                                }
                                catch (Exception ex)
                                {
                                    var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Pronto Pago.";
                                    lastMessage = ex.Message;
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                    {
                                        msg += lastMessage;
                                    }
                                    statusMessages.Add(msg);
                                    success = false;
                                }
                            }
                        }
                    }

                    if (emisionResp == null)
                    {
                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetQuotationEmition.";
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                        status &= false;
                    }
                }
                #endregion
            }

            return status;
        }

        public PolicyVehicleVehicleIdentification[] CheckChassisPlate(string chassis, string plate)
        {
            PolicyVehicleVehicleIdentification[] scp = soapClient2.CheckChassisOrRegistry(chassis, plate);
            return scp;
        }

        private string sysflexIdentificationTypeMatch(string IdentificationTypePV)
        {
            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros

            if (!string.IsNullOrEmpty(IdentificationTypePV))
            {
                if (IdentificationTypePV.ToLower() == "Cédula".ToLower() || IdentificationTypePV.ToLower() == "Licencia".ToLower())
                {
                    return "1";
                }
                else if (IdentificationTypePV.ToLower() == "RNC".ToLower())
                {
                    return "0";
                }
            }
            return "2";
        }

        private byte sysflexSexMatch(string SexPV)
        {
            // In sysflex:
            //  0 = Masculino
            //  1 = Femenino
            //  2 = Empresa            

            if (!string.IsNullOrEmpty(SexPV))
            {
                if (SexPV.ToLower() == "Masculino".ToLower())
                {
                    return 0;
                }
                else if (SexPV.ToLower() == "Femenino".ToLower())
                {
                    return 1;
                }
                else if (SexPV.ToLower() == "Empresa".ToLower())
                {
                    return 2;
                }
            }

            return 0;
        }

        public PolicyMaximoReaseguroSubramo getMaximoReaseguroSubRamo(int codRamo, int subRamo)
        {
            return soapClient2.GetMaximoReaseguro(codRamo, subRamo);
        }


        #region Metodos de Sysflex Nuevo

        public bool SetAutoQuotation_New(QuotationAuto quotation,
         int codMoneda,
         int tasaMoneda,
         int codIntermediario,
         int codOficina,
         int codRamo,
         int retryAmount,
         string username,
         int companySysflex,
         decimal porcDescuentoFlotilla,
         int descuentoFlotillaIDSysflex,
         decimal porcProntoPago,
         int descuentoProntoPagoIDSysflex,
         string Sistema,
         string errorPrimaZero,
         int ubicationID,
         string genderParam,
         string ageParam,
         string useNCFNew,

         bool IsShowPolicy,
         string AllowDescuentoProntoPago,
         string AllowDescuentoFlotilla,

         out string poliza,
         out decimal quotationCoreIdNumber,
         out decimal clientId,
         out List<string> statusMessages,
         out string SourceID,
         out List<STL.POS.Data.CSEntities.ListVehicleSourceID> listVehicleSourceID,
         out bool errorGP)
        {
            if (string.IsNullOrEmpty(username) || username == "POS-")
            {
                username = "POS-Venta Directa";
            }

            COD_COMPANIA = companySysflex;
            poliza = string.Empty;
            quotationCoreIdNumber = 0;
            clientId = 0;
            statusMessages = new List<string>();
            var status = true;
            var lastMessage = string.Empty;
            var success = false;
            SourceID = string.Empty;
            listVehicleSourceID = new List<STL.POS.Data.CSEntities.ListVehicleSourceID>();
            errorGP = false;

            if (quotation.TotalPrime.Value <= 0)
            {
                throw new Exception(errorPrimaZero);
            }

            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = quotation.Drivers.Where(d => d.IsPrincipal).FirstOrDefault();

            client.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = COD_COMPANIA;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;

            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            client.FechaNacimiento = dob;

            client.Intermediario = codIntermediario;
            client.Nacionalidad = principal.Nationality.Global_Country_Desc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = username;

            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            client.Cedula = principal.IdentificationNumber;

            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";

            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;

            client.Sexo = sysflexSexMatch(principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;
            client.Ubicacion = ubicationID;

            var retryCount = 0;

            PolicyQuotationHeader clientResp = null;

            while (!success && retryCount < retryAmount)
            {
                try
                {
                    clientResp = soapClient2.SetQuotationHeaderVehicle(client);

                    if (clientResp.Prima.HasValue && clientResp.Prima.Value <= 0)
                    {
                        success = false;
                        throw new Exception(errorPrimaZero);
                    }

                    poliza = clientResp.Poliza;
                    quotationCoreIdNumber = clientResp.Cotizacion;
                    clientId = clientResp.Cliente.GetValueOrDefault(0);
                    success = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "El cliente " + principal.FirstName + " " + principal.FirstSurname + " no ha podido ser creado en Sysflex. Falla en el método SetQuotationHeaderVehicle. Detalle: " + ex.Message;
                    success = false;
                }
                retryCount++;
            }
            #endregion

            if (!success)
            {
                statusMessages.Add(lastMessage);
                status = false;
            }
            else
            {
                #region Vehiculos/SetQuotationDetailVehicle

                var cantItems = quotation.VehicleProducts.Count;
                int i = 1;
                int count = 1;
                int vehicleIndex = 1;
                int lastVehicleID = 0;

                foreach (var vProd in quotation.VehicleProducts)
                {
                    count = 1;

                    /*Repetir el bloque de codigo todas las veces que indique el campo VehicleQuantity*/
                    while (count <= vProd.VehicleQuantity)
                    {
                        /*Preguntar si el chasis existe, esto es por si mandan mas de una vez la misma cotizacion*/
                        var ccp = this.CheckChassisPlate(vProd.Chassis, vProd.Plate);

                        if (ccp.Count() > 0)
                        {
                            success = false;
                            status = false;

                            string policyOfDuplicate = string.Join(", ", ccp.Select(a => a.Policy));
                            string policyOfDuplicateEncriptep = STL.POS.Data.CSEntities.EncrityDecript.Encrypt_Query(policyOfDuplicate);

                            string mid = "Mensaje ID:";
                            if (IsShowPolicy)
                            {
                                policyOfDuplicateEncriptep = policyOfDuplicate;
                                mid = "Poliza(s):";
                            }

                            //lastMessage = string.Format("El chasis \"{0}\" o placa \"{1}\" ya estan registrados en nuestros sistemas.<br/> {3} {2}", vProd.Chassis, vProd.Plate, policyOfDuplicateEncriptep, mid);
                            //success = false;
                            //statusMessages.Add(lastMessage);
                            //status = false;

                            //return status;

                            throw new Exception(
                                string.Format("El chasis \"{0}\" o placa \"{1}\" ya estan registrados en nuestros sistemas.<br/> {3} {2}", vProd.Chassis, vProd.Plate, policyOfDuplicateEncriptep, mid)
                                //string.Format("El chasis: \"{0}\" o placa: \"{1}\" ya estan registrados en nuestros sistemas.<br/> Message ID: {2}", vProd.Chassis, vProd.Plate, policyOfDuplicateEncriptep)
                                );
                        }

                        var cDetail = new PolicyQuotationSysFlexCotDetKey();
                        if (count > 1)
                        {
                            i++;
                        }
                        else
                        {
                            i = vProd.SecuenciaVehicleSysflex.HasValue ? vProd.SecuenciaVehicleSysflex.Value : 1;
                        }


                        PolicySysFlexGetPrimaCoberturaKey parm = new PolicySysFlexGetPrimaCoberturaKey();
                        parm.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                        parm.Secuencia = i;
                        var primacobertura = GetPrimaCobertura(parm);

                        cDetail.cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                        cDetail.secuencia = i;
                        cDetail.anoVehiculo = vProd.Year.Value.ToString();
                        //cDetail.Cilindro = "";                    
                        cDetail.compania = COD_COMPANIA;
                        cDetail.estacionaEn = vProd.StoreName;

                        /*Actualziacion de fecha de vencimiento en base a 6 meses*/
                        if (vProd.SelectedCoverageName.Contains("(6 Meses)")
                            || vProd.SelectedCoverageName.Contains("( 6 Meses )")
                            || vProd.SelectedCoverageName.Contains("( 6 Meses)")
                            || vProd.SelectedCoverageName.Contains("(6 Meses )")
                            )
                        {
                            var dateStart = quotation.StartDate.Value;
                            DateTime newEndDate = dateStart.AddMonths(6);

                            cDetail.fechaFin = newEndDate;
                            cDetail.fechaInicio = quotation.StartDate.Value;
                        }
                        else
                        {
                            cDetail.fechaFin = quotation.EndDate.Value;
                            cDetail.fechaInicio = quotation.StartDate.Value;
                        }

                        cDetail.marcaVehiculo = vProd.VehicleMakeName;
                        cDetail.modeloVehiculo = vProd.VehicleModel.Model_Desc;
                        cDetail.placa = vProd.Plate;
                        cDetail.chasis = vProd.Chassis;
                        cDetail.color = vProd.Color;
                        cDetail.ramo = codRamo;
                        cDetail.subRamo = vProd.SelectedCoverageCoreId.GetValueOrDefault();
                        cDetail.primaBruta = vProd.TotalPrime.Value;
                        cDetail.montoImpuesto = vProd.TotalIsc.GetValueOrDefault();
                        cDetail.montoDescuento = 0;
                        cDetail.neto = cDetail.primaBruta + cDetail.montoImpuesto;
                        cDetail.montoRecargo = 0;
                        cDetail.tasa = vProd.PercentageToInsure.Value;
                        cDetail.montoAsegurado = vProd.InsuredAmount.Value;
                        cDetail.porcDescuento = 0;
                        cDetail.porcImpuesto = quotation.ISCPercentage.GetValueOrDefault(0);
                        cDetail.porcRecargo = 0;
                        cDetail.tipoVehiculo = vProd.VehicleTypeName;
                        cDetail.uso = vProd.UsageName;
                        cDetail.noFormulario = vProd.NumeroFormulario;
                        cDetail.formadePago = "";
                        cDetail.renovacionAutomatica = "S";

                        var quantityOfMonth = STL.POS.Data.CSEntities.Helperes.QuantityOfMonth(cDetail.fechaInicio.Value, cDetail.fechaFin.Value);
                        cDetail.cantidadMeses = quantityOfMonth == 0 ? 1 : quantityOfMonth;// 12;//12;

                        cDetail.codigoTarifa = 1;
                        cDetail.usuario = username;

                        //Obteniendo los valores del ratejson que faltan para no tener que ir a sysflex a buscarlos
                        var rateJson = vProd.RateJson;

                        if (rateJson.Contains("PARAMETERS: "))
                        {
                            var spRateJson = rateJson.Split(new string[] { "PARAMETERS: ", " RESPONSE: " }, StringSplitOptions.RemoveEmptyEntries);
                            if (spRateJson.Count() > 0)
                            {
                                var res = spRateJson[1].Replace(@"\", "");

                                res = "[" + res.Replace(@"}"",""", "}") + "]";

                                var VehicleRateParameters = JsonConvert.DeserializeObject<List<STL.POS.Data.CSEntities.VehicleRateParameters>>(res);
                                if (VehicleRateParameters.Count() > 0 && VehicleRateParameters.FirstOrDefault() != null)
                                {
                                    var vrp = VehicleRateParameters.FirstOrDefault();

                                    cDetail.idTipoVehiculo = vrp.idTipoVehiculo.HasValue ? vrp.idTipoVehiculo.ToString() : "0";
                                    cDetail.idMarcaVehiculo = vrp.idMarcaVehiculo.HasValue ? vrp.idMarcaVehiculo.ToString() : "0";
                                    cDetail.idModeloVehiculo = vrp.idModeloVehiculo.HasValue ? vrp.idModeloVehiculo.ToString() : "0";
                                    cDetail.idAnoVehiculo = vrp.idAnoVehiculo.HasValue ? vrp.idAnoVehiculo.ToString() : "0";
                                    cDetail.idUso = vrp.idUso.HasValue ? vrp.idUso.ToString() : "0"; ;
                                    cDetail.idEstacionaEn = vrp.idEstacionaEn.HasValue ? vrp.idEstacionaEn.ToString() : "0";
                                    cDetail.idCapacidad = vrp.idCapacidad.HasValue ? vrp.idCapacidad.ToString() : "0";
                                    cDetail.capacidad = vrp.capacidad;
                                    cDetail.iddeducible = vrp.iddeducible.HasValue ? vrp.iddeducible.ToString() : "0";
                                    cDetail.deducible = vrp.deducible;
                                    cDetail.porciendoCobertura = vrp.porciendoCobertura.HasValue ? vrp.porciendoCobertura.Value.ToString() : "100";
                                    cDetail.idColor = "";
                                    cDetail.idVersion = "";
                                    cDetail.version = "";
                                    cDetail.categoria = "";
                                }
                            }
                        }
                        /**/

                        cDetail.estatus = "ACTIVO";


                        var gender = principal.Sex;

                        bool foreingLicence = false;
                        var principalLicence = (principal.ForeignLicense.HasValue ? principal.ForeignLicense : false);
                        if (principalLicence == true && gender != "Empresa" && vProd.SelectedCoverageName.ToLower().IndexOf("semi") <= -1)
                        {
                            foreingLicence = true;
                        }
                        cDetail.licenciaExtranjera = foreingLicence;

                        var genderId = 1;

                        if (gender == "Femenino")
                        {
                            genderId = 2;
                        }

                        DateTime birthday = DateTime.Now;
                        int age = 0;

                        if (gender == "Empresa")
                        {
                            int genderCompany = 0;
                            int.TryParse(genderParam, out genderCompany);

                            if (genderCompany > 0)
                            {
                                genderId = genderCompany;

                                gender = "N/A";
                            }

                            int ageCompany = 0;
                            int.TryParse(ageParam, out ageCompany);

                            if (ageCompany > 0)
                            {
                                age = 0;
                            }
                        }
                        else
                        {
                            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-DO");
                            birthday = DateTime.Parse(principal.DateOfBirth.ToString("dd/MM/yyyy"), culture);
                            age = GetAge(birthday);
                        }

                        STL.POS.WsProxy.SysflexService.PolicySexoEdadKeyParameter paramSex = new WsProxy.SysflexService.PolicySexoEdadKeyParameter();
                        paramSex.Sexo = gender;
                        paramSex.Edad = age.ToString();
                        paramSex.RamoID = cDetail.ramo.HasValue ? cDetail.ramo.Value : 106;
                        paramSex.subramo = cDetail.subRamo.HasValue ? cDetail.subRamo.Value : 0;
                        var resultSexoEdad = GetSexoEdad(paramSex);
                        var sexage = !string.IsNullOrEmpty(resultSexoEdad) ? resultSexoEdad : null;

                        cDetail.sexoEdad = sexage;
                        cDetail.PorcientoRecargoVentas = vProd.SurChargePercentage;

                        retryCount = 0;
                        success = false;
                        lastMessage = string.Empty;
                        string sourceID = ""; ;
                        while (!success && retryCount < retryAmount)
                        {
                            try
                            {
                                var res = soapClient2.SetQuotationDetailVehicle(cDetail);
                                sourceID = res.Insured_Vehicle_Id_Source_ID;
                                listVehicleSourceID.Add(new STL.POS.Data.CSEntities.ListVehicleSourceID()
                                {
                                    Index = vehicleIndex,
                                    SourceID = sourceID,
                                    VehicleID = (lastVehicleID != vProd.Id) ? vProd.Id : 0
                                });

                                success = true;
                            }
                            catch (Exception ex)
                            {
                                lastMessage = "Falla en el webservice SetQuotationDetailVehicle. Detalle: " + ex.Message;
                                success = false;
                            }
                            retryCount++;
                        }

                        if (!success)
                        {
                            var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                                msg += lastMessage;
                            statusMessages.Add(msg);
                            status &= false;
                        }

                        var limit = vProd.ProductLimits.Where(l => l.IsSelected).FirstOrDefault();

                        foreach (var cov in limit.SelfDamagesCoverages.Concat(limit.ThirdPartyCoverages))
                        {
                            var cotCobertura = new PolicyQuotationCoverageKey();
                            cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                            cotCobertura.Compania = COD_COMPANIA;
                            cotCobertura.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                            cotCobertura.Items = i;
                            cotCobertura.Limite = cov.Limit.ToString();

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }
                            }


                            retryCount = 0;
                            success = false;
                            lastMessage = string.Empty;
                            //bool ccResp = false;
                            int ccResp = 0;
                            bool SetQuotationCoverageFail = false;
                            while (!success && retryCount < retryAmount)
                            {
                                try
                                {
                                    ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                                    success = true;
                                    SetQuotationCoverageFail = true;
                                }
                                catch (Exception ex)
                                {
                                    lastMessage = "Falla en el webservice SetQuotationCoverageVehicle. Detalle: " + ex.Message;
                                    success = false;
                                    SetQuotationCoverageFail = false;
                                }
                                retryCount++;
                            }


                            if (!success && !SetQuotationCoverageFail)
                            {
                                var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                    msg += lastMessage;
                                statusMessages.Add(msg);
                                status &= false;
                            }
                        }

                        foreach (var vServ in limit.ServicesCoverages)
                        {
                            foreach (var cov in vServ.Coverages.Where(s => s.IsSelected))
                            {
                                var cotCobertura = new PolicyQuotationCoverageKey();
                                cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                                cotCobertura.Compania = COD_COMPANIA;
                                cotCobertura.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                                cotCobertura.Items = i;
                                cotCobertura.Limite = cov.Limit.ToString();

                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }

                                retryCount = 0;
                                success = false;
                                lastMessage = string.Empty;
                                int ccResp = 0;
                                bool SetQuotationCoverageFail = false;
                                while (!success && retryCount < retryAmount)
                                {
                                    try
                                    {
                                        ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                                        success = true;
                                        SetQuotationCoverageFail = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        lastMessage = "Falla en el webservice SetQuotationCoverageVehicle. Detalle: " + ex.Message;
                                        success = false;
                                        SetQuotationCoverageFail = false;
                                    }
                                    retryCount++;
                                }

                                if (!success && !SetQuotationCoverageFail)
                                {
                                    var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.VehicleModel.Model_Desc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                        msg += lastMessage;
                                    statusMessages.Add(msg);
                                    status &= false;
                                }
                            }
                        }

                        SetReinsurance(COD_COMPANIA, i, Convert.ToDecimal(quotation.QuotationCoreNumber));

                        if (!vProd.SecuenciaVehicleSysflex.HasValue)
                        {
                            i++;
                        }

                        count++;
                        vehicleIndex++;
                        lastVehicleID = vProd.Id;
                    }
                }
                #endregion

                #region Emision
                if (!quotation.SendInspectionOnly)
                {
                    PolicyQuotationILQuotationPassTransit emisionResp = null;

                    retryCount = 0;
                    success = false;
                    lastMessage = string.Empty;

                    while (!success && retryCount < retryAmount)
                    {
                        try
                        {
                            emisionResp = soapClient2.SetPasstransitVehicle(COD_COMPANIA, Convert.ToDecimal(quotation.QuotationCoreNumber), username, "", codOficina, 1);

                            if (string.IsNullOrEmpty(emisionResp.Poliza))
                            {
                                lastMessage = "Error en el metodo: SetPasstransitVehicle, Al parecer no se genero el numero de Poliza en sysflex para la cotizacion: " + quotation.QuotationNumber;
                                success = false;
                                statusMessages.Add(lastMessage);
                            }
                            else
                            {
                                poliza = emisionResp.Poliza;
                                SourceID = emisionResp.SourceId;
                                success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            lastMessage = ex.Message;
                            success = false;
                        }
                        retryCount++;
                    }

                    if (emisionResp != null && success)
                    {
                        try
                        {
                            //GENERANDO PAGO EN GP
                            if (useNCFNew == "N")//Proceso Viejo
                            {
                                var emisionFactura = soapClient2.SetMotionBillingVehicle(COD_COMPANIA, Convert.ToDecimal(quotation.QuotationCoreNumber), 1, username, 1, "", 1);
                                if (emisionFactura.ErrorMessage != "N/A")//ERROR
                                {
                                    success = false;
                                    errorGP = true;
                                    statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: SetMotionBillingVehicle. ERROR: " + emisionFactura.ErrorMessage);
                                }
                                else if (emisionFactura.ErrorMessage == "N/A")
                                {
                                    success = true;
                                }
                            }
                            else if (useNCFNew == "S")//Proceso Nuevo
                            {
                                decimal totalWithTaxes = quotation.TotalPrime.Value + quotation.TotalISC.Value;
                                decimal Taxes = quotation.TotalISC.Value;
                                NCFInvoiceResult emisionInvoiceNumber = soapClient2.GetNCFandInvoiceNumber(poliza, DateTime.Now, totalWithTaxes, Taxes);

                                if (emisionInvoiceNumber == null || !string.IsNullOrEmpty(emisionInvoiceNumber.Error))
                                {
                                    success = false;
                                    errorGP = true;
                                    statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: GetNCFandInvoiceNumber. ERROR: " + emisionInvoiceNumber.Error);
                                }
                                else if (emisionInvoiceNumber.Successful)
                                {
                                    var ResultFactSinGp = soapClient2.FacturacionMovimientoSinGP(COD_COMPANIA, Convert.ToDecimal(quotation.QuotationCoreNumber), 1, username, 1, "", 1,
                                                                                                 emisionInvoiceNumber.NCFNumber, emisionInvoiceNumber.InvoiceNumber, emisionInvoiceNumber.Error, false);
                                    success = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método FacturacionMovimientoSinGP.";
                            lastMessage = ex.Message;
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                            {
                                msg += lastMessage;
                            }
                            statusMessages.Add(msg);
                            success = false;
                            errorGP = true;
                        }

                        if (success)//Si Emision, Facturacion Salen Bien
                        {
                            try
                            {
                                /*Acuerdo de Pago*/
                                PolicyPaymentAgreementKey paramAcuerdoDePago = new PolicyPaymentAgreementKey();

                                paramAcuerdoDePago.compania = COD_COMPANIA;
                                paramAcuerdoDePago.cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                                paramAcuerdoDePago.sistema = Sistema;
                                paramAcuerdoDePago.usuario = username;

                                if (quotation.PaymentFrequencyId.HasValue)
                                {
                                    paramAcuerdoDePago.cantidadCuotas = quotation.PaymentFrequencyId.GetValueOrDefault();//la frecuencia de pago
                                    paramAcuerdoDePago.inicial = Convert.ToInt32(quotation.AmountToPayEnteredByUser);  //monto que escribrieron
                                }
                                else
                                {
                                    paramAcuerdoDePago.cantidadCuotas = 0;
                                    paramAcuerdoDePago.inicial = 0;
                                }

                                var x = soapClient2.SetPaymentAgreement(paramAcuerdoDePago);
                                success = true;
                                /**/
                            }
                            catch (Exception ex)
                            {
                                var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPaymentAgreement.";
                                lastMessage = ex.Message;
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                {
                                    msg += lastMessage;
                                }
                                statusMessages.Add(msg);
                                success = false;
                            }


                            if (quotation.Messaging && quotation.PaymentWay.HasValue && (int)quotation.PaymentWay.Value == 1 && quotation.User != null && quotation.User.AgentId.HasValue && success)//Efectivo
                            {
                                try
                                {
                                    /*Mensajeria*/
                                    PolicySysFlexMensajeriaKey param = new PolicySysFlexMensajeriaKey();
                                    param.Compania = COD_COMPANIA;
                                    param.Cotizacion = clientResp.Cotizacion;
                                    param.Usuario = username;
                                    var mens = soapClient2.SetMensajeria(param);
                                    success = true;
                                    /**/
                                }
                                catch (Exception ex)
                                {
                                    var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetMensajeria.";
                                    lastMessage = ex.Message;
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                    {
                                        msg += lastMessage;
                                    }
                                    statusMessages.Add(msg);
                                    success = false;
                                }
                            }

                            if (porcDescuentoFlotilla > 0)
                            {
                                if (AllowDescuentoFlotilla == "S")
                                {
                                    try
                                    {
                                        /*Si hay descuento de flotilla procesar el de flotilla primero*/

                                        /*Descuentos a Polizas Flotilla*/
                                        PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                        paramDiscount.Compania = COD_COMPANIA;
                                        paramDiscount.Sistema = Sistema;
                                        paramDiscount.Usuario = username;

                                        paramDiscount.Poliza = emisionResp.Poliza;
                                        paramDiscount.ConceptoId = descuentoFlotillaIDSysflex;
                                        paramDiscount.PorcDescuento = (porcDescuentoFlotilla / 100);

                                        soapClient2.SetPolizaDescuento(paramDiscount);
                                        success = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Flotilla.";
                                        lastMessage = ex.Message;
                                        if (!string.IsNullOrWhiteSpace(lastMessage))
                                        {
                                            msg += lastMessage;
                                        }
                                        statusMessages.Add(msg);
                                        success = false;
                                    }
                                }
                            }

                            if (porcProntoPago > 0)
                            {
                                if (AllowDescuentoProntoPago == "S")
                                {
                                    try
                                    {
                                        /*Descuentos a Polizas Protno Pago*/
                                        PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                        paramDiscount.Compania = COD_COMPANIA;
                                        paramDiscount.Sistema = Sistema;
                                        paramDiscount.Usuario = username;

                                        paramDiscount.Poliza = emisionResp.Poliza;
                                        paramDiscount.ConceptoId = descuentoProntoPagoIDSysflex;
                                        paramDiscount.PorcDescuento = (porcProntoPago / 100);

                                        soapClient2.SetPolizaDescuento(paramDiscount);
                                        success = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Pronto Pago.";
                                        lastMessage = ex.Message;
                                        if (!string.IsNullOrWhiteSpace(lastMessage))
                                        {
                                            msg += lastMessage;
                                        }
                                        statusMessages.Add(msg);
                                        success = false;
                                    }
                                }
                            }
                        }
                    }

                    if (emisionResp == null)
                    {
                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPasstransitVehicle.";
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                        status &= false;
                    }
                }
                #endregion
            }
            return status;
        }

        public string SetAutoQuotationHeaderForGetCoreQuotationNumber(QuotationAuto quotation,
           int codMoneda,
           int tasaMoneda,
           int codIntermediario,
           int codOficina,
           int codRamo,
           int retryAmount,
           string username,
           int companySysflex,
           decimal porcDescuentoFlotilla,
           int descuentoFlotillaIDSysflex,
           decimal porcProntoPago,
           int descuentoProntoPagoIDSysflex,
           string Sistema,
            out string messageError)
        {
            messageError = "";

            if (string.IsNullOrEmpty(username) || username == "POS-")
            {
                username = "POS-Venta Directa";
            }

            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = quotation.Drivers.Where(d => d.IsPrincipal).FirstOrDefault();

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = COD_COMPANIA;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;

            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            client.FechaNacimiento = dob;

            client.Intermediario = codIntermediario;
            client.Nacionalidad = principal.Nationality.Global_Country_Desc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = username;

            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            if (principal.IdentificationType != null)
            {
                client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            }
            else
            {
                client.TipoCedula = "";
            }
            client.Cedula = principal.IdentificationNumber;

            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";

            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;
            client.Sexo = sysflexSexMatch(principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;//Numero Cotizacion PV

            PolicyQuotationHeader clientResp = null;

            try
            {
                clientResp = soapClient2.SetQuotationHeaderVehicle(client);
                if (clientResp != null)
                {
                    return clientResp.Cotizacion.ToString();
                }
            }
            catch (Exception ex)
            {
                messageError = "En la Cotizacion " + quotation.QuotationNumber + " El cliente " + principal.FirstName + " " + principal.FirstSurname + " no ha podido ser creado en Sysflex. Falla en el método SetAutoQuotationHeaderForGetCoreQuotationNumber. Detalle: " + ex.Message;
            }


            #endregion

            return "0";
        }


        public string SetAgentInQuotationHeader(QuotationAuto quotation, int codIntermediario, string user, int company, int codMoneda, int codRamo, int tasaMoneda, int codOficina,
            DateTime? principalDateOfBirth, out List<string> messageError, string Sexo = null)
        {
            messageError = new List<string>();

            if (string.IsNullOrEmpty(user) || user == "POS-")
            {
                user = "POS-Venta Directa";
            }


            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = quotation.Drivers.Where(d => d.IsPrincipal).FirstOrDefault();

            client.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
            client.Intermediario = codIntermediario;

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = company;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;
            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            else if (principalDateOfBirth.HasValue)
            {
                dob = principalDateOfBirth.Value;
            }
            client.FechaNacimiento = dob;
            client.Nacionalidad = principal.Nationality.Global_Country_Desc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = user;
            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            if (principal.IdentificationType != null)
            {
                client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            }
            else
            {
                client.TipoCedula = "";
            }
            client.Cedula = principal.IdentificationNumber;
            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";
            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;
            client.Sexo = sysflexSexMatch(!string.IsNullOrEmpty(Sexo) ? Sexo : principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;//Numero Cotizacion PV

            PolicyQuotationHeader clientResp = null;

            try
            {
                clientResp = soapClient2.SetQuotationHeaderVehicle(client);
            }
            catch (Exception ex)
            {
                messageError.Add("En la Cotizacion " + quotation.QuotationNumber + " no se ha podido modificar el cliente en Sysflex. Falla en el método SetAgentInQuotationHeader. Detalle: " + ex.Message);
            }

            #endregion

            return "0";
        }


        public List<PolicySysflexMarcaVehiculo> GetVehicleMakes()
        {
            var prods = soapClient2.GetMarcaVehiculo();
            var vehicleTypes = (from p in prods
                                orderby p.Descripcion
                                select p).ToList();
            return vehicleTypes;
        }

        public List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetComboCondicion_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> result = null;
            result = soapClient2.GetComboConditionsByParameters(type, ramo, subramo, nombreArch, descrip, ano, id).ToList();
            return result;
        }

        public List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetComboTipoVehiculo_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> result = null;
            result = soapClient2.GetComboConditionsByParameters(type, ramo, subramo, nombreArch, descrip, ano, id).ToList();
            return result;
        }

        public List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetAnioVehiculo_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> result = null;
            result = soapClient2.GetComboConditionsByParameters(type, ramo, subramo, nombreArch, descrip, ano, id).ToList();
            return result;
        }

        public List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> GetDeductible_New(string type, int? ramo, int? subramo, string nombreArch, string descrip, int? ano, int? id)
        {
            List<STL.POS.WsProxy.SysflexService.PolicySysflexComboCondicion> result = null;
            result = soapClient2.GetComboConditionsByParameters(type, ramo, subramo, nombreArch, descrip, ano, id).ToList();
            return result;
        }

        public Dictionary<string, object> GetRates_New(PolicyQuotationSysFlexCotDetKey cDetail, out List<string> statusMessages)
        {
            statusMessages = new List<string>();
            string jsonParameters = "";
            try
            {
                PolicyQuotationSysFlexCotDet cDetailResp = null;

                jsonParameters = "PARAMETERS: " + JsonConvert.SerializeObject(cDetail);
                cDetailResp = soapClient2.SetQuotationDetailVehicle(cDetail);

                var AllToJson = JsonConvert.SerializeObject(new object[] { jsonParameters, " RESPONSE: " + JsonConvert.SerializeObject(cDetailResp) });

                //var AllToJson = JsonConvert.SerializeObject(new object[] { "PARAMETERS: " + JsonConvert.SerializeObject(cDetail), " RESPONSE: " + JsonConvert.SerializeObject(cDetailResp) });

                var output = new Dictionary<string, object>();
                output.Add("TpPrime", cDetailResp.PrimaTerceros);
                output.Add("SdPrime", cDetailResp.PrimaDanosPropio + ((cDetailResp.MontoRecargo.HasValue ? cDetailResp.MontoRecargo.Value : 0) - (cDetailResp.MontoDescuento.HasValue ? cDetailResp.MontoDescuento.Value : 0)));
                output.Add("ServicesPrime", cDetailResp.PrimaServicio);
                output.Add("TotalIsc", cDetailResp.MontoImpuesto);
                output.Add("VehicleTypeId", cDetail.idTipoVehiculo);
                output.Add("jsonRates", AllToJson);
                output.Add("PrimaDanosPropio", cDetailResp.PrimaDanosPropio);
                output.Add("PorcImpuesto", cDetailResp.PorcImpuesto);
                output.Add("primaproratadiasinimpuestos", cDetailResp.primaproratadiasinimpuestos);
                output.Add("DiasCotizados", cDetailResp.DiasCotizados);
                return output;
            }
            catch (Exception ex)
            {
                statusMessages.Add("ERROR en GetRates_New " + ex.Message + " EX COMPLETA: " + ex);

                var AllToJson = JsonConvert.SerializeObject(new object[] { jsonParameters });

                var output = new Dictionary<string, object>();
                output.Add("TpPrime", 0);
                output.Add("SdPrime", (0));
                output.Add("ServicesPrime", 0);
                output.Add("TotalIsc", 0);
                output.Add("VehicleTypeId", 0);
                output.Add("jsonRates", AllToJson);
                output.Add("PrimaDanosPropio", 0);
                output.Add("PorcImpuesto", 0);
                output.Add("primaproratadiasinimpuestos", 0);
                output.Add("DiasCotizados", 0);
                return output;
            }
        }

        public IList<VehicleTypeWS> GetVehicleTypes_New(int vehicleTypeCoreId, int vehicleYear, string coreDeLeyStringDiscriminator, int codRamo)
        {
            var output = new List<VehicleTypeWS>();

            PolicyProductSysFlexProductNewkey param = new PolicyProductSysFlexProductNewkey();
            param.productoId = null;
            param.tipoVehiculo = vehicleTypeCoreId;
            param.ano = vehicleYear;
            param.ramoId = codRamo;

            var prods = soapClient2.GetProductVehicle(param);

            var vehicleTypes = (from p in prods
                                orderby p.Descripcion //p.ProductName
                                select p.Descripcion.Trim() /*p.ProductName*/).Distinct().ToList();

            foreach (var vtId in vehicleTypes.OrderBy(t => t))
            {
                var vehicleType = new VehicleTypeWS();
                vehicleType.Name = vtId;

                /*----------------------------------------------*/
                vehicleType.NewUsages = new List<STL.POS.Data.POSEntities.WSEntities.UsageByProductWS>();

                var Usages = (from pr in prods
                              where pr.Descripcion == vtId
                              //&& pr.TipoPoliza == p.TipoPoliza
                              select new { IdUso = pr.IdUso, DescUso = pr.DescUso }).Distinct().ToList();

                foreach (var u in Usages)
                {
                    var us = new STL.POS.Data.POSEntities.WSEntities.UsageByProductWS();
                    us.idUso = u.IdUso;
                    us.descUso = u.DescUso;
                    us.allowed = 1;
                    us.message = "";

                    vehicleType.NewUsages.Add(us);
                }
                /*----------------------------------------------*/

                /*Uso por Producto*/
                vehicleType.ProductByUsages = new List<STL.POS.Data.POSEntities.WSEntities.ProductByUsageWS>();

                var UsagesByProd = (from pr in prods
                                    where pr.Descripcion == vtId
                                    select new { UsoDescripcion = pr.DescUso, ProductoDescripcion = pr.DescTipoPoliza }).Distinct().ToList();

                foreach (var u in UsagesByProd)
                {
                    var us = new STL.POS.Data.POSEntities.WSEntities.ProductByUsageWS();
                    us.UsoDescripcion = u.UsoDescripcion;
                    us.ProductoDescripcion = u.ProductoDescripcion;

                    vehicleType.ProductByUsages.Add(us);
                }
                /**/

                /*Producto Cobertura por Uso */
                vehicleType.CoveragesByUsages = new System.Collections.Generic.List<CoveragesByUsageWS>();

                var CovsByUsages = (from pr in prods
                                    where pr.Descripcion == vtId
                                    //&& pr.TipoPoliza == p.TipoPoliza
                                    //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                    select new
                                    {
                                        Id = pr.SubRamo,
                                        Name = pr.SubRamoName,
                                        Type = pr.DescTipoPoliza,
                                        IsLaw = pr.RequiereInspeccion == false ? true : false,
                                        UsoDescripcion = pr.DescUso,
                                        ProductName = pr.DescTipoPoliza
                                    }).Distinct().ToList();

                foreach (var c in CovsByUsages)
                {
                    var cov = new CoveragesByUsageWS();
                    cov.Id = c.Id;
                    cov.Name = c.Name;
                    cov.IsLaw = c.IsLaw;
                    cov.UsoDescripcion = c.UsoDescripcion;
                    cov.ProductName = c.ProductName;

                    vehicleType.CoveragesByUsages.Add(cov);
                }
                /**/

                vehicleType.Products = new List<ProductWS>();

                var products = (from p in prods
                                where p.Descripcion == vtId
                                //select p.TipoPoliza /*p.ProductTypeID.Value*/).Distinct().ToList();                                
                                select new { p.TipoPoliza, p.IdCapacidad, p.DescCapacidad/*, p.IdUso, p.DescUso*/ }/*p.ProductTypeID.Value*/).Distinct().ToList();
                if (products.Count() <= 0) { continue; }

                foreach (var p in products)
                {
                    var prod = new ProductWS();
                    prod.Id = p.TipoPoliza;

                    //var prodname = prods.FirstOrDefault(pd => pd.ProductTypeID.HasValue && pd.ProductTypeID.Value == p);
                    var prodname = prods.FirstOrDefault(pd => pd.TipoPoliza == p.TipoPoliza);

                    if (prodname != null)
                    {
                        prod.Name = prodname.DescTipoPoliza;

                        //Nuevos
                        prod.IdCapacidad = p.IdCapacidad.HasValue ? p.IdCapacidad.Value : (int?)null;
                        prod.DescCapacidad = p.DescCapacidad;

                        //prod.IdUso = p.IdUso.HasValue ? p.IdUso.Value : (int?)null;
                        //prod.DescUso = p.DescUso;
                        //
                    }
                    else
                    {
                        continue;
                    }

                    prod.Coverages = new List<CoverageWS>();

                    var cobs = (from pr in prods
                                where pr.Descripcion == vtId
                                && pr.TipoPoliza == p.TipoPoliza
                                //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                select new { Id = pr.SubRamo, Name = pr.SubRamoName, Type = pr.DescTipoPoliza, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();

                    /*
                     NOTA:
                     Si un producto requiere inspección, eso significa que no es de Ley, si no la requiere es un producto de ley.                     
                     pr.RequiereInspeccion == false ? true : false
                     */

                    foreach (var c in cobs)
                    {
                        var cov = new CoverageWS();
                        cov.Id = c.Id;
                        cov.Name = c.Name;
                        cov.IsLaw = c.IsLaw;

                        prod.Coverages.Add(cov);
                    }

                    prod.Coverages = prod.Coverages.OrderBy(c => c.Name).ToList();

                    vehicleType.Products.Add(prod);
                }

                vehicleType.Products = vehicleType.Products.OrderBy(p => p.Name).ToList();

                vehicleType.NewUsages = vehicleType.NewUsages.OrderBy(c => c.descUso).ToList();

                vehicleType.ProductByUsages = vehicleType.ProductByUsages.OrderBy(c => c.ProductoDescripcion).ToList();

                output.Add(vehicleType);
            }

            return output;
        }

        public IList<DeductibleValues> GetDeductibles_New(int coverageCoreId, Parameter seqId, int modelo, int codRamo)
        {
            var param = new PolicyRefillsKey();
            param.coveregeID = coverageCoreId;
            param.CondicionId = Convert.ToInt32(seqId.Value);
            param.modelo = modelo;
            param.RamoId = codRamo;

            var surcharges = soapClient2.GetRefillsVechile(param);

            var output = from s in surcharges
                         orderby s.Descripcion
                         select new DeductibleValues() { CoreId = s.Secuencia, Name = s.Descripcion };

            return output.ToList();
        }

        public void SetCoverageVehicle_GetRate_New(List<STL.POS.Data.POSEntities.CoverageJsonClass> selfAndThirdCoverage,
            List<STL.POS.Data.POSEntities.CoverageJsonClass> ServiceCoverage, decimal Cotizacion, int secuencia, int COD_COMPANIA, out List<string> statusMessages)
        {

            bool success = false;
            string lastMessage = string.Empty;
            statusMessages = new List<string>();

            PolicySysFlexGetPrimaCoberturaKey parm = new PolicySysFlexGetPrimaCoberturaKey();
            parm.Cotizacion = Cotizacion;
            parm.Secuencia = secuencia;
            var primacobertura = GetPrimaCobertura(parm);

            //Borrando Coberturas
            DeleteCoveragesForVehicle(COD_COMPANIA, Cotizacion, secuencia);

            foreach (var cov in selfAndThirdCoverage)
            {
                var cotCobertura = new PolicyQuotationCoverageKey();
                cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                cotCobertura.Compania = COD_COMPANIA;
                cotCobertura.Cotizacion = Cotizacion;
                cotCobertura.Items = secuencia;//i;
                cotCobertura.Limite = cov.Limit.ToString();

                if (primacobertura.Count() > 0)
                {
                    var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                    if (realCObert != null)
                    {
                        cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                        cotCobertura.tasa = realCObert.Porciento;
                        cotCobertura.prima = realCObert.Prima;
                        cotCobertura.deducible = realCObert.Deducible;
                        cotCobertura.minDeducible = realCObert.MinimoDeducible;
                    }
                }

                int ccResp = 0;
                bool SetQuotationCoverageFail = false;

                try
                {
                    ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                    success = true;
                    SetQuotationCoverageFail = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New. Detalle: " + ex.Message;
                    success = false;
                    SetQuotationCoverageFail = false;
                }

                if (!success && !SetQuotationCoverageFail)
                {
                    var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser creado en Sysflex la cobertura en el metodo SetCoverageVehicle_GetRate_New para la cotización Nro: " + Cotizacion.ToString();
                    if (!string.IsNullOrWhiteSpace(lastMessage))
                        msg += lastMessage;
                    statusMessages.Add(msg);

                    return;
                }
            }

            //borrando todas las coberturas de servicios en sysflex para volver a agregarlas
            foreach (var vServ in ServiceCoverage)
            {
                bool successDelete = false;
                try
                {
                    soapClient2.DeleteCoverageVehicle(COD_COMPANIA, Cotizacion, secuencia, vServ.CoverageDetailCoreId);
                    successDelete = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New Al-->Borrar una Cobertura-->DeleteCoverageVehicle. Detalle: " + ex.Message;
                    successDelete = false;
                }

                if (!successDelete)
                {
                    var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser borrado en Sysflex la cobertura de servicios en el metodo DeleteCoverageVehicle para la cotización Nro: " + Cotizacion.ToString();
                    if (!string.IsNullOrWhiteSpace(lastMessage))
                        msg += lastMessage;
                    statusMessages.Add(msg);
                }
            }

            //agrego las cobeRturas seleccionadas
            foreach (var vServ in ServiceCoverage)
            {
                if (vServ.isSelected)
                {
                    var cotCobertura = new PolicyQuotationCoverageKey();
                    cotCobertura.CoberturaId = vServ.CoverageDetailCoreId;
                    cotCobertura.Compania = COD_COMPANIA;
                    cotCobertura.Cotizacion = Cotizacion;
                    cotCobertura.Items = secuencia;//i;
                    cotCobertura.Limite = vServ.Limit.ToString();

                    if (primacobertura.Count() > 0)
                    {
                        var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == vServ.CoverageDetailCoreId);
                        if (realCObert != null)
                        {
                            cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                            cotCobertura.tasa = realCObert.Porciento;
                            cotCobertura.prima = realCObert.Prima;
                            cotCobertura.deducible = realCObert.Deducible;
                            cotCobertura.minDeducible = realCObert.MinimoDeducible;
                        }
                    }


                    success = false;
                    lastMessage = string.Empty;
                    int ccResp = 0;
                    bool SetQuotationCoverageFail = false;

                    try
                    {
                        ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                        success = true;
                        SetQuotationCoverageFail = true;
                    }
                    catch (Exception ex)
                    {
                        lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New. Detalle: " + ex.Message;
                        success = false;
                        SetQuotationCoverageFail = false;
                    }

                    if (!success && !SetQuotationCoverageFail)
                    {
                        var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser creado en Sysflex la cobertura de servicios en el metodo SetCoverageVehicle_GetRate_New para la cotización Nro: " + Cotizacion.ToString();
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                    }
                }
            }
        }

        public void DeleteVehicleOnSysflex(int COD_COMPANIA, int vehicleSecuence, decimal quotationCoreNumber)
        {
            soapClient2.QuotationVehicleDelete(COD_COMPANIA, quotationCoreNumber, vehicleSecuence);
        }

        public PolicyItemReinsurance[] GetReinsuranceByItemVehicle(int COD_COMPANIA, decimal quotationCoreNumber, int vehicleSecuence)
        {
            /*Insertando el Reaseguro*/
            SetReinsurance(COD_COMPANIA, vehicleSecuence, quotationCoreNumber);
            /**/

            /*Luego*/

            /*Viendo si el Vehiculo Aplcia a Reaseguro*/
            PolicyItemReinsurance[] result = soapClient2.GetReinsuranceByItemVehicle(COD_COMPANIA, quotationCoreNumber, vehicleSecuence);
            return result;
            /**/
        }

        private void SetReinsurance(int COD_COMPANIA, int vehicleSecuence, decimal quotationCoreNumber)
        {
            soapClient2.SetQuotationReinsuranceVehicle(COD_COMPANIA, quotationCoreNumber, vehicleSecuence, 0);
            soapClient2.SetQuotationCoverageReinsuranceVehicle(COD_COMPANIA, quotationCoreNumber, vehicleSecuence, 0);
        }

        public PolicySysFlexGetPrimaCobertura[] GetPrimaCobertura(PolicySysFlexGetPrimaCoberturaKey parameter)
        {
            return soapClient2.GetPrimaCobertura(parameter);
        }

        public string GetSexoEdad(PolicySexoEdadKeyParameter param)
        {
            return soapClient2.GetSexoEdadProducto(param);
        }

        private static int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            return age;
        }


        public void DeleteCoveragesForVehicle(int COD_COMPANIA, decimal quotationCoreNumber, int vehicleSecuence)
        {
            soapClient2.SPCDeleteCotizacionCobertura(COD_COMPANIA, quotationCoreNumber, vehicleSecuence);
        }
        #endregion


        #region Nuevo Punto de Venta

        public Office[] GetofficeMatch_NewPV(int globalOfficeId)
        {
            var dataResult = soapClient2.GetMatchOffice(globalOfficeId);
            return
                dataResult;

        }

        public string SetAutoQuotationHeaderForGetCoreQuotationNumber_NewPV(Entity.Entities.Quotation quotation,
            Entity.Entities.Driver Drivers,
          int codMoneda,
          int tasaMoneda,
          int codIntermediario,
          int codOficina,
          int codRamo,
          int retryAmount,
          string username,
          int companySysflex,
          decimal porcDescuentoFlotilla,
          int descuentoFlotillaIDSysflex,
          decimal porcProntoPago,
          int descuentoProntoPagoIDSysflex,
          int? ubicationID,
          string Sistema,
           out string messageError)
        {
            messageError = "";

            if (string.IsNullOrEmpty(username) || username == "POS-")
            {
                username = "POS-Venta Directa";
            }

            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = Drivers;

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = COD_COMPANIA;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;

            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            client.FechaNacimiento = dob;

            client.Intermediario = codIntermediario;
            client.Nacionalidad = principal.NationalityGlobalCountryDesc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = username;

            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            if (principal.IdentificationType != null)
            {
                client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            }
            else
            {
                client.TipoCedula = "";
            }
            client.Cedula = principal.IdentificationNumber;

            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";

            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;
            client.Sexo = sysflexSexMatch(principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;//Numero Cotizacion PV

            client.Ubicacion = ubicationID;

            PolicyQuotationHeader clientResp = null;

            try
            {
                clientResp = soapClient2.SetQuotationHeaderVehicle(client);
                if (clientResp != null)
                {
                    return clientResp.Cotizacion.ToString();
                }
            }
            catch (Exception ex)
            {
                messageError = "En la Cotizacion " + quotation.QuotationNumber + " El cliente " + principal.FirstName + " " + principal.FirstSurname + " no ha podido ser creado en Sysflex. Falla en el método SetAutoQuotationHeaderForGetCoreQuotationNumber. Detalle: " + ex.Message;
            }


            #endregion

            return "0";
        }

        public PolicyProductSysFlexProductNew[] GetVehicleTypes_NewPV(int vehicleTypeCoreId, int vehicleYear, string coreDeLeyStringDiscriminator, int codRamo)
        {
            PolicyProductSysFlexProductNewkey param = new PolicyProductSysFlexProductNewkey();
            param.productoId = null;
            param.tipoVehiculo = vehicleTypeCoreId;
            param.ano = vehicleYear;
            param.ramoId = codRamo;

            var prods = soapClient2.GetProductVehicle(param);

            return prods;
        }

        public PolicyRefills[] GetDeductibles_NewPV(int coverageCoreId, int seqId, int modelo, int codRamo)
        {
            var param = new PolicyRefillsKey();
            param.coveregeID = coverageCoreId;
            param.CondicionId = Convert.ToInt32(seqId);
            param.modelo = modelo;
            param.RamoId = codRamo;

            var surcharges = soapClient2.GetRefillsVechile(param);

            return surcharges;
        }

        public string SetAgentInQuotationHeader_NewPV(Entity.Entities.Quotation quotation,
            Entity.Entities.Driver Drivers, int codIntermediario, string user, int company, int codMoneda, int codRamo, int tasaMoneda, int codOficina,
           DateTime? principalDateOfBirth, out List<string> messageError, string Sexo = null)
        {
            messageError = new List<string>();

            if (string.IsNullOrEmpty(user) || user == "POS-")
            {
                user = "POS-Venta Directa";
            }


            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = Drivers;

            client.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
            client.Intermediario = codIntermediario;

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = company;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;
            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            else if (principalDateOfBirth.HasValue)
            {
                dob = principalDateOfBirth.Value;
            }
            client.FechaNacimiento = dob;
            client.Nacionalidad = principal.NationalityGlobalCountryDesc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = user;
            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            if (principal.IdentificationType != null)
            {
                client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            }
            else
            {
                client.TipoCedula = "";
            }
            client.Cedula = principal.IdentificationNumber;
            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";
            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;
            client.Sexo = sysflexSexMatch(!string.IsNullOrEmpty(Sexo) ? Sexo : principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;//Numero Cotizacion PV

            PolicyQuotationHeader clientResp = null;

            try
            {
                clientResp = soapClient2.SetQuotationHeaderVehicle(client);
            }
            catch (Exception ex)
            {
                messageError.Add("En la Cotizacion " + quotation.QuotationNumber + " no se ha podido modificar el cliente en Sysflex. Falla en el método SetAgentInQuotationHeader. Detalle: " + ex.Message);
            }

            #endregion

            return "0";
        }

        public void SetCoverageVehicle_GetRate_NewPV(List<Entity.Entities.WSEntities.CoverageJsonClass> selfAndThirdCoverage,
           List<Entity.Entities.WSEntities.CoverageJsonClass> ServiceCoverage, decimal Cotizacion, int secuencia, int COD_COMPANIA, out List<string> statusMessages)
        {

            bool success = false;
            string lastMessage = string.Empty;
            statusMessages = new List<string>();

            PolicySysFlexGetPrimaCoberturaKey parm = new PolicySysFlexGetPrimaCoberturaKey();
            parm.Cotizacion = Cotizacion;
            parm.Secuencia = secuencia;
            var primacobertura = GetPrimaCobertura(parm);

            //Borrando Coberturas
            DeleteCoveragesForVehicle(COD_COMPANIA, Cotizacion, secuencia);

            foreach (var cov in selfAndThirdCoverage)
            {
                var cotCobertura = new PolicyQuotationCoverageKey();
                cotCobertura.CoberturaId = cov.CoverageDetailCoreId;
                cotCobertura.Compania = COD_COMPANIA;
                cotCobertura.Cotizacion = Cotizacion;
                cotCobertura.Items = secuencia;//i;
                cotCobertura.Limite = cov.Limit.ToString();

                if (primacobertura.Count() > 0)
                {
                    var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                    if (realCObert != null)
                    {
                        cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                        cotCobertura.tasa = realCObert.Porciento;
                        cotCobertura.prima = realCObert.Prima;
                        cotCobertura.deducible = realCObert.Deducible;
                        cotCobertura.minDeducible = realCObert.MinimoDeducible;
                    }
                }

                int ccResp = 0;
                bool SetQuotationCoverageFail = false;

                try
                {
                    ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                    success = true;
                    SetQuotationCoverageFail = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New. Detalle: " + ex.Message;
                    success = false;
                    SetQuotationCoverageFail = false;
                }

                if (!success && !SetQuotationCoverageFail)
                {
                    var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser creado en Sysflex la cobertura en el metodo SetCoverageVehicle_GetRate_New para la cotización Nro: " + Cotizacion.ToString();
                    if (!string.IsNullOrWhiteSpace(lastMessage))
                        msg += lastMessage;
                    statusMessages.Add(msg);

                    return;
                }
            }

            //borrando todas las coberturas de servicios en sysflex para volver a agregarlas
            foreach (var vServ in ServiceCoverage)
            {
                bool successDelete = false;
                try
                {
                    soapClient2.DeleteCoverageVehicle(COD_COMPANIA, Cotizacion, secuencia, vServ.CoverageDetailCoreId);
                    successDelete = true;
                }
                catch (Exception ex)
                {
                    lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New Al-->Borrar una Cobertura-->DeleteCoverageVehicle. Detalle: " + ex.Message;
                    successDelete = false;
                }

                if (!successDelete)
                {
                    var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser borrado en Sysflex la cobertura de servicios en el metodo DeleteCoverageVehicle para la cotización Nro: " + Cotizacion.ToString();
                    if (!string.IsNullOrWhiteSpace(lastMessage))
                        msg += lastMessage;
                    statusMessages.Add(msg);
                }
            }

            //agrego las cobeRturas seleccionadas
            foreach (var vServ in ServiceCoverage)
            {
                if (vServ.isSelected)
                {
                    var cotCobertura = new PolicyQuotationCoverageKey();
                    cotCobertura.CoberturaId = vServ.CoverageDetailCoreId;
                    cotCobertura.Compania = COD_COMPANIA;
                    cotCobertura.Cotizacion = Cotizacion;
                    cotCobertura.Items = secuencia;//i;
                    cotCobertura.Limite = vServ.Limit.ToString();

                    if (primacobertura.Count() > 0)
                    {
                        var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == vServ.CoverageDetailCoreId);
                        if (realCObert != null)
                        {
                            cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                            cotCobertura.tasa = realCObert.Porciento;
                            cotCobertura.prima = realCObert.Prima;
                            cotCobertura.deducible = realCObert.Deducible;
                            cotCobertura.minDeducible = realCObert.MinimoDeducible;
                        }
                    }


                    success = false;
                    lastMessage = string.Empty;
                    int ccResp = 0;
                    bool SetQuotationCoverageFail = false;

                    try
                    {
                        ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                        success = true;
                        SetQuotationCoverageFail = true;
                    }
                    catch (Exception ex)
                    {
                        lastMessage = "ERROR en SetCoverageVehicle_GetRate_New Falla en el webservice SetCoverageVehicle_GetRate_New. Detalle: " + ex.Message;
                        success = false;
                        SetQuotationCoverageFail = false;
                    }

                    if (!success && !SetQuotationCoverageFail)
                    {
                        var msg = "ERROR en SetCoverageVehicle_GetRate_New No ha podido ser creado en Sysflex la cobertura de servicios en el metodo SetCoverageVehicle_GetRate_New para la cotización Nro: " + Cotizacion.ToString();
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                    }
                }
            }
        }

        public PolicyAcuerdos[] BuscarAcuerdos(int? compania, decimal? cotizacion, int? secuenciaMov, decimal? inicial, int? cantidadCuotas, string estatus)
        {
            return
                soapClient2.BuscarAcuerdos(compania, cotizacion, secuenciaMov, inicial, cantidadCuotas, estatus);
        }


        public bool SetAutoQuotationInlclusionSysFlex(Entity.Entities.Quotation quotation,
                                                     Entity.Entities.Person ContactData,
                                                     Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>> AllVehicleCoverages,
                                                     getVehicleProductLimitVehicle vehicleProductLimits,
                                                     String UserName,
                                                     String useNCFNew,
                                                     String Sistema,
                                                     int TasaCalc,
                                                     out string policyNumber,
                                                     out decimal quotationCoreId,
                                                     out decimal clientCoreId,
                                                     out List<string> statusMessages,
                                                     out bool errorGP
                                                     )
        {

            var success = true;
            var vRamo = 106;
            try
            {
                statusMessages = new List<string>(0);
                errorGP = false;
                policyNumber = string.Empty;
                quotationCoreId = 0m;
                clientCoreId = 0m;
                decimal CotizacionPoliza = 0m;
                decimal CotizacionPos = 0m;

                CotizacionPos = decimal.Parse(quotation.QuotationCoreNumber);

                var dCotizacion = soapClient2.GetVehiculosFromPoliza(quotation.policyNoMain);
                var oCotizacion = dCotizacion.FirstOrDefault();
                CotizacionPoliza = oCotizacion.Cotizacion;
                var dCliente = soapClient2.GetClienteFromPoliza(quotation.policyNoMain);

                clientCoreId = dCliente.Codigo;
                quotationCoreId = CotizacionPoliza;
                policyNumber = quotation.policyNoMain;

                var BeginDate = quotation.StartDate.HasValue ? quotation.StartDate.GetValueOrDefault() : DateTime.Now;
                var EndDate = quotation.EndDate.HasValue ? quotation.EndDate.Value : quotation.StartDate.Value.AddYears(1);
                var DiasCotizados = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, BeginDate, EndDate);

                var AnnualPremium = AllVehicleCoverages.Item1.Sum(k => (k.ProratedPremium * k.VehicleQuantity) * DiasCotizados);

                //Crear la encabezado del movimiento
                var SecuenciaMov = soapClient2.SetPolizaHeaderMov(CotizacionPoliza, 20, AnnualPremium, UserName);

                var Secuencias = AllVehicleCoverages.Item1.Select(p => new
                {
                    SecuenciaSysFlex = p.SecuenciaVehicleSysflex,
                    VehicleQuantity = p.VehicleQuantity
                });

                var SecuenciasMax = dCotizacion.Max(s => s.Item);
                var SecuenciaVeh = SecuenciasMax;
                var SecuenciaVehicleCotizacion = 0;

                #region Insertar vehiculos y coberturas
                foreach (var item in AllVehicleCoverages.Item1)
                {
                    SecuenciaVehicleCotizacion = item.SecuenciaVehicleSysflex.GetValueOrDefault();

                    for (int i = 0; i < item.VehicleQuantity; i++)
                    {
                        SecuenciaVeh = SecuenciaVeh + 1;

                        //Obteniendo los valores del ratejson que faltan para no tener que ir a sysflex a buscarlos
                        var rateJson = item.RateJson;
                        var idTipoVehiculo = string.Empty;
                        var idMarcaVehiculo = string.Empty;
                        var idModeloVehiculo = string.Empty;
                        var idVersion = string.Empty;
                        var idAnoVehiculo = string.Empty;
                        var idColor = string.Empty;
                        var idCapacidad = string.Empty;
                        var idUso = string.Empty;
                        var idEstacionaEn = string.Empty;
                        var iddeducible = string.Empty;
                        var capacidad = string.Empty;
                        var deducible = string.Empty;
                        var porciendoCobertura = string.Empty;
                        var version = string.Empty;
                        var categoria = string.Empty;

                        if (rateJson.Contains("PARAMETERS: "))
                        {
                            var spRateJson = rateJson.Split(new string[] { "PARAMETERS: ", " RESPONSE: " }, StringSplitOptions.RemoveEmptyEntries);
                            if (spRateJson.Count() > 0)
                            {
                                var res = spRateJson[1].Replace(@"\", "");

                                res = "[" + res.Replace(@"}"",""", "}") + "]";

                                var VehicleRateParameters = JsonConvert.DeserializeObject<List<STL.POS.Data.CSEntities.VehicleRateParameters>>(res);
                                if (VehicleRateParameters.Count() > 0 && VehicleRateParameters.FirstOrDefault() != null)
                                {
                                    var vrp = VehicleRateParameters.FirstOrDefault();

                                    idTipoVehiculo = vrp.idTipoVehiculo.HasValue ? vrp.idTipoVehiculo.ToString() : "0";
                                    idMarcaVehiculo = vrp.idMarcaVehiculo.HasValue ? vrp.idMarcaVehiculo.ToString() : "0";
                                    idModeloVehiculo = vrp.idModeloVehiculo.HasValue ? vrp.idModeloVehiculo.ToString() : "0";
                                    idAnoVehiculo = vrp.idAnoVehiculo.HasValue ? vrp.idAnoVehiculo.ToString() : "0";
                                    idUso = vrp.idUso.HasValue ? vrp.idUso.ToString() : "0"; ;
                                    idEstacionaEn = vrp.idEstacionaEn.HasValue ? vrp.idEstacionaEn.ToString() : "0";
                                    idCapacidad = vrp.idCapacidad.HasValue ? vrp.idCapacidad.ToString() : "0";
                                    capacidad = vrp.capacidad;
                                    iddeducible = vrp.iddeducible.HasValue ? vrp.iddeducible.ToString() : "0";
                                    deducible = vrp.deducible;
                                    porciendoCobertura = vrp.porciendoCobertura.HasValue ? vrp.porciendoCobertura.Value.ToString() : "100";
                                    idColor = "";
                                    idVersion = "";
                                    version = "";
                                    categoria = "";
                                }
                            }
                        }

                        /**/
                        var Edad = GetAge(ContactData.DateOfBirth).ToString();
                        var gender = ContactData.Sex;

                        var pSexoEdad = string.Empty;

                        var IsCompany = (gender == "Empresa");

                        if (!IsCompany)
                        {
                            pSexoEdad = soapClient2.GetSexoEdadProducto(new PolicySexoEdadKeyParameter
                            {
                                subramo = item.SelectedCoverageCoreId.GetValueOrDefault(),
                                RamoID = vRamo,
                                Edad = Edad,
                                Sexo = gender
                            });
                        }

                        var QtyMonth = Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Month, BeginDate, EndDate);
                        bool licenciaExtranjera = false;

                        var principalLicence = (ContactData.ForeignLicense.HasValue ? ContactData.ForeignLicense : false);

                        if (principalLicence == true && gender != "Empresa" && item.SelectedCoverageName.ToLower().IndexOf("semi") <= -1)
                            licenciaExtranjera = true;

                        var MontoImpuesto = AnnualPremium * (TasaCalc / 100);
                        var itemInclusion = new PolicyinclusionvehicleDetailMovparameter
                        {
                            compania = COD_COMPANIA,
                            cotizacion = (decimal)CotizacionPoliza,
                            ramo = vRamo,
                            subRamo = item.SelectedCoverageCoreId.GetValueOrDefault(),
                            secuencia = SecuenciaVeh,
                            tipoVehiculo = item.VehicleTypeName,
                            marcaVehiculo = item.VehicleMakeName,
                            modeloVehiculo = item.ModelDesc,
                            version = "",
                            anoVehiculo = item.Year.ToString(),
                            chasis = item.Chassis,
                            placa = item.Plate,
                            color = item.Color,
                            capacidad = capacidad,
                            uso = item.UsageName,
                            estacionaEn = item.StoreName,
                            porcRecargo = 0,
                            montoRecargo = 0,
                            porcDescuento = 0,
                            montoDescuento = 0,
                            porcImpuesto = TasaCalc,
                            montoImpuesto = MontoImpuesto,
                            renovacionAutomatica = string.Empty,
                            primaBruta = AnnualPremium,
                            neto = AnnualPremium + MontoImpuesto,
                            montoAsegurado = item.InsuredAmount,
                            fechaInicio = BeginDate,
                            fechaFin = EndDate,
                            cantidadMeses = (int)QtyMonth,
                            codigoTarifa = null,
                            usuario = UserName,
                            estatus = "ACTIVO",
                            tasa = 1,
                            noFormulario = "",
                            formadePago = "",
                            idTipoVehiculo = idTipoVehiculo,
                            idMarcaVehiculo = idMarcaVehiculo,
                            idModeloVehiculo = idModeloVehiculo,
                            idVersion = "",
                            idAnoVehiculo = idAnoVehiculo,
                            idColor = "",
                            idCapacidad = idCapacidad,
                            idUso = idUso,
                            idEstacionaEn = idEstacionaEn,
                            iddeducible = iddeducible,
                            deducible = deducible,
                            categoria = "4",
                            beneficiarioEndoso = string.Empty,
                            rncBeneficiarioEndoso = string.Empty,
                            valorEndoso = 0,
                            nombreContactoBeneficiarioEndoso = string.Empty,
                            telefonoContactoBeneficiarioEndoso = string.Empty,
                            correoContactoBeneficiarioEndoso = string.Empty,
                            sexoEdad = pSexoEdad,
                            porciendoCobertura = "100",
                            kilomatraje = null,
                            porcientoRecargoVentas = 0,
                            licenciaExtranjera = licenciaExtranjera,
                            montoProrrata = item.ProratedPremium,
                            secuenciaMov = SecuenciaMov,
                            idTipoCombustible = item.SelectedVehicleFuelTypeId.ToString(),
                            tipoCombustible = item.SelectedVehicleFuelTypeDesc

                        };

                        STL.POS.WsProxy.SysflexService.PolicyinclusionvehicleDetailMov[] resultSetInlcusion;
                        //Insertar el vehiculo en sysflex
                        resultSetInlcusion = soapClient2.SetInclusion(itemInclusion);

                        if (resultSetInlcusion == null)
                            success = false;

                        var parm = new PolicySysFlexGetPrimaCoberturaKey();
                        parm.Cotizacion = CotizacionPos;
                        parm.Secuencia = SecuenciaVehicleCotizacion;
                        var primacobertura = GetPrimaCobertura(parm);

                        //Insertar las coberturas
                        var limit = vehicleProductLimits(item.Id.GetValueOrDefault()).FirstOrDefault(p => p.IsSelected.GetValueOrDefault());
                        var ThirdPartyCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Daños Terceros" && x.vehilceID == item.Id.GetValueOrDefault());
                        var SelfDamageCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Daños Propios" && x.vehilceID == item.Id.GetValueOrDefault());
                        var ThirdPartySelfDamageCoverages = SelfDamageCoverages.Concat(ThirdPartyCoverages);

                        #region Daños a terceros
                        foreach (var cov in ThirdPartySelfDamageCoverages)
                        {
                            var cotCobertura = new PolicyinclusionvehicleCoverageparameter();
                            cotCobertura.secuencia = cov.CoverageDetailCoreId.GetValueOrDefault();
                            cotCobertura.secuenciaCot = SecuenciaVeh.GetValueOrDefault();
                            cotCobertura.secuenciaMov = SecuenciaMov;
                            cotCobertura.compania = COD_COMPANIA;
                            cotCobertura.cotizacion = CotizacionPoliza;
                            cotCobertura.limite = cov.Limit.ToString();

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }

                                soapClient2.SetPolizaCoberturaMov(cotCobertura);
                            }
                        }
                        #endregion
                        #region Servicios adicionales
                        var ServicesCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Servicios" && x.vehilceID == item.Id.GetValueOrDefault());

                        foreach (var vServ in ServicesCoverages)
                        {
                            if (vServ.IsSelected.GetValueOrDefault())
                            {
                                var cotCobertura = new PolicyinclusionvehicleCoverageparameter();
                                cotCobertura.secuencia = vServ.CoverageDetailCoreId.GetValueOrDefault();
                                cotCobertura.secuenciaCot = SecuenciaVeh.GetValueOrDefault();
                                cotCobertura.secuenciaMov = SecuenciaMov;
                                cotCobertura.compania = COD_COMPANIA;
                                cotCobertura.cotizacion = CotizacionPoliza;
                                cotCobertura.limite = vServ.Limit.ToString();

                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == vServ.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = 100;//realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = 0;// realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }

                                soapClient2.SetPolizaCoberturaMov(cotCobertura);
                            }
                        }
                        #endregion

                        //Esto se hara porque si tiene servicios debe que recalcular la tarifa 
                        resultSetInlcusion = soapClient2.SetInclusion(itemInclusion);

                        /*Reaseguro*/
                        var setReinsuranceVehicle = soapClient2.SetQuotationReinsuranceVehicle(COD_COMPANIA, CotizacionPoliza, SecuenciaVeh.GetValueOrDefault(), SecuenciaMov);
                        var setCoverageReinsuranceVehicle = soapClient2.SetQuotationCoverageReinsuranceVehicle(COD_COMPANIA, CotizacionPoliza, SecuenciaVeh.GetValueOrDefault(), SecuenciaMov);
                    }
                }
                #endregion

                #region Emision
                if (!quotation.SendInspectionOnly.GetValueOrDefault())
                {
                    //GENERANDO PAGO EN GP
                    if (useNCFNew == "N")//Proceso Viejo
                    {
                        var emisionFactura = soapClient2.SetMotionBillingVehicle(COD_COMPANIA, CotizacionPoliza, SecuenciaMov, UserName, 1, "", 1);
                        if (emisionFactura.ErrorMessage != "N/A")//ERROR
                        {
                            success = false;
                            errorGP = true;
                            statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: SetMotionBillingVehicle. ERROR: " + emisionFactura.ErrorMessage);
                        }
                        else if (emisionFactura.ErrorMessage == "N/A")
                        {
                            success = true;
                        }
                    }
                    else if (useNCFNew == "S")//Proceso Nuevo
                    {
                        decimal Taxes = quotation.TotalISC.Value;
                        decimal totalWithTaxes = AnnualPremium.GetValueOrDefault() + quotation.TotalISC.Value;

                        var emisionInvoiceNumber = soapClient2.GetNCFandInvoiceNumber(quotation.policyNoMain, DateTime.Now, totalWithTaxes, Taxes);

                        if (emisionInvoiceNumber == null || !string.IsNullOrEmpty(emisionInvoiceNumber.Error))
                        {
                            success = false;
                            errorGP = true;
                            statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: GetNCFandInvoiceNumber. ERROR: " + emisionInvoiceNumber.Error);
                        }
                        else if (emisionInvoiceNumber.Successful)
                        {
                            var ResultFactSinGp = soapClient2.FacturacionMovimientoSinGP(COD_COMPANIA, CotizacionPoliza, SecuenciaMov, UserName, 1, "", 1,
                                                                                         emisionInvoiceNumber.NCFNumber, emisionInvoiceNumber.InvoiceNumber, emisionInvoiceNumber.Error, false);
                            success = true;
                        }
                    }
                }
                #endregion

                if (success)
                {
                    /*Acuerdo de Pago*/
                    var paramAcuerdoDePago = new PolicyPaymentAgreementKey();

                    paramAcuerdoDePago.compania = COD_COMPANIA;
                    paramAcuerdoDePago.cotizacion = CotizacionPoliza;
                    paramAcuerdoDePago.sistema = Sistema;
                    paramAcuerdoDePago.usuario = UserName;

                    if (quotation.PaymentFrequencyId.HasValue)
                    {
                        paramAcuerdoDePago.cantidadCuotas = quotation.PaymentFrequencyId.GetValueOrDefault();//la frecuencia de pago
                        paramAcuerdoDePago.inicial = Convert.ToInt32(quotation.AmountToPayEnteredByUser);  //monto que escribrieron
                    }
                    else
                    {
                        paramAcuerdoDePago.cantidadCuotas = 0;
                        paramAcuerdoDePago.inicial = 0;
                    }

                    //var x = soapClient2.SetPaymentAgreement(paramAcuerdoDePago);
                    soapClient2.SetAcuerdoPagoMov(COD_COMPANIA, CotizacionPoliza, paramAcuerdoDePago.inicial, paramAcuerdoDePago.cantidadCuotas, paramAcuerdoDePago.usuario, paramAcuerdoDePago.sistema, SecuenciaMov);

                    success = true;
                }

                return
                     success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetAutoQuotation_NewPV(
            Entity.Entities.Quotation quotation,
            Entity.Entities.Person PrincipalDriver,
           Tuple<IEnumerable<Entity.Entities.VehicleProduct>, List<Entity.Entities.Coverage>> AllVehicleCoverages,
           getVehicleProductLimitVehicle vehicleProductLimits,
           Entity.Entities.User quotationUser,
        int codMoneda,
        int tasaMoneda,
        int codIntermediario,
        int codOficina,
        int codRamo,
        int retryAmount,
        string username,
        int companySysflex,
        decimal porcDescuentoFlotilla,
        int descuentoFlotillaIDSysflex,
        decimal porcProntoPago,
        int descuentoProntoPagoIDSysflex,
        string Sistema,
        string errorPrimaZero,
        int ubicationID,
        string genderParam,
        string ageParam,
        string useNCFNew,
        bool IsShowPolicy,
        string AllowDescuentoProntoPago,
        string AllowDescuentoFlotilla,

        string AllowDescuentoCoupon,
        int descuentoCouponIDSysflex,
        decimal CouponDiscountPercent,

        out string poliza,
        out decimal quotationCoreIdNumber,
        out decimal clientId,
        out List<string> statusMessages,
        out string SourceID,
        out List<Entity.Entities.ListVehicleSourceID> listVehicleSourceID,
        out bool errorGP,
        out bool errorChasis)
        {
            if (string.IsNullOrEmpty(username) || username == "POS-")
            {
                username = "POS-Venta Directa";
            }

            COD_COMPANIA = companySysflex;
            poliza = string.Empty;
            quotationCoreIdNumber = 0;
            clientId = 0;
            statusMessages = new List<string>();
            var status = true;
            var lastMessage = string.Empty;
            var success = false;
            SourceID = string.Empty;
            listVehicleSourceID = new List<Entity.Entities.ListVehicleSourceID>();
            errorGP = false;
            errorChasis = false;

            if (quotation.TotalPrime.Value <= 0)
            {
                throw new Exception(errorPrimaZero);
            }

            #region Clientes/SetQuotationHeader

            var client = new PolicyQuotationKey();
            var principal = PrincipalDriver;//quotation.Drivers.Where(d => d.IsPrincipal).FirstOrDefault();

            client.Cotizacion = 0; //Convert.ToDecimal(quotation.QuotationCoreNumber);

            client.Apellidos = principal.FirstSurname;
            client.CodMoneda = codMoneda;
            client.Compania = COD_COMPANIA;
            client.Direccion = principal.Address;
            client.Email = principal.Email;

            DateTime dob = principal.DateOfBirth;

            if (principal.IdentificationType == "RNC")
            {
                dob = new DateTime(1753, 1, 1);
            }
            client.FechaNacimiento = dob;

            client.Intermediario = codIntermediario;
            client.Nacionalidad = principal.NationalityGlobalCountryDesc;
            client.Nombres = principal.FirstName;
            client.Oficina = codOficina;
            client.PrimaTotal = quotation.TotalPrime.Value + quotation.TotalISC.Value;
            client.Ramo = codRamo;
            client.SubRamo = 0;
            client.SumaAsegurada = 0;
            client.TasaMoneda = tasaMoneda;
            client.TelefonoCasa = principal.PhoneNumber;
            client.TelefonoTrabajo = principal.WorkPhone;
            client.Celular = principal.Mobile;
            client.Usuario = username;

            // In sysflex:
            // 0 = Rnc
            // 1 = Cedula
            // 2 = Otros
            client.TipoCedula = sysflexIdentificationTypeMatch(principal.IdentificationType.Trim());
            client.Cedula = principal.IdentificationNumber;

            client.tipoRnc1 = null;
            client.rnc1 = "";
            client.tipoRnc2 = null;
            client.rnc2 = "";

            client.ExpirationDate = principal.IdentificationType != "RNC" ? principal.IdentificationNumberValidDate : DateTime.MaxValue;

            client.Sexo = sysflexSexMatch(principal.Sex.Trim());
            client.Ncf = principal.InvoiceTypeId.HasValue ? principal.InvoiceTypeId.Value : 0;
            client.Hora = DateTime.Now.ToString("hh:mm:ss tt");
            client.QuotationNumber = quotation.QuotationNumber;
            client.Ubicacion = ubicationID;

            var retryCount = 0;

            PolicyQuotationHeader clientResp = null;
            try
            {
                clientResp = soapClient2.SetQuotationHeaderVehicle(client);

                if (clientResp.Prima.HasValue && clientResp.Prima.Value <= 0)
                {
                    success = false;
                    throw new Exception(errorPrimaZero);
                }

                poliza = clientResp.Poliza;
                quotationCoreIdNumber = clientResp.Cotizacion;
                clientId = clientResp.Cliente.GetValueOrDefault(0);
                success = true;
            }
            catch (Exception ex)
            {
                lastMessage = "El cliente " + principal.FirstName + " " + principal.FirstSurname + " no ha podido ser creado en Sysflex. Falla en el método SetQuotationHeaderVehicle. Detalle: " + ex.Message;
                success = false;
            }
            retryCount++;

            #endregion

            if (!success)
            {
                statusMessages.Add(lastMessage);
                status = false;
            }
            else
            {
                #region Vehiculos/SetQuotationDetailVehicle

                var cantItems = AllVehicleCoverages.Item1.Count();//Vehicle Products //quotation.VehicleProducts.Count;
                int i = 1;
                int count = 1;
                int vehicleIndex = 1;
                int lastVehicleID = 0;

                foreach (var vProd in AllVehicleCoverages.Item1)
                {
                    count = 1;

                    /*Repetir el bloque de codigo todas las veces que indique el campo VehicleQuantity*/
                    while (count <= vProd.VehicleQuantity)
                    {
                        /*Preguntar si el chasis existe, esto es por si mandan mas de una vez la misma cotizacion*/
                        var ccp = this.CheckChassisPlate(vProd.Chassis, vProd.Plate);

                        if (ccp.Count() > 0)
                        {
                            success = false;
                            status = false;

                            string policyOfDuplicate = string.Join(", ", ccp.Select(a => a.Policy));
                            string policyOfDuplicateEncriptep = STL.POS.Data.CSEntities.EncrityDecript.Encrypt_Query(policyOfDuplicate);

                            string mid = "Mensaje ID:";
                            if (IsShowPolicy)
                            {
                                policyOfDuplicateEncriptep = policyOfDuplicate;
                                mid = "Poliza(s):";
                            }

                            lastMessage = string.Format("El chasis '{0}' o placa '{1}' ya estan registrados en nuestros sistemas.<br/> {3} {2}", vProd.Chassis, vProd.Plate, policyOfDuplicateEncriptep, mid);
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                            {
                                statusMessages.Add(lastMessage);
                            }

                            errorChasis = true;
                            return success;
                        }

                        var cDetail = new PolicyQuotationSysFlexCotDetKey();
                        if (count > 1)
                        {
                            i++;
                        }
                        else
                        {
                            i = vProd.SecuenciaVehicleSysflex.HasValue ? vProd.SecuenciaVehicleSysflex.Value : 1;
                        }

                        cDetail.cotizacion = quotationCoreIdNumber; //Convert.ToDecimal(quotation.QuotationCoreNumber);
                        cDetail.secuencia = i;
                        cDetail.anoVehiculo = vProd.Year.Value.ToString();
                        cDetail.compania = COD_COMPANIA;
                        cDetail.estacionaEn = vProd.StoreName;

                        /*Actualziacion de fecha de vencimiento en base a 6 meses*/
                        if (vProd.SelectedCoverageName.Contains("(6 Meses)")
                            || vProd.SelectedCoverageName.Contains("( 6 Meses )")
                            || vProd.SelectedCoverageName.Contains("( 6 Meses)")
                            || vProd.SelectedCoverageName.Contains("(6 Meses )")
                            )
                        {
                            var dateStart = quotation.StartDate.Value;
                            DateTime newEndDate = dateStart.AddMonths(6);

                            cDetail.fechaFin = newEndDate;
                            cDetail.fechaInicio = quotation.StartDate.Value;
                        }
                        else
                        {
                            cDetail.fechaFin = quotation.EndDate.Value;
                            cDetail.fechaInicio = quotation.StartDate.Value;
                        }

                        cDetail.marcaVehiculo = vProd.VehicleMakeName;
                        cDetail.modeloVehiculo = vProd.ModelDesc;//.VehicleModel.Model_Desc;
                        cDetail.placa = vProd.Plate;
                        cDetail.chasis = vProd.Chassis;
                        cDetail.color = vProd.Color;
                        cDetail.ramo = codRamo;
                        cDetail.subRamo = vProd.SelectedCoverageCoreId.GetValueOrDefault();
                        cDetail.primaBruta = vProd.TotalPrime.Value;
                        cDetail.montoImpuesto = vProd.TotalIsc.GetValueOrDefault();
                        cDetail.montoDescuento = 0;
                        cDetail.neto = cDetail.primaBruta + cDetail.montoImpuesto;
                        cDetail.montoRecargo = 0;
                        cDetail.tasa = vProd.PercentageToInsure.Value;
                        cDetail.montoAsegurado = vProd.InsuredAmount.Value;
                        cDetail.porcDescuento = 0;
                        cDetail.porcImpuesto = quotation.ISCPercentage.GetValueOrDefault(0);
                        cDetail.porcRecargo = 0;
                        cDetail.tipoVehiculo = vProd.VehicleTypeName;
                        cDetail.uso = vProd.UsageName;
                        cDetail.noFormulario = vProd.NumeroFormulario;
                        cDetail.formadePago = "";
                        cDetail.renovacionAutomatica = "S";

                        var quantityOfMonth = STL.POS.Data.CSEntities.Helperes.QuantityOfMonth(cDetail.fechaInicio.Value, cDetail.fechaFin.Value);
                        cDetail.cantidadMeses = quantityOfMonth == 0 ? 1 : quantityOfMonth;// 12;//12;

                        cDetail.idTipoCombustible = vProd.SelectedVehicleFuelTypeId.GetValueOrDefault().ToString();
                        cDetail.tipoCombustible = vProd.SelectedVehicleFuelTypeDesc;


                        cDetail.codigoTarifa = 1;
                        cDetail.usuario = username;

                        //Obteniendo los valores del ratejson que faltan para no tener que ir a sysflex a buscarlos
                        var rateJson = vProd.RateJson;

                        if (rateJson.Contains("PARAMETERS: "))
                        {
                            var spRateJson = rateJson.Split(new string[] { "PARAMETERS: ", " RESPONSE: " }, StringSplitOptions.RemoveEmptyEntries);
                            if (spRateJson.Count() > 0)
                            {
                                var res = spRateJson[1].Replace(@"\", "");

                                res = "[" + res.Replace(@"}"",""", "}") + "]";

                                var VehicleRateParameters = JsonConvert.DeserializeObject<List<STL.POS.Data.CSEntities.VehicleRateParameters>>(res);
                                if (VehicleRateParameters.Count() > 0 && VehicleRateParameters.FirstOrDefault() != null)
                                {
                                    var vrp = VehicleRateParameters.FirstOrDefault();

                                    cDetail.idTipoVehiculo = vrp.idTipoVehiculo.HasValue ? vrp.idTipoVehiculo.ToString() : "0";
                                    cDetail.idMarcaVehiculo = vrp.idMarcaVehiculo.HasValue ? vrp.idMarcaVehiculo.ToString() : "0";
                                    cDetail.idModeloVehiculo = vrp.idModeloVehiculo.HasValue ? vrp.idModeloVehiculo.ToString() : "0";
                                    cDetail.idAnoVehiculo = vrp.idAnoVehiculo.HasValue ? vrp.idAnoVehiculo.ToString() : "0";
                                    cDetail.idUso = vrp.idUso.HasValue ? vrp.idUso.ToString() : "0"; ;
                                    cDetail.idEstacionaEn = vrp.idEstacionaEn.HasValue ? vrp.idEstacionaEn.ToString() : "0";
                                    cDetail.idCapacidad = vrp.idCapacidad.HasValue ? vrp.idCapacidad.ToString() : "0";
                                    cDetail.capacidad = vrp.capacidad;
                                    cDetail.iddeducible = vrp.iddeducible.HasValue ? vrp.iddeducible.ToString() : "0";
                                    cDetail.deducible = vrp.deducible;
                                    cDetail.porciendoCobertura = vrp.porciendoCobertura.HasValue ? vrp.porciendoCobertura.Value.ToString() : "100";
                                    cDetail.idColor = "";
                                    cDetail.idVersion = "";
                                    cDetail.version = "";
                                    cDetail.categoria = "";
                                }
                            }
                        }
                        /**/

                        cDetail.estatus = "ACTIVO";

                        var gender = principal.Sex;

                        bool foreingLicence = false;
                        var principalLicence = (principal.ForeignLicense.HasValue ? principal.ForeignLicense : false);
                        if (principalLicence == true && gender != "Empresa" && vProd.SelectedCoverageName.ToLower().IndexOf("semi") <= -1)
                        {
                            foreingLicence = true;
                        }
                        cDetail.licenciaExtranjera = foreingLicence;

                        var genderId = 1;

                        if (gender == "Femenino")
                        {
                            genderId = 2;
                        }

                        DateTime birthday = DateTime.Now;
                        int age = 0;

                        if (gender == "Empresa")
                        {
                            int genderCompany = 0;
                            int.TryParse(genderParam, out genderCompany);

                            if (genderCompany > 0)
                            {
                                genderId = genderCompany;

                                gender = "N/A";
                            }

                            int ageCompany = 0;
                            int.TryParse(ageParam, out ageCompany);

                            if (ageCompany > 0)
                            {
                                age = 0;
                            }
                        }
                        else
                        {
                            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-DO");
                            birthday = DateTime.Parse(principal.DateOfBirth.ToString("dd/MM/yyyy"), culture);
                            age = GetAge(birthday);
                        }

                        STL.POS.WsProxy.SysflexService.PolicySexoEdadKeyParameter paramSex = new WsProxy.SysflexService.PolicySexoEdadKeyParameter();
                        paramSex.Sexo = gender;
                        paramSex.Edad = age.ToString();
                        paramSex.RamoID = cDetail.ramo.HasValue ? cDetail.ramo.Value : 106;
                        paramSex.subramo = cDetail.subRamo.HasValue ? cDetail.subRamo.Value : 0;
                        var resultSexoEdad = GetSexoEdad(paramSex);
                        var sexage = !string.IsNullOrEmpty(resultSexoEdad) ? resultSexoEdad : null;

                        cDetail.sexoEdad = sexage;
                        cDetail.PorcientoRecargoVentas = vProd.SurChargePercentage;

                        retryCount = 0;
                        success = false;
                        lastMessage = string.Empty;
                        string sourceID = "";

                        try
                        {
                            var res = soapClient2.SetQuotationDetailVehicle(cDetail);
                            sourceID = res.Insured_Vehicle_Id_Source_ID;
                            listVehicleSourceID.Add(new Entity.Entities.ListVehicleSourceID()
                            {
                                Index = vehicleIndex,
                                SourceID = sourceID,
                                VehicleID = (lastVehicleID != vProd.Id.GetValueOrDefault()) ? vProd.Id.GetValueOrDefault() : 0
                            });

                            success = true;
                        }
                        catch (Exception ex)
                        {
                            lastMessage = "Falla en el webservice SetQuotationDetailVehicle. Detalle: " + ex.Message;
                            success = false;
                        }

                        if (!success)
                        {
                            var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.ModelDesc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                                msg += lastMessage;
                            statusMessages.Add(msg);
                            status &= false;
                        }

                        PolicySysFlexGetPrimaCoberturaKey parm = new PolicySysFlexGetPrimaCoberturaKey();
                        parm.Cotizacion = Convert.ToDecimal(quotation.QuotationCoreNumber);
                        parm.Secuencia = i;
                        var primacobertura = GetPrimaCobertura(parm);


                        var limit = vehicleProductLimits(vProd.Id.GetValueOrDefault()).FirstOrDefault(p => p.IsSelected.GetValueOrDefault());
                        var ThirdPartyCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Daños Terceros" && x.vehilceID == vProd.Id.GetValueOrDefault());
                        var SelfDamageCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Daños Propios" && x.vehilceID == vProd.Id.GetValueOrDefault());

                        var ThirdPartySelfDamageCoverages = SelfDamageCoverages.Concat(ThirdPartyCoverages);

                        foreach (var cov in ThirdPartySelfDamageCoverages)
                        {
                            var cotCobertura = new PolicyQuotationCoverageKey();
                            cotCobertura.CoberturaId = cov.CoverageDetailCoreId.GetValueOrDefault();
                            cotCobertura.Compania = COD_COMPANIA;
                            cotCobertura.Cotizacion = quotationCoreIdNumber; //Convert.ToDecimal(quotation.QuotationCoreNumber);
                            cotCobertura.Items = i;
                            cotCobertura.Limite = cov.Limit.ToString();

                            if (primacobertura.Count() > 0)
                            {
                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == cov.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }
                            }

                            retryCount = 0;
                            success = false;
                            lastMessage = string.Empty;
                            int ccResp = 0;
                            bool SetQuotationCoverageFail = false;
                            try
                            {
                                ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                                success = true;
                                SetQuotationCoverageFail = true;
                            }
                            catch (Exception ex)
                            {
                                lastMessage = "Falla en el webservice SetQuotationCoverageVehicle. Detalle: " + ex.Message;
                                success = false;
                                SetQuotationCoverageFail = false;
                            }

                            if (!success && !SetQuotationCoverageFail)
                            {
                                var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.ModelDesc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                    msg += lastMessage;
                                statusMessages.Add(msg);
                                status &= false;
                            }
                        }

                        var ServicesCoverages = AllVehicleCoverages.Item2.Where(x => x.CoverageType == "Servicios" && x.vehilceID == vProd.Id.GetValueOrDefault());

                        foreach (var vServ in ServicesCoverages)
                        {
                            if (vServ.IsSelected.GetValueOrDefault())
                            {
                                var cotCobertura = new PolicyQuotationCoverageKey();
                                cotCobertura.CoberturaId = vServ.CoverageDetailCoreId.GetValueOrDefault();
                                cotCobertura.Compania = COD_COMPANIA;
                                cotCobertura.Cotizacion = quotationCoreIdNumber; //Convert.ToDecimal(quotation.QuotationCoreNumber);
                                cotCobertura.Items = i;
                                cotCobertura.Limite = vServ.Limit.ToString();

                                var realCObert = primacobertura.FirstOrDefault(x => x.Secuencia == vServ.CoverageDetailCoreId);
                                if (realCObert != null)
                                {
                                    cotCobertura.coaseguro = realCObert.PorcientoCobertura;
                                    cotCobertura.tasa = realCObert.Porciento;
                                    cotCobertura.prima = realCObert.Prima;
                                    cotCobertura.deducible = realCObert.Deducible;
                                    cotCobertura.minDeducible = realCObert.MinimoDeducible;
                                }

                                retryCount = 0;
                                success = false;
                                lastMessage = string.Empty;
                                int ccResp = 0;
                                bool SetQuotationCoverageFail = false;

                                try
                                {
                                    ccResp = soapClient2.SetQuotationCoverageVehicle(cotCobertura);
                                    success = true;
                                    SetQuotationCoverageFail = true;
                                }
                                catch (Exception ex)
                                {
                                    lastMessage = "Falla en el webservice SetQuotationCoverageVehicle. Detalle: " + ex.Message;
                                    success = false;
                                    SetQuotationCoverageFail = false;
                                };


                                if (!success && !SetQuotationCoverageFail)
                                {
                                    var msg = "El vehículo " + vProd.VehicleMakeName + " " + vProd.ModelDesc + "(" + vProd.Plate + ") no ha podido ser creado en Sysflex para la cotización Nro: " + clientResp.Cotizacion.ToString();
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                        msg += lastMessage;
                                    statusMessages.Add(msg);
                                    status &= false;
                                }
                            }
                        }

                        soapClient2.SetQuotationDetailVehicle(cDetail);

                        SetReinsurance(COD_COMPANIA, i, quotationCoreIdNumber /*Convert.ToDecimal(quotation.QuotationCoreNumber)*/);

                        if (!vProd.SecuenciaVehicleSysflex.HasValue)
                        {
                            i++;
                        }

                        count++;
                        vehicleIndex++;
                        lastVehicleID = vProd.Id.GetValueOrDefault();
                    }
                }
                #endregion

                #region Emision
                if (!quotation.SendInspectionOnly.GetValueOrDefault())
                {
                    PolicyQuotationILQuotationPassTransit emisionResp = null;

                    retryCount = 0;
                    success = false;
                    lastMessage = string.Empty;

                    while (!success && retryCount < retryAmount)
                    {
                        try
                        {
                            emisionResp = soapClient2.SetPasstransitVehicle(COD_COMPANIA, quotationCoreIdNumber /*Convert.ToDecimal(quotation.QuotationCoreNumber)*/, username, "", codOficina, 1);

                            if (string.IsNullOrEmpty(emisionResp.Poliza))
                            {
                                lastMessage = "Error en el metodo: SetPasstransitVehicle, Al parecer no se genero el numero de Poliza en sysflex para la cotizacion: " + quotation.QuotationNumber;
                                success = false;
                                statusMessages.Add(lastMessage);
                            }
                            else
                            {
                                poliza = emisionResp.Poliza;
                                SourceID = emisionResp.SourceId;
                                success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            lastMessage = ex.Message;
                            success = false;
                        }
                        retryCount++;
                    }

                    if (emisionResp != null && success)
                    {
                        try
                        {
                            //GENERANDO PAGO EN GP
                            if (useNCFNew == "N")//Proceso Viejo
                            {
                                var emisionFactura = soapClient2.SetMotionBillingVehicle(COD_COMPANIA, quotationCoreIdNumber /*Convert.ToDecimal(quotation.QuotationCoreNumber)*/, 1, username, 1, "", 1);
                                if (emisionFactura.ErrorMessage != "N/A")//ERROR
                                {
                                    success = false;
                                    errorGP = true;
                                    statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: SetMotionBillingVehicle. ERROR: " + emisionFactura.ErrorMessage);
                                }
                                else if (emisionFactura.ErrorMessage == "N/A")
                                {
                                    success = true;
                                }
                            }
                            else if (useNCFNew == "S")//Proceso Nuevo
                            {
                                decimal totalWithTaxes = quotation.TotalPrime.Value + quotation.TotalISC.Value;
                                decimal Taxes = quotation.TotalISC.Value;
                                NCFInvoiceResult emisionInvoiceNumber = soapClient2.GetNCFandInvoiceNumber(poliza, DateTime.Now, totalWithTaxes, Taxes);

                                if (emisionInvoiceNumber == null || !string.IsNullOrEmpty(emisionInvoiceNumber.Error))
                                {
                                    success = false;
                                    errorGP = true;
                                    statusMessages.Add("Fallo en la Emision de la Facuta en Sysflex. Metodo: GetNCFandInvoiceNumber. ERROR: " + emisionInvoiceNumber.Error);
                                }
                                else if (emisionInvoiceNumber.Successful)
                                {
                                    var ResultFactSinGp = soapClient2.FacturacionMovimientoSinGP(COD_COMPANIA, quotationCoreIdNumber /*Convert.ToDecimal(quotation.QuotationCoreNumber)*/, 1, username, 1, "", 1,
                                                                                                 emisionInvoiceNumber.NCFNumber, emisionInvoiceNumber.InvoiceNumber, emisionInvoiceNumber.Error, false);
                                    success = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método FacturacionMovimientoSinGP.";
                            lastMessage = ex.Message;
                            if (!string.IsNullOrWhiteSpace(lastMessage))
                            {
                                msg += lastMessage;
                            }
                            statusMessages.Add(msg);
                            success = false;
                            errorGP = true;
                        }

                        if (success)//Si Emision, Facturacion Salen Bien
                        {
                            try
                            {
                                /*Acuerdo de Pago*/
                                PolicyPaymentAgreementKey paramAcuerdoDePago = new PolicyPaymentAgreementKey();

                                paramAcuerdoDePago.compania = COD_COMPANIA;
                                paramAcuerdoDePago.cotizacion = quotationCoreIdNumber;//Convert.ToDecimal(quotation.QuotationCoreNumber);
                                paramAcuerdoDePago.sistema = Sistema;
                                paramAcuerdoDePago.usuario = username;

                                if (quotation.PaymentFrequencyId.HasValue)
                                {
                                    paramAcuerdoDePago.cantidadCuotas = quotation.PaymentFrequencyId.GetValueOrDefault();//la frecuencia de pago
                                    paramAcuerdoDePago.inicial = Convert.ToInt32(quotation.AmountToPayEnteredByUser);  //monto que escribrieron
                                }
                                else
                                {
                                    paramAcuerdoDePago.cantidadCuotas = 0;
                                    paramAcuerdoDePago.inicial = 0;
                                }

                                var x = soapClient2.SetPaymentAgreement(paramAcuerdoDePago);
                                success = true;
                                /**/
                            }
                            catch (Exception ex)
                            {
                                var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPaymentAgreement.";
                                lastMessage = ex.Message;
                                if (!string.IsNullOrWhiteSpace(lastMessage))
                                {
                                    msg += lastMessage;
                                }
                                statusMessages.Add(msg);
                                success = false;
                            }


                            if (quotation.Messaging.GetValueOrDefault() && quotation.PaymentWay.HasValue && (int)quotation.PaymentWay.Value == 1 && quotationUser != null
                                && quotationUser.AgentId.HasValue && success)//Efectivo
                            {
                                try
                                {
                                    /*Mensajeria*/
                                    PolicySysFlexMensajeriaKey param = new PolicySysFlexMensajeriaKey();
                                    param.Compania = COD_COMPANIA;
                                    param.Cotizacion = clientResp.Cotizacion;
                                    param.Usuario = username;
                                    var mens = soapClient2.SetMensajeria(param);
                                    success = true;
                                    /**/
                                }
                                catch (Exception ex)
                                {
                                    var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetMensajeria.";
                                    lastMessage = ex.Message;
                                    if (!string.IsNullOrWhiteSpace(lastMessage))
                                    {
                                        msg += lastMessage;
                                    }
                                    statusMessages.Add(msg);
                                    success = false;
                                }
                            }

                            if (porcDescuentoFlotilla > 0)
                            {
                                if (AllowDescuentoFlotilla == "S")
                                {
                                    try
                                    {
                                        /*Si hay descuento de flotilla procesar el de flotilla primero*/
                                        decimal realDiscountFlotilla = (porcDescuentoFlotilla / 100);

                                        /*Descuentos a Polizas Flotilla*/
                                        PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                        paramDiscount.Compania = COD_COMPANIA;
                                        paramDiscount.Sistema = Sistema;
                                        paramDiscount.Usuario = username;

                                        paramDiscount.Poliza = emisionResp.Poliza;
                                        paramDiscount.ConceptoId = descuentoFlotillaIDSysflex;
                                        paramDiscount.PorcDescuento = realDiscountFlotilla;


                                        soapClient2.SetPolizaDescuento(paramDiscount);
                                        success = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Flotilla.";
                                        lastMessage = ex.Message;
                                        if (!string.IsNullOrWhiteSpace(lastMessage))
                                        {
                                            msg += lastMessage;
                                        }
                                        statusMessages.Add(msg);
                                        success = false;
                                    }
                                }
                            }

                            if (CouponDiscountPercent > 0)
                            {
                                if (AllowDescuentoCoupon == "S")
                                {
                                    try
                                    {
                                        /*Si hay descuento de flotilla procesar el de flotilla primero*/
                                        decimal realDiscountCoupon = (CouponDiscountPercent / 100);

                                        /*Descuentos a Polizas Flotilla*/
                                        PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                        paramDiscount.Compania = COD_COMPANIA;
                                        paramDiscount.Sistema = Sistema;
                                        paramDiscount.Usuario = username;

                                        paramDiscount.Poliza = emisionResp.Poliza;
                                        paramDiscount.ConceptoId = descuentoCouponIDSysflex;
                                        paramDiscount.PorcDescuento = realDiscountCoupon;

                                        soapClient2.SetPolizaDescuento(paramDiscount);
                                        success = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Cupon.";
                                        lastMessage = ex.Message;
                                        if (!string.IsNullOrWhiteSpace(lastMessage))
                                        {
                                            msg += lastMessage;
                                        }
                                        statusMessages.Add(msg);
                                        success = false;
                                    }
                                }
                            }

                            if (porcProntoPago > 0)
                            {
                                if (AllowDescuentoProntoPago == "S")
                                {
                                    try
                                    {
                                        /*Descuentos a Polizas Protno Pago*/
                                        PolicySysFlexPolizaDescuentoParameter paramDiscount = new PolicySysFlexPolizaDescuentoParameter();
                                        paramDiscount.Compania = COD_COMPANIA;
                                        paramDiscount.Sistema = Sistema;
                                        paramDiscount.Usuario = username;

                                        paramDiscount.Poliza = emisionResp.Poliza;
                                        paramDiscount.ConceptoId = descuentoProntoPagoIDSysflex;
                                        paramDiscount.PorcDescuento = (porcProntoPago / 100);

                                        soapClient2.SetPolizaDescuento(paramDiscount);

                                        success = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPolizaDescuento - Pronto Pago.";
                                        lastMessage = ex.Message;
                                        if (!string.IsNullOrWhiteSpace(lastMessage))
                                        {
                                            msg += lastMessage;
                                        }
                                        statusMessages.Add(msg);
                                        success = false;
                                    }
                                }
                            }
                        }
                    }

                    if (emisionResp == null)
                    {
                        var msg = "Cotización Nro: " + clientResp.Cotizacion.ToString() + ": Falla en la ejecución del método SetPasstransitVehicle.";
                        if (!string.IsNullOrWhiteSpace(lastMessage))
                            msg += lastMessage;
                        statusMessages.Add(msg);
                        status &= false;
                    }
                }
                #endregion
            }
            return status;
        }

        #endregion

        public STL.POS.WsProxy.SysflexService.Policyinclusioncontact GetClienteFromPoliza(string PolicyNo)
        {
            return
                soapClient2.GetClienteFromPoliza(PolicyNo);
        }

        public STL.POS.WsProxy.SysflexService.Policyinclusionvehicle[] GetVehiculosFromPoliza(string PolicyNo)
        {
            return
                soapClient2.GetVehiculosFromPoliza(PolicyNo);
        }

        public PolicyOverPremiumResult GetIsOverPremium(int? intermediario, string marca, string modelo, int? anio, int? ramo, int? subRamo)
        {
            return
                soapClient2.GetIsOverPremium(intermediario, marca, modelo, anio, ramo, subRamo);
        }
    }
}