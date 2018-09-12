using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class NavyManager
    {
        private NavyRepository _navyRepository;

        public NavyManager()
        {
            _navyRepository = SingletonUnitOfWork.Instance.NavyRepository;
        }

        public virtual Navy.Insured.Key SetNavyInsured(Navy.Insured parameter)
        {
            return
                _navyRepository.SetNavyInsured(parameter);
        }
        public virtual Navy.Insured.Coverage.Key SetNavyInsuredCoverage(Navy.Insured.Coverage parameter)
        {
            return
               _navyRepository.SetNavyInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Navy.Insured> GetNavyInsured(Navy.Insured.Key parameter)
        {
            return
               _navyRepository.GetNavyInsured(parameter);
        }
        public virtual IEnumerable<Navy.Insured.Coverage> GetNavyInsuredCoverage(Navy.Insured.Coverage.Key parameter)
        {
            return
               _navyRepository.GetNavyInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Navy.Insured.Coverage.Surcharge> GetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge.Key parameter)
        {
            return
               _navyRepository.GetNavyInsuredCoverageSurcharge(parameter);
        }
        public virtual IEnumerable<Navy.Insured.Discount> GetNavyInsuredDiscount(Navy.Insured.Discount.Key parameter)
        {
            return
               _navyRepository.GetNavyInsuredDiscount(parameter);
        }

        public virtual Navy.Insured.Coverage.Surcharge.Key SetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge parameter)
        {
            return
               _navyRepository.SetNavyInsuredCoverageSurcharge(parameter);
        }
        public virtual Navy.Insured.Discount.Key SetNavyInsuredDiscount(Navy.Insured.Discount parameter)
        {
            return
               _navyRepository.SetNavyInsuredDiscount(parameter);
        }

        public virtual int SetNavyInsuredApplyDiscountAndSurcharge(Navy.Insured parameter)
        {
            return
               _navyRepository.SetNavyInsuredApplyDiscountAndSurcharge(parameter);
        }

        public virtual Navy.Insured.Engine SetNavyInsuredEngine(Navy.Insured.Engine parameter)
        {
            return
              _navyRepository.SetNavyInsuredEngine(parameter);
        }

        public virtual IEnumerable<Navy.Insured.Engine> GetNavyInsuredEngine(Navy.Insured.Engine.parameter parameter)
        {
            return
               _navyRepository.GetNavyInsuredEngine(parameter);
        }
    }
}