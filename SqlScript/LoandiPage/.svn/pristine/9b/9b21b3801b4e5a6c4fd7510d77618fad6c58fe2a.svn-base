using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.CALLBACK.Data.Repository;

using System.Globalization;


namespace STL.CALLBACK.Logic
{
    public class BaseManager
    {
        public readonly BaseRepository baseRepository;

        public BaseManager()
        {
            baseRepository = new BaseRepository();
        }
    }

    public static class Ext
    {
        public static string DecimalToString(this decimal? value)
        {
            string result;

            result = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : "0.00";

            return
               result;
        }
    }
}
