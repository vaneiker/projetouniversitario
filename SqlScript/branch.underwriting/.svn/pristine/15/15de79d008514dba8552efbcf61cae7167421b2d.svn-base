using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Emailtypes
    {        
        public static String WORK = "W";
        public static String PERSONAL = "P";
        


        public static char getEmailtypecode(String emailtype)
        {
            try
            {
                //emailtype = Lookuplangdata.getEnglishvalue(Lookuptables.emailtypedet, emailtype);
                var emailtypecode = (from email in Program.emailtypelist
                                     where email.emailtype.Equals(emailtype)
                                     select email).SingleOrDefault().emailtypecode;
                return emailtypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getEmailtype(char emailtypecode)
        {
            try
            {
                var emailtype = (from email in Program.emailtypelist
                                 where email.emailtypecode == emailtypecode
                                 select email).SingleOrDefault().emailtype;
                //return Lookuplangdata.getLanguagevalue(Lookuptables.emailtypedet, emailtype);
                return emailtype;
            }
            catch (Exception ex)
            {
                return "";
            }

        }


    }
}
