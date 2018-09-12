using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IBeneficiary
    {
        IEnumerable<Beneficiary> GetAllBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId);

        IEnumerable<Beneficiary> GetAllBeneficiaryExtended(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool? isInsured, int? beneficiaryTypeId, int? contactId, int languageId); 
        int InsertBeneficiary(Beneficiary beneficiary);
        int UpdatetBeneficiary(Beneficiary beneficiary);
        int DeleteBeneficiary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId);
        Contact.IdDocument GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId);
        int SetDocument(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId);

        int UpdateComment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, bool isInsured, int beneficiaryTypeId, string comment, int userId);

        int SetDocumentExtended(int contactId, int? seqNo, int? documentId, byte[] documentBinary, int userId);
        int GetLastSequenceContactIDsByContactId(int contactId);
    }
}
