﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Requeriments : BaseEntity
    {
        public int RequirementTypeId { get; set; }
        public string RequirementTypeDesc { get; set; }
        public string OnBaseNameKey { get; set; }
        public bool Required { get; set; }
        public Nullable<int> QuotationId { get; set; }
        public Nullable<int> DocumentId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public string DocumentName { get; set; }
        public bool Validated { get; set; }
        public Nullable<int> ValidatedUsrId { get; set; }
        public Nullable<int> CreateUsrId { get; set; }
        public string ValidatedUserName { get; set; }
        public string CreateUserName { get; set; }

        public class GetRequerimentsParameters
        {
            public Nullable<int> quotationId { get; set; }
            public Nullable<int> documentId { get; set; }
            public string RiskLevel { get; set; }
        }

        public class SetRequerimentsParameters
        {
            public int quotationId { get; set; }
            public Nullable<int> documentId { get; set; }
            public int requirementTypeId { get; set; }
            public Nullable<int> vehicleId { get; set; }
            public Nullable<int> personId { get; set; }
            public byte[] documentBinary { get; set; }
            public string documentName { get; set; }
            public int userId { get; set; }
            public bool validated { get; set; }
        }

        public class Documents
        {
            public int QuotationId { get; set; }
            public int DocumentId { get; set; }
            public byte[] DocumentBinary { get; set; }
        }
    }
}