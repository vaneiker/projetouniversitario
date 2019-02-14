using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Repositories
{
    public interface IUtilitiesRepository : IDisposable
    {
        string getTranslatedTextByLiteralDesc(string description, int LangID);
        List<Users> getSecurityUsersForPaymentsFilter(int UserID);
        List<Office> getAllOfficesGP();
        List<Modules> getModulesForPaymentsFilter();
        List<BussinessLine> getBusinessLinesForPaymentsFilter();
        bool setKTagByPayment(string gp_payment_number, string ktBarcode, string additionalInfo, string batch);
        bool isAdminUser(string userName);
        void ErrorLogDB(string parameters, string error_logged);
        string getCheckBookID(string userName);
        string getKTUserName(string userName);
        Users getUserInfoByID(string userName);
        Users getSecurityUserInfo(string userLogin);
    }
}
