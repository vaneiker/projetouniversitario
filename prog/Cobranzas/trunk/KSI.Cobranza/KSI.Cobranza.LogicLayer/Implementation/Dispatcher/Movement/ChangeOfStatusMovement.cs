using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation.Dispatcher
{
    public class ChangeOfStatusMovement : MovementBusinessModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ChangeOfStatusMovement()
        {
            Response = new Response();
        }

        /// <summary>
        /// 
        /// </summary>
        public int QueueTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UserConfirmsStatusChange { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Status CurrentStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Status NextStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Run()
        {
            ExecutionResult = _dispatcherManager.SetQueueStatus(new StatesMovement() {
                QueueId = QueueId,
                IdMovement = MovementEntityModel.IdMovement,
                QueueTypeId = NextStatus.QueueTypeId,
                MovementName = MovementEntityModel.Name,
                StatusName = NextStatus.Name,
                MovementUsr = UserId,
                IdPreviousQueueType = CurrentStatus.QueueTypeId,
                PreviousStatusName = CurrentStatus.Name,
                Comment = string.Empty,
                FinalizedDate = DateTime.Now,
                AssignmentDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreateUsr = UserId,
                Active = true
            });
        }
    }
}
