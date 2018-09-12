using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class BailBll : IBail
    {
        private BailManager _bailManager;

        public BailBll()
        {
            _bailManager = new BailManager();
        }

        Bail.Insured.Key IBail.SetBailInsured(Bail.Insured parameter)
        {
            return
                   _bailManager.SetBailInsured(parameter);
        }

        Bail.Insured.Coverage.Key IBail.SetBailInsuredCoverage(Bail.Insured.Coverage parameter)
        {
            return
                   _bailManager.SetBailInsuredCoverage(parameter);
        }

        IEnumerable<Bail.Insured> IBail.GetBailInsured(Bail.Insured.Key parameter)
        {
            return
                   _bailManager.GetBailInsured(parameter);
        }

        IEnumerable<Bail.Insured.Coverage> IBail.GetBailInsuredCoverage(Bail.Insured.Coverage.Key parameter)
        {
            return
                   _bailManager.GetBailInsuredCoverage(parameter);
        }

        IEnumerable<Bail.Insured.Coverage.Surcharge> IBail.GetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                  _bailManager.GetBailInsuredCoverageSurcharge(parameter);
        }

        IEnumerable<Bail.Insured.Discount> IBail.GetBailInsuredDiscount(Bail.Insured.Discount.Key parameter)
        {
            return
                  _bailManager.GetBailInsuredDiscount(parameter);
        }

        Bail.Insured.Coverage.Surcharge.Key IBail.SetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge parameter)
        {
            return
                  _bailManager.SetBailInsuredCoverageSurcharge(parameter);
        }

        Bail.Insured.Discount.Key IBail.SetBailInsuredDiscount(Bail.Insured.Discount parameter)
        {
            return
                  _bailManager.SetBailInsuredDiscount(parameter);
        }

        int IBail.SetBailInsuredApplyDiscountAndSurcharge(Bail.Insured parameter)
        {
            return
                    _bailManager.SetBailInsuredApplyDiscountAndSurcharge(parameter);
        }

        IEnumerable<Bail.Insured.Guarantors> IBail.GetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            return
                  _bailManager.GetBailInsuredGuarantors(parameter);
        }


        public Bail.Insured.Guarantors.Key SetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            return
                 _bailManager.SetBailInsuredGuarantors(parameter);
        }
    }

    public class BailWS : IBail
    {
        Bail.Insured.Key IBail.SetBailInsured(Bail.Insured parameter)
        {
            throw new NotImplementedException();
        }

        Bail.Insured.Coverage.Key IBail.SetBailInsuredCoverage(Bail.Insured.Coverage parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bail.Insured> IBail.GetBailInsured(Bail.Insured.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bail.Insured.Coverage> IBail.GetBailInsuredCoverage(Bail.Insured.Coverage.Key parameter)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Bail.Insured.Coverage.Surcharge> IBail.GetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge.Key parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bail.Insured.Discount> IBail.GetBailInsuredDiscount(Bail.Insured.Discount.Key parameter)
        {
            throw new NotImplementedException();
        }

        Bail.Insured.Coverage.Surcharge.Key IBail.SetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge parameter)
        {
            throw new NotImplementedException();
        }

        Bail.Insured.Discount.Key IBail.SetBailInsuredDiscount(Bail.Insured.Discount parameter)
        {
            throw new NotImplementedException();
        }

        int IBail.SetBailInsuredApplyDiscountAndSurcharge(Bail.Insured parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bail.Insured.Guarantors> IBail.GetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            throw new NotImplementedException();
        }



        public Bail.Insured.Guarantors.Key SetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            throw new NotImplementedException();
        }
    }
}
