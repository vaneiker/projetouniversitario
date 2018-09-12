using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCBlackListValidation : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        private void UpdateResumen()
        {
            //Actualizar el resumen   
            var IllustrationInformationUC = Utility.GetAllChildren(this.Page).FirstOrDefault(uc => uc is UCIllustrationInformation);

            if (IllustrationInformationUC != null)
                (IllustrationInformationUC as UCIllustrationInformation).FillData();
        }

        public void FillData()
        {
            var BlackListCertifiedMessage = ObjServices.dataConfig.FirstOrDefault(G => G.Namekey == "BlackListCertifiedMessage");
            if (BlackListCertifiedMessage != null)
                ltBody.Text = string.Format(BlackListCertifiedMessage.ConfigurationValue, !string.IsNullOrEmpty(ObjServices.BlacklistCheckUserName) ? ObjServices.BlacklistCheckUserName : ObjServices.UserFullName);

            if (ObjServices.BlacklistCheck.HasValue)
            {
                if (ObjServices.BlacklistCheck.Value)
                    rbAcepta.SelectedValue = "Si";
                else
                    rbAcepta.SelectedValue = "No";
            }
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rbAcepta.SelectedValue))
            {
                this.MessageBox(Resources.YesOrNo);
                return;
            }

            var res = (rbAcepta.SelectedItem.Value == "Si");

            ObjServices.oPolicyManager.SetBlakList(new Entity.UnderWriting.Entities.Policy.BlackList.Parameter
            {
                corpId = ObjServices.Corp_Id,
                regionId = ObjServices.Region_Id,
                countryId = ObjServices.Country_Id,
                domesticregId = ObjServices.Domesticreg_Id,
                stateProvId = ObjServices.State_Prov_Id,
                cityId = ObjServices.City_Id,
                officeId = ObjServices.Office_Id,
                caseSeqNo = ObjServices.Case_Seq_No,
                histSeqNo = ObjServices.Hist_Seq_No,
                blacklistCheck = res,
                userId = ObjServices.UserID
            });

            ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());
            UpdateResumen();
        }
    }
}