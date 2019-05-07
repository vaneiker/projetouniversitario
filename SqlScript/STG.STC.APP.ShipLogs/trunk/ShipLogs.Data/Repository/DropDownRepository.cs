using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLogs.Data.EdmxModel;
using ShipLogs.Entity.Entity;

namespace ShipLogs.Data.Repository
{
    public class DropDownRepository : BaseRepository
    {
        public DropDownRepository() { }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_FILL_DROPDOWN_Result> temp;
            temp = ShipLogsContex.SP_FILL_DROPDOWN(DropDownType);
            result = temp.Select(d => new Generic
            {
                id = d.Id,
                Value = d.Name,
                IdAlf = d.IdAlf
            }).ToArray();

            return
                 result;
        }

    }
}
