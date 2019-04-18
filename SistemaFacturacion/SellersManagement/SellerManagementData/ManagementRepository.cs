using SellersManagement.Data;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerManagementData
{
    public class ManagementRepository : BaseRepository
    {
        public ManagementRepository() { }

        public IEnumerable<Generic> SetManagement(ManagementData.parameters parameters)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_SET_MANAGEMENT_Result> temp;

            temp = SellersManagementContex.SP_SET_MANAGEMENT(parameters.managementId,
                parameters.managementSupervisorCode,
                parameters.managementSellerCode,
                parameters.managementTypeId,
                parameters.managementResultsId,
                parameters.comment,
                parameters.suggestedImprovement,
                parameters.createUserId,
                parameters.ManagedBy,
                parameters.ShowToSupervisor);

            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Action
            }).ToArray();

            return
                 result;
        }


        public IEnumerable<ManagementData> GetManagement(ManagementData.parameters parameters)
        {
            IEnumerable<ManagementData> result;
            IEnumerable<SP_GET_MANAGEMENT_Result> temp;

            temp = SellersManagementContex.SP_GET_MANAGEMENT(parameters.managementId,
                parameters.managementSupervisorCode,
                parameters.managementSellerCode);

            result = temp.Select(d => new ManagementData
            {
                Comment = d.Comment,
                ManagementDate = d.Management_Date,
                ManagementId = d.Management_Id,
                ManagementResultsIdSelected = d.ManagementResultsIdSelected,
                ManagementSellerCode = d.Management_Seller_Code,
                ManagementSupervisorCode = d.Management_Supervisor_Code,
                ManagementTypeIdSelected = d.ManagementTypeIdSelected,
                SuggestedImprovement = d.Suggested_Improvement,
                ShowToSupervisor = d.ShowToSupervisor
            }).ToArray();

            return
                 result;
        }

        public IEnumerable<AgentData> GetDataAgent(AgentData.parameters parameters)
        {
            IEnumerable<AgentData> result;
            IEnumerable<SP_GET_AGENT_INFORMATION_Result> temp;

            temp = SellersManagementContex.SP_GET_AGENT_INFORMATION(parameters.AgentId,
                parameters.AgentCode,
                parameters.BL,
                parameters.NameId,
                parameters.isExecutiveRol);

            result = temp.Select(d => new AgentData
            {
                AgentId = d.Agent_Id,
                AgentCode = d.Agent_Code,
                NameId = d.Name_Id,
                SourceID = d.Source_ID,
                FullName = d.Full_Name,
                Office = d.Office,
                Channel = d.Channel,
                BlId = d.Bl_Id,
                BlDesc = d.Bl_Desc,
                Phones = d.Phones,
                SupervisorName = d.Supervisor_Name,
                SupervisorAgentCode = d.Supervisor_AgentCode,
                
            }).ToArray();

            return
                 result;
        }


        public IEnumerable<AgentData> GetDataAgentAndManagements(AgentData.parameters parameters)
        {
            IEnumerable<AgentData> result;
            IEnumerable<SP_GET_AGENT_AND_MANAGEMENT_INFORMATION_Result> temp;

            temp = SellersManagementContex.SP_GET_AGENT_AND_MANAGEMENT_INFORMATION(parameters.AgentId,
                parameters.AgentCode,
                parameters.BL,
                parameters.NameId,
                parameters.isExecutiveRol);

            result = temp.Select(d => new AgentData
            {
                AgentId = d.Agent_Id.GetValueOrDefault(),
                AgentCode = d.Agent_Code,
                NameId = d.Name_Id,
                SourceID = d.Source_ID,
                FullName = d.Full_Name,
                Office = d.Office,
                Channel = d.Channel,
                BlId = d.Bl_Id.GetValueOrDefault(),
                BlDesc = d.Bl_Desc,
                Phones = d.Phones,
                SupervisorName = d.Supervisor_Name,
                SupervisorAgentCode = d.Supervisor_AgentCode,
                Comment = d.Comment,
                ManagementResultsIdSelected = d.ManagementResultsIdSelected,
                ManagementTypeIdSelected = d.ManagementTypeIdSelected,
                isProspect = d.isProspect,
                Management_Date = d.Management_Date,
                Management_Id = d.Management_Id,
                Management_Seller_Code = d.Management_Seller_Code,
                Management_Supervisor_Code = d.Management_Supervisor_Code,
                ShowToSupervisor = d.ShowToSupervisor,
                Suggested_Improvement = d.Suggested_Improvement
            }).ToArray();

            return
                 result;
        }

        public IEnumerable<ProspectData> GetDataProspect(ProspectData.parameters parameters)
        {
            IEnumerable<ProspectData> result;
            IEnumerable<SP_GET_PROSPECT_INFROMATION_Result> temp;

            temp = SellersManagementContex.SP_GET_PROSPECT_INFROMATION(parameters.ProspectCode);

            result = temp.Select(d => new ProspectData
            {
                ProspectChannel = d.ProspectChannel,
                ProspectCode = d.ProspectCode,
                ProspectFullName = d.ProspectFullName,
                ProspectOffices = d.ProspectOffices,
                ProspectPhones = d.ProspectPhones

            }).ToArray();

            return
                 result;
        }

        public IEnumerable<Generic> SetDataProspect(ProspectData.parameters parameters)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_SET_PROSPECT_Result> temp;

            temp = SellersManagementContex.SP_SET_PROSPECT(
                parameters.Id,
                parameters.ProspectCode,
                parameters.ProspectFullName,
                parameters.ProspectChannel,
                parameters.ProspectOffices,
                parameters.ProspectPhones,
                parameters.CreateUserId
                );

            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Action
            }).ToArray();

            return
                 result;
        }
        public IEnumerable<Generic> GetStatisticHeader()
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_STATISTIC_TABLE_HEADER_Result> temp;

            temp = SellersManagementContex.SP_GET_STATISTIC_TABLE_HEADER();

            result = temp.Select(d => new Generic
            {
                value = d.StatisticYear.ToString(),
                name = d.MonthName
            }).ToArray();

            return
                 result;
        }
        public IEnumerable<AgentStatisticData> GetAgentStatisticData(Nullable<int> AgentCode, string nameId = "")
        {
            IEnumerable<AgentStatisticData> result;
            IEnumerable<SP_GET_AGENT_STATISTIC_Result> temp;

            temp = SellersManagementContex.SP_GET_AGENT_STATISTIC(AgentCode, nameId);

            result = temp.Select(d => new AgentStatisticData
            {
                Type = d.Tipo,
                Sum1 = d.sum1,
                Sum2 = d.sum2,
                Sum3 = d.sum3,
                Sum4  = d.sum4,
                Sum5 = d.sum5,
                Sum6 = d.sum6,
                Sum7 = d.sum7,
                Sum8 = d.sum8,
                Sum9 = d.sum9,
                Sum10 = d.sum10,
                Sum11 = d.sum11,
                Sum12 = d.sum12,
                Sum13 = d.sum13
            }).ToArray();

            return
                 result;
        }

    }
}
