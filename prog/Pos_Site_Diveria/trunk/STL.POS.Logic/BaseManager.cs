using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data.NewVersion.Repository;
using System.Globalization;

namespace STL.POS.Logic
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
