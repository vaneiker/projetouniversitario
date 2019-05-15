using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion
{
    public class PosSiteDataContext
    {
        public PosSiteDataContext(string ConnStr = "") { }

        private POS_SITEEntities _PosContex;
        public POS_SITEEntities PosContex
        {
            get
            {
                return _PosContex ?? new POS_SITEEntities();
            }
        }
    }
}
