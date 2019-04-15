using Jass.Utilities;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer;
using KSI.Cobranza.LogicLayer.Implementation;
using KSI.Cobranza.LogicLayer.Implementation.Dispatcher;
using KSI.Cobranza.LogicLayer.Implementation.Dispatcher.Common;
using KSI.Cobranza.LogicLayer.Interface;
using KSI.Cobranza.Web.Models.ViewModels.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Controllers
{
    public class DispatcherController : BaseController
    {
        #region Fields
        /// <summary>
        /// vbarrera | 8 Feb 2019
        /// Le concede a este controlador acceso a la data
        /// </summary>
        DispatcherManager _dataManager = new DispatcherManager();
        #endregion

        /// <summary>
        /// vbarrera | 04 Mar 2019
        /// Invoca la vista parcial de gestión y control de movimientos
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public ActionResult Index(long QueueId)
        {
            ViewBag.QueueId = QueueId;
            return PartialView(_dataManager.GetMovement(QueueId));
        }

        /// <summary>
        /// vbarrera | 04 Mar 2019
        /// Este metodo se encarga de abrir un movimiento. 
        /// El movimiento puede ser abierto de dos maneras:
        /// 1 - Por medio de una ventana modal
        /// 2 - Por medio de un tab nuevo en el navegador
        /// </summary>
        /// <param name="QueueId">Id del caso</param>
        /// <param name="IdMovement">Id del movimiento que se va a levantar</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoadMovement(long QueueId, int IdMovement, int Secuence = 1)
        {
            Movement dataModelMovement 
                = _dataManager.GetMovement(IdMovement)?.SingleResult;

            MovementBusinessModel businessModelMovement = null;

            if (dataModelMovement == null)
                throw new Exception(
                    string.Format("IdMovement {0} not found", IdMovement));

            if (dataModelMovement?.IsLoadedInAnModal ?? true)
            {
                businessModelMovement = dataModelMovement?.ModelName?.GetInstance() as MovementBusinessModel;

                if (businessModelMovement == null)
                    throw new Exception(
                        string.Format("There is no defined model for movement {0}", dataModelMovement.Name));

                businessModelMovement.QueueId = QueueId;
                businessModelMovement.MovementEntityModel = dataModelMovement;
                businessModelMovement.UserId = Usuario.UserID;
                //businessModelMovement.se

                businessModelMovement.Initialize();

                return PartialView(
                    string.Format("~/Views/{0}/{1}.cshtml", 
                    dataModelMovement.ControllerName, dataModelMovement.ActionName), businessModelMovement);
            }

            return Json(dataModelMovement, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// vbarrera | 07 Mar 2019
        /// Devuelve la vista que contiene el grid de ejecucion de movimiento para un caso/queue
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public ActionResult MovementsExecutionGrid(long QueueId)
        {
            ResultLogic<MovementsExecution> result
                = _dataManager.GetMovementsExecution(QueueId);

            if (result.result.HasError)
                throw new Exception(result.result.ErrorDescription);

            return PartialView(result.dataResult.ToList());
        }

        /// <summary>
        /// vbarrera | 04 Mar 2019
        /// Este metodo se encarga de colocar el footer en el movimiento
        /// En el se delegan tareas como colocar los botones de movimiento de estado etc.
        /// </summary>
        /// <param name="QueueId"></param>
        /// <returns></returns>
        public ActionResult Footer(long QueueId)
        {
            ResultLogic<StatusByStatus> result 
                = _dataManager.GetStatusByStatus(QueueId);

            if (result.result.HasError)
                throw new Exception(result.result.ErrorDescription);

            return PartialView(result.dataResult.ToList());
        }

        /// <summary>
        /// vbarrera | 05 Mar 2019
        /// Devuelve lo requisitos de un movimiento
        /// y su estado de ejecución
        /// </summary>
        /// <param name="IdQuotation"></param>
        /// <param name="SelectedMovement"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckPrerequisitesPending(int QueueId, int IdMovement)
        {
            ResultLogic<MovementsPrerequisites> MovementsPrerequisitesDataResult
                = _dataManager.GetMovementsPrerequisites(QueueId, IdMovement);

            if (MovementsPrerequisitesDataResult.result.HasError)
                throw new Exception(MovementsPrerequisitesDataResult.result.ErrorDescription);

            ResultLogic<Movement> MovementEntityModelDataResult
                = _dataManager.GetMovement(IdMovement);

            if (MovementEntityModelDataResult.result.HasError)
                throw new Exception(MovementEntityModelDataResult.result.ErrorDescription);

            return Json(new CheckPrerequisitesPendingModel()
            {
                PrerequisitesPending = MovementsPrerequisitesDataResult.dataResult.Where(
                    x => x.IdExecutionState != 1 // << -- Total Execution
                    ).ToList(),
                MovementEntityModel = MovementEntityModelDataResult.SingleResult
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// vbarrera | 06 Mar 2019
        /// Cambia de estatus un caso
        /// </summary>
        /// <param name="changeOfStatusMovement"></param>
        /// <returns></returns>
        public ActionResult ChangeEstatus(ChangeOfStatusMovement changeOfStatusMovement)
        {
            ResultLogic<Movement> movementDataResult 
                = _dataManager.GetMovement(changeOfStatusMovement.MovementEntityModel.IdMovement);
            ResultLogic<Status> currentStateDataResult
                = _dataManager.GetStatus(changeOfStatusMovement.QueueId);
            ResultLogic<Status> nextStateDataResult
                = _dataManager.GetStatus(changeOfStatusMovement.QueueTypeId);

            if (movementDataResult.result.HasError)
                throw new Exception(movementDataResult.result.ErrorDescription);
            if(currentStateDataResult.result.HasError)
                throw new Exception(currentStateDataResult.result.ErrorDescription);
            if (nextStateDataResult.result.HasError)
                throw new Exception(nextStateDataResult.result.ErrorDescription);

            changeOfStatusMovement.UserId = Usuario.UserID;
            changeOfStatusMovement.MovementEntityModel = movementDataResult.SingleResult;
            changeOfStatusMovement.CurrentStatus = currentStateDataResult.SingleResult;
            changeOfStatusMovement.NextStatus = nextStateDataResult.SingleResult;

            IValidationRuleBusinessModel ValidationRule_CurrentStatus
                = changeOfStatusMovement.CurrentStatus.ModelName.GetInstance() as IValidationRuleBusinessModel;

            IValidationRuleBusinessModel ValidationRule_NextStatus
                = changeOfStatusMovement.NextStatus.ModelName.GetInstance() as IValidationRuleBusinessModel;

            if (ValidationRule_CurrentStatus == null)
                throw new Exception("An instance of the ValidationRule_CurrentState object could not be created");

            if (ValidationRule_NextStatus == null)
                throw new Exception("An instance of the ValidationRule_NextState object could not be created");

            ValidationRule_CurrentStatus.QueueId = changeOfStatusMovement.QueueId;
            ValidationRule_NextStatus.QueueId = changeOfStatusMovement.QueueId;

            ValidationRule_CurrentStatus.PostValidate();
            ValidationRule_NextStatus.PreValidate();

            changeOfStatusMovement.Response = ValidationRule_CurrentStatus.Response;
            changeOfStatusMovement.Response.MergeResponse(ValidationRule_NextStatus.Response);

            if(changeOfStatusMovement.Response.State && changeOfStatusMovement.UserConfirmsStatusChange)
            {
                ValidationRule_NextStatus.ExcuteInitialTask();
                changeOfStatusMovement.Run();

                if (changeOfStatusMovement.ExecutionResult.HasError)
                    throw new Exception(changeOfStatusMovement.ExecutionResult.ErrorDescription);
            }

            return Json(changeOfStatusMovement, JsonRequestBehavior.AllowGet);
        }
    }
}