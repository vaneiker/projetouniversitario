using System;
using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class ConfirmationCallManager
    {
        private ConfirmationCallRepository _confirmationCallRepository;

        public ConfirmationCallManager()
        {
            _confirmationCallRepository = SingletonUnitOfWork.Instance.ConfirmationCallRepository;
        }

        public virtual IEnumerable<ConfirmationCall.Pending> GetAll(int corpId, int companyId, int userId, string statusCall, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            if (string.IsNullOrWhiteSpace(statusCall))
                throw new ArgumentException("This property can't be whitespace or null.", "statusCall");
            if (corpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "corpId");
            if (companyId <= 0)
                throw new ArgumentException("This property can't be under 0.", "companyId");
            if (userId <= 0)
                throw new ArgumentException("This property can't be under 0.", "userId");

            statusCall = statusCall.Trim();
            policyNo = string.IsNullOrWhiteSpace(policyNo) ? null : policyNo.Trim();

            return
                 _confirmationCallRepository.GetAll(corpId, companyId, userId, statusCall, policyNo, initialDateFrom, initialDateTo);
        }

        public virtual IEnumerable<ConfirmationCall.Count> GetAllCount(int corpId, int companyId, int userId, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            return
               _confirmationCallRepository.GetAllCount(corpId, companyId, userId, policyNo, initialDateFrom, initialDateTo);
        }

        public virtual int InsertContactAction(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
              , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId
              , int actionId, int actionSeqNo, int stepTypeId, int stepId, int stepCaseNo, int userId)
        {
            return
                   _confirmationCallRepository.InsertContactAction(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
                , contactId, contactRoleTypeId, actionId, actionSeqNo, stepTypeId, stepId, stepCaseNo, userId);
        }
    }
}
