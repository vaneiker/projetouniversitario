using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels.Dispatcher
{
    public class CheckPrerequisitesPendingModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MovementsPrerequisites> PrerequisitesPending { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Movement MovementEntityModel { get; set; }
    }
}