using Declarative.Invoicing.Data.Repository;
using Declarative.Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Logic
{
    public class PolicyManager : BaseManager
    {
        private readonly PolicyRepository policyRepository;

        public PolicyManager()
        {
            policyRepository = new PolicyRepository();
        }

        #region Get

        //public IEnumerable<Policy> GetPolicyInfo(int driverID)
        //{
        //    return
        //        policyRepository.GetPolicyInfo(driverID);
        //}

        #endregion
    }
}
