using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class AmmendmentBll : IAmmendment
    {
        private AmmendmentManager _ammendmentManager;

        public AmmendmentBll()
        {
            _ammendmentManager = new AmmendmentManager();
        }

        IEnumerable<Ammendment> IAmmendment.GetAllAmmendmentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _ammendmentManager.GetAllAmmendmentInformation(coprId, regionId, countryId, domesticRegId, stateProvId
                    , cityId, officeId, caseSeqNo, histSeqNo);
        }

        Ammendment IAmmendment.GetAmmendment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                 _ammendmentManager.GetAmmendment(coprId, regionId, countryId, domesticRegId, stateProvId
                     , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);
        }

        int IAmmendment.InsertAmmendment(Ammendment ammendment)
        {
            return
                 _ammendmentManager.InsertAmmendment(ammendment);
        }

        Ammendment.Detail IAmmendment.InsertAmmendmentDetail(Ammendment.Detail ammeDet)
        {
            return
                  _ammendmentManager.InsertAmmendmentDetail(ammeDet);
        }
    }
    public class AmmendmentWS : IAmmendment
    {
        IEnumerable<Ammendment> IAmmendment.GetAllAmmendmentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        Ammendment IAmmendment.GetAmmendment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            throw new NotImplementedException();
        }

        int IAmmendment.InsertAmmendment(Ammendment ammendment)
        {
            throw new NotImplementedException();
        }

        Ammendment.Detail IAmmendment.InsertAmmendmentDetail(Ammendment.Detail ammeDet)
        {
            throw new NotImplementedException();
        }
    }
}
