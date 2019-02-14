using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Repositories;
using CollectorsModule.dal.Base;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CollectorsModule.dal.AtlanDB;

namespace CollectorsModule.dal.Implementations
{
    public class ClientSearchRepository : GlobalRepository, IClientSearchRepository
    {
        public ClientSearchRepository(GlobalEntities globalEntities)
            : base(globalEntities)
        {

        }

        public ClientSearchRepository(ATLANEntities atlanEntities)
            : base(null)
        {
            initAtlanRepository(atlanEntities);
        }

        public IEnumerable<Client> GetClients()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Client> GetClientsByBussinessLineId(int Bussiness_Line_Id)
        {
            var results = new List<Client>();
            try
            {
                return results;
            }
            catch (Exception ex)
            {
                return results;
            }
        }

        public IQueryable<VW_COLLECTORS_POLICIES_BY_CONTACTID> getPoliciesByContactID(int contactID)
        {
            var policies = globalModel.VW_COLLECTORS_POLICIES_BY_CONTACTID.Where(c => c.Contact_Id == contactID).AsQueryable();
            return policies;
        }

        public IQueryable<vwClient> ClientsContext()
        {
            var clients = globalModel.vwClients.OrderBy(c => c.RowKey).AsQueryable();
            return clients;
        }

        public PolicyID GetPolicyIdByPolicyNumber(string policy_no)
        {
            var policyid = globalModel.VW_COLLECTORS_POLICIES_BY_CONTACTID.Where(p => p.Policy_No == policy_no)
                                                                          .Select(r => new PolicyID
                                                                          {
                                                                              Case_Seq_No = r.Case_Seq_No,
                                                                              City_Id = r.City_Id,
                                                                              Corp_Id = r.Corp_Id,
                                                                              Country_Id = r.Country_Id,
                                                                              Domesticreg_Id = r.Domesticreg_Id,
                                                                              Hist_Seq_No = r.Hist_Seq_No,
                                                                              Office_Id = r.Office_Id,
                                                                              Region_Id = r.Region_Id,
                                                                              State_Prov_Id = r.State_Prov_Id
                                                                          })
                                                                          .FirstOrDefault();
            return policyid;
        }

        ///Calling GP methods
        public IQueryable<ST_CLIENT_POLICY_INFO> GetClientsGP()
        {
            var results = atlanModel.ST_CLIENT_POLICY_INFO.AsQueryable();
            return results;
        }

        public IQueryable<ST_CLIENT_POLICY_INFO> getPoliciesByClientIDGP(string Client_ID, string policy_number)
        {
            var results = (string.IsNullOrEmpty((Client_ID ?? string.Empty).Trim()) ? atlanModel.ST_CLIENT_POLICY_INFO.Where(i => i.POLICY_NUMBER == policy_number) : atlanModel.ST_CLIENT_POLICY_INFO.Where(i => i.CLIENT_ID == Client_ID)).AsQueryable();
            return results;
        }

        public string getClientIdByPolicyNumber(string policy_number)
        {
            var results = atlanModel.ST_CLIENT_POLICY_INFO.Where(p => p.POLICY_NUMBER == policy_number).FirstOrDefault().CLIENT_ID;
            return results;
        }

        public void Refresh()
        {
            try
            {
                initAtlanRepository(new ATLANEntities());
            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<BanksType> getListBankType()
        {
            var banklist = atlanModel.VW_GET_BANKS_INFORMATION.Select(a => new BanksType
            {
                BANKID = a.BANKID,
                BANKNAME = a.BANKNAME,
                DEX_ROW_ID = a.DEX_ROW_ID
            }).ToArray();
            return banklist;
        }

        public IEnumerable<BanksType.Checkbook> getListBankCheckbookType()
        {
            var banklist = atlanModel.ST_CHECKBOOKS.Where(s => s.Checkbook_Status == 1).Select(a => new BanksType.Checkbook
            {
                Bank_Account = a.Bank_Account,
                Bank_Name_Desc = a.Bank_Name_Desc,
                Checkbook_Id = a.Checkbook_Id,
                Checkbook_Name = a.Checkbook_Name,
                Checkbook_Status = a.Checkbook_Status,
                Create_Date = a.Create_Date,
                Currency_ISO = a.Currency_ISO,
                CHECKBOOK_INFO = a.Checkbook_Name + " (" + a.Currency_ISO + "$)"
            }).ToArray();
            return banklist;
        }

        public IEnumerable<BanksType.Checkbook> getListBankCheckbookTypeNames()
        {
            var banklist = atlanModel.ST_CHECKBOOKS.Where(s => s.Checkbook_Status == 1).Select(a => new BanksType.Checkbook
            {
                Bank_Name_Desc = a.Bank_Name_Desc
            }).Distinct().ToArray();
            return banklist;
        }
    }
}
