using DevExpress.Web;
using Statetrust.Framework.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Common
{
    public static class ControlsUtility
    {
        public static Common.SessionList datos;
        private static string key = "SessionData";
        /// <summary>
        /// Inicializa algunos componentes tales como TextBox,DropDownList,CheckBox y GridView pasando al metodo
        /// Una coleccion de controles
        /// </summary>
        /// <param name="controles"></param>
        public static void ClearAll(ControlCollection controles)
        {
            //Recorrer los componentes de la lista            
            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    var isDecimalTxt = false;
                    var txt = ((TextBox)control);

                    foreach (var item in txt.Attributes.Keys)
                    {
                        if (item.ToString() == "decimal" || item.ToString() == "decimal-us")
                        {
                            isDecimalTxt = true;
                            break;
                        }
                    }

                    if (isDecimalTxt)
                        txt.Clear("0.00");
                    else
                        txt.Clear();
                }
                else if (control is DropDownList)
                {
                    //Valido si el DropDownList para luego posicionarnos 
                    //en el inice 0 de la lista                    
                    if (((DropDownList)control).Items.Count > 0)
                        ((DropDownList)control).SelectedIndex = 0;
                }
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                //else if (control is CheckBoxList)
                //    ((CheckBoxList)control).Items.Clear();
                else if (control is GridView)
                {
                    ((GridView)control).DataSource = null;
                    ((GridView)control).DataBind();
                }

                ClearAll(control.Controls);
            }
        }

        public enum OperationType { Insert, InsertAll, Edit, Delete, None };

        public enum ContactRoleIDType { Owner = 1, Client = 2, AddicionalInsured = 3, Beneficiarie = 4, DesignatedPensioner = 5, Student = 6, IncludedFamiliar = 7, Dependent = 9,/*wcastro 16-03-2017 */ Legal = 11 /* fin wcastro*/  };

        /// <summary>
        ///  Forza a que una fecha se parsee en un formato especifico
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? ParseFormat(this String value, string format = "MM/dd/yyyy")
        {
            DateTime resultDate;
            var resulTry = DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDate);
            if (resulTry)
                return resultDate;
            else
                return (DateTime?)null;
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/28/2014
        /// devuelve el keyvalue del keyname pasado como paramero un aspxGridView
        /// </summary>
        /// <param name="aspxGridView"></param>
        /// <param name="RowIndex"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetKeyFromAspxGridView(this ASPxGridView aspxGridView, string keyName, int RowIndex, object defaultValue = null)
        {
            object result = null;
            defaultValue = defaultValue.isNullReferenceObject() ? -1 : defaultValue;
            var KeyVal = aspxGridView.GetRowValues(RowIndex, keyName);
            result = (KeyVal != null) ? KeyVal : defaultValue;
            return result;
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Devuelve true or false si la referencia al objeto es nula
        /// Created Date: 03/19/2015
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool isNullReferenceObject(this Object obj)
        {
            return (obj == null);
        }

        public static string MyRemoveInvalidCharacters(this string value)
        {
            return value.Replace("\r", "").Replace("\n", "").Replace("'", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string GetBase64FromImage(byte[] img)
        {
            var result = "";

            if (img != null)
                result = "data:;base64," + Convert.ToBase64String(img);

            return result;
        }

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
                TripleDESCryptoServiceProvider tdes =

                new TripleDESCryptoServiceProvider();


                tdes.Key = keyArray;

                tdes.Mode = CipherMode.ECB;

                tdes.Padding = PaddingMode.PKCS7;


                //se empieza con la transformación de la cadena  
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                //arreglo de bytes donde se guarda la  
                //cadena cifrada  

                byte[] ArrayResultado =

                 cTransform.TransformFinalBlock(Arreglo_a_Cifrar,

                0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena  

                return Convert.ToBase64String(ArrayResultado,

                      0, ArrayResultado.Length);

            }

            catch (Exception ex)
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

            catch (Exception ex)
            {

            }

            return string.Empty;

        }

        public class itemOccupationType
        {
            public string description { get; set; }
            public int value { get; set; }
        }

        public class itemOccupation
        {
            public string OccupationGroupDesc { get; set; }
            public int OccupationGroupId { get; set; }
            public string description { get; set; }
            public int value { get; set; }
        }

        public enum Language { en = 1, es = 2 };

        public enum TipoRiesgo { NONE, RA, RM, RB }

        public enum IdentificationType : int
        {
            Other = 0,
            ID = 1,
            Passport = 2,
            DriverLicense = 3,
            CompanyRegistration = 5,
            BirthCertificate = 6
        };

        public class Reason
        {
            public string Id { get; set; }
            public string Tipo { get; set; }
            public string Descripcion { get; set; }
            public string NameKey { get; set; }
        }
    }
}