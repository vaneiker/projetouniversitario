using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AccesData;
using Entity.Global_Entity;

namespace LogicNegocio.Global_Logica
{
    public class VendorLogic
    {
        VendorData Metodos = new VendorData();

        public IEnumerable<VendorEntity> ListadoVendorLogica()
        {
            return Metodos.GetVendors();
        }

        public VendorEntity ObtenerVendorLogica(int id)
        {
            var IntancesVendorEntity = new VendorEntity();
            IntancesVendorEntity.AgentId = id;
            if (id <= 0)
            {
                return null;
            }
            else
            {
                var respuesta = Metodos.ObtenerVendor(IntancesVendorEntity);
                if (respuesta == null)
                {
                    return null;
                }
                else
                {
                    return respuesta;
                }
            }
        }

        public bool SaveVendor(VendorEntitySave entity)
        {
            VendorEntitySave ent = new VendorEntitySave();


            ent.AgentId = entity.AgentId;
            ent.NoCommission = entity.NoCommission;
            ent.TakeVendorId = entity.TakeVendorId;
            ent.VendorId = entity.VendorId;
            ent.AgentStatus = entity.AgentStatus;
            ent.CreateDate = entity.CreateDate;
            ent.ModiDate = entity.ModiDate;
            ent.CreateUsrId = entity.CreateUsrId;
            ent.ModiUsrId = entity.ModiUsrId;
            ent.Hostname = entity.Hostname;
            Metodos.SaveData(ent);

            return true;
        }

    }
}
