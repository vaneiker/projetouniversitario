using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy
{
    public partial class WUCSearch : UC, IUC
    {
        public void save()
        {

            if (ObjServices.Agent_Id > 0 && !ObjServices.isNewCase)
            {
                ObjServices.oPolicyManager.ChangePolicyChain(new Entity.UnderWriting.Entities.Policy.Parameter()
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No,
                    AgentId = ObjServices.Agent_Id,
                    UserId = ObjServices.UserID.Value


                });
            }

        }
        public void edit() { }
        public void ReadOnlyControls(bool isReadOnly) { }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            Policy.InnerHtml = Resources.PolicyNoLabel;
            FirstName.InnerHtml = Resources.FirstNameLabel;
            MiddleName.InnerHtml = Resources.MiddleNameLabel;
            LastName.InnerHtml = Resources.LastNameLabel;
            SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
            IllustrationSearch.InnerHtml = Resources.ifIllustratrionWasAlready;
        }

        public void FillData()
        {
            int CorpId = ObjServices.Corp_Id;
            int RegionId = ObjServices.Region_Id;
            int CountryId = ObjServices.Country_Id;
            int DomesticregId = ObjServices.Domesticreg_Id;
            int StateProvId = ObjServices.State_Prov_Id;
            int CityId = ObjServices.City_Id;
            int OfficeId = ObjServices.Office_Id;
            int CaseSeqNo = ObjServices.Case_Seq_No;
            int HistSeqNo = ObjServices.Hist_Seq_No;

            var datos = ObjServices.oPolicyManager.GetPlanData(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo);

            if (datos != null)
            {
                ObjServices.Policy_Id = datos.PolicyNo;
                if (!string.IsNullOrEmpty(datos.PolicyNo))
                {
                    txtPolicy.Text = datos.PolicyNo.Contains("-") ? datos.PolicyNo : string.Empty;
                }
                else
                    txtPolicy.Text = string.Empty;
                txtFirstName.Text = datos.InsuredFirstName;
                txtMiddleName.Text = datos.InsuredMiddleName;
                txtLastName.Text = datos.InsuredLastName;
                txtSecondLastName.Text = datos.InsuredSecondLastName;
            }

            udpSearch.Update();
        }

        protected void btnShowPopIllustrations_Click(object sender, EventArgs e)
        {
            if (ObjServices.isSavePlan)
            {
                this.MessageBox(Resources.PlanDataMessage);
                return;
            }

            WUCIllustrationPopup.Initialize();
            ViewState["ShowPopIllustrationList"] = true;
            ModalPopupIllustrations.Show();
        }

        public void Initialize()
        {
            pnsearch.Visible = (currentTab == "PlanPolicy");
            ClearData();
            FillData();
        }

        public void ClearData()
        {
            CleanControls(this);
        }
    }
}