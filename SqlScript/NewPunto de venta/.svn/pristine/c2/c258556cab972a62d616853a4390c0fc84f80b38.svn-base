using System;
using STL.POS.Data;
using STL.POS.GlobalLogger;
using Newtonsoft.Json;

namespace STL.POS.Frontend.Web.Helpers
{
    public class LoggerHelper
    {
        public static void Log(Categories category, string currentUser, int quotationId, string title, string message, Exception ex = null)
        {
            object value;
            Exception exObj;
            var log = new PosLogEntry();
            log.CurrentUser = currentUser;
            log.QuotationId = quotationId;
            var msg = "QuotationId: " + quotationId + " - Usuario: " + currentUser + " \n" + message;
            log.Message = msg;
            log.Title = title;
            log.Category = category;

            //Logger.Write(log);

            if (ex == null)
            {
                value = new
                {
                    category,
                    currentUser,
                    quotationId,
                    title,
                    message
                };

                exObj = new Exception(JsonConvert.SerializeObject(value));
            }
            else
            {
                exObj = null;
            }


            try { GLogger.LogError(ex ?? exObj); }
            catch (Exception) { }


            /*
            if (exObj == null)
            {
                try { GLogger.LogError(ex); }
                catch (Exception exxx) { }
            }
            else
            {
                try { GLogger.LogError(exObj); }
                catch (Exception exxx) { }
            }*/
        }
    }
}