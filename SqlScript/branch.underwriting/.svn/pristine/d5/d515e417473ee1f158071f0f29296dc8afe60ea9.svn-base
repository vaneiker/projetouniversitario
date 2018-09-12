using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration.IllustrationVehicle.Models;
using WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCPopupApplySurcharge : UC, IUC
    {
        private bool IsHeaderFilter
        {
            get { return ViewState["IsHeaderFilter"].ToBoolean(); }
            set { ViewState["IsHeaderFilter"] = value; }
        }

        static long UniqueId;
        static int InsuredVehicleId;
        static int CoverageTypeId = Utility.CoverageType.OwnDamages.ToInt(); //Daños Propios

        static int? SurchargeId;
        

        IEnumerable<Policy.VehicleCoverageSurcharge> VehicleCoverageSurcharge;

        static string VehicleHasNoOwnDamagePremium = string.Empty,
                      InformationLabel = string.Empty,
                      SelectTypeSurchargeToApply = string.Empty,
                      SurchargesZeroValue = string.Empty,
                      Warning = string.Empty,
                      YouMustSelectTtypeOfSurchargeToApply = string.Empty,
                      YouMustSelectSurchargePercentageToApply = string.Empty,
                      PercentSurchargeAndSurchargeTypeAlreadyApplied = string.Empty,
                      SurchargeTypeAlreadyApplied = string.Empty;

        private int BlTypeId
        {
            get { return ViewState["BlTypeId"].ToInt(); }
            set { ViewState["BlTypeId"] = value; }
        }

        private decimal AnnualPremium
        {
            get { return ViewState["AnnualPremium"].ToDecimal(); }
            set { ViewState["AnnualPremium"] = value; }
        }

        private int BlId
        {
            get { return ViewState["BlId"].ToInt(); }
            set { ViewState["BlId"] = value; }
        }

        private int ProductId
        {
            get { return ViewState["ProductId"].ToInt(); }
            set { ViewState["ProductId"] = value; }
        }

        private int GroupId
        {
            get { return ViewState["GroupId"].ToInt(); }
            set { ViewState["GroupId"] = value; }
        }

        private int CoverageTypeIdAlliedLines
        {
            get { return ViewState["CoverageTypeIdAlliedLines"].ToInt(); }
            set { ViewState["CoverageTypeIdAlliedLines"] = value; }
        }

        private int CoverageId
        {
            get { return ViewState["CoverageId"].ToInt(); }
            set { ViewState["CoverageId"] = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    trTotalDanosPropios.Visible = true;
                    mtvRecargos.SetActiveView(vRecargosVehiculos);
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            mtvRecargos.SetActiveView(vRecargosAirPlane);
                            break;
                        case Utility.AlliedLinesType.Bail:
                            mtvRecargos.SetActiveView(vRecargosBail);
                            break;
                        case Utility.AlliedLinesType.Navy:
                            mtvRecargos.SetActiveView(vRecargosNavy);
                            break;
                        case Utility.AlliedLinesType.Property:
                            mtvRecargos.SetActiveView(vRecargosProperty);
                            break;
                        case Utility.AlliedLinesType.Transport:
                            mtvRecargos.SetActiveView(vTransport);
                            break;
                    }

                    trTotalDanosPropios.Visible = false;
                    break;
            }
        }

        public void Translator(string Lang)
        {
            VehicleHasNoOwnDamagePremium = Resources.VehicleHasNoOwnDamagePremium;
            InformationLabel = Resources.InformationLabel;
            SelectTypeSurchargeToApply = Resources.SelectTypeSurchargeToApply;
            SurchargesZeroValue = Resources.SurchargesZeroValue;
            Warning = Resources.Warning;
            YouMustSelectTtypeOfSurchargeToApply = Resources.YouMustSelectTtypeOfSurchargeToApply;
            YouMustSelectSurchargePercentageToApply = Resources.YouMustSelectSurchargePercentageToApply;
            PercentSurchargeAndSurchargeTypeAlreadyApplied = Resources.PercentSurchargeAndSurchargeTypeAlreadyApplied;
            SurchargeTypeAlreadyApplied = Resources.SurchargeTypeAlreadyApplied;

            btnApplySurcharge.Text = Resources.Save;
            ppcApplySurcharge.HeaderText = Resources.ApplySurcharge;
            ppcAllSurcharges.HeaderText = Resources.Surcharge;
        }

        protected void UpdatePanel4_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                                         .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();

            methodInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { sender as UpdatePanel });
        }

        private void SelectedRow()
        {
            var index = hdnSelectedRowVisibleIndex.Value.ToInt();

            #region Auto
            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                UniqueId = gvVehiculos.GetKeyFromAspxGridView("VehicleUniqueId", index).ToInt();
                InsuredVehicleId = gvVehiculos.GetKeyFromAspxGridView("InsuredVehicleId", index).ToInt();
                decimal OwnDamage = gvVehiculos.GetKeyFromAspxGridView("OwnDamage", index).ToDecimal();
                ViewState["OwnDamage"] = OwnDamage;

                var coverage = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                {
                    CorpId = ObjServices.Corp_Id,
                    VehicleUniqueId = UniqueId,
                    CoverageTypeId = CoverageTypeId
                }).FirstOrDefault(c => c.VehicleUniqueId == UniqueId);

                if (OwnDamage == 0m || coverage == null)
                {
                    this.MessageBox(VehicleHasNoOwnDamagePremium, Width: 500, Title: InformationLabel);
                    return;
                }

                BindGridRecargos(coverage);

                decimal sumaRecargos = VehicleCoverageSurcharge.Sum(v => v.Recargo);
                lblTotalSurcharges.Text = (sumaRecargos > 0 ? sumaRecargos : 0m).ToFormatCurrency();
                lblTotalOwnDamagesWithSurcharges.Text = (sumaRecargos > 0 ? OwnDamage : 0m).ToFormatCurrency();
            }
            #endregion
            #region Incendio y lineas aliadas
            else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
            {
                switch (ObjServices.AlliedLinesProductBehavior)
                {
                    case Utility.AlliedLinesType.Airplane:
                        UniqueId = gvAirplane.GetKeyFromAspxGridView("UniqueAirplaneId", index).ToInt();
                        this.AnnualPremium = gvAirplane.GetKeyFromAspxGridView("PremiumAmount", index).ToDecimal();
                        break;
                    case Utility.AlliedLinesType.Bail:
                        UniqueId = gvBail.GetKeyFromAspxGridView("UniqueBailId", index).ToInt();
                        this.AnnualPremium = gvBail.GetKeyFromAspxGridView("PremiumAmount", index).ToDecimal();
                        break;
                    case Utility.AlliedLinesType.Navy:
                        UniqueId = gvNavy.GetKeyFromAspxGridView("UniqueNavyId", index).ToInt();
                        this.AnnualPremium = gvNavy.GetKeyFromAspxGridView("PremiumAmount", index).ToDecimal();
                        break;
                    case Utility.AlliedLinesType.Property:
                        UniqueId = gvProperty.GetKeyFromAspxGridView("UniquePropertyId", index).ToInt();
                        this.AnnualPremium = gvProperty.GetKeyFromAspxGridView("PremiumAmount", index).ToDecimal();
                        break;
                    case Utility.AlliedLinesType.Transport:
                        UniqueId = gvTransport.GetKeyFromAspxGridView("UniqueTransportId", index).ToInt();
                        this.AnnualPremium = gvTransport.GetKeyFromAspxGridView("PremiumAmount", index).ToDecimal();
                        break;
                }

                ViewState["OwnDamage"] = this.AnnualPremium;
                BlTypeId = gvAirplane.GetKeyFromAspxGridView("BlTypeId", index).ToInt();
                BlId = gvAirplane.GetKeyFromAspxGridView("BlId", index).ToInt();
                ProductId = gvAirplane.GetKeyFromAspxGridView("ProductId", index).ToInt();
                BindGridRecargos(null);
                //decimal sumaRecargos = VehicleCoverageSurcharge.Sum(v => v.Recargo);
                //lblTotalSurcharges.Text = (sumaRecargos > 0 ? sumaRecargos : 0m).ToFormatCurrency();     
            }
            #endregion

            ddlPorcentajeRecargo.Enabled = true;
            ddlTipoRecargo.Enabled = true;
            btnApplySurcharge.Enabled = true;

            if (ddlPorcentajeRecargo.Items.Count > 0)
                ddlPorcentajeRecargo.SelectedIndex = 0;

            if (ddlTipoRecargo.Items.Count > 0)
                ddlTipoRecargo.SelectedIndex = 0;
        }

        protected void btnSelectedRow_Click(object sender, EventArgs e)
        {
            lblTotalOwnDamagesWithSurcharges.Text = "$0.00";
            lblTotalSurcharges.Text = "$0.00";
            ViewState["OwnDamage"] = 0m;
            txtCalculoRecargo.Text = "$0.00";

            SelectedRow();
        }

        protected void btnApplySurcharge_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;

            if (ddlTipoRecargo.SelectedItem.Value == "-1")
                msg = SelectTypeSurchargeToApply;
            else if (ddlPorcentajeRecargo.SelectedItem.Value == "0")
                msg = SurchargesZeroValue;

            if (!string.IsNullOrWhiteSpace(msg))
            {
                this.MessageBox(msg, Width: 500, Title: Warning);
                return;
            }

            save();
        }

        public void FillData()
        {
            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    var Params = new Policy.VehicleInsured.CoverageTypePremiun.Key
                   {
                       CorpId = ObjServices.Corp_Id,
                       RegionId = ObjServices.Region_Id,
                       CountryId = ObjServices.Country_Id,
                       DomesticRegId = ObjServices.Domesticreg_Id,
                       StateProvId = ObjServices.State_Prov_Id,
                       CityId = ObjServices.City_Id,
                       OfficeId = ObjServices.Office_Id,
                       CaseSeqNo = ObjServices.Case_Seq_No,
                       HistSeqNo = ObjServices.Hist_Seq_No,
                       InsuredVehicleId = 0,
                       CoverageTypeId = CoverageTypeId
                   };

                    var dataVehicle = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
                    {
                        CorpId = ObjServices.Corp_Id,
                        RegionId = ObjServices.Region_Id,
                        CountryId = ObjServices.Country_Id,
                        DomesticregId = ObjServices.Domesticreg_Id,
                        StateProvId = ObjServices.State_Prov_Id,
                        CityId = ObjServices.City_Id,
                        OfficeId = ObjServices.Office_Id,
                        CaseSeqNo = ObjServices.Case_Seq_No,
                        HistSeqNo = ObjServices.Hist_Seq_No
                    }).Select(v =>
                    {
                        Params.InsuredVehicleId = v.InsuredVehicleId.GetValueOrDefault();
                        var victp = ObjServices.oPolicyManager.GetVehicleInsuredCoverageTypePremiun(Params).FirstOrDefault(t => t.CoverageTypeId == CoverageTypeId);
                        v.OwnDamage = victp != null ? victp.PremiumAmount : 0m;
                        v.OwnDamageF = victp != null ? victp.PremiumAmount.ToString("#,0.00", CultureInfo.InvariantCulture) : "0";
                        v.VehicleDesc = string.Format("{0} {1} {2}", v.MakeDesc, v.ModelDesc, v.Year);
                        v.InsuredAmount = v.VehicleValue;
                        v.InsuredAmountF = v.VehicleValue.HasValue ? v.VehicleValue.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0";
                        v.PremiumAmountF = v.PremiumAmount.HasValue ? v.PremiumAmount.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0";
                        bool SurchargeApplied = false;
                        var coverage = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                        {
                            CorpId = v.CorpId,
                            VehicleUniqueId = v.VehicleUniqueId,
                            CoverageTypeId = CoverageTypeId
                        }).FirstOrDefault();

                        if (coverage != null)
                        {
                            var vcs = ObjServices.oPolicyManager.GetVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                            {
                                CorpId = coverage.CorpId,
                                RegionId = coverage.RegionId,
                                CountryId = coverage.CountryId,
                                VehicleUniqueId = coverage.VehicleUniqueId,
                                BlTypeId = coverage.BlTypeId,
                                BlId = coverage.BlId,
                                ProductId = coverage.ProductId,
                                VehicleTypeId = coverage.VehicleTypeId,
                                GroupId = coverage.GroupId,
                                CoverageTypeId = coverage.CoverageTypeId,
                                CoverageId = coverage.CoverageId,
                                SurchargeId = null,
                                DiscountRuleId = null,
                                DiscountRuleDetailId = null,
                                Language = ObjServices.Language.ToInt()
                            }).ToList();

                            SurchargeApplied = vcs.Count > 0;
                        }

                        v.SurchargeApplied = SurchargeApplied;

                        return v;
                    });
                    
                    gvVehiculos.DataSource = dataVehicle;
                    gvVehiculos.DataBind();
                    gvVehiculos.FocusedRowIndex = -1;
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            var dataAirplane = ObjServices.GetDataAirPlane().Select(v =>
                                {
                                    bool SurchargeApplied = false;
                                    var coverage = ObjServices.oAirPlaneManager.GetAirPlaneInsuredCoverage(new Airplane.Insured.Coverage.Key
                                    {
                                        CorpId = v.CorpId,
                                        UniqueAirplaneId = (int)v.UniqueAirplaneId,
                                        CoverageTypeId = CoverageTypeId
                                    }).FirstOrDefault();

                                    if (coverage != null)
                                    {
                                        var vcs = ObjServices.oAirPlaneManager.GetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge.Key
                                        {
                                            CorpId = coverage.CorpId,
                                            RegionId = coverage.RegionId,
                                            CountryId = coverage.CountryId,
                                            UniqueAirplaneId = coverage.UniqueAirplaneId,
                                            BlTypeId = coverage.BlTypeId,
                                            BlId = coverage.BlId,
                                            ProductId = coverage.ProductId,
                                            VehicleTypeId = coverage.VehicleTypeId,
                                            GroupId = coverage.GroupId,
                                            CoverageTypeId = coverage.CoverageTypeId,
                                            CoverageId = coverage.CoverageId,
                                            SurchargeId = null,
                                            discountRuleId = null,
                                            discountRuleDetailId = null,
                                            languageId = ObjServices.Language.ToInt()
                                        }).ToList();

                                        SurchargeApplied = vcs.Count > 0;
                                    }

                                    v.surchargeApplied = SurchargeApplied;

                                    return v;
                                }
                             );
                            gvAirplane.DatabindAspxGridView(dataAirplane);
                            break;
                        case Utility.AlliedLinesType.Bail:
                            var dataBail = ObjServices.GetDataBail().Select(v =>
                            {
                                bool SurchargeApplied = false;
                                var coverage = ObjServices.oBailManager.GetBailInsuredCoverage(new Bail.Insured.Coverage.Key
                                {
                                    CorpId = v.CorpId,
                                    UniqueBailId = v.UniqueBailId,
                                    CoverageTypeId = CoverageTypeId
                                }).FirstOrDefault();


                                if (coverage != null)
                                {
                                    var vcs = ObjServices.oBailManager.GetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = coverage.CorpId.GetValueOrDefault(),
                                        RegionId = coverage.RegionId.GetValueOrDefault(),
                                        CountryId = coverage.CountryId.GetValueOrDefault(),
                                        UniqueBailId = coverage.UniqueBailId.GetValueOrDefault(),
                                        BlTypeId = coverage.BlTypeId.GetValueOrDefault(),
                                        BlId = coverage.BlId.GetValueOrDefault(),
                                        ProductId = coverage.ProductId.GetValueOrDefault(),
                                        VehicleTypeId = coverage.VehicleTypeId.GetValueOrDefault(),
                                        GroupId = coverage.GroupId.GetValueOrDefault(),
                                        CoverageTypeId = coverage.CoverageTypeId.GetValueOrDefault(),
                                        CoverageId = coverage.CoverageId.GetValueOrDefault(),
                                        SurchargeId = null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).ToList();

                                    SurchargeApplied = vcs.Count > 0;
                                }

                                v.surchargeApplied = SurchargeApplied;

                                return v;
                            });
                            gvBail.DatabindAspxGridView(dataBail);
                            break;
                        case Utility.AlliedLinesType.Navy:
                            var dataNavy = ObjServices.GetDataNavy().Select(v =>
                            {
                                bool SurchargeApplied = false;
                                var coverage = ObjServices.oNavyManager.GetNavyInsuredCoverage(new Navy.Insured.Coverage.Key
                                {
                                    CorpId = v.CorpId,
                                    UniqueNavyId = (int)v.UniqueNavyId,
                                    CoverageTypeId = CoverageTypeId
                                }).FirstOrDefault();


                                if (coverage != null)
                                {
                                    var vcs = ObjServices.oNavyManager.GetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = coverage.CorpId.GetValueOrDefault(),
                                        RegionId = coverage.RegionId.GetValueOrDefault(),
                                        CountryId = coverage.CountryId.GetValueOrDefault(),
                                        UniqueNavyId = coverage.UniqueNavyId.GetValueOrDefault(),
                                        BlTypeId = coverage.BlTypeId.GetValueOrDefault(),
                                        BlId = coverage.BlId.GetValueOrDefault(),
                                        ProductId = coverage.ProductId.GetValueOrDefault(),
                                        VehicleTypeId = coverage.VehicleTypeId.GetValueOrDefault(),
                                        GroupId = coverage.GroupId.GetValueOrDefault(),
                                        CoverageTypeId = coverage.CoverageTypeId.GetValueOrDefault(),
                                        CoverageId = coverage.CoverageId.GetValueOrDefault(),
                                        SurchargeId = null,
                                        DiscountRuleId = null,
                                        DiscountRuleDetailId = null,
                                        LanguageId = ObjServices.Language.ToInt()
                                    }).ToList();

                                    SurchargeApplied = vcs.Count > 0;
                                }

                                v.surchargeApplied = SurchargeApplied;

                                return v;
                            });
                            gvNavy.DatabindAspxGridView(dataNavy);
                            break;
                        case Utility.AlliedLinesType.Property:
                            var dataProperty = ObjServices.GetDataProperty().Select(v =>
                            {
                                bool SurchargeApplied = false;
                                var coverage = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                                {
                                    corpId = v.CorpId,
                                    uniquePropertyId = v.UniquePropertyId
                                }).FirstOrDefault();


                                if (coverage != null)
                                {
                                    var vcs = ObjServices.oPropertyManager.GetPropertyInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge.Key
                                    {
                                        corpId = coverage.CorpId,
                                        regionId = coverage.RegionId,
                                        countryId = coverage.CountryId,
                                        uniquePropertyId = coverage.UniquePropertyId,
                                        blTypeId = coverage.BlTypeId,
                                        blId = coverage.BlId,
                                        productId = coverage.ProductId,
                                        vehicleTypeId = coverage.VehicleTypeId,
                                        groupId = coverage.GroupId,
                                        coverageTypeId = coverage.CoverageTypeId,
                                        coverageId = coverage.CoverageId,
                                        surchargeId = null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).ToList();

                                    SurchargeApplied = vcs.Count > 0;
                                }

                                v.surchargeApplied = SurchargeApplied;

                                return v;
                            }); ;
                            gvProperty.DatabindAspxGridView(dataProperty);
                            break;
                        case Utility.AlliedLinesType.Transport:
                            var dataTransport = ObjServices.GetDataTransport().Select(v =>
                            {
                                bool SurchargeApplied = false;
                                var coverage = ObjServices.oTransportManager.GetTransportInsuredCoverage(new Transport.Insured.Coverage.Key
                                {
                                    CorpId = v.CorpId,
                                    UniqueTransportId = (int)v.UniqueTransportId,
                                    CoverageTypeId = CoverageTypeId
                                }).FirstOrDefault();


                                if (coverage != null)
                                {
                                    var vcs = ObjServices.oTransportManager.GetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = coverage.CorpId.GetValueOrDefault(),
                                        RegionId = coverage.RegionId.GetValueOrDefault(),
                                        CountryId = coverage.CountryId.GetValueOrDefault(),
                                        UniqueTransportId = coverage.UniqueTransportId.GetValueOrDefault(),
                                        BlTypeId = coverage.BlTypeId.GetValueOrDefault(),
                                        BlId = coverage.BlId.GetValueOrDefault(),
                                        ProductId = coverage.ProductId.GetValueOrDefault(),
                                        VehicleTypeId = coverage.VehicleTypeId.GetValueOrDefault(),
                                        GroupId = coverage.GroupId.GetValueOrDefault(),
                                        CoverageTypeId = coverage.CoverageTypeId.GetValueOrDefault(),
                                        CoverageId = coverage.CoverageId.GetValueOrDefault(),
                                        SurchargeId = null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).ToList();

                                    SurchargeApplied = vcs.Count > 0;
                                }

                                v.surchargeApplied = SurchargeApplied;

                                return v;
                            });
                            gvTransport.DatabindAspxGridView(dataTransport);
                            break;
                    }
                    break;
            }
        }

        private void FillDropDownSurcharge(DropDownList dropDownList)
        {
            var lstSurchargeRules = ObjServices.oPolicyManager.GetDiscountRulesAndDetails(new Policy.DParameter
                {
                    Active = true,
                    CorpId = ObjServices.Corp_Id,
                    NameKey = Utility.DiscountRules.SurchargeByUseType.ToString()
                }).ToList();

            if (!lstSurchargeRules.Any()) return;

            var ListDiscountRules = lstSurchargeRules.Select(o => new DiscountRule
            {
                DiscountRuleId = o.DiscountRuleId,
                DiscountRuleDetailId = o.DetailId,
                DiscountRuleNameKey = o.NameKey,
                DiscountRuleValue = o.DetailRuleValue,
                DiscountRuleDetailNameKey = o.DetailNameKey
            }).ToList();

            var lstSurcharge = new Dictionary<string, string>();
            lstSurcharge.Add("0", Resources.Select);

            ListDiscountRules.ForEach(o => lstSurcharge.Add(o.ToJSON(), o.DiscountRuleValue.ToDecimal().ToPercent(false)));
            dropDownList.DataSource = lstSurcharge;
            dropDownList.DataTextField = "Value";
            dropDownList.DataValueField = "Key";
            dropDownList.DataBind();
        }

        private void FillDrops()
        {
            #region Tipo de Recargo
            ObjServices.FillReason(ddlTipoRecargo,
                                   Utility.ReasonPredefinieds.SurchargeIllustrationReason,
                                   Utility.EFamilyProductType.Auto.ToString());
            ddlTipoRecargo.SelectedIndex = 0;
            #endregion

            #region Porcentajes de Recargo
            FillDropDownSurcharge(ddlPorcentajeRecargo);
            if (ddlPorcentajeRecargo.Items.Count > 0)
                ddlPorcentajeRecargo.SelectedIndex = 0;
            #endregion
        }

        protected void gvVehiculos_BeforeHeaderFilterFillItems(object sender, DevExpress.Web.ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {
            IsHeaderFilter = true;
        }

        protected void gvVehiculos_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                FillData();
                Grid.FocusedRowIndex = -1;
                Grid.SetFilterSettings();
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            ddlPorcentajeRecargo.Enabled = isReadOnly;
            ddlTipoRecargo.Enabled = isReadOnly;
            btnApplySurcharge.Enabled = isReadOnly;
            if (isReadOnly == false)
                btnApplySurcharge.Attributes.Remove("Style");
        }

        public void save()
        {
            try
            {
                if (ddlTipoRecargo.SelectedIndex == 0)
                {
                    this.MessageBox(YouMustSelectTtypeOfSurchargeToApply, Width: 500, Title: Warning);
                    return;
                }

                if (ddlPorcentajeRecargo.SelectedIndex == 0)
                {
                    this.MessageBox(YouMustSelectSurchargePercentageToApply, Width: 500, Title: Warning);
                    return;
                }

                DiscountRule porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.SelectedValue);

                int notePredefiniedId = ddlTipoRecargo.SelectedValue.ToInt();

                if (ViewState["SurchargeId"] != null) { SurchargeId = ViewState["SurchargeId"] as int?; }
                #region Auto
                if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                {
                    var coverage = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                    {
                        CorpId = ObjServices.Corp_Id,
                        VehicleUniqueId = UniqueId,
                        CoverageTypeId = CoverageTypeId
                    }).FirstOrDefault(c => c.VehicleUniqueId == UniqueId);

                    var coverage_surcharges = ObjServices.oPolicyManager.GetVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                    {
                        CorpId = ObjServices.Corp_Id,
                        RegionId = ObjServices.Region_Id,
                        CountryId = ObjServices.Country_Id,
                        VehicleUniqueId = UniqueId,
                        BlTypeId = coverage.BlTypeId,
                        BlId = coverage.BlId,
                        ProductId = coverage.ProductId,
                        VehicleTypeId = coverage.VehicleTypeId,
                        GroupId = coverage.GroupId,
                        CoverageTypeId = coverage.CoverageTypeId,
                        CoverageId = coverage.CoverageId,
                        SurchargeId = null,
                        DiscountRuleId = null,
                        DiscountRuleDetailId = null,
                        Language = ObjServices.Language.ToInt()
                    }).ToList();

                    if (coverage_surcharges.Count > 0)
                    {
                        bool aplicado = false;
                        string msg = string.Empty;
                        bool edit = Convert.ToBoolean(ViewState["edit"]);
                        foreach (var coverage_surcharge in coverage_surcharges)
                        {
                            if (coverage_surcharge.NotePredefiniedId == notePredefiniedId &&
                                coverage_surcharge.DiscountRuleId == porcentaje_seleccionado.DiscountRuleId &&
                                coverage_surcharge.DiscountRuleDetailId == porcentaje_seleccionado.DiscountRuleDetailId)
                            {
                                msg = PercentSurchargeAndSurchargeTypeAlreadyApplied;
                                aplicado = true;
                                break;
                            }

                            if (!edit && coverage_surcharge.NotePredefiniedId == notePredefiniedId)
                            {
                                msg = SurchargeTypeAlreadyApplied;
                                aplicado = true;
                                break;
                            }
                        }

                        if (aplicado)
                        {
                            this.MessageBox(msg, Width: 500, Title: Warning);
                            return;
                        }
                    }

                    decimal OwnDamage = ViewState["OwnDamage"].ToDecimal(),
                            calculo_porcentaje = OwnDamage * (porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true)),
                            premiumAmountWithSurcharge = (OwnDamage + calculo_porcentaje),
                            OwnDamagesWithSurcharge = (OwnDamage + calculo_porcentaje);

                    //Guardar
                    var surcharge = ObjServices.oPolicyManager.SetVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                    {
                        CorpId = ObjServices.Corp_Id,
                        RegionId = ObjServices.Region_Id,
                        CountryId = ObjServices.Country_Id,
                        SurchargeId = SurchargeId,
                        DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                        DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                        OldCoverageAmount = OwnDamage,
                        VehicleUniqueId = UniqueId,
                        BlTypeId = coverage.BlTypeId,
                        BlId = coverage.BlId,
                        ProductId = coverage.ProductId,
                        VehicleTypeId = coverage.VehicleTypeId,
                        GroupId = coverage.GroupId,
                        CoverageTypeId = CoverageTypeId,
                        CoverageId = coverage.CoverageId,
                        UserId = ObjServices.UserID.GetValueOrDefault(),
                        NotePredefiniedId = notePredefiniedId
                    });

                    //ejecutar proceso cargos/descuentos
                    var result = ObjServices.oPolicyManager.SetVehicleInsuredApplyDiscountAndSurcharge(new Policy.Parameter
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
                        UserId = ObjServices.UserID
                    });

                    #region Actualizar Flat Table
                    ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());
                    #endregion

                    if (ddlPorcentajeRecargo.Items.Count > 0)
                        ddlPorcentajeRecargo.SelectedIndex = 0;

                    if (ddlTipoRecargo.Items.Count > 0)
                        ddlTipoRecargo.SelectedIndex = 0;

                    var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;
                    if (IllustrationsVehiclePage != null)
                    {
                        IllustrationsVehiclePage.FillVehiclesInformation();

                        var IllustrationInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCIllustrationInformation);
                        if (IllustrationInformationUC != null)
                            (IllustrationInformationUC as UCIllustrationInformation).FillData();
                    }

                    ViewState["SurchargeId"] = null;
                    SurchargeId = null;
                    ViewState["edit"] = false;

                    BindGridRecargos(coverage);

                    decimal sumaRecargos = VehicleCoverageSurcharge.Sum(v => v.Recargo);
                    string totalOwnDamagesWithSurcharge = sumaRecargos > 0 ? (OwnDamage + sumaRecargos).ToFormatCurrency() : "$0.00";

                    lblTotalSurcharges.Text = sumaRecargos.ToFormatCurrency();
                    lblTotalOwnDamagesWithSurcharges.Text = totalOwnDamagesWithSurcharge;
                }
                #endregion
                #region Incendio y Lineas aliadas
                else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                {
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            //Guardar
                            var oAirplaneSurcharge = ObjServices.oAirPlaneManager.SetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : -1,
                                DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                                DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                                UniqueAirplaneId = UniqueId,
                                OldCoverageAmount = this.AnnualPremium,
                                BlTypeId = this.BlTypeId,
                                BlId = this.BlId,
                                ProductId = this.ProductId,
                                VehicleTypeId = 1,
                                GroupId = this.GroupId,
                                SurchargeStatus = true,
                                CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                CoverageId = this.CoverageId,
                                UserId = ObjServices.UserID.GetValueOrDefault(),
                                NotePredefiniedId = notePredefiniedId
                            });

                            ObjServices.oAirPlaneManager.SetAirplaneApplyDiscountAndSurcharge(new Airplane.Insured
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                DomesticRegId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                UserId = ObjServices.UserID.GetValueOrDefault()
                            });

                            break;
                        case Utility.AlliedLinesType.Bail:
                            //Guardar
                            var oBailSurcharge = ObjServices.oBailManager.SetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : -1,
                                DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                                DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                                UniqueBailId = UniqueId,
                                OldCoverageAmount = this.AnnualPremium,
                                BlTypeId = this.BlTypeId,
                                BlId = this.BlId,
                                ProductId = this.ProductId,
                                VehicleTypeId = 1,
                                GroupId = this.GroupId,
                                SurchargeStatus = true,
                                CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                CoverageId = this.CoverageId,
                                UserId = ObjServices.UserID.GetValueOrDefault(),
                                NotePredefiniedId = notePredefiniedId
                            });

                            ObjServices.oBailManager.SetBailInsuredApplyDiscountAndSurcharge(new Bail.Insured
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
                                UsrId = ObjServices.UserID.GetValueOrDefault()
                            });
                            break;
                        case Utility.AlliedLinesType.Navy:
                            //Guardar
                            var oNavySurcharge = ObjServices.oNavyManager.SetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : -1,
                                DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                                DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                                UniqueNavyId = UniqueId,
                                OldCoverageAmount = this.AnnualPremium,
                                BlTypeId = this.BlTypeId,
                                BlId = this.BlId,
                                ProductId = this.ProductId,
                                VehicleTypeId = 1,
                                GroupId = this.GroupId,
                                SurchargeStatus = true,
                                CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                CoverageId = this.CoverageId,
                                UserId = ObjServices.UserID.GetValueOrDefault(),
                                NotePredefiniedId = notePredefiniedId
                            });

                            ObjServices.oNavyManager.SetNavyInsuredApplyDiscountAndSurcharge(new Navy.Insured
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                DomesticRegId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                UserId = ObjServices.UserID.GetValueOrDefault()
                            });
                            break;
                        case Utility.AlliedLinesType.Property:
                            //Guardar
                            var oPropertySurcharge = ObjServices.oPropertyManager.SetPropertytInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : -1,
                                DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                                DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                                UniquePropertyId = UniqueId,
                                OldCoverageAmount = this.AnnualPremium,
                                BlTypeId = this.BlTypeId,
                                BlId = this.BlId,
                                ProductId = this.ProductId,
                                VehicleTypeId = 1,
                                GroupId = this.GroupId,
                                SurchargeStatus = true,
                                CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                CoverageId = this.CoverageId,
                                UserId = ObjServices.UserID.GetValueOrDefault(),
                                NotePredefiniedId = notePredefiniedId
                            });
                            var obj =
                            ObjServices.oPropertyManager.SetPropertyInsuredApplyDiscountAndSurcharge(new Property.Insured
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
                                UserId = ObjServices.UserID.GetValueOrDefault()
                            });
                            break;
                        case Utility.AlliedLinesType.Transport:
                            //Guardar
                            var oTransportSurcharge = ObjServices.oTransportManager.SetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : -1,
                                DiscountRuleId = porcentaje_seleccionado.DiscountRuleId,
                                DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId,
                                uniqueTransportId = UniqueId,
                                OldCoverageAmount = this.AnnualPremium,
                                BlTypeId = this.BlTypeId,
                                BlId = this.BlId,
                                ProductId = this.ProductId,
                                VehicleTypeId = 1,
                                GroupId = this.GroupId,
                                SurchargeStatus = true,
                                CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                CoverageId = this.CoverageId,
                                UserId = ObjServices.UserID.GetValueOrDefault(),
                                NotePredefiniedId = notePredefiniedId
                            });

                            ObjServices.oTransportManager.SetTransportInsuredApplyDiscountAndSurcharge(new Transport.Insured
                            {
                                CorpId = ObjServices.Corp_Id,
                                RegionId = ObjServices.Region_Id,
                                CountryId = ObjServices.Country_Id,
                                DomesticRegId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                UserId = ObjServices.UserID.GetValueOrDefault()
                            });
                            break;
                    }

                    #region Actualizar Flat Table
                    ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());
                    #endregion

                    if (ddlPorcentajeRecargo.Items.Count > 0)
                        ddlPorcentajeRecargo.SelectedIndex = 0;

                    if (ddlTipoRecargo.Items.Count > 0)
                        ddlTipoRecargo.SelectedIndex = 0;

                    var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;
                    if (IllustrationsVehiclePage != null)
                    {
                        switch (ObjServices.AlliedLinesProductBehavior)
                        {
                            case Utility.AlliedLinesType.Airplane:
                                var UCAirPlane = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCAirPlane);
                                if (UCAirPlane != null)
                                    (UCAirPlane as UCAirPlane).FillData();
                                break;
                            case Utility.AlliedLinesType.Bail:
                                var UCBail = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCBail);
                                if (UCBail != null)
                                    (UCBail as UCBail).FillData();
                                break;
                            case Utility.AlliedLinesType.Navy:
                                var UCNavy = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCNavy);
                                if (UCNavy != null)
                                    (UCNavy as UCNavy).FillData();
                                break;
                            case Utility.AlliedLinesType.Property:
                                var UCProperty = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCProperty);
                                if (UCProperty != null)
                                    (UCProperty as UCProperty).FillData();
                                break;
                            case Utility.AlliedLinesType.Transport:
                                var UCTransport = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCTransport);
                                if (UCTransport != null)
                                    (UCTransport as UCTransport).FillData();
                                break;
                        }

                        var IllustrationInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCIllustrationInformation);
                        if (IllustrationInformationUC != null)
                            (IllustrationInformationUC as UCIllustrationInformation).FillData();
                    }

                    ViewState["SurchargeId"] = null;
                    SurchargeId = null;
                    ViewState["edit"] = false;

                    BindGridRecargos(null);
                }
                #endregion

                ViewState["OwnDamage"] = 0m;

                FillData();

                SelectedRow();

                txtCalculoRecargo.Text = "$0.00";
            }
            catch (Exception ex)
            {
                var msg = ex.GetLastInnerException().Message;
                this.MessageBox(msg, Width: 500, Title: "Error");
            }
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            ClearData();
            FillDrops();
            FillData();
        }

        public void ClearData()
        {
            ViewState["OwnDamage"] = 0m;
            Session["VehicleCoverageSurcharge"] = null;
            ViewState["SurchargeId"] = null;
            SurchargeId = null;
            ReadOnlyControls(false);
            gvRecargos.DataSource = null;
            gvRecargos.DataBind();
            ViewState["edit"] = false;
            lblTotalOwnDamagesWithSurcharges.Text = "$0.00";
            lblTotalSurcharges.Text = "$0.00";
            lblTotalAllSurcharges.Text = "$0.00";
            txtCalculoRecargo.Text = "$0.00";
        }

        public void SeeAllSurcharges()
        {
            decimal sumaTodosRecargos = 0m;

            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                var CoverageSurcharges = new List<Policy.VehicleCoverageSurcharge>(0);

                var Params = new Policy.Parameter
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No
                };

                var dataVehicle = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No
                }).ToList();

                if (dataVehicle.Count > 0)
                {
                    foreach (var item in dataVehicle)
                    {
                        var coverages = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                        {
                            CorpId = ObjServices.Corp_Id,
                            VehicleUniqueId = item.VehicleUniqueId,
                            CoverageTypeId = CoverageTypeId
                        }).ToList();

                        if (coverages.Count > 0)
                        {
                            foreach (var surcharge in coverages)
                            {
                                var CoverageSurcharge = ObjServices.oPolicyManager.GetVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                                {
                                    CorpId = surcharge.CorpId,
                                    RegionId = surcharge.RegionId,
                                    CountryId = surcharge.CountryId,
                                    VehicleUniqueId = surcharge.VehicleUniqueId,
                                    BlTypeId = surcharge.BlTypeId,
                                    BlId = surcharge.BlId,
                                    ProductId = surcharge.ProductId,
                                    VehicleTypeId = surcharge.VehicleTypeId,
                                    GroupId = surcharge.GroupId,
                                    CoverageTypeId = CoverageTypeId,
                                    CoverageId = surcharge.CoverageId,
                                    SurchargeId = null,
                                    DiscountRuleId = null,
                                    DiscountRuleDetailId = null,
                                    Language = ObjServices.Language.ToInt()
                                }).Select(s =>
                                {
                                    decimal recargo = s.OldCoverageAmount.Value * (s.DetailRuleValue.ToDecimal(0, true));
                                    var vehicle = ObjServices.oPolicyManager.GetVehicleInsured(Params).FirstOrDefault(v => v.VehicleUniqueId == surcharge.VehicleUniqueId);
                                    s.TipoRecargo = s.NotePredefiniedDesc;
                                    s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                    s.Recargo = recargo;
                                    s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                    s.VehicleDesc = string.Format("{0} {1} {2}", vehicle.MakeDesc, vehicle.ModelDesc, vehicle.Year);
                                    s.Registry = vehicle.Registry;
                                    return s;
                                }).ToList();

                                if (CoverageSurcharge != null)
                                    foreach (var _item in CoverageSurcharge)
                                        CoverageSurcharges.Add(_item);
                            }
                        }
                    }
                }

                mtMasterAllSurcharges.SetActiveView(vAllSurchargesAuto);
                sumaTodosRecargos = CoverageSurcharges.Sum(v => v.Recargo);
                lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                gvAllSurcharges.DataSource = CoverageSurcharges;
                gvAllSurcharges.DataBind();
                gvAllSurcharges.FocusedRowIndex = -1;
            }
            else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
            {
                switch (ObjServices.AlliedLinesProductBehavior)
                {
                    #region Airplane
                    case Utility.AlliedLinesType.Airplane:
                        var CoverageSurchargesAirplane = new List<Airplane.Insured.Coverage.Surcharge>(0);

                        var dataAirplane = ObjServices.GetDataAirPlane().ToList();

                        if (dataAirplane.Count > 0)
                        {
                            foreach (var item in dataAirplane)
                            {
                                var coveragesAirplane = ObjServices.oAirPlaneManager.GetAirPlaneInsuredCoverage(new Airplane.Insured.Coverage.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    UniqueAirplaneId = (int)item.UniqueAirplaneId
                                }).FirstOrDefault();

                                if (coveragesAirplane != null)
                                {
                                    var CoverageSAirplane = ObjServices.oAirPlaneManager.GetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = ObjServices.Corp_Id,
                                        RegionId = ObjServices.Region_Id,
                                        CountryId = ObjServices.Country_Id,
                                        UniqueAirplaneId = (int)item.UniqueAirplaneId,
                                        BlTypeId = coveragesAirplane.BlTypeId,
                                        BlId = coveragesAirplane.BlId,
                                        ProductId = coveragesAirplane.ProductId,
                                        VehicleTypeId = coveragesAirplane.VehicleTypeId,
                                        GroupId = coveragesAirplane.GroupId,
                                        CoverageTypeId = coveragesAirplane.CoverageTypeId,
                                        CoverageId = coveragesAirplane.CoverageId,
                                        SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).Select(s =>
                                    {
                                        decimal recargo = s.OldCoverageAmount * (s.DetailRuleValue.ToDecimal(0, true));
                                        s.TipoRecargo = s.NotePredefiniedDesc;
                                        s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                        s.Recargo = recargo;
                                        s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                        return s;
                                    }).ToList();

                                    if (CoverageSAirplane != null)
                                        foreach (var _item in CoverageSAirplane)
                                            CoverageSurchargesAirplane.Add(_item);
                                }
                            }
                        }

                        sumaTodosRecargos = CoverageSurchargesAirplane.Sum(v => v.Recargo);
                        lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                        mtMasterAllSurcharges.SetActiveView(vAllSurchargesAirplane);
                        gvAllSurchargesAirPlane.DataSource = CoverageSurchargesAirplane;
                        gvAllSurchargesAirPlane.DataBind();
                        break;
                    #endregion
                    #region Bail
                    case Utility.AlliedLinesType.Bail:
                        var CoverageSurchargesBail = new List<Bail.Insured.Coverage.Surcharge>(0);

                        var dataBail = ObjServices.GetDataBail().ToList();

                        if (dataBail.Count > 0)
                        {
                            foreach (var item in dataBail)
                            {
                                var coveragesBail = ObjServices.oBailManager.GetBailInsuredCoverage(new Bail.Insured.Coverage.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    UniqueBailId = (int)item.UniqueBailId
                                }).FirstOrDefault();

                                if (coveragesBail != null)
                                {
                                    var CoverageSBail = ObjServices.oBailManager.GetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = ObjServices.Corp_Id,
                                        RegionId = ObjServices.Region_Id,
                                        CountryId = ObjServices.Country_Id,
                                        UniqueBailId = (int)item.UniqueBailId,
                                        BlTypeId = coveragesBail.BlTypeId.GetValueOrDefault(),
                                        BlId = coveragesBail.BlId.GetValueOrDefault(),
                                        ProductId = coveragesBail.ProductId.GetValueOrDefault(),
                                        VehicleTypeId = coveragesBail.VehicleTypeId.GetValueOrDefault(),
                                        GroupId = coveragesBail.GroupId.GetValueOrDefault(),
                                        CoverageTypeId = coveragesBail.CoverageTypeId.GetValueOrDefault(),
                                        CoverageId = coveragesBail.CoverageId.GetValueOrDefault(),
                                        SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).Select(s =>
                                    {
                                        decimal recargo = s.OldCoverageAmount * (s.DetailRuleValue.ToDecimal(0, true));
                                        s.TipoRecargo = s.NotePredefiniedDesc;
                                        s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                        s.Recargo = recargo;
                                        s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                        return s;
                                    }).ToList();

                                    if (CoverageSBail != null)
                                        foreach (var _item in CoverageSBail)
                                            CoverageSurchargesBail.Add(_item);
                                }
                            }
                        }

                        sumaTodosRecargos = CoverageSurchargesBail.Sum(v => v.Recargo);
                        lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                        mtMasterAllSurcharges.SetActiveView(vAllSurchargesBail);
                        gvAllSurchargesBail.DataSource = CoverageSurchargesBail;
                        gvAllSurchargesBail.DataBind();
                        break;
                    #endregion
                    #region Navy
                    case Utility.AlliedLinesType.Navy:
                        var CoverageSurchargesNavy = new List<Navy.Insured.Coverage.Surcharge>(0);

                        var dataNavy = ObjServices.GetDataNavy().ToList();

                        if (dataNavy.Count > 0)
                        {
                            foreach (var item in dataNavy)
                            {
                                var coveragesNavy = ObjServices.oNavyManager.GetNavyInsuredCoverage(new Navy.Insured.Coverage.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    UniqueNavyId = (int)item.UniqueNavyId
                                }).FirstOrDefault();

                                if (coveragesNavy != null)
                                {
                                    var CoverageSNavy = ObjServices.oNavyManager.GetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = ObjServices.Corp_Id,
                                        RegionId = ObjServices.Region_Id,
                                        CountryId = ObjServices.Country_Id,
                                        UniqueNavyId = (int)item.UniqueNavyId,
                                        BlTypeId = coveragesNavy.BlTypeId.GetValueOrDefault(),
                                        BlId = coveragesNavy.BlId.GetValueOrDefault(),
                                        ProductId = coveragesNavy.ProductId.GetValueOrDefault(),
                                        VehicleTypeId = coveragesNavy.VehicleTypeId.GetValueOrDefault(),
                                        GroupId = coveragesNavy.GroupId.GetValueOrDefault(),
                                        CoverageTypeId = coveragesNavy.CoverageTypeId.GetValueOrDefault(),
                                        CoverageId = coveragesNavy.CoverageId.GetValueOrDefault(),
                                        SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                        DiscountRuleId = null,
                                        DiscountRuleDetailId = null,
                                        LanguageId = ObjServices.Language.ToInt()
                                    }).Select(s =>
                                    {
                                        decimal recargo = s.OldCoverageAmount * (s.DetailRuleValue.ToDecimal(0, true));
                                        s.TipoRecargo = s.NotePredefiniedDesc;
                                        s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                        s.Recargo = recargo;
                                        s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                        return s;
                                    }).ToList();

                                    if (CoverageSNavy != null)
                                        foreach (var _item in CoverageSNavy)
                                            CoverageSurchargesNavy.Add(_item);
                                }
                            }
                        }

                        sumaTodosRecargos = CoverageSurchargesNavy.Sum(v => v.Recargo);
                        lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                        mtMasterAllSurcharges.SetActiveView(vAllSurchargesNavy);
                        gvAllSurchargesNavy.DataSource = CoverageSurchargesNavy;
                        gvAllSurchargesNavy.DataBind();
                        break;
                    #endregion
                    #region Property
                    case Utility.AlliedLinesType.Property:
                        var CoverageSurchargesProperty = new List<Property.Insured.Coverage.Surcharge>(0);

                        var dataProperty = ObjServices.GetDataProperty().ToList();

                        if (dataProperty.Count > 0)
                        {
                            foreach (var item in dataProperty)
                            {
                                var coveragesProperty = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                                {
                                    corpId = ObjServices.Corp_Id,
                                    uniquePropertyId = item.UniquePropertyId
                                }).FirstOrDefault();

                                if (coveragesProperty != null)
                                {
                                    var CoverageSProperty = ObjServices.oPropertyManager.GetPropertyInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge.Key
                                    {
                                        corpId = ObjServices.Corp_Id,
                                        regionId = ObjServices.Region_Id,
                                        countryId = ObjServices.Country_Id,
                                        uniquePropertyId = item.UniquePropertyId,
                                        blTypeId = coveragesProperty.BlTypeId,
                                        blId = coveragesProperty.BlId,
                                        productId = coveragesProperty.ProductId,
                                        vehicleTypeId = coveragesProperty.VehicleTypeId,
                                        groupId = coveragesProperty.GroupId,
                                        coverageTypeId = coveragesProperty.CoverageTypeId,
                                        coverageId = coveragesProperty.CoverageId,
                                        surchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).Select(s =>
                                    {
                                        decimal recargo = s.OldCoverageAmount * (s.DetailRuleValue.ToDecimal(0, true));
                                        s.TipoRecargo = s.NotePredefiniedDesc;
                                        s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                        s.Recargo = recargo;
                                        s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                        return s;
                                    }).ToList();

                                    if (CoverageSProperty != null)
                                        foreach (var _item in CoverageSProperty)
                                            CoverageSurchargesProperty.Add(_item);
                                }
                            }
                        }

                        sumaTodosRecargos = CoverageSurchargesProperty.Sum(v => v.Recargo);
                        lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                        mtMasterAllSurcharges.SetActiveView(vAllSurchargesProperty);
                        gvAllSurchargesProperty.DataSource = CoverageSurchargesProperty;
                        gvAllSurchargesProperty.DataBind();
                        break;
                    #endregion
                    #region Transport
                    case Utility.AlliedLinesType.Transport:
                        var CoverageSurchargesTransport = new List<Transport.Insured.Coverage.Surcharge>(0);

                        var dataTransport = ObjServices.GetDataTransport().ToList();

                        if (dataTransport.Count > 0)
                        {
                            foreach (var item in dataTransport)
                            {
                                var coveragesTransport = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                                {
                                    corpId = ObjServices.Corp_Id,
                                    uniquePropertyId = (int)item.UniqueTransportId
                                }).FirstOrDefault();

                                if (coveragesTransport != null)
                                {
                                    var CoverageSTransport = ObjServices.oTransportManager.GetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge.Key
                                    {
                                        CorpId = ObjServices.Corp_Id,
                                        RegionId = ObjServices.Region_Id,
                                        CountryId = ObjServices.Country_Id,
                                        UniqueTransportId = (int)item.UniqueTransportId,
                                        BlTypeId = coveragesTransport.BlTypeId,
                                        BlId = coveragesTransport.BlId,
                                        ProductId = coveragesTransport.ProductId,
                                        VehicleTypeId = coveragesTransport.VehicleTypeId,
                                        GroupId = coveragesTransport.GroupId,
                                        CoverageTypeId = coveragesTransport.CoverageTypeId,
                                        CoverageId = coveragesTransport.CoverageId,
                                        SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                        discountRuleId = null,
                                        discountRuleDetailId = null,
                                        languageId = ObjServices.Language.ToInt()
                                    }).Select(s =>
                                    {
                                        decimal recargo = s.OldCoverageAmount * (s.DetailRuleValue.ToDecimal(0, true));
                                        s.TipoRecargo = s.NotePredefiniedDesc;
                                        s.PorcentajeRecargo = string.Format("{0} %", (s.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                                        s.Recargo = recargo;
                                        s.RecargoF = recargo.ToString("$#,0.00", CultureInfo.InvariantCulture);
                                        return s;
                                    }).ToList();

                                    if (CoverageSTransport != null)
                                        foreach (var _item in CoverageSTransport)
                                            CoverageSurchargesTransport.Add(_item);
                                }
                            }
                        }

                        sumaTodosRecargos = CoverageSurchargesTransport.Sum(v => v.Recargo);
                        lblTotalAllSurcharges.Text = sumaTodosRecargos.ToString("$#,0.00", CultureInfo.InvariantCulture);
                        mtMasterAllSurcharges.SetActiveView(vAllSurchargesTransport);
                        gvAllSurchargesTransport.DataSource = CoverageSurchargesTransport;
                        gvAllSurchargesTransport.DataBind();

                        break;
                    #endregion
                }
            }
            this.ExcecuteJScript("setTimeout(\"OpenAllSurcharges()\",10);");
        }

        protected void btnVerRecargos_Click(object sender, EventArgs e)
        {
            SeeAllSurcharges();
        }

        private void BindGridRecargos(Policy.VehicleCoverage coverage)
        {
            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                VehicleCoverageSurcharge = ObjServices.oPolicyManager.GetVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    VehicleUniqueId = UniqueId,
                    BlTypeId = coverage.BlTypeId,
                    BlId = coverage.BlId,
                    ProductId = coverage.ProductId,
                    VehicleTypeId = coverage.VehicleTypeId,
                    GroupId = coverage.GroupId,
                    CoverageTypeId = coverage.CoverageTypeId,
                    CoverageId = coverage.CoverageId,
                    SurchargeId = SurchargeId,
                    DiscountRuleId = null,
                    DiscountRuleDetailId = null,
                    Language = ObjServices.Language.ToInt()
                }).Select(v =>
                {
                    decimal recargo = v.OldCoverageAmount.Value * (v.DetailRuleValue.ToDecimal(0, true)),
                            monto_recargo = (v.OldCoverageAmount.Value + recargo);

                    v.TipoRecargo = v.NotePredefiniedDesc;
                    v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                    v.Recargo = recargo;
                    v.MontoRecargo = monto_recargo;
                    v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                    v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                    return v;
                });


                Session["VehicleCoverageSurcharge"] = VehicleCoverageSurcharge;

                gvRecargos.DataSource = VehicleCoverageSurcharge;
            }
            else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
            {
                switch (ObjServices.AlliedLinesProductBehavior)
                {
                    case Utility.AlliedLinesType.Airplane:

                        var AirplaneCoverage = ObjServices.oAirPlaneManager.GetAirPlaneInsuredCoverage(new Airplane.Insured.Coverage.Key
                           {
                               CorpId = ObjServices.Corp_Id,
                               UniqueAirplaneId = (int)UniqueId
                           });

                        if (AirplaneCoverage != null && AirplaneCoverage.Any())
                        {
                            var item = AirplaneCoverage.FirstOrDefault();
                            this.BlTypeId = item.BlTypeId;
                            this.BlId = item.BlId;
                            this.ProductId = item.ProductId;
                            this.GroupId = item.GroupId;
                            this.CoverageTypeIdAlliedLines = item.CoverageTypeId;
                            this.CoverageId = item.CoverageId;
                        }
                        else
                        {
                            this.MessageBox("Este elemento no tiene coberturas");
                            gvRecargos.DataSource = null;
                            gvRecargos.DataBind();
                            return;
                        }

                        var AirplaneCoverageSurcharge = ObjServices.oAirPlaneManager.GetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge.Key
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            UniqueAirplaneId = UniqueId,
                            BlTypeId = this.BlTypeId,
                            BlId = this.BlId,
                            ProductId = this.ProductId,
                            VehicleTypeId = 1,
                            GroupId = this.GroupId,
                            CoverageTypeId = this.CoverageTypeIdAlliedLines,
                            CoverageId = this.CoverageId,
                            SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                            discountRuleId = null,
                            discountRuleDetailId = null,
                            languageId = ObjServices.Language.ToInt()
                        }).Select(v =>
                        {
                            decimal recargo = v.OldCoverageAmount * (v.DetailRuleValue.ToDecimal(0, true)),
                                    monto_recargo = (v.OldCoverageAmount + recargo);

                            v.TipoRecargo = v.NotePredefiniedDesc;
                            v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                            v.Recargo = recargo;
                            v.MontoRecargo = monto_recargo;
                            v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            return v;
                        });

                        decimal sRecargosAirplane = AirplaneCoverageSurcharge.Sum(v => v.Recargo);
                        lblTotalSurcharges.Text = (sRecargosAirplane > 0 ? sRecargosAirplane : 0m).ToFormatCurrency();
                        gvRecargos.DataSource = AirplaneCoverageSurcharge;
                        break;
                    case Utility.AlliedLinesType.Bail:
                        var BailCoverage = ObjServices.oBailManager.GetBailInsuredCoverage(new Bail.Insured.Coverage.Key
                           {
                               CorpId = ObjServices.Corp_Id,
                               UniqueBailId = (int)UniqueId
                           });

                        if (BailCoverage != null && BailCoverage.Any())
                        {
                            var item = BailCoverage.FirstOrDefault();
                            this.BlTypeId = item.BlTypeId.GetValueOrDefault();
                            this.BlId = item.BlId.GetValueOrDefault();
                            this.ProductId = item.ProductId.GetValueOrDefault();
                            this.GroupId = item.GroupId.GetValueOrDefault();
                            this.CoverageTypeIdAlliedLines = item.CoverageTypeId.GetValueOrDefault();
                            this.CoverageId = item.CoverageId.GetValueOrDefault();
                        }
                        else
                        {
                            this.MessageBox("Este elemento no tiene coberturas");
                            gvRecargos.DataSource = null;
                            gvRecargos.DataBind();
                            return;
                        }
                        var BailCoverageSurcharge = ObjServices.oBailManager.GetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge.Key
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            UniqueBailId = UniqueId,
                            BlTypeId = this.BlTypeId,
                            BlId = this.BlId,
                            ProductId = this.ProductId,
                            VehicleTypeId = 1,
                            GroupId = this.GroupId,
                            CoverageTypeId = this.CoverageTypeIdAlliedLines,
                            CoverageId = this.CoverageId,
                            SurchargeId = SurchargeId.HasValue ? SurchargeId.GetValueOrDefault() : (int?)null,
                            discountRuleId = null,
                            discountRuleDetailId = null,
                            languageId = ObjServices.Language.ToInt()
                        }).Select(v =>
                        {
                            decimal recargo = v.OldCoverageAmount * (v.DetailRuleValue.ToDecimal(0, true)),
                                    monto_recargo = (v.OldCoverageAmount + recargo);

                            v.TipoRecargo = v.NotePredefiniedDesc;
                            v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                            v.Recargo = recargo;
                            v.MontoRecargo = monto_recargo;
                            v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            return v;
                        });

                        decimal sRecargosBail = BailCoverageSurcharge.Sum(v => v.Recargo);
                        lblTotalSurcharges.Text = (sRecargosBail > 0 ? sRecargosBail : 0m).ToFormatCurrency();
                        gvRecargos.DataSource = BailCoverageSurcharge;
                        break;
                    case Utility.AlliedLinesType.Navy:
                        var NavyCoverage = ObjServices.oNavyManager.GetNavyInsuredCoverage(new Navy.Insured.Coverage.Key
                           {
                               CorpId = ObjServices.Corp_Id,
                               UniqueNavyId = (int)UniqueId
                           });

                        if (NavyCoverage != null && NavyCoverage.Any())
                        {
                            var item = NavyCoverage.FirstOrDefault();
                            this.BlTypeId = item.BlTypeId.GetValueOrDefault();
                            this.BlId = item.BlId.GetValueOrDefault();
                            this.ProductId = item.ProductId.GetValueOrDefault();
                            this.GroupId = item.GroupId.GetValueOrDefault();
                            this.CoverageTypeIdAlliedLines = item.CoverageTypeId.GetValueOrDefault();
                            this.CoverageId = item.CoverageId.GetValueOrDefault();
                        }
                        else
                        {
                            this.MessageBox("Este elemento no tiene coberturas");
                            gvRecargos.DataSource = null;
                            gvRecargos.DataBind();
                            return;
                        }
                        var NavyCoverageSurcharge = ObjServices.oNavyManager.GetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge.Key
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            UniqueNavyId = UniqueId,
                            BlTypeId = this.BlTypeId,
                            BlId = this.BlId,
                            ProductId = this.ProductId,
                            VehicleTypeId = 1,
                            GroupId = this.GroupId,
                            CoverageTypeId = this.CoverageTypeIdAlliedLines,
                            CoverageId = this.CoverageId,
                            SurchargeId = SurchargeId.HasValue ? SurchargeId.GetValueOrDefault() : (int?)null,
                            DiscountRuleId = null,
                            DiscountRuleDetailId = null,
                            LanguageId = ObjServices.Language.ToInt()
                        }).Select(v =>
                        {
                            decimal recargo = v.OldCoverageAmount * (v.DetailRuleValue.ToDecimal(0, true)),
                                    monto_recargo = (v.OldCoverageAmount + recargo);

                            v.TipoRecargo = v.NotePredefiniedDesc;
                            v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                            v.Recargo = recargo;
                            v.MontoRecargo = monto_recargo;
                            v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            return v;
                        });
                        decimal sRecargosNavy = NavyCoverageSurcharge.Sum(v => v.Recargo);
                        lblTotalSurcharges.Text = (sRecargosNavy > 0 ? sRecargosNavy : 0m).ToFormatCurrency();
                        gvRecargos.DataSource = NavyCoverageSurcharge;
                        break;
                    case Utility.AlliedLinesType.Property:

                        var PropertyCoverage = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                        {
                            corpId = ObjServices.Corp_Id,
                            uniquePropertyId = (int)UniqueId

                        });

                        if (PropertyCoverage != null && PropertyCoverage.Any())
                        {
                            var item = PropertyCoverage.FirstOrDefault();
                            this.BlTypeId = item.BlTypeId;
                            this.BlId = item.BlId;
                            this.ProductId = item.ProductId;
                            this.GroupId = item.GroupId;
                            this.CoverageTypeIdAlliedLines = item.CoverageTypeId;
                            this.CoverageId = item.CoverageId;
                        }
                        else
                        {
                            this.MessageBox("Este elemento no tiene coberturas");
                            gvRecargos.DataSource = null;
                            gvRecargos.DataBind();
                            return;
                        }

                        var PropertyCoverageSurcharge = ObjServices.oPropertyManager.GetPropertyInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge.Key
                        {
                            corpId = ObjServices.Corp_Id,
                            regionId = ObjServices.Region_Id,
                            countryId = ObjServices.Country_Id,
                            uniquePropertyId = UniqueId,
                            blTypeId = this.BlTypeId,
                            blId = this.BlId,
                            productId = this.ProductId,
                            vehicleTypeId = 1,
                            groupId = this.GroupId,
                            coverageTypeId = this.CoverageTypeIdAlliedLines,
                            coverageId = this.CoverageId,
                            surchargeId = SurchargeId.HasValue ? SurchargeId.GetValueOrDefault() : (int?)null,
                            discountRuleId = null,
                            discountRuleDetailId = null,
                            languageId = ObjServices.Language.ToInt()
                        }).Select(v =>
                        {
                            decimal recargo = v.OldCoverageAmount * (v.DetailRuleValue.ToDecimal(0, true)),
                                    monto_recargo = (v.OldCoverageAmount + recargo);

                            v.TipoRecargo = v.NotePredefiniedDesc;
                            v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                            v.Recargo = recargo;
                            v.MontoRecargo = monto_recargo;
                            v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            return v;
                        });

                        decimal sRecargosProperty = PropertyCoverageSurcharge.Sum(v => v.Recargo);
                        lblTotalSurcharges.Text = (sRecargosProperty > 0 ? sRecargosProperty : 0m).ToFormatCurrency();
                        gvRecargos.DataSource = PropertyCoverageSurcharge;
                        break;
                    case Utility.AlliedLinesType.Transport:
                        var TransportCoverage = ObjServices.oTransportManager.GetTransportInsuredCoverage(new Transport.Insured.Coverage.Key
                        {
                            CorpId = ObjServices.Corp_Id,
                            UniqueTransportId = (int)UniqueId
                        });

                        if (TransportCoverage != null && TransportCoverage.Any())
                        {
                            var item = TransportCoverage.FirstOrDefault();
                            this.BlTypeId = item.BlTypeId.GetValueOrDefault();
                            this.BlId = item.BlId.GetValueOrDefault();
                            this.ProductId = item.ProductId.GetValueOrDefault();
                            this.GroupId = item.GroupId.GetValueOrDefault();
                            this.CoverageTypeIdAlliedLines = item.CoverageTypeId.GetValueOrDefault();
                            this.CoverageId = item.CoverageId.GetValueOrDefault();
                        }
                        else
                        {
                            this.MessageBox("Este elemento no tiene coberturas");
                            gvRecargos.DataSource = null;
                            gvRecargos.DataBind();
                            return;
                        }

                        var TransportCoverageSurcharge = ObjServices.oTransportManager.GetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge.Key
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            UniqueTransportId = UniqueId,
                            BlTypeId = this.BlTypeId,
                            BlId = this.BlId,
                            ProductId = this.ProductId,
                            VehicleTypeId = 1,
                            GroupId = this.GroupId,
                            CoverageTypeId = this.CoverageTypeIdAlliedLines,
                            CoverageId = this.CoverageId,
                            SurchargeId = SurchargeId.HasValue ? SurchargeId.GetValueOrDefault() : (int?)null,
                            discountRuleId = null,
                            discountRuleDetailId = null,
                            languageId = ObjServices.Language.ToInt()
                        }).Select(v =>
                        {
                            decimal recargo = v.OldCoverageAmount * (v.DetailRuleValue.ToDecimal(0, true)),
                                    monto_recargo = (v.OldCoverageAmount + recargo);

                            v.TipoRecargo = v.NotePredefiniedDesc;
                            v.PorcentajeRecargo = string.Format("{0} %", (v.DetailRuleValue.ToDecimal(0, true) * 100).ToString(CultureInfo.InvariantCulture));
                            v.Recargo = recargo;
                            v.MontoRecargo = monto_recargo;
                            v.RecargoF = recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            v.MontoRecargoF = monto_recargo.ToString("#,0.00", CultureInfo.InvariantCulture);
                            return v;
                        });
                        decimal sRecargosTransport = TransportCoverageSurcharge.Sum(v => v.Recargo);
                        lblTotalSurcharges.Text = (sRecargosTransport > 0 ? sRecargosTransport : 0m).ToFormatCurrency();
                        gvRecargos.DataSource = TransportCoverageSurcharge;
                        break;
                }
            }

            gvRecargos.DataBind();
            gvRecargos.FocusedRowIndex = -1;
        }

        protected void gvRecargos_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            SurchargeId = gvRecargos.GetKeyFromAspxGridView("SurchargeId", e.VisibleIndex).ToInt();
            ViewState["SurchargeId"] = SurchargeId;
            
            ViewState["edit"] = false;

            var command = e.CommandArgs.CommandName;
            switch (command)
            {
                case "Edit":
                    ViewState["edit"] = true;
                    #region Auto
                    if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                    {
                        if (VehicleCoverageSurcharge == null && Session["VehicleCoverageSurcharge"] != null)
                            VehicleCoverageSurcharge = Session["VehicleCoverageSurcharge"] as IEnumerable<Policy.VehicleCoverageSurcharge>;

                        if (VehicleCoverageSurcharge != null)
                        {
                            var surcharge = VehicleCoverageSurcharge.FirstOrDefault(v => v.SurchargeId == SurchargeId && v.VehicleUniqueId == UniqueId);

                            txtCalculoRecargo.Text = surcharge.RecargoF;

                            for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                            {
                                if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                {
                                    string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                    if (DiscountRuleValue == surcharge.DetailRuleValue)
                                    {
                                        ddlPorcentajeRecargo.SelectedIndex = i;
                                        break;
                                    }
                                }
                            }

                            ddlTipoRecargo.SelectedValue = surcharge.NotePredefiniedId.ToString();
                        }
                    }
                    #endregion
                    #region Incendio y lineas aliadas
                    else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                    {
                        switch (ObjServices.AlliedLinesProductBehavior)
                        {
                            case Utility.AlliedLinesType.Airplane:
                                var AirPlaneSurcharge = ObjServices.oAirPlaneManager.GetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge.Key
                                   {
                                       CorpId = ObjServices.Corp_Id,
                                       RegionId = ObjServices.Region_Id,
                                       CountryId = ObjServices.Country_Id,
                                       UniqueAirplaneId = UniqueId,
                                       BlTypeId = this.BlTypeId,
                                       BlId = this.BlId,
                                       ProductId = this.ProductId,
                                       VehicleTypeId = 1,
                                       GroupId = this.GroupId,
                                       CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                       CoverageId = this.CoverageId,
                                       SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                       discountRuleId = null,
                                       discountRuleDetailId = null,
                                       languageId = ObjServices.Language.ToInt()
                                   }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueAirplaneId == UniqueId);

                                for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                                {
                                    if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                    {
                                        string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                        if (DiscountRuleValue == AirPlaneSurcharge.DetailRuleValue)
                                        {
                                            ddlPorcentajeRecargo.SelectedIndex = i;
                                            
                                            break;
                                        }
                                    }
                                }

                                txtCalculoRecargo.Text = (AirPlaneSurcharge.DetailRuleValue.ToDecimal() * AirPlaneSurcharge.OldCoverageAmount).ToFormatCurrency();
                                ddlTipoRecargo.SelectedValue = AirPlaneSurcharge.NotePredefiniedId.ToString();
                                break;
                            case Utility.AlliedLinesType.Bail:
                                var BailSurcharge = ObjServices.oBailManager.GetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge.Key
                                   {
                                       CorpId = ObjServices.Corp_Id,
                                       RegionId = ObjServices.Region_Id,
                                       CountryId = ObjServices.Country_Id,
                                       UniqueBailId = UniqueId,
                                       BlTypeId = this.BlTypeId,
                                       BlId = this.BlId,
                                       ProductId = this.ProductId,
                                       VehicleTypeId = 1,
                                       GroupId = this.GroupId,
                                       CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                       CoverageId = this.CoverageId,
                                       SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                       discountRuleId = null,
                                       discountRuleDetailId = null,
                                       languageId = ObjServices.Language.ToInt()
                                   }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueBailId == UniqueId);

                                for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                                {
                                    if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                    {
                                        string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                        if (DiscountRuleValue == BailSurcharge.DetailRuleValue)
                                        {
                                            ddlPorcentajeRecargo.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                }

                                txtCalculoRecargo.Text = (BailSurcharge.DetailRuleValue.ToDecimal() * BailSurcharge.OldCoverageAmount).ToFormatCurrency();
                                ddlTipoRecargo.SelectedValue = BailSurcharge.NotePredefiniedId.ToString();
                                break;
                            case Utility.AlliedLinesType.Navy:
                                var NavySurcharge = ObjServices.oNavyManager.GetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge.Key
                                   {
                                       CorpId = ObjServices.Corp_Id,
                                       RegionId = ObjServices.Region_Id,
                                       CountryId = ObjServices.Country_Id,
                                       UniqueNavyId = UniqueId,
                                       BlTypeId = this.BlTypeId,
                                       BlId = this.BlId,
                                       ProductId = this.ProductId,
                                       VehicleTypeId = 1,
                                       GroupId = this.GroupId,
                                       CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                       CoverageId = this.CoverageId,
                                       SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                       DiscountRuleId = null,
                                       DiscountRuleDetailId = null,
                                       LanguageId = ObjServices.Language.ToInt()
                                   }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueNavyId == UniqueId);

                                for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                                {
                                    if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                    {
                                        string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                        if (DiscountRuleValue == NavySurcharge.DetailRuleValue)
                                        {
                                            ddlPorcentajeRecargo.SelectedIndex = i;
                                            
                                            break;
                                        }
                                    }
                                }

                                txtCalculoRecargo.Text = (NavySurcharge.DetailRuleValue.ToDecimal() * NavySurcharge.OldCoverageAmount).ToFormatCurrency();
                                ddlTipoRecargo.SelectedValue = NavySurcharge.NotePredefiniedId.ToString();
                                break;
                            case Utility.AlliedLinesType.Property:
                                var PropertySurcharge = ObjServices.oPropertyManager.GetPropertyInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge.Key
                                   {
                                       corpId = ObjServices.Corp_Id,
                                       regionId = ObjServices.Region_Id,
                                       countryId = ObjServices.Country_Id,
                                       uniquePropertyId = UniqueId,
                                       blTypeId = this.BlTypeId,
                                       blId = this.BlId,
                                       productId = this.ProductId,
                                       vehicleTypeId = 1,
                                       groupId = this.GroupId,
                                       coverageTypeId = this.CoverageTypeIdAlliedLines,
                                       coverageId = this.CoverageId,
                                       surchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                       discountRuleId = null,
                                       discountRuleDetailId = null,
                                       languageId = ObjServices.Language.ToInt()
                                   }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniquePropertyId == UniqueId);

                                for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                                {
                                    if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                    {
                                        string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                        if (DiscountRuleValue == PropertySurcharge.DetailRuleValue)
                                        {
                                            ddlPorcentajeRecargo.SelectedIndex = i;
                                            
                                            break;
                                        }
                                    }
                                }
                                //DetailRuleID * OldCoverageAmount
                                txtCalculoRecargo.Text = (PropertySurcharge.DetailRuleValue.ToDecimal() * PropertySurcharge.OldCoverageAmount).ToFormatCurrency();
                                ddlTipoRecargo.SelectedValue = PropertySurcharge.NotePredefiniedId.ToString();
                                break;
                            case Utility.AlliedLinesType.Transport:
                                var TransportSurcharge = ObjServices.oTransportManager.GetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge.Key
                                   {
                                       CorpId = ObjServices.Corp_Id,
                                       RegionId = ObjServices.Region_Id,
                                       CountryId = ObjServices.Country_Id,
                                       UniqueTransportId = UniqueId,
                                       BlTypeId = this.BlTypeId,
                                       BlId = this.BlId,
                                       ProductId = this.ProductId,
                                       VehicleTypeId = 1,
                                       GroupId = this.GroupId,
                                       CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                       CoverageId = this.CoverageId,
                                       SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                       discountRuleId = null,
                                       discountRuleDetailId = null,
                                       languageId = ObjServices.Language.ToInt()
                                   }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.uniqueTransportId == UniqueId);

                                for (int i = 0; i < ddlPorcentajeRecargo.Items.Count; i++)
                                {
                                    if (ddlPorcentajeRecargo.Items[i].Value != "0")
                                    {
                                        string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.Items[i].Value).DiscountRuleValue;
                                        if (DiscountRuleValue == TransportSurcharge.DetailRuleValue)
                                        {
                                            ddlPorcentajeRecargo.SelectedIndex = i;
                                            
                                            break;
                                        }
                                    }
                                }
                                
                                txtCalculoRecargo.Text = (TransportSurcharge.DetailRuleValue.ToDecimal() * TransportSurcharge.OldCoverageAmount).ToFormatCurrency();
                                ddlTipoRecargo.SelectedValue = TransportSurcharge.NotePredefiniedId.ToString();
                                break;
                        }
                    }
                    #endregion
                    ddlTipoRecargo.Enabled = true;
                    ddlPorcentajeRecargo.Enabled = true;
                    btnApplySurcharge.Enabled = true;
                    Session["VehicleCoverageSurcharge"] = null;
                    break;
                case "Delete":
                    #region Auto
                    if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                    {
                        //eliminar y aplicar cargos/descuentos en base de datos con el objeto [surcharge]
                        var coverage = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                        {
                            CorpId = ObjServices.Corp_Id,
                            CoverageTypeId = CoverageTypeId,
                            VehicleUniqueId = UniqueId

                        }).FirstOrDefault();

                        //Actualizar Status Recargo
                        var update_surcharge = ObjServices.oPolicyManager.UpdateVehicleCoverageSurcharge(new Policy.VehicleCoverageSurcharge
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            VehicleUniqueId = UniqueId,
                            BlTypeId = coverage.BlTypeId,
                            BlId = coverage.BlId,
                            ProductId = coverage.ProductId,
                            VehicleTypeId = coverage.VehicleTypeId,
                            GroupId = coverage.GroupId,
                            CoverageTypeId = CoverageTypeId,
                            CoverageId = coverage.CoverageId,
                            SurchargeId = SurchargeId,
                            UserId = ObjServices.UserID.GetValueOrDefault()
                        });

                        //reaplicar descuentos y recargos
                        var apply_discount_surcharge = ObjServices.oPolicyManager.SetVehicleInsuredApplyDiscountAndSurcharge(new Policy.Parameter
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
                            UserId = ObjServices.UserID
                        });

                        //Actualizar Flat Table
                        ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());

                        var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;

                        if (IllustrationsVehiclePage != null)
                        {
                            IllustrationsVehiclePage.FillVehiclesInformation();

                            var IllustrationInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCIllustrationInformation);
                            if (IllustrationInformationUC != null)
                            {
                                (IllustrationInformationUC as UCIllustrationInformation).FillData();
                            }
                        }

                        SurchargeId = null;
                        ViewState["SurchargeId"] = null;

                        FillData();

                        SelectedRow();

                        if (VehicleCoverageSurcharge.ToList().Count == 0)
                        {
                            lblTotalOwnDamagesWithSurcharges.Text = "$0.00";
                            lblTotalSurcharges.Text = "$0.00";
                            lblTotalAllSurcharges.Text = "$0.00";
                        }
                    }
                    #endregion
                    #region Incendio y lineas aliadas
                    else if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
                    {
                        switch (ObjServices.AlliedLinesProductBehavior)
                        {
                            case Utility.AlliedLinesType.Airplane:
                                var AirPlaneSurcharge = ObjServices.oAirPlaneManager.GetAirplaneCoverageSurcharge(new Airplane.Insured.Coverage.Surcharge.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    UniqueAirplaneId = UniqueId,
                                    BlTypeId = this.BlTypeId,
                                    BlId = this.BlId,
                                    ProductId = this.ProductId,
                                    VehicleTypeId = 1,
                                    GroupId = this.GroupId,
                                    CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                    CoverageId = this.CoverageId,
                                    SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                    discountRuleId = null,
                                    discountRuleDetailId = null,
                                    languageId = ObjServices.Language.ToInt()
                                }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueAirplaneId == UniqueId);

                                AirPlaneSurcharge.SurchargeStatus = false;
                                ObjServices.oAirPlaneManager.SetAirplaneCoverageSurcharge(AirPlaneSurcharge);

                                ObjServices.oAirPlaneManager.SetAirplaneApplyDiscountAndSurcharge(new Airplane.Insured
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    DomesticRegId = ObjServices.Domesticreg_Id,
                                    StateProvId = ObjServices.State_Prov_Id,
                                    CityId = ObjServices.City_Id,
                                    OfficeId = ObjServices.Office_Id,
                                    CaseSeqNo = ObjServices.Case_Seq_No,
                                    HistSeqNo = ObjServices.Hist_Seq_No,
                                    UserId = ObjServices.UserID.GetValueOrDefault()
                                });
                                break;
                            case Utility.AlliedLinesType.Bail:
                                var BailSurcharge = ObjServices.oBailManager.GetBailInsuredCoverageSurcharge(new Bail.Insured.Coverage.Surcharge.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    UniqueBailId = UniqueId,
                                    BlTypeId = this.BlTypeId,
                                    BlId = this.BlId,
                                    ProductId = this.ProductId,
                                    VehicleTypeId = 1,
                                    GroupId = this.GroupId,
                                    CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                    CoverageId = this.CoverageId,
                                    SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                    discountRuleId = null,
                                    discountRuleDetailId = null,
                                    languageId = ObjServices.Language.ToInt()
                                }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueBailId == UniqueId);

                                BailSurcharge.SurchargeStatus = false;
                                ObjServices.oBailManager.SetBailInsuredCoverageSurcharge(BailSurcharge);

                                ObjServices.oBailManager.SetBailInsuredApplyDiscountAndSurcharge(new Bail.Insured
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
                                    UsrId = ObjServices.UserID.GetValueOrDefault()
                                });
                                break;
                            case Utility.AlliedLinesType.Navy:
                                var NavySurcharge = ObjServices.oNavyManager.GetNavyInsuredCoverageSurcharge(new Navy.Insured.Coverage.Surcharge.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    UniqueNavyId = UniqueId,
                                    BlTypeId = this.BlTypeId,
                                    BlId = this.BlId,
                                    ProductId = this.ProductId,
                                    VehicleTypeId = 1,
                                    GroupId = this.GroupId,
                                    CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                    CoverageId = this.CoverageId,
                                    SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                    DiscountRuleId = null,
                                    DiscountRuleDetailId = null,
                                    LanguageId = ObjServices.Language.ToInt()
                                }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniqueNavyId == UniqueId);

                                NavySurcharge.SurchargeStatus = false;
                                ObjServices.oNavyManager.SetNavyInsuredCoverageSurcharge(NavySurcharge);

                                ObjServices.oNavyManager.SetNavyInsuredApplyDiscountAndSurcharge(new Navy.Insured
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    DomesticRegId = ObjServices.Domesticreg_Id,
                                    StateProvId = ObjServices.State_Prov_Id,
                                    CityId = ObjServices.City_Id,
                                    OfficeId = ObjServices.Office_Id,
                                    CaseSeqNo = ObjServices.Case_Seq_No,
                                    HistSeqNo = ObjServices.Hist_Seq_No,
                                    UserId = ObjServices.UserID.GetValueOrDefault()
                                });
                                break;
                            case Utility.AlliedLinesType.Property:
                                var PropertySurcharge = ObjServices.oPropertyManager.GetPropertyInsuredCoverageSurcharge(new Property.Insured.Coverage.Surcharge.Key
                                {
                                    corpId = ObjServices.Corp_Id,
                                    regionId = ObjServices.Region_Id,
                                    countryId = ObjServices.Country_Id,
                                    uniquePropertyId = UniqueId,
                                    blTypeId = this.BlTypeId,
                                    blId = this.BlId,
                                    productId = this.ProductId,
                                    vehicleTypeId = 1,
                                    groupId = this.GroupId,
                                    coverageTypeId = this.CoverageTypeIdAlliedLines,
                                    coverageId = this.CoverageId,
                                    surchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                    discountRuleId = null,
                                    discountRuleDetailId = null,
                                    languageId = ObjServices.Language.ToInt()
                                }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.UniquePropertyId == UniqueId);

                                PropertySurcharge.SurchargeStatus = false;
                                ObjServices.oPropertyManager.SetPropertytInsuredCoverageSurcharge(PropertySurcharge);

                                ObjServices.oPropertyManager.SetPropertyInsuredApplyDiscountAndSurcharge(new Property.Insured
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
                                    UserId = ObjServices.UserID.GetValueOrDefault()
                                });
                                break;
                            case Utility.AlliedLinesType.Transport:
                                var TransportSurcharge = ObjServices.oTransportManager.GetTransportInsuredCoverageSurcharge(new Transport.Insured.Coverage.Surcharge.Key
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    UniqueTransportId = UniqueId,
                                    BlTypeId = this.BlTypeId,
                                    BlId = this.BlId,
                                    ProductId = this.ProductId,
                                    VehicleTypeId = 1,
                                    GroupId = this.GroupId,
                                    CoverageTypeId = this.CoverageTypeIdAlliedLines,
                                    CoverageId = this.CoverageId,
                                    SurchargeId = SurchargeId.HasValue ? SurchargeId.Value : (int?)null,
                                    discountRuleId = null,
                                    discountRuleDetailId = null,
                                    languageId = ObjServices.Language.ToInt()
                                }).FirstOrDefault(v => v.SurchargeId == SurchargeId && v.uniqueTransportId == UniqueId);

                                TransportSurcharge.SurchargeStatus = false;
                                ObjServices.oTransportManager.SetTransportInsuredCoverageSurcharge(TransportSurcharge);

                                ObjServices.oTransportManager.SetTransportInsuredApplyDiscountAndSurcharge(new Transport.Insured
                                {
                                    CorpId = ObjServices.Corp_Id,
                                    RegionId = ObjServices.Region_Id,
                                    CountryId = ObjServices.Country_Id,
                                    DomesticRegId = ObjServices.Domesticreg_Id,
                                    StateProvId = ObjServices.State_Prov_Id,
                                    CityId = ObjServices.City_Id,
                                    OfficeId = ObjServices.Office_Id,
                                    CaseSeqNo = ObjServices.Case_Seq_No,
                                    HistSeqNo = ObjServices.Hist_Seq_No,
                                    UserId = ObjServices.UserID.GetValueOrDefault()
                                });
                                break;
                        }

                        //Actualizar Flat Table
                        ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());

                        var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;

                        if (IllustrationsVehiclePage != null)
                        {
                            switch (ObjServices.AlliedLinesProductBehavior)
                            {
                                case Utility.AlliedLinesType.Airplane:
                                    var UCAirPlane = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCAirPlane);
                                    if (UCAirPlane != null)
                                        (UCAirPlane as UCAirPlane).FillData();
                                    break;
                                case Utility.AlliedLinesType.Bail:
                                    var UCBail = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCBail);
                                    if (UCBail != null)
                                        (UCBail as UCBail).FillData();
                                    break;
                                case Utility.AlliedLinesType.Navy:
                                    var UCNavy = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCNavy);
                                    if (UCNavy != null)
                                        (UCNavy as UCNavy).FillData();
                                    break;
                                case Utility.AlliedLinesType.Property:
                                    var UCProperty = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCProperty);
                                    if (UCProperty != null)
                                        (UCProperty as UCProperty).FillData();
                                    break;
                                case Utility.AlliedLinesType.Transport:
                                    var UCTransport = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCTransport);
                                    if (UCTransport != null)
                                        (UCTransport as UCTransport).FillData();
                                    break;
                            }

                            var IllustrationInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCIllustrationInformation);
                            if (IllustrationInformationUC != null)
                            {
                                (IllustrationInformationUC as UCIllustrationInformation).FillData();
                            }
                        }

                        SurchargeId = null;
                        ViewState["SurchargeId"] = null;
                        FillData();
                        SelectedRow();
                    }
                    #endregion
                    txtCalculoRecargo.Text = "$0.00";
                    break;
            }
        }

        protected void gvProperty_BeforeHeaderFilterFillItems(object sender, ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {

        }

        protected void gvProperty_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                Grid.FocusedRowIndex = -1;
                Grid.SetFilterSettings();
            }
        }

        protected void gvAirplane_BeforeHeaderFilterFillItems(object sender, ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {

        }

        protected void gvAirplane_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                Grid.FocusedRowIndex = -1;
                Grid.SetFilterSettings();
            }
        }

        protected void gvNavy_BeforeHeaderFilterFillItems(object sender, ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {

        }

        protected void gvNavy_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                Grid.FocusedRowIndex = -1;
                Grid.SetFilterSettings();
            }
        }

        protected void gvBail_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {

        }

        protected void gvBail_BeforeHeaderFilterFillItems(object sender, ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {

        }

        protected void gvTransport_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                Grid.FocusedRowIndex = -1;
                Grid.SetFilterSettings();
            }
        }

        protected void gvTransport_BeforeHeaderFilterFillItems(object sender, ASPxGridViewBeforeHeaderFilterFillItemsEventArgs e)
        {

        }

        protected void gvVehiculos_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void ddlPorcentajeRecargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPorcentajeRecargo.SelectedValue != "0")
            {
                DiscountRule porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeRecargo.SelectedValue);
                
                decimal OwnDamage = ViewState["OwnDamage"].ToDecimal(),
                        calculo_porcentaje = OwnDamage * (porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true)),
                        OwnDamagesWithSurcharge = (OwnDamage + calculo_porcentaje);

                txtCalculoRecargo.Text = (OwnDamagesWithSurcharge - OwnDamage).ToFormatCurrency();
            }
            else
                txtCalculoRecargo.Text = "$0.00";
        }
    }
}