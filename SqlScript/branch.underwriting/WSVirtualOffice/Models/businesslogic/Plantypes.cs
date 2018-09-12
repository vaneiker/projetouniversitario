using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Plantypes
    {
        public static char FIXED = 'F';
        public static char INCREMENTAL = 'I';
        public static char INSURED = 'S';
        public static char NONINSURED = 'N';

        public static char getPlantypecode(String plantype)
        {
            try
            {
                //plantype = Lookuplangdata.getEnglishvalue(Lookuptables.plantypedet, plantype);
                plantypedet plantypedata = (from item in Program.plantypeslist
                                            where item.plantype.Equals(plantype)
                                            select item).SingleOrDefault();
                return plantypedata.plantypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (plantypedet item in Program.plantypeslist)
            {
                if (item.plantype.Equals(plantype.Trim()))
                {
                    return item.plantypecode;

                }
            }
            return ' ';
             */ 

        }

        public static String getPlantype(char plantypecode)
        {
            try
            {
                plantypedet plantypedata = (from item in Program.plantypeslist
                                            where item.plantypecode==plantypecode
                                            select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, plantypedata.plantype);
                return plantypedata.plantype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (plantypedet item in Program.plantypeslist)
            {
                if (item.plantypecode == plantypecode)
                {
                    return item.plantype;

                }
            }
            return "";
             */ 
        }
    }
}
