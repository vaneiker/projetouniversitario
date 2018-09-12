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
    public class BailManager
    {
        private BailRepository _bailRepository;

        public BailManager()
        {
            _bailRepository = SingletonUnitOfWork.Instance.BailRepository;
        }

        public virtual Bail.Insured.Key SetBailInsured(Bail.Insured parameter)
        {
            return
                  _bailRepository.SetBailInsured(parameter);
        }
        public virtual Bail.Insured.Coverage.Key SetBailInsuredCoverage(Bail.Insured.Coverage parameter)
        {
            return
                 _bailRepository.SetBailInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Bail.Insured> GetBailInsured(Bail.Insured.Key parameter)
        {
            return
                 _bailRepository.GetBailInsured(parameter);
        }
        public virtual IEnumerable<Bail.Insured.Coverage> GetBailInsuredCoverage(Bail.Insured.Coverage.Key parameter)
        {
            return
                 _bailRepository.GetBailInsuredCoverage(parameter);
        }

        public virtual IEnumerable<Bail.Insured.Coverage.Surcharge> GetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                 _bailRepository.GetBailInsuredCoverageSurcharge(parameter);
        }
        public virtual IEnumerable<Bail.Insured.Discount> GetBailInsuredDiscount(Bail.Insured.Discount.Key parameter)
        {
            return
                _bailRepository.GetBailInsuredDiscount(parameter);
        }
        public virtual Bail.Insured.Coverage.Surcharge.Key SetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge parameter)
        {
            return
               _bailRepository.SetBailInsuredCoverageSurcharge(parameter);
        }

        public virtual Bail.Insured.Discount.Key SetBailInsuredDiscount(Bail.Insured.Discount parameter)
        {
            return
                 _bailRepository.SetBailInsuredDiscount(parameter);
        }

        public virtual int SetBailInsuredApplyDiscountAndSurcharge(Bail.Insured parameter)
        {
            return
                _bailRepository.SetBailInsuredApplyDiscountAndSurcharge(parameter);
        }

        public virtual IEnumerable<Bail.Insured.Guarantors> GetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            return
                 _bailRepository.GetBailInsuredGuarantors(parameter);
        }

        public Bail.Insured.Guarantors.Key SetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            return
                 _bailRepository.SetBailInsuredGuarantors(parameter);
        }
    }
}