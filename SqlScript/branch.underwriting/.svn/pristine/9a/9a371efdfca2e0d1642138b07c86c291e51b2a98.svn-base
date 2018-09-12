using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Productinvprofile
    {
        public String productcode;
        public char investmentprofilecode;
        public char classcode;
        public double compgrowthrate1;
        public double compgrowthrate2;

        public char plantypecode;

        public Productinvprofile(String productcode, char investmentprofilecode, char plantypecode, char classcode)
        {
            this.productcode = productcode;
            this.investmentprofilecode = investmentprofilecode;
            this.classcode = classcode;
            this.compgrowthrate1 = getCompareprofilerate1(this.investmentprofilecode, this.productcode, classcode);
            this.compgrowthrate2 = getCompareprofilerate2(this.investmentprofilecode, this.productcode, classcode);
            this.plantypecode = plantypecode;
        }

        public static double getCompareprofilerate1(char invprofilecode, String productcode, char classcode)
        {
            try
            {
                var invcom = new IllustrationService().oIllusDataManager.GetInvProfileCompareRates(classcode.ToString(), productcode, invprofilecode.ToString()).Single(); 
                return invcom.GrowthRate1.ToDouble();
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }

        public static double getCompareprofilerate2(char invprofilecode, String productcode, char classcode)
        {
            try
            {

                var invcom = new IllustrationService().oIllusDataManager.GetInvProfileCompareRates(classcode.ToString(), productcode, invprofilecode.ToString()).Single();
                return invcom.GrowthRate2.ToDouble();
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }

        public static double getInvprofilerate(char invprofilecode, String productcode, char classcode)
        {
            try
            {
                return Utility.GetIllusDropDownByType(Utility.DropDownType.InvestmentProfile, productcode, pClass:classcode.ToString())
                    .Single(o=> o.InvestmentProfileCode ==invprofilecode.ToString()).InvestmentProfileRate.ToDouble();
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }
    }
}