using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.UserControls.Common
{
    public partial class UCHeaderHistorico : UC
    {
        new Services _services = new Services();

        Services _services2 = new Services();

        #region Methods
        public IEnumerable<Entity.UnderWriting.Entities.ConfirmationCall.Pending> DataConfirmationCall
        {
            get
            {
                var data = Session["UCHeader.DataConfirmationCall"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.ConfirmationCall.Pending>)Session["UCHeader.DataConfirmationCall"] : null;
            }
            set
            {
                Session["UCHeader.DataConfirmationCall"] = value;
            }
        }

        public IEnumerable<Entity.UnderWriting.Entities.ConfirmationCall.Count> CountConfirmationCall
        {
            get
            {
                var data = Session["UCHeader.CountConfirmationCall"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.ConfirmationCall.Count>)Session["UCHeader.CountConfirmationCall"] : null;
            }
            set
            {
                Session["UCHeader.CountConfirmationCall"] = value;
            }
        }

        public int CountryID
        {
            get
            {
                var data = Session["UCHeader.CountryID"];
                return data != null ? (int)Session["UCHeader.CountryID"] : 0;
            }
            set
            {
                Session["UCHeader.CountryID"] = value;
            }
        }

        public void FillConfirmationCall()
        {
            string status = hfSelectHeaderTAB.Value.Replace("btn", "");
            string policy = String.IsNullOrEmpty(txtPolicy.Text) ? null : txtPolicy.Text;
            DateTime? from = txtDateFrom.Text.IsDateReturnNull();
            DateTime? to = txtDateTo.Text.IsDateReturnNull();

            switch (HttpContext.Current.Request.Url.AbsolutePath.Replace("/Pages/", ""))
            {

                case "ConfirmationCall.aspx":
                    HtmlControl contenedor = (HtmlControl)this.FindControl("contenedor_tabshistory");
                    contenedor.Attributes["class"] = "contenedor_tabs Display";
                    ((WEB.ConfirmationCall.Pages.ConfirmationCall)Page).FillData(0);
                    FillDdlEstatus();

                    var tmp = _services.oConfirmationCallManager.GetAll(_services.Corp_Id, UserDataProvider.CompanyId, UserDataProvider.UserId, status, policy, from, to).OrderBy(o => o.InitialDate);

                    DataConfirmationCall = tmp.Select(p => new Entity.UnderWriting.Entities.ConfirmationCall.Pending
                    {
                        CorpId = p.CorpId,
                        RegionId = p.RegionId,
                        CountryId = p.CountryId,
                        DomesticregId = p.DomesticregId,
                        StateProvId = p.StateProvId,
                        CityId = p.CityId,
                        OfficeId = p.OfficeId,
                        CaseSeqNo = p.CaseSeqNo,
                        HistSeqNo = p.HistSeqNo,
                        StepTypeId = p.StepTypeId,
                        StepId = p.StepId,
                        StepCaseNo = p.StepCaseNo,
                        CaseStatus = p.CaseStatus,
                        PolicyNo = p.PolicyNo,
                        PlanName = p.PlanName,
                        PlanType = p.PlanType,
                        OwnerName = p.OwnerName,
                        InsuredName = p.InsuredName,
                        AddInsuredName = p.AddInsuredName,
                        OfficeDesc = p.OfficeDesc,
                        InitialDate = p.InitialDate,
                        WorkedBy = p.WorkedBy,
                        Observations =/* p.Observations ,*/(p.Observations == null ? null : Regex.Replace(p.Observations, @"\r\n?|\n", @"\")),
                        WorkedOn = p.WorkedOn,
                        Agent = p.Agent,
                        NumberOfCalls = p.NumberOfCalls,
                        Days = p.Days,
                        InsuredContactId = p.InsuredContactId,
                        AddContactId = p.AddContactId,
                        OwnerContactId = p.OwnerContactId
                    }).ToArray();


                    CountConfirmationCall = _services.oConfirmationCallManager.GetAllCount(_services.Corp_Id, UserDataProvider.CompanyId, UserDataProvider.UserId, policy, from, to);
                    iliAll.InnerText = CountConfirmationCall.Sum(o => o.RowCount).ToString();
                    iliPending.InnerText = CountConfirmationCall.Where(p => p.TabName == "Pending").FirstOrDefault().RowCount.ToString();
                    iliMedical.InnerText = CountConfirmationCall.Where(p => p.TabName == "Medical").FirstOrDefault().RowCount.ToString();
                    iliComplete.InnerText = CountConfirmationCall.Where(p => p.TabName == "Complete").FirstOrDefault().RowCount.ToString();
                    iliWarning.InnerText = CountConfirmationCall.Where(p => p.TabName == "Warning").FirstOrDefault().RowCount.ToString();
                    grdConfirmationCall.DataBind();
                    grdConfirmationCall.Columns["CaseStatus"].Visible = status == "All" ? true : false;
                    break;
                case "History.aspx":
                    HtmlControl contenedor_tabshistory = (HtmlControl)this.FindControl("contenedor_tabshistory");
                    contenedor_tabshistory.Attributes["class"] = "contenedor_tabs NoDisplay";
                    ((WEB.ConfirmationCall.Pages.History)Page).FillData(0);
                    FillDdlEstatus(true);

                    status = "History";

                    var tmpHist = _services.oConfirmationCallManager.GetAll(_services.Corp_Id, UserDataProvider.CompanyId, UserDataProvider.UserId, status, policy, from, to).OrderBy(o => o.InitialDate);
                    DataConfirmationCall = tmpHist.Select(p => new Entity.UnderWriting.Entities.ConfirmationCall.Pending
                    {
                        CorpId = p.CorpId,
                        RegionId = p.RegionId,
                        CountryId = p.CountryId,
                        DomesticregId = p.DomesticregId,
                        StateProvId = p.StateProvId,
                        CityId = p.CityId,
                        OfficeId = p.OfficeId,
                        CaseSeqNo = p.CaseSeqNo,
                        HistSeqNo = p.HistSeqNo,
                        StepTypeId = p.StepTypeId,
                        StepId = p.StepId,
                        StepCaseNo = p.StepCaseNo,
                        CaseStatus = p.CaseStatus,
                        PolicyNo = p.PolicyNo,
                        PlanName = p.PlanName,
                        PlanType = p.PlanType,
                        OwnerName = p.OwnerName,
                        InsuredName = p.InsuredName,
                        AddInsuredName = p.AddInsuredName,
                        OfficeDesc = p.OfficeDesc,
                        InitialDate = p.InitialDate,
                        WorkedBy = p.WorkedBy,
                        Observations =/* p.Observations ,*/(p.Observations == null ? null : Regex.Replace(p.Observations, @"\r\n?|\n", @"\")),
                        WorkedOn = p.WorkedOn,
                        Agent = p.Agent,
                        NumberOfCalls = p.NumberOfCalls,
                        Days = p.Days,
                        InsuredContactId = p.InsuredContactId,
                        AddContactId = p.AddContactId,
                        OwnerContactId = p.OwnerContactId
                    }).ToArray();


                    grdConfirmationCall.DataBind();


                    break;
            }
        }

        public Dictionary<string, string> FillDdlEstatus(bool isHistory = false)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            if (isHistory == false)
            {
                list.Add("All", "All");
                list.Add("Pending", "Pending");
                list.Add("Medical", "Medical");
                list.Add("Complete", "Complete");
                list.Add("Warning", "Warning");

            }
            //EN EL HISTORY DEBEN APARECER SOLO LOS COMPLETADOS
            else
            {
                list.Add("Complete", "Complete");
            }

            ddlEstatus.DataSource = list;
            ddlEstatus.DataTextField = "Value";
            ddlEstatus.DataValueField = "Key";
            ddlEstatus.DataBind();


            return list;

        }

        public bool GetMedicalStatusPoliza(string poliza)
        {
            bool rs = false;

            for (int i = 0; i < grdConfirmationCall.VisibleRowCount; i++)
            {
                string PolicyNo = grdConfirmationCall.GetRowValues(i, "PolicyNo").ToString();
                string CaseStatus = grdConfirmationCall.GetRowValues(i, "CaseStatus").ToString();

                if (poliza == PolicyNo && CaseStatus == "Medical")
                {
                    rs = true;
                }

            }
            return rs;

        }

        public object GetConfirmationCall(IEnumerable<Entity.UnderWriting.Entities.ConfirmationCall.Pending> data)
        {
            return data;
        }

        void SelectRow()
        {

            int rs = 0;
            bool status = false;
            string poliza = "";
            string typePlan = "";

            grdConfirmationCall.FocusedRowIndex = hdnGridIndexRow.Value.ToInt();
            _services.CleanSessionKeys();
            var sessionData = _services.SessionData;
            _services.SessionData.PolicyInfo.CorpId = grdConfirmationCall.GetKeyFromAspxGridView("CorpId").ToInt();
            _services.SessionData.PolicyInfo.RegionId = grdConfirmationCall.GetKeyFromAspxGridView("RegionId").ToInt();
            _services.SessionData.PolicyInfo.CountryId = grdConfirmationCall.GetKeyFromAspxGridView("CountryId").ToInt();
            CountryID = grdConfirmationCall.GetKeyFromAspxGridView("CountryId").ToInt();
            _services.SessionData.PolicyInfo.DomesticregId = grdConfirmationCall.GetKeyFromAspxGridView("DomesticregId").ToInt();
            _services.SessionData.PolicyInfo.StateProvId = grdConfirmationCall.GetKeyFromAspxGridView("StateProvId").ToInt();
            _services.SessionData.PolicyInfo.CityId = grdConfirmationCall.GetKeyFromAspxGridView("CityId").ToInt();
            _services.SessionData.PolicyInfo.OfficeId = grdConfirmationCall.GetKeyFromAspxGridView("OfficeId").ToInt();
            _services.SessionData.PolicyInfo.CaseSeqNo = grdConfirmationCall.GetKeyFromAspxGridView("CaseSeqNo").ToInt();
            _services.SessionData.PolicyInfo.HistSeqNo = grdConfirmationCall.GetKeyFromAspxGridView("HistSeqNo").ToInt();
            _services.SessionData.PolicyInfo.InsuredContactId = grdConfirmationCall.GetKeyFromAspxGridView("InsuredContactId").ToInt();
            _services.SessionData.PolicyInfo.AdditionalContactId = grdConfirmationCall.GetKeyFromAspxGridView("AddContactId").ToInt();

            _services.SessionData.PolicyInfo.OwnerContactId = grdConfirmationCall.GetKeyFromAspxGridView("OwnerContactId").ToInt();

            _services.SessionData.PolicyInfo.PolicyNo = grdConfirmationCall.GetKeyFromAspxGridView("PolicyNo").ToString();
            poliza = grdConfirmationCall.GetKeyFromAspxGridView("PolicyNo").ToString();
            status = GetMedicalStatusPoliza(poliza);

            typePlan = grdConfirmationCall.GetKeyFromAspxGridView("PlanType").ToString();

            _services.SessionData.PolicyInfo.CaseStatus = grdConfirmationCall.GetKeyFromAspxGridView("CaseStatus").ToString();

            _services.SessionData.PolicyInfo.CurrentContactId = grdConfirmationCall.GetKeyFromAspxGridView("OwnerContactId").ToInt();
            _services.SessionData.PolicyInfo.CurrentContactTypeId = WEB.ConfirmationCall.Common.ContactType.Owner;
            _services.SessionData.PolicyInfo.StepTypeId = grdConfirmationCall.GetKeyFromAspxGridView("StepTypeId").ToInt();
            _services.SessionData.PolicyInfo.StepId = grdConfirmationCall.GetKeyFromAspxGridView("StepId").ToInt();
            _services.SessionData.PolicyInfo.StepCaseNo = grdConfirmationCall.GetKeyFromAspxGridView("StepCaseNo").ToInt();


            //if ( _services2.SessionData != null)
            //{
            //    UsersAsigne.addUsersAsigned(_services2.SessionData.PolicyInfo.CorpId,
            //                                    _services2.SessionData.PolicyInfo.RegionId,
            //                                    _services2.SessionData.PolicyInfo.CountryId,
            //                                    _services2.SessionData.PolicyInfo.DomesticregId,
            //                                    _services2.SessionData.PolicyInfo.StateProvId,
            //                                    _services2.SessionData.PolicyInfo.CityId,
            //                                    _services2.SessionData.PolicyInfo.OfficeId,
            //                                    _services2.SessionData.PolicyInfo.CaseSeqNo,
            //                                    _services2.SessionData.PolicyInfo.HistSeqNo,
            //                                   UserDataProvider.UserId.ToInt(), 0, Request.ServerVariables["SERVER_NAME"].ToString(), "UPDATE");

            //}

            ////validacion temporal
            //rs = UsersAsigne.isUsersAsigned(_services.SessionData.PolicyInfo.CorpId,
            //                                 _services.SessionData.PolicyInfo.RegionId,
            //                                 _services.SessionData.PolicyInfo.CountryId,
            //                                 _services.SessionData.PolicyInfo.DomesticregId,
            //                                 _services.SessionData.PolicyInfo.StateProvId,
            //                                 _services.SessionData.PolicyInfo.CityId,
            //                                 _services.SessionData.PolicyInfo.OfficeId,
            //                                 _services.SessionData.PolicyInfo.CaseSeqNo,
            //                                 _services.SessionData.PolicyInfo.HistSeqNo, 
            //                                 UserDataProvider.UserId.ToInt()
            //                                 );

            //if (rs == 1) {
            //    Alertify.Alert(RESOURCE.UnderWriting.ConfirmationCall.Resources.SelectedCase, this);
            //    return;
            //}

            //UsersAsigne.addUsersAsigned(_services.SessionData.PolicyInfo.CorpId,
            //                               _services.SessionData.PolicyInfo.RegionId,
            //                               _services.SessionData.PolicyInfo.CountryId,
            //                               _services.SessionData.PolicyInfo.DomesticregId,
            //                               _services.SessionData.PolicyInfo.StateProvId,
            //                               _services.SessionData.PolicyInfo.CityId,
            //                               _services.SessionData.PolicyInfo.OfficeId,
            //                               _services.SessionData.PolicyInfo.CaseSeqNo,
            //                               _services.SessionData.PolicyInfo.HistSeqNo,
            //                              UserDataProvider.UserId.ToInt(), 1, Request.ServerVariables["SERVER_NAME"].ToString(), "INSERT");


            _services2.SessionData.PolicyInfo.CorpId = _services.SessionData.PolicyInfo.CorpId;
            _services2.SessionData.PolicyInfo.RegionId = _services.SessionData.PolicyInfo.RegionId;
            _services2.SessionData.PolicyInfo.CountryId = _services.SessionData.PolicyInfo.CountryId;
            _services2.SessionData.PolicyInfo.DomesticregId = _services.SessionData.PolicyInfo.DomesticregId;
            _services2.SessionData.PolicyInfo.StateProvId = _services.SessionData.PolicyInfo.StateProvId;
            _services2.SessionData.PolicyInfo.CityId = _services.SessionData.PolicyInfo.CityId;
            _services2.SessionData.PolicyInfo.OfficeId = _services.SessionData.PolicyInfo.OfficeId;
            _services2.SessionData.PolicyInfo.CaseSeqNo = _services.SessionData.PolicyInfo.CaseSeqNo;
            _services2.SessionData.PolicyInfo.HistSeqNo = _services.SessionData.PolicyInfo.HistSeqNo;


            //service.SessionData = sessionData;
            switch (HttpContext.Current.Request.Url.AbsolutePath.Replace("/Pages/", ""))
            {
                case "ConfirmationCall.aspx":
                    ((WEB.ConfirmationCall.Pages.ConfirmationCall)Page).TypePlan = typePlan;
                    ((WEB.ConfirmationCall.Pages.ConfirmationCall)Page).FillData(_services.Owner_Id, ContactType.Owner, status);
                    break;
                case "History.aspx":
                    ((WEB.ConfirmationCall.Pages.History)Page).FillData(_services.Owner_Id);
                    break;
            }

        }

        private float getInternetExplorerVersion()
        {
            // Returns the version of Internet Explorer or a -1
            // (indicating the use of another browser).
            float rv = -1;
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if (browser.Browser == "IE")
                rv = (float)(browser.MajorVersion + browser.MinorVersion);
            return rv;
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            double IE_Verzion = getInternetExplorerVersion();
            btnAll.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$UCHeader$btnAll','')" : "";
            btnPending.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$UCHeader$btnPending','')" : "";
            btnMedical.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$UCHeader$btnMedical','')" : "";
            btnComplete.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$UCHeader$btnComplete','')" : "";
            btnWarning.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$UCHeader$btnWarning','')" : "";
            hfSelectHeaderTAB.Value = Path.GetFileNameWithoutExtension(Request.Path) == "ConfirmationCall" ? "btnPending" : "btnAll";
            FillConfirmationCall();

        }

        protected void btnSelectTAB_Click(object sender, EventArgs e)
        {
            hfSelectHeaderTAB.Value = ((LinkButton)sender).CommandName;
            FillConfirmationCall();
        }

        protected void dsConfirmationCall_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataConfirmationCall;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlEstatus.SelectedItem != null && ddlEstatus.SelectedItem.Text == "All")
            {

                hfSelectHeaderTAB.Value = "btnAll";

            }

            if (ddlEstatus.SelectedItem != null && ddlEstatus.SelectedItem.Text == "Pending")
            {

                hfSelectHeaderTAB.Value = "btnPending";

            }
            if (ddlEstatus.SelectedItem != null && ddlEstatus.SelectedItem.Text == "Medical")
            {

                hfSelectHeaderTAB.Value = "btnMedical";

            }

            if (ddlEstatus.SelectedItem != null && ddlEstatus.SelectedItem.Text == "Complete")
            {

                hfSelectHeaderTAB.Value = "btnComplete";

            }

            if (ddlEstatus.SelectedItem != null && ddlEstatus.SelectedItem.Text == "Warning")
            {

                hfSelectHeaderTAB.Value = "btnWarning";

            }


            FillConfirmationCall();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPolicy.Text = "";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";

            switch (HttpContext.Current.Request.Url.AbsolutePath.Replace("/Pages/", ""))
            {

                case "ConfirmationCall.aspx":
                    ddlEstatus.SelectedValue = "All";
                    break;
                case "History.aspx":
                    ddlEstatus.SelectedValue = "Complete";
                    break;
            }

            FillConfirmationCall();

        }

        protected void grdConfirmationCall_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                grdConfirmationCall.FocusedRowIndex = -1;
        }

        protected void grdConfirmationCall_PageIndexChanged(object sender, EventArgs e)
        {
            grdConfirmationCall.FocusedRowIndex = -1;
        }

        protected void grdConfirmationCall_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            grdConfirmationCall.FocusedRowIndex = -1;
        }

        protected void btnSelectRow_Click(object sender, EventArgs e)
        {
            SelectRow();
        }

        #endregion

        protected void callbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            LblObservacion.Text = Convert.ToString(e.Parameter);
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            Utility.TranslateColumnsAspxGrid(this.grdConfirmationCall);
            btnSearch.Text = Resources.Search;
            btnReset.Text = Resources.Reset;
            //
            grdConfirmationCall.SettingsText.EmptyDataRow = RESOURCE.UnderWriting.ConfirmationCall.Resources.RowEmpty;


        }

        protected void grdConfirmationCall_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "OwnerName")
            {
                for (int i = 0; i < grdConfirmationCall.VisibleRowCount; i++)
                {
                    string status = grdConfirmationCall.GetRowValues(i, "CaseStatus").ToString();

                    if (status == "Pending")
                    {
                        if (e.CellValue != null)
                        {
                            var count = DataConfirmationCall.Count(o => o.OwnerName == e.CellValue.ToString());

                            if (Convert.ToInt32(count) >= 2)
                            {
                                e.Cell.ForeColor = Color.White;
                                e.Cell.BackColor = Color.FromArgb(147, 112, 219);

                            }
                        }
                    }

                }

            }

            if (e.DataColumn.FieldName == "InsuredName")
            {
                for (int i = 0; i < grdConfirmationCall.VisibleRowCount; i++)
                {
                    string status = grdConfirmationCall.GetRowValues(i, "CaseStatus").ToString();

                    if (status == "Medical")
                    {
                        if (e.CellValue != null)
                        {
                            var count = DataConfirmationCall.Count(o => o.InsuredName == e.CellValue.ToString() && o.CaseStatus == "Medical");

                            if (Convert.ToInt32(count) >= 1)
                            {
                                e.Cell.BackColor = Color.FromArgb(120, 177, 56);
                                e.Cell.ForeColor = Color.White;

                            }
                        }
                    }
                    //
                    if (status == "Warning")
                    {
                        if (e.CellValue != null)
                        {
                            var count = DataConfirmationCall.Count(o => o.InsuredName == e.CellValue.ToString() && o.CaseStatus == "Warning");

                            if (Convert.ToInt32(count) >= 1)
                            {
                                e.Cell.BackColor = Color.Yellow;
                                e.Cell.ForeColor = Color.Black;

                            }
                        }

                    }


                }

            }


        }



    }
}