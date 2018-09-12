using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.Entities;
using DevExpress.Web;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines
{
    public partial class UCPropertyDetail : UC, IUC
    {
        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

        public enum TipoProducto { IncendioBasico, InterrupciondeNegocios, TodoRiesgoPropiedades, Fidelidad3d };

        public TextBox txtBrand { get; set; }
        public TextBox txtModel { get; set; }
        public TextBox txtPosition { get; set; }
        public TextBox txtAuthor { get; set; }
        public TextBox txtSerialKey { get; set; }
        public TextBox txtYear { get; set; }
        public TextBox txtValue { get; set; }
        public TextBox txtQuantity { get; set; }
        public TextBox txtCapacity { get; set; }
        public TextBox txtHeight { get; set; }
        public TextBox txtWidth { get; set; }
        public TextBox txtMinimumDeductible { get; set; }
        public DropDownList ddlCertificateId { get; set; }
        public DropDownList ddlMeasureTypeId { get; set; }
        public DropDownList ddlPositionId { get; set; }
        public TextBox txtDeductible { get; set; }
        public TextBox txtDescription { get; set; }


        private void HideOrShow(String Product = "CristalesYLetreros")
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

                    foreach (GridViewColumn item in gvPropertyDetailFeature.Columns)
                        item.Visible = false;

                    foreach (var item in Fields)
                    {
                        var Column = gvPropertyDetailFeature.Columns[item];

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

            if (!entro)
                fieldSetFeatures.Visible = false;
        }

        public int UniquePropertyId
        {
            get
            {
                return ViewState["UniquePropertyId"].ToInt();
            }
            set
            {
                ViewState["UniquePropertyId"] = value;
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

        private List<Utility.DetailFeature> dataFeatureTemp = new List<Utility.DetailFeature>(0);

        public List<Utility.DetailFeature> oTemDataFeature
        {
            get
            {
                return ViewState["TemDataFeature"] == null ?
                    new List<Utility.DetailFeature>() :
                    ViewState["TemDataFeature"] as List<Utility.DetailFeature>;
            }

            set
            {
                List<Utility.DetailFeature> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.DetailFeature>(
                            ViewState["TemDataFeature"] != null
                            ?
                            (
                               (List<Utility.DetailFeature>)ViewState["TemDataFeature"]
                            )
                            :
                            new List<Utility.DetailFeature>()
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

        }

        public void edit()
        {

        }

        public void FillData()
        {
            var SelectedRecord = ObjServices.GetDataProperty(UniquePropertyId).FirstOrDefault();
            hdnProductName.Value = SelectedRecord.ProductDesc.Replace(" ", "").TrimStart().TrimEnd();
            var PConditionPropertyList = ObjServices.oPolicyManager
                                                  .GetConditionIL(ObjServices.Policy_Id, SelectedRecord.UniquePropertyId)
                                                  .Where(c => !c.descripcion.ToLower().Contains("endoso")).ToList();

            rpCondiciones.DataSource = PConditionPropertyList;
            rpCondiciones.DataBind();
            txt_producto.Text = SelectedRecord.ProductDesc;

            FillGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (isInsertingNewRecord)
                return;

            dataFeatureTemp.Add(new Utility.DetailFeature
            {
                isLocal = true,
                CorpId = ObjServices.Corp_Id,
                UniquePropertyId = UniquePropertyId,
                SeqId = -1,
                Brand = string.Empty,
                Model = string.Empty,
                SerialKey = string.Empty,
                Year = 0,
                Value = 0,
                Quantity = 0,
                Author = string.Empty,
                Capacity = string.Empty,
                Height = string.Empty,
                Width = string.Empty,
                Deductible = 0,
                MinimumDeductible = 0,
                CertificateId = null,
                MeasureTypeId = null,
                PositionId = null,
                ValueF = "0",
                QuantityF = "0",
                MinimumDeductibleF = "0",
                DeductibleF = "0",
                Description = string.Empty,
                MeasureTypeDesc = string.Empty,
                PositionDesc = string.Empty,
                CertificateDesc = string.Empty,
                FeaturePropertyStatusId = 1,
            });

            isInsertingNewRecord = true;

            oTemDataFeature = dataFeatureTemp;
            FillGrid(true);
            gvPropertyDetailFeature.PageIndex = gvPropertyDetailFeature.PageCount;
            var Index = oTemDataFeature.Count - 1;
            var script = string.Format("__doPostBack('ctl00$bodyContent$UCAlliedLinesDetail$UCProperty$UCPropertyDetail$gvPropertyDetailFeature$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        protected void gvPropertyDetailFeature_PageIndexChanged(object sender, EventArgs e)
        {
            if (!isInsertingNewRecord)
                FillGrid();
        }

        public void FillGrid(bool AddLocal = false)
        {
            var parameter = new Property.Insured.Detail.Feature.GetPropertyInsuredDetailFeatureResult.Key
            {
                corpId = ObjServices.Corp_Id,
                uniquePropertyId = UniquePropertyId,
                seqId = null
            };

            if (!AddLocal)
            {
                oTemDataFeature = null;
                oTemDataFeature = ObjServices.oPropertyManager.GetPropertyInsuredDetailFeature(parameter)
                    .Select(v => new Utility.DetailFeature
                    {
                        isLocal = false,
                        Brand = v.Brand,
                        Model = v.Model,
                        SerialKey = v.SerialKey,
                        Year = v.Year,
                        Value = v.Value,
                        Quantity = v.Quantity,
                        Author = v.Author,
                        Capacity = v.Capacity,
                        Height = v.Height,
                        Width = v.Width,
                        MinimumDeductible = v.MinimumDeductible,
                        CertificateId = v.CertificateId,
                        MeasureTypeId = v.MeasureTypeId,
                        PositionId = v.PositionId,
                        Deductible = v.Deductible,
                        Description = v.Description,
                        ValueF = v.Value.ToFormatNumeric(),
                        QuantityF = v.Quantity.ToFormatNumeric(),
                        MinimumDeductibleF = v.MinimumDeductible.ToFormatNumeric(),
                        DeductibleF = v.Deductible.ToFormatNumeric(),
                        MeasureTypeDesc = v.MeasureTypeDesc,
                        PositionDesc = v.PositionDesc,
                        CertificateDesc = v.CertificateDesc,
                        FeaturePropertyStatusId = v.FeaturePropertyStatusId,
                        UniquePropertyId = v.UniquePropertyId,
                        SeqId = v.SeqId
                    }).ToList();
            }

            gvPropertyDetailFeature.DataSource = oTemDataFeature;
            gvPropertyDetailFeature.DataBind();
            HideOrShow(hdnProductName.Value);
        }

        public void Initialize()
        {
            var isEfective = (ObjServices.StatusNameKey == "EFECT");
            ClearData();
            FillData();
            dvPropertyFeature.Enabled = !isEfective;
            var cOperation = gvPropertyDetailFeature.getThisColumn("Operation");
            if (cOperation != null)
                cOperation.Visible = !isEfective;
        }

        public void ClearData()
        {
            oTemDataFeature = null;
            Utility.ClearAll(this.Controls);
        }

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrand") as TextBox;
            txtModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModel") as TextBox;
            txtPosition = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPosition") as TextBox;
            txtSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerialKey") as TextBox;
            txtYear = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYear") as TextBox;
            txtValue = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtValue") as TextBox;
            txtQuantity = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtQuantity") as TextBox;

            txtAuthor = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPercentage") as TextBox;
            txtCapacity = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtCapacity") as TextBox;
            txtHeight = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtHeight") as TextBox;
            txtWidth = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtWidth") as TextBox;
            txtMinimumDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtMinimumDeductible") as TextBox;
            txtDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtDeductible") as TextBox;
            txtDescription = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtDescription") as TextBox;

            ddlCertificateId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCertificateId") as DropDownList;
            ddlMeasureTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlMeasureTypeId") as DropDownList;
            ddlPositionId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlPositionId") as DropDownList;

        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex, Utility.DetailFeature Record = null)
        {
            txtBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrand") as TextBox;
            var ltBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltBrand") as Control;
            txtModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModel") as TextBox;
            var ltModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltModel") as Control;
            txtSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerialKey") as TextBox;
            var ltSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltSerialKey") as Control;
            txtYear = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYear") as TextBox;
            var ltYear = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltYear") as Control;
            txtValue = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtValue") as TextBox;
            var ltValue = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltValue") as Control;
            txtQuantity = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtQuantity") as TextBox;
            var ltQuantity = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltQuantity") as Control;
            txtAuthor = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtAuthor") as TextBox;
            var ltAuthor = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltAuthor") as Control;
            txtCapacity = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtCapacity") as TextBox;
            var ltCapacity = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCapacity") as Control;
            txtHeight = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtHeight") as TextBox;
            var ltHeight = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltHeight") as Control;
            txtWidth = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtWidth") as TextBox;
            var ltWidth = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltWidth") as Control;
            txtMinimumDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtMinimumDeductible") as TextBox;
            var ltMinimumDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltMinimumDeductible") as Control;
            txtDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtDeductible") as TextBox;
            var ltDeductible = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltDeductible") as Control;
            txtDescription = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtDescription") as TextBox;
            var ltDescription = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltDescription") as Control;
            ddlCertificateId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlCertificateId") as DropDownList;
            var ltCertificateId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCertificateId") as Control;
            ddlMeasureTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlMeasureTypeId") as DropDownList;
            var ltMeasureTypeId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltMeasureTypeId") as Control;
            ddlPositionId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlPositionId") as DropDownList;
            var ltPositionId = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPositionId") as Control;

            if (txtBrand != null) txtBrand.Visible = isEdit;
            if (ltBrand != null) ltBrand.Visible = !isEdit;

            if (txtModel != null) txtModel.Visible = isEdit;
            if (ltModel != null) ltModel.Visible = !isEdit;

            if (txtSerialKey != null) txtSerialKey.Visible = isEdit;
            if (ltSerialKey != null) ltSerialKey.Visible = !isEdit;

            if (txtYear != null) txtYear.Visible = isEdit;
            if (ltYear != null) ltYear.Visible = !isEdit;

            if (txtValue != null) txtValue.Visible = isEdit;
            if (ltValue != null) ltValue.Visible = !isEdit;

            if (txtQuantity != null) txtQuantity.Visible = isEdit;
            if (ltQuantity != null) ltQuantity.Visible = !isEdit;

            if (txtAuthor != null) txtAuthor.Visible = isEdit;
            if (ltAuthor != null) ltAuthor.Visible = !isEdit;

            if (txtCapacity != null) txtCapacity.Visible = isEdit;
            if (ltCapacity != null) ltCapacity.Visible = !isEdit;

            if (txtHeight != null) txtHeight.Visible = isEdit;
            if (ltHeight != null) ltHeight.Visible = !isEdit;

            if (txtWidth != null) txtWidth.Visible = isEdit;
            if (ltWidth != null) ltWidth.Visible = !isEdit;

            if (txtMinimumDeductible != null) txtMinimumDeductible.Visible = isEdit;
            if (ltMinimumDeductible != null) ltMinimumDeductible.Visible = !isEdit;

            if (txtDeductible != null) txtDeductible.Visible = isEdit;
            if (ltDeductible != null) ltDeductible.Visible = !isEdit;

            if (txtDescription != null) txtDescription.Visible = isEdit;
            if (ltDescription != null) ltDescription.Visible = !isEdit;

            if (ddlCertificateId != null && ddlCertificateId.Items.Count <= 0)
            {
                var parameterCertificate = new Property.Insured.Detail.Feature.CertificatesResult.Key
                {
                    corpId = ObjServices.Corp_Id,
                    CertificateId = null
                };
                var resultCertificateId = ObjServices.oPropertyManager.GetPropertyFeatureCertificates(parameterCertificate);
                ddlCertificateId.DataSource = resultCertificateId;
                ddlCertificateId.DataTextField = "CertificateDesc";
                ddlCertificateId.DataValueField = "CertificateId";
                ddlCertificateId.DataBind();
                ddlCertificateId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlMeasureTypeId != null && ddlMeasureTypeId.Items.Count <= 0)
            {
                var parameterMeasureType = new Property.Insured.Detail.Feature.MeasureTypeResult.Key
                {
                    corpId = ObjServices.Corp_Id,
                    MeasureTypeId = null
                };
                var resultMeasures = ObjServices.oPropertyManager.GetPropertyFeatureMeasureType(parameterMeasureType);
                ddlMeasureTypeId.DataSource = resultMeasures;
                ddlMeasureTypeId.DataTextField = "MeasureTypeDesc";
                ddlMeasureTypeId.DataValueField = "MeasureTypeId";
                ddlMeasureTypeId.DataBind();
                ddlMeasureTypeId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlPositionId != null && ddlPositionId.Items.Count <= 0)
            {
                var parameterPositionId = new Property.Insured.Detail.Feature.PositionsResult.Key
                {
                    corpId = ObjServices.Corp_Id,
                    PositionId = null
                };

                var resultPositionId = ObjServices.oPropertyManager.GetPropertyFeaturePosition(parameterPositionId);
                ddlPositionId.DataSource = resultPositionId;
                ddlPositionId.DataTextField = "PositionDesc";
                ddlPositionId.DataValueField = "PositionId";
                ddlPositionId.DataBind();
                ddlPositionId.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
            }

            if (ddlCertificateId != null) ddlCertificateId.Visible = isEdit;
            if (ltCertificateId != null) ltCertificateId.Visible = !isEdit;

            if (ddlMeasureTypeId != null) ddlMeasureTypeId.Visible = isEdit;
            if (ltMeasureTypeId != null) ltMeasureTypeId.Visible = !isEdit;

            if (ddlPositionId != null) ddlPositionId.Visible = isEdit;
            if (ltPositionId != null) ltPositionId.Visible = !isEdit;

        }

        protected void gvPropertyDetailFeature_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var uniquePropertyId = grid.GetKeyFromAspxGridView("UniquePropertyId", e.VisibleIndex).ToInt();
            var seqId = grid.GetKeyFromAspxGridView("SeqId", e.VisibleIndex).ToInt();
            var PositionId = grid.GetKeyFromAspxGridView("PositionId", e.VisibleIndex).ToInt();
            var CertificateId = grid.GetKeyFromAspxGridView("CertificateId", e.VisibleIndex).ToInt();
            var MeasureTypeId = grid.GetKeyFromAspxGridView("MeasureTypeId", e.VisibleIndex).ToInt();
            var DetailBuildTypeId = grid.GetKeyFromAspxGridView("DetailBuildTypeId", e.VisibleIndex).ToInt();
            var MaterialId = grid.GetKeyFromAspxGridView("MaterialId", e.VisibleIndex).ToInt();
            var DetailPropertyStatId = grid.GetKeyFromAspxGridView("DetailPropertyStatId", e.VisibleIndex).ToInt();
            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;

            var Record = (isInsertingNewRecord) ? oTemDataFeature.Last()
                                                : oTemDataFeature.FirstOrDefault(r => r.SeqId == seqId);

            switch (Command)
            {
                case "DeleteFeature":
                    ObjServices.oPropertyManager.SetPropertyInsuredDetailFeature(new Property.Insured.Detail.Feature.Key
                   {
                       CorpId = ObjServices.Corp_Id,
                       UniquePropertyId = uniquePropertyId,
                       SeqId = seqId,
                       FeaturePropertyStatusId = 0
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
                        gvPropertyDetailFeature.PageIndex = 0;
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

                    if (Record.MeasureTypeId.HasValue)
                        ddlMeasureTypeId.SelectedValue = Record.MeasureTypeId.Value.ToString();

                    if (Record.CertificateId.HasValue)
                        ddlCertificateId.SelectedValue = Record.CertificateId.Value.ToString();

                    if (Record.PositionId.HasValue)
                        ddlPositionId.SelectedValue = Record.PositionId.Value.ToString();

                    break;
                case "SaveFeature":
                    btnEditOrSave.CommandName = "EditFeature";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    SetControls(grid, e.VisibleIndex);

                    var parameter = new Property.Insured.Detail.Feature.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniquePropertyId = uniquePropertyId,
                        SeqId = seqId,
                        Brand = txtBrand != null ? txtBrand.Text : string.Empty,
                        Model = txtModel != null ? txtModel.Text : string.Empty,
                        SerialKey = txtSerialKey != null ? txtSerialKey.Text : string.Empty,
                        Year = txtYear != null ? txtYear.ToInt() : (int?)null,
                        Value = txtValue != null ? txtValue.ToDecimal() : (decimal?)null,
                        Quantity = txtQuantity != null ? txtQuantity.ToInt() : (int?)null,
                        Author = txtAuthor != null ? txtAuthor.Text : string.Empty,
                        Capacity = txtCapacity != null ? txtCapacity.Text : string.Empty,
                        Deductible = txtDeductible != null ? txtDeductible.Text.ToInt() : (decimal?)null,
                        MinimumDeductible = txtMinimumDeductible != null ? txtMinimumDeductible.Text.ToDecimal() : (decimal?)null,
                        Description = txtDescription != null ? txtDescription.Text : string.Empty,
                        Height = txtHeight != null ? txtHeight.Text : string.Empty,
                        Width = txtWidth != null ? txtWidth.Text : string.Empty,
                        PositionId = ddlPositionId != null ? ddlPositionId.SelectedValue.ToInt() : (int?)null,
                        CertificateId = ddlCertificateId != null ? ddlCertificateId.SelectedValue.ToInt() : (int?)null,
                        MeasureTypeId = ddlMeasureTypeId != null ? ddlMeasureTypeId.SelectedValue.ToInt() : (int?)null,
                        UserId = ObjServices.UserID
                    };

                    ObjServices.oPropertyManager.SetPropertyInsuredDetailFeature(parameter);
                    FillGrid();
                    isInsertingNewRecord = false;
                    break;
            }
        }

        protected void gvPropertyDetailFeature_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);
            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }

        protected void gv_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var Grid = (sender as ASPxGridView);

            if (e.RowType == GridViewRowType.Data)
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void rpCondiciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var txtCondicion = e.Item.FindControl("txtCondicion") as TextBox;
            if (txtCondicion != null)
            {
                var recordItem = (e.Item.DataItem as Entity.UnderWriting.Entities.Policy.ConditionForSysflexIL);

                var isNumber = recordItem.esnumero == "S";
                if (isNumber)
                    txtCondicion.Attributes.Add("decimal", "decimal");
            }
        }
    }
}
