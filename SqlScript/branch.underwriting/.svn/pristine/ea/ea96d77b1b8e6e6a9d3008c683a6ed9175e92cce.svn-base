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
    public partial class UCNavyDetail : UC, IUC
    {
        public Utility.Navy oNavy { get; set; }

        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

        #region Comentado porque ya no se usara lo de los motores en las cotizaciones
        /* private bool isInsertingNewRecord
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

              public TextBox txtEngineType { get; set; }
               public TextBox txtEngineQty { get; set; }
               public TextBox txtCapacityHP { get; set; }
               public TextBox txtSerial { get; set; }
               public TextBox txtBrandEngine { get; set; }
               public TextBox txtModelEngine { get; set; }
               public TextBox txtYearEngine { get; set; }
               public TextBox txtFuelType { get; set; }
         


        private List<Utility.Engine> dataFeatureEngine = new List<Utility.Engine>(0);

        public List<Utility.Engine> oTemDataEngine
        {
            get
            {
                return ViewState["TemDataEngine"] == null ?
                    new List<Utility.Engine>() :
                    ViewState["TemDataEngine"] as List<Utility.Engine>;
            }

            set
            {
                List<Utility.Engine> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.Engine>(
                            ViewState["TemDataEngine"] != null
                            ?
                            (
                               (List<Utility.Engine>)ViewState["TemDataEngine"]
                            )
                            :
                            new List<Utility.Engine>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemDataEngine"] = tempList;
            }
        }*/
        #endregion

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
            /* int UniqueNavyId = hdnUniqueNavyID.Value.ToInt();
             var param = ObjServices.oNavyManager.GetNavyInsured(new Entity.UnderWriting.Entities.Navy.Insured.Key
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
                        }).FirstOrDefault((h => h.UniqueNavyId == UniqueNavyId));

             param.Brand = txtBrand.Text;
             param.Model = txtModel.Text;
             param.Name = txtName.Text;
             param.Type = txtType.Text;
             param.Year = txtYear.Text.ToInt();

             ObjServices.oNavyManager.SetNavyInsured(param);
             this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.FormCreated, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Success);*/
        }

        private bool isValid()
        {
            /*if (string.IsNullOrEmpty(txtName.Text))
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
            }*/

            return true;
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillGrid(bool AddLocal = false)
        {
            var UniqueNavyId = hdnUniqueNavyID.Value.ToInt();
            var parameter = new Entity.UnderWriting.Entities.Navy.Insured.Engine.parameter
            {
                corpId = ObjServices.Corp_Id,
                uniqueNavyId = UniqueNavyId,
                engineId = null
            };

            #region Comentado porque ya no se usara lo de los motores en las cotizaciones
            /*
            if (!AddLocal)
            {
                oTemDataEngine = null;
                oTemDataEngine = ObjServices.oNavyManager.GetNavyInsuredEngine(parameter)
                .Select(p => new Utility.Engine
                {

                    Brand = p.Brand,
                    Model = p.Model,
                    Year = p.Year,
                    UniqueNavyId = p.UniqueNavyId,
                    CapacityHP = p.CapacityHP,
                    EngineQty = p.EngineQty,
                    EngineType = p.EngineType,
                    FuelType = p.FuelType,
                    Serial = p.Serial,
                    EngineId = p.EngineId,
                    CorpId = p.CorpId,
                    usrId = p.usrId,
                    isLocal = false,
                }).ToList();
            }

            gvNavyDetailEngine.DataSource = oTemDataEngine;
            gvNavyDetailEngine.DataBind();*/
            #endregion
        }

        public void FillData()
        {
            txt_producto.Text = oNavy.ProductDesc;
            var PConditionPropertyList = ObjServices.oPolicyManager
                                                           .GetConditionIL(ObjServices.Policy_Id, oNavy.UniqueNavyId)
                                                           .Where(c => !c.descripcion.ToLower().Contains("endoso")).ToList();

            rpCondiciones.DataSource = PConditionPropertyList;
            rpCondiciones.DataBind();          
            FillGrid();
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {
            Utility.ClearAll(this.Controls);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                save();
                BindGrid();
            }
        }

        #region Comentado porque ya no se usara lo de los motores en las cotizaciones
        /*

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtBrandEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrandEngine") as TextBox;
            txtModelEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModelEngine") as TextBox;
            txtEngineType = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEngineType") as TextBox;
            txtEngineQty = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEngineQty") as TextBox;
            txtCapacityHP = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtCapacityHP") as TextBox;
            txtSerial = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerial") as TextBox;
            txtYearEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYearEngine") as TextBox;
            txtFuelType = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtFuelType") as TextBox;
        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtBrandEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtBrandEngine") as TextBox;
            var ltBrand = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltBrand") as Control;

            txtModelEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtModelEngine") as TextBox;
            var ltModel = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltModel") as Control;

            txtEngineType = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEngineType") as TextBox;
            var ltEngineType = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltEngineType") as Control;

            txtEngineQty = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtEngineQty") as TextBox;
            var ltEngineQty = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltEngineQty") as Control;

            txtCapacityHP = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtCapacityHP") as TextBox;
            var ltCapacityHP = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCapacityHP") as Control;

            txtSerial = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtSerial") as TextBox;
            var ltSerial = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltSerial") as Control;

            txtYearEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtYearEngine") as TextBox;
            var ltYearEngine = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltYearEngine") as Control;

            txtFuelType = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtFuelType") as TextBox;
            var ltFuelType = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltFuelType") as Control;


            if (txtBrandEngine != null) txtBrandEngine.Visible = isEdit;
            if (ltBrand != null) ltBrand.Visible = !isEdit;

            if (txtModelEngine != null) txtModelEngine.Visible = isEdit;
            if (ltModel != null) ltModel.Visible = !isEdit;

            if (txtEngineType != null) txtEngineType.Visible = isEdit;
            if (ltEngineType != null) ltEngineType.Visible = !isEdit;

            if (txtEngineQty != null) txtEngineQty.Visible = isEdit;
            if (ltEngineQty != null) ltEngineQty.Visible = !isEdit;

            if (txtCapacityHP != null) txtCapacityHP.Visible = isEdit;
            if (ltCapacityHP != null) ltCapacityHP.Visible = !isEdit;

            if (txtSerial != null) txtSerial.Visible = isEdit;
            if (ltSerial != null) ltSerial.Visible = !isEdit;

            if (txtYearEngine != null) txtYearEngine.Visible = isEdit;
            if (ltYearEngine != null) ltYearEngine.Visible = !isEdit;

            if (txtFuelType != null) txtFuelType.Visible = isEdit;
            if (ltFuelType != null) ltFuelType.Visible = !isEdit;
        }

        protected void gvNavyDetailEngine_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            var UniqueNavyId = grid.GetKeyFromAspxGridView("UniqueNavyId", e.VisibleIndex).ToInt();
            var EngineId = grid.GetKeyFromAspxGridView("EngineId", e.VisibleIndex).ToInt();

            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;


            switch (Command)
            {
                case "DeletePilot":

                    btnEditOrSave.CommandName = "EditPilote";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    SetControls(grid, e.VisibleIndex);

                    var parameterDelete = new Entity.UnderWriting.Entities.Navy.Insured.Engine
                    {
                        Brand = txtBrandEngine.Text,
                        Model = txtModelEngine.Text,
                        CapacityHP = txtCapacityHP.Text,
                        CorpId = ObjServices.Corp_Id,
                        EngineId = EngineId,
                        EngineQty = txtEngineQty.Text,
                        EngineStatusId = 0,
                        EngineType = txtEngineType.Text,
                        FuelType = txtFuelType.Text,
                        Serial = txtSerial.Text,
                        UniqueNavyId = UniqueNavyId,
                        usrId = ObjServices.UserID.GetValueOrDefault(),
                        Year = txtYearEngine.Text
                    };

                    ObjServices.oNavyManager.SetNavyInsuredEngine(parameterDelete);

                    FillGrid();
                    isInsertingNewRecord = false;

                    break;
                case "Cancel":
                    //Borrar todos los registros locales
                    var hasRecordLocal = oTemDataEngine.Any(p => p.isLocal);

                    if (hasRecordLocal)
                    {
                        var result = oTemDataEngine.Where(p => !p.isLocal).ToList();
                        oTemDataEngine = null;
                        oTemDataEngine = result;
                        FillGrid(hasRecordLocal);
                        gvNavyDetailEngine.PageIndex = 0;
                    }

                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    btnEditOrSave.CommandName = "EditPilot";
                    isInsertingNewRecord = false;
                    break;
                case "EditPilot":
                    if (btnCancel != null) btnCancel.Visible = true;
                    if (btnDelete != null) btnDelete.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "mysave_file";
                    btnEditOrSave.CommandName = "SavePilot";
                    EditMode(true, grid, e.VisibleIndex);
                    break;
                case "SavePilot":
                    btnEditOrSave.CommandName = "EditPilote";
                    if (btnCancel != null) btnCancel.Visible = false;
                    if (btnEditOrSave != null) btnEditOrSave.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditMode(false, grid, e.VisibleIndex);
                    SetControls(grid, e.VisibleIndex);

                    var parameter = new Entity.UnderWriting.Entities.Navy.Insured.Engine
                    {
                        Brand = txtBrandEngine.Text,
                        Model = txtModelEngine.Text,
                        CapacityHP = txtCapacityHP.Text,
                        CorpId = ObjServices.Corp_Id,
                        EngineId = EngineId,
                        EngineQty = txtEngineQty.Text,
                        EngineStatusId = 1,
                        EngineType = txtEngineType.Text,
                        FuelType = txtFuelType.Text,
                        Serial = txtSerial.Text,
                        UniqueNavyId = UniqueNavyId,
                        usrId = ObjServices.UserID.GetValueOrDefault(),
                        Year = txtYearEngine.Text
                    };

                    ObjServices.oNavyManager.SetNavyInsuredEngine(parameter);

                    FillGrid();
                    isInsertingNewRecord = false;
                    break;
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (isInsertingNewRecord)
                return;

            var UniqueNavyId = hdnUniqueNavyID.Value.ToInt();
            dataFeatureEngine.Add(new Utility.Engine
            {
                isLocal = true,
                CorpId = ObjServices.Corp_Id,
                CapacityHP = string.Empty,
                Brand = string.Empty,
                Model = string.Empty,
                EngineQty = string.Empty,
                EngineType = string.Empty,
                EngineStatusId = 1,
                FuelType = string.Empty,
                Serial = string.Empty,
                Year = string.Empty,
                UniqueNavyId = UniqueNavyId,
                EngineId = -1,
                usrId = ObjServices.UserID.GetValueOrDefault()
            });

            isInsertingNewRecord = true;

            oTemDataEngine = dataFeatureEngine;
            FillGrid(true);
            gvNavyDetailEngine.PageIndex = gvNavyDetailEngine.PageCount;
            var Index = oTemDataEngine.Count - 1;
            var script = string.Format("__doPostBack('ctl00$bodyContent$UCAlliedLinesDetail$UCNavy$UCNavyDetail$gvNavyDetailEngine$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        protected void gvNavyDetailEngine_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);

            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }

        protected void gvNavyDetailEngine_PageIndexChanged(object sender, EventArgs e)
        {
            if (!isInsertingNewRecord)
                FillGrid();
        }*/
        #endregion

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