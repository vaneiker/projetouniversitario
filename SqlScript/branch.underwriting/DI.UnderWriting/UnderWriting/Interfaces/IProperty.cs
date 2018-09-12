using System;
using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IProperty
    {
        IEnumerable<Property> GetProperty(Property.Key parameter);
        Property.SetPropertyResult SetProperty(Property parameter);
        IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> GetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key parameter);
        IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> GetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key parameter);
        IEnumerable<Property.Detail.GetDetailResult> GetPropertyDetail(Property.Detail.GetDetailResult.Key parameter);
        Property.Detail SetPropertyDetail(Property.Detail.key parameter);
        Property.Insured SetPropertyInsured(Property.Insured.key parameter);

        Property.Insured.Detail SetPropertyInsuredDetail(Property.Insured.Detail.key parameter);

        Property.Insured.Detail.Coverage SetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.Key parameter);
        Property.Insured.Detail.Feature SetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.Key parameter);
        IEnumerable<Property.Insured.Coverage.Surcharge> GetPropertyInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge.Key parameter);
        IEnumerable<Property.Insured.Discount> GetPropertyInsuredDiscount(Property.Insured.Discount.Key parameter);
        Property.Insured.Coverage.Surcharge.Key SetPropertytInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge parameter);
        Property.Insured.Discount.Key SetPropertyInsuredDiscount(Property.Insured.Discount parameter);
        int SetPropertyInsuredApplyDiscountAndSurcharge(Property.Insured parameter);
        Property.Insured.Detail.key GetPropertyInsuredDet(Property.Insured.Detail parameter);

        int UpdatePropertyInsuredDetail(Property.Insured.Detail.key parameter);

        IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> GetPropertyFeatureMeasureType(Property.Insured.Detail.Feature.MeasureTypeResult.Key parameter);
        IEnumerable<Property.Insured.Detail.Feature.PositionsResult> GetPropertyFeaturePosition(Property.Insured.Detail.Feature.PositionsResult.Key parameter);
        IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> GetPropertyFeatureCertificates(Property.Insured.Detail.Feature.CertificatesResult.Key parameter);


    }
}
