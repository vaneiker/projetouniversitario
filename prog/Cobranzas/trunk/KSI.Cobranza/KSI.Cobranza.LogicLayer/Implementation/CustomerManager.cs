using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.LogicLayer.Interface;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.LogicLayer;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class CustomerManager : BaseManager, IBaseLogic<Customer>
    {
        private CustomerRepository _customerRepository;

        public CustomerManager()
        {
            _customerRepository = SingletonUnitOfWork.Instance.CustomerRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultLogic<Customer> GetAll(long? entityId = null)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            ResultLogic<Customer> _Result;

            try
            {
                var data = _customerRepository.GetAll();
                _Result = new ResultLogic<Customer> { dataResult = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Customer> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseResultLogic<Customer> FindById(long? Id)
        {
            var MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            BaseResultLogic<Customer> _Result;

            try
            {
                var data = _customerRepository.FindById(Id);
                _Result = new BaseResultLogic<Customer> { entity = data, result = new Result(null, null) };
            }
            catch (Exception ex)
            {
                _Result = new BaseResultLogic<Customer> { result = new Result(ex, MethodName) };
            }

            return
                _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

    }
}
