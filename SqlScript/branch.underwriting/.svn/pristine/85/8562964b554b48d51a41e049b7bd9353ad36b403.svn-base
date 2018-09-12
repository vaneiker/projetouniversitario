using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
   public class Usertypes
    {
        public static string AGENT = "AG";
        //public static string EMPLOYEEAGENT = "EG";
        public static string EMPLOYEE = "EM";


        public static string getUsertypecode(String usertype)
        {
            try
            {
                //usertype = Lookuplangdata.getEnglishvalue(Lookuptables.usertypedet, usertype);
                usertypedet usergroupdata = (from item in Program.usertypelist
                                              where item.usertype.Equals(usertype)
                                              select item).SingleOrDefault();
                return usergroupdata.usertypecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (plangroupdet item in Program.plangroupslist)
            {
                if (item.plangroup.Equals(plangroup.Trim()))
                {
                    return item.plangroupcode;

                }
            }
            return ' ';
             */

        }

        public static String getUsertype(string usertypecode)
        {
            try
            {
                usertypedet usertypedata = (from item in Program.usertypelist
                                              where item.usertypecode == usertypecode
                                              select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.usertypedet, usertypedata.usertype);
                return usertypedata.usertype;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
