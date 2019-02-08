using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class VehicleInformationViewModels : BaseViewModels
    {
        public IEnumerable<VehicleInformationView> VehicleInformationView { get; set; }
    }

    public class VehicleInformationView
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public decimal? Percent { get; set; }
        public decimal? Amount { get; set; }
        public int ContractId { get; set; }
        public int EstadoId { get; set; }
        //public VehicleInformationDetail VehicleInformationDetail { get; set; }
        public VehicleInformationType VehicleInformationType { get; set; }
        public Contract Contract { get; set; }
        public Estado Estado { get; set; }
    }

    public class VehicleInformationType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Contract
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Estado
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}