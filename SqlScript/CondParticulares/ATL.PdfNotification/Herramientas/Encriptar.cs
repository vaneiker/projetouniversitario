using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Google.Apis.Urlshortener.v1;
using Google.Apis.Services;

namespace ATL.PdfNotification.Herramientas
{
   public static class Encriptar
    {
       

        public static string Encriptar001(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string Encrip(string clave)
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
               cTransform.TransformFinalBlock(Array_a_Descifrar,  0, Array_a_Descifrar.Length);
               tdes.Clear();
               //se regresa en forma de cadena  
               return UTF8Encoding.UTF8.GetString(resultArray);


           }

           catch (Exception)
           {

           }
           return string.Empty;
       }


        public static string shortenIt(string url)
        {

            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC-sNERlNNJZfTUpD0MbXPiH236B7XW1mo",
                ApplicationName = "Thunderhead",
            });

            var m = new Google.Apis.Urlshortener.v1.Data.Url();
            m.LongUrl = url;
            return service.Url.Insert(m).Execute().Id;
        }

        public static string unShortenIt(string url)
        {
            UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC-sNERlNNJZfTUpD0MbXPiH236B7XW1mo",
                ApplicationName = "Encripting",
            });
            return service.Url.Get(url).Execute().LongUrl;
        }
    }
}

    
