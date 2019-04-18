using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SellersManagement.CustomCode
{
    public static class Utility
    {
        public class ActionModel
        {
            public CommonEnums.ActionTypes ActionType { get; set; }
            public string ActionJson { get; set; }
        }


        public static int generateRandomSellerCode()
        {
            int randomSellerCode = 0;

            Random r = new Random();
            randomSellerCode = r.Next(0, 1000000);
           // string s = x.ToString("000000");

            return randomSellerCode;
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Created Date : 11-28-2014
        /// Deserializa un json a objeto T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T deserializeJSON<T>(string Json) where T : class
        {
            dynamic result = null;

            try
            {
                result = JsonConvert.DeserializeObject<T>(Json);
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
            }

            return result;
        }

        
    }
}