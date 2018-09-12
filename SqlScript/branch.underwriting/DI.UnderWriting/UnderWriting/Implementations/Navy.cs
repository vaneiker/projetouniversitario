using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class NavyBll : INavy
    {
        private NavyManager _navyManager;

        public NavyBll()
        {
            _navyManager = new NavyManager();
        }

        Navy.Insured.Key INavy.SetNavyInsured(Navy.Insured parameter)
        {
            return
                _navyManager.SetNavyInsured(parameter);
        }

        Navy.Insured.Coverage.Key INavy.SetNavyInsuredCoverage(Navy.Insured.Coverage parameter)
        {
            return
                _navyManager.SetNavyInsuredCoverage(parameter);
        }

        IEnumerable<Navy.Insured> INavy.GetNavyInsured(Navy.Insured.Key parameter)
        {
            return
               _navyManager.GetNavyInsured(parameter);
        }

        IEnumerable<Navy.Insured.Coverage> INavy.GetNavyInsuredCoverage(Navy.Insured.Coverage.Key parameter)
        {
            return
               _navyManager.GetNavyInsuredCoverage(parameter);
        }

        IEnumerable<Navy.Insured.Coverage.Surcharge> INavy.GetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge.Key parameter)
        {
            return
               _navyManager.GetNavyInsuredCoverageSurcharge(parameter);
        }

        IEnumerable<Navy.Insured.Discount> INavy.GetNavyInsuredDiscount(Navy.Insured.Discount.Key parameter)
        {
            return
               _navyManager.GetNavyInsuredDiscount(parameter);
        }

        Navy.Insured.Coverage.Surcharge.Key INavy.SetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge parameter)
        {
            return
               _navyManager.SetNavyInsuredCoverageSurcharge(parameter);
        }

        Navy.Insured.Discount.Key INavy.SetNavyInsuredDiscount(Navy.Insured.Discount parameter)
        {
            return
               _navyManager.SetNavyInsuredDiscount(parameter);
        }

        int INavy.SetNavyInsuredApplyDiscountAndSurcharge(Navy.Insured parameter)
        {
            return
               _navyManager.SetNavyInsuredApplyDiscountAndSurcharge(parameter);
        }


        Navy.Insured.Engine INavy.SetNavyInsuredEngine(Navy.Insured.Engine parameter)
        {
            return
               _navyManager.SetNavyInsuredEngine(parameter);
        }

        IEnumerable<Navy.Insured.Engine> INavy.GetNavyInsuredEngine(Navy.Insured.Engine.parameter parameter)
        {
            return
               _navyManager.GetNavyInsuredEngine(parameter);
        }
    }

    public class NavyWS : INavy
    {
        Navy.Insured.Key INavy.SetNavyInsured(Navy.Insured parameter)
        {
            throw new NotImplementedException();
        }

        Navy.Insured.Coverage.Key INavy.SetNavyInsuredCoverage(Navy.Insured.Coverage parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Navy.Insured> INavy.GetNavyInsured(Navy.Insured.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Navy.Insured.Coverage> INavy.GetNavyInsuredCoverage(Navy.Insured.Coverage.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Navy.Insured.Coverage.Surcharge> INavy.GetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Navy.Insured.Discount> INavy.GetNavyInsuredDiscount(Navy.Insured.Discount.Key parameter)
        {
            throw new NotImplementedException();
        }

        Navy.Insured.Coverage.Surcharge.Key INavy.SetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge parameter)
        {
            throw new NotImplementedException();
        }

        Navy.Insured.Discount.Key INavy.SetNavyInsuredDiscount(Navy.Insured.Discount parameter)
        {
            throw new NotImplementedException();
        }

        int INavy.SetNavyInsuredApplyDiscountAndSurcharge(Navy.Insured parameter)
        {
            throw new NotImplementedException();
        }


        Navy.Insured.Engine INavy.SetNavyInsuredEngine(Navy.Insured.Engine parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Navy.Insured.Engine> INavy.GetNavyInsuredEngine(Navy.Insured.Engine.parameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
