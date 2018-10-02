using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellersManagement.CustomCode
{
    public static class Utility
    {
        public class ActionModel
        {
            public CommonEnums.ActionTypes ActionType { get; set; }
            public string ActionJson { get; set; }
        }

        public static string ToJson(this object obj)
        {
            try
            {
                return "";//Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}