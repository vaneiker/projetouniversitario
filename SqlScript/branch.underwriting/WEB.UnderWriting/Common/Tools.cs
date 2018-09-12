using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using DevExpress.Web;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.UnderWriting.Common
{
	public static class Tools
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

				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
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

				return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
			}

			catch (Exception ex)
			{
				//Tools.SaveException(ex, "UCTransactionRegistry CerTenderedSave_Click", 1);
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

				byte[] Array_a_Descifrar = Convert.FromBase64String(clave);
				//se llama a las clases que tienen los algoritmos  

				//de encriptación se le aplica hashing  

				//algoritmo MD5  
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				hashmd5.Clear();
				TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
				tdes.Key = keyArray;
				tdes.Mode = CipherMode.ECB;
				tdes.Padding = PaddingMode.PKCS7;
				ICryptoTransform cTransform = tdes.CreateDecryptor();
				byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar,
				0, Array_a_Descifrar.Length);
				tdes.Clear();
				//se regresa en forma de cadena  
				return UTF8Encoding.UTF8.GetString(resultArray);
			}

			catch (Exception ex)
			{
				//SaveException(ex, "Toll Decrypt_Query", 1);
			}
			return string.Empty;

		}
        public enum Currency { USD = 1, EUR = 2, DOP = 3 };
		public enum UCSpecialDocuments
		{
			Corrida = 1,
			Solicitud = 2
		}

		public enum RisksRatingTypes
		{
			PerThousand = 1,
			TableRating = 2
		}

		public enum WorkFlowTypes
		{
			Approval = 1,
			PaymentReview = 2,
			BackgroundCheck = 3,
			ConfirmationCall = 4,
			Waitingformedicalinfo = 5,
			Evaluation = 6,
			WaitingfoClientinformation = 7,
			Reinsurance = 8,
			FinalReview = 9,
			Issuance = 10,
			NeverIssued = 11
		}

		public enum RisksOperations
		{
			Risk = 1,
			Credit = 2,
			Exclusion = 3
		}

		public enum AttachmentFileType
		{
			pdf = 1,
			jpg = 3,
			docx = 4,
			xlsx = 5,
			pptx = 6
		}

		public enum CreditTypes
		{
			PerThousand = 1,
			TableRating = 2
		}

		public enum UCTemplates
		{
			UCClientEmail = 1,
			UCProtocol = 2,
			UCGreeting = 3,
			UCPolicyPlan = 4,
			UCPlanValue = 5,
			UCInvestmentProfile = 6,
			UCFarewell = 7
		}

		public enum ProductBehavior
		{
			None,
			Horizon,
			Axys,
			EduPlan,
			Scholar,
			CompassIndex,
			Legacy,
			Sentinel,
			Lighthouse,
			Guardian,
			GuardianPlus,
			Orion,
			OrionPlus,
			Luminis,
			LuminisVIP,
			Exequium,
            VidaCredito,
			ExequiumVIP,
			Elite,
			Select,
			Fortis,
			Serenity,
			Asistencia90dias,
			Asistencia30dias,
			Asistencia60dias
		}

		public enum EFamilyProductType
		{
			Education,
			Retirement,
			LifeInsurance,
			TermInsurance,
			Funeral,
			HealthInsurance,
			None
		}

        public enum SettingOperations { Insert, Update, Delete }

		public static void SelectIndexByValue(ref DropDownList DropDownList1, String Value, bool SelectFistIndex = false)
		{
			System.Web.UI.WebControls.ListItem listItem = DropDownList1.Items.FindByValue(Value);
			if (listItem != null)
			{
				DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(listItem);
			}
			else if (SelectFistIndex)
			{
				if (DropDownList1.Items.Count > 0)
				{
					DropDownList1.SelectedIndex = -1;
				}
			}
		}
		public static void SelectIndexByText(ref DropDownList DropDownList1, String Text, bool SelectFistIndex = false)
		{
			System.Web.UI.WebControls.ListItem listItem = DropDownList1.Items.FindByText(Text);
			if (listItem != null)
			{
				DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(listItem);
			}
			else if (SelectFistIndex)
			{
				if (DropDownList1.Items.Count > 0)
				{
					DropDownList1.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// Genera y devuelve un ID aleatorio de 12 Caracteres
		/// </summary>
		/// <returns></returns>
		public static String GetSerialId()
		{
			return System.Guid.NewGuid().ToString().Replace("-", "").Substring(1, 12).ToUpper();
		}

		public static long SaveByteToFile(this byte[] bytes, String savePath)
		{
			File.WriteAllBytes(savePath, bytes);
			return new FileInfo(savePath).Length;
		}

		public static byte[] ReadBinaryFile(string path)
		{
			if (File.Exists(path))
			{
				try
				{
					FileStream fileStream = File.OpenRead(path);
					byte[] datos = ConvertStreamToByteBuffer(fileStream);
					fileStream.Close();
					return datos;
				}
				catch
				{
					return new byte[0];
				}
			}
			else
			{
				return new byte[0];
			}
		}

		public static byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
		{
			int b1;
			System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
			while ((b1 = theStream.ReadByte()) != -1)
			{
				tempStream.WriteByte(((byte)b1));
			}
			return tempStream.ToArray();
		}

		public static List<List<T>> SplitIntoChunks<T>(List<T> list, int chunkSize)
		{
			if (chunkSize <= 0)
			{
				throw new ArgumentException("chunkSize must be greater than 0.");
			}

			List<List<T>> retVal = new List<List<T>>();
			int index = 0;
			while (index < list.Count)
			{
				int count = list.Count - index > chunkSize ? chunkSize : list.Count - index;
				retVal.Add(list.GetRange(index, count));

				index += chunkSize;
			}

			return retVal;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Object getEnumTypeFromValue(Type enumType, int val)
        {
            return Enum.ToObject(enumType, val);
        }
        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Nullable<decimal> IsDecimalReturnNull(this string value)
        {
            decimal d;
            bool resut = Decimal.TryParse(value, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out d);

            if (resut)
                return d;
            else
                return new Nullable<decimal>();
        }

        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  Author: Lic. Carlos Ml Lebron
        ///  Forza a renderizar las etiquetas thead y tfoooter en un gridview
        /// </summary>
        /// <param name="gv"></param>
        public static void RenderTableHeaderOrTableFooterOnGridView(this GridView gv)
        {
            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                gv.UseAccessibleHeader = false;
                if (gv.HeaderRow != null)
                    gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                gv.UseAccessibleHeader = false;
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Devuelve true or false si la referencia al control es nula
        /// Created Date: 03/16/2015
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool isNullReferenceControl(this Control control)
        {
            return (control == null);
        }
        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Devuelvel el valor del enum pasando como parametro su nombre y el tipo del enmum
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static int getvalueFromEnumType(String Name, Type enumType)
        {
            var value = -1;

            if (!string.IsNullOrEmpty(Name))
            {
                var lst = enumType.ToListEnum();
                value = int.Parse(lst.Where(x => x.Value.ToLower() == Name.ToLower()).First().Key);
            }

            return value;
        }
        /// <summary>
        /// Devuelve el valor del enum como par Key Value
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> ToListEnum(this Type enumType)
        {
            var arrValues = Enum.GetValues(enumType);
            var arrNames = Enum.GetNames(enumType);

            List<KeyValuePair<string, string>> lstCodigos =
              arrNames.Select((name, index) => new KeyValuePair<string, string>(
                arrValues.GetValue(index).GetHashCode().ToString(), name)).ToList();

            return lstCodigos;
        }
		public static bool IsSessionExpired()
		{
			if (HttpContext.Current.Session != null)
			{
				if (HttpContext.Current.Session.IsNewSession)
				{
					string CookieHeaders = HttpContext.Current.Request.Headers["Cookie"];

					if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
					{
						// IsNewSession is true, but session cookie exists,
						// so, ASP.NET session is expired
						return true;
					}
				}
			}

			// Session is not expired and function will return false,
			// could be new session, or existing active session
			return false;
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsPercent(this string value)
		{
			var reg = new Regex("\\d{1,3}[.\\d{1,2}]{0,1}%");
			return reg.IsMatch(value);
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsDate(this string value)
		{
			DateTime d;
			return DateTime.TryParse(value, out d);
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsDecimal(this string value)
		{
			decimal d;
			return Decimal.TryParse(value, out d);
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsInt(this string value)
		{
			int d;
			return Int32.TryParse(value, out d);
		}

		public static void SetGridFilterSettings(ASPxGridView grid)
		{
			foreach (GridViewColumn column in grid.Columns)
			{
				if (column is GridViewDataColumn)
				{
					object value = grid.GetRowValues(0, ((GridViewDataColumn)column).FieldName);
					if (value is String)
						((GridViewDataColumn)column).Settings.AutoFilterCondition = AutoFilterCondition.Contains;
					else
						((GridViewDataColumn)column).Settings.AutoFilterCondition = AutoFilterCondition.Equals;
				}
			}
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Nullable<DateTime> IsDateReturnNull(this string value)
		{
			DateTime d;
			bool resut = DateTime.TryParse(value, out d);

			if (resut)
				return d;
			else
				return new Nullable<DateTime>();

		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Nullable<double> IsDoubleReturnNull(this string value)
		{
			double d;
			bool resut = double.TryParse(value, out d);

			if (resut)
				return d;
			else
				return new Nullable<double>();
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Nullable<double> IslongReturnNull(this string value)
		{
			long d;
			bool resut = long.TryParse(value, out d);

			if (resut)
				return d;
			else
				return new Nullable<long>();
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Nullable<Int32> IsIntReturnNull(this string value)
		{
			int d;
			bool resut = Int32.TryParse(value, out d);

			if (resut)
				return d;
			else
				return new Nullable<Int32>();
		}

		/// <summary>
		/// Author: Gregory Garcia
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static Nullable<Int16> IsShortReturnNull(this string value)
		{
			Int16 d;
			bool resut = Int16.TryParse(value, out d);

			if (resut)
				return d;
			else
				return new Nullable<Int16>();
		}

		/// <summary>
		///  Author: Lic. Carlos Ml. Lebron
		///  Serializa un objeto T a formato JSON
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static string serializeToJSON<T>(T item)
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
			var objeto = new JavaScriptSerializer().Deserialize<T>(Json);
			return objeto;
		}
        
		/// <summary>
		///  Author: Lic. Carlos Ml. Lebron
		///  Created Date :11-25-2014
		///  Obtener la data de un dropdownlist segun su tipo y bindearlo con esa data
		/// </summary>
		public static void GettingAllDropsJSON(ref DropDownList ddl,
										   DropDownType dropDownType,
										   string DataTextField = null,
										   bool GenerateItemSelect = false,
										   int? corpId = null,
										   int? regionId = null,
										   int? countryId = null,
										   int? domesticregId = null,
										   int? stateProvId = null,
										   int? cityId = null,
										   int? officeId = null,
										   int? caseSeqNo = null,
										   int? histSeqNo = null,
										   int? contactId = null,
										   int? agentId = null,
										   bool? isInsured = null,
										   int? occupGroupTypeId = null,
										   int? requirementCategory = null,
										   int? requirementType = null
										   )
		{

			//Limpiar el dropdown antes de bindearlo
			ddl.Items.Clear();

			//DI.UnderWriting.Interfaces.IDropDown dropdownManager;
			// var diManager = new DI.UnderWriting.UnderWritingDIManager();
			// dropdownManager = diManager.DropDownManager;

			var data = Services.DropDownManager.GetDropDownByType(new DropDown.Parameter 
			{ 
				DropDownType = dropDownType.ToString(), 
				CorpId = corpId, 
				RegionId = regionId, 
				CountryId = countryId, 
				DomesticregId = domesticregId, 
				StateProvId = stateProvId, 
				CityId = cityId, 
				OfficeId = officeId, 
				CaseSeqNo = caseSeqNo, 
				HistSeqNo = histSeqNo, 
				ContactId = contactId, 
				AgentId = agentId, 
				OccupGroupTypeId = occupGroupTypeId, 
				IsInsured = isInsured, 
				RequirementCatId = requirementCategory 
			});
			
			ddl.DataSource = data;
			ddl.DataTextField = DataTextField;
			ddl.DataValueField = "ValueField";
			ddl.DataBind();

			if (ddl.Items.Count > 0)
			{
				if (GenerateItemSelect)
				{
					ddl.Items.Insert(0, new ListItem() 
					{ 
						Value = "-1", 
						Text = "Select" 
					});
				}
			}
		}

		public static void MessageBox(this Control Ctrl, String Message, int? Width = null, int? Height = null, Boolean isModal = true, String Title = "Alert")
		{
			var Func = string.Format("CustomDialogMessageEx('{0}',{1},{2},{3},'{4}');", Message, 
																						Width.HasValue ? Width.ToString() : "null", 
																						Height.HasValue ? Height.ToString() : "null", 
																						isModal.ToString().ToLower(), 
																						Title);
			ExcecuteJScript(Ctrl, Func);
		}

		public class PolicyKeyItem
		{
			public int CorpId { get; set; }
			public int RegionId { get; set; }
			public int CountryId { get; set; }
			public int DomesticregId { get; set; }
			public int StateProvId { get; set; }
			public int CityId { get; set; }
			public int OfficeId { get; set; }
			public int CaseSeqNo { get; set; }
			public int HistSeqNo { get; set; }
			public int ContactId { get; set; }
			public int UnderwriterId { get; set; }
		}
        public class provider
        {
            public int? ProviderTypeId { get; set; }
            public int? ProviderId { get; set; }
            //public string ProviderName { get; set; }
            public string ElementDesc { get; set; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="gv"></param>
		public static void SetFilterSettings(this ASPxGridView gv)
		{
			foreach (GridViewColumn column in gv.Columns)
			{
				if (column is GridViewDataColumn)
				{
					object value = gv.GetRowValues(0, ((GridViewDataColumn)column).FieldName);
					if (value is String)
						((GridViewDataColumn)column).Settings.AutoFilterCondition = AutoFilterCondition.Contains;
					else
						((GridViewDataColumn)column).Settings.AutoFilterCondition = AutoFilterCondition.Equals;
				}
			}
		}

		/// <summary>
		///  Author: Lic. Carlos Ml. Lebron
		///  Es un metodo de extencion para los controles que ejecuta del lado del cliente el codigo javascript pasado como parametro en la variable JScript   
		/// </summary>
		/// <param name="JScript"></param>
		public static void ExcecuteJScript(this Control Container, string JScript)
		{
			ScriptManager.RegisterStartupScript(Container.Page, Container.Page.GetType(), null, JScript, true);
		}

		public static bool SendOutlookAppointment(DateTime appointmentStartDate, DateTime appointmentEndDate,
			Boolean important, int remindMinutesBefore, String subject, String appointmentBody, String appointmentLocation, String email)
		{
			try
			{
				var service = new Services();
				var filepath = service.TempFilePath + "\\appointmentTemplate.ics";
				// use PUBLISH for appointments
				// use REQUEST for meeting requests
				const string method = "PUBLISH";

				var message = new MailMessage()
				{
					From = new MailAddress(service.FromEmail),
					Subject = subject,
					Body = appointmentBody,
					Priority = MailPriority.High
				};

				message.To.Add(service.TestReceiptEmail);

				// iCal
				var iCal = new iCalendar()
				{
					Method = method,
					ProductID = "My Metting Product"
				};

				// Create an event and attach it to the iCalendar.
				var evt = iCal.Create<Event>();
				//evt = new Event()
				//{
				evt.UID = GetSerialId();
				evt.Class = "PUBLIC";
				evt.Created = new iCalDateTime(DateTime.Now);
				evt.DTStamp = new iCalDateTime(DateTime.Now);
				evt.Transparency = TransparencyType.Transparent;
				evt.Start = new iCalDateTime(appointmentStartDate);
				evt.End = new iCalDateTime(appointmentEndDate);
				evt.Location = appointmentLocation;
				evt.Description = appointmentBody;
				evt.Summary = subject;
				// 1: High
				// 5: Normal
				// 9: low
				evt.Priority = 1;
				//};

				// Let’s also add an alarm on this event so we can be reminded of it later.
				var alarm = new Alarm()
				{
					Action = AlarmAction.Display,
					Summary = "Upcoming meeting: " + subject,
					Trigger = new Trigger(TimeSpan.FromMinutes(-remindMinutesBefore)),
				};

				var serializer = new iCalendarSerializer();
				serializer.Serialize(iCal, filepath);

				// the .ics File as a string
				var iCalStr = serializer.SerializeToString(iCal);
				var calendarType = new System.Net.Mime.ContentType("text/calendar");
				calendarType.Parameters.Add("method", method);
				var ICSview = AlternateView.CreateAlternateViewFromString(iCalStr, calendarType);

				// Compose
				message.AlternateViews.Add(ICSview); // must be the last part

				// .ics as Attachment (used by mail clients other than Outlook)
				var bytes = Encoding.ASCII.GetBytes(iCalStr);
				var ms = new MemoryStream(bytes);
				var a = new System.Net.Mail.Attachment(ms, "Underwriting Call Appointment.ics", "text/calendar");
				message.Attachments.Add(a);

				// Send Mail
				var client = new SmtpClient(service.SmtpServer);
				client.Send(message);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string GetMimeTypeByFileName(string sFileName)
		{
			string sMime = "application/octet-stream";

			string sExtension = System.IO.Path.GetExtension(sFileName);
			if (!string.IsNullOrEmpty(sExtension))
			{
				sExtension = sExtension.Replace(".", "");
				sExtension = sExtension.ToLower();

				if (sExtension == "xls" || sExtension == "xlsx")
				{
					sMime = "application/ms-excel";
				}
				else if (sExtension == "doc" || sExtension == "docx")
				{
					sMime = "application/msword";
				}
				else if (sExtension == "ppt" || sExtension == "pptx")
				{
					sMime = "application/ms-powerpoint";
				}
				else if (sExtension == "rtf")
				{
					sMime = "application/rtf";
				}
				else if (sExtension == "zip")
				{
					sMime = "application/zip";
				}
				else if (sExtension == "mp3")
				{
					sMime = "audio/mpeg";
				}
				else if (sExtension == "bmp")
				{
					sMime = "image/bmp";
				}
				else if (sExtension == "gif")
				{
					sMime = "image/gif";
				}
				else if (sExtension == "jpg" || sExtension == "jpeg")
				{
					sMime = "image/jpeg";
				}
				else if (sExtension == "png")
				{
					sMime = "image/png";
				}
				else if (sExtension == "tiff" || sExtension == "tif")
				{
					sMime = "image/tiff";
				}
				else if (sExtension == "txt")
				{
					sMime = "text/plain";
				}
			}

			return sMime;
		}

		public static void StreamFileToBrowser(string sFileName, byte[] fileBytes)
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			context.Response.Clear();
			context.Response.ClearHeaders();
			context.Response.ClearContent();
			context.Response.AppendHeader("content-length", fileBytes.Length.ToString());
			context.Response.ContentType = GetMimeTypeByFileName(sFileName);
			context.Response.AppendHeader("content-disposition", "attachment; filename=" + sFileName);
			context.Response.BinaryWrite(fileBytes);

			context.ApplicationInstance.CompleteRequest();
		}

		public class EmailAttachmentItem
		{
			public int DocCountId { get; set; }
			public int? DocCategoryId { get; set; }
			public int? DocTypeId { get; set; }
			public int? DocumentId { get; set; }

			public String DocName { get; set; }
			public String DocExtension { get; set; }
			public Decimal DocSize { get; set; }
			public String FilePath { get; set; }
			public int? FileTypeId { get; set; }
		}

		public static int GetFileTypeFromExt(String extension)
		{
			extension = extension.Replace(".", "");

			var fileType = (AttachmentFileType)Enum.Parse(typeof(AttachmentFileType), extension);

			return (int)fileType;
		}

		public static String GetFileNameWithoutExt(String origFileName)
		{
			int nameIndex = -1;
			string name = "";
			if (origFileName != null)
			{
				nameIndex = origFileName.LastIndexOf('.');
				name = nameIndex == -1 ? origFileName : origFileName.Substring(0, nameIndex);
			}
			return name.Trim();
		}

		public static void SaveExceptions(Exception exception, Int64 UserID)
		{
			//var HostName = NetworkingUtilities.GetHostName();

			//if (System.Configuration.ConfigurationSettings.AppSettings["SendEmail"].ToString().ToLower() == "true")
			//{
			//    MailManager.SendMessage(
			//    System.Configuration.ConfigurationSettings.AppSettings["TestEmails"].ToString().ToLower(),
			//     "clebron@statetrustlife.com;jgomez@statetrustlife.com",
			//     "",
			//     "The error was generated from : " + HostName + "\n" + exception.Message + "******************************" + exception.StackTrace,
			//     System.Configuration.ConfigurationSettings.AppSettings["EmailFrom"].ToString(),
			//     System.Configuration.ConfigurationSettings.AppSettings["SubjectEmails"].ToString(),
			//     "",
			//     false
			//     );
			//}

		}

		/// <summary>
		/// 
		/// </summary>
		public class NetworkingUtilities
		{
			public static string GetHostName()
			{
				var hostName = Dns.GetHostName();
				return hostName;
			}

			public static IPAddress GetLocalIpaddress()
			{
				var host = Dns.GetHostEntry(Dns.GetHostName());
				var localIp = host.AddressList.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
				return localIp;
			}
		}

		//2016-02-12 | Marcos J. Perez
		/// <summary>
		/// Obtener BMI
		/// </summary>
		/// <param name="Weight">Metric == true then Kilograms else Pounds</param>
		/// <param name="Height">Metric == true then Meters else Inches</param>
		/// <param name="Metric">false then US Calculation else Metric Calculation</param>
		/// <returns></returns>
		public static string BMI(string Weight, string Height, bool Metric)
		{
			double height = 0d;
			if (!string.IsNullOrWhiteSpace(Height)) { double.TryParse(Height, out height); }

			double weight = 0d;
			if (!string.IsNullOrWhiteSpace(Weight)) { double.TryParse(Weight, out weight); }

            double bmi = (height >= 0 && weight >= 0) ? weight / Math.Pow(height, 2d): 0d;  
			if (bmi > 0d && !Metric) { bmi *= 703; }

			return bmi.ToString("N2") == "NaN" ? "0.00" : bmi.ToString("N2");
		}
	}
}
