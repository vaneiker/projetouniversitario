using STL.POS.AgentWSProxy.AgentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.AgentWSProxy
{
    public interface IAgentProxy
    {
        List<Agent.AgentTree> GetAgent(int? id, string principal, string principalType);

        List<Agent.AgentTreeInfo> GetAgentTreeNewInfoCall(int? CorpId, int? AgentId, string NameId, int BlId);

        List<AgentTreeInfoNew> GetAgentTreeNewInfoCallNew(int? CorpId, int? AgentId, string NameId, int BlId);
    }
}
