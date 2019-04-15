using KSI.Cobranza.DataLayer.Interfaces;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class DispatcherRepository : BaseRepository, IBaseRepository<Movement>, IDBOperation<Movement>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public DispatcherRepository(DbContext dbContext) : base(dbContext)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ResultRepository Add(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ResultRepository Delete(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ResultRepository Edit(Movement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movement FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public IEnumerable<Movement> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 27 Feb 2019
        /// Invoque para obtener la lista de movimientos relacionados a un Queue
        /// </summary>
        /// <param name="QueueId">Id del Queue</param>
        /// <returns></returns>
        public IEnumerable<Movement> GetMovement(long QueueId)
        {
            return
                _dbContext.SP_GET_MOVEMENT(null, QueueId)
                .Select(x => new Movement()
                {
                    IdMovement = x.IdMovement,
                    Name = x.Name,
                    Description = x.Description,
                    ModelName = x.ModelName,
                    ControllerName = x.ControllerName,
                    ActionName = x.ActionName,
                    ActionTitle = x.ActionTitle,
                    IframeActionName = x.IframeActionName,
                    AllowChangeStatus = x.AllowChangeStatus,
                    IframeControllerName = x.IframeControllerName,
                    cssClassIcon = x.cssClassIcon,
                    IsLoadedInAnModal = x.IsLoadedInAnModal
                });
        }

        /// <summary>
        /// /// vbarrera | 27 Feb 2019
        /// Invoque para obtener un movimiento en especifico
        /// </summary>
        /// <param name="IdMovement">Id del movimiento</param>
        /// <param name="QueueId">Id del Queue</param>
        /// <returns></returns>
        public Movement GetMovement(int IdMovement)
        {
            return
                _dbContext.SP_GET_MOVEMENT(IdMovement, null)
                .Select(x => new Movement()
                {
                    IdMovement = x.IdMovement,
                    Name = x.Name,
                    Description = x.Description,
                    ModelName = x.ModelName,
                    ControllerName = x.ControllerName,
                    ActionName = x.ActionName,
                    ActionTitle = x.ActionTitle,
                    IframeActionName = x.IframeActionName,
                    AllowChangeStatus = x.AllowChangeStatus,
                    IframeControllerName = x.IframeControllerName,
                    cssClassIcon = x.cssClassIcon,
                    IsLoadedInAnModal = x.IsLoadedInAnModal
                }).FirstOrDefault();
        }

        /// <summary>
        /// vbarrera | 06 ar 2019
        /// Devuelve el estatus en el que se encuentra un queue
        /// Se basa en la tabla [Queue].[QueueTypeId]
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="QueueTypeId"></param>
        /// <returns></returns>
        public Status GetStatus(long QueueId)
        {
            return
                _dbContext.SP_GET_STATUS(QueueId, null)
                .Select(x => new Status()
                {
                    QueueTypeId = x.QueueTypeId,
                    Name = x.Name,
                    QueueTypeDesc = x.QueueTypeDesc,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    IdStage = x.IdStage,
                    StageName = x.StageName,
                    ModelName = x.ModelName
                }).FirstOrDefault();
        }

        /// <summary>
        /// vbarrera | 06 ar 2019
        /// Devuelve un estatus en específico
        /// Se basa en la tabla [Queue].[QueueTypeId]
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="QueueTypeId"></param>
        /// <returns></returns>
        public Status GetStatus(int QueueTypeId)
        {
            return
                _dbContext.SP_GET_STATUS(null, QueueTypeId)
                .Select(x => new Status()
                {
                    QueueTypeId = x.QueueTypeId,
                    Name = x.Name,
                    QueueTypeDesc = x.QueueTypeDesc,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.DepartmentName,
                    IdStage = x.IdStage,
                    StageName = x.StageName,
                    ModelName = x.ModelName
                }).FirstOrDefault();
        }

        /// <summary>
        /// vbarrera | 04 Mar 2019
        /// Devuelve los estados a los que puede ir un queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public IEnumerable<StatusByStatus> GetStatusByStatus(long QueueId)
        {
            return
                _dbContext.SP_GET_STATUS_BY_STATUS(QueueId)
                .Select(x => new StatusByStatus() {
                    QueueTypeId = x.QueueTypeId,
                    DepartmentId = x.DepartmentId,
                    QueueTypeDesc = x.QueueTypeDesc,
                    IdStage = x.IdStage,
                    Name = x.Name,
                    Ruler = x.Ruler,
                    Ordinal = x.Ordinal,
                    ButtonLegend = x.ButtonLegend,
                    IsVisible = x.IsVisible,
                    IconCssClass = x.IconCssClass,
                    ButtonCssClass = x.ButtonCssClass
                });
        }

        /// <summary>
        /// vbarrera | 05 Mar 2019
        /// Devuelve lo requisitos de un movimiento
        /// y su estado de ejecución
        /// </summary>
        /// <param name="QueueId"></param>
        /// <param name="IdMovement"></param>
        /// <returns></returns>
        public IEnumerable<MovementsPrerequisites> GetMovementsPrerequisites(long QueueId, int IdMovement)
        {
            return
                _dbContext.SP_GET_MOVEMENTS_PREREQUISITES(QueueId, IdMovement)
                .Select(x => new MovementsPrerequisites() {
                    IdPrerequisiteMovement = x.IdPrerequisiteMovement,
                    PrerequisiteMovementName = x.PrerequisiteMovementName,
                    Ordinal = x.Ordinal,
                    HelpContent = x.HelpContent,
                    IdExecutionState = x.IdExecutionState,
                    ExecutionStateName = x.ExecutionStateName
                });
        }

        /// <summary>
        /// vbarrera | 07 Mar 2019
        /// Devuelve el listado de movimiento ejecutados para una caso/queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public IEnumerable<MovementsExecution> GetMovementsExecution(long QueueId)
        {
            return
                _dbContext.SP_GET_MOVEMENTS_EXECUTION(QueueId)
                .Select(x => new MovementsExecution() {
                    QueueId = x.QueueId,
                    QueueTypeId = x.QueueTypeId,
                    QueueTypeName = x.QueueTypeName,
                    IdMovement = x.IdMovement,
                    MovementName = x.MovementName,
                    IdExecutionState = x.IdExecutionState,
                    ExecutionStateName = x.ExecutionStateName,
                    ExecutionDate = x.ExecutionDate,
                    UserIdWhoExecutedIt = x.UserIdWhoExecutedIt,
                    UserNameWhoExecutedIt = x.UserNameWhoExecutedIt
                });
        }

        /// <summary>
        /// vbarrera | 05 Mar 2019
        /// Inserta o edita un registro en la bitacora de ejecición de movimientos
        /// Tabla [Dispatcher].[MovementsExecution]
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// NOTA: No retorna ID porque la tabla posee llave compuesta 
        /// y los elementos que componen la llave son enviados como parametros al proceso almacenado
        /// </returns>
        public ResultRepository RegisterLogOfMovementsExecution(MovementsExecution entity)
        {
            return _dbContext.SP_SET_MOVEMENTS_EXECUTION(
                entity.QueueId,
                entity.IdMovement,
                (int)entity.ExecutionState,
                entity.CreateDate,
                entity.CreateUsr,
                entity.ModiDate,
                entity.ModiUsr,
                entity.Active,
                entity.IsDeleted
                )
                .Select(x => new ResultRepository()
                {
                    Action = x.Action,
                    entityId = 0
                })
                .FirstOrDefault();
        }

        /// <summary>
        /// vbarrera | 06 Mar 2019
        /// Cambia de estatus un caso/queue
        /// </summary>
        /// <returns></returns>
        public ResultRepository SetQueueStatus(StatesMovement entity)
        {
            return _dbContext.SP_SET_QUEUE_STATUS(
                entity.QueueId, 
                entity.IdMovement, 
                entity.QueueTypeId, 
                entity.MovementName, 
                entity.StatusName, 
                entity.MovementUsr, 
                entity.IdPreviousQueueType, 
                entity.PreviousStatusName, 
                entity.Comment, 
                entity.IdShortAnswer, 
                entity.FinalizedDate, 
                entity.AssignmentDate, 
                entity.CreateDate, 
                entity.CreateUsr, 
                entity.ModiDate, 
                entity.ModiUsr, 
                entity.Active, 
                entity.IsDeleted)
                .Select(x => new ResultRepository()
                {
                    Action = x.Action,
                    entityId = Convert.ToInt32(x.IdStatesMovement ?? 0)
                })
                .FirstOrDefault();
        }
    }
}
