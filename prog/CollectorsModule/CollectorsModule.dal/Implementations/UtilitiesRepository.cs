using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.Base;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Repositories;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectorsModule.dal.Extensions;

namespace CollectorsModule.dal.Implementations
{
    public class UtilitiesRepository : GlobalRepository, IUtilitiesRepository
    {
        public UtilitiesRepository(GlobalEntities globalEntities)
            : base(globalEntities)
        {

        }

        public UtilitiesRepository(ATLANEntities atlanEntities)
            : base(null)
        {
            initAtlanRepository(atlanEntities);
        }

        public string getTranslatedTextByLiteralDesc(string description, int LangID)
        {
            var results = globalModel.VW_GET_TRANSLATE.Where(l => l.Destiny_Language_Id == LangID && l.Literal_Desc == description)
                                                      .Select(t => t.Translated_Literal)
                                                      .FirstOrDefault();
            return results;
        }

        public List<Users> getSecurityUsersForPaymentsFilter(int UserID)
        {
            if (UserID != 0)
                return globalModel.VWSecurityUsers.Where(r => r.StatusID == true && r.UserID == UserID && string.IsNullOrEmpty(r.UserLogin) == false)
                                                  .Distinct()
                                                  .AsEnumerable()
                                                  .Select(r => new Users
                                                  {
                                                      FirstName = r.FirstName,
                                                      FullName = r.FullName,
                                                      LastName = r.LastName,
                                                      UserID = r.UserID,
                                                      UserLogin = r.UserLogin.Trim().ToUpper(),
                                                      FullNameLogin = string.Format("{0} - ({1})", r.UserLogin.Trim().ToUpper(), r.FullName)
                                                  })
                                                  .OrderBy(x => x.UserLogin)
                                                  .ToList();
            else
                return globalModel.VWSecurityUsers.Where(r => r.StatusID == true && string.IsNullOrEmpty(r.UserLogin) == false)
                                                  .Distinct()
                                                  .AsEnumerable()
                                                  .Select(r => new Users
                                                  {
                                                      FirstName = r.FirstName,
                                                      FullName = r.FullName,
                                                      LastName = r.LastName,
                                                      UserID = r.UserID,
                                                      UserLogin = r.UserLogin.Trim().ToUpper(),
                                                      FullNameLogin = string.Format("{0} - ({1})", r.UserLogin.Trim().ToUpper(), r.FullName)
                                                  })
                                                  .Distinct()
                                                  .OrderBy(x => x.UserLogin)
                                                  .ToList();
        }

        public Users getSecurityUserInfo(string userLogin)
        {
            return globalModel.VWSecurityUsers.Where(r => r.StatusID == true && r.UserLogin.ToLower().Trim() == userLogin.ToLower().Trim())
                                              .Select(r => new Users
                                              {
                                                  FirstName = r.FirstName,
                                                  FullName = r.FullName,
                                                  LastName = r.LastName,
                                                  UserID = r.UserID,
                                                  UserLogin = r.UserLogin.Trim().ToUpper()
                                              })
                                              .FirstOrDefault();
        }

        public List<Office> getAllOfficesGP()
        {
            var results = atlanModel.ST_OFFICE_CODES.Where(s => s.Office_Status == 1)
                                                    .Select(r => new Office
                                                    {
                                                        Office_Code = r.Office_Code,
                                                        Office_NameKey = r.Office_NameKey
                                                    })
                                                    .OrderBy(x => x.Office_NameKey)
                                                    .ToList();
            return results;
        }

        public List<Modules> getModulesForPaymentsFilter()
        {
            var results = atlanModel.VW_ST_PMT_HISTORY.Select(x => new Modules { Module_Description = x.SOURCE_SYSTEM }).ToList();
            results = results.AsEnumerable().DistinctBy(x => x.Module_Description).OrderBy(x => x.Module_Description).ToList();
            return results;
        }

        public List<BussinessLine> getBusinessLinesForPaymentsFilter()
        {

            var results = atlanModel.ST_BUSINESS_LINE.Where(s => s.BusinessLine_Status == 1)
                                                     .Select(r => new BussinessLine
                                                     {
                                                         Bl_Code = r.BusinessLine_Code,
                                                         Bl_Desc = r.BusinessLine_NameKey
                                                     })
                                                     .OrderBy(x => x.Bl_Code)
                                                     .ToList();
            return results;
        }

        public bool setKTagByPayment(string gp_payment_number, string ktBarcode, string additionalInfo, string batch)
        {
            var results = atlanModel.USP_SET_KTAG_BY_PAYMENT(gp_payment_number, ktBarcode, additionalInfo, batch);
            return true;
        }

        public bool isAdminUser(string userName)
        {
            var results = atlanModel.ST_USERS.Where(u => u.USERCODE == userName);
            if (results.Count() > 0)
            {
                return results.FirstOrDefault().LEVEL == 1;
            }
            return false;
        }

        public string getCheckBookID(string userName)
        {
            var results = atlanModel.ST_USERS.Where(u => u.USERCODE == userName);
            if (results.Count() > 0)
            {
                return results.FirstOrDefault().CHECKBOOKID ?? string.Empty;
            }
            return string.Empty;
        }

        public string getKTUserName(string userName)
        {
            var results = atlanModel.ST_USERS.Where(u => u.USERCODE == userName);
            if (results.Count() > 0)
            {
                return results.FirstOrDefault().KT_USER ?? string.Empty;
            }
            return string.Empty;
        }

        public void ErrorLogDB(string parameters, string error_Logged)
        {
            atlanModel.USP_SET_COLLECTORS_ERRORS_LOG(parameters, error_Logged);
        }

        public Users getUserInfoByID(string userName)
        {
            var results = atlanModel.ST_USERS.Where(u => u.USERCODE == userName).ToList();
            if (results.Any())
            {
                return results.Select(u => new Users
                {
                    OfficeName = u.OFFICE,
                    BankName = u.BANKNAME,
                    CheckBookID = u.CHECKBOOKID
                }).FirstOrDefault();
            }
            return null;
        }
    }
}
