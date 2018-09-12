using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.Products
{
    public partial class UCCoverages : UC, IUC
    {
        public void Translator(string Lang) { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        public int UniqueId
        {
            get { return ViewState["UniqueId"].ToInt(); }
            set { ViewState["UniqueId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCoverage_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void FillData()
        {
            var Format = "#0,0.000000";

            switch (ObjServices.AlliedLinesProductBehavior)
            {
                case Utility.AlliedLinesType.Airplane:
                    var dataCoverageAirPlane = ObjServices.oAirPlaneManager.GetAirPlaneInsuredCoverage(new Airplane.Insured.Coverage.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueAirplaneId = this.UniqueId
                    }).Select(c => new
                    {
                        CurrencyId = c.CurrencyId,
                        UnitaryPrice = c.UnitaryPrice > 0 ? c.UnitaryPrice.ToFormatNumeric() : "-",
                        PackagePrice = c.PackagePrice,
                        DeductibleAmount = c.DeductibleAmount,
                        DeductiblePercentage = c.DeductiblePercentage.HasValue && c.DeductiblePercentage.Value > 0 ? c.DeductiblePercentage.Value.Truncate() + "%" : "-",
                        ManualDeductibleAmount = c.ManualDeductibleAmount,
                        ManualDeductiblePercentage = c.ManualDeductiblePercentage,
                        CoverageLimit = c.CoverageLimit.HasValue && c.CoverageLimit.Value > 0 ? c.CoverageLimit.ToFormatNumeric() : "-",
                        CoverageStatus = c.CoverageStatus,
                        CorpId = c.CorpId,
                        UniqueAirplaneId = c.UniqueAirplaneId,
                        RegionId = c.RegionId,
                        CountryId = c.CountryId,
                        BlTypeId = c.BlTypeId,
                        BlId = c.BlId,
                        ProductId = c.ProductId,
                        VehicleTypeId = c.VehicleTypeId,
                        GroupId = c.GroupId,
                        CoinsurancePercentage = c.CoinsurancePercentage.HasValue && c.CoinsurancePercentage.Value > 0 ? c.CoinsurancePercentage.Value.Truncate() + "%" : "-",
                        CoverageTypeId = c.CoverageTypeId,
                        CoverageId = c.CoverageId,
                        CoverageTypeDesc = c.CoverageTypeDesc,
                        GroupDesc = c.GroupDesc,
                        CoverageDesc = c.CoverageDesc,
                        PremiumPercentage = c.PremiumPercentage.HasValue && c.PremiumPercentage.Value > 0 ? c.PremiumPercentage.ToFormatNumeric(Format) : "-"
                    });

                    gvCoveragesIL.DataSource = dataCoverageAirPlane;

                    break;
                case Utility.AlliedLinesType.Bail:
                    var dataCoverageBail = ObjServices.oBailManager.GetBailInsuredCoverage(new Bail.Insured.Coverage.Key
                   {
                       CorpId = ObjServices.Corp_Id,
                       UniqueBailId = this.UniqueId
                   }).Select(c => new
                   {
                       CurrencyId = c.CurrencyId,
                       UnitaryPrice = c.UnitaryPrice.HasValue && c.UnitaryPrice.Value > 0 ? c.UnitaryPrice.ToFormatNumeric() : "-",
                       PackagePrice = c.PackagePrice,
                       DeductibleAmount = c.DeductibleAmount,
                       DeductiblePercentage = c.DeductiblePercentage.HasValue && c.DeductiblePercentage.Value > 0 ? c.DeductiblePercentage.Value.Truncate() + "%" : "-",
                       ManualDeductibleAmount = c.ManualDeductibleAmount,
                       ManualDeductiblePercentage = c.ManualDeductiblePercentage,
                       CoverageLimit = c.CoverageLimit.HasValue && c.CoverageLimit.Value > 0 ? c.CoverageLimit.ToFormatNumeric() : "-",
                       CoverageStatus = c.CoverageStatus,
                       CoinsurancePercentage = c.CoinsurancePercentage.HasValue && c.CoinsurancePercentage.Value > 0 ? c.CoinsurancePercentage.Value.Truncate() + "%" : "-",
                       CorpId = c.CorpId,
                       UniqueBailId = c.UniqueBailId,
                       RegionId = c.RegionId,
                       CountryId = c.CountryId,
                       BlTypeId = c.BlTypeId,
                       BlId = c.BlId,
                       ProductId = c.ProductId,
                       VehicleTypeId = c.VehicleTypeId,
                       GroupId = c.GroupId,
                       CoverageTypeId = c.CoverageTypeId,
                       CoverageId = c.CoverageId,
                       CoverageTypeDesc = c.CoverageTypeDesc,
                       GroupDesc = c.GroupDesc,
                       CoverageDesc = c.CoverageDesc,
                       PremiumPercentage = c.PremiumPercentage.HasValue && c.PremiumPercentage.Value > 0 ? c.PremiumPercentage.ToFormatNumeric(Format) : "-"
                   });

                    gvCoveragesIL.DataSource = dataCoverageBail;
                    break;
                case Utility.AlliedLinesType.Navy:
                    var dataCoverageNavy = ObjServices.oNavyManager.GetNavyInsuredCoverage(new Navy.Insured.Coverage.Key
                   {
                       CorpId = ObjServices.Corp_Id,
                       UniqueNavyId = this.UniqueId
                   }).Select(c => new
                   {
                       CurrencyId = c.CurrencyId,
                       UnitaryPrice = c.UnitaryPrice.HasValue && c.UnitaryPrice.Value > 0 ? c.UnitaryPrice.ToFormatNumeric() : "-",
                       PackagePrice = c.PackagePrice,
                       DeductibleAmount = c.DeductibleAmount,
                       DeductiblePercentage = c.DeductiblePercentage.HasValue && c.DeductiblePercentage.Value > 0 ? c.DeductiblePercentage.Value.Truncate() + "%" : "-",
                       ManualDeductibleAmount = c.ManualDeductibleAmount,
                       ManualDeductiblePercentage = c.ManualDeductiblePercentage,
                       CoverageLimit = c.CoverageLimit.HasValue && c.CoverageLimit.Value > 0 ? c.CoverageLimit.ToFormatNumeric() : "-",
                       CoverageStatus = c.CoverageStatus,
                       CoinsurancePercentage = c.CoinsurancePercentage.HasValue && c.CoinsurancePercentage.Value > 0 ? c.CoinsurancePercentage.Value.Truncate() + "%" : "-",
                       CorpId = c.CorpId,
                       UniqueNavyId = c.UniqueNavyId,
                       RegionId = c.RegionId,
                       CountryId = c.CountryId,
                       BlTypeId = c.BlTypeId,
                       BlId = c.BlId,
                       ProductId = c.ProductId,
                       VehicleTypeId = c.VehicleTypeId,
                       GroupId = c.GroupId,
                       CoverageTypeId = c.CoverageTypeId,
                       CoverageId = c.CoverageId,
                       CoverageTypeDesc = c.CoverageTypeDesc,
                       GroupDesc = c.GroupDesc,
                       CoverageDesc = c.CoverageDesc,
                       PremiumPercentage = c.PremiumPercentage.HasValue && c.PremiumPercentage.Value > 0 ? c.PremiumPercentage.ToFormatNumeric(Format) : "-"
                   });

                    gvCoveragesIL.DataSource = dataCoverageNavy;
                    break;
                case Utility.AlliedLinesType.Property:
                    var dataCoverageProperty = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                     {
                         corpId = ObjServices.Corp_Id,
                         uniquePropertyId = this.UniqueId
                     }).Select(c => new
                     {
                         CurrencyId = c.CurrencyId,
                         UnitaryPrice = c.UnitaryPrice > 0 ? c.UnitaryPrice.ToFormatNumeric() : "-",
                         PackagePrice = c.PackagePrice,
                         DeductibleAmount = c.DeductibleAmount,
                         //DeductiblePercentage = c.DeductiblePercentage.HasValue && c.DeductiblePercentage.Value > 0 ? c.DeductiblePercentage.Value.Truncate() + "%" : "-",
                         ManualDeductibleAmount = c.ManualDeductibleAmount,
                         ManualDeductiblePercentage = c.ManualDeductiblePercentage,
                         CoverageLimit = c.CoverageLimit.HasValue && c.CoverageLimit.Value > 0 ? c.CoverageLimit.ToFormatNumeric() : "-",
                         CoverageStatus = c.CoverageStatus,
                         CoinsurancePercentage = c.CoinsurancePercentage.HasValue && c.CoinsurancePercentage.Value > 0 ? c.CoinsurancePercentage.Value.Truncate() + "%" : "-",
                         CorpId = c.CorpId,
                         UniquePropertyId = c.UniquePropertyId,
                         RegionId = c.RegionId,
                         CountryId = c.CountryId,
                         BlTypeId = c.BlTypeId,
                         BlId = c.BlId,
                         ProductId = c.ProductId,
                         VehicleTypeId = c.VehicleTypeId,
                         GroupId = c.GroupId,
                         CoverageTypeId = c.CoverageTypeId,
                         CoverageId = c.CoverageId,
                         CoverageTypeDesc = c.CoverageTypeDesc,
                         GroupDesc = c.GroupDesc,
                         CoverageDesc = c.CoverageDesc,
                         PremiumPercentage = c.PremiumPercentage.HasValue && c.PremiumPercentage.Value > 0 ? c.PremiumPercentage.ToFormatNumeric(Format) : "-",

                         DeductiblePercentage =
                          c.DeductiblePercentage.HasValue
                          ?
                          !c.DeductibleInDay.Value
                          ?
                           c.DeductiblePercentage.Value.Truncate() + "%"
                          :
                           c.DeductiblePercentage.Value.Truncate() + " en dias"
                          :
                           "-"

                     });

                    gvCoveragesIL.DataSource = dataCoverageProperty;

                    break;
                case Utility.AlliedLinesType.Transport:
                    var dataCoverageTransport = ObjServices.oTransportManager.GetTransportInsuredCoverage(new Transport.Insured.Coverage.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueTransportId = this.UniqueId
                    }).Select(c => new
                    {
                        CurrencyId = c.CurrencyId,
                        UnitaryPrice = c.UnitaryPrice.HasValue && c.UnitaryPrice.Value > 0 ? c.UnitaryPrice.ToFormatNumeric() : "-",
                        PackagePrice = c.PackagePrice,
                        DeductibleAmount = c.DeductibleAmount,
                        DeductiblePercentage = c.DeductiblePercentage.HasValue && c.DeductiblePercentage.Value > 0 ? c.DeductiblePercentage.Value.Truncate() + "%" : "-",
                        ManualDeductibleAmount = c.ManualDeductibleAmount,
                        ManualDeductiblePercentage = c.ManualDeductiblePercentage,
                        CoverageLimit = c.CoverageLimit.HasValue && c.CoverageLimit.Value > 0 ? c.CoverageLimit.ToFormatNumeric() : "-",
                        CoverageStatus = c.CoverageStatus,
                        CorpId = c.CorpId,
                        UniqueTransportId = c.UniqueTransportId,
                        RegionId = c.RegionId,
                        CountryId = c.CountryId,
                        BlTypeId = c.BlTypeId,
                        BlId = c.BlId,
                        ProductId = c.ProductId,
                        VehicleTypeId = c.VehicleTypeId,
                        CoinsurancePercentage = c.CoinsurancePercentage.HasValue && c.CoinsurancePercentage.Value > 0 ? c.CoinsurancePercentage.Value.Truncate() + "%" : "-",
                        GroupId = c.GroupId,
                        CoverageTypeId = c.CoverageTypeId,
                        CoverageId = c.CoverageId,
                        CoverageTypeDesc = c.CoverageTypeDesc,
                        GroupDesc = c.GroupDesc,
                        CoverageDesc = c.CoverageDesc,
                        PremiumPercentage = c.PremiumPercentage.HasValue && c.PremiumPercentage.Value > 0 ? c.PremiumPercentage.ToFormatNumeric(Format) : "-"
                    });

                    gvCoveragesIL.DataSource = dataCoverageTransport;
                    break;
            }

            gvCoveragesIL.DataBind();
            gvCoveragesIL.GroupBy(gvCoveragesIL.Columns["CoverageTypeDesc"]);
            gvCoveragesIL.ExpandAll();

            //Ocultar o Mostrar las columnas Prima y Tasa
            var Premium = gvCoveragesIL.getThisColumn("Premium");
            var Rate = gvCoveragesIL.getThisColumn("Rate");
            Premium.Visible = ObjServices.IsViewPrimeAndRateCot;
            Rate.Visible = ObjServices.IsViewPrimeAndRateCot;
            hdnHideOrShowPrimeAndRate.Value = ObjServices.IsViewPrimeAndRateCot.ToString().ToLower();
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {

        }

        protected void gvCoverage_PreRender(object sender, EventArgs e)
        {
            (sender as DevExpress.Web.ASPxGridView).TranslateColumnsAspxGrid();
        }
    }
}