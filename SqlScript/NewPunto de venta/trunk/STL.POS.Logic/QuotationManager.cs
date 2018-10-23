﻿using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class QuotationManager : BaseManager
    {
        private readonly QuotationRepository quotationRepository;

        public QuotationManager()
        {
            quotationRepository = new QuotationRepository();
        }

        public Dictionary<int, int> getJobsByDesc(string desc)
        {
            return
               base.baseRepository.getJobsByDesc(desc);
        }

        public int GetMappingInfo(int type, string posId, int defaultId = 1)
        {
            BaseRepository.MappingElementType EResult;
            Enum.TryParse(type.ToString(), out EResult);

            return
                base.baseRepository.GetMappingInfo(EResult, posId, defaultId);
        }

        #region Set
        public BaseEntity SetQuotation(Quotation.parameter parameter)
        {
            return
                    quotationRepository.SetQuotation(parameter);
        }

        public int SetQuotationDeclined()
        {
            return quotationRepository.SetQuotationDeclined();
        }

        #endregion

        #region Get
        public Quotation GetQuotation(int? quotationID, string quotationNumber = "", string policyNumber = "")
        {
            return
                quotationRepository.GetQuotation(quotationID, quotationNumber, policyNumber);
        }

        public IEnumerable<Driver> GetQuotationDrivers(int quotationId)
        {
            return
                quotationRepository.GetQuotationDrivers(quotationId);
        }

        public IEnumerable<Coverage> GetQuotationCoverage(int? vehicleId, int Filtro)
        {
            return
                quotationRepository.GetQuotationCoverage(vehicleId, Filtro);
        }

        public IEnumerable<VehicleProduct> GetQuotationVehicles(int quotationID)
        {
            return
                quotationRepository.GetQuotationVehicles(quotationID);
        }

        public IEnumerable<ProductLimits> GetQuotationProductLimits(int vehicleID)
        {
            return
               quotationRepository.GetQuotationProductLimits(vehicleID);
        }

        public IEnumerable<ServicesTypes> GetQuotationServicesTypes(int quotationID)
        {
            return
                quotationRepository.GetQuotationServicesTypes(quotationID);
        }

        public IEnumerable<Coverage> GetQuotationServices(int quotationID)
        {
            return
                quotationRepository.GetQuotationServices(quotationID);
        }

        public IEnumerable<Coverage> GetQuotationCoverageDetail(int quotationID)
        {
            return
                quotationRepository.GetQuotationCoverageDetail(quotationID);
        }

        public bool getQuotationToNotValidate(string QuotationNumber)
        {
            return
                quotationRepository.getQuotationToNotValidate(QuotationNumber);
        }
        public IEnumerable<Quotation> GetQuotations(int? userType, string currentUserName = "", string quotationNumber = "", string principalName = "", string identification = "", string p_agents = "", bool? filtrarAgentes = false)
        {
            return
                quotationRepository.GetQuotations(userType, currentUserName, quotationNumber, principalName, identification, p_agents, filtrarAgentes);
        }

        public Quotation.Payment GetQuotationPaymentInfo(int quotationId)
        {
            return
                quotationRepository.GetQuotationPaymentInfo(quotationId);
        }

        public Quotation.PaymentCheckOut GetQuotationPaymentInfoViewModel(int quotationId)
        {
            Quotation.PaymentCheckOut result;
            Quotation.Payment temp;

            temp = this.GetQuotationPaymentInfo(quotationId);

            result = new Quotation.PaymentCheckOut
            {
                PaymentWay = temp.PaymentWay,
                PaymentFrequencyId = temp.PaymentFrequencyId,
                AmountToPayEnteredByUser = temp.AmountToPayEnteredByUser.DecimalToString(),
                TotalPrime = temp.TotalPrime.DecimalToString(),
                TotalISC = temp.TotalISC.DecimalToString(),
                ISCPercentage = temp.ISCPercentage.DecimalToString(),
                TotalDiscount = temp.TotalDiscount.DecimalToString(),
                DiscountPercentage = temp.DiscountPercentage.DecimalToString(),
                FlotillaDiscountPercent = temp.FlotillaDiscountPercent.DecimalToString(),
                TotalFlotillaDiscount = temp.TotalFlotillaDiscount.DecimalToString(),
                Messaging = temp.Messaging,
                TotalPrimeToDiscount = temp.TotalPrimeToDiscount.DecimalToString(),
                Total = temp.Total.DecimalToString(),
                MinimunAmountToPay = temp.MinimunAmountToPay.DecimalToString(),
                FlotillaDiscount = temp.TotalFlotillaDiscount.HasValue && temp.TotalFlotillaDiscount.Value > 0,
                PaymentFrequencyDropDown = temp.PaymentFrequencyDropDown,
                QuotationDailyNumber = temp.QuotationDailyNumber,
                couponCode = temp.couponCode,
                couponPercentageDiscount = ((temp.TotalPrime - temp.TotalFlotillaDiscount) * (temp.couponPercentageDiscount/100)).DecimalToString()
            };

            return
                result;
        }

        public IEnumerable<Quotation.ProductExcludeAgent> GetProductExcludeByAgent(string AgentCode)
        {
            return
               quotationRepository.GetProductExcludeByAgent(AgentCode);
        }
        public string ValidateRiskLevel()
        {
            var result = "";
          
            return result;
        }
        #endregion
    }
}