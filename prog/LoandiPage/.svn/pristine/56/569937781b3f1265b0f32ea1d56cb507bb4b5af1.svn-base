using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;


using System.Linq;
using System.Collections.Generic;

namespace CustomerCallBack.CustomCode
{
    public static class Utility
    {

        public static string Encrypt_Query(string cadena)
        {

            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            try
            {

                byte[] keyArray;
                //arreglo de bytes donde guardaremos el texto  
                //que vamos a encriptar  
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
                //se utilizan las clases de encriptación  
                //provistas por el Framework  
                //Algoritmo MD5     
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                //se guarda la llave para que se le realice  
                //hashing          
                keyArray = hashmd5.ComputeHash(

                UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo 3DAS  
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                //se empieza con la transformación de la cadena  
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                //arreglo de bytes donde se guarda la  
                //cadena cifrada  

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();

                //se regresa el resultado en forma de una cadena  

                return Convert.ToBase64String(ArrayResultado,

                      0, ArrayResultado.Length);

            }

            catch (Exception)
            {

            }

            return string.Empty;

        }

        public static string Decrypt_Query(string clave)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";
            try
            {

                byte[] keyArray;
                //convierte el texto en una secuencia de bytes  

                byte[] Array_a_Descifrar =
              Convert.FromBase64String(clave);

                //se llama a las clases que tienen los algoritmos  

                //de encriptación se le aplica hashing  

                //algoritmo MD5  
                MD5CryptoServiceProvider hashmd5 =
               new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(
                 UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes =
                new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;


                ICryptoTransform cTransform =

                 tdes.CreateDecryptor();


                byte[] resultArray =

                cTransform.TransformFinalBlock(Array_a_Descifrar,
                0, Array_a_Descifrar.Length);


                tdes.Clear();

                //se regresa en forma de cadena  
                return UTF8Encoding.UTF8.GetString(resultArray);
            }

            catch (Exception)
            {

            }

            return string.Empty;

        }

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

        public static int QuantityOfMonth(DateTime dt, DateTime df)
        {
            int monthsApart = 12 * (dt.Year - df.Year) + dt.Month - df.Month;
            return Math.Abs(monthsApart);
        }

        public static int QuantityOfDays(DateTime dt, DateTime df)
        {
            int DaysApart = df.Date.Subtract(dt.Date).Days;
            return Math.Abs(DaysApart);
        }

        public static int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            return age;
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

        public class Percent_Flotilla_Discount
        {
            public int From { get; set; }
            public int To { get; set; }
            public decimal Porc { get; set; }
        }

        public class jsonDocRequired
        {
            public string quotationID { get; set; }
            public string DocumentId { get; set; }
            public string RequirementTypeId { get; set; }
            public string RequirementTypeDesc { get; set; }
            public string PersonId { get; set; }
            public string VehicleId { get; set; }
            public string DRActualPath { get; set; }
        }

        public static string DecimalToString(this decimal? value)
        {
            string result;

            result = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : "0.00";

            return
               result;
        }

        public class blByCountry
        {
            public int countryID { get; set; }
            public string countryName { get; set; }

            public System.Collections.Generic.List<BussinesLines> _BussinesLines { get; set; }
        }

        public class BussinesLines
        {
            public string blName { get; set; }
            public int blID { get; set; }
        }

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


        public class ActionModel
        {
            public CommonEnums.ActionTypes ActionType { get; set; }
            public string ActionJson { get; set; }
        }

        public class ActionData
        {
            public string PolicyNo { get; set; }
            public string Action { get; set; }
        }

        public class GeoIpInfo
        {
            public string host { get; set; }
            public string ip { get; set; }
            public string rdns { get; set; }
            public int asn { get; set; }
            public string isp { get; set; }
            public string country_name { get; set; }
            public string country_code { get; set; }
            public object region_name { get; set; }
            public object region_code { get; set; }
            public object city { get; set; }
            public object postal_code { get; set; }
            public string continent_name { get; set; }
            public string continent_code { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public object metro_code { get; set; }
            public string timezone { get; set; }
            public string datetime { get; set; }
        }

        public class Data
        {
            public GeoIpInfo geo { get; set; }
        }

        public class GeoRootObject
        {
            public string status { get; set; }
            public string description { get; set; }
            public Data data { get; set; }
        }


    }
}