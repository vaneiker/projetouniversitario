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
    public class ContactEmailAddressManager : BaseManager, IBaseLogic<ContactEmail>
    {
        private ContactEmailAdressRepository _contactEmailAdressRepository;

        public ContactEmailAddressManager()
        {
            _contactEmailAdressRepository = SingletonUnitOfWork.Instance.ContactEmailAdressRepository;
        }

        public ResultLogic<ContactEmail> GetAll(long? entityId = null)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            ResultLogic<ContactEmail> _Result;

            try
            {
                var data = _contactEmailAdressRepository.GetAll(entityId);
                _Result = new ResultLogic<ContactEmail> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<ContactEmail> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        public BaseResultLogic<ContactEmail> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public Result Add(ContactEmail entity)
        {
            throw new NotImplementedException();
        }

        public Result Delete(ContactEmail entity)
        {
            throw new NotImplementedException();
        }

        public Result Edit(ContactEmail entity)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Result _Result;

            try
            {
                var data = _contactEmailAdressRepository.Edit(entity);
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
