using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class BaseManager
    {
        protected Result Result;
        private string MessageErrorFormat;
        private BaseRepository _baseRepository;

        public BaseManager(Result result = null)
        {            
            this.Result = (result == null) ? new Result { HasError = false, ErrorDescription = string.Empty }
                                           : result;
            this._baseRepository = SingletonUnitOfWork.Instance.BaseRepository;
        }
                

        public IEnumerable<DropDown> GetDropDown(string DropDownName)
        {
            return
                 _baseRepository.GetDropDown(DropDownName);
        }
    }
}
