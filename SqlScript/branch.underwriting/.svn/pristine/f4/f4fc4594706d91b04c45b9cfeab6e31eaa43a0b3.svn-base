using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines
{
    public partial class UCBailDetail : UC, IUC
    {
        public Utility.Bail oBail { get; set; }
        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

        public DropDownList ddlIdentificationTypeId { get; set; }
        public TextBox txtIdentification { get; set; }
        public TextBox txtName { get; set; }
        public TextBox txtLastName { get; set; }
        public TextBox txtEmail { get; set; }
        public TextBox txtPhone { get; set; }
        public TextBox txtAddress { get; set; }
        public DropDownList ddlCountryId { get; set; }
        public DropDownList ddlStateProvId { get; set; }
        public DropDownList ddlCityId { get; set; }
        public DropDownList ddlMunicipaly { get; set; }
        public DropDownList ddlNationalityCountryId { get; set; }
        public TextBox txtRepresentativeName { get; set; }
        public DropDownList ddlRepresentativeIdentificationTypeId { get; set; }
        public TextBox txtRepresentativeIdentification { get; set; }


        public enum TipoProducto { OtrasFianzas, FianzasConstruccion, FianzasAduanales, FianzasComerciales };


        private void HideOrShow(String Product)
        {
            var DataConfig = ObjServices.GettingDropData(
                                                        Utility.DropDownType.ProjectConfigurationValue,
                                                        corpId: ObjServices.Corp_Id,
                                                        pProjectId: int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectIdNewBusiness"])
                                                        );

            bool entro = false;
            if (DataConfig != null)
            {
                var DataFields = DataConfig.FirstOrDefault(h => h.Namekey == Product);
                if (DataFields != null)
                {
                    var Fields = DataFields.ConfigurationValue.Split(',');

                    foreach (GridViewColumn item in gvBailExtraInfo.Columns)
                        item.Visible = false;

                    foreach (var item in Fields)
                    {
                        var Column = gvBailExtraInfo.Columns[item];

                        if (Column != null)
                        {
                            Column.Visible = true;
                            entro = true;
                        }
                    }

                    if (entro)
                        fieldSetFeatures.Visible = true;
                }
            }

            if (entro == false)
                fieldSetFeatures.Visible = false;
        }

        public int UniqueBailId
        {
            get
            {
                return ViewState["UniqueBailId"].ToInt();
            }
            set
            {
                ViewState["UniqueBailId"] = value;
            }
        }

        private bool isInsertingNewRecord
        {
            get
            {
                return ViewState["isInsertingNewRecord"].ToBoolean();
            }
            set
            {
                ViewState["isInsertingNewRecord"] = value;
            }
        }

        private List<Utility.Guarantors> dataFeatureTemp = new List<Utility.Guarantors>(0);

        public List<Utility.Guarantors> oTemDataFeature
        {
            get
            {
                return ViewState["TemDataFeature"] == null ?
                    new List<Utility.Guarantors>() :
                    ViewState["TemDataFeature"] as List<Utility.Guarantors>;
            }

            set
            {
                List<Utility.Guarantors> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.Guarantors>(
                            ViewState["TemDataFeature"] != null
                            ?
                            (
                               (List<Utility.Guarantors>)ViewState["TemDataFeature"]
                            )
                            :
                            new List<Utility.Guarantors>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemDataFeature"] = tempList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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
            #region CodigoComentado
            /*int UniqueBailID = hdnUniqueBailID.Value.ToInt();
            var param = ObjServices.oBailManager.GetBailInsured(new Entity.UnderWriting.Entities.Bail.Insured.Key
                       {
                           CorpId = ObjServices.Corp_Id,
                           RegionId = ObjServices.Region_Id,
                           CountryId = ObjServices.Country_Id,
                           DomesticRegId = ObjServices.Domesticreg_Id,
                           StateProvId = ObjServices.State_Prov_Id,
                           CityId = ObjServices.City_Id,
                           OfficeId = ObjServices.Office_Id,
                           CaseSeqNo = ObjServices.Case_Seq_No,
                           HistSeqNo = ObjServices.Hist_Seq_No
                       }).FirstOrDefault((h => h.UniqueBailId == UniqueBailID));

            param.EquipmentQty = txtEquipmentQty.Text.ToInt();

            ObjServices.oBailManager.SetBailInsured(param);

            this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.FormCreated, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Success);*/
            #endregion
        }

        private bool isValid()
        {
            #region CodigoComentado
            /* if (string.IsNullOrEmpty(txtEquipmentQty.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Name));
                 return false;
             }*/
            #endregion
            return true;
        }

        public void edit()
        {
            throw new NotImplementedException();
        }


        public void FillData()
        {

            hdnProductName.Value = oBail.ProductDesc.Replace(" ", "").TrimStart().TrimEnd();
            txt_producto.Text = oBail.ProductDesc;
            var PConditionPropertyList = ObjServices.oPolicyManager
                                                  .GetConditionIL(ObjServices.Policy_Id, oBail.UniqueBailId)
                                                  .Where(c => !c.descripcion.ToLower().Contains("endoso")).ToList();

            rpCondiciones.DataSource = PConditionPropertyList;
            rpCondiciones.DataBind();

            hdnUniqueBailID.Value = oBail.UniqueBailId.ToString(CultureInfo.InvariantCulture);
            UniqueBailId = oBail.UniqueBailId.ToInt();

            FillGrid();
        }

        protected void gvBailExtraInfo_PageIndexChanged(object sender, EventArgs e)
        {
            if (!isInsertingNewRecord)
                FillGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (isInsertingNewRecord)
                return;

            dataFeatureTemp.Add(new Utility.Guarantors
            {
                isLocal = true,
                CorpId = ObjServices.Corp_Id,
                UniqueBailId = UniqueBailId,
                SeqId = -1,
                IdentificationTypeId = 0,
                Identification = string.Empty,
                Name = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Phone = string.Empty,
                Address = string.Empty,
                CountryId = 0,
                DomesticregId = 0,
                StateProvId = 0,
                CityId = 0,
                NationalityCountryId = 0,
                RepresentativeName = string.Empty,
                RepresentativeIdentificationTypeId = null,
                RepresentativeIdentification = string.Empty,
                BaileeStatusId = 1,
                CityDesc = string.Empty,
                CountryDesc = string.Empty,
                IdentificationTypeDesc = string.Empty,
                NationalityCountryDesc = string.Empty,
                RepresentativeIdentificationTypeDesc = string.Empty,
                Sector = string.Empty,
            });

            isInsertingNewRecord = true;

            oTemDataFeature = dataFeatureTemp;
            FillGrid(true);
            gvBailExtraInfo.PageIndex = gvBailExtraInfo.PageCount;
            var Index = oTemDataFeature.Count - 1;
            var script = string.Format("__doPostBack('ctl00$bodyContent$UCAlliedLinesDetail$UCBail$UCBailDetail$gvBailExtraInfo$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        public void FillGrid(bool AddLocal = false)
        {
            var parameter = new Bail.Insured.Guarantors.Key
            {
                CorpId = ObjServices.Corp_Id,
                UniqueBailId = UniqueBailId,
                SeqId = null
            };

            if (!AddLocal)
            {
                oTemDataFeature = null;
                oTemDataFeature = ObjServices.oBailManager.GetBailInsuredGuarantors(parameter)
                    .Select(v => new Utility.Guarantors
                    {
                        isLocal = false,
                        CorpId = ObjServices.Corp_Id,
                        UniqueBailId = UniqueBailId,
                        SeqId = v.SeqId,
                        IdentificationTypeId = v.IdentificationTypeId,
                        Identification = v.Identification,
                        Name = v.Name,
                        LastName = v.LastName,
                        Email = v.Email,
                        Phone = v.Phone,
                        Address = v.Address,
                        CountryId = v.CountryId,
                        DomesticregId = v.DomesticregId,
                        StateProvId = v.StateProvId,
                        CityId = v.CityId,
                        NationalityCountryId = v.NationalityCountryId,
                        RepresentativeName = v.RepresentativeName,
                        RepresentativeIdentificationTypeId = v.RepresentativeIdentificationTypeId,
                        RepresentativeIdentification = v.RepresentativeIdentification,
                        BaileeStatusId = v.BaileeStatusId,
                        TipoRiesgoNameKey = v.TipoRiesgoNameKey == "N/A" ? "NONE" : v.TipoRiesgoNameKey,
                        FinancialClearance = !string.IsNullOrEmpty(v.TipoRiesgoNameKey) ? Utility.GetImgRiesgo((Utility.TipoRiesgo)Enum.Parse(typeof(Utility.TipoRiesgo), v.TipoRiesgoNameKey == "N/A" ? "NONE" : v.TipoRiesgoNameKey))
                                                                                        : string.Empty,
                        CityDesc = v.CityDesc,
                        CountryDesc = v.CountryDesc,
                        NationalityCountryDesc = v.NationalityCountryDesc,
                        IdentificationTypeDesc = v.IdentificationTypeDesc,
                        RepresentativeIdentificationTypeDesc = v.RepresentativeIdentificationTypeDesc,
                        Sector = v.Sector,
                        MunicipioId = v.MunicipioId,
                        MunicipioDesc = v.MunicipioDesc,
                        ClassNameTU = v.IdentificationTypeDesc.ToLower() == "id" ? "view_file" : "view_file_dbl",
                        isEnableTU = v.IdentificationTypeDesc.ToLower() == "id"
                    }).ToList();
            }

            gvBailExtraInfo.DataSource = oTemDataFeature;
            gvBailExtraInfo.DataBind();

            HideOrShow(hdnProductName.Value);
        }

        public void Initialize()
        {
            var isEfective = (ObjServices.StatusNameKey == "EFECT");
            ClearData();
            FillData();
            dvPropertyFeature.Enabled = !isEfective;
            var cOperation = gvBailExtraInfo.getThisColumn("Operation");
            if (cOperation != null)
                cOperation.Visible = !isEfective;
        }

        public void ClearData()
        {
            Utility.ClearAll(this.Controls);
        }

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            ddlIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlIdentificationTypeId") as DropDownList;
            txtIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtIdentification") as TextBox;
            txtName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtName") as TextBox;
            txtLastName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtLastName") as TextBox;
            txtEmail = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEmail") as TextBox;
            txtPhone = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPhone") as TextBox;
            txtAddress = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtAddress") as TextBox;
            ddlCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCountryId") as DropDownList;
            ddlMunicipaly = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlMunicipality") as DropDownList;
            //ddlDomesticregId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlDomesticregId") as DropDownList;
            ddlStateProvId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlStateProvId") as DropDownList;
            ddlCityId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCityId") as DropDownList;
            ddlNationalityCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlNationalityCountryId") as DropDownList;
            txtRepresentativeName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtRepresentativeName") as TextBox;
            ddlRepresentativeIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlRepresentativeIdentificationTypeId") as DropDownList;
            txtRepresentativeIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtRepresentativeIdentification") as TextBox;
        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex, Utility.Guarantors Record = null)
        {
            ddlIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlIdentificationTypeId") as DropDownList;
            var ltIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltIdentificationTypeId") as Control;

            txtIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtIdentification") as TextBox;
            var ltIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltIdentification") as Control;

            txtName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtName") as TextBox;
            var ltName = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltName") as Control;

            txtLastName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtLastName") as TextBox;
            var ltLastName = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltLastName") as Control;

            txtEmail = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEmail") as TextBox;
            var ltEmail = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltEmail") as Control;

            txtPhone = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPhone") as TextBox;
            var ltPhone = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPhone") as Control;

            txtAddress = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtAddress") as TextBox;
            var ltAddress = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltAddress") as Control;

            ddlCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCountryId") as DropDownList;
            var ltCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCountryId") as Control;

            ddlMunicipaly = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlMunicipality") as DropDownList;
            var ltMunicipaly = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltMunicipaly") as Control;

            //ddlDomesticregId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlDomesticregId") as DropDownList;
            //var ltDomesticregId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltDomesticregId") as Control;

            ddlStateProvId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlStateProvId") as DropDownList;
            var ltStateProvId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltStateProvId") as Control;

            ddlCityId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCityId") as DropDownList;
            var ltCityId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCityId") as Control;

            ddlNationalityCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlNationalityCountryId") as DropDownList;
            var ltNationalityCountryId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltNationalityCountryId") as Control;

            txtRepresentativeName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtRepresentativeName") as TextBox;
            var ltRepresentativeName = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltRepresentativeName") as Control;

            ddlRepresentativeIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlRepresentativeIdentificationTypeId") as DropDownList;
            var ltRepresentativeIdentificationTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltRepresentativeIdentificationTypeId") as Control;

            txtRepresentativeIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtRepresentativeIdentification") as TextBox;
            var ltRepresentativeIdentification = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltRepresentativeIdentification") as Control;

            if (ddlIdentificationTypeId != null) ddlIdentificationTypeId.Visible = isEdit;
            if (ltIdentificationTypeId != null) ltIdentificationTypeId.Visible = !isEdit;

            if (txtIdentification != null) txtIdentification.Visible = isEdit;
            if (ltIdentification != null) ltIdentification.Visible = !isEdit;

            if (txtName != null) txtName.Visible = isEdit;
            if (ltName != null) ltName.Visible = !isEdit;

            if (txtLastName != null) txtLastName.Visible = isEdit;
            if (ltLastName != null) ltLastName.Visible = !isEdit;

            if (txtEmail != null) txtEmail.Visible = isEdit;
            if (ltEmail != null) ltEmail.Visible = !isEdit;

            if (txtPhone != null) txtPhone.Visible = isEdit;
            if (ltPhone != null) ltPhone.Visible = !isEdit;

            if (txtAddress != null) txtAddress.Visible = isEdit;
            if (ltAddress != null) ltAddress.Visible = !isEdit;

            if (ddlCountryId != null) ddlCountryId.Visible = isEdit;
            if (ltCountryId != null) ltCountryId.Visible = !isEdit;

            if (ddlMunicipaly != null) ddlMunicipaly.Visible = isEdit;
            if (ltMunicipaly != null) ltMunicipaly.Visible = !isEdit;

            //if (ddlDomesticregId != null) ddlDomesticregId.Visible = isEdit;
            //if (ltDomesticregId != null) ltDomesticregId.Visible = !isEdit;

            if (ddlStateProvId != null) ddlStateProvId.Visible = isEdit;
            if (ltStateProvId != null) ltStateProvId.Visible = !isEdit;

            if (ddlCityId != null) ddlCityId.Visible = isEdit;
            if (ltCityId != null) ltCityId.Visible = !isEdit;

            if (ddlNationalityCountryId != null) ddlNationalityCountryId.Visible = isEdit;
            if (ltNationalityCountryId != null) ltNationalityCountryId.Visible = !isEdit;

            if (txtRepresentativeName != null) txtRepresentativeName.Visible = isEdit;
            if (ltRepresentativeName != null) ltRepresentativeName.Visible = !isEdit;

            if (ddlRepresentativeIdentificationTypeId != null) ddlRepresentativeIdentificationTypeId.Visible = isEdit;
            if (ltRepresentativeIdentificationTypeId != null) ltRepresentativeIdentificationTypeId.Visible = !isEdit;

            if (txtRepresentativeIdentification != null) txtRepresentativeIdentification.Visible = isEdit;
            if (ltRepresentativeIdentification != null) ltRepresentativeIdentification.Visible = !isEdit;

            //Pais
            if (ddlCountryId != null && ddlCountryId.Items.Count <= 0)
            {
                var allCountrys = ObjServices.GettingDropData(Utility.DropDownType.Country);

                ddlCountryId.DataSource = allCountrys.GroupBy(p => new { p.CountryId, p.GlobalCountryDesc })
                                .Select(g => g.First())
                                .ToList();
                ddlCountryId.DataTextField = "GlobalCountryDesc";
                ddlCountryId.DataValueField = "CountryId";
                ddlCountryId.DataBind();
                ddlCountryId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            //Nacionalidad
            if (ddlNationalityCountryId != null && ddlNationalityCountryId.Items.Count <= 0)
            {
                var allCountrys = ObjServices.GettingDropData(Utility.DropDownType.Country);

                ddlNationalityCountryId.DataSource = allCountrys.GroupBy(p => new { p.CountryId, p.GlobalCountryDesc })
                                .Select(g => g.First())
                                .ToList();
                ddlNationalityCountryId.DataTextField = "GlobalCountryDesc";
                ddlNationalityCountryId.DataValueField = "CountryId";
                ddlNationalityCountryId.DataBind();
                ddlNationalityCountryId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlIdentificationTypeId != null && ddlIdentificationTypeId.Items.Count <= 0)
            {
                var allIDentifications = ObjServices.GettingDropData(Utility.DropDownType.IdType);
                int[] notId = new int[] { 0, 6, 7 };

                ddlIdentificationTypeId.DataSource = allIDentifications.Where(x => !notId.Contains(x.ContactTypeId.GetValueOrDefault())).ToList();
                ddlIdentificationTypeId.DataTextField = "ContactTypeIdDesc";
                ddlIdentificationTypeId.DataValueField = "ContactTypeId";
                ddlIdentificationTypeId.DataBind();
                ddlIdentificationTypeId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlRepresentativeIdentificationTypeId != null && ddlRepresentativeIdentificationTypeId.Items.Count <= 0)
            {
                var allIDentifications = ObjServices.GettingDropData(Utility.DropDownType.IdType);
                int[] notId = new int[] { 0, 6, 7 };

                ddlRepresentativeIdentificationTypeId.DataSource = allIDentifications.Where(x => !notId.Contains(x.ContactTypeId.GetValueOrDefault())).ToList();
                ddlRepresentativeIdentificationTypeId.DataTextField = "ContactTypeIdDesc";
                ddlRepresentativeIdentificationTypeId.DataValueField = "ContactTypeId";
                ddlRepresentativeIdentificationTypeId.DataBind();
                ddlRepresentativeIdentificationTypeId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }
        }

        protected void gvBailExtraInfo_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var UniqueBailId = grid.GetKeyFromAspxGridView("UniqueBailId", e.VisibleIndex).ToInt();
            var seqId = grid.GetKeyFromAspxGridView("SeqId", e.VisibleIndex).ToInt();
            var BaileeStatusId = grid.GetKeyFromAspxGridView("BaileeStatusId", e.VisibleIndex).ToInt();
            var IdentificationTypeDesc = grid.GetKeyFromAspxGridView("IdentificationTypeDesc", e.VisibleIndex).ToString().ToLower();
            var Identification = grid.GetKeyFromAspxGridView("Identification", e.VisibleIndex).ToString();
            var TipoRiesgoNameKey = grid.GetKeyFromAspxGridView("TipoRiesgoNameKey", e.VisibleIndex).ToString();
            var MunicipioId = grid.GetKeyFromAspxGridView("MunicipioId", e.VisibleIndex).ToInt();
            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;

            var Record = (isInsertingNewRecord) ? oTemDataFeature.Last()
                                                : oTemDataFeature.FirstOrDefault(r => r.SeqId == seqId);

            var DomecticRegId = hdnDomecticRegId.Value.ToInt();

            switch (Command)
            {
                case "DeleteFeature":
                    ObjServices.oBailManager.SetBailInsuredGuarantors(new Bail.Insured.Guarantors.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueBailId = UniqueBailId,
                        SeqId = seqId,
                        BaileeStatusId = 0
                    });

                    FillGrid();                   
                    break;
                case "Cancel":
                    //Borrar todos los registros locales
                    var hasRecordLocal = oTemDataFeature.Any(p => p.isLocal);

                    if (hasRecordLocal)
                    {
                        var result = oTemDataFeature.Where(p => !p.isLocal).ToList();
                        oTemDataFeature = null;
                        oTemDataFeature = result;
                        FillGrid(hasRecordLocal);
                        gvBailExtraInfo.PageIndex = 0;
                    }

                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    btnEditOrSave.CommandName = "EditFeature";
                    isInsertingNewRecord = false;
                    break;
                case "EditFeature":
                    if (btnCancel != null) btnCancel.Visible = true;
                    if (btnDelete != null) btnDelete.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "mysave_file";
                    btnEditOrSave.CommandName = "SaveFeature";
                    EditMode(true, grid, e.VisibleIndex, Record);

                    if (Record.CountryId > 0)
                    {
                        ddlCountryId.SelectedValue = Record.CountryId.Value.ToString();
                        ddlCountryIdSelectedIndexChanged(ddlCountryId, null);
                    }

                    if (Record.NationalityCountryId > 0)
                        ddlNationalityCountryId.SelectedValue = Record.NationalityCountryId.Value.ToString();

                    if (Record.StateProvId > 0)
                    {
                        var dbState = new Utility.StateProvince()
                        {
                            CorpId = Record.CorpId.HasValue ? Record.CorpId.Value : 0,
                            CountryId = Record.CountryId.Value,
                            DomesticregId = Record.DomesticregId.HasValue ? Record.DomesticregId.Value : 0,
                            RegionId = 24,//Puesto asi hasta que se vea de dond debe venir este dato que no esta en la tabla de los garantes
                            StateProvId = Record.StateProvId.HasValue ? Record.StateProvId.Value : 0
                        };

                        var x = Utility.serializeToJSON(dbState);
                        ddlStateProvId.SelectIndexByValueJSON(x);

                        ddlStateProvId_SelectedIndexChanged(ddlStateProvId, null);

                        //Seleccionar el municipio          
                        var M = Utility.serializeToJSON(new Utility.Municipaly
                                {
                                    CorpId = dbState.CorpId,
                                    RegionId = dbState.RegionId,
                                    CountryId = dbState.CountryId,
                                    DomesticregId = dbState.DomesticregId,
                                    StateProvId = dbState.StateProvId,
                                    CityId = MunicipioId,
                                }
                        );

                        ddlMunicipaly.SelectIndexByValueJSON(M);

                        ddlMunicipality_SelectedIndexChanged(ddlMunicipaly, null);

                    }

                    if (Record.CityId > 0)
                        ddlCityId.SelectedValue = Record.CityId.Value.ToString();

                    if (Record.IdentificationTypeId > 0)
                        ddlIdentificationTypeId.SelectedValue = Record.IdentificationTypeId.ToString();

                    if (Record.RepresentativeIdentificationTypeId.HasValue)
                        ddlRepresentativeIdentificationTypeId.SelectedValue = Record.RepresentativeIdentificationTypeId.Value.ToString();

                    break;
                case "InfCredit":

                    var KRiesgos = new[]
                    {                 
                        Utility.TipoRiesgo.RA,
                        Utility.TipoRiesgo.RB,
                        Utility.TipoRiesgo.RM
                    };

                    //Verificar si ya se hizo la verificacion crediticia
                    var keyRiesgo = TipoRiesgoNameKey == "N/A" || string.IsNullOrEmpty(TipoRiesgoNameKey) ? "NONE" : TipoRiesgoNameKey;

                    if ((keyRiesgo == null))
                    {
                        this.MessageBox(Resources.DontViewInfoCredit);
                        return;
                    }

                    if (!KRiesgos.Contains((Utility.TipoRiesgo)Enum.Parse(typeof(Utility.TipoRiesgo), keyRiesgo)))
                    {
                        this.MessageBox(Resources.DontViewInfoCredit);
                        return;
                    }

                    if (IdentificationTypeDesc == "id")
                    {
                        #region TransUnion
                        var pCedulaOrDriverLicense = Identification.Replace("-", "").RemoveInvalidCharacters().RemoveAccentsWithRegEx();
                        //var pCedulaOrDriverLicense = "223-0085773-1";
                        var url = "'http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/NewBusiness/Pages/Transunion.aspx?data={0}'";
                        var func = string.Format("$('#ifrmTransunion').attr('src'," + url + ")", HttpUtility.UrlEncode(Utility.Encrypt_Query(pCedulaOrDriverLicense + "|" + keyRiesgo)));
                        this.ExcecuteJScript(func);
                        hdnPopTransunion.Value = "true";
                        mpeTransunion.Show();
                        #endregion
                    }
                    break;
                case "SaveFeature":
                    btnEditOrSave.CommandName = "EditFeature";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    SetControls(grid, e.VisibleIndex);

                    var KeyStateProvince = Utility.deserializeJSON<Utility.StateProvince>(ddlStateProvId.SelectedValue);
                    int county = 0;
                    int state = 0;
                    if (KeyStateProvince != null)
                    {
                        state = KeyStateProvince.StateProvId;
                        county = KeyStateProvince.CountryId;
                    }

                    var parameter = new Bail.Insured.Guarantors.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueBailId = UniqueBailId,
                        SeqId = seqId,
                        IdentificationTypeId = ddlIdentificationTypeId != null ? ddlIdentificationTypeId.SelectedValue.ToInt() : 0,
                        Identification = txtIdentification != null ? txtIdentification.Text : string.Empty,
                        Name = txtName != null ? txtName.Text : string.Empty,
                        LastName = txtLastName != null ? txtLastName.Text : string.Empty,
                        Email = txtEmail != null ? txtEmail.Text : string.Empty,
                        Phone = txtPhone != null ? txtPhone.Text : string.Empty,
                        Address = txtAddress != null ? txtAddress.Text : string.Empty,
                        CountryId = county > 0 ? county : (int?)null,
                        DomesticregId = DomecticRegId > 0 ? DomecticRegId : (int?)null,
                        StateProvId = state > 0 ? state : (int?)null,
                        CityId = ddlCityId != null ? ddlCityId.SelectedValue.ToInt() : (int?)null,
                        NationalityCountryId = ddlNationalityCountryId != null ? ddlNationalityCountryId.SelectedValue.ToInt() : (int?)null,
                        RepresentativeName = txtRepresentativeName != null ? txtRepresentativeName.Text : string.Empty,
                        RepresentativeIdentificationTypeId = ddlRepresentativeIdentificationTypeId != null ? ddlRepresentativeIdentificationTypeId.SelectedValue.ToInt() : (int?)null,
                        RepresentativeIdentification = txtRepresentativeIdentification != null ? txtRepresentativeIdentification.Text : string.Empty,
                        BaileeStatusId = BaileeStatusId,
                        TipoRiesgoNameKey = txtIdentification.Text.ToLower() != "id" ? "N/A" : TipoRiesgoNameKey,
                        UserId = ObjServices.UserID
                    };

                    ObjServices.oBailManager.SetBailInsuredGuarantors(parameter);
                    FillGrid();
                    isInsertingNewRecord = false;
                    break;
            }
        }

        protected void gvBailExtraInfo_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);
            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                save();
                BindGrid();
            }
        }

        protected void ddlCountryIdSelectedIndexChanged(object sender, EventArgs e)
        {
            var Container = ((DevExpress.Web.GridViewDataItemTemplateContainer)((DropDownList)sender).NamingContainer);
            var Index = Container.ItemIndex;

            SetControls(gvBailExtraInfo, Index);

            var drop = (sender as DropDownList);

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                ddlStateProvId.DataSource = ObjServices.GettingDropData(Utility.DropDownType.StateProvince,
                                            corpId: ObjServices.Corp_Id,
                                            countryId: drop.ToInt());

                ddlStateProvId.DataTextField = "StateProvDesc";
                ddlStateProvId.DataValueField = "ValueField";
                ddlStateProvId.DataBind();
                ddlStateProvId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }
        }

        protected void ddlStateProvId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Container = ((DevExpress.Web.GridViewDataItemTemplateContainer)((DropDownList)sender).NamingContainer);
            var Index = Container.ItemIndex;

            SetControls(gvBailExtraInfo, Index);

            var drop = (sender as DropDownList);
            var KeyStateProvince = Utility.deserializeJSON<Utility.StateProvince>(drop.SelectedValue);
            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                ddlMunicipaly.DataSource = ObjServices.GettingDropData(Utility.DropDownType.Municipio,
                                                                      stateProvId: KeyStateProvince.StateProvId,
                                                                      domesticregId: KeyStateProvince.DomesticregId,
                                                                      countryId: KeyStateProvince.CountryId
                                                                      );

                ddlMunicipaly.DataTextField = "StateProvDesc";
                ddlMunicipaly.DataValueField = "ValueField";
                ddlMunicipaly.DataBind();
                ddlMunicipaly.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }
        }

        protected void ddlIdentificationTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Container = ((DevExpress.Web.GridViewDataItemTemplateContainer)((DropDownList)sender).NamingContainer);
            var Index = Container.ItemIndex;

            SetControls(gvBailExtraInfo, Index);

            var drop = (sender as DropDownList);

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                //data-inputmask="'mask': '999-9999999-9'" 
                switch (drop.SelectedValue)
                {
                    case "1":
                    case "3":
                        txtIdentification.Attributes.Add("data-inputmask=\"'mask': '999-9999999-9'\"", "");
                        break;
                    case "5":
                        txtIdentification.Attributes.Add("data-inputmask=\"'mask': '999-99999-9'\"", "");
                        break;
                    default:
                        txtIdentification.Attributes.Remove("data-inputmask=\"'mask': '999-9999999-9'\"");
                        break;
                }
            }
        }

        protected void ddlRepresentativeIdentificationTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Container = ((DevExpress.Web.GridViewDataItemTemplateContainer)((DropDownList)sender).NamingContainer);
            var Index = Container.ItemIndex;

            SetControls(gvBailExtraInfo, Index);

            var drop = (sender as DropDownList);

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            { //data-inputmask="'mask': '999-9999999-9'" 
                switch (drop.SelectedValue)
                {
                    case "1":
                    case "3":
                        txtIdentification.Attributes.Add("data-inputmask=\"'mask': '999-9999999-9'\"", "");
                        break;
                    case "5":
                        txtIdentification.Attributes.Add("data-inputmask=\"'mask': '999-99999-9'\"", "");
                        break;
                    default:
                        txtIdentification.Attributes.Remove("data-inputmask=\"'mask': '999-9999999-9'\"");
                        break;
                }
            }
        }

        protected void gvBailExtraInfo_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var Grid = (sender as ASPxGridView);
            var isEfective = (ObjServices.StatusNameKey == "EFECT");

            if (e.RowType == GridViewRowType.Data)
            {
                var urlImg = Grid.GetKeyFromAspxGridView("FinancialClearance", e.VisibleIndex, defaultValue: string.Empty).ToString();

                if (!string.IsNullOrEmpty(urlImg))
                {
                    var TipoRiesgo = (Utility.TipoRiesgo)Enum.Parse(typeof(Utility.TipoRiesgo), Grid.GetKeyFromAspxGridView("TipoRiesgoNameKey", e.VisibleIndex, defaultValue: string.Empty).ToString());
                    var RiesgoDesc = Utility.GetDescRiesgo(TipoRiesgo);

                    var imgRiesgo = Grid.FindRowCellTemplateControl(e.VisibleIndex, null, "imgRiesgo") as Image;

                    if (imgRiesgo != null)
                    {
                        imgRiesgo.ImageUrl = urlImg;
                        imgRiesgo.Attributes.Add("title", RiesgoDesc);
                    }
                }               
            }
        }

        protected void ddlMunicipality_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Container = ((DevExpress.Web.GridViewDataItemTemplateContainer)((DropDownList)sender).NamingContainer);
            var Index = Container.ItemIndex;

            SetControls(gvBailExtraInfo, Index);

            var drop = (sender as DropDownList);

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                var KeyStateProvince = Utility.deserializeJSON<Utility.StateProvince>(drop.SelectedValue);

                if (drop.SelectedIndex > 0)
                {

                    ddlCityId.DataSource = ObjServices.GettingDropData(Utility.DropDownType.City,
                                           stateProvId: KeyStateProvince.StateProvId,
                                            domesticregId: KeyStateProvince.DomesticregId,
                                            countryId: KeyStateProvince.CountryId);

                    hdnDomecticRegId.Value = KeyStateProvince.DomesticregId.ToString();

                    ddlCityId.DataTextField = "CityDesc";
                    ddlCityId.DataValueField = "CityId";
                    ddlCityId.DataBind();
                    ddlCityId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
                }
            }
        }

        protected void rpCondiciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var txtCondicion = e.Item.FindControl("txtCondicion") as TextBox;
            if (txtCondicion != null)
            {
                var isNumber = (e.Item.DataItem as Entity.UnderWriting.Entities.Policy.ConditionForSysflexIL).esnumero == "S";
                if (isNumber)
                    txtCondicion.Attributes.Add("decimal", "decimal");
            }
        }
    }
}