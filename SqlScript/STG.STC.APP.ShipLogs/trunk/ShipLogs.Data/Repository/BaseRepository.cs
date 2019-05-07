using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLogs.Data.EdmxModel;

namespace ShipLogs.Data.Repository
{
    public class BaseRepository
    {
        private ShipLogsDataContext DataContext;
        protected ShipLogs_Entities ShipLogsContex;

        public BaseRepository()
        {
            DataContext = new ShipLogsDataContext();
            ShipLogsContex = new ShipLogs_Entities();
        }

    }
}
