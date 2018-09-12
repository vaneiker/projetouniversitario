using System;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using Entity.UnderWriting.Entities;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.IllusData;
using System.Globalization;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCPoliciesInformation : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ObjServices.isChangingLang)
                FillData();
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

        public void FillData()
        {
            var policy = ObjServices.oPolicyManager.GetPolicy(ObjServices.Corp_Id,
                                                              ObjServices.Region_Id,
                                                              ObjServices.Country_Id,
                                                              ObjServices.Domesticreg_Id,
                                                              ObjServices.State_Prov_Id,
                                                              ObjServices.City_Id,
                                                              ObjServices.Office_Id,
                                                              ObjServices.Case_Seq_No,
                                                              ObjServices.Hist_Seq_No);

            var Policies = ObjServices.oPolicyManager.GetQuotationInfoTemp(new Policy.Quo.Temp
            {
                ContactId = ObjServices.ContactEntityID.GetValueOrDefault(),
                PolicyNo = policy.PolicyNo
            })
            .Where(o => !(
                                o.CorpId == ObjServices.Corp_Id &&
                                o.RegionId == ObjServices.Region_Id &&
                                o.CountryId == ObjServices.Country_Id &&
                                o.DomesticregId == ObjServices.Domesticreg_Id &&
                                o.StateProvId == ObjServices.State_Prov_Id &&
                                o.CityId == ObjServices.City_Id &&
                                o.OfficeId == ObjServices.Office_Id &&
                                o.CaseSeqNo == ObjServices.Case_Seq_No &&
                                o.HistSeqNo == ObjServices.Hist_Seq_No
                           )
                           && o.IsPolicy.GetValueOrDefault()
                    )
            .Select(o => new
            {
                Company = o.CompanyDesc,
                Policy = o.PolicyNo,
                BusinessLine = o.BlDesc.Translate(),
                PremiumAmount = o.AnnualPremium != null ? o.AnnualPremium.Value.ToFormatCurrency() : (0m).ToFormatCurrency(),
                EffectiveDate = o.EffectiveDate != null ? o.EffectiveDate.Value.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture).ToUpper() : string.Empty,
                ExpirationDate = o.ExpirationDate != null ? o.ExpirationDate.Value.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture).ToUpper() : string.Empty,
                Status = ("Illustration_" + o.PolicyStatusNameKey).Translate(),
                o.ProductTypeDesc,
                PolicyKey = new
                {
                    CorpId = o.CorpId,
                    RegionId = o.RegionId,
                    CountryId = o.CountryId,
                    DomesticRegId = o.DomesticregId,
                    StateProvId = o.StateProvId,
                    CityId = o.CityId,
                    OfficeId = o.OfficeId,
                    CaseSeqNo = o.CaseSeqNo,
                    HistSeqNo = o.HistSeqNo
                }.ToJSON()
            });

            gvPolicies.DataSource = Policies;
            gvPolicies.DataBind();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }        

        protected void gvPolicies_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            string[] KeyFieldValues = e.KeyValue.ToString().Split('|');
            var policyKey = KeyFieldValues[0].FromJsonToObject<Policy.Parameter>();

            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).FillNotes(policyKey.CorpId,
                                                                                     policyKey.RegionId,
                                                                                     policyKey.CountryId,
                                                                                     policyKey.DomesticregId,
                                                                                     policyKey.StateProvId,
                                                                                     policyKey.CityId,
                                                                                     policyKey.OfficeId,
                                                                                     policyKey.CaseSeqNo,
                                                                                     policyKey.HistSeqNo);
        }

        protected void gvPolicies_PreRender(object sender, EventArgs e)
        {
            (sender as DevExpress.Web.ASPxGridView).TranslateColumnsAspxGrid();
        }

        protected void gvPolicies_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
    }
}