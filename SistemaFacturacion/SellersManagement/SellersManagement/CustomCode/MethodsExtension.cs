using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SellersManagement.CustomCode
{
    public static class MethodsExtension
    {
        /// <summary>
        /// Devuelve si true si el string esta null o vacio o false si no lo esta
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool MyStringIsNullOrEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            return false;
        }

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

        public static string FormatDatetime(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return 0;
            }
        }        

        public static int? ToIntNullable(this string st)
        {
            int i = 0;

            if (int.TryParse(st, out i))
            {
                if (i > 0)
                {
                    return i;
                }
                else { return null; }
            }
            else
            {
                return null;
            }
        }

        public static DateTime ToDatetime(this string st)
        {
            DateTime i = DateTime.Now;
            CultureInfo ci = CultureInfo.CreateSpecificCulture("es-DO");

            if (DateTime.TryParse(st, ci, DateTimeStyles.None, out i))
            {
                return i;
            }
            else
            {
                return DateTime.Now;
            }
        }


        public static DateTime? ToDatetimeNullable(this string st)
        {
            DateTime i = DateTime.Now;
            //CultureInfo ci = CultureInfo.CreateSpecificCulture("es-DO");

            if (DateTime.TryParse(st, out i))
            {
                return i;
            }
            else
            {
                return null;
            }
        }


        public static decimal ToDecimal(this string st)
        {
            decimal i = 0;

            if (decimal.TryParse(st, out i))
            {
                return i;
            }
            else
            {
                return 0;
            }
        }

        public static decimal? ToDecimalNullable(this string st)
        {
            decimal i = 0;

            if (decimal.TryParse(st, out i))
            {
                return i;
            }
            else
            {
                return null;
            }
        }

        public static string UppercaseFirstLetter(this string st)
        {
            if (string.IsNullOrEmpty(st))
            {
                return string.Empty;
            }
            char[] a = st.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string UppercaseFirstLetterOfWords(this string st)
        {
            if (string.IsNullOrEmpty(st))
            {
                return string.Empty;
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            return textInfo.ToTitleCase(st.ToLower());
        }


        public static string ToJson(this object obj)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetTreeViewJsonFormat(this string str) { return '[' + str + ']'; }

        public static string MergeJsonString(this string str, string strTwo) { if (String.IsNullOrEmpty(str)) return strTwo; else return str + "," + strTwo; }

        public static string GetInnerExceptionMessage(this Exception ex)
        {
            if (ex != null && ex.InnerException != null)
            {
                return ex.InnerException.ToString();
            }
            return "N/A";

        }

        public static T ToObject<T>(this string json)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return default(T);
            }
        }


        public static string shrinkText(this string text)
        {
            string newText = "";

            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length >= 25)
                {
                    newText = text.Substring(0, 25).Trim() + "...";
                }
                else { newText = text; }
            }


            return newText;
        }
    }
}