using DI.UnderWriting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class AirPlaneBll : IAirPlane
    {
        private AirPlaneManager _airPlaneManager;

        public AirPlaneBll()
        {
            _airPlaneManager = new AirPlaneManager();
        }

        Airplane.Insured.Key IAirPlane.SetAirplaneInsured(Airplane.Insured parameter)
        {
            return
                 _airPlaneManager.SetAirplaneInsured(parameter);
        }

        Airplane.Insured.Coverage.Key IAirPlane.SetAirPlaneInsuredCoverage(Airplane.Insured.Coverage parameter)
        {
            return
                  _airPlaneManager.SetAirPlaneInsuredCoverage(parameter);
        }

        Airplane.Insured.Pilot.Key IAirPlane.SetAirPlaneInsuredPilot(Airplane.Insured.Pilot parameter)
        {
            return
                 _airPlaneManager.SetAirPlaneInsuredPilot(parameter);
        }

        IEnumerable<Airplane.Insured> IAirPlane.GetAirplaneInsured(Airplane.Insured.Key parameter)
        {
            return
                _airPlaneManager.GetAirplaneInsured(parameter);
        }

        IEnumerable<Airplane.Insured.Coverage> IAirPlane.GetAirPlaneInsuredCoverage(Airplane.Insured.Coverage.Key parameter)
        {
            return
                _airPlaneManager.GetAirPlaneInsuredCoverage(parameter);
        }

        IEnumerable<Airplane.Insured.Pilot> IAirPlane.GetAirplaneInsuredPilot(Airplane.Insured.Pilot.Key parameter)
        {
            return
                 _airPlaneManager.GetAirplaneInsuredPilot(parameter);
        }


        IEnumerable<Airplane.Insured.Coverage.Surcharge> IAirPlane.GetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                 _airPlaneManager.GetTransportAirplaneCoverageSurcharge(parameter);
        }

        IEnumerable<Airplane.Insured.Discount> IAirPlane.GetAirplaneInsuredDiscount(Airplane.Insured.Discount.Key parameter)
        {
            return
                 _airPlaneManager.GetAirplaneInsuredDiscount(parameter);
        }

        Airplane.Insured.Coverage.Surcharge.Key IAirPlane.SetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge parameter)
        {
            return
                  _airPlaneManager.SetAirplaneCoverageSurcharge(parameter);
        }

        Airplane.Insured.Discount.Key IAirPlane.SetAirplaneInsuredDiscount(Airplane.Insured.Discount parameter)
        {
            return
                 _airPlaneManager.SetAirplaneInsuredDiscount(parameter);
        }

        int IAirPlane.SetAirplaneApplyDiscountAndSurcharge(Airplane.Insured parameter)
        {
            return
                 _airPlaneManager.SetAirplaneApplyDiscountAndSurcharge(parameter);
        }
    }

    public class AirPlaneWS : IAirPlane
    {
        Airplane.Insured.Key IAirPlane.SetAirplaneInsured(Airplane.Insured parameter)
        {
            throw new NotImplementedException();
        }

        Airplane.Insured.Coverage.Key IAirPlane.SetAirPlaneInsuredCoverage(Airplane.Insured.Coverage parameter)
        {
            throw new NotImplementedException();
        }

        Airplane.Insured.Pilot.Key IAirPlane.SetAirPlaneInsuredPilot(Airplane.Insured.Pilot parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Airplane.Insured> IAirPlane.GetAirplaneInsured(Airplane.Insured.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Airplane.Insured.Coverage> IAirPlane.GetAirPlaneInsuredCoverage(Airplane.Insured.Coverage.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Airplane.Insured.Pilot> IAirPlane.GetAirplaneInsuredPilot(Airplane.Insured.Pilot.Key parameter)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Airplane.Insured.Coverage.Surcharge> IAirPlane.GetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Airplane.Insured.Discount> IAirPlane.GetAirplaneInsuredDiscount(Airplane.Insured.Discount.Key parameter)
        {
            throw new NotImplementedException();
        }

        Airplane.Insured.Coverage.Surcharge.Key IAirPlane.SetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge parameter)
        {
            throw new NotImplementedException();
        }

        Airplane.Insured.Discount.Key IAirPlane.SetAirplaneInsuredDiscount(Airplane.Insured.Discount parameter)
        {
            throw new NotImplementedException();
        }

        int IAirPlane.SetAirplaneApplyDiscountAndSurcharge(Airplane.Insured parameter)
        {
            throw new NotImplementedException();
        }
    }
}
