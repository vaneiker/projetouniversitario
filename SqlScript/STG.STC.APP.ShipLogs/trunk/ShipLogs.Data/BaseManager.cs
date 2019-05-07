using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Data
{
    public class BaseManager
    {
        public readonly BaseRepository baseRepository;

        public BaseManager()
        {
            baseRepository = new BaseRepository();
        }
    }
}
