using DevExpress.Web;
using Statetrust.Framework.Resources;
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
    public partial class UCAirPlaneDetail : UC, IUC
    {
        public delegate void BindingGridEventHandler();
        public event BindingGridEventHandler BindGrid;

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

        public TextBox txtNamePilot { get; set; }
        public TextBox txtFlighthours { get; set; }

        private List<Utility.DetailPilot> dataFeaturePilot = new List<Utility.DetailPilot>(0);

        public List<Utility.DetailPilot> oTemDataPilot
        {
            get
            {
                return ViewState["TemDataPilot"] == null ?
                    new List<Utility.DetailPilot>() :
                    ViewState["TemDataPilot"] as List<Utility.DetailPilot>;
            }

            set
            {
                List<Utility.DetailPilot> tempList = null;

                if (value != null)
                {
                    tempList = new List<Utility.DetailPilot>(
                            ViewState["TemDataPilot"] != null
                            ?
                            (
                               (List<Utility.DetailPilot>)ViewState["TemDataPilot"]
                            )
                            :
                            new List<Utility.DetailPilot>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemDataPilot"] = tempList;
            }
        }

        public int UniqueAirplaneId
        {
            get
            {
                return ViewState["UniqueAirplaneId"].ToInt();
            }
            set
            {
                ViewState["UniqueAirplaneId"] = value;
            }
        }

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

                    foreach (GridViewColumn item in gvAirplaneDetailPilot.Columns)
                        item.Visible = false;

                    foreach (var item in Fields)
                    {
                        var Column = gvAirplaneDetailPilot.Columns[item];

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

        public void FillGrid(bool AddLocal = false)
        {
            var parameter = new Entity.UnderWriting.Entities.Airplane.Insured.Pilot.Key
                {
                    CorpId = ObjServices.Corp_Id,
                    UniqueAirplaneId = this.UniqueAirplaneId,
                    SeqId = null
                };

            if (!AddLocal)
            {
                oTemDataPilot = null;
                oTemDataPilot = ObjServices.oAirPlaneManager.GetAirplaneInsuredPilot(parameter)
                .Select(p => new Utility.DetailPilot
                {
                    isLocal = false,
                    Name = p.Name,
                    Flighthours = p.Flighthours,
                    FlighthoursF = p.Flighthours.HasValue ? p.Flighthours.Value.ToString("#,0", CultureInfo.InvariantCulture) : "0",
                    AirplanePilotStatus = p.AirplanePilotStatus,
                    CorpId = p.CorpId,
                    UniqueAirplaneId = p.UniqueAirplaneId,
                    SeqId = p.SeqId,
                    UserId = p.UserId
                }).ToList();
            }

            gvAirplaneDetailPilot.DataSource = oTemDataPilot;
            gvAirplaneDetailPilot.DataBind();

            HideOrShow(hdnProductName.Value);
        }

        public void save()
        {
            /*int UniqueAirPlaneId = hdnAirPlaneUniqueID.Value.ToInt();
            var param = ObjServices.oAirPlaneManager.GetAirplaneInsured(new Entity.UnderWriting.Entities.Airplane.Insured.Key
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
                        }).FirstOrDefault((h => h.UniqueAirplaneId == UniqueAirPlaneId));

                             param.UniqueAirplaneId = UniqueAirPlaneId;
                             param.Name = txtName.Text;
                             param.Brand = txtBrand.Text;
                             param.Model = txtModel.Text;
                             param.Type = txtType.Text;
                             param.Year = txtYear.Text.ToInt();
                             param.SeatingQty = txtSeating_Qty.Text.ToInt();
                             param.AirplaneBase = txtAirplaneBase.Text;
                             param.UserId = ObjServices.UserID.GetValueOrDefault();
                             
                             ObjServices.oAirPlaneManager.SetAirplaneInsured(param);
                             this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.FormCreated, Title: RESOURCE.UnderWriting.NewBussiness.Resources.Success);*/
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        private bool isValid()
        {
            var result = true;

            /*if (string.IsNullOrEmpty(txtName.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Name));
                result = false;
            }

            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Marca del Avion"));
                result = false;
            }

            if (string.IsNullOrEmpty(txtModel.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Model));
                result = false;
            }

            if (string.IsNullOrEmpty(txtType.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Tipo del Avion"));
                result = false;
            }

            if (string.IsNullOrEmpty(txtYear.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), RESOURCE.UnderWriting.NewBussiness.Resources.Year));
                result = false;
            }

            if (string.IsNullOrEmpty(txtAirplaneBase.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Base del Avion"));
                result = false;
            }

            if (string.IsNullOrEmpty(txtSeating_Qty.Text))
            {
                this.MessageBox(string.Format(RESOURCE.UnderWriting.NewBussiness.Resources.ResourceManager.GetString("Required"), "Cantidad de Asientos"));
                result = false;
            }*/

            return result;
        }

        public void FillData()
        {
            var SelectedRecord = ObjServices.GetDataAirPlane(UniqueAirplaneId).FirstOrDefault();
            txt_producto.Text = SelectedRecord.ProductDesc;
            hdnProductName.Value = SelectedRecord.ProductDesc.Replace(" ", "");
            var PConditionPropertyList = ObjServices.oPolicyManager
                                                           .GetConditionIL(ObjServices.Policy_Id, SelectedRecord.UniqueAirplaneId)
                                                           .Where(c => !c.descripcion.ToLower().Contains("endoso")).ToList();

            rpCondiciones.DataSource = PConditionPropertyList;
            rpCondiciones.DataBind();
            FillGrid();
        }

        public void Initialize()
        {
            var isEfective = (ObjServices.StatusNameKey == "EFECT");
            ClearData();
            FillData();
            dvPilot.Enabled = !isEfective;
            var cOperation = gvAirplaneDetailPilot.getThisColumn("Operation");
            if (cOperation != null)
                cOperation.Visible = !isEfective;
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

        private void SetControls(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtNamePilot = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNamePilot") as TextBox;
            txtFlighthours = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtFlighthours") as TextBox;
        }

        private void EditMode(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtNamePilot = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtNamePilot") as TextBox;
            var ltNamePilot = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltNamePilot") as Control;

            txtFlighthours = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtFlighthours") as TextBox;
            var ltFlighthours = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltFlighthours") as Control;

            if (txtNamePilot != null) txtNamePilot.Visible = isEdit;
            if (ltNamePilot != null) ltNamePilot.Visible = !isEdit;

            if (txtFlighthours != null) txtFlighthours.Visible = isEdit;
            if (ltFlighthours != null) ltFlighthours.Visible = !isEdit;
        }

        protected void gvAirplaneDetailPilot_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;
            UniqueAirplaneId = grid.GetKeyFromAspxGridView("UniqueAirplaneId", e.VisibleIndex).ToInt();
            var seqId = grid.GetKeyFromAspxGridView("SeqId", e.VisibleIndex).ToInt();

            var btnEditOrSave = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSave") as LinkButton;
            var btnCancel = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancel") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;


            switch (Command)
            {
                case "DeletePilot":
                    var Todelete = new Entity.UnderWriting.Entities.Airplane.Insured.Pilot
                   {
                       AirplanePilotStatus = false,
                       SeqId = seqId,
                       CorpId = ObjServices.Corp_Id,
                       UniqueAirplaneId = UniqueAirplaneId,
                       UserId = ObjServices.UserID.GetValueOrDefault(),
                   };
                    ObjServices.oAirPlaneManager.SetAirPlaneInsuredPilot(Todelete);
                    break;
                case "Cancel":
                    //Borrar todos los registros locales
                    var hasRecordLocal = oTemDataPilot.Any(p => p.isLocal);

                    if (hasRecordLocal)
                    {
                        var result = oTemDataPilot.Where(p => !p.isLocal).ToList();
                        oTemDataPilot = null;
                        oTemDataPilot = result;
                        FillGrid(hasRecordLocal);
                        gvAirplaneDetailPilot.PageIndex = 0;
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

                    var parameter = new Entity.UnderWriting.Entities.Airplane.Insured.Pilot
                    {
                        Name = txtNamePilot.Text,
                        Flighthours = txtFlighthours.Text.Replace(",", "").ToInt(),
                        AirplanePilotStatus = true,
                        SeqId = seqId,
                        CorpId = ObjServices.Corp_Id,
                        UniqueAirplaneId = UniqueAirplaneId,
                        UserId = ObjServices.UserID.GetValueOrDefault(),
                    };

                    ObjServices.oAirPlaneManager.SetAirPlaneInsuredPilot(parameter);

                    FillGrid();
                    isInsertingNewRecord = false;
                    break;
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (isInsertingNewRecord)
                return;

            dataFeaturePilot.Add(new Utility.DetailPilot
            {
                isLocal = true,
                CorpId = ObjServices.Corp_Id,
                Name = string.Empty,
                Flighthours = 0,
                AirplanePilotStatus = true,
                UniqueAirplaneId = UniqueAirplaneId,
                SeqId = -1,
                UserId = ObjServices.UserID.GetValueOrDefault()
            });

            isInsertingNewRecord = true;

            oTemDataPilot = dataFeaturePilot;
            FillGrid(true);
            gvAirplaneDetailPilot.PageIndex = gvAirplaneDetailPilot.PageCount;
            var Index = oTemDataPilot.Count - 1;
            var script = string.Format("__doPostBack('ctl00$bodyContent$UCAlliedLinesDetail$UCAirPlane$UCAirPlaneDetail$gvAirplaneDetailPilot$cell{0}_0$TC$btnEditOrSave','')", Index);
            this.ExcecuteJScript(script);
        }

        protected void gvAirplaneDetailPilot_PreRender(object sender, EventArgs e)
        {
            var Grid = (sender as DevExpress.Web.ASPxGridView);

            //Traducir las columnas
            Grid.TranslateColumnsAspxGrid();
        }

        protected void gvAirplaneDetailPilot_PageIndexChanged(object sender, EventArgs e)
        {
            if (!isInsertingNewRecord)
                FillGrid();
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