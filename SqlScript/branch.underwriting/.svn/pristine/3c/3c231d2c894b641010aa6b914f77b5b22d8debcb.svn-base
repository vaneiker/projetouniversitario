using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls
{
    public partial class WUCBackgroundInformation : UC, IUC
    {
        #region Variables
        public int CaseSeqNo;
        public int CityId;
        public int ContactId;
        public int CorpId;
        public int CountryId;
        public int DomesticregId;
        public int HistSeqNo;
        public int OfficeId;
        public int RegionId;
        public int StateProvId;
        public int UserID;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Operation = Utility.OperationType.Insert;
                oTemDataCitizenContact = null;
                gvCitizenContact.FocusedRowIndex = -1;
            }
            udpBackgroundInformation.Update();
        }

        public int? RowIndex
        {
            get { return int.Parse(Session[PrefixSession + "_RowIndexCitizenContact"].ToString()); }
            set { Session[PrefixSession + "_RowIndexCitizenContact"] = value; }
        }

        public String PrefixSession
        {
            get { return hdnCurrentSession.Value; }
            set { hdnCurrentSession.Value = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            RelationshipWithInsured.InnerHtml = Resources.RelationshipWithInsured;
            ltBackInfo.Text = Resources.BackgorundInformationLabel;
            ltHasAcloseRelationship.Text = Resources.HasAcloseRelationship;
            ltClientIsa.Text = Resources.ClientIsA;
            btnAdd.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;

            //Traducir Grupo 1
            for (int i = 0; i < repeaterClientIsA.Items.Count; i++)
            {
                var lblQuestion = repeaterClientIsA.Items[i].FindControl("lblQuestion");
                var Position = repeaterClientIsA.Items[i].FindControl("Position");

                if (!lblQuestion.isNullReferenceControl())
                {
                    var oQuestion = (lblQuestion as System.Web.UI.HtmlControls.HtmlGenericControl);
                    var NameKey = oQuestion.Attributes["nameKey"];
                    oQuestion.InnerText = Resources.ResourceManager.GetString(NameKey);
                }

                if (!Position.isNullReferenceControl())
                    (Position as System.Web.UI.HtmlControls.HtmlGenericControl).InnerHtml = Resources.PositionVal;

            }

            //Traducir Grupo 2
            for (int i = 0; i < repeaterHasACloseRelationShipWithA.Items.Count; i++)
            {
                var lblQuestion = repeaterHasACloseRelationShipWithA.Items[i].FindControl("lblQuestion");
                var Position = repeaterHasACloseRelationShipWithA.Items[i].FindControl("Position");
                var Name = repeaterHasACloseRelationShipWithA.Items[i].FindControl("Name");                

                if (!lblQuestion.isNullReferenceControl())
                {
                    var oQuestion = (lblQuestion as System.Web.UI.HtmlControls.HtmlGenericControl);
                    var NameKey = oQuestion.Attributes["nameKey"];
                    oQuestion.InnerText = Resources.ResourceManager.GetString(NameKey);
                }

                if (!Position.isNullReferenceControl())
                    (Position as System.Web.UI.HtmlControls.HtmlGenericControl).InnerHtml = Resources.PositionVal;

                if (!Name.isNullReferenceControl())
                    (Name as System.Web.UI.HtmlControls.HtmlGenericControl).InnerHtml = Resources.NameLabel;
            }

            //Traducir  Grupo 3
            for (int i = 0; i < repeaterQuestion.Items.Count; i++)
            {
                var lblYes = repeaterQuestion.Items[i].FindControl("lblYes");
                var lblNo = repeaterQuestion.Items[i].FindControl("lblNo");
                var lblQuestion = repeaterQuestion.Items[i].FindControl("lblQuestion");

                if (!lblQuestion.isNullReferenceControl())
                {
                    var oQuestion = (lblQuestion as System.Web.UI.HtmlControls.HtmlGenericControl);
                    var NameKey = oQuestion.Attributes["nameKey"];
                    oQuestion.InnerText = Resources.ResourceManager.GetString(NameKey);
                }

                if (!lblYes.isNullReferenceControl())
                    (lblYes as System.Web.UI.HtmlControls.HtmlGenericControl).InnerText = Resources.YesLabel;

                if (!lblNo.isNullReferenceControl())
                    (lblNo as System.Web.UI.HtmlControls.HtmlGenericControl).InnerText = Resources.NoLabel;
            }

            lbFullName.InnerHtml = Resources.NameLabel;
            lbRelationship.InnerHtml = Resources.RelationshipLabel;
            lbPosition.InnerHtml = Resources.Position;
            lbFrom.InnerHtml = Resources.From;
            lbTo.InnerHtml = Resources.To;

            gvCitizenContact.Columns[0].Caption = Resources.NameLabel.ToUpper();
            gvCitizenContact.Columns[1].Caption = Resources.RelationshipLabel.ToUpper();
            gvCitizenContact.Columns[2].Caption = Resources.Position.ToUpper();
            gvCitizenContact.Columns[3].Caption = Resources.From.ToUpper();
            gvCitizenContact.Columns[4].Caption = Resources.To.ToUpper();
            gvCitizenContact.Columns[5].Caption = Resources.Edit.ToUpper();
            gvCitizenContact.Columns[6].Caption = Resources.DeleteLabel.ToUpper();

            if (isChangingLang)
                FillDrop();

        }

        public void SetVariables()
        {
            this.CaseSeqNo = ObjServices.Case_Seq_No;
            this.CityId = ObjServices.City_Id;
            this.ContactId = ObjServices.ContactEntityID.Value;
            this.CorpId = ObjServices.Corp_Id;
            this.CountryId = ObjServices.Country_Id;
            this.DomesticregId = ObjServices.Domesticreg_Id;
            this.HistSeqNo = ObjServices.Hist_Seq_No;
            this.OfficeId = ObjServices.Office_Id;
            this.RegionId = ObjServices.Region_Id;
            this.StateProvId = ObjServices.State_Prov_Id;
            this.UserID = ObjServices.UserID.Value;
        }

        public void save()
        {
            if (!ObjServices.IsDataReviewMode)
            {
                if ((currentTab == "OwnerInfo" && ObjServices.Owner_Id == ObjServices.Contact_Id) || ObjServices.IsReadOnly)
                    return;

                var WUCSearch = this.Page.Master.FindControl("bodyContent").FindControl("WUCSearchContacts");
                //Buscar el checkboxes
                var chkchkOwnerIsSameAsInsured = (CheckBox)(WUCSearch as WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo.WUCSearch).FindControl("chkOwnerIsSameAsInsured");
                var chkIsCompany = (CheckBox)(WUCSearch as WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo.WUCSearch).FindControl("chkIsCompany");
            }

            SetVariables();

            //Salvar el Grupo1 CLIENT IS A
            foreach (RepeaterItem item in repeaterClientIsA.Items)
            {
                int? vSocialFunctionTypeId = null;

                var txtPosition = (item.FindControl("txtPosition") as TextBox);

                vSocialFunctionTypeId = int.Parse(txtPosition.Attributes["data-question"].ToString());

                var rec = new Entity.UnderWriting.Entities.Contact.SocialExposure()
                {
                    CaseSeqNo = this.CaseSeqNo,
                    CityId = this.CityId,
                    ContactId = this.ContactId,
                    CorpId = this.CorpId,
                    CountryId = this.CountryId,
                    CreateUser = this.UserID,
                    DomesticregId = this.DomesticregId,
                    HistSeqNo = this.HistSeqNo,
                    ModifyUser = this.UserID,
                    OfficeId = this.OfficeId,
                    RegionId = this.RegionId,
                    StateProvId = this.StateProvId,
                    SocialFunctionTypeId = vSocialFunctionTypeId.Value,
                    SocialFunctionTypePosition = txtPosition.Text
                };

                if (ObjServices.ContactEntityID.Value > 0)
                    ObjServices.oContactManager.UpdateContactSocialExposureByContact(rec);

            }

            //Salvar el Grupo2
            foreach (RepeaterItem item in repeaterHasACloseRelationShipWithA.Items)
            {
                int? vSocialFunctionTypeId = null;

                var txtPosition = (item.FindControl("txtPosition") as TextBox);
                var txtName = (item.FindControl("txtName") as TextBox);

                vSocialFunctionTypeId = int.Parse(txtName.Attributes["data-question"].ToString());

                var rec = new Entity.UnderWriting.Entities.Contact.SocialExposureRelationship()
                {
                    CaseSeqNo = this.CaseSeqNo,
                    CityId = this.CityId,
                    ContactId = this.ContactId,
                    CorpId = this.CorpId,
                    CountryId = this.CountryId,
                    CreateUser = this.UserID,
                    DomesticregId = this.DomesticregId,
                    HistSeqNo = this.HistSeqNo,
                    ModifyUser = this.UserID,
                    OfficeId = this.OfficeId,
                    RegionId = this.RegionId,
                    StateProvId = this.StateProvId,
                    SocialFunctionTypeId = vSocialFunctionTypeId.Value,
                    SocialFunctionTypePosition = txtPosition.Text,
                    SocFuncRelName = txtName.Text
                };

                if (ObjServices.ContactEntityID.Value > 0)
                    ObjServices.oContactManager.UpdateContactSocialExposureRelationshipByContact(rec);
            }

            //Salvar el Grupo3
            foreach (RepeaterItem item in repeaterQuestion.Items)
            {
                int? vCitizenQuestId = null;

                var rbYes = (item.FindControl("rbYes") as RadioButton);

                var rbNo = (item.FindControl("rbNo") as RadioButton);

                bool? Answer = null;

                if (rbYes.Checked)
                    Answer = true;
                else
                    if (rbNo.Checked)
                        Answer = false;

                var label = (item.FindControl("lblQuestion") as System.Web.UI.HtmlControls.HtmlGenericControl);

                vCitizenQuestId = int.Parse(label.Attributes["data-question"].ToString());

                var rec = new Entity.UnderWriting.Entities.Contact.CitizenQuestion()
                {
                    CaseSeqNo = this.CaseSeqNo,
                    CityId = this.CityId,
                    ContactId = this.ContactId,
                    CorpId = this.CorpId,
                    CountryId = this.CountryId,
                    CreateUser = this.UserID,
                    DomesticregId = this.DomesticregId,
                    HistSeqNo = this.HistSeqNo,
                    ModifyUser = this.UserID,
                    OfficeId = this.OfficeId,
                    RegionId = this.RegionId,
                    StateProvId = this.StateProvId,
                    CitizenQuestId = vCitizenQuestId.Value,
                    CitizenQuestAnswer = Answer
                };

                if (ObjServices.ContactEntityID.Value > 0)
                    ObjServices.oContactManager.UpdateContactCitizenQuestionByContact(rec);

              
            }

            foreach (var item in oTemDataCitizenContact)
            {
                item.Contact_Id = this.ContactId;
                item.Case_Seq_No = this.CaseSeqNo;
                item.Hist_Seq_No = this.HistSeqNo;
            }
             
            ObjServices.SetCitizenContact(oTemDataCitizenContact);
            oTemDataCitizenContact.Clear();
        }

        public void FillDrop()
        {

            if (currentTab == "ClientInfo" || currentTab == "OwnerInfo")
            {
                ObjServices.GettingAllDrops(ref cbxRelationshipwithinsured,
                                      Utility.DropDownType.Relationship,
                                      "RelationshipDesc",
                                      "RelationshipId",
                                      GenerateItemSelect: true
                                      );

                ObjServices.GettingAllDrops(ref ddlRelationship,
                               Utility.DropDownType.Relationship,
                               "RelationshipDesc",
                               "RelationshipId",
                               GenerateItemSelect: true
                               );
            }

         
        }

        public void LoadSameDataFromInsured(int? ContactID)
        {
            SetVariables();

            ObjServices.ContactEntityID = ContactID.Value;

            if (ObjServices.ContactEntityID.HasValue)
            {
                //Grupo 1
                var Grupo1 = ObjServices.oContactManager.GetContactSocialExposureByContact
                    (
                     this.CorpId,
                     this.RegionId,
                     this.CountryId,
                     this.DomesticregId,
                     this.StateProvId,
                     this.CityId,
                     this.OfficeId,
                     this.CaseSeqNo,
                     this.HistSeqNo,
                     ObjServices.ContactEntityID,
                     languageId: ObjServices.getCurrentLanguage()
                    );

                repeaterClientIsA.DataSource = Grupo1;
                repeaterClientIsA.DataBind();

                //Grupo 2
                var Grupo2 = ObjServices.oContactManager.GetContactSocialExposureRelationshipByContact(
                     this.CorpId,
                     this.RegionId,
                     this.CountryId,
                     this.DomesticregId,
                     this.StateProvId,
                     this.CityId,
                     this.OfficeId,
                     this.CaseSeqNo,
                     this.HistSeqNo,
                     ObjServices.ContactEntityID
                     , languageId: ObjServices.getCurrentLanguage()
                    );
                repeaterHasACloseRelationShipWithA.DataSource = Grupo2;
                repeaterHasACloseRelationShipWithA.DataBind();


                //Grupo 3
                var Grupo3 = ObjServices.oContactManager.GetContactCitizenQuestionByContact(
                     this.CorpId,
                     this.RegionId,
                     this.CountryId,
                     this.DomesticregId,
                     this.StateProvId,
                     this.CityId,
                     this.OfficeId,
                     this.CaseSeqNo,
                     this.HistSeqNo,
                     ObjServices.ContactEntityID
                     , languageId: ObjServices.getCurrentLanguage()
                    );
                repeaterQuestion.DataSource = Grupo3.Where(x => x.NameKey != "ISCLIENTPEP");;
                repeaterQuestion.DataBind();
                cbxRelationshipwithinsured.Enabled = false;
                 
            }
            else
            {
                cbxRelationshipwithinsured.Enabled = true;
                FillDrop();
                ClearControls();
            }

            udpBackgroundInformation.Update();
        }

        public void edit()
        {
            var record =  oTemDataCitizenContact.ElementAt(RowIndex.Value);
            record.FullName = txtFullName.Text;
            record.Relationship = int.Parse(ddlRelationship.SelectedValue);
            record.Position = txtPosition.Text;
            record.JobFromDate = DateTime.Parse(txtFrom.Text);
            if (string.IsNullOrEmpty(txtTo.Text))
                record.JobToDate = null;
            else
                record.JobToDate = DateTime.Parse(txtTo.Text);
        }

        public void FillData()
        {

            //Grupo 1
            var Grupo1 = ObjServices.GetContactSocialExposureByContact();

            repeaterClientIsA.DataSource = Grupo1;
            repeaterClientIsA.DataBind();

            //Grupo 2
            var Grupo2 = ObjServices.GetContactSocialExposureRelationshipByContact();

            repeaterHasACloseRelationShipWithA.DataSource = Grupo2;
            repeaterHasACloseRelationShipWithA.DataBind();
            
            //Grupo 3
            var Grupo3 = ObjServices.GetContactCitizenQuestionByContact();

            repeaterQuestion.DataSource = Grupo3.Where(x => x.NameKey != "ISCLIENTPEP");
            repeaterQuestion.DataBind();

            var ContactId = ObjServices.isOwnerContact ? ObjServices.Owner_Id.Value : ObjServices.Contact_Id.Value;

            if (currentTab == "ClientInfo" || currentTab == "OwnerInfo")
            {
                if (ContactId != -1)
                {
                    var data = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ContactId,languageId:ObjServices.Language.ToInt());
                    if (data != null)
                        cbxRelationshipwithinsured.SelectIndexByValue(data.RelationshiptoOwner != null ? data.RelationshiptoOwner.ToString() : "-1");

                    FillDataCitizenContact();
                }
            }
        }
         

        /// <summary>
        /// Bindear el grid
        /// </summary>
        public void FillDataCitizenContact()
        {
            if (ObjServices.ContactEntityID > 0)
            {
                oTemDataCitizenContact = null; 

                Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                {
                    Corp_Id = ObjServices.Corp_Id,
                    Region_Id = ObjServices.Region_Id,
                    Country_Id = ObjServices.Country_Id,
                    Domesticreg_Id = ObjServices.Domesticreg_Id,
                    State_Prov_Id = ObjServices.State_Prov_Id,
                    City_Id = ObjServices.City_Id,
                    Office_Id = ObjServices.Office_Id,
                    Case_Seq_No = ObjServices.Case_Seq_No,
                    Hist_Seq_No = ObjServices.Hist_Seq_No,
                    Contact_Id = ObjServices.Contact_Id,
                    Language_id = ObjServices.getCurrentLanguage()
                };

                oTemDataCitizenContact = ObjServices.GetAllCitizenContact(param);
            }

            var data = (from source in oTemDataCitizenContact
                        select new
                        {
                            source.Exposure_Related_Id,
                            source.FullName,
                            source.Relationship,
                            source.RelationshipDesc,
                            source.Position,
                            From = string.Format("{0:MM/dd/yyyy}", source.JobFromDate),
                            To = string.Format("{0:MM/dd/yyyy}", source.JobToDate) 
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

            gvCitizenContact.DataSource = data;
            gvCitizenContact.DataBind();
            gvCitizenContact.Selection.UnselectAll();
            oTemDataCitizenContact = null;
            udpBackgroundInformation.Update();
        }

        public void EnabledControls(bool x)
        {
            Utility.EnableControls(frmGrupo1.Controls, x);
            Utility.EnableControls(frmGrupo2.Controls, x);
            Utility.EnableControlswithoutRecursion(frmBackGroundInformation.Controls, x);
            udpBackgroundInformation.Update();
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            SetVariables();
            FillDrop();
            FillData();
           if (currentTab=="OwnerInfo" && ObjServices.IsDataReviewMode && ObjServices.Contact_Id == ObjServices.Owner_Id)
                EnabledControls(false); 
        }

        public void ClearData()
        {
            ClearControls();
        }

        /// <summary>
        /// Questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repeaterQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {            
            var RadioButton1 = e.Item.FindControl("rbYes");
            var label1 = e.Item.FindControl("lblYes") as System.Web.UI.HtmlControls.HtmlGenericControl;
            label1.Attributes.Add("for", RadioButton1.ClientID);

            var RadioButton2 = e.Item.FindControl("rbNo");
            var label2 = e.Item.FindControl("lblNo") as System.Web.UI.HtmlControls.HtmlGenericControl;
            label2.Attributes.Add("for", RadioButton2.ClientID);

            var data = e.Item.DataItem as Entity.UnderWriting.Entities.Contact.CitizenQuestion;

            var radioYes = (RadioButton1 as RadioButton);
            var radioNo = (RadioButton2 as RadioButton); 

            //Llenar las respuestas
            if (data.CitizenQuestAnswer != null)
            { 
                radioYes.Checked = data.CitizenQuestAnswer.Value;
                radioNo.Checked = !data.CitizenQuestAnswer.Value;
            }
        }
 
 
        /// <summary>
        /// Grupo 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repeaterClientIsA_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Bindear los datos del Grupo1 
            var txtPosition = e.Item.FindControl("txtPosition") as TextBox;
            var checkMark = e.Item.FindControl("checkboxQuestion") as CheckBox;
            var positionLabel = e.Item.FindControl("Position") as System.Web.UI.HtmlControls.HtmlGenericControl;
            positionLabel.InnerHtml = Resources.PositionVal;

            var Answer = e.Item.DataItem as Entity.UnderWriting.Entities.Contact.SocialExposure;
            txtPosition.Text = Answer.SocialFunctionTypePosition;


            checkMark.Checked = !(string.IsNullOrEmpty(txtPosition.Text.Trim()));
        }

        /// <summary>
        /// Grupo 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repeaterHasACloseRelationShipWithA_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Bindear los datos del Grupo2
            var txtPosition = e.Item.FindControl("txtPosition") as TextBox;
            var txtName = e.Item.FindControl("txtName") as TextBox;
            var checkMark = (e.Item.FindControl("checkboxQuestion") as CheckBox);

            var Answer = e.Item.DataItem as Entity.UnderWriting.Entities.Contact.SocialExposureRelationship;
            txtPosition.Text = Answer.SocialFunctionTypePosition;
            var positionLabel = e.Item.FindControl("Position") as System.Web.UI.HtmlControls.HtmlGenericControl;
            positionLabel.InnerHtml = Resources.PositionVal;

            var NameLabel = e.Item.FindControl("Name") as System.Web.UI.HtmlControls.HtmlGenericControl;
            NameLabel.InnerHtml = Resources.NameLabel;

            txtName.Text = Answer.SocFuncRelName;
            checkMark.Checked = !(string.IsNullOrEmpty(txtPosition.Text.Trim()));
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(frmGrupo1.Controls, isReadOnly);
            Utility.ReadOnlyControls(frmGrupo2.Controls, isReadOnly);
            Utility.EnableControlswithoutRecursion(frmBackGroundInformation.Controls, !isReadOnly);
            udpBackgroundInformation.Update();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            saveCitizenContact();
        }

        public Utility.OperationType Operation
        {
            get {
                if (Session[PrefixSession + "_OperationCitizenContact"] == null)
                {
                    return Utility.OperationType.Insert;
                }
                else
                {
                    return ((Utility.OperationType)Session[PrefixSession + "_OperationCitizenContact"]);

                }            
            
            }
            set
            {
                Session[PrefixSession + "_OperationCitizenContact"] = value;
                gvCitizenContact.Enabled = (value == Utility.OperationType.Insert);
                
                //if (currentTab == "PlanPolicy")
                //    gvCitizenContact.Columns[7].Visible = (value == Utility.OperationType.Insert);
            }
        }

        public List<Entity.UnderWriting.Entities.Contact.CitizenContact> oTemDataCitizenContact
        {
            get
            {
                return Session[PrefixSession + "_TemDataCitizenContact"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact.CitizenContact>() :
                    Session[PrefixSession + "_TemDataCitizenContact"] as List<Entity.UnderWriting.Entities.Contact.CitizenContact>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.CitizenContact> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>(
                            Session[PrefixSession + "_TemDataCitizenContact"] != null
                            ?
                            (
                               (List<Entity.UnderWriting.Entities.Contact.CitizenContact>)Session[PrefixSession + "_TemDataCitizenContact"]
                            )
                            :
                            new List<Entity.UnderWriting.Entities.Contact.CitizenContact>()
                      );

                    tempList.AddRange(value);
                }

                Session[PrefixSession + "_TemDataCitizenContact"] = tempList;
            }
        }

        public void saveCitizenContact()
        { 
            Entity.UnderWriting.Entities.Contact.CitizenContact item = null;

            var record = new Entity.UnderWriting.Entities.Contact.CitizenContact();
             
            if (Operation == Utility.OperationType.Edit)
                record = oTemDataCitizenContact.ElementAt(RowIndex.Value);
                  
                //Agregar un item
                item = new Entity.UnderWriting.Entities.Contact.CitizenContact()
                {
                    Exposure_Related_Id = (Operation == Utility.OperationType.Edit) ? record.Exposure_Related_Id : null,
                    Corp_Id = ObjServices.Corp_Id,
                    Region_Id = ObjServices.Region_Id,
                    Country_Id = ObjServices.Country_Id,
                    Domesticreg_Id = ObjServices.Domesticreg_Id,
                    State_Prov_Id = ObjServices.State_Prov_Id,
                    City_Id = ObjServices.City_Id,
                    Office_Id = ObjServices.Office_Id,
                    Case_Seq_No = ObjServices.Case_Seq_No,
                    Hist_Seq_No = ObjServices.Hist_Seq_No,
                    Contact_Id = ObjServices.Contact_Id,
                    FullName = txtFullName.Text,
                    Relationship = int.Parse(ddlRelationship.SelectedValue),
                    RelationshipDesc = ddlRelationship.SelectedItem.Text,
                    Position = txtPosition.Text,
                    JobFromDate = !string.IsNullOrEmpty(txtFrom.Text) ? txtFrom.Text.ParseFormat() : (DateTime?)null,
                    JobToDate = !string.IsNullOrEmpty(txtTo.Text) ? txtTo.Text.ParseFormat() : (DateTime?)null,
                    CreateUser = (Operation == Utility.OperationType.Insert) ? ObjServices.UserID.Value : record.CreateUser,
                    ModifyUser = (Operation == Utility.OperationType.Edit) ? ObjServices.UserID.Value : record.ModifyUser

                };

                //Si es un nuevo caso  guardar en lista temporal
                if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.ContactEntityID < 0)
                {
                    if (Operation == Utility.OperationType.Insert)
                    {
                        if (oTemDataCitizenContact.RecordExistInList(x => x.FullName == txtFullName.Text))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.CitizenContactAlreadyExist + "',null, null, true, 'Warning')");
                            return;
                        }

                        TempDataCitizenContact.Add(item);
                    }
                    else
                        if (Operation == Utility.OperationType.Edit)
                        {
                            List<Entity.UnderWriting.Entities.Contact.CitizenContact> oTemDataCitizenContactEdit;
                            oTemDataCitizenContactEdit = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>(oTemDataCitizenContact);
                            oTemDataCitizenContactEdit.RemoveAt(RowIndex.Value);

                            if (oTemDataCitizenContactEdit.RecordExistInList(x => x.FullName == txtFullName.Text))
                            {
                                this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.CitizenContactAlreadyExist + "',null, null, true, 'Warning')");
                                return;
                            }

                            edit();
                        }

                    oTemDataCitizenContact = TempDataCitizenContact;

                }
                else
                {   //Guardar directamente en la base de datos tanto si es un insert como un edit
                    if (Operation == Utility.OperationType.Insert || Operation == Utility.OperationType.Edit)
                    {
                        //if (ObjServices.SetCitizenContact(item) == -2)
                        //{
                        //    this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.CitizenContactAlreadyExist + "',null, null, true, 'Warning')");
                        //    return;
                        //}
                        oTemDataCitizenContact = null;
                        TempDataCitizenContact.Add(item);
                        oTemDataCitizenContact = TempDataCitizenContact;

                        ObjServices.SetCitizenContact(oTemDataCitizenContact);
                        oTemDataCitizenContact = null;
                        //if (ObjServices.ContactServicesIsActive)
                        //{
                        //    //Invocar el metodo del webservice para guardar en illusdata
                        //    //ObjServices.oContactServicesClient.SetContactPhone(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()), contactId: Utility.Encrypt(ObjServices.ContactEntityID.ToString()));
                           
                        //}

                        if (Operation == Utility.OperationType.Insert)
                            //ir a la ultima pagina
                            gvCitizenContact.PageIndex = (gvCitizenContact.PageCount - 1);
                    }
                }
            //}
           

            btnAdd.Text = "Add";
            //Bindear el grid
            FillDataCitizenContact();  

            //Limpiar los controles a excepcion del grid
            //ClearControls(gvCitizenContact); 
            txtFullName.Text = string.Empty;
            ddlRelationship.SelectedIndex = -1;
            txtPosition.Text = string.Empty;
            txtFrom.Text = string.Empty;
            txtTo.Text = string.Empty;

            Operation = Utility.OperationType.Insert;
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.CitizenContact item)
        {
            txtFullName.Text = item.FullName;
            ddlRelationship.SelectedValue = item.Relationship.ToString();
            txtPosition.Text = item.Position;
            txtFrom.Text = item.JobFromDate.ToString();
            txtTo.Text = item.JobToDate.ToString();
        }
        
        #region TempData
        public List<Entity.UnderWriting.Entities.Contact.CitizenContact> TempDataCitizenContact = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>();
        #endregion

        protected void gvCitizenContact_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
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
                    setDataForm(oTemDataCitizenContact.ElementAt(RowIndex.Value));
                    gvCitizenContact.FocusedRowIndex = -1;
                    btnAdd.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar           
                    if ((ObjServices.isNewCase || ObjServices.ContactEntityID < 0) &&
                        !ObjServices.IsDataSearch)
                        oTemDataCitizenContact.RemoveAt(RowIndex.Value);
                    else
                    {
                        var ExposureRelatedId = int.Parse(gvCitizenContact.GetKeyFromAspxGridView("Exposure_Related_Id", RowIndex.Value).ToString());

                        Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                        {
                            Corp_Id = ObjServices.Corp_Id,
                            Region_Id = ObjServices.Region_Id,
                            Country_Id = ObjServices.Country_Id,
                            Domesticreg_Id = ObjServices.Domesticreg_Id,
                            State_Prov_Id = ObjServices.State_Prov_Id,
                            City_Id = ObjServices.City_Id,
                            Office_Id = ObjServices.Office_Id,
                            Case_Seq_No = ObjServices.Case_Seq_No,
                            Hist_Seq_No = ObjServices.Hist_Seq_No,
                            Contact_Id = ObjServices.Contact_Id,
                            Exposure_Related_Id = ExposureRelatedId
                        };

                      
                        ObjServices.oContactManager.DeleteCitizenContact(param);
                    }

                    //Llenar Data
                    FillDataCitizenContact();
                    break;
            }
        }

        protected void gvCitizenContact_PageIndexChanged(object sender, EventArgs e)
        {
            FillDataCitizenContact();
        }

        protected void udpDelete_Unload(object sender, EventArgs e)
        {

        }         
     
    }
}
