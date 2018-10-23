using STL.CALLBACK.Data.EdmxModel;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.CALLBACK.Data.Repository
{
    public class BaseRepository
    {
        private PosSiteDataContext DataContext;
        protected POS_SITEEntities PosContex;
        
        public enum MappingElementType
        {
            Storage = 1,
            Usage = 2,
            Color = 3,
            MaritalStatus = 4,
            VehicleType = 5
        }

        public BaseRepository()
        {
            DataContext = new PosSiteDataContext();
            PosContex = DataContext.PosContex;
        }

    }
}
