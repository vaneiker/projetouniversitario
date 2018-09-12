using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DI.UnderWriting.Interfaces;
using DI.UnderWriting;
using WEB.NewBusiness.Common;
using DevExpress.Web;
using PdfViewer4AspNet;
using RESOURCE.UnderWriting.NewBussiness;
using System.Globalization;

namespace WEB.NewBusiness.NewBusiness.UserControls.Beneficiaries
{
    public partial class WUCBeneficiaries : UC, IUC
    {
        public void ReadOnlyControls(bool isReadOnly) { }
        public void edit() { }
        public void FillData() { }

        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }

        private Boolean IsInsured
        {
            get { return Boolean.Parse(String.IsNullOrEmpty(hdnIsInsured.Value) ? "false" : hdnIsInsured.Value); }
            set { hdnIsInsured.Value = value.ToString(); }
        }

        public Boolean IsEditPop
        {
            get { return Boolean.Parse(String.IsNullOrEmpty(HFIsEditPop.Value) ? "false" : HFIsEditPop.Value); }
            set { HFIsEditPop.Value = value.ToString(); }
        }

        private int BeneficiaryTypeID
        {
            get { return int.Parse(String.IsNullOrEmpty(hdnBeneficiarieTypeID.Value) ? "0" : hdnBeneficiarieTypeID.Value); }
            set { hdnBeneficiarieTypeID.Value = value.ToString(); }
        }

        public class ValidationType
        {
            public Boolean Exists { get; set; }
            public Boolean IsSameId { get; set; }
        }

        public WUCBeneficiaries UCContingentBeneficiarie { get; set; }

        public void EnabledControls(bool x)
        {
            Utility.EnableControlswithoutRecursion(pnBeneficiaries.Controls, x);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvBeneficiariesCompany.RenderTableHeaderOrTableFooterOnGridView();
            gvBeneficiaries.RenderTableHeaderOrTableFooterOnGridView();
        }

        #region Interface Methods

        public void save()
        {
            var Corp_Id = ObjServices.Corp_Id;
            var Region_Id = ObjServices.Region_Id;
            var Country_Id = ObjServices.Country_Id;
            var Domesticreg_Id = ObjServices.Domesticreg_Id;
            var State_Prov_Id = ObjServices.State_Prov_Id;
            var City_Id = ObjServices.City_Id;
            var Office_Id = ObjServices.Office_Id;
            var Case_Seq_No = ObjServices.Case_Seq_No;
            var Hist_Seq_No = ObjServices.Hist_Seq_No;

            if (gvBeneficiariesCompany.Rows.Count > 0 || gvBeneficiaries.Rows.Count > 0)
                ObjServices.oBeneficiaryManager.UpdateComment(Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id
                    , City_Id, Office_Id, Case_Seq_No, Hist_Seq_No, IsInsured, BeneficiaryTypeID, txtSpecialInstructions.Text, 1);
        }

        public void Initialize(String BeneficiarieType)
        {
            Initialize();
            FillData(BeneficiarieType);
        }

        public void ClearData()
        {
            CleanPdf();

            gvBeneficiaries.DataSource = null;
            gvBeneficiaries.DataBind();

            gvBeneficiariesCompany.DataSource = null;
            gvBeneficiariesCompany.DataBind();
            txtSpecialInstructions.Text = String.Empty;

            ClearFields(true);
            ClearFields(false);
        }

        public void FillData(Boolean FillDrops = true)
        {
            var Corp_Id = this.ObjServices.Corp_Id;
            var Region_Id = this.ObjServices.Region_Id;
            var Country_Id = this.ObjServices.Country_Id;
            var Domesticreg_Id = this.ObjServices.Domesticreg_Id;
            var State_Prov_Id = this.ObjServices.State_Prov_Id;
            var City_Id = this.ObjServices.City_Id;
            var Office_Id = this.ObjServices.Office_Id;
            var Case_Seq_No = this.ObjServices.Case_Seq_No;
            var Hist_Seq_No = this.ObjServices.Hist_Seq_No;

            /* 
             --- Como llamar al metodo que trae la data según el tipo de Beneficiario ---
            Main Insured: isInsured = True, beneficiarieTypeId = 1
            Main Insured Contingent: isInsured = True, beneficiarieTypeId = 2
            Aditional Insured: isInsured = False, beneficiarieTypeId = 1
            Aditional Insured Contingent: isInsured = False, beneficiarieTypeId = 2 
            */

            //Lleno la data de los Beneficiarios segun el Valor del HiddenField (1 - Insured Main, 2 - Insured Contingent, 3 - Additional Insured Main, 4 - Additional Insured Contingent)
            switch (hdnBeneficiarieType.Value)
            {
                case "2":
                    IsInsured = true;
                    BeneficiaryTypeID = 2;
                    lblBeTitle.Text = "CONTINGENT BENEFICIARIES";
                    break;
                case "3":
                    IsInsured = false;
                    BeneficiaryTypeID = 1;
                    lblBeTitle.Text = "MAIN BENEFICIARIES";
                    break;
                case "4":
                    IsInsured = false;
                    BeneficiaryTypeID = 2;
                    lblBeTitle.Text = "CONTINGENT BENEFICIARIES";
                    break;
                default:
                    IsInsured = true;
                    BeneficiaryTypeID = 1;
                    lblBeTitle.Text = "MAIN BENEFICIARIES";
                    break;
            }

            var data = ObjServices.oBeneficiaryManager.GetAllBeneficiary(Corp_Id,
                                                                         Region_Id,
                                                                         Country_Id,
                                                                         Domesticreg_Id,
                                                                         State_Prov_Id,
                                                                         City_Id,
                                                                         Office_Id,
                                                                         Case_Seq_No,
                                                                         Hist_Seq_No,
                                                                         IsInsured,
                                                                         BeneficiaryTypeID,
                                                                         null,
                                                                         languageId: ObjServices.Language.ToInt()
                                                                         ).Select(x =>
                                                                         {
                                                                             x.BenefitsPercentF = (x.BenefitsPercent == null ? "0.00" : x.BenefitsPercent.Value.ToFormatNumeric());
                                                                             return x;
                                                                         }).ToList();

            //Llenar Grid  de Beneficiarios
            gvBeneficiaries.DataSource = data.Where(r => r.IsCompany.Value == false);
            gvBeneficiaries.DataBind();
            gvBeneficiaries.RenderTableHeaderOrTableFooterOnGridView();

            //Llenar Grid  de Beneficiarios tipo Compañía
            gvBeneficiariesCompany.DataSource = data.Where(r => r.IsCompany.Value);
            gvBeneficiariesCompany.DataBind();
            gvBeneficiariesCompany.RenderTableHeaderOrTableFooterOnGridView();

            //Llenar el Textbox de Comentarios (Special Instructions)
            txtSpecialInstructions.Text = data.Any() ? (String.IsNullOrWhiteSpace(data.First().Comments) ? txtSpecialInstructions.Text
                                                     : data.First().Comments) : txtSpecialInstructions.Text;

            //Llena los Dropdowns de los Mantenimientos
            if (FillDrops)
                FillDropDowns();

            //Muestra u oculta los campos segun el tipo de beneficiario
            ShowHideControls();

            if (BeneficiaryTypeID == 1 && IsInsured)
                UCContingentBeneficiarie.Initialize("2");
            else if (BeneficiaryTypeID == 1 && !IsInsured)
                UCContingentBeneficiarie.Initialize("4");
        }

        public void FillData(String BeneficiarieType)
        {
            ClearData();
            hdnBeneficiarieType.Value = BeneficiarieType;
            FillData(true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Limpia los campos de los mantenimientos de los beneficiarios.
        /// </summary>
        /// <param name="CompanyBeneficiarie" >Parametro para indicar si se van a limpiar los campos del Beneficiario o del Beneficiario Compañía </param>
        private void ClearFields(bool CompanyBeneficiarie)
        {
            if (!CompanyBeneficiarie)
            {
                txtFirstName.Text = String.Empty;
                txtMiddleName.Text = String.Empty;
                txtLastName.Text = String.Empty;
                txtSecondLastName.Text = String.Empty;
                txtBEDateofBirth.Text = String.Empty;
                txtPercentage.Text = String.Empty;
                txtIDNo.Text = String.Empty;
                ddlRelationship.SelectedIndex = ddlRelationship.Items.Count > 0 ? 0 : -1;
                ddlReplacing.SelectedIndex = ddlReplacing.Items.Count > 0 ? 0 : -1;
                cbxIDType.SelectedIndex = cbxIDType.Items.Count > 0 ? 0 : -1;
                pnGvBeneficiaries.CssClass = "grid_wrap margin_t_10 mB";
                gvBeneficiaries.Enabled = true;

                hdnEditIndex.Value = "0";
                hdnIsEdit.Value = "false";
                hdnUploadedPDFPath.Text = "";
            }
            else
            {
                txtEntityName.Text = String.Empty;
                txtBEIncorporationDate.Text = String.Empty;
                txtEntityPercentage.Text = String.Empty;
                txtEntityIDNo.Text = String.Empty;

                ddlEntityType.SelectedIndex = ddlEntityType.Items.Count > 0 ? 0 : -1;
                ddlReplacingCompany.SelectedIndex = ddlReplacingCompany.Items.Count > 0 ? 0 : -1;
                gvBeneficiariesCompany.Enabled = true;
                pnGvCompany.CssClass = "grid_wrap margin_t_10";

                hdnEditIndexCompany.Value = "0";
                hdnIsEditCompany.Value = "false";
                hdnUploadedPDFPathCompany.Text = "";
            }
        }

        /// <summary>
        /// Llena los dropdowns de los mantenimientos.
        /// </summary>
        private void FillDropDowns()
        {
            var Corp_Id = ObjServices.Corp_Id;
            var Region_Id = ObjServices.Region_Id;
            var Country_Id = ObjServices.Country_Id;
            var Domesticreg_Id = ObjServices.Domesticreg_Id;
            var State_Prov_Id = ObjServices.State_Prov_Id;
            var City_Id = ObjServices.City_Id;
            var Office_Id = ObjServices.Office_Id;
            var Case_Seq_No = ObjServices.Case_Seq_No;
            var Hist_Seq_No = ObjServices.Hist_Seq_No;

            //Llenar el DropDown de RelationShips
            ObjServices.GettingAllDrops(ref ddlRelationship, Utility.DropDownType.Relationship,
                                    "RelationshipDesc", "RelationshipId",
                                    GenerateItemSelect: true, corpId: Corp_Id);

            //Llenar el DropDown de Entity Type
            ObjServices.GettingAllDropsJSON(ref ddlEntityType, Utility.DropDownType.CompanyType,
                                    "OccupationDesc",
                                    GenerateItemSelect: true, corpId: Corp_Id,
                                    occupGroupTypeId: 1);

            if (ddlEntityType.Items.Count > 0)
                ddlEntityType.SelectedIndex = 0;

            if (ddlRelationship.Items.Count > 0)
                ddlRelationship.SelectedIndex = 0;

            if (BeneficiaryTypeID == 2)
            {
                //Llenar el DropDown de Replacing
                ObjServices.GettingAllDrops(ref ddlReplacing, Utility.DropDownType.PrimaryBeneficiary,
                                        "CodeName", "ContactId",
                                        GenerateItemSelect: true, corpId: Corp_Id,
                                        regionId: Region_Id, countryId: Country_Id,
                                        domesticregId: Domesticreg_Id, stateProvId: State_Prov_Id,
                                        cityId: City_Id, officeId: Office_Id, caseSeqNo: Case_Seq_No,
                                        histSeqNo: Hist_Seq_No, isInsured: IsInsured);

                //Llenar el DropDown de Replacing Company
                ObjServices.GettingAllDrops(ref ddlReplacingCompany, Utility.DropDownType.PrimaryBeneficiary,
                                        "CodeName", "ContactId",
                                        GenerateItemSelect: true, corpId: Corp_Id,
                                        regionId: Region_Id, countryId: Country_Id,
                                        domesticregId: Domesticreg_Id, stateProvId: State_Prov_Id,
                                        cityId: City_Id, officeId: Office_Id, caseSeqNo: Case_Seq_No,
                                        histSeqNo: Hist_Seq_No, isInsured: IsInsured);

                if (ddlReplacing.Items.Count > 0)
                    ddlReplacing.SelectedIndex = 0;

                if (ddlReplacingCompany.Items.Count > 0)
                    ddlReplacingCompany.SelectedIndex = 0;
            }
            ObjServices.GettingAllDrops(ref cbxIDType,
            Utility.DropDownType.IdType,
            "ContactTypeIdDesc",
            "ContactTypeId",
            GenerateItemSelect: true,
            corpId: ObjServices.Corp_Id);
        }

        /// <summary>
        /// Obtiene la suma total del porcentaje de ambos tipos de Beneficiarios
        /// </summary>
        /// <param name="contactID">Este parametro sirve para que obvie la suma de un Beneficiario en especifico, en caso de querer sumar todos enviar nulo o no enviar.</param>
        /// <returns></returns>
        private Decimal GetTotalPercentage(int? contactID = null)
        {
            Decimal sumPercent = 0;

            if (contactID != null)
            {
                foreach (GridViewRow item in gvBeneficiaries.Rows)
                {
                    var rContactId = int.Parse(gvBeneficiaries.DataKeys[item.RowIndex]["ContactId"].ToString());

                    if (rContactId != contactID)
                    {
                        var lbl = ((Label)item.FindControl("lblBenefitsPercent")).Text.Replace("%", "");
                        sumPercent += Decimal.Parse(lbl, CultureInfo.InvariantCulture);
                    }
                }

                foreach (GridViewRow item in gvBeneficiariesCompany.Rows)
                {
                    var rContactId = int.Parse(gvBeneficiariesCompany.DataKeys[item.RowIndex]["ContactId"].ToString());

                    if (rContactId != contactID)
                    {
                        var lbl = ((Label)item.FindControl("lblBenefitsPercent")).Text.Replace("%", "");
                        sumPercent += Decimal.Parse(lbl, CultureInfo.InvariantCulture);
                    }
                }
            }
            else
            {
                foreach (GridViewRow item in gvBeneficiaries.Rows)
                {
                    var lbl = ((Label)item.FindControl("lblBenefitsPercent")).Text.Replace("%", "");
                    sumPercent += Decimal.Parse(lbl, CultureInfo.InvariantCulture);
                }

                foreach (GridViewRow item in gvBeneficiariesCompany.Rows)
                {
                    var lbl = ((Label)item.FindControl("lblBenefitsPercent")).Text.Replace("%", "");
                    sumPercent += Decimal.Parse(lbl, CultureInfo.InvariantCulture);
                }
            }

            return sumPercent;
        }

        public Boolean CompletedData()
        {
            if (GetTotalPercentage() < 100)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Metodo para validar que un beneficiario ya existe.
        /// </summary>
        /// <param name="IsCompany">Para especificar si el beneficiario es una compañia o una persona.</param>
        /// <param name="ExcludeContacID"> Para que no tome en cuenta a una persona en especifico en la validación.</param>
        /// <param name="ExcludeContactRoleTypeId">Para que no tome en cuenta a una persona en especifico en la validación.</param>
        /// <returns></returns>
        private ValidationType ValidateCurrentBeneficiaries(Boolean IsCompany, int? ExcludeContacID = null, int? ExcludeContactRoleTypeId = null)
        {
            var ExistsItem = new ValidationType { Exists = false, IsSameId = false };

            var data = ObjServices.oBeneficiaryManager.GetAllBeneficiary(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id,
                ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No,
                ObjServices.Hist_Seq_No, IsInsured, BeneficiaryTypeID, null, languageId: ObjServices.Language.ToInt()).Where(r => r.IsCompany == IsCompany).ToList();

            var data2 = ObjServices.oBeneficiaryManager.GetAllBeneficiary(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id,
             ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No,
             ObjServices.Hist_Seq_No, IsInsured, (BeneficiaryTypeID == 1 ? 2 : 1), null, languageId: ObjServices.Language.ToInt()).Where(r => r.IsCompany == IsCompany).ToList();


            if (ExcludeContacID.HasValue)
                data = data.Where(r => !(r.ContactId == ExcludeContacID.Value && r.ContactRoleTypeId == ExcludeContactRoleTypeId.Value)).ToList();

            if (IsCompany)
            {
                foreach (var item in data)
                {
                    var ddlValue = new Utility.ddlEntityTypeItem { OccupationId = item.OccupationId.Value, OccupGroupTypeId = 1 };
                    var ddlValueJson = Utility.serializeToJSON(ddlValue);

                    if (item.InstitutionalName.Trim() == txtEntityName.Text.Trim() &&
                                           ddlValueJson == ddlEntityType.SelectedValue &&
                                           item.Dob.Value == txtBEIncorporationDate.Text.ParseFormat())
                    {
                        ExistsItem.IsSameId = false;
                        ExistsItem.Exists = true;
                        return ExistsItem;
                    }
                    else if (!String.IsNullOrWhiteSpace(txtEntityIDNo.Text) && item.IsCompany == true)
                    {
                        //aqui va tu condicional
                        if (item.ContactMainId.Trim() == txtEntityIDNo.Text.Trim())
                        {
                            ExistsItem.IsSameId = true;
                            ExistsItem.Exists = false;
                            return ExistsItem;
                        };
                    }

                }
            }
            else
            {
                foreach (var item in data)
                {
                    if (item.FirstName.Trim() == txtFirstName.Text.Trim() &&
                        item.FirstLastName.Trim() == txtLastName.Text.Trim() &&
                        item.Dob.Value == txtBEDateofBirth.Text.ParseFormat())
                    {
                        ExistsItem.IsSameId = false;
                        ExistsItem.Exists = true;
                        return ExistsItem;
                    }
                    else if ((hdnBeneficiarieType.Value.Trim() == "1" || hdnBeneficiarieType.Value.Trim() == "2") && !String.IsNullOrWhiteSpace(txtIDNo.Text))
                    {
                        if (item.ContactMainId.Trim() == txtIDNo.Text.Trim())
                        {
                            ExistsItem.IsSameId = true;
                            ExistsItem.Exists = false;
                            return ExistsItem;
                        };
                    }
                }

                foreach (var item in data2)
                {
                    if (item.FirstName.Trim() == txtFirstName.Text.Trim() &&
                        item.FirstLastName.Trim() == txtLastName.Text.Trim() &&
                        item.Dob.Value == txtBEDateofBirth.Text.ParseFormat())
                    {
                        ExistsItem.IsSameId = false;
                        ExistsItem.Exists = true;
                        return ExistsItem;
                    }
                    else if ((hdnBeneficiarieType.Value.Trim() == "1" || hdnBeneficiarieType.Value.Trim() == "2") && !String.IsNullOrWhiteSpace(txtIDNo.Text))
                    {
                        if (item.ContactMainId.Trim() == txtIDNo.Text.Trim())
                        {
                            ExistsItem.IsSameId = true;
                            ExistsItem.Exists = false;
                            return ExistsItem;
                        };
                    }
                }


            }

            return ExistsItem;
        }

        /// <summary>
        /// Muestra u oculta los campos segun el tipo de beneficiario
        /// </summary>
        private void ShowHideControls()
        {
            pnlReplacingCompany.Visible = BeneficiaryTypeID != 1;
            pnlReplacing.Visible = BeneficiaryTypeID != 1;
            //gvBeneficiaries.Columns[8].Visible = BeneficiaryTypeID == 2;
            gvBeneficiariesCompany.Columns[5].Visible = BeneficiaryTypeID == 2;

            switch (hdnBeneficiarieType.Value)
            {
                case "2":
                    //FileUpload Controls
                    fuBenediciarieFile.CssClass = "MC";
                    hdnUploadedPDFPath.CssClass = "MC";
                    btnBEClear.CssClass = "boton MC";

                    txtBEDateofBirth.Attributes.Add("class", "datepicker alignL MC");
                    btnAdd.Attributes.Add("class", "boton MC");
                    txtFirstName.Attributes.Add("class", "MC");
                    txtLastName.Attributes.Add("class", "MC");
                    txtPercentage.Attributes.Add("class", "MC");
                    ddlRelationship.Attributes.Add("class", "wrap_select MC");

                    ///Company

                    //FileUpload Controls
                    fuBenediciarieFileCompany.CssClass = "MC";
                    hdnUploadedPDFPathCompany.CssClass = "MC";
                    btnBECompanyClear.CssClass = "boton MC";

                    txtBEIncorporationDate.Attributes.Add("class", "datepicker alignL MC");
                    txtEntityName.Attributes.Add("class", "MC");
                    txtEntityPercentage.Attributes.Add("class", "MC");
                    ddlEntityType.Attributes.Add("class", "wrap_select MC");
                    btnBECompanyAdd.Attributes.Add("class", "boton MC");
                    break;
                case "3":
                    //FileUpload Controls
                    fuBenediciarieFile.CssClass = "AP";
                    hdnUploadedPDFPath.CssClass = "AP";
                    btnBEClear.CssClass = "boton AP";

                    txtBEDateofBirth.Attributes.Add("class", "datepicker alignL AP");
                    btnAdd.Attributes.Add("class", "boton AP");
                    txtFirstName.Attributes.Add("class", "AP");
                    txtLastName.Attributes.Add("class", "AP");
                    txtPercentage.Attributes.Add("class", "AP");
                    ddlRelationship.Attributes.Add("class", "wrap_select AP");

                    ///Company

                    //FileUpload Controls
                    fuBenediciarieFileCompany.CssClass = "AP";
                    hdnUploadedPDFPathCompany.CssClass = "AP";
                    btnBECompanyClear.CssClass = "boton AP";

                    txtBEIncorporationDate.Attributes.Add("class", "datepicker alignL AP");
                    txtEntityName.Attributes.Add("class", "AP");
                    txtEntityPercentage.Attributes.Add("class", "AP");
                    ddlEntityType.Attributes.Add("class", "wrap_select AP");
                    btnBECompanyAdd.Attributes.Add("class", "boton AP");
                    break;
                case "4":
                    //FileUpload Controls
                    fuBenediciarieFile.CssClass = "AC";
                    hdnUploadedPDFPath.CssClass = "AC";
                    btnBEClear.CssClass = "boton AC";

                    txtBEDateofBirth.Attributes.Add("class", "datepicker alignL AC");
                    btnAdd.Attributes.Add("class", "boton AC");
                    txtFirstName.Attributes.Add("class", "AC");
                    txtLastName.Attributes.Add("class", "AC");
                    txtPercentage.Attributes.Add("class", "AC");
                    ddlRelationship.Attributes.Add("class", "wrap_select AC");

                    ///Company

                    //FileUpload Controls
                    fuBenediciarieFileCompany.CssClass = "AC";
                    hdnUploadedPDFPathCompany.CssClass = "AC";
                    btnBECompanyClear.CssClass = "boton AC";

                    txtBEIncorporationDate.Attributes.Add("class", "datepicker alignL AC");
                    txtEntityName.Attributes.Add("class", "AC");
                    txtEntityPercentage.Attributes.Add("class", "AC");
                    ddlEntityType.Attributes.Add("class", "wrap_select AC");
                    btnBECompanyAdd.Attributes.Add("class", "boton AC");
                    break;
                default:
                    //FileUpload Controls
                    fuBenediciarieFile.CssClass = "MP";
                    hdnUploadedPDFPath.CssClass = "MP";
                    btnBEClear.CssClass = "boton MP";

                    txtBEDateofBirth.Attributes.Add("class", "datepicker alignL MP");
                    btnAdd.Attributes.Add("class", "boton MP");
                    txtFirstName.Attributes.Add("class", "MP");
                    txtLastName.Attributes.Add("class", "MP");
                    txtPercentage.Attributes.Add("class", "MP");
                    ddlRelationship.Attributes.Add("class", "wrap_select MP");

                    ///Company

                    //FileUpload Controls
                    fuBenediciarieFileCompany.CssClass = "MP";
                    hdnUploadedPDFPathCompany.CssClass = "MP";
                    btnBECompanyClear.CssClass = "boton MP";

                    txtBEIncorporationDate.Attributes.Add("class", "datepicker alignL MP");
                    txtEntityName.Attributes.Add("class", "MP");
                    txtEntityPercentage.Attributes.Add("class", "MP");
                    ddlEntityType.Attributes.Add("class", "wrap_select MP");
                    btnBECompanyAdd.Attributes.Add("class", "boton MP");
                    break;
            }
        }

        private void CleanPdf()
        {
            var viewer = ((NewBusiness.UserControls.Common.WUCShowPDFPopup)this.Page.Master.FindControl("WUCShowPDFPopup1")).FindControl("pdfViewerMyPreviewPDF");

            if (viewer != null)
            {
                var pdfViewer = (PdfViewer)viewer;

                pdfViewer.PdfSourceBytes = null;
                pdfViewer.DataBind();
            }
        }
        #endregion

        #region Company Beneficiaries Events
        protected void btnBECompanyAdd_Click(object sender, EventArgs e)
        {
            var BItem = new Entity.UnderWriting.Entities.Beneficiary();

            BItem.BeneficiaryTypeId = BeneficiaryTypeID; //Aqui va si el beneficiario es contigente o primario. --1 es Primario y 2 Contingente.
            BItem.PrimaryBeneficiary = IsInsured; //True si es del Insured, False si es del Additional.

            var entTypeSplit = Utility.deserializeJSON<Utility.CompanyType>(ddlEntityType.SelectedValue);
            var FileName = TempFilePath + "\\" + hdnUploadedPDFPathCompany.Text;

            Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
            {
                InsuredName = txtFirstName.Text + " " + txtMiddleName.Text + " " + txtLastName.Text + " " + txtSecondLastName.Text,
                Role_Type_ID = 4,
                identification = txtIDNo.Text
            };

            if (hdnIsEditCompany.Value == "true")
            {
                int RoleTypeId, ContId;
                var rIndex = int.Parse(hdnEditIndexCompany.Value);

                if (IsEditPop)
                {
                    ContId = HFContactId.Value.ToInt();
                    RoleTypeId = HFContactRoleIDType.Value.ToInt();
                }
                else
                {
                    ContId = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["ContactId"].ToString());
                    RoleTypeId = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["ContactRoleTypeId"].ToString());
                }

                var ContactId = ContId;
                var ContactRoleTypeId = RoleTypeId;
                       

                //Valido que este beneficiario no exista en el grid antes de agregarlo
                if (ValidateCurrentBeneficiaries(true, ContactId, ContactRoleTypeId).Exists)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary" : "Beneficiario no válido";
                    string message = ObjServices.Language == Utility.Language.en ? "This Beneficiary is already in the list, please verify and try again." :
                                     "Este beneficiario ya está en la lista, por favor verifique e inténtelo de nuevo";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '');");
                    return;
                }

                int? SeqNo = null;
                if (gvBeneficiariesCompany.DataKeys[rIndex]["SeqNo"] != null) //Esto quiere decir que el ID del contacto no existe en la tabla de contactto
                    SeqNo = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["SeqNo"].ToString());

                //Busco en el grid la suma de los porcentajes de los beneficiarios, para asegurarme de que el mismo nunca pase de 100%.
                if ((GetTotalPercentage(ContactId) + Decimal.Parse(txtEntityPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture)) > 100)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                    string message = ObjServices.Language == Utility.Language.en ?
                          "The Percentage of all Beneficiaries can not exceed 100%, please verify and try again."
                        : "El Porcentaje de todos los beneficiarios no puede superar el 100%, por favor verifique e inténtelo de nuevo.";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                //Actualiza o Inserta el Documento del Beneficiario
                if (!String.IsNullOrEmpty(hdnUploadedPDFPathCompany.Text))
                {   

                    if (gvBeneficiariesCompany.DataKeys[rIndex]["DocumentId"] != null)
                    {

                        Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add2 = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                        {   
                            Contact_ID = ContactId
                        };

                        //Obtener Informacion del Documento desde el Grid
                        var DocumentCategoryId = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["DocumentCategoryId"].ToString());
                        var DocumentTypeId = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["DocumentTypeId"].ToString());
                        var DocumentId = int.Parse(gvBeneficiariesCompany.DataKeys[rIndex]["DocumentId"].ToString());

                        //Actualizar Documento
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, DocumentId, Utility.ReadBinaryFile(FileName), 1);

                        SendFileToOnBase(Add2, DocumentCategoryId, DocumentTypeId, FileName);
                    }
                    else
                    {
                        //Insertar Documento
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, null, Utility.ReadBinaryFile(FileName), 1);
                        SendFileToOnBase(Add, 25, 1, FileName);
                    }
                }

                //Seteo el Key del Item
                BItem.CorpId = this.ObjServices.Corp_Id;
                BItem.RegionId = this.ObjServices.Region_Id;
                BItem.CountryId = this.ObjServices.Country_Id;
                BItem.DomesticregId = this.ObjServices.Domesticreg_Id;
                BItem.StateProvId = this.ObjServices.State_Prov_Id;
                BItem.CityId = this.ObjServices.City_Id;
                BItem.OfficeId = this.ObjServices.Office_Id;
                BItem.CaseSeqNo = this.ObjServices.Case_Seq_No;
                BItem.HistSeqNo = this.ObjServices.Hist_Seq_No;
                BItem.ContactId = ContactId;
                BItem.ContactRoleTypeId = ContactRoleTypeId;

                BItem.ContactTypeId = Utility.ContactTypeId.Company.ToInt(); //Aqui el tipo de cliente 5 Compañia y  4 beneficiario.
                BItem.InstitutionalName = txtEntityName.Text;
                BItem.Dob = txtBEIncorporationDate.Text.ParseFormat();
                BItem.BenefitsPercent = Decimal.Parse(txtEntityPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture);
                BItem.ContactMainId = txtEntityIDNo.Text;
                BItem.OccupGroupTypeId = entTypeSplit.OccupGroupTypeId;
                BItem.OccupationId = entTypeSplit.OccupationId;
                BItem.PrimaryBeneficiaryId = BeneficiaryTypeID == 2 && ddlReplacingCompany.SelectedIndex > 0 ? int.Parse(ddlReplacingCompany.SelectedValue) : (int?)null;
                BItem.SeqNo = SeqNo;
                BItem.CreateUser = ObjServices.UserID.Value;

                ObjServices.oBeneficiaryManager.UpdatetBeneficiary(BItem);
            }
            else
            {
                var ContactRoleTypeId = 4;

                //Valido que este beneficiario no exista en el grid antes de agregarlo
                if (ValidateCurrentBeneficiaries(true).Exists)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary" : "Beneficiario no válido";
                    string message = ObjServices.Language == Utility.Language.en ? "This Beneficiary is already in the list, please verify and try again." :
                                    "Este beneficiario ya está en la lista, por favor verifique e inténtelo de nuevo";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                //Busco en el grid la suma de los porcentajes de los beneficiarios, para asegurarme de que el mismo nunca pase de 100%.
                if ((GetTotalPercentage() + Decimal.Parse(txtEntityPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture)) > 100)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                    string message = ObjServices.Language == Utility.Language.en ?
                         "The Percentage of all Beneficiaries can not exceed 100%, please verify and try again."
                       : "El Porcentaje de todos los beneficiarios no puede superar el 100%, por favor verifique e inténtelo de nuevo.";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                if (ValidateCurrentBeneficiaries(true).IsSameId)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary" : "Beneficiario no válido";
                    string message = ObjServices.Language == Utility.Language.en ? "There is already a Beneficiary with this ID, please try with other ID Number."
                        : "Ya existe un beneficiario con esta ID, por favor intente con otro número de identificación.";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                //Seteo el Key del Item
                BItem.CorpId = this.ObjServices.Corp_Id;
                BItem.RegionId = this.ObjServices.Region_Id;
                BItem.CountryId = this.ObjServices.Country_Id;
                BItem.DomesticregId = this.ObjServices.Domesticreg_Id;
                BItem.StateProvId = this.ObjServices.State_Prov_Id;
                BItem.CityId = this.ObjServices.City_Id;
                BItem.OfficeId = this.ObjServices.Office_Id;
                BItem.CaseSeqNo = this.ObjServices.Case_Seq_No;
                BItem.HistSeqNo = this.ObjServices.Hist_Seq_No;
                BItem.ContactRoleTypeId = ContactRoleTypeId;

                BItem.ContactTypeId = Utility.ContactTypeId.Company.ToInt(); //Aqui el tipo de cliente 5 Compañia y  4 beneficiario.
                BItem.InstitutionalName = txtEntityName.Text;
                BItem.Dob = txtBEIncorporationDate.Text.ParseFormat();
                BItem.BenefitsPercent = Decimal.Parse(txtEntityPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture);
                BItem.ContactMainId = txtEntityIDNo.Text;
                BItem.OccupGroupTypeId = entTypeSplit.OccupGroupTypeId;
                BItem.OccupationId = entTypeSplit.OccupationId;
                BItem.PrimaryBeneficiaryId = BeneficiaryTypeID == 2 && ddlReplacingCompany.SelectedIndex > 0 ? int.Parse(ddlReplacingCompany.SelectedValue) : (int?)null;
                BItem.IssuedBy = "-";
                BItem.CreateUser = ObjServices.UserID.Value;
                BItem.DocumentBinary = String.IsNullOrEmpty(hdnUploadedPDFPathCompany.Text) ? null : Utility.ReadBinaryFile(FileName);

                ObjServices.oBeneficiaryManager.InsertBeneficiary(BItem);
                  
                SendFileToOnBase(Add,25, 1, FileName);
            }

            btnBECompanyAdd.Text = Resources.Add.Capitalize();
            //Limpio los Campos y refresco la Data de los Grids
            ClearFields(true);
            FillData(false);
        }

        protected void btnBECompanyClear_Click(object sender, EventArgs e)
        {
            ClearFields(true);
        }

        protected void btnBECompanyRemove_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var ContactId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["ContactId"].ToString());
            var ContactRoleTypeId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["ContactRoleTypeId"].ToString());

            //Obtener Key desde la Session
            var CorpId = this.ObjServices.Corp_Id;
            var RegionId = this.ObjServices.Region_Id;
            var CountryId = this.ObjServices.Country_Id;
            var DomesticregId = this.ObjServices.Domesticreg_Id;
            var StateProvId = this.ObjServices.State_Prov_Id;
            var CityId = this.ObjServices.City_Id;
            var OfficeId = this.ObjServices.Office_Id;
            var CaseSeqNo = this.ObjServices.Case_Seq_No;
            var HistSeqNo = this.ObjServices.Hist_Seq_No;

            ObjServices.oBeneficiaryManager.DeleteBeneficiary(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo, ContactId, ContactRoleTypeId);
            FillData(false);
        }

        protected void btnBECompanyEdit_Click(object sender, EventArgs e)
        {
            var gridrow = (GridViewRow)((LinkButton)sender).NamingContainer;

            txtEntityName.Text = gvBeneficiariesCompany.DataKeys[gridrow.RowIndex]["InstitutionalName"].ToString();
            txtBEIncorporationDate.Text = ((Label)gridrow.FindControl("lblDob")).Text;

            var labelPercent = ((Label)gridrow.FindControl("lblBenefitsPercent")).Text;

            txtEntityPercentage.Text = String.IsNullOrEmpty(labelPercent) ? "0" :
                 labelPercent.Replace("%", "");

            txtEntityIDNo.Text = ((Label)gridrow.FindControl("lblContactID")).Text;

            var ddlValue = new Utility.ddlEntityTypeItem { OccupationId = int.Parse(gvBeneficiariesCompany.DataKeys[gridrow.RowIndex]["OccupationId"].ToString()), OccupGroupTypeId = 1 };
            var ddlValueJson = Utility.serializeToJSON(ddlValue);

            ddlEntityType.SelectIndexByValueJSON(ddlValueJson);

            if (hdnBeneficiarieType.Value == "2" || hdnBeneficiarieType.Value == "4")
            {
                var RelatedID = gvBeneficiariesCompany.DataKeys[gridrow.RowIndex]["PrimaryBeneficiaryId"] == null ? "0" : gvBeneficiariesCompany.DataKeys[gridrow.RowIndex]["PrimaryBeneficiaryId"].ToString();
                ddlReplacingCompany.SelectIndexByValue(RelatedID, false);
            }

            gvBeneficiariesCompany.Enabled = false;
            pnGvCompany.CssClass = "DisabledGrid grid_wrap margin_t_10";
            hdnIsEditCompany.Value = "true";
            hdnEditIndexCompany.Value = gridrow.RowIndex.ToString();
            btnBECompanyAdd.Text = Resources.Save;
        }

        protected void btnBECompanyFile_Click(object sender, EventArgs e)
        {
            if (hdnIsEditCompany.Value != "true")
            {
                var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

                //Obtener Informacion del Documento desde el Grid
                var ContactId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["ContactId"].ToString());
                var DocumentCategoryId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["DocumentCategoryId"].ToString());
                var DocumentTypeId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["DocumentTypeId"].ToString());
                var DocumentId = int.Parse(gvBeneficiariesCompany.DataKeys[gridRow.RowIndex]["DocumentId"].ToString());
                                  

                string documentType = "D";
                Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                {                                                                                   
                    Contact_ID = ContactId
                };
                byte[] pdfOnBase = ObjServices.ViewFileFromOnBase(add,documentType, DocumentCategoryId, DocumentTypeId);

                if (pdfOnBase == null)
                {
                    //Buscar Data del documento.
                    var beneficiaryDoc = ObjServices.oBeneficiaryManager.GetIdDocument(ContactId, DocumentCategoryId, DocumentTypeId, DocumentId);

                    //Buscar control del PDF Viewer y pasarle el documento a mostrar.
                    if (beneficiaryDoc.DocumentBinary != null)
                    {
                        ViewPDF(beneficiaryDoc.DocumentBinary);
                    }
                }
                else
                {
                    ViewPDF(pdfOnBase);
                }
            }
            else
                this.MessageBox("Documents cannot be previewed while in edition mode, please save info and try again.", Title: "Edition Mode");
        }
        #endregion

        #region Beneficiaries Events

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            var ContainerContingente = (!ObjServices.IsDataReviewMode) ?
                                     bodyContent.FindControl("BeneficiariesContainer").FindControl("WUCMainInsured").FindControl("WUCContingentBeneficiaries")
                                   : bodyContent.FindControl("DReviewContainer").FindControl("BeneficiariesContainer").FindControl("WUCMainInsured").FindControl("WUCContingentBeneficiaries");

            var ContainerPrincipal = (!ObjServices.IsDataReviewMode) ?
                                     bodyContent.FindControl("BeneficiariesContainer").FindControl("WUCMainInsured").FindControl("WUCMainBeneficiaries")
                                   : bodyContent.FindControl("DReviewContainer").FindControl("BeneficiariesContainer").FindControl("WUCMainInsured").FindControl("WUCMainBeneficiaries");


            int RoleTypeId = 0, 
                ContId = 0;
            var rIndex = int.Parse(hdnEditIndex.Value);

            if (IsEditPop)
            {
                ContId = HFContactId.Value.ToInt();
                RoleTypeId = HFContactRoleIDType.Value.ToInt();
            }
            else
            {
                if (gvBeneficiaries.Rows.Count > 0)
                {    
                    ContId = int.Parse(gvBeneficiaries.DataKeys[rIndex]["ContactId"].ToString());
                    RoleTypeId = int.Parse(gvBeneficiaries.DataKeys[rIndex]["ContactRoleTypeId"].ToString());
                }    
            }      

            //validar fecha de nacimiento
            string[] formats = { "M/d/yyyy" };
            DateTime FechaActual = DateTime.Today.Date;
            DateTime FechaSeleccionada;
            var DateofBirthPrincipal = (ContainerPrincipal.FindControl("txtBEDateofBirth") as TextBox).Text;
            var DateofBirthContingente = (ContainerContingente.FindControl("txtBEDateofBirth") as TextBox).Text;

            if ((DateTime.TryParseExact(DateofBirthPrincipal, formats, new CultureInfo("en-US"), DateTimeStyles.None, out FechaSeleccionada)) || (DateTime.TryParseExact(DateofBirthContingente, formats, new CultureInfo("en-US"), DateTimeStyles.None, out FechaSeleccionada)))
            {
                if (FechaSeleccionada > FechaActual)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Date of Birth" : "Texto Informativo";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.NeedToBeDateInPast;  //"La fecha de nacimiento no puede ser una fecha futura";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
                else if (FechaSeleccionada == FechaActual)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Date of Birth" : "Texto Informativo";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.NeedToBeDateInPast; //"La fecha de nacimiento es hoy.!!!";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }

            var ddlDocument = cbxIDType.SelectedValue;
            var txtDocument = txtIDNo.Text.Replace("-", "");
            if (ddlDocument != "-1")
            {
                if (string.IsNullOrEmpty(txtDocument))
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary ID" : "Texto Informativo";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.InvalidDocumentNumberEmpty; //"El ID del beneficiario insertado ya se encuentra registrado";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                var ValidationDocumentExistIDs = ValidationDocumentExistInBeneficiary(ContId, txtDocument);
                if (ValidationDocumentExistIDs)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary ID" : "Texto Informativo";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.InvalidDocumentNumber; //"El ID del beneficiario insertado ya se encuentra registrado";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }

            if (ddlDocument == "1" || ddlDocument == "3")
            {
                var ValidationID = ObjServices.ValidationCedulaValid(txtDocument);
                if (ValidationID.InvalidCedula)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Documento Invalido";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.InvalidDocumentNumber; //"El ID del Beneficiario no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }
            else if (ddlDocument == "5")
            {
                var ValidationRNC = ObjServices.ValidationRNCValid(txtDocument);
                if (ValidationRNC.InvalidRNC)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Documento Invalido";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.InvalidDocumentNumber; //"El RNC del Beneficiario no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }

            var BItem = new Entity.UnderWriting.Entities.Beneficiary();

            BItem.BeneficiaryTypeId = BeneficiaryTypeID; //Aqui va si el beneficiario es contigente o primario. --1 es Primario y 2 Contingente.
            BItem.PrimaryBeneficiary = IsInsured; //True si es del Insured, False si es del Additional.

            var FileName = TempFilePath + "\\" + hdnUploadedPDFPath.Text;

            Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
            {
                InsuredName = txtFirstName.Text + " " + txtMiddleName.Text + " " + txtLastName.Text + " " + txtSecondLastName.Text,
                Role_Type_ID = 4,
                identification = txtIDNo.Text,
                ContactIdType = ddlDocument.ToInt()
            };

            if (hdnIsEdit.Value == "true")
            {
               

                var ContactId = ContId;
                var ContactRoleTypeId = RoleTypeId;

                //Valido que este beneficiario no exista en el grid antes de agregarlo
                var Validation = ValidateCurrentBeneficiaries(false, ContactId, ContactRoleTypeId);
                if (Validation.Exists)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary" : "Beneficiario no válido";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryAlreadyExist;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, 'Invalid Beneficiary');");
                    return;
                }
                else if (Validation.IsSameId)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary ID" : "ID no válido del Beneficiario";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryIDAlreadyExist;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                int? SeqNo = null;
                if (gvBeneficiaries.DataKeys[rIndex]["SeqNo"] != null) //Esto quiere decir que el ID del contacto no existe en la tabla de contactto
                    SeqNo = int.Parse(gvBeneficiaries.DataKeys[rIndex]["SeqNo"].ToString());

                //Busco en el grid la suma de los porcentajes de los beneficiarios, para asegurarme de que el mismo nunca pase de 100%.
                if ((GetTotalPercentage(ContactId) + Decimal.Parse(txtPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture)) > 100)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryExceed;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true,'" + Title + "');");
                    return;
                }

                //Actualiza o Inserta el Documento del Beneficiario
                if (!String.IsNullOrEmpty(hdnUploadedPDFPath.Text))
                {
                     Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add2 = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                     {
                        InsuredName = txtFirstName.Text + " " + txtMiddleName.Text + " " + txtLastName.Text + " " + txtSecondLastName.Text,
                        Role_Type_ID = 4,
                        identification = txtIDNo.Text,
                        ContactIdType =  ddlDocument.ToInt()
                     };

                    if (gvBeneficiaries.DataKeys[rIndex]["DocumentId"] != null)
                    {
                        //Obtener Informacion del Documento desde el Grid
                        var DocumentCategoryId = int.Parse(gvBeneficiaries.DataKeys[rIndex]["DocumentCategoryId"].ToString());
                        var DocumentTypeId = int.Parse(gvBeneficiaries.DataKeys[rIndex]["DocumentTypeId"].ToString());
                        var DocumentId = int.Parse(gvBeneficiaries.DataKeys[rIndex]["DocumentId"].ToString());

                        //Actualizar Documento
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, DocumentId, Utility.ReadBinaryFile(FileName), 1);
                        SendFileToOnBase(Add2,DocumentCategoryId, DocumentTypeId, FileName);
                    }
                    else
                    {
                        //Insertar Documento
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, null, Utility.ReadBinaryFile(FileName), 1);
                        SendFileToOnBase(Add,25, 1, FileName);
                    }
                }

                //Seteo el Key del Item
                BItem.CorpId = this.ObjServices.Corp_Id;
                BItem.RegionId = this.ObjServices.Region_Id;
                BItem.CountryId = this.ObjServices.Country_Id;
                BItem.DomesticregId = this.ObjServices.Domesticreg_Id;
                BItem.StateProvId = this.ObjServices.State_Prov_Id;
                BItem.CityId = this.ObjServices.City_Id;
                BItem.OfficeId = this.ObjServices.Office_Id;
                BItem.CaseSeqNo = this.ObjServices.Case_Seq_No;
                BItem.HistSeqNo = this.ObjServices.Hist_Seq_No;
                BItem.ContactId = ContactId;

                BItem.ContactRoleTypeId = ContactRoleTypeId;

                BItem.ContactTypeId = Utility.ContactTypeId.Beneficiary.ToInt(); //Aqui el tipo de cliente 5 Compañia y  4 Beneficiario.
                BItem.FirstName = txtFirstName.Text;
                BItem.MiddleName = txtMiddleName.Text;
                BItem.FirstLastName = txtLastName.Text;
                BItem.SecondLastName = txtSecondLastName.Text;
                BItem.Dob = txtBEDateofBirth.Text.ParseFormat();
                BItem.BenefitsPercent = Decimal.Parse(txtPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture);
                BItem.ContactMainId = txtIDNo.Text;
                BItem.DocumentTypeId = int.Parse(ddlDocument);
                BItem.RelationshipToOwnerId = int.Parse(ddlRelationship.SelectedValue);
                BItem.PrimaryBeneficiaryId = BeneficiaryTypeID == 2 && ddlReplacing.SelectedIndex > 0 ? int.Parse(ddlReplacing.SelectedValue) : (int?)null;
                BItem.SeqNo = SeqNo;
                BItem.CreateUser = ObjServices.UserID.Value;

                ObjServices.oBeneficiaryManager.UpdatetBeneficiary(BItem);
            }
            else
            {
                var ContactRoleTypeId = 4;
                //Valido que este beneficiario no exista en el grid antes de agregarlo
                var Validation = ValidateCurrentBeneficiaries(false);
                if (Validation.Exists)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary" : "Beneficiario no válido";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryAlreadyExist;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
                else if (Validation.IsSameId)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Beneficiary ID" : "ID no válido del Beneficiario";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryIDAlreadyExist;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                //Busco en el grid la suma de los porcentajes de los beneficiarios, para asegurarme de que el mismo nunca pase de 100%.
                if ((GetTotalPercentage() + Decimal.Parse(txtPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture)) > 100)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                    string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryExceed;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }

                //Seteo el Key del Item
                BItem.CorpId = this.ObjServices.Corp_Id;
                BItem.RegionId = this.ObjServices.Region_Id;
                BItem.CountryId = this.ObjServices.Country_Id;
                BItem.DomesticregId = this.ObjServices.Domesticreg_Id;
                BItem.StateProvId = this.ObjServices.State_Prov_Id;
                BItem.CityId = this.ObjServices.City_Id;
                BItem.OfficeId = this.ObjServices.Office_Id;
                BItem.CaseSeqNo = this.ObjServices.Case_Seq_No;
                BItem.HistSeqNo = this.ObjServices.Hist_Seq_No;
                BItem.ContactRoleTypeId = ContactRoleTypeId;

                BItem.ContactTypeId = Utility.ContactTypeId.Beneficiary.ToInt(); //Aqui el tipo de cliente 5 Compañia y  4 beneficiario.
                BItem.FirstName = txtFirstName.Text;
                BItem.MiddleName = txtMiddleName.Text;
                BItem.FirstLastName = txtLastName.Text;
                BItem.SecondLastName = txtSecondLastName.Text;
                BItem.Dob = txtBEDateofBirth.Text.ParseFormat();
                BItem.BenefitsPercent = Decimal.Parse(txtPercentage.Text.Replace(",", ""), CultureInfo.InvariantCulture);
                BItem.ContactMainId = txtIDNo.Text;
                BItem.DocumentTypeId = int.Parse(ddlDocument);
                BItem.RelationshipToOwnerId = int.Parse(ddlRelationship.SelectedValue);
                BItem.PrimaryBeneficiaryId = BeneficiaryTypeID == 2 && ddlReplacing.SelectedIndex > 0 ? int.Parse(ddlReplacing.SelectedValue) : (int?)null;
                BItem.IssuedBy = "-";
                BItem.CreateUser = ObjServices.UserID.Value;
                BItem.DocumentBinary = String.IsNullOrEmpty(hdnUploadedPDFPath.Text) ? null : Utility.ReadBinaryFile(FileName);

                ObjServices.oBeneficiaryManager.InsertBeneficiary(BItem);

           

                SendFileToOnBase(Add,25, 1, FileName);
            }

            btnAdd.Text = Resources.Add.Capitalize();
            //Limpio los Campos y refresco la Data de los Grids
            ClearFields(false);
            FillData(false);
        }

        public void SendFileToOnBase(Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add,int catid, int typeid, string pdfpath)
        {
            try
            {
                string TemplateIndexFile = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LifeOnBaseTemplatePath"]);
                string documentType = "D";

                ObjServices.SendFileToOnBase(Add,TemplateIndexFile,
                                             documentType,
                                             catid,
                                             typeid,
                                             pdfpath);
            }
            catch (Exception ex)
            {
                ObjServices.oPolicyManager.InsertLog(new Entity.UnderWriting.Entities.Policy.LogParameter
                {
                    LogTypeId = WEB.NewBusiness.Common.Utility.LogTypeId.Exception.ToInt(),
                    CorpId = ObjServices.Corp_Id,
                    CompanyId = ObjServices.CompanyId,
                    ProjectId = ObjServices.ProjectId,
                    Identifier = Guid.NewGuid(),
                    LogValue = "Se encontro un problema con el proceso OnBaseTranfer Beneficiary, Detalle: " + ex.Message.ToString()
                });
            }
        }

        protected void btnBEClear_Click(object sender, EventArgs e)
        {
            ClearFields(false);
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

            if (hdnIsEdit.Value != "true")
            {
                //Obtener Informacion del Documento desde el Grid
                var ContactId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["ContactId"].ToString());
                var DocumentCategoryId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["DocumentCategoryId"].ToString());
                var DocumentTypeId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["DocumentTypeId"].ToString());
                var DocumentId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["DocumentId"].ToString());

                string documentType = "D";
                Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                { 
                    Contact_ID = ContactId
                };
                byte[] pdfOnBase = ObjServices.ViewFileFromOnBase(add, documentType, DocumentCategoryId, DocumentTypeId);

                if (pdfOnBase == null)
                {
                    //Buscar Data del documento.
                    var beneficiaryDoc = ObjServices.oBeneficiaryManager.GetIdDocument(ContactId, DocumentCategoryId, DocumentTypeId, DocumentId);

                    //Buscar control del PDF Viewer y pasarle el documento a mostrar.
                    if (beneficiaryDoc.DocumentBinary != null)
                    {
                        ViewPDF(beneficiaryDoc.DocumentBinary);
                    }
                }
                else
                {
                    ViewPDF(pdfOnBase);
                }
            }
            else
                this.MessageBox("Documents cannot be previewed while in edition mode, please save info and try again.", Title: "Edition Mode");
        }

        public void ViewPDF(byte[] PdfFile)
        {
            var UCShowPDFPopup1 = (NewBusiness.UserControls.Common.WUCShowPDFPopup)this.Page.Master.FindControl("WUCShowPDFPopup1");
            var HiddenShowPdF = (HiddenField)this.Page.Master.FindControl("hdnShowBeneficiariePDF");
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("ModalPopupPDFViewer");
            //var PdfTitle = (Literal)UCShowPDFPopup1.FindControl("ltTypeDoc");

            if (UCShowPDFPopup1 != null && HiddenShowPdF != null && ModalPopUp != null)
            {
                UCShowPDFPopup1.LoadPDFPreview(PdfFile);
                //PdfTitle.Text = "View Documents";
                ModalPopUp.Show();
                this.ExcecuteJScript("$('#pnModalPopupPDFViewer').find('div:first').prepend(CreateNewPopFrame());");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

            txtFirstName.Text = gvBeneficiaries.DataKeys[gridRow.RowIndex]["FirstName"].ToString();
            txtMiddleName.Text = gvBeneficiaries.DataKeys[gridRow.RowIndex]["MiddleName"].ToString();
            txtLastName.Text = gvBeneficiaries.DataKeys[gridRow.RowIndex]["FirstLastName"].ToString();
            txtSecondLastName.Text = gvBeneficiaries.DataKeys[gridRow.RowIndex]["SecondLastName"].ToString();
            txtBEDateofBirth.Text = ((Label)gridRow.FindControl("lblDob")).Text;
            var contactIdType = gvBeneficiaries.DataKeys[gridRow.RowIndex]["ContactIdType"] != null ? gvBeneficiaries.DataKeys[gridRow.RowIndex]["ContactIdType"].ToString() : string.Empty;
            if (!contactIdType.SIsNullOrEmpty())
            {
                this.cbxIDType.SelectedValue = contactIdType;
            }
            var labelPercent = ((Label)gridRow.FindControl("lblBenefitsPercent")).Text;

            txtPercentage.Text = String.IsNullOrEmpty(labelPercent) ? "0" :
                 labelPercent.Replace("%", "");

            txtIDNo.Text = ((Label)gridRow.FindControl("lblContactID")).Text;

            var RelationshipID = gvBeneficiaries.DataKeys[gridRow.RowIndex]["RelationshipToOwnerId"].ToString();
            ddlRelationship.SelectIndexByValue(RelationshipID, false);

            if (hdnBeneficiarieType.Value == "2" || hdnBeneficiarieType.Value == "4")
            {
                var RelatedID = gvBeneficiaries.DataKeys[gridRow.RowIndex]["PrimaryBeneficiaryId"] == null ? "0" : gvBeneficiaries.DataKeys[gridRow.RowIndex]["PrimaryBeneficiaryId"].ToString();
                ddlReplacing.SelectIndexByValue(RelatedID, false);
            }

            gvBeneficiaries.Enabled = false;
            pnGvBeneficiaries.CssClass = "DisabledGrid grid_wrap margin_t_10 mB";
            hdnIsEdit.Value = "true";
            hdnEditIndex.Value = gridRow.RowIndex.ToString();
            btnAdd.Text = Resources.Save;
            IsEditPop = false;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var ContactId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["ContactId"].ToString());
            var ContactRoleTypeId = int.Parse(gvBeneficiaries.DataKeys[gridRow.RowIndex]["ContactRoleTypeId"].ToString());

            //Obtener Key desde la Session
            var CorpId = this.ObjServices.Corp_Id;
            var RegionId = this.ObjServices.Region_Id;
            var CountryId = this.ObjServices.Country_Id;
            var DomesticregId = this.ObjServices.Domesticreg_Id;
            var StateProvId = this.ObjServices.State_Prov_Id;
            var CityId = this.ObjServices.City_Id;
            var OfficeId = this.ObjServices.Office_Id;
            var CaseSeqNo = this.ObjServices.Case_Seq_No;
            var HistSeqNo = this.ObjServices.Hist_Seq_No;

            ObjServices.oBeneficiaryManager.DeleteBeneficiary(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo, ContactId, ContactRoleTypeId);
            FillData(false);
        }

        #endregion

        protected void fuBenediciarieFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            var message = string.Empty;

            try
            {
                var file = e.UploadedFile;

                if (file.IsValid)
                {
                    var fileName = Utility.GetSerialId() + "~~" + file.FileName;
                    var savePath = TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);

                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", fileName, "");
                }
                else
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
            }
            catch (Exception ex)
            {
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }

            e.CallbackData = message;
        }

        public bool saveBeneficiaries()
        {
            if (gvBeneficiariesCompany.Rows.Count > 0 || gvBeneficiaries.Rows.Count > 0)
            {
                //Busco en el grid la suma de los porcentajes de los beneficiarios, para asegurarme de que el mismo sea de 100%.
                var totalBenefPercentage = GetTotalPercentage();
                if (totalBenefPercentage != 100)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                    string message = string.Empty;
                    if (totalBenefPercentage > 100)
                        message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryExceed;
                    else
                        message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryLessThan100;
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return false;
                }

                ObjServices.oBeneficiaryManager.UpdateComment(
                ObjServices.Corp_Id
                , ObjServices.Region_Id
                , ObjServices.Country_Id
                , ObjServices.Domesticreg_Id
                , ObjServices.State_Prov_Id
                , ObjServices.City_Id
                , ObjServices.Office_Id
                , ObjServices.Case_Seq_No
                , ObjServices.Hist_Seq_No
                , IsInsured
                , BeneficiaryTypeID
                , txtSpecialInstructions.Text
                , ObjServices.UserID.Value);
            }
            else
            {
                string message = RESOURCE.UnderWriting.NewBussiness.Resources.BeneficiaryEachCategory;
                var Title = ObjServices.Language == Utility.Language.en ? "Wrong Percentage" : "Porcentaje incorrecto";
                this.MessageBox(message, 500, 150, true, Title);
                this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                return false;
            }

            return true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            switch (hdnBeneficiarieType.Value)
            {
                case "2":
                    IsInsured = true;
                    BeneficiaryTypeID = 2;
                    lblBeTitle.Text = Resources.ContingentBeneficiaries;
                    break;
                case "3":
                    IsInsured = false;
                    BeneficiaryTypeID = 1;
                    lblBeTitle.Text = Resources.MainBenficiariesLabel;
                    break;
                case "4":
                    IsInsured = false;
                    BeneficiaryTypeID = 2;
                    lblBeTitle.Text = Resources.ContingentBeneficiaries;
                    break;
                default:
                    IsInsured = true;
                    BeneficiaryTypeID = 1;
                    lblBeTitle.Text = Resources.MainBenficiariesLabel;
                    break;
            }

            FirstName.InnerHtml = Resources.FirstNameLabel;
            MiddleName.InnerHtml = Resources.MiddleNameLabel;
            SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
            LastName.InnerHtml = Resources.LastNameLabel;
            DateOftBirth.InnerHtml = Resources.DateofBirthLabel;
            Relationship.InnerHtml = Resources.RelationshipLabel;
            Percentage.InnerHtml = Resources.PercentageLabel;
            Percentage2.InnerHtml = Percentage.InnerHtml;
            ID.InnerHtml = "ID#";
            Document.InnerHtml = Resources.DocumentLabel;
            Document2.InnerHtml = Document.InnerHtml;

            btnBEClear.Text = Resources.Clear;
            btnBECompanyClear.Text = btnBEClear.Text;

            btnAdd.Text = Resources.Add;

            btnBECompanyAdd.Text = btnAdd.Text;

            fuBenediciarieFile.BrowseButton.Text = Resources.UPLOADID.Capitalize(' ');
            fuBenediciarieFileCompany.BrowseButton.Text = fuBenediciarieFile.BrowseButton.Text;

            Replacing.InnerHtml = Resources.ReplacingLabel;
            Replacing2.InnerHtml = Replacing.InnerHtml;

            SpecialInstructions.InnerHtml = Resources.SPECIALINSTRUCTIONS;

            EntityName.InnerHtml = Resources.EntityName;
            IncorpotarionDate.InnerHtml = Resources.IncorporationDate;
            Type.InnerHtml = Resources.TypeLabel;

            btnSearch.Text = Resources.SearchContact;
            btnSearchCompany.Text = Resources.SearchContact;
        }

        public void Initialize()
        {
            hdnIsEdit.Value = "false";
            hdnEditIndex.Value = "0";
            hdnUploadedPDFPath.Text = "";

            hdnIsEditCompany.Value = "false";
            hdnEditIndexCompany.Value = "0";
            hdnUploadedPDFPathCompany.Text = "";

            IsInsured = false;
            BeneficiaryTypeID = -1;
        }

        protected void Translate_PreRender(object sender, EventArgs e)
        {
            ((GridView)sender).TranslateColumnsGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var btnCompany = (Button)sender;

            bool IsMaimOrAdd = true;
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            (bodyContent.FindControl("hdnShowPopClientInfoSearch") as HiddenField).Value = "true";
            var WUCSearchClientOrOwner = bodyContent.FindControl("popSearchClientOrOwner").FindControl("WUCSearchClientOrOwner");


            var tab = !ObjServices.IsDataReviewMode ? (bodyContent.FindControl("BeneficiariesContainer").FindControl("hfMenuAccordeonBeneficiaries") as HiddenField).Value :
                                                    (bodyContent.FindControl("DReviewContainer").FindControl("BeneficiariesContainer").FindControl("hfMenuAccordeonBeneficiaries") as HiddenField).Value;

            if (tab != "")
            {
                var valor = tab.Split('|')[1];
                IsMaimOrAdd = valor == "0" ? true : false;
            }

            if (btnCompany.ID == "btnSearchCompany")
                hdnIsCompany.Value = "true";
            else
                hdnIsCompany.Value = "false";

            if (WUCSearchClientOrOwner != null)
            {
                var oWUCSearchClientOrOwner = (NewBusiness.UserControls.AddNewClient.Common.WUCSearchClientOrOwner)WUCSearchClientOrOwner;
                oWUCSearchClientOrOwner.ContactTypeID = hdnIsCompany.Value == "true" ? Utility.ContactTypeId.Company.ToInt() : Utility.ContactTypeId.Contact.ToInt();
                oWUCSearchClientOrOwner.Initialize();
                oWUCSearchClientOrOwner.IsConting = BeneficiaryTypeID == 2 ? true : false;
                oWUCSearchClientOrOwner.IsMain = IsMaimOrAdd;
                var udpAddNewClient = bodyContent.FindControl("udpAddNewClient");
                if (udpAddNewClient != null)
                    (udpAddNewClient as UpdatePanel).Update();
            }
        }

        public void createBeneficiarie(int contactId)
        {
            var objdata = ObjServices.validateExistBeneficiarie(contactId);

            if (objdata)
            {
                this.MessageBox(Resources.SelectBeneficiariesValidationMessage);
                return;
            }

            var DataContactBeneficiary = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, contactId, ObjServices.Language.ToInt());
            var objId = ObjServices.oContactManager.GetAllIdDocumentInformation(contactId, ObjServices.Language.ToInt()).LastOrDefault((i => i.ContactIdType == 4/*Beneficiary Document*/));


            if (hdnIsCompany.Value == "true")
            {
                ObjServices.ContactEntityID = contactId;
                var IdDataItem = ObjServices.GetAllIdDocumentInformation().LastOrDefault(x => x.ContactIdType == 5);

                txtEntityName.Text = DataContactBeneficiary.InstitutionalName;
                txtBEIncorporationDate.Text = DataContactBeneficiary.Dob.ToString();
                txtEntityPercentage.Text = "0";
                txtEntityIDNo.Text = IdDataItem != null ? IdDataItem.Id : string.Empty;

            }
            else
            {

                txtFirstName.Text = DataContactBeneficiary.FirstName;
                txtMiddleName.Text = DataContactBeneficiary.MiddleName;
                txtLastName.Text = DataContactBeneficiary.FirstLastName;
                txtSecondLastName.Text = DataContactBeneficiary.SecondLastName;
                txtBEDateofBirth.Text = DataContactBeneficiary.Dob.HasValue ? DataContactBeneficiary.Dob.ToString() : "";
                txtPercentage.Text = "0";

                txtIDNo.Text = objId != null ? objId.Id : string.Empty;

                var RelationshipID = DataContactBeneficiary.RelationshiptoOwner.ToString();
                ddlRelationship.SelectIndexByValue(RelationshipID, false);

            }

        }

        private bool ValidationDocumentExistInBeneficiary(int contact_id, string IdNumber)
        {
            var ExistsItem = false;
            var data3 = ObjServices.oContactManager.GetAllDocumentIDs(IdNumber);
            var txtDocument = txtIDNo.Text.Replace("-", "");
            var search = data3.Where(x => x.IDs.IsNullOrEmptyReturnValue(null) == txtDocument && x.Contact_id != contact_id);
            foreach (var item in search)
            {
                if (item.IDs.Trim() == txtDocument)
                {
                    ExistsItem = true;
                }
                else
                {
                    ExistsItem = false;
                }
            }
            return ExistsItem;
        }
    }
}