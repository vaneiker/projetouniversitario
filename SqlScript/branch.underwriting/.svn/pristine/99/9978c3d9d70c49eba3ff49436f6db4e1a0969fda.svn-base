using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class Header : UC, IUC
    {
        //IContact ContactManager
        //{
        //    get { return diManager.ContactManager; }
        //}
        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        //ICase Cases;

        public delegate void SelectGridRows_HEADER();
        public event SelectGridRows_HEADER SelectGridRow_HEADER;

        protected void Page_Load(object sender, EventArgs e)
        {
            UCCasesGrid1.SelectGridRow += new UCCasesGrid.SelectGridRows(SelectGridRows);
            //  ((WUCLeftMenu)this.Page.Master.FindControl("STFCUserProfile1").FindControl("WUCLeftMenu")).LeftAdvanceSearchFilter += FillAdvanceSearch;

            var result = Services.CaseManager.GetAllTabCounts(Service.CompanyId, Service.Underwriter_Id).ToList();


            AllOpenCountText.InnerText = result.First(r => r.TabName == "All Open").Count.ToString();
            ProcsssingCountText.InnerText = result.First(r => r.TabName == "Processing").Count.ToString();
            AwatingCountText.InnerText = result.First(r => r.TabName == "Awaiting Info").Count.ToString();
            ReinsuranceCountText.InnerText = result.First(r => r.TabName == "Reinsurance").Count.ToString();
            AlertCountText.InnerText = result.First(r => r.TabName == "Alerts").Count.ToString();
            ShowExceptionsCountText.InnerText = result.First(r => r.TabName == "Exceptions").Count.ToString();
            RecentCountText.InnerText = result.First(r => r.TabName == "Recent").Count.ToString();
            ChangesCountText.InnerText = result.First(r => r.TabName == "Changes").Count.ToString();
            HistoryResultCountText.InnerText = result.First(r => r.TabName == "History").Count.ToString();
            //MAVELAR 3/10/2017
            RejectedCasesCountText.InnerText = result.First(r => r.TabName == "Rejected").Count.ToString();
            //FIN MAVELAR 3/10/2017
            SearchResultCountText.InnerText = "0";


            if (IsPostBack) return;

            //var AllOpen = bool.Parse(ConfigurationManager.AppSettings["AllOpen"]);
            //var Processing = bool.Parse(ConfigurationManager.AppSettings["Processing"]);
            //var AwaitingInfo = bool.Parse(ConfigurationManager.AppSettings["AwaitingInfo"]);
            //var Reinsurance = bool.Parse(ConfigurationManager.AppSettings["Reinsurance"]);
            //var Alerts = bool.Parse(ConfigurationManager.AppSettings["Alerts"]);
            //var ShowExceptions = bool.Parse(ConfigurationManager.AppSettings["ShowExceptions"]);
            //var Recent = bool.Parse(ConfigurationManager.AppSettings["Recent"]);
            //var Changes = bool.Parse(ConfigurationManager.AppSettings["Changes"]);
            //var SearchResults = bool.Parse(ConfigurationManager.AppSettings["SearchResults"]);
            //Deshabilitar tabs segun sea el caso
            //if (!AllOpen)
            //{
            //    lnkAllOpen.Click -= SelectTabAllCases;
            //    lnkAllOpen.Attributes.Add("alt", "Disabled");
            //}

            //if (!Processing)
            //{
            //    lnkProcessing.Click -= SelectTabAllCases;
            //    lnkProcessing.Attributes.Add("alt", "Disabled");
            //}

            //if (!AwaitingInfo)
            //{
            //    lnkAwaitingInfo.Click -= SelectTabAllCases;
            //    lnkAwaitingInfo.Attributes.Add("alt", "Disabled");
            //}

            //if (!Reinsurance)
            //{
            //    lnkReinsurance.Click -= SelectTabAllCases;
            //    lnkReinsurance.Attributes.Add("alt", "Disabled");
            //}

            //if (!Alerts)
            //{
            //    lnkAlerts.Click -= SelectTabAllCases;
            //    lnkAlerts.Attributes.Add("alt", "Disabled");
            //}

            //if (!ShowExceptions)
            //{
            //    lnkShowExceptions.Click -= SelectTabAllCases;
            //    lnkShowExceptions.Attributes.Add("alt", "Disabled");
            //}


            //if (!Recent)
            //{
            //    lnkRecent.Click -= SelectTabAllCases;
            //    lnkRecent.Attributes.Add("alt", "Disabled");
            //}


            //if (!Changes)
            //{
            //    lnkChanges.Click -= SelectTabAllCases;
            //    lnkChanges.Attributes.Add("alt", "Disabled");
            //}


            //if (!SearchResults)
            //{
            //    lnkSearchResults.Click -= SelectTabAllCases;
            //    lnkSearchResults.Attributes.Add("alt", "Disabled");
            //}


        }

        public void ReloadTabCounter()
        {

            var result = Services.CaseManager.GetAllTabCounts(Service.CompanyId, Service.Underwriter_Id).ToList();


            AllOpenCountText.InnerText = result.First(r => r.TabName == "All Open").Count.ToString();
            ProcsssingCountText.InnerText = result.First(r => r.TabName == "Processing").Count.ToString();
            AwatingCountText.InnerText = result.First(r => r.TabName == "Awaiting Info").Count.ToString();
            ReinsuranceCountText.InnerText = result.First(r => r.TabName == "Reinsurance").Count.ToString();
            AlertCountText.InnerText = result.First(r => r.TabName == "Alerts").Count.ToString();
            ShowExceptionsCountText.InnerText = result.First(r => r.TabName == "Exceptions").Count.ToString();
            RecentCountText.InnerText = result.First(r => r.TabName == "Recent").Count.ToString();
            ChangesCountText.InnerText = result.First(r => r.TabName == "Changes").Count.ToString();
            HistoryResultCountText.InnerText = result.First(r => r.TabName == "History").Count.ToString();
            ////MAVELAR 3/10/2017
            RejectedCasesCountText.InnerText = result.First(r => r.TabName == "Rejected").Count.ToString();
            ////FIN MAVELAR 3/10/2017
            SearchResultCountText.InnerText = "0";

        }

        public void SelectGridRows()
        {
            SelectGridRow_HEADER();
        }

        protected void SelectTabAllCases(object sender, EventArgs e)
        {
            //Obtener el Current Tab
            var SelectTab = ((LinkButton)sender);

            Service.TabName = SelectTab.ID.Replace("lnk", "");
            hfMenuCasesAllCases.Value = Service.TabName;

            UCCasesGrid1.FillData();
        }

        void IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        void IUC.save()
        {
            throw new NotImplementedException();
        }

        void IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void IUC.edit()
        {
            throw new NotImplementedException();
        }

        void IUC.FillData()
        {
            throw new NotImplementedException();
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void FillAdvanceSearch()
        {
            Service.TabName = "SearchResults";
            SelectTabAllCases(lnkSearchResults, null);
        }
    }
}