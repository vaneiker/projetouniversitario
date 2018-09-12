using System.Collections.Generic;
using System.Data;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IHealth
    {
        Health.Policy.Premium SetHealthPolicyPremium(Health.Policy.Premium parameter);
        Health.Policy.Member.CoveragePremium SetHealthPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter);
        IEnumerable<Health.Policy.Member.CoveragePremium> GetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter);
        IEnumerable<Health.BenefitPlan> GetBenefitPlan(Health.BenefitPlan.Key parameter);
    }
}
