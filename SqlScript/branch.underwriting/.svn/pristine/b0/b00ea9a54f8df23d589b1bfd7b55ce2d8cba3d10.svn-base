using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using DevExpress.Web;

namespace WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies
{
    public partial class WUCEffectivePendingReceipt : UC, IUC
    {
        public delegate void btnSearchHandler(object sender, EventArgs e);
        public event btnSearchHandler btnSearch;

        public void Translator(string Lang){}
        public void save(){}
        public void readOnly(bool x){}
        public void edit(){}
        public void ReadOnlyControls(bool isReadOnly){}
        public void ClearData(){}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvEffectivePendingReceipt.SetFilterSettings();
        }                 

        public void FillData()
        {
            var data = ObjServices.oCaseManager.GetAllEffectivePendingReceipt(new Entity.UnderWriting.Entities.Policy.NBParameter()
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                AgentId = ObjServices.Agent_LoginId
            });
            gvEffectivePendingReceipt.DataSource = data;
            gvEffectivePendingReceipt.DataBind();
        }

        public void Initialize()
        {
            FillData();
        }        

        protected void gvEffectivePendingReceipt_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            btnSearch(null, null);
        }

        protected void gvEffectivePendingReceipt_PageIndexChanged(object sender, EventArgs e)
        {
            btnSearch(null, null);
        }

        protected void SetVariables(int RowIndex, DevExpress.Web.ASPxGridView Grid)
        {
            ObjServices.Corp_Id = int.Parse(Grid.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());
            ObjServices.Region_Id = int.Parse(Grid.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(Grid.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(Grid.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(Grid.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());   
            ObjServices.City_Id = int.Parse(Grid.GetKeyFromAspxGridView("CityId", RowIndex).ToString());              
            ObjServices.Office_Id = int.Parse(Grid.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());          
            ObjServices.Owner_Id = int.Parse(Grid.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());     
            ObjServices.Case_Seq_No = int.Parse(Grid.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());       
            ObjServices.Hist_Seq_No = int.Parse(Grid.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());       
            ObjServices.Contact_Id = int.Parse(Grid.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString()); 
            ObjServices.Policy_Id = Grid.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();                     
            ObjServices.Agent_Id = int.Parse(Grid.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());            
        }

        protected void gvEffectivePendingReceipt_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var RowIndex = e.VisibleIndex;
            SetVariables(RowIndex, sender as DevExpress.Web.ASPxGridView);
            var oContactInfo = ObjServices.GetContact(ObjServices.Contact_Id.Value);

            int RequirementCatId = gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementCatId", RowIndex) == null ? -1 :
                                              int.Parse(gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementCatId", RowIndex).ToString());

            int RequirementTypeId = gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementTypeId", RowIndex) == null ? -1 :
                int.Parse(gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementTypeId", RowIndex).ToString());

            int RequirementId = gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementId", RowIndex) == null ? -1 :
                int.Parse(gvEffectivePendingReceipt.GetKeyFromAspxGridView("RequirementId", RowIndex).ToString());

            int AmmendmentId = gvEffectivePendingReceipt.GetKeyFromAspxGridView("AmmendmentId", RowIndex) == null ? -1 :
                int.Parse(gvEffectivePendingReceipt.GetKeyFromAspxGridView("AmmendmentId", RowIndex).ToString());

            bool? IsAmmendReq = gvEffectivePendingReceipt.GetKeyFromAspxGridView("IsAmmendReq", RowIndex) == null ?
                (bool?)null :
                bool.Parse(gvEffectivePendingReceipt.GetKeyFromAspxGridView("IsAmmendReq", RowIndex, false).ToString());


            string AmmendmentDate = gvEffectivePendingReceipt.GetKeyFromAspxGridView("AmmendmentDate", RowIndex) == null ? DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy") :
                      gvEffectivePendingReceipt.GetKeyFromAspxGridView("AmmendmentDate", RowIndex).ToString().ParseFormat().Value.ToString("MM/dd/yyyy");

            hdnAmmendmentDate.Value = AmmendmentDate.ToString();

            WUCUploadReceiptPopup.FillData(
                oContactInfo.FirstName, oContactInfo.MiddleName, oContactInfo.FirstLastName,
                oContactInfo.SecondLastName, RequirementCatId,
                RequirementTypeId, RequirementId, AmmendmentId, IsAmmendReq);

            ModalPopupExtender2.Show();

        }

        protected void gvEffectivePendingReceipt_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
       
    }
}