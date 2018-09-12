using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class DataReviewBll : IDataReview
    {
        private DataReviewManager _dataReviewManager;

        public DataReviewBll()
        {
            _dataReviewManager = new DataReviewManager();
        }

        IEnumerable<DataReview> IDataReview.GetAll(Parameter.Case parameter)
        {
            return
                _dataReviewManager.GetAll(parameter);
        }

        IEnumerable<DataReview.DocumentToReview> IDataReview.GetDocumentsToReview(Policy.Parameter policyParameter)
        {
            return
                _dataReviewManager.GetDocumentsToReview(policyParameter);
        }

        int IDataReview.SetDocumentReview(DataReview.DocumentToReview docReview)
        {
            return
                _dataReviewManager.SetDocumentReview(docReview);
        }

        DataReview.DocumentInfomation IDataReview.GetDocument(DataReview.DocumentInfomation document)
        {
            return
                _dataReviewManager.GetDocument(document);
        }

        IEnumerable<DataReview.Change> IDataReview.GetAllRejected(int companyId, int underwriterId)
        {
            return
                _dataReviewManager.GetAllRejected(companyId, underwriterId);
        }

        IEnumerable<DataReview.Change> IDataReview.GetAllApproved(int companyId, int underwriterId)
        {
            return
                _dataReviewManager.GetAllApproved(companyId, underwriterId);
        }

        IEnumerable<DataReview.DRCaseResult> IDataReview.SendToUnderwriting(IEnumerable<DataReview.DRCase> drCases)
        {
            return
                _dataReviewManager.SendToUnderwriting(drCases);
        }

        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMerge(Policy.Parameter policyParameter)
        {
            return
                _dataReviewManager.GetContactMerge(policyParameter);
        }
        [ObsoleteAttribute("This method is deprecated.")]
        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMergeMath(int contactId, int languageId)
        {
            return
                _dataReviewManager.GetContactMergeMath(contactId, languageId);
        }

        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMergeMath(IEnumerable<int> contactIds, int languageId)
        {
            return
                _dataReviewManager.GetContactMergeMath(contactIds, languageId);
        }

        IEnumerable<Case.Process> IDataReview.GetAllInProcessNB(int companyId, int underwriterId)
        {
            return
                _dataReviewManager.GetAllInProcessNB(companyId, underwriterId);
        }

        IEnumerable<Case.Process> IDataReview.GetAllInReviewNB(int companyId, int underwriterId)
        {
            return
                _dataReviewManager.GetAllInReviewNB(companyId, underwriterId);
        }
    }

    public class DataReviewWS : IDataReview
    {
        IEnumerable<DataReview> IDataReview.GetAll(Parameter.Case parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.DocumentToReview> IDataReview.GetDocumentsToReview(Policy.Parameter policyParameter)
        {
            throw new NotImplementedException();
        }

        int IDataReview.SetDocumentReview(DataReview.DocumentToReview docReview)
        {
            throw new NotImplementedException();
        }

        DataReview.DocumentInfomation IDataReview.GetDocument(DataReview.DocumentInfomation document)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.Change> IDataReview.GetAllRejected(int companyId, int underwriterId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.Change> IDataReview.GetAllApproved(int companyId, int underwriterId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Case.Process> IDataReview.GetAllInProcessNB(int companyId, int underwriterId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Case.Process> IDataReview.GetAllInReviewNB(int companyId, int underwriterId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.DRCaseResult> IDataReview.SendToUnderwriting(IEnumerable<DataReview.DRCase> drCases)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMerge(Policy.Parameter policyParameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMergeMath(int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DataReview.ContactMerge> IDataReview.GetContactMergeMath(IEnumerable<int> contactIds, int languageId)
        {
            throw new NotImplementedException();
        }
    }
}
