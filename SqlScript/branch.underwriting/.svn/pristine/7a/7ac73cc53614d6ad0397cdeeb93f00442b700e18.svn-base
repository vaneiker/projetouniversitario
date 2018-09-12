using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Classdata
    {
        public static char getClasscode(String classtext)
        {
            if (!classtext.Equals(""))
            {
                return classtext.ToCharArray()[0];
            }
            else
            {
                return ' ';
            }
        }

        public static String getClasstext(char classcode)
        {
            return classcode.ToString();
        }

        public static String getClasscodefromcurrency(String currencycode)
        {
            try
            {
                var cur1 = (from prod in Program.currencylist
                               where prod.currencycode.Trim().Equals(currencycode)
                               select prod).SingleOrDefault();
                return cur1.@class.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }


        public static List<String> getProductclasscodes(String productcode)
        {
            List<String> classlist = new List<String>();
            try
            {
                var prod1 = from prod in Program.prodcurlist
                               where prod.productcode.Equals(productcode)
                               select prod;
                
                foreach (productcurrencydet item in prod1)
                {
                    classlist.Add(getClasscodefromcurrency(item.currencycode));
                }
                return classlist;
            }
            catch (Exception ex)
            {
                return classlist;
            }
        }
    }


}
