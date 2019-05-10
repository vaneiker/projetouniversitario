
using ShipLogs.Data.Repository;
using ShipLogs.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Logic.LogicBL
{
    public class ShioLogsManager : BaseManager
    {
        private readonly ShioLogsRepocitory shioLogsRepocitory;

        public ShioLogsManager()
        {
            shioLogsRepocitory = new ShioLogsRepocitory();
        }

       

        public virtual Generic Set_Shimet_Logic(ShipmentEntity parameters)
        {
            //var modelconv = new ShipmentEntity();
            //modelconv.Incoming = parameters.Incoming;

            var Result = shioLogsRepocitory.Set_Shimet(parameters);

            return Result.FirstOrDefault();
        }
        public virtual int Set_ShimetDetailsInsert_Logic(ShipmentDetailEntity parameters)
        {
            return

                shioLogsRepocitory.Set_Shimet_DetailsSave(parameters);

        }
        public virtual int Set_ShimetDetailsUpdate_Logic(ShipmentDetailEntity parameters)
        {
            return

                shioLogsRepocitory.Set_Shimet_DetailsUpdate(parameters);
        }
        public virtual IEnumerable<ShipmentEntity> GET_Shimet_Logic(String parameters)
        {
            return

              shioLogsRepocitory.GET_Shimet(parameters);
        }

        public virtual IEnumerable<ShipmentViewModel> GET_Shimet_Logic_All()
        {
            return

              shioLogsRepocitory.GET_ShimetAll();
        }


        public virtual ShipmentEntity Method_Outgoing(string param)
        {
           
           var obj= int.Parse(param);

            var dataList = shioLogsRepocitory.GET_Obtain_Shimet_Outgoing(obj);
            return dataList;
        }
        public virtual IEnumerable<ShipmentViewModel> Method_Incoming(string param)
        {
            var obj = new ShipmentViewModel();
            obj.ShipUniqueID = int.Parse(param);
             
            var dataList = shioLogsRepocitory.GET_Obtain_Shimet_Incoming(obj);
            return dataList;
        }
        public virtual ShipmentEntity IsIncomingVerificationLog(string param)
        {
            var obj = new ShipmentViewModel();
            obj.ShipUniqueID = int.Parse(param);
            var dataList = shioLogsRepocitory.IsIncomingVerification(obj);
            return dataList;
        }
    }
}
