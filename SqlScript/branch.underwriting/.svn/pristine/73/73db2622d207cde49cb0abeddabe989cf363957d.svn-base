using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Currencytypes
    {
        public static char USD = 'A';
        public static char Euro = 'E';
        public static char RD = 'R'; 
        
        public static String getcurrencycode(String currency)
        {
            try
            {
                currencydet curr = (from item in Program.currencylist
                                    where item.currency.Equals(currency)
                                    select item).SingleOrDefault();
                return curr.currencycode;
            }
            catch (Exception ex)
            {
                return "";
            }
            

        }

        public static String getcurrency(String currencycode)
        {
            try
            {
                currencydet curr = (from item in Program.currencylist
                                    where item.currencycode.Equals(currencycode)
                                    select item).SingleOrDefault();
                return curr.currencycode;
            }
            catch (Exception ex)
            {
                return "";
            }
            
        }

        public static String Currencycode(char classcode)
        {
            if (classcode == Currencytypes.Euro)
            {
                return "€";
            }
            else if (classcode == Currencytypes.USD)
            {
                return "US$";
            }
            else if (classcode == Currencytypes.RD)
            {
                return "RD$";
            }
            else
            {
                return "";
            }
        }

    }
}
