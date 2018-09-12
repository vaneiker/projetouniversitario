using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class CaseBll : ICase
    {
        private CaseManager _caseManager;

        public CaseBll()
        {
            _caseManager = new CaseManager();
        }

        IEnumerable<Case> ICase.GetAllOpen(int companyId, int underwriterId)
        {
            return
                _caseManager.GetAllOpen(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllHistory(int companyId, int underwriterId)
        {
            return
                _caseManager.GetAllHistory(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllProcessing(int companyId, int underwriterId)
        {
            return
                 _caseManager.GetAllProcessing(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllAwaitingInformation(int companyId, int underwriterId)
        {
            return
                 _caseManager.GetAllAwaitingInformation(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllReinsurance(int companyId, int underwriterId)
        {
            return
                  _caseManager.GetAllReinsurance(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllAlert(int companyId, int underwriterId)
        {
            return
                 _caseManager.GetAllAlert(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllException(int companyId, int underwriterId)
        {
            return
                 _caseManager.GetAllException(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllRecent(int companyId, int underwriterId)
        {
            return
                 _caseManager.GetAllRecent(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllChange(int companyId, int underwriterId)
        {
            return
                _caseManager.GetAllChange(companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllSearchResult(Case.SearchResult searchResult)
        {
            return
                 _caseManager.GetAllSearchResult(searchResult);
        }

        IEnumerable<Case.TabCount> ICase.GetAllTabCounts(int companyId, int underwriterId)
        {
            return
                _caseManager.GetAllTabCounts(companyId, underwriterId);
        }

        Policy ICase.GenerateNewCase(Case.NewCase newCase)
        {
            return
                _caseManager.GenerateNewCase(newCase);
        }

        IEnumerable<Case.Process> ICase.GetAllInProcess(Policy.NBParameter paramerter)
        {
            return
                _caseManager.GetAllInProcess(paramerter);
        }

        IEnumerable<Case.Process> ICase.GetAllInReview(Policy.NBParameter paramerter)
        {
            return
                _caseManager.GetAllInReview(paramerter);
        }

        Case.CaseResult ICase.SendToReview(Case currentCase)
        {
            return
                _caseManager.SendToReview(currentCase);
        }

        Case.CaseResult ICase.SendToReject(Case currentCase)
        {
            return
                _caseManager.SendToReject(currentCase);
        }

        IEnumerable<Case.Comment> ICase.GetAllComments(Case currentCase)
        {
            return
                _caseManager.GetAllComments(currentCase);
        }

        int ICase.InsertComment(Case.Comment comment)
        {
            return
                _caseManager.InsertComment(comment);
        }

        Case.CaseResult ICase.SendToStl(Case currentCase)
        {
            return
               _caseManager.SendToStl(currentCase);
        }

        IEnumerable<Case.Process> ICase.GetAllEffectivePendingReceipt(Policy.NBParameter paramerter)
        {
            return
                _caseManager.GetAllEffectivePendingReceipt(paramerter);
        }

        IEnumerable<Case> ICase.GetAllOpen(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllOpen(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllHistory(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllHistory(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllProcessing(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllProcessing(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllAwaitingInformation(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllAwaitingInformation(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllReinsurance(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllReinsurance(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllAlert(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllAlert(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllException(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllException(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllRecent(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllRecent(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllChange(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllChange(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllSearchResult(Policy.Parameter policyParameter)
        {
            return
                _caseManager.GetAllSearchResult(policyParameter);
        }

        IEnumerable<Case> ICase.GetAllByType(string type, int companyId, int underwriterId)
        {
            return
                _caseManager.GetAllByType(type, companyId, underwriterId);
        }

        IEnumerable<Case> ICase.GetAllByType(string type, Policy.Parameter policyParameter)
        {
            return
               _caseManager.GetAllByType(type, policyParameter);
        }

        IEnumerable<Case.Queue> ICase.GetQueue(int companyId, int underwriterId)
        {
            return
                _caseManager.GetQueue(companyId, underwriterId);
        }

        Case.AssignCase ICase.SetAssignCase(Case.AssignCase paramter)
        {
            return
                _caseManager.SetAssignCase(paramter);
        }
    }

    public class CaseWS : ICase
    {

        IEnumerable<Case> ICase.GetAllOpen(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllHistory(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllProcessing(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllAwaitingInformation(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllReinsurance(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllAlert(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllException(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllRecent(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllChange(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllSearchResult(Case.SearchResult searchResult)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllOpen(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllHistory(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllProcessing(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllAwaitingInformation(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllReinsurance(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllAlert(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllException(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllRecent(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllChange(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllSearchResult(Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllByType(string type, int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case> ICase.GetAllByType(string type, Policy.Parameter policyParameter)
        {
            throw new System.NotImplementedException();
        }

        Policy ICase.GenerateNewCase(Case.NewCase newCase)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.Process> ICase.GetAllInProcess(Policy.NBParameter paramerter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.Process> ICase.GetAllInReview(Policy.NBParameter paramerter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.Process> ICase.GetAllEffectivePendingReceipt(Policy.NBParameter paramerter)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.Queue> ICase.GetQueue(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.TabCount> ICase.GetAllTabCounts(int companyId, int underwriterId)
        {
            throw new System.NotImplementedException();
        }

        Case.CaseResult ICase.SendToReview(Case currentCase)
        {
            throw new System.NotImplementedException();
        }

        Case.CaseResult ICase.SendToReject(Case currentCase)
        {
            throw new System.NotImplementedException();
        }

        Case.CaseResult ICase.SendToStl(Case currentCase)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Case.Comment> ICase.GetAllComments(Case currentCase)
        {
            throw new System.NotImplementedException();
        }

        int ICase.InsertComment(Case.Comment comment)
        {
            throw new System.NotImplementedException();
        }

        Case.AssignCase ICase.SetAssignCase(Case.AssignCase paramter)
        {
            throw new System.NotImplementedException();
        }
    }
}
