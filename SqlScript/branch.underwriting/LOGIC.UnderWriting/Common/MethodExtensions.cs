using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.UnderWriting.Common
{
    public static class MethodExtensions
    {
        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(this string value)
        {
            int d;
            return Int32.TryParse(value, out d);
        }

        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsLong(this string value)
        {
            long d;
            return Int64.TryParse(value, out d);
        }

        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            int d;
            return Int32.TryParse(value, out d) ? d : 0;
        }

        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            long d;
            return Int64.TryParse(value, out d) ? d : 0;
        }

        public static Exception FindInnerException(this Exception ex)
        {
            if (ex.InnerException != null) return FindInnerException(ex.InnerException);
            return ex;
        }
    }
}
