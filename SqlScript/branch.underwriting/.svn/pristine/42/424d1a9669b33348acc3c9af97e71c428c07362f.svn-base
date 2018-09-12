using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.ConfirmationCall.Common
{
    /// <summary>
    /// Author: Lic. Carlos Ml. Lebron
    /// </summary>
    public static class Utility
    {
        public static void FillCorpId(int corpId)
        {
            if (generalCorpId == 0)
                generalCorpId = corpId;
        }

        #region Enums
        public enum DropDownType
        {
            Occupation,
            Profession,
            OccupationType,
            City,
            Country,
            MaritalStatus,
            PolicyStatus,
            ByDate,
            Manager,
            SubManager,
            Office,
            AddressType,
            PhoneType,
            EmailType,
            Smoker,
            Gender,
            Summary,
            StateProvince,
            Relationship,
            IdType,
            Agent,
            AmmendmentType,
            AmmendmentTypeScope,
            RiderStatus,
            LengthatWork,
            Months,
            IssuedBy,
            PrimaryBeneficiary,
            PlanType,
            Product,
            Currency,
            Serie,
            ProfileType,
            PaymentFrequency,
            PolicyContactByRole,
            ProfileType_NewBusiness,
            ContributionType,
            PaymentType,
            PaymentTypeCheck,
            PaymentTypeCC,
            PaymentSource,
            ReceiptType,
            RetirementPeriod,
            DefermentPeriod,
            ProductByFamily
        }

        public enum ContactRoleIDType { Client = 2, Owner = 1, DesignatedPensioner = 5, AddicionalInsure = 3, Student = 6 };


        public enum OperationType { Insert, InsertAll, Edit, Delete };

        public enum TypeReportGenerate
        {
            ExportToExcel,
            ExportToPDF,
            ExportToHTML,
            ExportToCSV
        }

        public enum Order : byte { Asc, Desc }

        public enum CommType
        {
            Phone,
            Email,
            Address
        }
        #endregion

        #region Items DropDown

        public class YearsItem
        {
            public Int32 Year { get; set; }
            public string YearDescription { get; set; }
        }

        public class itemOfficce
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int AgentId { get; set; }
        }

        public class StateProvince
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
        }

        /// <summary>
        /// Para llenar el Dropdown de los Tipos de Compañías en el tab de Beneficiarios
        /// </summary>
        public class CompanyType
        {
            public Int32 OccupationId { get; set; }
            public Int32 OccupGroupTypeId { get; set; }
        }

        public class itemProduct
        {
            public int CorpId { get; set; }

            public int CountryId { get; set; }

            public int BlId { get; set; }
            public int ProductId { get; set; }

            public int RegionId { get; set; }
            public int BlTypeId { get; set; }

        }

        public class ProfileType
        {
            public int CorpId { get; set; }
            public int CurrencyId { get; set; }
            public int ProfileTypeId { get; set; }


        }

        public class FamilyProduct
        {
            public int CorpId { get; set; }
            public int BlTypeId { get; set; }
            public int CountryId { get; set; }

            public int BlId { get; set; }

            public int RegionId { get; set; }
        }

        public struct RequirementsValues
        {
            public int ID { get; set; }
            public int CategoryID { get; set; }
            public int TypeID { get; set; }
            public int ContactID { get; set; }
            public int? DocId { get; set; }
            public bool HasDocument { get; set; }
        }


        public class ddlEntityTypeItem
        {
            public int OccupationId { get; set; }
            public int OccupGroupTypeId { get; set; }
        }


        public class PaymentSource
        {
            public int PaymentSourceTypeId { get; set; }
            public int PaymentSourceId { get; set; }
            public int PaymentControlId { get; set; }


        }

        #endregion

        public struct DateRange
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        private static int generalCorpId;

        private static byte[] key = { };

        private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };

        public static decimal? ToDecimal(this TextBox txt)
        {
            return decimal.Parse(txt.Text);
        }

        public static int getvalueFromEnumType(String Name, Type enumType)
        {
            var lst = enumType.ToListEnum();
            var value = int.Parse(lst.Where(x => x.Value == Name).First().Key);
            return value;
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

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Añade al UpdatePanel pasado como parametro en udp un trigger al control pasado en el parametro ControlID
        ///  Created Date: 11/29/2014  
        /// </summary>
        /// <param name="udp"></param>
        /// <param name="ControlID"></param>
        /// <param name="EventName"></param>
        public static void AddTrigger(this UpdatePanel udp, string ControlID, String EventName = "")
        {
            //var Trigger = new AsyncPostBackTrigger();

            var Trigger = new PostBackTrigger();
            //ControlID = ID del control que provoca el evento.
            Trigger.ControlID = ControlID;
            //EventName = Nombre del evento, p.e: Click, SelectedIndexChange.
            //Trigger.EventName = EventName;
            //Se añade el trigger al update panel                            
            udp.Triggers.Add(Trigger);
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
        ///  Busca el registro dentro de la lista segun el criterio pasado en el predicate oItem
        ///  Created Date: 11/29/2014  
        /// <summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oList"></param>
        /// <param name="oItem"></param>
        /// <returns></returns>
        public static bool RecordExistInList<T>(this List<T> oList, Func<T, bool> oItem) where T : class
        {
            return oList.Where(oItem).Any();
        }

        /// <summary>
        ///  Es un metodo de extencion para los controles que ejecuta del lado del cliente el codigo javascript pasado como parametro en la variable JScript   
        /// </summary>
        /// <param name="JScript"></param>
        public static void ExcecuteJScript(this Control Container, string JScript)
        {
            ScriptManager.RegisterStartupScript(Container.Page, Container.Page.GetType(), null, JScript, true);
        }
        
        /// <summary>
        /// Obtiene el Tab actual de la pagina Add New Client
        /// Debes enviarle this en el parametro UC
        /// </summary>
        /// <param name="UC"></param>
        /// <returns></returns>
        public static string GetCurrentTabAddNewClient(UserControl UC)
        {
            var Tab = string.Empty;
            var hdnCurrentTabAddNewClient = UC.Page.Master.FindControl("bodyContent").FindControl("hdnCurrentTabAddNewClient");
            if (hdnCurrentTabAddNewClient != null)
            {
                Tab = (hdnCurrentTabAddNewClient as HiddenField).Value;
            }
            return Tab;
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/29/2014        
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this TextBox txt)
        {
            return DateTime.Parse(txt.Text);
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/29/2014        
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int ToInt(this TextBox txt)
        {
            return
               ConvertStringToInt(txt.Text);
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/30/2014
        /// </summary>
        /// <param name="hdn"></param>
        /// <returns></returns>
        public static int ToInt(this HiddenField hdn)
        {
            return
               ConvertStringToInt(hdn.Value);
        }

        /// <summary>
        /// Try to convert a string to a int, if the string is not a number it return a default value in case that you no provide a default value it return -1.
        /// </summary>
        /// <param name="value">A string to try to convert.</param>
        /// <param name="defaultValue">The default value that you want to return in case the convertion fail.</param>
        /// <returns>int</returns>
        private static int ConvertStringToInt(string value, int? defaultValue = null)
        {
            int result;

            value = !string.IsNullOrWhiteSpace(value)
                ? value.Trim()
                : string.Empty;

            if (!int.TryParse(value, out result))
                result = defaultValue.HasValue ? defaultValue.Value : -1;

            return
                result;
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/28/2014
        /// </summary>
        /// <param name="drop"></param>
        /// <returns></returns>
        public static int ToInt(this DropDownList drop)
        {
            return
                ConvertStringToInt(drop.SelectedValue);
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/28/2014
        ///  devuelve la cantidad de filas de in gridview
        ///  <param name="gv"></param>
        /// <returns></returns>
        public static int getRowcountFromGridView(this GridView gv)
        {
            return gv.Rows.Count;
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/28/2014
        ///  devuelve un arreglo de los valores de los keyfieldname de un aspxGridView
        /// </summary>
        /// <param name="aspxGridView"></param>
        /// <param name="RowIndex"></param>
        /// <returns></returns>
        public static object[] GetKeysFromAspxGridView(this ASPxGridView aspxGridView)
        {
            var KeyArray = aspxGridView.GetRowValues(aspxGridView.FocusedRowIndex, aspxGridView.KeyFieldName).ToString().Split('|');
            return KeyArray;
        }

        /// <summary>
        ///  Author: Lic. Carlos Ml. Lebron
        ///  Created Date: 11/28/2014
        /// devuelve el keyvalue del keyname pasado como paramero un aspxGridView el grid debe tener configurado AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true"
        /// </summary>
        /// <param name="aspxGridView"></param>
        /// <param name="RowIndex"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object GetKeyFromAspxGridView(this ASPxGridView aspxGridView, string keyName)
        {
            dynamic result = null;
            var Key = aspxGridView.GetRowValues(aspxGridView.FocusedRowIndex, keyName);

            if (key != null)
            {
                result = Key;
            }

            return result;
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
        public static object GetKeyFromAspxGridView(this ASPxGridView aspxGridView, string keyName, int RowIndex)
        {
            dynamic result = null;
            var Key = aspxGridView.GetRowValues(RowIndex, keyName);

            if (key != null)
            {
                result = Key;
            }

            return result;
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

        public static void SaveExceptions(Exception exception, Int64 UserID)
        {
            var HostName = NetworkingUtilities.GetHostName();

            if (System.Configuration.ConfigurationManager.AppSettings["SendEmail"].ToString().ToLower() == "true")
            {
                //MailManager.SendMessage(
                //    to:System.Configuration.ConfigurationManager.AppSettings["TestEmails"].ToString().ToLower(),
                //    Copia:"clebron@statetrustlife.com;jgomez@statetrustlife.com",
                //    BCC:"",
                //    Body:"The error was generated from : " + HostName + "\n" + exception.Message + "******************************" + exception.StackTrace,
                //    From:System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString(),
                //    Subject: System.Configuration.ConfigurationManager.AppSettings["SubjectEmails"].ToString(),
                //    Attachments: "",
                //    ishtml: false
                // );
            }

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
                                           bool GenerateItemSelect = true,
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
                                           int? requirementType = null,
                                           int? BlTypeId = null,
                                           int? BlId = null,
                                           int? currencyId = null

                                           )
        {

            //Limpiar el dropdown antes de bindearlo
            ddl.Items.Clear();

            if (!corpId.HasValue)
                corpId = generalCorpId;

            var data = new Services().oDropDownManager.GetDropDownByType(new DropDown.Parameter {
                                                          DropDownType=Enum.GetName(typeof(DropDownType), dropDownType),
                                                          CorpId = corpId,
                                                          RegionId = regionId,
                                                          CountryId=countryId,
                                                          DomesticregId=domesticregId,
                                                          StateProvId=stateProvId,
                                                          CityId=cityId,
                                                          OfficeId=officeId,
                                                          CaseSeqNo=caseSeqNo,
                                                          HistSeqNo=histSeqNo,
                                                          ContactId=contactId,
                                                          AgentId=agentId,
                                                          IsInsured=isInsured,
                                                          OccupGroupTypeId=occupGroupTypeId,
                                                          RequirementCatId=requirementCategory,
                                                          //RequirementType=requirementType,
                                                          RiskDetId=null,
                                                          RiskGroupId=null,
                                                          TableTypeId=null,
                                                          BlTypeId=BlTypeId,
                                                          BlId=BlId,
                                                          CurrencyId=currencyId
                                                        });
            if (data != null)
            {
                ddl.DataSource = data;
                ddl.DataTextField = DataTextField;
                ddl.DataValueField = "ValueField";
                ddl.DataBind();
            }



            if (GenerateItemSelect)
            {
                ddl.Items.Insert(0, new ListItem() { Value = "-1", Text = "Select" });
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl">Dropdown </param>
        /// <param name="dropDownType"></param>
        /// <param name="DataTextField"></param>
        /// <param name="DataValueField"></param>
        /// <param name="GenerateItemSelect"></param>
        /// <param name="corpId"></param>
        /// <param name="regionId"></param>
        /// <param name="countryId"></param>
        /// <param name="domesticregId"></param>
        /// <param name="stateProvId"></param>
        /// <param name="cityId"></param>
        /// <param name="officeId"></param>
        /// <param name="caseSeqNo"></param>
        /// <param name="histSeqNo"></param>
        /// <param name="contactId"></param>
        /// <param name="agentId"></param>
        /// <param name="isInsured"></param>
        /// <param name="occupGroupTypeId"></param>
        /// <param name="requirementCategory"></param>
        /// <param name="requirementType"></param>
        public static void GettingAllDrops(ref DropDownList ddl,
                                           DropDownType dropDownType,
                                           string DataTextField = null,
                                           string DataValueField = null,
                                           bool GenerateItemSelect = true,
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
                                           int? requirementType = null,
                                           int? BlTypeId = null,
                                           int? BlId = null,
                                           int? PaymentSourceId = null,
                                           int? PaymentSourceTypeId = null,
                                           int? currencyId = null
                                           )
        {
            //Limpiar el dropdown antes de bindearlo
            ddl.Items.Clear();

            if (dropDownType != DropDownType.LengthatWork &&
                dropDownType != DropDownType.Months &&
                dropDownType != DropDownType.RetirementPeriod &&
                dropDownType != DropDownType.DefermentPeriod
               )
            {
                if (!corpId.HasValue)
                    corpId = generalCorpId;

                var data = new Services().oDropDownManager.GetDropDownByType(new DropDown.Parameter {
                                                          DropDownType=Enum.GetName(typeof(DropDownType), dropDownType),
                                                          CorpId = corpId,
                                                          RegionId = regionId,
                                                          CountryId=countryId,
                                                          DomesticregId=domesticregId,
                                                          StateProvId=stateProvId,
                                                          CityId=cityId,
                                                          OfficeId=officeId,
                                                          CaseSeqNo=caseSeqNo,
                                                          HistSeqNo=histSeqNo,
                                                          ContactId=contactId,
                                                          AgentId=agentId,
                                                          IsInsured=isInsured,
                                                          OccupGroupTypeId=occupGroupTypeId,
                                                          RequirementCatId=requirementCategory,
                                                          //RequirementType=requirementType,
                                                          RiskDetId=null,
                                                          RiskGroupId=null,
                                                          TableTypeId=null,
                                                          BlTypeId=BlTypeId,
                                                          BlId=BlId,
                                                          //PaymentSourceId: PaymentSourceId,
                                                          //PaymentSourceTypeId: PaymentSourceTypeId,
                                                          CurrencyId=currencyId
                                                        });
                ddl.DataSource = data;
                ddl.DataTextField = DataTextField;

                if (dropDownType == DropDownType.StateProvince ||
                    dropDownType == DropDownType.Agent)
                    ddl.DataValueField = "ValueField";
                else
                    ddl.DataValueField = DataValueField;

                ddl.SelectedIndex = -1;

                ddl.DataBind();

                if (ddl.Items.Count > 0)
                {
                    if (GenerateItemSelect)
                    {
                        ddl.Items.Insert(0, new ListItem() { Value = "-1", Text = "Select" });
                        ddl.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                ddl.Items.Clear();

                switch (dropDownType)
                {
                    case DropDownType.LengthatWork:
                        for (int x = 1; x <= 60; x++)
                            ddl.Items.Add(new ListItem() { Value = x.ToString(), Text = x.ToString() });
                        break;

                    case DropDownType.Months:
                        for (int x = 1; x <= 12; x++)
                            ddl.Items.Add(new ListItem() { Value = x.ToString(), Text = x.ToString() });
                        break;

                    case DropDownType.RetirementPeriod:
                        for (int x = 5; x <= 30; x++)
                            ddl.Items.Add(new ListItem() { Value = x.ToString(), Text = x.ToString() });
                        break;

                    case DropDownType.DefermentPeriod:
                        for (int x = 0; x <= 30; x++)
                            ddl.Items.Add(new ListItem() { Value = x.ToString(), Text = x.ToString() });
                        break;
                }


                if (GenerateItemSelect)
                {
                    ddl.Items.Insert(0, new ListItem() { Value = "-1", Text = "Select" });
                    ddl.SelectedIndex = 0;
                }

            }

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

                switch (ptype)
                {
                    case "Boolean": resultFieldAndValue = "true";
                        break;
                    case "Int32": resultFieldAndValue = new Random().Next(1, 999999);
                        break;
                    case "Decimal": resultFieldAndValue = decimal.Parse(new Random().Next(1, 999999).ToString());
                        break;
                    case "DateTime": resultFieldAndValue = DateTime.Now;
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
            {
                if (generateSecuencialCodeInFirstField)
                    JsonData += record.Replace(":\"" + FirstField + "\"", ":\"" + FirstField + " - " + string.Format("{0:000000}", x) + "\"") + ",";
                else
                    JsonData += record + ",";
            }

            JsonData = JsonData.Substring(0, JsonData.Length - 1);
            JsonData += "]";

            var Data = new JavaScriptSerializer().Deserialize<List<T>>(JsonData);

            return Data;
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron
        /// Este metodo es para limpiar o inicializa los componentes de un WebUserControl
        /// </summary>
        /// <param name="uc"></param>
        public static void InitializateFormControls(this System.Web.UI.UserControl uc)
        {
            foreach (Control control in uc.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = String.Empty;
                else if (control is DropDownList)
                {
                    //Valido si el DropDownList para luego posicionarnos 
                    //en el inice 0 de la lista
                    if (((DropDownList)control).Items.Count > 0)
                        ((DropDownList)control).SelectedIndex = 0;
                }
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is GridView)
                {
                    ((GridView)control).DataSource = null;
                    ((GridView)control).DataBind();
                }
            }

        }

        /// <summary>
        ///   Author: Lic. Carlos Ml Lebron
        ///   Oculta o Muestra los elementos que estan dentro de un contenedor de controles
        /// </summary>
        /// <param name="Controls"></param>
        /// <param name="Show"></param>
        public static void HideShowAllControls(ControlCollection Controls, bool Show)
        {
            foreach (Control control in Controls)
                control.Visible = Show;
        }

        /// <summary>
        /// Author: Lic. Carlos ML. Lebron B.
        /// Verifica que la contraseña Tenga al menos un caracter en mayuscula,
        /// al menos un caracter en miniscula, un caracter numerico y un tamaño minimo de 8 caracteres
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="messageError"></param>
        /// <returns></returns>
        public static bool ValiateSecurityPassword(String pass, String Lang, out String messageError)
        {
            var errorSummary = new StringBuilder();

            messageError = "";

            var mayusculas = 0;
            var minusculas = 0;
            var caracteres = pass.Length;
            var numeros = 0;
            string msj;

            //Verificar si la cadena tiene al menos una mayuscula, minuscula, numeros y un minimo de 8 caracteres
            for (var x = 0; x <= pass.Length - 1; x++)
            {
                if (char.IsUpper(pass[x]))
                    mayusculas++;

                if (char.IsLower(pass[x]))
                    minusculas++;

                if (char.IsNumber(pass[x]))
                    numeros++;
            }

            if (mayusculas == 0)
            {
                msj = (Lang == "EN") ? "* The new password must have at least one character in uppercase" : "* La nueva clave debe tener al menos un carácter en mayúscula";
                errorSummary.AppendLine(msj);
            }

            if (minusculas == 0)
            {
                msj = (Lang == "EN") ? "* The new password must have at least one character lowercase" : "* La nueva clave debe tener al menos un carácter en minúscula";
                errorSummary.AppendLine(msj);
            }

            if (numeros == 0)
            {
                msj = (Lang == "EN") ? "* The new password must have at least one number" : "* La nueva clave debe tener al menos un número";
                errorSummary.AppendLine(msj);
            }

            if (caracteres < 8)
            {
                msj = (Lang == "EN") ? "* The new password must be a minimum of 8 characters" : "* La nueva clave debe tener un mínimo de 8 caracteres";
                errorSummary.AppendLine(msj);
            }


            if (errorSummary.Length > 0)
                messageError = errorSummary.ToString();

            return (mayusculas >= 1) && (minusculas >= 1) && (numeros >= 1) && (caracteres >= 8);

        }

        public static bool EmailIsValid(string emailaddress)
        {
            try
            {
                var m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron.
        /// Quitar el Chequeo de todos los items de un CheckBoxList
        /// </summary>
        /// <param name="chkList"></param>
        public static void UnCheckAll(this CheckBoxList chkList)
        {
            foreach (ListItem item in chkList.Items)
                item.Selected = false;
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron.
        /// Contar cuantos items han sido chequeados
        /// </summary>
        /// <param name="chkList"></param>
        /// <returns></returns>
        public static int CheckedCount(this CheckBoxList chkList)
        {
            return chkList.Items.Cast<ListItem>().Count(item => item.Selected);
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron.
        /// Chequear todos los items de un CheckBoxList
        /// </summary>
        /// <param name="chkList"></param>
        public static void CheckAll(this CheckBoxList chkList)
        {
            foreach (ListItem item in chkList.Items)
                item.Selected = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal Truncate(this decimal x)
        {
            return Math.Truncate(x);
        }

        /// <summary>
        /// Limpiar el texto de los textBox
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="txt"></param>
        public static void Clear(this TextBox txt)
        {
            txt.Text = string.Empty;
        }

        /// <summary>
        /// Limpiar el texto de los Literal
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="txt"></param>
        public static void Clear(this Literal Lt)
        {
            Lt.Text = string.Empty;
        }

        /// Limpiar el texto de los textBox
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="txt"></param>
        public static void Clear(this Literal Lt, String InicializerCharacter)
        {
            Lt.Text = InicializerCharacter;
        }

        /// Limpiar el texto de los textBox
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="txt"></param>
        public static void Clear(this TextBox txt, String InicializerCharacter)
        {
            txt.Text = InicializerCharacter;
        }

        /// <summary>
        /// Bindea el GridView Con el datasource Pasado en la variable DataSource
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="GridView"></param>
        /// <param name="DataSource"></param>
        public static void DatabindGridView(this GridView GridView, Object DataSource)
        {
            if (DataSource != null)
            {
                GridView.DataSource = DataSource;
                GridView.DataBind();
            }

        }

        /// <summary>
        /// Convertir DataTable a array byte de csv
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static byte[] AsCSVArraByte(this DataTable dt)
        {
            var Line = string.Empty;
            var Header = string.Empty;

            var Listado = new List<string>();

            //Obtener el Header
            Header = dt.Columns.Cast<DataColumn>().Aggregate(Header, (current, item) => current + (item.ColumnName.ToString().QuotedString() + ","));

            Header = Header.Remove(Header.Length - 1, 1);

            Listado.Add(Header);

            foreach (DataRow Row in dt.Rows)
            {
                Line = dt.Columns.Cast<DataColumn>().Aggregate(Line, (current, Col) => current + (Row[Col].ToString().QuotedString() + ","));

                Line = Line.Remove(Line.Length - 1, 1);
                Listado.Add(Line);
                Line = string.Empty;
            }

            string[] strArrayResult = Listado.ToArray();

            var sb = new StringBuilder();

            foreach (var item in strArrayResult)
                sb.AppendLine(item);



            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());
        }


        /// <summary>
        /// Convertir IEnumerable<T> a array byte de csv
        /// Autores: Lic. Carlos Ml Lebron B
        ///          Ing. Carlos Soriano.        
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static byte[] AsCSVArraByte<T>(this IEnumerable<T> Data) where T : class
        {
            var Line = string.Empty;
            var Header = string.Empty;

            var Listado = new List<string>();

            //Obtener las propiedades
            PropertyInfo[] Props = typeof(T).GetProperties();

            //Obtener el Header
            Header = Props.Aggregate(Header, (current, item) => current + (item.Name.ToString().QuotedString() + ","));

            Header = Header.Remove(Header.Length - 1, 1);

            Listado.Add(Header);

            foreach (var item in Data)
            {
                Line = Props.Aggregate(Line, (current, prop) => current + (item.GetType().GetProperty(prop.Name).GetValue(item, null).ToString().QuotedString() + ","));

                Line = Line.Remove(Line.Length - 1, 1);
                Listado.Add(Line);
                Line = string.Empty;
            }

            string[] strArrayResult = Listado.ToArray();

            var sb = new StringBuilder();

            foreach (var item in strArrayResult)
                sb.AppendLine(item);

            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());
        }

        /// <summary>
        /// Author: Lic. Carlos Ml. Lebron.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties, bool AllToString = false) where T : new()
        {
            T item = new T();

            foreach (var property in properties)
            {
                try
                {
                    if (AllToString == false)
                        property.SetValue(item, row[property.Name], null);
                    else
                        if (row[property.Name].GetType() == typeof(DateTime))
                            property.SetValue(item, DateTime.Parse(row[property.Name].ToString()).ToString("MM/dd/yyyy"), null);
                        else
                            property.SetValue(item, row[property.Name].ToString(), null);
                }
                catch (Exception)
                {
                }

            }
            return item;
        }
        /// <summary>
        /// Author : Lic. Carlos Ml Lebron B.
        /// Serializar un DataTable a IList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this DataTable table, bool AllToString = false) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                try
                {
                    var item = CreateItemFromRow<T>((DataRow)row, properties, AllToString);
                    result.Add(item);
                }
                catch (Exception)
                {


                }

            }

            return result;
        }

        public static string UppercaseFirst(string value)
        {
            try
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length == 0)
                    return value;

                var result = new StringBuilder(value);
                result[0] = char.ToUpper(result[0]);
                for (int i = 1; i < result.Length; ++i)
                {
                    if (char.IsWhiteSpace(result[i - 1]))
                        result[i] = char.ToUpper(result[i]);
                    else
                        result[i] = char.ToLower(result[i]);
                }
                return result.ToString();
            }
            catch (Exception)
            {

                return value;
            }

        }

        public static string JSON_DataTable(this DataTable dt)
        {

            /****************************************************************************
            * Without goingin to the depth of the functioning
            * of this method, i will try to give an overview
            * As soon as this method gets a DataTable
            * it starts to convert it into JSON String,
            * it takes each row and ineach row it creates
            * an array of cells and in each cell is having its data
            * on the client side it is very usefull for direct binding of object to  TABLE.
            * Values Can be Access on clien in this way. OBJ.TABLE[0].ROW[0].CELL[0].DATA 
            * NOTE: One negative point. by this method user
            * will not be able to call any cell by its name.
            * *************************************************************************/

            StringBuilder JsonString = new StringBuilder();

            JsonString.Append("{ ");
            JsonString.Append("\"TABLE\":[{ ");
            JsonString.Append("\"ROW\":[ ");

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                JsonString.Append("{ ");
                JsonString.Append("\"COL\":[ ");

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("{" + "\"DATA\":\"" +
                                          dt.Rows[i][j] + "\"},");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("{" + "\"DATA\":\"" +
                                          dt.Rows[i][j] + "\"}");
                    }
                }
                /*end Of String*/
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("]} ");
                }
                else
                {
                    JsonString.Append("]}, ");
                }
            }
            JsonString.Append("]}]}");
            return JsonString.ToString();
        }

        public static string CreateJsonParameters(DataTable dt)
        {
            /* /****************************************************************************
             * Without goingin to the depth of the functioning
             * of this method, i will try to give an overview
             * As soon as this method gets a DataTable it starts to convert it into JSON String,
             * it takes each row and in each row it grabs the cell name and its data.
             * This kind of JSON is very usefull when developer have to have Column name of the .
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName>
             * NOTE: One negative point. by this method user
             * will not be able to call any cell by its index.
             * *************************************************************************/

            StringBuilder JsonString = new StringBuilder();

            //Exception Handling
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"Head\":[ ");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
                                  "\":" + "\"" +
                                  dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" +
                               dt.Columns[j].ColumnName.ToString() + "\":" +
                               "\"" + dt.Rows[i][j].ToString() + "\"");
                        }
                    }

                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }

                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  Author : Lic. Carlos Ml Lebron B.
        ///  Serializar un List<T> a DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static string Encrypt(object Argument)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Argument.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["Encryption_Key"]));
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

        /// <summary>
        /// Author : Lic. Carlos Ml Lebron B.
        /// Capitalize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Capitalize(this string value)
        {
            return value.Substring(0, 1).ToUpper() +
                    value.Substring(1, value.Length - 1).ToLower();
        }

        /// <summary>
        /// Author : Lic. Carlos Ml Lebron B.
        /// QuotedString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string QuotedString(this string value)
        {
            return "\"" + value + "\"";
        }

        /// <summary>
        /// Author : Lic. Carlos Ml Lebron B.
        /// QuotedString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SimpleQuotedString(this string value)
        {
            return "'" + value + "'";
        }

        public static string Decrypt(object Argument)
        {
            byte[] keyArray;
            byte[] Array_a_Descifrar = Convert.FromBase64String(Argument.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["Encryption_Key"]));
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
                ICryptoTransform cTransform =
               tdes.CreateEncryptor();

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

        public static String GetSerialId()
        {
            return System.Guid.NewGuid().ToString().Replace("-", "").Substring(1, 12).ToUpper();
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

        public static byte[] ReadBinaryFile(string path, string fileName)
        {
            if (File.Exists(path + fileName))
            {
                try
                {
                    ///Open and read a file&#12290;
                    FileStream fileStream = File.OpenRead(path + fileName);
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
        public static byte[] ReadBinaryFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    ///Open and read a file&#12290;
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
        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
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
                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        public static void EnableControls(ControlCollection controles, bool Estado)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Enabled = Estado;
                else if (control is DropDownList)
                    ((DropDownList)control).Enabled = Estado;
                else if (control is Button)
                    ((Button)control).Enabled = Estado;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = Estado;
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).Enabled = Estado;
                else if (control is FileUpload)
                    ((FileUpload)control).Enabled = Estado;
                else if (control is GridView)
                    ((GridView)control).Enabled = Estado;
                else if (control is Panel)
                    ((Panel)control).Enabled = Estado;
                else if (control is System.Web.UI.HtmlControls.HtmlGenericControl)
                    (control as System.Web.UI.HtmlControls.HtmlGenericControl).Disabled = !Estado;
                else if (control is DevExpress.Web.ASPxGridView)
                    ((DevExpress.Web.ASPxGridView)control).Enabled = Estado;
                else if (control is DevExpress.Web.ASPxTabControl)
                    (control as DevExpress.Web.ASPxTabControl).Enabled = Estado;
                EnableControls(control.Controls, Estado);
            }
        }

        public static void EnableControls(ControlCollection controles, Control ExcludeControl, bool Estado)
        {
            foreach (Control control in controles)
            {
                if (control != ExcludeControl)
                {
                    if (control is TextBox)
                        ((TextBox)control).Enabled = Estado;
                    else if (control is DropDownList)
                        ((DropDownList)control).Enabled = Estado;
                    else if (control is Button)
                        ((Button)control).Enabled = Estado;
                    else if (control is CheckBox)
                        ((CheckBox)control).Enabled = Estado;
                    else if (control is CheckBoxList)
                        ((CheckBoxList)control).Enabled = Estado;
                    else if (control is FileUpload)
                        ((FileUpload)control).Enabled = Estado;
                    else if (control is GridView)
                        ((GridView)control).Enabled = Estado;
                    else if (control is Panel)
                        ((Panel)control).Enabled = Estado;
                    else if (control is System.Web.UI.HtmlControls.HtmlGenericControl)
                        (control as System.Web.UI.HtmlControls.HtmlGenericControl).Disabled = !Estado;
                    else if (control is DevExpress.Web.ASPxGridView)
                        ((DevExpress.Web.ASPxGridView)control).Enabled = Estado;
                    else if (control is DevExpress.Web.ASPxTabControl)
                        (control as DevExpress.Web.ASPxTabControl).Enabled = Estado;
                    EnableControls(control.Controls, ExcludeControl, Estado);
                }
            }
        }

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

        /// <summary>
        /// Inicializa algunos componentes tales como TextBox,DropDownList,CheckBox y GridView pasando al metodo
        /// Una coleccion de controles y Excluye del proceso el control pasado en la variable ExcludeControl 
        /// </summary>
        /// <param name="controles"></param>
        /// <param name="ExcludeControl"></param>
        public static void ClearAll(ControlCollection controles, Control ExcludeControl)
        {

            foreach (Control control in controles)
            {
                if (control != ExcludeControl)
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
                        else ((DropDownList)control).Items.Clear();
                    }
                    else if (control is CheckBox)
                        ((CheckBox)control).Checked = false;
                    //else if (control is HiddenField)
                    //    ((HiddenField)control).Value = string.Empty;
                    else if (control is GridView)
                    {
                        ((GridView)control).DataSource = null;
                        ((GridView)control).DataBind();
                    }
                    else if (control is ASPxGridView)
                    {
                        ((ASPxGridView)control).DataSource = null;
                        ((ASPxGridView)control).DataBind();
                    }

                    ClearAll(control.Controls, ExcludeControl);
                }

            }
        }


        public static void ClearAll(ControlCollection controles, List<Control> ExcludeControls)
        {
            foreach (Control control in controles)
            {
                var Exclude = ExcludeControls.Where(x => x.UniqueID == control.UniqueID).Any();

                if (!Exclude)
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
                    {    //Valido si el DropDownList para luego posicionarnos 
                        //en el inice 0 de la lista
                        if (((DropDownList)control).Items.Count > 0)
                            ((DropDownList)control).SelectedIndex = 0;

                        else ((DropDownList)control).Items.Clear();
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
                    else if (control is ASPxGridView)
                    {
                        ((ASPxGridView)control).DataSource = null;
                        ((ASPxGridView)control).DataBind();
                    }
                }
            }
        }


        public static void ClearAll(ControlCollection controles, Control ExcludeControl, Control ExcludeControl2)
        {

            foreach (Control control in controles)
            {
                if (control != ExcludeControl && control != ExcludeControl2)
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
                    {    //Valido si el DropDownList para luego posicionarnos 
                        //en el inice 0 de la lista
                        if (((DropDownList)control).Items.Count > 0)
                            ((DropDownList)control).SelectedIndex = 0;

                        else ((DropDownList)control).Items.Clear();
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
                    else if (control is ASPxGridView)
                    {
                        ((ASPxGridView)control).DataSource = null;
                        ((ASPxGridView)control).DataBind();
                    }
                    ClearAll(control.Controls, ExcludeControl, ExcludeControl2);
                }

            }
        }


        public static List<YearsItem> GetYearsList()
        {
            try
            {
                List<YearsItem> Result = new List<YearsItem>();

                for (int i = 2000; i < DateTime.Now.Year + 1; i++)
                {
                    YearsItem YearItem = new YearsItem();
                    YearItem.Year = i;
                    YearItem.YearDescription = i.ToString();

                    Result.Add(YearItem);
                }

                return Result;
            }
            catch (Exception)
            {
                return new List<YearsItem>();
            }

        }

        public static List<YearsItem> GetYearsList(byte year, Order order = Order.Desc)
        {
            try
            {
                var Result = new List<YearsItem>();

                for (int i = DateTime.Now.Year; i > DateTime.Now.Year - year; i--)
                {
                    YearsItem YearItem = new YearsItem();
                    YearItem.Year = i;
                    YearItem.YearDescription = i.ToString();

                    Result.Add(YearItem);
                }

                if (order == Order.Desc)
                    return Result;
                else
                    return Result.OrderBy(i => i.Year).ToList();
            }
            catch (Exception)
            {
                return new List<YearsItem>();
            }

        }

        public static List<YearsItem> GetYearsList(byte year, int startYear, Order order = Order.Desc)
        {
            try
            {
                var Result = new List<YearsItem>();

                for (int i = startYear; i > DateTime.Now.Year - year; i--)
                {
                    YearsItem YearItem = new YearsItem();
                    YearItem.Year = i;
                    YearItem.YearDescription = i.ToString();

                    Result.Add(YearItem);
                }

                if (order == Order.Desc)
                    return Result;
                else
                    return Result.OrderBy(i => i.Year).ToList();
            }
            catch (Exception)
            {
                return new List<YearsItem>();
            }

        }

        public static IEnumerable<string> DtToCommaList(GridView gv, String Campo, String SelectCheckName)
        {

            var commaString = "";

            foreach (var row in from GridViewRow row in gv.Rows
                                let cb = row.FindControl(SelectCheckName) as CheckBox
                                where cb != null && cb.Checked
                                select row)
            {
                if (!String.IsNullOrEmpty(commaString))
                    commaString = commaString + "," + gv.DataKeys[row.RowIndex].Values[Campo];
                else
                    commaString = commaString + gv.DataKeys[row.RowIndex].Values[Campo];
            }

            return commaString.Split(',');
        }

        /// <summary>
        /// Método que devuelve en un arreglo el trimestre.
        /// </summary>
        /// <param name="aDate">fecha</param>
        /// <returns></returns>
        public static DateRange GetQuarterDateRange(DateTime aDate)
        {
            var result = new DateRange();
            var aMonth = aDate.Month;
            var aYear = aDate.Year;

            if (aMonth >= 1 && aMonth <= 3)
            {
                result.StartDate = new DateTime(aYear, 1, 1);
                result.EndDate = new DateTime(aYear, 3, 31, 23, 59, 59);
            }
            else if (aMonth >= 4 && aMonth <= 6)
            {
                result.StartDate = new DateTime(aYear, 4, 1);
                result.EndDate = new DateTime(aYear, 6, 30, 23, 59, 59);
            }
            else if (aMonth >= 7 && aMonth <= 9)
            {
                result.StartDate = new DateTime(aYear, 7, 1);
                result.EndDate = new DateTime(aYear, 9, 30, 23, 59, 59);
            }
            else if (aMonth >= 9 && aMonth <= 12)
            {
                result.StartDate = new DateTime(aYear, 10, 1);
                result.EndDate = new DateTime(aYear, 12, 31, 23, 59, 59);
            }

            return result;
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
        /// Para Seleccionar un valor del DropDown segun el Indice
        /// </summary>
        /// <param name="dropDown"></param>
        /// <param name="Value"></param>
        /// <param name="SelectFistIndex"></param>

        public static void SelectIndexByValueJSON(this DropDownList dropDown, string value)
        {
            try
            {
                var val = string.Empty;

                if (dropDown != null && dropDown.Items.Count >= 1)
                {
                    for (int i = 0; i < dropDown.Items.Count; i++)
                    {
                        if (dropDown.Items[i].Value != "-1")
                        {
                            val = dropDown.Items[i].Value;
                            i = dropDown.Items.Count;
                        }
                    }

                    if (string.IsNullOrEmpty(val) == false)
                    {
                        var temp = value.Trim().Replace("{", "").Replace("}", "").Split(',');

                        var realValue = val.Trim().Replace("{", "").Replace("}", "").Split(',');

                        System.Collections.Hashtable valores = new Hashtable();
                        System.Collections.Hashtable formato = new Hashtable();
                        for (int i = 0; i < temp.Length; i++)
                        {
                            valores.Add(temp[i].Split(':')[0], temp[i].Split(':')[1]);
                        }
                        for (int i = 0; i < realValue.Length; i++)
                        {
                            formato.Add(realValue[i].Split(':')[0], realValue[i].Split(':')[1]);
                        }

                        foreach (DictionaryEntry deEntry in valores)
                        {
                            // Get value from Registry and assign to sValue.
                            // ...
                            // Change value in hashtable.
                            var sKey = deEntry.Key.ToString();
                            formato[sKey] = valores[sKey];
                        }


                        StringBuilder select = new StringBuilder();
                        select.Append("{");

                        int first = 0;
                        for (int i = 0; i < realValue.Length; i++)
                        {
                            var sKey = realValue[i].Split(':')[0];
                            var v = formato[realValue[i].Split(':')[0]];

                            if (first == 0)
                                select.Append(sKey + ":" + v + "");
                            else
                                select.Append("," + sKey + ":" + v + "");

                            first++;
                        }

                        select.Append("}");

                        dropDown.SelectIndexByValue(select.ToString());

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Author: Ronny Alvarez
        /// Para Seleccionar un valor del DropDown segun el Indice
        /// </summary>
        /// <param name="DropDownList1"></param>
        /// <param name="Value"></param>
        /// <param name="SelectFistIndex"></param>

        public static void SelectIndexByValue(this System.Web.UI.WebControls.DropDownList DropDownList1, String Value, bool SelectFistIndex = false)
        {
            System.Web.UI.WebControls.ListItem listItem = DropDownList1.Items.FindByValue(Value.Trim());
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
        /// Author: Ronny Alvarez
        /// Para Seleccionar un valor del DropDown segun el Valor
        /// </summary>
        /// <param name="DropDownList1"></param>
        /// <param name="Text"></param>
        /// <param name="SelectFistIndex"></param>
        public static void SelectIndexByText(this System.Web.UI.WebControls.DropDownList DropDownList1, String Text, bool SelectFistIndex = false)
        {
            ListItem listItem = DropDownList1.Items.FindByText(Text.Trim());

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

        /// <summary>
        /// Author: Gregory Garcia
        /// Valida si el string es nulo para devolver un vacio vacio, en caso contrario, devuelve el valor y ejecuta trim.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NTrim(this string value)
        {
            return (value ?? "").Trim();
        }

        public static bool IsEmail(this string email)
        {
            try
            {
                var m = new MailAddress(email);

                return true;
            }
            catch (Exception)
            {
                return false;
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
        public static Nullable<decimal> IsDecimalReturnNull(this string value)
        {
            decimal d;
            bool resut = Decimal.TryParse(value, out d);

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
        public static Nullable<Int32> IsIntReturnNull(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
               return null;
            }
        }

        /// <summary>
        /// Author: Gregory Garcia
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return -1;
            }
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
        /// Traduce las columnas del los grid de devExpress
        /// </summary>
        /// <param name="grid"></param>
        public static void TranslateColumnsAspxGrid(this ASPxGridView grid)
        {
            foreach (GridViewColumn column in grid.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    var column2 = (GridViewDataColumn)column;

                    var key = column.Name;
                    var result = Resources.ResourceManager.GetString(key);
                    column.Caption = !string.IsNullOrEmpty(result) ? result :
                       (Resources.ResourceManager.GetString(column2.FieldName) ?? Resources.ResourceManager.GetString(column.Caption) ?? column.Caption);
                }
            }
        }

        public static string ToFormatCurrency(this decimal value, string currency = "USD")
        {
            string language = "en-US";
            switch (currency)
            {
                case "EUR":
                    language = "fr-FR";
                    break;
            }
            return string.Format(new CultureInfo(language), "{0:c}", value);
        }

        public static string ToFormatCurrency(this int? value, string currency = "USD")
        {
            if (!value.HasValue) return null;
            string language = "en-US";
            switch (currency)
            {
                case "EUR":
                    language = "fr-FR";
                    break;
            }
            return string.Format(new CultureInfo(language), "{0:c}", value);
        }

        public static string ToFormatCurrency(this int value, string currency = "USD")
        {
            string language = "en-US";
            switch (currency)
            {
                case "EUR":
                    language = "fr-FR";
                    break;
            }
            return string.Format(new CultureInfo(language), "{0:c}", value);
        }

        /// <summary>
        /// Author: Dirson Breton
        /// </summary>
        /// <returns></returns>
        public static decimal GetItbis()
        {
            decimal Result = 0;

            var itbis = Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["ITBISPorc"], NumberFormatInfo.InvariantInfo);

            Result = itbis / 100;

            return Result;
        }

    }


}