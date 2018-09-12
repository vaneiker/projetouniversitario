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
    public partial class WUCIdentificationLegal : UC, IUC
    {
        protected void UpdatePanel_Unload_Legal(object sender, EventArgs e) 
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

        public class ValidationCedula
        {
            public Boolean ValidCedula { get; set; }
            public Boolean InvalidCedula { get; set; }
        }
        public class ValidationRNC
        {
            public Boolean ValidRNC { get; set; }
            public Boolean InvalidRNC { get; set; }
        }

        public class ValidationDocumentExist
        {
            public Boolean Exists { get; set; }
        }
	
        public String PrefixSession
        {
            get { return hdnCurrentSession_Legal.Value; }
            set { hdnCurrentSession_Legal.Value = value; }
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

            udpIdentification_Legal.Update();
        }

        private ValidationDocumentExist ValidationDocumentExistInBeneficiary(string IdNumber)
        {
            var ExistsItem = new ValidationDocumentExist { Exists = false };
            var data3 = ObjServices.oContactManager.GetAllDocumentIDs(IdNumber);
            var txtDocument = txtIDNumber_Legal.Text.Replace("-", "");
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

        public void LoadSameDataFromInsured(int? Agent_Legal)
        {
            if (!ObjServices.isNewCase)
            {
                oTemDataIdentifications = null;
                oTemDataIdentifications = ObjServices.oContactManager.GetAllIdDocumentInformationJuridico(Agent_Legal.Value, ObjServices.Language.ToInt()).ToList();
            }

            var data = (from source in oTemDataIdentifications
                        select new
                        {
                            source.SeqNo,
                            source.Id,
                            ExpireDate = string.Format("{0:dd/MM/yyyy}", source.ExpireDate),
                            source.DocumentTypeId,
                            source.ContactIdType,
                            source.ContactIdTypeDescription,
                            source.DocumentTypeDescription,
                            source.IssuedBy,
                            source.CountryIssuedByDesc
                        }).ToList();

            hdnTotalIdentification_Legal.Value = data.Count().ToString();
            gvCommonIdentification.DataSource = data;
            gvCommonIdentification.DataBind();
            gvCommonIdentification.FocusedRowIndex = -1;


            udpIdentification_Legal.Update();

        }

        public void FillData()
        {
            /*
             1.- Si no es un nuevo caso 
             2.- Si el contactid es igual a -1             
            */
            if (ObjServices.Agent_Legal > 0)
            {
                oTemDataIdentifications = null;
                oTemDataIdentifications = ObjServices.GetAllIdDocumentInformationJuridico().Where(x => x.ContactIdType == 1).ToList();
            }

            var data = (from source in oTemDataIdentifications
                        select new
                        {
                            source.SeqNo,
                            source.Id,
                            ExpireDate = string.Format("{0:dd/MM/yyyy}", source.ExpireDate),
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

            hdnTotalIdentification_Legal.Value = data.Count().ToString();

            gvCommonIdentification.DataSource = data;
            gvCommonIdentification.DataBind();
            gvCommonIdentification.Selection.UnselectAll();
            udpIdentification_Legal.Update();

        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltIdentifications_Legal.Text = Resources.IdentificationsLabel;
            IDType.InnerHtml = Resources.IDTypeLabel;
            IDNumber.InnerHtml = Resources.IDNumberLabel;
            ExpDate.InnerHtml = Resources.ExpirationDateLabel;
            btnAddIdentification_Legal.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;
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

                if (ObjServices.Agent_Legal < 0)
                    oTemDataIdentifications.ForEach(x => x.ContactIdTypeDescription = cbxIDType_Legal.Items.FindByValue(x.ContactIdType.ToString()).Text);

                FillData();
            }
        }


        /// <summary>
        /// Metodos para validar un Cedula RNC Real
        private ValidationCedula ValidationCedulaValid(string IDCedula)
        {
            var ExistsItem = new ValidationCedula { ValidCedula = false, InvalidCedula = false };
            
            var x = ObjServices.oContactManager.GetResultCedula(IDCedula);

            if ((x.Cedula == 0))
            {
                ExistsItem.InvalidCedula = true;
                return ExistsItem;
            }
            else if (x.Cedula == 1)
            {
                ExistsItem.InvalidCedula = false;
                return ExistsItem;
            }

            return ExistsItem;
        }

        private Common.WUCSaveTab.ValidationRNC ValidationRNCValid(string IDRNC)
        {
            var ExistsItem = new Common.WUCSaveTab.ValidationRNC { ValidRNC = false, InvalidRNC = false };

            var y = ObjServices.oContactManager.GetResultRNC(IDRNC);


            if (y.RNC == 0)
            {
                ExistsItem.InvalidRNC = true;
                return ExistsItem;
            }
            else if (y.RNC == 1)
            {
                ExistsItem.InvalidRNC = false;
                return ExistsItem;
            }

            return ExistsItem;
        }

        public void save()
        {
            Entity.UnderWriting.Entities.Contact.IdDocument item = null;

            var ddlDocument = cbxIDType_Legal.SelectedValue;
            var txtDocument = txtIDNumber_Legal.Text.Replace("-", "");

            //validar fecha de vigencia de documentos
            DateTime FechaActual = DateTime.Today.Date;
            DateTime FechaSeleccionada;

            var typeDoc = cbxIDType_Legal.SelectedValue;

            if (DateTime.TryParse(txtExpDate_Legal.Text, out FechaSeleccionada))
            {
                if ((typeDoc == "1") || (typeDoc == "2") || (typeDoc == "8"))
                {
                    if (FechaSeleccionada < FechaActual)
                    {
                        var Title = ObjServices.Language == Utility.Language.en ? "Information" : "Texto Informativo";
                        string message = "La fecha de vigencia del documento se encuentra expirada.!!!";
                        this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                        return;
                    }
                    else if (FechaSeleccionada == FechaActual)
                    {
                        var Title = ObjServices.Language == Utility.Language.en ? "Information" : "Texto Informativo";
                        string message = "El documento expira el dia de hoy.!!!";
                        this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    }
                }
                else if ((typeDoc == "5") || (typeDoc == "6") || (typeDoc == "7"))
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Date" : "Fecha no valida";
                    string message = "La fecha de vencimiento no aplica para este documento.!!!";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }

            //Validando el Cedula y  RNC
            if (ddlDocument == "1")
            {
                var ValidationCedula = ValidationCedulaValid(txtDocument);
                if (ValidationCedula.InvalidCedula)
                {
                    var msj = "La Cedula {0} del Representante Legal no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, txtIDNumber_Legal.Text) + "\"',null, null, true, 'Warning')");
                    return;

                }
            }
            else if (ddlDocument == "7")
            {
                var ValidationRNC = ValidationRNCValid(txtDocument);
                if (ValidationRNC.InvalidRNC)
                {
                    var msj = "El RNC {0} del Representante Legal no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, txtIDNumber_Legal.Text) + "\"',null, null, true, 'Warning')");
                    return;

                }
            }

            var record = new Entity.UnderWriting.Entities.Contact.IdDocument();

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataIdentifications.ElementAt(RowIndex.Value);

            if (cbxIDType_Legal.SelectedValue != "-1" &&
               cbxIssuedBy_Legal.SelectedValue != "-1" &&
               !txtIDNumber_Legal.isEmpty())
            {
                //Agregar un item
                item = new Entity.UnderWriting.Entities.Contact.IdDocument()
                {
                    //Key
                    ContactId = ObjServices.Agent_Legal.Value,
                    SeqNo = (Operation == Utility.OperationType.Edit) ? record.SeqNo : -1,
                    //Campos 
                    ContactIdType = !string.IsNullOrEmpty(cbxIDType_Legal.SelectedValue) ? int.Parse(cbxIDType_Legal.SelectedValue) : int.Parse("0"),
                    ContactIdTypeDescription = cbxIDType_Legal.SelectedItem.Text,
                    Id = txtIDNumber_Legal.Text,
                    ExpireDate = !string.IsNullOrEmpty(txtExpDate_Legal.Text) ? txtExpDate_Legal.Text.ParseFormat() : (DateTime?)null,
                    IssuedBy = null,
                    MainIdentity = true,
                    CountryIssuedBy = int.Parse(cbxIssuedBy_Legal.SelectedValue),
                    CountryIssuedByDesc = cbxIssuedBy_Legal.SelectedItem.Text,
                    //Información Usuario
                    UserId = ObjServices.UserID.Value
                };

                //Si es un nuevo caso  guardar en lista temporal
                if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.Agent_Legal < 0)
                {
                    if (Operation == Utility.OperationType.Insert)
                    {
                        //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El DUI no se repita a nivel de Pais y tipo de documento
                        if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el DUI y el RNC
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
                                //Validando el DUI y  RNC
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
                        //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El DUI no se repita a nivel de Pais y tipo de documento
                        if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el DUI y el RNC
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
                                //Validando el DUI y  RNC
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
                                //Bmarroquin 04/02/2017 Cambio a raiz de tropicalizacion, Validar que El DUI no se repita a nivel de Pais y tipo de documento
                                if (item.ContactIdType == 1 || item.ContactIdType == 7) //Esta validacion solo fue solicitada para el DUI   y el RNC
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
                                if (ObjServices.oContactManager.CheckIdDocument(ObjServices.Agent_Legal.Value, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                                {
                                    var msj = "El documento {0} ya se encuentra adicionado a la lista";
                                    this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(msj, item.Id) + "\"',null, null, true, 'Warning')");
                                    return;
                                }
                                ObjServices.SetIdentificationsContactJuridico(item);
                            }
                            else if (!string.IsNullOrEmpty(txtExpDate_Legal.Text))
                                ObjServices.SetIdentificationsContactJuridico(item);

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
                            if (ObjServices.oContactManager.CheckIdDocument(ObjServices.Agent_Legal.Value, item.ContactIdType, item.CountryIssuedBy.Value, item.Id))
                            {
                                this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.DocumentIDAlreadyExist, item.Id) + "\"',null, null, true, 'Warning')");
                                return;
                            }
                            else
                            {
                                ObjServices.SetIdentificationsContactJuridico(item);

                            }

                            if (ObjServices.ContactServicesIsActive)
                            {
                                
                                //Invocar el metodo del webservice para guardar en illusdata
                                ObjServices.oContactServicesClient.SetContactIdentificationJuridico(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()),
                                                                                           Agent_Legal: Utility.Encrypt(ObjServices.Agent_Legal.ToString())
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
                    vitem.ContactId = ObjServices.Agent_Legal.Value;

                ObjServices.SetIdentificationsContactJuridico(oTemDataIdentifications);
            }

            btnAddIdentification_Legal.Text = "Add";
            //Bindear el grid
            FillData();

            //Limpiar los controles a excepcion del grid
            ClearControls(gvCommonIdentification);

            Operation = Utility.OperationType.Insert;
        }

        public void edit()
        {
            var record = oTemDataIdentifications.ElementAt(RowIndex.Value);
            record.ContactIdType = int.Parse(cbxIDType_Legal.SelectedValue);
            record.ContactIdTypeDescription = cbxIDType_Legal.SelectedItem.Text;
            record.CountryIssuedBy = cbxIssuedBy_Legal.ToInt();
            record.CountryIssuedByDesc = cbxIssuedBy_Legal.SelectedItem.Text;
            record.Id = txtIDNumber_Legal.Text;
            record.ExpireDate = txtExpDate_Legal.Text.ParseFormat();
        }

        public void FillDrop()
        {
            ObjServices.GettingAllDrops(ref cbxIDType_Legal,
                                    Utility.DropDownType.IdType,
                                    "ContactTypeIdDesc",
                                    "ContactTypeId",
                                    GenerateItemSelect: true,
                                    corpId: ObjServices.Corp_Id);

            ObjServices.GettingAllDrops(ref cbxIssuedBy_Legal,
                                    Utility.DropDownType.IssuedBy,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true,
                                    corpId: ObjServices.Corp_Id);
        }

        public void setDataFormLegal(Entity.UnderWriting.Entities.Contact.IdDocument item)
        {
            cbxIDType_Legal.SelectedValue = item.ContactIdType.ToString();
            txtIDNumber_Legal.Text = item.Id;
            ViewState["idNumber"] = txtIDNumber_Legal.Text;
            ViewState["DocType"] = item.ContactIdType.ToString();
            ViewState["IssuedBy"] = (item.CountryIssuedBy == 0) ? "-1" : item.CountryIssuedBy.ToString();
            txtExpDate_Legal.Text = item.ExpireDate.HasValue ? item.ExpireDate.Value.ToString("dd/MM/yyyy") : string.Empty;
            ViewState["txtExpDate"] = txtExpDate_Legal.Text;
            cbxIssuedBy_Legal.SelectIndexByValue((item.CountryIssuedBy == 0) ? "-1" : item.CountryIssuedBy.ToString());
            isBirthCertificate_Legal.Value = cbxIDType_Legal.SelectedValue == "6" ? "true" : "false";
        }
         

        public void EnabledControls(bool x)
        {
            EnabledControls(frmIdentifications_Legal.Controls, x);
        }

        public void Initialize(String value = "")
        {
            ClearData();
            hdnCurrentSession_Legal.Value = String.IsNullOrEmpty(value) ? "" : value;
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

        protected void btnAddIdentification_Legal_Click(object sender, EventArgs e) 
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
            Utility.ClearAll(frmIdentifications_Legal.Controls);
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
                    setDataFormLegal(oTemDataIdentifications.ElementAt(RowIndex.Value));
                    gvCommonIdentification.FocusedRowIndex = -1;
                    btnAddIdentification_Legal.Text = "Save";
                    //SetBirthCetificate();
                    break;
                case "Delete":
                    //Eliminar          
                    if ((ObjServices.isNewCase || ObjServices.Agent_Legal.Value < 0) && !ObjServices.IsDataSearch)
                        oTemDataIdentifications.RemoveAt(RowIndex.Value);
                    else
                    {
                        var SeqNo = int.Parse(gvCommonIdentification.GetKeyFromAspxGridView("SeqNo", RowIndex.Value).ToString());
                        ObjServices.oContactManager.DeleteIdDocumentJuridico(ObjServices.Agent_Legal.Value, SeqNo, ObjServices.UserID.Value); 
                    }
                    FillData();

                    break;
            }

            //SetBirthCetificate();
        }

        protected void gvCommonIdentification_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnForm_Legal.Controls, isReadOnly);
        }

        protected void gvCommonIdentification_PreRender(object sender, EventArgs e)
        {
            Utility.ReadOnlyControls(gvCommonIdentification.Controls, ObjServices.IsReadOnly);
        }

        private void SetBirthCetificate()
        {
          
            if (cbxIDType_Legal.SelectedValue == "6" || cbxIDType_Legal.SelectedValue == "-1" || cbxIDType_Legal.SelectedValue == "7" || cbxIDType_Legal.SelectedValue == "5" || cbxIDType_Legal.SelectedValue == "9")
                this.txtExpDate_Legal.Attributes.Remove("validation");
            else
                txtExpDate_Legal.Attributes.Add("validation", "Required");

        }

        protected void cbxIDType_Legal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idtype = int.Parse(cbxIDType_Legal.SelectedValue);

            if (idtype == 5 ||
                idtype == 6 ||
                idtype == 7 ||
                idtype == 9)
            {
                txtExpDate_Legal.Enabled = false;
                txtExpDate_Legal.Attributes.Remove("validation");
            }
            else
            {
                if (idtype == 1)
                {
                    txtIDNumber_Legal.Attributes.Add("data-inputmask", "'mask': '999-9999999-9','clearMaskOnLostFocus': true,'showTooltip': true");
                }
                else
                {
                    txtIDNumber_Legal.Attributes.Remove("data-inputmask");
                }

                txtExpDate_Legal.Attributes.Add("validation", "Required");
                txtExpDate_Legal.Enabled = true;
            }  
        }
    }
}