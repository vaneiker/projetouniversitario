using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Datedata
    {
        public static DateTime getDatevalue(String str1)
        {
            try
            {
                if (!str1.Trim().Equals(""))
                {
                    return DateTime.Parse(str1);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }


    }
}
