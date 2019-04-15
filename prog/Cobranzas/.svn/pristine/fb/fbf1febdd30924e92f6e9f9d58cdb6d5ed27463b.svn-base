using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class MovementsExecution
    {
        #region Input and output properties
        public long QueueId { get; set; }
        public int QueueTypeId { get; set; }
        public int IdMovement { get; set; }
        #endregion

        #region Output properties
        public string QueueTypeName { get; set; }
        public string MovementName { get; set; }
        public int IdExecutionState { get; set; }
        public string ExecutionStateName { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        public int UserIdWhoExecutedIt { get; set; }
        public string UserNameWhoExecutedIt { get; set; }
        #endregion

        #region Input properties
        public ExecutionStates ExecutionState { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUsr { get; set; }
        public DateTime? ModiDate { get; set; }
        public int? ModiUsr { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        public enum ExecutionStates
        {
            NotExecuted = 0,
            TotalExecution = 1,
            PartialExecution = 2
        }
    }
}
