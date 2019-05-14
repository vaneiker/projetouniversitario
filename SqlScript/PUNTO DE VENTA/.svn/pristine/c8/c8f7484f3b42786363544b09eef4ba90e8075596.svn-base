using STL.POS.AchWsProxy.AchPayments;
using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace STL.POS.AchWsProxy
{
    public class AchPaymentProxy : IAchPaymentProxy
    {

        private IGPPayments soapClient;

        public AchPaymentProxy(IGPPayments client)
        {
            soapClient = client;
        }

        public bool CreateAchPaymentForAuto(QuotationAuto quotation,
            string currencyId,
            string accountHolder,
            string accountNumber,
            string accountHolderGovernmentId,
            string accountBankRoutingNumber,
            int accountType,
            out string statusMsg,
            out string parameterErr)
        {

            var principal = quotation.Drivers.FirstOrDefault(f => f.IsPrincipal);

            var pParam = new ACHPayment();
            pParam.BankAccountHolder = accountHolder;
            pParam.BankAccountHolderGovernmentID = accountHolderGovernmentId;
            pParam.BankAccountNumber = accountNumber;
            pParam.BankAccountType = accountType; // 0 for checking, 1 for savings
            pParam.BankRoutingNumber = accountBankRoutingNumber;
            pParam.CurrencyID = currencyId;
            pParam.PaymentAmount = quotation.AmountToPayEnteredByUser.GetValueOrDefault(0);
            pParam.PaymentDate = DateTime.Now;
            pParam.QuoteNumber = quotation.QuotationNumber;

            pParam.PolicyNumber = quotation.PolicyNumber;

            pParam.ReceivedBy = principal.FirstName + " " + principal.FirstSurname;
            pParam.SourcePlatform = "POSSITE-AUTO";
            pParam.SourceTransactionID = quotation.QuotationNumber;
            pParam.PaymentNotes = string.Empty;
            pParam.CheckbookID = string.Empty;

            var result = soapClient.NewACHPayment(pParam);

            if (result.Result)
            {
                statusMsg = "El pago se ha procesado correctamente.";
                parameterErr = string.Empty;
            }
            else
            {
                statusMsg = "El pago no se ha podido procesar.";
                parameterErr = JsonConvert.SerializeObject(pParam, Formatting.Indented);
            }

            return result.Result;
        }

        public bool CreateCreditCardPaymentForAuto(QuotationAuto quotation,
          string currencyId,
          string creditCardNumber,
          string creditCardProcessorNumber,
          string policyNumber,
          out string statusMsg,
          out string parameterErr)
        {

            var principal = quotation.Drivers.FirstOrDefault(f => f.IsPrincipal);

            var pParam = new CreditCardPayment();
            pParam.CreditCardIssuer = "CardNet";
            pParam.CreditCardMaskedCardNumber = creditCardNumber;
            pParam.CreditCardProcessorTransactionNumber = creditCardProcessorNumber;
            pParam.CheckbookID = string.Empty;
            pParam.CurrencyID = currencyId;
            pParam.PaymentAmount = quotation.AmountToPayEnteredByUser.GetValueOrDefault(0);
            pParam.PaymentDate = DateTime.Now;

            pParam.QuoteNumber = string.Empty;

            pParam.PolicyNumber = policyNumber;
            pParam.ReceivedBy = principal.FirstName + " " + principal.FirstSurname;
            pParam.SourcePlatform = "POSSITE-AUTO";
            pParam.SourceTransactionID = quotation.QuotationNumber;

            var result = soapClient.NewCreditCardPayment(pParam);

            if (result.Result)
            {
                statusMsg = "El pago se ha procesado correctamente.";
                parameterErr = string.Empty;
            }
            else
            {
                statusMsg = "El pago no se ha podido procesar.";
                parameterErr = JsonConvert.SerializeObject(pParam, Formatting.Indented);
            }

            return result.Result;
        }

        public bool CreateCreditCardPaymentForAuto(Entity.Entities.Quotation quotation,
          string currencyId,
          string creditCardNumber,
          string creditCardProcessorNumber,
          string policyNumber,
          out string statusMsg,
          out string parameterErr)
        {
            var pParam = new CreditCardPayment();
            pParam.CreditCardIssuer = "CardNet";
            pParam.CreditCardMaskedCardNumber = creditCardNumber;
            pParam.CreditCardProcessorTransactionNumber = creditCardProcessorNumber;
            pParam.CheckbookID = string.Empty;
            pParam.CurrencyID = currencyId;
            pParam.PaymentAmount = quotation.AmountToPayEnteredByUser.GetValueOrDefault(0);
            pParam.PaymentDate = DateTime.Now;

            pParam.QuoteNumber = string.Empty;

            pParam.PolicyNumber = policyNumber;
            pParam.ReceivedBy = quotation.PrincipalFullName;
            pParam.SourcePlatform = "POSSITE-AUTO";
            pParam.SourceTransactionID = quotation.QuotationNumber;

            var result = soapClient.NewCreditCardPayment(pParam);

            if (result.Result)
            {
                statusMsg = "El pago se ha procesado correctamente.";
                parameterErr = string.Empty;
            }
            else
            {
                statusMsg = "El pago no se ha podido procesar.";
                parameterErr = JsonConvert.SerializeObject(pParam, Formatting.Indented);
            }

            return result.Result;
        }




        public bool CreateCashPaymentForAuto(QuotationAuto quotation,
            string currencyId,
            out string statusMsg,
            out string parameterErr)
        {

            var principal = quotation.Drivers.FirstOrDefault(f => f.IsPrincipal);

            var pParam = new CashPayment();
            pParam.CurrencyID = currencyId;
            pParam.PaymentAmount = quotation.AmountToPayEnteredByUser.GetValueOrDefault(0);
            pParam.PaymentDate = DateTime.Now;
            pParam.QuoteNumber = quotation.QuotationNumber;

            pParam.PolicyNumber = quotation.PolicyNumber;

            pParam.ReceivedBy = principal.FirstName + " " + principal.FirstSurname;
            pParam.SourcePlatform = "POSSITE-AUTO";
            pParam.SourceTransactionID = quotation.QuotationNumber;
            pParam.PaymentNotes = string.Empty;
            pParam.CheckbookID = string.Empty;

            var result = soapClient.NewCashPayment(pParam);

            if (result.Result)
            {
                statusMsg = "El pago se ha procesado correctamente.";
                parameterErr = string.Empty;
            }
            else
            {
                statusMsg = "El pago no se ha podido procesar.";
                parameterErr = JsonConvert.SerializeObject(pParam, Formatting.Indented);
            }

            return result.Result;
        }
    }
}
