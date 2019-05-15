using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.AchWsProxy
{
    public interface IAchPaymentProxy
    {

        bool CreateAchPaymentForAuto(QuotationAuto quotation,
            string currencyId,
            string accountHolder,
            string accountNumber,
            string accountHolderGovernmentId,
            string accountBankRoutingNumber,
            int accountType,
            out string statusMsg,
            out string parameterErr);

        bool CreateCreditCardPaymentForAuto(QuotationAuto quotation,
          string currencyId,
          string creditCardNumber,
          string creditCardProcessorNumber,
          string policyNumber,
          out string statusMsg,
          out string parameterErr);


        bool CreateCashPaymentForAuto(QuotationAuto quotation,
           string currencyId,
           out string statusMsg,
           out string parameterErr);

    }
}
