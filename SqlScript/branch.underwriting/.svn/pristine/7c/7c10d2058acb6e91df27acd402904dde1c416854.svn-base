using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls
{
    public partial class WUCIdentification : UC, IUC
    {
        protected void UpdatePanel_Unload(object sender, EventArgs e)
        {
            try
            {
                MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                   .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();
                methodInfo.Invoke(ScriptManager.GetCurrent(Page),
                    new object[] { sender as UpdatePanel });
            }
            catch (Exception ex)
            {

            }

        }

        #region TempData
        public List<Entity.UnderWriting.Entities.Contact.IdDocument> TempDataContactIdentifications = new List<Entity.UnderWriting.Entities.Contact.IdDocument>();
        #endregion
        		
        public class ValidationDocumentExist
        {
            public Boolean Exists { get; set; }
        }

        public String PrefixSession
        {
            get { return hdnCurrentSession.Value; }
            set { hdnCurrentSession.Value = value; }
        }

        public int? RowIndex
        {
            get { return int.Parse(Session[PrefixSession + "_RowIndexIdentifications"].ToString()); }
            set { Session[PrefixSession + "_RowIndexIdentifications"] = value; }
        }

        public Utility.OperationType Operation
        {
            get { return ((Utility.OperationType)Session[PrefixSession + "_OperationIdentificationsContact"]); }
            set
            {
                Session[PrefixSession + "_OperationIdentificationsContact"] = value;
                gvCommonIdentification.Enabled = (Operation == Utility.OperationType.Insert);
            }
        }

        public List<Entity.UnderWriting.Entities.Contact.IdDocument> oTemDataIdentifications
        {
            get
            {
                return Session[PrefixSession + "_TemDataIdentificationsContact"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact.IdDocument>() :
                    Session[PrefixSession + "_TemDataIdentificationsContact"] as List<Entity.UnderWriting.Entities.Contact.IdDocument>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.IdDocument> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.IdDocument>(Session[PrefixSession + "_TemDataIdentificationsContact"] != null ?
                      ((List<Entity.UnderWriting.Entities.Contact.IdDocument>)Session[PrefixSession + "_TemDataIdentificationsContact"]) :
                      new List<Entity.UnderWriting.Entities.Contact.IdDocument>());
                    tempList.AddRange(value);
                }

                Session[PrefixSession + "_TemDataIdentificationsContact"] = tempList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Operation = Utility.OperationType.Insert;
                gvCommonIdentification.FocusedRowIndex = -1;
            }

            udpIdentification.Update();
        }

        private ValidationDocumentExist ValidationDocumentExistInBeneficiary(string IdNumber)
        {
            var ExistsItem = new ValidationDocumentExist { Exists = false };
            var data3 = ObjServices.oContactManager.GetAllDocumentIDs(IdNumber);
            var txtDocument = txtIDNumber.Text.Replace("-", "");
            var search = data3.Where(x => x.IDs.IsNullOrEmptyReturnValue(null) == txtDocument);
            foreach (var item in search)
            {
                if (item.IDs.Trim() == txtDocument)
                {
                    ExistsItem.Exists = true;
                }
                else
                {
                    ExistsItem.Exists = false;
                }
            }
            return ExistsItem;
        }


        public void LoadSameDataFromInsured(int? ContactID)
        {
            if (!ObjServices.isNewCase)
            {
                oTemDataIdentifications = null;
                oTemDataIdentifications = ObjServices.oContactManager.GetAllIdDocumentInformation(ContactID.Value, ObjServices.Language.ToInt()).ToList();
            }

            var data = (from source in oTemDataIdentifications
                        select new
                        {
                            source.SeqNo,
                            source.Id,
                            ExpireDate = string.Format("{0:MM/dd/yyyy}", source.ExpireDate),
                            source.DocumentTypeId,
                            source.ContactIdType,
                            source.ContactIdTypeDescription,
                            source.DocumentTypeDescription,
                            source.IssuedBy,
                            source.CountryIssuedByDesc
                        }).ToList();

            hdnTotalIdentification.Value = data.Count().ToString();
            gvCommonIdentification.DataSource = data;
            gvCommonIdentification.DataBind();
            gvCommonIdentification.FocusedRowIndex = -1;


            udpIdentification.Update();

        }

        public void FillData()
        {
            /*
             1.- Si no es un nuevo caso 
             2.- Si el contactid es igual a -1             
            */
            if (ObjServices.ContactEntityID > 0)
            {
                oTemDataIdentifications = null;
                oTemDataIdentifications = ObjServices.GetAllIdDocumentInformation();
            }

            var data = (from source in oTemDataIdentifications
                        select new
                        {
                            source.SeqNo,
                            source.Id,
                            ExpireDate = string.Format("{0:MM/dd/yyyy}", source.ExpireDate),
                            source.DocumentTypeId,
                            source.ContactIdType,
                            source.ContactIdTypeDescription,
                            source.DocumentTypeDescription,
                            source.IssuedBy,
                            source.CountryIssuedByDesc
                        }).ToList();

            if (!ObjServices.isNewCase)
            {
                if (!data.Any())
                {
                    if (currentTab == "ClientInfo" || currentTab == "OwnerInfo")
                    {
                        Utility.Tab Tab = (currentTab == "ClientInfo") ? Utility.Tab.ClientInfo : Utility.Tab.OwnerInfo;
                        ObjServices.saveSetValidTab(Tab, false);
                    }
                }
            }

            hdnTotalIdentification.Value = data.Count().ToString();

            gvCommonIdentification.DataSource = data;
            gvCommonIdentification.DataBind();
            gvCommonIdentification.Selection.UnselectAll();
            udpIdentification.Update();

        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltIdentifications.Text = Resources.IdentificationsLabel;
            IDType.InnerHtml = Resources.IDTypeLabel;
            IDNumber.InnerHtml = Resources.IDNumberLabel;
            ExpDate.InnerHtml = Resources.ExpirationDateLabel;
            btnAddIdentification.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;
            IssuedBy.InnerText = Resources.IssuedByLabel;
            gvCommonIdentification.Columns[0].Caption = Resources.TypeLabel.ToUpper();
            gvCommonIdentification.Columns[1].Caption = Resources.IDNumberLabel.ToUpper();
            gvCommonIdentification.Columns[2].Caption = Resources.ExpirationDateLabel.ToUpper();
            gvCommonIdentification.Columns[3].Caption = Resources.IssuedByLabel.ToUpper();
            gvCommonIdentification.Columns[4].Caption = Resources.Edit.ToUpper();
            gvCommonIdentification.Columns[5].Caption = Resources.DeleteLabel.ToUpper();
            if (isChangingLang)
            {
                FillDrop();

                if (ObjServices.ContactEntityID < 0)
                    oTemDataIdentifications.ForEach(x => x.ContactIdTypeDescription = cbxIDType.Items.FindByValue(x.ContactIdType.ToString()).Text);

                FillData();
            }
        }

        
        public void save()
        {
            Entity.UnderWriting.Entities.Contact.IdDocument item = null;

            var ddlDocument = cbxIDType.SelectedValue;
            var txtDocument = txtIDNumber.Text.Replace("-", "");
            
            //validar fecha de vigencia de documentos
            DateTime FechaActual = DateTime.Today.Date;
            DateTime FechaSeleccionada;

            var typeDoc = cbxIDType.SelectedValue;

            if (DateTime.TryParse(txtExpDate.Text, out FechaSeleccionada))
            {
                if ((typeDoc == "1") || (typeDoc == "2") || (typeDoc == "8")) { 
                if (FechaSeleccionada < FechaActual) {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Texto Informativo";
                    string message = "La fecha de vigencia del documento se encuentra expirada.!!!";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                    }
                else if (FechaSeleccionada == FechaActual)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Texto Informativo";
                    string message = "El documento expira el dia de hoy.!!!";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    }
                }
                else if ((typeDoc == "5") || (typeDoc == "6") || (typeDoc == "7"))
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Texto Informativo";
                    string message = "La fecha de vencimiento no aplica para este documento.!!!";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }
          
            //Validando el Cedula y  RNC
            if (ddlDocument == "1") {
                var ValidationCedula = ObjServices.ValidationCedulaValid(txtDocument);
                if (ValidationCedula.InvalidCedula)
                {
                    var msj = "El Cedula {0} no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, txtIDNumber.Text) + "\"',null, null, true, 'Documento Invalido')");
                    return;
                }
            }
            else if (ddlDocument == "7"){
                var ValidationRNC= ObjServices.ValidationRNCValid(txtDocument);
                if (ValidationRNC.InvalidRNC)
                {
                    var msj = "El RNC {0} no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, txtIDNumber.Text) + "\"',null, null, true, 'Warning')");
                    return;
                }
            }

            var record = new Entity.UnderWriting.Entities.Contact.IdDocument();

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataIdentifications.ElementAt(RowIndex.Value);

            if (cbxIDType.SelectedValue != "-1" &&
               cbxIssuedBy.SelectedValue != "-1" &&
               !txtIDNumber.isEmpty())
            {
                //Agregar un item
                item = new Entity.UnderWriting.Entities.Contact.IdDocument()
                {
                    //Key
                    ContactId = ObjServices.ContactEntityID.Value,
                    SeqNo = (Operation == Utility.OperationType.Edit) ? record.SeqNo : -1,
                    //Campos 
                    ContactIdType = !string.IsNullOrEmpty(cbxIDType.SelectedValue) ? int.Parse(cbxIDType.SelectedValue) : int.Parse("0"),
                    ContactIdTypeDescription = cbxIDType.SelectedItem.Text,
                    Id = txtIDNumber.Text,
                    ExpireDate = !string.IsNullOrEmpty(txtExpDate.Text) ? txtExpDate.Text.ParseFormat() : (DateTime?)null,
                    IssuedBy = null,
                    MainIdentity = true,
                    CountryIssuedBy = int.Parse(cbxIssuedBy.SelectedValue),
                    CountryIssuedByDesc = cbxIssuedBy.SelectedItem.Text,
                    //Información Usuario
                    UserId = ObjServices.UserID.Value
                };

                //Si es un nuevo caso  guardar en lista temporal
                if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.ContactEntityID < 0)
                {
                    if (Operation == Utility.OperationType.Insert)
                    {
                        //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El Cedula no se repita a nivel de Pais y tipo de documento
                        if (item.ContactIdType == 1 || item.ContactIdType == 7 ) //Esta validacion solo fue solicitada para el Cedula y el RNC
                        {
                            //El truco esta en  enviarle el -1 como contactID
                            if (ObjServices.oContactManager.CheckIdDocument(0, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                            {
                                this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                return;
                            }
                            /**********************************************/
                            else
                            {
                                //Validando el Cedula y  RNC
                                if (ddlDocument != "-1")
                                {
                                    if ((ddlDocument == "1") || (ddlDocument == "7"))
                                    {
                                        var ValidationDocumentExistIDs = ValidationDocumentExistInBeneficiary(txtDocument);
                                        if (ValidationDocumentExistIDs.Exists)
                                        {
                                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        if (oTemDataIdentifications.RecordExistInList(x => x.Id == item.Id && x.CountryIssuedBy == item.CountryIssuedBy && x.ContactIdType == item.ContactIdType))
                        {
                            var msj = "El documento {0} ya se encuentra adicionado a la lista";
                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, item.Id) + "\"',null, null, true, 'Warning')");
                            return;
                        }

                        TempDataContactIdentifications.Add(item);
                    }
                    else if (Operation == Utility.OperationType.Edit)
                    {
                        //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El Cedula no se repita a nivel de Pais y tipo de documento
                        if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el Cedula y el RNC
                        {
                            //El truco esta en  enviarle el -1 como contactID
                            if (ObjServices.oContactManager.CheckIdDocument(0, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                            {
                                this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                return;
                            }
                            /**********************************************/
                            else
                            {
                                //Validando el Cedula y  RNC
                                if (ddlDocument != "-1")
                                {
                                    if ((ddlDocument == "1") || (ddlDocument == "7"))
                                    {
                                        var ValidationDocumentExistIDs = ValidationDocumentExistInBeneficiary(txtDocument);
                                        if (ValidationDocumentExistIDs.Exists)
                                        {
                                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        List<Entity.UnderWriting.Entities.Contact.IdDocument> oTemDataIdentificationsEdit;
                        oTemDataIdentificationsEdit = new List<Entity.UnderWriting.Entities.Contact.IdDocument>(oTemDataIdentifications);
                        oTemDataIdentificationsEdit.RemoveAt(RowIndex.Value);

                        if (oTemDataIdentificationsEdit.RecordExistInList(x => x.Id == item.Id && x.CountryIssuedBy == item.CountryIssuedBy && x.ContactIdType == item.ContactIdType))
                        {
                            var msj = "El documento {0} ya se encuentra adicionado a la lista";
                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, item.Id) + "\"',null, null, true, 'Warning')");
                            return;
                        }

                        edit();
                    }

                    oTemDataIdentifications = TempDataContactIdentifications;
                }
                else
                {   //Guardar directamente en la base de datos tanto si es un insert como un edit
                    if (Operation == Utility.OperationType.Insert || Operation == Utility.OperationType.Edit)
                    {
                       if (Operation == Utility.OperationType.Edit)
                        {
                            if (ViewState["idNumber"].ToString() != item.Id || ViewState["DocType"].ToString() != item.ContactIdType.ToString() || ViewState["IssuedBy"].ToString() != item.CountryIssuedBy.ToString())
                            {
                                //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El Cedula no se repita a nivel de Pais y tipo de documento
                                if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el Cedula   y el RNC
                                {
                                    //El truco esta en  enviarle el -1 como contactID
                                    if (ObjServices.oContactManager.CheckIdDocument(-1, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                                    {
                                       this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                        return;
                                    }
                                    /**********************************************/
                                    else { 
                                    //Validando el Cedula y  RNC
                                    if (ddlDocument != "-1")
                                    {
                                        if ((ddlDocument == "1") || (ddlDocument == "7")) { 
                                        var ValidationDocumentExistIDs = ValidationDocumentExistInBeneficiary(txtDocument);
                                        if (ValidationDocumentExistIDs.Exists)
                                        {
                                        this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                        return;
                                      }
                                        }
                                    }
                                    }
                                }

                                if (ObjServices.oContactManager.CheckIdDocument(ObjServices.ContactEntityID.Value, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                                {
                                    var msj = "El documento {0} ya se encuentra adicionado a la lista";
                                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, item.Id) + "\"',null, null, true, 'Warning')");
                                    return;
                                }
                                ObjServices.SetIdentificationsContact(item);
                            }
                            else if (!string.IsNullOrEmpty(txtExpDate.Text))
                                ObjServices.SetIdentificationsContact(item);
                        }
                        
                        //Limpiar Grid
                        if (Operation == Utility.OperationType.Insert)
                        {

                            //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El Cedula no se repita a nivel de Pais y tipo de documento
                            if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el Cedula  y el RNC
                            {
                                //El truco esta en  enviarle el -1 como contactID
                                if (ObjServices.oContactManager.CheckIdDocument(-1, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                                {
                                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                     return;
                                }
                                /**********************************************/
                                else
                                {
                                    //Validando el Cedula y  RNC
                                    if (ddlDocument != "-1")
                                    {
                                        if ((ddlDocument == "1") || (ddlDocument == "7"))
                                        {
                                            var ValidationDocumentExistIDs = ValidationDocumentExistInBeneficiary(txtDocument);
                                            if (ValidationDocumentExistIDs.Exists)
                                            {
                                                this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.MsjCedulaAlreadyExists, item.Id) + "\"',null, null, true, 'Warning')");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            //Fin Cambios Bmarroquin 04/02/2017
                            if (ObjServices.oContactManager.CheckIdDocument(ObjServices.ContactEntityID.Value, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                            {
                                this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.DocumentIDAlreadyExist, item.Id) + "\"',null, null, true, 'Warning')");
                                return;
                            }
                            else
                            {
                                ObjServices.SetIdentificationsContact(item);

                            }

                            if (ObjServices.ContactServicesIsActive)
                            {
                                //Invocar el metodo del webservice para guardar en illusdata
                                ObjServices.oContactServicesClient.SetContactIdentification(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()),
                                                                                           contactId: Utility.Encrypt(ObjServices.ContactEntityID.ToString())
                                                                                           );
                            }

                            //Ir a la ultima pagina
                            gvCommonIdentification.PageIndex = (gvCommonIdentification.PageCount - 1);
                        }

                        oTemDataIdentifications = null;
                    }

                }
            }
            else if (Operation == Utility.OperationType.InsertAll)
            {
                foreach (var vitem in oTemDataIdentifications)
                    vitem.ContactId = ObjServices.ContactEntityID.Value;

                ObjServices.SetIdentificationsContact(oTemDataIdentifications);
            }

            btnAddIdentification.Text = "Add";
            //Bindear el grid
            FillData();

            //Limpiar los controles a excepcion del grid
            ClearControls(gvCommonIdentification);

            Operation = Utility.OperationType.Insert;
        }

        public void edit()
        {
            var record = oTemDataIdentifications.ElementAt(RowIndex.Value);
            record.ContactIdType = int.Parse(cbxIDType.SelectedValue);
            record.ContactIdTypeDescription = cbxIDType.SelectedItem.Text;
            record.CountryIssuedBy = cbxIssuedBy.ToInt();
            record.CountryIssuedByDesc = cbxIssuedBy.SelectedItem.Text;
            record.Id = txtIDNumber.Text;
            record.ExpireDate = txtExpDate.Text.ParseFormat();
        }

        public void FillDrop()
        {
            ObjServices.GettingAllDrops(ref cbxIDType,
                                    Utility.DropDownType.IdType,
                                    "ContactTypeIdDesc",
                                    "ContactTypeId",
                                    GenerateItemSelect: true,
                                    corpId: ObjServices.Corp_Id);

            ObjServices.GettingAllDrops(ref cbxIssuedBy,
                                    Utility.DropDownType.IssuedBy,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true,
                                    corpId: ObjServices.Corp_Id);
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.IdDocument item)
        {
            cbxIDType.SelectedValue = item.ContactIdType.ToString();
            txtIDNumber.Text = item.Id;
            ViewState["idNumber"] = txtIDNumber.Text;
            ViewState["DocType"] = item.ContactIdType.ToString();
            ViewState["IssuedBy"] = (item.CountryIssuedBy == 0) ? "-1" : item.CountryIssuedBy.ToString();
            txtExpDate.Text = item.ExpireDate.HasValue ? item.ExpireDate.Value.ToString("MM/dd/yyyy") : string.Empty;
            ViewState["txtExpDate"] = txtExpDate.Text;
            cbxIssuedBy.SelectIndexByValue((item.CountryIssuedBy == 0) ? "-1" : item.CountryIssuedBy.ToString());
            isBirthCertificate.Value = cbxIDType.SelectedValue == "6" ? "true" : "false";
        }

        public void EnabledControls(bool x)
        {
            EnabledControls(frmIdentifications.Controls, x);
        }

        public void Initialize(String value = "")
        {
            ClearData();
            hdnCurrentSession.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            gvCommonIdentification.PageIndex = 0;
            oTemDataIdentifications = new List<Entity.UnderWriting.Entities.Contact.IdDocument>();
            Operation = Utility.OperationType.Insert;
            FillDrop();
            FillData();

            if (ObjServices.IsDataReviewMode)
                EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        protected void btnAddIdentification_Click(object sender, EventArgs e)
        {
            save();
        }

        public void ClearData()
        {
            Session[PrefixSession + "_OperationIdentificationsContact"] = null;
            ViewState["idNumber"] = null;
            ViewState["DocType"] = null;
            ViewState["IssuedBy"] = null;
            oTemDataIdentifications = null;
            RowIndex = null;
            Operation = Utility.OperationType.Insert;
            Utility.ClearAll(frmIdentifications.Controls);
        }

        public void ClearData(String value = "")
        {
            PrefixSession = value;
            ClearData();
        }

        protected void gvCommonIdentification_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            RowIndex = e.VisibleIndex;

            var GridView = (sender as DevExpress.Web.ASPxGridView);

            GridView.Selection.UnselectAll();

            switch (Commando)
            {
                case "Modify":
                    //Editar                  
                    Operation = Utility.OperationType.Edit;
                    setDataForm(oTemDataIdentifications.ElementAt(RowIndex.Value));
                    gvCommonIdentification.FocusedRowIndex = -1;
                    btnAddIdentification.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar          
                    if ((ObjServices.isNewCase || ObjServices.ContactEntityID.Value < 0) && !ObjServices.IsDataSearch)
                        oTemDataIdentifications.RemoveAt(RowIndex.Value);
                    else
                    {
                        var SeqNo = int.Parse(gvCommonIdentification.GetKeyFromAspxGridView("SeqNo", RowIndex.Value).ToString());
                        ObjServices.oContactManager.DeleteIdDocument(ObjServices.ContactEntityID.Value, SeqNo, ObjServices.UserID.Value);
                    }
                    FillData();

                    break;
            }
        }

        protected void gvCommonIdentification_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnForm.Controls, isReadOnly);
        }

        protected void gvCommonIdentification_PreRender(object sender, EventArgs e)
        {
            Utility.ReadOnlyControls(gvCommonIdentification.Controls, ObjServices.IsReadOnly);
        }

        //private void SetBirthCetificate()
        //{
        //    /*
        //      0 = Other
        //      6 = Birth Certificate             
        //      7 = School Registration               
        //    */
        //    if (cbxIDType.SelectedValue == "6" || cbxIDType.SelectedValue == "0" || cbxIDType.SelectedValue == "7")
        //        txtExpDate.Attributes.Remove("validation");
        //    else
        //        txtExpDate.Attributes.Add("validation", "Required");

        //}

        protected void cbxIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idtype = int.Parse(cbxIDType.SelectedValue);

            if (idtype == 5 || 
                idtype == 6 ||
                idtype == 7 ||
                idtype == 9)
            {
                txtExpDate.Enabled = false;
                txtExpDate.Attributes.Remove("validation");
            }
            else 
            {
                if (idtype == 1)
                {
                    txtIDNumber.Attributes.Add("data-inputmask", "'mask': '999-9999999-9','clearMaskOnLostFocus': true,'showTooltip': true");
                }
                else
                {
                    txtIDNumber.Attributes.Remove("data-inputmask");
                }                   

                txtExpDate.Attributes.Add("validation", "Required");
                txtExpDate.Enabled = true;
            }  
        }
    }
}