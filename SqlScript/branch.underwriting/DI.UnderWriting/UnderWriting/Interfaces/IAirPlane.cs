using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IAirPlane
    {
        Airplane.Insured.Key SetAirplaneInsured(Airplane.Insured parameter);
        Airplane.Insured.Coverage.Key SetAirPlaneInsuredCoverage(Airplane.Insured.Coverage parameter);
        Airplane.Insured.Pilot.Key SetAirPlaneInsuredPilot(Airplane.Insured.Pilot parameter); 
        IEnumerable<Airplane.Insured> GetAirplaneInsured(Airplane.Insured.Key parameter);
        IEnumerable<Airplane.Insured.Coverage> GetAirPlaneInsuredCoverage(Airplane.Insured.Coverage.Key parameter);
        IEnumerable<Airplane.Insured.Pilot> GetAirplaneInsuredPilot(Airplane.Insured.Pilot.Key parameter);
        IEnumerable<Airplane.Insured.Coverage.Surcharge> GetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge.Key parameter);
        IEnumerable<Airplane.Insured.Discount> GetAirplaneInsuredDiscount(Airplane.Insured.Discount.Key parameter);
        Airplane.Insured.Coverage.Surcharge.Key SetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge parameter);
        Airplane.Insured.Discount.Key SetAirplaneInsuredDiscount(Airplane.Insured.Discount parameter);
        int SetAirplaneApplyDiscountAndSurcharge(Airplane.Insured parameter);
    }
}
