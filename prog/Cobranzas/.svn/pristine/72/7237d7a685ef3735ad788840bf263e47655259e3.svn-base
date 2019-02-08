using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class ContactPhoneManager : BaseManager, IBaseLogic<ContactPhone>
    {
        private ContactPhoneRepository _contactPhoneRepository;

        public ContactPhoneManager()
        {
            _contactPhoneRepository = SingletonUnitOfWork.Instance.ContactPhoneRepository;
        }

        public ResultLogic<ContactPhone> GetAll(long? entityId = null)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            ResultLogic<ContactPhone> _Result;

            try
            {
                var data = _contactPhoneRepository.GetAll(entityId);
                _Result = new ResultLogic<ContactPhone> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<ContactPhone> {result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public BaseResultLogic<ContactPhone> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public Result Add(ContactPhone entity)
        {
            throw new NotImplementedException();
        }

        public Result Delete(ContactPhone entity)
        {
            throw new NotImplementedException();
        }

        public Result Edit(ContactPhone entity)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Result _Result;

            try
            {
                var data = _contactPhoneRepository.Edit(entity);
                _Result = new Result
                {
                    Action = data.Action,
                    entityId = data.entityId
                };
            }
            catch (Exception ex)
            {
                _Result = new Result(ex, MethodName);
            }

            return
                _Result;
        }
    }
}
