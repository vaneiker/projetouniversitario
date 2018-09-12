using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class RequirementBll : IRequirement
    {
        private RequirementManager _requirementManager;

        public RequirementBll()
        {
            _requirementManager = new RequirementManager();
        }

        IEnumerable<Requirement> IRequirement.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int languageId)
        {
            return
                 _requirementManager.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, languageId);
        }

        IEnumerable<Requirement.Document> IRequirement.GetAllDocuments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId)
        {
            return
                 _requirementManager.GetAllDocuments(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
                 , contactId, requirementCatId, requirementTypeId, requirementId);
        }

        Requirement.Document IRequirement.GetDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId, int requirementDocId)
        {
            return
               _requirementManager.GetDocument(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
               , contactId, requirementCatId, requirementTypeId, requirementId, requirementDocId);
        }

        Requirement.DocumentRequirementOnBase IRequirement.GetRequirementDocumentOnBase(string type, int coprId, int requirementCatId, int requirementTypeId)
        {
            return
               _requirementManager.GetRequirementDocumentOnBase(type,coprId, requirementCatId, requirementTypeId);
        }

        IEnumerable<Requirement.Comunication> IRequirement.GetAllComunications(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId)
        {
            return
                 _requirementManager.GetAllComunications(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
                 , contactId, requirementCatId, requirementTypeId, requirementId);
        }

        int IRequirement.Insert(Requirement requirement)
        {
            return
                _requirementManager.Insert(requirement);
        }
        int IRequirement.Update(Requirement requirement)
        {
            return
                _requirementManager.Update(requirement);
        }

        int IRequirement.SetList(IEnumerable<Requirement> requirements)
        {
            return
                _requirementManager.SetList(requirements);
        }

        int IRequirement.SetDocumentStatus(Requirement.Document document)
        {
            return
                 _requirementManager.SetDocumentStatus(document);
        }

        int IRequirement.SendToReinsurance(Requirement requirement)
        {
            return
                  _requirementManager.SendToReinsurance(requirement);
        }

        int IRequirement.InsertDocument(Requirement.Document document)
        {
            return
               _requirementManager.InsertDocument(document);
        }

        int IRequirement.InsertComunication(Requirement.Comunication comunication)
        {
            return
               _requirementManager.InsertComunication(comunication);
        }

        IEnumerable<Requirement.CategoryByContactRole> IRequirement.GetAllCategoryByContactRole(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                  _requirementManager.GetAllCategoryByContactRole(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }

        IEnumerable<Requirement> IRequirement.GetAllNewBusiness(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? requirementCatId, int languageId)
        {
            return
               _requirementManager.GetAllNewBusiness(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId
                    , caseSeqNo, histSeqNo, contactId, requirementCatId, languageId);
        }

        int IRequirement.DeleteDocument(Requirement.Document document)
        {
            return
              _requirementManager.DeleteDocument(document);
        }

        int IRequirement.DeleteAll(Requirement requirement)
        {
            return
              _requirementManager.DeleteAll(requirement);
        }

        Requirement.Document IRequirement.GetSpecialDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentType)
        {
            return
              _requirementManager.GetSpecialDocument(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId
                   , caseSeqNo, histSeqNo, documentType);
        }

        int IRequirement.SetReqAgent(Requirement reqAgent)
        {
            return
                _requirementManager.SetReqAgent(reqAgent);
        }

        int IRequirement.SetReqAgent(IEnumerable<Requirement> reqAgents)
        {
            return
                _requirementManager.SetReqAgent(reqAgents);
        }

        IEnumerable<Requirement.Product> IRequirement.GetRequirementProduct(Requirement.Product.Key parameter)
        {
            return
                _requirementManager.GetRequirementProduct(parameter);
        }
		//Bmarroquin 03-04-2017 se crea metodo
        public IEnumerable<Requirement.Compliance> GetComplianceContacts(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int languageId,int CompanyId)
        {
            return _requirementManager.GetComplianceContacts(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, languageId, CompanyId);
        }
       
    }

    public class RequirementWS : IRequirement
    {

        //Bmarroquin 03-04-2017 se crea metodo
        public IEnumerable<Requirement.Compliance> GetComplianceContacts(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int languageId, int CompanyId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement> IRequirement.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement.CategoryByContactRole> IRequirement.GetAllCategoryByContactRole(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement> IRequirement.GetAllNewBusiness(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? requirementCatId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement.Document> IRequirement.GetAllDocuments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId)
        {
            throw new NotImplementedException();
        }

        Requirement.Document IRequirement.GetDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId, int requirementDocId)
        {
            throw new NotImplementedException();
        }

        Requirement.DocumentRequirementOnBase IRequirement.GetRequirementDocumentOnBase(string type, int coprId, int requirementCatId, int requirementTypeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement.Comunication> IRequirement.GetAllComunications(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int requirementCatId, int requirementTypeId, int requirementId)
        {
            throw new NotImplementedException();
        }

        Requirement.Document IRequirement.GetSpecialDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentType)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Requirement.Product> IRequirement.GetRequirementProduct(Requirement.Product.Key parameter)
        {
            throw new NotImplementedException();
        }

        int IRequirement.SetReqAgent(Requirement reqAgent)
        {
            throw new NotImplementedException();
        }

        int IRequirement.SetReqAgent(IEnumerable<Requirement> reqAgents)
        {
            throw new NotImplementedException();
        }

        int IRequirement.SetList(IEnumerable<Requirement> requirements)
        {
            throw new NotImplementedException();
        }

        int IRequirement.SetDocumentStatus(Requirement.Document document)
        {
            throw new NotImplementedException();
        }

        int IRequirement.SendToReinsurance(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        int IRequirement.InsertDocument(Requirement.Document document)
        {
            throw new NotImplementedException();
        }

        int IRequirement.InsertComunication(Requirement.Comunication comunication)
        {
            throw new NotImplementedException();
        }

        int IRequirement.DeleteDocument(Requirement.Document document)
        {
            throw new NotImplementedException();
        }

        int IRequirement.DeleteAll(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        int IRequirement.Insert(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        int IRequirement.Update(Requirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
