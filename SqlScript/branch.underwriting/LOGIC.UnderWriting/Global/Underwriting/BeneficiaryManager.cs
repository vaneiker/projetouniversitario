using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class BeneficiaryManager
    {
        private BeneficiaryRepository _beneficiaryRepository;
        private ContactRepository _contactRepository;

        public BeneficiaryManager()
        {
            _beneficiaryRepository = SingletonUnitOfWork.Instance.BeneficiaryRepository;
            _contactRepository = SingletonUnitOfWork.Instance.ContactRepository;
        }
        public virtual IEnumerable<Beneficiary> GetAllBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            Policy.Parameter policyParameter;

            policyParameter = new Policy.Parameter
            {
                CorpId = coprId,
                RegionId = regionId,
                CountryId = countryId,
                DomesticregId = domesticRegId,
                StateProvId = stateProvId,
                CityId = cityId,
                OfficeId = officeId,
                CaseSeqNo = caseSeqNo,
                HistSeqNo = histSeqNo,
                LanguageId = languageId
            };

            return
                _beneficiaryRepository.GetAll(policyParameter, isInsured, beneficiaryTypeId, contactId, languageId);
        }
        public virtual IEnumerable<Beneficiary> GetAllBeneficiaryExtended(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId)
        {
            Policy.Parameter policyParameter;

            policyParameter = new Policy.Parameter
            {
                CorpId = coprId,
                RegionId = regionId,
                CountryId = countryId,
                DomesticregId = domesticRegId,
                StateProvId = stateProvId,
                CityId = cityId,
                OfficeId = officeId,
                CaseSeqNo = caseSeqNo,
                HistSeqNo = histSeqNo,
                LanguageId = languageId
            };

            return
                _beneficiaryRepository.GetAllExtended(policyParameter, isInsured, beneficiaryTypeId, contactId, languageId);
        }

        public virtual int InsertBeneficiary(Beneficiary beneficiary)
        {
            return
                 _beneficiaryRepository.Insert(beneficiary);
        }
        public virtual int UpdatetBeneficiary(Beneficiary beneficiary)
        {
            return
                  _beneficiaryRepository.Update(beneficiary);
        }
        public virtual int DeleteBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId)
        {
            return
                  _beneficiaryRepository.Delete(
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

        public virtual Contact.IdDocument GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId)
        {
            Contact.IdDocument result;

            result = _contactRepository.GetIdDocument(contactId, documentCategoryId, documentTypeId, documentId);

            return
                result;
        }

        public virtual int SetDocument(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            return
                  _beneficiaryRepository.SetDocument(contactId, seqNo, documentId, documentBinary, userId);
        }

        public virtual int UpdateComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool isInsured, int beneficiaryTypeId, string comment, int userId)
        {
            return
                _beneficiaryRepository.UpdateComment(
               coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, isInsured, beneficiaryTypeId, comment, userId
                );
        }
        public virtual int SetDocumentExtended(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId)
        {
            return
                  _beneficiaryRepository.SetDocumentExtended(contactId, seqNo, documentId, documentBinary, userId);
        }
        public virtual int GetLastSequenceContactIDsByContactId(int contactId)
        {
            return _beneficiaryRepository.GetLastSequenceContactIDsByContactId(contactId);
        }
    }
}
