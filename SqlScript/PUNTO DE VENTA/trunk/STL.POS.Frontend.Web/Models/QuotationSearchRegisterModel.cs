﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Models
{
    public class QuotationSearchRegisterModel
    {

        public string Id { get; set; }

        public string QuotationNumber { get; set; }

        public string PrincipalIdentificationNumber { get; set; }

        public string PrincipalName { get; set; }

        public string QuotationDate { get; set; }

        public string BusinessLine { get; set; }

        public string Plan { get; set; }

        public string Currency { get; set; }

        public string AnnualPrime { get; set; }

        public string Taxes { get; set; }

        public string Total { get; set; }

        public string AgentQuotationName { get; set; }

        public string FullName { get; set; }

    }
}