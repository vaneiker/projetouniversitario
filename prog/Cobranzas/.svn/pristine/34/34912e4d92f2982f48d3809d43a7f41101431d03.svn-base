using KSI.Cobranza.EntityLayer;
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

        public IEnumerable<BaseViewModels.KeyValue> GetDropDown(Enums.DropDownType DropDownType, object FilterBy = null)
        {
            var dataDrop = oApiService.baseManager.GetDropDown(DropDownType.ToString()).ToList();

            if (FilterBy != null)
            {
                var res = dataDrop.Select(o => new
                {
                    RealKey = o.Key.Split('|')[1],
                    Key = o.Key.Split('|')[0],
                    Value = o.Value
                }).ToList();

                dataDrop = res.Where(x => x.Key == FilterBy.ToString()).Select(x => new DropDown
                {
                    Key = x.RealKey,
                    Value = x.Value
                }).ToList();
            }

            var result = dataDrop.Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            });

            return
                result;
        }
    }
}