using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EF_MODEL;
using Entity.Global_Entity;
namespace Data.AccesData
{
    public class VendorData :IData
    {
        public void DeleteStudent(int agentId)
        {
            throw new NotImplementedException();
        }

        public VendorEntitySave GetStudentByID(int agentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendorEntitySave> GetVendor()
        {
            throw new NotImplementedException();
        }
        #region metodos
        public IEnumerable<VendorEntity> GetVendors()
        {
            var result = new List<VendorEntity>();

            using (var ctx = new GlobalEntities())
            {
                var entryPoint = (
                                 from vendor in ctx.VIEW_GET_VENDOR

                                 where //vendor.Agent_Id == entity.AgentId &&
                                       vendor.Agent_Status == true
                                 select new VendorEntity
                                 {
                                     CorpId = vendor.Corp_Id,
                                     AgentId = vendor.Agent_Id,
                                     NoCommission = vendor.No_Commission,
                                     TakeVendorId = vendor.Take_Vendor_Id,
                                     VendorId = vendor.Vendor_Id,
                                     AgentStatus = vendor.Agent_Status,
                                     CreateDate = vendor.Create_Date,
                                     ModiDate = vendor.Modi_Date,
                                     CreateUsrId = vendor.Create_UsrId,
                                     ModiUsrId = vendor.Modi_UsrId,
                                     Full_Name = vendor.Full_Name
                                 }).Take(5);

                result = entryPoint.ToList();
                //result = ctx.EN_AGENT_GP_COMMISSION
                //          .Where(x => x.Agent_Status == true)
                //          .OrderBy(x => x.Agent_Id)
                //          .Select(x => new VendorEntity
                //          {
                //              CorpId = x.Corp_Id,
                //              AgentId = x.Agent_Id,
                //              NoCommission = x.No_Commission,
                //              TakeVendorId = x.Take_Vendor_Id,
                //              VendorId = x.Vendor_Id,
                //              AgentStatus = x.Agent_Status,
                //              CreateDate = x.Create_Date,
                //              ModiDate = x.Modi_Date,
                //              CreateUsrId = x.Create_UsrId,
                //              ModiUsrId = x.Modi_UsrId,
                //              Hostname = x.Hostname,


                //          }).ToList();
            }
            return result;

        }

        public void Insert(VendorEntity.vendorEn en)
        {           
            using (var _ctx = new GlobalEntities()) 
            {
                //_ctx.EN_AGENT_GP_COMMISSION.Add(en);
            }
                
        }

        public VendorEntity ObtenerVendor(VendorEntity entity)
        {

            var result = new VendorEntity();
            using (var ctx = new GlobalEntities())
            {
                var entryPoint = (
                                  from vendor in ctx.VIEW_GET_VENDOR
                                  where vendor.Agent_Id == entity.AgentId || vendor.Vendor_Id == entity.VendorId
                                  select new VendorEntity
                                  {
                                      CorpId = vendor.Corp_Id,
                                      AgentId = vendor.Agent_Id,
                                      NoCommission = vendor.No_Commission,
                                      TakeVendorId = vendor.Take_Vendor_Id,
                                      VendorId = vendor.Vendor_Id,
                                      AgentStatus = vendor.Agent_Status,
                                      CreateDate = vendor.Create_Date,
                                      ModiDate = vendor.Modi_Date,
                                      CreateUsrId = vendor.Create_UsrId,
                                      ModiUsrId = vendor.Modi_UsrId,
                                      Full_Name = vendor.Full_Name
                                  }).FirstOrDefault();
                result = entryPoint;

                //result = ctx.EN_AGENT_GP_COMMISSION
                //          .Where(x => x.Agent_Id == entity.AgentId && x.Agent_Status == true)
                //          .Select(x => new VendorEntity
                //          {
                //              CorpId = x.Corp_Id,
                //              AgentId = x.Agent_Id,
                //              NoCommission = x.No_Commission,
                //              TakeVendorId = x.Take_Vendor_Id,
                //              VendorId = x.Vendor_Id,
                //              AgentStatus = x.Agent_Status,
                //              CreateDate = x.Create_Date,
                //              ModiDate = x.Modi_Date,
                //              CreateUsrId = x.Create_UsrId,
                //              ModiUsrId = x.Modi_UsrId,
                //              Hostname = x.Hostname
                //          }).FirstOrDefault();
            }
            return result;
        }

        public void Save()
        {
             
        }

        public void SaveData(VendorEntitySave entity)
        {
           
            using (var ctx = new GlobalEntities())
            { 

            }
        }

        public void UpdateStudent(VendorEntitySave agentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(VendorEntity.vendorEn agentId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}