using Entity.UnderWriting.Entities;
using System;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCWork : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OcupationTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Occupation
            Service.DropDowns.GetDropDown(ref OccupationDLL, Language.English, DropDownType.Occupation, Service.Corp_Id, null, null, null, null, null, null, null, null, null, null, occupationTypeId: int.Parse(OcupationTypeDDL.SelectedIndex > 0 ? OcupationTypeDDL.SelectedValue.ToString() : "0"));
        }

        public void FillData(Contact contactInfo)
        {
            FillDrops(contactInfo);

            PersonalIncomeTxt.Text = contactInfo.AnnualPersonalIncome.GetValueOrDefault().ToString("#,##0.00");
            YearFamilyIncomeTxt.Text = contactInfo.AnnualFamilyIncome.GetValueOrDefault().ToString("#,##0.00");
            txtMonthlyFIncome.Text = Math.Round((contactInfo.AnnualFamilyIncome.GetValueOrDefault() / 12), 2).ToString("#,##0.00");
            txtMonthlyPIncome.Text = Math.Round((contactInfo.AnnualPersonalIncome.GetValueOrDefault() / 12), 2).ToString("#,##0.00");
            this.CompanyNameTxt.Text = contactInfo.CompanyName;
            this.LineOfBussinessTxt.Text = contactInfo.LineOfBusiness;
            this.LineOfBussiness2Txt.Text = contactInfo.LineOfBusiness2;
            //Bmarroquin 14-03-2017 Mejora para que no aparezca 1 en el Month cuando no se ha ingresado valor alguno en NB o DT...
            this.LengthAtWorkMonthTxt.Text = contactInfo.LengthWorkMonth.HasValue ? (contactInfo.LengthWorkMonth > 0 ? contactInfo.LengthWorkMonth.ToString() : "") : ""; 
            this.LengthAtWorkYearTxt.Text = contactInfo.LengthWorkYear.HasValue ? (contactInfo.LengthWorkYear > 0 ? contactInfo.LengthWorkYear.ToString() : "") : "";
            //Fin Cambio Bmarroquin 14-03-2017
            this.TaskPerformedTxt.Text = contactInfo.LaborTasks;

            
        }

        private void FillDrops(Contact contactInfo)
        {
            //Occupation Type
            Service.DropDowns.GetDropDown(ref OcupationTypeDDL, Language.English, DropDownType.OccupationType, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
            Tools.SelectIndexByValue(ref OcupationTypeDDL, (!contactInfo.OccupGroupTypeId.HasValue ? "0" : contactInfo.OccupGroupTypeId.ToString()), false);
            //UnderWriting.Common.Tools.SelectIndexByValue(ref OcupationTypeDDL, (Contact.OccupGroupTypeId != null ? Contact.OccupGroupTypeId.ToString() : "0") + "|" + Contact.OccupationId.ToString(), false);

            //Occupation
            Service.DropDowns.GetDropDown(ref OccupationDLL, Language.English, DropDownType.Occupation, Service.Corp_Id, null, null, null, null, null, null, null, null, null, null, occupationTypeId: int.Parse(!contactInfo.OccupGroupTypeId.HasValue ? "-1" : contactInfo.OccupGroupTypeId.ToString()), projectId: Service.ProjectId, companyId: Service.CompanyId);
            Tools.SelectIndexByValue(ref OccupationDLL, (!contactInfo.OccupGroupTypeId.HasValue ? "0" : contactInfo.OccupGroupTypeId.ToString()) + "|" + contactInfo.OccupationId.ToString(), false);
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            var contactToSave = new Contact
            {
                ContactId = Service.Contact_Id,
                CompanyName = this.CompanyNameTxt.Text,
                OccupGroupTypeId = Convert.ToInt32(this.OccupationDLL.SelectedValue.Split('|')[0]),
                OccupationId = Convert.ToInt32(this.OccupationDLL.SelectedValue.Split('|')[1]),
                LineOfBusiness = this.LineOfBussinessTxt.Text,
                LineOfBusiness2 = this.LineOfBussiness2Txt.Text,
                LaborTasks = this.TaskPerformedTxt.Text,
                AnnualPersonalIncome = Convert.ToDecimal(this.PersonalIncomeTxt.Text),
                AnnualFamilyIncome = Convert.ToDecimal(this.YearFamilyIncomeTxt.Text)
            };


            if (!string.IsNullOrEmpty(this.LengthAtWorkYearTxt.Text))
                contactToSave.LengthWorkYear = Convert.ToInt32(this.LengthAtWorkYearTxt.Text);
            else
                contactToSave.LengthWorkYear = null;

            if (!string.IsNullOrEmpty(this.LengthAtWorkMonthTxt.Text))
                contactToSave.LengthWorkMonth = Convert.ToInt32(this.LengthAtWorkMonthTxt.Text);
            else
                contactToSave.LengthWorkMonth = null;

            //Key
            contactToSave.PolicyInfo = new Contact.PolicyContact()
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                ContactId = Service.Contact_Id,
                ContactRoleTypeId = Service.IsOwner ? 1 : Service.RoleTypeId,
                UserId = Service.Underwriter_Id
            };

            Services.ContactManager.UpdateContact(contactToSave);
            Services.PolicyManager.UpdatePersonalInfoContact(contactToSave);

            
        }

        public void clearData()
        {
            OcupationTypeDDL.Items.Clear();
            CompanyNameTxt.Text = string.Empty;
            LineOfBussinessTxt.Text = string.Empty;
            LineOfBussiness2Txt.Text = string.Empty;
            LengthAtWorkMonthTxt.Text = string.Empty;
            LengthAtWorkYearTxt.Text = string.Empty;
            TaskPerformedTxt.Text = string.Empty;
            PersonalIncomeTxt.Text = string.Empty;
            YearFamilyIncomeTxt.Text = string.Empty;

            
        }

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }
    }
}