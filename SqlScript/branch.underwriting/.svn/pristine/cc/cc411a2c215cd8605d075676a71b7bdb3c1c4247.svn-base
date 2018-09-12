using System;
using System.Collections.Generic;
using System.Data;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class HealthBll : IHealth
    {
        private HealthManager _healthManager;

        public HealthBll()
        {
            _healthManager = new HealthManager();
        }

        Health.Policy.Premium IHealth.SetHealthPolicyPremium(Health.Policy.Premium parameter)
        {
            return
                _healthManager.SetPolicyPremium(parameter);
        }

        Health.Policy.Member.CoveragePremium IHealth.SetHealthPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            return
                _healthManager.SetPolicyMemberCoveragePremium(parameter);
        }

        IEnumerable<Health.Policy.Member.CoveragePremium> IHealth.GetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            return
                _healthManager.GetPolicyMemberCoveragePremium(parameter);
        }

        IEnumerable<Health.BenefitPlan> IHealth.GetBenefitPlan(Health.BenefitPlan.Key parameter)
        {
            return
                _healthManager.GetBenefitPlan(parameter);
        }
    }

    public class HealthWS : IHealth
    {
        Health.Policy.Premium IHealth.SetHealthPolicyPremium(Health.Policy.Premium parameter)
        {
            throw new NotImplementedException();
        }

        Health.Policy.Member.CoveragePremium IHealth.SetHealthPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Health.Policy.Member.CoveragePremium> IHealth.GetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Health.BenefitPlan> IHealth.GetBenefitPlan(Health.BenefitPlan.Key parameter)
        {
            throw new NotImplementedException();
        }
    }
}
