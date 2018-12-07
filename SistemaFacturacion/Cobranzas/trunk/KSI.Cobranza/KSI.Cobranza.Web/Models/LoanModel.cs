using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models
{
    /// <summary>
    /// Author        : Lic. Carlos Ml. Lebron B
    /// Created Date  : 08/13/2018
    /// </summary>
    public class LoanModel : BaseModel
    {
        private LoanInformationViewModels @Model { get; set; }

        public LoanModel()
        {
            @Model = new Lazy<LoanInformationViewModels>().Value;
        }          
    }
}