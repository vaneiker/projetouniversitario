using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    public abstract class ValidationBusinessModel: IValidationRuleBusinessModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ValidationBusinessModel()
        {
            Response = new Response();
        }

        /// <summary>
        /// 
        /// </summary>
        public long QueueId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract void ExcuteInitialTask();

        /// <summary>
        /// 
        /// </summary>
        public abstract void PostValidate();

        /// <summary>
        /// 
        /// </summary>
        public abstract void PreValidate();
    }
}
