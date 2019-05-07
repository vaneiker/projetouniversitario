using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Declarative.Invoicing.CustomCode
{
    public static class Utility
    {

        public static string Encode(string encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }

        public static T deserializeJSON<T>(string Json) where T : class
        {
            dynamic result = null;

            try
            {
                result = new JavaScriptSerializer().Deserialize<T>(Json);
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Serializar un objeto y convertirlo en un XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToXMLString(object obj)
        {
            string xmlString = string.Empty;
            XmlSerializer s = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, new UTF8Encoding());
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = ' ';
            writer.Indentation = 5;

            try
            {
                s.Serialize(writer, obj);
                xmlString = UTF8Encoding.UTF8.GetString(ms.ToArray());
            }
            finally
            {
                writer.Close();
                ms.Close();
            }

            return
                xmlString;
        }


        public static void Log(string currentUser, string title, string message, Exception ex = null)
        {
            object value;
            Exception exObj;
            
            if (ex == null)
            {
                value = new
                {
                    currentUser,
                    title,
                    message
                };

                exObj = new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
            else
            {
                exObj = null;
            }
            
            try { GLogger.LogError(ex ?? exObj); }
            catch (Exception) { }
        }
    }

}