using System;
using System.Collections.Generic;

namespace WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models
{
    public class ParticularsConditionsData
    {
        public string OwnerName { get; set; }
        public string OwnerIdentificationType { get; set; }
        public string OwnerIdentification { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
        public string DriverName { get; set; }
        public string DriverIdentificationType { get; set; }
        public string DriverIdentification { get; set; }
        public string DriverBirthDate { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }
        public string AuthorizationDate { get; set; }
        public string EmissionDate { get; set; }
        public string QuotDate { get; set; }
        public string QuotNumber { get; set; }
        public string FeesNumber { get; set; }
        public string VehiclesNumber { get; set; }
        public string Office { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleType { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleChassis { get; set; }
        public string VehicleRegistry { get; set; }
        public string VehicleUse { get; set; }
        public string VehicleCilindres { get; set; }
        public string VehiclePassengersNo { get; set; }
        public string VehicleValue { get; set; }
        public string VehiclePlan { get; set; }
        public string VehicleClosure { get; set; }
        public List<Coverage> ListThirdDamage { get; set; }
        public List<Coverage> ListOwnDamage { get; set; }
        public List<Coverage> ListSuplement { get; set; }
        public decimal ThirdDamageTotalPremium { get; set; }
        public decimal OwnDamageTotalPremium { get; set; }
        public decimal SuplementTotalPremium { get; set; }
        public decimal Tax { get; set; }
        public decimal CoverageTotalPremium { get { return ThirdDamageTotalPremium + OwnDamageTotalPremium + SuplementTotalPremium; } }
        public DateTime AgreementDate { get; set; }
        public decimal MovementTotalPremium { get; set; }

        public class Coverage
        {
            public string CoverageDescription { get; set; }
            public string CoverageNameKey { get; set; }
            public decimal Premium { get; set; }
            public decimal Limit { get; set; }
            public decimal Deductible { get; set; }
            public decimal MinimumDeductible { get; set; }
        }
    }
}