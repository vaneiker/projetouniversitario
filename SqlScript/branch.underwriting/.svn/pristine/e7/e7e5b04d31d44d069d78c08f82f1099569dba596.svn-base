using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class BeneficiaryBll : IBeneficiary
    {
        private BeneficiaryManager _beneficiaryManager;

        public BeneficiaryBll()
        {
            _beneficiaryManager = new BeneficiaryManager();
        }

        IEnumerable<Beneficiary> IBeneficiary.GetAllBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            return
                _beneficiaryManager.GetAllBeneficiary(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, isInsured, beneficiaryTypeId, contactId,  languageId);
        }
        
        IEnumerable<Beneficiary> IBeneficiary.GetAllBeneficiaryExtended(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            return
                _beneficiaryManager.GetAllBeneficiaryExtended(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, isInsured, beneficiaryTypeId, contactId, languageId);
        }

        int IBeneficiary.InsertBeneficiary(Beneficiary beneficiary)
        {
            return
                _beneficiaryManager.InsertBeneficiary(beneficiary);
        }

        int IBeneficiary.UpdatetBeneficiary(Beneficiary beneficiary)
        {
            return
                _beneficiaryManager.UpdatetBeneficiary(beneficiary);
        }

        int IBeneficiary.DeleteBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                _beneficiaryManager.DeleteBeneficiary(
                     coprId,
                     regionId,
                     countryId,
                     domesticRegId,
                     stateProvId,
                     cityId,
                     officeId,
                     caseSeqNo,
                     histSeqNo,
                     contactId,
                     contactRoleTypeId);
        }
        
        Contact.IdDocument IBeneficiary.GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                   _beneficiaryManager.GetIdDocument(contactId, documentCategoryId, documentTypeId, documentId);
        }

        public virtual int SetDocument(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            return
                _beneficiaryManager.SetDocument(contactId, seqNo, documentId, documentBinary, userId);
        }

        int IBeneficiary.UpdateComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool isInsured, int beneficiaryTypeId, string comment, int userId)
        {
            return
                   _beneficiaryManager.UpdateComment(
               coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, isInsured, beneficiaryTypeId, comment, userId
                );
        }

        public int SetDocumentExtended(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            return
                  _beneficiaryManager.SetDocumentExtended(contactId, seqNo, documentId, documentBinary, userId);
        }
        public int GetLastSequenceContactIDsByContactId(int contactId)
        {
            return
                  _beneficiaryManager.GetLastSequenceContactIDsByContactId(contactId);
        }
        
    }
    public class BeneficiaryWS : IBeneficiary
    {
        IEnumerable<Beneficiary> IBeneficiary.GetAllBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            throw new NotImplementedException();
        }
       
        int IBeneficiary.InsertBeneficiary(Beneficiary beneficiary)
        {
            throw new NotImplementedException();
        }

        int IBeneficiary.UpdatetBeneficiary(Beneficiary beneficiary)
        {
            throw new NotImplementedException();
        }

        int IBeneficiary.DeleteBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            throw new NotImplementedException();
        }

        Contact.IdDocument IBeneficiary.GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId)
        {
            throw new NotImplementedException();
        }

        int IBeneficiary.SetDocument(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            throw new NotImplementedException();
        }

        int IBeneficiary.UpdateComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool isInsured, int beneficiaryTypeId, string comment, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Beneficiary> GetAllBeneficiaryExtended(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        public int SetDocumentExtended(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            throw new NotImplementedException();
        }

        public int GetLastSequenceContactIDsByContactId(int contactId)
        {
            throw new NotImplementedException();
        }
    }

}
