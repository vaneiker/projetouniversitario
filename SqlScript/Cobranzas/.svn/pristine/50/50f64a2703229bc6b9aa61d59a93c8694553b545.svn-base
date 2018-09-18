using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models
{
    public class BaseModel
    {
        protected ApiService oApiService { get; set; }

        public BaseModel()
        {
            oApiService = new Lazy<ApiService>().Value;
        }

        public IEnumerable<BaseViewModels.KeyValue> GetDropDown(Enums.DropDownType DropDownType)
        {
            var countries = oApiService.baseManager.GetDropDown(DropDownType.ToString()).ToList();

            var result = countries.Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            });        
         
            return
                result;
        }
    }
}