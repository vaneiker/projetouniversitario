using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using KSI.Cobranza.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.DataLayer;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class DataManager : BaseManager, IBaseLogic<DataField>
    {
        private DataManagerRepository _Repository;

        public DataManager()
        {
            _Repository = SingletonUnitOfWork.Instance.DataManagerRepository;
        }

        public Result Add(DataField entity)
        {
            throw new NotImplementedException();
        }

        public Result Delete(DataField entity)
        {
            throw new NotImplementedException();
        }

        public Result Edit(DataField entity)
        {
            throw new NotImplementedException();
        }

        public BaseResultLogic<DataField> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public ResultLogic<DataField> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public ResultLogic<DataFieldGroup> GetDataFieldGroup(long QueueId, int IdMovement)
        {
            ResultLogic<DataFieldGroup> _Result;

            try
            {
                _Result = new ResultLogic<DataFieldGroup>
                {
                    dataResult = _Repository.GetDataFieldGroup(QueueId, IdMovement),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<DataFieldGroup>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public ResultLogic<DataField> GetDataField(long QueueId, int IdFieldGroup, int Sequence = 1)
        {
            ResultLogic<DataField> _Result;

            try
            {
                _Result = new ResultLogic<DataField>
                {
                    dataResult = _Repository.GetDataField(QueueId, IdFieldGroup, Sequence),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<DataField>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result SaveDataField(DataField entity)
        {
            Result _Result;

            try
            {
                _Result = new Result
                {
                    Action = _Repository.SaveDataField(entity).Action,
                    entityId = 0
                };
            }
            catch (Exception ex)
            {
                _Result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return _Result;
        }
    }
}
