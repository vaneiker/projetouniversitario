using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Invprofiledata
    {
        public static char GUARANTEED = 'U';
        public static char GROWTH = 'G';
        public static char MODERATE = 'M';
        public static char BALANCED = 'B';

        public static char getInvestmentprofilecode(String investmentprofile)
        {
            try
            {
                //investmentprofile = Lookuplangdata.getEnglishvalue(Lookuptables.investmentprofiledet, investmentprofile);
                var invprofile = (from item in Program.investprofilelist
                                  where item.investmentprofile.Trim().Equals(investmentprofile)
                                  select item).SingleOrDefault();
                return invprofile.investmentprofilecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getInvestmentprofile(char investmentprofilecode)
        {
            try
            {
                var invprofile = (from item in Program.investprofilelist
                                  where item.investmentprofilecode == investmentprofilecode
                                  select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, invprofile.investmentprofile);
                return invprofile.investmentprofile;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

    }
}
