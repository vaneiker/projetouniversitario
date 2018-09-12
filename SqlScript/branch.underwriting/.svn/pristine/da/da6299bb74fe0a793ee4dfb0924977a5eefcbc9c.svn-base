using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class BailRepository : GlobalRepository
    {
        public BailRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual Bail.Insured.Key SetBailInsured(Bail.Insured parameter)
        {
            Bail.Insured.Key result;
            IEnumerable<SP_SET_PL_POLICY_BAIL_INSURED_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_BAIL_INSURED
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
                 parameter.BailId,
                 parameter.BlTypeId,
                 parameter.BlId,
                 parameter.ProductId,
                 parameter.ReinsuranceId,
                 parameter.ReinsuranceAmount,
                 parameter.EquipmentQty,
                 parameter.ContractAmount,
                 parameter.Beneficiary,
                 parameter.Activity,
                 parameter.BusinessType,
                 parameter.BailType,
                 parameter.PercentageInsuredAmount,
                 parameter.Obligations,
                 parameter.ToDepositIn,
                 parameter.AddressStreet,
                 parameter.AddressNumber,
                 parameter.AddressCountryId,
                 parameter.AddressDomesticregId,
                 parameter.AddressStateProvId,
                 parameter.AddressCityId,
                 parameter.HasEndOfTerm,
                 parameter.IsBuilding,
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
                 parameter.BailStatusId,
                 parameter.UsrId,
                 parameter.SourceId

                    )
                .ToArray();

            result = temp
                .Select(pp => new Bail.Insured.Key
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
                    BailId = pp.Bail_Id
                })
                 .FirstOrDefault();

            return
                  result;
        }
        public virtual Bail.Insured.Coverage.Key SetBailInsuredCoverage(Bail.Insured.Coverage parameter)
        {
            Bail.Insured.Coverage.Key result;
            IEnumerable<SP_SET_PL_POLICY_BAIL_INSURED_COVERAGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_BAIL_INSURED_COVERAGE
                (
                    parameter.CorpId,
                    parameter.UniqueBailId,
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
                Select(pp => new Bail.Insured.Coverage.Key
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniqueBailId = pp.Unique_Bail_Id,
                    RegionId = pp.Region_Id,
                    CountryId = pp.Country_Id,
                    BlTypeId = pp.Bl_Type_Id,
                    BlId = pp.Bl_Id,
                    ProductId = pp.Product_Id,
                    VehicleTypeId = pp.Vehicle_Type_Id,
                    GroupId = pp.Group_Id,
                    CoverageTypeId = pp.Coverage_Type_Id,
                })
                .FirstOrDefault();

            return
                 result;
        }

        public virtual IEnumerable<Bail.Insured> GetBailInsured(Bail.Insured.Key parameter)
        {
            IEnumerable<Bail.Insured> result;
            IEnumerable<SP_GET_PL_POLICY_BAIL_INSURED_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_BAIL_INSURED
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
                        parameter.BailId
                );

            result = temp
                .Select(bi => new Bail.Insured
                {
                    EquipmentQty = bi.Equipment_Qty,
                    InsuredDate = bi.Insured_Date,
                    InsuredAmount = bi.Insured_Amount,
                    Rate = bi.Rate,
                    PremiumAmount = bi.Premium_Amount,
                    BasePremiumAmount = bi.Base_Premium_Amount,
                    DeductiblePercentage = bi.Deductible_Percentage,
                    DeductibleAmount = bi.Deductible_Amount,
                    MinimumDeductibleAmount = bi.Minimum_Deductible_Amount,
                    IsNew = bi.New,
                    RequiresInspection = bi.Requires_Inspection,
                    Reinsurance = bi.Reinsurance,
                    Inspected = bi.Inspected,
                    EndorsementClarifying = bi.Endorsement_Clarifying,
                    Endorsement = bi.Endorsement,
                    EndorsementBeneficiary = bi.Endorsement_Beneficiary,
                    EndorsementBeneficiaryRnc = bi.Endorsement_Beneficiary_Rnc,
                    EndorsementAmount = bi.Endorsement_Amount,
                    EndorsementContactName = bi.Endorsement_Contact_Name,
                    EndorsementContactPhone = bi.Endorsement_Contact_Phone,
                    EndorsementContactEmail = bi.Endorsement_Contact_Email,
                    InspectionAddress = bi.Inspection_Address,
                    BailStatusId = bi.Bail_Status_Id,
                    CorpId = bi.Corp_Id,
                    RegionId = bi.Region_Id,
                    CountryId = bi.Country_Id,
                    DomesticregId = bi.Domesticreg_Id,
                    StateProvId = bi.State_Prov_Id,
                    CityId = bi.City_Id,
                    OfficeId = bi.Office_Id,
                    CaseSeqNo = bi.Case_Seq_No,
                    HistSeqNo = bi.Hist_Seq_No,
                    BailId = bi.Bail_Id,
                    UniqueBailId = bi.Unique_Bail_Id,
                    BlTypeId = bi.Bl_Type_Id,
                    BlId = bi.Bl_Id,
                    ProductId = bi.Product_Id,
                    ProductDesc = bi.Product_Desc,
                    ProductTypeId = bi.Product_Type_Id,
                    ReinsuranceId = bi.Reinsurance_Id,
                    ReinsuranceAmount = bi.Reinsurance_Amount,
                    ReinsurancePercentage = bi.Reinsurance_Percentage,
                    ContractAmount = bi.ContractAmount,
                    Beneficiary = bi.Beneficiary,
                    Activity = bi.Activity,
                    BusinessType = bi.BusinessType,
                    BailType = bi.BailType,
                    PercentageInsuredAmount = bi.PercentageInsuredAmount,
                    HasEndOfTerm = bi.Has_End_Of_Term,
                    Obligations = bi.Obligations,
                    ToDepositIn = bi.To_Deposit_In,
                    AddressStreet = bi.Address_Street,
                    AddressNumber = bi.Address_Number,
                    AddressCountryId = bi.Address_Country_Id,
                    AddressDomesticregId = bi.Address_Domesticreg_Id,
                    AddressStateProvId = bi.Address_State_Prov_Id,
                    AddressCityId = bi.Address_City_Id,
                    ReinsurancePremiumAmount = bi.Reinsurance_Premium_Amount,
                    Ramo = bi.Ramo,
                    SubRamo = bi.SubRamo,
                    IsBuilding = bi.Is_Building,
                    AddressCountryDesc = bi.Address_Country_Desc,
                    AddressDomesticregDesc = bi.Address_Domesticreg_Desc,
                    AddressStateProvDesc = bi.Address_State_Prov_Desc,
                    AddressMunicipioDesc = bi.Address_Municipio_Desc,
                    AddressCityDesc = bi.Address_City_Desc
                })
                .ToArray();

            return
                result;
        }
        public virtual IEnumerable<Bail.Insured.Coverage> GetBailInsuredCoverage(Bail.Insured.Coverage.Key parameter)
        {
            IEnumerable<Bail.Insured.Coverage> result;
            IEnumerable<SP_GET_PL_POLICY_BAIL_INSURED_COVERAGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_BAIL_INSURED_COVERAGE
                (
                    parameter.CorpId,
                    parameter.UniqueBailId
                );

            result = temp
                .Select(bc => new Bail.Insured.Coverage
                {
                    CurrencyId = bc.Currency_Id,
                    UnitaryPrice = bc.Unitary_Price,
                    PackagePrice = bc.Package_Price,
                    DeductibleAmount = bc.Deductible_Amount,
                    DeductiblePercentage = bc.Deductible_Percentage,
                    ManualDeductibleAmount = bc.Manual_Deductible_Amount,
                    ManualDeductiblePercentage = bc.Manual_Deductible_Percentage,
                    CoverageLimit = bc.Coverage_Limit,
                    CoverageStatus = bc.Coverage_Status,
                    CoverageDesc = bc.Coverage_Desc,
                    CoverageTypeDesc = bc.Coverage_Type_Desc,
                    CorpId = bc.Corp_Id,
                    UniqueBailId = bc.Unique_Bail_Id,
                    RegionId = bc.Region_Id,
                    CountryId = bc.Country_Id,
                    BlTypeId = bc.Bl_Type_Id,
                    BlId = bc.Bl_Id,
                    ProductId = bc.Product_Id,
                    VehicleTypeId = bc.Vehicle_Type_Id,
                    GroupId = bc.Group_Id,
                    CoverageTypeId = bc.Coverage_Type_Id,
                    CoverageId = bc.Coverage_Id,
                    Ramo = bc.Ramo,
                    SubRamo = bc.SubRamo,
                    RamoDesc = bc.Ramo_Desc,
                    SubRamoDesc = bc.SubRamo_Desc,
                    CoveragePercentage = bc.Coverage_Percentage,
                    PremiumPercentage = bc.Premium_Percentage,
                    CoinsurancePercentage = bc.Coinsurance_Percentage
                })
                .ToArray();

            return
                result;
        }
        public virtual IEnumerable<Bail.Insured.Coverage.Surcharge> GetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge.Key parameter)
        {
            IEnumerable<Bail.Insured.Coverage.Surcharge> result;
            IEnumerable<SP_GET_PL_POLICY_BAIL_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_BAIL_COVERAGE_SURCHARGE
                (
                    parameter.SurchargeId,
                    parameter.discountRuleId,
                    parameter.discountRuleDetailId,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueBailId,
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
                .Select(cs => new Bail.Insured.Coverage.Surcharge
                {
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueBailId = cs.Unique_Bail_Id,
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
        public virtual IEnumerable<Bail.Insured.Discount> GetBailInsuredDiscount(Bail.Insured.Discount.Key parameter)
        {
            IEnumerable<Bail.Insured.Discount> result;
            IEnumerable<SP_GET_PL_POLICY_BAIL_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_BAIL_INSURED_DISCOUNT
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
                    parameter.BailId,
                    parameter.DiscountId,
                    parameter.LanguageId
                )
                .ToArray();

            result = temp
                .Select(d => new Bail.Insured.Discount
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
                    BailId = d.Bail_Id,
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
        public virtual Bail.Insured.Coverage.Surcharge.Key SetBailInsuredCoverageSurcharge(Bail.Insured.Coverage.Surcharge parameter)
        {
            Bail.Insured.Coverage.Surcharge.Key result;
            IEnumerable<SP_SET_PL_POLICY_BAIL_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_BAIL_COVERAGE_SURCHARGE
                 (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.OldCoverageAmount,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniqueBailId,
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
                .Select(cs => new Bail.Insured.Coverage.Surcharge.Key
                {
                    Action = cs.Action,
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniqueBailId = cs.Unique_Bail_Id,
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
        public virtual Bail.Insured.Discount.Key SetBailInsuredDiscount(Bail.Insured.Discount parameter)
        {
            Bail.Insured.Discount.Key result;
            IEnumerable<SP_SET_PL_POLICY_BAIL_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_BAIL_INSURED_DISCOUNT
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
                    parameter.BailId,
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
                 .Select(pp => new Bail.Insured.Discount.Key
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
                     BailId = pp.Bail_Id,
                     DiscountId = pp.Discount_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual int SetBailInsuredApplyDiscountAndSurcharge(Bail.Insured parameter)
        {
            IEnumerable<SP_SET_PL_POLICY_BAIL_INSURED_APPLY_DISCOUNT_AND_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_BAIL_INSURED_APPLY_DISCOUNT_AND_SURCHARGE
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
                    parameter.UsrId
                );

            return
                -1;
        }

        public virtual IEnumerable<Bail.Insured.Guarantors> GetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            IEnumerable<Bail.Insured.Guarantors> result = null;
            IEnumerable<SP_GET_PL_POLICY_BAIL_INSURED_GUARANTORS_Result> temp;

            temp = globalModelExtended.SP_GET_PL_POLICY_BAIL_INSURED_GUARANTORS
                (
                    parameter.CorpId,
                    parameter.UniqueBailId,
                    parameter.SeqId
                );

            result = temp
                .Select(bc => new Bail.Insured.Guarantors
                {
                    Address = bc.Address,
                    BaileeStatusId = bc.Bailee_Status_Id,
                    CityId = bc.City_Id,
                    CorpId = bc.Corp_Id,
                    CountryId = bc.Country_Id,
                    DomesticregId = bc.Domesticreg_Id,
                    Email = bc.Email,
                    Identification = bc.Identification,
                    IdentificationTypeId = bc.Identification_Type_Id,
                    LastName = bc.LastName,
                    Name = bc.Name,
                    NationalityCountryId = bc.Nationality_Country_Id,
                    Phone = bc.Phone,
                    RepresentativeIdentification = bc.Representative_Identification,
                    RepresentativeIdentificationTypeId = bc.Representative_Identification_Type_Id,
                    RepresentativeName = bc.Representative_Name,
                    SeqId = bc.Seq_Id,
                    SourceId = bc.Source_Id,
                    StateProvId = bc.State_Prov_Id,
                    UniqueBailId = bc.Unique_Bail_Id,
                    Sector = bc.Sector,
                    CityDesc = bc.City,
                    CountryDesc = bc.CountryDesc,
                    IdentificationTypeDesc = bc.IdentificationTypeDesc,
                    RepresentativeIdentificationTypeDesc = bc.RepresentativeIdentificationTypeDesc,
                    NationalityCountryDesc = bc.NationalityCountryDesc,
                    TipoRiesgoNameKey = bc.Tipo_Riesgo_Name_Key,
                    MunicipioDesc = bc.Municipio_Desc,
                    MunicipioId = bc.Municipio_Id,
                    IdPais = bc.IdPais,
                    IdProvincia = bc.IdProvincia,
                    IdMunicipio = bc.IdMunicipio,
                    IdSector = bc.IdSector,
                    IdentificationTypeIdSysflex = bc.Identification_Type_Id_Sysflex,
                    RepresentativeIdentificationTypeIdSysflex = bc.Representative_Identification_Type_Id_Sysflex
                })
                .ToArray();

            return
                result;
        }

        public virtual Bail.Insured.Guarantors.Key SetBailInsuredGuarantors(Bail.Insured.Guarantors.Key parameter)
        {
            Bail.Insured.Guarantors.Key result;
            IEnumerable<SP_SET_PL_POLICY_BAIL_INSURED_GUARANTORS_Result> temp;

            temp = globalModelExtended.SP_SET_PL_POLICY_BAIL_INSURED_GUARANTORS
                (
                    parameter.CorpId,
                    parameter.UniqueBailId,
                    parameter.SeqId,
                    parameter.IdentificationTypeId,
                    parameter.Identification,
                    parameter.Name,
                    parameter.LastName,
                    parameter.Email,
                    parameter.Phone,
                    parameter.Address,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.NationalityCountryId,
                    parameter.RepresentativeName,
                    parameter.RepresentativeIdentificationTypeId,
                    parameter.RepresentativeIdentification,
                    parameter.BaileeStatusId,
                    parameter.UserId,
                    parameter.SourceId,
                    parameter.TipoRiesgoNameKey
                )
                .ToArray();

            result = temp
                 .Select(pp => new Bail.Insured.Guarantors.Key
                 {
                     //Action = pp.Action,
                     CorpId = pp.Corp_Id,
                     UniqueBailId = pp.Unique_Bail_Id,
                     SeqId = pp.Seq_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
    }
}
