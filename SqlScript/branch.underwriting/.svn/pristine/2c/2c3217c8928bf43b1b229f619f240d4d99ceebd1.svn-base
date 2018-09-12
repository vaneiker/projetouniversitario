using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WSVirtualOffice.Models
{
    public class Linkcopy
    {
        public static void CopyToAnother(Object source, Object dest)
        {
            PropertyInfo[] oProps =
            ((Type)source.GetType()).GetProperties();

            PropertyInfo[] oProps1 =
            ((Type)dest.GetType()).GetProperties();

            foreach (PropertyInfo pi in oProps)
            {
                //String temp = pi.PropertyType.ToString();
                if (pi.PropertyType.ToString().Equals("System.DateTime") || pi.PropertyType.ToString().Equals("System.Int64") || pi.PropertyType.ToString().Equals("System.String") ||
                    pi.PropertyType.ToString().Equals("System.Char") || pi.PropertyType.ToString().Equals("System.Decimal") || pi.PropertyType.ToString().Equals("System.Int32") ||
                    pi.PropertyType.ToString().Equals("System.Int16") || pi.PropertyType.ToString().Equals("System.Nullable`1[System.DateTime]") || pi.PropertyType.ToString().Equals("System.Nullable`1[System.Int64]") || pi.PropertyType.ToString().Equals("System.Nullable`1[System.String]") ||
                    pi.PropertyType.ToString().Equals("System.Nullable`1[System.Char]") || pi.PropertyType.ToString().Equals("System.Nullable`1[System.Decimal]") || pi.PropertyType.ToString().Equals("System.Nullable`1[System.Int32]") ||
                    pi.PropertyType.ToString().Equals("System.Nullable`1[System.Int16]")) 
                {
                foreach (PropertyInfo pi1 in oProps1)
                    {
                        if (pi1.Name.Equals(pi.Name))
                        {
                            pi1.SetValue(dest, pi.GetValue(source, null), null);
                        }
                    }
                }
            }

        }        
    }
}
