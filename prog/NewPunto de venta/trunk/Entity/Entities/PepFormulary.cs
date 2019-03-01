﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class PepFormulary
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> PersonsID { get; set; }
        public string name { get; set; }
        public Nullable<int> RelationshipId { get; set; }
        public string Position { get; set; }
        public Nullable<int> FromYear { get; set; }
        public Nullable<int> ToYear { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Action { get; set; }
        public Nullable<int> BeneficiaryId { get; set; }
        public bool IsPepManagerCompany { get; set; }
        public Nullable<int> PepFormularyOptionsId { get; set; }

        public class Parameter
        {
            public Nullable<int> id {get; set;}
            public string action { get; set; }
            public Nullable<int> BeneficiaryId { get; set; }
            public bool IsPepManagerCompany { get; set; }
        }
    }
}