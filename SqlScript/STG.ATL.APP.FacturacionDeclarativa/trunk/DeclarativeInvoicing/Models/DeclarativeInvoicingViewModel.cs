using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Declarative.Invoicing.Models
{
    public class DeclarativeInvoicingViewModel
    {
        public List<VehiclesFromPolicy> _vehicles { get; set; }
        public PolicyInfo _policyInfo { get; set; }
        public List<InvoicingHistoric> _invoicingHistoric { get; set; }
        public InvoicingResume _invoicingResume { get; set; }
        public string _billingInformation { get; set; }

        public class PolicyInfo
        {
            public string Policy { get; set; }
            public string Insured { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string InsuredAmount { get; set; }
            public int? Office { get; set; }
            public decimal? CoreQuotation{ get; set; }
            public int? Agent { get; set; }

        }

        public class InvoicingHistoric
        {

        }

        public class InvoicingResume
        {
            public string InvoicingPeriod { get; set; }
            public string SubTotal { get; set; }
            public string Itbis { get; set; }
            public string TotalToPay { get; set; }
        }

        public class VehiclesFromPolicy
        {
            public string Ano { get; set; }
            public string Cliente { get; set; }
            public decimal Cotizacion { get; set; }
            public string DescripcionSubramo { get; set; }
            public string EstatusItem { get; set; }
            public System.Nullable<System.DateTime> FechaAdicion { get; set; }
            public string IdMarca { get; set; }
            public string Idmodelo { get; set; }
            public System.Nullable<int> Item { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Poliza { get; set; }
            public System.Nullable<decimal> Prima { get; set; }
            public System.Nullable<int> Ramo { get; set; }
            public System.Nullable<int> SubRamo { get; set; }
            public string chasis { get; set; }
            public string color { get; set; }
            public string placa { get; set; }

            public System.Nullable<decimal> ProrrataMensual { get; set; }
            public Nullable<System.DateTime> FechaInclusion { get; set; }
            public Nullable<System.DateTime> FechaExlusion { get; set; }

        }



    }
}