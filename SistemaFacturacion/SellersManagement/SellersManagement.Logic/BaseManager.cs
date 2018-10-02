using SellersManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Logic
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
