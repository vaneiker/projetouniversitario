using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class PepFormularyManager
    {
        private readonly PepFormularyRepository pepFormularyRepository;

        public PepFormularyManager()
        {
            pepFormularyRepository = new PepFormularyRepository();
        }

        #region Set
        public BaseEntity SetPepFormulary(PepFormulary.Parameter parameter)
        {
            return pepFormularyRepository.SetPepFormulary(parameter);
        }

        #endregion
    }
}
