using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class GuaranteeViewModels : BaseViewModels
    {
        public IEnumerable<Guarantee> GuaranteeList { get; set; }
        public IEnumerable<KeyValue> vehicleInformationDetail { get; set; }
    }

    public class VehicleInformationDetail
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Plate { get; set; }
        public string Chassis { get; set; }
        public string Color { get; set; }
        public string Registry { get; set; }
        public string Especifications { get; set; }
        public string VehicleTypeName { get; set; }
    }

    public class Guarantee
    {
        public long GuaranteeNumber { get; set; }
        public string GuaranteeName { get; set; }
        public string GuaranteeType { get; set; }
        public decimal? GuaranteePercentage { get; set; }
        public decimal? GuaranteeAmount { get; set; }
        public long? GuaranteeContract { get; set; }
        public string GuaranteeStatus { get; set; }
    }
}