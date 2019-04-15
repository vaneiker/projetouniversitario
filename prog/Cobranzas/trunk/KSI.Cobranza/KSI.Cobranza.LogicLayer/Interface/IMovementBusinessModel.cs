using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Interface
{
    public interface IMovementBusinessModel
    {
        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// LLave primaria del caso/queue
        /// </summary>
        long QueueId { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Instancia modelo de datos del movimiento
        /// </summary>
        Movement MovementEntityModel { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Id del usario autenticado en la aplicacion
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Resultado de la ejecucion del movimiento
        /// </summary>
        Result ExecutionResult { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// En este metodo se hacen todas las inicializaciones necesarias
        /// para que el movimiento pueda ejecutarse
        /// </summary>
        void Initialize();

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// En este metodo se realizan las tareas necesarias 
        /// para que se de por completada la ejecución del movimiento
        /// </summary>
        void Run();

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// En metodo se registra la ejecución del movimiento
        /// </summary>
        void Register();
    }
}
