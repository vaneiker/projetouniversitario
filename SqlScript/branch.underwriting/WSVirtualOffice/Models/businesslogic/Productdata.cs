using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Productdata
    {
        public static int PROFILEU = 0;
        public static int PROFILEM = 1;
        public static int PROFILEB = 2;
        public static int PROFILEG = 3;


        public static String getProductcode(String productname)
        {
            try
            {
                //productname = Lookuplangdata.getEnglishvalue(Lookuptables.productdet, productname);
                var product = (from prod in Program.productslist
                               where prod.product.Trim().Equals(productname)
                               select prod).SingleOrDefault();
                return product.productcode;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static String getProduct(String productcode,string company_id)
        {
            try
            {
                //productname = Lookuplangdata.getEnglishvalue(Lookuptables.productdet, productname);
                
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode) && prod.company_id.Equals(company_id)
                               select prod).SingleOrDefault();

                
                return product.product;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static String getProducts(string company_id)
        {
            try
            {
                //productname = Lookuplangdata.getEnglishvalue(Lookuptables.productdet, productname);
                string[] prods = (from prod in Program.productslist                               
                                  where prod.company_id.Equals(company_id)
                               select prod.productcode).ToArray<string>();
                return string.Join("|",prods);
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static String getProduct(String productcode)
        {
            try
            {
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode)
                               select prod).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.productdet, product.product);
                return product.product;
            }
            catch (Exception ex)
            {
                return "";
            }

        }


        public static Boolean isFixed(String productcode)
        {
            try
            {
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode)
                               select prod).SingleOrDefault();
                return ((product.@fixed=='Y')?true:false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean isProfilehide(String productcode)
        {
            try
            {
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode)
                               select prod).SingleOrDefault();
                return ((product.showprofile == 'N') ? true : false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean isRefund(String productcode)
        {
            try
            {
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode)
                               select prod).SingleOrDefault();
                return ((product.isrefund == 'Y') ? true : false);
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static int getProductcancelno(String productcode,int retirementperiod)
        {
            try
            {
                var prodcan = (from item in Program.cancelist
                               where item.productcode.Trim().Equals(productcode) && item.fromcontributionpriod<=retirementperiod && item.tocontributionpriod>=retirementperiod
                               select item).SingleOrDefault();
                return Numericdata.getIntegervalue(prodcan.productcancelno.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static WSVirtualOffice.Models.blinsurance.ICanceldata[] getProductcanceldata(String productcode,int retirementperiod)
        {
            WSVirtualOffice.Models.blinsurance.ICanceldata[] candata = null;
            try
            {
                int prodcancelno = getProductcancelno(productcode,retirementperiod);
                var proddetails = from item in Program.canceldetailslist
                               where item.productcancelno==prodcancelno
                               orderby item.yearno
                               select item;
                candata=new WSVirtualOffice.Models.blinsurance.ICanceldata[proddetails.Count()];
                int i = -1;
                foreach (productcanceldetailsdet item in proddetails)
                {
                    i++;
                    candata[i] = new WSVirtualOffice.Models.blinsurance.ICanceldata();
                    candata[i].sno = item.yearno.Value;
                    candata[i].cancelpercent =Numericdata.getDoublevalue(item.cancelpercent.ToString());
                }
                return candata;
            }
            catch (Exception ex)
            {
                return candata;
            }
        }


        public static char getPlangroupcode(String productcode)
        {
            try
            {
                var product = (from prod in Program.productslist
                               where prod.productcode.Trim().Equals(productcode)
                               select prod).SingleOrDefault();
                return Convert.ToChar((product.plangroupcode.Value+"").Substring(0,1));
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }


        public static double[] getProfileRates(String productcode,char classcode)
        {
            List<vwinvestmentprofilevalue> invlist = (from item in Program.investprofilevalueslist
                                                        where item.productcode.Equals(productcode) && item.classcode == classcode
                                                        select item).ToList<vwinvestmentprofilevalue>();
            double[] profilerates=new double[4];

            foreach (vwinvestmentprofilevalue invdata in invlist)
            {
                if (invdata.investmentprofilecode == Invprofiledata.GUARANTEED)
                {
                    profilerates[PROFILEU] = Numericdata.getDoublevalue(invdata.investmentprofilerate.ToString());
                }
                else if (invdata.investmentprofilecode == Invprofiledata.MODERATE)
                {
                    profilerates[PROFILEM] = Numericdata.getDoublevalue(invdata.investmentprofilerate.ToString());
                }
                else if (invdata.investmentprofilecode == Invprofiledata.BALANCED)
                {
                    profilerates[PROFILEB] = Numericdata.getDoublevalue(invdata.investmentprofilerate.ToString());
                }
                else if (invdata.investmentprofilecode == Invprofiledata.GROWTH)
                {
                    profilerates[PROFILEG] = Numericdata.getDoublevalue(invdata.investmentprofilerate.ToString());
                }
            }
            return profilerates;

        }

                


        


    }
}
