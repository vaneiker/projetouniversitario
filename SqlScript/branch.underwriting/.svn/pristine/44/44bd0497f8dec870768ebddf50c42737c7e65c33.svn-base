using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class MedicalRepository : GlobalRepository
    {
        public MedicalRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<Medical> GetInfo(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            IEnumerable<Medical> result;
            IEnumerable<SP_GET_MEDICAL_INFO_Result> temp;

            temp = globalModel.SP_GET_MEDICAL_INFO(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);

            result = temp
                .Select(m => new Medical
                {
                    CorpId = m.Corp_Id,
                    RegionId = m.Region_Id,
                    CountryId = m.Country_Id,
                    DomesticregId = m.Domesticreg_Id,
                    StateProvId = m.State_Prov_Id,
                    CityId = m.City_Id,
                    OfficeId = m.Office_Id,
                    CaseSeqNo = m.Case_Seq_No,
                    HistSeqNo = m.Hist_Seq_No,
                    ContactId = m.Contact_Id,
                    ContactRoleTypeId = m.Contact_Role_Type_Id,
                    HealthWeigth = m.Health_Weigth,
                    HealthWeigthTypeId = m.Health_Weigth_Type_Id,
                    HealthHeight = m.Health_Height,
                    HealthHeigthTypeId = m.Health_Heigth_Type_Id,
                    HealthAge = m.Health_Age,
                    HealthGender = m.Health_Gender,
                    HealthSmoke = m.Health_Smoke,
                    HealthExcercise = m.Health_Excercise,
                    HealthDrugs = m.Health_Drugs,
                    HealthSystolic = m.Health_Systolic,
                    HealthDiastolic = m.Health_Diastolic,
                    HealthLastMedVisit = m.Health_LastMedVisit,
                    HealthLastMedReason = m.Health_LastMed_Reason,
                    HealthLastMedResult = m.Health_LastMed_Result,
                    HealthDrName = m.Health_Dr_Name,
                    HealthDrAddress = m.Health_Dr_Address,
                    HealthDrPhonePrefix = m.Health_Dr_Phone_Prefix,
                    HealthDrPhoneArea = m.Health_Dr_Phone_Area,
                    HealthDrPhoneNum = m.Health_Dr_Phone_Num,
                    HealthMedication = m.Health_Medication
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Medical.Condition> GetCondition(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            IEnumerable<Medical.Condition> result;
            IEnumerable<SP_GET_MEDICAL_CONDITIONS_Result> temp;

            temp = globalModel.SP_GET_MEDICAL_CONDITIONS(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);

            result = temp
                .Select(mc => new Medical.Condition
                {
                    CorpId = mc.Corp_Id,
                    RegionId = mc.Region_Id,
                    CountryId = mc.Country_Id,
                    DomesticregId = mc.Domesticreg_Id,
                    StateProvId = mc.State_Prov_Id,
                    CityId = mc.City_Id,
                    OfficeId = mc.Office_Id,
                    CaseSeqNo = mc.Case_Seq_No,
                    HistSeqNo = mc.Hist_Seq_No,
                    ContactId = mc.Contact_Id,
                    ContactRoleTypeId = mc.Contact_Role_Type_Id,
                    MedConditionId = mc.Med_Condition_Id,
                    MedConditionDesc = mc.Med_Condition_Desc
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Medical.FamilyHistory> GetFamilyHistory(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            IEnumerable<Medical.FamilyHistory> result;
            IEnumerable<SP_GET_MEDICAL_FAMILY_HISTORY_Result> temp;

            temp = globalModel.SP_GET_MEDICAL_FAMILY_HISTORY(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);

            result = temp
                .Select(fh => new Medical.FamilyHistory
                {
                    CorpId = fh.Corp_Id,
                    RegionId = fh.Region_Id,
                    CountryId = fh.Country_Id,
                    DomesticregId = fh.Domesticreg_Id,
                    StateProvId = fh.State_Prov_Id,
                    CityId = fh.City_Id,
                    OfficeId = fh.Office_Id,
                    CaseSeqNo = fh.Case_Seq_No,
                    HistSeqNo = fh.Hist_Seq_No,
                    ContactId = fh.Contact_Id,
                    ContactRoleTypeId = fh.Contact_Role_Type_Id,
                    RelationshipId = fh.Relationship_Id,
                    RelationshipDesc = fh.Relationship_Desc,
                    CauseOfDeath = fh.Cause_Of_Death,
                    CurrentAge = fh.Current_Age,
                    AgeDeath = fh.Age_Death
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Medical.ExamReceived> GetExamReceived(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
            IEnumerable<Medical.ExamReceived> result;
            IEnumerable<SP_GET_MEDICAL_EXMA_RECEIVED_Result> temp;

            temp = globalModel.SP_GET_MEDICAL_EXMA_RECEIVED(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId);

            result = temp
                .Select(er => new Medical.ExamReceived
                {
                    CorpId = er.Corp_Id,
                    RegionId = er.Region_Id,
                    CountryId = er.Country_Id,
                    DomesticregId = er.Domesticreg_Id,
                    StateProvId = er.State_Prov_Id,
                    CityId = er.City_Id,
                    OfficeId = er.Office_Id,
                    CaseSeqNo = er.Case_Seq_No,
                    HistSeqNo = er.Hist_Seq_No,
                    ContactId = er.Contact_Id,
                    RequirementCatId = er.Requirement_Cat_Id,
                    RequirementTypeId = er.Requirement_Type_Id,
                    RequirementId = er.Requirement_Id,
                    MedicalTestId = er.Medical_Test_Id,
                    SequenceReference = er.Sequence_Reference,
                    LabId = er.Lab_Id,
                    RequirementTypeDesc = er.Requirement_Type_Desc,
                    DateRequested = er.Date_Requested,
                    DateReceived = er.Date_Received,
                    LabDesc = er.Lab_Desc,
                    DocTypeId = er.Doc_Type_Id,
                    DocCategoryId = er.Doc_Category_Id,
                    DocumentId = er.Document_Id,
                    IsPending = er.IsPending,
                    IsEverythingOk = er.IsEverythingOk
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Medical.ExamResult> GetExamResult(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId
            , int requirementCatId, int requirementTypeId, int requirementId, int medicalTestId)
        {
            IEnumerable<Medical.ExamResult> result;
            IEnumerable<SP_GET_MEDICAL_EXMA_RESULT_Result> temp;

            temp = globalModel.SP_GET_MEDICAL_EXMA_RESULT(coprId, regionId, countryId, domesticRegId, stateProvId, cityId
                , officeId, caseSeqNo, histSeqNo, contactId, requirementCatId, requirementTypeId, requirementId, medicalTestId);

            result = temp
                .Select(er => new Medical.ExamResult
                {
                    ExmaDate = er.ExmaDate,
                    ExmaTime = er.ExmaTime,
                    MedTestDesc = er.Med_Test_Desc,
                    SubtestDesc = er.Subtest_Desc,
                    Units = er.Units,
                    Result = er.Result,
                    LabFromParam = er.Lab_From_Param,
                    LabToParam = er.Lab_To_Param,
                    ReinsurerFromParam = er.Reinsurer_From_Param,
                    ReinsurerToParam = er.Reinsurer_To_Param,
                    IsEverythingOk = er.IsEverythingOk
                })
                .ToArray();

            return
                result;
        }

        public virtual int SetInfo(Medical info)
        {
            int result;
            IEnumerable<SP_SET_MEDICAL_INFO_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_MEDICAL_INFO(
                    info.CorpId,
                    info.RegionId,
                    info.CountryId,
                    info.DomesticregId,
                    info.StateProvId,
                    info.CityId,
                    info.OfficeId,
                    info.CaseSeqNo,
                    info.HistSeqNo,
                    info.ContactId,
                    info.ContactRoleTypeId,
                    info.HealthMemberPremium,
                    info.HealthWeigth,
                    info.HealthWeigthTypeId,
                    info.HealthHeight,
                    info.HealthHeigthTypeId,
                    info.HealthAge,
                    info.HealthGender,
                    info.HealthSmoke,
                    info.HealthExcercise,
                    info.HealthDrugs,
                    info.HealthSystolic,
                    info.HealthDiastolic,
                    info.HealthLastMedVisit,
                    info.HealthLastMedReason,
                    info.HealthLastMedResult,
                    info.HealthDrName,
                    info.HealthDrAddress,
                    info.HealthDrPhonePrefix,
                    info.HealthDrPhoneArea,
                    info.HealthDrPhoneNum,
                    info.HealthMedication,
                    null, 
                    null,
                    null,
                    info.UserId
                );

            return
                result;
        }
    }
}
