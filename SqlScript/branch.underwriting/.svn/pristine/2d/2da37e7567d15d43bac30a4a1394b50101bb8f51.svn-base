using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WSVirtualOffice.Models.businesslogic
{
    class Policystatus
    {

        public static char getPolstatuscode(String status)
        {

          DataVOUniversalDataContext newdb = Program.getDbConnection();
          try
          {
              policystatusdet policystatus = (from item in newdb.policystatusdets
                                              where item.policystatus.Equals(status)
                                              select item).SingleOrDefault();
              return policystatus.policystatuscode;
          }
          catch (Exception ex)
          {

          }
          finally
          {
          }
            return ' ';
        }
        public static String getpolstatus(char statuscode)
        {
          DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {

                policystatusdet policystatus = (from item in newdb.policystatusdets
                                                where item.policystatuscode == statuscode
                                                select item).SingleOrDefault();
                return policystatus.policystatus;
            }
            catch (Exception ex)
            {

            }
            finally
            {
               // //newdb.Dispose();
            }
            return "";
        }


    }
}