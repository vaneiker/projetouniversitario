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
    public partial class WUCEmailAddressLegal : UC, IUC 
    {
        protected void UpdatePanel_UnloadLegal(object sender, EventArgs e) 
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
        public List<Entity.UnderWriting.Entities.Contact.Email> TempDataContactEmails = new List<Entity.UnderWriting.Entities.Contact.Email>();
        #endregion

        public void UpdateUpdatePanel()
        {
            udpEmailAddressLegal.Update();
        }
        public int? RowIndex
        {
            get { return int.Parse(Session[PrefixSession + "_RowIndexEmailContact"].ToString()); }
            set { Session[PrefixSession + "_RowIndexEmailContact"] = value; }
        }

        public Utility.OperationType Operation
        {
            get { return ((Utility.OperationType)Session[PrefixSession + "_OperationEmail"]); }
            set
            {
                Session[PrefixSession + "_OperationEmail"] = value;
                gvCommonEmailAddress.Enabled = (Operation == Utility.OperationType.Insert);
                if (currentTab == "PlanPolicy")
                    gvCommonEmailAddress.Columns[4].Visible = (value == Utility.OperationType.Insert);
            }
        }

        public String PrefixSession
        {
            get { return hdnCurrentSession_Legal.Value; }
            set { hdnCurrentSession_Legal.Value = value; }
        }

        public List<Entity.UnderWriting.Entities.Contact.Email> oTemDataEmailContact
        {
            get
            {
                return Session[PrefixSession + "_TemDataEmailContactLegal"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact.Email>() :
                    Session[PrefixSession + "_TemDataEmailContactLegal"] as List<Entity.UnderWriting.Entities.Contact.Email>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.Email> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.Email>(Session[PrefixSession + "_TemDataEmailContactLegal"] != null ?
                      ((List<Entity.UnderWriting.Entities.Contact.Email>)Session[PrefixSession + "_TemDataEmailContactLegal"]) :
                      new List<Entity.UnderWriting.Entities.Contact.Email>());
                    tempList.AddRange(value);
                }

                Session[PrefixSession + "_TemDataEmailContactLegal"] = tempList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Operation = Utility.OperationType.Insert;
                gvCommonEmailAddress.FocusedRowIndex = -1;
            }
            udpEmailAddressLegal.Update();
        }

        public void LoadSameDataFromInsured(int? ContactID)
        {
            if (ContactID.HasValue) 
            {
                oTemDataEmailContact = null;

                oTemDataEmailContact = ObjServices.oContactManager.GetCommunicatonEmailJuridico(this.ObjServices.Corp_Id, (int)ContactID, languageId: ObjServices.Language.ToInt()).ToList();
                var data = (from source in oTemDataEmailContact
                            select new
                            {
                                source.DirectoryDetailId,
                                source.DirectoryId,
                                source.CommunicationTypeId,
                                source.CommunicationType,
                                source.DirectoryTypeDesc,
                                source.EmailAdress,
                                source.IsPrimary,
                                imgClassIsPrimary = source.IsPrimary ? "primary_chk" : ""
                            }).ToList();

                hdnTotalEmail_Legal.Value = data.Count().ToString();
                gvCommonEmailAddress.DataSource = data;
                gvCommonEmailAddress.DataBind();
                gvCommonEmailAddress.FocusedRowIndex = -1;
            }
            else
            {
                gvCommonEmailAddress.DataSource = null;
                gvCommonEmailAddress.DataBind();
            }
            udpEmailAddressLegal.Update();
        }


        /// <summary>
        /// Bindear el grid
        /// </summary>
        public void FillData()
        {
            /*
             1.- Si no es un nuevo caso 
             2.- Si el contactid es igual a -1             
            */
            if (ObjServices.Agent_Legal > 0)
            {
                oTemDataEmailContact = null;
                oTemDataEmailContact = ObjServices.GetCommunicationEmailJuridico();
            }

            var data = (from source in oTemDataEmailContact
                        select new
                        {
                            source.DirectoryDetailId,
                            source.DirectoryId,
                            source.CommunicationTypeId,
                            source.CommunicationType,
                            source.DirectoryTypeDesc,
                            source.EmailAdress,
                            source.IsPrimary,
                            imgClassIsPrimary = source.IsPrimary ? "primary_chk" : ""
                        }).ToList();

            if (!ObjServices.isNewCase)
            {
                if (ObjServices.CompanyId != 2)
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
            }

            hdnTotalEmail_Legal.Value = data.Count().ToString();

            gvCommonEmailAddress.DataSource = data;
            gvCommonEmailAddress.DataBind();
            gvCommonEmailAddress.Selection.UnselectAll();
            udpEmailAddressLegal.Update();
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltEmailAddress.Text = Resources.EmailAddressLabel;
            EmailType.InnerHtml = Resources.EmailTypeLabel;
            Primary.InnerHtml = Resources.PrimaryLabel;
            btnAdd_Legal.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;
            EmailAddress.InnerHtml = Resources.EmailAddressLabel;
            gvCommonEmailAddress.Columns[0].Caption = Resources.TypeLabel.ToUpper();
            gvCommonEmailAddress.Columns[1].Caption = Resources.AddressLabel.ToUpper();
            gvCommonEmailAddress.Columns[2].Caption = Resources.PrimaryLabel.ToUpper();
            gvCommonEmailAddress.Columns[3].Caption = Resources.Edit.ToUpper();
            gvCommonEmailAddress.Columns[4].Caption = Resources.DeleteLabel.ToUpper();
            if (isChangingLang)
            {
                FillDrop();

                if (ObjServices.Agent_Legal < 0)
                    oTemDataEmailContact.ForEach(x => x.DirectoryTypeDesc = cbxEmailType_Legal.Items.FindByValue(x.DirectoryTypeId.ToString()).Text);

                FillData();
            }
        }

        public void save()
        {  
            Entity.UnderWriting.Entities.Contact.Email item = null;

            var record = new Entity.UnderWriting.Entities.Contact.Email();

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataEmailContact.ElementAt(RowIndex.Value);

            if (cbxEmailType_Legal.SelectedValue != "-1" &&
               !string.IsNullOrEmpty(txtEmailAddress_Legal.Text)
                )
            {

                if (!Utility.IsEmail(txtEmailAddress_Legal.Text))
                {
                    this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.EmailNotValid + "',500,200,true,'Warning');");
                    return;
                }

                //Agregar un item
                item = new Entity.UnderWriting.Entities.Contact.Email()
                {
                    //Key
                    CorpId = ObjServices.Corp_Id,
                    DirectoryId = (Operation == Utility.OperationType.Edit) ? record.DirectoryId : -1,
                    DirectoryDetailId = (Operation == Utility.OperationType.Edit) ? record.DirectoryDetailId : -1,
                    CommunicationType = Utility.CommType.Email.ToString(),
                    ContactId = ObjServices.Agent_Legal.Value,

                    //Campos 
                    DirectoryTypeId = int.Parse(cbxEmailType_Legal.SelectedValue),
                    DirectoryTypeDesc = cbxEmailType_Legal.SelectedItem.Text,
                    EmailAdress = txtEmailAddress_Legal.Text,
                    IsPrimary = chkIsPrimary_Legal.Checked,

                    //Información Usuario
                    CreateUser = (Operation == Utility.OperationType.Insert) ? ObjServices.UserID.Value : record.CreateUser,
                    ModifyUser = (Operation == Utility.OperationType.Edit) ? ObjServices.UserID.Value : record.ModifyUser
                };


                //Si es un nuevo caso  guardar en lista temporal
                if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.Agent_Legal.Value < 0)
                {
                    if (item.IsPrimary)
                        //Quitar todos los que tienen isprimary de true a false                                                
                        foreach (var vrecord in oTemDataEmailContact)
                            vrecord.IsPrimary = false;

                    if (Operation == Utility.OperationType.Insert)
                    {
                        if (oTemDataEmailContact.RecordExistInList(x => x.EmailAdress == item.EmailAdress))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.EmailAlreadyExist, item.EmailAdress) + "\"',null, null, true, 'Warning')");
                            return;
                        }

                        TempDataContactEmails.Add(item);
                    }
                    else if (Operation == Utility.OperationType.Edit)
                    {

                        List<Entity.UnderWriting.Entities.Contact.Email> oTemDataEmailContactEdit;
                        oTemDataEmailContactEdit = new List<Entity.UnderWriting.Entities.Contact.Email>(oTemDataEmailContact);
                        oTemDataEmailContactEdit.RemoveAt(RowIndex.Value);

                        if (oTemDataEmailContactEdit.RecordExistInList(x => x.EmailAdress == item.EmailAdress))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.EmailAlreadyExist, item.EmailAdress) + "\"',null, null, true, 'Warning')");
                            return;
                        }     
                        edit();
                    }
                    oTemDataEmailContact = TempDataContactEmails;
                }
                else
                {   //Guardar directamente en la base de datos tanto si es un insert como un edit
                    if (Operation == Utility.OperationType.Insert ||
                        Operation == Utility.OperationType.Edit)
                    {
                        if (ObjServices.SetEmailContactJuridico(item) == -2) 
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('\"" + @String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.EmailAlreadyExist, item.EmailAdress) + "\"',null, null, true, 'Warning')");
                            return;
                        }

                        //Limpiar Grid
                        oTemDataEmailContact = null;

                        if (ObjServices.ContactServicesIsActive)
                        {
                            //Invocar el metodo del webservice para guardar en illusdata
                            ObjServices.oContactServicesClient.SetContactEmailJuridico(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()),
                                                                                        Agent_Legal: Utility.Encrypt(ObjServices.Agent_Legal.ToString())
                                                                                       );
                        }

                        if (Operation == Utility.OperationType.Insert)
                            //ir a la ultima pagina
                            gvCommonEmailAddress.PageIndex = (gvCommonEmailAddress.PageCount - 1); 
                    }
                }
            }
            else if (Operation == Utility.OperationType.InsertAll)
            {
                foreach (var vitem in oTemDataEmailContact)
                    vitem.ContactId = ObjServices.Agent_Legal.Value;

                ObjServices.SetEmailContactJuridico(oTemDataEmailContact);
            }

            btnAdd_Legal.Text = "Add";
            //Bindear el grid
            FillData();

            //Limpiar los controles a excepcion del grid
            ClearControls(gvCommonEmailAddress);
            Operation = Utility.OperationType.Insert;
        }

        public void edit()
        {
            var record = oTemDataEmailContact.ElementAt(RowIndex.Value);
            record.DirectoryTypeId = int.Parse(cbxEmailType_Legal.SelectedValue);
            record.DirectoryTypeDesc = cbxEmailType_Legal.SelectedItem.Text;
            record.EmailAdress = txtEmailAddress_Legal.Text;
            record.IsPrimary = chkIsPrimary_Legal.Checked;
        }

        public void FillDrop()
        {
            ObjServices.GettingAllDrops(ref cbxEmailType_Legal,
                                    Utility.DropDownType.EmailType,
                                    "DirTypeShortDesc",
                                    "DirectoryTypeId",
                                    GenerateItemSelect: true,
                                    corpId: this.ObjServices.Corp_Id 
                                    );
        }

        public void EnabledControls(bool x)
        {
            EnabledControls(frmEmailAddress_Legal.Controls, x);
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.Email item)
        {
            cbxEmailType_Legal.SelectedValue = item.DirectoryTypeId.ToString();
            txtEmailAddress_Legal.Text = item.EmailAdress;
            chkIsPrimary_Legal.Checked = item.IsPrimary;
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession_Legal.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            gvCommonEmailAddress.PageIndex = 0;
            oTemDataEmailContact = new List<Entity.UnderWriting.Entities.Contact.Email>();
            Operation = Utility.OperationType.Insert;
            ClearData();
            FillDrop();
            FillData();

            if (ObjServices.IsDataReviewMode)
                EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        protected void btnAdd_Legal_Click(object sender, EventArgs e)
        {
            save();
        }

        public void ClearData()
        {
            Session[PrefixSession + "_OperationEmail"] = null;
            oTemDataEmailContact = null;
            RowIndex = null;
            Operation = Utility.OperationType.Insert;
            hdnTotalEmail_Legal.Value = "0";
            ClearControls(this);
        }

        public void ClearData(String value = "")
        {
            PrefixSession = value;
            ClearData();
        }

        protected void gvCommonEmailAddress_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
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
                    setDataForm(oTemDataEmailContact.ElementAt(RowIndex.Value));
                    gvCommonEmailAddress.FocusedRowIndex = -1;
                    btnAdd_Legal.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar          
                    if ((ObjServices.isNewCase || ObjServices.Agent_Legal.Value < 0) && !ObjServices.IsDataSearch)
                        oTemDataEmailContact.RemoveAt(RowIndex.Value);
                    else
                    {
                        var directoryDetailId = int.Parse(gvCommonEmailAddress.GetKeyFromAspxGridView("DirectoryDetailId", RowIndex.Value).ToString());
                        var directoryId = int.Parse(gvCommonEmailAddress.GetKeyFromAspxGridView("DirectoryId", RowIndex.Value).ToString());
                        ObjServices.oContactManager.DeleteCommunicatonJuridico(ObjServices.Corp_Id, directoryId, directoryDetailId, ObjServices.UserID.Value);
                    }

                    //Llenar Data
                    FillData();

                    break;
            }
        }

        protected void gvCommonEmailAddress_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnForm.Controls, isReadOnly);
        }

        protected void gvCommonEmailAddress_PreRender(object sender, EventArgs e)
        {
            Utility.ReadOnlyControls(gvCommonEmailAddress.Controls, ObjServices.IsReadOnly);
        }
    }
}