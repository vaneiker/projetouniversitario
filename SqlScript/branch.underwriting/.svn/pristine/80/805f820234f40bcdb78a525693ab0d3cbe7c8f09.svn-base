using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IMedical
    {
        IEnumerable<Medical> GetInfo(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId);
        IEnumerable<Medical.Condition> GetCondition(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId);
        IEnumerable<Medical.FamilyHistory> GetFamilyHistory(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId);
        int SetInfo(Medical info);
        IEnumerable<Medical.ExamReceived> GetExamReceived(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo, int contactId);
        IEnumerable<Medical.ExamResult> GetExamResult(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int contactId
            , int requirementCatId, int requirementTypeId, int requirementId, int medicalTestId);
    }
}
