using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EF_MODEL;
using Entity.Global_Entity;
namespace Data.AccesData
{  public interface IData
        {
            IEnumerable<VendorEntitySave> GetVendor();

            VendorEntitySave GetStudentByID(int agentId);
            void Insert(VendorEntity.vendorEn agentId);
            void DeleteStudent(int agentId);
            void UpdateStudent(VendorEntity.vendorEn agentId);
            void Save();
        
    }
}
