using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Data.CSEntities
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Author : Lic. Carlos Ml Lebron B.
        /// Capitalize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Capitalize(this string value, char? separator = null)
        {
            string result = string.Empty;

            value = value.ToLower();

            if (string.IsNullOrWhiteSpace(value))
                return result;

            if (string.IsNullOrEmpty(separator.ToString()))
            {
                result = value.Substring(0, 1).ToUpper() +
                         value.Substring(1, value.Length - 1).ToLower();
            }
            else
            {
                var s = value.Split(separator.Value);

                for (int i = 0; i < s.Length; i++)
                {
                    if (!string.IsNullOrEmpty(s[i]))
                    {
                        result += (s[i].Substring(0, 1).ToUpper() +
                                   s[i].Substring(1, s[i].Length - 1).ToLower()) + " ";
                    }
                }

                result = result.Remove(result.LastIndexOf(' '), 1);
            }

            return result;
        }
        
        public static int toInt(this string value)
        {
            int i;

            int.TryParse(value, out i);

            if (i > 0)
            {
                return i;
            }

            return 0;
        }

        public static decimal toDecimal(this string value)
        {
            decimal i;

            decimal.TryParse(value, out i);

            if (i > 0)
            {
                return i;
            }
            return 0;
        }

        public static DateTime? toDatetime(this string value)
        {
            DateTime d;

            DateTime.TryParse(value, out d);

            if (d!=null)
            {
                return d;
            }

            return null;
        }
    }
}