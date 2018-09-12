using System;

namespace Entity.UnderWriting.Entities
{
    public class Reinsurance
    {
        public class Communication
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticRegId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int StepTypeId { get; set; }
            public int StepId { get; set; }
            public int StepCaseNo { get; set; }
            public int? CommunicationId { get; set; }
            public int ReinsurerId { get; set; }
            public int CommTypeId { get; set; }
            public string CommText { get; set; }
            public string CommFrom { get; set; }
            public string CommSubject { get; set; }
            public DateTime? CommDate { get; set; }
            public bool? CommAttachment { get; set; }
            public string ReinsurerDesc { get; set; }
            public string CommTypeDesc { get; set; }
            public int? DocTypeId { get; set; }
            public int? DocCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public string DocumentName { get; set; }
            public string DocTypeDesc { get; set; }            
            public int? UserId { get; set; }
            public string Extension { get; set; }
        }

        public class StepAvailable
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticRegId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int StepTypeId { get; set; }
            public int StepId { get; set; }
            public int StepCaseNo { get; set; }
            public int ReinsurerId { get; set; }
            public int CommTypeId { get; set; }
            public string StepSeqReference { get; set; }
            public string ReinsurerEmail { get; set; }
        }

        public class FacultativeStatus
        {
            public int Corp_Id { get; set; }
            public int Facultative_Status_Id { get; set; }
            public string Facultative_Status_Desc { get; set; }
            public string Name_Key { get; set; }
            public bool Facultative_Status_Status { get; set; }
        }
        public class FacultativeDetails
        {
            public int Corp_Id { get; set; }
            public int Region_Id { get; set; }
            public int Country_Id { get; set; }
            public int Domesticreg_Id { get; set; }
            public int State_Prov_Id { get; set; }
            public int City_Id { get; set; }
            public int Office_Id { get; set; }
            public int Case_seq_No { get; set; }
            public int Hist_Seq_No { get; set; }
            public int? Rider_Type_Id { get; set; }
            public int? Rider_Id { get; set; }
            public string Coverage_Type_Desc { get; set; }
            public decimal? Beneficiary_Amount { get; set; }
            //public DateTime Requested_Date { get; set; }
            public DateTime? Requested_Date { get; set; }
            //public DateTime Processed_Date { get; set; }
            public DateTime? Processed_Date { get; set; }
            public decimal Company_Risk_Amount { get; set; }
            public decimal Reinsurance_Risk_Amount { get; set; }
            public decimal? Authorized_Amount { get; set; }
            public decimal Risk_Rating_Amount { get; set; }
            public string Risk_Rating { get; set; }
            public decimal Per_Thousend_Risk_Amount { get; set; }
            public int Facultative_Status_Id { get; set; }
            public string Facultative_Status_Desc { get; set; }
            public bool Reinsurance_Facultative_Status { get; set; }
            public decimal Total_Amount_Insured { get; set; }
            public string Facultative_Reinsurance_Id { get; set; }
        }
        public class RatingRisk
        {
            public string TableRating_Id { get; set; }
            public string Short_Description { get; set; }
            public string Long_Description { get; set; }
            public decimal? Rating_Value { get; set; }
        }
    }
}
