using System;
using System.Web.UI;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCRequestAmendments : WEB.UnderWriting.Common.UC
    {
        DropDownManager DropDowns = new DropDownManager();
        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        public void fillDdl()
        {
            var dataDocumentType = DropDowns.GetDropDown(DropDownType.AmmendmentType, 
														 Service.Corp_Id, 
														 projectId: Service.ProjectId, 
														 companyId: Service.CompanyId);

            var dataPerson = DropDowns.GetDropDown(DropDownType.AmmendmentTypeScope, 
												   Service.Corp_Id, 
												   Service.Region_Id, 
												   Service.Country_Id, 
												   Service.Domesticreg_Id, 
												   Service.State_Prov_Id, 
												   Service.City_Id, 
												   Service.Office_Id, 
												   Service.Case_Seq_No, 
												   Service.Hist_Seq_No, 
												   projectId: Service.ProjectId, 
												   companyId: Service.CompanyId);

            ddlDocumentType.DataSource = dataDocumentType;
            ddlPerson.DataSource = dataPerson;
            ddlDocumentType.DataBind();
            ddlPerson.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Entity.UnderWriting.Entities.Ammendment ammendment = new Entity.UnderWriting.Entities.Ammendment();
            ammendment.CorpId = Service.Corp_Id;
            ammendment.RegionId = Service.Region_Id;
            ammendment.CountryId = Service.Country_Id;
            ammendment.DomesticregId = Service.Domesticreg_Id;
            ammendment.StateProvId = Service.State_Prov_Id;
            ammendment.CityId = Service.City_Id;
            ammendment.OfficeId = Service.Office_Id;
            ammendment.CaseSeqNo = Service.Case_Seq_No;
            ammendment.HistSeqNo = Service.Hist_Seq_No;

            ammendment.AmmendmentTypeId = int.Parse(ddlDocumentType.SelectedValue);
            ammendment.InsuredScopeId = int.Parse(ddlPerson.SelectedValue);
            ammendment.DateFrom = Convert.ToDateTime(txtFromDate.Text);
            ammendment.DateTo = Convert.ToDateTime(txtToDate.Text);
            ammendment.Comments = txtComment.Text;
            ammendment.AmmendmentDate = DateTime.Now;
            ammendment.SignatureReq = true;
            ammendment.CreateUser = 1;

            Services.AmmendmentManager.InsertAmmendment(ammendment);

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "document.getElementById(\"hfRequestAmendments\").value = \"1\";", true);
            var amendments = (UCAmendments)this.Parent;
            amendments.FillGrid();
        }

    }
}