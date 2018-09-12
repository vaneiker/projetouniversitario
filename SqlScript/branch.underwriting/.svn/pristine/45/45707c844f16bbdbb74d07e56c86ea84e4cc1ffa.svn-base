using System;
/*using WEB.ConfirmationCall.Services.Services;
using WEB.ConfirmationCall.Data.Models;
using WEB.ConfirmationCall.Data.Models.AgentProfile;
using WEB.ConfirmationCall.Infrastructure.Providers;
using WEB.ConfirmationCall.Infrastructure.Utils;
using RESOURCE.UnderWriting.ConfirmationCall;*/

namespace WEB.ConfirmationCall.UserControls.Common.MyProfile
{
    public partial class AgentProfile : System.Web.UI.UserControl
    {
        public bool ApplyPreviousTab
        {
            get
            {
                var applyPreviousTab = Session["ApplyPreviousTab"];
                return applyPreviousTab != null && (bool)applyPreviousTab;
            }

            set
            {
                Session["ApplyPreviousTab"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            /*drpCompanyProfile.DataSource = CommonService.GetListCompany();
            drpCompanyProfile.DataBind();
            drpEmailTo.DataSource = CommonService.GetListDepartments();
            drpEmailTo.DataBind();*/
            Load();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            /*if (UserDataProvider.IsChangingLanguage || !IsPostBack)
            {
                Translate();
            }
            drpCompanyProfile.SelectedValue = UserDataProvider.CompanyId.ToString() ?? "2";
            Change_Logo();*/
        }

        protected void Translate()
        {
            /*txtSubject.Attributes.Add("placeholder", Resources.Subject);
            txtMessage1.Attributes.Add("placeholder", Resources.WriteMessage);
            btnClear.Text = Resources.Clear;
            btnSend.Text = Resources.Send;
            btnLogout.Text = Resources.LogOut;
            btnCancelAProfile.Text = Resources.Cancel;*/
        }

        protected void drpCompanyProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*UserDataProvider.CompanyId = drpCompanyProfile.SelectedValue.ToInt();
            //Change_Logo();
            ApplyPreviousTab = true;
            Session["PreviousTabLeft"] = Session["CurrentTabLeft"];
            Session["PreviousTabRight"] = Session["CurrentTabRight"];
            Response.Redirect(Request.RawUrl, true);*/
        }

        protected void Change_Logo()
        {
            /*System.Web.UI.HtmlControls.HtmlGenericControl profile_menu_logo = (this.Parent as System.Web.UI.UserControl).FindControl("profile_menu_logo") as System.Web.UI.HtmlControls.HtmlGenericControl;
            profile_menu_logo.Attributes.Remove("class");
            profile_menu_logo.Attributes.Add("class", UserDataProvider.CompanyId == 1 ? "logo" : "logo_atl");*/
        }

        new void Load()
        {
            /*using (var service = new AgentService())
            {
                try
                {
                    var data = service.GetAgentInfo();
                    hdnAgentProfileData.Value = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var firstAddress = data.ListAddress.FirstOrDefault();
                    var countryId = firstAddress != null ? firstAddress.CountryId : 0;
                    var regionId = firstAddress != null ? firstAddress.RegionId : 0;
                    var stateId = firstAddress != null ? firstAddress.StateId : 0;
                    hdnListCountry.Value = Newtonsoft.Json.JsonConvert.SerializeObject(CommonService.GetListCountry(UserDataProvider.CorpId).Select(o => o.Value));
                    hdnListRegion.Value = Newtonsoft.Json.JsonConvert.SerializeObject(CommonService.GetDomesticRegionByCountry(countryId, UserDataProvider.CorpId));
                    hdnListState.Value = Newtonsoft.Json.JsonConvert.SerializeObject(CommonService.GetStateProvByDomesticRegion(countryId, regionId, UserDataProvider.CorpId));
                    hdnListCity.Value = Newtonsoft.Json.JsonConvert.SerializeObject(CommonService.GetCityByStateProv(countryId, regionId, stateId, UserDataProvider.CorpId));
                    hdnMessage.Value = "";
                }
                catch (Exception ex)
                {

                }
            }*/
        }

        protected void btnHdnSaveAgentProfileData_Click(object sender, EventArgs e)
        {
            /*var lstMsg = new List<string>();
            try
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<AgentModel>(hdnAgentProfileData.Value);
                var msg = "";
                if (data.ModelIsValid(ref msg))
                    using (var service = new AgentService())
                        service.SaveAgentInfo(data);
                else
                    lstMsg.Add(msg);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    lstMsg.Add(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        lstMsg.Add(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
            }
            catch (Exception ex)
            {
                lstMsg.Add(ex.FindInnerException().Message);
            }
            if (!lstMsg.All(String.IsNullOrEmpty))
            {
                hdnMessage.Value = Newtonsoft.Json.JsonConvert.SerializeObject(lstMsg);
                hdnAgentProfileData.Value = "";
            }
            else
                Load();*/
        }

        protected void btnCancelAProfile_Click(object sender, EventArgs e)
        {
            Load();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            /*if (UserDataProvider.ViewNameId == "")
            {
                Session.Abandon();
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["SecurityLogin"], true);
            }
            else
            {
                UserDataProvider.NameId = UserDataProvider.RealNameId;
                UserDataProvider.Role = UserDataProvider.RealRole;
                HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["DefaultPage"], true);
            }*/
        }
    }
}