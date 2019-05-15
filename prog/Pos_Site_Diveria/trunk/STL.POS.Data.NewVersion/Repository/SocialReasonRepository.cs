using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class SocialReasonRepository: BaseRepository
    {
        public SocialReasonRepository() { }

        #region Set
        public virtual BaseEntity SetSocialReason(SocialReason.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_SOCIAL_REASON_Result> temp;
            temp = PosContex.SP_SET_SOCIAL_REASON(
                                                    parameter.id,
                                                    parameter.description,
                                                    parameter.status,
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

        #region Get

        #endregion
    }
}
