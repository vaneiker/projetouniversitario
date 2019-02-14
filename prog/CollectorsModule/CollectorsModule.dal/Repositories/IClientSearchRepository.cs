using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Repositories
{
    public interface IClientSearchRepository : IDisposable
    {
        IEnumerable<Client> GetClients();
        IEnumerable<Client> GetClientsByBussinessLineId(int Bussiness_Line_Id);
        IQueryable<vwClient> ClientsContext();
        IQueryable<VW_COLLECTORS_POLICIES_BY_CONTACTID> getPoliciesByContactID(int contactID);
        PolicyID GetPolicyIdByPolicyNumber(string policy_no);
        ///GP Methods
        IQueryable<ST_CLIENT_POLICY_INFO> GetClientsGP();
        IQueryable<ST_CLIENT_POLICY_INFO> getPoliciesByClientIDGP(string Client_ID, string policy_number);
        string getClientIdByPolicyNumber(string policy_number);
        void Refresh();
        IEnumerable<BanksType> getListBankType();
        IEnumerable<BanksType.Checkbook> getListBankCheckbookType();
        IEnumerable<BanksType.Checkbook> getListBankCheckbookTypeNames();
    }
}
