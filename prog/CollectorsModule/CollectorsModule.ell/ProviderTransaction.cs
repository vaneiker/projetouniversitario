using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class ProviderTransaction
    {
        public ProviderTransactionKey ProviderKey { get; set; }

        public Int32 PaymentDet_Id { get; set; }
        public DateTime? Transaction_Date { get; set; }
        public String Credit_Card_Number { get; set; }
        public String Credit_Card_Expiration_Date { get; set; }
        public Decimal? Amount { get; set; }
        public Decimal? Tax { get; set; }
        public String Response_Code { get; set; }
        public String Authorization_Code { get; set; }
        public String Retrieval_Reference_Number { get; set; }
        public String Order_Id { get; set; }
        public String Transaction_Extra_Data { get; set; }
        public Int32? UserId { get; set; }

    }

    public class ProviderTransactionKey
    {
        public Nullable<int> Provider_Id { get; set; }
        public string Transaction_Id { get; set; }
        public Nullable<int> Transaction_Key_Id { get; set; }
        public Nullable<int> Transaction_Type_Catalog_Id { get; set; }
        public Nullable<int> Provider_Transaction_Type_Id { get; set; }
    }

    public class ProviderTransactionResult
    {
        public ProviderTransactionKey ProviderKey { get; set; }
        public string Order_Id { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }

    }
}
