using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipLogs.Data.EF_MODEL;
using ShipLogs.Entity.Entity;

namespace ShipLogs.Data
{
    public class DropDownRepository : BaseRepository
    {
        public DropDownRepository() { }

        /// <summary>
        /// Generic DropDown
        /// </summary>
        /// <param name="DropDownType">Resive un parametro</param>
        /// <returns>Retorna el resultado de los DropDown</returns>
        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_FILL_DROPDOWN_Result> temp;
            temp = ShipLogsManagementContex.SP_FILL_DROPDOWN(DropDownType);         
            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Name,
                IdAlf = d.IdAlf
            }).ToArray();

            return
                 result;
        } 
    }

}
