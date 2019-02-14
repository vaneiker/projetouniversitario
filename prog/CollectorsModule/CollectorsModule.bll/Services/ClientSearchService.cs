using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Implementations;
using CollectorsModule.dal.Repositories;
using CollectorsModule.dal.Singleton;
using CollectorsModule.dal.UnitOfWork;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.bll
{
    public class ClientSearchService
    {
        public IEnumerable<Client> getClients()
        {
            var results = Singleton.Instance.UnitOfWork.ClientSearchRepository.GetClients();
            return results;
        }

        public IQueryable<vwClient> ClientsContext()
        {
            var clients = Singleton.Instance.UnitOfWork.ClientSearchRepository.ClientsContext();
            return clients;
        }

        public string getPoliciesByContactIDGrouped(int contactID)
        {
            var grpPolicies = Singleton.Instance.UnitOfWork.ClientSearchRepository.getPoliciesByContactID(contactID).Select(c => c.Policy_No).ToArray();
            string grp = grpPolicies.Aggregate((current, next) => current + ", " + next).ToString();
            return grp;
        }

        public IQueryable<VW_COLLECTORS_POLICIES_BY_CONTACTID> getPoliciesByContactID(int contactID)
        {
            var policies = Singleton.Instance.UnitOfWork.ClientSearchRepository.getPoliciesByContactID(contactID);
            return policies;
        }

        public PolicyID GetPolicyIdByPolicyNumber(string policy_no)
        {
            var policyid = Singleton.Instance.UnitOfWork.ClientSearchRepository.GetPolicyIdByPolicyNumber(policy_no);
            return policyid;
        }

        ///GP Data
        public IQueryable<ST_CLIENT_POLICY_INFO> ClientsContextGP()
        {
            var clients = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.GetClientsGP();
            return clients;
        }

        public IQueryable<ST_CLIENT_POLICY_INFO> getPoliciesByClientIDGP(string Client_ID, string policy_number)
        {
            try
            {
                Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.Refresh();
                var results = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.getPoliciesByClientIDGP(Client_ID, policy_number);
                return results;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public string getClientIdByPolicyNumber(string policy_number)
        {
            var results = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.getClientIdByPolicyNumber(policy_number);
            return results;
        }

        public IEnumerable<BanksType> getListBankType()
        {
            var listBankType = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.getListBankType();
            return listBankType;
        }
        public IEnumerable<BanksType.Checkbook> getListBankCheckbookType()
        {
            var listBankType = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.getListBankCheckbookType();
            return listBankType;
        }
        public IEnumerable<BanksType.Checkbook> getListBankCheckbookTypeNames()
        {
            var listBankType = Singleton.Instance.UnitOfWorkGP.ClientSearchRepositoryGP.getListBankCheckbookTypeNames();
            return listBankType;
        }
    }
}
