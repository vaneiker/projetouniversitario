using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using System.Globalization;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.ContactsInfo
{
    public partial class WUCCompanyInfo : UC, IUC
    {
        public void edit() { }
        protected void Page_Load(object sender, EventArgs e) { }
        public String PrefixSession
        {
            get { return hdnCurrentSession.Value; }
            set { hdnCurrentSession.Value = value; }
        }

        private void FillDrop()
        {
            ObjServices.GettingAllDrops(ref ddlSocietyType, Utility.DropDownType.CompanyStructure,
                                    "AgentName", "AgentId",
                                    GenerateItemSelect: true);
            ObjServices.GettingAllDrops(ref ddlCommercialActivity, Utility.DropDownType.CompanyActivity,
                                   "AgentName", "AgentId",
                                   GenerateItemSelect: true);

            /*FILTERING VALUES FOR COMPANY ONLY IN FINAL BENEFICIARY*/
            //ObjServices.GettingAllDrops(ref ddlSocietyFinalBeneficiary, Utility.DropDownType.FinalBeneficiaryOption,"AgentName", "AgentId",GenerateItemSelect: true);
            var finalBenef = ObjServices.GettingDropData(Utility.DropDownType.FinalBeneficiaryOption).Where(c=>c.CountryId == 1 || c.CorpId == 1);
            ddlSocietyFinalBeneficiary.DataSource = finalBenef;
            ddlSocietyFinalBeneficiary.DataTextField = "AgentName";
            ddlSocietyFinalBeneficiary.DataValueField = "AgentId";
            ddlSocietyFinalBeneficiary.DataBind();

            var idsTps = new List<int> { 1, 5 };
            var idData = ObjServices.GettingDropData(Utility.DropDownType.IdType);
            ddlIDType.DataSource = idData.Where(d => idsTps.Contains(d.ContactTypeId.GetValueOrDefault())).ToArray();
            ddlIDType.DataTextField = "ContactTypeIdDesc";
            ddlIDType.DataValueField = "ContactTypeId";
            ddlIDType.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            CompanyName.InnerHtml = Resources.CompanyNameLabel;
            RegistrationNumber.InnerHtml = Resources.RegistrationNumberLabel;
            RegistrationDate.InnerHtml = Resources.RegistrationDateLabel;
            SocietyType.InnerHtml = Resources.SocietyType;
            CompanyActivity.InnerHtml = Resources.CommercialActivity;
            SocietyFinalBeneficiary.InnerHtml = Resources.SocietyFinalBeneficiary;
            IDType.InnerHtml = Resources.IDTypeLabel;
            CompanyRNC.InnerHtml = Resources.CompanyRNCLabel;
        }

        public void FillData()
        {
            var dataContact = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, (int)ObjServices.Contact_Id, ObjServices.Language.ToInt());
            IsCompany = dataContact.IsCompany;
            hdnIsCompany.Value = IsCompany.ToString().ToLower();
             
            var data = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

            if (data != null && data.InstitutionalName != null)
            {
                txtCompanyName.Text = data.InstitutionalName;

                if (data.companyStructureId != null)
                {
                    ddlSocietyType.SelectedValue = data.companyStructureId.ToString();
                    ddlSocietyFinalBeneficiary.SelectedValue = data.finalBeneficiaryOptionId.ToString();
                    ddlCommercialActivity.SelectedValue = data.companyActivityId.ToString();
                }
                
                var IdDataItem = ObjServices.GetAllIdDocumentInformation();

                if (IdDataItem != null)
                {
                    try
                    {
                        txtCompanyRNC.Text = IdDataItem.FirstOrDefault(x => x.ContactIdType == 5).Id;

                        if (txtCompanyRNC.Text.Length == 11)
                        {
                            ddlIDType.SelectedValue = "5";
                        }
                        else
                        {
                            ddlIDType.SelectedValue = "1";
                        }

                        txtRegistrationNumber.Text = IdDataItem.FirstOrDefault(x => x.ContactIdType == 0).Id;
                    }
                    catch (Exception)
                    {

                    }                
                }

                txtRegistrationDate.Text = !string.IsNullOrEmpty(data.Dob.Value.ToString()) ? data.Dob.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null;             
            }

            if ((ObjServices.Agent_Legal == null || ObjServices.Agent_Legal == -1) && data != null)
            {                
                ObjServices.Agent_Legal = data.LegalContactId;
            }

            WUCEmailAddress1.Initialize(currentTab);
            WUCPhoneNumber1.Initialize(currentTab);
            WUCAddress1.Initialize(currentTab);
            udpCompanyInfo.Update();
        }

        public void EnabledControls(bool x)
        {
            EnabledControls(pnCompany.Controls, x);
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void ClearData()
        {
            ClearControls();
        }

        public void Initialize()
        {
            ClearData();
            FillDrop();
            FillData();
            Mask();
            if (ObjServices.Owner_Id != null)
            {
                btnVerBeneficiariosFinales.Visible = WUCFinalBeneficary.HasFinalBenefEx((int)ObjServices.Owner_Id).Any();
            }
            else
            {
                btnVerBeneficiariosFinales.Visible = false;
            }
        }

        public void save()
        {
            WUCAddress1.save();
            WUCPhoneNumber1.Operation = Utility.OperationType.InsertAll;
            WUCPhoneNumber1.save();
            WUCEmailAddress1.Operation = Utility.OperationType.InsertAll;
            WUCEmailAddress1.save();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnCompany.Controls, isReadOnly);
        }

        public void Mask()
        {
            int idtype = int.Parse(ddlIDType.SelectedValue);

            if (idtype == 1)
            {
                txtCompanyRNC.Attributes.Remove("data-inputmask");
                txtCompanyRNC.Attributes.Add("data-inputmask", "'mask': '999-9999999-9','clearMaskOnLostFocus': true,'showTooltip': true");
            }

            if (idtype == 5)
            {
                txtCompanyRNC.Attributes.Remove("data-inputmask");
                txtCompanyRNC.Attributes.Add("data-inputmask", "'mask': '999-99999-9','clearMaskOnLostFocus': true,'showTooltip': true");
            }
        }

        protected void ddlIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mask();
        }

        private bool IsCompany { get { return ViewState["IsCompany"].ToBoolean(); } set { ViewState["IsCompany"] = value; } }

        protected void ddlSocietyFinalBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Drop = (sender as DropDownList);

            if (Drop.SelectedValue == "-1")
                return;

            if (ObjServices.Corp_Id == 1 && Drop.SelectedValue == "2")
            {
                //Mostrar popup con los beneficiarios finales
                hdnShowFinalBenef.Value = "true";
                WUCFinalBeneficary.ContactId = (int)ObjServices.Contact_Id;
                WUCFinalBeneficary.Initialize();
                WUCFinalBeneficary.IsCompany = this.IsCompany;
                WUCFinalBeneficary.ClickButtonScript = "javascript:__doPostBack('ctl00$bodyContent$ContactsInfoContainer$WUCCompanyInfo$WUCFinalBeneficary$gvFinalBeneficiary$cell{0}_0$TC$btnEditOrSave','')";
                btnVerBeneficiariosFinales.Visible = WUCFinalBeneficary.HasFinalBenef || (ObjServices.Corp_Id == 1);
                mpeFinalBeneficiary.Show();
            }
            else
            {
                hdnShowFinalBenef.Value = "false";
                btnVerBeneficiariosFinales.Visible = false;
            }
        }

        protected void btnVerBeneficiariosFinales_Click(object sender, EventArgs e)
        {
            hdnShowFinalBenef.Value = "true";
            WUCFinalBeneficary.ContactId = (int)ObjServices.Contact_Id;
            WUCFinalBeneficary.Initialize();
            WUCFinalBeneficary.IsCompany = this.IsCompany;
            mpeFinalBeneficiary.Show();
        }

        protected void btnExitPopup_Click(object sender, EventArgs e)
        {
            mpeFinalBeneficiary.Hide();
        }
    }
}