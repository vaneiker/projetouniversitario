using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class ServicesTypesRepository: BaseRepository
    {
        public ServicesTypesRepository() { }

        #region Set
        public virtual BaseEntity SetServiceType(ServicesTypes.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_SERVICES_TYPES_Result> temp;
            temp = PosContex.SP_SET_SERVICES_TYPES(
                                                    parameter.id,
                                                    parameter.name,
                                                    parameter.servicesTypesToProductLimits,
                                                    parameter.userId
                                                  );
            result = temp.Select(q => new BaseEntity()
            {
                EntityId = q.Id,
                Action = q.Action
            })
            .FirstOrDefault();

            return result;
        }
        #endregion
    }
}
