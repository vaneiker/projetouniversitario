using KSI.Cobranza.Web.Common.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class PaymentProcessViewModels : BaseViewModels
    {
        [Required(ErrorMessage = "El campo Tipo de Tarjeta es Requerido")]
        public int CardTypeId { get; set; }

        public string CardTypeDesc { get; set; }

        [Required(ErrorMessage = "El campo Número de Tarjeta es requerido")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "El campo Tarjetahabiente es requerido")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "El campo Año de Expiración es requerido")]
        public int CardExpirationYear { get; set; }

        [Required(ErrorMessage = "El campo Mes de Expiración es requerido")]
        public int CardExpirationMonth { get; set; }

        public decimal? Balance { get; set; }

        public decimal? share { get; set; }

        [Required(ErrorMessage = "El campo CVV es requerido")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "El campo Monto a Cobrar es requerido")]
        [DependencyNumericValueValidator("share","El campo Monto a cobrar no debe ser mayor a la cuota",DependencyNumericValueValidator.LogicOperatorType.MenorOIgual)]
        public decimal? AmountReceivable { get; set; }

        public long CustomerId { get; set; }

        public long AccountId { get; set; }

        public List<BaseViewModels.KeyValue> CardTypes { get; set; }

        public List<BaseViewModels.KeyValue> Years { get; set; }

    }
}