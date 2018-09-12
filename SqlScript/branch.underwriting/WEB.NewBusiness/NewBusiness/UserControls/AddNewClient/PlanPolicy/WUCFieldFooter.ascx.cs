using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Configuration;

namespace WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy
{
    public partial class WUCFieldFooter : UC, IUC
    {
        public UpdatePanel oUdpDesignatedPensioner;
        public WUCDesignatedPensionerInformation oWUCDesignatedPensionerInformation;
        public PlanPolicyContainer oPlanPolicyContainer;
        WUCPlanInformation oWUCPlanInformation;
        public Button _btnSaveFooter
        {
            get { return btnSaveFooter; }
        }
        public View ver;


        public int CorpId;
        public int RegionId;
        public int CountryId;
        public int DomesticregId;
        public int StateProvId;
        public int CityId;
        public int OfficeId;
        public int CaseSeqNo;
        public int HistSeqNo;

        public decimal AnnualPre;

        public TextBox txtSelectiveTax;
        public TextBox txtAnnualPremiumWithTax;
        public TextBox txtTotalRetirementAmount;
        public TextBox txtAnnualPremium;
        public HiddenField hdAnnualPremium;
        public TextBox txtPeriodicPremium;
        public TextBox txtTargetAnnualPremium;
        public TextBox txtMinimumAnnualPremium;
        public TextBox txtProspectAgeStartRetirement;
        public TextBox txtBenefitAmount;
        public TextBox txtInsuredAmount;
        public TextBox txtReturnofPremium;

        public HtmlGenericControl TotalRetirementAmountLabel;
        public HtmlGenericControl AnnualPremiumLabel;
        public HtmlGenericControl PeriodicPremiumLabel;
        public HtmlGenericControl TargetPremiumLabel;
        public HtmlGenericControl ReturnOfPremiumLabel;
        public HtmlGenericControl SelectiveTaxLabel;
        public HtmlGenericControl AnnualPremiumWithTaxLabel;

        public UserControl Controles;
        //Bmarroquin 28-04-2017 Add Campo Monto Recargo por Fraccionamiento a solicitud de SSF
        public HtmlGenericControl lblRecargoFracLabel;
        public TextBox txtFraccionamiento;
        public TextBox txtPrimaAnualNeta;  //Bmarroquin 05-05-2017


        public void EnabledControls(bool x)
        {
            WUCFieldFooterAxys.EnableControls(x);
            WUCFieldFooterCompassIndex.EnableControls(x);
            WUCFieldFooterEduplan.EnableControls(x);
            WUCFieldFooterHorizon.EnableControls(x);
            WUCFieldFooterLegacy.EnableControls(x);
            WUCFieldFooterLighthouse.EnableControls(x);
            WUCFieldFooterScholar.EnableControls(x);
            WUCFieldFooterSentinel.EnableControls(x);
        }

        public void ChangeView(int index)
        {
            mtvFieldFooterProduct.ActiveViewIndex = index;
        }

        /// <summary>
        /// Metodo que setea la variable de prima
        /// </summary>
        /// <param name="valor"></param>
        public void setRurnPremium(decimal? pValueMountPremium)
        {
            try
            {
                txtReturnofPremium.Text = pValueMountPremium.ToFormatNumeric();
                Hidden1.Value = Convert.ToString(pValueMountPremium.ToFormatNumeric());
            }
            catch (Exception)
            {
                txtReturnofPremium.Text = "0.00";
            }
        }

        public void getControls()
        {
            var vView = mtvFieldFooterProduct.GetActiveView();
            ver = vView;

            if (vView == VHorizon)
                Controles = WUCFieldFooterHorizon;
            else
                if (vView == VAxys)
                    Controles = WUCFieldFooterAxys;
                else
                    if (vView == VEduplan)
                        Controles = WUCFieldFooterEduplan;
                    else
                        if (vView == VScholar)
                            Controles = WUCFieldFooterScholar;
                        else
                            if (vView == VCompassIndex)
                                Controles = WUCFieldFooterCompassIndex;
                            else
                                if (vView == VLegacy)
                                    Controles = WUCFieldFooterLegacy;
                                else
                                    if (vView == VSentinel)
                                        Controles = WUCFieldFooterSentinel;
                                    else
                                        if (vView == VLighthouse)
                                            Controles = WUCFieldFooterLighthouse;
                                        else
                                            if (vView == VElite)
                                                Controles = WUCFieldFooterElite;
                                            else
                                                if (vView == VSelect)
                                                    Controles = WUCFieldFooterSelect;
                                                else
                                                    if (vView == VFunerarios)
                                                        Controles = WUCFieldFooterFunerarios;
        }

        public void setControls()
        {
            getControls();

            if (ver != VEmpty)
            {
                /*Labels*/
                TotalRetirementAmountLabel = (HtmlGenericControl)Controles.FindControl("TotalRetirementAmount");
                AnnualPremiumLabel = (HtmlGenericControl)Controles.FindControl("AnnualPremium");
                PeriodicPremiumLabel = (HtmlGenericControl)Controles.FindControl("PeriodicPremium");
                TargetPremiumLabel = (HtmlGenericControl)Controles.FindControl("TargetAnnualPremium");
                ReturnOfPremiumLabel = (HtmlGenericControl)Controles.FindControl("ReturnofPremium");
                SelectiveTaxLabel = (HtmlGenericControl)Controles.FindControl("SelectiveTax");
                AnnualPremiumWithTaxLabel = (HtmlGenericControl)Controles.FindControl("AnnualPremiumWithTax");

                /* TextBox*/
                txtTotalRetirementAmount = (TextBox)Controles.FindControl("txtTotalRetirementAmount");
                txtAnnualPremium = (TextBox)Controles.FindControl("txtAnnualPremium");
                hdAnnualPremium = (HiddenField)Controles.FindControl("hdAnnualPremium");
                txtPeriodicPremium = (TextBox)Controles.FindControl("txtPeriodicPremium");
                txtTargetAnnualPremium = (TextBox)Controles.FindControl("txtTargetAnnualPremium");
                txtMinimumAnnualPremium = (TextBox)Controles.FindControl("txtMinimumAnnualPremium");
                txtProspectAgeStartRetirement = (TextBox)Controles.FindControl("txtProspectAgeStartRetirement");
                //txtReturnofPremium = (TextBox)Controles.FindControl("txtReturnofPremium"); //
                
                if ((TextBox)Controles.FindControl("txtReturnofPremium") != null)
                {
                    if (string.IsNullOrEmpty(((TextBox)Controles.FindControl("txtReturnofPremium")).Text) || ((TextBox)Controles.FindControl("txtReturnofPremium")).Text.Equals("0.00"))
                    {
                        if(!string.IsNullOrEmpty(Hidden1.Value) && !Hidden1.Value.Equals("0.00"))
                        {
                            ((TextBox)Controles.FindControl("txtReturnofPremium")).Text = Hidden1.Value;
                        }
                    }
                }

                txtReturnofPremium = (TextBox)Controles.FindControl("txtReturnofPremium");
                txtBenefitAmount = (TextBox)Controles.FindControl("txtBenefitAmount");
                txtInsuredAmount = (TextBox)Controles.FindControl("txtInsuredAmount");
                txtSelectiveTax = ((TextBox)Controles.FindControl("txtSelectiveTax"));
                txtAnnualPremiumWithTax = ((TextBox)Controles.FindControl("txtAnnualPremiumWithTax"));
                //Bmarroquin 28-04-2017 Add Campo Monto Recargo por Fraccionamiento a solicitud de SSF
                lblRecargoFracLabel = (HtmlGenericControl)Controles.FindControl("RecargoFrac");
                txtFraccionamiento = ((TextBox)Controles.FindControl("txtFraccionamiento"));
                txtPrimaAnualNeta = ((TextBox)Controles.FindControl("txtPrimaAnualNeta")); //Bmarroquin 05-05-2017

            }
        }

        public void setVariables()
        {
            CorpId = ObjServices.Corp_Id;
            RegionId = ObjServices.Region_Id;
            CountryId = ObjServices.Country_Id;
            DomesticregId = ObjServices.Domesticreg_Id;
            StateProvId = ObjServices.State_Prov_Id;
            CityId = ObjServices.City_Id;
            OfficeId = ObjServices.Office_Id;
            CaseSeqNo = ObjServices.Case_Seq_No;
            HistSeqNo = ObjServices.Hist_Seq_No;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var bodyContent = this.Page.Master.FindControl("bodyContent");

                if (!ObjServices.IsDataReviewMode)
                {

                    oUdpDesignatedPensioner = bodyContent.FindControl("PlanPolicyContainer")
                                             .FindControl("WUCDesignatedPensionerInformation")
                                             .FindControl("udpDesignatedPensioner")
                                             as UpdatePanel;

                    oWUCDesignatedPensionerInformation = bodyContent.FindControl("PlanPolicyContainer")
                                                         .FindControl("WUCDesignatedPensionerInformation")
                                                         as WUCDesignatedPensionerInformation;

                    oPlanPolicyContainer = bodyContent.FindControl("PlanPolicyContainer") as PlanPolicyContainer;
                }
                else
                {
                    oUdpDesignatedPensioner = bodyContent.FindControl("DReviewContainer")
                                              .FindControl("PlanPolicyContainer")
                                              .FindControl("WUCDesignatedPensionerInformation")
                                              .FindControl("udpDesignatedPensioner")
                                              as UpdatePanel;

                    oWUCDesignatedPensionerInformation = bodyContent.FindControl("DReviewContainer")
                                                         .FindControl("PlanPolicyContainer")
                                                         .FindControl("WUCDesignatedPensionerInformation")
                                                         as WUCDesignatedPensionerInformation;

                    oPlanPolicyContainer = bodyContent.FindControl("DReviewContainer")
                                                      .FindControl("PlanPolicyContainer") as PlanPolicyContainer;

                }
            }
            catch (Exception)
            {

            }

        }

        public void DeleteAllRequirement()
        {
            ObjServices.oRequirementManager.DeleteAll(new Entity.UnderWriting.Entities.Requirement()
            {
                CorpId = this.CorpId,
                RegionId = this.RegionId,
                CountryId = this.CountryId,
                DomesticregId = this.DomesticregId,
                StateProvId = this.StateProvId,
                CityId = this.CityId,
                OfficeId = this.OfficeId,
                CaseSeqNo = this.CaseSeqNo,
                HistSeqNo = this.HistSeqNo,
                UserId = ObjServices.UserID.Value
            });
        }

        public void save()
        {
            setVariables();
            setControls();

            /*if (ObjServices.IsPlanChange)
            {
                DeleteAllRequirement();
                ObjServices.IsPlanChange = false;
            } */

            var pData = ObjServices.oPolicyManager.GetPolicy(CorpId, RegionId, CountryId, DomesticregId, StateProvId
            , CityId, OfficeId, CaseSeqNo, HistSeqNo);

            pData.UserId = ObjServices.UserID.Value;

            if (hdAnnualPremium != null)
                pData.AnnualPremium = Utility.IsDecimalReturnNull(hdAnnualPremium.Value.Replace(",", ""));

            if (txtMinimumAnnualPremium != null)
            {
                var value = Utility.IsDecimalReturnNull(txtMinimumAnnualPremium.Text.Replace(",", ""));
                pData.MinimunPremiunAmount = value;
                pData.MinAnnualPremium = value;
            }

            if (txtTargetAnnualPremium != null)
                pData.TargetPremium = Utility.IsDecimalReturnNull(txtTargetAnnualPremium.Text.Replace(",", ""));

            if (txtTotalRetirementAmount != null)
                pData.RetirementAmount = Utility.IsDecimalReturnNull(txtTotalRetirementAmount.Text.Replace(",", ""));

            if (txtPeriodicPremium != null)
                pData.PeriodicPremium = Utility.IsDecimalReturnNull(txtPeriodicPremium.Text.Replace(",", ""));

            if (txtInsuredAmount != null)
                pData.InsuredAmount = decimal.Parse(txtInsuredAmount.Text.Replace(",", ""), CultureInfo.InvariantCulture);

            if (txtBenefitAmount != null)
                pData.BenefitAmount = Utility.IsDecimalReturnNull(txtBenefitAmount.Text.Replace(",", ""));
            else
                pData.BenefitAmount = pData.InsuredAmount;
            /*  Lgonzalez 24-02-2017
            if (txtReturnofPremium != null)
                pData.ReturnAmount = Utility.IsDecimalReturnNull(txtReturnofPremium.Text.Replace(",", ""));
            */
            if (Hidden1.Value != null)
                pData.ReturnAmount = Utility.IsDecimalReturnNull(Hidden1.Value.Replace(",", ""));

            //***  Bmarroquin 17-03-2017 se estaba perdiendo el valor de la Devolucion del retorno de PRima ***
            bool lBnl_Flag = false;

            //Verificar primero si ya se seteo la variable entonces no Asignarle un nuevo valor
            if (pData.ReturnAmount.HasValue == false)
            {
                lBnl_Flag = true;
            }
            else
            {
                if (pData.ReturnAmount <= 0) 
                {
                    lBnl_Flag = true;
                }
            }

            if (lBnl_Flag)
            {
                //if (Hidden1.Value != null)
                if (Hidden1 != null)
                {
                    //if (string.IsNullOrWhiteSpace(Hidden1.Value))
                    if (string.IsNullOrWhiteSpace(Hidden1.Value) || Hidden1.Value.Equals("0.00"))
                    {
                        if (txtReturnofPremium != null)
                        {
                            if (string.IsNullOrWhiteSpace(txtReturnofPremium.Text) == false)
                            {
                                var lNumReturnPremium = Utility.IsDecimalReturnNull(txtReturnofPremium.Text.Replace(",", ""));
                                if (lNumReturnPremium.HasValue)
                                {
                                    pData.ReturnAmount = lNumReturnPremium;

                                    Hidden1.Value = Convert.ToString(lNumReturnPremium);//lo volvemos a setear
                                }
                            }
                        }

                    }
                }
            }
            //***  Fin cambios bmarroquin 17-03-2017  ***

            //Bmarroquin 28-04-2017 Add Campo Monto Recargo por Fraccionamiento a solicitud de SSF
            if (txtFraccionamiento != null)
                if (!string.IsNullOrEmpty(txtFraccionamiento.Text) && !txtFraccionamiento.Text.Equals("0.00"))
                    pData.Fraction_Surcharge = decimal.Parse(txtFraccionamiento.Text.Replace(",", ""), CultureInfo.InvariantCulture);

            //Bmarroquin 05-05-2017 Add Campo Prima Comercial/Neta a solicitud de SSF
            if (txtPrimaAnualNeta != null)
                if (!string.IsNullOrEmpty(txtPrimaAnualNeta.Text) && !txtPrimaAnualNeta.Text.Equals("0.00"))
                    pData.Net_Annual_Premium = decimal.Parse(txtPrimaAnualNeta.Text.Replace(",", ""), CultureInfo.InvariantCulture);

            ObjServices.oPolicyManager.UpdatePolicy(pData);

            //***  Bmarroquin 21-03-2017 Comento codigo para que no se este insertando un Header de Info. de PAgo en Payments en NB y DT se crean registros y en UW se ven duplicados/Triplicados cuando se rechaza caso desde DT se pierde la info de pago en NB ***
            //***  Fin Bmarroquin 21-03-2017 

            #region Payments

            if (!ObjServices.PaymentId.HasValue || ObjServices.PaymentId.Value <= 0)
            {
                var pay = new Entity.UnderWriting.Entities.Payment.ApplyPayment();
                pay.CorpId = ObjServices.Corp_Id;
                pay.RegionId = ObjServices.Region_Id;
                pay.CountryId = ObjServices.Country_Id;
                pay.DomesticregId = ObjServices.Domesticreg_Id;
                pay.StateProvId = ObjServices.State_Prov_Id;
                pay.CityId = ObjServices.City_Id;
                pay.OfficeId = ObjServices.Office_Id;
                pay.CaseSeqNo = ObjServices.Case_Seq_No;
                pay.HistSeqNo = ObjServices.Hist_Seq_No;
                pay.PaymentStatusId = 2;
                pay.UserId = ObjServices.UserID.Value;
                ObjServices.PaymentId = ObjServices.oPaymentManager.InsertPayment(pay).PaymentId;
            }
            var item = ObjServices.oPaymentManager.GetPayment
                (
                      ObjServices.Corp_Id
                    , ObjServices.Region_Id
                    , ObjServices.Country_Id
                    , ObjServices.Domesticreg_Id
                    , ObjServices.State_Prov_Id
                    , ObjServices.City_Id
                    , ObjServices.Office_Id
                    , ObjServices.Case_Seq_No
                    , ObjServices.Hist_Seq_No
                    , ObjServices.PaymentId.Value
                );

            if (item.PaymentStatusId == 2) // completado
            {
                item.CorpId = ObjServices.Corp_Id;
                item.CityId = ObjServices.City_Id;
                item.CountryId = ObjServices.Country_Id;
                item.RegionId = ObjServices.Region_Id;
                item.StateProvId = ObjServices.State_Prov_Id;
                item.DomesticregId = ObjServices.Domesticreg_Id;
                item.OfficeId = ObjServices.Office_Id;
                item.CaseSeqNo = ObjServices.Case_Seq_No;
                item.HistSeqNo = ObjServices.Hist_Seq_No;
                item.PaymentId = ObjServices.PaymentId.Value;
                item.DueAmount = (pData.PeriodicPremium.HasValue ? pData.PeriodicPremium.Value : 0) + (pData.InitialContribution.HasValue ? pData.InitialContribution.Value : 0);
                item.DueDate = DateTime.Now;
                item.PaidAmount = 0;
                item.PaymentStatusId = 2;
                item.UserId = ObjServices.UserID.Value;
                var payReturn = ObjServices.oPaymentManager.UpdatePayment(item);
                if (payReturn != null)
                    ObjServices.PaymentId = payReturn.PaymentId;

            }

            #endregion
         
     

            if (!GetWUCPlanInformation().isNullReferenceControl())
            {
                GetWUCPlanInformation().setControls();

                var oddlInvestmentProfile = GetWUCPlanInformation().Controles.FindControl("ddlInvestmentProfile");
                var ddlInvestmentProfile = oddlInvestmentProfile as DropDownList;

                if (!oddlInvestmentProfile.isNullReferenceControl() && ddlInvestmentProfile.SelectedValue != "-1")
                {
                    var keyInvestProfdata = Utility.deserializeJSON<Utility.KeyInvestProfile>(ddlInvestmentProfile.SelectedValue);
                    var profileTypeId = keyInvestProfdata.ProfileTypeId;

                    if (!keyInvestProfdata.Modifiable)
                    {
                        var date = DateTime.Now;

                        //Profile Item
                        var investProfile = new Entity.UnderWriting.Entities.Policy.InvestProfile
                        {
                            //Profile Data
                            ProfileTypeId = profileTypeId,
                            InvestProductDateId = int.Parse(date.ToString("yyyyMMdd")),
                            InvestmentProductDate = date,
                            InvstProfileDesc = ddlInvestmentProfile.SelectedItem.Text,
                        };

                        ObjServices.SavePPInvestmentProfile(investProfile);
                    }
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            setControls();
            btnSaveFooter.Text = Resources.Save;

            if (ver != VEmpty)
            {
                var TotalInsuredAmount = Controles.FindControl("TotalInsuredAmount").AsHtmlGenericControl();
                if (!TotalInsuredAmount.isNullReferenceControl())
                    TotalInsuredAmount.InnerHtml = Resources.TotalInsuredAmount;

                var TotalRetirementAmount = Controles.FindControl("TotalRetirementAmount").AsHtmlGenericControl();
                if (!TotalRetirementAmount.isNullReferenceControl())
                    TotalRetirementAmount.InnerHtml = Resources.TotalRetirementAmount;

                var AnnualPremium = Controles.FindControl("AnnualPremium").AsHtmlGenericControl();
                if (!AnnualPremium.isNullReferenceControl())
                    AnnualPremium.InnerHtml = Resources.AnnualPremium;

                var PeriodicPremium = Controles.FindControl("PeriodicPremium").AsHtmlGenericControl();
                if (!PeriodicPremium.isNullReferenceControl())
                    PeriodicPremium.InnerHtml = Resources.PeriodicPremium;

                var TargetAnnualPremium = Controles.FindControl("TargetAnnualPremium").AsHtmlGenericControl();
                if (!TargetAnnualPremium.isNullReferenceControl())
                    TargetAnnualPremium.InnerHtml = Resources.TargetAnnualPremium;

                var MinimumAnnualPremium = Controles.FindControl("MinimumAnnualPremium").AsHtmlGenericControl();
                if (!MinimumAnnualPremium.isNullReferenceControl())
                    MinimumAnnualPremium.InnerHtml = Resources.MinimumAnnualPremium;

                var ProspectAgeatStartofRetirement = Controles.FindControl("ProspectAgeatStartofRetirement").AsHtmlGenericControl();
                if (!ProspectAgeatStartofRetirement.isNullReferenceControl())
                    ProspectAgeatStartofRetirement.InnerHtml = Resources.ProspectAgeatStartofRetirement;

                var ProspectAgeatStartofEducation = Controles.FindControl("ProspectAgeatStartofEducation").AsHtmlGenericControl();
                if (!ProspectAgeatStartofEducation.isNullReferenceControl())
                    ProspectAgeatStartofEducation.InnerHtml = Resources.ProspectAgeatStartofEducation;

                var TotalStudyAmount = Controles.FindControl("TotalStudyAmount").AsHtmlGenericControl();
                if (!TotalStudyAmount.isNullReferenceControl())
                    TotalStudyAmount.InnerHtml = Resources.TotalStudyAmount;

                var ReturnofPremium = Controles.FindControl("ReturnofPremium").AsHtmlGenericControl();
                if (!ReturnofPremium.isNullReferenceControl())
                    ReturnofPremium.InnerHtml = Resources.ReturnofPremium;

                if (!SelectiveTaxLabel.isNullReferenceControl())
                    SelectiveTaxLabel.InnerHtml = Resources.SelectiveTaxLabel;

                if (!AnnualPremiumWithTaxLabel.isNullReferenceControl())
                    AnnualPremiumWithTaxLabel.InnerHtml = Resources.AnnualPremiumWithTaxLabel;
                //Bmarroquin 28-04-2017 Add Campo Monto Recargo por Fraccionamiento a solicitud de SSF
                if (!lblRecargoFracLabel.isNullReferenceControl())
                    lblRecargoFracLabel.InnerHtml = Resources.lblMontoRecargoFraccio;

            }

            if (isChangingLang)
                FillData();
        }

        public void edit()
        {

        }

        public void FillData()
        {
            setVariables();
            setControls();

            var defaultValue = "0.00";
            var NumberFormat = "#0.00";

            var datos = ObjServices.oPolicyManager.GetPlanData(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo);

            if (datos != null)
            {
                if (txtTotalRetirementAmount != null)
                    txtTotalRetirementAmount.Text = datos.RetirementAmount.HasValue ?
                                                    datos.RetirementAmount.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                                    : defaultValue;

                if (txtPeriodicPremium != null)
                    txtPeriodicPremium.Text = datos.PeriodicPremium.HasValue ?
                                              datos.PeriodicPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                              : defaultValue;

                if (txtAnnualPremium != null)
                {
                    txtAnnualPremium.Text = datos.AnnualPremium.HasValue ?
                                            datos.AnnualPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                            : defaultValue;

                    if (txtAnnualPremium.Text == "0.00")
                        if (txtPeriodicPremium.Text != "0.00")
                        {
                            AnnualPre = CalculateAnnualPremium(txtPeriodicPremium.Text.ToDecimal());
                            txtAnnualPremium.Text = AnnualPre != 0 ? AnnualPre.ToString(NumberFormat, NumberFormatInfo.InvariantInfo) : defaultValue;
                        }

                    //Bmarroquin Cambios a raiz de la tropicalizacion de ESA el Impuesto Selectivo a Seguros es cero...
                    var SelectiveTax = 0; // (decimal.Parse(txtAnnualPremium.Text, NumberFormatInfo.InvariantInfo) * Utility.GetItbis());

                    txtSelectiveTax.Text = SelectiveTax != 0 ? SelectiveTax.ToString(NumberFormat, NumberFormatInfo.InvariantInfo) : defaultValue;

                    //Bmarroquin Cambios a raiz de la tropicalizacion de ESA prima con impuesto es igual a prima Anual no hay impuesto...
                    //txtAnnualPremiumWithTax.Text = (AnnualPre != 0)  ? (AnnualPre + SelectiveTax).ToString(NumberFormat, NumberFormatInfo.InvariantInfo) : defaultValue;
                    txtAnnualPremiumWithTax.Text = datos.AnnualPremium.HasValue ? datos.AnnualPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo) : defaultValue;

                }

                if (txtTargetAnnualPremium != null)
                    txtTargetAnnualPremium.Text = datos.TargetPremium.HasValue ?
                                                  datos.TargetPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                                  : defaultValue;

                if (txtMinimumAnnualPremium != null)
                    txtMinimumAnnualPremium.Text = datos.MinAnnualPremium.HasValue ?
                                                   datos.MinAnnualPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                                   : defaultValue;

                if (txtBenefitAmount != null)
                    txtBenefitAmount.Text = datos.BenefitAmount.HasValue ?
                                            datos.BenefitAmount.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                            : defaultValue;

                if (txtInsuredAmount != null)
                    txtInsuredAmount.Text = datos.InsuredAmount.HasValue ?
                                            datos.InsuredAmount.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                            : defaultValue;

                if (txtReturnofPremium != null)
                    txtReturnofPremium.Text = Hidden1.Value= datos.ReturnAmount.HasValue ?
                                              datos.ReturnAmount.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                              : defaultValue;

                if (txtProspectAgeStartRetirement != null)
                    txtProspectAgeStartRetirement.Text = datos.AgeAtStartOfRetirement.ToString();

                //Bmarroquin 28-04-2017 Add Campo Monto Recargo por Fraccionamiento a solicitud de SSF
                if (txtFraccionamiento != null)
                    txtFraccionamiento.Text = datos.Fraction_Surcharge.HasValue ?
                                            datos.Fraction_Surcharge.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                            : defaultValue;

                //Bmarroquin 05-05-2017 Add Campo Prima Comercial a solicitud de SSF
                if (txtPrimaAnualNeta != null)
                    txtPrimaAnualNeta.Text = datos.NetAnnualPremium.HasValue ?
                                            datos.NetAnnualPremium.Value.ToString(NumberFormat, NumberFormatInfo.InvariantInfo)
                                            : defaultValue;
            }
        }

        public void Initialize()
        {
            ClearData();
            FillData();
            if (ObjServices.IsReadOnly || ObjServices.IsDataReviewMode && getisView)
                ReadOnlyControls(ObjServices.IsReadOnly);
        }

        public void ClearData()
        {
            Utility.ClearAll(pnFooter.Controls);
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnFooter.Controls, isReadOnly);
        }

        private decimal CalculateAnnualPremium(decimal? PeriodicPremium)
        {
            decimal? Annpremium = 0;
            var WUCPlanInformation = GetWUCPlanInformation();
            WUCPlanInformation.setControls();
            var ddlFrequencyofPayment = WUCPlanInformation.ddlFrequencyofPayment;
            if (!ddlFrequencyofPayment.isNullReferenceControl())
            {
                int frequencyValue = ddlFrequencyofPayment.SelectedValue.ToInt();

                if (frequencyValue == -1)
                    return Annpremium.Value;

                var MultiploAnual = Convert.ToDecimal(HDFMultiploAnual.Value);

                switch (frequencyValue)
                {
                    case 1://Trimestral
                        Annpremium = (PeriodicPremium * 4m) - ((PeriodicPremium * 4m) * MultiploAnual);
                        break;
                    case 2://Mensual
                        Annpremium = (PeriodicPremium * 12m) - ((PeriodicPremium * 12m) * MultiploAnual);
                        break;
                    case 3://Anual
                        Annpremium = (PeriodicPremium * 1m) - ((PeriodicPremium * 1m) * MultiploAnual);
                        break;
                    case 4://Semestral
                        Annpremium = (PeriodicPremium * 2m) - ((PeriodicPremium * 2m) * MultiploAnual);
                        break;
                }
            }

            return Annpremium.Value;
        }

        public WUCPlanInformation GetWUCPlanInformation()
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");

            var oWUCPlanInformation = (!ObjServices.IsDataReviewMode) ? bodyContent.FindControl("PlanPolicyContainer").FindControl("WUCPlanInformation") as WUCPlanInformation
                                                                      : bodyContent.FindControl("DReviewContainer").FindControl("PlanPolicyContainer").FindControl("WUCPlanInformation") as WUCPlanInformation;

            return oWUCPlanInformation;
        }

        public void SetMultiploAnualAndItbis()
        {
            var data = ObjServices.GettingDropData(Utility.DropDownType.ProjectConfigurationValue, corpId: ObjServices.Corp_Id, pProjectId: int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectIdNewBusiness"]));

            HDFItbis.Value = Utility.GetItbis().ToString("#,0.00", NumberFormatInfo.InvariantInfo);

            HDFMultiploAnual.Value = data.FirstOrDefault(x => x.Namekey == "MultiploAnual").ConfigurationValue;
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            double RopAmount = 0;
            RopAmount = 1 + (2 * 3 * Math.Floor(4.00));            
        }
    }
}