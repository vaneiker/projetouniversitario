using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class IdentificationFinalBeneficiaryManager: BaseManager
    {
        private readonly IdentificationFinalBeneficiaryRepository identificationFinalBeneficiaryRepository;

        public IdentificationFinalBeneficiaryManager()
        {
            identificationFinalBeneficiaryRepository = new IdentificationFinalBeneficiaryRepository();
        }

    }
}
