using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class SearchViewModels
    {
        public IEnumerable<SearchResult> searchResult { get; set; }
    }

    public class dataRequest
    {
        public long? CustomerId { get; set; }
        public long? accountId { get; set; }
        public long? RequestId { get; set; }         
    }

    public class SearchResult
    {
        public string _dataRequest { get; set; }
        public string account { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string PhoneNumber { get; set; }
        public string LoanNumber { get; set; }
        public string RequestNumber { get; set; }
    }
}