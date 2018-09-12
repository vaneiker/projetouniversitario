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
    public class AirPlaneManager
    {
        private AirPlaneRepository _airPlaneRepository;

        public AirPlaneManager()
        {
            _airPlaneRepository = SingletonUnitOfWork.Instance.AirPlaneRepository;
        }

        public virtual Airplane.Insured.Key SetAirplaneInsured(Airplane.Insured parameter)
        {
            return
                _airPlaneRepository.SetAirplaneInsured(parameter);
        }

        public virtual Airplane.Insured.Coverage.Key SetAirPlaneInsuredCoverage(Airplane.Insured.Coverage parameter)
        {
            return
                _airPlaneRepository.SetAirPlaneInsuredCoverage(parameter);
        }

        public virtual Airplane.Insured.Pilot.Key SetAirPlaneInsuredPilot(Airplane.Insured.Pilot parameter)
        {
            return
                _airPlaneRepository.SetAirPlaneInsuredPilot(parameter);
        }

        public virtual IEnumerable<Airplane.Insured> GetAirplaneInsured(Airplane.Insured.Key parameter)
        {
            return
                _airPlaneRepository.GetAirplaneInsured(parameter);
        }
        public virtual IEnumerable<Airplane.Insured.Coverage> GetAirPlaneInsuredCoverage(Airplane.Insured.Coverage.Key parameter)
        {
            return
                _airPlaneRepository.GetAirPlaneInsuredCoverage(parameter);
        }
        public virtual IEnumerable<Airplane.Insured.Pilot> GetAirplaneInsuredPilot(Airplane.Insured.Pilot.Key parameter)
        {
            return
                _airPlaneRepository.GetAirplaneInsuredPilot(parameter);
        }

        public virtual IEnumerable<Airplane.Insured.Coverage.Surcharge> GetTransportAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                _airPlaneRepository.GetAirplaneCoverageSurcharge(parameter);
        }
        public virtual IEnumerable<Airplane.Insured.Discount> GetAirplaneInsuredDiscount(Airplane.Insured.Discount.Key parameter)
        {
            return
                _airPlaneRepository.GetAirplaneInsuredDiscount(parameter);
        }
        public virtual Airplane.Insured.Coverage.Surcharge.Key SetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge parameter)
        {
            return
                _airPlaneRepository.SetAirplaneCoverageSurcharge(parameter);
        }
        public virtual Airplane.Insured.Discount.Key SetAirplaneInsuredDiscount(Airplane.Insured.Discount parameter)
        {
            return
                _airPlaneRepository.SetAirplaneInsuredDiscount(parameter);
        }
        public virtual int SetAirplaneApplyDiscountAndSurcharge(Airplane.Insured parameter)
        {
            return
                _airPlaneRepository.SetAirplaneApplyDiscountAndSurcharge(parameter);
        }
    }
}