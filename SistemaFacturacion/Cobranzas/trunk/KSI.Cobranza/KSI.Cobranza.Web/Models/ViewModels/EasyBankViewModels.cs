using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class EasyBankViewModels : BaseViewModels
    {
        public string DetalleCuota { get; set; }
        public int NoRecibo { get; set; }
        public decimal SaldoPrestamo { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}