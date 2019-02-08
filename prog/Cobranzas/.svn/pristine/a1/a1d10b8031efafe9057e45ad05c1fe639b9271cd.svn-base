using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace KSI.Cobranza.Web.Common
{
    public static class Utility
    {
        public class ItemCalls {
            public string CallDuration { get; set; }
            public string CallerIDName { get; set; }
            public string CallerIDNo { get; set; }
            public string CallID { get; set; }
            public string CallLogID { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime CallStart { get; set; }
            public DateTime CallStop { get; set; }
            public string Department { get; set; }
            public string DialedNumber { get; set; }
            public string DNIS { get; set; }
            public string Extension { get; set; }
            public string FileHash { get; set; }
            public string FileLocation { get; set; }
            public string FileName { get; set; }
            public string FirstName { get; set; }
            public string FromCallLogID { get; set; }
            public bool IsRecordingChainSegment { get; set; }
            public bool IsStereo { get; set; }
            public string LastName { get; set; }
            public string Location { get; set; }
            public string RecordedBy { get; set; }
            public string RecorderUtcOffset { get; set; }
            public bool Rejected { get; set; }
            public string ToCallLogID { get; set; }
            public string UserID { get; set; }
            public string XferFrom { get; set; }
            public string FullName { get; set; }
        }

        /// <summary>
        ///   Author: Lic. Carlos Ml Lebron
        ///   devuelve una lista de datos dummy del tipo que se le pase como parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GenerateDummyData<T>(int totalrecords, bool generateSecuencialCodeInFirstField = false) where T : class
        {   //Obtener las propiedades
            PropertyInfo[] Props = typeof(T).GetProperties();

            var FirstField = string.Empty;
            var JsonData = "[";
            var record = "{";
            var CountField = 0;
            //Crear Registro JSON
            foreach (var item in Props)
            {
                CountField++;

                if (CountField == 1)
                    FirstField = item.Name;

                var ptype = item.PropertyType.Name;

                dynamic resultFieldAndValue = string.Empty;

                var NumericRandom = new Random().Next(1, 999999);

                switch (ptype)
                {
                    case "Boolean":
                        resultFieldAndValue = "true";
                        break;
                    case "Int32":
                        resultFieldAndValue = NumericRandom;
                        break;
                    case "Decimal":
                        resultFieldAndValue = decimal.Parse(NumericRandom.ToString());
                        break;
                    case "DateTime":
                        DateTime d;
                        DateTime.TryParseExact(DateTime.Now.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d);
                        resultFieldAndValue = d;
                        break;
                    default:
                        resultFieldAndValue = item.Name;
                        break;
                }

                record += ("\"" + item.Name) + "\":\"" + resultFieldAndValue + "\",";
            }

            record = record.Substring(0, record.Length - 1);
            record += "}";

            for (int x = 1; x <= totalrecords; x++)
                JsonData += (generateSecuencialCodeInFirstField) ? record.Replace(":\"" + FirstField + "\"", ":\"" + FirstField + " - " + string.Format("{0:000000}", x) + "\"") + ","
                                                                 : record + ",";

            JsonData = JsonData.Substring(0, JsonData.Length - 1);
            JsonData += "]";

            var Data = deserializeJSON<List<T>>(JsonData);

            return Data;
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
                result = new JavaScriptSerializer().Deserialize<T>(Json);
            }
            catch (Exception ex)
            {
                var ErrorMessage = ex.Message;
            }

            return result;
        }

        public static string Encrypt(object Argument)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Argument.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["EncriptionKey"]));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        public static string Decrypt(object Argument)
        {
            byte[] keyArray;
            byte[] Array_a_Descifrar = Convert.FromBase64String(Argument.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["EncriptionKey"]));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();
            string res = UTF8Encoding.UTF8.GetString(resultArray);
            return res;
        }

        public static string SerializeToXMLString(object obj)
        {
            string xmlString = string.Empty;
            XmlSerializer s = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, new UTF8Encoding());
            writer.Formatting =  System.Xml.Formatting.Indented;
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

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Serializa un objeto T a formato JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string serializeToJSON(object item)
        {
            var objeto = new JavaScriptSerializer().Serialize(item);
            return objeto;
        }   

        public static string URLDecrypt(string EncryptedText)
        {
            byte[] inputByteArray = new byte[EncryptedText.Length + 1];
            byte[] rgbIV = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };
            byte[] key = { };

            try
            {
                key = System.Text.Encoding.UTF8.GetBytes("A0D1nX0Q");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(EncryptedText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, rgbIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string URLEncrypt(string stringToEncrypt)
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            byte[] rgbIV = { 0x21, 0x43, 0x56, 0x87, 0x10, 0xfd, 0xea, 0x1c };
            byte[] key = { };
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes("A0D1nX0Q");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, rgbIV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static String GetSerialId()
        {
            return System.Guid.NewGuid().ToString().Replace("-", "").Substring(1, 12).ToUpper();
        }

        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}