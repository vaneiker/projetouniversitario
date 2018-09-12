using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    class Productinvprofile
    {
        public String productcode;
        public char investmentprofilecode;
        public char classcode;
        public double investmentprofilerate;
        public double compgrowthrate1;
        public double compgrowthrate2;

        public char plantypecode;

        public Productinvprofile(String productcode,char investmentprofilecode,char plantypecode,char classcode)
        {
            this.productcode = productcode;
            this.investmentprofilecode = investmentprofilecode;
            this.classcode = classcode;
            this.investmentprofilerate = getInvprofilerate(this.investmentprofilecode, this.productcode,classcode);
            this.compgrowthrate1 = getCompareprofilerate1(this.investmentprofilecode, this.productcode,classcode);
            this.compgrowthrate2= getCompareprofilerate2(this.investmentprofilecode, this.productcode,classcode);
            this.plantypecode = plantypecode;
        }



        public static double getCompareprofilerate1(char invprofilecode, String productcode,char classcode)
        {
            try
            {

                invprofilecompareratesdet invcom = (from item in Program.invcomparelist
                                                    where item.investmentprofilecode == invprofilecode && item.productcode.Equals(productcode) && item.classcode == classcode
                                                    select item).SingleOrDefault();
                return double.Parse(invcom.growthrate1.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            /*
            foreach(invprofilecompareratesdet invcomp in Program.invcomparelist){
                if((invcomp.investmentprofilecode==invprofilecode)&&(invcomp.productcode.Equals(productcode))){
                    return double.Parse(invcomp.growthrate1.ToString());
                }
            }
             */ 
            
        }

        public static double getCompareprofilerate2(char invprofilecode, String productcode,char classcode)
        {
            try
            {

                invprofilecompareratesdet invcom = (from item in Program.invcomparelist
                                                    where item.investmentprofilecode == invprofilecode && item.productcode.Equals(productcode) && item.classcode == classcode
                                                    select item).SingleOrDefault();
                return double.Parse(invcom.growthrate2.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            /*
            foreach(invprofilecompareratesdet invcomp in Program.invcomparelist){
                if((invcomp.investmentprofilecode==invprofilecode)&&(invcomp.productcode.Equals(productcode))){
                    return double.Parse(invcomp.growthrate2.ToString());
                }
            }
            return 0.0;
             */ 
        }

        public static double getInvprofilerate(char invprofilecode, String productcode,char classcode)
        {
            try
            {
                vwinvestmentprofilevalue invest = (from item in Program.investprofilevalueslist
                                                    where item.investmentprofilecode == invprofilecode && item.productcode.Equals(productcode) && item.classcode == classcode
                                                    select item).SingleOrDefault();
                return double.Parse(invest.investmentprofilerate.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            /*
            foreach(vwinvestmentprofilevalue item in Program.investprofilevalueslist){
                if((item.investmentprofilecode==invprofilecode)&&(item.productcode.Equals(productcode))){
                    return double.Parse(item.investmentprofilerate.ToString());
                }
            }
            return 0.0;
             */ 
        }


    }
}
