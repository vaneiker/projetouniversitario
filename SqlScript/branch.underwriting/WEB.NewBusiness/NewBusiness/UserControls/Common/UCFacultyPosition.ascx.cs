using DevExpress.Web;
using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class UCFacultyPosition : UC, IUC
    {
        public string[] Coverage100PocRetencion { get { return new[] { "DAÑOS A TERCEROS", "SERVICIOS" }; } }

        public int NameKeyAtlantica
        {
            get
            {
                return
                       int.Parse(Session["NameKeyAtlantica"].ToString());
            }
            set
            {
                Session["NameKeyAtlantica"] = value;
            }
        }
        /// <summary>
        /// Genera una clolumna de tipo pasado
        /// </summary>      

        public Utility.KeyItem _keyItemSelected
        {
            get
            {
                return
                      Session["KeyItem"] as Utility.KeyItem;
            }

            set
            {
                Session["KeyItem"] = value;
            }
        }


        public bool _isFromDataBase
        {
            get
            {
                return
                      ViewState["isFromDataBase"].ToBoolean();
            }

            set
            {
                ViewState["isFromDataBase"] = value;
            }

        }

        public Utility.KeyCoverageContract _keyCoverageContract
        {
            get
            {
                return
                      ViewState["KeyCoverageContract"] as Utility.KeyCoverageContract;
            }

            set
            {
                ViewState["KeyCoverageContract"] = value;
            }
        }

        public IEnumerable<object> dataCoverages
        {
            get
            {
                return ViewState["dataCoverages"] as IEnumerable<object>;
            }
            set
            {
                ViewState["dataCoverages"] = value;
            }
        }

        private bool isInsertingNewRecord
        {
            get
            {
                return Session["isInsertingNewRecord"].ToBoolean();
            }
            set
            {
                Session["isInsertingNewRecord"] = value;
            }
        }

        public int IdContrato
        {
            get
            {
                return ViewState["IdContrato"].ToInt();
            }
            set
            {
                ViewState["IdContrato"] = value;
            }
        }

        public DataTable dtCoveragesViewState
        {
            get { return ViewState["dtCoveragesViewState"] as DataTable; }
            set { ViewState["dtCoveragesViewState"] = value; }
        }

        public Utility.Contrato _ContractualPercentageSelected
        {
            get
            {
                return ViewState["ContractualPercentageSelected"] as Utility.Contrato;
            }
            set
            {
                ViewState["ContractualPercentageSelected"] = value;
            }
        }

        public TextBox txtNombreContrato { get; set; }
        public TextBox txtMontoContrato { get; set; }
        public TextBox txtPorcCommision { get; set; }
        public DropDownList ddlNombreCompania { get; set; }
        public TextBox txtPayDateLimit { get; set; }
        public Label ltPorcContrato { get; set; }

        private List<Utility.Contrato> dataContrato = new List<Utility.Contrato>(0);

        public List<int> oTemCompanySelected
        {
            get
            {
                return ViewState["TemCompanySelected"] == null ?
                    new List<int>() :
                    ViewState["TemCompanySelected"] as List<int>;
            }

            set
            {
                List<int> tempList = null;

                if (value != null)
                {
                    tempList = new List<int>(
                            ViewState["TemCompanySelected"] != null
                            ?
                            (
                               (List<int>)ViewState["TemCompanySelected"]
                            )
                            :
                            new List<int>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemCompanySelected"] = tempList;
            }
        }

        public List<Utility.Contrato> oTemDataContrato
        {
            get
            {
                return ViewState["TemDataContrato"] == null ?
                    new List<Utility.Contrato>() :
                    ViewState["TemDataContrato"] as List<Utility.Contrato>;
            }

            set
            {
                List<Utility.Contrato> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.Contrato>(
                            ViewState["TemDataContrato"] != null
                            ?
                            (
                               (List<Utility.Contrato>)ViewState["TemDataContrato"]
                            )
                            :
                            new List<Utility.Contrato>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemDataContrato"] = tempList;
            }
        }

        public ASPxGridView GridCoverages
        {
            get { return Session["GridCoverages"] as ASPxGridView; }
            set { Session["GridCoverages"] = value; }
        }
        public void Translator(string Lang) { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        private void setCoverageGrid()
        {
            var gvCoverages = pnCoverages.FindControl("gvCoverages");

            if (gvCoverages != null)
                pnCoverages.Controls.Remove(gvCoverages);

            pnCoverages.Controls.Add(GridCoverages);

            SetAttributesInCoverageGrid();
            gvCoveragesFake.Visible = false;
            udpCoverages.Update();
        }

        protected void gvVehiculos_PreRender(object sender, EventArgs e)
        {
            (sender as DevExpress.Web.ASPxGridView).TranslateColumnsAspxGrid();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Pintar el grid
            if (GridCoverages != null && _keyItemSelected != null)
                setCoverageGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtNombreContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNombreContrato") as TextBox;
            txtMontoContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtMontoContrato") as TextBox;
            txtPorcCommision = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPorcCommision") as TextBox;
            txtPayDateLimit = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPayDateLimit") as TextBox;
            ddlNombreCompania = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlNombreCompania") as DropDownList;
            ltPorcContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPorcContrato") as Label;
        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex, Utility.Contrato Record = null)
        {
            txtNombreContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNombreContrato") as TextBox;
            var ltNombreContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltNombreContrato") as Control;

            txtMontoContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtMontoContrato") as TextBox;
            var ltMontoContrato = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltMontoContrato") as Control;

            txtPorcCommision = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPorcCommision") as TextBox;
            var ltPorcCommision = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPorcCommision") as Control;

            txtPayDateLimit = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPayDateLimit") as TextBox;
            var ltPayDateLimit = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPayDateLimit") as Control;

            ddlNombreCompania = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlNombreCompania") as DropDownList;
            var ltNombreCompania = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltNombreCompania") as Control;

            if (txtNombreContrato != null) txtNombreContrato.Visible = isEdit;
            if (ltNombreContrato != null) ltNombreContrato.Visible = !isEdit;

            if (txtMontoContrato != null) txtMontoContrato.Visible = isEdit;
            if (ltMontoContrato != null) ltMontoContrato.Visible = !isEdit;

            if (txtPayDateLimit != null)
            {
                txtPayDateLimit.Visible = isEdit;
                if (isInsertingNewRecord)
                    txtPayDateLimit.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            if (ltPayDateLimit != null) ltPayDateLimit.Visible = !isEdit;

            if (txtPorcCommision != null) txtPorcCommision.Visible = isEdit;
            if (ltPorcCommision != null) ltPorcCommision.Visible = !isEdit;

            if (ddlNombreCompania != null && ddlNombreCompania.Items.Count <= 0)
            {
                var dataDrop = ObjServices.GettingDropData(Utility.DropDownType.FacultativeCompany).Select(f => new
                {
                    NameKey = f.Namekey,
                    CompnayId = f.CityId,
                    CompanyName = f.CityDesc
                });

                dynamic xData = null;
                var IsNewRecord = false;

                if (Record != null)
                    IsNewRecord = (Record.Status == Utility.RecordStatus.New);

                if (IsNewRecord)
                    xData = dataDrop.Where(v => !oTemCompanySelected.Contains(v.CompnayId.GetValueOrDefault())).ToList();
                else
                {
                    var CompanyList = oTemCompanySelected;
                    CompanyList = CompanyList.Where(o => o != Record.IdCompania).ToList();
                    xData = dataDrop.Where(v => !CompanyList.Contains(v.CompnayId.GetValueOrDefault())).ToList();
                }

                ddlNombreCompania.DataSource = xData;
                ddlNombreCompania.DataValueField = "CompnayId";
                ddlNombreCompania.DataTextField = "CompanyName";
                ddlNombreCompania.DataBind();
                ddlNombreCompania.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlNombreCompania != null) ddlNombreCompania.Visible = isEdit;
            if (ltNombreCompania != null) ltNombreCompania.Visible = !isEdit;

        }

        public void FillGridContrato(bool AddLocal = false)
        {
            gvContrato.DatabindAspxGridView(oTemDataContrato);
        }

        public IEnumerable<Utility.CoverageDetail> FillDataCoverage()
        {
            IEnumerable<Utility.CoverageDetail> result = null;

            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
                    result = ObjServices.oPolicyManager.GetVehicleCoverage(new Policy.VehicleCoverageGet
                    {
                        CorpId = ObjServices.Corp_Id,
                        VehicleUniqueId = _keyItemSelected.UniqueId
                    }).Select(c => new Utility.CoverageDetail
                    {
                        Status = Utility.RecordStatus.New,
                        isLocal = true,
                        CoverageId = c.CoverageId,
                        CoverageName = c.CoverageDesc,
                        CoverageTypeDesc = c.CoverageTypeDesc,
                        ContractualPercentage = 0.00m,
                        CoverageCorpId = c.CorpId,
                        CoverageRegionId = c.RegionId,
                        CoverageCountryId = c.CountryId,
                        UniqueId = c.VehicleUniqueId,
                        BlTypeId = c.BlTypeId,
                        BlId = c.BlId,
                        ProductId = c.ProductId,
                        VehicleTypeId = c.VehicleTypeId,
                        GroupId = c.GroupId,
                        CoverageTypeId = c.CoverageTypeId
                    }).ToArray();
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            result = ObjServices.oAirPlaneManager.GetAirPlaneInsuredCoverage(new Airplane.Insured.Coverage.Key
                            {
                                CorpId = ObjServices.Corp_Id,
                                UniqueAirplaneId = _keyItemSelected.UniqueId
                            }).Select(c => new Utility.CoverageDetail
                            {
                                Status = Utility.RecordStatus.New,
                                isLocal = true,
                                CoverageId = c.CoverageId,
                                CoverageName = c.CoverageDesc,
                                CoverageTypeDesc = c.CoverageTypeDesc,
                                ContractualPercentage = 0.00m,
                                CoverageCorpId = c.CorpId,
                                CoverageRegionId = c.RegionId,
                                CoverageCountryId = c.CountryId,
                                UniqueId = c.UniqueAirplaneId,
                                BlTypeId = c.BlTypeId,
                                BlId = c.BlId,
                                ProductId = c.ProductId,
                                VehicleTypeId = c.VehicleTypeId,
                                GroupId = c.GroupId,
                                CoverageTypeId = c.CoverageTypeId
                            }).ToArray();
                            break;
                        case Utility.AlliedLinesType.Bail:
                            result = ObjServices.oBailManager.GetBailInsuredCoverage(new Bail.Insured.Coverage.Key
                            {
                                CorpId = ObjServices.Corp_Id,
                                UniqueBailId = _keyItemSelected.UniqueId
                            }).Select(c => new Utility.CoverageDetail
                            {
                                Status = Utility.RecordStatus.New,
                                isLocal = true,
                                CoverageId = c.CoverageId.GetValueOrDefault(),
                                CoverageName = c.CoverageDesc,
                                CoverageTypeDesc = c.CoverageTypeDesc,
                                ContractualPercentage = 0.00m,
                                CoverageCorpId = c.CorpId.GetValueOrDefault(),
                                CoverageRegionId = c.RegionId.GetValueOrDefault(),
                                CoverageCountryId = c.CountryId.GetValueOrDefault(),
                                UniqueId = (long)c.UniqueBailId,
                                BlTypeId = c.BlTypeId.GetValueOrDefault(),
                                BlId = c.BlId.GetValueOrDefault(),
                                ProductId = c.ProductId.GetValueOrDefault(),
                                VehicleTypeId = c.VehicleTypeId.GetValueOrDefault(),
                                GroupId = c.GroupId.GetValueOrDefault(),
                                CoverageTypeId = c.CoverageTypeId.GetValueOrDefault()
                            }).ToArray();
                            break;
                        case Utility.AlliedLinesType.Navy:
                            result = ObjServices.oNavyManager.GetNavyInsuredCoverage(new Navy.Insured.Coverage.Key
                            {
                                CorpId = ObjServices.Corp_Id,
                                UniqueNavyId = _keyItemSelected.UniqueId
                            }).Select(c => new Utility.CoverageDetail
                            {
                                Status = Utility.RecordStatus.New,
                                isLocal = true,
                                CoverageId = c.CoverageId.GetValueOrDefault(),
                                CoverageName = c.CoverageDesc,
                                CoverageTypeDesc = c.CoverageTypeDesc,
                                ContractualPercentage = 0.00m,
                                CoverageCorpId = c.CorpId.GetValueOrDefault(),
                                CoverageRegionId = c.RegionId.GetValueOrDefault(),
                                CoverageCountryId = c.CountryId.GetValueOrDefault(),
                                UniqueId = (long)c.UniqueNavyId,
                                BlTypeId = c.BlTypeId.GetValueOrDefault(),
                                BlId = c.BlId.GetValueOrDefault(),
                                ProductId = c.ProductId.GetValueOrDefault(),
                                VehicleTypeId = c.VehicleTypeId.GetValueOrDefault(),
                                GroupId = c.GroupId.GetValueOrDefault(),
                                CoverageTypeId = c.CoverageTypeId.GetValueOrDefault()
                            }).ToArray();
                            break;
                        case Utility.AlliedLinesType.Property:
                            result = ObjServices.oPropertyManager.GetPropertyInsuredDetailCoverage(new Property.Insured.Detail.Coverage.GetDetailCoverageResult.Key
                            {
                                corpId = ObjServices.Corp_Id,
                                uniquePropertyId = _keyItemSelected.UniqueId
                            }).Select(c => new Utility.CoverageDetail
                            {
                                Status = Utility.RecordStatus.New,
                                isLocal = true,
                                CoverageId = c.CoverageId,
                                CoverageName = c.CoverageDesc,
                                CoverageTypeDesc = c.CoverageTypeDesc,
                                ContractualPercentage = 0.00m,
                                CoverageCorpId = c.CorpId,
                                CoverageRegionId = c.RegionId,
                                CoverageCountryId = c.CountryId,
                                UniqueId = (long)c.UniquePropertyId,
                                BlTypeId = c.BlTypeId,
                                BlId = c.BlId,
                                ProductId = c.ProductId,
                                VehicleTypeId = c.VehicleTypeId,
                                GroupId = c.GroupId,
                                CoverageTypeId = c.CoverageTypeId
                            }).ToArray();
                            break;
                        case Utility.AlliedLinesType.Transport:
                            result = ObjServices.oTransportManager.GetTransportInsuredCoverage(new Transport.Insured.Coverage.Key
                            {
                                CorpId = ObjServices.Corp_Id,
                                UniqueTransportId = _keyItemSelected.UniqueId
                            }).Select(c => new Utility.CoverageDetail
                            {
                                Status = Utility.RecordStatus.New,
                                isLocal = true,
                                CoverageId = c.CoverageId.GetValueOrDefault(),
                                CoverageName = c.CoverageDesc,
                                CoverageTypeDesc = c.CoverageTypeDesc,
                                ContractualPercentage = 0.00m,
                                CoverageCorpId = c.CorpId.GetValueOrDefault(),
                                CoverageRegionId = c.RegionId.GetValueOrDefault(),
                                CoverageCountryId = c.CountryId.GetValueOrDefault(),
                                UniqueId = (long)c.UniqueTransportId,
                                BlTypeId = c.BlTypeId.GetValueOrDefault(),
                                BlId = c.BlId.GetValueOrDefault(),
                                ProductId = c.ProductId.GetValueOrDefault(),
                                VehicleTypeId = c.VehicleTypeId.GetValueOrDefault(),
                                GroupId = c.GroupId.GetValueOrDefault(),
                                CoverageTypeId = c.CoverageTypeId.GetValueOrDefault()
                            }).ToArray();
                            break;
                    }
                    break;
            }
            return
                  result;
        }

        public void FillData()
        {
            switch (ObjServices.ProductLine)
            {
                case Utility.ProductLine.Auto:
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
                      }).Where(g => g.AppliesToReinsurance.GetValueOrDefault()).Select(v => new
                      {
                          v.ReinsuranceAmount,
                          v.ReinsurancePercentage,
                          v.CorpId,
                          v.RegionId,
                          v.CountryId,
                          v.DomesticregId,
                          v.StateProvId,
                          v.CityId,
                          v.OfficeId,
                          v.CaseSeqNo,
                          v.HistSeqNo,
                          UniqueId = v.VehicleUniqueId,
                          v.Chassis,
                          v.Registry,
                          v.DPPremiumAmount,
                          DPPremiumAmountF = v.DPPremiumAmount.HasValue ? v.DPPremiumAmount.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0",
                          v.ReinsurancePremiumAmount,
                          ReinsurancePremiumAmountF = v.ReinsurancePremiumAmount.HasValue ? v.ReinsurancePremiumAmount.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0",
                          VehicleDesc = string.Concat(v.MakeDesc, " ", v.ModelDesc, " ", v.Year),
                          InsuredAmount = v.VehicleValue,
                          InsuredAmountF = v.VehicleValue.HasValue ? v.VehicleValue.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0",
                          PremiumAmountF = v.PremiumAmount.HasValue ? v.PremiumAmount.Value.ToString("#,0.00", CultureInfo.InvariantCulture) : "0"
                      });

                    if (dataVehicle.Any())
                        gvVehiculos.DatabindAspxGridView(dataVehicle);

                    mtvMaster.SetActiveView(vAuto);
                    break;
                case Utility.ProductLine.AlliedLines:
                    switch (ObjServices.AlliedLinesProductBehavior)
                    {
                        case Utility.AlliedLinesType.Airplane:
                            var dataAirplane = ObjServices.GetDataAirPlane().Where(g => g.AppliesToReinsurance).Select(v => new
                            {
                                v.ReinsuranceAmount,
                                v.ReinsurancePercentage,
                                v.CorpId,
                                v.RegionId,
                                v.CountryId,
                                v.DomesticregId,
                                v.StateProvId,
                                v.CityId,
                                v.OfficeId,
                                v.CaseSeqNo,
                                v.HistSeqNo,
                                v.ReinsurancePremiumAmount,
                                UniqueId = v.UniqueAirplaneId,
                                ProductDesc = v.ProductDesc,
                                InsuredAmount = v.InsuredAmount,
                                InsuredAmountF = v.InsuredAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture),
                                PremiumAmountF = v.PremiumAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture)
                            });

                            if (dataAirplane.Any())
                                gvAirplane.DatabindAspxGridView(dataAirplane);

                            mtvMaster.SetActiveView(vAirPlane);
                            break;
                        case Utility.AlliedLinesType.Bail:
                            var dataBail = ObjServices.GetDataBail().Where(g => g.AppliesToReinsurance).Select(v => new
                            {
                                v.ReinsuranceAmount,
                                v.ReinsurancePercentage,
                                v.CorpId,
                                v.RegionId,
                                v.CountryId,
                                v.DomesticregId,
                                v.StateProvId,
                                v.CityId,
                                v.OfficeId,
                                v.CaseSeqNo,
                                v.HistSeqNo,
                                UniqueId = v.UniqueBailId,
                                v.ReinsurancePremiumAmount,
                                ProductDesc = v.ProductDesc,
                                InsuredAmount = v.InsuredAmount,
                                InsuredAmountF = v.InsuredAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture),
                                PremiumAmountF = v.PremiumAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture)
                            });

                            if (dataBail.Any())
                                gvBail.DatabindAspxGridView(dataBail);

                            mtvMaster.SetActiveView(vBail);
                            break;
                        case Utility.AlliedLinesType.Navy:
                            var dataNavy = ObjServices.GetDataNavy().Where(g => g.AppliesToReinsurance).Select(v => new
                            {
                                v.ReinsuranceAmount,
                                v.ReinsurancePercentage,
                                v.CorpId,
                                v.RegionId,
                                v.CountryId,
                                v.DomesticregId,
                                v.StateProvId,
                                v.CityId,
                                v.OfficeId,
                                v.CaseSeqNo,
                                v.HistSeqNo,
                                v.ReinsurancePremiumAmount,
                                UniqueId = v.UniqueNavyId,
                                ProductDesc = v.ProductDesc,
                                InsuredAmount = v.InsuredAmount,
                                InsuredAmountF = v.InsuredAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture),
                                PremiumAmountF = v.PremiumAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture)
                            });

                            if (dataNavy.Any())
                                gvNavy.DatabindAspxGridView(dataNavy);

                            mtvMaster.SetActiveView(vNavy);
                            break;
                        case Utility.AlliedLinesType.Property:
                            var dataProperty = ObjServices.GetDataProperty().Where(g => g.AppliesToReinsurance).Select(v => new
                            {
                                v.ReinsuranceAmount,
                                v.ReinsurancePercentage,
                                v.CorpId,
                                v.RegionId,
                                v.CountryId,
                                v.DomesticregId,
                                v.StateProvId,
                                v.CityId,
                                v.OfficeId,
                                v.CaseSeqNo,
                                v.HistSeqNo,
                                UniqueId = v.UniquePropertyId,
                                v.ReinsurancePremiumAmount,
                                ProductDesc = v.ProductDesc,
                                InsuredAmount = v.InsuredAmount,
                                InsuredAmountF = v.InsuredAmount.ToString("#,0.00", CultureInfo.InvariantCulture),
                                PremiumAmountF = v.PremiumAmount.ToString("#,0.00", CultureInfo.InvariantCulture)
                            });

                            if (dataProperty.Any())
                                gvProperty.DatabindAspxGridView(dataProperty);

                            mtvMaster.SetActiveView(vProperty);
                            break;
                        case Utility.AlliedLinesType.Transport:
                            var dataTransport = ObjServices.GetDataTransport().Where(g => g.AppliesToReinsurance).Select(v => new
                            {
                                v.ReinsuranceAmount,
                                v.ReinsurancePercentage,
                                v.CorpId,
                                v.RegionId,
                                v.CountryId,
                                v.DomesticregId,
                                v.StateProvId,
                                v.CityId,
                                v.OfficeId,
                                v.CaseSeqNo,
                                v.HistSeqNo,
                                UniqueId = v.UniqueTransportId,
                                v.ReinsurancePremiumAmount,
                                ProductDesc = v.ProductDesc,
                                InsuredAmount = v.InsuredAmount,
                                InsuredAmountF = v.InsuredAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture),
                                PremiumAmountF = v.PremiumAmount.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture)
                            });

                            if (dataTransport.Any())
                                gvTransport.DatabindAspxGridView(dataTransport);

                            mtvMaster.SetActiveView(vTransport);
                            break;
                    }
                    break;
                default:
                    break;
            }

            FillGridContrato();
        }

        public void Initialize()
        {
            ClearData();
            FillData();
            gvCoveragesFake.DatabindAspxGridView(new List<Utility.CoverageDetail>(0));
            gvCoveragesFake.GroupBy(gvCoveragesFake.Columns["CoverageTypeDesc"]);
            gvCoveragesFake.ExpandAll();
        }

        public void ClearData()
        {
            btnGuardar.CssClass = "button button-green disabled alignC embossed fl col-6";
            lnkCancelContract.CssClass = "button button-red disabled alignC embossed fr row_A";

            btnGuardar.Enabled = false;
            pnItems.Enabled = true;
            pnContratos.Enabled = false;
            pnCoverages.Enabled = false;
            lnkCancelContract.Enabled = false;
            oTemDataContrato = null;
            dtCoveragesViewState = null;
            _keyItemSelected = null;
            _keyCoverageContract = null;
            GridCoverages = null;
            NameKeyAtlantica = 1;
            gvContrato.DatabindAspxGridView(oTemDataContrato);

            var gvCoverages = pnCoverages.FindControl("gvCoverages");
            if (gvCoverages != null)
            {
                pnCoverages.Controls.Remove(gvCoverages);
                udpCoverages.Update();
            }

            gvCoveragesFake.Visible = true;

            txtFactultyAmount.Clear("0.00");
            txtRestoTotal.Clear("0.00");
            txtTotalDistribuido.Clear("0.00");
            isInsertingNewRecord = false;
            udpTotales.Update();
        }

        protected void gvContrato_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            IdContrato = grid.GetKeyFromAspxGridView("IdContrato", e.VisibleIndex).ToInt();
            var RecordIndex = grid.GetKeyFromAspxGridView("RecordIndex", e.VisibleIndex).ToInt();
            var Status = grid.GetKeyFromAspxGridView("Status", e.VisibleIndex).ToInt();

            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;

            var Record = (isInsertingNewRecord) ? oTemDataContrato.Last()
                                                : oTemDataContrato.FirstOrDefault(r => r.RecordIndex == RecordIndex);
            udpGridView.Update();

            switch (Command)
            {
                case "Delete":
                    oTemDataContrato.Remove(Record);

                    //Eliminar la compañia para que aperezca en el dropdown de compañias
                    var dataCompany = oTemCompanySelected.Where(c => c != Record.IdCompania);
                    if (dataCompany.Any())
                    {
                        oTemCompanySelected = null;
                        oTemCompanySelected = dataCompany.ToList();
                    }

                    var corpId = grid.GetKeyFromAspxGridView("corpId", e.VisibleIndex).ToInt();
                    var contractUniqueId = grid.GetKeyFromAspxGridView("contractUniqueId", e.VisibleIndex).ToInt();
                    var userId = ObjServices.UserID.GetValueOrDefault();
                    if (!Record.isLocal)
                    {
                        //Eliminar de la base de datos
                        ObjServices.oPolicyManager.DeleteFacultativeContract(corpId, contractUniqueId, userId);
                        dtCoveragesViewState = GetCoveragesFromDB();
                        SetAttributesInCoverageGrid();
                    }

                    FillGridContrato();
                    gvContrato.PageIndex = 0;
                    SetAmount();

                    //Eliminar la columna correspondiente al contrato en el grid de coberturas
                    var cColRemove = GridCoverages.getThisColumn(Record.RecordIndex.ToString());
                    GridCoverages.Columns[cColRemove.Index].Visible = false;
                    GridCoverages.Columns[cColRemove.Index].Name = "delete"; //La delete significa que la columna fue borrada no debe ser tomada en cuenta
                    setCoverageGrid();
                    break;
                case "Cancel":

                    var hasNewRecord = oTemDataContrato.Any(p => p.Status == Utility.RecordStatus.New);

                    if (hasNewRecord)
                    {
                        var result = oTemDataContrato.Where(p => p.Status != Utility.RecordStatus.New).ToList();
                        oTemDataContrato = null;
                        oTemDataContrato = result;
                        FillGridContrato();
                        gvContrato.PageIndex = 0;
                    }

                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex, Record);
                    btnEditOrSave.CommandName = "Edit";
                    isInsertingNewRecord = false;
                    FillGridContrato();
                    break;
                case "Edit":
                    if (btnCancel != null) btnCancel.Visible = true;
                    if (btnDelete != null) btnDelete.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "mysave_file";
                    btnEditOrSave.CommandName = "Save";
                    EditMode(true, grid, e.VisibleIndex, Record);
                    if (Record.IdCompania.HasValue)
                        ddlNombreCompania.SelectedValue = Record.IdCompania.ToString();
                    break;
                case "Save":
                    btnEditOrSave.CommandName = "Edit";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    isInsertingNewRecord = false;
                    EditMode(false, grid, e.VisibleIndex, Record);
                    SetControls(grid, e.VisibleIndex);
                    //Validaciones                       

                    //Validacion del Montos
                    var MontoFacultativo = txtFactultyAmount.ToDecimal(removeSpecialCharacter: true);
                    var MontoContrato = txtMontoContrato.ToDecimal(removeSpecialCharacter: true);
                    var NombreContrato = txtNombreContrato.Text;

                    var MontoAnterior = Record.MontoContrato;
                    var NombreAnterior = Record.NombreContrato;

                    Record.MontoContrato = MontoContrato;
                    Record.NombreContrato = NombreContrato;

                    //Validacion de los nombre de contrato
                    var ContractNames = oTemDataContrato.Where(t => t.RecordIndex != Record.RecordIndex).Select(h => h.NombreContrato);

                    var DataContratName = ContractNames.Where(x => x.ToUpper().Contains(Record.NombreContrato.ToUpper()));

                    if (DataContratName.Any())
                    {
                        this.MessageBox("Los nombre de contratos no pueden ser iguales.");
                        DoClickEdit(e.VisibleIndex);
                        return;
                    }

                    if (MontoContrato > MontoFacultativo)
                    {
                        this.MessageBox("El monto del contrato no debe ser mayor que monto factultativo.");
                        Record.MontoContrato = MontoAnterior;
                        DoClickEdit(e.VisibleIndex);
                        return;
                    }

                    var TotalMontoDistribuido = oTemDataContrato.Sum(c => c.MontoContrato);

                    if (TotalMontoDistribuido > MontoFacultativo)
                    {
                        this.MessageBox("La Sumatoria de todos los contratos no debe ser mayor que monto factultativo.");
                        Record.MontoContrato = MontoAnterior;
                        DoClickEdit(e.VisibleIndex);
                        return;
                    }

                    Record.NombreContrato = txtNombreContrato.Text;
                    Record.MontoContrato = txtMontoContrato.ToDecimal(removeSpecialCharacter: true);
                    Record.PorcCommision = txtPorcCommision.ToDecimal(removeSpecialCharacter: true);
                    Record.NombreCompania = ddlNombreCompania.SelectedItem.Text;
                    Record.IdCompania = ddlNombreCompania.ToInt();
                    Record.MontoContratoF = Record.MontoContrato.ToString("#,0.00", CultureInfo.InvariantCulture);
                    Record.PorcCommisionF = Record.PorcCommision.ToString("#,0.00", CultureInfo.InvariantCulture);
                    Record.FechaLimitePago = DateTime.ParseExact(txtPayDateLimit.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Date;
                    Record.FechaLimitePagoF = Record.FechaLimitePago.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Record.Status = Utility.RecordStatus.Old;
                    var SumaAsegurada = _keyItemSelected.InsuredAmount;
                    Record.PorcContrato = (Record.MontoContrato / SumaAsegurada) * 100;


                    //Crear columna contrato x
                    var ContratoNameAttr = new Dictionary<string, string>();
                    ContratoNameAttr.Add("decimal", "decimal3");
                    var ContratoName = new Utility.MyColumn() { Name = Record.RecordIndex.ToString(), Caption = Record.NombreContrato };
                    var cContrato = CreateTemplate(ContratoName,
                                                  ContratoNameAttr,
                                                  Utility.WebControlType.TextBox,
                                                  Utility.TemplateType.GridViewDataColumn,
                                                  string.Concat("txtContrato", Record.RecordIndex.ToString()),
                                                  "valGet"
                                                  );

                    //Validar si ya el contrato existe para no repetir la columna en caso de que existe entonces editar el caption de la columna
                    var cCol = GridCoverages.getThisColumn(Record.RecordIndex.ToString());

                    if (cCol == null)
                    {
                        //No existe
                        cContrato.VisibleIndex = Record.RecordIndex;
                        GridCoverages.Columns.Add(cContrato);
                        oTemCompanySelected = new List<int>() { Record.IdCompania.GetValueOrDefault() };
                    }
                    else
                        //Editar
                        GridCoverages.Columns[cCol.Index].Caption = cContrato.Caption;
                    //Fin          
                    SetAmount();
                    SetAttributesInCoverageGrid();
                    udpTotales.Update();
                    FillGridContrato();


                    break;
            }
        }

        private void SetAmount()
        {
            var MontoFacultativo = txtFactultyAmount.ToDecimal(removeSpecialCharacter: true);
            var TotalMontoDistribuido = oTemDataContrato.Sum(c => c.MontoContrato);
            txtTotalDistribuido.Text = TotalMontoDistribuido.ToString(CultureInfo.InvariantCulture).Replace(",", "");
            var totalRestante = MontoFacultativo - TotalMontoDistribuido;
            pnCoverages.Enabled = (totalRestante == 0);
            txtRestoTotal.Text = totalRestante.ToString(CultureInfo.InvariantCulture).Replace(",", "");
            udpTotales.Update();
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            int RecIndex = 0;

            if (!ValidateCanFacultativeColocation())
                return;

            //Validar antes de agregar que el monto facultativo no este totalmente distribuido
            var MontoFacultativo = txtFactultyAmount.ToDecimal(removeSpecialCharacter: true);
            var TotalMontoDistribuido = oTemDataContrato.Sum(c => c.MontoContrato);
            if (TotalMontoDistribuido == MontoFacultativo)
            {
                this.MessageBox("No se pueden agregar mas contratos, el monto facultativo ya ha sido totalmente distribuido");
                return;
            }

            if (isInsertingNewRecord)
                return;

            //Calcular el indice
            RecIndex = (_isFromDataBase) ? oTemDataContrato.Any() ? oTemDataContrato.Max(b => b.RecordIndex) + 1
                                                                 : 2
                                         : oTemDataContrato.Count() + 2;

            dataContrato.Add(new Utility.Contrato
            {
                Status = Utility.RecordStatus.New,
                isLocal = true,
                IdCompania = null,
                NombreCompania = string.Empty,
                NameKeyContrato = string.Empty,
                RecordIndex = RecIndex,
                IdContrato = _isFromDataBase ? (int?)RecIndex : null,
                NombreContrato = string.Empty,
                MontoContrato = 0.00m,
                PorcCommision = 0.00m,
                PorcContrato = 0.000000m
            });

            isInsertingNewRecord = true;
            oTemDataContrato = dataContrato;

            FillGridContrato(true);
            gvContrato.PageIndex = gvContrato.PageCount;
            var Index = oTemDataContrato.Count - 1;
            DoClickEdit(Index);
        }

        private void DoClickEdit(int Index)
        {
            var script = string.Format("javascript:__doPostBack('ctl00$bodyContent$UCFacultyPosition$gvContrato$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        protected void gvContrato_PageIndexChanged(object sender, EventArgs e)
        {
            FillGridContrato();
        }

        private void GenerateGridCoverages(bool isFirst = false)
        {
            GridViewColumn cCol;
            ASPxGridView GridTemp = null;

            GridTemp = new ASPxGridView()
            {
                ID = "gvCoverages",
                EnableCallBacks = false,
                Width = Unit.Percentage(100),
                AutoGenerateColumns = false,
                ClientIDMode = System.Web.UI.ClientIDMode.Static,
                KeyFieldName = "CoverageTypeDesc;CoverageName;CoverageId;CoverageCorpId;CoverageRegionId;CoverageCountryId;UniqueId;BlTypeId;BlId;ProductId;VehicleTypeId;GroupId;CoverageTypeId",
            };

            GridTemp.Settings.VerticalScrollableHeight = 740;
            GridTemp.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
            GridTemp.SettingsPager.PageSize = 100000000;
            GridTemp.HtmlRowCreated += gvCoverages_HtmlRowCreated;

            //Crear la columna coverage
            var ColumnCoverageName = new Utility.MyColumn() { Name = "CoverageName", Caption = "COBERTURA", FieldName = "CoverageName" };
            cCol = CreateTemplate(ColumnCoverageName, null, Utility.WebControlType.DataBoundField, Utility.TemplateType.GridViewDataTextColumn, "", "");
            GridTemp.Columns.Add(cCol);
            //Fin

            //Crear la columna coverage Type
            var ColumnCoverageTypeDesc = new Utility.MyColumn() { Name = "CoverageTypeDesc", Caption = "", FieldName = "CoverageTypeDesc" };
            cCol = CreateTemplate(ColumnCoverageTypeDesc, null, Utility.WebControlType.DataBoundField, Utility.TemplateType.GridViewDataTextColumn, "", "");
            GridTemp.Columns.Add(cCol);
            //Fin

            //Crear la columna contractual percentage
            var ContractualNameAttr = new Dictionary<string, string>();
            ContractualNameAttr.Add("decimal", "decimal3");
            var ContractualPercentageName = new Utility.MyColumn() { Name = "Retencion", Caption = "RETENCION" };
            var cContractualPercentage = CreateTemplate(ContractualPercentageName, ContractualNameAttr, Utility.WebControlType.TextBox, Utility.TemplateType.GridViewDataColumn, "txtPorcientoContractual", "valGet", WithHiddenField: true);
            GridTemp.Columns.Add(cContractualPercentage);
            //Fin

            //Crear la columna Total Percentage
            var TotalPercentNameAttr = new Dictionary<string, string>();
            TotalPercentNameAttr.Add("decimal", "decimal3");
            var TotalPercentName = new Utility.MyColumn() { Name = "TotalPercent", Caption = "TOTAL" };
            var cTotalPercent = CreateTemplate(TotalPercentName, TotalPercentNameAttr, Utility.WebControlType.TextBox, Utility.TemplateType.GridViewDataColumn, "txtTotalPercent", "valTotal", IsReadOnly: true, WithHiddenField: false);
            cTotalPercent.VisibleIndex = 10000;
            GridTemp.Columns.Add(cTotalPercent);
            //Fin

            var DCoverage = isFirst ? new List<Utility.CoverageDetail>(0)
                                    : FillDataCoverage();

            GridTemp.DataSource = DCoverage;
            GridTemp.DataBind();
            GridTemp.GroupBy(GridTemp.Columns["CoverageTypeDesc"]);
            GridTemp.ExpandAll();
            GridCoverages = GridTemp;
            setCoverageGrid();
        }

        private GridViewColumn CreateTemplate(Utility.MyColumn myColumn, Dictionary<string, string> AttrList, Utility.WebControlType controlType, Utility.TemplateType templateType, string IdControl, string CssClass, string TextValue = "", bool IsReadOnly = false, bool WithHiddenField = false)
        {
            GridViewColumn result = null;

            if (templateType == Utility.TemplateType.GridViewDataColumn)
            {
                var colItemTemplate = new DevExpress.Web.GridViewDataColumn();
                colItemTemplate.DataItemTemplate = new Utility.MyGenericTemplate(AttrList, controlType, IdControl, CssClass, TextValue, IsReadOnly, WithHiddenField);
                colItemTemplate.Name = myColumn.Name;
                colItemTemplate.Caption = myColumn.Caption;
                result = colItemTemplate;
            }
            else
                if (templateType == Utility.TemplateType.GridViewDataTextColumn)
                {
                    var colItemDataTextColumn = new DevExpress.Web.GridViewDataTextColumn();
                    colItemDataTextColumn.Name = myColumn.Name;
                    colItemDataTextColumn.Caption = myColumn.Caption;
                    colItemDataTextColumn.FieldName = myColumn.FieldName;
                    result = colItemDataTextColumn;
                }

            return
                result;
        }

        protected void Item_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            var Grid = sender as ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var Index = e.VisibleIndex;

            if (Command == "Select")
            {
                pnItems.Enabled = false;
                pnContratos.Enabled = true;

                var KeyItem = new Utility.KeyItem
                {
                    CorpId = Grid.GetKeyFromAspxGridView("CorpId", Index).ToInt(),
                    RegionId = Grid.GetKeyFromAspxGridView("RegionId", Index).ToInt(),
                    CountryId = Grid.GetKeyFromAspxGridView("CountryId", Index).ToInt(),
                    DomesticregId = Grid.GetKeyFromAspxGridView("DomesticregId", Index).ToInt(),
                    StateProvId = Grid.GetKeyFromAspxGridView("StateProvId", Index).ToInt(),
                    CityId = Grid.GetKeyFromAspxGridView("CityId", Index).ToInt(),
                    OfficeId = Grid.GetKeyFromAspxGridView("OfficeId", Index).ToInt(),
                    CaseSeqNo = Grid.GetKeyFromAspxGridView("CaseSeqNo", Index).ToInt(),
                    HistSeqNo = Grid.GetKeyFromAspxGridView("HistSeqNo", Index).ToInt(),
                    UniqueId = Grid.GetKeyFromAspxGridView("UniqueId", Index).ToInt(),
                    ReinsuranceAmount = Grid.GetKeyFromAspxGridView("ReinsuranceAmount", Index).ToDecimal(),
                    ReinsurancePercentage = Grid.GetKeyFromAspxGridView("ReinsurancePercentage", Index).ToDecimal(),
                    InsuredAmount = Grid.GetKeyFromAspxGridView("InsuredAmount", Index).ToDecimal(),
                    ReinsurancePremiumAmount = Grid.GetKeyFromAspxGridView("ReinsurancePremiumAmount", Index).ToDecimal(), 
                    IdGrid = Grid.ID
                };

                btnGuardar.Enabled = true;
                lnkCancelContract.Enabled = true;
                btnGuardar.CssClass = "button button-green alignC embossed fl col-6";
                lnkCancelContract.CssClass = "button button-red alignC embossed fr row_A";
                _keyItemSelected = KeyItem;
                oTemCompanySelected = null;
                txtFactultyAmount.Text = _keyItemSelected.ReinsuranceAmount.ToString("#,0.00", CultureInfo.InvariantCulture);
                txtReinsurancePercentage.Text = _keyItemSelected.ReinsurancePercentage.Truncate().ToString() + "%";
                txtPrimaCedida.Text = _keyItemSelected.ReinsurancePremiumAmount.ToString("#,0.00", CultureInfo.InvariantCulture);
                BindFromDataBase();
                gvCoveragesFake.Visible = false;

                var isEffectivePolicy = ObjServices.StatusNameKey == Utility.IllustrationStatus.Effective.Code();

                var IsEnableOrVisible = (ObjServices.IsFacultativeCot || ObjServices.isUserCot) && !isEffectivePolicy;

                btnAdd.Enabled = IsEnableOrVisible;

                for (int i = gvContrato.VisibleStartIndex; i < gvContrato.VisibleRowCount; i++)
                {
                    var pnDelete = gvContrato.FindRowCellTemplateControl(i, null, "pnDelete") as Panel;
                    var btnCancel = gvContrato.FindRowCellTemplateControl(i, null, "btnCancel") as LinkButton;
                    var btnEditOrSave = gvContrato.FindRowCellTemplateControl(i, null, "btnEditOrSave") as LinkButton;

                    if (pnDelete != null)
                    {
                        var btnDelete = pnDelete.FindControl("btnDelete") as LinkButton;
                        btnDelete.Enabled = IsEnableOrVisible;
                        btnDelete.OnClientClick = IsEnableOrVisible ? "return DlgConfirm(this);" : "";
                    }

                    if (btnCancel != null)
                        btnCancel.Enabled = IsEnableOrVisible;

                    if (btnEditOrSave != null)
                        btnEditOrSave.Enabled = IsEnableOrVisible;
                }

                DevExpress.Web.GridViewDataColumn cColPercentage;

                for (int i = GridCoverages.VisibleStartIndex; i < GridCoverages.VisibleRowCount; i++)
                {
                    //Buscar las columnas y agregar atributos
                    cColPercentage = GridCoverages.getThisColumn("Retencion") as DevExpress.Web.GridViewDataColumn;
                    var txtPorcientoContractual = GridCoverages.FindRowCellTemplateControl(i, cColPercentage, "txtPorcientoContractual") as TextBox;

                    if (txtPorcientoContractual != null)
                    {
                        txtPorcientoContractual.ReadOnly = !IsEnableOrVisible;

                        ////Buscar las columnas de contratos
                        foreach (var item in oTemDataContrato)
                        {
                            var cCol = GridCoverages.getThisColumn(item.RecordIndex.ToString()) as DevExpress.Web.GridViewDataColumn;
                            var ControlId = string.Concat("txtContrato", item.RecordIndex.ToString());
                            var txtContratoX = GridCoverages.FindRowCellTemplateControl(i, cCol, ControlId) as TextBox;
                            if (txtContratoX != null)
                                txtContratoX.ReadOnly = !IsEnableOrVisible;

                        }
                    }
                }
            }
        }

        private void BindFromDataBase()
        {
            //Buscar los contratos de este item
            var DataContract = ObjServices.oPolicyManager.GetFacultativeContract(new Policy.Facultative.Key
            {
                CorpId = _keyItemSelected.CorpId,
                RegionId = _keyItemSelected.RegionId,
                CountryId = _keyItemSelected.CountryId,
                DomesticregId = _keyItemSelected.DomesticregId,
                StateProvId = _keyItemSelected.StateProvId,
                CityId = _keyItemSelected.CityId,
                OfficeId = _keyItemSelected.OfficeId,
                CaseSeqNo = _keyItemSelected.CaseSeqNo,
                HistSeqNo = _keyItemSelected.HistSeqNo,
                UniqueId = _keyItemSelected.UniqueId
            });

            if (DataContract.Any())
            {
                foreach (var item in DataContract)
                {
                    //Existe el contrato
                    dataContrato.Add(new Utility.Contrato
                    {
                        Status = Utility.RecordStatus.Old,
                        isLocal = false,
                        corpId = item.CorpId,
                        contractUniqueId = item.ContractUniqueId,
                        IdCompania = item.CompanyFacultativeId,
                        NombreCompania = item.CompanyFacultativeDesc,
                        RecordIndex = item.ContractId,
                        IdContrato = item.ContractId,
                        NameKeyContrato = item.ContractName,
                        NombreContrato = item.ContractName,
                        MontoContrato = item.ContractAmount,
                        PorcCommision = item.ContractCommissionPercentage,
                        MontoContratoF = item.ContractAmount.ToString("#,0.00", CultureInfo.InvariantCulture),
                        PorcCommisionF = item.ContractCommissionPercentage.ToString("#,0.00", CultureInfo.InvariantCulture),
                        FechaLimitePago = item.PaymentDate.Date,
                        FechaLimitePagoF = item.PaymentDate.ToString("dd/MM/yyyy"),
                        PorcContrato = (item.ContractAmount / _keyItemSelected.InsuredAmount) * 100
                    });
                }

                _ContractualPercentageSelected = dataContrato.FirstOrDefault(c => c.NombreContrato == "Retencion");

                oTemDataContrato = dataContrato.Where(c => c.NombreContrato != "Retencion").ToList();//Discriminar la Retencion                     
                gvContrato.DatabindAspxGridView(oTemDataContrato);
                SetAmount();
                _isFromDataBase = true;
                GenerateGridCoverages();

                dtCoveragesViewState = GetCoveragesFromDB();

                //Generar contratos en el grid de coberturas
                foreach (var Record in oTemDataContrato)
                {
                    //Crear columna contrato x
                    var ContratoNameAttr = new Dictionary<string, string>();
                    ContratoNameAttr.Add("decimal", "decimal3");
                    var ContratoName = new Utility.MyColumn() { Name = Record.RecordIndex.ToString(), Caption = Record.NombreContrato };
                    var cContrato = CreateTemplate(ContratoName,
                                                   ContratoNameAttr,
                                                   Utility.WebControlType.TextBox,
                                                   Utility.TemplateType.GridViewDataColumn,
                                                   string.Concat("txtContrato", Record.RecordIndex.ToString()),
                                                   "valGet"
                                                  );

                    cContrato.VisibleIndex = Record.RecordIndex;
                    GridCoverages.Columns.Add(cContrato);
                    oTemCompanySelected = new List<int>() { Record.IdCompania.GetValueOrDefault() };
                }

                setCoverageGrid();
                GridCoverages.GroupBy(GridCoverages.Columns["CoverageTypeDesc"]);
                GridCoverages.ExpandAll();

                SetAttributesInCoverageGrid();
                udpCoverages.Update();
            }
            else
            {
                _isFromDataBase = false;
                GenerateGridCoverages();
                setCoverageGrid();
                GridCoverages.GroupBy(GridCoverages.Columns["CoverageTypeDesc"]);
                GridCoverages.ExpandAll();
            }
        }

        private DataTable GetCoveragesFromDB()
        {
            //Obtener las coberturas
            var dCoverages = ObjServices.oPolicyManager.GetFacultativeContractCoverage(new Policy.Facultative.Key
            {
                CorpId = _keyItemSelected.CorpId,
                RegionId = _keyItemSelected.RegionId,
                CountryId = _keyItemSelected.CountryId,
                DomesticregId = _keyItemSelected.DomesticregId,
                StateProvId = _keyItemSelected.StateProvId,
                CityId = _keyItemSelected.CityId,
                OfficeId = _keyItemSelected.OfficeId,
                CaseSeqNo = _keyItemSelected.CaseSeqNo,
                HistSeqNo = _keyItemSelected.HistSeqNo,
                UniqueId = _keyItemSelected.UniqueId
            });

            return
                  dCoverages;
        }

        private void SetAttributesInCoverageGrid()
        {
            DevExpress.Web.GridViewDataColumn cColPercentage;
            Utility.KeyCoverageContract KeyCoverage;
            var jsonKey = string.Empty;
            int ContractCoverageId = 0;

            for (int i = GridCoverages.VisibleStartIndex; i < GridCoverages.VisibleRowCount; i++)
            {
                //Este es el Key de la cobertura
                var CoverageId = GridCoverages.GetKeyFromAspxGridView("CoverageId", i).ToInt();
                var CoverageCorpId = GridCoverages.GetKeyFromAspxGridView("CoverageCorpId", i).ToInt();
                var CoverageRegionId = GridCoverages.GetKeyFromAspxGridView("CoverageRegionId", i).ToInt();
                var CoverageCountryId = GridCoverages.GetKeyFromAspxGridView("CoverageCountryId", i).ToInt();
                var BlTypeId = GridCoverages.GetKeyFromAspxGridView("BlTypeId", i).ToInt();
                var BlId = GridCoverages.GetKeyFromAspxGridView("BlId", i).ToInt();
                var ProductId = GridCoverages.GetKeyFromAspxGridView("ProductId", i).ToInt();
                var VehicleTypeId = GridCoverages.GetKeyFromAspxGridView("VehicleTypeId", i).ToInt();
                var GroupId = GridCoverages.GetKeyFromAspxGridView("GroupId", i).ToInt();
                var CoverageTypeId = GridCoverages.GetKeyFromAspxGridView("CoverageTypeId", i).ToInt();
                //End key de la cobertura                

                if (_keyItemSelected != null)
                {
                    KeyCoverage = new Utility.KeyCoverageContract
                    {
                        //Key de la Poliza
                        CorpId = _keyItemSelected.CorpId,
                        RegionId = _keyItemSelected.RegionId,
                        CountryId = _keyItemSelected.CountryId,
                        DomesticregId = _keyItemSelected.DomesticregId,
                        StateProvId = _keyItemSelected.StateProvId,
                        CityId = _keyItemSelected.CityId,
                        OfficeId = _keyItemSelected.OfficeId,
                        CaseSeqNo = _keyItemSelected.CaseSeqNo,
                        HistSeqNo = _keyItemSelected.HistSeqNo,
                        //End Key de la poliza 

                        UniqueId = _keyItemSelected.UniqueId, //Id del item ejemplo vehiculo, property, navy, airplae

                        //Key de la covertura
                        CoverageId = CoverageId,
                        CoverageCorpId = CoverageCorpId,
                        CoverageRegionId = CoverageRegionId,
                        CoverageCountryId = CoverageCountryId,
                        BlTypeId = BlTypeId,
                        BlId = BlId,
                        ProductId = ProductId,
                        VehicleTypeId = VehicleTypeId,
                        GroupId = GroupId,
                        CoverageTypeId = CoverageTypeId
                        //End Key de la cobertura
                    };

                    var Filter = string.Format("Coverage_Id={0} AND Corp_Id={1} AND Region_Id={2} AND Country_Id={3} AND Bl_Type_Id={4} AND  Bl_Id={5} AND Product_Id={6} AND Vehicle_Type_Id={7} AND Group_Id={8} AND Coverage_Type_Id={9}",
                                                KeyCoverage.CoverageId,
                                                KeyCoverage.CoverageCorpId,
                                                KeyCoverage.CoverageRegionId,
                                                KeyCoverage.CoverageCountryId,
                                                KeyCoverage.BlTypeId,
                                                KeyCoverage.BlId,
                                                KeyCoverage.ProductId,
                                                KeyCoverage.VehicleTypeId,
                                                KeyCoverage.GroupId,
                                                KeyCoverage.CoverageTypeId
                                               );

                    //Buscar las columnas y agregar atributos
                    cColPercentage = GridCoverages.getThisColumn("Retencion") as DevExpress.Web.GridViewDataColumn;
                    var txtPorcientoContractual = GridCoverages.FindRowCellTemplateControl(i, cColPercentage, "txtPorcientoContractual") as TextBox;

                    if (txtPorcientoContractual != null)
                    {
                        DataView dv = null;

                        if (_isFromDataBase)
                        {
                            dv = new DataView(dtCoveragesViewState);
                            dv.RowFilter = Filter;
                            if (dv.Count > 0)
                                ContractCoverageId = dv[0]["Contract_Coverage_Id"].ToInt();
                        }

                        KeyCoverage.CompanyContractId = NameKeyAtlantica;
                        KeyCoverage.NombreContrato = "Retencion";
                        KeyCoverage.ContratctId = 1;
                        KeyCoverage.MontoContrato = 0;
                        KeyCoverage.FechaLimitePago = _isFromDataBase ? (DateTime?)_ContractualPercentageSelected.FechaLimitePago.Date : null;
                        KeyCoverage.PorcCommision = 0;
                        KeyCoverage.ContractCoverageId = _isFromDataBase ? ContractCoverageId : 0;

                        if (dv != null && dv.Count > 0)
                        {
                            var ValueContractualPorc = dv[0][string.Concat("Retencion|", NameKeyAtlantica)];
                            txtPorcientoContractual.Text = ValueContractualPorc.ToString().Replace(",", ".");
                        }

                        jsonKey = Utility.serializeToJSON(KeyCoverage);
                        txtPorcientoContractual.Attributes.Add("data", jsonKey);

                        //Buscar las columnas de contratos
                        foreach (var item in oTemDataContrato)
                        {
                            var cCol = GridCoverages.getThisColumn(item.RecordIndex.ToString()) as DevExpress.Web.GridViewDataColumn;
                            var ControlId = string.Concat("txtContrato", item.RecordIndex.ToString());
                            var txtContratoX = GridCoverages.FindRowCellTemplateControl(i, cCol, ControlId) as TextBox;
                            if (txtContratoX != null)
                            {
                                //Agregar datos del contrato al KeyCoverage
                                KeyCoverage.CompanyContractId = item.IdCompania.GetValueOrDefault();
                                KeyCoverage.ContratctId = _isFromDataBase ? item.IdContrato.GetValueOrDefault() : (item.RecordIndex + 2);
                                KeyCoverage.MontoContrato = item.MontoContrato;
                                KeyCoverage.NombreContrato = item.NombreContrato;
                                KeyCoverage.NameKeyContrato = string.IsNullOrEmpty(KeyCoverage.NameKeyContrato) ? item.NombreContrato
                                                                                                                : KeyCoverage.NameKeyContrato;
                                KeyCoverage.FechaLimitePago = item.FechaLimitePago.Date;
                                KeyCoverage.PorcCommision = item.PorcCommision;
                                KeyCoverage.ContractCoverageId = _isFromDataBase ? ContractCoverageId : 0;
                                jsonKey = Utility.serializeToJSON(KeyCoverage);
                                txtContratoX.Attributes.Add("data", jsonKey);
                                if ((dv != null && dv.Count > 0) && !item.isLocal)
                                {
                                    var ColumnContractName = string.Concat(item.NameKeyContrato, "|", item.IdContrato);
                                    var ValueContract = dv[0][ColumnContractName];
                                    txtContratoX.Text = ValueContract.ToString().Replace(",", ".");
                                }
                            }
                        }

                        SetRetentionByRow(GridCoverages, i);
                    }
                }
            }
        }

        protected void lnkCancelContract_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private Tuple<bool, List<string>> ValidatePercentageCoverage()
        {
            DevExpress.Web.GridViewDataColumn cColPercentage;
            Tuple<bool, List<string>> result;
            List<string> ListError = new List<string>(0);
            var message = "El porciento total de la cobertura \"{0}\" debe ser 100";
            var SumatoriaPorc = 0m;

            //Validar que todas las coberturas tengan un 100%
            for (int i = GridCoverages.VisibleStartIndex; i < GridCoverages.VisibleRowCount; i++)
            {
                //Buscar las columnas y agregar atributos
                cColPercentage = GridCoverages.getThisColumn("Retencion") as DevExpress.Web.GridViewDataColumn;
                var txtPorcientoContractual = GridCoverages.FindRowCellTemplateControl(i, cColPercentage, "txtPorcientoContractual") as TextBox;
                var CoverageName = GridCoverages.GetKeyFromAspxGridView("CoverageName", i).ToString();

                if (txtPorcientoContractual != null)
                {
                    SumatoriaPorc = txtPorcientoContractual.ToDecimal(removeSpecialCharacter: true);

                    foreach (var item in oTemDataContrato)
                    {
                        var cCol = GridCoverages.getThisColumn(item.RecordIndex.ToString()) as DevExpress.Web.GridViewDataColumn;
                        var ControlId = string.Concat("txtContrato", item.RecordIndex.ToString());
                        var txtContratoX = GridCoverages.FindRowCellTemplateControl(i, cCol, ControlId) as TextBox;
                        if (txtContratoX != null)
                            SumatoriaPorc += txtContratoX.ToDecimal(removeSpecialCharacter: true);
                    }

                    if (SumatoriaPorc < 100)
                        ListError.Add(string.Format(message, CoverageName));
                }
            }

            result = new Tuple<bool, List<string>>(ListError.Any(), ListError);

            return
                 result;
        }

        private List<Tuple<string, decimal>> CheckSumCoverages()
        {
            var result = new List<Tuple<string, decimal>>();

            foreach (var item in oTemDataContrato)
            {
                var Sumatory = 0m;

                //Recorro todas las filas para sumar
                for (int i = GridCoverages.VisibleStartIndex; i < GridCoverages.VisibleRowCount; i++)
                {
                    var cCol = GridCoverages.getThisColumn(item.RecordIndex.ToString()) as DevExpress.Web.GridViewDataColumn;
                    var ControlId = string.Concat("txtContrato", item.RecordIndex.ToString());
                    var txtContratoX = GridCoverages.FindRowCellTemplateControl(i, cCol, ControlId) as TextBox;
                    if (txtContratoX != null)
                        Sumatory += txtContratoX.ToDecimal(removeSpecialCharacter: true);
                }

                result.Add(new Tuple<string, decimal>(item.NombreContrato, Sumatory));
            }

            return
                result;
        }

        private bool ValidateCanFacultativeColocation()
        {
            bool result = true;
            //Validar que este en el tab de casos facultativos
            var TabSelected = Utility.ParseEnum<Utility.Tabs>(ObjServices.hdnQuotationTabs);
            if (TabSelected != Utility.Tabs.lnkFacultative)
            {
                this.MessageBox("Para poder hacer la colocacion del facultativo deberas ir al tab de Casos Facultativos");
                result = false;
            }

            //Validar si el usuario logueado tenga los permisos para guardar el facultivo
            if (!ObjServices.IsFacultativeCot && !ObjServices.isUserCot)
            {
                this.MessageBox("No tienes permisos para ejecutar esta accion");
                result = false;
            }

            return
                 result;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var vCoverages = new List<Policy.Facultative.Coverage>(0);
            DevExpress.Web.GridViewDataColumn cColPercentage;
            var ContratosExistentesEnSysFlex = new List<string>(0);

            try
            {
                if (!ValidateCanFacultativeColocation())
                    return;

                var resultValidationContractName = ObjServices.ExisteNombreContratoEnSysFlex(oTemDataContrato);

                if (resultValidationContractName.Item1)
                {
                    this.MessageBox(resultValidationContractName.Item2);
                    return;
                }

                //Validar que el monto factultavivo este completamente distribuido
                var TotalDistribuido = txtTotalDistribuido.ToDecimal(removeSpecialCharacter: true);
                var MotoFacultativo = txtFactultyAmount.ToDecimal(removeSpecialCharacter: true);

                if (TotalDistribuido != MotoFacultativo)
                {
                    this.MessageBox("El monto facultativo debe ser totalmente distribuido");
                    return;
                }

                //Validar que todos los contratos tengan participación
                var ResultChkSum = CheckSumCoverages();

                if (ResultChkSum.Any())
                {
                    var DataValidation = ResultChkSum.Where(c => c.Item2 == 0);

                    string Msg = string.Empty;
                    var counter = 1;

                    if (DataValidation.Any())
                    {
                        foreach (var item in DataValidation)
                        {
                            Msg += string.Concat(counter, ".- ", item.Item1, " debe tener participación al menos en un cobertura </br></br>");
                            counter++;
                        }

                        this.MessageBox(Msg, Width: 800);
                        return;
                    }
                }

                //Validar que los porcientos de todas las coberturas esten correctos
                var resultValidate = ValidatePercentageCoverage();

                if (resultValidate.Item1)
                {
                    string Msg = string.Empty;
                    //Desplegar Mensaje de error
                    var counter = 1;
                    foreach (var item in resultValidate.Item2)
                    {
                        Msg += string.Concat(counter, ".- ", item, "</br></br>");
                        counter++;
                    }

                    this.MessageBox(Msg, Width: 800);
                    return;
                }

                var CoverageCount = 1;
                var RetencionCount = 1;


                udpCoverages.Update();

                for (int i = GridCoverages.VisibleStartIndex; i < GridCoverages.VisibleRowCount; i++)
                {
                    //Buscar las columnas y agregar atributos
                    cColPercentage = GridCoverages.getThisColumn("Retencion") as DevExpress.Web.GridViewDataColumn;
                    var txtPorcientoContractual = GridCoverages.FindRowCellTemplateControl(i, cColPercentage, "txtPorcientoContractual") as TextBox;

                    if (txtPorcientoContractual != null)
                    {
                        var Data = txtPorcientoContractual.Attributes["data"];

                        if (!string.IsNullOrEmpty(Data))
                        {
                            var oData = Utility.deserializeJSON<Utility.KeyCoverageContract>(Data);
                            var PayDate = _isFromDataBase ? oData.FechaLimitePago.GetValueOrDefault().Date : DateTime.Now;

                            vCoverages.Add(new Policy.Facultative.Coverage
                            {
                                Corp_Id = oData.CoverageCorpId,
                                Contract_Id = oData.ContratctId,
                                Company_Facultative_Id = oData.CompanyContractId,
                                Contract_Name = oData.NombreContrato,
                                Contract_Amount = oData.MontoContrato,
                                Contract_Commission_Percentage = oData.PorcCommision,
                                Contract_Coverage_Id = _isFromDataBase ? oData.ContractCoverageId : RetencionCount,
                                Region_Id = oData.CoverageRegionId,
                                Country_Id = oData.CoverageCountryId,
                                Bl_Type_Id = oData.BlTypeId,
                                Bl_Id = oData.BlId,
                                Product_Id = oData.ProductId,
                                Vehicle_Type_Id = oData.VehicleTypeId,
                                Group_Id = oData.GroupId,
                                Coverage_Type_Id = oData.CoverageTypeId,
                                Coverage_Id = oData.CoverageId,
                                Contract_Coverage_Percentage = txtPorcientoContractual.Text.ToDecimal(),
                                Contract_Coverage_Status = 1,
                                PaymentDate = PayDate.Date
                            });

                            RetencionCount++;
                        }

                        ////Buscar las columnas de contratos
                        foreach (var item in oTemDataContrato)
                        {
                            var cCol = GridCoverages.getThisColumn(item.RecordIndex.ToString()) as DevExpress.Web.GridViewDataColumn;
                            var ControlId = string.Concat("txtContrato", item.RecordIndex.ToString());
                            var txtContratoX = GridCoverages.FindRowCellTemplateControl(i, cCol, ControlId) as TextBox;
                            if (txtContratoX != null)
                            {
                                var DataContrato = txtContratoX.Attributes["data"];

                                if (!string.IsNullOrEmpty(DataContrato))
                                {
                                    var oData = Utility.deserializeJSON<Utility.KeyCoverageContract>(DataContrato);

                                    vCoverages.Add(new Policy.Facultative.Coverage
                                    {
                                        Corp_Id = oData.CoverageCorpId,
                                        Contract_Id = oData.ContratctId,
                                        Company_Facultative_Id = oData.CompanyContractId,
                                        Contract_Name = oData.NombreContrato,
                                        Contract_Amount = oData.MontoContrato,
                                        Contract_Commission_Percentage = oData.PorcCommision,
                                        Contract_Coverage_Id = _isFromDataBase ? oData.ContractCoverageId : CoverageCount,
                                        Region_Id = oData.CoverageRegionId,
                                        Country_Id = oData.CoverageCountryId,
                                        Bl_Type_Id = oData.BlTypeId,
                                        Bl_Id = oData.BlId,
                                        Product_Id = oData.ProductId,
                                        Vehicle_Type_Id = oData.VehicleTypeId,
                                        Group_Id = oData.GroupId,
                                        Coverage_Type_Id = oData.CoverageTypeId,
                                        Coverage_Id = oData.CoverageId,
                                        Contract_Coverage_Percentage = txtContratoX.ToDecimal(),
                                        Contract_Coverage_Status = 1,
                                        PaymentDate = oData.FechaLimitePago.GetValueOrDefault().Date
                                    });
                                }
                            }
                        }

                        CoverageCount++;
                    }
                }

                if (vCoverages.Any())
                {
                    var dtResult = ObjServices.oPolicyManager.SetFacultativeContractCoverage(new Policy.Facultative.SetContractCoverage
                    {
                        CorpId = _keyItemSelected.CorpId,
                        RegionId = _keyItemSelected.RegionId,
                        CountryId = _keyItemSelected.CountryId,
                        DomesticregId = _keyItemSelected.DomesticregId,
                        StateProvId = _keyItemSelected.StateProvId,
                        CityId = _keyItemSelected.CityId,
                        OfficeId = _keyItemSelected.OfficeId,
                        CaseSeqNo = _keyItemSelected.CaseSeqNo,
                        HistSeqNo = _keyItemSelected.HistSeqNo,
                        UniqueId = _keyItemSelected.UniqueId,
                        Coverages = vCoverages,
                        UserId = ObjServices.UserID.GetValueOrDefault()
                    });

                    var Code = dtResult.Rows[0]["Code"].ToString();
                    var Message = dtResult.Rows[0]["Message"].ToString();

                    if (Code == "-1")
                        this.MessageBox(Message.RemoveInvalidCharacters().Replace('\'', '\"'));
                    else
                    {
                        FillData();
                        #region Codigo comentado
                        //var js = string.Format("DisplayResultSaveFacultative({0},'{1}')", _keyItemSelected.UniqueId.ToString(), _keyItemSelected.IdGrid);
                        //lnkCancelContract_Click(lnkCancelContract, null);
                        //this.ExcecuteJScript(js);
                        #endregion
                        this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.SaveSucessfully);
                    }
                }
            }
            catch (Exception ex)
            {
                var MessageEx = ex.Message.Replace('\'', '\"').MyRemoveInvalidCharacters();
                (this.Page as BasePage).ErrorDescription = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
                var msg = string.Format("{0}  <br> <br> Presione Ok para descargar un archivo con el detalle del error", MessageEx);
                this.CustomDialogMessageWithCallBack(msg, "function(){$('#btnGenerateFileError').click();}", "Error", "", "");
            }
        }

        protected void gvCoverages_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var Grid = (sender as ASPxGridView);

            if (e.RowType == GridViewRowType.Data)
                SetRetentionByRow(Grid, e.VisibleIndex);
        }

        private void SetRetentionByRow(ASPxGridView Grid, int Index)
        {
            var CoverageTypeDesc = Grid.GetKeyFromAspxGridView("CoverageTypeDesc", Index, defaultValue: string.Empty).ToString();

            if (Coverage100PocRetencion.Contains(CoverageTypeDesc))
            {
                var txtPorcientoContractual = Grid.FindRowCellTemplateControl(Index, null, "txtPorcientoContractual") as TextBox;
                var hdntxtPorcientoContractual = Grid.FindRowCellTemplateControl(Index, null, "hdntxtPorcientoContractual") as HiddenField;
                if (txtPorcientoContractual != null)
                {
                    txtPorcientoContractual.Text = txtPorcientoContractual.Text == "0.00" ? "100" : txtPorcientoContractual.Text;
                    if (hdntxtPorcientoContractual != null)
                        hdntxtPorcientoContractual.Value = txtPorcientoContractual.Text;
                }
            }
        }

        protected void gvContrato_PreRender(object sender, EventArgs e)
        {
            (sender as DevExpress.Web.ASPxGridView).TranslateColumnsAspxGrid();
        }
    }
}