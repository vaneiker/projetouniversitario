using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface ICase
    {
        IEnumerable<Case> GetAllOpen(int companyId, int underwriterId);
        IEnumerable<Case> GetAllProcessing(int companyId, int underwriterId);
        IEnumerable<Case> GetAllAwaitingInformation(int companyId, int underwriterId);
        IEnumerable<Case> GetAllReinsurance(int companyId, int underwriterId);
        IEnumerable<Case> GetAllAlert(int companyId, int underwriterId);
        IEnumerable<Case> GetAllException(int companyId, int underwriterId);
        IEnumerable<Case> GetAllRecent(int companyId, int underwriterId);
        IEnumerable<Case> GetAllChange(int companyId, int underwriterId);
        IEnumerable<Case> GetAllSearchResult(Case.SearchResult searchResult);
        //ROJAS
        IEnumerable<Case> GetAllHistory(int companyId, int underwriterId);

        IEnumerable<Case> GetAllOpen(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllProcessing(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllAwaitingInformation(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllReinsurance(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllAlert(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllException(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllRecent(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllChange(Policy.Parameter policyParameter);
        IEnumerable<Case> GetAllSearchResult(Policy.Parameter policyParameter);
        //ROJAS
        IEnumerable<Case> GetAllHistory(Policy.Parameter policyParameter);


        IEnumerable<Case> GetAllByType(string type, int companyId, int underwriterId);
        IEnumerable<Case> GetAllByType(string type, Policy.Parameter policyParameter);

        Policy GenerateNewCase(Case.NewCase newCase);

        IEnumerable<Case.Process> GetAllInProcess(Policy.NBParameter paramerter);
        IEnumerable<Case.Process> GetAllInReview(Policy.NBParameter paramerter);
        IEnumerable<Case.Process> GetAllEffectivePendingReceipt(Policy.NBParameter paramerter);

        IEnumerable<Case.Queue> GetQueue(int companyId, int underwriterId);

        IEnumerable<Case.TabCount> GetAllTabCounts(int companyId, int underwriterId);

        Case.CaseResult SendToReview(Case currentCase);
        Case.CaseResult SendToReject(Case currentCase);
        Case.CaseResult SendToStl(Case currentCase);

        IEnumerable<Case.Comment> GetAllComments(Case currentCase);
        int InsertComment(Case.Comment comment);

        Case.AssignCase SetAssignCase(Case.AssignCase paramter);
    }
}
