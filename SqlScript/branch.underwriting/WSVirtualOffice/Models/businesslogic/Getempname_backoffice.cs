using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Getempname_backoffice
    {
        public static string getempcode(String empname)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                managerdet quary = (from item in newdb.managerdets where item.managername.Equals(empname) select item).SingleOrDefault();

                return quary.managercode;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return " ";
        }
    }
}
