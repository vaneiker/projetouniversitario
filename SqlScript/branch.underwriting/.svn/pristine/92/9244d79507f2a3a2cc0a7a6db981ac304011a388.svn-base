using System;
using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class StepManager
    {
        private StepRepository _stepRepository;
        private string _msg,_msgN;

        public StepManager()
        {
            _stepRepository = SingletonUnitOfWork.Instance.StepRepository;
            _msg = "This property can't be under 0.";
            _msgN = "This property can't be null or under 0.";
        }

        public virtual IEnumerable<Step> GetAll(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
         , int officeId, int caseSeqNo, int histSeqNo, int stepTypeId)
        {
            return
                _stepRepository.GetAll(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, stepTypeId);
        }
        public virtual IEnumerable<Step.Note> GetAllNotes(Step step)
        {
            return
                _stepRepository.GetAllNotes(step);
        }


        public virtual IEnumerable<Step.Workflow> GetWorkflow(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo)
        {
            if (coprId <= 0)
                throw new ArgumentException(_msg, "coprId");
            if (regionId <= 0)
                throw new ArgumentException(_msg, "regionId");
            if (countryId <= 0)
                throw new ArgumentException(_msg, "countryId");
            if (domesticRegId <= 0)
                throw new ArgumentException(_msg, "domesticRegId");
            if (stateProvId <= 0)
                throw new ArgumentException(_msg, "stateProvId");
            if (cityId <= 0)
                throw new ArgumentException(_msg, "cityId");
            if (officeId <= 0)
                throw new ArgumentException(_msg, "officeId");
            if (caseSeqNo <= 0)
                throw new ArgumentException(_msg, "caseSeqNo");
            if (histSeqNo <= 0)
                throw new ArgumentException(_msg, "histSeqNo");

            return
                _stepRepository.GetWorkflow(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }

        public virtual int Insert(Step.NewStep newStep)
        {
            newStep.StepCaseNo = -1;
            newStep.Automatic = false;
            newStep.ProcessDate = DateTime.Now;

            newStep.Note = string.IsNullOrWhiteSpace(newStep.Note)
                ? null
                : newStep.Note.Trim();

            return
                _stepRepository.Set(newStep);
        }

        public virtual IEnumerable<Policy.Call> GetAllCall(Step step)
        {
            return
                _stepRepository.GetAllCall(step);
        }

        public virtual int DeleteCall(Policy.Call call)
        {
            if (call.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (call.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (call.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (call.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (call.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (call.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (call.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (call.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (call.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (call.CommunicationTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CommunicationTypeId");
            if (!call.CallId.HasValue || call.CallId.Value <= 0)
                throw new ArgumentException("This property can't either be null or under 0.", "ContactRoleTypeId");
            if (!call.StepTypeId.HasValue || call.StepTypeId.Value <= 0)
                throw new ArgumentException("This property can't either be null or under 0.", "StepTypeId");
            if (!call.StepId.HasValue || call.StepId.Value <= 0)
                throw new ArgumentException("This property can't either be null or under 0.", "StepId");
            if (!call.StepCaseNo.HasValue || call.StepCaseNo.Value <= 0)
                throw new ArgumentException("This property can't either be null or under 0.", "StepCaseNo");


            return
               _stepRepository.DeleteCall(call);
        }

        public virtual int CloseStep(Step step)
        {
            return
                CloseVoidStep(step, 2);
        }
        public virtual int VoidStep(Step step)
        {
            return
                CloseVoidStep(step, 3);
        }

        public virtual int InsertNote(Step.Note note)
        {
            note.NoteId = -1;
            note.DateAdded = DateTime.Now;
            note.DateModified = null;

            return
                _stepRepository.SetNote(note);
        }
        public virtual int UpdateNote(Step.Note note)
        {
            if (note.NoteId <= 0)
                throw new ArgumentException("This property can't be under 0.", "NoteId");

            note.OriginatedBy = null;
            note.DateAdded = null;
            note.UnderwriterId = null;
            note.NoteName = null;
            note.DateModified = DateTime.Now;

            return
                _stepRepository.SetNote(note);
        }

        public virtual int InsertStepComment(Step step)
        {
            if (step.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (step.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (step.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (step.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (step.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (step.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (step.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (step.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (step.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (step.StepTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StepTypeId");
            if (step.StepId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StepId");
            if (step.StepCaseNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "StepCaseNo");

            return
                _stepRepository.InsertStepComment(step);
        }

        private int CloseVoidStep(Step step, int statusId)
        {
            Step.Process process;

            process = new Step.Process
            {
                CorpId = step.CorpId,
                RegionId = step.RegionId,
                CountryId = step.CountryId,
                DomesticregId = step.DomesticregId,
                StateProvId = step.StateProvId,
                CityId = step.CityId,
                OfficeId = step.OfficeId,
                CaseSeqNo = step.CaseSeqNo,
                HistSeqNo = step.HistSeqNo,
                StepTypeId = step.StepTypeId,
                StepId = step.StepId,
                StepCaseNo = step.StepCaseNo,
                ProcessId = 2,
                StatusTypeId = 1,
                StatusId = statusId,
                ProcessDate = DateTime.Now,
                UserId = step.UserId
            };

            return
                _stepRepository.SetProcess(process);
        }

        public virtual IEnumerable<Step.ExtraInfo> GetStepExtraInfo(Policy.Parameter policyParameter)
        {
            this.IsValid(policyParameter, Utility.DataBaseActionType.Select);

            return
                _stepRepository.GetStepExtraInfo(policyParameter);
        }

        public virtual int InsertDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            this.IsValid(extraInfo, Utility.DataBaseActionType.Insert);

            extraInfo.StepExtraInfoId = -1;

            return
                this.SetDocumentExtraInfo(extraInfo);
        }
        public virtual int UpdateDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            this.IsValid(extraInfo, Utility.DataBaseActionType.Update);

            if (extraInfo.StepExtraInfoId  <= 0)
                throw new ArgumentException(_msg, "StepExtraInfoId");

            return
                this.SetDocumentExtraInfo(extraInfo);
        }

        public virtual int InsertLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            this.IsValid(extraInfo, Utility.DataBaseActionType.Insert);

            extraInfo.StepExtraInfoId = -1;

            return
                this.SetLinkExtraInfo(extraInfo);
        }
        public virtual int UpdateLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            this.IsValid(extraInfo, Utility.DataBaseActionType.Update);

            if (extraInfo.StepExtraInfoId <= 0)
                throw new ArgumentException(_msg, "StepExtraInfoId");

            return
                this.SetLinkExtraInfo(extraInfo);
        }     
        
        public virtual int SetExtraInfo(Step.ExtraInfo extraInfo)
        {
            return
                _stepRepository.SetExtraInfo(extraInfo);
        }

        private int SetDocumentExtraInfo(Step.ExtraInfo extraInfo)
        {
            extraInfo.StepExtraInfoDesc = null;
            extraInfo.StepExtraInfoStatusId = 1;

            if (!extraInfo.DocTypeId.HasValue && extraInfo.DocTypeId.Value <= 0)
                throw new ArgumentException(_msgN, "DocTypeId");
            if (!extraInfo.DocCategoryId.HasValue && extraInfo.DocCategoryId.Value <= 0)
                throw new ArgumentException(_msgN, "DocCategoryId");
            if (!extraInfo.DocumentId.HasValue && extraInfo.DocumentId.Value <= 0)
                throw new ArgumentException(_msgN, "DocumentId");

            return
                this.SetExtraInfo(extraInfo);
        }
        private int SetLinkExtraInfo(Step.ExtraInfo extraInfo)
        {
            extraInfo.DocTypeId = null;
            extraInfo.DocCategoryId = null;
            extraInfo.DocumentId = null;

            if (string.IsNullOrWhiteSpace(extraInfo.StepExtraInfoDesc))
                throw new ArgumentException(_msg, "StepExtraInfoDesc");

            if (extraInfo.StepExtraInfoStatusId <= 0)
                throw new ArgumentException(_msg, "StepExtraInfoStatusId");

            return
                this.SetExtraInfo(extraInfo);
        }

        private void IsValid(Policy.Parameter policy, Utility.DataBaseActionType action)
        {
            if (policy.CorpId <= 0)
                throw new ArgumentException(_msg, "CorpId");
            if (policy.RegionId <= 0)
                throw new ArgumentException(_msg, "RegionId");
            if (policy.CountryId <= 0)
                throw new ArgumentException(_msg, "CountryId");
            if (policy.DomesticregId <= 0)
                throw new ArgumentException(_msg, "DomesticregId");
            if (policy.StateProvId <= 0)
                throw new ArgumentException(_msg, "StateProvId");
            if (policy.CityId <= 0)
                throw new ArgumentException(_msg, "CityId");
            if (policy.OfficeId <= 0)
                throw new ArgumentException(_msg, "OfficeId");
            if (policy.CaseSeqNo <= 0)
                throw new ArgumentException(_msg, "CaseSeqNo");
            if (policy.HistSeqNo <= 0)
                throw new ArgumentException(_msg, "HistSeqNo");
        }
        private void IsValid(Step.ExtraInfo extraInfo, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (extraInfo.CorpId <= 0)
                throw new ArgumentException(_msg, "CorpId");
            if (extraInfo.RegionId <= 0)
                throw new ArgumentException(_msg, "RegionId");
            if (extraInfo.CountryId <= 0)
                throw new ArgumentException(_msg, "CountryId");
            if (extraInfo.DomesticRegId <= 0)
                throw new ArgumentException(_msg, "DomesticRegId");
            if (extraInfo.StateProvId <= 0)
                throw new ArgumentException(_msg, "StateProvId");
            if (extraInfo.CityId <= 0)
                throw new ArgumentException(_msg, "CityId");
            if (extraInfo.OfficeId <= 0)
                throw new ArgumentException(_msg, "OfficeId");
            if (extraInfo.CaseSeqNo <= 0)
                throw new ArgumentException(_msg, "CaseSeqNo");
            if (extraInfo.HistSeqNo <= 0)
                throw new ArgumentException(_msg, "HistSeqNo");
            if (extraInfo.StepTypeId <= 0)
                throw new ArgumentException(_msg, "StepTypeId");
            if (extraInfo.StepId <= 0)
                throw new ArgumentException(_msg, "StepId");
            if (extraInfo.StepCaseNo <= 0)
                throw new ArgumentException(_msg, "StepCaseNo");
            if (extraInfo.StepExtraInfoTypeId <= 0)
                throw new ArgumentException(_msg, "StepExtraInfoTypeId");

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (extraInfo.StepExtraInfoId <= 0)
                        throw new ArgumentException(_msg, "StepExtraInfoId");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    checkUserId = false;
                    break;
            }

            if (checkUserId && extraInfo.UserId <= 0)
                throw new ArgumentException(_msg, "UserId");
        }

        public virtual IEnumerable<Step> GetAll_byStepId(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
         , int officeId, int caseSeqNo, int histSeqNo, int stepTypeId, int stepId)
        {
            return
                _stepRepository.GetAll_byStepId(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, stepTypeId, stepId);
        }

        #region Garbage
        /*
         public virtual IEnumerable<Step.Workflow> GetWorkflow(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo)
        {
            IEnumerable<Step.Workflow> result;
            //    , tempa;
            //List<Step.Workflow> tempb;
            //Step.Workflow nwf;
            //IEnumerable<Step.WorkflowAction> nwfa;
            //IEnumerable<int> keys;
            //int? currentProcessStatus;

            result = _stepRepository.GetWorkflow(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo);

            //if (tempa != null && tempa.Any())
            //{
            //    tempb = new List<Step.Workflow>(1);
            //    keys = tempa
            //            .Select(w => w.StepId)
            //            .Distinct();

            //    foreach (int key in keys)
            //    {
            //        nwfa = tempa
            //                .Where(w => w.StepId == key && w.StepCaseNo.HasValue)
            //                .Select(w => new Step.WorkflowAction
            //                        {
            //                            ActionName = w.StepDesc,
            //                            Opened = w.Opened,
            //                            Closed = w.Closed,
            //                            ProcessStatus = w.ProcessStatus
            //                        })
            //                .ToArray();

            //        currentProcessStatus = nwfa.Min(w => w.ProcessStatus);

            //        nwf = tempa
            //                .Where(w => w.StepId == key)
            //                .Select(w => new Step.Workflow
            //                {
            //                    CorpId = w.CorpId,
            //                    RegionId = w.RegionId,
            //                    CountryId = w.CountryId,
            //                    DomesticregId = w.DomesticregId,
            //                    StateProvId = w.StateProvId,
            //                    CityId = w.CityId,
            //                    OfficeId = w.OfficeId,
            //                    CaseSeqNo = w.CaseSeqNo,
            //                    HistSeqNo = w.HistSeqNo,
            //                    StepTypeId = w.StepTypeId,
            //                    StepId = w.StepId,
            //                    StepCaseNo = w.StepCaseNo,
            //                    Opened = null,
            //                    Closed = null,
            //                    ProcessStatus = currentProcessStatus,
            //                    StepDesc = w.StepDesc,
            //                    Actions = nwfa
            //                })
            //                .First();

            //        tempb.Add(nwf);
            //    }

            //    result = tempb.AsEnumerable();
            //}
            //else
            //    result = null;

            return
               result;
        }
         
         
         */
        #endregion
    }
}
