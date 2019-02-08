using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class ServicesTypesRepositoryManager : BaseManager
    {
        private readonly ServicesTypesRepository servicesTypesRepository;

        public ServicesTypesRepositoryManager()
        {
            servicesTypesRepository = new ServicesTypesRepository();
        }

        public virtual BaseEntity SetServiceType(ServicesTypes.Parameter parameter)
        {
            return
                 servicesTypesRepository.SetServiceType(parameter);

        }
    }
}
