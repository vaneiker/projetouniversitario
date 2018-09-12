using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class RiderManager
    {
        private RiderRepository _riderRepository;

        public RiderManager()
        {
            _riderRepository = SingletonUnitOfWork.Instance.RiderRepository;
        }

        public virtual IEnumerable<Rider> GetAllRider(Policy.Parameter policyParameter)
        {
            return
                _riderRepository.GetAll(policyParameter);
        }

        public virtual int SetRider(Rider rider)
        {
            return
                _riderRepository.SetRider(rider);
        }

        public virtual IEnumerable<Rider.Comment> GetAllRiderComments(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int riderTypeId, int riderId)
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
                HistSeqNo = histSeqNo
            };

            return
                 _riderRepository.GetAllComments(policyParameter, riderTypeId, riderId);
        }

        public virtual int InsertComment(Rider.Comment comment)
        {
            return
                 _riderRepository.InsertComment(comment);
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
        public virtual int DeleteRider(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int? riderTypeId, int? riderId)
        {
            riderId = null;

            return
                _riderRepository.DeleteRider(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, riderTypeId, riderId);
        }
    }
}
