using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Occupationtypes
    {


        public static String getOccupationtypecode(String occupationtype)
        {
            try
            {
                occupationtypedet occtype = (from item in Program.occtypeslist
                                             where item.occupationtype.Equals(occupationtype)
                                             select item).SingleOrDefault();
                return occtype.occupationtypecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (occupationtypedet item in Program.occtypeslist)
            {
                if (item.occupationtype.Equals(occupationtype.Trim()))
                {
                    return item.occupationtypecode;

                }
            }
             */
            return "";

        }

        public static String getOccupationtype(String occupationtypecode)
        {
            try
            {
                occupationtypedet occtype = (from item in Program.occtypeslist
                                             where item.occupationtypecode.Equals(occupationtypecode)
                                             select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.occupationtypedet, occtype.occupationtype);
                return occtype.occupationtype;
            }
            catch (Exception ex)
            {
                return "";
            }


        }

        public static List<occupationtypedet> getOccupationsByProfession(string professionTypeCode)
        {
            return (from occ in Program.occtypeslist
                    where occ.professiontypecode.Equals(professionTypeCode)
                    select occ).ToList();
        }
    }
}
