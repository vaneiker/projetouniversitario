using Entity.Entities;
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

        public int SetQuotationDeclined(int quotationId, int reasonDeclined, int userId, string reasonComment = "")
        {
            return quotationRepository.SetQuotationDeclined(quotationId, reasonDeclined, userId, reasonComment);
        }

        public virtual int SetQuotationNote(int quotationId, int noteReasonId, string Note, int userId)
        {
            return quotationRepository.SetQuotationNote(quotationId, noteReasonId, Note, userId);
        }

        public virtual int SendQuotationNotesToGlobal(int quotationId, int? NoteId)
        {
            return quotationRepository.SendQuotationNotesToGlobal(quotationId, NoteId);
        }

        public int SetLogVisits(LogVisits parameter)
        {
            return quotationRepository.SetLogVisits(parameter);
        }

        public int SetQuotationReferred(Quotation.QuotationReferred parameters)
        {
            return quotationRepository.SetQuotationReferred(parameters);
        }

        public int DeleteQuotationReferred(int quotationId)
        {
            return quotationRepository.DeleteQuotationReferred(quotationId);
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


            var dataQuotation = GetQuotation(quotationId);
            bool isDomiciliation = dataQuotation.Domiciliation.GetValueOrDefault();


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
                couponPercentageDiscount = ((temp.TotalPrime - temp.TotalFlotillaDiscount) * (temp.couponPercentageDiscount / 100)).DecimalToString(),

                sumAllDiscount = (
                                    (temp.TotalFlotillaDiscount) +
                                    ((temp.TotalPrime - temp.TotalFlotillaDiscount) * (temp.couponPercentageDiscount / 100))
                                   ).DecimalToString(),

                PaymentFrequencyId_Dom = (isDomiciliation && temp.PaymentFrequencyId.GetValueOrDefault() == 4)
                                         ?
                                         4.1M
                                         :
                                         (temp.PaymentFrequencyId.HasValue ? (decimal)temp.PaymentFrequencyId.Value : -1)

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

        public virtual Quotation.VerificationCode GetVerificationCode(string phoneNumber, string verificationCode)
        {
            return
               quotationRepository.GetVerificationCode(phoneNumber, verificationCode);
        }

        public virtual int SetVerificationCode(string phoneNumber, string verificationCode)
        {
            return
               quotationRepository.SetVerificationCode(phoneNumber, verificationCode);
        }

        public virtual IEnumerable<Quotation.QuotationNotes> GetQuotationNotes(int QuotationId)
        {
            return
               quotationRepository.GetQuotationNotes(QuotationId);
        }

        public virtual Quotation.QuotationReferred GetQuotationReferred(int quotationId, int? referredId)
        {
            return quotationRepository.GetQuotationReferred(quotationId, referredId);
        }
        #endregion
    }
}
