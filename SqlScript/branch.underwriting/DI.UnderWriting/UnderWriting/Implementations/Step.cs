using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;
using System;
using System.Collections.Generic;

namespace DI.UnderWriting.Implementations
{
    public class StepBll : IStep
    {
        private StepManager _stepManager;

        public StepBll()
        {
            _stepManager = new StepManager();
        }

        IEnumerable<Step> IStep.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int stepTypeId)
        {
            return
                 _stepManager.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, stepTypeId);
        }

        IEnumerable<Step.Note> IStep.GetAllNotes(Step step)
        {
            return
                _stepManager.GetAllNotes(step);
        }

        int IStep.Insert(Step.NewStep newStep)
        {
            return
                _stepManager.Insert(newStep);
        }

        int IStep.CloseStep(Step step)
        {
            return
                _stepManager.CloseStep(step);
        }

        int IStep.VoidStep(Step step)
        {
            return
                _stepManager.VoidStep(step);
        }

        int IStep.InsertNote(Step.Note note)
        {
            return
                _stepManager.InsertNote(note);
        }

        IEnumerable<Step.Workflow> IStep.GetWorkflow(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _stepManager.GetWorkflow(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }

        int IStep.UpdateNote(Step.Note note)
        {
            return
                _stepManager.UpdateNote(note);
        }

        IEnumerable<Policy.Call> IStep.GetAllCall(Step step)
        {
            return
               _stepManager.GetAllCall(step);
        }

        int IStep.DeleteCall(Policy.Call call)
        {
            return
                _stepManager.DeleteCall(call);
        }

        int IStep.InsertStepComment(Step step)
        {
            return
                _stepManager.InsertStepComment(step);
        }

        IEnumerable<Step.ExtraInfo> IStep.GetStepExtraInfo(Policy.Parameter policyParameter)
        {
            return
                _stepManager.GetStepExtraInfo(policyParameter);
        }

        int IStep.InsertDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
                _stepManager.InsertDocumentExtraInfo(extraInfo);
        }

        int IStep.UpdateDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
               _stepManager.UpdateDocumentExtraInfo(extraInfo);
        }

        int IStep.InsertLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
                _stepManager.InsertLinkExtraInfo(extraInfo);
        }

        int IStep.UpdateLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
               _stepManager.UpdateLinkExtraInfo(extraInfo);
        }

        int IStep.SetExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
               _stepManager.SetExtraInfo(extraInfo);
        }

        IEnumerable<Step> IStep.GetAll_byStepId(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int stepTypeId, int stepId)
        {
            return
                 _stepManager.GetAll_byStepId(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, stepTypeId, stepId);
        }

    }

    public class StepWS : IStep
    {
        IEnumerable<Step> IStep.GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int stepTypeId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Step.Note> IStep.GetAllNotes(Step step)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Step.Workflow> IStep.GetWorkflow(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        int IStep.Insert(Step.NewStep newStep)
        {
            throw new NotImplementedException();
        }

        int IStep.CloseStep(Step step)
        {
            throw new NotImplementedException();
        }

        int IStep.VoidStep(Step step)
        {
            throw new NotImplementedException();
        }

        int IStep.InsertNote(Step.Note note)
        {
            throw new NotImplementedException();
        }

        int IStep.UpdateNote(Step.Note note)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Policy.Call> IStep.GetAllCall(Step step)
        {
            throw new NotImplementedException();
        }

        int IStep.DeleteCall(Policy.Call call)
        {
            throw new NotImplementedException();
        }

        int IStep.InsertStepComment(Step step)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Step.ExtraInfo> IStep.GetStepExtraInfo(Policy.Parameter policyParameter)
        {
            throw new NotImplementedException();
        }

        int IStep.InsertDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            throw new NotImplementedException();
        }

        int IStep.UpdateDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            throw new NotImplementedException();
        }

        int IStep.InsertLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            throw new NotImplementedException();
        }

        int IStep.UpdateLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            throw new NotImplementedException();
        }

        int IStep.SetExtraInfo(Step.ExtraInfo extraInfo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Step> IStep.GetAll_byStepId(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int stepTypeId, int stepId)
        {
            throw new NotImplementedException();
        }

    }
}
