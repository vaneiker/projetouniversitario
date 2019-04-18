using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellersManagement.Models.ViewModels
{
    public class ManagementGridViewModel : BaseViewModel
    {
        public IEnumerable<AgentInfomation> Managements { get; set; }

        public ManagementGridViewModel(){
            Managements = new List<AgentInfomation>(0);
        }
    }
}