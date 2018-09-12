using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Requirements
{
    public partial class UCRequirementContainer : UC, IUC
    {
        #region Private Properties
        private UCPlanContainer UCIllustrationPlanContainer
        {
            get
            {
                return (UCPlanContainer)Page.Controls[0].FindControl("bodyContent").FindControl("UCIllustrationContainer").FindControl("UCPlanContainer");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Translator(string Lang)
        {
            UCRequirement.Translator(Lang);
            if (UCIllustrationPlanContainer.HasOtherInsured())
                UCRequirement1.Translator(Lang);
        }

        public void save()
        {
            UCRequirement.save();
            if (UCIllustrationPlanContainer.HasOtherInsured())
                UCRequirement1.save();
            SetExamCondition();
        }

        public void edit()
        {
            UCRequirement.edit();
            if (UCIllustrationPlanContainer.HasOtherInsured())
                UCRequirement1.edit();
            SetExamCondition();
        }

        private void SetExamCondition()
        {
            UCRequirement.DeleteExamCondition();
                UCRequirement.RefreshExamCondition();
            UCRequirement1.DeleteExamCondition();
            if (UCIllustrationPlanContainer.HasOtherInsured())
                if (UCIllustrationPlanContainer.GetPlanType() != Utility.EPlanType.NonInsured)
                    UCRequirement1.RefreshExamCondition();
        }

        public void FillData()
        {
            UCRequirement.FillData();
            if (UCIllustrationPlanContainer.HasOtherInsured())
                UCRequirement1.FillData();
        }

        public void Initialize()
        {
            UCRequirement.Initialize("P");
            UCRequirement1.Initialize("O");
        }

        public void ClearData()
        {

        }


        public void ReadOnlyControls(bool isReadOnly)
        {

        }
    }
}