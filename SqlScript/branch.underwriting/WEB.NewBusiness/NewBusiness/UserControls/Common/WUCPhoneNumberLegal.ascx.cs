using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCPhoneNumberLegal : UC, IUC
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
        public List<Entity.UnderWriting.Entities.Contact.Phone> TempDataContactPhone = new List<Entity.UnderWriting.Entities.Contact.Phone>();
        #endregion
        public void UpdateUpdatePanel()
        {
            udpPhoneNumberLegal.Update();
        }

        public int? RowIndex
        {
            get { return int.Parse(Session[PrefixSession + "_RowIndexPhoneContact"].ToString()); }
            set { Session[PrefixSession + "_RowIndexPhoneContact"] = value; }
        }

        public Utility.OperationType Operation
        {
            get { return ((Utility.OperationType)Session[PrefixSession + "_OperationPhone"]); }
            set
            {
                Session[PrefixSession + "_OperationPhone"] = value;
                gvCommonPhoneLegal.Enabled = (value == Utility.OperationType.Insert);
                if (currentTab == "PlanPolicy")
                    gvCommonPhoneLegal.Columns[7].Visible = (value == Utility.OperationType.Insert);
            }
        }

        public String PrefixSession
        {
            get { return hdnCurrentSessionLegal.Value; }
            set { hdnCurrentSessionLegal.Value = value; }
        }

        public List<Entity.UnderWriting.Entities.Contact.Phone> oTemDataPhoneContactLegal
        {
            get
            {
                return Session[PrefixSession + "_TemDataPhoneContactLegal"] == null ? 
                    new List<Entity.UnderWriting.Entities.Contact.Phone>() : 
                    Session[PrefixSession + "_TemDataPhoneContactLegal"] as List<Entity.UnderWriting.Entities.Contact.Phone>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.Phone> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.Phone>(
                            Session[PrefixSession + "_TemDataPhoneContactLegal"] != null
                            ?
                            (
                               (List<Entity.UnderWriting.Entities.Contact.Phone>)Session[PrefixSession + "_TemDataPhoneContactLegal"]
                            )
                            :
                            new List<Entity.UnderWriting.Entities.Contact.Phone>()
                      );

                    tempList.AddRange(value);
                }

                Session[PrefixSession + "_TemDataPhoneContactLegal"] = tempList;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Operation = Utility.OperationType.Insert;
                gvCommonPhoneLegal.FocusedRowIndex = -1;
            }
            udpPhoneNumberLegal.Update();
        }

        public void LoadSameDataFromInsured(int? ContactID)
        {
            if (ContactID.HasValue)
            {
                oTemDataPhoneContactLegal = null;

                oTemDataPhoneContactLegal = ObjServices.oContactManager.GetCommunicatonPhone(this.ObjServices.Corp_Id, ContactID.Value, languageId: ObjServices.Language.ToInt()).ToList();

                var data = (from source in oTemDataPhoneContactLegal
                            select new
                            {
                                source.DirectoryId,
                                source.DirectoryDetailId,
                                Type = source.DirectoryTypeDesc,
                                source.CountryCode,
                                source.AreaCode,
                                PhoneNumber = Int64.Parse(source.PhoneNumber.GetNumber()),
                                Ext = source.PhoneExt,
                                source.IsPrimary,
                                imgClassIsPrimary = source.IsPrimary ? "primary_chk" : ""
                            }).ToList();

                hdnTotalPhonesLegal.Value = data.Count().ToString();
                gvCommonPhoneLegal.DataSource = data;
                gvCommonPhoneLegal.DataBind();
                gvCommonPhoneLegal.FocusedRowIndex = -1;
            }
            else
            {
                gvCommonPhoneLegal.DataSource = null;
                gvCommonPhoneLegal.DataBind();
            }

            udpPhoneNumberLegal.Update();
        }

        /// <summary>
        /// Bindear el grid
        /// </summary>
        public void FillData()
        {
            if (ObjServices.Agent_Legal > 0)
            {
                oTemDataPhoneContactLegal = null;
                oTemDataPhoneContactLegal = ObjServices.GetCommunicatonPhoneLegal(ObjServices.Agent_Legal.Value);
            }


            var data = (from source in oTemDataPhoneContactLegal
                        select new
                        {
                            source.DirectoryId,
                            source.DirectoryDetailId,
                            Type = source.DirectoryTypeDesc,
                            source.CountryCode,
                            source.AreaCode,
                            PhoneNumber = Int64.Parse(source.PhoneNumber.GetNumber()),
                            Ext = source.PhoneExt,
                            source.IsPrimary,
                            imgClassIsPrimary = source.IsPrimary ? "primary_chk" : ""
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

            hdnTotalPhonesLegal.Value = data.Count().ToString();
            gvCommonPhoneLegal.DataSource = data;
            gvCommonPhoneLegal.DataBind();
            gvCommonPhoneLegal.Selection.UnselectAll();
            udpPhoneNumberLegal.Update();
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltPhoneType.InnerHtml = Resources.PhoneTypeLabel;
            Primary.InnerHtml = Resources.PrimaryLabel;
            btnAdd.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;
            CountryCode.InnerHtml = Resources.CountryCodeLabel;
            AreaCode.InnerHtml = Resources.AreaCodeLabel;
            PhoneNumber.InnerHtml = Resources.PhoneNumberLabel;
            ltPhoneNumbers.Text = Resources.PhoneNumbersLabel;
            gvCommonPhoneLegal.Columns[0].Caption = Resources.TypeLabel.ToUpper();
            gvCommonPhoneLegal.Columns[1].Caption = Resources.CountryCodeLabel.ToUpper();
            gvCommonPhoneLegal.Columns[2].Caption = Resources.AreaCodeLabel.ToUpper();
            gvCommonPhoneLegal.Columns[3].Caption = Resources.PhoneNumberLabel.ToUpper();
            gvCommonPhoneLegal.Columns[4].Caption = "EXT";
            gvCommonPhoneLegal.Columns[5].Caption = Resources.PrimaryLabel.ToUpper();
            gvCommonPhoneLegal.Columns[6].Caption = Resources.Edit.ToUpper();
            gvCommonPhoneLegal.Columns[7].Caption = Resources.DeleteLabel.ToUpper();

            if (isChangingLang)
            {
                FillDrop();

                if (ObjServices.Agent_Legal < 0)
                    oTemDataPhoneContactLegal.ForEach(x => x.DirectoryTypeDesc = cbxPhoneTypeLegal.Items.FindByValue(x.DirectoryTypeId.ToString()).Text);
                FillData();
            }
        }

        public void save()
        {
            Entity.UnderWriting.Entities.Contact.Phone item = null;

            var record = new Entity.UnderWriting.Entities.Contact.Phone(); 

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataPhoneContactLegal.ElementAt(RowIndex.Value);

            if (cbxPhoneTypeLegal.SelectedValue != "-1" &&
                !string.IsNullOrEmpty(txtCountryCodeLegal.Text) &&
                !string.IsNullOrEmpty(txtCityCode.Text) &&
                !string.IsNullOrEmpty(txtPhoneNumber.Text))
            {

                //Agregar un item
                item = new Entity.UnderWriting.Entities.Contact.Phone()
                {
                    //Key
                    CorpId = ObjServices.Corp_Id,
                    DirectoryId = (Operation == Utility.OperationType.Edit) ? record.DirectoryId : -1,
                    DirectoryDetailId = (Operation == Utility.OperationType.Edit) ? record.DirectoryDetailId : -1,
                    CommunicationType = Utility.CommType.Phone.ToString(),
                    ContactId = ObjServices.Agent_Legal.Value,

                    //Campos 
                    DirectoryTypeId = int.Parse(cbxPhoneTypeLegal.SelectedValue),
                    DirectoryTypeDesc = cbxPhoneTypeLegal.SelectedItem.Text,
                    CountryCode = txtCountryCodeLegal.Text,
                    AreaCode = txtCityCode.Text,
                    PhoneNumber = txtPhoneNumber.Text.Replace("-", ""),
                    PhoneExt = txtExtension.Text,
                    IsPrimary = chkIsPrimary.Checked,

                    //Campo aun Indefinido --Preguntar
                    PersonToContact = null,

                    //Información Usuario
                    CreateUser = (Operation == Utility.OperationType.Insert) ? ObjServices.UserID.Value : record.CreateUser,
                    ModifyUser = (Operation == Utility.OperationType.Edit) ? ObjServices.UserID.Value : record.ModifyUser
                };

                var PhoneNumber = item.CountryCode + item.AreaCode + item.PhoneNumber.Replace("-", "");

                //Si es un nuevo caso  guardar en lista temporal
                if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.Agent_Legal < 0)
                {
                    if (item.IsPrimary)
                        //Quitar todos los que tienen isprimary de true a false                                                
                        foreach (var vrecord in oTemDataPhoneContactLegal)
                            vrecord.IsPrimary = false;

                    if (Operation == Utility.OperationType.Insert)
                    {
                        if (oTemDataPhoneContactLegal.RecordExistInList(x => x.CountryCode + x.AreaCode + x.PhoneNumber.Replace("-", "") == PhoneNumber))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.PhoneAlreadyExist + "',null, null, true, 'Warning')");
                            return;
                        }

                        TempDataContactPhone.Add(item);
                    }
                    else
                        if (Operation == Utility.OperationType.Edit)
                    {

                        List<Entity.UnderWriting.Entities.Contact.Phone> oTemDataPhoneContactLegalEdit;
                        oTemDataPhoneContactLegalEdit = new List<Entity.UnderWriting.Entities.Contact.Phone>(oTemDataPhoneContactLegal);
                        oTemDataPhoneContactLegalEdit.RemoveAt(RowIndex.Value);

                        if (oTemDataPhoneContactLegalEdit.RecordExistInList(x => x.CountryCode + x.AreaCode + x.PhoneNumber.Replace("-", "") == PhoneNumber))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.PhoneAlreadyExist + "',null, null, true, 'Warning')");
                            return;
                        }

                        edit();


                    }

                    oTemDataPhoneContactLegal = TempDataContactPhone;

                }
                else
                {   //Guardar directamente en la base de datos tanto si es un insert como un edit
                    if (Operation == Utility.OperationType.Insert || Operation == Utility.OperationType.Edit)
                    {
                        if (ObjServices.SetPhoneContact(item) == -2)
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.PhoneAlreadyExist + "',null, null, true, 'Warning')");
                            return;
                        }
                        //Limpiar Grid
                        oTemDataPhoneContactLegal = null;

                        if (ObjServices.ContactServicesIsActive)
                        {
                            //Invocar el metodo del webservice para guardar en illusdata
                            ObjServices.oContactServicesClient.SetContactPhone(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()), contactId: Utility.Encrypt(ObjServices.Agent_Legal.ToString()));
                        }

                        if (Operation == Utility.OperationType.Insert)
                            //ir a la ultima pagina
                            gvCommonPhoneLegal.PageIndex = (gvCommonPhoneLegal.PageCount - 1);
                    }
                }

            }
            else if (Operation == Utility.OperationType.InsertAll)
            {
                foreach (var vitem in oTemDataPhoneContactLegal)
                    vitem.ContactId = ObjServices.Agent_Legal.Value;

                ObjServices.SetPhoneContact(oTemDataPhoneContactLegal);
            }

            btnAdd.Text = "Add";
            //Bindear el grid
            FillData();

            //Limpiar los controles a excepcion del grid
            ClearControls(gvCommonPhoneLegal);
            Operation = Utility.OperationType.Insert;
        }

        public void edit()
        {
            var record = oTemDataPhoneContactLegal.ElementAt(RowIndex.Value);
            record.DirectoryTypeId = int.Parse(cbxPhoneTypeLegal.SelectedValue);
            record.DirectoryTypeDesc = cbxPhoneTypeLegal.SelectedItem.Text;
            record.CountryCode = txtCountryCodeLegal.Text;
            record.AreaCode = txtCityCode.Text;
            record.PhoneNumber = txtPhoneNumber.Text.Replace("-", "");
            record.PhoneExt = txtExtension.Text;
            record.IsPrimary = chkIsPrimary.Checked;
        }

        public void FillDrop()
        {
            ObjServices.GettingAllDrops(ref cbxPhoneTypeLegal,
                                        Utility.DropDownType.PhoneType,
                                        "DirTypeShortDesc",
                                        "DirectoryTypeId",
                                        GenerateItemSelect: true,
                                        corpId: ObjServices.Corp_Id
                                        );

        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.Phone item)
        {
            cbxPhoneTypeLegal.SelectedValue = item.DirectoryTypeId.ToString();
            txtCountryCodeLegal.Text = item.CountryCode;
            txtCityCode.Text = item.AreaCode;
            txtPhoneNumber.Text = item.PhoneNumber;
            txtExtension.Text = item.PhoneExt;
            chkIsPrimary.Checked = item.IsPrimary;
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSessionLegal.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            gvCommonPhoneLegal.PageIndex = 0;
            oTemDataPhoneContactLegal = new List<Entity.UnderWriting.Entities.Contact.Phone>();
            Operation = Utility.OperationType.Insert;
            ClearData();
            FillDrop();
            FillData();

            if (ObjServices.IsDataReviewMode)
                EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            save();
        }

        public void ClearData()
        {
            Session[PrefixSession + "_OperationPhone"] = null;
            oTemDataPhoneContactLegal = null;
            RowIndex = null;
            Operation = Utility.OperationType.Insert;
            hdnTotalPhonesLegal.Value = "0";
            ClearControls(this);
        }

        public void ClearData(String value = "")
        {
            PrefixSession = value;
            ClearData();
        }

        public void EnabledControls(bool x)
        {
            EnabledControls(frmPhoneNumbersLegal.Controls, x);
        }

        protected void gvCommonPhoneLegal_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
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
                    setDataForm(oTemDataPhoneContactLegal.ElementAt(RowIndex.Value));
                    gvCommonPhoneLegal.FocusedRowIndex = -1;
                    btnAdd.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar           
                    if ((ObjServices.isNewCase || ObjServices.Agent_Legal < 0) &&
                        !ObjServices.IsDataSearch)
                        oTemDataPhoneContactLegal.RemoveAt(RowIndex.Value);
                    else
                    {
                        var directoryDetailId = int.Parse(gvCommonPhoneLegal.GetKeyFromAspxGridView("DirectoryDetailId", RowIndex.Value).ToString());
                        var directoryId = int.Parse(gvCommonPhoneLegal.GetKeyFromAspxGridView("DirectoryId", RowIndex.Value).ToString());
                        ObjServices.oContactManager.DeleteCommunicaton(ObjServices.Corp_Id, directoryId, directoryDetailId, ObjServices.UserID.Value);
                    }
                    //Llenar Data
                    FillData();
                    break;
            }
        }

        protected void gvCommonPhoneLegal_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(pnForm.Controls, isReadOnly);
        }

        protected void gvCommonPhoneLegal_PreRender(object sender, EventArgs e)
        {
            Utility.ReadOnlyControls(gvCommonPhoneLegal.Controls, ObjServices.IsReadOnly);
        }
    }
}