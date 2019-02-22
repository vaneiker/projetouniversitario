using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalLogger;
using Newtonsoft.Json;

namespace StateTrustGlobal.Helpers
{
    public class LoggerHelper
    {
        public static void Log(string currentUser, string menuOption, string title, string message, Exception ex = null)
        {
            object value;
            Exception exObj;

            /*if (ex == null)
            {
                value = new
                {
                    currentUser,
                    menuOption,
                    title,
                    message,
                    ex
                };

                exObj = new Exception(JsonConvert.SerializeObject(value));
            }
            else
            {
                exObj = null;
            }

            try { GLogger.LogError(ex ?? exObj); }
            catch (Exception) { }*/

            value = new
            {
                currentUser,
                menuOption,
                title,
                message,
                ex
            };

            exObj = new Exception(JsonConvert.SerializeObject(value));

            try { 
                GLogger.LogError(exObj); 
            }
            catch (Exception) { }
        }
    }
}
