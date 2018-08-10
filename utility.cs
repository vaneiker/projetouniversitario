using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using iTextSharp.text;
using System.Linq;
using System.Collections.Generic;

namespace STL.POS.Frontend.Web.NewVersion.CustomCode
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

        /// <summary>
        /// Author: Marcos J. Pérez
        /// Compresión de PDF
        /// </summary>
        /// <param name="pdf">PDF a comprimir</param>
        /// <returns>PDF comprimido</returns>
        public static byte[] CompressPDF(byte[] pdf)
        {
            byte[] result = new byte[] { };

            PdfReader reader = new PdfReader(pdf);
            for (int i = 1; i <= reader.NumberOfPages; i++)
                reader.SetPageContent(i, reader.GetPageContent(i), PdfStream.BEST_COMPRESSION);

            using (MemoryStream memStream = new MemoryStream())
            {
                PdfStamper stamper = new PdfStamper(reader, memStream, PdfWriter.VERSION_1_7);
                stamper.FormFlattening = true;
                stamper.SetFullCompression();
                stamper.Writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
                stamper.Writer.SetFullCompression();
                stamper.Close();

                result = memStream.ToArray();
            }

            return result;
        }


        public static bool convertFileToPDF(string path, string fileName, Byte[] fileBinary, bool isImage, byte[] imgBytes, out string newFileName)
        {
            string newPathFileName = string.Concat(path, Path.GetFileNameWithoutExtension(fileName), ".pdf");

            Document doc = new Document();
            // create PDF File and create a writer on it
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(newPathFileName, FileMode.Create));

            // open the document
            doc.Open();
            // Add the text file contents
            if (isImage)
            {
                Image img = Image.GetInstance(imgBytes);
                doc.Add(img);
            }
            else
            {
                doc.Add(new iTextSharp.text.Paragraph(System.Text.Encoding.UTF8.GetString(fileBinary)));
            }
            // Close the document
            doc.Close();

            newFileName = string.Concat(Path.GetFileNameWithoutExtension(fileName), ".pdf");

            return true;
        }

        public static byte[] ConvertImageAsPng(Stream stream)
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            byte[] png;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                png = ms.ToArray();
            }

            return png;
        }

        public static byte[] ConvertImageToPdf(byte[] img)
        {
            iTextSharp.text.Rectangle pageSize = null;

            //var stream = GetImageStream(img);            
            Stream stream = new MemoryStream(img);

            using (var srcImage = new System.Drawing.Bitmap(stream))
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);

            byte[] result = new byte[] { };

            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(img);
                document.Add(image);
                document.Close();

                result = ms.ToArray();
            }

            return result;
        }

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            var result = false;

            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                // Writes a block of bytes to this stream using data from a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Flush();
                _FileStream.Close();
                _FileStream.Dispose();
                result = true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            // error occured, return false
            return result;
        }


        public static StringBuilder getIndexFileText()
        {
            var TextBuilder = new StringBuilder();

            TextBuilder.AppendLine("BEGIN");
            TextBuilder.AppendLine(">>DocTypeName: {0}");
            TextBuilder.AppendLine(">>DocDate: {1}");
            TextBuilder.AppendLine(">>FileFormat: 16");

            TextBuilder.AppendLine("Numero de Poliza: {2}");
            TextBuilder.AppendLine("Asegurado: {3}");
            TextBuilder.AppendLine("FechaAutorizacion: {4}");
            TextBuilder.AppendLine("FechaFinal: {5}");
            TextBuilder.AppendLine("FechaInicio: {6}");
            TextBuilder.AppendLine("Origen: Punto de Venta");
            TextBuilder.AppendLine("Nombre Autor: {7} ");
            TextBuilder.AppendLine("Numero Cotizacion: {8}");
            TextBuilder.AppendLine("Identificacion: {9}");
            TextBuilder.AppendLine("Chasis: {10}");
            TextBuilder.AppendLine("TipodeMovimiento: {11}");
            TextBuilder.AppendLine(@">>Full Path: {12}");

            TextBuilder.AppendLine("END:");

            return TextBuilder;
        }


        public static List<Entity.Entities.RequestChanges> getRequestChanges(string policyNo, int? conditionID, int secuenceVehicle, bool lastRecord = false)
        {
            Logic.VehicleProductManager oManager = new Logic.VehicleProductManager();
            var result = oManager.GetRequestChanges(new Entity.Entities.RequestChanges.Parameter()
            {
                policy_Number = policyNo,
                condition_Id = conditionID,
                IsLasRecord = lastRecord
            }).ToList();

            if (result.Any())
            {
                var realResult = result.Where(x => x.Vehicle_Secuence == secuenceVehicle).ToList();
                return realResult;
            }

            return null;
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

       
    }
}