using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IStep
    {
        IEnumerable<Step> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
         , int officeId, int caseSeqNo, int histSeqNo, int stepTypeId);
        IEnumerable<Step.Note> GetAllNotes(Step step);
        IEnumerable<Step.Workflow> GetWorkflow(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo);
        int Insert(Step.NewStep newStep);
        int CloseStep(Step step);
        int VoidStep(Step step);
        int InsertNote(Step.Note note);
        int UpdateNote(Step.Note note);
        IEnumerable<Policy.Call> GetAllCall(Step step);
        int DeleteCall(Policy.Call call);
        int InsertStepComment(Step step);

        IEnumerable<Step.ExtraInfo> GetStepExtraInfo(Policy.Parameter policyParameter);

        int InsertDocumentExtraInfo(Step.ExtraInfo extraInfo);
        int UpdateDocumentExtraInfo(Step.ExtraInfo extraInfo);

        int InsertLinkExtraInfo(Step.ExtraInfo extraInfo);
        int UpdateLinkExtraInfo(Step.ExtraInfo extraInfo);
        int SetExtraInfo(Step.ExtraInfo extraInfo);
        IEnumerable<Step> GetAll_byStepId(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
         , int officeId, int caseSeqNo, int histSeqNo, int stepTypeId, int stepId);
    }
}
