using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class TransportRepository : GlobalRepository
    {
        public TransportRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Transport.Insured.Key SetTransportInsured(Transport.Insured parameter)
        {
            Transport.Insured.Key result;
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_INSURED_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_TRANSPORT_INSURED
                (
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.TransportId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.TransportInsuredId,
                    parameter.ReinsuranceId,
                    parameter.ReinsuranceAmount,
                    parameter.BuninessType,
                    parameter.Activity,
                    parameter.MerchandasingType,
                    parameter.PackagingType,
                    parameter.LimitLiability,
                    parameter.ValuationClause,
                    parameter.Deductible,
                    parameter.GeographicalLimitFrom,
                    parameter.GeographicalLimitTo,
                    parameter.Conveyance,
                    parameter.VehicleQty,
                    parameter.FreightAmount,
                    parameter.TruckAmount,
                    parameter.ContainerAmount,
                    parameter.ChassisAmount,
                    parameter.Transfer,
                    parameter.NoRating,
                    parameter.Barge,
                    parameter.UnknownValue,
                    parameter.LowTonnage,
                    parameter.ByAge,
                    parameter.AddressCountryId,
                    parameter.AddressDomesticregId,
                    parameter.AddressStateProvId,
                    parameter.AddressCityId,
                    parameter.AddressStreet,
                    parameter.AddressNumber,
                    parameter.VehicleHasInsure,
                    parameter.MerchandiseDesc,
                    parameter.Security,
                    parameter.WayOfTransport,
                    parameter.Warehouse,
                    parameter.billingType,
                    parameter.InsuredDate,
                    parameter.InsuredAmount,
                    parameter.Rate,
                    parameter.PremiumAmount,
                    parameter.BasePremiumAmount,
                    parameter.DeductiblePercentage,
                    parameter.DeductibleAmount,
                    parameter.MinimumDeductibleAmount,
                    parameter.IsNew,
                    parameter.RequiresInspection,
                    parameter.Reinsurance,
                    parameter.Inspected,
                    parameter.EndorsementClarifying,
                    parameter.Endorsement,
                    parameter.EndorsementBeneficiary,
                    parameter.EndorsementBeneficiaryRnc,
                    parameter.EndorsementAmount,
                    parameter.EndorsementContactName,
                    parameter.EndorsementContactPhone,
                    parameter.EndorsementContactEmail,
                    parameter.InspectionAddress,
                    parameter.TransportStatusId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp
                .Select(pp => new Transport.Insured.Key
                    {
                        Action = pp.Action,
                        CorpId = pp.Corp_Id,
                        RegionId = pp.Region_Id,
                        CountryId = pp.Country_Id,
                        DomesticregId = pp.Domesticreg_Id,
                        StateProvId = pp.State_Prov_Id,
                        CityId = pp.City_Id,
                        OfficeId = pp.Office_Id,
                        CaseSeqNo = pp.Case_Seq_No,
                        HistSeqNo = pp.Hist_Seq_No,
                        TransportId = pp.Transport_Id
                    })
                .FirstOrDefault();

            return
                result;
        }
        public virtual Transport.Insured.Coverage.Key SetTransportInsuredCoverage(Transport.Insured.Coverage parameter)
        {
            Transport.Insured.Coverage.Key result;
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_INSURED_COVERAGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_TRANSPORT_INSURED_COVERAGE
                (
                    parameter.CorpId,
                    parameter.UniqueTransportId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.VehicleTypeId,
                    parameter.GroupId,
                    parameter.CoverageTypeId,
                    parameter.CoverageId,
                    parameter.CurrencyId,
                    parameter.UnitaryPrice,
                    parameter.PackagePrice,
                    parameter.DeductibleAmount,
                    parameter.DeductiblePercentage,
                    parameter.ManualDeductibleAmount,
                    parameter.ManualDeductiblePercentage,
                    parameter.CoverageLimit,
                    parameter.CoverageStatus,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp.
                Select(pp => new Transport.Insured.Coverage.Key
                    {
                        Action = pp.Action,
                        CorpId = pp.Corp_Id,
                        UniqueTransportId = pp.Unique_Transport_Id,
                        RegionId = pp.Region_Id,
                        CountryId = pp.Country_Id,
                        BlTypeId = pp.Bl_Type_Id,
                        BlId = pp.Bl_Id,
                        ProductId = pp.Product_Id,
                        VehicleTypeId = pp.Vehicle_Type_Id,
                        GroupId = pp.Group_Id,
                        CoverageTypeId = pp.Coverage_Type_Id,
                        CoverageId = pp.Coverage_Id
                    })
                .FirstOrDefault();

            return
                result;
        }
        public virtual IEnumerable<Transport.Insured> GetTransportInsured(Transport.Insured.Key parameter)
        {
            IEnumerable<Transport.Insured> result;
            IEnumerable<SP_GET_PL_POLICY_TRANSPORT_INSURED_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_TRANSPORT_INSURED(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.TransportId
                );

            result = temp
                .Select(ti => new Transport.Insured
                {
                    MerchandasingType = ti.Merchandasing_Type,
                    InsuredDate = ti.Insured_Date,
                    InsuredAmount = ti.Insured_Amount,
                    Rate = ti.Rate,
                    PremiumAmount = ti.Premium_Amount,
                    BasePremiumAmount = ti.Base_Premium_Amount,
                    DeductiblePercentage = ti.Deductible_Percentage,
                    DeductibleAmount = ti.Deductible_Amount,
                    MinimumDeductibleAmount = ti.Minimum_Deductible_Amount,
                    IsNew = ti.New,
                    RequiresInspection = ti.Requires_Inspection,
                    Reinsurance = ti.Reinsurance,
                    Inspected = ti.Inspected,
                    EndorsementClarifying = ti.Endorsement_Clarifying,
                    Endorsement = ti.Endorsement,
                    EndorsementBeneficiary = ti.Endorsement_Beneficiary,
                    EndorsementBeneficiaryRnc = ti.Endorsement_Beneficiary_Rnc,
                    EndorsementAmount = ti.Endorsement_Amount,
                    EndorsementContactName = ti.Endorsement_Contact_Name,
                    EndorsementContactPhone = ti.Endorsement_Contact_Phone,
                    EndorsementContactEmail = ti.Endorsement_Contact_Email,
                    InspectionAddress = ti.Inspection_Address,
                    TransportStatusId = ti.Transport_Status_Id,
                    CorpId = ti.Corp_Id,
                    RegionId = ti.Region_Id,
                    CountryId = ti.Country_Id,
                    DomesticRegId = ti.Domesticreg_Id,
                    StateProvId = ti.State_Prov_Id,
                    CityId = ti.City_Id,
                    OfficeId = ti.Office_Id,
                    CaseSeqNo = ti.Case_Seq_No,
                    HistSeqNo = ti.Hist_Seq_No,
                    TransportId = ti.Transport_Id,
                    UniqueTransportId = ti.Unique_Transport_Id,
                    BlTypeId = ti.Bl_Type_Id,
                    BlId = ti.Bl_Id,
                    ProductId = ti.Product_Id,
                    TransportInsuredId = ti.Transport_Insured_Id,
                    ProductDesc = ti.Product_Desc,
                    ProductTypeId = ti.Product_Type_Id,
                    ReinsuranceId = ti.Reinsurance_Id,
                    ReinsuranceAmount = ti.Reinsurance_Amount,
                    ReinsurancePercentage = ti.Reinsurance_Percentage,
                    BuninessType = ti.Buniness_Type,
                    Activity = ti.Activity,
                    PackagingType = ti.Packaging_Type,
                    LimitLiability = ti.Limit_Liability,
                    ValuationClause = ti.Valuation_Clause,
                    Deductible = ti.Deductible,
                    GeographicalLimitFrom = ti.Geographical_Limit_From,
                    GeographicalLimitTo = ti.Geographical_Limit_To,
                    Conveyance = ti.Conveyance,
                    VehicleQty = ti.Vehicle_Qty,
                    FreightAmount = ti.Freight_Amount,
                    TruckAmount = ti.Truck_Amount,
                    ContainerAmount = ti.Container_Amount,
                    ChassisAmount = ti.Chassis_Amount,
                    Transfer = ti.Transfer,
                    NoRating = ti.NoRating,
                    Barge = ti.Barge,
                    UnknownValue = ti.UnknownValue,
                    LowTonnage = ti.LowTonnage,
                    ByAge = ti.ByAge,
                    AddressCountryId = ti.Address_Country_Id,
                    AddressDomesticregId = ti.Address_Domesticreg_Id,
                    AddressStateProvId = ti.Address_State_Prov_Id,
                    AddressCityId = ti.Address_City_Id,
                    AddressStreet = ti.Address_Street,
                    AddressNumber = ti.Address_Number,
                    VehicleHasInsure = ti.Vehicle_HasInsure,
                    MerchandiseDesc = ti.Merchandise_Desc,
                    Security = ti.Security,
                    WayOfTransport = ti.Way_Of_Transport,
                    Warehouse = ti.Warehouse,
                    SourceId = ti.Source_Id,
                    ReinsurancePremiumAmount = ti.Reinsurance_Premium_Amount,
                    AddressCountryDesc = ti.Address_Country_Desc,
                    AddressStateProvDesc = ti.Address_State_Prov_Desc,
                    AddressMunicipioDesc = ti.Address_Municipio_Desc,
                    AddressCityDesc = ti.Address_City_Desc,
                    billingType = ti.Billing_Type,
                    Ramo = ti.Ramo,
                    SubRamo = ti.SubRamo
                })
                .ToArray();

            return
                result;
        }
        public virtual IEnumerable<Transport.Insured.Coverage> GetTransportInsuredCoverage(Transport.Insured.Coverage.Key parameter)
        {
            IEnumerable<Transport.Insured.Coverage> result;
            IEnumerable<SP_GET_PL_POLICY_TRANSPORT_INSURED_COVERAGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_TRANSPORT_INSURED_COVERAGE(
                    parameter.CorpId,
                    parameter.UniqueTransportId
                );

            result = temp
                .Select(tic => new Transport.Insured.Coverage
                {
                    CurrencyId = tic.Currency_Id,
                    UnitaryPrice = tic.Unitary_Price,
                    PackagePrice = tic.Package_Price,
                    DeductibleAmount = tic.Deductible_Amount,
                    DeductiblePercentage = tic.Deductible_Percentage,
                    ManualDeductibleAmount = tic.Manual_Deductible_Amount,
                    ManualDeductiblePercentage = tic.Manual_Deductible_Percentage,
                    CoverageLimit = tic.Coverage_Limit,
                    CoverageStatus = tic.Coverage_Status,
                    CoverageDesc = tic.Coverage_Desc,
                    CoverageTypeDesc = tic.Coverage_Type_Desc,
                    CorpId = tic.Corp_Id,
                    UniqueTransportId = tic.Unique_Transport_Id,
                    RegionId = tic.Region_Id,
                    CountryId = tic.Country_Id,
                    BlTypeId = tic.Bl_Type_Id,
                    BlId = tic.Bl_Id,
                    ProductId = tic.Product_Id,
                    VehicleTypeId = tic.Vehicle_Type_Id,
                    GroupId = tic.Group_Id,
                    CoverageTypeId = tic.Coverage_Type_Id,
                    CoverageId = tic.Coverage_Id,
                    Ramo = tic.Ramo,
                    SubRamo = tic.SubRamo,
                    RamoDesc = tic.Ramo_Desc,
                    SubRamoDesc = tic.SubRamo_Desc,
                    CoveragePercentage = tic.Coverage_Percentage,
                    PremiumPercentage = tic.Premium_Percentage,
                    CoinsurancePercentage = tic.Coinsurance_Percentage
                })
                .ToArray();

            return
                result;
        }
        public virtual IEnumerable<Transport.Insured.Coverage.Surcharge> GetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge.Key parameter)
        {
            IEnumerable<Transport.Insured.Coverage.Surcharge> result;
            IEnumerable<SP_GET_PL_POLICY_TRANSPORT_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_TRANSPORT_COVERAGE_SURCHARGE
                (
                    parameter.SurchargeId,
                    parameter.discountRuleId,
                    parameter.discountRuleDetailId,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueTransportId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.VehicleTypeId,
                    parameter.GroupId,
                    parameter.CoverageTypeId,
                    parameter.CoverageId,
                    parameter.languageId
                )
                .ToArray();

            result = temp
                .Select(cs => new Transport.Insured.Coverage.Surcharge
                {
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    uniqueTransportId = cs.Unique_Transport_Id,
                    BlTypeId = cs.Bl_Type_Id,
                    BlId = cs.Bl_Id,
                    ProductId = cs.Product_Id,
                    VehicleTypeId = cs.Vehicle_Type_Id,
                    GroupId = cs.Group_Id,
                    CoverageTypeId = cs.Coverage_Type_Id,
                    CoverageId = cs.Coverage_Id,
                    SurchargeId = cs.Surcharge_Id,
                    DiscountRuleId = cs.Discount_Rule_Id,
                    DiscountRuleDetailId = cs.Discount_Rule_Detail_Id,
                    OldCoverageAmount = cs.Old_Coverage_Amount,
                    NotePredefiniedId = cs.Note_Predefinied_Id,
                    DiscountRuleDesc = cs.Discount_Rule_Desc,
                    DiscountRuleNameKey = cs.Discount_Rule_Name_Key,
                    DetailApplyDate = cs.Detail_Apply_Date,
                    DetailRuleValue = cs.Detail_Rule_Value,
                    DetailRuleNameKey = cs.Detail_Rule_NameKey,
                    NotePredefiniedDesc = cs.Note_Predefinied_Desc,
                    NoteNameKey = cs.Note_Name_Key,
                    BasePremiumAmount = cs.Base_Premium_Amount
                });

            return
                result;
        }
        public virtual IEnumerable<Transport.Insured.Discount> GetTransportInsuredDiscount(Transport.Insured.Discount.Key parameter)
        {
            IEnumerable<Transport.Insured.Discount> result;
            IEnumerable<SP_GET_PL_POLICY_TRANSPORT_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_TRANSPORT_INSURED_DISCOUNT
                (
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.TransportId,
                    parameter.DiscountId,
                    parameter.LanguageId
                )
                .ToArray();

            result = temp
                .Select(d => new Transport.Insured.Discount
                {
                    CorpId = d.Corp_Id,
                    RegionId = d.Region_Id,
                    CountryId = d.Country_Id,
                    DomesticregId = d.Domesticreg_Id,
                    StateProvId = d.State_Prov_Id,
                    CityId = d.City_Id,
                    OfficeId = d.Office_Id,
                    CaseSeqNo = d.Case_Seq_No,
                    HistSeqNo = d.Hist_Seq_No,
                    TransportId = d.Transport_Id,
                    DiscountId = d.Discount_Id,
                    DiscountRuleId = d.Discount_Rule_Id,
                    DiscountRuleDetailId = d.Discount_Rule_Detail_Id,
                    NotePredefiniedId = d.Note_Predefinied_Id,
                    PremiumAmount = d.Premium_Amount,
                    OldPremiumAmount = d.Old_Premium_Amount,
                    DetailApplyDate = d.Detail_Apply_Date,
                    DetailRuleValue = d.Detail_Rule_Value,
                    DetailRuleNameKey = d.Detail_Rule_NameKey,
                    DiscountRuleDesc = d.Discount_Rule_Desc,
                    DiscountNameKey = d.Discount_Name_Key,
                    NotePredefiniedDesc = d.Note_Predefinied_Desc,
                    NoteNameKey = d.Note_NameKey,
                    Comment = d.Comment,
                    FullName = d.FullName,
                    UserId = d.UserId
                });

            return
                result;
        }
        public virtual Transport.Insured.Coverage.Surcharge.Key SetTransportInsuredCoverageSurcharge(Transport.Insured.Coverage.Surcharge parameter)
        {
            Transport.Insured.Coverage.Surcharge.Key result;
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_TRANSPORT_COVERAGE_SURCHARGE
                 (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.OldCoverageAmount,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.uniqueTransportId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.VehicleTypeId,
                    parameter.GroupId,
                    parameter.CoverageTypeId,
                    parameter.CoverageId,
                    parameter.UserId,
                    parameter.NotePredefiniedId,
                    parameter.SurchargeStatus
                 )
                 .ToArray();

            result = temp
                .Select(cs => new Transport.Insured.Coverage.Surcharge.Key
                {
                    Action = cs.Action,
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueTransportId = cs.Unique_Transport_Id,
                    BlTypeId = cs.Bl_Type_Id,
                    BlId = cs.Bl_Id,
                    ProductId = cs.Product_Id,
                    VehicleTypeId = cs.Vehicle_Type_Id,
                    GroupId = cs.Group_Id,
                    CoverageTypeId = cs.Coverage_Type_Id,
                    CoverageId = cs.Coverage_Id,
                    SurchargeId = cs.Surcharge_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual Transport.Insured.Discount.Key SetTransportInsuredDiscount(Transport.Insured.Discount parameter)
        {
            Transport.Insured.Discount.Key result;
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_TRANSPORT_INSURED_DISCOUNT
                (
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.TransportId,
                    parameter.DiscountId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.NotePredefiniedId,
                    parameter.PremiumAmount,
                    parameter.OldPremiumAmount,
                    parameter.Comment,
                    parameter.DiscountStatus,
                    parameter.UserId
                )
                .ToArray();

            result = temp
                 .Select(pp => new Transport.Insured.Discount.Key
                 {
                     Action = pp.Action,
                     CorpId = pp.Corp_Id,
                     RegionId = pp.Region_Id,
                     CountryId = pp.Country_Id,
                     DomesticregId = pp.Domesticreg_Id,
                     StateProvId = pp.State_Prov_Id,
                     CityId = pp.City_Id,
                     OfficeId = pp.Office_Id,
                     CaseSeqNo = pp.Case_Seq_No,
                     HistSeqNo = pp.Hist_Seq_No,
                     TransportId = pp.Transport_Id,
                     DiscountId = pp.Discount_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual int SetTransportInsuredApplyDiscountAndSurcharge(Transport.Insured parameter)
        {
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_INSURED_APPLY_DISCOUNT_AND_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_TRANSPORT_INSURED_APPLY_DISCOUNT_AND_SURCHARGE
                (
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticRegId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.UserId
                );

            return
                -1;
        }
        public virtual IEnumerable<Transport.Insured.ExtraInfo> GetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            IEnumerable<Transport.Insured.ExtraInfo> result;
            IEnumerable<SP_GET_PL_POLICY_TRANSPORT_INSURED_EXTRAINFO_Result> temp;

            temp = globalModelExtended.SP_GET_PL_POLICY_TRANSPORT_INSURED_EXTRAINFO
                (
                    parameter.CorpId,
                    parameter.UniqueTransportId,
                    parameter.SeqId
                )
                .ToArray();

            result = temp
                .Select(d => new Transport.Insured.ExtraInfo
                {
                    CorpId = d.Corp_Id,
                    SeqId = d.Seq_Id,
                    UniqueTransportId = d.Unique_Transport_Id,
                    Brand = d.Brand,
                    Model = d.Model,
                    Name = d.Name,
                    Plate = d.Plate,
                    SerialKey = d.Serial_Key,
                    Vin = d.Vin,
                    Year = d.Year,
                    TransportExtraInfoStatusId = d.Transport_ExtraInfo_Status_Id,
                    TransportInsuredId = d.Transport_Insured_Id,
                    TransportInsuredDesc = d.Transport_Insured_Desc
                });

            return
                result;
        }
        public virtual Transport.Insured.ExtraInfo.Key SetTransportInsuredExtraInfo(Transport.Insured.ExtraInfo.Key parameter)
        {
            Transport.Insured.ExtraInfo.Key result;
            IEnumerable<SP_SET_PL_POLICY_TRANSPORT_INSURED_EXTRAINFO_Result> temp;

            temp = globalModelExtended.SP_SET_PL_POLICY_TRANSPORT_INSURED_EXTRAINFO
                (
                    parameter.CorpId,
                    parameter.UniqueTransportId,
                    parameter.SeqId,
                    parameter.Name,
                    parameter.Brand,
                    parameter.Model,
                    parameter.Plate,
                    parameter.Vin,
                    parameter.Year,
                    parameter.SerialKey,
                    parameter.TransportExtraInfoStatusId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp.
                Select(pp => new Transport.Insured.ExtraInfo.Key
                {
                    //Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniqueTransportId = pp.Unique_Transport_Id
                })
                .FirstOrDefault();

            return
                result;
        }
    }
}
