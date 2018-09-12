using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Professiontypes
    {
        public static String getProfessiontypecode(String Professiontype)
        {
            try
            {
                //Professiontype = Lookuplangdata.getEnglishvalue(Lookuptables.professiontypedet, Professiontype);
                professiontypedet prof = (from item in Program.professiontypeslist
                                          where item.professiontype.Equals(Professiontype)
                                          select item).SingleOrDefault();
                return prof.professiontypecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*

            foreach (professiontypedet item in Program.professiontypeslist)
            {
                if (item.professiontype.Equals(Professiontype.Trim()))
                {
                    return item.professiontypecode;

                }
            }
            return "";
             */ 

        }

        public static String getProfessiontype(String Professiontypecode)
        {
            try
            {
                professiontypedet prof = (from item in Program.professiontypeslist
                                          where item.professiontypecode.Equals(Professiontypecode)
                                          select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.professiontypedet, prof.professiontype);
                return prof.professiontype;
            }
            catch (Exception ex)
            {
                return "";
            }

            /*
            foreach (professiontypedet item in Program.professiontypeslist)
            {
                if (item.professiontypecode.Equals(Professiontypecode))
                {
                    return item.professiontype;

                }
            }
            return "";
             */ 
        }
    }
}
