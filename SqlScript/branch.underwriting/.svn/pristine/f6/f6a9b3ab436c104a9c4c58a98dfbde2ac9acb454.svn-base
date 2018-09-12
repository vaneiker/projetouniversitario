using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class PropertyBll : IProperty
    {
        private PropertyManager _propertyManager;

        public PropertyBll()
        {
            _propertyManager = new PropertyManager();
        }

        IEnumerable<Property> IProperty.GetProperty(Property.Key parameter)
        {
            return
                 _propertyManager.GetProperty(parameter);
        }

        Property.SetPropertyResult IProperty.SetProperty(Property parameter)
        {
            return
               _propertyManager.SetProperty(parameter);
        }

        IEnumerable<Property.Detail.GetDetailResult> IProperty.GetPropertyDetail(Property.Detail.GetDetailResult.Key parameter)
        {
            return
                 _propertyManager.GetPropertyDetail(parameter);
        }
        Property.Detail IProperty.SetPropertyDetail(Property.Detail.key parameter)
        {
            return
               _propertyManager.SetPropertyDetail(parameter);
        }

        Property.Insured IProperty.SetPropertyInsured(Property.Insured.key parameter)
        {
            return
               _propertyManager.SetPropertyInsured(parameter);
        }

        Property.Insured.Detail IProperty.SetPropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            return
               _propertyManager.SetPropertyInsuredDetail(parameter);
        }

        Property.Insured.Detail.Coverage IProperty.SetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.Key parameter)
        {
            return
                _propertyManager.SetPropertyInsuredDetailCoverage(parameter);
        }

        Property.Insured.Detail.Feature IProperty.SetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.Key parameter)
        {
            return
                _propertyManager.SetPropertyInsuredDetailFeature(parameter);
        }

        IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> IProperty.GetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key parameter)
        {
            return
                 _propertyManager.GetPropertyInsuredDetailCoverage(parameter);
        }

        IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> IProperty.GetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key parameter)
        {
            return
                  _propertyManager.GetPropertyInsuredDetailFeature(parameter);
        }  

        IEnumerable<Property.Insured.Coverage.Surcharge> IProperty.GetPropertyInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge.Key parameter)
        {
            return
                   _propertyManager.GetPropertyInsuredCoverageSurcharge(parameter);
        }

        IEnumerable<Property.Insured.Discount> IProperty.GetPropertyInsuredDiscount(Property.Insured.Discount.Key parameter)
        {
            return
                   _propertyManager.GetPropertyInsuredDiscount(parameter);
        }

        Property.Insured.Coverage.Surcharge.Key IProperty.SetPropertytInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge parameter)
        {
            return
                   _propertyManager.SetPropertytInsuredCoverageSurcharge(parameter);
        }

        Property.Insured.Discount.Key IProperty.SetPropertyInsuredDiscount(Property.Insured.Discount parameter)
        {
            return
                  _propertyManager.SetPropertyInsuredDiscount(parameter);
        }

        int IProperty.SetPropertyInsuredApplyDiscountAndSurcharge(Property.Insured parameter)
        {
            return
                  _propertyManager.SetPropertyInsuredApplyDiscountAndSurcharge(parameter);
        }
                                

        Property.Insured.Detail.key  IProperty.GetPropertyInsuredDet(Property.Insured.Detail parameter)
        {
            return
                   _propertyManager.GetPropertyInsuredDet(parameter);
        }

        int IProperty.UpdatePropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            return
                    _propertyManager.UpdatePropertyInsuredDetail(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> GetPropertyFeatureMeasureType(Property.Insured.Detail.Feature.MeasureTypeResult.Key parameter)
        {
            return
             _propertyManager.GetPropertyFeatureMeasureType(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.PositionsResult> GetPropertyFeaturePosition(Property.Insured.Detail.Feature.PositionsResult.Key parameter)
        {
            return
           _propertyManager.GetPropertyFeaturePosition(parameter);
        }

        public IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> GetPropertyFeatureCertificates(Property.Insured.Detail.Feature.CertificatesResult.Key parameter)
        {
            return
           _propertyManager.GetPropertyFeatureCertificates(parameter);
        }
    }

    public class PropertyWS : IProperty
    {
        IEnumerable<Property> IProperty.GetProperty(Property.Key parameter)
        {
            throw new NotImplementedException();
        } 
        Property.SetPropertyResult IProperty.SetProperty(Property parameter)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Property.Detail.GetDetailResult> IProperty.GetPropertyDetail(Property.Detail.GetDetailResult.Key parameter)
        { 
            throw new NotImplementedException();
        }
        Property.Detail IProperty.SetPropertyDetail(Property.Detail.key parameter)
        {
            throw new NotImplementedException();
        }    
        Property.Insured IProperty.SetPropertyInsured(Property.Insured.key parameter)
        {
            throw new NotImplementedException();
        } 
        Property.Insured.Detail IProperty.SetPropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            throw new NotImplementedException();
        }  
        Property.Insured.Detail.Coverage IProperty.SetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.Key parameter)
        {
            throw new NotImplementedException();
        }  
        Property.Insured.Detail.Feature IProperty.SetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.Key parameter)
        {
            throw new NotImplementedException();
        }  
        IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> IProperty.GetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key parameter)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> IProperty.GetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key parameter)
        {
            throw new NotImplementedException();
        } 
        IEnumerable<Property.Insured.Coverage.Surcharge> IProperty.GetPropertyInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge.Key parameter)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Property.Insured.Discount> IProperty.GetPropertyInsuredDiscount(Property.Insured.Discount.Key parameter)
        {
            throw new NotImplementedException();
        } 
        Property.Insured.Coverage.Surcharge.Key IProperty.SetPropertytInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge parameter)
        {
            throw new NotImplementedException();
        } 
        Property.Insured.Discount.Key IProperty.SetPropertyInsuredDiscount(Property.Insured.Discount parameter)
        {
            throw new NotImplementedException();
        }
        int IProperty.SetPropertyInsuredApplyDiscountAndSurcharge(Property.Insured parameter)
        {
            throw new NotImplementedException();
        }         

        Property.Insured.Detail.key IProperty.GetPropertyInsuredDet(Property.Insured.Detail parameter)
        {
            throw new NotImplementedException();
        }

        int IProperty.UpdatePropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> GetPropertyFeatureMeasureType(Property.Insured.Detail.Feature.MeasureTypeResult.Key parameter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property.Insured.Detail.Feature.PositionsResult> GetPropertyFeaturePosition(Property.Insured.Detail.Feature.PositionsResult.Key parameter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> GetPropertyFeatureCertificates(Property.Insured.Detail.Feature.CertificatesResult.Key parameter)
        {
            throw new NotImplementedException();
        }
    }
}
