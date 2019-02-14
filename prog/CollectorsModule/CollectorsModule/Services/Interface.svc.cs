using CollectorsModule.bll;
using CollectorsModule.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CollectorsModule.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Interface" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Interface.svc or Interface.svc.cs at the Solution Explorer and start debugging.
    public class Interface : IInterface
    {
        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        public string BanksInfo(string bankName)
        {
            
            var info = CSS.Value.getListBankCheckbookType().Where(b => b.Bank_Name_Desc == bankName.Unescape()).ToArray();
            return JsonConvert.SerializeObject(info.ToArray());
        }

        public string DepositAccountInfo(string checkbookName)
        {

            var info = CSS.Value.getListBankCheckbookType().Where(b => b.Checkbook_Name == checkbookName).ToArray();
            return JsonConvert.SerializeObject(info.ToArray());
        }
    }
}
