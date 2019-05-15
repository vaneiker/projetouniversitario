using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using STL.POS.Frontend.Web.Areas.Auto.Controllers;
using System.IO;
using STL.POS.THProxy;
using STL.POS.WsProxy;
using STL.POS.WsProxy.WSSysFlexVehicleService;

namespace STL.POS.Frontend.Web.Controllers
{
    public class AlertsController : ApiController
    {

        [AllowAnonymous]
        public void Get()
        {

            var dataAccess = new PosModel();
            var thunderHeadProxy = new THProxy.THProxy();
            var coreProxy = new CoreProxy(new  STL.POS.WsProxy.SysflexService.SysFlexServiceClient());
            var autoController = new PoSAutoController(dataAccess, coreProxy, null, thunderHeadProxy, null, null);


            //Get quotations next to 15 days

            var quotsFifteen = (from q in dataAccess.Quotations.OfType<QuotationAuto>().Include("Drivers.Nationality")
                  .Include("VehicleProducts.VehicleModel")
                  .Include("VehicleProducts.ProductLimits")
                                where SqlFunctions.DateDiff("day", DateTime.Now, SqlFunctions.DateAdd("day", 30, q.Created)) == 15
                                && q.Status == QuotationStatus.InProgress
                                select q
                   );
            //TODO: check this code with the changes in report generation with Thunderhead
            //foreach (QuotationAuto quotation in quotsFifteen)
            //{
            //    var pdf = autoController.GetReportQuotation(quotation);
            //    var physicalPath = autoController.GetThPhysicalPath(quotation.QuotationNumber);
            //    autoController.WriteByteArrayToFile(physicalPath, pdf);
            //    try
            //    {
            //        thunderHeadProxy.SendQuotation15DaysWarning(quotation, physicalPath);
            //    }
            //    catch (Exception ex)
            //    {
            //        //No action taken
            //    }
            //}

            //Get quotations next to 5 days
            var quotsFive = (from q in dataAccess.Quotations.OfType<QuotationAuto>().Include("Drivers.Nationality")
                  .Include("VehicleProducts.VehicleModel")
                  .Include("VehicleProducts.ProductLimits")
                             where SqlFunctions.DateDiff("day", DateTime.Now, SqlFunctions.DateAdd("day", 30, q.Created)) == 5
                             && q.Status == QuotationStatus.InProgress
                             select q
                   );

            foreach (QuotationAuto quotation in quotsFive)
            {
                //TODO: check this code with the changes in report generation with Thunderhead
                //var pdf = autoController.GetReportQuotation(quotation);
                //var physicalPath = autoController.GetThPhysicalPath(quotation.QuotationNumber);
                //autoController.WriteByteArrayToFile(physicalPath, pdf);
                //try
                //{
                //    thunderHeadProxy.SendQuotation5DaysWarning(quotation, physicalPath);
                //}
                //catch (Exception ex)
                //{
                //    //No action taken
                //}
            }




        }

    }
}
