using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class IdentificationFinalBeneficiary
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> personsID { get; set; }
        public string name { get; set; }
        public Nullable<decimal> percentageParticipation { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<bool> isPEP { get; set; }
        public Nullable<int> pepFormularyOptionsId { get; set; }
        public Nullable<int> IdentityId { get; set; }
        public string IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<int> NationalityCountryId { get; set; }
        public class Parameter
        {
            public Nullable<int> id {get; set;}
            public Nullable<int> personsID {get; set;}
            public string name {get; set;}
            public Nullable<decimal> percentageParticipation {get; set;}
            public Nullable<int> userId { get; set; }
            public Nullable<bool> isPEP { get; set; }
            public Nullable<int> pepFormularyOptionsId { get; set; }
            public Nullable<int> IdentificationTypeId { get; set; }
            public string IdentificationNumber { get; set; }
            public Nullable<int> NationalityCountryId { get; set; }
        }
    }
}
