using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Interface
{
    public interface IValidationRuleBusinessModel
    {
        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// LLave primaria del caso/queue
        /// </summary>
        long QueueId { get; set; }

        /// <summary>
        /// vbarrera | 08 Mar 2019
        /// Objeto de respuesta de la regla de validación
        /// </summary>
        Response Response { get; set; }

        /// <summary>
        /// vbarrera | 26/Mar/2018
        /// Implemente este metodo para ejecutar tareas iniciales
        /// al estado actual
        /// </summary>
        void ExcuteInitialTask();

        /// <summary>
        /// vbarrera | 26/Mar/2018
        /// Coloque aqui las validaciones que se realizaran 
        /// cuando esta interface es implementada como siguiente estatus
        /// </summary>
        /// <returns></returns>
        void PreValidate();

        /// <summary>
        /// vbarrera | 26/Mar/2018
        /// Coloque aqui las validaciones que se realizaran 
        /// cuando esta interface es implementada como estatus actual
        /// </summary>
        /// <returns></returns>
        void PostValidate();
    }
}
