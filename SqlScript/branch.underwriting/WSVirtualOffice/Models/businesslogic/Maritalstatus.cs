using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Maritalstatus
    {

        public static string getMaritalstatuscode(String maritalstatus)
        {
            try
            {
                //maritalstatus = Lookuplangdata.getEnglishvalue(Lookuptables.maritalstatusdet, maritalstatus);
                maritalstatusdet marstatus = (from item in Program.maritalstatuslist
                                              where item.maritalstatus.Equals(maritalstatus)
                                              select item).SingleOrDefault();
                return marstatus.maritalstatuscode;
            }
            catch (Exception ex)
            {
                return " ";
            }
            /*
            foreach (maritalstatusdet item in Program.maritalstatuslist)
            {
                if (item.maritalstatus.Equals(maritalstatus.Trim()))
                {
                    return item.maritalstatuscode;

                }
            }
            return ' ';
             */ 

        }

        public static string getMaritalstatusValues()
        {
            try
            {
                //maritalstatus = Lookuplangdata.getEnglishvalue(Lookuptables.maritalstatusdet, maritalstatus);
                string[] chlist = (from item in Program.maritalstatuslist
                                     select item.maritalstatuscode).ToArray<string>();
                string values = string.Join("|", chlist);
                return values;
                //return marstatus.maritalstatuscode;
                //new string()
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (maritalstatusdet item in Program.maritalstatuslist)
            {
                if (item.maritalstatus.Equals(maritalstatus.Trim()))
                {
                    return item.maritalstatuscode;

                }
            }
            return ' ';
             */

        }

        public static String getmaritalstatus(string maritalstatuscode)
        {
            try
            {
                maritalstatusdet marstatus = (from item in Program.maritalstatuslist
                                              where item.maritalstatuscode == maritalstatuscode
                                              select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, marstatus.maritalstatus);
                return marstatus.maritalstatus;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (maritalstatusdet item in Program.maritalstatuslist)
            {
                if (item.maritalstatuscode == maritalstatuscode)
                {
                    return item.maritalstatus;

                }
            }
            return "";
             */ 
        }
    }
}
