
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
        public virtual int Set_ShimetDetailsInsert_Logic(List<ShipmentDetailEntity> parameters)
        {
            var insertar = new ShipmentDetailEntity();

            try
            {
                foreach (var d in parameters)
                {
                    insertar.ShipUniqueID = d.ShipUniqueID;
                    insertar.AssignedTo = d.AssignedTo;
                    insertar.ItemDetail = d.ItemDetail;
                    insertar.DetailUniqueID = d.DetailUniqueID;

                    shioLogsRepocitory.Set_Shimet_DetailsSave(insertar);
                }
            }
            catch (Exception ex)
            {
                return 0;

            }
            return 1;
        }


        public virtual int Set_ShimetDetailsInsert_Logic(ShipmentDetailEntity parameters)
        {
            var insertar = new ShipmentDetailEntity();

            try
            {
                insertar.ShipUniqueID = parameters.ShipUniqueID;
                insertar.AssignedTo = parameters.AssignedTo;
                insertar.ItemDetail = parameters.ItemDetail;
                insertar.DetailUniqueID = parameters.DetailUniqueID;

                shioLogsRepocitory.Set_Shimet_DetailsSave(insertar);

            }
            catch (Exception ex)
            {
                return 0;

            }
            return 1;
        }
        public virtual int Set_ShimetDetailsDelete_Logic(int parameters)
        {
            var insertar = new ShipmentDetailEntity();

            try
            {

                shioLogsRepocitory.Set_Shimet_DetailsDelete(parameters);

            }
            catch (Exception ex)
            {
                return 0;

            }
            return 1;
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

        public virtual IEnumerable<ShipmentEntity> GET_Shimet_Logic_All()
        {
            return

              shioLogsRepocitory.GET_ShimetAll();
        }
        public virtual ShipmentEntityViewModel.ShipmentEntity Method_Outgoing(string param)
        {

            var obj = int.Parse(param);

            var dataList = shioLogsRepocitory.GET_Obtain_Shimet_Outgoing(obj);
            return dataList;
        }
        public virtual ShipmentEntityViewModel.ShipmentEntity Method_Incoming(string param)
        {
            int paramet = 0;
            if (param == "" || param == null)
            {
                paramet =0;
            }
            else
            {
                paramet = int.Parse(param);
            }

            var dataList = shioLogsRepocitory.GET_Obtain_Shimet_Incoming(paramet);
            return dataList;
        }
        public virtual ShipmentEntityViewModel.ShipmentEntity IsIncomingVerificationLog(string id)
        {
            var obj = new ShipmentEntityViewModel.ShipmentEntity();
            obj.ShipUniqueID = int.Parse(id);
            var dataList = shioLogsRepocitory.IsIncomingVerification(obj);
            return dataList;
        }

        public virtual List<ShipmentEntityViewModel.detail> GET_SHIPMENTDETAILSLog(string id)
        {
            var idNumeric = int.Parse(id);
            return shioLogsRepocitory.GET_SHIPMENTDETAILS(idNumeric);
        }

    }
}
