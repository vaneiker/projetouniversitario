using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Areas.CardNet.Models
{
    public abstract class RequestModel
    {

        private string CreateMD5(string input)
        {

            // Use input string to calculate MD5 hash
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected string transactionType;

        public string TransactionType { get { return transactionType; } }
        public string CurrencyCode { get; set; }
        public string AcquiringInstitutionCode { get; set; }
        public string MerchantType { get; set; }
        public string MerchantNumber { get; set; }
        public string MerchantNumber_amex { get; set; }
        public string MerchantTerminal { get; set; }
        public string MerchantTerminal_amex { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
        public string PageLanguaje { get; set; }
        public string OrdenId { get; set; }
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string Tax { get; set; }
        public string MerchantName { get; set; }

        public string Ipclient { get; set; }

        public string KeyEncriptionKey
        {
            get
            {
                //MerchantType
                //MerchantNumber
                //MerchantTerminal
                //TransactionId
                //Amount
                //Tax
                if (!string.IsNullOrEmpty(this.MerchantType)
                    && !string.IsNullOrEmpty(this.MerchantNumber)
                    && !string.IsNullOrEmpty(this.MerchantTerminal)
                    && !string.IsNullOrEmpty(this.TransactionId)
                    && !string.IsNullOrEmpty(this.Amount)
                    && !string.IsNullOrEmpty(this.Tax))
                {
                    var str = this.MerchantType
                        + this.MerchantNumber
                        + this.MerchantTerminal
                        + this.TransactionId
                        + this.Amount
                        + this.Tax;

                    var output = CreateMD5(str.ToLower());
                    return output.ToLower();
                }
                else
                    throw new InvalidOperationException("El modelo no tiene todos los parámetros necesarios cargados para generar el KeyTransactionKey.");

            }
        }

        public string CardnetUrl { get; set; }

    }
}