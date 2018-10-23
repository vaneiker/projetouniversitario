﻿using STL.POS.Frontend.Web.NewVersion.CustomCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Entities;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    /// <summary>
    /// Author: Lic. Carlos ML. Lebron B.
    /// </summary>
    public partial class HomeController : BaseController
    {
        public class VehicleCoverages
        {
            public IEnumerable<Coverage> ThirdDamage { get; set; }
            public IEnumerable<Coverage> SelfDamage { get; set; }
            public IEnumerable<Coverage> Additional { get; set; }

            public decimal ThirdDamageTotalLimit { get; set; }
            public decimal SelfDamageTotalLimit { get; set; }
            public decimal AdditionalTotalLimit { get; set; }
        }

        private QuotationViewModel getDataQuotation(int QuotId)
        {
            var data = getQuotationData(QuotId);
            return
                data;
        }

        public ActionResult Summary()
        {
            ViewBag.TitlePage = "RESUMEN";
            ViewBag.QuoId = QuotationId;
            QuotationId = ViewBag.QuoId;
            var DataQuotation = getDataQuotation(QuotationId);
            ViewBag.QuotationNumber = DataQuotation.QuotationNumber;
            ViewBag.isFinanced = DataQuotation.Financed.GetValueOrDefault() ? "1" : "0";
            isFinanced = DataQuotation.Financed.GetValueOrDefault();
            ViewBag.Period = DataQuotation.Period;
            ViewBag.MonthlyPayment = DataQuotation.MonthlyPayment;

            var dataPaymentFreqFinanced = oDropDownManager.GetDropDown("PaymentFreqFinanced").Select(p => new SelectListItem
            {
                Text = p.name,
                Value = p.Value.Replace("\"", "'")
            }).ToList();

            dataPaymentFreqFinanced.Insert(0, new SelectListItem { Value = "-1", Text = "Seleccione" });

            ViewBag.PaymentFreqFinanced = dataPaymentFreqFinanced;


            var _vehicles = getVehicleData(QuotationId).ToList();
            //var quot = getQuotationData(QuotationId);

            var discountCoupon = DataQuotation.couponPercentageDiscount;

            var TotalPrimeVehicle = DataQuotation.TotalPrime;
            var TotalISCVehicle = DataQuotation.TotalISC;

            var ISCPercentage = DataQuotation.ISCPercentage;
            var TotalDiscountFlotilla = DataQuotation.TotalFlotillaDiscount;
            var TotalPrimeVehicleWithDiscount = (TotalPrimeVehicle - TotalDiscountFlotilla);

            var TotalDiscountCoupon = (TotalPrimeVehicleWithDiscount * (discountCoupon / 100));

            TotalPrimeVehicleWithDiscount = (TotalPrimeVehicleWithDiscount - TotalDiscountCoupon);

            var newTotalISC = TotalPrimeVehicleWithDiscount * (ISCPercentage / 100);

            var newTotalPrimeVehicle = TotalPrimeVehicleWithDiscount + newTotalISC;

            Dictionary<string, decimal?> fields = new Dictionary<string, decimal?>();
            fields.Add("TPV", TotalPrimeVehicle);
            fields.Add("TIV", TotalISCVehicle);
            fields.Add("TDF", TotalDiscountFlotilla);
            fields.Add("TDC", TotalDiscountCoupon);
            fields.Add("TPVD", TotalPrimeVehicleWithDiscount);
            fields.Add("NTI", newTotalISC);
            fields.Add("NTPV", newTotalPrimeVehicle);

            var DataVehicle = new Tuple<List<CustomCode.QuotationViewModel.Vehicles>, Dictionary<string, decimal?>, CustomCode.CommonEnums.RequestType>
                (_vehicles, fields, base.RequestType);

            ViewBag.isNotLawProduct = isNotLawProduct;
            ViewBag.IsExclusion = (base.RequestType == CustomCode.CommonEnums.RequestType.Exclusion);
            ViewBag.IsVehicleChange = (base.RequestType == CustomCode.CommonEnums.RequestType.Cambios);
            ViewBag.Policy_No = string.IsNullOrEmpty(DataQuotation.policyNoMain) ? "" : DataQuotation.policyNoMain;
            ViewBag.CouponCode = string.IsNullOrEmpty(DataQuotation.couponCode) ? "" : DataQuotation.couponCode;

            var IsAgentFinancial = false;
            var dataAgentQuotation = oUserManager.GetUser(DataQuotation.User_Id, null, null, null);

            var pNameID = dataAgentQuotation.Username;
            if (!string.IsNullOrEmpty(pNameID))
            {
                var agent = getAgenteUserInfo(pNameID);
                if (agent != null)
                    IsAgentFinancial = oPersonManagerManager.IsAgentFinancial(agent.AgentId);
            }
            var IsDeclarativa = (DataQuotation.QuotationProduct.ToLower().Contains("declarativa"));
            var ShowCheckFinancial = true;

            if (IsAgentFinancial)
                ShowCheckFinancial = false;

            if (IsDeclarativa)
                ShowCheckFinancial = false;


            ViewBag.ShowCheckFinancial = ShowCheckFinancial;

            var qtyVehicles = _vehicles.Count();
            var qtyVehiclesDublicates = _vehicles.Where(x => x.VehicleQuantity > 1).Count();
            if (qtyVehicles > 1 || qtyVehiclesDublicates > 0)
            {
                ViewBag.hideSection = false;
            }
            else
            {
                ViewBag.hideSection = true;
            }

            return PartialView(DataVehicle);
        }

        [HttpPost]
        public JsonResult GetCoverage(int VehicleId)
        {
            var coverages = oQuotationManager.GetQuotationCoverage(VehicleId, CommonEnums.CoverageFilterType.Todo.ToInt()).Select(a => new QuotationViewModel.coverages
            {
                Id = a.Id,
                IsSelected = a.IsSelected,
                CoverageDetailCoreId = a.CoverageDetailCoreId,
                Name = a.Name,
                Amount = a.Amount,
                MinDeductible = a.MinDeductible,
                SelfDamagesToProductLimits = a.SelfDamagesToProductLimits,
                ThirdPartyToProductLimits = a.ThirdPartyToProductLimits,
                ServiceType_Id = a.ServiceType_Id,
                Limit = a.Limit,
                UserId = a.UserId,
                Deductible = a.Deductible,
                CoverageType = a.CoverageType
            });

            var ThirdDamage = coverages.Where(t => t.CoverageType == "Daños Terceros");
            var SelfDamage = coverages.Where(s => s.CoverageType == "Daños Propios");
            var Additional = coverages.Where(a => a.CoverageType == "Servicios");

            var prodLimits = oQuotationManager.GetQuotationProductLimits(VehicleId);

            var oVehiclesCoverages = new VehicleCoverages
            {
                ThirdDamage = ThirdDamage,
                ThirdDamageTotalLimit = prodLimits.FirstOrDefault().TpPrime.Value,

                SelfDamage = SelfDamage,
                SelfDamageTotalLimit = prodLimits.FirstOrDefault().SdPrime.Value,

                Additional = Additional,
                AdditionalTotalLimit = prodLimits.FirstOrDefault().ServicesPrime.Value,
            };

            return
                Json(oVehiclesCoverages, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAmortizacionTable(int Period, double TotalPremium)
        {
            var DataAmortizationTable = oVirtualOfficeProxy.GetAmortizationTable(TotalPremium, Period, "VehicleInsurance", 20, TotalPremium);

            return
                Json(DataAmortizationTable, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowAmortizationTable(int QuotationId, int period, double TotalPrime)
        {
            string PathFile = string.Empty;

            //crear el archivo pdf 
            var FileName = string.Concat("AmortizacionTableQuotationNumber", QuotationId.ToString(), ".pdf");
            var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);
            var Xml = GenerateXMLContratoOTablaKCO(QuotationId, period);
            var PdfFileByteArray = oThunderheadProxy.SendToTHExecutePreview(null, Xml);
            System.IO.File.WriteAllBytes(FullFileName, PdfFileByteArray);
            PathFile = @"\Tmp\" + FileName;
            return
                Json(PathFile, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowFinancedContractTH(int QuotationId)
        {
            string PathFile = string.Empty;

            //crear el archivo pdf 
            var FileName = string.Concat("FinancedContractQuotationNumber", QuotationId.ToString(), ".pdf");
            var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);
            var Xml = GenerateXMLContratoOTablaKCO(QuotationId, IsContract: true);
            var PdfFileByteArray = oThunderheadProxy.SendToTHExecutePreview(null, Xml);
            System.IO.File.WriteAllBytes(FullFileName, PdfFileByteArray);
            PathFile = @"\Tmp\" + FileName;
            return
                Json(PathFile, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowQuotation(int quotationId, string pNameID = "", bool pQuotationResume = false)
        {
            string PathFile = string.Empty;
            bool IsAgentFinancial = false;
            var quotationData = getQuotationData(quotationId);

            //crear el archivo pdf 
            var FileName = "";
            if (quotationData != null)
                FileName = string.Concat(string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_QUOTATION_EMAIL_FILE_NAME").Value, quotationData.QuotationNumber), ".pdf");
            else
                FileName = string.Concat("QuotationNumber-", quotationId.ToString(), ".pdf");

            //crear el archivo pdf 

            var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);
            var User = GetCurrentUsuario();
            if (!string.IsNullOrEmpty(pNameID))
            {
                var agent = getAgenteUserInfo(pNameID);

                if (agent != null)
                    IsAgentFinancial = oPersonManagerManager.IsAgentFinancial(agent.AgentId);
            }

            byte[] Xml = GenerateXMLQuotation(quotationId, !IsAgentFinancial, pQuotationResume != null ? pQuotationResume : false);
            var PdfFileByteArray = oThunderheadProxy.SendToTHExecutePreview(null, Xml);
            System.IO.File.WriteAllBytes(FullFileName, PdfFileByteArray);
            PathFile = @"\Tmp\" + FileName;

            return
                  Json(PathFile, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Generar el contrato o la tabla de amortizacion
        /// </summary>
        /// <param name="QuotationId"></param>
        /// <param name="PeriodQuota"></param>
        /// <param name="IsContract"></param>
        /// <returns></returns>
        private byte[] GenerateXMLContratoOTablaKCO(int QuotationId, int? PeriodQuota = null, bool IsContract = false)
        {
            const string FormatoFecha = "{0:dd/MM/yyyy}";
            var result = new byte[] { };
            var Email = string.Empty;
            #region Data
            var PolicyData = getQuotationData(QuotationId);
            var ContactData = getDriverData(QuotationId).FirstOrDefault();
            var _vehicles = getVehicleData(QuotationId);

            #endregion

            #region Thunderhead
            var DocumentId = IsContract ? ConfigurationManager.AppSettings["DocumentIDContratoKSI"]
                                       : ConfigurationManager.AppSettings["DocumentIDAmortizacionKSI"];

            var data = new THProxy.Schemas.POS_AUTO();

            var oContract = new THProxy.Schemas.Contract();
            var oTransaction = new THProxy.Schemas.Transaction();
            var oLoan = new THProxy.Schemas.Loan();
            var oFee = new THProxy.Schemas.Fee();
            #region Transacction
            oTransaction.DocumentId = DocumentId;

            #region Loan
            oLoan.Account = "";
            oLoan.Id = "";
            oLoan.Status = "";
            oLoan.AccountName = ContactData.GetFullName();
            oLoan.Client = ContactData.GetFullName();
            oLoan.FoundsSource = "Fondos Propios";
            oLoan.FundsDestination = "-";
            oLoan.CredtitFacility = "PRESTAMOS PERSONALES PARA GASTOS";
            oLoan.Comite = "";
            oLoan.PaymentMethod = "";
            oLoan.RequestedAmount = "";
            oLoan.ApprovedAmount = "";
            oLoan.ReleasedAmount = "";
            oLoan.CapitalReturn = "";
            oLoan.LastCut = "";
            oLoan.Interest = "";
            oLoan.Comission = "";
            oLoan.DelayFee = "";
            oLoan.FeeAmount = "";
            oLoan.PaymentPeriod = "";
            oLoan.Frequency = "";
            oLoan.RequestDate = "";
            oLoan.ApprovementDate = "";
            oLoan.ReleasedDate = "";
            oLoan.ExpirationDate = "";
            oLoan.NextPaymentDate = "";

            #region Fee
            oLoan.Fee = new List<THProxy.Schemas.Fee>(0);
            var Period = PolicyData.Period.HasValue ? PolicyData.Period.Value : PeriodQuota.GetValueOrDefault();
            var MonthlyPayment = PolicyData.MonthlyPayment;

            //Obtener la tabla de amortizacion del prestamo
            var annualPremium = (double)(PolicyData.TotalPrime + PolicyData.TotalISC);

            var DataResult = oVirtualOfficeProxy.GetAmortizationTable(annualPremium,
                                                                      Period,
                                                                      "VehicleInsurance",
                                                                      20,
                                                                      annualPremium
                                                                      );

            double GastosCierre = DataResult.productCalculatorResult.ExpendituresAmount;

            var FinancedAmount = DataResult.productCalculatorResult.FinancedAmount;

            var DataAT = DataResult.productCalculatorResult.AmotizationTable;

            var AmortizationTable = DataAT.Select(ta => new THProxy.Schemas.Fee
            {
                Number = ta.PeriodNumber.ToString().Replace(",", ""),
                Date = string.Format(FormatoFecha, ta.Date),
                Amount = ta.Payment.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Capital = ta.Principal.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Interests = ta.Interest.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Comission = "0",
                Spends = "0",
                Total = ta.Balance.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "")
            });

            oLoan.TotalCapital = DataAT.Sum(p => p.Principal).ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oLoan.TotalInterests = DataAT.Sum(p => p.Interest).ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oLoan.TotalComissions = "0";
            oLoan.TotalSpends = "0";
            oLoan.TotalAmount = "";

            var NumeroCuotas = (DataAT.Count()).ToString("#,0", CultureInfo.InvariantCulture).Replace(",", "");
            var NumeroCuotasDisplay = Period;

            oLoan.FeeNumber = NumeroCuotas;
            oLoan.Fee.AddRange(AmortizationTable);
            oTransaction.Loan = oLoan;
            #endregion

            #endregion

            #endregion
            #region Contract
            var ValueToConvertAnnualPrime = FinancedAmount.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            var ValueToConvertMonthlyPayment = MonthlyPayment.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            var LoanAmountString = Numalet.ToCardinal(ValueToConvertAnnualPrime, CultureInfo.InvariantCulture).ToUpper();
            var PaymentAmountString = Numalet.ToCardinal(ValueToConvertMonthlyPayment, CultureInfo.InvariantCulture).ToUpper();

            oContract.LoanNumber = PolicyData.QuotationNumber;
            oContract.CustomerName = ContactData.GetFullName();
            oContract.Citizenship = "Republica Dominicana";

            var MaritalStatusDesc = "N/A";
            MaritalStatusDesc = !string.IsNullOrEmpty(ContactData.MaritalStatus) ? ContactData.MaritalStatus : MaritalStatusDesc;

            var Direccion = !string.IsNullOrEmpty(ContactData.Address) ? ContactData.Address : "-";

            oContract.CivilStatus = MaritalStatusDesc;
            oContract.Id = ContactData.IdentificationNumber;
            oContract.Address1 = Direccion;
            oContract.Address2 = Direccion;
            oContract.CompanyRepresentative = "";
            oContract.CompanyRepCiticenship = "";
            oContract.CompanyRepId = "";
            oContract.QuotationNumber = PolicyData.QuotationNumber;
            oContract.InsuranceCompany = "ATLANTICA SEGUROS";
            oContract.LoanAmountString = string.Format("{0} {1}", LoanAmountString, FinancedAmount.ToString("RD$#,0.00", CultureInfo.InvariantCulture));
            oContract.NumberOfPaymentString = string.Format("{0} ({1}) Cuotas", Numalet.ToCardinal(NumeroCuotasDisplay.ToString(), CultureInfo.InvariantCulture), NumeroCuotasDisplay.ToString()).Replace("con 00/100.- ", "");
            oContract.PaymentAmountString = string.Format("{0} {1}", PaymentAmountString, MonthlyPayment.GetValueOrDefault().ToString("RD$#,0.00", CultureInfo.InvariantCulture));
            oContract.LoanRateString = "";

            if (!string.IsNullOrEmpty(PolicyData.Credit_Card_Number) && PolicyData.Credit_Card_Type_Id.HasValue)
            {
                oContract.CreditCardNumber = Utility.Decrypt_Query(PolicyData.Credit_Card_Number);
                oContract.CreditCardType = Enum.GetName(typeof(CommonEnums.CreditCardType), PolicyData.Credit_Card_Type_Id).Replace("_", " ");
            }

            var Month = PolicyData.Expiration_Date_Month.GetValueOrDefault();
            var Year = PolicyData.Expiration_Date_Year.GetValueOrDefault();

            var ExpirationDate = string.Concat(Month, "/", Year);
            oContract.CreditCardExpirationDate = ExpirationDate;

            string mes = DateTime.Now.ToString("MMMM").Capitalize();

            var ContractDateString = string.Format("{0}({1}) di­as del mes de {2} del año {3} ({4})",
                                                    Numalet.ToCardinal(DateTime.Now.Day).Replace("con 00/100.- ", ""),
                                                    DateTime.Now.Day,
                                                    mes,
                                                    Numalet.ToCardinal(DateTime.Now.Year).Replace("con 00/100.- ", ""),
                                                    DateTime.Now.Year);

            oContract.ContractDateString = ContractDateString;
            #endregion

            data.Transaction = oTransaction;
            data.Contract = oContract;
            #endregion

            var DocXML = Utility.SerializeToXMLString(data);

            result = Encoding.UTF8.GetBytes(DocXML);

            return
                 result;
        }

        private byte[] GenerateXMLQuotation(int QuotationId, bool IsSaleChannelNormal = false, bool? IsResume = false)
        {
            const string FormatoFecha = "{0:yyyy-MM-dd}";
            var NumericDefault = "0.00";
            var DriverFullName = string.Empty;
            var result = new byte[] { };

            var oPosAuto = new CustomCode.TH.POS_AUTO();
            var oTransaction = new CustomCode.TH.Transaction();
            var oQuotation = new CustomCode.TH.Quotation();
            var oDriver = new CustomCode.TH.Drivers();
            var oVehicles = new List<CustomCode.TH.Vehicles>();
            var oPolicyChange = new List<CustomCode.TH.PolicyChange>();

            var oPrimeResume = new CustomCode.TH.PrimeResume();
            bool isExclusion = (base.RequestType == CommonEnums.RequestType.Exclusion);
            bool isVehicleRequestChanges = (base.RequestType == CommonEnums.RequestType.Cambios);

            #region Data
            var dataQuotation = getDataQuotation(QuotationId);
            var dataDriver = getDriverData(QuotationId).FirstOrDefault();
            var dataVehicles = getVehicleData(QuotationId);
            DriverFullName = dataDriver.GetFullName();

            #endregion

            #region Transaction
            oTransaction.NoPoliza = dataQuotation.QuotationNumber;

            /*Forma Anterior de Flotilla 21-07-2017*/
            var quantityTotalDiferentVehicles = dataVehicles.Count();
            var quantityTotalVehicles = dataVehicles.Where(x => x.VehicleQuantity > 4);

            var quantityTotalVehiclesDuplicates = dataVehicles.Where(x => x.VehicleQuantity > 1);
            var quantityTotalVehiclesNODuplicates = dataVehicles.Where(x => x.VehicleQuantity == 1);

            if (quantityTotalVehiclesDuplicates != null)
            {
                quantityTotalDiferentVehicles = 0;
                foreach (var a in quantityTotalVehiclesDuplicates)
                {
                    quantityTotalDiferentVehicles += a.VehicleQuantity.Value;
                }

                foreach (var a in quantityTotalVehiclesNODuplicates)
                {
                    quantityTotalDiferentVehicles += a.VehicleQuantity.Value;
                }

            }

            if (quantityTotalDiferentVehicles > 4)
                oTransaction.DocumentId = "1335504116";//Para vehiculos mayores a 4
            else if (quantityTotalVehicles.Count() > 0)
                oTransaction.DocumentId = "1335504116";//Para vehiculos mayores a 4
            else
                oTransaction.DocumentId = "1335501365";

            if (IsResume.GetValueOrDefault())
            {
                var DocIDResume = oDropDownManager.GetParameter("PARAMETER_KEY_DOCUMENT_ID_QUOTATATION_RESUMED").Value;
                oTransaction.DocumentId = DocIDResume;
            }

            int codRamo = oDropDownManager.GetParameter("PARAMETER_KEY_COD_RAMO").Value.ToInt();


            oTransaction.Fullname = DriverFullName;
            oTransaction.FechaInicio = string.Format(FormatoFecha, dataQuotation.StartDate);
            oTransaction.FechaVencimiento = string.Format(FormatoFecha, dataQuotation.EndDate);

            string userDefault = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToString();
            var agentNameFull = userDefault;

            var _agentQuotation = oUserManager.GetUser(dataQuotation.User_Id, null, null, null);
            string RealAgentCode = "0";

            if (_agentQuotation != null && _agentQuotation.AgentId != null)
            {
                var userAgenCode = getAgenteUserInfo(_agentQuotation.AgentId.Value);
                if (userAgenCode != null)
                {
                    if (userAgenCode.AgentId <= 0)
                        userAgenCode = getAgenteUserInfo(_agentQuotation.Username);

                    agentNameFull = userAgenCode != null ? userAgenCode.FullName : userDefault;
                    RealAgentCode = userAgenCode != null ? userAgenCode.AgentCode : "0";

                    oTransaction.IntermediarioCode = !string.IsNullOrEmpty(userAgenCode.AgentCode) ? userAgenCode.AgentCode : "";
                    oTransaction.Intermediario = userAgenCode.FullName;
                    oTransaction.AgenteComercial = userAgenCode.AgentsChannel != null ? userAgenCode.AgentsChannel.First_Name + " " + userAgenCode.AgentsChannel.First_Lastname + " " + userAgenCode.AgentsChannel.Second_Lastname : "";

                    var DataOffice = userAgenCode.AgentOffices.FirstOrDefault();

                    oTransaction.Office = DataOffice != null ? string.Concat(DataOffice.OfficeDesc, " (", DataOffice.OfficeCode, ")") : "";
                    oTransaction.Channel = userAgenCode.AgentsChannel != null ? userAgenCode.AgentsChannel.Channel_Desc : "";
                }
            }

            oTransaction.Currency = dataQuotation.CurrencySymbol;
            oTransaction.Username = (agentNameFull != "10562" && !string.IsNullOrEmpty(agentNameFull)) ? agentNameFull : DriverFullName;

            #endregion

            #region Quotation
            oQuotation.PrincipalName = DriverFullName;
            oQuotation.PrincipalCountry = "República Dominicana";
            oQuotation.QuotationNumber = dataQuotation.QuotationNumber;
            oQuotation.QuotationDate = string.Format(FormatoFecha, DateTime.Now);

            decimal DepreciationRate = oDropDownManager.GetParameter("PARAMETER_KEY_PORC_DEPREC_MIN").Value.ToDecimal();

            var OverPremiumList = new List<WsProxy.SysflexService.PolicyOverPremiumResult>();

            //Detectar si existe algun vehiculo con tasa Recargada
            try
            {
                foreach (var itemVehicle in dataVehicles)
                {
                    var r = oCoreProxy.GetIsOverPremium(RealAgentCode.ToInt(),
                                                        itemVehicle.VehicleMakeName,
                                                        itemVehicle.ModelDesc,
                                                        itemVehicle.Year.GetValueOrDefault(),
                                                        codRamo,
                                                        itemVehicle.SelectedCoverageCoreId);


                    DepreciationRate = r.Percent.GetValueOrDefault();

                    if (r.Result.GetValueOrDefault())
                    {
                        OverPremiumList.Add(r);
                    }
                }

                var HasOverPremiumVehicle = OverPremiumList.Any(x => x.Result.GetValueOrDefault());
                if (HasOverPremiumVehicle)
                {
                    DepreciationRate = OverPremiumList.Max(x => x.Percent.GetValueOrDefault());
                }
            }
            catch (Exception ex)
            {
                //Si hubo algun error loguearlos
                LoggerHelper.Log(CommonEnums.Categories.Error, dataQuotation.UserName, QuotationId, "Error detectando vehiculo con sobreprima", ex.Message, ex);
            }

            oQuotation.DepreciationRate = DepreciationRate;
            oQuotation.Plan = "AUTO";
            oQuotation.StartDate = oTransaction.FechaInicio;
            oQuotation.EndDate = oTransaction.FechaVencimiento;
            oQuotation.ProposalDate = string.Format(FormatoFecha, DateTime.Now);
            oQuotation.IdType = dataDriver.IdentificationType;
            oQuotation.IdNumber = dataDriver.IdentificationNumber;
            oQuotation.TelephoneNumber = !string.IsNullOrEmpty(dataDriver.PhoneNumber) ? dataDriver.PhoneNumber : "";
            oQuotation.Email = string.IsNullOrEmpty(dataDriver.Email) ? "-" : dataDriver.Email;
            oQuotation.NumberOfPayments = "0";
            oQuotation.NumberOfVehicles = quantityTotalDiferentVehicles.ToInt().ToString();//dataVehicles.Count().ToString(CultureInfo.InvariantCulture);
            oQuotation.ForeignDriverLicense = dataDriver.ForeignLicense.HasValue ? dataDriver.ForeignLicense.Value : false;


            oDriver.Name = DriverFullName;
            oDriver.IdType = dataDriver.IdentificationType;
            oDriver.IdNumber = dataDriver.IdentificationNumber;
            oDriver.BirthDate = dataDriver.IdentificationType == "RNC" ? "" : string.Format(FormatoFecha, dataDriver.DateOfBirth);
            oDriver.Email = dataDriver.Email;

            if (!string.IsNullOrEmpty(dataDriver.PhoneNumber))
                oDriver.TelephoneNumber = dataDriver.PhoneNumber;
            else if (!string.IsNullOrEmpty(dataDriver.Mobile))
                oDriver.TelephoneNumber = dataDriver.Mobile;
            else if (!string.IsNullOrEmpty(dataDriver.WorkPhone))
                oDriver.TelephoneNumber = dataDriver.WorkPhone;
            else
                oDriver.TelephoneNumber = "";

            oDriver.LicenseNumber = dataDriver.ForeignLicense.GetValueOrDefault() ? "SI" : "NO";
            oDriver.Sex = dataDriver.GetSexOneLetter();
            oDriver.Age = dataDriver.GetAge();

            oQuotation.Drivers = oDriver;

            //Recorrer los vehiculos
            int count = 0;
            foreach (var itemVehicle in dataVehicles)
            {
                var dataCoverage = getCoverageData(itemVehicle.Id.GetValueOrDefault());
                var vehicleProductLimits = getVehicleProductLimit(itemVehicle.Id.GetValueOrDefault());

                count = 1;
                while (count <= itemVehicle.VehicleQuantity)
                {
                    var oThirdDamagesCoverages = new List<CustomCode.TH.ThirdDamagesCoverages>();
                    var oSelfDamagesCoverages = new List<CustomCode.TH.SelfDamagesCoverages>();
                    var oAdditionals = new List<CustomCode.TH.Additionals>();

                    var oDataThirdDamagesCoverages = dataCoverage.Where(v => v.CoverageType == "Daños Terceros");
                    var oDataSelfDamagesCoverages = dataCoverage.Where(v => v.CoverageType == "Daños Propios");
                    var oDataAdditional = dataCoverage.Where(v => v.CoverageType == "Servicios");

                    //Daños Terceros
                    foreach (var itemTD in oDataThirdDamagesCoverages)
                    {
                        oThirdDamagesCoverages.Add(new CustomCode.TH.ThirdDamagesCoverages
                        {
                            Description = itemTD.Name,
                            Limit = itemTD.Limit.HasValue ? itemTD.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            MinimumDeductible = itemTD.MinDeductible.HasValue ? itemTD.MinDeductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            CovPercentage = itemTD.coveragePercentage.GetValueOrDefault(),
                            Base = itemTD.baseDeductible
                        });
                    }

                    //Daños Propios
                    foreach (var itemSD in oDataSelfDamagesCoverages)
                    {
                        oSelfDamagesCoverages.Add(new CustomCode.TH.SelfDamagesCoverages
                        {
                            Description = itemSD.Name,
                            Limit = itemSD.Limit.HasValue ? itemSD.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            Deducible = itemSD.Deductible.HasValue ? itemSD.Deductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            MinimumDeductible = itemSD.MinDeductible.HasValue ? itemSD.MinDeductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            CovPercentage = itemSD.coveragePercentage.GetValueOrDefault(),
                            Base = itemSD.baseDeductible
                        });
                    }

                    foreach (var itemAdditional in oDataAdditional)
                    {
                        oAdditionals.Add(new CustomCode.TH.Additionals
                        {
                            Description = itemAdditional.Name,
                            //Limit = itemAdditional.Limit.HasValue ? itemAdditional.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            Limit = itemAdditional.Amount.HasValue ? itemAdditional.Amount.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                            MinimumDeductible = itemAdditional.MinDeductible.HasValue ? itemAdditional.MinDeductible.Value.ToString() : NumericDefault,
                            CovPercentage = itemAdditional.coveragePercentage.GetValueOrDefault(),
                            Base = itemAdditional.baseDeductible
                        });
                    }

                    var ThirdTotalDamagePrime = vehicleProductLimits.TpPrime.Value.ToString(CultureInfo.InvariantCulture);
                    var SelfDamagesTotalPrime = vehicleProductLimits.SdPrime.Value.ToString(CultureInfo.InvariantCulture);
                    var AdditionalsTotalPrime = vehicleProductLimits.ServicesPrime.Value.ToString(CultureInfo.InvariantCulture);
                    //var VehicleProductLimit = oQuotationManager.GetQuotationProductLimits()

                    oVehicles.Add(new CustomCode.TH.Vehicles
                    {
                        Brand = itemVehicle.VehicleMakeName,
                        Model = itemVehicle.ModelDesc,
                        Year = itemVehicle.Year.Value.ToString(CultureInfo.InvariantCulture),
                        VehicleType = itemVehicle.SelectedVehicleTypeName,
                        Plan = itemVehicle.SelectedProductName,
                        Registro = itemVehicle.Plate,
                        Chasis = itemVehicle.Chassis,
                        EnsuredAmount = itemVehicle.VehiclePrice.Value.ToString(CultureInfo.InvariantCulture),
                        ThirdDamagesCoverages = oThirdDamagesCoverages,
                        ThirdDamagesPrime = ThirdTotalDamagePrime,
                        SelfDamagesCoverages = oSelfDamagesCoverages,
                        SelfDamagesPrime = SelfDamagesTotalPrime,
                        Additionals = oAdditionals,
                        AdditionalsPrime = AdditionalsTotalPrime,
                        VehiclePrime = itemVehicle.TotalPrime.GetValueOrDefault().ToString(CultureInfo.InvariantCulture),
                        VehicleValue = itemVehicle.VehiclePrice.Value.ToString(CultureInfo.InvariantCulture),
                        Quantity = "1", //itemVehicle.VehicleQuantity.Value.ToString(CultureInfo.InvariantCulture)
                        TotalVehiclePrime = (itemVehicle.TotalPrime.GetValueOrDefault() * 1).ToString(CultureInfo.InvariantCulture), //itemVehicle.TotalPrime.Value.ToString(CultureInfo.InvariantCulture),
                        FuelType = itemVehicle.SelectedVehicleFuelTypeDesc,
                        Parking = itemVehicle.StoreName,
                        CoveragePercentage = itemVehicle.PercentageToInsure.GetValueOrDefault(),
                        Coverage = itemVehicle.SelectedCoverageName,
                        Deducible = vehicleProductLimits.SelectedDeductibleName != null ? vehicleProductLimits.SelectedDeductibleName : "",
                        Uso = string.IsNullOrEmpty(itemVehicle.UsageName) ? "" : itemVehicle.UsageName,
                        Pasajeros = itemVehicle.Passengers != null ? itemVehicle.Passengers : "0"
                    });

                    count++;
                }

                if (isExclusion)
                {
                    CustomCode.TH.PolicyChange pc = new CustomCode.TH.PolicyChange();
                    string desc = string.Format("Marca: {0} - Modelo: {1} - Año: {2} - Placa: {3} - Chasis: {4} - Color: {5}",
                                                itemVehicle.VehicleMakeName,
                                                itemVehicle.ModelDesc,
                                                itemVehicle.Year,
                                                itemVehicle.Plate,
                                                itemVehicle.Chassis,
                                                itemVehicle.Color
                                                );


                    pc.ChangeType = "Exclusión";
                    pc.ChangeDescription = desc;
                    pc.ChangeDetail = "Proceso de Exclusión";

                    oPolicyChange.Add(pc);
                }
                else if (isVehicleRequestChanges)
                {
                    CustomCode.TH.PolicyChange pc = new CustomCode.TH.PolicyChange();
                    List<RequestChanges> dataVehicleRequestChange = Utility.getRequestChanges(dataQuotation.policyNoMain, null, itemVehicle.SecuenciaVehicleSysflex.GetValueOrDefault(), true);

                    string oldPlate = dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Placa.ToInt()) != null ? dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Placa.ToInt()).Old_Value : "";//7 = Placa
                    string oldChassis = dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Chasis.ToInt()) != null ? dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Chasis.ToInt()).Old_Value : "";//6 = Chasis
                    string oldColor = dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Color.ToInt()) != null ? dataVehicleRequestChange.FirstOrDefault(x => x.Condition_Id == CommonEnums.ChangeConditionCatalog.Color.ToInt()).Old_Value : "";//5 = Color

                    string shortDesc = string.Format("Marca: {0} - Modelo: {1} - Año: {2} ", itemVehicle.VehicleMakeName, itemVehicle.ModelDesc, itemVehicle.Year);
                    string chasisChange = string.Empty;
                    string plateChange = string.Empty;
                    string colorChange = string.Empty;

                    string realDesc = "";

                    if (oldPlate != itemVehicle.Plate)
                    {
                        plateChange = string.Format("- Placa Anterior: {0} - Placa Nueva: {1} ", oldPlate, itemVehicle.Plate);
                    }

                    if (oldChassis != itemVehicle.Chassis)
                    {
                        chasisChange = string.Format("- Chasis Anterior: {0} - Chasis Nuevo: {1} ", oldChassis, itemVehicle.Chassis);
                    }

                    if (oldColor != itemVehicle.Color)
                    {
                        colorChange = string.Format("- Color Anterior: {0} - Color Nuevo: {1}", oldColor, itemVehicle.Color);
                    }
                    realDesc = string.Concat(shortDesc, chasisChange, plateChange, colorChange);

                    pc.ChangeType = "Solicitud de Cambios Vehículos";
                    pc.ChangeDescription = realDesc;
                    pc.ChangeDetail = "Proceso de Cambio";

                    oPolicyChange.Add(pc);
                }
            }

            oQuotation.Vehicles = oVehicles;
            var TotalPrime = dataQuotation.TotalPrime;
            decimal TotalPaymnent = 0;

            oPrimeResume.TotalAnualPrime = TotalPrime.Value.ToString(CultureInfo.InvariantCulture);


            //Descuentos         
            var realDiscount = (dataQuotation.TotalFlotillaDiscount.HasValue ? dataQuotation.TotalFlotillaDiscount.Value : 0) + (dataQuotation.TotalDiscount.HasValue ? dataQuotation.TotalDiscount.Value : 0);

            decimal newTotalAnualPrime = (TotalPrime.GetValueOrDefault() - realDiscount);
            decimal totalDiscountCoupon = (newTotalAnualPrime * (dataQuotation.couponPercentageDiscount.GetValueOrDefault() / 100));

            realDiscount = realDiscount + totalDiscountCoupon;

            newTotalAnualPrime = (newTotalAnualPrime - totalDiscountCoupon);

            decimal newTotaltaxes = newTotalAnualPrime * ((dataQuotation.ISCPercentage.HasValue ? dataQuotation.ISCPercentage.Value : 0) / 100);

            oPrimeResume.Discount = realDiscount.ToString(CultureInfo.InvariantCulture);
            oPrimeResume.PrimeDiscount = newTotalAnualPrime.ToString(CultureInfo.InvariantCulture);

            oPrimeResume.Taxes = newTotaltaxes.ToString(CultureInfo.InvariantCulture);

            TotalPaymnent = (newTotalAnualPrime + newTotaltaxes);

            oPrimeResume.TotalPayment = TotalPaymnent.ToString(CultureInfo.InvariantCulture);

            oQuotation.PrimeResume = oPrimeResume;
            #endregion

            #region PaymentOptions
            if (RequestType == CommonEnums.RequestType.Inclusion)
                IsSaleChannelNormal = false;

            if (IsSaleChannelNormal)
                //Si el producto es declarativa no debe mostrar las opciones de pago
                if (dataQuotation.QuotationProduct.ToLower().Contains("declarativa"))
                    IsSaleChannelNormal = false;

            oQuotation.IsSaleChannelNormal = IsSaleChannelNormal ? "true" : "false";

            IEnumerable<itemProjectionPayment> itemProjectionPayment = null;
            var totalPrime = Convert.ToDecimal(dataQuotation.TotalPrime + dataQuotation.TotalISC);
            //itemProjectionPayment = this.getProjectionPayment(totalPrime);
            itemProjectionPayment = this.getProjectionPayment(TotalPaymnent);

            var PaymentOptions = new List<CustomCode.TH.PaymentOptions>(0);
            if (itemProjectionPayment.ToList().Count > 0)
            {
                //Pago Unico
                var DataPagoUnico = itemProjectionPayment.FirstOrDefault(x => x.Numero == 1);
                PaymentOptions.Add(new CustomCode.TH.PaymentOptions
                {
                    PaymentType = "1",
                    InitialPayment = DataPagoUnico.Inicial.ToString(CultureInfo.InvariantCulture),
                    NextPay = DataPagoUnico.Cuotas,
                });

                //Inicial + 4 Cuotas
                var DataInicialMas4Pagos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 2);
                PaymentOptions.Add(new CustomCode.TH.PaymentOptions
                {
                    PaymentType = "2",
                    InitialPayment = DataInicialMas4Pagos.Inicial.ToString(CultureInfo.InvariantCulture),
                    NextPay = DataInicialMas4Pagos.Cuotas
                });

                //Inicial + 4 Cuotas Automaticas
                var DataInicialMas4PagosAutomaticos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 3);
                PaymentOptions.Add(new CustomCode.TH.PaymentOptions
                {
                    PaymentType = "3",
                    InitialPayment = DataInicialMas4PagosAutomaticos.Inicial.ToString(CultureInfo.InvariantCulture),
                    NextPay = DataInicialMas4PagosAutomaticos.Cuotas
                });

                //Inicial + 11 cuotas financiadas
                var DataFinanced = itemProjectionPayment.FirstOrDefault(x => x.Numero == 4);
                PaymentOptions.Add(new CustomCode.TH.PaymentOptions
                {
                    PaymentType = "4",
                    InitialPayment = DataFinanced.Inicial.ToString(CultureInfo.InvariantCulture),
                    NextPay = DataFinanced.Cuotas
                });
            }
            oQuotation.PaymentOptions = PaymentOptions;

            #endregion


            if (isExclusion || isVehicleRequestChanges)
            {
                oTransaction.DocumentId = "1335506497";//Solicitud de cambios

                oQuotation.Product = dataQuotation.QuotationProduct;
                oQuotation.NCFType = getInvoiceTypes(dataDriver.InvoiceTypeId.GetValueOrDefault());
                oQuotation.Email = string.IsNullOrEmpty(dataDriver.Email) ? "" : dataDriver.Email;

                oTransaction.NoPoliza = dataQuotation.policyNoMain;
                oTransaction.FechaInicio = string.Format("{0:dd/MM/yyyy}", dataQuotation.StartDate);
                oTransaction.FechaVencimiento = string.Format("{0:dd/MM/yyyy}", dataQuotation.EndDate);

                oPosAuto.PolicyChange = oPolicyChange;
            }

            oPosAuto.Quotation = oQuotation;
            oPosAuto.Transaction = oTransaction;

            var DocXML = Utility.SerializeToXMLString(oPosAuto);

            result = Encoding.UTF8.GetBytes(DocXML);

            return
                 result;
        }

        private byte[] GenerateXMLQuotation_Marbete(int QuotationId, string MarbeteTransaction_DocumentId = "")
        {
            const string FormatoFecha = "{0:yyyy-MM-dd}";
            var NumericDefault = "0.00";
            var DriverFullName = string.Empty;
            var result = new byte[] { };

            var oPosAuto = new CustomCode.TH.POS_AUTO();
            var oTransaction = new CustomCode.TH.Transaction();
            var oQuotation = new CustomCode.TH.Quotation();
            var oDriver = new CustomCode.TH.Drivers();
            var oVehicles = new List<CustomCode.TH.Vehicles>();

            var oPrimeResume = new CustomCode.TH.PrimeResume();
            var PaymentOptions = new List<POS_AUTOQuotationPaymentOptions>(0);

            #region Data
            var dataQuotation = getDataQuotation(QuotationId);
            var dataDriver = getDriverData(QuotationId).FirstOrDefault();
            var dataVehicles = getVehicleData(QuotationId);
            DriverFullName = dataDriver.GetFullName();
            #endregion

            #region Transaction
            oTransaction.NoPoliza = dataQuotation.PolicyNumber;

            /*Forma Anterior de Flotilla 21-07-2017*/
            var quantityTotalDiferentVehicles = dataVehicles.Count();
            var quantityTotalVehicles = dataVehicles.Where(x => x.VehicleQuantity > 4);

            var quantityTotalVehiclesDuplicates = dataVehicles.Where(x => x.VehicleQuantity > 1);

            if (quantityTotalVehiclesDuplicates != null)
            {
                foreach (var a in quantityTotalVehiclesDuplicates)
                    quantityTotalDiferentVehicles += a.VehicleQuantity.Value;
            }

            oTransaction.DocumentId = MarbeteTransaction_DocumentId;

            oTransaction.Fullname = DriverFullName;
            oTransaction.FechaInicio = string.Format(FormatoFecha, dataQuotation.StartDate);
            oTransaction.FechaVencimiento = string.Format(FormatoFecha, dataQuotation.EndDate);

            string userDefault = oDropDownManager.GetParameter("PARAMETER_KEY_COD_INTERMEDIARIO").Value.ToString();
            var agentNameFull = userDefault;

            var _agentQuotation = oUserManager.GetUser(dataQuotation.User_Id, null, null, null);

            if (_agentQuotation != null && _agentQuotation.AgentId != null)
            {
                var userAgenCode = getAgenteUserInfo(_agentQuotation.AgentId.Value);
                if (userAgenCode != null)
                {
                    if (userAgenCode.AgentId <= 0)
                        userAgenCode = getAgenteUserInfo(_agentQuotation.Username);

                    agentNameFull = userAgenCode != null ? userAgenCode.FullName : userDefault;
                }
            }

            oTransaction.Username = agentNameFull;
            #endregion

            #region Quotation
            oQuotation.PrincipalName = DriverFullName;
            oQuotation.PrincipalCountry = "República Dominicana";
            oQuotation.QuotationNumber = dataQuotation.QuotationNumber;
            oQuotation.QuotationDate = string.Format(FormatoFecha, DateTime.Now);
            oQuotation.Plan = "AUTO";
            oQuotation.StartDate = oTransaction.FechaInicio;
            oQuotation.EndDate = oTransaction.FechaVencimiento;
            oQuotation.ProposalDate = string.Format(FormatoFecha, DateTime.Now);
            oQuotation.IdType = dataDriver.IdentificationType;
            oQuotation.IdNumber = dataDriver.IdentificationNumber;
            oQuotation.TelephoneNumber = dataDriver.PhoneNumber;
            oQuotation.Email = dataDriver.Email;
            oQuotation.NumberOfPayments = "0";
            oQuotation.NumberOfVehicles = dataVehicles.Count().ToString(CultureInfo.InvariantCulture);

            oDriver.Name = DriverFullName;
            oDriver.IdType = dataDriver.IdentificationType;
            oDriver.IdNumber = dataDriver.IdentificationNumber;
            oDriver.BirthDate = string.Format(FormatoFecha, dataDriver.DateOfBirth);
            oDriver.Email = dataDriver.Email;

            if (!string.IsNullOrEmpty(dataDriver.PhoneNumber))
                oDriver.TelephoneNumber = dataDriver.PhoneNumber;
            else if (!string.IsNullOrEmpty(dataDriver.Mobile))
                oDriver.TelephoneNumber = dataDriver.Mobile;
            else if (!string.IsNullOrEmpty(dataDriver.WorkPhone))
                oDriver.TelephoneNumber = dataDriver.WorkPhone;
            else
                oDriver.TelephoneNumber = "";

            oQuotation.Drivers = oDriver;

            //Recorrer los vehiculos
            foreach (var itemVehicle in dataVehicles)
            {
                var dataCoverage = getCoverageData(itemVehicle.Id.GetValueOrDefault());
                var vehicleProductLimits = getVehicleProductLimit(itemVehicle.Id.GetValueOrDefault());

                var oThirdDamagesCoverages = new List<CustomCode.TH.ThirdDamagesCoverages>();
                var oSelfDamagesCoverages = new List<CustomCode.TH.SelfDamagesCoverages>();
                var oAdditionals = new List<CustomCode.TH.Additionals>();

                var oDataThirdDamagesCoverages = dataCoverage.Where(v => v.CoverageType == "Daños Terceros");
                var oDataSelfDamagesCoverages = dataCoverage.Where(v => v.CoverageType == "Daños Propios");
                var oDataAdditional = dataCoverage.Where(v => v.CoverageType == "Servicios");

                //Daños Terceros
                foreach (var itemTD in oDataThirdDamagesCoverages)
                {
                    oThirdDamagesCoverages.Add(new CustomCode.TH.ThirdDamagesCoverages
                    {
                        Description = itemTD.Name,
                        Limit = itemTD.Limit.HasValue ? itemTD.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                        MinimumDeductible = itemTD.MinDeductible.HasValue ? itemTD.MinDeductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault
                    });
                }

                //Daños Propios
                foreach (var itemSD in oDataSelfDamagesCoverages)
                {
                    oSelfDamagesCoverages.Add(new CustomCode.TH.SelfDamagesCoverages
                    {
                        Description = itemSD.Name,
                        Limit = itemSD.Limit.HasValue ? itemSD.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                        Deducible = itemSD.Deductible.HasValue ? itemSD.Deductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                        MinimumDeductible = itemSD.MinDeductible.HasValue ? itemSD.MinDeductible.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault
                    });
                }

                foreach (var itemAdditional in oDataAdditional)
                {
                    oAdditionals.Add(new CustomCode.TH.Additionals
                    {
                        Description = itemAdditional.Name,
                        //Limit = itemAdditional.Limit.HasValue ? itemAdditional.Limit.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                        Limit = itemAdditional.Amount.HasValue ? itemAdditional.Amount.Value.ToString(CultureInfo.InvariantCulture) : NumericDefault,
                        MinimumDeductible = itemAdditional.MinDeductible.HasValue ? itemAdditional.MinDeductible.Value.ToString() : NumericDefault
                    });
                }

                var ThirdTotalDamagePrime = vehicleProductLimits.TpPrime.Value.ToString(CultureInfo.InvariantCulture);
                var SelfDamagesTotalPrime = vehicleProductLimits.SdPrime.Value.ToString(CultureInfo.InvariantCulture);
                var AdditionalsTotalPrime = vehicleProductLimits.ServicesPrime.Value.ToString(CultureInfo.InvariantCulture);

                oVehicles.Add(new CustomCode.TH.Vehicles
                {
                    Brand = itemVehicle.VehicleMakeName,
                    Model = itemVehicle.ModelDesc,
                    Year = itemVehicle.Year.Value.ToString(CultureInfo.InvariantCulture),
                    VehicleType = itemVehicle.SelectedVehicleTypeName,
                    Plan = itemVehicle.SelectedProductName,
                    Registro = itemVehicle.Plate,
                    Chasis = itemVehicle.Chassis,
                    EnsuredAmount = itemVehicle.VehiclePrice.Value.ToString(CultureInfo.InvariantCulture),
                    ThirdDamagesCoverages = oThirdDamagesCoverages,
                    ThirdDamagesPrime = ThirdTotalDamagePrime,
                    SelfDamagesCoverages = oSelfDamagesCoverages,
                    SelfDamagesPrime = SelfDamagesTotalPrime,
                    Additionals = oAdditionals,
                    AdditionalsPrime = AdditionalsTotalPrime,
                    TotalVehiclePrime = itemVehicle.TotalPrime.Value.ToString(CultureInfo.InvariantCulture),
                    VehiclePrime = itemVehicle.TotalPrimeVehicle.ToString(CultureInfo.InvariantCulture),
                    VehicleValue = itemVehicle.VehiclePrice.Value.ToString(CultureInfo.InvariantCulture),
                    Quantity = itemVehicle.VehicleQuantity.Value.ToString(CultureInfo.InvariantCulture)
                });
            }

            oQuotation.Vehicles = oVehicles;
            var TotalPrime = dataQuotation.TotalPrime;
            var TotalTaxes = dataQuotation.TotalISC;
            var TotalDiscount = dataQuotation.TotalDiscount;
            var PrimeDiscount = TotalPrime - TotalDiscount;
            var TotalPaymnent = PrimeDiscount + TotalTaxes;

            oPrimeResume.TotalAnualPrime = TotalPrime.Value.ToString(CultureInfo.InvariantCulture);
            oPrimeResume.Taxes = TotalTaxes.Value.ToString(CultureInfo.InvariantCulture);
            oPrimeResume.Discount = TotalDiscount.Value.ToString(CultureInfo.InvariantCulture);
            oPrimeResume.PrimeDiscount = PrimeDiscount.Value.ToString(CultureInfo.InvariantCulture);
            oPrimeResume.TotalPayment = TotalPaymnent.Value.ToString(CultureInfo.InvariantCulture);

            oQuotation.PrimeResume = oPrimeResume;
            #region Detalle formas pago
            ////Pago Unico
            //var DataPagoUnico = itemProjectionPayment.FirstOrDefault(x => x.Numero == 1);
            //PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            //{
            //    PaymentType = "1",
            //    PaymentTypeFieldSpecified = true,
            //    InitialPayment = DataPagoUnico.Inicial.ToString(CultureInfo.InvariantCulture),
            //    InitialPaymentFieldSpecified = true,
            //    NextPay = DataPagoUnico.Cuotas,
            //    NextPayFieldSpecified = true
            //});

            ////Inicial + 4 Cuotas
            //var DataInicialMas4Pagos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 2);
            //PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            //{
            //    PaymentType = "2",
            //    PaymentTypeFieldSpecified = true,
            //    InitialPayment = DataInicialMas4Pagos.Inicial.ToString(CultureInfo.InvariantCulture),
            //    InitialPaymentFieldSpecified = true,
            //    NextPay = DataInicialMas4Pagos.Cuotas,
            //    NextPayFieldSpecified = true
            //});

            ////Inicial + 4 Cuotas Automaticas
            //var DataInicialMas4PagosAutomaticos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 3);
            //PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            //{
            //    PaymentType = "3",
            //    PaymentTypeFieldSpecified = true,
            //    InitialPayment = DataInicialMas4PagosAutomaticos.Inicial.ToString(CultureInfo.InvariantCulture),
            //    InitialPaymentFieldSpecified = true,
            //    NextPay = DataInicialMas4PagosAutomaticos.Cuotas,
            //    NextPayFieldSpecified = true

            //});

            ////Inicial + 11 cuotas financiadas
            //var DataFinanced = itemProjectionPayment.FirstOrDefault(x => x.Numero == 4);
            //PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            //{
            //    PaymentType = "4",
            //    PaymentTypeFieldSpecified = true,
            //    InitialPayment = DataFinanced.Inicial.ToString(CultureInfo.InvariantCulture),
            //    InitialPaymentFieldSpecified = true,
            //    NextPay = DataFinanced.Cuotas,
            //    NextPayFieldSpecified = true
            //});

            //oQuotation.PaymentPaymentOptions = PaymentOptions.ToArray();
            #endregion
            #endregion

            oPosAuto.Quotation = oQuotation;
            oPosAuto.Transaction = oTransaction;

            var DocXML = Utility.SerializeToXMLString(oPosAuto);

            result = Encoding.UTF8.GetBytes(DocXML);

            return
                 result;
        }

        public void SaveFinanced(int? Period, decimal? MonthlyPayment, int? paymentFrequencyId, bool financed)
        {
            var itemFinanced = new Quotation.parameter
            {
                id = QuotationId,
                period = Period < 0 ? (int?)null : Period,
                paymentFrequencyId = paymentFrequencyId == -1 ? null : paymentFrequencyId,
                monthlyPayment = financed ? MonthlyPayment : (decimal?)null,
                financed = financed,
                lastStepVisited = 2
            };

            isFinanced = financed;
            oQuotationManager.SetQuotation(itemFinanced);

            var FileName = string.Concat("QuotationNumber-", QuotationId.ToString(), ".pdf");
            var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);

            /*Borrando PDF de la cotizacion*/
            try
            { DeleteFileOfQuotation(FullFileName); }
            catch (Exception ax) { }
            /**/
        }

        public JsonResult sendMail(int quotationID, string emails, string pNameID = "")
        {
            string PathFile = string.Empty;
            bool IsAgentFinancial = false;
            var quotationData = getQuotationData(quotationID);

            //crear el archivo pdf 
            var FileName = "";
            if (quotationData != null)
                FileName = string.Concat(string.Format(oDropDownManager.GetParameter("PARAMETER_KEY_QUOTATION_EMAIL_FILE_NAME").Value, quotationData.QuotationNumber), ".pdf");
            else
                FileName = string.Concat("QuotationNumber-", quotationID.ToString(), ".pdf");
            ////crear el archivo pdf 
            //var FileName = string.Concat("QuotationNumber-", quotationID.ToString(), ".pdf");

            var FullFileName = string.Concat(Server.MapPath("~/Tmp/"), FileName);
            var User = GetCurrentUsuario();
            if (!string.IsNullOrEmpty(pNameID))
            {
                var agent = getAgenteUserInfo(pNameID);

                if (agent != null)
                {
                    IsAgentFinancial = oPersonManagerManager.IsAgentFinancial(agent.AgentId);
                }
            }

            byte[] Xml = GenerateXMLQuotation(quotationID, !IsAgentFinancial);
            var PdfFileByteArray = oThunderheadProxy.SendToTHExecutePreview(null, Xml);
            System.IO.File.WriteAllBytes(FullFileName, PdfFileByteArray);

            var subject = oDropDownManager.GetParameter("PARAMETER_KEY_REPORT_EMAIL_SUBJECT").Value;
            if (quotationData != null)
                subject = string.Format(subject, quotationData.QuotationNumber);

            var body = oDropDownManager.GetParameter("PARAMETER_KEY_REPORT_EMAIL_BODY").Value;
            var sender = oDropDownManager.GetParameter("PARAMETER_KEY_EMAIL_SENDER").Value;

            List<string> destinatariosList = new List<string>();
            var sp = emails.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (sp.Count() > 0)
            {
                foreach (var s in sp)
                {
                    destinatariosList.Add(s);
                }
            }

            try
            {
                SendEmailHelper.SendMail(sender, destinatariosList, subject, body, FullFileName);

                /*Borrando PDF de la cotizacion*/
                try
                { DeleteFileOfQuotation(FullFileName); }
                catch (Exception ax) { }
                /**/
            }
            catch (Exception ex)
            {
                var usuario = GetCurrentUsuario();

                LoggerHelper.Log(CommonEnums.Categories.Error, (usuario != null ? usuario.UserLogin : ""), -1, "Error al enviar cotizacion por correo", ex.Message, ex);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<itemProjectionPayment> getProjectionPayment(decimal annualPremium)
        {
            decimal Initial;
            decimal Cuotas;
            string NumberFormat = "#,0.00";
            decimal ParameterFinancingPercent = Convert.ToInt32(oDropDownManager.GetParameter("PARAMETER_KEY_PERCENT_FINANCING_POLICY").Value);
            var PorcPagoUnico = Convert.ToDecimal(oDropDownManager.GetParameter("PARAMETER_KEY_PORC_DESC_PAGO_UNICO").Value);
            var PorcPagoAutomatico = Convert.ToDecimal(oDropDownManager.GetParameter("PARAMETER_KEY_PORC_DESC_PAGO_AUTOMATICO").Value);
            var PorcPagoInicial = Convert.ToDecimal(oDropDownManager.GetParameter("PARAMETER_KEY_PORC_PAGO_INICIAL").Value);

            var result = new List<itemProjectionPayment>(0);

            var TotalPremium = annualPremium;

            //Pago Unico  
            Initial = TotalPremium - (TotalPremium * PorcPagoUnico);
            var pagoUnico = new itemProjectionPayment
            {
                Numero = 1,
                Inicial = Initial,
                Cuotas = string.Empty
            };

            result.Add(pagoUnico);

            //Inicial + 4 Cuotas
            Initial = TotalPremium * PorcPagoInicial;
            Cuotas = (TotalPremium - Initial) / 4;
            var Inititial4Quotes = new itemProjectionPayment
            {
                Numero = 2,
                Inicial = Initial,
                Cuotas = string.Format("4 cuotas de {0}", Cuotas.ToString(NumberFormat, CultureInfo.InvariantCulture))
            };

            result.Add(Inititial4Quotes);

            //Inicial + 4 Cuotas Automaticas
            Initial = TotalPremium * PorcPagoInicial;
            Cuotas = (TotalPremium - Initial) / 4;
            var CuotaFinal = Cuotas - (TotalPremium * PorcPagoAutomatico);
            var Inititial4QuotesAutomatic = new itemProjectionPayment
            {
                Numero = 3,
                Inicial = Initial,
                Cuotas = string.Format("3 cuotas de {0} y la ultima de {1}", Cuotas.ToString(NumberFormat, CultureInfo.InvariantCulture), CuotaFinal.ToString(NumberFormat, CultureInfo.InvariantCulture))
            };

            result.Add(Inititial4QuotesAutomatic);
            try
            {
                //Inicial + Financiamiento a 11 meses            
                //Obtener la tabla de amortizacion de KCO
                double Principal = (double)ParameterFinancingPercent;
                var loanType = "VehicleInsurance";
                var resultGetAmortizationTable = oVirtualOfficeProxy.GetAmortizationTable((double)annualPremium, 11, loanType, Convert.ToInt32(ParameterFinancingPercent), (double)annualPremium);

                var financedInitial = (decimal)resultGetAmortizationTable.productCalculatorResult.AmotizationTable.FirstOrDefault(k => k.PeriodNumber == 0).Payment;
                Cuotas = (decimal)resultGetAmortizationTable.productCalculatorResult.AmotizationTable.LastOrDefault().Payment;
                var Financed = new itemProjectionPayment
                {
                    Numero = 4,
                    Inicial = financedInitial,
                    Cuotas = string.Format("11 cuotas de {0}", Cuotas.ToString(NumberFormat, CultureInfo.InvariantCulture))
                };

                result.Add(Financed);
            }
            catch (Exception)
            {
                var Financed = new itemProjectionPayment
                {
                    Numero = 4,
                    Inicial = 0,
                    Cuotas = "Información no dispobible"
                };

                result.Add(Financed);
            }


            return
                 result;
        }

        public void DeleteFileOfQuotation(string quotName)
        {
            System.IO.File.Delete(quotName);
        }

        private string getInvoiceTypes(int invoiceTypeId)
        {
            var param = oDropDownManager.GetParameter("PARAMETER_KEY_TYPE_INVOICE").Value;

            Dictionary<int, string> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(param);

            var x = values.FirstOrDefault(z => z.Key == invoiceTypeId);
            string text = "";
            if (x.Key > 0)
            {
                text = x.Value;
            }

            return text;
        }
    }
}