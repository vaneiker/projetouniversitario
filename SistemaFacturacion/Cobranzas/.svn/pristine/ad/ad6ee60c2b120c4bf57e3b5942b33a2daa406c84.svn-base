using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class BaseViewModels
    {
        public List<string> ModelErrorList;
        public string ErrosInJsonFormat { get; set; }
        public bool hasError;

        public BaseViewModels()
        {
            ModelErrorList = new List<string>(0);
            ErrosInJsonFormat = string.Empty;
            hasError = false;
        }
          
        public class KeyValue
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}