using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace STL.CALLBACK.Data.Repository
{
    public class CallBackRepository : BaseRepository
    {
        public CallBackRepository() { }

        public virtual int SetCallBack(Entity.Entities.Callback parameter)
        {
            ObjectResult<Nullable<int>> temp;
            int result = 0;
            temp = PosContex.SP_SET_CALL_BACK_LOG(
                parameter.FirstNames,
                parameter.LastNames, 
                parameter.PhoneType.GetValueOrDefault(),
                parameter.NumToCall,
                parameter.Reference
            );

            result = 1;

            return
                result;
        }
    }
}
