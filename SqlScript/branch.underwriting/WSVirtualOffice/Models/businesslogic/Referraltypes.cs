using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Referraltypes
    {
        public static char getReferraltypecode(String referraltype)
        {
            try
            {
                //referraltype = Lookuplangdata.getEnglishvalue(Lookuptables.referraltypedet, referraltype);
                referraltypedet reftype = (from item in Program.referraltypeslist
                                           where item.referraltype.Equals(referraltype)
                                           select item).SingleOrDefault();
                return reftype.referraltypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (referraltypedet item in Program.referraltypeslist)
            {
                if (item.referraltype.Equals(referraltype.Trim()))
                {
                    return item.referraltypecode;

                }
            }
            return ' ';
             */ 

        }

        public static String getReferraltype(char referraltypecode)
        {
            try
            {
                referraltypedet reftype = (from item in Program.referraltypeslist
                                           where item.referraltypecode == referraltypecode
                                           select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.referraltypedet, reftype.referraltype);
                return reftype.referraltype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (referraltypedet item in Program.referraltypeslist)
            {
                if (item.referraltypecode == referraltypecode)
                {
                    return item.referraltype;

                }
            }
            return "";
             */ 
        }
    }
}
