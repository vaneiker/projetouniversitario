using SellerManagementData;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Logic
{
    public class ManagementManager : BaseManager
    {
        private readonly ManagementRepository managementRepository;

        public ManagementManager()
        {
            managementRepository = new ManagementRepository();
        }

        public IEnumerable<Generic> SetManagement(ManagementData.parameters parameters)
        {
            return
                managementRepository.SetManagement(parameters);
        }

        public IEnumerable<ManagementData> GetManagement(ManagementData.parameters parameters)
        {
            return
                managementRepository.GetManagement(parameters);
        }

        public IEnumerable<AgentData> GetDataAgent(AgentData.parameters parameters)
        {
            return
                managementRepository.GetDataAgent(parameters);
        }

        public IEnumerable<ProspectData> GetDataProspect(ProspectData.parameters parameters)
        {
            return
                managementRepository.GetDataProspect(parameters);
        }


        public IEnumerable<Generic> SetDataProspect(ProspectData.parameters parameters)
        {
            return
                managementRepository.SetDataProspect(parameters);
        }

        public IEnumerable<Generic> GetStatisticHeader()
        {
            return
                managementRepository.GetStatisticHeader();
        }

        public IEnumerable<AgentStatisticData> GetAgentStatisticData(Nullable<int> AgentCode, string nameId = "")
        {
            return
                managementRepository.GetAgentStatisticData(AgentCode, nameId);
        }

        public IEnumerable<AgentData> GetDataAgentAndManagement(AgentData.parameters parameters)
        {
            return
                managementRepository.GetDataAgentAndManagements(parameters);
        }
    }
}
