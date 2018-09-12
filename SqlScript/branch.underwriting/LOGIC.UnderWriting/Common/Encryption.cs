using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace LOGIC.UnderWriting.Common
{
    public class Encryption
    {
        private static string _key = ConfigurationManager.AppSettings["EncriptionKey"];
        //static string _key = System.Configuration.ConfigurationSettings.AppSettings["EncryptionKey"];

        public Encryption() { }

        public static string Encrypt(object Argument)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Argument.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            //keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["EncriptionKey"]));
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
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
            //keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["EncriptionKey"]));
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
    }
}
