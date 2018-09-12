using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IRequirement
    {
        IEnumerable<Requirement> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int languageId);

        IEnumerable<Requirement.CategoryByContactRole> GetAllCategoryByContactRole(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo);

        IEnumerable<Requirement> GetAllNewBusiness(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? requirementCatId, int languageId);

        IEnumerable<Requirement.Document> GetAllDocuments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId);

        Requirement.Document GetDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId, int requirementDocId);

        Requirement.DocumentRequirementOnBase GetRequirementDocumentOnBase(string type, int coprId, int requirementCatId, int requirementTypeId);

        IEnumerable<Requirement.Comunication> GetAllComunications(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId);

        Requirement.Document GetSpecialDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo, int documentType);

        IEnumerable<Requirement.Product> GetRequirementProduct(Requirement.Product.Key parameter);

        int SetReqAgent(Requirement reqAgent);
        int SetReqAgent(IEnumerable<Requirement> reqAgents);

        int SetList(IEnumerable<Requirement> requirements);
        int SetDocumentStatus(Requirement.Document document);
        int SendToReinsurance(Requirement requirement);
        int InsertDocument(Requirement.Document document);
        int InsertComunication(Requirement.Comunication comunication);
        int DeleteDocument(Requirement.Document document);
        int DeleteAll(Requirement requirement);
        int Insert(Requirement requirement);
        int Update(Requirement requirement);

        //Bmarroquin 03-04-2017 se crea metodo
        IEnumerable<Requirement.Compliance> GetComplianceContacts(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int languageId, int CompanyId);
    }
}
