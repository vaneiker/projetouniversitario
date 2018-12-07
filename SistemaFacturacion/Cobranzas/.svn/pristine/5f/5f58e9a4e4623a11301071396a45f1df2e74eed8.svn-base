using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class ProjectedStatementViewModels : BaseViewModels
    {
        public IEnumerable<paymentProjection> paymentProjection { get; set; }   
    }

    public class paymentProjection
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public Nullable<int> TipoSaldo { get; set; }
    }
}