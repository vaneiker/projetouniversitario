using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Collectors.Helpers
{
    public static class GlobalUtility
    {
        public static Boolean BooleanToBoolNullableParse(string Value)
        {
            Boolean result = false;
            Boolean.TryParse(Value, out result);
            return result;
        }

        public static int IntToIntNullableParse(string Value)
        {
            int result = 0;
            int.TryParse(Value, out result);
            return result;
        }

        public static Decimal DecimalNullableParse(string Value)
        {
            Decimal result;
            Decimal.TryParse(Value, out result);
            return result;
        }

        public static DateTime DateTimeNullableParse(string Value)
        {
            DateTime result = new DateTime();
            DateTime.TryParse(Value, out result);
            return result;
        }

        public static String MoneyFormat(Object _value)
        {
            if (_value == null)
                _value = "";

            Decimal _valor;
            Decimal.TryParse(_value.ToString(), out _valor);
            return _valor.ToString("C");
        }

        public static T _Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static class QueryString
        {
            private static byte[] key = new byte[8] { 4, 7, 8, 8, 0, 2, 3, 9 };
            private static byte[] iv = new byte[8] { 6, 2, 8, 1, 5, 1, 7, 2 };

            public static String _Key = "8BFBE569-3919-4DE9-BEF9-EBE7076D1260";
            public static String _Salt = "0";

            public static string EncryptString(string inputText)
            {
                byte[] plainText = Encoding.UTF8.GetBytes(inputText);

                using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
                {
                    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(_Key), Encoding.ASCII.GetBytes(_Salt));
                    using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainText, 0, plainText.Length);
                                cryptoStream.FlushFinalBlock();
                                string base64 = Convert.ToBase64String(memoryStream.ToArray());
                                return base64;
                                // Generate a string that won't get screwed up when passed as a query string.
                                //string urlEncoded = HttpUtility.UrlEncode(base64);
                                //return urlEncoded;
                            }
                        }
                    }
                }
            }

            public static string DecryptString(string inputText)
            {
                string utf8 = "";
                if (!String.IsNullOrEmpty(inputText))
                {
                    byte[] encryptedData = Convert.FromBase64String(inputText);
                    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(_Key), Encoding.ASCII.GetBytes(_Salt));

                    using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
                    {
                        using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainText = new byte[encryptedData.Length];
                                    cryptoStream.Read(plainText, 0, plainText.Length);
                                    utf8 = Encoding.UTF8.GetString(plainText);
                                    return utf8;
                                }
                            }
                        }
                    }
                }
                return utf8;
            }

        }

        public class Transaction_Message
        {
            public static String Success = "Transacción procesada satisfactoriamente!";
            public static String Error = "Ha ocurrido un error en la transacción!";
        }

        public static void Use<T>(this T item, Action<T> work)
        {
            work(item);
        }

    }

}