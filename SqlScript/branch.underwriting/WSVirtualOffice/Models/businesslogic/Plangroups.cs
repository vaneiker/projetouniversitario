using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Plangroups
    {
        public static char LIFE = 'L';
        public static char EDUCATION = 'E';
        public static char RETIREMENT = 'R';
        public static char TERMINSURANCE = 'T';
        public static char FUNERAL = 'F';

        public static string getPlangroups()
        {
            return "L|E|R|T|F";
        }
        
        public static char getPlangroupcode(String plangroup)
        {
            try
            {
                //plangroup = Lookuplangdata.getEnglishvalue(Lookuptables.plangroupdet, plangroup);
                plangroupdet plangroupdata = (from item in Program.plangroupslist
                                              where item.plangroup.Equals(plangroup)
                                              select item).SingleOrDefault();
                return plangroupdata.plangroupcode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
        

        }

        public static String getPlangroup(char plangroupcode)
        {
            try
            {
                plangroupdet plangroupdata = (from item in Program.plangroupslist
                                              where item.plangroupcode== plangroupcode
                                              select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.plangroupdet,plangroupdata.plangroup);
                return plangroupdata.plangroup;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
