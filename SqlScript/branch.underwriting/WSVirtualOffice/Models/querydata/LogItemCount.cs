using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
     class LogItemCount
    {
        private String product;
        private long count;

        public LogItemCount(String productcode, long count)
        {
            this.product = Productdata.getProduct(productcode);
            this.count = count;
        }
        public String Product
        {
            get { return product; }
            set { product = value; }
        }
        public long Count
        {
            get { return count; }
            set { count = value; }
        }




    }
}