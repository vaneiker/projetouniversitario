using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IAmmendment
    {
        IEnumerable<Ammendment> GetAllAmmendmentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo);
        Ammendment GetAmmendment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId);
        int InsertAmmendment(Ammendment ammendment);
        Ammendment.Detail InsertAmmendmentDetail(Ammendment.Detail ammeDet);
    }
}
