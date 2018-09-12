using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation
{
    public partial class WUCContactInformation : UC, IUC
    {
        public delegate void FillDataContactHandler();
        public event FillDataContactHandler FillDataContact;

        public void edit() { }
        public void FillData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            btnSave.Text = Resources.Save;
            btnGoToillustration.Text = Resources.NewIllustration;
        }

        public void save()
        {
            WUCInsuredPersonalIinformation.save();
            WUCOccupationInformation.save();
            WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
            WUCPhoneNumber.save();
            WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
            WUCEmailAddress.save();
            WUCIdentification.Operation = Utility.OperationType.InsertAll;
            WUCIdentification.save();
            WUCAddress.save();
            WUCAdditionalInformation.save();

            var vTitle = ObjServices.Language == Utility.Language.en ? "INFORMATION" : "INFORMACIÓN";

            if (ObjServices.ContactEntityID > 0)
            {
                if (ObjServices.ContactServicesIsActive)
                {
                    var result = ObjServices.oContactServicesClient.SetContactAllInformation(Utility.Encrypt(ObjServices.Corp_Id.ToString()), Utility.Encrypt(ObjServices.ContactEntityID), Utility.Encrypt(ObjServices.CompanyId));

                    if (result.Status == ServicesApi.ContactService.ReturnMessageData.StatusProcess.Error)
                    {
                        var sb = new StringBuilder();
                        result.ListMessage.ToList().ForEach(o => sb.AppendLine(o));
                        this.MessageBox(sb.ToString());
                    }
                    else
                        if (!Session["CallFromSaveIllustration"].ToBoolean())
                        {
                            Session["CallFromSaveIllustration"] = false;
                            this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully, Title: vTitle);
                        }
                }
                else
                {
                    var result = ObjServices.oContactServicesClient.SetContactAllInformation(Utility.Encrypt(ObjServices.Corp_Id.ToString()), Utility.Encrypt(ObjServices.ContactEntityID), Utility.Encrypt(ObjServices.CompanyId));
                    if (!Session["CallFromSaveIllustration"].ToBoolean())
                    {
                        Session["CallFromSaveIllustration"] = false;
                        this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully, Title: vTitle);
                    }
                }
            }

            if (!Session["CallFromSaveIllustration"].ToBoolean())
            {
                Session["CallFromSaveIllustration"] = false;
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully, Title: vTitle);
            }
        }

        public void Initialize()
        {
            WUCOccupationInformation.Initialize();
            WUCInsuredPersonalIinformation.Initialize();
            WUCPhoneNumber.Initialize("Contact");
            WUCEmailAddress.Initialize("Contact");
            WUCAddress.Initialize();
            WUCIdentification.Initialize("Contact");
            WUCAdditionalInformation.Initialize();
            WUCIllustration.Initialize();
        }

        public void ClearData()
        {
            WUCOccupationInformation.ClearData();
            WUCInsuredPersonalIinformation.ClearData();
            WUCPhoneNumber.ClearData("Contact");
            WUCEmailAddress.ClearData("Contact");
            WUCAddress.ClearData();
            WUCIdentification.ClearData("Contact");
            WUCAdditionalInformation.ClearData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
            FillDataContact();
        }

        protected void btnGoToillustration_Click(object sender, EventArgs e)
        {
            ObjIllustrationServices.CustomerPlanNo = null;
            ObjIllustrationServices.CustomerNo = null;
            var pageContact = (NewBusiness.Pages.Contact)Page;
            pageContact.ManageTabs("lnkIllustrations");
        }
    }
}
