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
    public class DispatcherManager : BaseManager, IBaseLogic<Movement>
    {
        private DispatcherRepository _Repository;

        public DispatcherManager()
        {
            _Repository = SingletonUnitOfWork.Instance.DispatcherRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Add(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Delete(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Edit(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseResultLogic<Movement> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public ResultLogic<Movement> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 27 Feb 2019
        /// Invoque para obtener la lista de movimientos
        /// relacionados a un queue (QueueId)
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <returns></returns>
        public ResultLogic<Movement> GetMovement(long QueueId)
        {
            ResultLogic<Movement> _Result;

            try
            {
                _Result = new ResultLogic<Movement>
                {
                    dataResult = _Repository.GetMovement(QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Movement>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un movimiento en especifico
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <param name="IdMovement">Id del movimiento</param>
        /// <returns></returns>
        public ResultLogic<Movement> GetMovement(int IdMovement)
        {
            ResultLogic<Movement> _Result;

            try
            {
                _Result = new ResultLogic<Movement>
                {
                    SingleResult = _Repository.GetMovement(IdMovement),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Movement>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 06 ar 2019
        /// Devuelve el estatus en el que se encuentra un queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="QueueTypeId"></param>
        /// <returns></returns>
        public ResultLogic<Status> GetStatus(long QueueId)
        {
            ResultLogic<Status> _Result;

            try
            {
                _Result = new ResultLogic<Status>
                {
                    SingleResult = _Repository.GetStatus(QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Status>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 06 ar 2019
        /// Devuelve un estatus en específico
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="QueueTypeId"></param>
        /// <returns></returns>
        public ResultLogic<Status> GetStatus(int QueueTypeId)
        {
            ResultLogic<Status> _Result;

            try
            {
                _Result = new ResultLogic<Status>
                {
                    SingleResult = _Repository.GetStatus(QueueTypeId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Status>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 04 Mar 2019
        /// Devuelve los estados a los que puede ir un queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public ResultLogic<StatusByStatus> GetStatusByStatus(long QueueId)
        {
            ResultLogic<StatusByStatus> _Result;

            try
            {
                _Result = new ResultLogic<StatusByStatus>
                {
                    dataResult = _Repository.GetStatusByStatus(QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<StatusByStatus>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 05 Mar 2019
        /// Devuelve lo requisitos de un movimiento
        /// y su estado de ejecución
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public ResultLogic<MovementsPrerequisites> GetMovementsPrerequisites(long QueueId, int IdMovement)
        {
            ResultLogic<MovementsPrerequisites> _Result;

            try
            {
                _Result = new ResultLogic<MovementsPrerequisites>
                {
                    dataResult = _Repository.GetMovementsPrerequisites(QueueId, IdMovement),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<MovementsPrerequisites>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 07 Mar 2019
        /// Devuelve el listado de movimiento ejecutados para una caso/queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public ResultLogic<MovementsExecution> GetMovementsExecution(long QueueId)
        {
            ResultLogic<MovementsExecution> _Result;

            try
            {
                _Result = new ResultLogic<MovementsExecution>
                {
                    dataResult = _Repository.GetMovementsExecution(QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<MovementsExecution>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 26 Feb 2019
        /// Inserta o edita un registro en la bitacora de ejecición de movimientos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result RegisterLogOfMovementsExecution(MovementsExecution entity)
        {
            Result _Result;

            try
            {
                _Result = new Result
                {
                    Action = _Repository.RegisterLogOfMovementsExecution(entity).Action,
                    entityId = 0
                };
            }
            catch (Exception ex)
            {
                _Result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 06 Mar 2019
        /// Cambia de estatus un caso/queue
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result SetQueueStatus(StatesMovement entity)
        {
            Result _Result;

            try
            {
                ResultRepository resultRepository 
                    = _Repository.SetQueueStatus(entity);

                _Result = new Result
                {
                    Action = resultRepository.Action,
                    entityId = resultRepository.entityId
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
