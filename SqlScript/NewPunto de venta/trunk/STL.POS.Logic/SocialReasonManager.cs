using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class SocialReasonManager : BaseManager
    {
        private readonly SocialReasonRepository socialReasonRepository;
        public SocialReasonManager() { }
        public BaseEntity SetSocialReason(SocialReason.Parameter parameter)
        {
            return
                  SetSocialReason(parameter);
        }
    }
}
