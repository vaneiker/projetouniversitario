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
    public class PropertyManager
    {
        private PropertyRepository _propertyRepository;

        public PropertyManager()
        {
            _propertyRepository = SingletonUnitOfWork.Instance.PropertyRepository;
        }

        public IEnumerable<Property> GetProperty(Property.Key parameter)
        {
            return
                _propertyRepository.GetProperty(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> GetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key parameter)
        {
            return
                _propertyRepository.GetPropertyInsuredDetailCoverage(parameter);
        }
        public IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> GetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key parameter)
        {
            return
                 _propertyRepository.GetPropertyInsuredDetailFeature(parameter);
        }
        public IEnumerable<Property.Detail.GetDetailResult> GetPropertyDetail(Property.Detail.GetDetailResult.Key parameter)
        {
            return
                _propertyRepository.GetPropertyDetail(parameter);
        }
        public Property.SetPropertyResult SetProperty(Property parameter)
        {
            return
                 _propertyRepository.SetProperty(parameter);
        }
        public Property.Detail SetPropertyDetail(Property.Detail.key parameter)
        {
            return
                 _propertyRepository.SetPropertyDetail(parameter);
        }
        public Property.Insured SetPropertyInsured(Property.Insured.key parameter)
        {
            return
                 _propertyRepository.SetPropertyInsured(parameter);
        }
        public Property.Insured.Detail SetPropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            return
                 _propertyRepository.SetPropertyInsuredDetail(parameter);
        }
        public Property.Insured.Detail.Coverage SetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.Key parameter)
        {
            return
                 _propertyRepository.SetPropertyInsuredDetailCoverage(parameter);
        }
        public Property.Insured.Detail.Feature SetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.Key parameter)
        {
            return
                _propertyRepository.SetPropertyInsuredDetailFeature(parameter);
        }
        public IEnumerable<Property.Insured.Coverage.Surcharge> GetPropertyInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                _propertyRepository.GetPropertyInsuredCoverageSurcharge(parameter);
        }
        public IEnumerable<Property.Insured.Discount> GetPropertyInsuredDiscount(Property.Insured.Discount.Key parameter)
        {
            return
                 _propertyRepository.GetPropertyInsuredDiscount(parameter);
        }
        public Property.Insured.Coverage.Surcharge.Key SetPropertytInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge parameter)
        {
            return
                   _propertyRepository.SetPropertytInsuredCoverageSurcharge(parameter);
        }
        public Property.Insured.Discount.Key SetPropertyInsuredDiscount(Property.Insured.Discount parameter)
        {
            return
                 _propertyRepository.SetPropertyInsuredDiscount(parameter);
        }
        public int SetPropertyInsuredApplyDiscountAndSurcharge(Property.Insured parameter)
        {
            return
                 _propertyRepository.SetPropertyInsuredApplyDiscountAndSurcharge(parameter);
        }
        public Property.Insured.Detail.key GetPropertyInsuredDet(Property.Insured.Detail parameter)
        {
            return
              _propertyRepository.GetPropertyInsuredDet(parameter);
        }

        public int UpdatePropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            return
                _propertyRepository.UpdatePropertyInsuredDetail(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> GetPropertyFeatureMeasureType(Property.Insured.Detail.Feature.MeasureTypeResult.Key parameter)
        {
            return
             _propertyRepository.GetPropertyFeatureMeasureType(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.PositionsResult> GetPropertyFeaturePosition(Property.Insured.Detail.Feature.PositionsResult.Key parameter)
        {
            return
           _propertyRepository.GetPropertyFeaturePosition(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> GetPropertyFeatureCertificates(Property.Insured.Detail.Feature.CertificatesResult.Key parameter)
        {
            return
           _propertyRepository.GetPropertyFeatureCertificates(parameter);
        }
    }
}