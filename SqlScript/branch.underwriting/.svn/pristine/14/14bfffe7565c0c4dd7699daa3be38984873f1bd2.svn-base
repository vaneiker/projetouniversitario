using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface INavy
    {
        Navy.Insured.Key SetNavyInsured(Navy.Insured parameter);
        Navy.Insured.Coverage.Key SetNavyInsuredCoverage(Navy.Insured.Coverage parameter);
        IEnumerable<Navy.Insured> GetNavyInsured(Navy.Insured.Key parameter);
        IEnumerable<Navy.Insured.Coverage> GetNavyInsuredCoverage(Navy.Insured.Coverage.Key parameter);
        IEnumerable<Navy.Insured.Coverage.Surcharge> GetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge.Key parameter);
        IEnumerable<Navy.Insured.Discount> GetNavyInsuredDiscount(Navy.Insured.Discount.Key parameter);
        Navy.Insured.Coverage.Surcharge.Key SetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge parameter);
        Navy.Insured.Discount.Key SetNavyInsuredDiscount(Navy.Insured.Discount parameter);
        int SetNavyInsuredApplyDiscountAndSurcharge(Navy.Insured parameter);
        Navy.Insured.Engine SetNavyInsuredEngine(Navy.Insured.Engine parameter);
        IEnumerable<Navy.Insured.Engine> GetNavyInsuredEngine(Navy.Insured.Engine.parameter parameter);
    }
}
