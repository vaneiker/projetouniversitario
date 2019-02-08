using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models;
using KSI.Cobranza.Web.Models.ViewModels;

namespace KSI.Cobranza.Web.Controllers
{
    public class QueueController : BaseController
    {

        private QueueModel _oQueueModel { get; set; }

        public QueueController()
        {
            _oQueueModel = new QueueModel();
        }
        // GET: Queue
        public ActionResult Index()
        {
            var model = _oQueueModel.GetLoansInQueue();
            return View(model);
        }

        public PartialViewResult _QueueData(int? QueueId)
        {
            var model = _oQueueModel.GetLoansInQueue(QueueTypeId: QueueId);

            return
                PartialView(model);
        }

    }
}