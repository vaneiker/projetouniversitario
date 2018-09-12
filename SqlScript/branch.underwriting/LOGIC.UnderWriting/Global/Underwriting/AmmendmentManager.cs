using System;
using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class AmmendmentManager
    {
        private AmmendmentRepository _ammendmentRepository;

        public AmmendmentManager()
        {
            _ammendmentRepository = SingletonUnitOfWork.Instance.AmmendmentRepository;
        }

        public virtual IEnumerable<Ammendment> GetAllAmmendmentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _ammendmentRepository.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo);
        }

        public virtual Ammendment GetAmmendment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                _ammendmentRepository.Get(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);
        }

        public virtual int InsertAmmendment(Ammendment ammendment)
        {
            if (ammendment.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (ammendment.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (ammendment.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (ammendment.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (ammendment.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (ammendment.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (ammendment.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (ammendment.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (ammendment.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");

            ammendment.AmmendmentId = -1;

            return
                _ammendmentRepository.Insert(ammendment);
        }

        public virtual Ammendment.Detail InsertAmmendmentDetail(Ammendment.Detail ammeDet)
        {
            if (ammeDet.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (ammeDet.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (ammeDet.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (ammeDet.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (ammeDet.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (ammeDet.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (ammeDet.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (ammeDet.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (ammeDet.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (ammeDet.AmmendmentId <= 0)
                throw new ArgumentException("This property can't be under 0.", "AmmendmentId");
            if (ammeDet.DocTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DocTypeId");
            if (ammeDet.DocCategoryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DocCategoryId");
            if (ammeDet.DocumentBinary == null)
                throw new ArgumentException("This property can't be null.", "DocumentBinary");

            ammeDet.AmmendmentDetId = -1;
            ammeDet.CreationDate = DateTime.Now;

            return
                _ammendmentRepository.InsertAmmendmentDetail(ammeDet);
        }
    }
}
