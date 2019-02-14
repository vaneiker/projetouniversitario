using Collectors.Helpers;
using CollectorsModule.dal.Singleton;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.bll.Services
{
    public class UtilitiesServices
    {
        public string getTranslatedTextByLiteralDesc(string description, int LangID)
        {
            var results = Singleton.Instance.UnitOfWork.UtilitiesRepository.getTranslatedTextByLiteralDesc(description, LangID);
            return results;
        }
        public List<Users> getSecurityUsersForPaymentsFilter(int UserID)
        {
            var results = Singleton.Instance.UnitOfWork.UtilitiesRepository.getSecurityUsersForPaymentsFilter(UserID);
            return results;
        }

        public List<Office> getAllOfficesGP()
        {
            var results = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getAllOfficesGP();
            return results;
        }

        public List<Modules> getModulesForPaymentsFilter()
        {
            var results = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getModulesForPaymentsFilter();
            return results;
        }

        public List<BussinessLine> getBusinessLinesForPaymentsFilter()
        {
            var results = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getBusinessLinesForPaymentsFilter();
            return results;
        }

        public Dictionary<int, string> getCurrencyForPaymentsFilter()
        {
            var results = EnumHelper.ToDictionary(Collectors.Helpers.Enums.Currency.DOP);
            return results;
        }
        public bool setKTagByPayment(string gp_payment_number, string ktBarcode, string additionalInfo, string batch)
        {
            var results = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.setKTagByPayment(gp_payment_number, ktBarcode, additionalInfo, batch);
            return results;
        }
        public bool isAdminUser(string userName)
        {
            var result = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.isAdminUser(userName);
            return result;
        }
        public void ErrorLogDB(string parameters, string error_Logged)
        {
            try
            {
                Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.ErrorLogDB(parameters, error_Logged);
            }
            catch (Exception ex)
            {
            }
        }
        public string getCheckBookID(string userName)
        {
            var result = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getCheckBookID(userName);
            return result;
        }
        public string getKTUserName(string userName)
        {
            var result = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getKTUserName(userName);
            return result;
        }

        public Users getUserInfoByID(string userName)
        {
            var result = Singleton.Instance.UnitOfWorkGP.UtilitiesRepositoryGP.getUserInfoByID(userName);
            return result;
        }

        public Users getSecurityUserInfo(string userLogin)
        {
            var result = Singleton.Instance.UnitOfWork.UtilitiesRepository.getSecurityUserInfo(userLogin);
            return result;
        }
    }
}
