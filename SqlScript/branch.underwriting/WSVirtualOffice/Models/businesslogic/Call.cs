using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{
   
    public class Call
    {
        public static char callcode(String callitem)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                logitemdet logitem = (from item in newdb.logitemdets
                                      where item.logitem.Equals(callitem)
                                      select item).SingleOrDefault();
                return logitem.logitemcode;
            }
            catch (Exception ex)
            {
              
            }
            finally
            {
                //newdb.Dispose();
            }
            return ' ';
        }

        public static String callitem(String callitemcode)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                logitemdet logitem = (from item in newdb.logitemdets
                                      where item.logitemcode.Equals(callitemcode)
                                      select item).SingleOrDefault();
                return logitem.logitem;
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                //newdb.Dispose();
            }
            return "";
        }
        //public static char callcode(String callitem)
        //{
        //    foreach (logitemdet item in Program.Logitemcall)
        //    {
        //        if (item.logitem.Equals(callitem.Trim()))
        //        {
        //            return item.logitemcode;
        //        }
        //    }

        //    return ' ';
        //}

        //public static String callitem(Char callitemcode)
        //{
        //    foreach (logitemdet item in Program.Logitemcall)
        //    {
        //        if (item.logitemcode==callitemcode)
        //        {
        //            return item.logitem;
        //        }
        //    }

        //    return "";
        //}
    }
}