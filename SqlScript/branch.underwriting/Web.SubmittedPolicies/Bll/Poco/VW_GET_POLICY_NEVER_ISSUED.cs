using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SubmittedPolicies.Dal
{
    public partial class VW_GET_POLICY_NEVER_ISSUED
    {
        public string Status_Image
        {
            get { return Status.HasValue ? (Status.Value ? "../../../images/icono/cotejo.png" : "../../../images/icono/equis.png") : "../../../images/icono/equis.png"; }
        }
    }
}