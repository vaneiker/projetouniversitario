using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.UserControl
{
    public partial class PlanPolicyContainer : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void edit() { }
        public void FillData() { }
        public void ClearData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void Translator(string Lang) { }

        public void Initialize()
        {
            WUCFieldFooter.SetMultiploAnualAndItbis();
            WUCDesignatedPensionerInformation.Initialize();
            WUCPlanInformation.Initialize();
            WUCFieldFooter.Initialize();
        }

        public void save()
        {
            var result = WUCPlanInformation.saveOtherProcess();
            if (result) 
            {
                WUCDesignatedPensionerInformation.save();
                WUCFieldFooter.save();
            }            
        }

    }
}