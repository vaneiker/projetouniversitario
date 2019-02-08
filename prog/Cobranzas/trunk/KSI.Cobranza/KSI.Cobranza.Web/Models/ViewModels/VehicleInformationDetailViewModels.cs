using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class VehicleInformationDetailViewModels : BaseViewModels
    {
        IEnumerable<VehicleInformationDetail> VehicleInformationDetail { get; set; }
    }

    

    public class VehicleMake
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class VehicleModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class VehicleType
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}