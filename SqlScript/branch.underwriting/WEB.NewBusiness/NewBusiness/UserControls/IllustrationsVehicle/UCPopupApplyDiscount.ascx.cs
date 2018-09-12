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
    public partial class UCPopupApplyDiscount : UC, IUC
    {
        static List<Policy.VehicleInsured> vehiclesInsured;
        static List<Policy.VehicleInsured.Discount> Discounts;

        static List<Utility.Property> propertiesInsured;
        static List<Property.Insured.Discount> DiscountsProperties;

        static List<Utility.AirPlane> airPlaneInsured;
        static List<Airplane.Insured.Discount> DiscountsAirplane;

        static List<Utility.Bail> bailInsured;
        static List<Bail.Insured.Discount> DiscountsBail;

        static List<Utility.Transport> tranportInsured;
        static List<Transport.Insured.Discount> DiscountsTransport;

        static List<Utility.Navy> navyInsured;
        static List<Navy.Insured.Discount> DiscountsNavy;

        static string YouMustSaveSelectedDiscountBeforeClosingWindow = string.Empty,
                      Warning = string.Empty,
                      YouMustSelectDiscountRateToApply = string.Empty,
                      YouMustSelectPercentageDiscountToApply = string.Empty,
                      TypeOfDiscountAlreadyApplied = string.Empty;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                this.ExcecuteJScript("DropText();");
                ddlPorcentajeDescuento.Enabled = txtMontoDescuento.Text == "0.00";
                txtMontoDescuento.Enabled = ddlPorcentajeDescuento.SelectedIndex == 0;
            }

            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    mvDiscount.SetActiveView(vAuto);
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            mvDiscount.SetActiveView(vAirPlane);
                            break;
                        case Utility.AlliedLinesType.Bail:
                            mvDiscount.SetActiveView(vBail);
                            break;
                        case Utility.AlliedLinesType.Navy:
                            mvDiscount.SetActiveView(vNavy);
                            break;
                        case Utility.AlliedLinesType.Property:
                            mvDiscount.SetActiveView(vProperty);
                            break;
                        case Utility.AlliedLinesType.Transport:
                            mvDiscount.SetActiveView(vTransport);
                            break;
                        case Utility.AlliedLinesType.Vehicle:
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        public void Translator(string Lang)
        {
            YouMustSaveSelectedDiscountBeforeClosingWindow = Resources.YouMustSaveSelectedDiscountBeforeClosingWindow;
            Warning = Resources.Warning;
            YouMustSelectDiscountRateToApply = Resources.YouMustSelectDiscountRateToApply;
            YouMustSelectPercentageDiscountToApply = Resources.YouMustSelectPercentageDiscountToApply;
            TypeOfDiscountAlreadyApplied = Resources.TypeOfDiscountAlreadyApplied;

            btnApplyDiscount.Text = Resources.Save;
            ltTypeDoc.Text = Resources.ApplyDiscount;
            btnClean.Text = Resources.Clear;
            hdnWarningMessageTitle.Value = string.Format("{0}|{1}", YouMustSaveSelectedDiscountBeforeClosingWindow, Warning);
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void save(bool DiscountStatus, int? DiscountId)
        {
            try
            {
                bool delete = ViewState["Delete"] != null ? Convert.ToBoolean(ViewState["Delete"]) : false,
                     edit = ViewState["edit"] != null ? Convert.ToBoolean(ViewState["edit"]) : false;

                if (!delete && !edit)
                {
                    string mensaje = string.Empty;

                    bool montoVacioCero = (ObjServices.ProductLine == Utility.ProductLine.Auto) ? (string.IsNullOrWhiteSpace(txtMontoDescuento.Text.Trim()) ||
                                                                                                                             txtMontoDescuento.Text.ToDecimal() == 0m)
                                                                                                : true;

                    if (ddlTipoDescuento.SelectedIndex == 0)
                        mensaje = YouMustSelectDiscountRateToApply;
                    else if (ddlPorcentajeDescuento.SelectedIndex == 0 && montoVacioCero)
                        mensaje = YouMustSelectPercentageDiscountToApply;

                    if (!string.IsNullOrWhiteSpace(mensaje))
                    {
                        this.MessageBox(mensaje, Width: 500, Title: Warning);
                        ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                        return;
                    }
                }

                Policy policy = ObjServices.oPolicyManager.GetPolicy(ObjServices.Corp_Id,
                                                                    ObjServices.Region_Id,
                                                                    ObjServices.Country_Id,
                                                                    ObjServices.Domesticreg_Id,
                                                                    ObjServices.State_Prov_Id,
                                                                    ObjServices.City_Id,
                                                                    ObjServices.Office_Id,
                                                                    ObjServices.Case_Seq_No,
                                                                    ObjServices.Hist_Seq_No);

                decimal annualPremium = 0m,
                        descuento = 0m,
                        MaximoDescuentoPermitidoPorRole = 0m,
                        sumaPorcentajes = 0m;

                int notePredefiniedId = ViewState["NotePredefiniedId"] != null ? Convert.ToInt32(ViewState["NotePredefiniedId"]) : 0,
                    DiscountRuleId = ViewState["DiscountRuleId"] != null ? Convert.ToInt32(ViewState["DiscountRuleId"]) : 0,
                    DiscountRuleDetailId = ViewState["DiscountRuleDetailId"] != null ? Convert.ToInt32(ViewState["DiscountRuleDetailId"]) : 0,
                    NADiscountRuleId = ViewState["NADiscountRuleId"] != null ? Convert.ToInt32(ViewState["NADiscountRuleId"]) : 0,
                    NADetailId = ViewState["NADetailId"] != null ? Convert.ToInt32(ViewState["NADetailId"]) : 0;

                DiscountRule porcentaje_seleccionado = new DiscountRule();
                bool excede = false;

                switch (ObjServices.ProductLine)
                {
                    case Utility.ProductLine.Auto:
                        #region Proceso Auto

                        if (DiscountId == null || edit)
                        {
                            notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                            annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                            if (ddlPorcentajeDescuento.SelectedIndex > 0)
                            {
                                porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                NADiscountRuleId =
                                NADetailId = 0;
                            }

                            var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);

                            if (montoDescuento > 0m)
                            {
                                //verificar si montoDescuento excede a % permitido por el role                        
                                MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                       : 0m;

                                decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                        MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                        montoPorcentaje = (montoDescuento / annualPremium);

                                sumaPorcentajes = Discounts.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                if (excede && !delete && !edit)
                                {
                                    this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                    ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                    ddlPorcentajeDescuento.Enabled = false;
                                    return;
                                }
                                else
                                    descuento = annualPremium - montoDescuento;
                            }
                        }
                        else
                        {
                            porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                            porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                            //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                        }

                        #region Verificar si los decuentos ya habian sido aplicados
                        if (!delete && !edit)
                        {
                            if (Discounts.Count > 0)
                            {
                                bool aplicado = false;
                                string msg = string.Empty;

                                var descuentos = Discounts.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                if (descuentos.Count > 0)
                                {
                                    foreach (var desc in descuentos)
                                    {
                                        if (desc.NotePredefiniedId == notePredefiniedId)
                                        {
                                            msg = TypeOfDiscountAlreadyApplied;
                                            aplicado = true;
                                            break;
                                        }

                                        if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                        {
                                            msg = TypeOfDiscountAlreadyApplied;
                                            aplicado = true;
                                            break;
                                        }
                                    }

                                    if (aplicado)
                                    {
                                        this.MessageBox(msg, Width: 500, Title: Warning);
                                        ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                        return;
                                    }
                                }
                            }
                        }
                        #endregion

                        foreach (var vehicle_insured in vehiclesInsured)
                        {
                            #region Guardar - Actualizar
                            Policy.VehicleInsured.Discount discount = new Policy.VehicleInsured.Discount();

                            discount.CorpId = vehicle_insured.CorpId;
                            discount.RegionId = vehicle_insured.RegionId;
                            discount.CountryId = vehicle_insured.CountryId;
                            discount.DomesticRegId = vehicle_insured.DomesticregId;
                            discount.StateProvId = vehicle_insured.StateProvId;
                            discount.CityId = vehicle_insured.CityId;
                            discount.OfficeId = vehicle_insured.OfficeId;
                            discount.CaseSeqNo = vehicle_insured.CaseSeqNo;
                            discount.HistSeqNo = vehicle_insured.HistSeqNo;
                            discount.InsuredVehicleId = vehicle_insured.InsuredVehicleId.Value;
                            discount.DiscountId = DiscountId;
                            discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                            discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                            discount.NotePredefiniedId = notePredefiniedId;
                            discount.DiscountStatus = DiscountStatus;
                            discount.UserId = ObjServices.UserID.Value;

                            if (!delete)
                            {
                                discount.PremiumAmount = descuento;
                                discount.OldPremiumAmount = annualPremium;
                                discount.Comment = txtNota.Text;
                            }

                            var vehicle_discount = ObjServices.oPolicyManager.SetVehicleInsuredDiscount(discount);
                            #endregion

                            #region Ejecutar proceso cargos/descuentos
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
                            #endregion
                        }
                        #endregion
                        break;
                    case Utility.ProductLine.AlliedLines:
                        switch (ObjServices.AlliedLinesProductBehavior)
                        {
                            case Utility.AlliedLinesType.Airplane:
                                #region Proceso AirPlane

                                if (DiscountId == null || edit)
                                {
                                    notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                                    annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                                    if (ddlPorcentajeDescuento.SelectedIndex > 0)
                                    {
                                        porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                        descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                        NADiscountRuleId =
                                        NADetailId = 0;
                                    }

                                    //var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);
                                    var montoDescuento = 0;
                                    if (montoDescuento > 0m)
                                    {
                                        //verificar si montoDescuento excede a % permitido por el role                        
                                        MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                               : 0m;

                                        decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                                MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                                montoPorcentaje = (montoDescuento / annualPremium);

                                        sumaPorcentajes = DiscountsAirplane.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                        excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                        if (excede && !delete && !edit)
                                        {
                                            this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                            ddlPorcentajeDescuento.Enabled = false;
                                            return;
                                        }
                                        else
                                            descuento = annualPremium - montoDescuento;
                                    }
                                }
                                else
                                {
                                    porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                                    porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                                    //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                                }

                                #region Verificar si los decuentos ya habian sido aplicados
                                if (!delete && !edit)
                                {
                                    if (DiscountsAirplane.Count > 0)
                                    {
                                        bool aplicado = false;
                                        string msg = string.Empty;

                                        var descuentos = DiscountsAirplane.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                        if (descuentos.Count > 0)
                                        {
                                            foreach (var desc in descuentos)
                                            {
                                                if (desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }

                                                if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }
                                            }

                                            if (aplicado)
                                            {
                                                this.MessageBox(msg, Width: 500, Title: Warning);
                                                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                foreach (var airPlane_insured in airPlaneInsured)
                                {
                                    #region Guardar - Actualizar
                                    Airplane.Insured.Discount discount = new Airplane.Insured.Discount();

                                    discount.CorpId = airPlane_insured.CorpId;
                                    discount.RegionId = airPlane_insured.RegionId;
                                    discount.CountryId = airPlane_insured.CountryId;
                                    discount.DomesticregId = airPlane_insured.DomesticregId;
                                    discount.StateProvId = airPlane_insured.StateProvId;
                                    discount.CityId = airPlane_insured.CityId;
                                    discount.OfficeId = airPlane_insured.OfficeId;
                                    discount.CaseSeqNo = airPlane_insured.CaseSeqNo;
                                    discount.HistSeqNo = airPlane_insured.HistSeqNo;
                                    discount.AirplaneId = airPlane_insured.AirplaneId.ToInt();
                                    discount.DiscountId = DiscountId.GetValueOrDefault();
                                    discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                                    discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                                    discount.NotePredefiniedId = notePredefiniedId;
                                    discount.discountStatus = DiscountStatus;
                                    discount.UserId = ObjServices.UserID.Value;

                                    if (!delete)
                                    {
                                        discount.PremiumAmount = descuento;
                                        discount.OldPremiumAmount = annualPremium;
                                        discount.Comment = txtNota.Text;
                                    }

                                    var pro_discount = ObjServices.oAirPlaneManager.SetAirplaneInsuredDiscount(discount);
                                    #endregion

                                    #region Ejecutar proceso cargos/descuentos
                                    var result = ObjServices.oAirPlaneManager.SetAirplaneApplyDiscountAndSurcharge(new Airplane.Insured
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
                                        //UserId = ObjServices.UserID.GetValueOrDefault()
                                    });
                                    #endregion
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Bail:
                                #region Proceso Bail

                                if (DiscountId == null || edit)
                                {
                                    notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                                    annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                                    if (ddlPorcentajeDescuento.SelectedIndex > 0)
                                    {
                                        porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                        descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                        NADiscountRuleId =
                                        NADetailId = 0;
                                    }

                                    //var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);
                                    var montoDescuento = 0;
                                    if (montoDescuento > 0m)
                                    {
                                        //verificar si montoDescuento excede a % permitido por el role                        
                                        MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                               : 0m;

                                        decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                                MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                                montoPorcentaje = (montoDescuento / annualPremium);

                                        sumaPorcentajes = DiscountsBail.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                        excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                        if (excede && !delete && !edit)
                                        {
                                            this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                            ddlPorcentajeDescuento.Enabled = false;
                                            return;
                                        }
                                        else
                                            descuento = annualPremium - montoDescuento;
                                    }
                                }
                                else
                                {
                                    porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                                    porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                                    //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                                }

                                #region Verificar si los decuentos ya habian sido aplicados
                                if (!delete && !edit)
                                {
                                    if (DiscountsBail.Count > 0)
                                    {
                                        bool aplicado = false;
                                        string msg = string.Empty;

                                        var descuentos = DiscountsBail.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                        if (descuentos.Count > 0)
                                        {
                                            foreach (var desc in descuentos)
                                            {
                                                if (desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }

                                                if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }
                                            }

                                            if (aplicado)
                                            {
                                                this.MessageBox(msg, Width: 500, Title: Warning);
                                                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                foreach (var bail_insured in bailInsured)
                                {
                                    #region Guardar - Actualizar
                                    Bail.Insured.Discount discount = new Bail.Insured.Discount();

                                    discount.CorpId = bail_insured.CorpId;
                                    discount.RegionId = bail_insured.RegionId;
                                    discount.CountryId = bail_insured.CountryId;
                                    discount.DomesticregId = bail_insured.DomesticregId;
                                    discount.StateProvId = bail_insured.StateProvId;
                                    discount.CityId = bail_insured.CityId;
                                    discount.OfficeId = bail_insured.OfficeId;
                                    discount.CaseSeqNo = bail_insured.CaseSeqNo;
                                    discount.HistSeqNo = bail_insured.HistSeqNo;
                                    discount.BailId = bail_insured.BailId.ToInt();
                                    discount.DiscountId = DiscountId.GetValueOrDefault();
                                    discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                                    discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                                    discount.NotePredefiniedId = notePredefiniedId;
                                    discount.discountStatus = DiscountStatus;
                                    discount.UserId = ObjServices.UserID.Value;

                                    if (!delete)
                                    {
                                        discount.PremiumAmount = descuento;
                                        discount.OldPremiumAmount = annualPremium;
                                        discount.Comment = txtNota.Text;
                                    }

                                    var pro_discount = ObjServices.oBailManager.SetBailInsuredDiscount(discount);
                                    #endregion

                                    #region Ejecutar proceso cargos/descuentos
                                    var result = ObjServices.oBailManager.SetBailInsuredApplyDiscountAndSurcharge(new Bail.Insured
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
                                    #endregion
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Navy:
                                #region Proceso Navy

                                if (DiscountId == null || edit)
                                {
                                    notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                                    annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                                    if (ddlPorcentajeDescuento.SelectedIndex > 0)
                                    {
                                        porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                        descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                        NADiscountRuleId =
                                        NADetailId = 0;
                                    }

                                    //var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);
                                    var montoDescuento = 0;
                                    if (montoDescuento > 0m)
                                    {
                                        //verificar si montoDescuento excede a % permitido por el role                        
                                        MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                               : 0m;

                                        decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                                MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                                montoPorcentaje = (montoDescuento / annualPremium);

                                        sumaPorcentajes = DiscountsNavy.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                        excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                        if (excede && !delete && !edit)
                                        {
                                            this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                            ddlPorcentajeDescuento.Enabled = false;
                                            return;
                                        }
                                        else
                                            descuento = annualPremium - montoDescuento;
                                    }
                                }
                                else
                                {
                                    porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                                    porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                                    //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                                }

                                #region Verificar si los decuentos ya habian sido aplicados
                                if (!delete && !edit)
                                {
                                    if (DiscountsNavy.Count > 0)
                                    {
                                        bool aplicado = false;
                                        string msg = string.Empty;

                                        var descuentos = DiscountsNavy.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                        if (descuentos.Count > 0)
                                        {
                                            foreach (var desc in descuentos)
                                            {
                                                if (desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }

                                                if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }
                                            }

                                            if (aplicado)
                                            {
                                                this.MessageBox(msg, Width: 500, Title: Warning);
                                                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                foreach (var navy_insured in navyInsured)
                                {
                                    #region Guardar - Actualizar
                                    Navy.Insured.Discount discount = new Navy.Insured.Discount();

                                    discount.CorpId = navy_insured.CorpId;
                                    discount.RegionId = navy_insured.RegionId;
                                    discount.CountryId = navy_insured.CountryId;
                                    discount.DomesticRegId = navy_insured.DomesticregId;
                                    discount.StateProvId = navy_insured.StateProvId;
                                    discount.CityId = navy_insured.CityId;
                                    discount.OfficeId = navy_insured.OfficeId;
                                    discount.CaseSeqNo = navy_insured.CaseSeqNo;
                                    discount.HistSeqNo = navy_insured.HistSeqNo;
                                    discount.NavyId = navy_insured.NavyId.ToInt();
                                    discount.DiscountId = DiscountId.GetValueOrDefault();
                                    discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                                    discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                                    discount.NotePredefiniedId = notePredefiniedId;
                                    discount.DiscountStatus = DiscountStatus;
                                    discount.UserId = ObjServices.UserID.Value;

                                    if (!delete)
                                    {
                                        discount.PremiumAmount = descuento;
                                        discount.OldPremiumAmount = annualPremium;
                                        discount.Comment = txtNota.Text;
                                    }

                                    var pro_discount = ObjServices.oNavyManager.SetNavyInsuredDiscount(discount);
                                    #endregion

                                    #region Ejecutar proceso cargos/descuentos
                                    var result = ObjServices.oNavyManager.SetNavyInsuredApplyDiscountAndSurcharge(new Navy.Insured
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
                                    #endregion
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Property:
                                #region Proceso Propiedad

                                if (DiscountId == null || edit)
                                {
                                    notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                                    annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                                    if (ddlPorcentajeDescuento.SelectedIndex > 0)
                                    {
                                        porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                        descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                        NADiscountRuleId =
                                        NADetailId = 0;
                                    }

                                    //var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);
                                    var montoDescuento = 0;
                                    if (montoDescuento > 0m)
                                    {
                                        //verificar si montoDescuento excede a % permitido por el role                        
                                        MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                               : 0m;

                                        decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                                MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                                montoPorcentaje = (montoDescuento / annualPremium);

                                        sumaPorcentajes = DiscountsProperties.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                        excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                        if (excede && !delete && !edit)
                                        {
                                            this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                            ddlPorcentajeDescuento.Enabled = false;
                                            return;
                                        }
                                        else
                                            descuento = annualPremium - montoDescuento;
                                    }
                                }
                                else
                                {
                                    porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                                    porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                                    //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                                }

                                #region Verificar si los decuentos ya habian sido aplicados
                                if (!delete && !edit)
                                {
                                    if (DiscountsProperties.Count > 0)
                                    {
                                        bool aplicado = false;
                                        string msg = string.Empty;

                                        var descuentos = DiscountsProperties.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                        if (descuentos.Count > 0)
                                        {
                                            foreach (var desc in descuentos)
                                            {
                                                if (desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }

                                                if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }
                                            }

                                            if (aplicado)
                                            {
                                                this.MessageBox(msg, Width: 500, Title: Warning);
                                                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                foreach (var properties_insured in propertiesInsured)
                                {
                                    #region Guardar - Actualizar
                                    Property.Insured.Discount discount = new Property.Insured.Discount();

                                    discount.CorpId = properties_insured.CorpId;
                                    discount.RegionId = properties_insured.RegionId;
                                    discount.CountryId = properties_insured.CountryId;
                                    discount.DomesticregId = properties_insured.DomesticregId;
                                    discount.StateProvId = properties_insured.StateProvId;
                                    discount.CityId = properties_insured.CityId;
                                    discount.OfficeId = properties_insured.OfficeId;
                                    discount.CaseSeqNo = properties_insured.CaseSeqNo;
                                    discount.HistSeqNo = properties_insured.HistSeqNo;
                                    discount.PropertyId = properties_insured.PropertyId.ToInt();
                                    discount.DiscountId = DiscountId.GetValueOrDefault();
                                    discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                                    discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                                    discount.NotePredefiniedId = notePredefiniedId;
                                    discount.discountStatus = DiscountStatus;
                                    discount.UserId = ObjServices.UserID.Value;

                                    if (!delete)
                                    {
                                        discount.PremiumAmount = descuento;
                                        discount.OldPremiumAmount = annualPremium;
                                        discount.Comment = txtNota.Text;
                                    }

                                    var pro_discount = ObjServices.oPropertyManager.SetPropertyInsuredDiscount(discount);
                                    #endregion

                                    #region Ejecutar proceso cargos/descuentos
                                    var result = ObjServices.oPropertyManager.SetPropertyInsuredApplyDiscountAndSurcharge(new Property.Insured
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
                                    #endregion
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Transport:
                                #region Proceso Transport

                                if (DiscountId == null || edit)
                                {
                                    notePredefiniedId = ddlTipoDescuento.SelectedValue.ToInt();
                                    annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                                    if (ddlPorcentajeDescuento.SelectedIndex > 0)
                                    {
                                        porcentaje_seleccionado = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.SelectedValue);
                                        descuento = annualPremium - (annualPremium * porcentaje_seleccionado.DiscountRuleValue.ToDecimal(0, true));

                                        NADiscountRuleId =
                                        NADetailId = 0;
                                    }

                                    //var montoDescuento = txtMontoDescuento.Text.ToDecimal(0, true);
                                    var montoDescuento = 0;
                                    if (montoDescuento > 0m)
                                    {
                                        //verificar si montoDescuento excede a % permitido por el role                        
                                        MaximoDescuentoPermitidoPorRole = ViewState["MaximoDescuentoPermitidoPorRole"] != null ? Convert.ToDecimal(ViewState["MaximoDescuentoPermitidoPorRole"]) / 100
                                                                                                                               : 0m;

                                        decimal MontoDescuento = annualPremium - (annualPremium * MaximoDescuentoPermitidoPorRole),
                                                MontoDescuentoMaximoPermitidoPorRole = annualPremium - MontoDescuento,
                                                montoPorcentaje = (montoDescuento / annualPremium);

                                        sumaPorcentajes = DiscountsTransport.Sum(p => p.PorcentajeDescuento.ToDecimal(0, true)) / 100;

                                        excede = montoDescuento > MontoDescuentoMaximoPermitidoPorRole || (montoPorcentaje + sumaPorcentajes) > MaximoDescuentoPermitidoPorRole;
                                        if (excede && !delete && !edit)
                                        {
                                            this.MessageBox("El monto excede al porcentaje máximo permitido.", Width: 500, Title: Warning);
                                            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                            ddlPorcentajeDescuento.Enabled = false;
                                            return;
                                        }
                                        else
                                            descuento = annualPremium - montoDescuento;
                                    }
                                }
                                else
                                {
                                    porcentaje_seleccionado.DiscountRuleId = DiscountRuleId;
                                    porcentaje_seleccionado.DiscountRuleDetailId = DiscountRuleDetailId;
                                    //notePredefiniedId = Convert.ToInt32(ViewState["NotePredefiniedId"]);
                                }

                                #region Verificar si los decuentos ya habian sido aplicados
                                if (!delete && !edit)
                                {
                                    if (DiscountsTransport.Count > 0)
                                    {
                                        bool aplicado = false;
                                        string msg = string.Empty;

                                        var descuentos = DiscountsTransport.Where(d => d.UserId == ObjServices.UserID.Value).ToList();
                                        if (descuentos.Count > 0)
                                        {
                                            foreach (var desc in descuentos)
                                            {
                                                if (desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }

                                                if (!edit && desc.NotePredefiniedId == notePredefiniedId)
                                                {
                                                    msg = TypeOfDiscountAlreadyApplied;
                                                    aplicado = true;
                                                    break;
                                                }
                                            }

                                            if (aplicado)
                                            {
                                                this.MessageBox(msg, Width: 500, Title: Warning);
                                                ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
                                                return;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                foreach (var trans_insured in tranportInsured)
                                {
                                    #region Guardar - Actualizar
                                    Transport.Insured.Discount discount = new Transport.Insured.Discount();

                                    discount.CorpId = trans_insured.CorpId;
                                    discount.RegionId = trans_insured.RegionId;
                                    discount.CountryId = trans_insured.CountryId;
                                    discount.DomesticregId = trans_insured.DomesticregId;
                                    discount.StateProvId = trans_insured.StateProvId;
                                    discount.CityId = trans_insured.CityId;
                                    discount.OfficeId = trans_insured.OfficeId;
                                    discount.CaseSeqNo = trans_insured.CaseSeqNo;
                                    discount.HistSeqNo = trans_insured.HistSeqNo;
                                    discount.TransportId = trans_insured.TransportId.ToInt();
                                    discount.DiscountId = DiscountId.GetValueOrDefault();
                                    discount.DiscountRuleId = porcentaje_seleccionado.DiscountRuleId == 0 ? NADiscountRuleId : porcentaje_seleccionado.DiscountRuleId;
                                    discount.DiscountRuleDetailId = porcentaje_seleccionado.DiscountRuleDetailId == 0 ? NADetailId : porcentaje_seleccionado.DiscountRuleDetailId;
                                    discount.NotePredefiniedId = notePredefiniedId;
                                    discount.DiscountStatus = DiscountStatus;
                                    discount.UserId = ObjServices.UserID.Value;

                                    if (!delete)
                                    {
                                        discount.PremiumAmount = descuento;
                                        discount.OldPremiumAmount = annualPremium;
                                        discount.Comment = txtNota.Text;
                                    }

                                    var pro_discount = ObjServices.oTransportManager.SetTransportInsuredDiscount(discount);
                                    #endregion

                                    #region Ejecutar proceso cargos/descuentos
                                    var result = ObjServices.oTransportManager.SetTransportInsuredApplyDiscountAndSurcharge(new Transport.Insured
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
                                    #endregion
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Vehicle:
                                break;
                            default:
                                break;
                        }
                        break;
                }

                #region Actualizar Flat Table
                ObjServices.UpdateTempTable(policy.PolicyNo, ObjServices.UserID.GetValueOrDefault());
                #endregion

                ddlPorcentajeDescuento.SelectedIndex = 0;

                ddlTipoDescuento.SelectedIndex = 0;

                btnClean.Enabled = true;

                #region Refrescar pagina IllustrationsVehicle
                var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;
                if (IllustrationsVehiclePage != null)
                {
                    IllustrationsVehiclePage.ShowApplyDiscountPopup();
                    //Header 
                    var IllustrationInformationUC = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCIllustrationInformation);

                    if (IllustrationInformationUC != null)
                        (IllustrationInformationUC as UCIllustrationInformation).FillData();

                    //Detalle
                    if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                        IllustrationsVehiclePage.FillVehiclesInformation();
                    else
                        if (ObjServices.ProductLine == Utility.ProductLine.AlliedLines)
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
                                case Utility.AlliedLinesType.Vehicle:
                                    break;
                            }
                        }

                }
                #endregion

                //this.ExcecuteJScript("setTimeout(\"SaveApplyDiscountSucessfully()\",10);");                

                Initialize();

                this.ExcecuteJScript("$('#ddlPorcentajeDescuento').trigger('change');");

                if (ObjServices.ProductLine == Utility.ProductLine.Auto)
                {
                    this.ExcecuteJScript("DropText();");

                    ddlPorcentajeDescuento.Enabled = txtMontoDescuento.Text == "0.00";
                    txtMontoDescuento.Enabled = ddlPorcentajeDescuento.SelectedIndex == 0;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.GetLastInnerException().Message;
                this.MessageBox(msg, Width: 500, Title: "Error");
            }
        }

        private void EditPorcentajeDescuento(Policy.VehicleInsured.Discount discount = null,
                                             Property.Insured.Discount DiscountsProperties = null,
                                             Airplane.Insured.Discount DiscountsAirplane = null,
                                             Bail.Insured.Discount DiscountsBail = null,
                                             Transport.Insured.Discount DiscountsTranport = null,
                                             Navy.Insured.Discount DiscountsNavy = null)
        {
            #region Auto
            if (discount != null)
            {
                if (discount.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == discount.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    txtMontoDescuento.Text = discount.MontoDescuento.ToString(CultureInfo.InvariantCulture);
                    txtCalculatedAmount.Text = discount.MontoDescuentoF.ToString(CultureInfo.InvariantCulture);
                }

                return;
            }
            #endregion

            #region Properties
            if (DiscountsProperties != null)
            {
                if (DiscountsProperties.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == DiscountsProperties.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else { txtMontoDescuento.Text = DiscountsProperties.MontoDescuento.ToString(CultureInfo.InvariantCulture); }
                return;
            }
            #endregion

            #region Airplane
            if (DiscountsAirplane != null)
            {
                if (DiscountsAirplane.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == DiscountsAirplane.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else { txtMontoDescuento.Text = DiscountsAirplane.MontoDescuento.ToString(CultureInfo.InvariantCulture); }
                return;
            }
            #endregion

            #region Bail
            if (DiscountsBail != null)
            {
                if (DiscountsBail.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == DiscountsBail.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else { txtMontoDescuento.Text = DiscountsBail.MontoDescuento.ToString(CultureInfo.InvariantCulture); }
                return;
            }
            #endregion

            #region Navy
            if (DiscountsNavy != null)
            {
                if (DiscountsNavy.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == DiscountsNavy.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else { txtMontoDescuento.Text = DiscountsNavy.MontoDescuento.ToString(CultureInfo.InvariantCulture); }
                return;
            }
            #endregion

            #region Tranport
            if (DiscountsTranport != null)
            {
                if (DiscountsTranport.DetailRuleNameKey != "N/A")
                {
                    for (int i = 0; i < ddlPorcentajeDescuento.Items.Count; i++)
                    {
                        if (ddlPorcentajeDescuento.Items[i].Value != "0")
                        {
                            string DiscountRuleValue = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountRule>(ddlPorcentajeDescuento.Items[i].Value).DiscountRuleValue;
                            if (DiscountRuleValue == DiscountsTranport.DetailRuleValue)
                            {
                                ddlPorcentajeDescuento.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else { txtMontoDescuento.Text = DiscountsTranport.MontoDescuento.ToString(CultureInfo.InvariantCulture); }
                return;
            }
            #endregion
        }

        public void edit()
        {
            int DiscountId = ViewState["DiscountId"] != null ? Convert.ToInt32(ViewState["DiscountId"]) : 0;
            if (DiscountId > 0)
            {
                FillDrops();

                switch (ObjServices.ProductLine)
                {
                    case Utility.ProductLine.Auto:
                        #region Proceso Auto
                        Policy.VehicleInsured.Discount discount = Discounts.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                        if (discount != null)
                        {
                            EditPorcentajeDescuento(discount);

                            ddlTipoDescuento.SelectedValue = discount.NotePredefiniedId.ToString();
                            txtPorcentajeDescuento.Text = discount.DetailRuleNameKey;

                            string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                            //eliminar descuento seleccionado
                            save(false, DiscountId);

                            txtNota.Text = Comment;

                            EditPorcentajeDescuento(discount);

                            ddlTipoDescuento.SelectedValue = discount.NotePredefiniedId.ToString();
                            txtPorcentajeDescuento.Text = discount.DetailRuleNameKey;
                        }
                        #endregion
                        break;
                    case Utility.ProductLine.AlliedLines:
                        switch (ObjServices.AlliedLinesProductBehavior)
                        {
                            case Utility.AlliedLinesType.Airplane:
                                #region Proceso AirPlane
                                var discountAirPlane = DiscountsAirplane.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                                if (discountAirPlane != null)
                                {
                                    EditPorcentajeDescuento(DiscountsAirplane: discountAirPlane);

                                    ddlTipoDescuento.SelectedValue = discountAirPlane.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountAirPlane.DetailRuleNameKey;

                                    string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                                    //eliminar descuento seleccionado
                                    save(false, DiscountId);

                                    txtNota.Text = Comment;

                                    EditPorcentajeDescuento(DiscountsAirplane: discountAirPlane);

                                    ddlTipoDescuento.SelectedValue = discountAirPlane.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountAirPlane.DetailRuleNameKey;
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Bail:
                                #region Proceso Bail
                                var discountBail = DiscountsBail.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                                if (discountBail != null)
                                {
                                    EditPorcentajeDescuento(DiscountsBail: discountBail);

                                    ddlTipoDescuento.SelectedValue = discountBail.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountBail.DetailRuleNameKey;

                                    string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                                    //eliminar descuento seleccionado
                                    save(false, DiscountId);

                                    txtNota.Text = Comment;

                                    EditPorcentajeDescuento(DiscountsBail: discountBail);

                                    ddlTipoDescuento.SelectedValue = discountBail.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountBail.DetailRuleNameKey;
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Navy:
                                #region Proceso Navy
                                var discountNavy = DiscountsNavy.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                                if (discountNavy != null)
                                {
                                    EditPorcentajeDescuento(DiscountsNavy: discountNavy);

                                    ddlTipoDescuento.SelectedValue = discountNavy.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountNavy.DetailRuleNameKey;

                                    string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                                    //eliminar descuento seleccionado
                                    save(false, DiscountId);

                                    txtNota.Text = Comment;

                                    EditPorcentajeDescuento(DiscountsNavy: discountNavy);

                                    ddlTipoDescuento.SelectedValue = discountNavy.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountNavy.DetailRuleNameKey;
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Property:
                                #region Proceso Property

                                var discountProp = DiscountsProperties.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                                if (discountProp != null)
                                {
                                    EditPorcentajeDescuento(DiscountsProperties: discountProp);

                                    ddlTipoDescuento.SelectedValue = discountProp.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountProp.DetailRuleNameKey;

                                    string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                                    //eliminar descuento seleccionado
                                    save(false, DiscountId);

                                    txtNota.Text = Comment;

                                    EditPorcentajeDescuento(DiscountsProperties: discountProp);

                                    ddlTipoDescuento.SelectedValue = discountProp.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountProp.DetailRuleNameKey;
                                }
                                #endregion
                                break;
                            case Utility.AlliedLinesType.Transport:
                                #region Proceso Transport
                                var discountTransp = DiscountsTransport.FirstOrDefault(v => v.DiscountId == DiscountId && v.UserId == ObjServices.UserID);

                                if (discountTransp != null)
                                {
                                    EditPorcentajeDescuento(DiscountsTranport: discountTransp);

                                    ddlTipoDescuento.SelectedValue = discountTransp.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountTransp.DetailRuleNameKey;

                                    string Comment = ViewState["Comment"] != null ? Convert.ToString(ViewState["Comment"]) : default(string);

                                    //eliminar descuento seleccionado
                                    save(false, DiscountId);

                                    txtNota.Text = Comment;

                                    EditPorcentajeDescuento(DiscountsTranport: discountTransp);

                                    ddlTipoDescuento.SelectedValue = discountTransp.NotePredefiniedId.ToString();
                                    txtPorcentajeDescuento.Text = discountTransp.DetailRuleNameKey;
                                }
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


            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                this.ExcecuteJScript("DropText();");

                ddlPorcentajeDescuento.Enabled = txtMontoDescuento.Text == "0.00";
                txtMontoDescuento.Enabled = ddlPorcentajeDescuento.SelectedIndex == 0;
            }

            txtCalculatedAmount.Text = ViewState["MontoDescuentoF"] != null ? ViewState["MontoDescuentoF"].ToString() : "0.00";
        }

        public void FillData()
        {
            hdnCalculoPorcentaje.Value = "0.00";

            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    #region Fill GridView gvVehiculos
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
                        v.VehicleDesc = string.Format("{0} {1} {2}", v.MakeDesc, v.ModelDesc, v.Year);
                        v.InsuredAmount = v.VehicleValue;
                        return v;
                    });

                    gvVehiculos.DataSource = dataVehicle;
                    gvVehiculos.DataBind();
                    gvVehiculos.FocusedRowIndex = -1;

                    hdnCalculoPorcentaje.Value = dataVehicle.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");

                    #endregion

                    #region Fill GridView Descuentos
                    if (dataVehicle.ToList().Count > 0)
                    {
                        vehiclesInsured = dataVehicle.ToList();

                        //var policy = ObjServices.oPolicyManager.GetPolicy(ObjServices.Corp_Id,
                        //                                                  ObjServices.Region_Id,
                        //                                                  ObjServices.Country_Id,
                        //                                                  ObjServices.Domesticreg_Id,
                        //                                                  ObjServices.State_Prov_Id,
                        //                                                  ObjServices.City_Id,
                        //                                                  ObjServices.Office_Id,
                        //                                                  ObjServices.Case_Seq_No,
                        //                                                  ObjServices.Hist_Seq_No);

                        //decimal annualPremium = policy.AnnualPremium != null ? policy.AnnualPremium.Value : 0m;

                        var vehicle = vehiclesInsured.FirstOrDefault();

                        var discounts = ObjServices.oPolicyManager.GetVehicleInsuredDiscount(new Policy.VehicleInsured.Discount.Key
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
                            InsuredVehicleId = vehicle.InsuredVehicleId.Value,
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
                        });

                        Discounts = discounts.ToList();

                        decimal sumaPrimaTotal = dataVehicle.Sum(v => v.PremiumAmount).Value,
                                sumaDescuentos = discounts.Sum(d => d.MontoDescuento);

                        //lblTotalPremiumDiscounts.Text = (sumaDescuentos > 0m ? (sumaPrimaTotal + sumaDescuentos) : 0m).ToFormatCurrency();
                        lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                        gvRecargos.DataSource = discounts;
                        gvRecargos.DataBind();
                        gvRecargos.FocusedRowIndex = -1;
                    }
                    #endregion
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            #region Fill GridView gvAirPlane
                            var dataAirplane = ObjServices.GetDataAirPlane().Select(v =>
                            {
                                v.Name = string.Format("{0} {1}", v.BrandModel, v.Year);
                                return v;
                            });

                            gvAirPlane.DataSource = dataAirplane;
                            gvAirPlane.DataBind();
                            gvAirPlane.FocusedRowIndex = -1;

                            hdnCalculoPorcentaje.Value = dataAirplane.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");
                            #endregion

                            #region Fill GridView Descuentos
                            if (dataAirplane.ToList().Count > 0)
                            {
                                airPlaneInsured = dataAirplane.ToList();

                                var plane = airPlaneInsured.FirstOrDefault();

                                var discounts = ObjServices.oAirPlaneManager.GetAirplaneInsuredDiscount(new Airplane.Insured.Discount.Key
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
                                    AirplaneId = plane.AirplaneId.ToInt(),
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
                                });

                                DiscountsAirplane = discounts.ToList();

                                decimal sumaPrimaTotal = dataAirplane.Sum(v => v.PremiumAmount.GetValueOrDefault()),
                                        sumaDescuentos = DiscountsAirplane.Sum(d => d.MontoDescuento);

                                lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                                gvRecargos.DataSource = discounts;
                                gvRecargos.DataBind();
                                gvRecargos.FocusedRowIndex = -1;
                            }
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Bail:
                            #region Fill GridView gvBail
                            var dataBail = ObjServices.GetDataBail().Select(v =>
                            {
                                v.EquipmentQty = v.EquipmentQty;
                                return v;
                            });

                            gvBail.DataSource = dataBail;
                            gvBail.DataBind();
                            gvBail.FocusedRowIndex = -1;

                            hdnCalculoPorcentaje.Value = dataBail.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");

                            #endregion

                            #region Fill GridView Descuentos
                            if (dataBail.ToList().Count > 0)
                            {
                                bailInsured = dataBail.ToList();

                                var bail = bailInsured.FirstOrDefault();

                                var discounts = ObjServices.oBailManager.GetBailInsuredDiscount(new Bail.Insured.Discount.Key
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
                                    BailId = bail.BailId.ToInt(),
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
                                });

                                DiscountsBail = discounts.ToList();

                                decimal sumaPrimaTotal = dataBail.Sum(v => v.PremiumAmount.GetValueOrDefault()),
                                        sumaDescuentos = DiscountsBail.Sum(d => d.MontoDescuento);

                                lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                                gvRecargos.DataSource = discounts;
                                gvRecargos.DataBind();
                                gvRecargos.FocusedRowIndex = -1;
                            }
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Navy:
                            #region Fill GridView gvNavy
                            var dataNavy = ObjServices.GetDataNavy().Select(v =>
                            {
                                v.Name = string.Format("{0} {1}", v.BrandModel, v.Year);
                                return v;
                            });

                            gvNavy.DataSource = dataNavy;
                            gvNavy.DataBind();
                            gvNavy.FocusedRowIndex = -1;

                            hdnCalculoPorcentaje.Value = dataNavy.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");

                            #endregion

                            #region Fill GridView Descuentos
                            if (dataNavy.ToList().Count > 0)
                            {
                                navyInsured = dataNavy.ToList();

                                var navy = navyInsured.FirstOrDefault();

                                var discounts = ObjServices.oNavyManager.GetNavyInsuredDiscount(new Navy.Insured.Discount.Key
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
                                    NavyId = navy.NavyId.ToInt(),
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
                                });

                                DiscountsNavy = discounts.ToList();

                                decimal sumaPrimaTotal = dataNavy.Sum(v => v.PremiumAmount.GetValueOrDefault()),
                                        sumaDescuentos = DiscountsNavy.Sum(d => d.MontoDescuento);

                                lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                                gvRecargos.DataSource = discounts;
                                gvRecargos.DataBind();
                                gvRecargos.FocusedRowIndex = -1;
                            }
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Property:
                            #region Fill GridView gvProperty
                            var dataProperty = ObjServices.GetDataProperty();

                            gvProperty.DataSource = dataProperty;
                            gvProperty.DataBind();
                            gvProperty.FocusedRowIndex = -1;

                            hdnCalculoPorcentaje.Value = dataProperty.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");

                            #endregion

                            #region Fill GridView Descuentos
                            if (dataProperty.ToList().Count > 0)
                            {
                                propertiesInsured = dataProperty.ToList();

                                var prope = propertiesInsured.FirstOrDefault();

                                var discounts = ObjServices.oPropertyManager.GetPropertyInsuredDiscount(new Property.Insured.Discount.Key
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
                                    PropertyId = prope.PropertyId.ToInt(),
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
                                });

                                DiscountsProperties = discounts.ToList();

                                decimal sumaPrimaTotal = dataProperty.Sum(v => v.PremiumAmount),
                                        sumaDescuentos = DiscountsProperties.Sum(d => d.MontoDescuento);

                                //lblTotalPremiumDiscounts.Text = (sumaDescuentos > 0m ? (sumaPrimaTotal + sumaDescuentos) : 0m).ToFormatCurrency();
                                lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                                gvRecargos.DataSource = discounts;
                                gvRecargos.DataBind();
                                gvRecargos.FocusedRowIndex = -1;
                            }
                            #endregion
                            break;
                        case Utility.AlliedLinesType.Transport:
                            #region Fill GridView gvTransport
                            var dataTransport = ObjServices.GetDataTransport().Select(v =>
                            {
                                //v.Name = string.Format("{0} {1} {2}", v.Brand, v.Model, v.Year);
                                return v;
                            });

                            gvTransport.DataSource = dataTransport;
                            gvTransport.DataBind();
                            gvTransport.FocusedRowIndex = -1;

                            hdnCalculoPorcentaje.Value = dataTransport.Sum(x => x.PremiumAmount).ToFormatNumeric().Replace(",", "");

                            #endregion

                            #region Fill GridView Descuentos
                            if (dataTransport.ToList().Count > 0)
                            {
                                tranportInsured = dataTransport.ToList();

                                var trasn = tranportInsured.FirstOrDefault();

                                var discounts = ObjServices.oTransportManager.GetTransportInsuredDiscount(new Transport.Insured.Discount.Key
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
                                    TransportId = trasn.TransportId.GetValueOrDefault(),
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
                                });

                                DiscountsTransport = discounts.ToList();

                                decimal sumaPrimaTotal = dataTransport.Sum(v => v.PremiumAmount.GetValueOrDefault()),
                                        sumaDescuentos = DiscountsTransport.Sum(d => d.MontoDescuento);

                                lblTotalPremiumDiscounts.Text = (sumaPrimaTotal).ToFormatCurrency();

                                gvRecargos.DataSource = discounts;
                                gvRecargos.DataBind();
                                gvRecargos.FocusedRowIndex = -1;
                            }
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

        public void Initialize()
        {
            ClearData();
            FillData();
            FillDrops();
        }

        public void ClearData()
        {
            vehiclesInsured = new List<Policy.VehicleInsured>();
            Discounts = new List<Policy.VehicleInsured.Discount>() { };

            txtMontoDescuento.Text =            
            txtCalculatedAmount.Text = "0.00";

            txtPorcentajeDescuento.Text = string.Empty;

            txtNota.Text = string.Empty;

            gvVehiculos.DataSource = null;
            gvVehiculos.DataBind();
            gvVehiculos.FocusedRowIndex = -1;

            gvProperty.DataSource = null;
            gvProperty.DataBind();
            gvProperty.FocusedRowIndex = -1;

            gvNavy.DataSource = null;
            gvNavy.DataBind();
            gvNavy.FocusedRowIndex = -1;

            gvBail.DataSource = null;
            gvBail.DataBind();
            gvBail.FocusedRowIndex = -1;

            gvAirPlane.DataSource = null;
            gvAirPlane.DataBind();
            gvAirPlane.FocusedRowIndex = -1;

            gvTransport.DataSource = null;
            gvTransport.DataBind();
            gvTransport.FocusedRowIndex = -1;

            gvRecargos.DataSource = null;
            gvRecargos.DataBind();
            gvRecargos.FocusedRowIndex = -1;

            ViewState["DiscountId"] = null;
            ViewState["edit"] = false;
            ViewState["Delete"] = false;
            ViewState["DiscountRuleId"] = null;
            ViewState["DiscountRuleDetailId"] = null;
            ViewState["NotePredefiniedId"] = null;
            ViewState["Comment"] = string.Empty;
            ViewState["MaximoDescuentoPermitidoPorRole"] = null;
            ViewState["NADiscountRuleId"] = null;
            ViewState["NADetailId"] = null;
        }

        private void FillDrops()
        {
            #region Tipo de Descuento
            ObjServices.FillReason(ddlTipoDescuento,
                                   Utility.ReasonPredefinieds.DiscountIllustrationReason,
                                   Utility.EFamilyProductType.Auto.ToString());
            ddlTipoDescuento.SelectedIndex = 0;
            #endregion

            #region Roles
            string role = string.Empty;
            if (ObjServices.IsSuscripcionManagerQuotRole) { role = Utility.DiscountRoles.SuscripcionManagerCot.ToString(); }
            if (ObjServices.IsDirectorQuotRole) { role = Utility.DiscountRoles.DirectorCot.ToString(); }
            if (ObjServices.IsSucripcionDirectorQuotRole) { role = Utility.DiscountRoles.DirectorSuscricion.ToString(); }
            if (ObjServices.isUserCot) { role = Utility.DiscountRoles.UserCot.ToString(); }
            if (ObjServices.isDescuentocot) { role = Utility.DiscountRoles.DescuentoCot.ToString(); }
            if (ObjServices.isDescuentoCot100Porc) { role = Utility.DiscountRoles.DescuentoCot100Porc.ToString(); }
            #endregion

            #region Porcentajes de Descuento
            var lstDiscountRules = ObjServices.oPolicyManager.GetDiscountRulesAndDetails(new Policy.DParameter
            {
                Active = true,
                CorpId = ObjServices.Corp_Id,
                NameKey = Utility.DiscountRules.SubscriptionDiscountRulesByRoleType.ToString(),
                Role = role
            }).ToList();

            if (!lstDiscountRules.Any())
            {
                ddlPorcentajeDescuento.Items.Add(new ListItem(Resources.Select, "0"));
                ddlPorcentajeDescuento.SelectedIndex = 0;

                txtPorcentajeDescuento.Text = string.Empty;

                ddlTipoDescuento.Enabled =
                ddlPorcentajeDescuento.Enabled =
                btnApplyDiscount.Enabled =
                btnClean.Enabled = false;

                return;
            }

            int suma_porcentajes = Discounts.Count > 0 ? Convert.ToInt32(Discounts.Sum(d => d.PorcentajeDescuento.ToDecimal(0, true))) : 0,
                contador = 0;

            #region Get DiscountRuleId and DetailId
            var firstRule = lstDiscountRules.FirstOrDefault(d => d.DetailNameKey == "N/A" || d.DetailNameKey == "0.00");

            int NADiscountRuleId = firstRule.DiscountRuleId,
                NADetailId = firstRule.DetailId;

            ViewState["NADiscountRuleId"] = NADiscountRuleId;
            ViewState["NADetailId"] = NADetailId;
            #endregion

            var DiscountRules = lstDiscountRules.Where(d => d.DetailNameKey != "N/A" ||
                                                            d.DetailNameKey != "0.00").ToList();

            var MaximoDescuentoPermitidoPorRole = DiscountRules.Max(d => d.DetailRuleValue);
            ViewState["MaximoDescuentoPermitidoPorRole"] = MaximoDescuentoPermitidoPorRole;

            bool edit = ViewState["edit"] != null ? Convert.ToBoolean(ViewState["edit"]) : false;
            if (edit)
                lstDiscountRules.Clear();

            #region Sumar Porcentajes y Filtrar lstDiscountRules
            //if (!edit)
            {
                if (suma_porcentajes > 0)
                {
                    contador = DiscountRules.Count - suma_porcentajes;

                    var porcentajes = new List<Policy.Vehicle.Discount.RulesAndDetails>() { };

                    for (int i = 0; i < contador; i++)
                        porcentajes.Add(DiscountRules[i]);

                    lstDiscountRules = porcentajes;
                }
            }
            #endregion

            var ListDiscountRules = lstDiscountRules.Where(d => d.DetailNameKey != "N/A" || d.DetailNameKey != "0.00").Select(o => new DiscountRule
            {
                DiscountRuleId = o.DiscountRuleId,
                DiscountRuleDetailId = o.DetailId,
                DiscountRuleNameKey = o.NameKey,
                DiscountRuleValue = o.DetailRuleValue,
                DiscountRuleDetailNameKey = o.DetailNameKey
            }).ToList();

            var lstDiscount = new Dictionary<string, string>();
            lstDiscount.Add("0", Resources.Select);

            ListDiscountRules.ForEach(o => lstDiscount.Add(o.ToJSON(), o.DiscountRuleValue.ToDecimal().ToPercent(false)));

            ddlPorcentajeDescuento.DataSource = lstDiscount;
            ddlPorcentajeDescuento.DataTextField = "Value";
            ddlPorcentajeDescuento.DataValueField = "Key";
            ddlPorcentajeDescuento.DataBind();
            ddlPorcentajeDescuento.SelectedIndex = 0;

            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                ddlPorcentajeDescuento.Enabled = (lstDiscount.Count() > 1);

                this.ExcecuteJScript("DropText();");

                ddlPorcentajeDescuento.Enabled = txtMontoDescuento.Text == "0.00";
                txtMontoDescuento.Enabled = ddlPorcentajeDescuento.SelectedIndex == 0;
            }
            #endregion
        }

        protected void UpdatePanel3_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                             .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();

            methodInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { sender as UpdatePanel });
        }

        protected void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            bool edit = ViewState["edit"] != null ? Convert.ToBoolean(ViewState["edit"]) : false;
            int? discount_id = ViewState["DiscountId"] != null ? (int?)ViewState["DiscountId"] : null;
            int? DiscountId = edit ? discount_id : null;

            save(true, DiscountId);
        }

        protected void gvRecargos_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            string[] KeyFieldValues = e.KeyValue.ToString().Split('|');

            int DiscountId = KeyFieldValues[0].ToInt(),
                DiscountRuleId = KeyFieldValues[1].ToInt(),
                DiscountRuleDetailId = KeyFieldValues[2].ToInt(),
                NotePredefiniedId = KeyFieldValues[3].ToInt();

            string Comment = Convert.ToString(KeyFieldValues[4]);

            var MontoDescuentoF = Convert.ToString(KeyFieldValues[5]);

            #region set ViewState values
            ViewState["DiscountId"] = DiscountId;
            ViewState["DiscountRuleId"] = DiscountRuleId;
            ViewState["DiscountRuleDetailId"] = DiscountRuleDetailId;
            ViewState["NotePredefiniedId"] = NotePredefiniedId;
            ViewState["Comment"] = Comment;
            ViewState["MontoDescuentoF"] = MontoDescuentoF;

            ViewState["edit"] = false;
            ViewState["Delete"] = false;
            #endregion

            var command = e.CommandArgs.CommandName;
            switch (command)
            {
                case "Edit":
                    #region Edit
                    ViewState["edit"] = true;
                    edit();
                    this.ExcecuteJScript("$('#ddlPorcentajeDescuento').trigger('change');");
                    btnClean.Enabled = false;
                    #endregion

                    break;
                case "Delete":
                    #region Delete
                    ViewState["Delete"] = true;
                    save(false, DiscountId);
                    #endregion

                    break;
            }

            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();

            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).FillVehiclesInformation();

            if (ObjServices.ProductLine == Utility.ProductLine.Auto)
            {
                this.ExcecuteJScript("DropText();");

                ddlPorcentajeDescuento.Enabled = txtMontoDescuento.Text == "0.00";
                txtMontoDescuento.Enabled = ddlPorcentajeDescuento.SelectedIndex == 0;
            }
        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            Initialize();
            ((WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle)Page).ShowApplyDiscountPopup();
        }

        protected void gvRecargos_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Comment")
            {
                if (e.Value != null)
                {
                    string cellValue = e.Value.ToString();
                    if (cellValue.Length > 10)
                    {
                        e.DisplayText = cellValue.Substring(0, 10) + "...";
                    }
                }
            }
        }

        protected void gvRecargos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Comment")
            {
                if (e.CellValue != null)
                {
                    e.Cell.ToolTip = e.CellValue.ToString();
                }
            }
        }

        #region Grid PreRender
        protected void gvVehiculos_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvRecargos_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvProperty_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvAirPlanePreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvNavy_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvBail_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        protected void gvTransport_PreRender(object sender, EventArgs e)
        {
            TranslateColumnsAspxGrid((ASPxGridView)sender);
        }

        private void TranslateColumnsAspxGrid(ASPxGridView grid)
        {
            grid.TranslateColumnsAspxGrid();
        }
        #endregion

        protected void btnClosePopupDiscount_Click(object sender, EventArgs e)
        {
            var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;
            if (IllustrationsVehiclePage != null)
                IllustrationsVehiclePage.HideApplyDiscountPopup();
        }

        protected void gvVehiculos_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
    }
}