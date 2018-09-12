using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class PropertyRepository : GlobalRepository
    {
        public PropertyRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<Property> GetProperty(Property.Key parameter)
        {
            IEnumerable<Property> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL_Result> temp;

            temp = globalModelExtended.SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL(
                        parameter.CorpId,
                        parameter.RegionId,
                        parameter.CountryId,
                        parameter.DomesticregId,
                        parameter.StateProvId,
                        parameter.CityId,
                        parameter.OfficeId,
                        parameter.CaseSeqNo,
                        parameter.HistSeqNo
                    );

            result = temp
                .Select(p => new Property
                {

                    CorpId = p.Corp_Id,
                    RegionId = p.Region_Id,
                    CountryId = p.Country_Id,
                    DomesticregId = p.Domesticreg_Id,
                    StateProvId = p.State_Prov_Id,
                    CityId = p.City_Id,
                    OfficeId = p.Office_Id,
                    CaseSeqNo = p.Case_Seq_No,
                    HistSeqNo = p.Hist_Seq_No,
                    PropertyId = p.Property_Id,
                    SeqId = p.Seq_Id,
                    UniquePropertyId = p.Unique_Property_Id,
                    InsurableTypeId = p.Insurable_Type_Id,
                    InsurableTypeDesc = p.Insurable_Type_Desc,
                    InsuredDetailTypeId = p.Insured_Detail_Type_Id,
                    InsuredDetailTypeDesc = p.Insured_Detail_Type_Desc,
                    EquipmentTypeId = p.Equipment_Type_Id,
                    EquipmentTypeDesc = p.Equipment_Type_Desc,
                    ConditionId = p.Condition_Id,
                    ConditionDesc = p.Condition_Desc,
                    BlTypeId = p.Bl_Type_Id,
                    BlId = p.Bl_Id,
                    ProductId = p.Product_Id,
                    ProductDesc = p.Product_Desc,
                    ProductTypeId = p.Product_Type_Id,
                    ProductTypeDesc = p.Product_Type_Desc,
                    InsuredDate = p.Insured_Date,
                    InsuredAmount = p.Insured_Amount,
                    Rate = p.Rate,
                    PremiumAmount = p.Premium_Amount,
                    BasePremiumAmount = p.Base_Premium_Amount,
                    DeductiblePercentage = p.Deductible_Percentage,
                    DeductibleAmount = p.Deductible_Amount,
                    MinimumDeductibleAmount = p.Minimum_Deductible_Amount,
                    RequiresInspection = p.Requires_Inspection,
                    Inspected = p.Inspected,
                    EndorsementClarifying = p.Endorsement_Clarifying,
                    Endorsement = p.Endorsement,
                    EndorsementBeneficiary = p.Endorsement_Beneficiary,
                    EndorsementBeneficiaryRnc = p.Endorsement_Beneficiary_Rnc,
                    EndorsementAmount = p.Endorsement_Amount,
                    EndorsementContactName = p.Endorsement_Contact_Name,
                    EndorsementContactPhone = p.Endorsement_Contact_Phone,
                    EndorsementContactEmail = p.Endorsement_Contact_Email,
                    PropertyDetailStatusId = p.Property_Detail_Status_Id,
                    PropertyDetailStatusDesc = p.Property_Detail_Status_Desc,
                    PropertyDetailSourceId = p.Property_Detail_Source_Id,
                    RegionIdLoc = p.Region_Id_Loc,
                    CountryIdLoc = p.Country_Id_Loc,
                    DomesticregIdLoc = p.Domesticreg_Id_Loc,
                    StateProvIdLoc = p.State_Prov_Id_Loc,
                    CityIdLoc = p.City_Id_Loc,
                    RegionDescLoc = p.Region_Desc_Loc,
                    CountryDescLoc = p.Country_Desc_Loc,
                    DomesticregDescLoc = p.Domesticreg_Desc_Loc,
                    StateProvDescLoc = p.State_Prov_Desc_Loc,
                    CityDescLoc = p.City_Desc_Loc,
                    BusinessTypeId = p.Business_Type_Id,
                    BusinessTypeDesc = p.Business_Type_Desc,
                    PropertyBuildTypeId = p.Property_Build_Type_Id,
                    PropertyBuildTypeDesc = p.Property_Build_Type_Desc,
                    ActivfityTypeId = p.Activfity_Type_Id,
                    ActivfityTypeDesc = p.Activfity_Type_Desc,
                    ReinsuranceId = p.Reinsurance_Id,
                    ReinsuranceDesc = p.Reinsurance_Desc,
                    ReinsuranceAmount = p.Reinsurance_Amount,
                    ReinsurancePercentage = p.Reinsurance_Percentage,
                    AddressStreet = p.Address_Street,
                    AddressNumber = p.Address_Number,
                    EvaluationValue = p.Evaluation_Value,
                    EdificationValue = p.Edification_Value,
                    MachineryValue = p.Machinery_Value,
                    FurnitureAndEquipmentValue = p.FurnitureAndEquipment_Value,
                    StockValue = p.Stock_Value,
                    RemodelingAndFittingValue = p.RemodelingAndFitting_Value,
                    ValueObjectAndArtValue = p.ValueObjectAndArt_Value,
                    SouthBorderId = p.South_Border_Id,
                    NorthBorderId = p.North_Border_Id,
                    EastBorderId = p.East_Border_Id,
                    WestBorderId = p.West_Border_Id,
                    DistanceKilometersSea = p.Distance_Kilometers_Sea,
                    DistanceKilometersRiver = p.Distance_Kilometers_River,
                    DistanceKilometersStream = p.Distance_Kilometers_Stream,
                    Latitude = p.Latitude,
                    PropertyStatusId = p.Property_Status_Id,
                    PropertyStatusDesc = p.Property_Status_Desc,
                    PropertySourceId = p.Property_Source_Id,
                    PropertyInspectedValue = p.Property_Inspected_Value,
                    SouthBorderDesc = p.South_Border_Desc,
                    NorthBorderDesc = p.North_Border_Desc,
                    EastBorderDesc = p.East_Border_Desc,
                    WestBorderDesc = p.West_Border_Desc,
                    GraduationYear = p.Graduation_Year,
                    UndergroundFeatures = p.Underground_Features,
                    ProjectAccountWithGuaranteeorDeposit = p.Project_Account_With_Guarantee_or_Deposit,
                    DeductibleInDays = p.Deductible_In_Days,
                    InsideBusiness = p.Inside_Business,
                    ProjectDescription = p.Project_Description,
                    GPS = p.GPS,
                    Specialty = p.Specialty,
                    Exequatur = p.Exequatur,
                    PenaltyForDelayedProjectDelivery = p.Penalty_For_Delayed_Project_Delivery,
                    ContractorExperienceInSimilarProjects = p.Contractor_Experience_In_Similar_Projects,
                    MachineryOperatorExperience = p.Machinery_Operator_Experience,
                    SubcontractorExperience = p.Subcontractor_Experience,
                    ExequaturRegistrationDate = p.Exequatur_Registration_Date,
                    PolicyFormat = p.Policy_Format,
                    OutofLocalBankDeposits = p.Out_of_Local_Bank_Deposits,
                    EquipmentMaintenance = p.Equipment_Maintenance,
                    ConstructionMaterial = p.Construction_Material,
                    ControlMeasures = p.Control_Measures,
                    SecurityMeasures = p.Security_Measures,
                    MinimumDeductible = p.Minimum_Deductible,
                    NameCentre = p.Name_Centre,
                    OtherRisks = p.Other_Risks,
                    SpecialDangers = p.Special_Dangers,
                    CompensationPeriod = p.Compensation_Period,
                    EquipmentWeight = p.Equipment_Weight,
                    PercentofCoinsuranceAgreed = p.Percent_of_Coinsurance_Agreed,
                    CivilLiability = p.Civil_Liability,
                    RiskofTempest = p.Risk_of_Tempest,
                    CatastrophicRisks = p.Catastrophic_Risks,
                    SecurityProtectionDuringConstructionProcess = p.Security_Protection_During_Construction_Process,
                    ProjectHasSubcontractor = p.Project_Has_Subcontractor,
                    TheContractorHasContractualRCCoverage = p.The_Contractor_Has_Contractual_RC_Coverage,
                    TypeCoverage = p.Type_Coverage,
                    ProjectType = p.Project_Type,
                    TypeofEquipmentGuard = p.Type_of_Equipment_Guard,
                    TypeMachinery = p.Type_Machinery,
                    UniversityStudies = p.University_Studies,
                    UseOfMachinery = p.Use_Of_Machinery,
                    GrossProfit = p.Gross_Profit,
                    TransportVehicles = p.Transport_Vehicles,
                    Surveillance = p.Surveillance,
                    MunicipioIdLoc = p.Municipio_Id_Loc,
                    MunicipioDescLoc = p.Municipio_Desc_Loc,
                    FireProtectionEquipmentTypeId = p.Fire_Protection_Equipment_Type_Id,
                    OrganizationTypeId = p.Organization_Type_Id,
                    ElectricSystemTypeId = p.Electric_System_Type_Id,
                    SecurityTypeId = p.Security_Type_Id,
                    SecurityTypeDesc = p.Security_Type_Desc,
                    OrganizationTypeDesc = p.Organization_Type_Desc,
                    FireProtectionEquipmentTypeDesc = p.Fire_Protection_Equipment_Type_Desc,
                    ElectricSystemTypeDesc = p.Electric_System_Type_Desc,
                    ReinsurancePremiumAmount = p.Reinsurance_Premium_Amount,
                    CoaseguroRobo = p.Coaseguro_Robo,
                    Ramo = p.Ramo,
                    SubRamo = p.SubRamo,
                    ProjectAmount = p.Project_Amount,
                    fireProtectionequipment = p.Fire_Protection_Equipment_Type_Desc,
                    organization = p.Organization_Type_Desc,
                    security = p.Security_Type_Desc,
                    electricsystem = p.Electric_System_Type_Desc,
                    countrydesc = p.Country_Desc_Loc,
                    StateProvDesc = p.State_Prov_Desc_Loc,
                    MunicipDesc = p.Municipio_Desc_Loc,
                    citydesc = p.City_Desc_Loc,
                    PolicyFomat = p.Policy_Format
                })
                .ToArray();

            return
                result;
        }
        public virtual IEnumerable<Property.Detail.GetDetailResult> GetPropertyDetail(Property.Detail.GetDetailResult.Key parameter)
        {
            IEnumerable<Property.Detail.GetDetailResult> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_DETAIL_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_DETAIL
                (
                parameter.corpId,
                parameter.propertyId,
                parameter.seqId
                )
                .ToArray();

            result = temp
                .Select(pp => new Property.Detail.GetDetailResult
                {
                    DetailBuildTypeId = pp.Detail_Build_Type_Id,
                    Position = pp.Position,
                    Percentage = pp.Percentage,
                    Brand = pp.Brand,
                    Model = pp.Model,
                    SerialKey = pp.Serial_Key,
                    Year = pp.Year,
                    Value = pp.Value,
                    RecessedOrScrewed = pp.RecessedOrScrewed,
                    Quantity = pp.Quantity,
                    DeepFeet = pp.Deep_Feet,
                    HeightFeet = pp.Height_Feet,
                    MaterialId = pp.Material_Id,
                    DetailPropertyStatId = pp.Detail_Property_Stat_Id
                });

            return
                result;
        }
        public virtual IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> GetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key parameter)
        {
            IEnumerable<Property.Insured.Detail.Coverage.GetDetailCoverageResult> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL_COVERAGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL_COVERAGE
                (
                parameter.corpId,
                parameter.uniquePropertyId
                )
                .ToArray();

            result = temp
                    .Select(pp => new Property.Insured.Detail.Coverage.GetDetailCoverageResult
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
                        UniquePropertyId = pp.Unique_Property_Id,
                        RegionId = pp.Region_Id,
                        CountryId = pp.Country_Id,
                        BlTypeId = pp.Bl_Type_Id,
                        BlId = pp.Bl_Id,
                        ProductId = pp.Product_Id,
                        VehicleTypeId = pp.Vehicle_Type_Id,
                        GroupId = pp.Group_Id,
                        CoverageTypeId = pp.Coverage_Type_Id,
                        CoverageId = pp.Coverage_Id,
                        CoverageTypeDesc = pp.Coverage_Type_Desc,
                        GroupDesc = pp.Group_Desc,
                        CoverageDesc = pp.Coverage_Desc,
                        Ramo = pp.Ramo,
                        SubRamo = pp.SubRamo,
                        RamoDesc = pp.Ramo_Desc,
                        SubRamoDesc = pp.SubRamo_Desc,
                        CoveragePercentage = pp.Coverage_Percentage,
                        PremiumPercentage = pp.Premium_Percentage,
                        CoinsurancePercentage = pp.Coinsurance_Percentage,
                        DeductibleInDay = pp.DeductibleInDay,
                        BaseDeducible = pp.BaseDeducible
                    });
            return
                 result;
        }
        public virtual IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> GetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key parameter)
        {
            IEnumerable<Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL_FEATURE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_INSURED_DETAIL_FEATURE
                (
                parameter.corpId,
                parameter.uniquePropertyId,
                parameter.seqId
                )
                .ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult
                {
                    PositionId = pp.Position_Id,
                    Brand = pp.Brand,
                    Model = pp.Model,
                    SerialKey = pp.Serial_Key,
                    Year = pp.Year,
                    Value = pp.Value,
                    Quantity = pp.Quantity,
                    Height = pp.Height,
                    FeaturePropertyStatusId = pp.Feature_Property_Status_Id,
                    CorpId = pp.Corp_Id,
                    UniquePropertyId = pp.Unique_Property_Id,
                    SeqId = pp.Seq_Id,
                    Width = pp.Width,
                    Author = pp.Author,
                    Capacity = pp.Capacity,
                    CertificateId = pp.Certificate_Id,
                    Deductible = pp.Deductible,
                    Description = pp.Description,
                    MeasureTypeId = pp.Measure_Type_Id,
                    MinimumDeductible = pp.Minimum_Deductible,
                    PositionDesc = pp.Position_Desc,
                    MeasureTypeDesc = pp.Measure_Type_Desc,
                    CertificateDesc = pp.Certificate_Desc,
                    Type = pp.Type
                });

            return
                 result;
        }
        public virtual Property.SetPropertyResult SetProperty(Property parameter)
        {
            Property.SetPropertyResult result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_Result> temp;

            temp = globalModelExtended.SP_SET_PL_POLICY_PROPERTY
                (
                    parameter.CorpId,
                    parameter.PropertyId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.BusinessTypeId,
                    parameter.PropertyBuildTypeId,
                    parameter.ActivfityTypeId,
                    parameter.ReinsuranceId,
                    parameter.ReinsuranceAmount,
                    parameter.AddressStreet,
                    parameter.AddressNumber,
                    parameter.EvaluationValue,
                    parameter.EdificationValue,
                    parameter.MachineryValue,
                    parameter.FurnitureAndEquipmentValue,
                    parameter.StockValue,
                    parameter.RemodelingAndFittingValue,
                    parameter.ValueObjectAndArtValue,
                //parameter.Rooms,
                //parameter.Bathrooms,
                //parameter.LocationActivityTypeId,
                //parameter.Registry,
                //parameter.PropertyYear,
                //parameter.BuildAreaSqFeet,
                //parameter.BuildAreaSqMeters,
                //parameter.GeographicLimitation,
                    parameter.SouthBorderId,
                    parameter.NorthBorderId,
                    parameter.EastBorderId,
                    parameter.WestBorderId,
                //parameter.PhysicalAddress,
                //parameter.accidents,
                //parameter.Garage,
                //parameter.Pool,
                    parameter.DistanceKilometersSea,
                    parameter.DistanceKilometersRiver,
                    parameter.DistanceKilometersStream,
                    parameter.Longitude,
                    parameter.Latitude,
                    parameter.PropertyStatusId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp
                   .Select(pp => new Property.SetPropertyResult
                    {
                        Action = pp.Action,
                        CorpId = pp.Corp_Id,
                        PropertyId = pp.Property_Id
                    })
                    .FirstOrDefault();

            return
                  result;
        }
        public virtual Property.Detail SetPropertyDetail(Property.Detail.key parameter)
        {
            Property.Detail result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_DETAIL_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_DETAIL
                (
                    parameter.CorpId,
                    parameter.PropertyId,
                    parameter.SeqId,
                    parameter.DetailBuildTypeId,
                    parameter.Position,
                    parameter.Percentage,
                    parameter.Brand,
                    parameter.Model,
                    parameter.SerialKey,
                    parameter.Year,
                    parameter.Value,
                    parameter.RecessedOrScrewed,
                    parameter.Quantity,
                    parameter.DeepFeet,
                    parameter.HeightFeet,
                    parameter.MaterialId,
                    parameter.DetailPropertyStatId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();

            result = temp
                .Select(pp => new Property.Detail
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    PropertyId = pp.Property_Id,
                    SeqId = pp.Seq_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual Property.Insured SetPropertyInsured(Property.Insured.key parameter)
        {
            Property.Insured result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED
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
                    parameter.PropertyId,
                    parameter.InsuredDate,
                    parameter.InsuredAmount,
                    parameter.PremiumAmount,
                    parameter.BasePremiumAmount,
                    parameter.DeductiblePercentage,
                    parameter.DeductibleAmount,
                    parameter.PropertyInspectedValue,
                    parameter.Inspection,
                    parameter.PolicyPropertyStatusId,
                    parameter.UserId,
                    parameter.SourceId
                )
                .ToArray();


            result = temp
                .Select(pp => new Property.Insured
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
                    PropertyId = pp.Property_Id
                })
                 .FirstOrDefault();

            return
                 result;
        }

        public virtual Property.Insured.Detail.key GetPropertyInsuredDet(Property.Insured.Detail parameter)
        {
            Property.Insured.Detail.key result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_INSURED_DET_Result> temp;
            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_INSURED_DET(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.PropertyId,
                    parameter.SeqId,
                    parameter.uniquePropertyId
                ).ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.key
                {
                    CorpId = pp.Corp_Id,
                    RegionId = pp.Region_Id,
                    CountryId = pp.Country_Id,
                    DomesticregId = pp.Domesticreg_Id,
                    StateProvId = pp.State_Prov_Id,
                    CityId = pp.City_Id,
                    OfficeId = pp.Office_Id,
                    CaseSeqNo = pp.Case_Seq_No,
                    HistSeqNo = pp.Hist_Seq_No,
                    PropertyId = pp.Property_Id,
                    SeqId = pp.Seq_Id,
                    InsurableTypeId = pp.Insurable_Type_Id,
                    InsuredDetailTypeId = pp.Insured_Detail_Type_Id,
                    EquipmentTypeId = pp.Equipment_Type_Id,
                    ConditionId = pp.Condition_Id,
                    ElectricSystemTypeId = pp.Electric_System_Type_Id,
                    FireProtectionEquipmentTypeId = pp.Fire_Protection_Equipment_Type_Id,
                    OrganizationTypeId = pp.Organization_Type_Id,
                    SecurityTypeId = pp.Security_Type_Id,
                    BlTypeId = pp.Bl_Type_Id,
                    BlId = pp.Bl_Id,
                    ProductId = pp.Product_Id,
                    ReinsuranceId = pp.Reinsurance_Id,
                    ReinsuranceAmount = pp.Reinsurance_Amount,
                    //Quantity = pp.Quantity,
                    //Placement = pp.Placement,
                    //Height = pp.Height,
                    //Width = pp.Width,
                    //Brand = pp.Brand,
                    //Model = pp.Model,
                    //SerialKey = pp.Serial_Key,
                    //Year = pp.Year,
                    //Value = pp.Value,
                    //ReplacementValue = pp.Replacement_Value,
                    //ConstructionDateStart = pp.Construction_Date_Start,
                    //ConstructionDateEnd = pp.Construction_Date_End,
                    //PercentageOfCompletion = pp.Percentage_Of_Completion,
                    //EquipmentValue = pp.Equipment_Value,
                    //MarketExperience = pp.Market_Experience,
                    //Capacity = pp.Capacity,
                    //Maker = pp.Maker,
                    //Author = pp.Author,
                    //EmployeesQty = pp.Employees_Qty,
                    //WorkStartDate = pp.Work_Start_Date,
                    //WorkEndDate = pp.Work_End_Date,
                    //Experience = pp.Experience,
                    //CompletionPercentage = pp.Completion_Percentage,
                    InsuredDate = pp.Insured_Date,
                    InsuredAmount = pp.Insured_Amount,
                    Rate = pp.Rate,
                    PremiumAmount = pp.Premium_Amount,
                    BasePremiumAmount = pp.Base_Premium_Amount,
                    DeductiblePercentage = pp.Deductible_Percentage,
                    DeductibleAmount = pp.Deductible_Amount,
                    MinimumDeductibleAmount = pp.Minimum_Deductible_Amount,
                    RequiresInspection = pp.Requires_Inspection,
                    Inspected = pp.Inspected,
                    EndorsementClarifying = pp.Endorsement_Clarifying,
                    Endorsement = pp.Endorsement,
                    EndorsementBeneficiary = pp.Endorsement_Beneficiary,
                    EndorsementBeneficiaryRnc = pp.Endorsement_Beneficiary_Rnc,
                    EndorsementAmount = pp.Endorsement_Amount,
                    EndorsementContactName = pp.Endorsement_Contact_Name,
                    EndorsementContactPhone = pp.Endorsement_Contact_Phone,
                    EndorsementContactEmail = pp.Endorsement_Contact_Email,
                    PropertyDetailStatusId = pp.Property_Detail_Status_Id,
                    SourceId = pp.Source_Id
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual Property.Insured.Detail SetPropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            Property.Insured.Detail result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL
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
                     parameter.PropertyId,
                     parameter.SeqId,
                     parameter.InsurableTypeId,
                     parameter.InsuredDetailTypeId,
                     parameter.EquipmentTypeId,
                     parameter.ConditionId,
                     parameter.ElectricSystemTypeId,
                     parameter.FireProtectionEquipmentTypeId,
                     parameter.OrganizationTypeId,
                     parameter.SecurityTypeId,
                     parameter.BlTypeId,
                     parameter.BlId,
                     parameter.ProductId,
                     parameter.ReinsuranceId,
                     parameter.ReinsuranceAmount,
                     parameter.GraduationYear,
                     parameter.UndergroundFeatures,
                     parameter.ProjectAccountWithGuaranteeorDeposit,
                     parameter.DeductibleInDays,
                     parameter.InsideBusiness,
                     parameter.ProjectDescription,
                     parameter.GPS,
                     parameter.Specialty,
                     parameter.Exequatur,
                     parameter.PenaltyForDelayedProjectDelivery,
                     parameter.ContractorExperienceInSimilarProjects,
                     parameter.MachineryOperatorExperience,
                     parameter.SubcontractorExperience,
                     parameter.ExequaturRegistrationDate,
                     parameter.PolicyFormat,
                     parameter.OutofLocalBankDeposits,
                     parameter.EquipmentMaintenance,
                     parameter.ConstructionMaterial,
                     parameter.ControlMeasures,
                     parameter.SecurityMeasures,
                     parameter.MinimumDeductible,
                     parameter.NameCentre,
                     parameter.OtherRisks,
                     parameter.SpecialDangers,
                     parameter.CompensationPeriod,
                     parameter.EquipmentWeight,
                     parameter.PercentofCoinsuranceAgreed,
                     parameter.CivilLiability,
                     parameter.RiskofTempest,
                     parameter.CatastrophicRisks,
                     parameter.SecurityProtectionDuringConstructionProcess,
                     parameter.ProjectHasSubcontractor,
                     parameter.TheContractorHasContractualRCCoverage,
                     parameter.TypeCoverage,
                     parameter.ProjectType,
                     parameter.TypeofEquipmentGuard,
                     parameter.TypeMachinery,
                     parameter.UniversityStudies,
                     parameter.UseOfMachinery,
                     parameter.GrossProfit,
                     parameter.TransportVehicles,
                     parameter.Surveillance,
                     parameter.coaseguroRobo,
                     parameter.ProjectAmount,
                     parameter.InsuredDate,
                     parameter.InsuredAmount,
                     parameter.Rate,
                     parameter.PremiumAmount,
                     parameter.BasePremiumAmount,
                     parameter.DeductiblePercentage,
                     parameter.DeductibleAmount,
                     parameter.MinimumDeductibleAmount,
                     parameter.RequiresInspection,
                     parameter.Inspected,
                     parameter.EndorsementClarifying,
                     parameter.Endorsement,
                     parameter.EndorsementBeneficiary,
                     parameter.EndorsementBeneficiaryRnc,
                     parameter.EndorsementAmount,
                     parameter.EndorsementContactName,
                     parameter.EndorsementContactPhone,
                     parameter.EndorsementContactEmail,
                     parameter.PropertyDetailStatusId,
                     parameter.UserId,
                     parameter.SourceId
                )
                .ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail
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
                    PropertyId = pp.Property_Id,
                    SeqId = pp.Seq_Id
                })
                .FirstOrDefault();

            return
                result;

        }
        public virtual Property.Insured.Detail.Coverage SetPropertyInsuredDetailCoverage(Property.Insured.Detail.Coverage.Key parameter)
        {
            Property.Insured.Detail.Coverage result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL_COVERAGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL_COVERAGE
                        (
                            parameter.CorpId,
                            parameter.UniquePropertyId,
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
                .Select(pp => new Property.Insured.Detail.Coverage
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniquePropertyId = pp.Unique_Property_Id,
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
        public virtual Property.Insured.Detail.Feature SetPropertyInsuredDetailFeature(Property.Insured.Detail.Feature.Key parameter)
        {
            Property.Insured.Detail.Feature result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL_FEATURE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED_DETAIL_FEATURE
               (
                    parameter.CorpId,
                    parameter.UniquePropertyId,
                    parameter.SeqId,
                    parameter.Description,
                    parameter.Brand,
                    parameter.Model,
                    parameter.SerialKey,
                    parameter.Capacity,
                    parameter.Year,
                    parameter.Value,
                    parameter.Quantity,
                    parameter.Author,
                    parameter.PositionId,
                    parameter.CertificateId,
                    parameter.MeasureTypeId,
                    parameter.Height,
                    parameter.Width,
                    parameter.Deductible,
                    parameter.MinimumDeductible,
                    parameter.FeaturePropertyStatusId,
                    parameter.UserId,
                    parameter.SourceId
               )
               .ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.Feature
                {
                    Action = pp.Action,
                    CorpId = pp.Corp_Id,
                    UniquePropertyId = pp.Unique_Property_Id,
                    SeqId = pp.Seq_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual IEnumerable<Property.Insured.Coverage.Surcharge> GetPropertyInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge.Key parameter)
        {
            IEnumerable<Property.Insured.Coverage.Surcharge> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_COVERAGE_SURCHARGE
                (
                    parameter.surchargeId,
                    parameter.discountRuleId,
                    parameter.discountRuleDetailId,
                    parameter.corpId,
                    parameter.regionId,
                    parameter.countryId,
                    parameter.uniquePropertyId,
                    parameter.blTypeId,
                    parameter.blId,
                    parameter.productId,
                    parameter.vehicleTypeId,
                    parameter.groupId,
                    parameter.coverageTypeId,
                    parameter.coverageId,
                    parameter.languageId
                )
                .ToArray();

            result = temp
                .Select(cs => new Property.Insured.Coverage.Surcharge
                {
                    CorpId = cs.Corp_Id,
                    RegionId = cs.Region_Id,
                    CountryId = cs.Country_Id,
                    UniquePropertyId = cs.Unique_Property_Id,
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
        public virtual IEnumerable<Property.Insured.Discount> GetPropertyInsuredDiscount(Property.Insured.Discount.Key parameter)
        {
            IEnumerable<Property.Insured.Discount> result;
            IEnumerable<SP_GET_PL_POLICY_PROPERTY_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_GET_PL_POLICY_PROPERTY_INSURED_DISCOUNT
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
                    parameter.PropertyId,
                    parameter.DiscountId,
                    parameter.languageId
                )
                .ToArray();

            result = temp
                .Select(d => new Property.Insured.Discount
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
                    PropertyId = d.Property_Id,
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
        public virtual Property.Insured.Coverage.Surcharge.Key SetPropertytInsuredCoverageSurcharge(Property.Insured.Coverage.Surcharge parameter)
        {
            Property.Insured.Coverage.Surcharge.Key result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_COVERAGE_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_COVERAGE_SURCHARGE
                 (
                    parameter.SurchargeId,
                    parameter.DiscountRuleId,
                    parameter.DiscountRuleDetailId,
                    parameter.OldCoverageAmount,
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.UniquePropertyId,
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
                .Select(cs => new Property.Insured.Coverage.Surcharge.Key
                {
                    Action = cs.Action,
                    corpId = cs.Corp_Id,
                    regionId = cs.Region_Id,
                    countryId = cs.Country_Id,
                    uniquePropertyId = cs.Unique_Property_Id,
                    blTypeId = cs.Bl_Type_Id,
                    blId = cs.Bl_Id,
                    productId = cs.Product_Id,
                    vehicleTypeId = cs.Vehicle_Type_Id,
                    groupId = cs.Group_Id,
                    coverageTypeId = cs.Coverage_Type_Id,
                    coverageId = cs.Coverage_Id,
                    surchargeId = cs.Surcharge_Id
                })
                .FirstOrDefault();

            return
                result;
        }
        public virtual Property.Insured.Discount.Key SetPropertyInsuredDiscount(Property.Insured.Discount parameter)
        {
            Property.Insured.Discount.Key result;
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_DISCOUNT_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED_DISCOUNT
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
                    parameter.PropertyId,
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
                 .Select(pp => new Property.Insured.Discount.Key
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
                     PropertyId = pp.Property_Id,
                     DiscountId = pp.Discount_Id
                 })
                 .FirstOrDefault();

            return
                result;
        }
        public virtual int SetPropertyInsuredApplyDiscountAndSurcharge(Property.Insured parameter)
        {
            IEnumerable<SP_SET_PL_POLICY_PROPERTY_INSURED_APPLY_DISCOUNT_AND_SURCHARGE_Result> temp;

            temp = globalModel.SP_SET_PL_POLICY_PROPERTY_INSURED_APPLY_DISCOUNT_AND_SURCHARGE
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
                    parameter.UserId
                );

            return
                -1;
        }

        public virtual int UpdatePropertyInsuredDetail(Property.Insured.Detail.key parameter)
        {
            int result;
            IEnumerable<SP_UPDATE_PL_POLICY_PROPERTY_INSURED_DETAIL_Result> temp;

            temp = globalModelExtended.SP_UPDATE_PL_POLICY_PROPERTY_INSURED_DETAIL(
                    parameter.CorpId,
                    parameter.RegionId,
                    parameter.CountryId,
                    parameter.DomesticregId,
                    parameter.StateProvId,
                    parameter.CityId,
                    parameter.OfficeId,
                    parameter.CaseSeqNo,
                    parameter.HistSeqNo,
                    parameter.PropertyId,
                    parameter.SeqId,
                    parameter.UniquePropertyId,
                    parameter.Inspected,
                    parameter.EndorsementClarifying,
                    parameter.UserId
                  );

            result = temp
                    .Select(d => d.Result)
                    .FirstOrDefault();

            return
                result;
        }

        public virtual IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> GetPropertyFeatureMeasureType(Property.Insured.Detail.Feature.MeasureTypeResult.Key parameter)
        {
            IEnumerable<Property.Insured.Detail.Feature.MeasureTypeResult> result;
            IEnumerable<SP_GET_PL_PROPERTY_MEASURE_TYPE_Result> temp;

            temp = globalModelExtended.SP_GET_PL_PROPERTY_MEASURE_TYPE
                (
                parameter.corpId,
                parameter.MeasureTypeId
                ).ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.Feature.MeasureTypeResult
                {
                    CorpId = pp.Corp_Id,
                    MeasureTypeDesc = pp.Measure_Type_Desc,
                    MeasureTypeId = pp.Measure_Type_Id,
                    MeasureTypeNameKey = pp.Measure_Type_NameKey,
                    MeasureTypeStatus = pp.Measure_Type_Status,
                    SourceId = pp.Source_Id,
                });

            return
                 result;
        }

        public virtual IEnumerable<Property.Insured.Detail.Feature.PositionsResult> GetPropertyFeaturePosition(Property.Insured.Detail.Feature.PositionsResult.Key parameter)
        {
            IEnumerable<Property.Insured.Detail.Feature.PositionsResult> result;
            IEnumerable<SP_GET_PL_PROPERTY_POSITION_Result> temp;

            temp = globalModelExtended.SP_GET_PL_PROPERTY_POSITION
                (
                parameter.corpId,
                parameter.PositionId
                ).ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.Feature.PositionsResult
                {
                    CorpId = pp.Corp_Id,
                    PositionDesc = pp.Position_Desc,
                    PositionId = pp.Position_Id,
                    PositionNameKey = pp.Position_NameKey,
                    PositionStatus = pp.Position_Status,
                    SourceId = pp.Source_Id,
                });

            return
                 result;
        }

        public virtual IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> GetPropertyFeatureCertificates(Property.Insured.Detail.Feature.CertificatesResult.Key parameter)
        {
            IEnumerable<Property.Insured.Detail.Feature.CertificatesResult> result;
            IEnumerable<SP_GET_PL_PROPERTY_CERTIFICATE_Result> temp;

            temp = globalModelExtended.SP_GET_PL_PROPERTY_CERTIFICATE
                (
                parameter.corpId,
                parameter.CertificateId
                ).ToArray();

            result = temp
                .Select(pp => new Property.Insured.Detail.Feature.CertificatesResult
                {
                    CorpId = pp.Corp_Id,
                    CertificateDesc = pp.Certificate_Desc,
                    CertificateId = pp.Certificate_Id,
                    CertificateNameKey = pp.Certificate_NameKey,
                    CertificateStatus = pp.Certificate_Status,
                    SourceId = pp.Source_Id,
                });

            return
                 result;
        }

    }
}