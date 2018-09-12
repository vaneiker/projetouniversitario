using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class HealthManager
    {
        private HealthRepository _healthRepository;

        public HealthManager()
        {
            _healthRepository = SingletonUnitOfWork.Instance.HealthRepository;
        }

        public virtual Health.Policy.Premium SetPolicyPremium(Health.Policy.Premium parameter)
        {
            return
                _healthRepository.SetPolicyPremium(parameter);
        }
        public virtual Health.Policy.Member.CoveragePremium SetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            return
                _healthRepository.SetPolicyMemberCoveragePremium(parameter);
        }
        public virtual IEnumerable<Health.Policy.Member.CoveragePremium> GetPolicyMemberCoveragePremium(Health.Policy.Member.CoveragePremium parameter)
        {
            return
                _healthRepository.GetPolicyMemberCoveragePremium(parameter);
        }

        public virtual IEnumerable<Health.BenefitPlan> GetBenefitPlan(Health.BenefitPlan.Key parameter)
        {
            return
                _healthRepository.GetBenefitPlan(parameter);
        }
        
    }
}
