using DevExpress.Web;
using Entity.UnderWriting.Entities;
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
    public partial class UCTransportDetail : UC, IUC
    {
        public Utility.Transport oTransport { get; set; }

        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

        public TextBox txtNameExtra { get; set; }
        public TextBox txtBrand { get; set; }
        public TextBox txtModel { get; set; }
        public TextBox txtYearExtra { get; set; }
        public TextBox txtPlate { get; set; }
        public TextBox txtVin { get; set; }
        public TextBox txtSerialKey { get; set; }

        public enum TipoProducto { TransporteAereo, TransporteMaritimo, TransporteTerrestre }

        private void HideOrShow(String Product = "TransporteAereo")
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

                    foreach (GridViewColumn item in gvTransportExtraInfo.Columns)
                        item.Visible = false;

                    foreach (var item in Fields)
                    {
                        var Column = gvTransportExtraInfo.Columns[item];

                        if (Column != null)
                        {
                            Column.Visible = true;
                            entro = true;
                        }
                    }

                    if (entro)
                    {
                        fieldSetFeatures.Visible = true;
                    }

                }
            }

            if (entro == false)
            {
                fieldSetFeatures.Visible = true;
            }
        }

        public int UniqueTransportId
        {
            get
            {
                return ViewState["UniqueTransportId"].ToInt();
            }
            set
            {
                ViewState["UniqueTransportId"] = value;
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

        private List<Utility.TransportExtraInfo> dataFeatureTemp = new List<Utility.TransportExtraInfo>(0);

        public List<Utility.TransportExtraInfo> oTemDataFeature
        {
            get
            {
                return ViewState["TemDataFeature"] == null ?
                    new List<Utility.TransportExtraInfo>() :
                    ViewState["TemDataFeature"] as List<Utility.TransportExtraInfo>;
            }

            set
            {
                List<Utility.TransportExtraInfo> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.TransportExtraInfo>(
                            ViewState["TemDataFeature"] != null
                            ?
                            (
                               (List<Utility.TransportExtraInfo>)ViewState["TemDataFeature"]
                            )
                            :
                            new List<Utility.TransportExtraInfo>()
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
            #region Codigo comentado
            /* int UniqueTransportId = hdnUniqueTransportID.Value.ToInt();
             var param = ObjServices.oTransportManager.GetTransportInsured(new Entity.UnderWriting.Entities.Transport.Insured.Key
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
                        }).FirstOrDefault((h => h.UniqueTransportId == UniqueTransportId));

             param.Brand = txtBrand.Text;
             param.Model = txtModel.Text;
             param.Name = txtName.Text;
             param.Type = txtType.Text;
             param.Year = txtYear.Text.ToInt();   
             ObjServices.oTransportManager.SetTransportInsured(param);
             this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.FormCreated, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Success);*/
            #endregion
        }

        private bool isValid()
        {
            #region Codigo Comentado

            /* if (string.IsNullOrEmpty(txtName.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Name));
                 return false;
             }

             if (string.IsNullOrEmpty(txtBrand.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Marca del Avion"));
                 return false;
             }

             if (string.IsNullOrEmpty(txtModel.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Model));
                 return false;
             }

             if (string.IsNullOrEmpty(txtType.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Tipo del Avion"));
                 return false;
             }

             if (string.IsNullOrEmpty(txtYear.Text))
             {
                 this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Year));
                 return false;
             }
            */

            #endregion
            return true;
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            hdnProductName.Value = oTransport.ProductDesc.Replace(" ", "").TrimEnd().TrimStart();
            var PConditionPropertyList = ObjServices.oPolicyManager
                                                   .GetConditionIL(ObjServices.Policy_Id, oTransport.UniqueTransportId)
                                                   .Where(c => !c.descripcion.ToLower().Contains("endoso")).ToList();

            rpCondiciones.DataSource = PConditionPropertyList;
            rpCondiciones.DataBind();
            txt_producto.Text = oTransport.ProductDesc;
            UniqueTransportId = oTransport.UniqueTransportId.ToInt();
            hdnUniqueTransportID.Value = oTransport.UniqueTransportId.ToString(CultureInfo.InvariantCulture);
            FillGrid();
        }

        protected void gvTransportExtraInfo_PageIndexChanged(object sender, EventArgs e)
        {
            if (!isInsertingNewRecord)
                FillGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (isInsertingNewRecord)
                return;

            dataFeatureTemp.Add(new Utility.TransportExtraInfo
            {
                isLocal = true,
                CorpId = ObjServices.Corp_Id,
                UniqueTransportId = UniqueTransportId,
                SeqId = -1,
                Name = string.Empty,
                Brand = string.Empty,
                Model = string.Empty,
                SerialKey = string.Empty,
                Year = null,
                Plate = string.Empty,
                Vin = string.Empty,
                TransportExtraInfoStatusId = 1
            });

            isInsertingNewRecord = true;

            oTemDataFeature = dataFeatureTemp;
            FillGrid(true);
            gvTransportExtraInfo.PageIndex = gvTransportExtraInfo.PageCount;
            var Index = oTemDataFeature.Count - 1;
            var script = string.Format("__doPostBack('ctl00$bodyContent$UCAlliedLinesDetail$UCTransport$UCTransportDetail$gvTransportExtraInfo$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        public void FillGrid(bool AddLocal = false)
        {
            var parameter = new Transport.Insured.ExtraInfo.Key
            {
                CorpId = ObjServices.Corp_Id,
                UniqueTransportId = UniqueTransportId,
                SeqId = null
            };

            if (!AddLocal)
            {
                oTemDataFeature = null;
                oTemDataFeature = ObjServices.oTransportManager.GetTransportInsuredExtraInfo(parameter)
                    .Select(v => new Utility.TransportExtraInfo
                    {
                        isLocal = false,
                        CorpId = v.CorpId,
                        UniqueTransportId = v.UniqueTransportId,
                        SeqId = v.SeqId,
                        Name = v.Name,
                        Brand = v.Brand,
                        Model = v.Model,
                        Year = v.Year,
                        Plate = v.Plate,
                        Vin = v.Vin,
                        SerialKey = v.SerialKey,
                        TransportExtraInfoStatusId = v.TransportExtraInfoStatusId,
                    }).ToList();
            }

            gvTransportExtraInfo.DataSource = oTemDataFeature;
            gvTransportExtraInfo.DataBind();

            HideOrShow(hdnProductName.Value);
        }

        public void Initialize()
        {
            var isEfective = (ObjServices.StatusNameKey == "EFECT");
            ClearData();
            FillData();
            dvPropertyFeature.Enabled = !isEfective;
            var cOperation = gvTransportExtraInfo.getThisColumn("Operation");
            if (cOperation != null)
                cOperation.Visible = !isEfective;
        }

        public void ClearData()
        {
            Utility.ClearAll(this.Controls);
        }

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtNameExtra = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNameExtra") as TextBox;
            txtBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrand") as TextBox;
            txtModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModel") as TextBox;
            txtYearExtra = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYearExtra") as TextBox;
            txtPlate = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPlate") as TextBox;
            txtVin = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtVin") as TextBox;
            txtSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerialKey") as TextBox;
        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex, Utility.TransportExtraInfo Record = null)
        {
            txtNameExtra = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNameExtra") as TextBox;
            var ltName = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltName") as Control;

            txtBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrand") as TextBox;
            var ltBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltBrand") as Control;

            txtModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModel") as TextBox;
            var ltModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltModel") as Control;

            txtSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerialKey") as TextBox;
            var ltSerialKey = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltSerialKey") as Control;

            txtYearExtra = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYearExtra") as TextBox;
            var ltYear = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltYear") as Control;

            txtPlate = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtPlate") as TextBox;
            var ltPlate = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltPlate") as Control;

            txtVin = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtVin") as TextBox;
            var ltVin = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltVin") as Control;

            if (txtNameExtra != null) txtNameExtra.Visible = isEdit;
            if (ltName != null) ltName.Visible = !isEdit;

            if (txtBrand != null) txtBrand.Visible = isEdit;
            if (ltBrand != null) ltBrand.Visible = !isEdit;

            if (txtModel != null) txtModel.Visible = isEdit;
            if (ltModel != null) ltModel.Visible = !isEdit;

            if (txtSerialKey != null) txtSerialKey.Visible = isEdit;
            if (ltSerialKey != null) ltSerialKey.Visible = !isEdit;

            if (txtYearExtra != null) txtYearExtra.Visible = isEdit;
            if (ltYear != null) ltYear.Visible = !isEdit;

            if (txtPlate != null) txtPlate.Visible = isEdit;
            if (ltPlate != null) ltPlate.Visible = !isEdit;

            if (txtVin != null) txtVin.Visible = isEdit;
            if (ltVin != null) ltVin.Visible = !isEdit;
        }

        protected void gvTransportExtraInfo_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var UniqueTransportId = grid.GetKeyFromAspxGridView("UniqueTransportId", e.VisibleIndex).ToInt();
            var seqId = grid.GetKeyFromAspxGridView("SeqId", e.VisibleIndex).ToInt();
            var TransportExtraInfoStatusId = grid.GetKeyFromAspxGridView("TransportExtraInfoStatusId", e.VisibleIndex).ToInt();

            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;

            var Record = (isInsertingNewRecord) ? oTemDataFeature.Last()
                                                : oTemDataFeature.FirstOrDefault(r => r.SeqId == seqId);

            switch (Command)
            {
                case "DeleteFeature":
                    ObjServices.oTransportManager.SetTransportInsuredExtraInfo(new Transport.Insured.ExtraInfo.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueTransportId = UniqueTransportId,
                        SeqId = seqId,
                        TransportExtraInfoStatusId = 0
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
                        gvTransportExtraInfo.PageIndex = 0;
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
                    break;
                case "SaveFeature":
                    btnEditOrSave.CommandName = "EditFeature";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    SetControls(grid, e.VisibleIndex);

                    var parameter = new Transport.Insured.ExtraInfo.Key
                    {
                        CorpId = ObjServices.Corp_Id,
                        UniqueTransportId = UniqueTransportId,
                        SeqId = seqId,
                        Brand = txtBrand != null ? txtBrand.Text : string.Empty,
                        Model = txtModel != null ? txtModel.Text : string.Empty,
                        SerialKey = txtSerialKey != null ? txtSerialKey.Text : string.Empty,
                        Year = txtYearExtra != null ? txtYearExtra.ToInt() : (int?)null,
                        Name = txtNameExtra != null ? txtNameExtra.Text : string.Empty,
                        Plate = txtPlate != null ? txtPlate.Text : string.Empty,
                        Vin = txtVin != null ? txtVin.Text : string.Empty,
                        TransportExtraInfoStatusId = TransportExtraInfoStatusId,
                        UserId = ObjServices.UserID
                    };

                    ObjServices.oTransportManager.SetTransportInsuredExtraInfo(parameter);
                    FillGrid();
                    isInsertingNewRecord = false;
                    break;
            }
        }

        protected void gvTransportExtraInfo_PreRender(object sender, EventArgs e)
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

        protected void gv_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            var Grid = (sender as ASPxGridView);

            if (e.RowType == GridViewRowType.Data)
            {
                
            }
        }
    }
}

