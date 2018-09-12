using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IRider
    {
        IEnumerable<Rider> GetAllRider(Policy.Parameter policyParameter);
        int SetRider(Rider rider);
        IEnumerable<Rider.Comment> GetAllRiderComments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int riderTypeId, int riderId);
        int InsertComment(Rider.Comment comment);
        int DeleteRider(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int? riderTypeId, int? riderId);
    }
}
