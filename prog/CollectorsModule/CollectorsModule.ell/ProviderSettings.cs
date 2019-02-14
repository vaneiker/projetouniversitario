using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class ProviderSettings
    {
        public int ProviderId { get; set; }
        public int TransactionTypeCatalogId { get; set; }
        public int TransactionTypeId { get; set; }
        public int ParametersId { get; set; }
        public String Acquiring_Institution_Code { get; set; }
        public String Merchant_Type { get; set; }
        public String Merchant_Number { get; set; }
        public String Merchant_Terminal { get; set; }
        public String Merchant_Number_Amex { get; set; }
        public String Merchant_Terminal_Amex { get; set; }
        public String Url { get; set; }
        public String Currency_Code { get; set; }
        public String MerchantName { get; set; }
        public String TransactionType { get; set; }
    }
}
