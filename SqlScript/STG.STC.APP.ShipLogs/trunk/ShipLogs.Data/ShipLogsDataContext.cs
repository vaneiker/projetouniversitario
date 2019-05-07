using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLogs.Data.EdmxModel;

namespace ShipLogs.Data
{
    public class ShipLogsDataContext
    {
        public ShipLogsDataContext(string ConnStr = "") { }

        private ShipLogs_Entities _ShipLogsContex;

        public ShipLogs_Entities ShipLogsContex
        {
            get
            {
                return _ShipLogsContex ?? new ShipLogs_Entities();
            }
        }

    }
}
