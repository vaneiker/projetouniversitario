using ShipLogs.Data;
using ShipLogs.Data.Repository;
using ShipLogs.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Logic
{
    public class DropDownManager : BaseManager
    {
        private readonly DropDownRepository dropDownRepository;
        public DropDownManager()
        {
            dropDownRepository = new DropDownRepository();
        }
        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            return
                dropDownRepository.GetDropDown(DropDownType);
        }
    }
}
