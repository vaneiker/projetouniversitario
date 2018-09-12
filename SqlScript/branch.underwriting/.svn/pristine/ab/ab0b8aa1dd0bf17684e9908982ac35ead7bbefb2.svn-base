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
    public class TransportManager
    {
        private TransportRepository _transportRepository;

        public TransportManager()
        {
            _transportRepository = SingletonUnitOfWork.Instance.TransportRepository;
        }

        public virtual Transport.Insured.Key SetTransportInsured(Transport.Insured parameter)
        {
            return
                _transportRepository.SetTransportInsured(parameter);
        }

        public virtual Transport.Insured.Coverage.Key SetTransportInsuredCoverage(Transport.Insured.Coverage parameter)
        {
            return
                 _transportRepository.SetTransportInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Transport.Insured> GetTransportInsured(Transport.Insured.Key parameter)
        {
            return
                _transportRepository.GetTransportInsured(parameter);
        }

        public virtual IEnumerable<Transport.Insured.Coverage> GetTransportInsuredCoverage(Transport.Insured.Coverage.Key parameter)
        {
            return
                _transportRepository.GetTransportInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Transport.Insured.Coverage.Surcharge> GetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                 _transportRepository.GetTransportInsuredCoverageSurcharge(parameter);
        }

        public virtual IEnumerable<Transport.Insured.Discount> GetTransportInsuredDiscount(Transport.Insured.Discount.Key parameter)
        {
            return
                _transportRepository.GetTransportInsuredDiscount(parameter);
        }

        public virtual Transport.Insured.Coverage.Surcharge.Key SetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge parameter)
        {
            return
                _transportRepository.SetTransportInsuredCoverageSurcharge(parameter);
        }

        public virtual Transport.Insured.Discount.Key SetTransportInsuredDiscount(Transport.Insured.Discount parameter)
        {
            return
                _transportRepository.SetTransportInsuredDiscount(parameter);
        }

        public virtual int SetTransportInsuredApplyDiscountAndSurcharge(Transport.Insured parameter)
        {
            return
                _transportRepository.SetTransportInsuredApplyDiscountAndSurcharge(parameter);
        }

        public virtual IEnumerable<Transport.Insured.ExtraInfo> GetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            return
                _transportRepository.GetTransportInsuredExtraInfo(parameter);
        }

        public Transport.Insured.ExtraInfo.Key SetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            return
                _transportRepository.SetTransportInsuredExtraInfo(parameter);
        }
    }
}