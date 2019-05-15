using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    public enum QuotationStatus : byte
    {
        InProgress,
        Finalized,
    }

    public enum QuotationCardnetStatus
    {
        NotSent,
        AuthorizationSuccessfull,
        AuthorizationCancelled
    }

    public enum AchAccountType
    {
        Ahorro = 0,
        Corriente
    }

    public enum PaymentWay
    {
        Cash = 1,
        CreditCard = 2,
        ACH = 3,

    }

    public class itemProjectionPayment
    {
        public int Numero { get; set; }
        public decimal Inicial { get; set; }
        public string Cuotas { get; set; }
    }

    [Table("QUOTATION")]
    public abstract class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public BusinessLine BusinessLine { get; set; }

        public string ProductNumber { get; set; }

        public int QuotationDailyNumber { get; set; }

        public string QuotationNumber { get; set; }

        public string PolicyNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public TermType TermType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // Payment section
        public int? PaymentFrequencyId { get; set; }

        public string PaymentFrequency { get; set; }

        public PaymentWay? PaymentWay { get; set; }

        public decimal? AmountToPayEnteredByUser { get; set; }

        public string CardnetLastResponseCode { get; set; }

        public string CardnetLastResponseMessage { get; set; }

        public string CardnetAuthorizationCode { get; set; }

        public QuotationCardnetStatus CardnetPaymentStatus { get; set; }

        public decimal? TotalPrime { get; set; }

        public decimal? TotalISC { get; set; }

        public decimal? ISCPercentage { get; set; }

        public decimal? TotalDiscount { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? AmountPaid
        {
            get
            {
                return TotalPrime.GetValueOrDefault(0) + TotalISC.GetValueOrDefault(0) - TotalDiscount.GetValueOrDefault(0);
            }
        }

        public decimal? QuotationCoreIdNumber { get; set; }

        public decimal? ClientCoreIdNumber { get; set; }

        public bool SendInspectionOnly { get; set; }

        /// <summary>
        /// Nombre del Cuenta Habiente
        /// </summary>
        public string AchName { get; set; }

        /// <summary>
        /// Nro Identificación Cuenta Habiente
        /// </summary>
        public string AchAccountHolderGovId { get; set; }

        /// <summary>
        /// Routing Number
        /// </summary>
        public string AchBankRoutingNumber { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        public AchAccountType AchType { get; set; }

        /// <summary>
        /// Número de cuenta
        /// </summary>
        public string AchNumber { get; set; }

        public User User { get; set; }

        public abstract string GetPrincipalName();

        public string PrincipalFullName { get; set; }

        public Currency Currency { get; set; }

        public string CurrencySymbol { get; set; }

        public string QuotationProduct { get; set; }

        public string PrincipalIdentificationNumber { get; set; }

        public int LastStepVisited { get; set; }

        public bool Messaging { get; set; }
        public bool Declined { get; set; }

        public decimal? FlotillaDiscountPercent { get; set; }
        public decimal? TotalFlotillaDiscount { get; set; }

        public string QuotationCoreNumber { get; set; }

        public int? Modi_UserId { get; set; }
        public DateTime? Modi_Date { get; set; }

        public int? qtyDayOfVigency { get; set; } 

        public abstract string GetPrincipalEmail();

        public abstract string GetQuotationProduct();

        public abstract Person GetPrincipal();

        [Required]
        public QuotationStatus Status { get; set; }

        public bool? Financed { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public int? Period { get; set; }
        public int? Credit_Card_Type_Id { get; set; }
        public string Credit_Card_Number_Key { get; set; }
        public string Credit_Card_Number { get; set; }
        public int? Expiration_Date_Year { get; set; }
        public int? Expiration_Date_Month { get; set; }
        public string Card_Holder { get; set; }
        public bool? Domiciliation { get; set; }
        public int? Request_Type_Id { get; set; }
        public bool? DomicileInitialPayment { get; set; }
    }
}
