using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class NavyRepository : GlobalRepository
    {
        public NavyRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Navy.Insured.Key SetNavyInsured(Navy.Insured parameter)
        {
            Navy.Insured.Key result;
            IEnumerable<SP_SET_PL_POLICY_NAVY_INSURED_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_INSURED
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
                        parameter.NavyId,
                        parameter.BlTypeId,
                        parameter.BlId,
                        parameter.ProductId,
                        parameter.ReinsuranceId,
                        parameter.ReinsuranceAmount,
                        parameter.Name,
                        parameter.BrandModel,
                        parameter.YearProduction,
                        parameter.SerialKey,
                        parameter.BrandEngine,
                        parameter.Casco,
                        parameter.Purtal,
                        parameter.Eslora,
                        parameter.Manga,
                        parameter.Usage,
                        parameter.NavigationLimit,
                        parameter.BasePort,
                        parameter.YearProductionEngine,
                        parameter.PlaceRefuge,
                        parameter.Year,
                        parameter.PortLoadingType,
                        parameter.CoverageLimitMedicalExpensesOnePerson,
                        parameter.CoverageLimitMedicalExpensesByEvent,
                        parameter.CoverageLimitMedicalExpensesOneCrewMember,
                        parameter.CoverageLimitMedicalExpensesAllCrewMember,
                        parameter.CoverageLimitPersonalAccidentOnePassengers,
                        parameter.CoverageLimitPersonalAccidentAllPassengersByEvent,
                        parameter.CoverageLimitPersonalAccidentOneCrewMember,
                        parameter.CoverageLimitPersonalAccidentAllCrewMember,
                        parameter.CoverageLimitPersonalEffects,
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
                        parameter.NavyStatusId,
                        parameter.UserId,
                        parameter.SourceId
                )
                .ToArray();

            result = temp
                 .Select(pp => new Navy.Insured.Key
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
                     NavyId = pp.Navy_Id,
                     UniqueNavyId = pp.Unique_Navy_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual Navy.Insured.Coverage.Key SetNavyInsuredCoverage(Navy.Insured.Coverage parameter)
        {
            Navy.Insured.Coverage.Key result;
            IEnumerable<SP_SET_PL_POLICY_NAVY_INSURED_COVERAGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_INSURED_COVERAGE
                 (
                    parameter.CorpId,
                    parameter.UniqueNavyId,
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
                .Select(pp => new Navy.Insured.Coverage.Key
                {
                    Action = pp.Action,
                    CorpId = pp.Bl_Id,
                    UniqueNavyId = pp.Unique_Navy_Id,
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

        public virtual IEnumerable<Navy.Insured> GetNavyInsured(Navy.Insured.Key parameter)
        {
            IEnumerable<Navy.Insured> result;
            IEnumerable<SP_GET_PL_POLICY_NAVY_INSURED_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_NAVY_INSURED
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
                    parameter.NavyId
                )
                .ToArray();

            result = temp
                .Select(ni => new Navy.Insured
                {
                    Name = ni.Name,
                    SerialKey = ni.Serial_Key,
                    Year = ni.Year,
                    Manga = ni.Manga,
                    NavigationLimit = ni.Navigation_Limit,
                    BasePort = ni.Base_Port,
                    InsuredDate = ni.Insured_Date,
                    InsuredAmount = ni.Insured_Amount,
                    Rate = ni.Rate,
                    PremiumAmount = ni.Premium_Amount,
                    BasePremiumAmount = ni.Base_Premium_Amount,
                    DeductiblePercentage = ni.Deductible_Percentage,
                    DeductibleAmount = ni.Deductible_Amount,
                    MinimumDeductibleAmount = ni.Minimum_Deductible_Amount,
                    IsNew = ni.New,
                    RequiresInspection = ni.Requires_Inspection,
                    Reinsurance = ni.Reinsurance,
                    Inspected = ni.Inspected,
                    EndorsementClarifying = ni.Endorsement_Clarifying,
                    Endorsement = ni.Endorsement,
                    EndorsementBeneficiary = ni.Endorsement_Beneficiary,
                    EndorsementBeneficiaryRnc = ni.Endorsement_Beneficiary_Rnc,
                    EndorsementAmount = ni.Endorsement_Amount,
                    EndorsementContactName = ni.Endorsement_Contact_Name,
                    EndorsementContactPhone = ni.Endorsement_Contact_Phone,
                    EndorsementContactEmail = ni.Endorsement_Contact_Email,
                    InspectionAddress = ni.Inspection_Address,
                    NavyStatusId = ni.Navy_Status_Id,
                    CorpId = ni.Corp_Id,
                    RegionId = ni.Region_Id,
                    CountryId = ni.Country_Id,
                    DomesticRegId = ni.Domesticreg_Id,
                    StateProvId = ni.State_Prov_Id,
                    CityId = ni.City_Id,
                    OfficeId = ni.Office_Id,
                    CaseSeqNo = ni.Case_Seq_No,
                    HistSeqNo = ni.Hist_Seq_No,
                    NavyId = ni.Navy_Id,
                    UniqueNavyId = ni.Unique_Navy_Id,
                    BlTypeId = ni.Bl_Type_Id,
                    BlId = ni.Bl_Id,
                    ProductId = ni.Product_Id,
                    ReinsuranceId = ni.Reinsurance_Id,
                    ReinsuranceAmount = ni.Reinsurance_Amount,
                    ReinsurancePercentage = ni.Reinsurance_Percentage,
                    BrandModel = ni.Brand_Model,
                    YearProduction = ni.Year_Production,
                    BrandEngine = ni.Brand_Engine,
                    Casco = ni.Casco,
                    Purtal = ni.Purtal,
                    Eslora = ni.Eslora,
                    Usage = ni.Usage,
                    YearProductionEngine = ni.Year_Production_Engine,
                    PlaceRefuge = ni.Place_Refuge,
                    PortLoadingType = ni.Port_Loading_Type,
                    SourceId = ni.Source_Id,
                    ProductDesc = ni.Product_Desc,
                    ProductTypeId = ni.Product_Type_Id,
                    ReinsurancePremiumAmount = ni.Reinsurance_Premium_Amount,
                    CoverageLimitMedicalExpensesOnePerson = ni.Coverage_Limit_Medical_Expenses_OnePerson,
                    CoverageLimitMedicalExpensesByEvent = ni.Coverage_Limit_Medical_Expenses_ByEvent,
                    CoverageLimitMedicalExpensesOneCrewMember = ni.Coverage_Limit_Medical_Expenses_OneCrewMember,
                    CoverageLimitMedicalExpensesAllCrewMember = ni.Coverage_Limit_Medical_Expenses_AllCrewMember,
                    CoverageLimitPersonalAccidentOnePassengers = ni.Coverage_Limit_Personal_Accident_OnePassengers,
                    CoverageLimitPersonalAccidentAllPassengersByEvent = ni.Coverage_Limit_Personal_Accident_AllPassengers_ByEvent,
                    CoverageLimitPersonalAccidentOneCrewMember = ni.Coverage_Limit_Personal_Accident_OneCrewMember,
                    CoverageLimitPersonalAccidentAllCrewMember = ni.Coverage_Limit_Personal_Accident_AllCrewMember,
                    CoverageLimitPersonalEffects = ni.Coverage_Limit_Personal_Effects,
                    Ramo = ni.Ramo,
                    SubRamo = ni.SubRamo
                });

            return
                result;
        }
        public virtual IEnumerable<Navy.Insured.Coverage> GetNavyInsuredCoverage(Navy.Insured.Coverage.Key parameter)
        {
            IEnumerable<Navy.Insured.Coverage> result;
            IEnumerable<SP_GET_PL_POLICY_NAVY_INSURED_COVERAGE_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_NAVY_INSURED_COVERAGE
                (
                     parameter.CorpId,
                     parameter.UniqueNavyId
                )
                .ToArray();

            result = temp
                .Select(pp => new Navy.Insured.Coverage
                {
                    CurrencyId = pp.Currency_Id,
                    UnitaryPrice = pp.Unitary_Price,
                    PackagePrice = pp.Package_Price,
                    DeductibleAmount = pp.Deductible_Amount,
                    DeductiblePercentage = pp.Deductible_Percentage,
                    ManualDeductibleAmount = pp.Manual_Deductible_Amount,
                    ManualDeductiblePercentage = pp.Manual_Deductible_Percentage,
                    CoverageLimit = pp.Coverage_Limit,
                    CoverageDesc = pp.Coverage_Desc,
                    GroupDesc = pp.Group_Desc,
                    CoverageTypeDesc = pp.Coverage_Type_Desc,
                    CoverageStatus = pp.Coverage_Status,
                    CorpId = pp.Corp_Id,
                    UniqueNavyId = pp.Unique_Navy_Id,
                    RegionId = pp.Region_Id,
                    CountryId = pp.Country_Id,
                    BlTypeId = pp.Bl_Type_Id,
                    BlId = pp.Bl_Id,
                    ProductId = pp.Product_Id,
                    VehicleTypeId = pp.Vehicle_Type_Id,
                    GroupId = pp.Group_Id,
                    CoverageTypeId = pp.Coverage_Id,
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

        public virtual IEnumerable<Navy.Insured.Coverage.Surcharge> GetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge.Key parameter)
        {
            IEnumerable<Navy.Insured.Coverage.Surcharge> result;
            IEnumerable<SP_GET_PL_POLICY_NAVY_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_NAVY_COVERAGE_SURCHARGE
                (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueNavyId,
                    parameter.BlTypeId,
                    parameter.BlId,
                    parameter.ProductId,
                    parameter.VehicleTypeId,
                    parameter.GroupId,
                    parameter.CoverageTypeId,
                    parameter.CoverageId,
                    parameter.LanguageId
                )
                .ToArray();

            result = temp
                .Select(cs => new Navy.Insured.Coverage.Surcharge
                {
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueNavyId = cs.Unique_Navy_Id,
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
        public virtual IEnumerable<Navy.Insured.Discount> GetNavyInsuredDiscount(Navy.Insured.Discount.Key parameter)
        {
            IEnumerable<Navy.Insured.Discount> result;
            IEnumerable<SP_GET_PL_POLICY_NAVY_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_NAVY_INSURED_DISCOUNT
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
                    parameter.NavyId,
                    parameter.DiscountId,
                    parameter.LanguageId
                )
                .ToArray();

            result = temp
                .Select(d => new Navy.Insured.Discount
                {
                    CorpId = d.Corp_Id,
                    RegionId = d.Region_Id,
                    CountryId = d.Country_Id,
                    DomesticRegId = d.Domesticreg_Id,
                    StateProvId = d.State_Prov_Id,
                    CityId = d.City_Id,
                    OfficeId = d.Office_Id,
                    CaseSeqNo = d.Case_Seq_No,
                    HistSeqNo = d.Hist_Seq_No,
                    NavyId = d.Navy_Id,
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

        public virtual Navy.Insured.Coverage.Surcharge.Key SetNavyInsuredCoverageSurcharge(Navy.Insured.Coverage.Surcharge parameter)
        {
            Navy.Insured.Coverage.Surcharge.Key result;
            IEnumerable<SP_SET_PL_POLICY_NAVY_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_COVERAGE_SURCHARGE
                 (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.OldCoverageAmount,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueNavyId,
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
                .Select(cs => new Navy.Insured.Coverage.Surcharge.Key
                {
                    Action = cs.Action,
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueNavyId = cs.Unique_Navy_Id,
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
        public virtual Navy.Insured.Discount.Key SetNavyInsuredDiscount(Navy.Insured.Discount parameter)
        {
            Navy.Insured.Discount.Key result;
            IEnumerable<SP_SET_PL_POLICY_NAVY_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_INSURED_DISCOUNT
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
                    parameter.NavyId,
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
                 .Select(pp => new Navy.Insured.Discount.Key
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
                     NavyId = pp.Navy_Id,
                     DiscountId = pp.Discount_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual int SetNavyInsuredApplyDiscountAndSurcharge(Navy.Insured parameter)
        {
            IEnumerable<SP_SET_PL_POLICY_NAVY_INSURED_APPLY_DISCOUNT_AND_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_INSURED_APPLY_DISCOUNT_AND_SURCHARGE
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

        public virtual Navy.Insured.Engine SetNavyInsuredEngine(Navy.Insured.Engine parameter)
        {
            Navy.Insured.Engine result;
            IEnumerable<SP_SET_PL_POLICY_NAVY_INSURED_ENGINE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_NAVY_INSURED_ENGINE
                 (
                  parameter.CorpId,
                  parameter.UniqueNavyId,
                  parameter.EngineId,
                  parameter.EngineType,
                  parameter.EngineQty,
                  parameter.CapacityHP,
                  parameter.Serial,
                  parameter.Brand,
                  parameter.Model,
                  parameter.Year,
                  parameter.FuelType,
                  parameter.EngineStatusId,
                  parameter.usrId,
                  parameter.sourceId
                 )
                 .ToArray();

            result = temp
                .Select(cs => new Navy.Insured.Engine
                {
                    Action = cs.Action,
                    CorpId = cs.Corp_Id,
                    EngineId = cs.Engine_Id,
                    UniqueNavyId = cs.Unique_Navy_Id
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual IEnumerable<Navy.Insured.Engine> GetNavyInsuredEngine(Navy.Insured.Engine.parameter parameter)
        {
            IEnumerable<Navy.Insured.Engine> result;
            IEnumerable<SP_GET_PL_POLICY_NAVY_INSURED_ENGINE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_NAVY_INSURED_ENGINE
                (
                    parameter.corpId,
                    parameter.uniqueNavyId,
                    parameter.engineId
                )
                .ToArray();

            result = temp
                .Select(ni => new Navy.Insured.Engine
                {
                    CorpId = ni.Corp_Id,
                    UniqueNavyId = ni.Unique_Navy_Id,
                    EngineId = ni.Engine_Id,
                    EngineType = ni.Engine_Type,
                    EngineQty = ni.Engine_Qty,
                    CapacityHP = ni.Capacity_HP,
                    Serial = ni.Serial,
                    Brand = ni.Brand,
                    Model = ni.Model,
                    Year = ni.Year,
                    FuelType = ni.Fuel_Type,
                    EngineStatusId = ni.Engine_Status_Id
                });

            return
                result;
        }
    }
}
