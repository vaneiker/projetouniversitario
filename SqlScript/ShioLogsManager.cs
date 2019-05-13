
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



        public virtual List<CarrierEntity> CarrierLogic(string name)
        {
            var result = shioLogsRepocitory.GetCarrier(name);
            return result;
        }


        public virtual List<CarrierEntity> CarrierLogicDirect()
        {
            var result = shioLogsRepocitory.GetCarrierDirec();
            return result;
        }

        public virtual List<OperatorEntity> GetOperator()
        {
            var result = shioLogsRepocitory.GetOperator();
            return result;
        }

        public virtual Generic Set_Shimet_Logic(ShipmentEntity parameters)
        {
            Generic generic = new Generic();
            try
            {
                if (!parameters.ShipUniqueID.HasValue)
                {
                    parameters.ShipUniqueID = 0;
                }
                parameters.Transit = false;

                var Result = shioLogsRepocitory.Set_Shimet(parameters);

                return Result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                var error = generic.ErrorMenssager = ex.Message.ToString();
                var code = generic.id = ex.GetHashCode();
                return generic;
            }

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

            var obj = int.Parse(param);

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
            var obj = new ShipmentEntity();
            obj.ShipUniqueID = int.Parse(param);
            var dataList = shioLogsRepocitory.IsIncomingVerification(obj);
            return dataList;
        }
    }
}
