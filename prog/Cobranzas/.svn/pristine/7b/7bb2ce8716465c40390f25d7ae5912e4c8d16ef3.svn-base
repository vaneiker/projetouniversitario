using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    public abstract class MovementBusinessModel : IMovementBusinessModel
    {
        #region Fields
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// Le concede a este movimiento acceso a los datos relacionados
        /// al componente Dispatcher
        /// </summary>
        protected DispatcherManager _dispatcherManager = new DispatcherManager();
        #endregion

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// LLave primaria del caso/queue
        /// </summary>
        public long QueueId { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Instancia modelo de datos del movimiento
        /// </summary>
        public Movement MovementEntityModel { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Id del usario autenticado en la aplicacion
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// vbarrera | 13 Mar 2019
        /// Puede utilizar esta propiedad para capturar el resultado de ejecución de la función [Run()]
        /// </summary>
        public Result ExecutionResult { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// En este metodo se realizan las tareas necesarias 
        /// para que se de por completada la ejecución del movimiento
        /// </summary>
        public virtual void Run()
        {
            Register();
        }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// En este metodo se hacen todas las inicializaciones necesarias
        /// para que el movimiento pueda ejecutarse
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// vbarrera | 01 Mar 2019
        /// En metodo se registra la ejecución del movimiento
        /// </summary>
        public virtual void Register()
        {
            _dispatcherManager.RegisterLogOfMovementsExecution(new MovementsExecution() {
                QueueId = QueueId,
                IdMovement = MovementEntityModel.IdMovement,
                ExecutionState = MovementsExecution.ExecutionStates.TotalExecution,
                CreateDate = DateTime.Now,
                CreateUsr = UserId,
                ModiDate = DateTime.Now,
                ModiUsr = UserId,
                Active = true,
                IsDeleted = false
            });
        }
    }
}
