﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class VehicleProduct
    {
        public Nullable<int> Id { get; set; }
        public string VehicleDescription { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<byte> Cylinders { get; set; }
        public string Passengers { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Chassis { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> VehiclePrice { get; set; }
        public Nullable<decimal> InsuredAmount { get; set; }
        public Nullable<decimal> PercentageToInsure { get; set; }
        public Nullable<decimal> TotalPrime { get; set; }
        public Nullable<decimal> TotalIsc { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<int> SelectedProductCoreId { get; set; }
        public Nullable<int> VehicleTypeCoreId { get; set; }
        public string SelectedProductName { get; set; }
        public string VehicleTypeName { get; set; }
        public string VehicleMakeName { get; set; }
        public Nullable<int> UsageId { get; set; }
        public string UsageName { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> Driver_Id { get; set; }
        public Nullable<int> VehicleModel_Make_Id { get; set; }
        public Nullable<int> VehicleModel_Model_Id { get; set; }
        public Nullable<int> Quotation_Id { get; set; }
        public Nullable<int> SelectedVehicleTypeId { get; set; }
        public string SelectedVehicleTypeName { get; set; }
        public Nullable<int> SelectedCoverageCoreId { get; set; }
        public string SelectedCoverageName { get; set; }
        public string VehicleYearOld { get; set; }
        public Nullable<decimal> SurChargePercentage { get; set; }
        public string NumeroFormulario { get; set; }
        public string RateJson { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> Modi_Date { get; set; }
        public Nullable<int> SecuenciaVehicleSysflex { get; set; }
        public Nullable<bool> IsFacultative { get; set; }
        public Nullable<decimal> AmountFacultative { get; set; }
        public Nullable<int> VehicleQuantity { get; set; }         
        public string ModelDesc { get; set; }
        public Nullable<long> VehicleNumber { get; set; }
        public Nullable<decimal> ProratedPremium { get; set; }
        public Nullable<int> SelectedVehicleFuelTypeId { get; set; }
        public string SelectedVehicleFuelTypeDesc { get; set; }

        public class Parameter
        {
            public Nullable<int> id{get; set;}
            public Nullable<int> vehicleQuantity { get; set; }
            public Nullable<decimal> ProratedPremium { get; set; }
            public Nullable<int> SelectedVehicleFuelTypeId { get; set; }
            public string SelectedVehicleFuelTypeDesc { get; set; }
        }
    }
}