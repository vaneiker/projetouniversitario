using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IBail
    {
        Bail.Insured.Key SetBailInsured(Bail.Insured parameter);
        Bail.Insured.Coverage.Key SetBailInsuredCoverage(Bail.Insured.Coverage parameter);

        IEnumerable<Bail.Insured> GetBailInsured(Bail.Insured.Key parameter);
        IEnumerable<Bail.Insured.Coverage> GetBailInsuredCoverage(Bail.Insured.Coverage.Key parameter);
        IEnumerable<Bail.Insured.Coverage.Surcharge> GetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge.Key parameter);
        IEnumerable<Bail.Insured.Discount> GetBailInsuredDiscount(Bail.Insured.Discount.Key parameter);
        Bail.Insured.Coverage.Surcharge.Key SetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge parameter);
        Bail.Insured.Discount.Key SetBailInsuredDiscount(Bail.Insured.Discount parameter);
        int SetBailInsuredApplyDiscountAndSurcharge(Bail.Insured parameter);

        IEnumerable<Bail.Insured.Guarantors> GetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter);
        Bail.Insured.Guarantors.Key SetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter);
    }
}
