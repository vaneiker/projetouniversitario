using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class ConfirmationCallBll : IConfirmationCall
    {
        private ConfirmationCallManager _confirmationCallManager;

        public ConfirmationCallBll()
        {
            _confirmationCallManager = new ConfirmationCallManager();
        }

        IEnumerable<ConfirmationCall.Pending> IConfirmationCall.GetAll(int corpId, int companyId, int userId, string statusCall, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            return
                _confirmationCallManager.GetAll(corpId, companyId, userId, statusCall, policyNo, initialDateFrom, initialDateTo);
        }

        int IConfirmationCall.InsertContactAction(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId, int actionId, int actionSeqNo, int stepTypeId, int stepId, int stepCaseNo, int userId)
        {
            return
                  _confirmationCallManager.InsertContactAction(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
               , contactId, contactRoleTypeId, actionId, actionSeqNo, stepTypeId, stepId, stepCaseNo, userId);
        }

        IEnumerable<ConfirmationCall.Count> IConfirmationCall.GetAllCount(int corpId, int companyId, int userId, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            return
                _confirmationCallManager.GetAllCount(corpId,  companyId,  userId, policyNo, initialDateFrom, initialDateTo);
        }
    }

    public class ConfirmationCallWS : IConfirmationCall
    {
        IEnumerable<ConfirmationCall.Pending> IConfirmationCall.GetAll(int corpId, int companyId, int userId, string statusCall, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            throw new NotImplementedException();
        }

        int IConfirmationCall.InsertContactAction(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId, int actionId, int actionSeqNo, int stepTypeId, int stepId, int stepCaseNo, int userId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ConfirmationCall.Count> IConfirmationCall.GetAllCount(int corpId, int companyId, int userId, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            throw new NotImplementedException();
        }
    }
}
