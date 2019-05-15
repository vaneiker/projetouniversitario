using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace STL.POS.Data
{

    public class PercentageDTO
    {
        public decimal amount { get; set; }

        public string text { get; set; }
    }

    [Table("VEHICLE_PRODUCT")]
    public class VehicleProduct
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string VehicleDescription { get; set; }

        public int? Year { get; set; }
        public byte? Cylinders { get; set; }
        public string Passengers { get; set; }
        public int? Weight { get; set; }

        public string Chassis { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public decimal VehiclePrice { get; set; }
        public decimal? InsuredAmount { get; set; }
        public decimal? PercentageToInsure { get; set; }

        public decimal? TotalPrime { get; set; }

        public decimal? TotalIsc { get; set; }

        public decimal? TotalDiscount { get; set; }

        public int? SelectedVehicleTypeId { get; set; }

        public string SelectedVehicleTypeName { get; set; }

        public int? SelectedProductCoreId { get; set; }

        public string SelectedProductName { get; set; }

        public int? SelectedCoverageCoreId { get; set; }

        public string SelectedCoverageName { get; set; }

        public int? VehicleTypeCoreId { get; set; }

        public string VehicleYearOld { get; set; }

        public string VehicleTypeName { get; set; }

        public string VehicleMakeName { get; set; }

        public ST_VEHICLE_MODEL VehicleModel { get; set; }

        public Driver Driver { get; set; }

        public int UsageId { get; set; }

        public string UsageName { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public decimal? SurChargePercentage { get; set; }

        public string NumeroFormulario { get; set; }

        public string RateJson { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }

        public int? SecuenciaVehicleSysflex { get; set; }

        public Nullable<Boolean> IsFacultative { get; set; }
        public Nullable<decimal> AmountFacultative { get; set; }

        public Nullable<int> VehicleQuantity { get; set; }


        public ICollection<VehicleTypeWS> VehicleTypes { get; set; }

        public ICollection<PercentageDTO> Percentages { get; set; }

        public ICollection<ProductLimit> ProductLimits { get; set; }

        public ICollection<DeductibleValues> Deductibles { get; set; }
    }
}