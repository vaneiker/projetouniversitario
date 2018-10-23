using Entity.Entities;
using STL.CALLBACK.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.CALLBACK.Logic
{

    public class DropDownManager : BaseManager
    {
        private readonly DropDownRepository dropDownRepository;
        public DropDownManager()
        {
            dropDownRepository = new DropDownRepository();
        }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            return
                dropDownRepository.GetDropDown(DropDownType);
        }

        public Generic GetParameter(string parameterName)
        {
            return
                dropDownRepository.GetParameter(parameterName);
        }
    }
}
