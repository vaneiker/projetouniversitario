using Entity.Entities;
using STL.CALLBACK.Data.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.CALLBACK.Data.Repository
{
    public class DropDownRepository: BaseRepository
    {
        public DropDownRepository() { }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_FILL_DROP_DOWN_Result> temp;
            temp = PosContex.SP_FILL_DROP_DOWN(DropDownType);
            result = temp.Select(d => new Generic
            {
                Value = d.id,
                name = d.name
            }).ToArray();

            return
                 result;
        }

        public Generic GetParameter(string parameterName)
        {
            Generic result;
            IEnumerable<SP_GET_PARAMETERS_Result> temp;
            temp = PosContex.SP_GET_PARAMETERS(parameterName);

            result = temp.Select(q => new Generic()
            {
                Value = q.Value,
                name = q.Name
            }).FirstOrDefault();

            return
                result;
        }

    }
}
