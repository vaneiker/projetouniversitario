﻿using STL.POS.AgentWSProxy.AgentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.AgentWSProxy
{
    public class AgentProxy : IAgentProxy
    {
        private AgentServiceClient agentClient;

        public AgentProxy()
        {
            agentClient = new AgentServiceClient();
        }

        public List<Agent.AgentTree> GetAgent(int? id, string principal, string principalType)
        {
            var response = agentClient.GetAgentTree(id, principal, principalType, 1);

            return response.Where(a => !string.IsNullOrWhiteSpace(a.nameid)).ToList();
        }


        public List<Agent.AgentTreeInfo> GetAgentTreeNewInfoCall(int? CorpId, int? AgentId, string NameId, int BlId)
        {
            var response = agentClient.GetAgentTreeNewInfo(CorpId, AgentId, NameId, BlId);

            return response.Where(a => !string.IsNullOrWhiteSpace(a.FullNameAll)).ToList();
        }

        public List<AgentTreeInfoNew> GetAgentTreeNewInfoCallNew(int? CorpId, int? AgentId, string NameId, int BlId)
        {
            var response = agentClient.GetAgentTreeNewInfo(CorpId, AgentId, NameId, BlId);
            List<AgentTreeInfoNew> result = new List<AgentTreeInfoNew>();

            foreach (var r in response)
            {
                result.Add(new AgentTreeInfoNew()
                {
                    AgentCode = r.AgentCode,
                    CorpId = r.CorpId,
                    FullName = r.FullName,
                    FullNameAll = r.FullNameAll,
                    NameId = r.NameId
                });
            }

            return result;
        }

        //public Agent.AssignedOffice[] TEST()
        //{
        //    Agent.AssignedOfficeKeyNew param = new Agent.AssignedOfficeKeyNew();
        //    param.CorpId = 1;
        //    param.AgentId = 34364;
        //    return agentClient.GetAgentAssignedOfficeNew(param);
        //}
    }
}