using System;
using System.Linq;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Requirements
{
    public partial class UCRequimentInformation :UC, IUC
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            UCRequirementTableGeneral.SentToReinsurance();
            UCRequirementTableActivitySports.SentToReinsurance();
            UCRequirementTableFinancial.SentToReinsurance();
            UCRequirementTableMedical.SentToReinsurance();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            var requirementData = Services.RequirementManager.GetAll(
                      Service.Corp_Id
                    , Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id
                    , Service.Case_Seq_No, Service.Hist_Seq_No, Service.LanguageId
                    ).ToList();

            UCRequirementTableGeneral.FillData(requirementData.Where(r => r.RequirementCatId == 1).ToList());
            UCRequirementTableMedical.FillData(requirementData.Where(r => r.RequirementCatId == 2).ToList());
            UCRequirementTableFinancial.FillData(requirementData.Where(r => r.RequirementCatId == 3).ToList());
            UCRequirementTableActivitySports.FillData(requirementData.Where(r => r.RequirementCatId == 4).ToList());
            UCRequirementTableOcupations.FillData(requirementData.Where(r => r.RequirementCatId == 5).ToList());
        }

        public void clearData()
        {
            UCRequirementTableGeneral.clearData();
            UCRequirementTableMedical.clearData();
            UCRequirementTableFinancial.clearData();
            UCRequirementTableActivitySports.clearData();
        }

        protected void lnkAddRequirement_Click(object sender, EventArgs e)
        {
            UCAddNewRequirement.ClearTempRequirements();
            
            hfRequirementInsertForm.Value = "true";
            UCAddNewRequirement.FillData();
        }
    }
}