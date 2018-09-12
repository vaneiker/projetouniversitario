using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    class Profilecompare
    {
        public static double getCompareprofilerate1(char invprofilecode, String productcode)
        {
            foreach(invprofilecompareratesdet invcomp in Program.invcomparelist){
                if((invcomp.investmentprofilecode==invprofilecode)&&(invcomp.productcode.Equals(productcode))){
                    return double.Parse(invcomp.growthrate1.ToString());
                }
            }
            return 0.0;
        }

        public static double getCompareprofilerate2(char invprofilecode, String productcode)
        {
            foreach(invprofilecompareratesdet invcomp in Program.invcomparelist){
                if((invcomp.investmentprofilecode==invprofilecode)&&(invcomp.productcode.Equals(productcode))){
                    return double.Parse(invcomp.growthrate2.ToString());
                }
            }
            return 0.0;
        }

        public static double getInvprofilerate(char invprofilecode, String productcode)
        {
            foreach(vwinvestmentprofilevalue item in Program.investprofilevalueslist){
                if((item.investmentprofilecode==invprofilecode)&&(item.productcode.Equals(productcode))){
                    return double.Parse(item.investmentprofilerate.ToString());
                }
            }
            return 0.0;
        }

    }
}
