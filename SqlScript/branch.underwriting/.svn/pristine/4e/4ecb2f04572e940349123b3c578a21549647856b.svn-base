using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.Pages
{
    public partial class History : BasePage
    {
        public Services _services = new Services();

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #region Methods
        public void FillData(int contactId, ContactType contactType = ContactType.Owner)
        {
            //FillDataContact(_objServices.Owner_Id);
            _services.RefreshData();
            _services.SessionData.PolicyInfo.CurrentContactId = contactId.ToInt();
            _services.SessionData.PolicyInfo.CurrentContactTypeId = contactType;
            //_services.Current_Contact_Id = contactId;
            //_services.Current_Contact_Type_Id = contactType;
            lnkOwnerInformation.Enabled = true;
            //lnkOwnerInformation.ForeColor = System.Drawing.Color.HotPink;
            lnkInsuredInformation.Enabled = _services.Insured_Contact_Id.HasValue;
            lnkAdditionalInformation.Enabled = _services.Additional_Contact_Id.HasValue;


            liOwnerInformation.Attributes.Remove("class");
            //lnkOwnerInformation.Attributes.Remove("onclick");
            //href="javascript:__doPostBack('ctl00$bodyContent$lnkInsuredInformation','')"
            liInsuredInformation.Attributes.Remove("class");
            lnkInsuredInformation.Attributes.Remove("class");
            liAdditionalInformation.Attributes.Remove("class");


            switch (contactType)
            {
                case ContactType.Owner:
                    liOwnerInformation.Attributes.Add("class", "active");
                    break;
                case ContactType.Insured:
                    liInsuredInformation.Attributes.Add("class", "active");
                    break;
                case ContactType.AdditionalInsured:
                    liAdditionalInformation.Attributes.Add("class", "active");
                    break;
            }

            if ((contactId > 0) || (IsPostBack))
            {
                //LEFT TAB
                UCPolicyDetails.FillPolicyDetail();
                UCEmailAndPhones.FillEmails();
                UCEmailAndPhones.FillPhones();
                UCAddress.FillAddresses();
                UCGreetings.LlenaGreetings();

                //RIGHT TAB
                UCNotes.FillNotes();
                UCAttachment.FillAttachments();
                UCSecurityQuestions.FillSecurityQuestions();
            }

            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "Country",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            try
            {
                /*foreach (var ri in CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(ci => new RegionInfo(ci.ToString())).OrderBy(x => x.TwoLetterISORegionName))
                    Console.WriteLine("{0,3}: {1,11}: {2} ({3})", ri.TwoLetterISORegionName, ri, ri.EnglishName, ri.NativeName);
                var pruebat0 = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                var pruebat1 = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(ci => new RegionInfo(ci.ToString())).Where(x => (x.TwoLetterISORegionName == "DO") || x.ThreeLetterISORegionName == "DOM" || x.ThreeLetterWindowsRegionName == "DOM");*/

                var CountryInfo = lista.FirstOrDefault(o => o.CountryId == _services.Country_Id);
                string[] CalcCountryTimeZoneSplit = (CountryInfo.GlobalCountryDescTimeZone ?? "UTC-4:30").Replace("UTC", "").Split(':');
                decimal? CalcCountryTimeZone = CalcCountryTimeZoneSplit[0].ToInt() + (CalcCountryTimeZoneSplit[1].ToInt() != 0 ? (CalcCountryTimeZoneSplit[1].ToInt() / 60) : 0);
                decimal CountryTimeZone = (decimal)(CalcCountryTimeZone ?? (decimal)-4.5);
                //decimal CountryTimeZone = (decimal)-4.5;
                hdnCurrentCountryTime.Value = CountryTimeZone.ToString();
                //var CountryInfo = lista.FirstOrDefault(o => o.CountryId == _services.Country_Id);
                lblPolicyCountryName.Text = "Republica Dominicana";// lista != null ? CountryInfo.GlobalCountryDesc : "";
            }
            catch (Exception ex)
            {

            }
        }

        /*void FillDataContact(int _services.Current_Contact_Id, ContactType contactType = ContactType.Owner)
        {

        }*/

        private float getInternetExplorerVersion()
        {
            // Returns the version of Internet Explorer or a -1
            // (indicating the use of another browser).
            float rv = -1;
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if (browser.Browser == "IE")
                rv = (float)(browser.MajorVersion + browser.MinorVersion);
            return rv;
        }
        #endregion

        #region Events
        #region LEFT_TAB
        protected void btnGreetings_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VGreetings);
            hfSelectTABLeft.Value = "btnGreetings";
            UCGreetings.LlenaGreetings();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndCommentsHistory");
        }

        protected void btnEmailTelephones_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VEmailAndPhones);
            hfSelectTABLeft.Value = "btnEmailTelephones";
            UCEmailAndPhones.FillEmails();
            UCEmailAndPhones.FillPhones();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndComments2History");
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VAddress);
            hfSelectTABLeft.Value = "btnAddress";
            UCPolicyDetails.FillPolicyDetail();
            UCAddress.FillAddresses();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndCommentsHistory");
        }

        protected void btnPolicyData_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VPolicyDetails);
            hfSelectTABLeft.Value = "btnPolicyData";
            UCPolicyDetails.FillPolicyDetail();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndCommentsHistory");
        }

        protected void btnNextLeft_Click(object sender, EventArgs e)
        {
            if (MVLeft.GetActiveView() == VGreetings)
            {
                //MVLeft.SetActiveView(VEmailAndPhones);
                //hfSelectTABLeft.Value = "btnEmailTelephones";
                btnEmailTelephones_Click(sender, e);
            }
            else
            {
                if (MVLeft.GetActiveView() == VEmailAndPhones)
                {
                    //MVLeft.SetActiveView(VAddress);
                    //hfSelectTABLeft.Value = "btnAddress";
                    btnAddress_Click(sender, e);
                }
                else
                {
                    if (MVLeft.GetActiveView() == VAddress)
                    {
                        //MVLeft.SetActiveView(VPolicyDetails);
                        //hfSelectTABLeft.Value = "btnPolicyData";
                        btnPolicyData_Click(sender, e);
                    }
                    else
                    {
                        if (MVLeft.GetActiveView() == VPolicyDetails)
                        {
                            //MVLeft.SetActiveView(VGreetings);
                            //hfSelectTABLeft.Value = "btnGreetings";
                            btnGreetings_Click(sender, e);
                        }
                    }
                }
            }
        }
        #endregion

        #region RIGHT_TAB
        protected void btnSecurityQuestions_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VSecurityQuestions);
            hfSelectTABRight.Value = "btnSecurityQuestions";
            UCSecurityQuestions.FillSecurityQuestions();
            
        }

        protected void btnNotes_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VNotes);
            hfSelectTABRight.Value = "btnNotes";
            UCNotes.FillNotes();
        }

        protected void btnAttachments_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VAttachment);
            hfSelectTABRight.Value = "btnAttachments";
            UCAttachment.FillAttachments();
        }
        #endregion
        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            btnGreetings.Text = Resources.Greetings.ToUpper();
            btnEmailTelephones.Text = Resources.EmailsAndTelephones.ToUpper();
            btnAddress.Text = Resources.Address.ToUpper();
            btnPolicyData.Text = Resources.PolicyDetails.ToUpper();

            btnSecurityQuestions.Text = Resources.SecurityQuestions.ToUpper();
            btnNotes.Text = Resources.Notes.ToUpper();
            btnAttachments.Text = Resources.Attachments.ToUpper();
            //btnSubmit.Text = Resources.Submit.ToUpper();
            btnNextLeft.Text = Resources.Next.ToUpper();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdnCurrentCountryTime.Value))
            {
                /*TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - Epoch.Ticks);
                hdnCurrentCountryTime.Value = Math.Round(ts.TotalMilliseconds, 0).ToString();*/
                decimal CountryTimeZone = (decimal) - 4.5;
                hdnCurrentCountryTime.Value = CountryTimeZone.ToString();
            }
            if (!IsPostBack)
            {
                //_services.Corp_Id = 1;
                double IE_Verzion = getInternetExplorerVersion();
                lnkOwnerInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkOwnerInformation','')" : "";
                lnkInsuredInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkInsuredInformation','')" : "";
                lnkAdditionalInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkAdditionalInformation','')" : "";
            }
        }

        protected void lnkContactInformation_Click(object sender, EventArgs e)
        {
            var lnk = (LinkButton)sender;

            switch (lnk.Attributes["data-contacttype"])
            {
                case "1":
                    FillData(_services.Owner_Id, ContactType.Owner);
                    break;
                case "2":
                    FillData(_services.Insured_Contact_Id.Value, ContactType.Insured);
                    break;
                case "3":
                    FillData(_services.Additional_Contact_Id.Value, ContactType.AdditionalInsured);
                    break;
            }
        }
        #endregion
    }
}