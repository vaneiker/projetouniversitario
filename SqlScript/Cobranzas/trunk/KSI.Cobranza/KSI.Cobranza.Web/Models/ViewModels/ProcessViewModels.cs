﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class ProcessViewModels
    {
        public CollectionViewModels CollectionViewModels { get; set; }

        public PersonalInformationViewModels personalInformationViewModels { get; set; }
        public LoanInformationViewModels LoanInformationViewModels { get; set; }
        public PolicyInformationViewModels PolicyInformationViewModels { get; set; }
        public VehicleInformationDetailViewModels VehicleInformationDetailViewModels { get; set; }
        public GuaranteeViewModels GuaranteeViewModels { get; set; }
        public ProjectedStatementViewModels ProjectedStatementViewModels { get; set; }
    }
}