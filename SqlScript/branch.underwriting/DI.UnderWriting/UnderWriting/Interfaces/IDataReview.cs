using System;
using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IDataReview
    {
        IEnumerable<DataReview> GetAll(Parameter.Case parameter);
        
        IEnumerable<DataReview.DocumentToReview> GetDocumentsToReview(Policy.Parameter policyParameter);
       
        int SetDocumentReview(DataReview.DocumentToReview docReview);
        
        DataReview.DocumentInfomation GetDocument(DataReview.DocumentInfomation document);
        
        IEnumerable<DataReview.Change> GetAllRejected(int companyId, int underwriterId);
        
        IEnumerable<DataReview.Change> GetAllApproved(int companyId, int underwriterId);
        
        IEnumerable<Case.Process> GetAllInProcessNB(int companyId, int underwriterId);
        
        IEnumerable<Case.Process> GetAllInReviewNB(int companyId, int underwriterId);
        
        IEnumerable<DataReview.DRCaseResult> SendToUnderwriting(IEnumerable<DataReview.DRCase> drCases);
        
        IEnumerable<DataReview.ContactMerge> GetContactMerge(Policy.Parameter policyParameter);
        
        [ObsoleteAttribute("This method is deprecated.")]
        IEnumerable<DataReview.ContactMerge> GetContactMergeMath(int contactId, int languageId);
        
        IEnumerable<DataReview.ContactMerge> GetContactMergeMath(IEnumerable<int> contactIds, int languageId);
    }
}
