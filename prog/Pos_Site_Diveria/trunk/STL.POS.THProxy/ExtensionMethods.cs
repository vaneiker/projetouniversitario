using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.THProxy
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Devuelve true or false si la referencia al objeto es nula
        /// Created Date: 03/19/2015
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool isNullReferenceObject(this Object obj)
        {
            return (obj == null);
        }

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

            if (separator.isNullReferenceObject())
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

    }
}