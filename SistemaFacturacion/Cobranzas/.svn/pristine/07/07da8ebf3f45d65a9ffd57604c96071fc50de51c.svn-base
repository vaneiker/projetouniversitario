using KSI.Core.Models.cardnetservice;
using KSI.Infrastructure.Repositories.cardnetservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.CardNet
{
    public class CardNetProxy
    {   
        private CardnetServiceRepository CarnedClient
        {
            get
            {
                return new Lazy<CardnetServiceRepository>().Value;
            }
        }

        public CardNetProxy() { }

        public CardnetServiceResult ApplyPayment(string CredicardNumber,
                                 string Year,
                                 string Month,
                                 string CreditVerificationValue,
                                 decimal Amount,
                                 decimal Tax,
                                 string userName,
                                 string SourceApp
                                )
        {
            
            var result = CarnedClient.SetPaymentCardnet(CredicardNumber, Year, Month, CreditVerificationValue, Amount, Tax, userName, SourceApp);
            return
                result;
        }
    }
}
