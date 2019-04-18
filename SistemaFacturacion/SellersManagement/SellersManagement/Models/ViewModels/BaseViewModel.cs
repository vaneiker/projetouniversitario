using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellersManagement.Models.ViewModels
{
    public class BaseViewModel
    {
        public string MessageError { get; set; }
        public string InnerExceptionMessage { get; set; }
        public bool HasError { get; set; }
        public string ColumnsNameJson { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }

        public BaseViewModel()
        {
            this.MessageError = string.Empty;
            this.HasError = false;
        }

        public class KeyValue
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public class ItemAdditionalFilters : KeyValue
        {
            public bool IsNumber { get; set; }
        }
    }
}