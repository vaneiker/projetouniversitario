using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.DocumentsXmlProvider
{
    public static class UtilityForDocuments
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertToString(this DateTime? date, string format = "dd/MM/yyyy")
        {
            return (date ?? DateTime.MinValue).ToString(format).Replace(".", string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ConvertToString(this DateTime date, string format = "dd/MM/yyyy")
        {
            return date.ToString(format).Replace(".", string.Empty);
        }
    }
}
