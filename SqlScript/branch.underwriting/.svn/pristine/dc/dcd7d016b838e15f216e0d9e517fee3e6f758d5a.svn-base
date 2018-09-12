using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Entity.UnderWriting.Entities
{
    public class Requirement
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
        public int AgentId { get; set; }
        public int? StepTypeId { get; set; }
        public int? StepId { get; set; }
        public int? StepCaseNo { get; set; }
        public string RequirementTypeDesc { get; set; }
        public int ContactRoleTypeId { get; set; }
        public string RoleDesc { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedByUserName { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool IsManual { get; set; }
        public bool SendToReinsurance { get; set; }
        public int? RequirementDocId { get; set; }
        public int? DocTypeId { get; set; }
        public int? DocCategoryId { get; set; }
        public int? DocumentId { get; set; }
        public bool? IsComplete { get; set; }
        public bool? Automatic { get; set; }
        public bool HasDocument { get; set; }
        public int UserId { get; set; }
        public string RequirementCatDesc { get; set; }
        public string Comment { get; set; }
        public bool RequimentPolicyOnly { get; set; }
        public string ContactRoleDesc { get; set; }
        public string ClientName { get; set; } 
        public DateTime? LastUpdate { get; set; }
        public IEnumerable<Requirement> AgentList { get; set; }
        public bool Is_Mandatory { get; set; }

        public class Document
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
            public int DocumentStatusId { get; set; }
            public string DocumentStatusDesc { get; set; }
            public int RequirementDocId { get; set; }
            public int DocumentTypeId { get; set; }
            public int DocumentCategoryId { get; set; }
            public int DocumentId { get; set; }
            public byte[] DocumentBinary { get; set; }
            public string DocumentName { get; set; }
            public string DocumentTypeDesc { get; set; }
            public string ContentType { get; set; }
            public string Extension { get; set; }
            public DateTime? ClientSignatureDate { get; set; } 
            public int UserId { get; set; }
        }

        public class Comunication
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
            public int ComunicationId { get; set; }
            public string Comment { get; set; }
            public int CommentBy { get; set; }            
            public string CommentByUserName { get; set; }
            public int UserId { get; set; }
            public DateTime CommentDate { get; set; }
        }

        public struct CategoryByContactRole
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
            public int RequirementCatId { get; set; }
            public int ContactId { get; set; }
            public string RequirementCatDesc { get; set; }
            public string Roles { get; set; }
            public string Key { get; set; }
        }
                 
        public struct DocumentRequirementOnBase
        {
            public string DescriptionName { get; set; }   
            public int Doc_Type_Id { get; set; }   
            public int Doc_Category_Id { get; set; }
            public string On_Base_Name_Key { get; set; }
            public string Clasification { get; set; }
        }

        public struct OnBaseAditionalInformation
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
            public int? Contact_ID { get; set; }
            public string InsuredName { get; set; }
            public int? Role_Type_ID { get; set; }
            public string identification { get; set; }
            public int ContactIdType { get; set; }
        }
 
        public class Product
        {   
            public int OrderId { get; set; }
            public int CorpId { get; set; }
            public int RequirementCatId { get; set; }
            public string RequirementCatDesc { get; set; }
            public int? RequirementTypeId { get; set; }
            public string RequirementTypeDesc { get; set; }
            public int? DocTypeId { get; set; }
            public int? DocCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public bool? Automatic { get; set; }
            public bool? RequimentPolicyOnly { get; set; }
            public bool? RequimentAssingToInsured { get; set; }
            public int? RegionId { get; set; }
            public int? CountryId { get; set; }
            public int? DomesticregId { get; set; }
            public int? StateProvId { get; set; }
            public int? CityId { get; set; }
            public int? OfficeId { get; set; }
            public int? CaseSeqNo { get; set; }
            public int? HistSeqNo { get; set; }
            public int? ContactId { get; set; }
            public int? RequirementId { get; set; }
            public int? RequirementDocId { get; set; }            
            public bool? IsValid { get; set; }
            public int? FunctionalitySeqNo { get; set; }
            public bool? IsMandatory { get; set; }
            public int? InsuredId { get; set; }
            public int? SeqId { get; set; }
            public long? UniqueId { get; set; }
            public string AssingTo { get; set; }
            public int? FunctionalityId { get; set; }
            public int? UploadById { get; set; }
            public string UploadByUserName { get; set; }
            public int? ValidById { get; set; }
            public string ValidByUserName { get; set; }
            public DateTime? ValidByDate { get; set; }
            public string RequimentOnBaseNameKey { get; set; }
            public string RequirementTypeSubType { get; set; }
            public string EndorsementBeneficiary { get; set; }
            public string DocumentName { get; set; }
            public int? InsuredBenefiaryId { get; set; }
            public int? FinalBeneficiaryId { get; set; }

            public class Key
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
                public int? ContactId { get; set; }   
            }
        }

		//Bmarroquin 03-04-2017 se crea Class
        public class Compliance
        {
            public int ContactId { get; set; }
            public string Nombre_Rol { get; set; }
            public string ClientName { get; set; }
            public DateTime? Dob { get; set; }
            public string Identificacion { get; set; }
            public string TipoIdentificacion { get; set; }
            public string statusCompliance { get; set; }
            //BM:Nuevos campos solicitados por Cumplimiento
            public string Address { get; set; }
            public string CountryOfBirth { get; set; }
            public string ID { get; set; }
            public string IDType { get; set; }
            public bool IsOk { get; set; }

            public class RequiredData
            {
                public int FieldId { get; set; }
                public string Field { get; set; }
                public string FieldReference { get; set; }
                public string Document { get; set; }
                public bool Required { get; set; }
                public bool Completed { get; set; }
            }
            public enum ClientType
            {
                [Description("Persona Física")]
                PHYSICAL_PERSON = 1,
                [Description("Persona Jurídica")]
                LEGAL_PERSON = 2,
                [Description("Persona Física Extranjera")]
                PHYSICAL_PERSON_FOREIGN = 3,
                [Description("Persona Juridica Extranjera")]
                LEGAL_PERSON_FOREIGN = 4,
                [Description("Organimos Públicos")]
                PUBLIC_ORGANISMS = 5
            }
            public enum Fields
            {
                [Description("Name and Lastname")]
                FULLNAME = 1,
                [Description("Date Of Birth")]
                DOB = 2,
                [Description("Citizenship")]
                CITIZENSHIP = 3,
                [Description("Gender")]
                GENDER = 4,
                [Description("ID")]
                ID = 5,
                [Description("ID Type")]
                ID_TYPE = 6,
                [Description("Address")]
                ADDRESS = 7,
                [Description("Phone Number")]
                PHONE_NUMBER = 8,
                [Description("Mail Address")]
                EMAIL = 9,
                [Description("Employment Activity")]
                EMPLOYMENT_ACTIVITY = 10,
                [Description("Job Company Name")]
                JOB_COMPANY_NAME = 11,
                [Description("Job Company Address")]
                JOB_COMPANY_ADDRESS = 12,
                [Description("Annual Income")]
                ANNUAL_INCOME = 13,
                [Description("Premium Payment Method")]
                PREMIUM_PAYMENT_METHOD = 14,
                [Description("PEP Questionaire")]
                PEP_QUESTIONAIRE = 15,
                [Description("Company Name or Commercial Name")]
                COMPANY_NAME = 16,
                [Description("Company Commercial Activity")]
                COMPANY_COMMERCIAL_ACTIVITY = 17,
                [Description("Company Structure Details")]
                COMPANY_STRUCTURE = 18,
                [Description("Final Beneficiary Information")]
                FINAL_BENEFICIARY_INFO = 19,
                [Description("Organization Manager")]
                PUBLIC_ORGANIZATION_MANAGER = 20,
                [Description("Organization Manager Address")]
                PUBLIC_ORGANIZATION_MANAGER_AD = 21
            }

            public enum Documents
            {
                [Description("ID")]
                ID_DOCUMENT = 1,
                [Description("PEP Formulary")]
                PEP_DOCUMENT = 2,
                [Description("Company Registry")]
                COMPANY_REGISTRY = 3,
                [Description("Company Certificate of Society")]
                COMPANY_SOCIETY_CERTIFICATION = 4,
                [Description("List of Shareholders")]
                SHAREHOLDER_LIST = 5,
                [Description("ID of Final Beneficiary with Over 20%")]
                FINAL_BENEFICIARY_OVER20 = 6,
                [Description("Company Domicile Certification")]
                COMPANY_DOMICILE_CERTIFICATION = 7
            }
            }
    }
}
