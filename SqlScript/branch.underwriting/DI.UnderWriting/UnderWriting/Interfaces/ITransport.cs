using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface ITransport
    {
        Transport.Insured.Key SetTransportInsured(Transport.Insured parameter);
        Transport.Insured.Coverage.Key SetTransportInsuredCoverage(Transport.Insured.Coverage parameter);    
        IEnumerable<Transport.Insured> GetTransportInsured(Transport.Insured.Key parameter);
        IEnumerable<Transport.Insured.Coverage> GetTransportInsuredCoverage(Transport.Insured.Coverage.Key parameter);
        IEnumerable<Transport.Insured.Coverage.Surcharge> GetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge.Key parameter);
        IEnumerable<Transport.Insured.Discount> GetTransportInsuredDiscount(Transport.Insured.Discount.Key parameter);
        Transport.Insured.Coverage.Surcharge.Key SetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge parameter);
        Transport.Insured.Discount.Key SetTransportInsuredDiscount(Transport.Insured.Discount parameter);
        int SetTransportInsuredApplyDiscountAndSurcharge(Transport.Insured parameter); 
        IEnumerable<Transport.Insured.ExtraInfo> GetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter); 
        Transport.Insured.ExtraInfo.Key SetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter);
    }
}
