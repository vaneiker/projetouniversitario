using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview.UserControl.DReview
{
    public partial class WUCAddNewNotePopup : UC, IUC
    {
        public void edit() { }
        public void FillData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        protected void Page_Load(object sender, EventArgs e) { }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            PolicyNumber.InnerHtml = Resources.PolicyNoLabel;
            User.InnerHtml = Resources.USER.Capitalize();
            InsuredName.InnerHtml = Resources.InsuredName;
            PlanName.InnerHtml = Resources.PlanName;
            SendTo.InnerHtml = Resources.SendTo;
            Note.InnerHtml = Resources.NOTE.Capitalize();
            btnCancel.Value = Resources.Cancel;
            btnSend.Text = Resources.Send;          
        }

        public void Initialize()
        {
            FillDrop();
            FillData();
            udpAddNewNotePopup.Update();
        }

        public void FillDrop()
        {
            var parameter = new Entity.UnderWriting.Entities.DropDown.Parameter
            {
                DropDownType = Enum.GetName(typeof(WEB.NewBusiness.Common.Utility.DropDownType), WEB.NewBusiness.Common.Utility.DropDownType.DataReviewNoteType),
                CorpId = ObjServices.Corp_Id,
                RegionId = null,
                CountryId = null,
                DomesticregId = null,
                StateProvId = null,
                CityId = null,
                OfficeId = null,
                CaseSeqNo = null,
                HistSeqNo = null,
                ContactId = null,
                AgentId = null,
                IsInsured = null,
                OccupGroupTypeId = null,
                RequirementCatId = null,
                RiskDetId = null,
                RiskGroupId = null,
                TableTypeId = null,
                BlTypeId = null,
                BlId = null,
                PaymentSourceId = null,
                PaymentSourceTypeId = null,
                CurrencyId = null,
                AbaNumber = null,
                AppliedByFreqOrCountry = null,
                ProductTypeId = null,
                NameKey = "",
                CompanyId = ObjServices.CompanyId,
                ProjectId = ObjServices.ProjectId,
                LanguageId = ObjServices.Language.ToInt()
            };

            var ddlSendToSource = new Services().oDropDownManager.GetDropDownByType(parameter);
            var ddlSendTo = (ASPxListBox)ddlCheckComboBox.FindControl("ddlSendTo");                  
            ddlSendTo.DataSource = ddlSendToSource;
            ddlSendTo.DataBind();
            ddlSendTo.Items.Insert(0, new ListEditItem { Value = "0", Text = Resources.Selectall });
        }

        public void Initialize(String PolicyNumber, String UserName, String InsuredName, String PlanName)
        {
            ClearData();
            txtPolicyNumber.Text = PolicyNumber;
            txtUser.Text = UserName;
            txtInsuredName.Text = InsuredName;
            txtPlanName.Text = PlanName;
            Initialize();
        }

        public void ClearData()
        {
            this.ExcecuteJScript("checkListBox.UnselectAll();");
            ClearControls();
        }

        public void save()
        {
            var ddlSendTo = (ASPxListBox)ddlCheckComboBox.FindControl("ddlSendTo");

            if (!string.IsNullOrEmpty(txtNote.Text) && ddlSendTo.SelectedItems.Count > 0)
            {
                foreach (ListEditItem item in ddlSendTo.SelectedItems)
                {
                    if (item.Value.ToString() != "0")
                        ObjServices.oNote.Insert(new Entity.UnderWriting.Entities.Note()
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            DomesticregId = ObjServices.Domesticreg_Id,
                            StateProvId = ObjServices.State_Prov_Id,
                            CityId = ObjServices.City_Id,
                            OfficeId = ObjServices.Office_Id,
                            CaseSeqNo = ObjServices.Case_Seq_No,
                            HistSeqNo = ObjServices.Hist_Seq_No,
                            ReferenceTypeId = int.Parse(item.Value.ToString()),
                            NoteName = "DataReview",
                            OriginatedById = ObjServices.UserID.Value,
                            NoteBody = txtNote.Text.Trim(),
                            UserId = ObjServices.UserID.Value
                        });
                }

                Utility.ExcecuteJScript(this, "$('#dvAddNote').dialog('close');");
            }

            else if (ddlSendTo.SelectedItems.Count == 0)
            {
                var Title = (ObjServices.Language == Utility.Language.en ? "'Warning'" : "'Advertencia'"); 
                Utility.ExcecuteJScript(this, "CustomDialogMessageEx(null,370,170,false,'" + Title +"','SelectModuleValidation');");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            save();
        }       
    }
}