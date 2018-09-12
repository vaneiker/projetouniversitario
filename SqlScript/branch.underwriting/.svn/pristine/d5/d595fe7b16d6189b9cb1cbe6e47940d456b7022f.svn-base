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
    public partial class WUCBackgroundInformationLegal : UC, IUC 
    {
        #region Variables
        public int CaseSeqNo;
        public int CityId;
        public int ContactId;
        public int Agent_Legal; 
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
                gvCitizenContact_legal.FocusedRowIndex = -1;
            }
            udpBackgroundInformationLegal.Update();
        }

        public int? RowIndex
        {
            get { return int.Parse(Session[PrefixSession + "_RowIndexCitizenContact"].ToString()); }
            set { Session[PrefixSession + "_RowIndexCitizenContact"] = value; }
        }

        public String PrefixSession
        {
            get { return hdnCurrentSession_Legal.Value; }
            set { hdnCurrentSession_Legal.Value = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            RelationshipWithInsured_Legal.InnerHtml = Resources.RelationshipWithInsured;
            ltBackInfo.Text = Resources.BackgorundInformationLabel;
            ltHasAcloseRelationship.Text = Resources.HasAcloseRelationship;
            ltClientIsa.Text = Resources.ClientIsA;
            btnAdd_legal.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;

            //Traducir Grupo 1
            for (int i = 0; i < repeaterClientIsA.Items.Count; i++)
            {
                var lblQuestion = repeaterClientIsA.Items[i].FindControl("lblQuestion_Legal");
                var Position = repeaterClientIsA.Items[i].FindControl("Position_Legal");

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
                var lblQuestion = repeaterHasACloseRelationShipWithA.Items[i].FindControl("lblQuestion_Legal");
                var Position = repeaterHasACloseRelationShipWithA.Items[i].FindControl("Position_Legal");
                var Name = repeaterHasACloseRelationShipWithA.Items[i].FindControl("Name_Legal");                

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
                var lblYes = repeaterQuestion.Items[i].FindControl("lblYes_Legal");
                var lblNo = repeaterQuestion.Items[i].FindControl("lblNo_Legal");
                var lblQuestion = repeaterQuestion.Items[i].FindControl("lblQuestion_Legal");

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

            gvCitizenContact_legal.Columns[0].Caption = Resources.NameLabel.ToUpper();
            gvCitizenContact_legal.Columns[1].Caption = Resources.RelationshipLabel.ToUpper();
            gvCitizenContact_legal.Columns[2].Caption = Resources.Position.ToUpper();
            gvCitizenContact_legal.Columns[3].Caption = Resources.From.ToUpper();
            gvCitizenContact_legal.Columns[4].Caption = Resources.To.ToUpper();
            gvCitizenContact_legal.Columns[5].Caption = Resources.Edit.ToUpper();
            gvCitizenContact_legal.Columns[6].Caption = Resources.DeleteLabel.ToUpper();

            if (isChangingLang)
                FillDrop();

        }

        public void SetVariables()
        {
            this.CaseSeqNo = ObjServices.Case_Seq_No;
            this.CityId = ObjServices.City_Id;
            this.ContactId = ObjServices.Agent_Legal.Value;
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

                var txtPosition = (item.FindControl("txtPosition_Legal") as TextBox);

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

                if (ObjServices.Agent_Legal.Value > 0)
                    ObjServices.oContactManager.UpdateContactSocialExposureByContactJuridico(rec); 

            }

            //Salvar el Grupo2
            foreach (RepeaterItem item in repeaterHasACloseRelationShipWithA.Items)
            {
                int? vSocialFunctionTypeId = null;

                var txtPosition = (item.FindControl("txtPosition_Legal") as TextBox);
                var txtName = (item.FindControl("txtName_Legal") as TextBox);

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

                if (ObjServices.Agent_Legal.Value > 0)
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

                var label = (item.FindControl("lblQuestion_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl);

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



                if (ObjServices.Agent_Legal.Value > 0)
                    ObjServices.oContactManager.UpdateContactCitizenQuestionByContact(rec);
            } 

            foreach (var item in oTemDataCitizenContact)
            {
                item.Contact_Id = this.ContactId;
                item.Case_Seq_No = this.CaseSeqNo;
                item.Hist_Seq_No = this.HistSeqNo;
            }

            ObjServices.SetCitizenContact(oTemDataCitizenContact);
        }

        public void FillDrop()
        {
            if (currentTab == "OwnerInfo" || currentTab == "OwnerInfo")
            {
                ObjServices.GettingAllDrops(ref cbxRelationshipwithinsured_Legal,
                                      Utility.DropDownType.Relationship,
                                      "RelationshipDesc",
                                      "RelationshipId",
                                      GenerateItemSelect: true
                                      );

                ObjServices.GettingAllDrops(ref ddlRelationship_legal,
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

            ObjServices.Agent_Legal = ContactID.Value;

            if (ObjServices.Agent_Legal.HasValue)
            {
                //Grupo 1
                var Grupo1 = ObjServices.oContactManager.GetContactSocialExposureByContactJuridico
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
                     ObjServices.Agent_Legal,
                     languageId: ObjServices.getCurrentLanguage()
                    );

                repeaterClientIsA.DataSource = Grupo1;
                repeaterClientIsA.DataBind();

                //Grupo 2
                var Grupo2 = ObjServices.oContactManager.GetContactSocialExposureRelationshipByContactJuridico(
                     this.CorpId,
                     this.RegionId,
                     this.CountryId,
                     this.DomesticregId,
                     this.StateProvId,
                     this.CityId,
                     this.OfficeId,
                     this.CaseSeqNo,
                     this.HistSeqNo,
                     ObjServices.Agent_Legal
                     , languageId: ObjServices.getCurrentLanguage()
                    );
                repeaterHasACloseRelationShipWithA.DataSource = Grupo2;
                repeaterHasACloseRelationShipWithA.DataBind();


                //Grupo 3
                var Grupo3 = ObjServices.oContactManager.GetContactCitizenQuestionByContactJuridico(
                     this.CorpId,
                     this.RegionId,
                     this.CountryId,
                     this.DomesticregId,
                     this.StateProvId,
                     this.CityId,
                     this.OfficeId,
                     this.CaseSeqNo,
                     this.HistSeqNo,
                     ObjServices.Agent_Legal
                     , languageId: ObjServices.getCurrentLanguage()
                    );

                repeaterQuestion.DataSource = Grupo3.Where(x => x.NameKey != "ISCLIENTPEP");
                repeaterQuestion.DataBind();
                cbxRelationshipwithinsured_Legal.Enabled = false;
            }
            else
            {
                cbxRelationshipwithinsured_Legal.Enabled = true;
                FillDrop();
                ClearControls();
            }

            udpBackgroundInformationLegal.Update();
        }

        public void edit()
        {
            var record = oTemDataCitizenContact.ElementAt(RowIndex.Value);
            record.FullName = txtFullName_legal.Text;
            record.Relationship = int.Parse(ddlRelationship_legal.SelectedValue);
            record.Position = txtPosition_legal.Text;
            record.JobFromDate = DateTime.Parse(txtFrom_legal.Text);
            record.JobToDate = DateTime.Parse(txtTo_legal.Text);
        }

        public void FillData()
        {
            //Grupo 1
            var Grupo1 = ObjServices.GetContactSocialExposureByContactJuridico();

            repeaterClientIsA.DataSource = Grupo1;
            repeaterClientIsA.DataBind();

            //Grupo 2
            var Grupo2 = ObjServices.GetContactSocialExposureRelationshipByContactJuridico();

            repeaterHasACloseRelationShipWithA.DataSource = Grupo2;
            repeaterHasACloseRelationShipWithA.DataBind();


            //Grupo 3
            var Grupo3 = ObjServices.GetContactCitizenQuestionByContactJuridico();

            repeaterQuestion.DataSource = Grupo3.Where(x => x.NameKey != "ISCLIENTPEP");
            repeaterQuestion.DataBind();

            var ContactId = ObjServices.isOwnerContact ? ObjServices.Owner_Id.Value : ObjServices.Agent_Legal.Value;

            if (currentTab == "ClientInfo" || currentTab == "OwnerInfo")
            {
                if (ContactId != -1)
                {
                    var data = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ContactId,languageId:ObjServices.Language.ToInt());
                    if (data != null)
                        cbxRelationshipwithinsured_Legal.SelectIndexByValue(data.RelationshiptoOwner != null ? data.RelationshiptoOwner.ToString() : "-1");

                    FillDataCitizenContact();
                }
            }

        }

        public void FillDataCitizenContact()
        {
            if (ObjServices.Agent_Legal.Value > 0)
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
                    Contact_Id = ObjServices.Agent_Legal.Value,
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

            gvCitizenContact_legal.DataSource = data;
            gvCitizenContact_legal.DataBind();
            gvCitizenContact_legal.Selection.UnselectAll();
            oTemDataCitizenContact = null;
            udpBackgroundInformationLegal.Update();
        }

        public void EnabledControls(bool x)
        {
            Utility.EnableControls(frmGrupo1.Controls, x);
            Utility.EnableControls(frmGrupo2.Controls, x);
            Utility.EnableControlswithoutRecursion(frmBackGroundInformation_Legal.Controls, x);
            udpBackgroundInformationLegal.Update();
        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession_Legal.Value = String.IsNullOrEmpty(value) ? "" : value;
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
            var label1 = e.Item.FindControl("lblYes_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl;
            label1.Attributes.Add("for", RadioButton1.ClientID);

            var RadioButton2 = e.Item.FindControl("rbNo");
            var label2 = e.Item.FindControl("lblNo_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl;
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
            var txtPosition = e.Item.FindControl("txtPosition_Legal") as TextBox;
            var checkMark = e.Item.FindControl("checkboxQuestion_Legal") as CheckBox;
            var positionLabel = e.Item.FindControl("Position_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl;
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
            var txtPosition = e.Item.FindControl("txtPosition_Legal") as TextBox;
            var txtName = e.Item.FindControl("txtName_Legal") as TextBox;
            var checkMark = (e.Item.FindControl("checkboxQuestion_Legal") as CheckBox);

            var Answer = e.Item.DataItem as Entity.UnderWriting.Entities.Contact.SocialExposureRelationship;
            txtPosition.Text = Answer.SocialFunctionTypePosition;
            var positionLabel = e.Item.FindControl("Position_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl;
            positionLabel.InnerHtml = Resources.PositionVal;

            var NameLabel = e.Item.FindControl("Name_Legal") as System.Web.UI.HtmlControls.HtmlGenericControl;
            NameLabel.InnerHtml = Resources.NameLabel;

            txtName.Text = Answer.SocFuncRelName;
            checkMark.Checked = !(string.IsNullOrEmpty(txtPosition.Text.Trim()));
        }


        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(frmGrupo1.Controls, isReadOnly);
            Utility.ReadOnlyControls(frmGrupo2.Controls, isReadOnly);
            Utility.EnableControlswithoutRecursion(frmBackGroundInformation_Legal.Controls, !isReadOnly);
            udpBackgroundInformationLegal.Update();
        }


        public Utility.OperationType Operation
        {
            get
            {
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
                gvCitizenContact_legal.Enabled = (value == Utility.OperationType.Insert);

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
            SetVariables();

            Entity.UnderWriting.Entities.Contact.CitizenContact item = null;

            var record = new Entity.UnderWriting.Entities.Contact.CitizenContact();

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataCitizenContact.ElementAt(RowIndex.Value);

            //Agregar un item
            item = new Entity.UnderWriting.Entities.Contact.CitizenContact()
            {
                Exposure_Related_Id = (Operation == Utility.OperationType.Edit) ? record.Exposure_Related_Id : null,
                Corp_Id = this.CorpId,
                Region_Id = this.RegionId,
                Country_Id = this.CountryId,
                Domesticreg_Id = this.DomesticregId,
                State_Prov_Id = this.StateProvId,
                City_Id = this.CityId,
                Office_Id = this.OfficeId,
                Case_Seq_No = this.CaseSeqNo,
                Hist_Seq_No = this.HistSeqNo,
                Contact_Id = this.ContactId,
                FullName = txtFullName_legal.Text,
                Relationship = int.Parse(ddlRelationship_legal.SelectedValue),
                RelationshipDesc = ddlRelationship_legal.SelectedItem.Text,
                Position = txtPosition_legal.Text,
                JobFromDate = !string.IsNullOrEmpty(txtFrom_legal.Text) ? txtFrom_legal.Text.ParseFormat() : (DateTime?)null,
                JobToDate = !string.IsNullOrEmpty(txtTo_legal.Text) ? txtTo_legal.Text.ParseFormat() : (DateTime?)null,
                CreateUser = (Operation == Utility.OperationType.Insert) ? ObjServices.UserID.Value : record.CreateUser,
                ModifyUser = (Operation == Utility.OperationType.Edit) ? ObjServices.UserID.Value : record.ModifyUser

            };

            //Si es un nuevo caso  guardar en lista temporal
            if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.ContactEntityID < 0)
            {
                if (Operation == Utility.OperationType.Insert)
                {
                    if (oTemDataCitizenContact.RecordExistInList(x => x.FullName == txtFullName_legal.Text))
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

                        if (oTemDataCitizenContactEdit.RecordExistInList(x => x.FullName == txtFullName_legal.Text))
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
                        gvCitizenContact_legal.PageIndex = (gvCitizenContact_legal.PageCount - 1);
                }
            }
            //}


            btnAdd_legal.Text = "Add";
            //Bindear el grid
            FillDataCitizenContact();

            //Limpiar los controles a excepcion del grid
            //ClearControls(gvCitizenContact); 
            txtFullName_legal.Text = string.Empty;
            ddlRelationship_legal.SelectedIndex = -1;
            txtPosition_legal.Text = string.Empty;
            txtFrom_legal.Text = string.Empty;
            txtTo_legal.Text = string.Empty;

            Operation = Utility.OperationType.Insert;
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.CitizenContact item)
        {
            txtFullName_legal.Text = item.FullName;
            ddlRelationship_legal.SelectedValue = item.Relationship.ToString();
            txtPosition_legal.Text = item.Position;
            txtFrom_legal.Text = item.JobFromDate.ToString();
            txtTo_legal.Text = item.JobToDate.ToString();
        }

        #region TempData
           public List<Entity.UnderWriting.Entities.Contact.CitizenContact> TempDataCitizenContact = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>();
        #endregion

        protected void btnAdd_legal_Click(object sender, EventArgs e)
        {
            saveCitizenContact();
        }

        protected void gvCitizenContact_legal_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
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
                    gvCitizenContact_legal.FocusedRowIndex = -1;
                    btnAdd_legal.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar           
                    if ((ObjServices.isNewCase || ObjServices.ContactEntityID < 0) &&
                        !ObjServices.IsDataSearch)
                        oTemDataCitizenContact.RemoveAt(RowIndex.Value);
                    else
                    {
                        var ExposureRelatedId = int.Parse(gvCitizenContact_legal.GetKeyFromAspxGridView("Exposure_Related_Id", RowIndex.Value).ToString());

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
                            Contact_Id = ObjServices.Agent_Legal.Value,
                            Exposure_Related_Id = ExposureRelatedId
                        };


                        ObjServices.oContactManager.DeleteCitizenContact(param);
                    }

                    //Llenar Data
                    FillDataCitizenContact();
                    break;
            }
        }

        protected void gvCitizenContact_legal_PageIndexChanged(object sender, EventArgs e)
        {
            FillDataCitizenContact();

        }

        protected void udpDelete_Unload(object sender, EventArgs e)
        {

        }
    }
}
