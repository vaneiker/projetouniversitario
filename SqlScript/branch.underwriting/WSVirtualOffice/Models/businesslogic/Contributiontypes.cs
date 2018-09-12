using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{

    


    class Contributiontypes
    {
        public static char CONTINUOUS = 'C';
        public static char UNTILAGE = 'U';
        public static char NUMBEROFYEARS = 'Y';

        public static char getcontributiontypecode(String contributiontype)
        {
            try{
                //contributiontype = Lookuplangdata.getEnglishvalue(Lookuptables.contributiontypedet, contributiontype);
            contributiontypedet contr = (from item in Program.contrtypeslist
                                         where item.contributiontype.Equals(contributiontype)
                                         select item).SingleOrDefault();
            return contr.contributiontypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (contributiontypedet item in Program.contrtypeslist)
            {
                if (item.contributiontype.Equals(contributiontype.Trim()))
                {
                    return item.contributiontypecode;

                }
            }
            return ' ';
            */
        }

        public static String getcontributiontype(char contributiontypecode)
        {
            try
            {
                contributiontypedet contr = (from item in Program.contrtypeslist
                                             where item.contributiontypecode == contributiontypecode
                                             select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.contributiontypedet, contr.contributiontype);
                return contr.contributiontype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (contributiontypedet item in Program.contrtypeslist)
            {
                if (item.contributiontypecode.Equals(contributiontypecode))
                {
                    return item.contributiontype;

                }
            }
            return "";
             */
        }

    }
}
