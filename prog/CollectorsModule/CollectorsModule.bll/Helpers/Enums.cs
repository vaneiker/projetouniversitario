using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Collectors.Helpers
{
    public class Enums
    {
        public enum Procedure_name
        {
            #region PM_PROVIDER

            [Description("Payments.SP_GET_PM_PROVIDER_PARAMETER")]
            SP_GET_PM_PROVIDER_PARAMETER,

            [Description("Payments.SP_GET_PM_PROVIDER_TRANSACTION_BY_ORDERID")]
            SP_GET_PM_PROVIDER_TRANSACTION_BY_ORDERID,

            [Description("Payments.SP_INSERT_PM_PROVIDER_LOG")]
            SP_INSERT_PM_PROVIDER_LOG,

            [Description("Payments.SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY")]
            SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY,

            [Description("Payments.SP_SET_PM_PROVIDER_TRANSACTION")]
            SP_SET_PM_PROVIDER_TRANSACTION,

            [Description("ClientSite.SP_GET_CardType")]
            SP_GET_CardType,

            #endregion

            #region PM_PAYMENTS

            [Description("Payments.SP_SET_PM_PAYMENTS")]
            SP_SET_PM_PAYMENTS, 

            [Description("Payments.SP_SET_PM_PAYMENTS_DETAILS_ALL")]
            SP_SET_PM_PAYMENTS_DETAILS_ALL, 

            [Description("GLOBAL.SP_GET_BANK_ACCOUNT_TYPE")]
            SP_GET_BANK_ACCOUNT_TYPE, 

            #endregion

            #region POLICY
            
            [Description("Policy.SP_GET_ContactByPolicy")]
            SP_GET_ContactByPolicy,

            [Description("reportes.SP_GET_POLICY_KEY")]
            SP_GET_POLICY_KEY,  

            #endregion

        }

        public enum Project_Id
        {
            STGPaymentProcess = 8,
            STGPaymentModuleCash = 9,
        }

        public enum Corp_Id
        {
            STG = 1
        }

        public enum Log_Type_Id 
        {
            Request = 1,
            Response = 2,
            Exception = 3
        }

        public enum Company_Id
        {
            STL = 1,
            ATL = 2,
        }

        public enum PaymentForm
        {
            [Description("Efectivo")]
            CASH = 0,
            [Description("Cheque")]
            CHECK = 1,
            [Description("Tarjeta de Crédito")]
            CREDITCARD =2,
            [Description("ACH")]
            ACH = 3,
            [Description("STB")]
            STB = 4
            
        }

        public enum SystemData
        { 
            GP = 1,
            Global = 2
        }

        public enum Currency
        {
            USD = 1, 
            EUR = 2,
            DOP = 3
        }
    }
}