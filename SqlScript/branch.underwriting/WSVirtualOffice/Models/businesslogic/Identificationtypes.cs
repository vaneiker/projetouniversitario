using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Identificationtypes
    {
        public static char getidentificationtypecode(String identificationtype)
        {
            try
            {
                var invprofile = (from item in Program.identificationtypeslist
                                  where item.identificationtype.Trim().Equals(identificationtype)
                                  select item).SingleOrDefault();
                return invprofile.identificationtypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getidentificationtype(char identificationtypecode)
        {
            try
            {
                var invprofile = (from item in Program.identificationtypeslist
                                  where item.identificationtypecode == identificationtypecode
                                  select item).SingleOrDefault();
                return invprofile.identificationtype;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}
