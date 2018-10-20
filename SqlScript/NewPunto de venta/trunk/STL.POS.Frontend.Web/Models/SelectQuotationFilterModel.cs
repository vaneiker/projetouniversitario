using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Models
{
    public class SelectQuotationFilterModel
    {

        public string QuotationId { get; set; }

        public string QuotationNumber { get; set; }

        public string PrincipalId { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public string Error { get; set; }

    }
}