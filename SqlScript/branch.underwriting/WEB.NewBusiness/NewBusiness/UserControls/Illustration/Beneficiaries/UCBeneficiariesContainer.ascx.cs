using System;
using RESOURCE.UnderWriting.NewBussiness;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Beneficiaries
{
    public partial class UCBeneficiariesContainer : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {
            UCBeneficiaries.save();
            UCBeneficiaries1.save();
            UCBeneficiaries2.save();
            UCBeneficiaries3.save();
        }

        public void save()
        {
            UCBeneficiaries.save();
            UCBeneficiaries1.save();
            UCBeneficiaries2.save();
            UCBeneficiaries3.save();
        }

        public void edit()
        {
            UCBeneficiaries.edit();
            UCBeneficiaries1.edit();
            UCBeneficiaries2.edit();
            UCBeneficiaries3.edit();
        }

        public void FillData()
        {
            UCBeneficiaries.FillData("P", "P");//Primary Principal
            UCBeneficiaries1.FillData("P", "C");//Primary Contingent
            UCBeneficiaries2.FillData("O", "P");//Additional Principal
            UCBeneficiaries3.FillData("O", "C");//Additional Contingent
        }

        public void Initialize()
        {
            UCBeneficiaries.Initialize();
            UCBeneficiaries1.Initialize();
            UCBeneficiaries2.Initialize();
            UCBeneficiaries3.Initialize();
        }

        public void ClearData()
        {
            UCBeneficiaries.ClearData();
            UCBeneficiaries1.ClearData();
            UCBeneficiaries2.ClearData();
            UCBeneficiaries3.ClearData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {

        }

        public void ChangePlan(string familyProductCode)
        {
            var isFuneral = familyProductCode == Utility.EFamilyProductType.Funeral.Code();
            liBeneficiaries2.Visible = liBeneficiaries3.Visible = liBeneficiaries4.Visible = !isFuneral;

            UCBeneficiaries.ChangeVisibilityPercentage(!isFuneral);
            UCBeneficiaries1.ChangeVisibilityPercentage(!isFuneral);
            UCBeneficiaries2.ChangeVisibilityPercentage(!isFuneral);
            UCBeneficiaries3.ChangeVisibilityPercentage(!isFuneral);

            if (!isFuneral)
                ltMainBeneficiaries.Text = Resources.MainBenficiariesLabel.ToUpper();
            else
                ltMainBeneficiaries.Text = Resources.BeneficiariesClaimants.ToUpper();
        }
    }
}