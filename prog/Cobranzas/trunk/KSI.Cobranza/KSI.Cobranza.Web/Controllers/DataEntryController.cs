using KSI.Cobranza.LogicLayer.Implementation;
using KSI.Cobranza.LogicLayer.Implementation.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSI.Cobranza.Web.Controllers
{
    public class DataEntryController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(long QueueId, int IdMovement)
        {
            DataEntryMovement Movement = new DataEntryMovement() {
                QueueId = QueueId,
                MovementEntityModel = new EntityLayer.Movement() { IdMovement = IdMovement },
                UserId = Usuario.UserID
            };

            Movement.Run();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}