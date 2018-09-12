using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class TransportBll : ITransport
    {
        private TransportManager _transportManager;

        public TransportBll()
        {
            _transportManager = new TransportManager();
        }

        Transport.Insured.Key ITransport.SetTransportInsured(Transport.Insured parameter)
        {
            return
                _transportManager.SetTransportInsured(parameter);
        }

        Transport.Insured.Coverage.Key ITransport.SetTransportInsuredCoverage(Transport.Insured.Coverage parameter)
        {
            return
                _transportManager.SetTransportInsuredCoverage(parameter);
        }

        IEnumerable<Transport.Insured> ITransport.GetTransportInsured(Transport.Insured.Key parameter)
        {
            return
                _transportManager.GetTransportInsured(parameter);
        }

        IEnumerable<Transport.Insured.Coverage> ITransport.GetTransportInsuredCoverage(Transport.Insured.Coverage.Key parameter)
        {
            return
                _transportManager.GetTransportInsuredCoverage(parameter);
        }



        IEnumerable<Transport.Insured.Coverage.Surcharge> ITransport.GetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge.Key parameter)
        {
            return
               _transportManager.GetTransportInsuredCoverageSurcharge(parameter);
        }

        IEnumerable<Transport.Insured.Discount> ITransport.GetTransportInsuredDiscount(Transport.Insured.Discount.Key parameter)
        {
            return
               _transportManager.GetTransportInsuredDiscount(parameter);
        }

        Transport.Insured.Coverage.Surcharge.Key ITransport.SetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge parameter)
        {
            return
               _transportManager.SetTransportInsuredCoverageSurcharge(parameter);
        }

        Transport.Insured.Discount.Key ITransport.SetTransportInsuredDiscount(Transport.Insured.Discount parameter)
        {
            return
               _transportManager.SetTransportInsuredDiscount(parameter);
        }

        int ITransport.SetTransportInsuredApplyDiscountAndSurcharge(Transport.Insured parameter)
        {
            return
                _transportManager.SetTransportInsuredApplyDiscountAndSurcharge(parameter);
        }

        IEnumerable<Transport.Insured.ExtraInfo> ITransport.GetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            return
                _transportManager.GetTransportInsuredExtraInfo(parameter);
        }



        public Transport.Insured.ExtraInfo.Key SetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            return
                 _transportManager.SetTransportInsuredExtraInfo(parameter);
        }
    }

    public class TransportWS : ITransport
    {
        Transport.Insured.Key ITransport.SetTransportInsured(Transport.Insured parameter)
        {
            throw new NotImplementedException();
        }

        Transport.Insured.Coverage.Key ITransport.SetTransportInsuredCoverage(Transport.Insured.Coverage parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transport.Insured> ITransport.GetTransportInsured(Transport.Insured.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transport.Insured.Coverage> ITransport.GetTransportInsuredCoverage(Transport.Insured.Coverage.Key parameter)
        {
            throw new NotImplementedException();
        }

              
        IEnumerable<Transport.Insured.Coverage.Surcharge> ITransport.GetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transport.Insured.Discount> ITransport.GetTransportInsuredDiscount(Transport.Insured.Discount.Key parameter)
        {
            throw new NotImplementedException();
        }

        Transport.Insured.Coverage.Surcharge.Key ITransport.SetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge parameter)
        {
            throw new NotImplementedException();
        }

        Transport.Insured.Discount.Key ITransport.SetTransportInsuredDiscount(Transport.Insured.Discount parameter)
        {
            throw new NotImplementedException();
        }

        int ITransport.SetTransportInsuredApplyDiscountAndSurcharge(Transport.Insured parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transport.Insured.ExtraInfo> ITransport.GetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            throw new NotImplementedException();
        }


        public Transport.Insured.ExtraInfo.Key SetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            throw new NotImplementedException();
        }
    }
}
