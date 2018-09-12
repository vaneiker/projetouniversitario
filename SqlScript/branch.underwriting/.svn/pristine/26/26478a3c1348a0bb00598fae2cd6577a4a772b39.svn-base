using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Logintypes
    {
        public static String getLogintypecode(String logintype)
        {
            try
            {
                logintypedet logtype = (from item in Program.logintypelist
                                        where item.logintype.Equals(logintype)
                                        select item).SingleOrDefault();
                return logtype.logintypecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (logintypedet item in Program.logintypelist)
            {
                if (item.logintype.Equals(logintype.Trim()))
                {
                    return item.logintypecode;

                }
            }
            return "";
             */ 

        }

        public static String getLogintype(String logintypecode)
        {
            try
            {
                logintypedet logtype = (from item in Program.logintypelist
                                        where item.logintypecode.Equals(logintypecode)
                                        select item).SingleOrDefault();
                return logtype.logintype;
            }
            catch (Exception ex)
            {
                return "";
            }

            /*
            foreach (logintypedet item in Program.logintypelist)
            {
                if (item.logintypecode.Equals(logintypecode))
                {
                    return item.logintype;

                }
            }
            return "";
             */ 
        }
    }
}
