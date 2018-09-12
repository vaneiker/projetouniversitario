using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.SubmittedPolicies.Bll;
using Web.SubmittedPolicies.Bll.Poco;

namespace Web.SubmittedPolicies.Common.Classes
{
    public static class Common
    {
        public static SubmittedPoliciesService DataService { get; set; }

        [Serializable]
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
            public int? StepTypeId { get; set; }
            public int? StepId { get; set; }
            public int? StepCaseNo { get; set; }
            public string PolicyNo { get; set; }
        }

        public static int CurrentUserId
        {
            get
            {
                return HttpContext.Current.Session["UserID"] == null ? -1 : (int)HttpContext.Current.Session["UserID"];
            }
            set { HttpContext.Current.Session["UserID"] = value; }
        }
        public static int CurrentCompanyId
        {
            get
            {
                return HttpContext.Current.Session["CurrentCompanyId"] == null ? 1 : (int)HttpContext.Current.Session["CurrentCompanyId"];
            }
            set { HttpContext.Current.Session["CurrentCompanyId"] = value; }
        }
        public static int LanguageId
        {
            get
            {
                return HttpContext.Current.Session["LanguageId"] == null ? 1 : (int)HttpContext.Current.Session["LanguageId"];
            }
            set { HttpContext.Current.Session["LanguageId"] = value; }
        }
        public static string TempFilePath
        {
            get { return HttpContext.Current.Server.MapPath("~/TempFiles"); }
        }
        public static int ProjectId
        {
            get { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectId"]); }
        }
        public static string PDFViewerKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["PDFViewer"]; }
        }

        /// <summary>
        /// Este metodo sirve para obtener un objeto 
        /// PolicyKeyItem a partir de un string que contenga el key
        /// </summary>
        /// <param name="key">Este es el key con los separadores de por medio</param>
        /// <param name="separator">este es el caracte que sirve para hacer el split al key</param>
        /// <returns></returns>
        public static PolicyKeyItem GetKeyItem(String key, char separator)
        {
            var keyItemSplit = key.Split(separator);
            PolicyKeyItem keyItem = new PolicyKeyItem
             {
                 CorpId = int.Parse(keyItemSplit[0]),
                 RegionId = int.Parse(keyItemSplit[1]),
                 CountryId = int.Parse(keyItemSplit[2]),
                 DomesticregId = int.Parse(keyItemSplit[3]),
                 StateProvId = int.Parse(keyItemSplit[4]),
                 CityId = int.Parse(keyItemSplit[5]),
                 OfficeId = int.Parse(keyItemSplit[6]),
                 CaseSeqNo = int.Parse(keyItemSplit[7]),
                 HistSeqNo = int.Parse(keyItemSplit[8])
             };

            return keyItem;
        }

        public static void FillDrops(this DropDownList ddlToFill, List<DropdownItem> ddlDataSource, Boolean addSelectItem = false, String selectText = "--- Seleccione ---")
        {
            ddlToFill.DataValueField = "Value";
            ddlToFill.DataTextField = "Text";
            ddlToFill.DataSource = ddlDataSource;
            ddlToFill.DataBind();

            if (addSelectItem)
                ddlToFill.Items.Insert(0, new ListItem { Text = selectText, Value = "-1" });
        }

        public static void ReadOnlyTextbox(this Control controlContainer, bool readOnly)
        {
            foreach (var box in controlContainer.Controls.OfType<TextBox>())
                box.ReadOnly = readOnly;
        }

        public static String GetPolicyResultMsg(PolicyService.SubmitPolicyResult policyResult)
        {
            var sucessfullMessage = "";
            var failedMessage = "";

            foreach (var policy in policyResult._PolicyResult)
            {
                if (policy.Result)
                    sucessfullMessage += "Número de Caso: " + policy.PolicyNumber + " - Nuevo Número de Póliza: " + policy.NewPolicyNumber;
                else
                    failedMessage += policy.PolicyNumber;
            }

            var message = !String.IsNullOrEmpty(sucessfullMessage) ? "Caso(s) Enviado(s):<br><br>" + sucessfullMessage : "";
            message += !String.IsNullOrEmpty(failedMessage) ? "Caso(s) no enviado(s):<br><br>" + failedMessage : "";

            return message;
        }
    }
}