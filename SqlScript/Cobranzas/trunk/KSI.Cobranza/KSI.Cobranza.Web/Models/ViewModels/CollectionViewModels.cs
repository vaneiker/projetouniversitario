using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class CollectionViewModels : BaseModel
    {
        public long? accountId { get; set; }    
        public string _dataRequest { get; set; }
        public decimal? PaidTotal { get; set; }
        public IEnumerable<CollectionHistoryPaymentViewModels> CollectionHistoryPaymentViewModels { get; set; }
        public IEnumerable<CollectionPaymentViewModels> CollectionPaymentViewModels { get; set; }
        public CardDomitiliationViewModel CardDomitiliationViewModel { get; set; }
    }  

    public class CollectionHistoryPaymentViewModels
    {
        public int? QuotaNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? QuotaAmount { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? PaidAmount { get; set; }
    }

    public class CollectionPaymentViewModels
    {
        public int? QuotaNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? QuotaAmount { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? QuotaAmountBalance { get; set; }
        public decimal AmountToPay { get; set; }
        public decimal LatePay { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }

    public class dataRequestCard
    {
        public long? accountId { get; set; }
        public long? clientId { get; set; }
        public int? CardTypeId { get; set; }
        public string LastFourDigits { get; set; }
    }

    public class CardDomitiliationViewModel
    {
        public CardDomitiliationViewModel()
        {
            CardHolder = string.Empty;
            CardNumber = string.Empty;
            CardTypeId = -1;
            StatusId = -1;
            CardExpirationYear = -1;
            CardExpirationMonth = -1;
        }

        [Required(ErrorMessage = "El campo Tipo de Tarjeta es Requerido")]
        public int CardTypeId { get; set; }
        public string CardTypeDesc { get; set; }
        [Required(ErrorMessage = "El campo Status es Requerido")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "El campo Número de Tarjeta es requerido")]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "Debe ser entre 12 a 19 digitos")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "El campo Tarjetahabiente es requerido")]
        public string CardHolder { get; set; }
        [Required(ErrorMessage = "El campo Año de Expiración es requerido")]
        public int CardExpirationYear { get; set; }
        [Required(ErrorMessage = "El campo Mes de Expiración es requerido")]
        public int CardExpirationMonth { get; set; }
        public long CustomerId { get; set; }
        public long AccountId { get; set; }
        public string LastFourDigits { get; set; }
        public string StatusDesc { get; set; }
        public string ExpirationDate { get; set; }
        public List<BaseViewModels.KeyValue> CardTypes { get; set; }
        public List<BaseViewModels.KeyValue> StatusTypes { get; set; }
        public List<BaseViewModels.KeyValue> Years { get; set; }
        public List<BaseViewModels.KeyValue> Months { get; set; }
        public IEnumerable<CardDomitiliationViewModel> AffiliateCards { get; set; }
        public string IsEditMode { get; set; }
        public string _dataRequest { get; set; }
    }

}