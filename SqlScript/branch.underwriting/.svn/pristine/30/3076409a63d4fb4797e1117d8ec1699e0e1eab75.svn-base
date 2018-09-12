using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Beneficiaries
{
	public partial class UCBAddresses : UC, IUC
	{
		//DropDownManager DropDowns = new DropDownManager();
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
                
			}
		}

		void IUC.Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
		{

		}

		void IUC.readOnly(bool x)
		{
			throw new NotImplementedException();
		}

		void IUC.edit()
		{
			throw new NotImplementedException();
		}

        public void FillAddress(int SelectedContactId, IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressList = null)
		{

            var addressData = addressList ?? Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, SelectedContactId, Service.LanguageId);
          //  var addressData = addressList;
              var addressCount = addressData.Count();
              gvAddress.DataSource = addressData;
              gvAddress.DataBind();

             setPagerIndex(gvAddress, addressCount);
		}

        public void FillAddress(IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressList = null)
        {

            var addressData = addressList ?? Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);
            //  var addressData = addressList;
            //var fullsource = addressData.a
            var addressCount = addressData.Count();
            gvAddress.DataSource = addressData;
            gvAddress.DataBind();

            setPagerIndex(gvAddress, addressCount);
        }

        public void FillAddress(string FullName, IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressList = null)
        {


            var addressData = addressList ?? Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);

            //addressData =  addressData.Concat(FullName);
              // addressData = addressList;
            var addressCount = addressData.Count();
            gvAddress.DataSource = addressData;
            gvAddress.DataBind();

            setPagerIndex(gvAddress, addressCount);
        }

		public void FillData()
		{
		}

        public void FillData2() {

         /*   var Corp_Id = Service.Corp_Id;
            var Region_Id = Service.Region_Id;
            var Country_Id = Service.Country_Id;
            var Domesticreg_Id = Service.Domesticreg_Id;
            var State_Prov_Id = Service.State_Prov_Id;
            var City_Id = Service.City_Id;
            var Office_Id = Service.Office_Id;
            var Case_Seq_No = Service.Case_Seq_No;
            var Hist_Seq_No = Service.Hist_Seq_No;
            var Contact_Id = Service.Contact_Id; */

            // CompanyId = companyId, ProjectId = projectId, CorpId = corpId, RegionId = regionId, CountryId = countryId, DomesticregId = domesticregId, StateProvId = stateProvId, CityId = cityId, OfficeId = officeId, CaseSeqNo = caseSeqNo, HistSeqNo = histSeqNo, ContactId = contactId, AgentId = agentId, OccupGroupTypeId = occupationTypeId, IsInsured = isInsured 


            Service.DropDowns.GetDropDown(ref PrimaryBeneficiary, 
                                              Language.English,
                                              DropDownType.PrimaryBeneficiary,
                                              Service.Corp_Id,
                                              Service.Region_Id,
                                              Service.Country_Id,
                                              Service.Domesticreg_Id,
                                              Service.State_Prov_Id,
                                              Service.City_Id,
                                              Service.Office_Id,
                                              Service.Case_Seq_No,
                                              Service.Hist_Seq_No,
                                              Service.Contact_Id,
                                              companyId: Service.CompanyId,
                                              projectId: Service.ProjectId
                                              );

            UnderWriting.Common.Tools.SelectIndexByValue(ref PrimaryBeneficiary, "-1", true);

            Service.DropDowns.GetDropDown(ref BCountryDDL,
                                              Language.English,
                                              DropDownType.Country,
                                              Service.Corp_Id,
                                              Service.Region_Id,
                                              Service.Country_Id,
                                              Service.Domesticreg_Id,
                                              Service.State_Prov_Id,
                                              Service.City_Id,
                                              Service.Office_Id,
                                              Service.Case_Seq_No,
                                              Service.Hist_Seq_No,
                                              Service.Contact_Id,
                                              projectId: Service.ProjectId,
                                              companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref BCountryDDL, "-1", true);

            Service.DropDowns.GetDropDown(ref BAddresTypeDDL,
                                          Language.English,
                                          DropDownType.AddressType,
                                          Service.Corp_Id,
                                          Service.Region_Id,
                                          Service.Country_Id,
                                          Service.Domesticreg_Id,
                                          Service.State_Prov_Id,
                                          Service.City_Id,
                                          Service.Office_Id,
                                          Service.Case_Seq_No,
                                          Service.Hist_Seq_No,
                                          Service.Contact_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);
        
        }

		public void FillData(IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressList = null)
		{
            //FillAddress(addressList);

            Service.DropDowns.GetDropDown(ref BCountryDDL,
                                          Language.English,
                                          DropDownType.Country,
                                          Service.Corp_Id,
                                          Service.Region_Id,
                                          Service.Country_Id,
                                          Service.Domesticreg_Id,
                                          Service.State_Prov_Id,
                                          Service.City_Id,
                                          Service.Office_Id,
                                          Service.Case_Seq_No,
                                          Service.Hist_Seq_No,
                                          Service.Contact_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref BCountryDDL, "-1", true);

            Service.DropDowns.GetDropDown(ref BAddresTypeDDL,
                                          Language.English,
                                          DropDownType.AddressType,
                                          Service.Corp_Id,
                                          Service.Region_Id,
                                          Service.Country_Id,
                                          Service.Domesticreg_Id,
                                          Service.State_Prov_Id,
                                          Service.City_Id,
                                          Service.Office_Id,
                                          Service.Case_Seq_No,
                                          Service.Hist_Seq_No,
                                          Service.Contact_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);
		}
     
        protected void DisplayAddressOfBeneficiary(Object sender, EventArgs e) {

            var contactSelected = Convert.ToInt32(PrimaryBeneficiary.Text);

            if(contactSelected > 0 ){

            var addressData = Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, contactSelected, Service.LanguageId);
            //  var addressData = addressList;
            //var fullsource = addressData.a
            var addressCount = addressData.Count();
            gvAddress.DataSource = addressData;
            gvAddress.DataBind();

            setPagerIndex(gvAddress, addressCount);
            }
            else if (contactSelected == -1) {

                SetInitialAddress();
            }



        }

        public void SetInitialAddress() {
            var contactSelected = 0;

            if (contactSelected == 0)
            {

                var addressData = Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, contactSelected, Service.LanguageId);
                //  var addressData = addressList;
                //var fullsource = addressData.a
                var addressCount = addressData.Count();
                gvAddress.DataSource = addressData;
                gvAddress.DataBind();

                setPagerIndex(gvAddress, addressCount);
            }
           
        }

		protected void AddAddresBTN_Click(Object sender, EventArgs e)
		{
            //addBeneficiaryAddress(int directoryid, string address, List<string> aCity, string postalcode, bool isPrimaryChecked, string SelectedContactId)
  
            string[] aCity = BCityDDL.SelectedValue.Split('|');
            int SelectedContactId =  Convert.ToInt32(PrimaryBeneficiary.Text ?? "0");
            int DirectoryTypeId = Convert.ToInt32(BAddresTypeDDL.SelectedValue.Split('|')[1]);
            string StreetAddress = BStreetAdressTxt.Text;
            string ZipCode = String.IsNullOrEmpty(BPostalCodeTxt.Text) ? null : BPostalCodeTxt.Text;
            bool IsPrimary = BAddressPrimaryChk.Checked;

            Services.ContactManager.SetAddress(new Entity.UnderWriting.Entities.Contact.Address
            {
                CorpId = Service.Corp_Id,
                DirectoryId = -1,
                DirectoryDetailId = -1,
                DirectoryTypeId = Convert.ToInt32(BAddresTypeDDL.SelectedValue.Split('|')[1]),
                StreetAddress = BStreetAdressTxt.Text,
                CreateUser = 1,
                ModifyUser = 1,
                
                RegionId = Convert.ToInt32(aCity[0]),
                CountryId = Convert.ToInt32(aCity[1]),
                DomesticregId = Convert.ToInt32(aCity[2]),
                StateProvId = Convert.ToInt32(aCity[3]),
                CityId = Convert.ToInt32(aCity[4]),

                ZipCode = String.IsNullOrEmpty(BPostalCodeTxt.Text) ? null : BPostalCodeTxt.Text,
                IsPrimary = BAddressPrimaryChk.Checked,
                CommunicationType = CommType.Address.ToString(),
                ContactId = SelectedContactId
            });

            if (SelectedContactId == -1) {

                SetInitialAddress();
            }
          //((UCBeneficiaries)Parent.FindControl("UCBeneficiaries")).addBeneficiaryAddress(DirectoryTypeId, StreetAddress, aCity, ZipCode, IsPrimary, SelectedContactId);

          //{"Cannot insert the value NULL into column 'Directory_Id', table 'Global.Global.ST_COMM_DETAIL'; column does not allow nulls. UPDATE fails.\r\nThe statement has been terminated."}
            EmptyAddressControls();
            FillAddress(SelectedContactId);
		}

		protected void EditAddressBTN_Click(Object sender, EventArgs e)
		{
            string[] aCity;
            aCity = this.BCityDDL.SelectedValue.Split('|');
            int RownIndex = Convert.ToInt32(this.hdfRowIndex.Value);
            int SelectedContactId = Convert.ToInt32(PrimaryBeneficiary.Text ?? "0");
            Services.ContactManager.SetAddress(new Entity.UnderWriting.Entities.Contact.Address
            {
                CorpId = Convert.ToInt32(gvAddress.DataKeys[RownIndex]["CorpId"]),
                DirectoryId = Convert.ToInt32(gvAddress.DataKeys[RownIndex]["DirectoryId"]),
                DirectoryDetailId = Convert.ToInt32(gvAddress.DataKeys[RownIndex]["DirectoryDetailId"]),
                DirectoryTypeId = Convert.ToInt32(BAddresTypeDDL.SelectedValue.Split('|')[1]),
                CommunicationTypeId = Convert.ToInt32(gvAddress.DataKeys[RownIndex]["CommunicationTypeId"]),
                StreetAddress = this.BStreetAdressTxt.Text,
                CreateUser = 1,
                ModifyUser = 1,
                ContactId = SelectedContactId,
                RegionId = Convert.ToInt32(aCity[0]),
                CountryId = Convert.ToInt32(aCity[1]),
                DomesticregId = Convert.ToInt32(aCity[2]),
                StateProvId = Convert.ToInt32(aCity[3]),
                CityId = Convert.ToInt32(aCity[4]),

                ZipCode = String.IsNullOrEmpty(this.BPostalCodeTxt.Text) ? null : this.BPostalCodeTxt.Text,
                IsPrimary = this.BAddressPrimaryChk.Checked
            });


            EmptyAddressControls();
            DisplayAddressOfBeneficiary(sender, e);
            //FillAddress();
		}

		protected void UpdateAddress(object sender, EventArgs e)
		{
            var rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            this.hdfRowIndex.Value = rowIndex.ToString();
            Tools.SelectIndexByValue(ref BCountryDDL, gvAddress.DataKeys[rowIndex]["CountryId"].ToString(), false);


            Service.DropDowns.GetDropDown(ref BStateDDL, Language.English, DropDownType.StateProvince, Service.Corp_Id, null, Convert.ToInt32(BCountryDDL.SelectedValue), projectId: Service.ProjectId, companyId: Service.CompanyId);
            Tools.SelectIndexByValue(ref BStateDDL, gvAddress.DataKeys[rowIndex]["CountryId"].ToString() + '|' + gvAddress.DataKeys[rowIndex]["DomesticregId"].ToString() + '|' + gvAddress.DataKeys[rowIndex]["StateProvId"].ToString(), false);


            Service.DropDowns.GetDropDown(ref BCityDDL, Language.English, DropDownType.City,
                Service.Corp_Id,
                null,
                Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[0]),
                Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[1]), Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[2]), projectId: Service.ProjectId, companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref BCityDDL, gvAddress.DataKeys[rowIndex]["RegionId"].ToString() + '|' +
                gvAddress.DataKeys[rowIndex]["CountryId"] + '|' +
                gvAddress.DataKeys[rowIndex]["DomesticregId"] + '|' +
                gvAddress.DataKeys[rowIndex]["StateProvId"] + '|' +
                gvAddress.DataKeys[rowIndex]["CityId"], false);

            Tools.SelectIndexByValue(ref BAddresTypeDDL, gvAddress.DataKeys[rowIndex]["CorpId"].ToString() + '|' + gvAddress.DataKeys[rowIndex]["DirectoryTypeId"].ToString(), false);
            BStreetAdressTxt.Text = gvAddress.DataKeys[rowIndex]["StreetAddress"].ToString();

            BPostalCodeTxt.Text = gvAddress.DataKeys[rowIndex]["ZipCode"] == null ? "" : gvAddress.DataKeys[rowIndex]["ZipCode"].ToString();

            BAddressPrimaryChk.Checked = !String.IsNullOrEmpty(gvAddress.DataKeys[rowIndex]["IsPrimary"].ToString()) && Boolean.Parse(gvAddress.DataKeys[rowIndex]["IsPrimary"].ToString());

            EditAddressBTN.Visible = true;
            AddAddresBTN.Visible = false;
		}

		protected void DeleteAddress(Object sender, EventArgs e)
		{
            var rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Services.ContactManager.DeleteCommunicaton(Convert.ToInt32(gvAddress.DataKeys[rowIndex]["CorpId"]), Convert.ToInt32(gvAddress.DataKeys[rowIndex]["DirectoryId"]), Convert.ToInt32(gvAddress.DataKeys[rowIndex]["DirectoryDetailId"]), 1);
            EmptyAddressControls();
            DisplayAddressOfBeneficiary(sender, e);
            //FillAddress();
		}

		protected void CountryDDL_SelectedIndexChanged(Object sender, EventArgs e)
		{
            Service.DropDowns.GetDropDown(ref BStateDDL,
                                          Language.English,
                                          DropDownType.StateProvince,
                                          Service.Corp_Id,
                                          null,
                                          Convert.ToInt32(BCountryDDL.SelectedValue),
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref BStateDDL, "-1", true);

            this.BCityDDL.Items.Clear();
		}

		protected void StateDDL_SelectedIndexChanged(Object sender, EventArgs e)
		{
            var cityId = 0;
            var officeId = 0;

            if (BStateDDL.SelectedValue.Split('|').Count() > 1)
            {
                cityId = Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[1]);
                officeId = Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[2]);
            }

            Service.DropDowns.GetDropDown(ref BCityDDL,
                                          Language.English,
                                          DropDownType.City,
                                          Service.Corp_Id,
                                          null,
                                          Convert.ToInt32(this.BStateDDL.SelectedValue.Split('|')[0]),
                                          cityId,
                                          officeId,
                                          null,
                                          null,
                                          null,
                                          null,
                                          null,
                                          null);

            UnderWriting.Common.Tools.SelectIndexByValue(ref BCityDDL, "-1", true);
		}

		public void EmptyAddressControls()
		{
            this.BAddressPrimaryChk.Checked = false;
            this.BStreetAdressTxt.Text = string.Empty;
            this.BPostalCodeTxt.Text = string.Empty;

            //Fill GridData
            //var addressData = Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, Service.Contact_Id);
            //gvAddress.DataSource = addressData;
            //gvAddress.DataBind();

            this.AddAddresBTN.Visible = true;
            this.EditAddressBTN.Visible = false;
            UnderWriting.Common.Tools.SelectIndexByValue(ref BCountryDDL, "-1", false);
            UnderWriting.Common.Tools.SelectIndexByValue(ref BStateDDL, "-1", false);
            UnderWriting.Common.Tools.SelectIndexByValue(ref BCityDDL, "-1", false);
            UnderWriting.Common.Tools.SelectIndexByValue(ref BAddresTypeDDL, "-1", false);
		}



		public void clearData()
		{
			throw new NotImplementedException();
		}

		void setPagerIndex(GridView gv, int Count)
		{

            if (gv.BottomPagerRow != null)
            {
                var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
                var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
                var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
                var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
                var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
                var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


                var count = gv.PageCount;
                var index = gv.PageIndex + 1;

                indexText.Text = index.ToString();
                totalText.Text = count.ToString();

                if (index == 1)
                {
                    DisableLinkButton(lnkPrev, "prev_dis");
                    DisableLinkButton(lnkFirst, "rewd_dis");
                }
                else if (index == count)
                {
                    DisableLinkButton(lnkNext, "next_dis");
                    DisableLinkButton(lnkLast, "fwrd_dis");

                }

                var totalItems = (Literal)gv.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = Count.ToString();
            }
		}

		public void DisableLinkButton(LinkButton linkButton, string disable_class)
		{

			linkButton.CssClass = disable_class;
			linkButton.Enabled = false;
		}

		protected void gvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
            gvAddress.PageIndex = e.NewPageIndex;
            gvAddress.DataBind();
            //FillAddress();
		}
	}
}