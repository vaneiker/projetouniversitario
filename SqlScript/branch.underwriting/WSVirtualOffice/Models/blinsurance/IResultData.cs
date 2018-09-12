using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    public class IResultData
    {
        
        public double targetamount;
        public double minimumpremium;
        public double insuredamount;
        public double premiumamount;
        public double targetamountvariable;
        //public double accountvalue;

        public double rideradbcost;
        public double rideracdbcost;
        public double ridertermcost;
        public double ridercicost;
        public double rideroircost;

        public Boolean impossible=false;

        public String getTargetamount()
        {
            return String.Format("{0:f2}", this.targetamount);

        }
        public String getInsuredamount()
        {
            return String.Format("{0:f2}", this.insuredamount);
        }
        public String getPremiumamount()
        {
            return String.Format("{0:f2}", this.premiumamount);
        }
        public String getMinimumpremiumamount()
        {
            return String.Format("{0:f2}", this.minimumpremium);
        }
        
    }
}
