using System;

namespace Entity.UnderWriting.Entities
{
    public class Medical
    {
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticregId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
        public int ContactId { get; set; }
        public int ContactRoleTypeId { get; set; }
        public decimal? HealthMemberPremium { get; set; }
        public decimal? HealthWeigth { get; set; }
        public decimal? HealthBmi { get; set; }
        public int? HealthWeigthTypeId { get; set; }
        public decimal? HealthHeight { get; set; }
        public int? HealthHeigthTypeId { get; set; }
        public int? HealthAge { get; set; }
        public string HealthGender { get; set; }
        public bool? HealthSmoke { get; set; }
        public int? HealthExcercise { get; set; }
        public int? HealthDrugs { get; set; }
        public int? HealthSystolic { get; set; }
        public int? HealthDiastolic { get; set; }
        public DateTime? HealthLastMedVisit { get; set; }
        public string HealthLastMedReason { get; set; }
        public string HealthLastMedResult { get; set; }
        public string HealthDrName { get; set; }
        public string HealthDrAddress { get; set; }
        public string HealthDrPhonePrefix { get; set; }
        public string HealthDrPhoneArea { get; set; }
        public string HealthDrPhoneNum { get; set; }
        public string HealthMedication { get; set; }
        public int UserId { get; set; }

        public struct Condition
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int ContactId { get; set; }
            public int ContactRoleTypeId { get; set; }
            public int MedConditionId { get; set; }
            public string MedConditionDesc { get; set; }
        }

        public struct FamilyHistory
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int ContactId { get; set; }
            public int ContactRoleTypeId { get; set; }
            public int? RelationshipId { get; set; }
            public string RelationshipDesc { get; set; }
            public string CauseOfDeath { get; set; }
            public int? CurrentAge { get; set; }
            public int? AgeDeath { get; set; }
        }

        public struct ExamReceived
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int ContactId { get; set; }
            public int RequirementCatId { get; set; }
            public int RequirementTypeId { get; set; }
            public int RequirementId { get; set; }
            public int MedicalTestId { get; set; }
            public string SequenceReference { get; set; }
            public int LabId { get; set; }
            public string RequirementTypeDesc { get; set; }
            public DateTime DateRequested { get; set; }
            public DateTime DateReceived { get; set; }
            public string LabDesc { get; set; }
            public int? DocTypeId { get; set; }
            public int? DocCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public bool? IsPending { get; set; }
            public bool? IsEverythingOk { get; set; }
        }

        public struct ExamResult
        {
            public string ExmaDate { get; set; }
            public string ExmaTime { get; set; }
            public string MedTestDesc { get; set; }
            public string SubtestDesc { get; set; }
            public string Units { get; set; }
            public decimal? Result { get; set; }
            public decimal? LabFromParam { get; set; }
            public decimal? LabToParam { get; set; }
            public decimal? ReinsurerFromParam { get; set; }
            public decimal? ReinsurerToParam { get; set; }
            public bool? IsEverythingOk { get; set; }
        }
    }
}
