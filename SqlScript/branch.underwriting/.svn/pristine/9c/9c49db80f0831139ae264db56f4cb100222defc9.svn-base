using System;
using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IConfirmationCall
    {
        IEnumerable<ConfirmationCall.Pending> GetAll(int corpId, int companyId, int userId, string statusCall, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo);
        int InsertContactAction(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
              , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId
              , int actionId, int actionSeqNo, int stepTypeId, int stepId, int stepCaseNo, int userId);
        IEnumerable<ConfirmationCall.Count> GetAllCount(int corpId, int companyId, int userId, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo);
    }
}
