using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class AirPlaneRepository : GlobalRepository
    {
        public AirPlaneRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Airplane.Insured.Key SetAirplaneInsured(Airplane.Insured parameter)
        {
            Airplane.Insured.Key result;
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_INSURED_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_AIRPLANE_INSURED
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
                    parameter.AirplaneId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.ReinsuranceId,
                    parameter.ReinsuranceAmount,
                    parameter.AirplaneBase,
                    parameter.YearProduction,
                    parameter.YearProductionEngine,
                    parameter.AirportFeatures,
                    parameter.LandingState,
                    parameter.FuselageFailures,
                    parameter.PlaceRefuge,
                    parameter.HullMaintenance,
                    parameter.BrandModel,
                    parameter.HullMaterial,
                    parameter.Name,
                    parameter.EngineBrandModel,
                    parameter.SerialKey,
                    parameter.EngineOverhaul,
                    parameter.Usage,
                    parameter.Year,
                    parameter.CoverageLimitMedicalExpensesOnePassenger,
                    parameter.CoverageLimitMedicalExpensesAllPassenger,
                    parameter.CoverageLimitMedicalExpensesOneCrewman,
                    parameter.CoverageLimitMedicalExpensesAllCrewman,
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
                    parameter.AirplaneStatusId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp
                .Select(pp => new Airplane.Insured.Key
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    RegionId = pp.Region_Id,
                    CountryId = pp.Country_Id,
                    DomesticRegId = pp.Domesticreg_Id,
                    StateProvId = pp.State_Prov_Id,
                    CityId = pp.City_Id,
                    OfficeId = pp.Office_Id,
                    CaseSeqNo = pp.Case_Seq_No,
                    HistSeqNo = pp.Hist_Seq_No,
                    AirplaneId = pp.Airplane_Id,
                    UniqueAirplaneId = pp.Unique_Airplane_Id
                }).FirstOrDefault();

            return
                result;
        }
        public virtual Airplane.Insured.Coverage.Key SetAirPlaneInsuredCoverage(Airplane.Insured.Coverage parameter)
        {
            Airplane.Insured.Coverage.Key result;
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_INSURED_COVERAGE_Result> temp;
            temp = globalModel.SP_SET_PL_POLICY_AIRPLANE_INSURED_COVERAGE
                (
                    parameter.CorpId,
                    parameter.UniqueAirplaneId,
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

            result = temp
                .Select(pp => new Airplane.Insured.Coverage.Key
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniqueAirplaneId = pp.Unique_Airplane_Id,
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
        public virtual Airplane.Insured.Pilot.Key SetAirPlaneInsuredPilot(Airplane.Insured.Pilot parameter)
        {
            Airplane.Insured.Pilot.Key result;
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_INSURED_PILOT_Result> temp;
            temp = globalModelExtended.SP_SET_PL_POLICY_AIRPLANE_INSURED_PILOT
                (
                    parameter.CorpId,
                    parameter.UniqueAirplaneId,
                    parameter.SeqId,
                    parameter.Name,
                    parameter.Flighthours,
                    parameter.AirplanePilotStatus,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp
                .Select(pp => new Airplane.Insured.Pilot.Key
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniqueAirplaneId = pp.Unique_Airplane_Id,
                    SeqId = pp.Seq_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual IEnumerable<Airplane.Insured> GetAirplaneInsured(Airplane.Insured.Key parameter)
        {
            IEnumerable<Airplane.Insured> result;
            IEnumerable<SP_GET_PL_POLICY_AIRPLANE_INSURED_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_AIRPLANE_INSURED
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
                   parameter.AirplaneId
                )
                .ToArray();

            result = temp
                    .Select(pp => new Airplane.Insured
                    {
                        Name = pp.Name,
                        SerialKey = pp.Serial_Key,
                        Year = pp.Year,
                        Usage = pp.Usage,
                        AirplaneBase = pp.Airplane_Base,
                        InsuredAmount = pp.Insured_Amount,
                        Rate = pp.Rate,
                        PremiumAmount = pp.Premium_Amount,
                        BasePremiumAmount = pp.Base_Premium_Amount,
                        DeductiblePercentage = pp.Deductible_Percentage,
                        DeductibleAmount = pp.Deductible_Amount,
                        MinimumDeductibleAmount = pp.Minimum_Deductible_Amount,
                        IsNew = pp.New,
                        RequiresInspection = pp.Requires_Inspection,
                        Reinsurance = pp.Reinsurance,
                        Inspected = pp.Inspected,
                        EndorsementClarifying = pp.Endorsement_Clarifying,
                        Endorsement = pp.Endorsement,
                        EndorsementBeneficiary = pp.Endorsement_Beneficiary,
                        EndorsementBeneficiaryRnc = pp.Endorsement_Beneficiary_Rnc,
                        EndorsementAmount = pp.Endorsement_Amount,
                        EndorsementContactName = pp.Endorsement_Contact_Name,
                        EndorsementContactPhone = pp.Endorsement_Contact_Phone,
                        EndorsementContactEmail = pp.Endorsement_Contact_Email,
                        InspectionAddress = pp.Inspection_Address,
                        AirplaneStatusId = pp.Airplane_Status_Id,
                        CorpId = pp.Corp_Id,
                        RegionId = pp.Region_Id,
                        CountryId = pp.Country_Id,
                        DomesticRegId = pp.Domesticreg_Id,
                        StateProvId = pp.State_Prov_Id,
                        CityId = pp.City_Id,
                        OfficeId = pp.Office_Id,
                        CaseSeqNo = pp.Case_Seq_No,
                        HistSeqNo = pp.Hist_Seq_No,
                        AirplaneId = pp.Airplane_Id,
                        UniqueAirplaneId = pp.Unique_Airplane_Id,
                        BlTypeId = pp.Bl_Type_Id,
                        BlId = pp.Bl_Id,
                        ProductId = pp.Product_Id,
                        ReinsuranceId = pp.Reinsurance_Id,
                        ReinsuranceAmount = pp.Reinsurance_Amount,
                        ReinsurancePercentage = pp.Reinsurance_Percentage,
                        YearProduction = pp.YearProduction,
                        YearProductionEngine = pp.YearProductionEngine,
                        AirportFeatures = pp.AirportFeatures,
                        LandingState = pp.LandingState,
                        FuselageFailures = pp.FuselageFailures,
                        PlaceRefuge = pp.PlaceRefuge,
                        HullMaintenance = pp.HullMaintenance,
                        BrandModel = pp.BrandModel,
                        HullMaterial = pp.HullMaterial,
                        EngineBrandModel = pp.EngineBrandModel,
                        EngineOverhaul = pp.EngineOverhaul,
                        SourceId = pp.Source_Id,
                        CoverageLimitMedicalExpensesOnePassenger = pp.Coverage_Limit_Medical_Expenses_OnePassenger,
                        CoverageLimitMedicalExpensesAllPassenger = pp.Coverage_Limit_Medical_Expenses_AllPassenger,
                        CoverageLimitMedicalExpensesOneCrewman = pp.Coverage_Limit_Medical_Expenses_OneCrewman,
                        CoverageLimitMedicalExpensesAllCrewman = pp.Coverage_Limit_Medical_Expenses_AllCrewman,
                        ProductDesc = pp.Product_Desc,
                        ProductTypeId = pp.Product_Type_Id,
                        ReinsurancePremiumAmount = pp.Reinsurance_Premium_Amount,
                        Ramo = pp.Ramo,
                        SubRamo = pp.SubRamo
                    });

            return
                 result;
        }
        public virtual IEnumerable<Airplane.Insured.Coverage> GetAirPlaneInsuredCoverage(Airplane.Insured.Coverage.Key parameter)
        {
            IEnumerable<Airplane.Insured.Coverage> result;
            IEnumerable<SP_GET_PL_POLICY_AIRPLANE_INSURED_COVERAGE_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_AIRPLANE_INSURED_COVERAGE
                (
                 parameter.CorpId,
                 parameter.UniqueAirplaneId
                )
                .ToArray();

            result = temp
                .Select(pp => new Airplane.Insured.Coverage
                {
                    CurrencyId = pp.Currency_Id,
                    UnitaryPrice = pp.Unitary_Price,
                    PackagePrice = pp.Package_Price,
                    DeductibleAmount = pp.Deductible_Amount,
                    DeductiblePercentage = pp.Deductible_Percentage,
                    ManualDeductibleAmount = pp.Manual_Deductible_Amount,
                    ManualDeductiblePercentage = pp.Manual_Deductible_Percentage,
                    CoverageLimit = pp.Coverage_Limit,
                    CoverageStatus = pp.Coverage_Status,
                    CorpId = pp.Corp_Id,
                    UniqueAirplaneId = pp.Unique_Airplane_Id,
                    RegionId = pp.Region_Id,
                    CountryId = pp.Country_Id,
                    BlTypeId = pp.Bl_Type_Id,
                    CoverageDesc = pp.Coverage_Desc,
                    CoverageTypeDesc = pp.Coverage_Type_Desc,
                    BlId = pp.Bl_Id,
                    ProductId = pp.Product_Id,
                    VehicleTypeId = pp.Vehicle_Type_Id,
                    GroupId = pp.Group_Id,
                    CoverageTypeId = pp.Coverage_Type_Id,
                    CoverageId = pp.Coverage_Id,
                    Ramo = pp.Ramo,
                    SubRamo = pp.SubRamo,
                    RamoDesc = pp.Ramo_Desc,
                    SubRamoDesc = pp.SubRamo_Desc,
                    CoveragePercentage = pp.Coverage_Percentage,
                    PremiumPercentage = pp.Premium_Percentage,
                    CoinsurancePercentage = pp.Coinsurance_Percentage
                });

            return
                result;
        }
        public virtual IEnumerable<Airplane.Insured.Pilot> GetAirplaneInsuredPilot(Airplane.Insured.Pilot.Key parameter)
        {
            IEnumerable<Airplane.Insured.Pilot> result;
            IEnumerable<SP_GET_PL_POLICY_AIRPLANE_INSURED_PILOT_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_AIRPLANE_INSURED_PILOT
                (
                      parameter.CorpId,
                      parameter.UniqueAirplaneId,
                      parameter.SeqId
                )
                .ToArray();

            result = temp
                .Select(pp => new Airplane.Insured.Pilot
                {
                    Name = pp.Name,
                    Flighthours = pp.Flight_hours,
                    AirplanePilotStatus = pp.Airplane_Pilot_Status,
                    CorpId = pp.Corp_Id,
                    UniqueAirplaneId = pp.Unique_Airplane_Id,
                    SeqId = pp.Seq_Id
                });

            return
                result;
        }
        public virtual IEnumerable<Airplane.Insured.Coverage.Surcharge> GetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge.Key parameter)
        {
            IEnumerable<Airplane.Insured.Coverage.Surcharge> result;
            IEnumerable<SP_GET_PL_POLICY_AIRPLANE_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_AIRPLANE_COVERAGE_SURCHARGE
                (
                    parameter.SurchargeId,
                    parameter.discountRuleId,
                    parameter.discountRuleDetailId,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueAirplaneId,
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
                .Select(cs => new Airplane.Insured.Coverage.Surcharge
                {
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueAirplaneId = cs.Unique_Airplane_Id,
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
                    NotePredefiniedId = cs.Note_Predefinied_Id.GetValueOrDefault(),
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
        public virtual IEnumerable<Airplane.Insured.Discount> GetAirplaneInsuredDiscount(Airplane.Insured.Discount.Key parameter)
        {
            IEnumerable<Airplane.Insured.Discount> result;
            IEnumerable<SP_GET_PL_POLICY_AIRPLANE_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_AIRPLANE_INSURED_DISCOUNT
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
                    parameter.AirplaneId,
                    parameter.DiscountId,
                    parameter.languageId
                )
                .ToArray();

            result = temp
                .Select(d => new Airplane.Insured.Discount
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
                    AirplaneId = d.Airplane_Id,
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
        public virtual Airplane.Insured.Coverage.Surcharge.Key SetAirplaneCoverageSurcharge(Airplane.Insured.Coverage.Surcharge parameter)
        {
            Airplane.Insured.Coverage.Surcharge.Key result;
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_AIRPLANE_COVERAGE_SURCHARGE
                 (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.OldCoverageAmount,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueAirplaneId,
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
                .Select(cs => new Airplane.Insured.Coverage.Surcharge.Key
                {
                    Action = cs.Action,
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueAirplaneId = cs.Unique_Airplane_Id,
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
        public virtual Airplane.Insured.Discount.Key SetAirplaneInsuredDiscount(Airplane.Insured.Discount parameter)
        {
            Airplane.Insured.Discount.Key result;
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_AIRPLANE_INSURED_DISCOUNT
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
                    parameter.AirplaneId,
                    parameter.DiscountId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.NotePredefiniedId,
                    parameter.PremiumAmount,
                    parameter.OldPremiumAmount,
                    parameter.Comment,
                    parameter.discountStatus,
                    parameter.UserId
                )
                .ToArray();

            result = temp
                 .Select(pp => new Airplane.Insured.Discount.Key
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
                     AirplaneId = pp.Airplane_Id,
                     DiscountId = pp.Discount_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual int SetAirplaneApplyDiscountAndSurcharge(Airplane.Insured parameter)
        {
            IEnumerable<SP_SET_PL_POLICY_AIRPLANE_INSURED_APPLY_DISCOUNT_AND_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_AIRPLANE_INSURED_APPLY_DISCOUNT_AND_SURCHARGE
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
    }
}
