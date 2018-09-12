using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class RiderBll : IRider
    {
        private RiderManager _riderManager;

        public RiderBll()
        {
            _riderManager = new RiderManager();
        }
        IEnumerable<Rider> IRider.GetAllRider(Policy.Parameter policyParameter)
        {
            return
                _riderManager.GetAllRider(policyParameter);
        }

        int IRider.SetRider(Rider rider)
        {
            return
                _riderManager.SetRider(rider);
        }

        IEnumerable<Rider.Comment> IRider.GetAllRiderComments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int riderTypeId, int riderId)
        {
            return
                  _riderManager.GetAllRiderComments(coprId, regionId, countryId, domesticRegId
                 , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, riderTypeId, riderId);
        }

        int IRider.InsertComment(Rider.Comment comment)
        {
            return
                  _riderManager.InsertComment(comment);
        }

        /// <summary>
        /// Delete a rider of a policy or delete all riders it.
        /// </summary>
        /// <param name="coprId">Corporation Id</param>
        /// <param name="regionId">Region Id</param>
        /// <param name="countryId">Country Id</param>
        /// <param name="domesticRegId">Domestric Region Id</param>
        /// <param name="stateProvId">State Province Id</param>
        /// <param name="cityId">City Id</param>
        /// <param name="officeId">Office Id</param>
        /// <param name="caseSeqNo">Case Sequence Number</param>
        /// <param name="histSeqNo">History Sequece Number</param>
        /// <param name="riderTypeId">Rider Type Id, if you want to delete all riders let this field null.</param>
        /// <param name="riderId">Rider Id, if you want to delete all riders let this field null.</param>
        /// <returns>int</returns>
        int IRider.DeleteRider(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? riderTypeId, int? riderId)
        {
            return
                  _riderManager.DeleteRider(coprId, regionId, countryId, domesticRegId
                 , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, riderTypeId, riderId);
        }
    }
    public class RiderWS : IRider
    {
        IEnumerable<Rider> IRider.GetAllRider(Policy.Parameter policyParameter)
        {
            throw new NotImplementedException();
        }

        int IRider.SetRider(Rider rider)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Rider.Comment> IRider.GetAllRiderComments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int riderTypeId, int riderId)
        {
            throw new NotImplementedException();
        }

        int IRider.InsertComment(Rider.Comment comment)
        {
            throw new NotImplementedException();
        }

        int IRider.DeleteRider(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? riderTypeId, int? riderId)
        {
            throw new NotImplementedException();
        }
    }
}
