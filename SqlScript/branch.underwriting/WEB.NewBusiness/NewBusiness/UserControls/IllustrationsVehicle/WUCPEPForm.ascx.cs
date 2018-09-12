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
    public partial class WUCPEPForm : UC, IUC
    {
        public Utility.CumplimientoItem SelectedcumplimientoItem
        {
            get
            {
                return (Utility.CumplimientoItem)ViewState["SelectedcumplimientoItem"];
            }
            set
            {
                ViewState["SelectedcumplimientoItem"] = value;
            }
        }
        public TextBox txtName { get; set; }
        public DropDownList ddlParentesco { get; set; }
        public TextBox txtCargoPublico { get; set; }
        public TextBox txtanioDesde { get; set; }
        public TextBox txtAnioHasta { get; set; }
        public string hdnOrigen { get; set; }

        private List<PEP> dataPEP = new List<PEP>(0);

        [Serializable]
        public class PEP
        {
            public Utility.RecordStatus Status { get; set; }
            public int RecordIndex { get; set; }
            public string NombreCompleto { get; set; }
            public int? ParentescoId { get; set; }
            public string ParentescoDesc { get; set; }
            public string CargoPublico { get; set; }
            public string anioDesde { get; set; }
            public string anioHasta { get; set; }
            public int? BeneficiaryId { get; set; }
            public bool? IsPepManagerCompany { get; set; }
            public int? PepFormularyOptionsId { get; set; }
        }

        public int ContactId
        {
            get
            {
                return
                      ViewState["ContactId"].ToInt();
            }

            set
            {
                ViewState["ContactId"] = value;
            }

        }

        public int? RelationShipIdSelected
        {
            get
            {
                return
                      ViewState["RelationShipIdSelected"].ToInt();
            }

            set
            {
                ViewState["RelationShipIdSelected"] = value;
            }

        }

        public bool HasPEP
        {
            get
            {
                return
                      ViewState["HasPEP"].ToBoolean();
            }

            set
            {
                ViewState["HasPEP"] = value;
            }

        }

        public List<PEP> oTemDataPEP
        {
            get
            {
                return ViewState["TemDataPEP"] == null ?
                    new List<PEP>() :
                    ViewState["TemDataPEP"] as List<PEP>;
            }

            set
            {
                List<PEP> tempList = null;

                if (value != null)
                {
                    tempList = new List<PEP>(
                            ViewState["TemDataPEP"] != null
                            ?
                            (
                               (List<PEP>)ViewState["TemDataPEP"]
                            )
                            :
                            new List<PEP>()
                      );

                    tempList.AddRange(value);
                }

                ViewState["TemDataPEP"] = tempList;
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
        public bool isDesigned
        {
            get
            {
                return ViewState["isDesigned"].ToBoolean();
            }
            set
            {
                ViewState["isDesigned"] = value;
            }
        }
        public string DesignedFullName
        {
            get
            {
                return ViewState["DesignedFullName"].ToString();
            }
            set
            {
                ViewState["DesignedFullName"] = value;
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
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        private string GetRelationShipDesc(int? RelationShipId)
        {
            var DataRelationShip = ObjServices.GettingDropData(Utility.DropDownType.RelationshipPEP).Select(g => new { Text = g.RelationshipDesc, Value = g.RelationshipId });
            return DataRelationShip.FirstOrDefault(x => x.Value == RelationShipId).Text;
        }

        public IEnumerable<Entity.UnderWriting.Entities.Contact.PepFormulary.PEPFormResult> HasPEPEx(int ContactId)
        {
            if (string.IsNullOrEmpty(hdnOrigen))
                hdnOrigen = "CalidadPep";

            var dataPEPDB = ObjServices.oContactManager.GetContactPEPFormulary(ContactId, hdnOrigen);
            return
                  dataPEPDB;
        }

        public void FillData()
        {
            //Verificar si existen datos en la base de datos
            if (string.IsNullOrEmpty(hdnOrigen))
                hdnOrigen = "CalidadPep";
            var dataPEPDB = ObjServices.oContactManager.GetContactPEPFormulary(this.ContactId, hdnOrigen);
            HasPEP = dataPEPDB.Any();

            oTemDataPEP = null;
            var dataFormated = dataPEPDB.Select(h => new PEP
            {
                Status = Utility.RecordStatus.Old,
                RecordIndex = h.PepFormularyId,
                NombreCompleto = this.isDesigned? this.DesignedFullName: h.PepFormularyOptionsId == 2? "": h.Name,
                ParentescoId = (!h.RelationshipId.HasValue || h.RelationshipId == 0) ? (int?)null : h.RelationshipId.GetValueOrDefault(),
                ParentescoDesc = (!h.RelationshipId.HasValue || h.RelationshipId == 0) ? string.Empty : GetRelationShipDesc(h.RelationshipId),
                CargoPublico = h.Position,
                anioDesde = h.FromYear.HasValue ? h.FromYear > 0 ? h.FromYear.ToString() : string.Empty : string.Empty,
                anioHasta = h.ToYear.HasValue ? h.ToYear > 0 ? h.ToYear.ToString() : string.Empty : string.Empty,
                BeneficiaryId = h.BeneficiaryId,
                IsPepManagerCompany = h.IsPepManagerCompany,
                PepFormularyOptionsId = this.isDesigned? 1: h.PepFormularyOptionsId
            }).ToList();

            dataPEP.AddRange(dataFormated);
            oTemDataPEP = dataPEP;

            FillGridPEP();

            //Recorro el grid para deshabilitar el dropdown de parentescos
            for (var i = 0; i <= oTemDataPEP.Count - 1; i++)
            {
                var ddl = gvPEP.FindRowCellTemplateControl(i, null, "ddlParentesco") as DropDownList;
                var pepTypeLabel = gvPEP.FindRowCellTemplateControl(i, null, "PepFormularyOptionsId") as Label;
                var BeneficiaryId = gvPEP.FindRowCellTemplateControl(i, null, "BeneficiaryId") as Label;
                var ControlDelete = gvPEP.FindRowCellTemplateControl(i, null, "btnDeletePEP") as LinkButton;

                if (!string.IsNullOrEmpty(BeneficiaryId.Text))
                {
                    if (BeneficiaryId.Text.ToInt() > 0)
                        ControlDelete.Visible = false;
                }
                ddl.Enabled = (pepTypeLabel.Text != "1"); // lo activa si es diferente de designado
            }
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {
            RelationShipIdSelected = null;
            HasPEP = false;
            isInsertingNewRecord = false;
            oTemDataPEP = null;
        }

        private void FillGridPEP(bool isLocal = false)
        {
            gvPEP.DataSource = oTemDataPEP;
            gvPEP.DataBind();
        }

        private void DoClickEdit(int Index)
        {
            var script = string.Format("javascript:__doPostBack('ctl00$bodyContent$ucInsuredInformation$UCContactEditForm$WUCPEPForm$gvPEP$cell{0}_0$TC$btnEditOrSavePEP','')", Index);
            this.ExcecuteJScript(script);
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            int RecIndex = oTemDataPEP.Count() + 1;

            if (isInsertingNewRecord)
                return;

            dataPEP.Add(new PEP
            {
                RecordIndex = RecIndex,
                Status = Utility.RecordStatus.New,
                NombreCompleto = this.isDesigned? this.DesignedFullName: string.Empty,
                ParentescoId = null,
                ParentescoDesc = string.Empty,
                CargoPublico = string.Empty,
                anioDesde = string.Empty,
                anioHasta = string.Empty,
                BeneficiaryId = 0,
                PepFormularyOptionsId = this.isDesigned? 1 : 0,
                IsPepManagerCompany = string.IsNullOrEmpty(hdnOrigen) || hdnOrigen == "CalidadPep"? false: true
            });

            isInsertingNewRecord = true;
            oTemDataPEP = dataPEP;
            FillGridPEP(true);
            gvPEP.PageIndex = gvPEP.PageCount;
            var Index = oTemDataPEP.Count - 1;
            DoClickEdit(Index);
            ValidateDesignedPeps();
        }

        private void SetControlsPEP(DevExpress.Web.ASPxGridView grid, int VisibleIndex)
        {
            txtName = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtName") as TextBox;
            ddlParentesco = grid.FindRowCellTemplateControl(VisibleIndex, null, "ddlParentesco") as DropDownList;
            txtCargoPublico = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtCargoPublico") as TextBox;
            txtanioDesde = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtanioDesde") as TextBox;
            txtAnioHasta = grid.FindRowCellTemplateControl(VisibleIndex, null, "txtAnioHasta") as TextBox;
        }

        private void EditModePEP(bool isEdit, DevExpress.Web.ASPxGridView grid, int VisibleIndex, PEP Record = null)
        {
            SetControlsPEP(grid, VisibleIndex);
            var ltName = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltName") as Control;
            var ltParentesco = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltParentesco") as Control;
            var ltCargoPublico = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltCargoPublico") as Control;
            var ltanioDesde = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltanioDesde") as Control;
            var ltAnioHasta = grid.FindRowCellTemplateControl(VisibleIndex, null, "ltAnioHasta") as Control;
            var PepFormularyOptionsId = grid.FindRowCellTemplateControl(VisibleIndex, null, "PepFormularyOptionsId") as Label;
            if (this.isDesigned)
                PepFormularyOptionsId.Text = "1";

            if (txtName != null) txtName.Visible = isEdit;
            if (ltName != null) ltName.Visible = !isEdit;

            if (ddlParentesco != null)
            {
                var DataRelationShip = ObjServices.GettingDropData(Utility.DropDownType.RelationshipPEP).Select(g => new { Text = g.RelationshipDesc, Value = g.RelationshipId });
                ddlParentesco.DataSource = DataRelationShip;
                ddlParentesco.DataTextField = "Text";
                ddlParentesco.DataValueField = "Value";
                ddlParentesco.DataBind();
                ddlParentesco.Items.Insert(0, new ListItem { Text = "----", Value = "-1" });
                ddlParentesco.Visible = isEdit;

                if (Record != null && Record.ParentescoId > 0)
                {
                    ddlParentesco.SelectedValue = Record.ParentescoId.ToString();
                    RelationShipIdSelected = Record.ParentescoId;
                }

                //var isEnabledParentesco = !(this.SelectedcumplimientoItem.pepFormularyOptionId == 1);
                var isEnabledParentesco = ( PepFormularyOptionsId.Text != "1");

                ddlParentesco.Enabled = isEnabledParentesco;
                if ((isEnabledParentesco))
                    ddlParentesco.Attributes.Add("validation", "Required");
                else
                    ddlParentesco.Attributes.Remove("validation");

                if (ltParentesco != null) ltParentesco.Visible = !isEdit;
            }

            if (txtCargoPublico != null) txtCargoPublico.Visible = isEdit;
            if (ltCargoPublico != null) ltCargoPublico.Visible = !isEdit;

            if (txtanioDesde != null) txtanioDesde.Visible = isEdit;
            if (ltanioDesde != null) ltanioDesde.Visible = !isEdit;

            if (txtAnioHasta != null) txtAnioHasta.Visible = isEdit;
            if (ltAnioHasta != null) ltAnioHasta.Visible = !isEdit;
          
        }


        private void ActualizaContactForm()
        {
            var HasRecords = oTemDataPEP.Any();

            var IllustrationsVehiclePage = Page as WEB.NewBusiness.NewBusiness.Pages.IllustrationsVehicle;

            if (IllustrationsVehiclePage != null)
            {
                var UCContactEditForm = Utility.GetAllChildren(IllustrationsVehiclePage).FirstOrDefault(uc => uc is UCContactEditForm);
                if (UCContactEditForm != null)
                {
                    var oForm = (UCContactEditForm as UCContactEditForm);

                    var btnVerPEPS = oForm.FindControl("btnVerPEPS");
                    if (btnVerPEPS != null)
                    {
                        (btnVerPEPS as LinkButton).Visible = HasRecords;

                        var udpContactEditForm = oForm.FindControl("udpContactEditForm");
                        if (udpContactEditForm != null)
                            (udpContactEditForm as UpdatePanel).Update();

                        if (!HasRecords)
                        {
                            var ddlPep = oForm.FindControl("ddlPep");
                            if (ddlPep != null)
                                (ddlPep as DropDownList).SelectIndexByValue("-1");

                        }

                        var mpePepPop = oForm.FindControl("mpePepPop");
                        if (mpePepPop != null)
                            (mpePepPop as AjaxControlToolkit.ModalPopupExtender).Show();
                    }

                    oForm.save();
                }
            }
        }

        protected void gvPEP_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView;
            var Command = e.CommandArgs.CommandName;

            var RecordIndex = grid.GetKeyFromAspxGridView("RecordIndex", e.VisibleIndex).ToInt();
            var StatusStr = grid.GetKeyFromAspxGridView("Status", e.VisibleIndex).ToString();
            var Status = (Utility.RecordStatus)Enum.Parse(typeof(Utility.RecordStatus), StatusStr);

            var btnEditOrSavePEP = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnEditOrSavePEP") as LinkButton;
            var btnCancelPEP = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "btnCancelPEP") as LinkButton;
            var btnDelete = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "pnDelete") as Panel;
            var ddl = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "ddlParentesco") as DropDownList;
            var BeneficiaryId = grid.FindRowCellTemplateControl(e.VisibleIndex, null, "BeneficiaryId") as Label;
            var Record = (isInsertingNewRecord) ? oTemDataPEP.Last()
                                                : oTemDataPEP.FirstOrDefault(r => r.RecordIndex == RecordIndex);

            Record.ParentescoId = RelationShipIdSelected;

            switch (Command)
            {
                case "Delete":
                    ObjServices.oContactManager.SetContactPepFormulary(this.ContactId,
                                                                       (Status == Utility.RecordStatus.Old) ? Record.RecordIndex : (int?)null,
                                                                        Record.NombreCompleto,
                                                                        Record.ParentescoId,
                                                                        Record.CargoPublico,
                                                                        Record.anioDesde.ToInt(),
                                                                        Record.anioHasta.ToInt(),
                                                                        false,
                                                                        ObjServices.UserID.GetValueOrDefault(),
                                                                        Record.BeneficiaryId,
                                                                        Record.IsPepManagerCompany
                                                                        );
                    FillData();
                    ActualizaContactForm();
                    break;
                case "Cancel":
                    if (btnCancelPEP != null) btnCancelPEP.Visible = false;
                    if (btnEditOrSavePEP != null) btnEditOrSavePEP.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    EditModePEP(false, grid, e.VisibleIndex);
                    btnEditOrSavePEP.CommandName = "Edit";

                    var hasNewRecord = oTemDataPEP.Any(p => p.Status == Utility.RecordStatus.New);

                    if (hasNewRecord)
                    {
                        var result = oTemDataPEP.Where(p => p.Status != Utility.RecordStatus.New).ToList();
                        oTemDataPEP = null;
                        oTemDataPEP = result;
                        FillGridPEP();
                        gvPEP.PageIndex = 0;
                    }
                    isInsertingNewRecord = false;
                    break;
                case "Edit":
                    if (btnCancelPEP != null) btnCancelPEP.Visible = true;
                    if (btnEditOrSavePEP != null) btnEditOrSavePEP.CssClass = "mysave_file";
                    if (btnDelete != null) btnDelete.Visible = false;
                    btnEditOrSavePEP.CommandName = "Save";
                    EditModePEP(true, grid, e.VisibleIndex, Record);
                    break;
                case "Save":
                    if (ddl.Enabled && (!Record.ParentescoId.HasValue || Record.ParentescoId <= 0))
                    {
                        this.MessageBox("Debe indicar el parentesco");
                        break;
                    }
                                 

                    btnEditOrSavePEP.CommandName = "Edit";
                    if (btnCancelPEP != null) btnCancelPEP.Visible = false;
                    if (btnEditOrSavePEP != null) btnEditOrSavePEP.CssClass = "myedit_file";
                    if (btnDelete != null) btnDelete.Visible = true;
                    isInsertingNewRecord = false;
                    EditModePEP(false, grid, e.VisibleIndex, Record);
                    SetControlsPEP(grid, e.VisibleIndex);
                    if (!string.IsNullOrEmpty(txtanioDesde.Text) && !string.IsNullOrEmpty(txtAnioHasta.Text))
                    {
                        if (txtanioDesde.Text.ToInt() > txtAnioHasta.Text.ToInt())
                        {
                            this.MessageBox("El Año Desde no puede ser mayor que el Año Hasta");
                            break;
                        }
                    }

                    Record.NombreCompleto = txtName.Text;
                    Record.Status = Utility.RecordStatus.Old;
                    Record.ParentescoId = ddlParentesco.Enabled ? RelationShipIdSelected : (int?)null;

                    if (ddlParentesco.Enabled)
                    {
                        ddlParentesco.SelectedValue = RelationShipIdSelected.ToString();
                        Record.ParentescoDesc = ddlParentesco.SelectedItem.Text;
                    }

                    Record.CargoPublico = txtCargoPublico.Text;
                    Record.anioDesde = txtanioDesde.Text;
                    Record.anioHasta = txtAnioHasta.Text;
                    if (!string.IsNullOrEmpty(BeneficiaryId.Text))
                    {
                        if (BeneficiaryId.Text.ToInt() > 0)
                            Record.BeneficiaryId = BeneficiaryId.Text.ToInt();
                    }

                    if (hdnOrigen == null || hdnOrigen == "CalidadPep")
                        Record.IsPepManagerCompany = false;
                    else
                        Record.IsPepManagerCompany = true;

                    ObjServices.oContactManager.SetContactPepFormulary(this.ContactId,
                                                                      (Status == Utility.RecordStatus.Old) ? Record.RecordIndex : (int?)null,
                                                                       Record.NombreCompleto,
                                                                       Record.ParentescoId,
                                                                       Record.CargoPublico,
                                                                       Record.anioDesde.ToInt(),
                                                                       Record.anioHasta.ToInt(),
                                                                       true,
                                                                       ObjServices.UserID.GetValueOrDefault(),
                                                                       Record.BeneficiaryId,
                                                                       Record.IsPepManagerCompany
                                                                      );

                    FillData();
                    ActualizaContactForm();
                    break;
            }

        }

        protected void ddlParentesco_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Drop = (sender as DropDownList);
            var ItemSelectedValue = Drop.SelectedValue;
            RelationShipIdSelected = ItemSelectedValue.ToInt();
        }
        private void ValidateDesignedPeps()
        {
            var i = 0;
            //seteando el valor de cada dropdown
            for (i = 0; i <= oTemDataPEP.Count() - 1; i++)
            {

                ddlParentesco = gvPEP.FindRowCellTemplateControl(i, null, "ddlParentesco") as DropDownList;
                if (this.isDesigned)
                    ddlParentesco.Enabled = false;
            }
        }
    }
}