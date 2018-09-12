using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.Common;
using DevExpress.Web;

namespace WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies
{

    public partial class WUCSubmittedPolicies : UC, IUC
    {
        public delegate void btnSearchHandler(object sender, EventArgs e);
        public event btnSearchHandler btnSearch;


        public void save() { }
        public void readOnly(bool x) { }
        public void ClearData() { }
        public void edit() { }
        public void ReadOnlyControls(bool isReadOnly) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvSubmittedPolcies.SetFilterSettings();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            if (isChangingLang)
                FillData();   
        }

        public void FillData()
        {
            var data = ObjServices.oDataReviewManager.GetAll(new Entity.UnderWriting.Entities.Parameter.Case
            {
                CompanyId = ObjServices.CompanyId,
                UserId = ObjServices.Agent_LoginId,
                LanguageId = ObjServices.Language.ToInt()
            });

            gvSubmittedPolcies.DataSource = data;
            gvSubmittedPolcies.DataBind();
        }

        public void Initialize()
        {
            FillData();
        }

        protected void SetVariables(int RowIndex)
        {
            ObjServices.Corp_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());
            ObjServices.Region_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Policy_Id = gvSubmittedPolcies.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id = int.Parse(gvSubmittedPolcies.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
        }

        protected void gvSubmittedPolcies_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            var RowIndex = e.VisibleIndex;

            SetVariables(RowIndex);

            hdnShowPopAddCommment.Value = "true";
            UCNotesComments.FillData();
        }

        protected void gvSubmittedPolcies_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            btnSearch(null, null);
        }

        protected void gvSubmittedPolcies_PageIndexChanged(object sender, EventArgs e)
        {
            btnSearch(null, null);
        }

        protected void gvSubmittedPolcies_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}