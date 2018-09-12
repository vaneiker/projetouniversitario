using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Beneficiaries
{
    public partial class WUCAdditionalInsured : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WUCMainBeneficiaries.UCContingentBeneficiarie = WUCContingentBeneficiaries;
        }
        
        public void Translator(string Lang)
        {

        }

        public void EnabledControls(bool x)
        {
            WUCMainBeneficiaries.EnabledControls(x);
        }                   

        public void save()
        {
            WUCMainBeneficiaries.save();
            WUCContingentBeneficiaries.save();
        }

        public void edit()
        {

        }

        public void FillData()
        {
            WUCMainBeneficiaries.FillData("3");
        }

        public void Initialize()
        {
            WUCMainBeneficiaries.UCContingentBeneficiarie = WUCContingentBeneficiaries;
            WUCMainBeneficiaries.Initialize("3");

            if (ObjServices.IsReadOnly || (ObjServices.IsDataReviewMode && getisView))
                ReadOnlyControls(ObjServices.IsReadOnly);
        }

        public void ClearData()
        {
            WUCMainBeneficiaries.ClearData();
            WUCContingentBeneficiaries.ClearData();
        }

        public bool saveBeneficiaries()
        {
            return WUCMainBeneficiaries.saveBeneficiaries();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            WUCMainBeneficiaries.ReadOnlyControls(isReadOnly);
            WUCContingentBeneficiaries.ReadOnlyControls(isReadOnly);
        }
    }
}