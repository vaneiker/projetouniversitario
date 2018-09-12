using System;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCIllustrationContainer : UC, IUC
    {
        public UCHeaderIllustrationInformation UCHeaderIllustrationInfo
        {
            get
            {
                return UCHeaderIllustrationInformation;
            }
        }

        public void ClearData() { }

        public void ReadOnlyControls(bool isReadOnly) { }

        protected void Page_Load(object sender, EventArgs e) { }

        public void Translator(string Lang) { }

        public void save()
        {
            UCHeaderIllustrationInformation.save();
            UCPlanContainer.save();
        }

        public void edit()
        {
            UCHeaderIllustrationInformation.edit();
            UCPlanContainer.edit();
        }

        public void FillData()
        {
            UCHeaderIllustrationInformation.FillData();
            UCPlanContainer.FillData();
        }

        public void Initialize()
        {
            UCHeaderIllustrationInformation.Visible = true;
            mvIllustrator.SetActiveView(VPlanInformation);
            UCHeaderIllustrationInformation.Initialize();
            UCPlanContainer.Initialize();
        }

        public void SetMultiView(MultiViewIllustrator view = MultiViewIllustrator.PlanInformation)
        {
            mvIllustrator.ActiveViewIndex = (int)view;
            UCHeaderIllustrationInformation.Visible = view != MultiViewIllustrator.Compare;
            switch (view)
            {
                case MultiViewIllustrator.PlanInformation:
                    break;
                case MultiViewIllustrator.Compare:
                    UCCompareContainer.FillData();
                    break;
                case MultiViewIllustrator.Preview:
                    break;
                case MultiViewIllustrator.Eform:
                    UCFormsContainer.FillData();
                    break;
                default:
                    break;
            }
        }

        public void SetIllustrationNo(string illustrationNo)
        {
            UCHeaderIllustrationInformation.IllustrationNumber = illustrationNo;
        }

        public void FillDataPreview(byte[] reportArray, string reportName)
        {
            UCIllustratorPreview.PreviewReport(reportArray, reportName);
        }

        public enum MultiViewIllustrator
        {
            PlanInformation = 0,
            Compare,
            Preview,
            Eform
        }
    }
}