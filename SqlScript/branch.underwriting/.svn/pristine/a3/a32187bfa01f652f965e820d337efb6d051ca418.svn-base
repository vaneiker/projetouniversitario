using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Frequencytypes
    {
        public static char Yearly = 'A';
        public static char Semiannually = 'H';
        public static char Quarterly = 'Q';
        public static char Monthly = 'M';

        public static char getfrequencytypecode(String frequencytype)
        {
            try
            {
                //frequencytype = Lookuplangdata.getEnglishvalue(Lookuptables.frequencytype, frequencytype);
                frequencytypedet freqdata = (from item in Program.frequencylist
                                             where item.frequencytype.Equals(frequencytype)
                                             select item).SingleOrDefault();
                return freqdata.frequencytypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*

            foreach (frequencytypedet item in Program.frequencylist)
            {
                if (item.frequencytype.Equals(frequencytype.Trim()))
                {
                    return item.frequencytypecode;

                }
            }
            return ' ';
             */ 

        }

        public static int getfrequencytypevalue(String frequencytype)
        {
            try
            {
                //frequencytype=Lookuplangdata.getEnglishvalue(Lookuptables.frequencytype, frequencytype);
                frequencytypedet freqdata = (from item in Program.frequencylist
                                             where item.frequencytype.Equals(frequencytype)
                                             select item).SingleOrDefault();
                return Int32.Parse(freqdata.frequencyvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }

            /*
            foreach (frequencytypedet item in Program.frequencylist)
            {
                if (item.frequencytype.Equals(frequencytype.Trim()))
                {
                    return Int32.Parse(item.frequencyvalue.ToString());

                }
            }
            return 0;
             */ 
        }

        public static int getfrequencytypevaluefromcode(char frequencytypecode)
        {
            try
            {
                frequencytypedet freqdata = (from item in Program.frequencylist
                                             where item.frequencytypecode==frequencytypecode
                                             select item).SingleOrDefault();
                return Int32.Parse(freqdata.frequencyvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }            
        }

        public static int getfrequencytypevalue(char frequencytypecode)
        {
            try
            {
                frequencytypedet freqdata = (from item in Program.frequencylist
                                             where item.frequencytypecode == frequencytypecode
                                             select item).SingleOrDefault();
                return Int32.Parse(freqdata.frequencyvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
            /*

            foreach (frequencytypedet item in Program.frequencylist)
            {
                if (item.frequencytypecode== frequencytypecode)
                {
                    return Int32.Parse(item.frequencyvalue.ToString());
                }
            }
            return 0;
             */ 
        }

        public static double getfrequencytypepenaltyfromcode(char frequencytypecode,String productcode)
        {
            frequencycostdet freqcostdata = (from item in Program.freqcostlist
                                         where (item.productcode.Equals(productcode)) && item.frequencytypecode == frequencytypecode
                                         select item).SingleOrDefault();
            return Double.Parse(freqcostdata.frequencycost.ToString());

        }

        public static double getfrequencytypepenalty(String frequencytype)
        {
            //frequencytype = Lookuplangdata.getEnglishvalue(Lookuptables.frequencytype, frequencytype);
            foreach (frequencytypedet item in Program.frequencylist)
            {
                if (item.frequencytype.Equals(frequencytype.Trim()))
                {
                    return Double.Parse(item.frequencycost.ToString());

                }
            }
            return 0.0;
        }

        public static String getfrequencytype(char frequencytypecode)
        {
            foreach (frequencytypedet item in Program.frequencylist)
            {
                if (item.frequencytypecode == frequencytypecode)
                {
                    //return Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, item.frequencytype);
                    return item.frequencytype;

                }
            }
            return "";
        }
    }
}
