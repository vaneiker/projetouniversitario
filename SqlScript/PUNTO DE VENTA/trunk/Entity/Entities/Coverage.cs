﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Coverage : BaseEntity
    {
        public string CoverageType { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public Nullable<int> CoverageDetailCoreId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> MinDeductible { get; set; }
        public Nullable<int> SelfDamagesToProductLimits { get; set; }
        public Nullable<int> ThirdPartyToProductLimits { get; set; }
        public Nullable<int> ServiceType_Id { get; set; }
        public Nullable<decimal> Limit { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<decimal> Deductible { get; set; }
        public int vehilceID { get; set; }
        public Nullable<decimal> coveragePercentage { get; set; }
        public string baseDeductible { get; set; }
        public Nullable<bool> AllowsToSummarize { get; set; }

        public class Parameter
        {
            public Nullable<int> id { get; set; }
            public Nullable<bool> isSelected { get; set; }
            public Nullable<int> coverageDetailCoreId { get; set; }
            public string name { get; set; }
            public Nullable<decimal> amount { get; set; }
            public Nullable<decimal> minDeductible { get; set; }
            public Nullable<int> selfDamagesToProductLimits { get; set; }
            public Nullable<int> thirdPartyToProductLimits { get; set; }
            public Nullable<int> serviceType_Id { get; set; }
            public Nullable<decimal> limit { get; set; }
            public Nullable<int> userId { get; set; }
            public Nullable<decimal> deductible { get; set; }
            public Nullable<decimal> coveragePercentage{get;set;}
            public string baseDeductible { get; set; }
            public Nullable<bool> allowsToSummarize { get; set; }
        }
    }
}
