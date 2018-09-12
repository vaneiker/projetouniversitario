using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCSeeDiscount : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ClearData() { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void Translator(string Lang) { }
        public void Initialize()
        {
            FillData();
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

            decimal annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;


            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    #region Auto
                    var discounts = ObjServices.oPolicyManager.GetVehicleInsuredDiscount(new Entity.UnderWriting.Entities.Policy.VehicleInsured.Discount.Key
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
                        InsuredVehicleId = -1,
                        DiscountId = null,
                        LanguageId = ObjServices.Language.ToInt()
                    }).Select(v =>
                    {
                        v.TipoDescuento = v.NotePredefiniedDesc;

                        #region Porcentaje
                        if (v.DetailRuleNameKey != "N/A")
                        {
                            v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                            v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                            v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                            v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                        }
                        #endregion

                        #region Monto
                        if (v.DetailRuleNameKey == "N/A")
                        {
                            v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                            v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                            v.MontoDescuento = v.Descuento;
                            v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                        }
                        #endregion

                        v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                        return v;
                    }).Distinct();

                    gvRecargos.DataSource = discounts;
                    gvRecargos.DataBind();
                    gvRecargos.FocusedRowIndex = -1;
                    #endregion
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            #region AirPlane
                            var discountsAir = ObjServices.oAirPlaneManager.GetAirplaneInsuredDiscount(new Entity.UnderWriting.Entities.Airplane.Insured.Discount.Key
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
                                AirplaneId = -1,
                                DiscountId = null,
                                languageId = ObjServices.Language.ToInt()
                            }).Select(v =>
                            {
                                v.TipoDescuento = v.NotePredefiniedDesc;

                                #region Porcentaje
                                if (v.DetailRuleNameKey != "N/A")
                                {
                                    v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                                    v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                                    v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                                    v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                                }
                                #endregion

                                #region Monto
                                if (v.DetailRuleNameKey == "N/A")
                                {
                                    v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                                    v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                                    v.MontoDescuento = v.Descuento;
                                    v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                                }
                                #endregion

                                v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                                return v;
                            }).Distinct();

                            gvRecargos.DataSource = discountsAir;
                            gvRecargos.DataBind();
                            gvRecargos.FocusedRowIndex = -1;
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Bail:
                            #region Bail
                            var discountsBail = ObjServices.oBailManager.GetBailInsuredDiscount(new Entity.UnderWriting.Entities.Bail.Insured.Discount.Key
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
                                BailId = -1,
                                DiscountId = null,
                                LanguageId = ObjServices.Language.ToInt()
                            }).Select(v =>
                            {
                                v.TipoDescuento = v.NotePredefiniedDesc;

                                #region Porcentaje
                                if (v.DetailRuleNameKey != "N/A")
                                {
                                    v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                                    v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                                    v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                                    v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                                }
                                #endregion

                                #region Monto
                                if (v.DetailRuleNameKey == "N/A")
                                {
                                    v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                                    v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                                    v.MontoDescuento = v.Descuento;
                                    v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                                }
                                #endregion

                                v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                                return v;
                            }).Distinct();

                            gvRecargos.DataSource = discountsBail;
                            gvRecargos.DataBind();
                            gvRecargos.FocusedRowIndex = -1;
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Navy:
                            #region Navy
                            var discountsNavy = ObjServices.oNavyManager.GetNavyInsuredDiscount(new Entity.UnderWriting.Entities.Navy.Insured.Discount.Key
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
                                NavyId = -1,
                                DiscountId = null,
                                LanguageId = ObjServices.Language.ToInt()
                            }).Select(v =>
                            {
                                v.TipoDescuento = v.NotePredefiniedDesc;

                                #region Porcentaje
                                if (v.DetailRuleNameKey != "N/A")
                                {
                                    v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                                    v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                                    v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                                    v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                                }
                                #endregion

                                #region Monto
                                if (v.DetailRuleNameKey == "N/A")
                                {
                                    v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                                    v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                                    v.MontoDescuento = v.Descuento;
                                    v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                                }
                                #endregion

                                v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                                return v;
                            }).Distinct();

                            gvRecargos.DataSource = discountsNavy;
                            gvRecargos.DataBind();
                            gvRecargos.FocusedRowIndex = -1;
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Property:
                            #region Property
                            var discountsProperty = ObjServices.oPropertyManager.GetPropertyInsuredDiscount(new Entity.UnderWriting.Entities.Property.Insured.Discount.Key
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
                                 PropertyId = -1,
                                 DiscountId = null,
                                 languageId = ObjServices.Language.ToInt()
                             }).Select(v =>
                             {
                                 v.TipoDescuento = v.NotePredefiniedDesc;

                                 #region Porcentaje
                                 if (v.DetailRuleNameKey != "N/A")
                                 {
                                     v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                                     v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                                     v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                                     v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                                 }
                                 #endregion

                                 #region Monto
                                 if (v.DetailRuleNameKey == "N/A")
                                 {
                                     v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                                     v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                                     v.MontoDescuento = v.Descuento;
                                     v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                                 }
                                 #endregion

                                 v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                                 return v;
                             }).Distinct();

                            gvRecargos.DataSource = discountsProperty;
                            gvRecargos.DataBind();
                            gvRecargos.FocusedRowIndex = -1;
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Transport:
                            #region Trasnport
                            var discountsTransport = ObjServices.oTransportManager.GetTransportInsuredDiscount(new Entity.UnderWriting.Entities.Transport.Insured.Discount.Key
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
                                TransportId = -1,
                                DiscountId = null,
                                LanguageId = ObjServices.Language.ToInt()
                            }).Select(v =>
                            {
                                v.TipoDescuento = v.NotePredefiniedDesc;

                                #region Porcentaje
                                if (v.DetailRuleNameKey != "N/A")
                                {
                                    v.PorcentajeDescuento = string.Format("{0} %", Math.Round((v.DetailRuleValue.ToDecimal(0, true) * 100), 2).ToString(CultureInfo.InvariantCulture));
                                    v.Descuento = v.OldPremiumAmount - (v.OldPremiumAmount * v.DetailRuleValue.ToDecimal(0, true));
                                    v.MontoDescuento = v.OldPremiumAmount - v.Descuento;
                                    v.MontoDescuentoF = (v.OldPremiumAmount - v.Descuento).ToFormatNumeric();
                                }
                                #endregion

                                #region Monto
                                if (v.DetailRuleNameKey == "N/A")
                                {
                                    v.Descuento = v.OldPremiumAmount - v.PremiumAmount;
                                    v.PorcentajeDescuento = string.Format("{0} %", (Math.Round((v.Descuento / v.OldPremiumAmount) * 100, 2)).ToString(CultureInfo.InvariantCulture));
                                    v.MontoDescuento = v.Descuento;
                                    v.MontoDescuentoF = v.Descuento.ToFormatNumeric();
                                }
                                #endregion

                                v.VisibleButton = v.UserId != ObjServices.UserID ? false : true;

                                return v;
                            }).Distinct();

                            gvRecargos.DataSource = discountsTransport;
                            gvRecargos.DataBind();
                            gvRecargos.FocusedRowIndex = -1;
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Vehicle:
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
    }
}