using System;
using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class ConfirmationCallRepository : GlobalRepository
    {
        public ConfirmationCallRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended) : base(globalModel, globalModelExtended) { }

        public virtual IEnumerable<ConfirmationCall.Pending> GetAll(int corpId, int companyId, int userId, string statusCall, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            IEnumerable<ConfirmationCall.Pending> result;
            IEnumerable<SP_GET_CONFIRMATION_CALL_Result> temp;

            temp = globalModel.SP_GET_CONFIRMATION_CALL(corpId, companyId, userId, statusCall, policyNo, initialDateFrom, initialDateTo);

            result = temp
                .Select(p => new ConfirmationCall.Pending
                {
                    CorpId = p.Corp_Id.ConvertToNoNullable(),
                    RegionId = p.Region_Id.ConvertToNoNullable(),
                    CountryId = p.Country_Id.ConvertToNoNullable(),
                    DomesticregId = p.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = p.State_Prov_Id.ConvertToNoNullable(),
                    CityId = p.City_Id.ConvertToNoNullable(),
                    OfficeId = p.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = p.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = p.Hist_Seq_No.ConvertToNoNullable(),
                    StepTypeId = p.Step_Type_Id.ConvertToNoNullable(),
                    StepId = p.Step_Id.ConvertToNoNullable(),
                    StepCaseNo = p.Step_Case_No.ConvertToNoNullable(),
                    CaseStatus = p.CaseStatus,
                    PolicyNo = p.PolicyNo,
                    PlanName = p.PlanName,
                    PlanType = p.PlanType,
                    OwnerName = p.OwnerName,
                    InsuredName = p.InsuredName,
                    AddInsuredName = p.AddInsuredName,
                    OfficeDesc = p.Office,
                    InitialDate = p.InitialDate,
                    WorkedBy = p.WorkedBy,
                    Observations = p.Observations,
                    WorkedOn = p.WorkedOn,
                    Agent = p.AgentName,
                    NumberOfCalls = p.NumberOfCalls,
                    Days = p.Days,
                    InsuredContactId = p.InsuredContactId,
                    AddContactId = p.AddContactId,
                    OwnerContactId = p.OwnerContactId
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<ConfirmationCall.Count> GetAllCount(int corpId, int companyId, int userId, string policyNo, DateTime? initialDateFrom, DateTime? initialDateTo)
        {
            IEnumerable<ConfirmationCall.Count> result;
            IEnumerable<SP_GET_CONFIRMATION_CALL_TAB_COUNT_Result> temp;

            temp = globalModel.SP_GET_CONFIRMATION_CALL_TAB_COUNT(corpId, companyId, userId, policyNo, initialDateFrom, initialDateTo);

            result = temp
                .Select(p => new ConfirmationCall.Count
                {
                    Order = p.Order,
                    TabName = p.TabName,
                    RowCount = p.Count
                })
                .ToArray();

            return
                result;
        }

        public virtual int InsertContactAction(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
               , int officeId, int caseSeqNo, int histSeqNo, int contactId, int contactRoleTypeId
               , int actionId, int actionSeqNo, int stepTypeId, int stepId, int stepCaseNo, int userId)
        {
            int result;
            IEnumerable<SP_INSERT_PL_PCY_CONTACT_ACTIONS_Result> temp;

            result = -1;

            temp = globalModel.SP_INSERT_PL_PCY_CONTACT_ACTIONS(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo
                , contactId, contactRoleTypeId, actionId, actionSeqNo, stepTypeId, stepId, stepCaseNo, userId);

            return
                result;
        }
    }
}
